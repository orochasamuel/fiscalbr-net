using FiscalBr.Common;
using FiscalBr.Common.Sped;
using FiscalBr.Common.Sped.Enums;
using FiscalBr.Common.Sped.Interfaces;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDFiscal
{
    /// <summary>
    ///     BLOCO D: DOCUMENTOS FISCAIS II - SERVIÇOS (ICMS)
    /// </summary>
    public class BlocoD : IBlocoSped
    {
        public RegistroD001 RegD001 { get; set; }
        public RegistroD990 RegD990 { get; set; }

        /// <summary>
        ///     REGISTRO D001: ABERTURA DO BLOCO D
        /// </summary>
        public class RegistroD001 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD001"/>.
            /// </summary>
            public RegistroD001() : base("D001")
            {
            }

            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD001"/>.
            /// </summary>
            public RegistroD001(IndMovimento indMovimento) : base("D001")
            {
                IndMov = indMovimento;
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroD001" />.
            /// </summary>
            public RegistroD001(bool temMovimento) : base("D001")
            {
                IndMov = temMovimento ? IndMovimento.BlocoComDados : IndMovimento.BlocoSemDados;
            }

            /// <summary>
            ///     Indicador de movimento:
            ///     <remarks>
            ///     <para />
            ///     0 - Bloco com dados informados;
            ///     <para />
            ///     1 - Bloco sem dados informados.
            ///     </remarks>
            /// </summary>
            [SpedCampos(2, "IND_MOV", "N", 1, 0, true, 2)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroD100> RegD100s { get; set; }
            public List<RegistroD300> RegD300s { get; set; }
            public List<RegistroD350> RegD350s { get; set; }
            public List<RegistroD400> RegD400s { get; set; }
            public List<RegistroD500> RegD500s { get; set; }
            public List<RegistroD600> RegD600s { get; set; }
            public List<RegistroD695> RegD695s { get; set; }

            public RegistroD001 ComIndicadorMovimento(bool v)
            {
                IndMov = v ? IndMovimento.BlocoComDados : IndMovimento.BlocoSemDados;
                return this;  
            }

            public override bool Validar()
            {
                if (!Reg.Equals("D001"))
                    return false;

                return base.Validar();
            }
        }

        /// <summary>
        ///     REGISTRO D100: NOTA FISCAL DE SERVIÇO DE TRANSPORTE (CÓDIGO 07) E CONHECIMENTOS DE TRANSPORTE RODOVIÁRIO DE CARGAS
        ///     (CÓDIGO 08),
        ///     CONHECIMENTOS DE TRANSPORTE DE CARGAS AVULSO (CÓDIGO 8B), AQUAVIÁRIO DE CARGAS (CÓDIGO 09), AÉREO (CÓDIGO 10),
        ///     FERROVIÁRIO DE CARGAS (CÓDIGO 11) E
        ///     MULTIMODAL DE CARGAS (CÓDIGO 26), NOTA FISCAL DE TRANSPORTE FERROVIÁRIO DE CARGA ( CÓDIGO 27) E CONHECIMENTO DE
        ///     TRANSPORTE ELETRÔNICO – CT-e (CÓDIGO 57).
        /// </summary>
        public class RegistroD100 : RegistroSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="RegistroD100"/>.
            /// </summary>
            public RegistroD100() : base("D100")
            {
            }

            #region Propriedades

            /// <summary>
            ///     Indicador do tipo de operação:
            ///     <para />
            ///     0- Aquisição;
            ///     <para />
            ///     1- Prestação
            /// </summary>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true, 2)]
            public IndTipoOperacaoServico IndOper { get; set; }

            /// <summary>
            ///     Indicador do emitente do documento fiscal:
            ///     <para />
            ///     0 - Emissão própria;
            ///     <para />
            ///     1 - Terceiros;
            /// </summary>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true, 2)]
            public IndEmitente IndEmit { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150):
            /// </summary>
            /// <remarks>
            ///     - do emitente do documento ou do remetente das mercadorias, no caso de entradas;
            ///     <para />
            ///     - do adquirente, no caso de saídas.
            /// </remarks>
            [SpedCampos(4, "COD_PART", "C", 60, 0, false, 2)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(5, "COD_MOD", "C", 2, 0, true, 2)]
            public IndCodMod CodMod { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(6, "COD_SIT", "N", 2, 0, true, 2)]
            public IndCodSitDoc CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(7, "SER", "C", 4, 0, false, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(8, "SUB", "C", 3, 0, false, 2)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(9, "NUM_DOC", "N", 9, 0, true, 2)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Chave do Conhecimento de Transporte Eletrônico
            /// </summary>
            [SpedCampos(10, "CHV_CTE", "N", 44, 0, false, 2)]
            public string ChvCte { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(11, "DT_DOC", "N", 8, 0, false, 2)]
            public DateTime? DtDoc { get; set; }

            /// <summary>
            ///     Data da aquisição ou da prestação do serviço
            /// </summary>
            [SpedCampos(12, "DT_AP", "N", 8, 0, false, 2)]
            public DateTime? DtAp { get; set; }

            /// <summary>
            ///     Tipo de Conhecimento de Transporte Eletrônico conforme definido no Manual de Integração do CT-e
            /// </summary>
            [SpedCampos(13, "TP_CT-e", "N", 1, 0, false, 2)]
            public int? TpCte { get; set; }

            /// <summary>
            ///     Chave do CT-e de referência cujos valores foram complementados (opção “1” do campo anterior) 
            ///     <para />
            ///     ou cujo débito foi anulado(opção “2” do campo anterior).
            /// </summary>
            [SpedCampos(14, "CHV_CTE_REF", "N", 44, 0, false, 2)]
            public string ChvCteRef { get; set; }

            /// <summary>
            ///     Valor total do documento fisca
            /// </summary>
            [SpedCampos(15, "VL_DOC", "N", 0, 2, false, 2)]
            public decimal? VlDoc { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(16, "VL_DESC", "N", 0, 2, false, 2)]
            public decimal? VlDesc { get; set; }

            /// <summary>
            ///     Indicador do tipo do frete:
            /// </summary>
            /// <remarks>
            ///     0- Por conta de terceiros;
            ///     <para />
            ///     1- Por conta do emitente;
            ///     <para />
            ///     2- Por conta do destinatário;
            ///     <para />
            ///     9- Sem cobrança de frete.
            /// </remarks>
            [SpedCampos(17, "IND_FRT", "N", 1, 0, false, 2)]
            public IndTipoFrete IndFrt { get; set; }

            /// <summary>
            ///     Valor total do serviço
            /// </summary>
            [SpedCampos(18, "VL_SERV", "N", 0, 2, false, 2)]
            public decimal? VlServ { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(19, "VL_BC_ICMS", "N", 0, 2, false, 2)]
            public decimal? VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS
            /// </summary>
            [SpedCampos(20, "VL_ICMS", "N", 0, 2, false, 2)]
            public decimal? VlIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS
            /// </summary>
            [SpedCampos(21, "VL_NT", "N", 0, 2, false, 2)]
            public decimal? VlNt { get; set; }

            /// <summary>
            ///     Código da informação complementar do documento fiscal (campo 02 do Registro 0450)
            /// </summary>
            [SpedCampos(22, "COD_INF", "C", 6, 0, false, 2)]
            public string CodInf { get; set; }

            /// <summary>
            ///     Código da informação complementar do documento fiscal (campo 02 do Registro 0450)
            /// </summary>
            [SpedCampos(22, "COD_CTA", "C", 0, 0, false, 2)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Código do município de origem do serviço, conforme a tabela IBGE (Preencher com 9999999, se Exterior)
            ///     <para />
            ///     Guia Prático EFD-ICMS/IPI – Versão 2.0.21
            ///     <para />
            ///     Atualização: 22/08/2017
            /// </summary>
            [SpedCampos(24, "COD_MUN_ORIG", "N", 7, 0, false, 2)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///     Código do município de destino, conforme a tabela IBGE (Preencher com 9999999, se Exterior)
            ///     <para />
            ///     Guia Prático EFD-ICMS/IPI – Versão 2.0.21 
            ///     <para />
            ///     Atualização: 22/08/2017
            /// </summary>
            [SpedCampos(25, "COD_MUN_DEST", "N", 7, 0, false, 2)]
            public string CodMunDest { get; set; }

            #region Registros Filhos

            public RegistroD101 RegD101 { get; set; }
            public List<RegistroD110> RegD110s { get; set; }
            public List<RegistroD130> RegD130s { get; set; }
            public RegistroD140 RegD140 { get; set; }
            public RegistroD150 RegD150 { get; set; }
            public List<RegistroD160> RegD160s { get; set; }
            public RegistroD170 RegD170 { get; set; }
            public List<RegistroD180> RegD180s { get; set; }
            public List<RegistroD190> RegD190s { get; set; }
            public List<RegistroD195> RegD195s { get; set; }

            #endregion Registros Filhos

            #endregion Propriedades

            public RegistroD100 ComTipoOperacao(IndTipoOperacaoServico v)
            {
                IndOper = v;
                return this;
            }

            public RegistroD100 ComTipoEmissao(IndEmitente v)
            {
                IndEmit = v;
                return this;
            }

            public RegistroD100 ComCodigoParticipante(string v)
            {
                CodPart = v;
                return this;
            }

            public RegistroD100 ComCodigoModelo(IndCodMod v)
            {
                CodMod = v;
                return this;
            }

            public RegistroD100 ComCodigoSituacao(IndCodSitDoc v)
            {
                CodSit = v;
                return this;
            }

            public RegistroD100 ComSerie(string v)
            {
                Ser = v;
                return this;
            }

            public RegistroD100 ComSubSerie(string v)
            {
                Sub = v;
                return this;
            }

            public RegistroD100 ComNumeroDocumento(string v)
            {
                NumDoc = v;
                return this;
            }

            public RegistroD100 ComChaveDfe(string v)
            {
                ChvCte = v;
                return this;
            }

            public RegistroD100 ComDataEmissao(DateTime v)
            {
                DtDoc = v;
                return this;
            }

            public RegistroD100 ComDataAquisicaoPrestacao(DateTime v)
            {
                DtAp = v;
                return this;
            }

            public RegistroD100 ComTipoCte(int v)
            {
                TpCte = v;
                return this;
            }

            public RegistroD100 ComChaveDfeRef(string v)
            {
                ChvCteRef = v;
                return this;
            }

            public RegistroD100 ComValorTotal(decimal v)
            {
                VlDoc = v;
                return this;
            }

            public RegistroD100 ComValorDesconto(decimal v)
            {
                VlDesc = v;
                return this;
            }

            public RegistroD100 ComTipoFrete(IndTipoFrete v)
            {
                IndFrt = v;
                return this;
            }

            public RegistroD100 ComValorServico(decimal v)
            {
                VlServ = v;
                return this;
            }

            public RegistroD100 ComValorBaseIcms(decimal v)
            {
                VlBcIcms = v;
                return this;
            }

            public RegistroD100 ComValorIcms(decimal v)
            {
                VlIcms = v;
                return this;
            }

            public RegistroD100 ComValorNaoTributado(decimal v)
            {
                VlNt = v;
                return this;
            }

            public RegistroD100 ComCodigoInfComplementar(string v)
            {
                CodInf = v;
                return this;
            }

            public RegistroD100 ComContaContabil(string v)
            {
                CodCta = v;
                return this;
            }

            public RegistroD100 ComCodMunicipioOrigem(string v)
            {
                CodMunOrig = v;
                return this;
            }

            public RegistroD100 ComCodMunicipioDestino(string v)
            {
                CodMunOrig = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO D101: INFORMAÇÃO COMPLEMENTAR DOS DOCUMENTOS FISCAIS QUANDO 
        ///     <para />
        ///     DAS PRESTAÇÕES INTERESTADUAIS DESTINADAS A CONSUMIDOR 
        ///     <para />
        ///     FINAL NÃO CONTRIBUINTE EC 87/15 (CÓDIGOS 57 e 67)
        /// </summary>
        public class RegistroD101 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD101"/>.
            /// </summary>
            public RegistroD101() : base("D101")
            {
            }

            /// <summary>
            ///   Valor total relativo ao Fundo de Combate à Pobreza (FCP) da UF de destino
            /// </summary>
            [SpedCampos(2, "VL_FCP_UF_DEST", "N", 0, 2, true, 2)]
            public decimal VlFcpUfDest { get; set; }

            /// <summary>
            ///   Valor total do ICMS Interestadual para a UF de destino
            /// </summary>
            [SpedCampos(3, "VL_ICMS_UF_DEST", "N", 0, 2, true, 2)]
            public decimal VlIcmsUfDest { get; set; }

            /// <summary>
            ///   Valor total do ICMS Interestaduak para a UF do remetente
            /// </summary>
            [SpedCampos(4, "VL_ICMS_UF_REM", "N", 0, 2, true, 2)]
            public decimal VlIcmsUfRem { get; set; }
        }

        /// <summary>
        ///     REGISTRO D110: ITENS DO DOCUMENTO - NOTA FISCAL DE SERVIÇOS DE TRANSPORTE (CODIGO 07)
        /// </summary>
        public class RegistroD110 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD110"/>.
            /// </summary>
            public RegistroD110() : base("D110")
            {
            }

            /// <summary>
            ///   Numero sequencial do item no documento fiscal
            /// </summary>
            [SpedCampos(2, "NUM_ITEM", "N", 3, 0, true, 2)]
            public decimal NumItem { get; set; }

            /// <summary>
            ///   Codigo do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true, 2)]
            public string CodItem { get; set; }

            /// <summary>
            ///   Valor do serviço
            /// </summary>
            [SpedCampos(4, "VL_SERV", "N", 0, 2, true, 2)]
            public decimal VlServ { get; set; }

            /// <summary>
            ///   Outros valores
            /// </summary>
            [SpedCampos(5, "VL_OUT", "N", 0, 2, false, 2)]
            public decimal VlOut { get; set; }

            public List<RegistroD120> RegD120s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D120: COMPLEMENTO DA NOTA FISCAL DE SERVIÇOS DE TRANSPORTE (CODIGO 07)
        /// </summary>
        public class RegistroD120 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD120"/>.
            /// </summary>
            public RegistroD120() : base("D120")
            {
            }

            /// <summary>
            ///   Codigo do municipio de origem do serviço, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(2, "COD_MUN_ORIG", "N", 7, 0, true, 2)]
            public decimal CodMunOrig { get; set; }

            /// <summary>
            ///   Codigo do municipio de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(3, "COD_MUN_DEST", "N", 7, 0, true, 2)]
            public decimal CodMunDest { get; set; }

            /// <summary>
            ///   Placa de identificacao do veiculo
            /// </summary>
            [SpedCampos(4, "VEIC_ID", "C", 7, 0, false, 2)]
            public decimal VeicId { get; set; }

            /// <summary>
            ///   Sigla da UF da placa do veiculo
            /// </summary>
            [SpedCampos(5, "UF_ID", "C", 2, 0, false, 2)]
            public decimal UfId { get; set; }
        }

        /// <summary>
        ///     REGISTRO  D130:  COMPLEMENTO  DO  CONHECIMENTO  RODOVIÁRIO  DE  CARGAS (CÓDIGO 08) E DO CONHECIMENTO RODOVIÁRIO DE CARGAS AVULSO (CÓDIGO 8B)
        ///     E DO CONHECIMENTO DE TRANSPORTE ELETRÔNICO SIMPLIFICADO(CÓDIGO 57)
        /// </summary>
        public class RegistroD130 : RegistroSped
        {
            public RegistroD130() : base("D130")
            {
            }

            /// <summary>
            ///    Código do participante (campo 02 do Registro 0150):
            /// </summary>
            /// <remarks>
            ///    -consignatário, se houver
            /// </remarks>
            [SpedCampos(2, "COD_PART_CONSG", "C", 60, 0, false, 2)]
            public string CodPartConsg { get; set; }


            /// <summary>
            ///    Código do participante (campo 02 do Registro 0150):
            /// </summary>
            /// <remarks>
            ///    -redespachado, se houver
            /// </remarks>
            [SpedCampos(3, "COD_PART_RED", "C", 60, 0, false, 2)]
            public string CodPartRed { get; set; }

            /// <summary>
            ///    Indicador do tipo do frete da operação de redespacho:
            /// </summary>
            /// <remarks>
            ///    0 – Sem redespacho;
            ///    <para />
            ///    1 - Por conta do emitente;
            ///    <para />
            ///    2 - Por conta do destinatário;
            ///    <para />
            ///    9 –Outros.
            /// </remarks>
            [SpedCampos(4, "IND_FRT_RED", "C", 1, 0, true, 2)]
            public int IntFrtRed { get; set; }

            /// <summary>
            ///    Código do município de origem do serviço, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(5, "COD_MUN_ORIG", "N", 7, 0, true, 2)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///    Código do município de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(6, "COD_MUN_DEST", "N", 7, 0, true, 2)]
            public string CodMunDest { get; set; }

            /// <summary>
            ///    Placa de identificação do veículo
            /// </summary>
            [SpedCampos(7, "VEIC_ID", "C", 7, 0, false, 2)]
            public string VeicId { get; set; }

            /// <summary>
            ///    Valor líquido do frete 
            /// </summary>
            [SpedCampos(8, "VL_LIQ_FRT", "N", 0, 2, true, 2)]
            public string VlLiqFrt { get; set; }

            /// <summary>
            ///     Soma de valores de Sec/Cat (serviços de coleta/custo adicional de transporte) 
            /// </summary>
            [SpedCampos(9, "VL_SEC_CAT", "N", 0, 2, false, 2)]
            public string VlSecCat { get; set; }

            /// <summary>
            ///     Soma de valores de despacho
            /// </summary>
            [SpedCampos(10, "VL_DESP", "N", 0, 2, false, 2)]
            public string VlDesp { get; set; }

            /// <summary>
            ///     Soma dos valores de pedágio
            /// </summary>
            [SpedCampos(11, "VL_PEDG", "N", 0, 2, false, 2)]
            public string VlPedg { get; set; }

            /// <summary>
            ///    Outros valores 
            /// </summary>
            [SpedCampos(12, "VL_OUT", "N", 0, 2, false, 2)]
            public string VlOut { get; set; }

            /// <summary>
            ///     Valor total do frete
            /// </summary>
            [SpedCampos(13, "VL_FRT", "N", 0, 2, true, 2)]
            public string VlFrt { get; set; }

            /// <summary>
            ///     Sigla da UF da placa do veículo
            /// </summary>
            [SpedCampos(14, "UF_ID", "C", 2, 0, false, 2)]
            public string UfId { get; set; }

        }

        /// <summary>
        ///     REGISTRO D140: COMPLEMENTO DO CONHECIMENTO AQUAVIÁRIO DE CARGAS (CÓDIGO 09)
        /// </summary>
        public class RegistroD140 : RegistroSped
        {
            public RegistroD140() : base("D140")
            {
            }

            /// <summary>
            ///    Código do participante (campo 02 do Registro 0150):
            /// </summary>
            /// <remarks>
            ///    -consignatário, se houver
            /// </remarks>
            [SpedCampos(2, "COD_PART_CONSG", "C", 60, 0, false, 2)]
            public string CodPartConsg { get; set; }


            /// <summary>
            ///   Código do município de origem do serviço, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(3, "COD_MUN_ORIG", "N", 7, 0, true, 2)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///   Código do município de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(4, "COD_MUN_DEST", "N", 7, 0, true, 2)]
            public string CodMunDest { get; set; }


            /// <summary>
            ///       Indicador do tipo do veículo transportador:
            /// </summary>
            /// <remarks>
            ///      0- Embarcação;
            ///      <para />
            ///      1-Empurrador/rebocador
            /// </remarks>
            [SpedCampos(5, "IND_VEIC", "C", 1, 0, true, 2)]
            public string IndVeic { get; set; }

            /// <summary>
            ///   Identificação da embarcação (IRIM ou Registro CPP)
            /// </summary>
            [SpedCampos(6, "VEIC_ID", "C", 0, 0, false, 2)]
            public string VeicId { get; set; }

            /// <summary>
            ///      Indicador do tipo da navegação:
            /// </summary>
            /// <remarks>
            ///      0- Interior;
            ///      <para />
            ///      1-Cabotagem
            /// </remarks>
            [SpedCampos(7, "IND_NAV", "C", 1, 0, true, 2)]
            public string IndNav { get; set; }

            /// <summary>
            ///  Número da viagem
            /// </summary>
            [SpedCampos(8, "VIAGEM", "N", 0, 0, false, 2)]
            public string Viagem { get; set; }

            /// <summary>
            ///  Valor líquido do frete
            /// </summary>
            [SpedCampos(9, "VL_FRT_LIQ", "N", 0, 2, true, 2)]
            public string VlFrtLiq { get; set; }

            /// <summary>
            ///  Valor das despesas portuárias 
            /// </summary>
            [SpedCampos(10, "VL_DESP_PORT", "N", 0, 2, false, 2)]
            public string VlDespPort { get; set; }

            /// <summary>
            ///  Valor das despesas com carga e descarga 
            /// </summary>
            [SpedCampos(11, "VL_DESP_CAR_DESC", "N", 0, 2, false, 2)]
            public string VlDespCarDesC { get; set; }

            /// <summary>
            ///   Outros valores
            /// </summary>
            [SpedCampos(12, "VL_OUT", "N", 0, 2, false, 2)]
            public string VlOut { get; set; }

            /// <summary>
            ///  Valor brutodo frete
            /// </summary>
            [SpedCampos(13, "VL_FRT_BRT", "N", 0, 2, true, 2)]
            public string VlFrtBrt { get; set; }

            /// <summary>
            /// Valor adicional do frete para renovação da Marinha Mercante
            /// <summary>
            [SpedCampos(14, "VL_FRT_MM", "N", 0, 2, false, 2)]
            public string VlFrtMm { get; set; }

        }

        /// <summary>
        ///   REGISTRO D150: COMPLEMENTO DO CONHECIMENTO AÉREO (CÓDIGO 10)  
        /// </summary>
        public class RegistroD150 : RegistroSped
        {

            public RegistroD150() : base("D150")
            {
            }

            /// <summary>
            ///     Código do município de origem do serviço, conforme a tabela IBGE (Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(2, "COD_MUN_ORIG", "N", 7, 0, true, 2)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///    Código do município de destino, conforme a tabela IBGE (Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(3, "COD_MUN_DEST", "N", 7, 0, true, 2)]
            public string CodMunDest { get; set; }

            /// <summary>
            ///    Identificação da aeronave (DAC)
            /// </summary>
            [SpedCampos(4, "VEIC_ID", "C", 0, 0, false, 2)]
            public string VeicId { get; set; }

            /// <summary>
            ///    Número do vôo.
            /// </summary>
            [SpedCampos(5, "VIAGEM", "N", 0, 0, false, 2)]
            public string Viagem { get; set; }

            /// <summary>
            ///    Indicador do tipo de tarifa aplicada:
            /// </summary>
            /// <remarks>
            ///     0- Exp.;
            ///     <para />
            ///     1- Enc.;
            ///     <para />
            ///     2- C.I.;
            ///     <para />
            ///     9-Outra
            /// </remarks>
            [SpedCampos(6, "IND_TFA", "C", 1, 0, true, 2)]
            public string IndTfa { get; set; }

            /// <summary>
            ///   Peso taxado
            /// </summary>
            [SpedCampos(7, "VL_PESO_TX", "N", 0, 2, true, 2)]
            public string VlPesoTx { get; set; }

            /// <summary>
            ///   Valor da taxa terrestre
            /// </summary>
            [SpedCampos(8, "VL_TX_TERR", "N", 0, 2, false, 2)]
            public string VlTxTerr { get; set; }


            /// <summary>
            ///    Valor da taxa de redespacho
            /// </summary>
            [SpedCampos(9, "VL_TX_RED", "N", 0, 2, false, 2)]
            public string VlTxRed { get; set; }


            /// <summary>
            ///    Outros valores
            /// </summary>
            [SpedCampos(10, "VL_OUT", "N", 0, 2, false, 2)]
            public string VlOut { get; set; }

            /// <summary>
            ///    Valor da taxa "ad valorem"
            /// </summary>
            [SpedCampos(11, "VL_TX_ADV", "N", 0, 2, false, 2)]
            public string VlTxAdv { get; set; }

        }

        /// <summary>
        ///   REGISTRO D160: CARGA TRANSPORTADA (CÓDIGO 08, 8B, 09, 10, 11, 26 e 27)
        /// </summary>
        public class RegistroD160 : RegistroSped
        {
            public RegistroD160() : base("D160")
            {
            }

            /// <summary>
            ///   Identificação do número do despacho 
            /// </summary>
            [SpedCampos(2, "DESPACHO", "C", 0, 0, false, 2)]
            public string Despacho { get; set; }

            /// <summary>
            ///    CNPJ ou CPF do remetente das mercadorias que constam na nota fiscal.
            /// </summary>
            [SpedCampos(3, "CNPJ_CPF_REM", "N", 14, 0, false, 2)]
            public string CnpjCpfRem { get; set; }

            /// <summary>
            ///   Inscrição Estadual do remetente das mercadorias que constam na nota fiscal.
            /// </summary>
            [SpedCampos(4, "IE_REM", "C", 14, 0, false, 2)]
            public string IeRem { get; set; }

            /// <summary>
            ///    Código do Município de origem, conforme tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(5, "COD_MUN_ORI", "N", 7, 0, true, 2)]
            public string CodMunOri { get; set; }

            /// <summary>
            ///   CNPJ ou CPF do destinatário das mercadorias que constam na nota fiscal.
            /// </summary>
            [SpedCampos(6, "CNPJ_CPF_DEST", "N", 14, 0, false, 2)]
            public string CnpjCpfDest { get; set; }

            /// <summary>
            ///   Inscrição Estadual do destinatáriodas mercadorias que constam na nota fiscal.
            /// </summary>
            [SpedCampos(7, "IE_DEST", "C", 14, 0, false, 2)]
            public string IeDest { get; set; }

            /// <summary>
            ///   Código do Município de destino, conforme tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(8, "COD_MUN_DEST", "N", 7, 0, true, 2)]
            public string CodMunDest { get; set; }

            public RegistroD161 RegD161 { get; set; }
            public List<RegistroD162> RegD162s { get; set; }
        }

        /// <summary>
        ///  REGISTRO D161: LOCAL DA COLETA E ENTREGA (CÓDIGO 08, 8B, 09, 10, 11 e 26)
        /// </summary>
        public class RegistroD161 : RegistroSped
        {
            public RegistroD161() : base("D161")
            {
            }

            /// <summary>
            ///   Indicador do tipo de transporte da carga coletada:
            /// </summary>
            /// <remarks>
            ///   0-Rodoviário
            ///   <para />
            ///   1-Ferroviário
            ///   <para />
            ///   2-Rodo-Ferroviário
            ///   <para />
            ///   3-Aquaviário
            ///   <para />
            ///   4-Dutoviário
            ///   <para />
            ///   5-Aéreo
            ///   9-Outros
            /// </remarks>
            [SpedCampos(2, "IND_CARGA", "N", 1, 0, true, 2)]
            public string IndCarga { get; set; }

            /// <summary>
            ///    Número do CNPJ ou CPF do local da coleta.
            /// </summary>
            [SpedCampos(3, "CNPJ_CPF_COL", "C", 14, 0, false, 2)]
            public string CnpjCpfCol { get; set; }

            /// <summary>
            ///   Inscrição Estadual do contribuinte do local de coleta.
            /// </summary>
            [SpedCampos(4, "IE_Col", "C", 14, 0, false, 2)]
            public string IeCol { get; set; }

            /// <summary>
            ///    Código do Município do local de  coleta, conforme tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(5, "COD_MUN_COL", "N", 7, 0, true, 2)]
            public string CodMunCol { get; set; }

            /// <summary>
            ///   Número do CNPJ ou CPF do local da entrega
            /// </summary>
            [SpedCampos(6, "CNPJ_CPF_ENTG", "C", 14, 0, false, 2)]
            public string CnpjCpfEntg { get; set; }

            /// <summary>
            ///   Inscrição  Estadual  do  contribuinte  do  local  de entrega
            /// </summary>
            [SpedCampos(7, "IE_ENTG", "C", 14, 0, false, 2)]
            public string IeEntg { get; set; }

            /// <summary>
            ///    Código do Município do local de entrega, conforme tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(8, "COD_MUN_ENTG", "N", 7, 0, true, 2)]
            public string CodMunEntg { get; set; }
        }

        /// <summary>
        ///   REGISTRO  D162: IDENTIFICAÇÃO DOS DOCUMENTOS FISCAIS (CÓDIGOS 08, 8B, 09, 10, 11, 26 E 27)
        /// </summary>
        public class RegistroD162 : RegistroSped
        {
            public RegistroD162() : base("D162")
            {
            }

            /// <summary>
            ///    Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, false, 2)]
            public string CodMod { get; set; }

            /// <summary>
            ///   Série do documento fiscal
            /// </summary>
            [SpedCampos(3, "SER", "C", 4, 0, false, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///    Número do documento fiscal
            /// </summary>
            [SpedCampos(4, "NUM_DOC", "N", 9, 0, true, 2)]
            public string NumDoc { get; set; }

            /// <summary>
            ///   Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(5, "DT_DOC", "N", 8, 0, false, 2)]
            public string DtDoc { get; set; }

            /// <summary>
            ///   Valor total do documento fiscal 
            /// </summary>
            [SpedCampos(6, "VL_DOC", "N", 0, 2, false, 2)]
            public string VlDoc { get; set; }

            /// <summary>
            ///   Valor das mercadorias constantes no documento fiscal
            /// </summary>
            [SpedCampos(7, "VL_MERC", "N", 0, 2, false, 2)]
            public string VlMerc { get; set; }

            /// <summary>
            ///  Quantidade de volumes transportados
            /// </summary>
            [SpedCampos(8, "QTD_VOL", "N", 0, 0, true, 2)]
            public string QtdVol { get; set; }


            /// <summary>
            ///   Peso bruto dos volumes transportados (em kg)
            /// </summary>
            [SpedCampos(9, "PESO_BRT", "N", 0, 2, false, 2)]
            public string PesoBrt { get; set; }


            /// <summary>
            ///    Peso líquido dos volumes transportados (em kg)
            /// </summary>
            [SpedCampos(10, "PESO_LIQ", "N", 0, 2, false, 2)]
            public string PesoLiq { get; set; }
        }

        /// <summary>
        ///    REGISTRO  D170: COMPLEMENTO DO CONHECIMENTO MULTIMODAL DE CARGAS (CÓDIGO 26)
        /// </summary>
        public class RegistroD170 : RegistroSped
        {
            public RegistroD170() : base("D170")
            {
            }

            /// <summary>
            ///    Código do participante (campo 02 do Registro 0150):
            /// </summary>
            /// <remarks>
            ///   -consignatário, se houver
            /// </remarks>
            [SpedCampos(2, "COD_PART_CONSG", "C", 60, 0, false, 2)]
            public string CodPartConsg { get; set; }

            /// <summary>
            ///    Código do participante (campo 02 do Registro 0150):
            /// </summary>
            /// <remarks>
            ///  -redespachante, se houver
            /// </remarks>
            [SpedCampos(3, "COD_PART_RED", "C", 60, 0, false, 2)]
            public string CodPartRed { get; set; }

            /// <summary>
            ///    Código do município de origem do serviço, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(4, "COD_MUN_ORIG", "N", 7, 0, true, 2)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///    Código do município de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(5, "COD_MUN_DEST", "N", 7, 0, true, 2)]
            public string CodMunDest { get; set; }

            /// <summary>
            ///    Registro do operador de transporte multimodal
            /// </summary>
            [SpedCampos(6, "OTM", "C", 0, 0, true, 2)]
            public string Otm { get; set; }

            /// <summary>
            ///    Indicador da natureza do frete:
            /// </summary>
            /// <remarks>
            ///    0- Negociável;
            ///    <para />
            ///    1-Não negociável
            /// </remarks>
            [SpedCampos(7, "IND_NAT_FRT", "C", 1, 0, true, 2)]
            public string IndNatFrt { get; set; }

            /// <summary>
            ///   Valor líquido do frete
            /// </summary>
            [SpedCampos(8, "VL_LIQ_FRT", "N", 0, 2, true, 2)]
            public string VlLinqFrt { get; set; }

            /// <summary>
            ///   Valor do gris (gerenciamento de risco)
            /// </summary>
            [SpedCampos(9, "VL_GRIS", "N", 0, 2, false, 2)]
            public string VlGris { get; set; }

            /// <summary>
            ///   Somatório dos valores de pedágio
            /// </summary>
            [SpedCampos(10, "VL_PDG", "N", 0, 2, false, 2)]
            public string VlPdg { get; set; }

            /// <summary>
            ///    Outros valores
            /// </summary>
            [SpedCampos(11, "VL_OUT", "N", 0, 2, false, 2)]
            public string VlOut { get; set; }

            /// <summary>
            ///    Valor total do frete
            /// </summary>
            [SpedCampos(12, "VL_FRT", "N", 0, 2, true, 2)]
            public string VlFrt { get; set; }

            /// <summary>
            ///    Placa de identificação do veículo
            /// </summary>
            [SpedCampos(13, "VEIC_ID", "C", 7, 0, false, 2)]
            public string VeicId { get; set; }

            /// <summary>
            ///   Sigla da UF da placa do veículo
            /// <summary>
            [SpedCampos(14, "UF_ID", "C", 2, 0, false, 2)]
            public string UfId { get; set; }
        }

        /// <summary>
        ///  REGISTRO D180: MODAIS (CÓDIGO 26)
        /// </summary>
        public class RegistroD180 : RegistroSped
        {
            public RegistroD180() : base("D180")
            {
            }

            /// <summary>
            ///   Número de ordem sequencial do modal
            /// </summary>
            [SpedCampos(2, "NUM_SEQ", "N", 0, 0, true, 2)]
            public string NumSeq { get; set; }

            /// <summary>
            ///    Indicador do emitente do documento fiscal:
            /// </summary>
            /// <remarks>
            ///    0 - Emissão própria;
            ///    <para />
            ///    1 -Terceiros
            /// </remarks>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true, 2)]
            public string IndEmit { get; set; }

            /// <summary>
            ///   CNPJ ou CPF do participante emitente do modal
            /// </summary>
            [SpedCampos(4, "CNPJ_CPF_EMIT", "N", 14, 0, true, 2)]
            public string CnpjCpfEmit { get; set; }

            /// <summary>
            ///   Sigla da unidade da federação do participante emitente do modal
            /// </summary>
            [SpedCampos(5, "UF_EMIT", "C", 2, 0, true, 2)]
            public string UfEmit { get; set; }

            /// <summary>
            ///    Inscrição Estadual do participante emitente do modal
            /// </summary>
            [SpedCampos(6, "IE_EMIT", "C", 14, 0, false, 2)]
            public string IeEmit { get; set; }

            /// <summary>
            ///    Código do município de origem do serviço, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(7, "COD_MUN_ORIG", "N", 7, 0, true, 2)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///    CNPJ/CPF do participante tomador do serviço
            /// </summary>
            [SpedCampos(8, "CNPJ_CPF_TOM", "N", 14, 0, true, 2)]
            public string CnpjCpfTom { get; set; }

            /// <summary>
            ///    Sigla da unidade da federação do participante tomador do serviço
            /// </summary>
            [SpedCampos(9, "UF_TOM", "C", 2, 0, true, 2)]
            public string UfTom { get; set; }

            /// <summary>
            ///     Inscrição Estadual do participante tomador do serviço
            /// </summary>
            [SpedCampos(10, "IE_TOM", "C", 14, 0, false, 2)]
            public string IeTom { get; set; }

            /// <summary>
            ///     Código do município de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(11, "COD_MUN_DEST", "N", 7, 0, true, 2)]
            public string CodMunDest { get; set; }

            /// <summary>
            ///    Código do modelo do documento fiscal, conforme a Tabela 4.1.1 
            /// </summary>
            [SpedCampos(12, "COD_MOD", "C", 2, 0, true, 2)]
            public string CodMod { get; set; }

            /// <summary>
            ///    Série do documento fiscal
            /// </summary>
            [SpedCampos(13, "SER", "C", 4, 0, true, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///    Subsérie do documento fiscal
            /// <summary>
            [SpedCampos(14, "SUB", "N", 3, 0, false, 2)]
            public string Sub { get; set; }

            /// <summary>
            ///    Número do documento fiscal
            /// </summary>
            [SpedCampos(15, "NUM_DOC", "N", 9, 0, true, 2)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(16, "DT_DOC", "N", 8, 0, true, 2)]
            public string DtDoc { get; set; }

            /// <summary>
            ///     Valor total do documento fiscal
            /// </summary>
            [SpedCampos(17, "VL_DOC", "N", 0, 2, true, 2)]
            public string VlDoc { get; set; }
        }

        /// <summary>
        ///     REGISTRO D190: REGISTRO ANALÍTICO DOS DOCUMENTOS (CÓDIGO 07, 08, 8B, 09, 10, 11, 26, 27 e 57).
        /// </summary>
        public class RegistroD190 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroD190"/>.
            /// </summary>
            public RegistroD190() : base("D190")
            {
            }

            /// <summary>
            ///     Código da Situação Tributária referente ao ICMS, conforme a Tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true, 2)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação, conforme a tabela indicada no item 4.2.2
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true, 2)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, true, 2)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor da operação correspondente à combinação de CST_ICMS, CFOP, e alíquota do ICMS.
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true, 2)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///   Parcela correspondente ao "Valor da base de cálculo do ICMS" 
            ///   <para />
            ///   referente à combinação CST_ICMS, CFOP,e alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true, 2)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do ICMS" referente à combinação CST_ICMS,  CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true, 2)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///   Valor não tributado em função da redução da base de cálculo do ICMS,
            ///   <para />
            ///   referente à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(8, "VL_RED_BC", "N", 0, 2, true, 2)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Código da observação do lançamento fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(9, "COD_OBS", "C", 6, 0, false, 2)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO D195: OBSERVAÇÕES DO LANÇAMENTO FISCAL
        /// </summary>
        public class RegistroD195 : RegistroSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="RegistroD195"/>.
            /// </summary>
            public RegistroD195() : base("D195")
            {
            }

            /// <summary>
            ///     Código da observação do lançamento fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(2, "COD_OBS", "C", 6, 0, true, 6)]
            public string CodObs { get; set; }

            /// <summary>
            ///     Descrição complementar do código de observação
            /// </summary>
            [SpedCampos(3, "TXT_COMPL", "C", 0, 0, false, 6)]
            public string TxtCompl { get; set; }

            public List<RegistroD197> RegD197s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D197: OUTRAS OBRIGAÇÕES TRIBUTÁRIAS, AJUSTES E INFORMAÇÕES DE VALORES PROVENIENTES DE DOCUMENTO FISCAL.
        /// </summary>
        public class RegistroD197 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroD197" />.
            /// </summary>
            public RegistroD197() : base("D197")
            {
            }

            /// <summary>
            ///     Código do ajustes/benefício/incentivo, conforme tabela indicada no item 5.3
            /// </summary>
            [SpedCampos(2, "COD_AJ", "C", 10, 0, true, 6)]
            public string CodAj { get; set; }

            /// <summary>
            ///     Descrição complementar do ajuste do documento fiscal
            /// </summary>
            [SpedCampos(3, "DESCR_COMPL_AJ", "C", 999, 0, false, 6)]
            public string DescrComplAj { get; set; }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(4, "COD_ITEM", "C", 60, 0, false, 6)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Base de cálculo do ICMS ou do ICMS ST
            /// </summary>
            [SpedCampos(5, "VL_BC_ICMS", "N", 0, 2, false, 6)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "ALIQ_ICMS", "N", 6, 2, false, 6)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS ou do ICMS ST
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, false, 6)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Outros valores
            /// </summary>
            [SpedCampos(8, "VL_OUTROS", "N", 0, 2, false, 6)]
            public decimal VlOutros { get; set; }
        }

        /// <summary>
        ///    REGISTRO D300: REGISTRO ANALÍTICO DOS BILHETES CONSOLIDADOS DE PASSAGEM RODOVIÁRIO (CÓDIGO 13), 
        ///    <para />
        ///    DE PASSAGEM AQUAVIÁRIO (CÓDIGO 14), DE PASSAGEM E NOTA DE BAGAGEM (CÓDIGO 15) E DE PASSAGEM FERROVIÁRIO (CÓDIGO 16)
        /// </summary>
        public class RegistroD300 : RegistroSped
        {
            public RegistroD300() : base("D300")
            {
            }

            /// <summary>
            ///   Código do modelo do documento fiscal, conforme a Tabela 4.1.1 
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true, 2)]
            public string CodMod { get; set; }

            /// <summary>
            ///   Série do documento fiscal
            /// </summary>
            [SpedCampos(3, "SER", "C", 4, 0, true, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///   Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(4, "SUB", "N", 4, 0, false, 2)]
            public string Sub { get; set; }

            /// <summary>
            ///    Número do primeiro documento fiscal emitido (mesmo modelo, série e subsérie)
            /// </summary>
            [SpedCampos(5, "NUM_DOC_INI", "N", 6, 0, true, 2)]
            public string NumDocIni { get; set; }

            /// <summary>
            ///   Número do último documento fiscal emitido (mesmo modelo, série e subsérie)
            /// </summary>
            [SpedCampos(6, "NUM_DOC_FIN", "N", int.MaxValue, 0, true, 2)]
            public int NumDocFin { get; set; }

            /// <summary>
            ///   Código da Situação Tributária, conforme a Tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(7, "CST_ICMS", "N", 3, 0, true, 2)]
            public string CstIcms { get; set; }

            /// <summary>
            ///   Código Fiscal de Operação e Prestação conforme tabela indicada no item 4.2.2
            /// </summary>
            [SpedCampos(8, "CFOP", "N", 4, 0, true, 2)]
            public string Cfop { get; set; }

            /// <summary>
            ///   Alíquota do ICMS
            /// </summary>
            [SpedCampos(9, "ALIQ_ICMS", "N", 6, 2, false, 2)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///   Data da emissão dos documentos fiscais
            /// </summary>
            [SpedCampos(10, "DT_DOC", "N", 8, 0, true, 2)]
            public string DtDoc { get; set; }

            /// <summary>
            ///   Valor total acumulado das operações correspondentes à combinação de CST_ICMS, CFOP
            ///   <para />
            ///   e alíquota do ICMS, incluídas as despesas acessórias e acréscimos. 
            /// </summary>
            [SpedCampos(11, "VL_OPR", "N", 0, 2, true, 2)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///   Valor total dos descontos
            /// </summary>
            [SpedCampos(12, "VL_DESC", "N", 0, 2, false, 2)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///   Valor total da prestação de serviço
            /// </summary>
            [SpedCampos(13, "VL_SERV", "N", 0, 2, true, 2)]
            public decimal VlServ { get; set; }

            /// <summary>
            ///   Valor de seguro
            /// </summary>
            [SpedCampos(14, "VL_SEG", "N", 0, 2, false, 2)]
            public decimal VlSeg { get; set; }

            /// <summary>
            ///   Valor de outras despesas
            /// </summary>
            [SpedCampos(15, "VL_OUT_DESP", "N", 0, 2, false, 2)]
            public decimal VlOutDesp { get; set; }

            /// <summary>
            ///   Valor total da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(16, "VL_BC_ICMS", "N", 0, 2, true, 2)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///   Valor total do ICMS
            /// </summary>
            [SpedCampos(17, "VL_ICMS", "N", 0, 2, true, 2)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///   Valor não tributado em função da redução da base de cálculo do ICMS, 
            ///   <para />
            ///   referente à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(18, "VL_RED_BC", "N", 0, 2, true, 2)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///   Código da observação do lançamento fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(19, "COD_OBS", "C", 6, 0, false, 2)]
            public string CodObs { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(20, "COD_CTA", "C", 255, 0, false, 2)]
            public string CodCta { get; set; }

            public List<RegistroD301> RegD301s { get; set; }
            public List<RegistroD310> RegD310s { get; set; }
        }

        /// <summary>
        ///    REGISTRO D301: DOCUMENTOS CANCELADOS DOS BILHETES DE PASSAGEM RODOVIÁRIO (CÓDIGO 13), 
        ///    <para />
        ///    DE PASSAGEM AQUAVIÁRIO (CÓDIGO 14), DE PASSAGEM E NOTA DE BAGAGEM (CÓDIGO 15) E DE PASSAGEM FERROVIÁRIO (CÓDIGO 16). 
        /// </summary>
        public class RegistroD301 : RegistroSped
        {
            public RegistroD301() : base("D301")
            {
            }

            /// <summary>
            ///   Número do documento fiscal cancelado 
            /// </summary>
            [SpedCampos(2, "NUM_DOC_CANC", "N", 0, 0, true, 2)]
            public string NumDocCanc { get; set; }

        }
        /// <summary>
        ///    REGISTRO D310: COMPLEMENTO DOS BILHETES (CÓDIGO 13, 14, 15 E 16).
        /// </summary>
        public class RegistroD310 : RegistroSped
        {
            public RegistroD310() : base("D310")
            {
            }

            /// <summary>
            ///    Código do município de origem do serviço, conforme a tabela IBGE
            /// </summary>
            [SpedCampos(2, "COD_MUN_ORIG", "N", 7, 0, true, 2)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///    Valor total da prestação de serviço
            /// </summary>
            [SpedCampos(3, "VL_SERV", "N", 0, 2, true, 2)]
            public decimal VlServ { get; set; }

            /// <summary>
            ///    Valor total da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(4, "VL_BC_ICMS", "N", 0, 2, false, 2)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///    Valor total do ICMS
            /// </summary>
            [SpedCampos(5, "VL_ICMS", "N", 0, 2, false, 2)]
            public decimal VlIcms { get; set; }
        }

        /// <summary>
        ///   REGISTRO D350: EQUIPAMENTO ECF (CÓDIGOS 2E, 13, 14, 15 e 16)
        /// </summary>
        public class RegistroD350 : RegistroSped
        {
            public RegistroD350() : base("D350")
            {
            }

            /// <summary>
            ///    Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true, 2)]
            public string CodMod { get; set; }

            /// <summary>
            ///   Modelo do equipamento
            /// </summary>
            [SpedCampos(3, "ECF_MOD", "C", 20, 0, true, 2)]
            public string EcfMod { get; set; }

            /// <summary>
            ///   Número de série de fabricação do ECF
            /// </summary>
            [SpedCampos(4, "ECF_FAB", "C", 21, 0, true, 2)]
            public string EcfFab { get; set; }

            /// <summary>
            ///   Número do caixa atribuído ao ECF
            /// </summary>
            [SpedCampos(5, "ECF_CX", "N", 3, 0, true, 2)]
            public string EcfCx { get; set; }

            public List<RegistroD355> RegD355s { get; set; }
        }

        /// <summary>
        ///  REGISTRO D355: REDUÇÃO Z (CÓDIGOS 2E, 13, 14, 15 e 16). 
        /// </summary>
        public class RegistroD355 : RegistroSped
        {
            public RegistroD355() : base("D355")
            {
            }

            /// <summary>
            ///   Data do movimento a que se refere a Redução Z
            /// </summary>
            [SpedCampos(2, "DT_DOC", "N", 8, 0, true, 2)]
            public string DtDoc { get; set; }

            /// <summary>
            ///   Posição do Contador de Reinício de Operação
            /// </summary>
            [SpedCampos(3, "CRO", "N", 3, 0, true, 2)]
            public string Cro { get; set; }

            /// <summary>
            ///   Posição do Contador de Redução Z
            /// </summary>
            [SpedCampos(4, "CRZ", "N", 6, 0, true, 2)]
            public string Crz { get; set; }

            /// <summary>
            ///   Número do Contador de Ordem de Operação do último documento emitido no dia. (Número do COO na Redução Z)
            /// </summary>
            [SpedCampos(5, "NUM_COO_FIN", "N", 9, 0, true, 2)]
            public string NumCooFin { get; set; }

            /// <summary>
            ///   Valor do Grande Total final
            /// </summary>
            [SpedCampos(6, "GT_FIN", "N", 0, 2, true, 2)]
            public string GtFin { get; set; }

            /// <summary>
            ///   Valor da venda bruta
            /// </summary>
            [SpedCampos(7, "VL_BRT", "N", 0, 2, true, 2)]
            public string VlBrt { get; set; }

            public RegistroD360 RegD360s { get; set; }
            public List<RegistroD365> RegD365s { get; set; }
            public List<RegistroD390> RegD390s { get; set; }
        }

        /// <summary>
        ///   REGISTRO D360: PIS E COFINS TOTALIZADOS NO DIA (CÓDIGOS 2E, 13, 14, 15 e 16).
        /// </summary>
        public class RegistroD360 : RegistroSped
        {
            public RegistroD360() : base("D360")
            {
            }

            /// <summary>
            ///   Valor total do PIS
            /// </summary>
            [SpedCampos(2, "VL_PIS", "N", 0, 2, false, 2)]
            public string VlPis { get; set; }

            /// <summary>
            ///   Valor total da COFINS
            /// </summary>
            [SpedCampos(3, "VL_COFINS", "N", 0, 2, false, 2)]
            public string VlCofins { get; set; }

        }

        /// <summary>
        ///   REGISTRO D365: REGISTRO DOS TOTALIZADORES PARCIAIS DA  REDUÇÃO Z (CÓDIGOS 2E, 13, 14, 15 e 16).
        /// </summary>
        public class RegistroD365 : RegistroSped
        {
            public RegistroD365() : base("D365")
            {
            }

            /// <summary>
            ///   Código do totalizador, conforme Tabela 4.4.6
            /// </summary>
            [SpedCampos(2, "COD_TOT_PAR", "C", 7, 0, true, 2)]
            public string CodTotPar { get; set; }

            /// <summary>
            ///   Valor acumulado no totalizador, relativo à respectiva Redução Z.
            /// </summary>
            [SpedCampos(3, "VLR_ACUM_TOT", "N", 0, 2, true, 2)]
            public string VlrAcumTot { get; set; }

            /// <summary>
            ///   Número do totalizador quando ocorrer mais de uma situação com a mesma carga tributária efetiva.
            /// </summary>
            [SpedCampos(4, "NR_TOT", "N", 2, 0, false, 2)]
            public string NrTot { get; set; }

            /// <summary>
            ///   Descrição da situação tributária relativa ao totalizador parcial, 
            ///   <para />
            ///   quando houver mais de um com a mesma carga tributária efetiva.
            /// </summary>
            [SpedCampos(5, "DESCR_NR_TOT", "C", 0, 0, false, 2)]
            public string DescrNrTot { get; set; }

            public List<RegistroD370> RegD370s { get; set; }
        }

        /// <summary>
        ///   REGISTRO D370: COMPLEMENTO DOS DOCUMENTOS INFORMADOS (CÓDIGOS 13, 14, 15 e 16 e 2E)
        /// </summary>
        public class RegistroD370 : RegistroSped
        {
            public RegistroD370() : base("D370")
            {
            }

            /// <summary>
            ///   Código do município de origem do serviço, conforme a tabela IBGE
            /// </summary>
            [SpedCampos(2, "COD_MUN_ORIG", "N", 7, 0, true, 2)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///   Valor total da prestação de serviço
            /// </summary>
            [SpedCampos(3, "VL_SERV", "N", 0, 2, true, 2)]
            public string VlServ { get; set; }

            /// <summary>
            ///   Quantidade de bilhetes emitidos
            /// </summary>
            [SpedCampos(4, "QTD_BILH", "N", 0, 0, true, 2)]
            public string QtdBilh { get; set; }

            /// <summary>
            ///   Valor total da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(5, "VL_BC_ICMS", "N", 0, 2, false, 2)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///   Valor total do ICMS
            /// </summary>
            [SpedCampos(6, "VL_ICMS", "N", 0, 2, false, 2)]
            public string VlIcms { get; set; }

        }

        /// <summary>
        ///   REGISTRO D390: REGISTRO ANALÍTICO DO MOVIMENTO DIÁRIO (CÓDIGOS 13, 14, 15, 16 E 2E).
        /// </summary>
        public class RegistroD390 : RegistroSped
        {
            public RegistroD390() : base("D390")
            {
            }

            /// <summary>
            ///   Código da Situação Tributária, conforme a Tabela indicada no item 4.3.1.
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true, 2)]
            public string CstIcms { get; set; }

            /// <summary>
            ///   Código Fiscal de Operação e Prestação
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true, 2)]
            public string Cfop { get; set; }

            /// <summary>
            ///   Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false, 2)]
            public string AliqIcms { get; set; }

            /// <summary>
            ///   Valor da operação correspondente à combinação de CST_ICMS, CFOP, 
            ///   <para />
            ///   e alíquota do ICMS, incluídas as despesas acessórias e acréscimos 
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true, 2)]
            public string VlOpr { get; set; }

            /// <summary>
            ///   Valor da base de cálculo do ISSQN
            /// </summary>
            [SpedCampos(6, "VL_BC_ISSQN", "N", 0, 2, false, 2)]
            public string VlBcIssqn { get; set; }

            /// <summary>
            ///   Alíquota do ISSQN
            /// </summary>
            [SpedCampos(7, "ALIQ_ISSQN", "N", 6, 2, false, 2)]
            public string AliqIssqn { get; set; }

            /// <summary>
            ///   Valor do ISSQN
            /// </summary>
            [SpedCampos(8, "VL_ISSQN", "N", 0, 2, false, 2)]
            public string VlIssqn { get; set; }

            /// <summary>
            ///   Base de cálculo do ICMS acumulada relativa à alíquota informada
            /// </summary>
            [SpedCampos(9, "VL_BC_ICMS", "N", 0, 2, true, 2)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///   Valor do ICMS acumulado relativo à alíquota informada
            /// </summary>
            [SpedCampos(10, "VL_ICMS", "N", 0, 2, true, 2)]
            public string VlIcms { get; set; }

            /// <summary>
            ///   Código da observação do lançamento fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(11, "COD_OBS", "C", 6, 0, false, 2)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///   REGISTRO D400: RESUMO DE MOVIMENTO DIÁRIO - RMD (CÓDIGO 18).
        /// </summary>
        public class RegistroD400 : RegistroSped
        {
            public RegistroD400() : base("D400")
            {
            }

            /// <summary>
            ///   Código do participante (campo 02 do Registro 0150):-agência, filial ou posto
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, true, 2)]
            public string CodPart { get; set; }

            /// <summary>
            ///   Código do modelo do documento fiscal, conforme a Tabela 4.1.1 
            /// </summary>
            [SpedCampos(3, "COD_MOD", "C", 2, 0, true, 2)]
            public string CodMod { get; set; }

            /// <summary>
            ///   Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(4, "COD_SIT", "N", 2, 0, true, 2)]
            public string CodSit { get; set; }

            /// <summary>
            ///    Série do documento fiscal
            /// </summary>
            [SpedCampos(5, "SER", "C", 4, 0, false, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///   Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(6, "SUB", "N", 3, 0, false, 2)]
            public string Sub { get; set; }

            /// <summary>
            ///   Número do documento fiscal resumo.
            /// </summary>
            [SpedCampos(7, "NUM_DOC", "N", 6, 0, true, 2)]
            public string NumDoc { get; set; }

            /// <summary>
            ///   Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(8, "DT_DOC", "N", 8, 0, true, 2)]
            public string DtDoc { get; set; }

            /// <summary>
            ///   Valor total do documento fiscal
            /// </summary>
            [SpedCampos(9, "VL_DOC", "N", 0, 2, true, 2)]
            public string VlDoc { get; set; }

            /// <summary>
            ///   Valor acumulado dos descontos
            /// </summary>
            [SpedCampos(10, "VL_DESC", "N", 0, 2, false, 2)]
            public string VlDesc { get; set; }

            /// <summary>
            ///   Valor acumulado da prestação de serviço
            /// </summary>
            [SpedCampos(11, "VL_SERV", "N", 0, 2, true, 2)]
            public string VlServ { get; set; }

            /// <summary>
            ///   Valor total da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(12, "VL_BC_ICMS", "N", 0, 2, false, 2)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///   Valor total do ICMS
            /// </summary>
            [SpedCampos(13, "VL_ICMS", "N", 0, 2, false, 2)]
            public string VlIcms { get; set; }

            /// <summary>
            ///   Valor do PIS
            /// </summary>
            [SpedCampos(14, "VL_PIS", "N", 0, 2, false, 2)]
            public string VlPis { get; set; }

            /// <summary>
            ///   Valor da COFINS
            /// </summary>
            [SpedCampos(15, "VL_COFINS", "N", 0, 2, false, 2)]
            public string VlOfins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(16, "COD_CTA", "C", 0, 0, false, 2)]
            public string CodCta { get; set; }

            public List<RegistroD410> RegD410s { get; set; }
            public List<RegistroD420> RegD420s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D410: DOCUMENTOS INFORMADOS (CÓDIGOS 13, 14, 15 E 16).
        /// </summary>
        public class RegistroD410 : RegistroSped
        {
            public RegistroD410() : base("D410")
            {
            }

            /// <summary>
            ///   Código do modelo do documento fiscal , conforme a Tabela 4.1.1 
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true, 2)]
            public string CodMod { get; set; }

            /// <summary>
            ///   Série do documento fiscal 
            /// </summary>
            [SpedCampos(3, "SER", "C", 4, 0, true, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///   Subsérie do documento fisca
            /// </summary>
            [SpedCampos(4, "SUB", "N", 3, 0, false, 2)]
            public string Sub { get; set; }

            /// <summary>
            ///   Número do documento fiscal inicial (mesmo modelo, série e subsérie)
            /// </summary>
            [SpedCampos(5, "NUM_DOC_INI", "N", 6, 0, true, 2)]
            public string NumDocIni { get; set; }

            /// <summary>
            ///   Número do documento fiscal final(mesmo modelo, série e subsérie)
            /// </summary>
            [SpedCampos(6, "NUM_DOC_FIN", "N", 0, 0, true, 2)]
            public string NumDocFin { get; set; }

            /// <summary>
            ///   Data da emissão dos documentos fiscais
            /// </summary>
            [SpedCampos(7, "DT_DOC", "N", 8, 0, true, 2)]
            public string DtDoc { get; set; }

            /// <summary>
            ///   Código da Situação Tributária, conforme a Tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(8, "CST_ICMS", "N", 3, 0, true, 2)]
            public string CstIcms { get; set; }

            /// <summary>
            ///   Código Fiscal de Operação e Prestação
            /// </summary>
            [SpedCampos(9, "CFOP", "N", 4, 0, true, 2)]
            public string Cfop { get; set; }

            /// <summary>
            ///   Alíquota do ICMS
            /// </summary>
            [SpedCampos(10, "ALIQ_ICMS", "N", 6, 2, false, 2)]
            public string AliqIcms { get; set; }

            /// <summary>
            ///   Valor total acumulado das operações correspondentes à combinação de CST_ICMS, CFOP
            ///   <para />
            ///   e alíquota do ICMS,incluídas as despesas acessórias e acréscimos. 
            /// </summary>
            [SpedCampos(11, "VL_OPR", "N", 0, 2, true, 2)]
            public string VlOpr { get; set; }

            /// <summary>
            ///   Valor acumulado dos descontos
            /// </summary>
            [SpedCampos(12, "VL_DESC", "N", 0, 2, false, 2)]
            public string VlDesc { get; set; }

            /// <summary>
            ///   Valor acumulado da prestação de serviço
            /// </summary>
            [SpedCampos(13, "VL_SERV", "N", 0, 2, true, 2)]
            public string VlServ { get; set; }

            /// <summary>
            ///   Valor acumulado da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(14, "VL_BC_ICMS", "N", 0, 2, true, 2)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///   Valor acumulado do ICMS
            /// </summary>
            [SpedCampos(15, "VL_ICMS", "N", 0, 2, true, 2)]
            public string VlIcms { get; set; }

            public List<RegistroD411> RegD411s { get; set; }

        }

        /// <summary>
        ///   REGISTRO D411: DOCUMENTOS CANCELADOS DOS DOCUMENTOS INFORMADOS (CÓDIGO 13, 14, 15 e 16).
        /// </summary>
        public class RegistroD411 : RegistroSped
        {
            public RegistroD411() : base("D411")
            {
            }

            /// <summary>
            ///   Número do documento fiscal cancelado
            /// </summary>
            [SpedCampos(2, "NUM_DOC_CANC", "N", 0, 0, true, 2)]
            public string NumDocCanc { get; set; }

        }

        /// <summary>
        ///   REGISTRO D420: COMPLEMENTO DOS DOCUMENTOS INFORMADOS (CÓDIGO 13, 14,15 e 16).
        /// </summary>
        public class RegistroD420 : RegistroSped
        {
            public RegistroD420() : base("D420")
            {
            }

            /// <summary>
            ///   Código do município de origem do serviço, conforme a tabela IBGE
            /// </summary>
            [SpedCampos(2, "COD_MUN_ORIG", "N", 7, 0, true, 2)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///   Valor total da prestação de serviço
            /// </summary>
            [SpedCampos(3, "VL_SERV", "N", 0, 2, true, 2)]
            public string VlServ { get; set; }

            /// <summary>
            ///   Valor total da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(4, "VL_BC_ICMS", "N", 0, 2, true, 2)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///    Valor total do ICMS
            /// </summary>
            [SpedCampos(5, "VL_ICMS", "N", 0, 2, true, 2)]
            public string VlIcms { get; set; }

        }

        /// <summary>
        ///     REGISTRO D500: NOTA FISCAL DE SERVIÇO DE COMUNICAÇÃO (CÓDIGO 21) E NOTA FISCAL DE SERVIÇO DE TELECOMUNICAÇÃO (CÓDIGO 22)
        /// </summary>
        public class RegistroD500 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD500"/>.
            /// </summary>
            public RegistroD500() : base("D500")
            {
            }

            /// <summary>
            ///     Indicador do tipo de operação:
            ///     <para />
            ///     0 - Aquisição;
            ///     <para />
            ///     1 - Prestação;
            /// </summary>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true, 2)]
            public IndTipoOperacaoServico IndOper { get; set; }

            /// <summary>
            ///     Indicador do emitente do documento fiscal:
            ///     <para />
            ///     0 - Emissao própria;
            ///     <para />
            ///     1 - Terceiros;
            /// </summary>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true, 2)]
            public IndEmitente IndEmit { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150);
            ///     <para />
            ///     -do prestador do serviço, no caso de aquisição;
            ///     <para />
            ///     -do tomador do serviço, no caso de prestação;
            /// </summary>
            [SpedCampos(4, "COD_PART", "C", 60, 0, true, 2)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(5, "COD_MOD", "C", 2, 0, true, 2)]
            public IndCodMod CodMod { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(6, "COD_SIT", "N", 2, 0, true, 2)]
            public IndCodSitDoc CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(7, "SER", "C", 4, 0, false, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(8, "SUB", "C", 3, 0, false, 2)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(9, "NUM_DOC", "N", 9, 0, true, 2)]
            public decimal NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(10, "DT_DOC", "N", 8, 0, true, 2)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Data da entrada(aquisição) ou da saida(prestação do serviço)
            /// </summary>
            [SpedCampos(11, "DT_A_P", "N", 8, 0, false, 2)]
            public DateTime? DtAP { get; set; }

            /// <summary>
            ///     Valor total do documento fiscal
            /// </summary>
            [SpedCampos(12, "VL_DOC", "N", 0, 2, true, 2)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(13, "VL_DESC", "N", 0, 2, false, 2)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Valor da prestação de serviços
            /// </summary>
            [SpedCampos(14, "VL_SERV", "N", 0, 2, true, 2)]
            public decimal VlServ { get; set; }

            /// <summary>
            ///     Valor total dos serviços não-tributados pelo ICMS
            /// </summary>
            [SpedCampos(15, "VL_SERV_NT", "N", 0, 2, false, 2)]
            public decimal VlServNt { get; set; }

            /// <summary>
            ///     Valores cobrados em nome de terceiros
            /// </summary>
            [SpedCampos(16, "VL_TERC", "N", 0, 2, false, 2)]
            public decimal VlTerc { get; set; }

            /// <summary>
            ///     Valor de outras despesas indicadas no documento fiscal
            /// </summary>
            [SpedCampos(17, "VL_DA", "N", 0, 2, false, 2)]
            public decimal VlDa { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(18, "VL_BC_ICMS", "N", 0, 2, false, 2)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS
            /// </summary>
            [SpedCampos(19, "VL_ICMS", "N", 0, 2, false, 2)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Código da informação complementar (campo 02 do Registro 0450)
            /// </summary>
            [SpedCampos(20, "COD_INF", "C", 6, 0, false, 2)]
            public string CodInf { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(21, "VL_PIS", "N", 0, 2, false, 2)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(22, "VL_COFINS", "N", 0, 2, false, 2)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(23, "COD_CTA", "C", 0, 0, false, 2)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Código do Tipo de Assinante:
            ///     <para />
            ///     1 - Comercial/Industrial
            ///     <para />
            ///     2 - Poder Público
            ///     <para />
            ///     3 - Residencial/Pessoa física
            ///     <para />
            ///     4 - Público
            ///     <para/>
            ///     5 - Semi-Público
            ///     <para />
            ///     6 - Outros
            /// </summary>
            [SpedCampos(24, "TP_ASSINANTE", "N", 1, 0, false, 3)]
            public string TpAssinante { get; set; }

            public List<RegistroD510> RegD510s { get; set; }
            public List<RegistroD530> RegD530s { get; set; }
            public List<RegistroD590> RegD590s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D510: ITENS DO DOCUMENTO - NOTA FISCAL DE SERVIÇO DE COMUNICAÇÃO (CÓDIGO 21) E SERVIÇO DE TELECOMUNICAÇÃO (CÓDIGO 22).
        /// </summary>
        public class RegistroD510 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD510"/>.
            /// </summary>
            public RegistroD510() : base("D510")
            {
            }

            /// <summary>
            ///     Número sequencial do item no documento fiscal
            /// </summary>
            [SpedCampos(2, "NUM_ITEM", "N", 3, 0, true, 2)]
            public int NumItem { get; set; }

            /// <summary>
            ///     Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true, 2)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Código de classificação do item do serviço de comunicação ou de telecomunicação, conforme a Tabela 4.4.1
            /// </summary>
            [SpedCampos(4, "COD_CLASS", "N", 4, 0, true, 2)]
            public int CodClass { get; set; }

            /// <summary>
            ///     Quantidade do item
            /// </summary>
            [SpedCampos(5, "QTD", "N", 0, 3, true, 2)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Unidade do item (Campo 02 do registro 0190)
            /// </summary>
            [SpedCampos(6, "UNID", "C", 6, 0, true, 2)]
            public string Unid { get; set; }

            /// <summary>
            ///     Valor do item
            /// </summary>
            [SpedCampos(7, "VL_ITEM", "N", 0, 2, true, 2)]
            public decimal Vl_Item { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(8, "VL_DESC", "N", 0, 2, false, 2)]
            public decimal Vl_Desc { get; set; }

            /// <summary>
            ///     Código da Situação Tributária, conforme a Tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(9, "CST_ICMS", "N", 3, 0, true, 2)]
            public decimal CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação
            /// </summary>
            [SpedCampos(10, "CFOP", "N", 4, 0, true, 2)]
            public decimal Cfop { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(11, "VL_BC_ICMS", "N", 0, 2, false, 2)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(12, "ALIQ_ICMS", "N", 6, 2, false, 2)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS creditado/debitado
            /// </summary>
            [SpedCampos(13, "VL_ICMS", "N", 0, 2, false, 2)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS de outras UFs
            /// </summary>
            [SpedCampos(14, "VL_BC_ICMS_UF", "N", 0, 2, false, 2)]
            public decimal VlBcIcmsUf { get; set; }

            /// <summary>
            ///     Valor do ICMS de outras UFs
            /// </summary>
            [SpedCampos(15, "VL_ICMS_UF", "N", 0, 2, false, 2)]
            public decimal VlIcmsUf { get; set; }

            /// <summary>
            ///     Indicador do tipo de receita:
            ///     <para />
            ///     0 - Receita própria - serviços prestados;
            ///     <para />
            ///     1 - Receita própria - cobrança de débitos;
            ///     <para />
            ///     2 - Receita própria - venda de mercadorias;
            ///     <para />
            ///     3 - Receita própria - venda de serviço pré-pago;
            ///     <para />
            ///     4 - Outras receitas próprias;
            ///     <para />
            ///     5 - Receitas de terceiros (co-faturamento);
            ///     <para />
            ///     9 - Outras receitas de terceiros;
            /// </summary>
            [SpedCampos(16, "IND_REC", "C", 1, 0, true, 2)]
            public string IndRec { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150) receptor da receita, terceiro da operação, se houver.
            /// </summary>
            [SpedCampos(17, "COD_PART", "C", 60, 0, false, 2)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(18, "VL_PIS", "N", 0, 2, false, 2)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(19, "VL_COFINS", "N", 0, 2, false, 2)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(20, "COD_CTA", "C", 0, 0, false, 2)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO D530: TERMINAL FATURADO.
        /// </summary>
        public class RegistroD530 : RegistroSped
        {
            /// <summary>
            ///    Inicializa uma nova instância da classe <see cref="RegistroD530"/>.
            /// </summary>
            public RegistroD530() : base("D530")
            {
            }

            /// <summary>
            ///     Indicador do tipo de serviço prestado:
            /// </summary>
            /// <remarks>
            ///         0- Telefonia;
            ///         <para />
            ///         1- Comunicação de dados;
            ///         <para />
            ///         2- TV por assinatura;
            ///         <para />
            ///         3- Provimento de acesso à Internet;
            ///         <para />
            ///         4- Multimídia;
            ///         <para />
            ///         9- Outros
            /// </remarks>
            [SpedCampos(2, "IND_SERV", "C", 1, 0, true, 2)]
            public string IndServ { get; set; }

            /// <summary>
            ///     Data em que se iniciou a prestação do serviço
            /// </summary>
            [SpedCampos(3, "DT_INI_SERV", "N", 8, 0, false, 2)]
            public DateTime? DtIniServ { get; set; }

            /// <summary>
            ///     Data em que se encerrou a prestação do serviço
            /// </summary>
            [SpedCampos(4, "DT_FIN_SERV", "N", 8, 0, false, 2)]
            public DateTime? DtFinServ { get; set; }

            /// <summary>
            ///     Período fiscal da prestação do serviço (MMAAAA)
            /// </summary>
            [SpedCampos(5, "PER_FISCAL", "MA", 6, 0, true, 2)]
            public DateTime PerFiscal { get; set; }

            /// <summary>
            ///     Código de área do terminal faturado
            /// </summary>
            [SpedCampos(6, "COD_AREA", "C", int.MaxValue, 0, false, 2)]
            public string CodArea { get; set; }

            /// <summary>
            ///     Identificação do terminal faturado
            /// </summary>
            [SpedCampos(7, "TERMINAL", "N", int.MaxValue, 0, false, 2)]
            public string Terminal { get; set; }
        }

        /// <summary>
        ///     REGISTRO D590: REGISTRO ANALÍTICO DO DOCUMENTO (CÓDIGO 21 E 22).
        /// </summary>
        public class RegistroD590 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD590"/>.
            /// </summary>
            public RegistroD590() : base("D590")
            {
            }

            /// <summary>
            ///     Código da Situação Tributária, conforme a tabela indicada no item 4.3.1.
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true, 2)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação, conforme a tabela indicada no item 4.2.2.
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true, 2)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS.
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false, 2)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor da operação correspondente à combinação de CST_ICMS, CFOP, 
            ///     <para />
            ///     e alíquota do ICMS, incluídas as despesas acessórias e acrescímos.
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true, 2)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor da base de cálculo do ICMS" referente à combinação CST_ICMS, CFOP, e alíquota do ICMS. 
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true, 2)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do ICMS" referente à combinação CST_ICMS, CFOP, e alíquota do ICMS.
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true, 2)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao valor da base de cálculo do ICMS de outras UFs, referente à combinação de CST_ICMS, CFOP, e alíquota do ICMS. 
            /// </summary>
            [SpedCampos(8, "VL_BC_ICMS_UF", "N", 0, 2, true, 2)]
            public decimal VlBcIcmsUf { get; set; }

            /// <summary>
            ///     Parcela correspondente ao valor do ICMS de outras UFs, referente à combinação de CST_ICMS, CFOP, e alíquota do ICMS. 
            /// </summary>
            [SpedCampos(9, "VL_ICMS_UF", "N", 0, 2, true, 2)]
            public decimal VlIcmsUf { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do ICMS, referente à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(10, "VL_RED_BC", "N", 0, 2, true, 2)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Código da observação (campo 02 do Registro 0460).
            /// </summary>
            [SpedCampos(11, "COD_OBS", "C", 6, 0, false, 2)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO D600: CONSOLIDAÇÃO DA PRESTAÇÃO DE SERVIÇOS - NOTAS DE SERVIÇO DE COMUNICAÇÃO (CÓDIGO  21) E DE SERVIÇO DE TELECOMUNICAÇÃO (CÓDIGO 22).
        /// </summary>
        public class RegistroD600 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD600"/>.
            /// </summary>
            public RegistroD600() : base("D600")
            {
            }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true, 2)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código do município dos terminais faturados, conforme a tabela IBGE
            /// </summary>
            [SpedCampos(3, "COD_MUN", "N", 7, 0, true, 2)]
            public string CodMun { get; set; }

            /// <summary>
            ///   Série do documento fiscal
            /// </summary>
            [SpedCampos(4, "SER", "C", 4, 0, true, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///   Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(5, "SUB", "N", 3, 0, false, 2)]
            public string Sub { get; set; }

            /// <summary>
            ///     Código de classe de consumo dos serviços de comunicação ou de telecomunicação, conforme a Tabela 4.4.4
            /// </summary>
            [SpedCampos(6, "COD_CONS", "N", 2, 0, true, 2)]
            public string CodCons { get; set; }

            /// <summary>
            ///     Quantidade de documentos consolidados neste registro
            /// </summary>
            [SpedCampos(7, "QTD_CONS", "N", 0, 0, true, 2)]
            public string QtdCons { get; set; }

            /// <summary>
            ///    Data dos documentos consolidados
            /// </summary>
            [SpedCampos(8, "DT_DOC", "N", 8, 0, true, 2)]
            public DateTime? DtDoc { get; set; }

            /// <summary>
            ///     Valor total acumulado dos documentos fiscais
            /// </summary>
            [SpedCampos(9, "VL_DOC", "N", 0, 2, true, 2)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Valor acumulado dos descontos
            /// </summary>
            [SpedCampos(10, "VL_DESC", "N", 0, 2, false, 2)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Valor acumulado das prestações de serviços tributados pelo ICMS
            /// </summary>
            [SpedCampos(11, "VL_SERV", "N", 0, 2, true, 2)]
            public decimal VlServ { get; set; }

            /// <summary>
            ///     Valor acumulado dos serviços não-tributados pelo ICMS
            /// </summary>
            [SpedCampos(12, "VL_SERV_NT", "N", 0, 2, false, 2)]
            public decimal VlServNt { get; set; }

            /// <summary>
            ///     Valores cobrados em nome de terceiros
            /// </summary>
            [SpedCampos(13, "VL_TERC", "N", 0, 2, false, 2)]
            public decimal VlTerc { get; set; }

            /// <summary>
            ///     Valor acumulado das despesas acessórias
            /// </summary>
            [SpedCampos(14, "VL_DA", "N", 0, 2, false, 2)]
            public decimal VlDa { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(15, "VL_BC_ICMS", "N", 0, 2, true, 2)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor acumulado do ICMS
            /// </summary>
            [SpedCampos(16, "VL_ICMS", "N", 0, 2, true, 2)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(17, "VL_PIS", "N", 0, 2, false, 2)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(18, "VL_COFINS", "N", 0, 2, false, 2)]
            public decimal VlCofins { get; set; }

            public List<RegistroD610> RegD610s { get; set; }
            public List<RegistroD690> RegD690s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D610: ITENS DO DOCUMENTO CONSOLIDADO (CÓDIGO 21 E 22).
        /// </summary>
        public class RegistroD610 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD610"/>.
            /// </summary>
            public RegistroD610() : base("D610")
            {
            }

            /// <summary>
            ///     Código de classificação do item do serviço de comunicação ou de telecomunicação, conforme a Tabela 4.4.1
            /// </summary>
            [SpedCampos(2, "COD_CLASS", "N", 4, 0, true, 2)]
            public int CodClass { get; set; }


            /// <summary>
            ///     Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true, 2)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade acumulada do item
            /// </summary>
            [SpedCampos(4, "QTD", "N", 0, 3, true, 2)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Unidade do item (Campo 02 do registro 0190)
            /// </summary>
            [SpedCampos(5, "UNID", "C", 6, 0, true, 2)]
            public string Unid { get; set; }

            /// <summary>
            ///    Valor acumulado do item
            /// </summary>
            [SpedCampos(6, "VL_ITEM", "N", 0, 2, true, 2)]
            public decimal Vl_Item { get; set; }

            /// <summary>
            ///     Valor acumulado dos descontos
            /// </summary>
            [SpedCampos(7, "VL_DESC", "N", 0, 2, false, 2)]
            public decimal Vl_Desc { get; set; }

            /// <summary>
            ///     Código da Situação Tributária, conforme a Tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(8, "CST_ICMS", "N", 3, 0, true, 2)]
            public decimal CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação conforme tabela indicada no item 4.2.2.
            /// </summary>
            [SpedCampos(9, "CFOP", "N", 4, 0, true, 2)]
            public decimal Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(10, "ALIQ_ICMS", "N", 6, 2, false, 2)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(11, "VL_BC_ICMS", "N", 0, 2, false, 2)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS creditado/debitado
            /// </summary>
            [SpedCampos(12, "VL_ICMS", "N", 0, 2, false, 2)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS de outras UFs
            /// </summary>
            [SpedCampos(13, "VL_BC_ICMS_UF", "N", 0, 2, false, 2)]
            public decimal VlBcIcmsUf { get; set; }

            /// <summary>
            ///     Valor do ICMS de outras UFs
            /// </summary>
            [SpedCampos(14, "VL_ICMS_UF", "N", 0, 2, false, 2)]
            public decimal VlIcmsUf { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do ICMS,referente à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(15, "VL_RED_BC", "N", 0, 2, false, 2)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Valor acumulado do PIS
            /// </summary>
            [SpedCampos(16, "VL_PIS", "N", 0, 2, false, 2)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor acumulado da COFINS
            /// </summary>
            [SpedCampos(17, "VL_COFINS", "N", 0, 2, false, 2)]
            public string VlCofins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(18, "COD_CTA", "C", 0, 0, false, 2)]
            public decimal CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO D690: REGISTRO ANALÍTICO DOS DOCUMENTOS (CÓDIGOS 21 e 22).
        /// </summary>
        public class RegistroD690 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD690"/>.
            /// </summary>
            public RegistroD690() : base("D690")
            {
            }

            /// <summary>
            ///   Código da Situação Tributária, conforme a tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true, 2)]
            public decimal CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação conforme tabela indicada no item 4.2.2.
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true, 2)]
            public decimal Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false, 2)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///    Valor da operação correspondente à combinação  de  CST_ICMS,  CFOP,  e  alíquota do  ICMS,  incluídas  as  despesas  acessórias  e acréscimos 
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true, 2)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Parcela  correspondente  ao  “Valor  da  base  de cálculo   do   ICMS”   referente   à   combinação CST_ICMS, CFOP, e alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true, 2)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela  correspondente  ao  "Valor  do  ICMS" referente  à  combinação  CST_ICMS,  CFOP,  e alíquota do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true, 2)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Parcela  correspondente  ao  valor  da  base  de cálculo  do  ICMS  de  outras  UFs,  referente  à combinação  de  CST_ICMS,  CFOP  e  alíquota do ICMS.
            /// </summary>
            [SpedCampos(8, "VL_BC_ICMS_UF", "N", 0, 2, true, 2)]
            public decimal VlBcIcmsUf { get; set; }

            /// <summary>
            ///    Parcela  correspondente  ao  valor  do  ICMS  de outras  UFs,  referente  à  combinação  de  CST ICMS, CFOP, e alíquota do ICMS.
            /// </summary>
            [SpedCampos(9, "VL_ICMS_UF", "N", 0, 2, true, 2)]
            public decimal VlIcmsUf { get; set; }

            /// <summary>
            ///     Valor  não  tributado  em  função  da  redução  da base    de    cálculo    do    ICMS,    referente    à combinação  de  CST_ICMS,  CFOP  e  alíquota do ICMS.
            /// </summary>
            [SpedCampos(10, "VL_RED_BC", "N", 0, 2, true, 2)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            /// Código  da  observação  do  lançamento  fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(11, "COD_OBS", "C", 6, 0, false, 2)]
            public int CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO D695: CONSOLIDAÇÃO DA PRESTAÇÃO DE SERVIÇOS – NOTAS DE SERVIÇO DE COMUNICAÇÃO (CÓDIGO  21) E DE SERVIÇO DE TELECOMUNICAÇÃO (CÓDIGO 22) 
        ///     (EMPRESAS OBRIGADAS À ENTREGA DOS ARQUIVOS PREVISTOS NO CONVÊNIO ICMS 115/03).
        /// </summary>
        public class RegistroD695 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD695"/>.
            /// </summary>
            public RegistroD695() : base("D695")
            {
            }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true, 2)]
            public string CodMod { get; set; }

            /// <summary>
            ///   Série do documento fiscal
            /// </summary>
            [SpedCampos(3, "SER", "C", 4, 0, true, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///     Número de ordem inicial
            /// </summary>
            [SpedCampos(4, "NRO_ORD_INI", "N", 9, 0, true, 2)]
            public string NroOrdIni { get; set; }

            /// <summary>
            ///    Número de ordem final
            /// </summary>
            [SpedCampos(5, "NRO_ORD_FIN", "N", 9, 0, true, 2)]
            public string NroOrdFin { get; set; }

            /// <summary>
            ///  Data de emissão inicial dos documentos / Data inicial de vencimento da fatura
            /// </summary>
            [SpedCampos(6, "DT_DOC_INI", "N", 8, 0, true, 2)]
            public string DtDocIni { get; set; }

            /// <summary>
            ///  Data de emissão final dos documentos / Data final do vencimento da fatura
            /// </summary>
            [SpedCampos(7, "DT_DOC_FIN", "N", 8, 0, true, 2)]
            public string DtDocFin { get; set; }

            /// <summary>
            ///  Nome do arquivo Mestre de Documento Fiscal
            /// </summary>
            [SpedCampos(8, "NOM_MEST", "C", 33, 0, true, 2)]
            public string NomMest { get; set; }

            /// <summary>
            ///  Chave de codificação digital do arquivo Mestre de Documento Fiscal
            /// </summary>
            [SpedCampos(9, "CHV_COD_DIG", "C", 32, 0, true, 2)]
            public string ChvCodDig { get; set; }

            public List<RegistroD696> RegD696s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D696: REGISTRO ANALÍTICO DOS DOCUMENTOS (CÓDIGO 21 E 22).
        /// </summary>
        public class RegistroD696 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD696"/>.
            /// </summary>
            public RegistroD696() : base("D696")
            {
            }

            /// <summary>
            ///   Código da Situação Tributária, conforme a tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true, 2)]
            public decimal CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação conforme tabela indicada no item 4.2.2.
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true, 2)]
            public decimal Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false, 2)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///    Valor da operação correspondente à combinação  de  CST_ICMS,  CFOP,  e  alíquota do  ICMS,  incluídas  as  despesas  acessórias  e acréscimos 
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true, 2)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Parcela  correspondente  ao  “Valor  da  base  de cálculo   do   ICMS”   referente   à   combinação CST_ICMS, CFOP, e alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true, 2)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela  correspondente  ao  "Valor  do  ICMS" referente  à  combinação  CST_ICMS,  CFOP,  e alíquota do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true, 2)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Parcela  correspondente  ao  valor  da  base  de cálculo  do  ICMS  de  outras  UFs,  referente  à combinação  de  CST_ICMS,  CFOP  e  alíquota do ICMS.
            /// </summary>
            [SpedCampos(8, "VL_BC_ICMS_UF", "N", 0, 2, true, 2)]
            public decimal VlBcIcmsUf { get; set; }

            /// <summary>
            ///    Parcela  correspondente  ao  valor  do  ICMS  de outras  UFs,  referente  à  combinação  de  CST ICMS, CFOP, e alíquota do ICMS.
            /// </summary>
            [SpedCampos(9, "VL_ICMS_UF", "N", 0, 2, true, 2)]
            public decimal VlIcmsUf { get; set; }

            /// <summary>
            ///     Valor  não  tributado  em  função  da  redução  da base    de    cálculo    do    ICMS,    referente    à combinação  de  CST_ICMS,  CFOP  e  alíquota do ICMS.
            /// </summary>
            [SpedCampos(10, "VL_RED_BC", "N", 0, 2, true, 2)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            /// Código  da  observação  do  lançamento  fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(11, "COD_OBS", "C", 6, 0, false, 2)]
            public int CodObs { get; set; }

            public List<RegistroD697> RegD697s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D697:  REGISTRO  DE  INFORMAÇÕES  DE  OUTRAS  UFs,  RELATIVAMENTE AOS SERVIÇOS “NÃO-MEDIDOS” DE TELEVISÃO POR ASSINATURA VIA SATÉLITE.
        /// </summary>
        public class RegistroD697 : RegistroSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD697"/>.
            /// </summary>
            public RegistroD697() : base("D697")
            {
            }

            /// <summary>
            ///    Sigla da unidade da federação
            /// </summary>
            [SpedCampos(2, "Uf", "C", 2, 0, true, 2)]
            public decimal Uf { get; set; }

            // <summary>
            ///    Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(3, "VL_BC_ICMS", "N", 0, 2, true, 2)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS 
            /// </summary>
            [SpedCampos(4, "VL_ICMS", "N", 0, 2, true, 2)]
            public decimal VlIcms { get; set; }
        }

        /// <summary>
        ///     REGISTRO D700:  NOTA FISCAL FATURA ELETRÔNICA DE SERVIÇOS DE COMUNICAÇÃO – NFCom(CÓDIGO 62).
        /// </summary>
        [SpedRegistros("01/01/2023", "")]
        public class RegistroD700 : RegistroSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="RegistroD700"/>.
            /// </summary>
            public RegistroD700() : base("D700")
            {
            }

            /// <summary>
            ///     Indicador do tipo de operação:
            ///     0- Entrada;
            ///     1- Saiía
            /// </summary>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true, 17)]
            public int IndOper { get; set; }

            /// <summary>
            ///     Indicador do emitente do documento fiscal:
            ///     0 - Emissão própria;
            ///     1 - Terceiros;
            /// </summary>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true, 17)]
            public int IndEmit { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150) do prestador, no caso de entradas.
            /// </summary>
            [SpedCampos(4, "COD_PART", "C", 60, 0, true, 17)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1.
            /// </summary>
            [SpedCampos(5, "COD_MOD", "C", 2, 0, true, 17)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal, conforme a Tabela 4.1.2.
            /// </summary>
            [SpedCampos(6, "COD_SIT", "N", 2, 0, true, 17)]
            public int CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal.
            /// </summary>
            [SpedCampos(7, "SER", "N", 3, 0, false, 17)]
            [SpedCampos(7, "SER", "N", 3, 0, true, 18)]
            public string Ser { get; set; }

            /// <summary>
            ///     Número do documento fiscal.
            /// </summary>
            [SpedCampos(8, "NUM_DOC", "N", 9, 0, true, 17)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal.
            /// </summary>
            [SpedCampos(9, "DT_DOC", "N", 8, 0, true, 17)]
            public DateTime? DtDoc { get; set; }

            /// <summary>
            ///     Data da entrada ou da saída.
            /// </summary>
            [SpedCampos(10, "DT_E_S", "N", 8, 0, false, 17)]
            public DateTime? DtEs { get; set; }

            /// <summary>
            ///     Valor do documento fiscal.
            /// </summary>
            [SpedCampos(11, "VL_DOC", "N", 0, 2, true, 17)]
            public decimal? VlDoc { get; set; }

            /// <summary>
            ///     Valor do desconto.
            /// </summary>
            [SpedCampos(12, "VL_DESC", "N", 0, 2, false, 17)]
            public decimal? VlDesc { get; set; }

            /// <summary>
            ///     Valor total do serviços tributados pelo ICMS.
            /// </summary>
            [SpedCampos(13, "VL_SERV", "N", 0, 2, true, 17)]
            public decimal? VlServ { get; set; }

            /// <summary>
            ///     Valores cobrados em nome do prestador sem destaque de ICMS.
            /// </summary>
            [SpedCampos(14, "VL_SERV_NT", "N", 0, 2, false, 17)]
            public decimal? VlServNt { get; set; }

            /// <summary>
            ///     Valores cobrados em nome de terceiros.
            /// </summary>
            [SpedCampos(15, "VL_TERC", "N", 0, 0, false, 17)]
            public decimal? VlTerc { get; set; }

            /// <summary>
            ///     Valor de despesas acessórias indicadas no documento fiscal.
            /// </summary>
            [SpedCampos(16, "VL_DA", "N", 0, 2, false, 17)]
            public decimal? VlDa { get; set; }

            /// <summary>
            ///     Valor da Base de Cálculo (BC) do ICMS.
            /// </summary>
            [SpedCampos(17, "VL_BC_ICMS", "N", 0, 2, false, 17)]
            public decimal? VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS.
            /// </summary>
            [SpedCampos(18, "VL_ICMS", "N", 0, 2, false, 17)]
            public decimal? VlIcms { get; set; }

            /// <summary>
            ///     Código da informação complementar do documento fiscal(campo 02 do Registro 0450).
            /// </summary>
            [SpedCampos(19, "COD_INF", "C", 6, 0, false, 17)]
            public string CodInf { get; set; }

            /// <summary>
            ///     Valor do PIS/Pasep.
            /// </summary>
            [SpedCampos(20, "VL_PIS", "N", 0, 2, false, 17)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Valor do Cofins.
            /// </summary>
            [SpedCampos(21, "VL_COFINS", "N", 0, 2, false, 17)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     Chave da Nota Fiscal Fatura de Serviço de Comunicação Eletrônica.
            /// </summary>
            [SpedCampos(22, "CHV_DOCe", "C", 44, 0, false, 17)]
            [SpedCampos(22, "CHV_DOCe", "C", 44, 0, true, 18)]
            public string ChvDoce { get; set; }

            /// <summary>
            ///     Finalidade da emissão do documento eletrônico:
            ///     0 - NFCom Normal;
            ///     3 - NFCom de Substituição; 
            ///     4 - NFCom de Ajuste;
            /// </summary>
            [SpedCampos(23, "FIN_DOCe", "N", 1, 0, true, 17)]
            public int FinDoce { get; set; }

            /// <summary>
            ///     Tipo de faturamento do documento eletrônico:
            ///     0 - Faturamento Normal;
            ///     1 - Faturamento centralizado;
            ///     4 - 2 - Cofaturamento
            /// </summary>
            [SpedCampos(24, "TIP_FAT", "N", 1, 0, true, 17)]
            public int TipFat { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal referenciado, conforme a Tabela 4.1.1. 
            /// </summary>
            [SpedCampos(25, "COD_MOD_DOC_REF", "N", 2, 0, false, 17)]
            public int CodModDocRef { get; set; }

            /// <summary>
            ///     Chave da nota referenciada.
            /// </summary>
            [SpedCampos(26, "CHV_DOCe_REF", "N", 44, 0, false, 17)]
            public string ChvDoceRef { get; set; }

            /// <summary>
            ///     Código de autenticação digital do registro, 
            ///     campo 36 do registro do Arquivo tipo mestre de documento fiscal, 
            ///     conforme definido no Convênio 115/2003.
            /// </summary>
            [SpedCampos(27, "HASH_DOC_REF", "C", 32, 0, false, 17)]
            public string HashDocRef { get; set; }

            /// <summary>
            ///     Série do documento fiscal referenciado. 
            /// </summary>
            [SpedCampos(28, "SER_DOC_REF", "C", 4, 0, false, 17)]
            public string SerDocRef { get; set; }

            /// <summary>
            ///     Número do documento fiscal referenciado.
            /// </summary>
            [SpedCampos(29, "NUM_DOC_REF", "N", 9, 0, false, 17)]
            public string NumDocRef { get; set; }

            /// <summary>
            ///     Mês e ano da emissão do documento fiscal referenciado.
            /// </summary>
            [SpedCampos(30, "MES_DOC_REF", "N", 6, 0, false, 17)]
            public string MesDocRef { get; set; }

            /// <summary>
            ///     Código do município do destinatário conforme a tabela do IBGE.
            /// </summary>
            [SpedCampos(31, "COD_MUN_DEST", "N", 7, 0, true, 17)]
            public string CodMunDes { get; set; }

            /// <summary>
            ///     Deduções.
            /// </summary>
            [SpedCampos(32, "DED", "N", int.MaxValue, 2, false, 19)]
            public decimal Ded { get; set; }

            public RegistroD730 RegD730 { get; set; }
            public RegistroD731 RegD731 { get; set; }
            public RegistroD735 RegD735 { get; set; }
            public RegistroD737 RegD737 { get; set; }
            public RegistroD750 RegD750 { get; set; }
            public RegistroD760 RegD760 { get; set; }
            public RegistroD761 RegD761 { get; set; }

        }

        /// <summary>
        ///     REGISTRO D730:  REGISTRO ANALÍTICO NOTA FISCAL FATURA ELETRÔNICA DE SERVIÇOS DE COMUNICAÇÃO – NFCom (CÓDIGO 62).
        /// </summary>
        [SpedRegistros("01/01/2023", "")]
        public class RegistroD730 : RegistroSped
        {
            /// <summary>
            ///    Inicializa uma nova instância da classe <see cref="RegistroD730"/>.
            /// </summary>
            public RegistroD730() : base("D730")
            {
            }

            /// <summary>
            ///     Código da situação tributária, conforme a tabela indicada no item 4.3.1.
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true, 17)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação, conforme a tabela indicada no item 4.2.2.
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true, 17)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS.
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false, 17)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor total dos itens relacionados aos serviços próprios, com destaque de ICMS, correspondente à
            ///     combinação de CST_ICMS, CFOP, e alíquota do CMS.
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true, 17)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor da base de cálculo do ICMS" referente à combinação CST_ICMS, CFOP, e 
            ///     alíquota do ICMS.
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true, 17)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do ICMS" referente à combinação CST_ICMS, CFOP, e alíquota do ICMS, 
            ///     incluindo o FCP, quando aplicável, referente à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true, 17)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do ICMS, referente
            ///     à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(8, "VL_RED_BC", "N", 0, 2, true, 17)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Código da observação o (campo 02 do Registro 0460).
            /// </summary>
            [SpedCampos(9, "COD_OBS", "C", 6, 0, false, 17)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO D731: INFORMAÇÕES DO FUNDO DE COMBATE À POBREZA – FCP – (CÓDIGO 62).
        /// </summary>
        [SpedRegistros("01/01/2023", "")]
        public class RegistroD731 : RegistroSped
        {
            /// <summary>
            ///    Inicializa uma nova instância da classe <see cref="RegistroD731"/>.
            /// </summary>
            public RegistroD731() : base("D731")
            {
            }

            /// <summary>
            ///     Valor do Fundo de Combate à Pobreza (FCP) vinculado à 
            ///     operação própria, na combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(2, "VL_FCP_OP", "N", 0, 2, true, 17)]
            public decimal VlFcpOp { get; set; }
        }

        /// <summary>
        ///     REGISTRO D735: OBSERVAÇÕES DO LANÇAMENTO FISCAL (CÓDIGO 62).
        /// </summary>
        [SpedRegistros("01/01/2023", "")]
        public class RegistroD735 : RegistroSped
        {
            /// <summary>
            ///    Inicializa uma nova instância da classe <see cref="RegistroD735"/>.
            /// </summary>
            public RegistroD735() : base("D735")
            {
            }

            /// <summary>
            ///     Código da observação do lançamento fiscal (campo 02 do Registro 0460).
            /// </summary>
            [SpedCampos(2, "COD_OBS", "C", 6, 0, true, 17)]
            public string CodObs { get; set; }

            /// <summary>
            ///     Descrição complementar do código de observação.
            /// </summary>
            [SpedCampos(3, "TXT_COMPL", "C", 999, 0, false, 17)]
            public string TxrCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO D737: OUTRAS OBRIGAÇÕES TRIBUTÁRIAS, AJUSTES E INFORMAÇÕES DE 
        ///     VALORES PROVENIENTES DE DOCUMENTO FISCAL.
        /// </summary>
        [SpedRegistros("01/01/2023", "")]
        public class RegistroD737 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroD737" />.
            /// </summary>
            public RegistroD737() : base("D737")
            {
            }

            /// <summary>
            ///     Código do ajustes/benefício/incentivo, conforme tabela indicada no item 5.3.
            /// </summary>
            [SpedCampos(2, "COD_AJ", "C", 10, 0, true, 17)]
            public string CodAj { get; set; }

            /// <summary>
            ///     Descrição complementar do ajuste do documento fiscal.
            /// </summary>
            [SpedCampos(3, "DESCR_COMPL_AJ", "C", 999, 0, false, 17)]
            public string DescrComplAj { get; set; }

            /// <summary>
            ///     Código do item (campo 02 do Registro 0200).
            /// </summary>
            [SpedCampos(4, "COD_ITEM", "C", 60, 0, false, 17)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Base de cálculo do ICMS.
            /// </summary>
            [SpedCampos(5, "VL_BC_ICMS", "N", 0, 2, false, 17)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Alíquota do ICMS.
            /// </summary>
            [SpedCampos(6, "ALIQ_ICMS", "N", 6, 2, false, 17)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS.
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, false, 17)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Outros valores.
            /// </summary>
            [SpedCampos(8, "VL_OUTROS", "N", 0, 2, false, 17)]
            public decimal VlOutros { get; set; }
        }

        /// <summary>
        ///     REGISTRO D750: ESCRITURAÇÃO CONSOLIDADA DA NOTA FISCAL FATURA 
        ///     ELETRÔNICA DE SERVIÇOS DE COMUNICAÇÃO - NFCom (CÓDIGO 62).
        /// </summary>
        [SpedRegistros("01/01/2023", "")]
        public class RegistroD750 : RegistroSped
        {
            /// <summary>
            ///    Inicializa uma nova instância da classe <see cref="RegistroD750"/>.
            /// </summary>
            public RegistroD750() : base("D750")
            {
            }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1.
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true, 17)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(3, "SER", "C", 3, 0, true, 17)]
            [SpedCampos(3, "SER", "N", 3, 0, true, 18)]
            public string Ser { get; set; }

            /// <summary>
            ///     Data da emissão dos documentos
            /// </summary>
            [SpedCampos(4, "DT_DOC", "N", 8, 0, true, 17)]
            public DateTime? DtDoc { get; set; }

            // <summary>
            ///     Quantidade de documentos consolidados neste registro
            /// </summary>
            [SpedCampos(5, "QTD_CONS", "N", 0, 0, true, 17)]
            public decimal QtdCons { get; set; }

            // <summary>
            ///     Forma de pagamento: 
            ///     0 – pré pago
            ///     1 – pós pago
            /// </summary>
            [SpedCampos(6, "IND_PREPAGO", "N", 1, 0, true, 17)]
            public int IndPrepago { get; set; }

            /// <summary>
            ///     Valor total dos documentos
            /// </summary>
            [SpedCampos(7, "VL_DOC", "N", 0, 2, true, 17)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Valor dos serviços tributados pelo ICMS.
            /// </summary>
            [SpedCampos(8, "VL_SERV", "N", 0, 2, true, 17)]
            public decimal VlServ { get; set; }

            /// <summary>
            ///     Valores cobrados em nome do prestador sem destaque de ICMS.
            /// </summary>
            [SpedCampos(9, "VL_SERV_NT", "N", 0, 2, true, 17)]
            public decimal VlServNt { get; set; }

            /// <summary>
            ///     Valor total cobrado em nome de terceiros.
            /// </summary>
            [SpedCampos(10, "VL_TERC", "N", 0, 2, true, 17)]
            public decimal VlTerc { get; set; }

            /// <summary>
            ///     Valor total dos descontos.
            /// </summary>
            [SpedCampos(11, "VL_DESC", "N", 0, 2, true, 17)]
            public decimal VlDes { get; set; }

            /// <summary>
            ///     Valor total das despesas acessórias.
            /// </summary>
            [SpedCampos(12, "VL_DA", "N", 0, 2, true, 17)]
            public decimal VlDa { get; set; }

            /// <summary>
            ///     Valor total da base de cálculo do ICMS.
            /// </summary>
            [SpedCampos(13, "VL_BC_ICMS", "N", 0, 2, true, 17)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor total do ICMS.
            /// </summary>
            [SpedCampos(14, "VL_ICMS", "N", 0, 2, true, 17)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor total do PIS.
            /// </summary>
            [SpedCampos(15, "VL_PIS", "N", 0, 2, false, 17)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor total da COFINS.
            /// </summary>
            [SpedCampos(16, "VL_COFINS", "N", 0, 2, false, 17)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Deduções.
            /// </summary>
            [SpedCampos(17, "DED", "N", int.MaxValue, 2, false, 19)]
            public decimal Ded { get; set; }
        }

        /// <summary>
        ///     REGISTRO D760: REGISTRO ANALÍTICO DA ESCRITURAÇÃO CONSOLIDADA DA NOTA 
        ///     FISCAL FATURA ELETRÔNICA DE SERVIÇOS DE COMUNICAÇÃO - NFCom(CÓDIGO 62)
        /// </summary>
        [SpedRegistros("01/01/2023", "")]
        public class RegistroD760 : RegistroSped
        {
            /// <summary>
            ///    Inicializa uma nova instância da classe <see cref="RegistroD760"/>.
            /// </summary>
            public RegistroD760() : base("D760")
            {
            }

            /// <summary>
            ///     Código da situação tributária, conforme a tabela indicada no item 4.3.1.
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true, 17)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação, conforme a tabela indicada no item 4.2.2.
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true, 17)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS.
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false, 17)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor total dos itens relacionados aos serviços próprios com destaque de ICMS, correspondente à combinação de
            ///     CST_ICMS, CFOP, e alíquota do ICMS.
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true, 17)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor da base de cálculo do ICMS" referente à combinação CST_ICMS, CFOP, e 
            ///     alíquota do ICMS.
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true, 17)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do ICMS", incluindo o FCP, quando aplicável, referente à combinação de
            ///     CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true, 17)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do ICMS, referente
            ///     à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(08, "VL_RED_BC", "N", 0, 2, true, 17)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Código da observação o (campo 02 do Registro 0460).
            /// </summary>
            [SpedCampos(09, "COD_OBS", "C", 6, 0, false, 17)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO D731: INFORMAÇÕES DO FUNDO DE COMBATE À POBREZA – FCP – (CÓDIGO 62).
        /// </summary>
        [SpedRegistros("01/01/2023", "")]
        public class RegistroD761 : RegistroSped
        {
            /// <summary>
            ///    Inicializa uma nova instância da classe <see cref="RegistroD761"/>.
            /// </summary>
            public RegistroD761() : base("D761")
            {
            }

            /// <summary>
            ///     Valor do Fundo de Combate à Pobreza (FCP) vinculado à 
            ///     operação própria, na combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(2, "VL_FCP_OP", "N", 0, 2, true, 17)]
            public decimal VlFcpOp { get; set; }
        }

        /// <summary>
        ///     REGISTRO D990: ENCERRAMENTO DO BLOCO D.
        /// </summary>
        public class RegistroD990 : RegistroSped
        {
            /// <summary>
            ///    Inicializa uma nova instância da classe <see cref="RegistroD990"/>.
            /// </summary>
            public RegistroD990() : base("D990")
            {
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco D
            /// </summary>
            [SpedCampos(2, "QTD_LIN_D", "N", int.MaxValue, 0, true, 2)]
            public int QtdLinD { get; set; }
        }
    }
}
