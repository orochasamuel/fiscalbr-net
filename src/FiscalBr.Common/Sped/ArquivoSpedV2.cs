using FiscalBr.Common.Sped.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FiscalBr.Common.Sped
{
    public abstract class ArquivoSpedV2 : IArquivoSped, ISped
    {
        private readonly Dictionary<string, SpedCamposAttribute[]> CachedSpedCamposAttribute;

        public string NomeSoftwareHouse { get; private set; }
        public string CnpjSoftwareHouse { get; private set; }
        public LeiauteArquivoSped ArquivoSped { get; private set; }
        public CodigoVersaoLeiaute VersaoLeiaute { get; private set; }

        public List<string> Erros { get; private set; }
        public List<string> Linhas { get; private set; }

        public ArquivoSpedV2(
            LeiauteArquivoSped leiauteSped
            )
        {
            ArquivoSped = leiauteSped;

            Erros = new List<string>();
            Linhas = new List<string>();

            CachedSpedCamposAttribute = new Dictionary<string, SpedCamposAttribute[]>();
        }

        public ArquivoSpedV2(
            CodigoVersaoLeiaute versaoLeiaute, 
            LeiauteArquivoSped leiauteSped
            ) : this(leiauteSped)
        {
            VersaoLeiaute = versaoLeiaute;
        }

        public ArquivoSpedV2(
            CodigoVersaoLeiaute versaoLeiaute, 
            LeiauteArquivoSped leiauteSped, 
            string nomeSoftwareHouse
            ) : this(versaoLeiaute, leiauteSped)
        {
            // TODO: Transformar em objeto
            NomeSoftwareHouse = nomeSoftwareHouse;
        }

        public ArquivoSpedV2(
            CodigoVersaoLeiaute versaoLeiaute, 
            LeiauteArquivoSped leiauteSped, 
            string nomeSoftwareHouse, 
            string cnpjSoftwareHouse
            ) : this(versaoLeiaute, leiauteSped, nomeSoftwareHouse)
        {
            // TODO: Transformar em objeto
            CnpjSoftwareHouse = cnpjSoftwareHouse;
        }

        //private bool EhPropriedadeSomenteLeitura(System.Reflection.PropertyInfo property)
        //{
        //    if (property.PropertyType.BaseType.Equals(typeof(RegistroSped))) return true;

        //    if (property.PropertyType.IsGenericType &&
        //        property.PropertyType.GetGenericTypeDefinition() == typeof(List<>)) return true;

        //    return false;
        //}

        //private Type ObterTipo(object source)
        //{
        //    return source.GetType();
        //}

        ///// <summary>
        ///// Extrai o nome do registro atual. Ex.: RegistroA001 -> Resultado: A001
        ///// </summary>
        ///// <param name="tipo"></param>
        ///// <returns></returns>
        //private string ObtemRegistroAtual(Type tipo)
        //{
        //    if (tipo == null)
        //        throw new Exception("Falha ao identificar tipo do objeto!");

        //    // Extrai o nome do registro atual. Ex.: RegistroA001 -> Resultado: A001
        //    return tipo.Name.Substring(tipo.Name.Length - 4);
        //}

        //private SpedRegistrosAttribute ObterAtributoRegistroAtual(Type tipo)
        //{
        //    return (SpedRegistrosAttribute)Attribute.GetCustomAttribute(tipo, typeof(SpedRegistrosAttribute));
        //}

        //private List<System.Reflection.PropertyInfo> ObterListaComPropriedadesOrdenadas(Type t)
        //{
        //    /*
        //     * http://stackoverflow.com/questions/22306689/get-properties-of-class-by-order-using-reflection
        //     */
        //    return t.GetProperties().OrderBy(p => p.GetCustomAttributes(typeof(SpedCamposAttribute), true)
        //        .Cast<SpedCamposAttribute>()
        //        .Select(a => a.Ordem)
        //        .FirstOrDefault())
        //        .ToList();
        //}

        //private CodigoVersaoLeiaute[] ObterVersoesDisponiveisLeiaute()
        //{
        //    return (CodigoVersaoLeiaute[])Enum.GetValues(typeof(CodigoVersaoLeiaute));
        //}

        //private int ObterUltimaVersaoLeiaute()
        //{
        //    return ObterVersoesDisponiveisLeiaute().LastOrDefault().ToDefaultValue().ToInt();
        //}

        //private int ObterVersaoEspecificaLeiaute(CodigoVersaoLeiaute? versaoEspecifica)
        //{
        //    if ((versaoEspecifica ?? 0 ) == 0 )
        //        return ObterUltimaVersaoLeiaute();

        //    return versaoEspecifica.ToDefaultValue().ToInt();
        //}

        //private SpedCamposAttribute[] GetSpedCamposAttribute(PropertyInfo prop)
        //{
        //    lock (CachedSpedCamposAttribute)
        //    {
        //        string propName = $"{prop.DeclaringType.FullName}.{prop.Name}";
        //        if (!CachedSpedCamposAttribute.ContainsKey(propName))
        //            CachedSpedCamposAttribute.Add(propName, (SpedCamposAttribute[])Attribute.GetCustomAttributes(prop, typeof(SpedCamposAttribute)));

        //        return CachedSpedCamposAttribute[propName];
        //    }
        //}

        //private SpedCamposAttribute ObtemAtributoPropriedadeAtualPorIndice(PropertyInfo prop, int index = 0)
        //{
        //    return GetSpedCamposAttribute(prop)[index];
        //}

        //private bool ExisteAtributoPropriedadeParaVersao(PropertyInfo prop, int versao)
        //{
        //    return GetSpedCamposAttribute(prop).Any(a => a.Versao == versao);
        //}

        //private SpedCamposAttribute ObtemAtributoPropriedadeAtualPorVersao(PropertyInfo prop, int versao)
        //{
        //    return GetSpedCamposAttribute(prop).FirstOrDefault(f => f.Versao == versao);
        //}

        #region Private Methods

        private string Pipe()
        {
            return "|";
        }

        private string NewLine()
        {
            return Environment.NewLine;
        }

        private bool IsCodeOrNumber(string v)
        {
            return v == Constantes.ArquivoDigital.Sped.TipoInformacao.CodeOrNumber;
        }

        private bool IsDateTime(string v)
        {
            return v == Constantes.ArquivoDigital.Sped.TipoInformacao.DateTime ||
                v == Constantes.ArquivoDigital.Sped.TipoInformacao.NullableDateTime;
        }

        private bool IsDecimal(string v)
        {
            return v == Constantes.ArquivoDigital.Sped.TipoInformacao.Decimal ||
                v == Constantes.ArquivoDigital.Sped.TipoInformacao.NullableDecimal;
        }

        private bool IsHour(string v)
        {
            return v == Constantes.ArquivoDigital.Sped.TipoInformacao.Hour;
        }

        private bool IsLiteralEnum(string v)
        {
            return v == Constantes.ArquivoDigital.Sped.TipoInformacao.LiteralEnum;
        }

        private bool IsMonthAndYear(string v)
        {
            return v == Constantes.ArquivoDigital.Sped.TipoInformacao.MonthAndYear;
        }

        #endregion Private Methods

        public string PreencherCampo(string valor, string tpAttr, string tpProp, int tamanho, int qtdCasas, bool ehObrigatorio)
        {
            //if (ehObrigatorio && !valor.HasValue())
            //    return Constantes.StructuralError;

            //if (ehObrigatorio && IsDecimal(tpProp) && (valor.HasValue() && valor.ToDecimal() == 0))
            //    return FormatarCampoDecimal(Constantes.VZero, qtdCasas);
            //else if (IsDecimal(tpProp) && valor.HasValue())
            //    return FormatarCampoDecimal(Convert.ToDecimal(valor), qtdCasas);
            //else if (IsDateTime(tpProp) && valor.HasValue())
            //{
            //    if (IsHour(tpAttr))
            //        return Convert.ToDateTime(valor).ToString("hhmmss");
            //    else if (IsMonthAndYear(tpAttr))
            //        return Convert.ToDateTime(valor).ToString("MMyyyy");
            //    else
            //        return Convert.ToDateTime(valor).ToString("ddMMyyyy");
            //}
            //else if (IsCodeOrNumber(tpAttr) && tamanho > 0 && tamanho <= 4 ||
            //          IsLiteralEnum(tpAttr) && valor.HasValue())
            //    return valor.PadLeft(tamanho, '0');
            //else if (valor.Length > 0 && valor.Length > tamanho)
            //    return valor.Substring(0, tamanho);
            //else
            //    return valor;

            if (ehObrigatorio && !valor.HasValue())
                return Constantes.StructuralError;

            if (IsCodeOrNumber(tpAttr))
                if (valor.Length <= tamanho)
                    return valor.PadLeft(tamanho, '0');

            if (IsDateTime(tpProp))
                if (IsHour(tpAttr))
                    return FormatarCampoDateTime(Convert.ToDateTime(valor), "hhmmss");
                else if (IsMonthAndYear(tpAttr))
                    return FormatarCampoDateTime(Convert.ToDateTime(valor), "MMyyyy");
                else
                    return FormatarCampoDateTime(Convert.ToDateTime(valor), "ddMMyyyy");

            if (IsDecimal(tpProp))
            {
                if (ehObrigatorio)
                    if (!valor.HasValue())
                        return FormatarCampoDecimal(Constantes.VZero, qtdCasas);

                return FormatarCampoDecimal(Convert.ToDecimal(valor), qtdCasas);
            }

            //if (IsCodeOrNumber(tpAttr) || IsLiteralEnum(tpAttr))
            //{
            //    if (valor.Length > 0 && valor.Length <= tamanho)
            //        return valor.PadLeft(tamanho, '0');
            //}

            if (valor.Length > tamanho)
                return valor.Substring(0, tamanho);

            return valor;
        }

        public bool ExisteAtributoSpedNaPropriedade(PropertyInfo prop, int version)
        {
            return ObterAtributosSpedDoCache(prop).Any(a => a.Versao == version);
        }

        public SpedCamposAttribute[] ObterAtributosSpedDoCache(PropertyInfo prop)
        {
            lock (CachedSpedCamposAttribute)
            {
                string propName = $"{prop.DeclaringType.FullName}.{prop.Name}";
                if (!CachedSpedCamposAttribute.ContainsKey(propName))
                    CachedSpedCamposAttribute.Add(propName, (SpedCamposAttribute[])Attribute.GetCustomAttributes(prop, typeof(SpedCamposAttribute)));

                return CachedSpedCamposAttribute[propName];
            }
        }

        public SpedCamposAttribute ObterAtributoSpedDaPropriedade(PropertyInfo prop)
        {
            return ObterAtributoSpedDaPropriedade(prop);
        }

        public SpedCamposAttribute ObterAtributoSpedDaPropriedade(PropertyInfo prop, int? version)
        {
            if (version.HasValue)
                return ObterAtributosSpedDoCache(prop).FirstOrDefault(f => f.Versao == version);

            return ObterAtributosSpedDoCache(prop)[0];
        }

        public string ObterTipoDoAtributo(SpedCamposAttribute attr)
        {
            switch (attr.Tipo)
            {
                case "LE":
                    return Constantes.ArquivoDigital.Sped.TipoInformacao.LiteralEnum;
                case "C":
                case "N":
                    return Constantes.ArquivoDigital.Sped.TipoInformacao.CodeOrNumber;
                case "H":
                    return Constantes.ArquivoDigital.Sped.TipoInformacao.Hour;
                case "MA":
                    return Constantes.ArquivoDigital.Sped.TipoInformacao.MonthAndYear;
            }

            return Constantes.ArquivoDigital.Sped.TipoInformacao.GenericData;
        }

        public bool EhPropriedadeSomenteLeitura(PropertyInfo prop)
        {
            if (prop.PropertyType.BaseType.Equals(typeof(RegistroSped))) return true;

            if (prop.PropertyType.IsGenericType &&
                prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>)) return true;

            return false;
        }

        public List<PropertyInfo> ObterListaComPropriedadesDoTipo(Type t)
        {
            /*
             * http://stackoverflow.com/questions/22306689/get-properties-of-class-by-order-using-reflection
             */
            return t.GetProperties().OrderBy(p => p.GetCustomAttributes(typeof(SpedCamposAttribute), true)
                .Cast<SpedCamposAttribute>()
                .Select(a => a.Ordem)
                .FirstOrDefault())
                .ToList();
        }

        public string ObterTipoDaPropriedade(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(decimal))
                return Constantes.ArquivoDigital.Sped.TipoInformacao.Decimal;

            if (prop.PropertyType == typeof(decimal?))
                return Constantes.ArquivoDigital.Sped.TipoInformacao.NullableDecimal;

            if (prop.PropertyType == typeof(DateTime))
                return Constantes.ArquivoDigital.Sped.TipoInformacao.DateTime;

            if (prop.PropertyType == typeof(DateTime?))
                return Constantes.ArquivoDigital.Sped.TipoInformacao.NullableDateTime;

            if (prop.PropertyType == typeof(Int16) ||
                prop.PropertyType == typeof(Int16?) ||
                prop.PropertyType == typeof(Int32) ||
                prop.PropertyType == typeof(Int32?))
                return Constantes.ArquivoDigital.Sped.TipoInformacao.CodeOrNumber;

            return Constantes.ArquivoDigital.Sped.TipoInformacao.GenericData;
        }

        public CodigoVersaoLeiaute[] ObterListaComVersoesLeiaute()
        {
            return (CodigoVersaoLeiaute[])Enum.GetValues(typeof(CodigoVersaoLeiaute));
        }

        public int ObterVersaoLeiaute(CodigoVersaoLeiaute? versao)
        {
            if ((versao ?? 0) == 0)
                return ObterListaComVersoesLeiaute().LastOrDefault().ToDefaultValue().ToInt();

            return versao.ToDefaultValue().ToInt();
        }

        public string FormatarCampoDateTime(DateTime v)
        {
            return FormatarCampoDateTime(v, "ddMMyyyy");
        }

        public string FormatarCampoDateTime(DateTime v, string format)
        {
            return v.Date.ToString(format);
        }

        public string FormatarCampoDateTime(DateTime? v)
        {
            return FormatarCampoDateTime(v, "ddMMyyyy");
        }

        public string FormatarCampoDateTime(DateTime? v, string format)
        {
            if (v.HasValue)
                return v?.Date.ToString(format);

            return string.Empty;
        }

        public string FormatarCampoDecimal(decimal? v)
        {
            return FormatarCampoDecimal(v, 2);
        }

        public string FormatarCampoDecimal(decimal? v, int qtdCasas)
        {
            if (v.HasValue)
                return string.Format(CultureInfo.GetCultureInfo("pt-BR"), $"{{0:0.{qtdCasas}}}", v);

            //return string.Format(CultureInfo.GetCultureInfo("pt-BR"), $"{{0:0.{qtdCasas}}}", Constantes.VZero);
            return string.Empty;
        }

        public string FormatarCampoInt(int v)
        {
            throw new NotImplementedException();
        }

        public string FormatarCampoInt(int v, int tamanho)
        {
            throw new NotImplementedException();
        }

        public string FormatarCampoInt(int? v)
        {
            throw new NotImplementedException();
        }

        public string FormatarCampoInt(int? v, int tamanho)
        {
            throw new NotImplementedException();
        }

        public string FormatarCampoString(string v)
        {
            throw new NotImplementedException();
        }

        public string[] EscreverArquivo(IRegistroSped[] regs)
        {
            throw new NotImplementedException();
        }

        public string[] EscreverArquivo(IRegistroSped[] regs, CodigoVersaoLeiaute? versao)
        {
            throw new NotImplementedException();
        }

        public string[] EscreverArquivo(List<IRegistroSped> regs)
        {
            throw new NotImplementedException();
        }

        public string[] EscreverArquivo(List<IRegistroSped> regs, CodigoVersaoLeiaute? versao)
        {
            throw new NotImplementedException();
        }

        public string EscreverLinha(IRegistroSped reg)
        {
            throw new NotImplementedException();
        }

        public string EscreverLinha(IRegistroSped reg, CodigoVersaoLeiaute? versao)
        {
            throw new NotImplementedException();
        }

        public string EscreverLinha(IRegistroSped reg, CodigoVersaoLeiaute? versao, DateTime? competencia)
        {
            throw new NotImplementedException();
        }

        public string EscreverLinha(IRegistroSped reg, CodigoVersaoLeiaute? versao, DateTime? competencia, bool? removerQuebraLinha)
        {
            throw new NotImplementedException();
        }

        public string[] EscreverLinhas(IRegistroSped[] regs)
        {
            throw new NotImplementedException();
        }

        public string[] EscreverLinhas(IRegistroSped[] regs, CodigoVersaoLeiaute? versao)
        {
            throw new NotImplementedException();
        }

        public string[] EscreverLinhas(List<IRegistroSped> regs)
        {
            throw new NotImplementedException();
        }

        public string[] EscreverLinhas(List<IRegistroSped> regs, CodigoVersaoLeiaute? versao)
        {
            throw new NotImplementedException();
        }

        public List<IRegistroSped> LerArquivo(string caminho)
        {
            throw new NotImplementedException();
        }

        public List<IRegistroSped> LerArquivo(string caminho, LeiauteArquivoSped tipo)
        {
            throw new NotImplementedException();
        }

        public List<IRegistroSped> LerArquivo(string caminho, LeiauteArquivoSped tipo, CodigoVersaoLeiaute? versao)
        {
            throw new NotImplementedException();
        }

        public List<IRegistroSped> LerArquivo(string[] linhas)
        {
            throw new NotImplementedException();
        }

        public List<IRegistroSped> LerArquivo(string[] linhas, LeiauteArquivoSped tipo)
        {
            throw new NotImplementedException();
        }

        public List<IRegistroSped> LerArquivo(string[] linhas, LeiauteArquivoSped tipo, CodigoVersaoLeiaute? versao)
        {
            throw new NotImplementedException();
        }

        public IRegistroSped LerLinha(string linha)
        {
            throw new NotImplementedException();
        }

        public IRegistroSped LerLinha(string linha, LeiauteArquivoSped tipo)
        {
            throw new NotImplementedException();
        }

        public IRegistroSped LerLinha(string linha, LeiauteArquivoSped tipo, CodigoVersaoLeiaute? versao)
        {
            throw new NotImplementedException();
        }

        public List<IRegistroSped> LerLinhas(string[] linhas)
        {
            throw new NotImplementedException();
        }

        public List<IRegistroSped> LerLinhas(string[] linhas, LeiauteArquivoSped tipo)
        {
            throw new NotImplementedException();
        }

        public List<IRegistroSped> LerLinhas(string[] linhas, LeiauteArquivoSped tipo, CodigoVersaoLeiaute? versao)
        {
            throw new NotImplementedException();
        }

        public List<IRegistroSped> LerLinhas(List<string> linhas)
        {
            throw new NotImplementedException();
        }

        public List<IRegistroSped> LerLinhas(List<string> linhas, LeiauteArquivoSped tipo)
        {
            throw new NotImplementedException();
        }

        public List<IRegistroSped> LerLinhas(List<string> linhas, LeiauteArquivoSped tipo, CodigoVersaoLeiaute? versao)
        {
            throw new NotImplementedException();
        }

        public string FormatarCampoDecimal(decimal v)
        {
            throw new NotImplementedException();
        }

        public string FormatarCampoDecimal(decimal v, int qtdCasas)
        {
            throw new NotImplementedException();
        }

        //private enum InformationType
        //{
        //    CodeOrNumber,
        //    DateTime,
        //    NullableDateTime,
        //    Decimal,
        //    NullableDecimal,
        //    Generic,
        //    Hour,
        //    LiteralEnum,
        //    MonthAndYear
        //}

        //private string PreencherCampo(
        //    string valorEscrever,
        //    Tuple<InformationType, InformationType, bool, int, int> info)
        //{
        //    var hasValue = !string.IsNullOrEmpty(valorEscrever) ||
        //                   !string.IsNullOrWhiteSpace(valorEscrever);
        //    var isDecimal = info.Item2 == InformationType.Decimal;
        //    var isNullableDecimal = info.Item2 == InformationType.NullableDecimal;
        //    var isDateTime = info.Item2 == InformationType.DateTime;
        //    var isNullableDateTime = info.Item2 == InformationType.NullableDateTime;
        //    var isLiteralEnum = info.Item1 == InformationType.LiteralEnum;
        //    var isHour = info.Item1 == InformationType.Hour;
        //    var onlyMonthAndYear = info.Item1 == InformationType.MonthAndYear;
        //    var isRequired = info.Item3;
        //    var fieldLength = info.Item4;
        //    var decimalPlaces = info.Item5;
        //    var decimalPlacesStr = string.Empty.PadLeft(decimalPlaces, '0');
        //    var cultura = CultureInfo.GetCultureInfo("pt-BR");

        //    var propertyLength = hasValue ? valorEscrever.Length : 0;


        //    // Verificação necessária p/ ajustes no tamanho de campos como CSTs e Indicadores. Ex.: CST PIS '1' -> Deve estar no arquivo como '01'.
        //    var isCodeOrNumberAndHasLength = info.Item2 == InformationType.CodeOrNumber &&
        //                                     (fieldLength > 0 && fieldLength <= 4);

        //    //if (isRequired && !hasValue)
        //    //    throw new Exception(
        //    //        $"O campo {spedCampoAttr.Ordem} - {spedCampoAttr.Campo} no Registro {registroAtual} é obrigatório e não foi informado!");

        //    if (!hasValue && isRequired)
        //        return Constantes.StructuralError;

        //    if (isRequired && isDecimal &&
        //        (valorEscrever == string.Empty || valorEscrever.ToDecimal() == 0))
        //        //return Constantes.VZero.ToString("N" + decimalPlaces);
        //        return string.Format(cultura, $"{{0:0.{decimalPlacesStr}}}", Constantes.VZero);
        //    else
        //    {
        //        if (isDecimal && hasValue)
        //        {
        //            return string.Format(cultura, $"{{0:0.{decimalPlacesStr}}}", Convert.ToDecimal(valorEscrever));
        //            /*
        //            var vDecimal =
        //                Convert.ToDecimal(valorEscrever).ToString("N" + decimalPlaces);
        //            return vDecimal.ToStringSafe().Replace(".", string.Empty);
        //            */
        //        }
        //        else if (isNullableDecimal && hasValue)
        //        {
        //            return string.Format(cultura, $"{{0:0.{decimalPlacesStr}}}", Convert.ToDecimal(valorEscrever));
        //            /*
        //            var vDecimal =
        //                Convert.ToDecimal(valorEscrever).ToString("N" + decimalPlaces);
        //            return vDecimal.ToStringSafe().Replace(".", string.Empty);
        //            */
        //        }
        //        else if (isNullableDateTime && hasValue)
        //            return Convert.ToDateTime(valorEscrever).Date.ToString("ddMMyyyy");
        //        else if ((isDateTime && hasValue) && isHour)
        //            return Convert.ToDateTime(valorEscrever).Date.ToString("hhmmss");
        //        else if ((isDateTime && hasValue) && onlyMonthAndYear)
        //            return Convert.ToDateTime(valorEscrever).Date.ToString("MMyyyy");
        //        else if (isDateTime && hasValue)
        //            return Convert.ToDateTime(valorEscrever).Date.ToString("ddMMyyyy");
        //        else if ((isCodeOrNumberAndHasLength && hasValue) || (isLiteralEnum && hasValue))
        //            return valorEscrever.PadLeft(fieldLength, '0');
        //        else
        //        {
        //            if (propertyLength > 0 && (propertyLength > fieldLength))
        //                return valorEscrever.Substring(0, fieldLength);
        //            else
        //                return valorEscrever;
        //        }
        //    }
        //}

        //private InformationType ObtemTipoDoAtributo(SpedCamposAttribute attribute)
        //{
        //    switch (attribute.Tipo)
        //    {
        //        case "LE":
        //            return InformationType.LiteralEnum;
        //        case "C":
        //        case "N":
        //            return InformationType.CodeOrNumber;
        //        case "H":
        //            return InformationType.Hour;
        //        case "MA":
        //            return InformationType.MonthAndYear;
        //    }

        //    return InformationType.Generic;
        //}

        //private InformationType ObtemTipoDaPropriedade(System.Reflection.PropertyInfo property)
        //{
        //    if (property.PropertyType == typeof(decimal))
        //        return InformationType.Decimal;
        //    if (property.PropertyType == typeof(decimal?))
        //        return InformationType.NullableDecimal;
        //    if (property.PropertyType == typeof(DateTime))
        //        return InformationType.DateTime;
        //    if (property.PropertyType == typeof(DateTime?))
        //        return InformationType.NullableDateTime;
        //    /*
        //     * Substituir todos os campos de indicadores por Int16
        //     */
        //    if (property.PropertyType == typeof(Int16) ||
        //        property.PropertyType == typeof(Int16?) ||
        //        property.PropertyType == typeof(Int32) ||
        //        property.PropertyType == typeof(Int32?))
        //        return InformationType.CodeOrNumber;

        //    return InformationType.Generic;
        //}
    }
}
