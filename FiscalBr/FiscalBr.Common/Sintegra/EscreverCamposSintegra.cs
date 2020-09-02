using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiscalBr.Common.Sintegra
{
    public static class EscreverCamposSintegra
    {
        /// <summary>
        /// Escrever campos p/ arquivo SINTEGRA
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string EscreverCampos(this object source)
        {
            var type = source.GetType();

            if (type == null)
                throw new Exception("Falha ao identificar tipo do objeto!");

            // Extrai o nome do registro atual. Ex.: Registro10 -> Resultado: 10
            var registroAtual = type.Name.Substring(type.Name.Length - 2);

            /*
             * http://stackoverflow.com/questions/22306689/get-properties-of-class-by-order-using-reflection
             */
            var listaComPropriedadesOrdenadas =
                type.GetProperties().OrderBy(p => p.GetCustomAttributes(typeof(SintegraCamposAttribute), true)
                    .Cast<SintegraCamposAttribute>()
                    .Select(a => a.Ordem)
                    .FirstOrDefault())
                    .ToList();

            var sb = new StringBuilder();
            foreach (var property in listaComPropriedadesOrdenadas)
            {
                foreach (
                    var sintegraCampoAttr in
                        from Attribute attr in property.GetCustomAttributes(true) select attr as SintegraCamposAttribute
                    )
                {
                    if (sintegraCampoAttr == null)
                        throw new Exception(
                            $"O campo {property.Name} no registro tipo {registroAtual} não possui atributo SINTEGRA definido!");

                    var propertyValue = RegistroBaseSintegra.GetPropValue(source, property.Name);
                    var propertyValueToStringSafe = propertyValue.ToStringSafe().Trim();

                    var isRequired = sintegraCampoAttr.IsObrigatorio;
                    var isDecimal = property.PropertyType == typeof(decimal);
                    var isNullableDecimal = property.PropertyType == typeof(decimal?);
                    var isDateTime = property.PropertyType == typeof(DateTime);
                    var isNullableDateTime = property.PropertyType == typeof(DateTime?);
                    var hasValue = !string.IsNullOrEmpty(propertyValueToStringSafe) ||
                                   !string.IsNullOrWhiteSpace(propertyValueToStringSafe);

                    var propertyLength = hasValue
                        ? propertyValueToStringSafe.Length
                        : 0;

                    // Verificação necessária p/ ajustes no tamanho de campos.
                    var isCode = sintegraCampoAttr.Tipo == "X";
                    var isNumber = sintegraCampoAttr.Tipo == "N";
                    var isPartialDate = sintegraCampoAttr.Tipo == "DP";

                    //if (isRequired && !hasValue)
                    //    throw new Exception(
                    //        $"O campo {sintegraCampoAttr.Ordem} - {sintegraCampoAttr.Campo} no Registro Tipo {registroAtual} é obrigatório e não foi informado!");

                    const decimal vZero = 0M;
                    if (isRequired && isDecimal &&
                        (propertyValueToStringSafe == string.Empty || propertyValueToStringSafe.ToDecimal() == 0))
                        sb.Append(
                            vZero.ToString("N" + sintegraCampoAttr.QtdCasas)
                                .Replace(",", "")
                                .PadLeft(sintegraCampoAttr.Tamanho, '0'));
                    else
                    {
                        if (isDecimal)
                        {
                            if (!hasValue)
                                sb.Append(0.ToStringSafe().PadLeft(sintegraCampoAttr.Tamanho, '0'));
                            else
                            {
                                var vDecimal =
                                    Convert.ToDecimal(propertyValue).ToString("N" + sintegraCampoAttr.QtdCasas);
                                sb.Append(
                                    vDecimal.ToStringSafe()
                                        .Replace(".", "")
                                        .Replace(",", "")
                                        .PadLeft(sintegraCampoAttr.Tamanho, '0'));
                            }
                        }
                        else if (isNullableDecimal)
                        {
                            if (!hasValue)
                                sb.Append(0.ToStringSafe().PadLeft(sintegraCampoAttr.Tamanho, '0'));
                            else
                            {
                                var vDecimal =
                                    Convert.ToDecimal(propertyValue).ToString("N" + sintegraCampoAttr.QtdCasas);
                                sb.Append(
                                    vDecimal.ToStringSafe()
                                        .Replace(".", "")
                                        .Replace(",", "")
                                        .PadLeft(sintegraCampoAttr.Tamanho, '0'));
                            }
                        }
                        else if (isDateTime && hasValue)
                            sb.Append(isPartialDate
                                ? Convert.ToDateTime(propertyValue).Date.ToString("MMyyyy")
                                : Convert.ToDateTime(propertyValue).Date.ToString("yyyyMMdd"));
                        else if (isNullableDateTime && hasValue)
                            sb.Append(Convert.ToDateTime(propertyValue).Date.ToString("yyyyMMdd"));
                        else if (isCode)
                            sb.Append(propertyValueToStringSafe.Length > sintegraCampoAttr.Tamanho
                                ? propertyValueToStringSafe.Substring(0, sintegraCampoAttr.Tamanho)
                                : propertyValueToStringSafe.PadRight(sintegraCampoAttr.Tamanho, ' '));
                        else if (isNumber && hasValue)
                        {
                            var valueProp = propertyValue.ToString().Replace(".", "").Replace(",", "");
                            sb.Append(valueProp.Length > sintegraCampoAttr.Tamanho
                                ? valueProp.Substring(0, sintegraCampoAttr.Tamanho)
                                : valueProp.PadLeft(sintegraCampoAttr.Tamanho, '0'));
                        }
                        else
                        {
                            if (propertyLength > 0 && (propertyLength > sintegraCampoAttr.Tamanho))
                                sb.Append(propertyValueToStringSafe.Substring(0, sintegraCampoAttr.Tamanho));
                            else
                                sb.Append(propertyValueToStringSafe);
                        }
                    }
                }
            }
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}