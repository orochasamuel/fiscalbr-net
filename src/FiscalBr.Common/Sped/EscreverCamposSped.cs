using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FiscalBr.Common.Sped
{
    public static class EscreverCamposSped
    {
        #region Private Methods

        private enum InformationType
        {
            CodeOrNumber,
            DateTime,
            NullableDateTime,
            Decimal,
            NullableDecimal,
            Generic,
            Hour,
            LiteralEnum,
            MonthAndYear
        }

        /// <summary>
        /// Escrever campo do Registro atual.
        /// </summary>
        /// <param name="valorEscrever">Dado que será inserido na linha a ser escrita.</param>
        /// <param name="info">Informações essenciais para escrita dos dados.<para />
        /// <remarks>
        /// [1] Tipo do atributo.<para />
        /// [2] Tipo da propriedade.<para />
        /// [3] É obrigatório?<para />
        /// [4] Tamanho do campo.<para />
        /// [5] Quantidade de casas decimais.
        /// </remarks>
        /// </param>
        /// <returns>Campo escrito.</returns>
        private static string EscreverCampo(this string valorEscrever,
            Tuple<InformationType, InformationType, bool, int, int> info)
        {
            var hasValue = !string.IsNullOrEmpty(valorEscrever) ||
                           !string.IsNullOrWhiteSpace(valorEscrever);
            var isDecimal = info.Item2 == InformationType.Decimal;
            var isNullableDecimal = info.Item2 == InformationType.NullableDecimal;
            var isDateTime = info.Item2 == InformationType.DateTime;
            var isNullableDateTime = info.Item2 == InformationType.NullableDateTime;
            var isLiteralEnum = info.Item1 == InformationType.LiteralEnum;
            var isHour = info.Item1 == InformationType.Hour;
            var onlyMonthAndYear = info.Item1 == InformationType.MonthAndYear;
            var isRequired = info.Item3;
            var fieldLength = info.Item4;
            var decimalPlaces = info.Item5;
            var decimalPlacesStr = string.Empty.PadLeft(decimalPlaces, '0');
            var cultura = CultureInfo.GetCultureInfo("pt-BR");

            var propertyLength = hasValue ? valorEscrever.Length : 0;


            // Verificação necessária p/ ajustes no tamanho de campos como CSTs e Indicadores. Ex.: CST PIS '1' -> Deve estar no arquivo como '01'.
            var isCodeOrNumberAndHasLength = info.Item2 == InformationType.CodeOrNumber &&
                                             (fieldLength > 0 && fieldLength <= 4);

            //if (isRequired && !hasValue)
            //    throw new Exception(
            //        $"O campo {spedCampoAttr.Ordem} - {spedCampoAttr.Campo} no Registro {registroAtual} é obrigatório e não foi informado!");

            if (!hasValue && isRequired)
                return Constantes.StructuralError;

            if (isRequired && isDecimal &&
                (valorEscrever == string.Empty || valorEscrever.ToDecimal() == 0))
                //return Constantes.VZero.ToString("N" + decimalPlaces);
                return string.Format(cultura, $"{{0:0.{decimalPlacesStr}}}", Constantes.VZero);
            else
            {
                if (isDecimal && hasValue)
                {
                    return string.Format(cultura, $"{{0:0.{decimalPlacesStr}}}", Convert.ToDecimal(valorEscrever));
                    /*
                    var vDecimal =
                        Convert.ToDecimal(valorEscrever).ToString("N" + decimalPlaces);
                    return vDecimal.ToStringSafe().Replace(".", string.Empty);
                    */
                }
                else if (isNullableDecimal && hasValue)
                {
                    return string.Format(cultura, $"{{0:0.{decimalPlacesStr}}}", Convert.ToDecimal(valorEscrever));
                    /*
                    var vDecimal =
                        Convert.ToDecimal(valorEscrever).ToString("N" + decimalPlaces);
                    return vDecimal.ToStringSafe().Replace(".", string.Empty);
                    */
                }
                else if (isNullableDateTime && hasValue)
                    return Convert.ToDateTime(valorEscrever).Date.ToString("ddMMyyyy");
                else if ((isDateTime && hasValue) && isHour)
                    return Convert.ToDateTime(valorEscrever).Date.ToString("hhmmss");
                else if ((isDateTime && hasValue) && onlyMonthAndYear)
                    return Convert.ToDateTime(valorEscrever).Date.ToString("MMyyyy");
                else if (isDateTime && hasValue)
                    return Convert.ToDateTime(valorEscrever).Date.ToString("ddMMyyyy");
                else if ((isCodeOrNumberAndHasLength && hasValue) || (isLiteralEnum && hasValue))
                    return valorEscrever.PadLeft(fieldLength, '0');
                else
                {
                    if (propertyLength > 0 && (propertyLength > fieldLength))
                        return valorEscrever.Substring(0, fieldLength);
                    else
                        return valorEscrever;
                }
            }
        }

        private static InformationType ObtemTipoDoAtributo(SpedCamposAttribute attribute)
        {
            switch (attribute.Tipo)
            {
                case "LE":
                    return InformationType.LiteralEnum;
                case "C":
                case "N":
                    return InformationType.CodeOrNumber;
                case "H":
                    return InformationType.Hour;
                case "MA":
                    return InformationType.MonthAndYear;
            }

            return InformationType.Generic;
        }

        private static InformationType ObtemTipoDaPropriedade(System.Reflection.PropertyInfo property)
        {
            if (property.PropertyType == typeof(decimal))
                return InformationType.Decimal;
            if (property.PropertyType == typeof(decimal?))
                return InformationType.NullableDecimal;
            if (property.PropertyType == typeof(DateTime))
                return InformationType.DateTime;
            if (property.PropertyType == typeof(DateTime?))
                return InformationType.NullableDateTime;
            /*
             * Substituir todos os campos de indicadores por Int16
             */
            if (property.PropertyType == typeof(Int16) ||
                property.PropertyType == typeof(Int16?) ||
                property.PropertyType == typeof(Int32) ||
                property.PropertyType == typeof(Int32?))
                return InformationType.CodeOrNumber;

            return InformationType.Generic;
        }

        private static Type ObtemTipo(object source)
        {
            return source.GetType();
        }

        /// <summary>
        /// Extrai o nome do registro atual. Ex.: RegistroA001 -> Resultado: A001
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        private static string ObtemRegistroAtual(Type tipo)
        {
            if (tipo == null)
                throw new Exception("Falha ao identificar tipo do objeto!");

            // Extrai o nome do registro atual. Ex.: RegistroA001 -> Resultado: A001
            return tipo.Name.Substring(tipo.Name.Length - 4);
        }

        private static SpedRegistrosAttribute ObtemAtributoRegistroAtual(Type tipo)
        {
            return (SpedRegistrosAttribute)Attribute.GetCustomAttribute(tipo, typeof(SpedRegistrosAttribute));
        }

        private static readonly Dictionary<string, SpedCamposAttribute[]> SpedCamposAttributeRepository = new Dictionary<string, SpedCamposAttribute[]>();

        private static SpedCamposAttribute[] GetSpedCamposAttribute(PropertyInfo prop)
        {
            lock (SpedCamposAttributeRepository)
            {
                string propName = $"{prop.DeclaringType.FullName}.{prop.Name}";
                if (!SpedCamposAttributeRepository.ContainsKey(propName))
                    SpedCamposAttributeRepository.Add(propName, (SpedCamposAttribute[])Attribute.GetCustomAttributes(prop, typeof(SpedCamposAttribute)));

                return SpedCamposAttributeRepository[propName];
            }
        }

        private static SpedCamposAttribute ObtemAtributoPropriedadeAtual(PropertyInfo prop, int index = 0)
        {
            return GetSpedCamposAttribute(prop)[index];
        }

        private static bool ExisteAtributoPropriedadeParaVersao(PropertyInfo prop, int versao)
        {
            var attrs = GetSpedCamposAttribute(prop);

            return attrs.Any(a => a.Versao == versao);
        }

        private static int ObtemVersaoPropriedadeAtual(PropertyInfo prop, int index = 0)
        {
            var temp = (SpedCamposAttribute)Attribute.GetCustomAttributes(prop, typeof(SpedCamposAttribute), true)[index];

            return temp.Versao;
        }

        private static SpedCamposAttribute ObtemAtributoPropriedadeVersaoAtual(PropertyInfo prop, int versao)
        {
            var attrs = GetSpedCamposAttribute(prop);

            return attrs.FirstOrDefault(f => f.Versao == versao);
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

        /// <summary>
        /// Verifica obrigatoriedade de escrita do registro. Ex.: M225/M625 -> Obrigatório a partir de 01/10/2015
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        private static bool VerificaObrigatoriedadeRegistro(Tuple<DateTime?, DateTime?, DateTime> datas)
        {
            var obrigatorio = !(datas.Item1.HasValue &&
                (datas.Item1.Value > datas.Item3));

            if (datas.Item2.HasValue &&
                (datas.Item2.Value < datas.Item3.ObterProximoMesPrimeiroDia().AddDays(-1)))
                obrigatorio = false;

            return obrigatorio;
        }

        private static bool SomenteParaLeitura(System.Reflection.PropertyInfo property)
        {
            if (property.PropertyType.BaseType.Equals(typeof(RegistroBaseSped))) return true;

            if (property.PropertyType.IsGenericType &&
                property.PropertyType.GetGenericTypeDefinition() == typeof(List<>)) return true;

            return false;
        }

        #endregion Private Methods

        /// <summary>
        /// Escrever campos p/ qualquer arquivo do projeto SPED (Contábil, Fiscal, Pis/Cofins)
        /// </summary>
        /// <param name="source">Objeto com os dados a serem tratados e gerados na linha do arquivo.</param>
        /// <param name="competenciaDeclaracao">Mês a que se referem as informações no arquivo(exceto informações extemporâneas).</param>
        /// <param name="tryTrim">Remove a quebra de linha no final de cada registro.</param>
        /// <returns>Linha de arquivo SPED escrita e formatada.</returns>
        public static string EscreverCampos(
            this object source,
            DateTime? competenciaDeclaracao = null,
            bool tryTrim = false
            )
        {
            var type = ObtemTipo(source);

            var registroAtual = ObtemRegistroAtual(type);

            var spedRegistroAttr = ObtemAtributoRegistroAtual(type);

            var dataObrigatoriedadeInicial = spedRegistroAttr != null ? spedRegistroAttr.ObrigatoriedadeInicial.ToDateTimeNullable() : null;
            var dataObrigatoriedadeFinal = spedRegistroAttr != null ? spedRegistroAttr.ObrigatoriedadeFinal.ToDateTimeNullable() : null;

            if (!competenciaDeclaracao.HasValue)
                competenciaDeclaracao = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            else
                competenciaDeclaracao = new DateTime(competenciaDeclaracao.Value.Year, competenciaDeclaracao.Value.Month, 1);

            var deveGerarCamposDoRegistro =
                VerificaObrigatoriedadeRegistro(new Tuple<DateTime?, DateTime?, DateTime>(dataObrigatoriedadeInicial,
                    dataObrigatoriedadeFinal, competenciaDeclaracao.Value));

            var listaComPropriedadesOrdenadas = ObtemListaComPropriedadesOrdenadas(type);

            var availableVersions = (VersaoLeiauteSped[])Enum.GetValues(typeof(VersaoLeiauteSped));
            var lastVersion = availableVersions.LastOrDefault();

            var sb = new StringBuilder();
            if (deveGerarCamposDoRegistro)
            {
                foreach (var property in listaComPropriedadesOrdenadas)
                {
                    if (SomenteParaLeitura(property)) continue;

                    sb.Append("|");

                    int versaoEspecifica = lastVersion.ToDefaultValue().ToInt();
                    SpedCamposAttribute spedCampoAttr = null;
                    var attrs = GetSpedCamposAttribute(property);

                    switch (attrs.Length)
                    {
                        case 0:
                            break;
                        case 1:
                            spedCampoAttr = ObtemAtributoPropriedadeAtual(property);
                            break;
                        default:
                            while (!ExisteAtributoPropriedadeParaVersao(property, versaoEspecifica))
                            {
                                versaoEspecifica--;

                                if (versaoEspecifica < 1)
                                    break;
                            }

                            spedCampoAttr = ObtemAtributoPropriedadeVersaoAtual(property, versaoEspecifica);
                            break;
                    }

                    if (spedCampoAttr == null)
                        throw new Exception(string.Format(
                            "O campo {0} no registro {1} não possui atributo SPED definido!", property.Name, registroAtual));

                    var propertyValue = RegistroBaseSped.GetPropValue(source, property.Name);
                    var propertyValueToStringSafe = propertyValue.ToStringSafe().Trim();

                    var isRequired = spedCampoAttr.IsObrigatorio;
                    var campoEscrito =
                        propertyValueToStringSafe.EscreverCampo(
                            new Tuple<
                                InformationType,
                                InformationType,
                                bool,
                                int,
                                int>(
                                ObtemTipoDoAtributo(spedCampoAttr),
                                ObtemTipoDaPropriedade(property),
                                isRequired,
                                spedCampoAttr.Tamanho,
                                spedCampoAttr.QtdCasas
                                ));

                    if (campoEscrito == Constantes.StructuralError)
                        throw new Exception(string.Format(
                            "O campo {0} - {1} no Registro {2} é obrigatório e não foi informado!", spedCampoAttr.Ordem, spedCampoAttr.Campo, registroAtual));

                    sb.Append(campoEscrito);
                }
                sb.Append("|");
                sb.Append(Environment.NewLine);
            }

            return tryTrim ? sb.ToString().Trim() : sb.ToString();
        }

        /// <summary>
        /// Escrever campos p/ qualquer arquivo do projeto SPED (Contábil, Fiscal, Pis/Cofins)
        /// </summary>
        /// <param name="source">Objeto com os dados a serem tratados e gerados na linha do arquivo.</param>
        /// <param name="version">Versão desejada para geração das linhas do arquivo.</param>
        /// <param name="competenciaDeclaracao">Mês a que se referem as informações no arquivo(exceto informações extemporâneas).</param>
        /// <param name="tryTrim">Remove a quebra de linha no final de cada registro.</param>
        /// <returns>Linha de arquivo SPED escrita e formatada.</returns>
        public static string EscreverCampos(
            this object source,
            VersaoLeiauteSped version,
            DateTime? competenciaDeclaracao = null,
            bool tryTrim = false,
            bool ignoreErrors = false
            )
        {
            var type = ObtemTipo(source);

            var registroAtual = ObtemRegistroAtual(type);

            var spedRegistroAttr = ObtemAtributoRegistroAtual(type);

            var dataObrigatoriedadeInicial = spedRegistroAttr != null ? spedRegistroAttr.ObrigatoriedadeInicial.ToDateTimeNullable() : null;
            var dataObrigatoriedadeFinal = spedRegistroAttr != null ? spedRegistroAttr.ObrigatoriedadeFinal.ToDateTimeNullable() : null;

            if (!competenciaDeclaracao.HasValue)
                competenciaDeclaracao = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            else
                competenciaDeclaracao = new DateTime(competenciaDeclaracao.Value.Year, competenciaDeclaracao.Value.Month, 1);

            var deveGerarCamposDoRegistro =
                VerificaObrigatoriedadeRegistro(new Tuple<DateTime?, DateTime?, DateTime>(dataObrigatoriedadeInicial,
                    dataObrigatoriedadeFinal, competenciaDeclaracao.Value));

            var sb = new StringBuilder();
            if (deveGerarCamposDoRegistro)
            {
                var listaComPropriedadesOrdenadas = ObtemListaComPropriedadesOrdenadas(type);

                foreach (var property in listaComPropriedadesOrdenadas)
                {
                    if (SomenteParaLeitura(property)) continue;

                    int versaoEspecifica = version.ToDefaultValue().ToInt();
                    SpedCamposAttribute spedCampoAttr = null;

                    var attrs = GetSpedCamposAttribute(property);

                    if (attrs.Length > 0)
                    {
                        if (ExisteAtributoPropriedadeParaVersao(property, versaoEspecifica))
                        {
                            spedCampoAttr = ObtemAtributoPropriedadeVersaoAtual(property, versaoEspecifica);
                        }
                        else
                        {
                            while (!ExisteAtributoPropriedadeParaVersao(property, versaoEspecifica))
                            {
                                versaoEspecifica--;

                                if (versaoEspecifica < 1)
                                    break;
                            }

                            spedCampoAttr = ObtemAtributoPropriedadeVersaoAtual(property, versaoEspecifica);
                        }
                    }
                    else
                    {
                        if (ignoreErrors == false)
                            throw new Exception(string.Format(
                                "O campo {0} no registro {1} não possui atributo SPED definido!", property.Name, registroAtual));
                    }

                    if (spedCampoAttr != null)
                    {
                        sb.Append("|");
                        var propertyValue = RegistroBaseSped.GetPropValue(source, property.Name);
                        var propertyValueToStringSafe = propertyValue.ToStringSafe().Trim();

                        var isRequired = spedCampoAttr.IsObrigatorio;
                        var campoEscrito =
                            propertyValueToStringSafe.EscreverCampo(
                                new Tuple<
                                    InformationType,
                                    InformationType,
                                    bool,
                                    int,
                                    int>(
                                    ObtemTipoDoAtributo(spedCampoAttr),
                                    ObtemTipoDaPropriedade(property),
                                    isRequired,
                                    spedCampoAttr.Tamanho,
                                    spedCampoAttr.QtdCasas
                                    ));

                        if (ignoreErrors == false)
                            if (campoEscrito == Constantes.StructuralError)
                                throw new Exception(string.Format(
                                    "O campo {0} - {1} no Registro {2} é obrigatório e não foi informado!", spedCampoAttr.Ordem, spedCampoAttr.Campo, registroAtual));

                        sb.Append(campoEscrito);
                    }
                    spedCampoAttr = null;
                }
                sb.Append("|");
                sb.Append(Environment.NewLine);

                return tryTrim ? sb.ToString().Trim() : sb.ToString();
            }

            return null;
        }

        /// <summary>
        /// Escrever campos p/ qualquer arquivo do projeto SPED (Contábil, Fiscal, Pis/Cofins)
        /// </summary>
        /// <param name="source">Objeto com os dados a serem tratados e gerados na linha do arquivo.</param>
        /// <param name="errosEncontrados">Lista com erros encontrados no processo de escrita.</param>
        /// <param name="competenciaDeclaracao">Mês a que se referem as informações no arquivo(exceto informações extemporâneas).</param>
        /// <param name="tryTrim">Remove a quebra de linha no final de cada registro.</param>
        /// <returns>Linha de arquivo SPED escrita e formatada.</returns>
        public static string EscreverCampos(
            this object source,
            out string errosEncontrados,
            DateTime? competenciaDeclaracao = null,
            bool tryTrim = false
            )
        {
            errosEncontrados = string.Empty;

            var type = ObtemTipo(source);

            var registroAtual = ObtemRegistroAtual(type);

            var spedRegistroAttr = ObtemAtributoRegistroAtual(type);

            var dataObrigatoriedadeInicial = spedRegistroAttr != null ? spedRegistroAttr.ObrigatoriedadeInicial.ToDateTimeNullable() : null;
            var dataObrigatoriedadeFinal = spedRegistroAttr != null ? spedRegistroAttr.ObrigatoriedadeFinal.ToDateTimeNullable() : null;

            if (!competenciaDeclaracao.HasValue)
                competenciaDeclaracao = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            else
                competenciaDeclaracao = new DateTime(competenciaDeclaracao.Value.Year, competenciaDeclaracao.Value.Month, 1);

            var deveGerarCamposDoRegistro =
                VerificaObrigatoriedadeRegistro(new Tuple<DateTime?, DateTime?, DateTime>(dataObrigatoriedadeInicial,
                    dataObrigatoriedadeFinal, competenciaDeclaracao.Value));

            var listaComPropriedadesOrdenadas = ObtemListaComPropriedadesOrdenadas(type);

            var availableVersions = (VersaoLeiauteSped[])Enum.GetValues(typeof(VersaoLeiauteSped));
            var lastVersion = availableVersions.LastOrDefault();

            var sb = new StringBuilder();
            if (deveGerarCamposDoRegistro)
            {
                foreach (var property in listaComPropriedadesOrdenadas)
                {
                    if (SomenteParaLeitura(property)) continue;

                    sb.Append("|");

                    int versaoEspecifica = lastVersion.ToDefaultValue().ToInt();
                    SpedCamposAttribute spedCampoAttr = null;
                    var attrs = GetSpedCamposAttribute(property);

                    if (attrs.Length > 0)
                    {
                        if (attrs.Length == 1)
                        {
                            spedCampoAttr = ObtemAtributoPropriedadeAtual(property);
                        }
                        else
                        {
                            if (ExisteAtributoPropriedadeParaVersao(property, versaoEspecifica))
                            {
                                spedCampoAttr = ObtemAtributoPropriedadeVersaoAtual(property, versaoEspecifica);
                            }
                            else
                            {
                                while (!ExisteAtributoPropriedadeParaVersao(property, versaoEspecifica))
                                {
                                    versaoEspecifica--;

                                    if (versaoEspecifica < 1)
                                        break;
                                }

                                spedCampoAttr = ObtemAtributoPropriedadeVersaoAtual(property, versaoEspecifica);
                            }
                        }
                    }

                    if (spedCampoAttr == null)
                        throw new Exception(string.Format(
                            "O campo {0} no registro {1} não possui atributo SPED definido!", property.Name, registroAtual));

                    var propertyValue = RegistroBaseSped.GetPropValue(source, property.Name);
                    var propertyValueToStringSafe = propertyValue.ToStringSafe().Trim();

                    var isRequired = spedCampoAttr.IsObrigatorio;
                    var campoEscrito =
                        propertyValueToStringSafe.EscreverCampo(
                            new Tuple<
                                InformationType,
                                InformationType,
                                bool,
                                int,
                                int>(
                                ObtemTipoDoAtributo(spedCampoAttr),
                                ObtemTipoDaPropriedade(property),
                                isRequired,
                                spedCampoAttr.Tamanho,
                                spedCampoAttr.QtdCasas
                                ));

                    if (campoEscrito == Constantes.StructuralError)
                        errosEncontrados +=
                                string.Format("O campo {0} - {1} no Registro {2} é obrigatório e não foi informado!\n", spedCampoAttr.Ordem, spedCampoAttr.Campo, registroAtual);
                    else
                        sb.Append(campoEscrito);
                }
            }
            sb.Append("|");
            sb.Append(Environment.NewLine);

            if (errosEncontrados.Length > 0)
                errosEncontrados =
                    string.Format("Registro {0} -  Contém os seguintes erros: \n{1}", source.GetType().FullName, errosEncontrados);

            return tryTrim ? sb.ToString().Trim() : sb.ToString();
        }

        /// <summary>
        /// Escrever campos p/ qualquer arquivo do projeto SPED (Contábil, Fiscal, Pis/Cofins)
        /// </summary>
        /// <param name="source">Objeto com os dados a serem tratados e gerados na linha do arquivo.</param>
        /// <param name="version">Versão desejada para geração das linhas do arquivo.</param>
        /// <param name="errosEncontrados">Lista com erros encontrados no processo de escrita.</param>
        /// <param name="competenciaDeclaracao">Mês a que se referem as informações no arquivo(exceto informações extemporâneas).</param>
        /// <param name="tryTrim">Remove a quebra de linha no final de cada registro.</param>
        /// <returns>Linha de arquivo SPED escrita e formatada.</returns>
        public static string EscreverCampos(
            this object source,
            VersaoLeiauteSped version,
            out string errosEncontrados,
            DateTime? competenciaDeclaracao = null,
            bool tryTrim = false
            )
        {
            errosEncontrados = string.Empty;

            var type = ObtemTipo(source);

            var registroAtual = ObtemRegistroAtual(type);

            var spedRegistroAttr = ObtemAtributoRegistroAtual(type);

            var dataObrigatoriedadeInicial = spedRegistroAttr != null ? spedRegistroAttr.ObrigatoriedadeInicial.ToDateTimeNullable() : null;
            var dataObrigatoriedadeFinal = spedRegistroAttr != null ? spedRegistroAttr.ObrigatoriedadeFinal.ToDateTimeNullable() : null;

            if (!competenciaDeclaracao.HasValue)
                competenciaDeclaracao = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            else
                competenciaDeclaracao = new DateTime(competenciaDeclaracao.Value.Year, competenciaDeclaracao.Value.Month, 1);

            var deveGerarCamposDoRegistro =
                VerificaObrigatoriedadeRegistro(new Tuple<DateTime?, DateTime?, DateTime>(dataObrigatoriedadeInicial,
                    dataObrigatoriedadeFinal, competenciaDeclaracao.Value));

            var listaComPropriedadesOrdenadas = ObtemListaComPropriedadesOrdenadas(type);

            var sb = new StringBuilder();
            if (deveGerarCamposDoRegistro)
            {
                foreach (var property in listaComPropriedadesOrdenadas)
                {
                    if (SomenteParaLeitura(property)) continue;

                    sb.Append("|");

                    int versaoEspecifica = version.ToDefaultValue().ToInt();
                    SpedCamposAttribute spedCampoAttr = null;
                    var attrs = GetSpedCamposAttribute(property);

                    if (attrs.Length > 0)
                    {
                        if (attrs.Length == 1)
                        {
                            spedCampoAttr = ObtemAtributoPropriedadeAtual(property);
                        }
                        else
                        {
                            if (ExisteAtributoPropriedadeParaVersao(property, versaoEspecifica))
                            {
                                spedCampoAttr = ObtemAtributoPropriedadeVersaoAtual(property, versaoEspecifica);
                            }
                            else
                            {
                                while (!ExisteAtributoPropriedadeParaVersao(property, versaoEspecifica))
                                {
                                    versaoEspecifica--;

                                    if (versaoEspecifica < 1)
                                        break;
                                }

                                spedCampoAttr = ObtemAtributoPropriedadeVersaoAtual(property, versaoEspecifica);
                            }
                        }
                    }

                    if (spedCampoAttr == null)
                        throw new Exception(string.Format(
                            "O campo {0} no registro {1} não possui atributo SPED definido!", property.Name, registroAtual));

                    var propertyValue = RegistroBaseSped.GetPropValue(source, property.Name);
                    var propertyValueToStringSafe = propertyValue.ToStringSafe().Trim();

                    var isRequired = spedCampoAttr.IsObrigatorio;
                    var campoEscrito =
                        propertyValueToStringSafe.EscreverCampo(
                            new Tuple<
                                InformationType,
                                InformationType,
                                bool,
                                int,
                                int>(
                                ObtemTipoDoAtributo(spedCampoAttr),
                                ObtemTipoDaPropriedade(property),
                                isRequired,
                                spedCampoAttr.Tamanho,
                                spedCampoAttr.QtdCasas
                                ));

                    if (campoEscrito == Constantes.StructuralError)
                        errosEncontrados +=
                                string.Format("O campo {0} - {1} no Registro {2} é obrigatório e não foi informado!\n", spedCampoAttr.Ordem, spedCampoAttr.Campo, registroAtual);
                    else
                        sb.Append(campoEscrito);
                }
            }
            sb.Append("|");
            sb.Append(Environment.NewLine);

            if (errosEncontrados.Length > 0)
                errosEncontrados =
                    string.Format("Registro {0} -  Contém os seguintes erros: \n{1}", source.GetType().FullName, errosEncontrados);

            return tryTrim ? sb.ToString().Trim() : sb.ToString();
        }
    }
}