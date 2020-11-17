using System;
using System.Collections.Generic;
using System.Linq;

namespace FiscalBr.Common.Sped
{
    public static class LerCamposSped
    {
        public static object LerCampos(this string line, string file = "EFDFiscal")
        {
            line = line.Substring(1);

            line = line.Remove(line.LastIndexOf('|'));

            var splittedLine = line.Split('|');
            
            // Retorna o registro sem os 'pipes'. Ex: |0000| -> 0000
            var registro = line.Substring(0, line.IndexOf('|', 1));

            var bloco = registro.Substring(0, 1);

            var toInstantiate = $"FiscalBr.{file}.Bloco{bloco}+Registro{registro}, FiscalBr.{file}";

            var objectType = Type.GetType(toInstantiate);

            var instantiatedObject = Activator.CreateInstance(objectType);

            var properties = ObtemListaComPropriedadesOrdenadas(objectType);

            for (int i = 0; i < properties.Count; i++)
            {
                var prop = properties[i];

                bool conversionResult = true;

                object value = splittedLine[i];

                if (prop.CanWrite)
                {
                    var propType = prop.PropertyType;

                    if (propType == typeof(Int32))
                    {
                        int convertedInt32Value;
                        conversionResult = Int32.TryParse(value.ToStringSafe(), out convertedInt32Value);
                        prop.SetValue(instantiatedObject, convertedInt32Value);
                    }
                    else if (propType == typeof(DateTime))
                    {
                        var dateToConvert = value.ToStringSafe().Insert(2, "/").Insert(5, "/");
                        DateTime convertedDateTimeValue;
                        conversionResult = DateTime.TryParse(dateToConvert, out convertedDateTimeValue);
                        prop.SetValue(instantiatedObject, convertedDateTimeValue);
                    }
                    else if (propType.IsEnum)
                    {
                        var convertedEnum = Enum.Parse(propType, value.ToStringSafe());

                        prop.SetValue(instantiatedObject, convertedEnum);
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

        private static List<System.Reflection.PropertyInfo> ObtemListaComPropriedadesOrdenadas(Type tipo)
        {
            /*
             * http://stackoverflow.com/questions/22306689/get-properties-of-class-by-order-using-reflection
             */
            return tipo.GetProperties().OrderBy(p => p.GetCustomAttributes(typeof(SpedCamposAttribute), true)
                .Cast<SpedCamposAttribute>()
                .Select(a => a.Ordem)
                .FirstOrDefault())
                .ToList();
        }
    }
}
