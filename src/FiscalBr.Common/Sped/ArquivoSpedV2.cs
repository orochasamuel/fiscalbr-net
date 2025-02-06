using FiscalBr.Common.Sped.Interfaces;
using FiscalBr.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FiscalBr.Common.Sped
{
    public abstract class ArquivoSpedV2 : IArquivoSped, ISped
    {
        public event EventHandler<SpedEventArgs> AoProcessarLinha;
        protected void AoProcessarLinhaRaise(object sender, SpedEventArgs e)
        {
            if (AoProcessarLinha != null)
                AoProcessarLinha.Invoke(sender, e);
        }

        private readonly Dictionary<string, SpedCamposAttribute[]> CachedSpedCamposAttribute;

        public SoftwareHouse SoftwareHouse { get; private set; }
        public LeiauteArquivoSped ArquivoSped { get; private set; }
        public VersaoLeiauteSped? VersaoLeiaute { get; private set; }

        public List<string> Erros { get; private set; }
        public List<string> Linhas { get; private set; }

        private ArquivoSpedV2(
            LeiauteArquivoSped leiauteSped
            )
        {
            ArquivoSped = leiauteSped;

            Erros = new List<string>();
            Linhas = new List<string>();

            CachedSpedCamposAttribute = new Dictionary<string, SpedCamposAttribute[]>();
        }

        public ArquivoSpedV2(
            LeiauteArquivoSped leiauteSped,
            VersaoLeiauteSped versaoLeiaute

            ) : this(leiauteSped)
        {
            VersaoLeiaute = versaoLeiaute;
        }

        public ArquivoSpedV2(
            string nomeSoftwareHouse,
            LeiauteArquivoSped leiauteSped,
            VersaoLeiauteSped versaoLeiaute
            ) : this(leiauteSped, versaoLeiaute)
        {
            SoftwareHouse = new SoftwareHouse(nomeSoftwareHouse, null, null);
        }

        public ArquivoSpedV2(
            string nomeSoftwareHouse,
            string cnpjSoftwareHouse,
            LeiauteArquivoSped leiauteSped,
            VersaoLeiauteSped versaoLeiaute
            ) : this(nomeSoftwareHouse, leiauteSped, versaoLeiaute)
        {
            SoftwareHouse = new SoftwareHouse(nomeSoftwareHouse, cnpjSoftwareHouse, null);
        }

        public ArquivoSpedV2(
            string nomeSoftwareHouse,
            string cnpjSoftwareHouse,
            string emailSoftwareHouse,
            LeiauteArquivoSped leiauteSped,
            VersaoLeiauteSped versaoLeiaute
            ) : this(nomeSoftwareHouse, cnpjSoftwareHouse, leiauteSped, versaoLeiaute)
        {
            SoftwareHouse = new SoftwareHouse(nomeSoftwareHouse, cnpjSoftwareHouse, emailSoftwareHouse);
        }

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

        private bool EhRegistroSpedObrigatorio(DateTime? obrigatorioDesde, DateTime? obrigatorioAte, DateTime dataAtual)
        {
            var primeiroDiaMesAtual = dataAtual.GetFirstDayOfCurrentMonth();
            var ultimoDiaDoMesAtual = dataAtual.GetFirstDayOfNextMonth().AddDays(-1);

            // TODO: Fazer testes para este método
            bool ehObrigatorio = !(obrigatorioDesde.HasValue &&
            (obrigatorioDesde.Value > primeiroDiaMesAtual));

            if (obrigatorioAte.HasValue &&
                (obrigatorioAte.Value < ultimoDiaDoMesAtual))
                ehObrigatorio = false;

            return ehObrigatorio;
        }

        private bool ExisteAssinaturaNoArquivo()
        {
            var index9999 = Linhas.FindIndex(p => p.StartsWith("|9999"));

            if (index9999 < 0)
                return false;

            if (Linhas.Count > index9999 + 1)
                return true;

            return false;
        }

        /// <summary>
        /// Calcula o Bloco 9 - 
        /// É necessário que as linhas já estejam geradas. Gere manualmente ou utilize a função "GerarLinhas()".
        /// </summary>
        /// <param name="totalizarblocos">Calcula o totalizados de todos os blocos, ex: 0990, C990, ...</param>
        public virtual void CalcularBloco9(bool totalizarBlocos = true)
        {
            if (Linhas == null || !Linhas.Any())
                throw new Exception("Não é possível calcular o bloco 9 sem as linhas. Execute a função \"GerarLinhas()\", gere as linhas manualemnte ou leia um arquivo para preencher as linhas.");
        }

        protected virtual void GerarBlocoSped(IBlocoSped bloco)
        {
            if (bloco == null)
                return;

            object obj = null;

            // TODO: Usar GetNestedTypes para GerarRegistroSped
            GerarRegistroSped((IRegistroSped)obj);
        }

        /// <summary>
        /// TODO: REFATORAR
        /// </summary>
        /// <param name="registro"></param>
        protected virtual void GerarRegistroSped(IRegistroSped registro)
        {
            if (registro == null)
                return;

            EscreverEAdicionarNasLinhas(registro);
        }

        /// <summary>
        /// Serializa o objeto no atributo "Linhas"
        /// </summary>
        public virtual void GerarLinhas()
        {
            Linhas = new List<string>();
        }

        private void RemoverLinhasVazias()
        {
            Linhas.RemoveAll(l => string.IsNullOrEmpty(l.Trim()));
        }

        private void RemoverLinhasDeAssinatura()
        {
            var index9999 = Linhas.FindIndex(p => p.StartsWith("|9999"));

            var startsAt = index9999 + 1;
            var countedToDelete = Linhas.Count - startsAt;

            Linhas.RemoveRange(startsAt, countedToDelete);
        }

        #endregion Private Methods

        public virtual string PreencherCampo(string valor, string tpAttr, string tpProp, int tamanho, int qtdCasas, bool ehObrigatorio)
        {
            if (ehObrigatorio && !valor.HasValue())
                return Constantes.IsRequiredField;

            // TODO: Refatorar e melhorar
            if ((IsCodeOrNumber(tpAttr) && (tamanho > 0 && tamanho <= 4)) || IsLiteralEnum(tpAttr))
                if (valor.Length <= tamanho)
                    return FormatarCampoString(valor, tamanho, '0');

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

            if (valor.Length > tamanho)
                return FormatarCampoString(valor.Substring(0, tamanho));

            return FormatarCampoString(valor);
        }

        public bool ExisteAtributoSpedNaPropriedade(PropertyInfo prop, int versao)
        {
            return ObterAtributosSpedDoCache(prop).Any(a => a.Versao == versao);
        }

        private SpedCamposAttribute[] ObterAtributosSpedDoCache(PropertyInfo prop)
        {
            lock (CachedSpedCamposAttribute)
            {
                string propName = $"{prop.DeclaringType.FullName}.{prop.Name}";
                if (!CachedSpedCamposAttribute.ContainsKey(propName))
                    CachedSpedCamposAttribute.Add(propName, (SpedCamposAttribute[])Attribute.GetCustomAttributes(prop, typeof(SpedCamposAttribute)));

                return CachedSpedCamposAttribute[propName];
            }
        }

        public SpedCamposAttribute ObterAtributoSpedDaPropriedade(PropertyInfo prop, int? versao = null)
        {
            if (versao.HasValue)
                return ObterAtributosSpedDoCache(prop).FirstOrDefault(f => f.Versao == versao);

            return ObterAtributosSpedDoCache(prop)[0];
        }

        public SpedRegistrosAttribute ObterAtributoRegistroSped(Type tipo)
        {
            return (SpedRegistrosAttribute)Attribute.GetCustomAttribute(tipo, typeof(SpedRegistrosAttribute));
        }

        public virtual string ObterTipoDoAtributo(SpedCamposAttribute attr)
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

        public List<PropertyInfo> ObterListaComPropriedadesDoTipo(Type t, int? v)
        {
            /*
             * http://stackoverflow.com/questions/22306689/get-properties-of-class-by-order-using-reflection
             */
            //return t.GetProperties().OrderBy(p => p.GetCustomAttributes(typeof(SpedCamposAttribute), true)
            //    .Cast<SpedCamposAttribute>()
            //    .Select(a => a.Ordem)
            //    .FirstOrDefault())
            //    .ToList();

            var r = t.GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(SpedCamposAttribute))); //Só quero os campos do tipo SpedCamposAttribute, ignorando registros filhos!

            if (v != null)
                if (v.HasValue && v > 0)
                {
                    r = r.Where(x => x.GetCustomAttributes(typeof(SpedCamposAttribute), true)
                    .Cast<SpedCamposAttribute>()
                    .Any(a => a.Versao <= v));
                }

            r = r.OrderBy(p => p.GetCustomAttributes(typeof(SpedCamposAttribute), true)
                .Cast<SpedCamposAttribute>()
                .Select(a => a.Ordem)
                .FirstOrDefault());

            return r.ToList();
        }

        public virtual string ObterTipoDaPropriedade(PropertyInfo prop)
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

        public virtual void EscreverArquivo(string caminho, Encoding encoding = null)
        {
            if (Linhas == null || !Linhas.Any())
                throw new Exception("Não é possível escrever sem as linhas. Execute a função \"GerarLinhas()\", gere as linhas manualemnte ou leia um arquivo para preencher as linhas.");

            File.WriteAllLines(caminho, Linhas.ToArray(), encoding ?? Encoding.Default);
        }

        private void EscreverEAdicionarNasLinhas(IRegistroSped reg, DateTime? competencia = null, bool? removerQuebraLinha = null)
        {
            Linhas.Add(EscreverLinha(reg, competencia, removerQuebraLinha));
        }

        public virtual string EscreverLinha(IRegistroSped reg, DateTime? competencia = null, bool? removerQuebraLinha = null)
        {
            var type = reg.GetType();

            var spedRegistroAttr = ObterAtributoRegistroSped(type);

            var dataObrigatoriedadeInicial = spedRegistroAttr != null ? spedRegistroAttr.ObrigatoriedadeInicial.ToDateTimeNullable() : null;
            var dataObrigatoriedadeFinal = spedRegistroAttr != null ? spedRegistroAttr.ObrigatoriedadeFinal.ToDateTimeNullable() : null;

            if (!competencia.HasValue)
                competencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            else
                competencia = new DateTime(competencia.Value.Year, competencia.Value.Month, 1);

            var deveGerarCamposDoRegistro =
                EhRegistroSpedObrigatorio(
                    dataObrigatoriedadeInicial,
                    dataObrigatoriedadeFinal,
                    competencia.Value
                    );

            var versoesLeiaute = ObterVersoesLeiaute(ArquivoSped);

            int versaoDesejada =
                versoesLeiaute.FirstOrDefault(fd =>
                    Convert.ToInt32(fd.ToString()).Equals((int)VersaoLeiaute));

            if (versaoDesejada == 0)
                versaoDesejada = versoesLeiaute.LastOrDefault();

            var sb = new StringBuilder();
            if (deveGerarCamposDoRegistro)
            {
                var propriedades = ObterListaComPropriedadesDoTipo(type, versaoDesejada);
                foreach (var property in propriedades)
                {
                    if (EhPropriedadeSomenteLeitura(property)) continue;

                    sb.Append(Pipe());

                    SpedCamposAttribute spedCampoAttr = null;
                    var attrs = ObterAtributosSpedDoCache(property);

                    switch (attrs.Length)
                    {
                        case 0:
                            break;
                        case 1:
                            spedCampoAttr = ObterAtributoSpedDaPropriedade(property);
                            break;
                        default:
                            while (!ExisteAtributoSpedNaPropriedade(property, versaoDesejada))
                            {
                                versaoDesejada--;

                                if (versaoDesejada < 1)
                                    break;
                            }

                            spedCampoAttr = ObterAtributoSpedDaPropriedade(property, versaoDesejada);
                            break;
                    }

                    if (spedCampoAttr == null)
                        Erros.Add(string.Format(
                            "O campo {0} no registro {1} não possui atributo SPED definido!", property.Name, reg.Reg));

                    var propertyValue = RegistroSped.GetPropValue(reg, property.Name);
                    var propertyValueToStringSafe = propertyValue.ToStringSafe().Trim();

                    var campoEscrito = PreencherCampo(
                        propertyValueToStringSafe,
                        ObterTipoDoAtributo(spedCampoAttr),
                        ObterTipoDaPropriedade(property),
                        spedCampoAttr.Tamanho,
                        spedCampoAttr.QtdCasas,
                        spedCampoAttr.IsObrigatorio
                        );

                    if (campoEscrito == Constantes.IsRequiredField)
                        Erros.Add(string.Format(
                            "O campo {0} - {1} no Registro {2} é obrigatório e não foi informado!", spedCampoAttr.Ordem, spedCampoAttr.Campo, reg.Reg));

                    sb.Append(campoEscrito);
                }
                sb.Append(Pipe());
                sb.Append(NewLine());
            }

            return removerQuebraLinha.HasValue ? sb.ToString().Trim() : sb.ToString();
        }

        public virtual string[] EscreverLinhas(List<IRegistroSped> regs, DateTime? competencia = null, bool? removerQuebraLinha = null)
        {
            List<string> list = new List<string>();

            for (int i = 0; i < regs.Count; i++)
                list.Add(EscreverLinha(regs[i], competencia, removerQuebraLinha));

            return list.ToArray();
        }

        public virtual string FormatarCampoDateTime(DateTime v)
        {
            return FormatarCampoDateTime(v, "ddMMyyyy");
        }

        public virtual string FormatarCampoDateTime(DateTime v, string format)
        {
            return v.Date.ToString(format);
        }

        public virtual string FormatarCampoDateTime(DateTime? v)
        {
            return FormatarCampoDateTime(v, "ddMMyyyy");
        }

        public virtual string FormatarCampoDateTime(DateTime? v, string format)
        {
            if (v.HasValue)
                return v?.Date.ToString(format);

            return string.Empty;
        }

        public virtual string FormatarCampoDecimal(decimal v)
        {
            return FormatarCampoDecimal(v);
        }

        public virtual string FormatarCampoDecimal(decimal v, int qtdCasas)
        {
            return FormatarCampoDecimal(v, qtdCasas);
        }

        public virtual string FormatarCampoDecimal(decimal? v)
        {
            return FormatarCampoDecimal(v, 2);
        }

        public virtual string FormatarCampoDecimal(decimal? v, int qtdCasas)
        {
            if (v.HasValue)
                return string.Format(CultureInfo.GetCultureInfo("pt-BR"), $"{{0:0.{qtdCasas}}}", v);

            return string.Empty;
        }

        public virtual string FormatarCampoInt(int v)
        {
            return FormatarCampoInt(v, 0);
        }

        public virtual string FormatarCampoInt(int v, int tamanho)
        {
            return FormatarCampoInt(v, tamanho);
        }

        public virtual string FormatarCampoInt(int? v)
        {
            return FormatarCampoInt(v, 0);
        }

        public virtual string FormatarCampoInt(int? v, int tamanho)
        {
            if (v.HasValue)
                return v.ToString().PadLeft(tamanho, '0');

            return string.Empty;
        }

        public virtual string FormatarCampoString(string v)
        {
            if (!string.IsNullOrWhiteSpace(v))
                return v;

            return string.Empty;
        }

        public virtual string FormatarCampoString(string v, int tamanho)
        {
            if (!string.IsNullOrWhiteSpace(v))
                return v.PadLeft(tamanho, '0');

            return string.Empty;
        }

        public virtual string FormatarCampoString(string v, int tamanho, char caractere)
        {
            if (!string.IsNullOrWhiteSpace(v))
                return v.PadLeft(tamanho, caractere);

            return string.Empty;
        }

        public virtual void LerArquivo(string[] linhas)
        {
            if (linhas == null || linhas.Length == 0)
                throw new Exception("Nada a ser lido! Verifique e tente novamente");

            Linhas = linhas.ToList();

            if (ExisteAssinaturaNoArquivo())
                RemoverLinhasDeAssinatura();

            RemoverLinhasVazias();
        }

        public virtual void LerArquivo(List<string> linhas)
        {
            if (linhas == null || linhas.Count == 0)
                throw new Exception("Nada a ser lido! Verifique e tente novamente");

            Linhas = linhas;

            if (ExisteAssinaturaNoArquivo())
                RemoverLinhasDeAssinatura();

            RemoverLinhasVazias();
        }

        public virtual void LerArquivo(string caminho, Encoding encoding = null, VersaoLeiauteSped? versao = null)
        {
            if (!File.Exists(caminho))
                throw new Exception("O arquivo não existe! Verifique e tente novamente.");

            // TODO: Alterar para remover os espaços em branco antes do primeiro pipe e após o último pipe.
            Linhas = File.ReadAllLines(caminho, encoding ?? Encoding.Default).ToList();

            if (ExisteAssinaturaNoArquivo())
                RemoverLinhasDeAssinatura();

            RemoverLinhasVazias();
        }

        public virtual List<IRegistroSped> LerArquivo(string[] linhas, LeiauteArquivoSped tipo, VersaoLeiauteSped? versao)
        {
            return LerLinhas(linhas.ToList(), tipo, versao);
        }

        /// <summary>
        /// TODO: REFATORAR
        /// </summary>
        /// <param name="linha"></param>
        /// <param name="tipo"></param>
        /// <param name="versao"></param>
        /// <returns></returns>
        public abstract IRegistroSped LerLinha(string linha, LeiauteArquivoSped tipo, VersaoLeiauteSped? versao);

        public virtual List<IRegistroSped> LerLinhas(List<string> linhas, LeiauteArquivoSped tipo, VersaoLeiauteSped? versao)
        {
            List<IRegistroSped> list = new List<IRegistroSped>();

            for (int i = 0; i < linhas.Count; i++)
                list.Add(LerLinha(linhas[i], tipo, versao));

            return list;
        }

        public virtual int ObterVersaoLeiaute(VersaoLeiauteSped? versaoLeiaute)
        {
            if (versaoLeiaute.HasValue)
                return (int)versaoLeiaute;

            return (int)VersaoLeiaute;
        }

        public virtual int[] ObterVersoesLeiaute(LeiauteArquivoSped? leiauteSped)
        {
            switch (leiauteSped ?? ArquivoSped)
            {
                case LeiauteArquivoSped.ECD:
                    return EnumHelpers.GetEnumValues<CodVersaoSpedECD>();
                case LeiauteArquivoSped.ECF:
                    return EnumHelpers.GetEnumValues<CodVersaoSpedECF>();
                case LeiauteArquivoSped.EFDContrib:
                    return EnumHelpers.GetEnumValues<CodVersaoSpedContrib>();
                case LeiauteArquivoSped.EFDFiscal:
                    return EnumHelpers.GetEnumValues<CodVersaoSpedFiscal>();
            }
            throw new ArgumentException("O leiute do arquivo não foi especificado!");
        }

        public virtual Enum ObterEnumVersaoLeiaute()
        {
            switch (ArquivoSped)
            {
                case LeiauteArquivoSped.ECD:
                    switch (VersaoLeiaute)
                    {
                        case VersaoLeiauteSped.V1:
                            return CodVersaoSpedECD.V1;
                        case VersaoLeiauteSped.V2:
                            return CodVersaoSpedECD.V2;
                        case VersaoLeiauteSped.V3:
                            return CodVersaoSpedECD.V3;
                        case VersaoLeiauteSped.V4:
                            return CodVersaoSpedECD.V4;
                        case VersaoLeiauteSped.V5:
                            return CodVersaoSpedECD.V5;
                        case VersaoLeiauteSped.V6:
                            return CodVersaoSpedECD.V6;
                        case VersaoLeiauteSped.V7:
                            return CodVersaoSpedECD.V7;
                        case VersaoLeiauteSped.V8:
                            return CodVersaoSpedECD.V8;
                        case VersaoLeiauteSped.V9:
                            return CodVersaoSpedECD.V9;
                    }
                    break;
                case LeiauteArquivoSped.ECF:
                    switch (VersaoLeiaute)
                    {
                        case VersaoLeiauteSped.V1:
                            return CodVersaoSpedECF.V1;
                        case VersaoLeiauteSped.V2:
                            return CodVersaoSpedECF.V2;
                        case VersaoLeiauteSped.V3:
                            return CodVersaoSpedECF.V3;
                        case VersaoLeiauteSped.V4:
                            return CodVersaoSpedECF.V4;
                        case VersaoLeiauteSped.V5:
                            return CodVersaoSpedECF.V5;
                        case VersaoLeiauteSped.V6:
                            return CodVersaoSpedECF.V6;
                        case VersaoLeiauteSped.V7:
                            return CodVersaoSpedECF.V7;
                        case VersaoLeiauteSped.V8:
                            return CodVersaoSpedECF.V8;
                        case VersaoLeiauteSped.V9:
                            return CodVersaoSpedECF.V9;
                    }
                    break;
                case LeiauteArquivoSped.EFDContrib:
                    switch (VersaoLeiaute)
                    {
                        case VersaoLeiauteSped.V1:
                            return CodVersaoSpedContrib.V1;
                        case VersaoLeiauteSped.V2:
                            return CodVersaoSpedContrib.V2;
                        case VersaoLeiauteSped.V3:
                            return CodVersaoSpedContrib.V3;
                        case VersaoLeiauteSped.V4:
                            return CodVersaoSpedContrib.V4;
                        case VersaoLeiauteSped.V5:
                            return CodVersaoSpedContrib.V5;
                        case VersaoLeiauteSped.V6:
                            return CodVersaoSpedContrib.V6;
                    }
                    break;
                case LeiauteArquivoSped.EFDFiscal:
                    switch (VersaoLeiaute)
                    {
                        case VersaoLeiauteSped.V2:
                            return CodVersaoSpedFiscal.V2;
                        case VersaoLeiauteSped.V3:
                            return CodVersaoSpedFiscal.V3;
                        case VersaoLeiauteSped.V4:
                            return CodVersaoSpedFiscal.V4;
                        case VersaoLeiauteSped.V5:
                            return CodVersaoSpedFiscal.V5;
                        case VersaoLeiauteSped.V6:
                            return CodVersaoSpedFiscal.V6;
                        case VersaoLeiauteSped.V7:
                            return CodVersaoSpedFiscal.V7;
                        case VersaoLeiauteSped.V8:
                            return CodVersaoSpedFiscal.V8;
                        case VersaoLeiauteSped.V9:
                            return CodVersaoSpedFiscal.V9;
                        case VersaoLeiauteSped.V10:
                            return CodVersaoSpedFiscal.V10;
                        case VersaoLeiauteSped.V11:
                            return CodVersaoSpedFiscal.V11;
                        case VersaoLeiauteSped.V12:
                            return CodVersaoSpedFiscal.V12;
                        case VersaoLeiauteSped.V13:
                            return CodVersaoSpedFiscal.V13;
                        case VersaoLeiauteSped.V14:
                            return CodVersaoSpedFiscal.V14;
                        case VersaoLeiauteSped.V15:
                            return CodVersaoSpedFiscal.V15;
                        case VersaoLeiauteSped.V16:
                            return CodVersaoSpedFiscal.V16;
                        case VersaoLeiauteSped.V17:
                            return CodVersaoSpedFiscal.V17;
                        case VersaoLeiauteSped.V18:
                            return CodVersaoSpedFiscal.V18;
                        case VersaoLeiauteSped.V19:
                            return CodVersaoSpedFiscal.V19;
                    }
                    break;
            }
            throw new ArgumentException("O leiute do arquivo ou a versão não foram especificados!");
        }
    }
}
