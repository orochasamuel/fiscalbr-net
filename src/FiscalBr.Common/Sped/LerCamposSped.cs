using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace FiscalBr.Common.Sped
{
    public static class LerCamposSped
    {
        public static object LerCampos(this string line, string file = "EFDFiscal", int codVersao = 0)
        {
            line = line.TrimStart().Substring(1);

            line = line.Remove(line.LastIndexOf('|'));

            var splittedLine = line.Split('|');

            // Retorna o registro sem os 'pipes'. Ex: |0000| -> 0000
            var registro = line.Substring(0, line.IndexOf('|', 1));

            var bloco = registro.Substring(0, 1);

            var toInstantiate = $"FiscalBr.{file}.Bloco{bloco}+Registro{registro}, FiscalBr.{file}";

            var objectType = Type.GetType(toInstantiate);

            var instantiatedObject = Activator.CreateInstance(objectType);

            var properties = ObtemListaComPropriedadesOrdenadas(objectType, codVersao);

            for (int i = 0; i < properties.Count; i++)
            {
                var prop = properties[i];

                bool conversionResult = true;

                object value = splittedLine[i];

                if (prop.CanWrite)
                {
                    var propType = prop.PropertyType;

                    //Trata campos nullable com valor vazio
                    if (propType.IsNullable() && (value == null || string.IsNullOrEmpty(value.ToString())))
                        prop.SetValue(instantiatedObject, null);

                    else if (propType == typeof(Int32) || propType == typeof(Nullable<Int32>))
                    {
                        int convertedInt32Value;
                        conversionResult = Int32.TryParse(value.ToStringSafe(), out convertedInt32Value);
                        prop.SetValue(instantiatedObject, convertedInt32Value);
                    }

                    else if (propType == typeof(Int64) || propType == typeof(Nullable<Int64>))
                    {
                        int convertedInt32Value;
                        conversionResult = Int32.TryParse(value.ToStringSafe(), out convertedInt32Value);

                        if (propType == typeof(Nullable<Int64>))
                            prop.SetValue(instantiatedObject, (Nullable<Int64>)convertedInt32Value);
                        else
                            prop.SetValue(instantiatedObject, convertedInt32Value);
                    }

                    else if (propType == typeof(DateTime) || propType == typeof(Nullable<DateTime>))
                    {
                        var dateToConvert = value.ToStringSafe();

                        if (dateToConvert.Length == 6) //MA -< MM/yyyy, Ex: E250 - MES_REF
                            dateToConvert = $"01{dateToConvert}";

                        dateToConvert = dateToConvert.Insert(2, "/").Insert(5, "/");
                        DateTime convertedDateTimeValue;
                        conversionResult = DateTime.TryParse(dateToConvert, out convertedDateTimeValue);
                        prop.SetValue(instantiatedObject, convertedDateTimeValue);
                    }

                    else if (propType.IsEnum)
                    {
                        foreach (var currentEnumItem in propType.GetEnumValues())
                        {
                            MemberInfo memberInfo = propType.GetMember(currentEnumItem.ToString()).FirstOrDefault();

                            if (memberInfo != null)
                            {
                                DefaultValueAttribute attribute = (DefaultValueAttribute)
                                             memberInfo.GetCustomAttributes(typeof(DefaultValueAttribute), false)
                                                       .FirstOrDefault();

                                if (attribute != null)
                                {
                                    if (attribute.Value.ToString() == value.ToString())
                                    {
                                        var convertedEnum = Enum.Parse(propType, currentEnumItem.ToString());

                                        prop.SetValue(instantiatedObject, convertedEnum);
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    else if (propType == typeof(Decimal) || propType == typeof(Nullable<Decimal>))
                    {
                        Decimal convertedDecimalValue;
                        System.Globalization.NumberStyles style = System.Globalization.NumberStyles.Number;
                        conversionResult = Decimal.TryParse(value.ToStringSafe(), style, System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), out convertedDecimalValue);
                        
                        if (propType == typeof(Nullable<Decimal>))
                            prop.SetValue(instantiatedObject, (Nullable<Decimal>)convertedDecimalValue);
                        else
                            prop.SetValue(instantiatedObject, convertedDecimalValue);
                    }
                    else if (propType == typeof(Double) || propType == typeof(Nullable<Double>))
                    {
                        Double convertedDoubleValue;
                        System.Globalization.NumberStyles style = System.Globalization.NumberStyles.Number;
                        conversionResult = Double.TryParse(value.ToStringSafe(), style, System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), out convertedDoubleValue);

                        if (propType == typeof(Nullable<Double>))
                            prop.SetValue(instantiatedObject, (Nullable<Double>)convertedDoubleValue);
                        else
                            prop.SetValue(instantiatedObject, convertedDoubleValue);
                    }
                    else if (propType == typeof(Int32) || propType == typeof(Nullable<Int32>))
                    {
                        int convertedInt32Value;
                        conversionResult = Int32.TryParse(value.ToStringSafe(), out convertedInt32Value);
                        prop.SetValue(instantiatedObject, convertedInt32Value);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(value.ToStringSafe()))
                            prop.SetValue(instantiatedObject, null, null);
                        else
                            prop.SetValue(instantiatedObject, value, null);
                    }
                }
            }

            return instantiatedObject;
        }

        public static bool IsNullable<T>(this T obj)
        {
            /*
             * https://stackoverflow.com/questions/374651/how-to-check-if-an-object-is-nullable/4131871
             */

            if (obj == null) return true; // obvious
            Type type = typeof(T);
            if (!type.IsValueType) return true; // ref-type
            if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
            return false; // value-type
        }

        public static List<System.Reflection.PropertyInfo> ObtemListaComPropriedadesOrdenadas(Type tipo, int codVersao = 0)
        {
            var r = tipo.GetProperties()
             .Where(p => Attribute.IsDefined(p, typeof(SpedCamposAttribute))); //Só quero os campos do tipo SpedCamposAttribute, ignorando registros filhos!

            if (codVersao > 0)
            {
                r = r.Where(x => x.GetCustomAttributes(typeof(SpedCamposAttribute), true)
                .Cast<SpedCamposAttribute>()
                .Any(a => a.Versao <= codVersao));

            }

            r = r.OrderBy(p => p.GetCustomAttributes(typeof(SpedCamposAttribute), true)
                .Cast<SpedCamposAttribute>()
                .Select(a => a.Ordem)
                .FirstOrDefault());

            return r.ToList();

            /*
             * http://stackoverflow.com/questions/22306689/get-properties-of-class-by-order-using-reflection
             */
            //return tipo.GetProperties()
            //    .Where(p => Attribute.IsDefined(p, typeof(SpedCamposAttribute))) //Só quero os campos do tipo SpedCamposAttribute, ignorando registros filhos!
            //    .OrderBy(p => p.GetCustomAttributes(typeof(SpedCamposAttribute), true)
            //    .Cast<SpedCamposAttribute>()
            //    .Select(a => a.Ordem)
            //    .FirstOrDefault())
            //    .ToList();
        }
    }
}
