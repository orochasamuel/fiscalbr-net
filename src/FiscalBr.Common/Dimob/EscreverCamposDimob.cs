using FiscalBr.Common;
using System;
using System.Linq;
using System.Text;

namespace FiscalBr.Common.Dimob
{
    public static class EscreverCamposDimob
    {
        #region Convenções de Formato e Tamanho dos Campos

        /*    R$ - Campo numérico de 14 posições, onde as 12 primeiras posições são
         * a parte inteira com zeros à esquerda; e as 2 últimas são a parte decimal
         * com zeros à direita. Se vazio, preencher com zeros. Somente aceita valor
         * maior ou igual a zero.
         * 
         *    DATA - Campo do tipo Data, com formato DDMMAAAA.
         *    
         *    ANO - Campo numérico, com 4 posições. Válidos 2005 a ano declarado.
         *    
         *    X - Campo alfanumérico com tamanho especificado na descrição, alinhado
         * à esquerda com brancos a direita.
         * 
         *    N - Campo numérico com tamanho especificado na descrição, alinhado à
         * direita, com zeros à esquerda. Se vazio, preencher com zeros.
         * 
         *    CPF - Campo numérico com 11 posições. CPF válido.
         *    
         *    CNPJ - Campo numérico com 14 posições.
         *    
         *    CPF/CNPJ - Campo numéricos com 14 posições, se CNPJ. Com 11 posições,
         * alinhado à esquerda com brancos à direita, se CPF.
         * 
         *    CPF/CNPJ2 - Campo numéricos com 14 posições, se CNPJ. Com 11 posições,
         * alinhado à esquerda com brancos à direita, se CPF. Aceita NDP - Não 
         * Domiciliado no País.
         * 
         *    EOL - Sequência de caracteres Hexadecimais 0D0A, delimitar de registro.   
         */

        #endregion

        /// <summary>
        /// Escrever campos p/ arquivo DIMOB.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string EscreverCampos(this object source)
        {
            var type = source.GetType();

            if (type == null)
                throw new Exception("Falha ao identificar tipo do objeto!");

            // Extrai o nome do registro atual. Ex.: DimobR01 -> Resultado: R01
            var registroAtual = type.Name.Substring(type.Name.Length - 3);

            /*
             * http://stackoverflow.com/questions/22306689/get-properties-of-class-by-order-using-reflection
             */
            var listaComPropriedadesOrdenadas =
                type.GetProperties().OrderBy(p => p.GetCustomAttributes(typeof(DimobCamposAttribute), true)
                    .Cast<DimobCamposAttribute>()
                    .Select(a => a.Ordem)
                    .FirstOrDefault())
                    .ToList();

            var sb = new StringBuilder();

            foreach (var property in listaComPropriedadesOrdenadas)
            {
                foreach (
                    var dimobCampoAttr in
                        from Attribute attr in property.GetCustomAttributes(true) select attr as DimobCamposAttribute
                    )
                {
                    if (dimobCampoAttr == null)
                        throw new Exception(
                            string.Format("O campo {0} no registro {1} não possui atributo DIMOB definido!", property.Name, registroAtual));

                    var propertyValue = RegistroBaseDimob.GetPropValue(source, property.Name);
                    var propertyValueToStringSafe = propertyValue.ToStringSafe().Trim();
                    var hasValue = !string.IsNullOrEmpty(propertyValueToStringSafe) ||
                                   !string.IsNullOrWhiteSpace(propertyValueToStringSafe);

                    var isDecimal = property.PropertyType == typeof(decimal);
                    var isDateTime = property.PropertyType == typeof(DateTime);
                    var isNullableDateTime = property.PropertyType == typeof(DateTime?);
                    var isNumeric = dimobCampoAttr.Formato == "N";
                    var isCpfOrCnpj = dimobCampoAttr.Formato.Contains("CPF") || dimobCampoAttr.Formato.Contains("CNPJ");

                    const decimal vZero = 0M;
                    if (isDecimal && (!hasValue || propertyValueToStringSafe.ToDecimal() == 0))
                        sb.Append(vZero.RetornaCampoDecimalFormatado2String());
                    else
                    {
                        if (isNumeric)
                            sb.Append(propertyValueToStringSafe.PadLeft(dimobCampoAttr.Tamanho, '0'));
                        else if (isCpfOrCnpj)
                            sb.Append(propertyValueToStringSafe.DeletarCaracteres(new[] { ".", "/", "-" }).PadRight(dimobCampoAttr.Tamanho, ' '));
                        else if (isDecimal)
                        {
                            var vDecimal = Convert.ToDecimal(propertyValue);
                            sb.Append(vDecimal.RetornaCampoDecimalFormatado2String());
                        }
                        else if ((isDateTime || isNullableDateTime) && hasValue)
                        {
                            var vDate = Convert.ToDateTime(propertyValue);
                            sb.Append(vDate.RetornaCampoDataFormatado2String());
                        }
                        else
                        {
                            if (propertyValueToStringSafe.Length > 0 &&
                                (propertyValueToStringSafe.Length > dimobCampoAttr.Tamanho))
                                sb.Append(propertyValueToStringSafe.Substring(0, dimobCampoAttr.Tamanho));
                            else
                                sb.Append(propertyValueToStringSafe.PadRight(dimobCampoAttr.Tamanho, ' '));
                        }
                    }
                }
            }


            return sb.ToString();
        }

        private static string RetornaCampoDataFormatado2String(this DateTime data)
        {
            return data.Date.ToString("ddMMyyyy");
        }

        private static string RetornaCampoDecimalFormatado2String(this decimal valor)
        {
            return valor.ToString("N2").Replace(",", string.Empty).Replace(".", string.Empty).PadLeft(14, '0');
        }
    }
}
