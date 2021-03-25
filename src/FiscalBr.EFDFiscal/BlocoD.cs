using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDFiscal
{
    /// <summary>
    ///     BLOCO D: DOCUMENTOS FISCAIS II - SERVIÇOS (ICMS)
    /// </summary>
    public class BlocoD
    {
        public RegistroD001 RegD001 { get; set; }
        public RegistroD001 RegD990 { get; set; }

        /// <summary>
        ///     REGISTRO D001: ABERTURA DO BLOCO D
        /// </summary>
        public class RegistroD001 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD001"/>.
            /// </summary>
            public RegistroD001()
            {
                Reg = "D001";
            }

            /// <summary>
            ///     Indicador de movimento: 
            ///     <para />
            ///     0 - Bloco com dados informados;
            ///     <para />
            ///     1 - Bloco sem dados informados.
            /// </summary>
            [SpedCampos(2, "IND_MOV", "N", 1, 0, true)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroD100> RegD100s { get; set; }
            public List<RegistroD300> RegD300s { get; set; }
            public List<RegistroD350> RegD350s { get; set; }
            public List<RegistroD400> RegD400s { get; set; }
            public List<RegistroD500> RegD500s { get; set; }
            public List<RegistroD600> RegD600s { get; set; }
            public List<RegistroD695> RegD695s { get; set; } 
        }

        /// <summary>
        ///     REGISTRO D100: NOTA FISCAL DE SERVIÇO DE TRANSPORTE (CÓDIGO 07) E CONHECIMENTOS DE TRANSPORTE RODOVIÁRIO DE CARGAS
        ///     (CÓDIGO 08),
        ///     CONHECIMENTOS DE TRANSPORTE DE CARGAS AVULSO (CÓDIGO 8B), AQUAVIÁRIO DE CARGAS (CÓDIGO 09), AÉREO (CÓDIGO 10),
        ///     FERROVIÁRIO DE CARGAS (CÓDIGO 11) E
        ///     MULTIMODAL DE CARGAS (CÓDIGO 26), NOTA FISCAL DE TRANSPORTE FERROVIÁRIO DE CARGA ( CÓDIGO 27) E CONHECIMENTO DE
        ///     TRANSPORTE ELETRÔNICO – CT-e (CÓDIGO 57).
        /// </summary>
        public class RegistroD100 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="RegistroD100"/>.
            /// </summary>
            public RegistroD100()
            {
                Reg = "D100";
            }

            /// <summary>
            ///     Indicador do tipo de operação:
            ///     <para />
            ///     0- Aquisição;
            ///     <para />
            ///     1- Prestação
            /// </summary>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true)]
            public int IndOper { get; set; }

            /// <summary>
            ///     Indicador do emitente do documento fiscal:
            ///     <para />
            ///     0 - Emissão própria;
            ///     <para />
            ///     1 - Terceiros;
            /// </summary>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true)]
            public int IndEmit { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150):
            /// </summary>
            /// <remarks>
            ///     - do emitente do documento ou do remetente das mercadorias, no caso de entradas;
            ///     <para />
            ///     - do adquirente, no caso de saídas.
            /// </remarks>
            [SpedCampos(4, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(5, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(6, "COD_SIT", "N", 2, 0, true)]
            public int CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(7, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(8, "SUB", "C", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(9, "NUM_DOC", "N", 9, 0, true)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Chave do Conhecimento de Transporte Eletrônico
            /// </summary>
            [SpedCampos(10, "CHV_CTE", "N", 44, 0, false)]
            public string ChvCte { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(11, "DT_DOC", "N", 8, 0, false)]
            public DateTime? DtDoc { get; set; }

            /// <summary>
            ///     Data da aquisição ou da prestação do serviço
            /// </summary>
            [SpedCampos(12, "DT_AP", "N", 8, 0, false)]
            public DateTime? DtAP { get; set; }

            /// <summary>
            ///     Tipo de Conhecimento de Transporte Eletrônico conforme definido no Manual de Integração do CT-e
            /// </summary>
            [SpedCampos(13, "TP_CT-e", "N", 1, 0, false)]
            public int? TpCte { get; set; }

            /// <summary>
            ///     Chave do CT-e de referência cujos valores foram complementados (opção “1” do campo anterior) 
            ///     <para />
            ///     ou cujo débito foi anulado(opção “2” do campo anterior).
            /// </summary>
            [SpedCampos(14, "CHV_CTE_REF", "N", 44, 0, false)]
            public string ChvCteRef { get; set; }

            /// <summary>
            ///     Valor total do documento fisca
            /// </summary>
            [SpedCampos(15, "VL_DOC", "N", 0, 2, false)]
            public decimal? VlDoc { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(16, "VL_DESC", "N", 0, 2, false)]
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
            [SpedCampos(17, "IND_FRT", "N", 1, 0, false)]
            public int? IndFrt { get; set; }

            /// <summary>
            ///     Valor total do serviço
            /// </summary>
            [SpedCampos(18, "VL_SERV", "N", 0, 2, false)]
            public decimal? VlServ { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(19, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal? VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS
            /// </summary>
            [SpedCampos(20, "VL_ICMS", "N", 0, 2, false)]
            public decimal? VlIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS
            /// </summary>
            [SpedCampos(21, "VL_NT", "N", 0, 2, false)]
            public decimal? VlNt { get; set; }

            /// <summary>
            ///     Código da informação complementar do documento fiscal (campo 02 do Registro 0450)
            /// </summary>
            [SpedCampos(22, "COD_INF", "C", 6, 0, false)]
            public string CodInf { get; set; }

            /// <summary>
            ///     Código da informação complementar do documento fiscal (campo 02 do Registro 0450)
            /// </summary>
            [SpedCampos(22, "COD_CTA", "C", 0, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Código do município de origem do serviço, conforme a tabela IBGE (Preencher com 9999999, se Exterior)
            ///     <para />
            ///     Guia Prático EFD-ICMS/IPI – Versão 2.0.21
            ///     <para />
            ///     Atualização: 22/08/2017
            /// </summary>
            [SpedCampos(24, "COD_MUN_ORIG", "N", 7, 0, false)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///     Código do município de destino, conforme a tabela IBGE (Preencher com 9999999, se Exterior)
            ///     <para />
            ///     Guia Prático EFD-ICMS/IPI – Versão 2.0.21 
            ///     <para />
            ///     Atualização: 22/08/2017
            /// </summary>
            [SpedCampos(25, "COD_MUN_DEST", "N", 7, 0, false)]
            public string CodMunDest { get; set; }

            public RegistroD101 RegD101 { get; set; }
            public List<RegistroD110> RegD110 { get; set; }
            public List<RegistroD130> RegD130s { get; set; }
            public RegistroD140 RegD140 { get; set; }
            public RegistroD150 RegD150s { get; set; }
            public List<RegistroD160> RegD160s { get; set; }
            public RegistroD170 RegD170 { get; set; }
            public List<RegistroD180> RegD180s { get; set; }
            public List<RegistroD190> RegD190s { get; set; }
            public List<RegistroD195> RegD195s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D101: INFORMAÇÃO COMPLEMENTAR DOS DOCUMENTOS FISCAIS QUANDO 
        ///     <para />
        ///     DAS PRESTAÇÕES INTERESTADUAIS DESTINADAS A CONSUMIDOR 
        ///     <para />
        ///     FINAL NÃO CONTRIBUINTE EC 87/15 (CÓDIGOS 57 e 67)
        /// </summary>
        public class RegistroD101 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD101"/>.
            /// </summary>
            public RegistroD101()
            {
                Reg = "D101";
            }

            /// <summary>
            ///   Valor total relativo ao Fundo de Combate à Pobreza (FCP) da UF de destino
            /// </summary>
            [SpedCampos(2, "VL_FCP_UF_DEST", "N", 0, 2, true)]
            public decimal VlFcpUfDest { get; set; }

            /// <summary>
            ///   Valor total do ICMS Interestadual para a UF de destino
            /// </summary>
            [SpedCampos(3, "VL_ICMS_UF_DEST", "N", 0, 2, true)]
            public decimal VlIcmsUfDest { get; set; }

            /// <summary>
            ///   Valor total do ICMS Interestaduak para a UF do remetente
            /// </summary>
            [SpedCampos(4, "VL_ICMS_UF_REM", "N", 0, 2, true)]
            public decimal VlIcmsUfRem { get; set; }
        }

        /// <summary>
        ///     REGISTRO D110: ITENS DO DOCUMENTO - NOTA FISCAL DE SERVIÇOS DE TRANSPORTE (CODIGO 07)
        /// </summary>
        public class RegistroD110 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD110"/>.
            /// </summary>
            public RegistroD110()
            {
                Reg = "D110";
            }

            /// <summary>
            ///   Numero sequencial do item no documento fiscal
            /// </summary>
            [SpedCampos(2, "NUM_ITEM", "N", 3, 0, true)]
            public decimal NumItem { get; set; }

            /// <summary>
            ///   Codigo do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///   Valor do serviço
            /// </summary>
            [SpedCampos(4, "VL_SERV", "N", 0, 2, true)]
            public decimal VlServ { get; set; }

            /// <summary>
            ///   Outros valores
            /// </summary>
            [SpedCampos(5, "VL_OUT", "N", 0, 2, false)]
            public decimal VlOut { get; set; }

            public List<RegistroD120> RegD120s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D120: COMPLEMENTO DA NOTA FISCAL DE SERVIÇOS DE TRANSPORTE (CODIGO 07)
        /// </summary>
        public class RegistroD120 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD120"/>.
            /// </summary>
            public RegistroD120()
            {
                Reg = "D120";
            }

            /// <summary>
            ///   Codigo do municipio de origem do serviço, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(2, "COD_MUN_ORIG", "N", 7, 0, true)]
            public decimal CodMunOrig { get; set; }

            /// <summary>
            ///   Codigo do municipio de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(3, "COD_MUN_DEST", "N", 7, 0, true)]
            public decimal CodMunDest { get; set; }

            /// <summary>
            ///   Placa de identificacao do veiculo
            /// </summary>
            [SpedCampos(4, "VEIC_ID", "C", 7, 0, false)]
            public decimal VeicId { get; set; }

            /// <summary>
            ///   Sigla da UF da placa do veiculo
            /// </summary>
            [SpedCampos(5, "UF_ID", "C", 2, 0, false)]
            public decimal UfId { get; set; }
        }

        /// <summary>
        ///     REGISTRO  D130:  COMPLEMENTO  DO  CONHECIMENTO  RODOVIÁRIO  DE  CARGAS (CÓDIGO 08) E DO CONHECIMENTO RODOVIÁRIO DE CARGAS AVULSO (CÓDIGO 8B)
        /// </summary>
        public class RegistroD130 : RegistroBaseSped
        {
            public RegistroD130()
            {
                Reg = "D130";
            }

            /// <summary>
            ///    Código do participante (campo 02 do Registro 0150):
            /// </summary>
            /// <remarks>
            ///    -consignatário, se houver
            /// </remarks>
            [SpedCampos(2, "COD_PART_CONSG", "C", 60, 0, false)]
            public string CodPartConsg { get; set; }


            /// <summary>
            ///    Código do participante (campo 02 do Registro 0150):
            /// </summary>
            /// <remarks>
            ///    -redespachado, se houver
            /// </remarks>
            [SpedCampos(3, "COD_PART_RED", "C", 60, 0, false)]
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
            [SpedCampos(4, "IND_FRT_RED", "C", 1, 0, true)]
            public int IntFrtRed { get; set; }

            /// <summary>
            ///    Código do município de origem do serviço, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(5, "COD_MUN_ORIG", "N", 7, 0, true)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///    Código do município de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(6, "COD_MUN_DEST", "N", 7, 0, true)]
            public string CodMunDest { get; set; }

            /// <summary>
            ///    Placa de identificação do veículo
            /// </summary>
            [SpedCampos(7, "VEIC_ID", "C", 7, 0, false)]
            public string VeicId { get; set; }

            /// <summary>
            ///    Valor líquido do frete 
            /// </summary>
            [SpedCampos(8, "VL_LIQ_FRT", "N", 0, 2, true)]
            public string VlLiqFrt { get; set; }

            /// <summary>
            ///     Soma de valores de Sec/Cat (serviços de coleta/custo adicional de transporte) 
            /// </summary>
            [SpedCampos(9, "VL_SEC_CAT", "N", 0, 2, false)]
            public string VlSecCat { get; set; }

            /// <summary>
            ///     Soma de valores de despacho
            /// </summary>
            [SpedCampos(10, "VL_DESP", "N", 0, 2, false)]
            public string VlDesp { get; set; }

            /// <summary>
            ///     Soma dos valores de pedágio
            /// </summary>
            [SpedCampos(11, "VL_PEDG", "N", 0, 2, false)]
            public string VlPedg { get; set; }

            /// <summary>
            ///    Outros valores 
            /// </summary>
            [SpedCampos(12, "VL_OUT", "N", 0, 2, false)]
            public string VlOut { get; set; }

            /// <summary>
            ///     Valor total do frete
            /// </summary>
            [SpedCampos(13, "VL_FRT", "N", 0, 2, true)]
            public string VlFrt { get; set; }

            /// <summary>
            ///     Sigla da UF da placa do veículo
            /// </summary>
            [SpedCampos(14, "UF_ID", "C", 2, 0, false)]
            public string UfId { get; set; }

        }

        /// <summary>
        ///     REGISTRO D140: COMPLEMENTO DO CONHECIMENTO AQUAVIÁRIO DE CARGAS (CÓDIGO 09)
        /// </summary>
        public class RegistroD140 : RegistroBaseSped
        {
            public RegistroD140()
            {
                Reg = "D140";
            }

            /// <summary>
            ///    Código do participante (campo 02 do Registro 0150):
            /// </summary>
            /// <remarks>
            ///    -consignatário, se houver
            /// </remarks>
            [SpedCampos(2, "COD_PART_CONSG", "C", 60, 0, false)]
            public string CodPartConsg { get; set; }


            /// <summary>
            ///   Código do município de origem do serviço, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(3, "COD_MUN_ORIG", "N", 7, 0, true)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///   Código do município de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(4, "COD_MUN_DEST", "N", 7, 0, true)]
            public string CodMunDest { get; set; }


            /// <summary>
            ///       Indicador do tipo do veículo transportador:
            /// </summary>
            /// <remarks>
            ///      0- Embarcação;
            ///      <para />
            ///      1-Empurrador/rebocador
            /// </remarks>
            [SpedCampos(5, "IND_VEIC", "C", 1, 0, true)]
            public string IndVeic { get; set; }

            /// <summary>
            ///   Identificação da embarcação (IRIM ou Registro CPP)
            /// </summary>
            [SpedCampos(6, "VEIC_ID", "C", 0, 0, false)]
            public string VeicId { get; set; }

            /// <summary>
            ///      Indicador do tipo da navegação:
            /// </summary>
            /// <remarks>
            ///      0- Interior;
            ///      <para />
            ///      1-Cabotagem
            /// </remarks>
            [SpedCampos(7, "IND_NAV", "C", 1, 0, true)]
            public string IndNav { get; set; }

            /// <summary>
            ///  Número da viagem
            /// </summary>
            [SpedCampos(8, "VIAGEM", "N", 0, 0, false)]
            public string Viagem { get; set; }

            /// <summary>
            ///  Valor líquido do frete
            /// </summary>
            [SpedCampos(9, "VL_FRT_LIQ", "N", 0, 2, true)]
            public string VlFrtLiq { get; set; }

            /// <summary>
            ///  Valor das despesas portuárias 
            /// </summary>
            [SpedCampos(10, "VL_DESP_PORT", "N", 0, 2, false)]
            public string VlDespPort { get; set; }

            /// <summary>
            ///  Valor das despesas com carga e descarga 
            /// </summary>
            [SpedCampos(11, "VL_DESP_CAR_DESC", "N", 0, 2, false)]
            public string VlDespCarDesC { get; set; }

            /// <summary>
            ///   Outros valores
            /// </summary>
            [SpedCampos(12, "VL_OUT", "N", 0, 2, false)]
            public string VlOut { get; set; }

            /// <summary>
            ///  Valor brutodo frete
            /// </summary>
            [SpedCampos(13, "VL_FRT_BRT", "N", 0, 2, true)]
            public string VlFrtBrt { get; set; }

            /// <summary>
            /// Valor adicional do frete para renovação da Marinha Mercante
            /// <summary>
            [SpedCampos(14, "VL_FRT_MM", "N", 0, 2, false)]
            public string VlFrtMm { get; set; }

        }

        /// <summary>
        ///   REGISTRO D150: COMPLEMENTO DO CONHECIMENTO AÉREO (CÓDIGO 10)  
        /// </summary>
        public class RegistroD150 : RegistroBaseSped
        {

            public RegistroD150()
            {
                Reg = "D150";
            }

            /// <summary>
            ///     Código do município de origem do serviço, conforme a tabela IBGE (Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(2, "COD_MUN_ORIG", "N", 7, 0, true)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///    Código do município de destino, conforme a tabela IBGE (Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(3, "COD_MUN_DEST", "N", 7, 0, true)]
            public string CodMunDest { get; set; }

            /// <summary>
            ///    Identificação da aeronave (DAC)
            /// </summary>
            [SpedCampos(4, "VEIC_ID", "C", 0, 0, false)]
            public string VeicId { get; set; }

            /// <summary>
            ///    Número do vôo.
            /// </summary>
            [SpedCampos(5, "VIAGEM", "N", 0, 0, false)]
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
            [SpedCampos(6, "IND_TFA", "C", 1, 0, true)]
            public string IndTfa { get; set; }

            /// <summary>
            ///   Peso taxado
            /// </summary>
            [SpedCampos(7, "VL_PESO_TX", "N", 0, 2, true)]
            public string VlPesoTx { get; set; }

            /// <summary>
            ///   Valor da taxa terrestre
            /// </summary>
            [SpedCampos(8, "VL_TX_TERR", "N", 0, 2, false)]
            public string VlTxTerr { get; set; }


            /// <summary>
            ///    Valor da taxa de redespacho
            /// </summary>
            [SpedCampos(9, "VL_TX_RED", "N", 0, 2, false)]
            public string VlTxRed { get; set; }


            /// <summary>
            ///    Outros valores
            /// </summary>
            [SpedCampos(10, "VL_OUT", "N", 0, 2, false)]
            public string VlOut { get; set; }

            /// <summary>
            ///    Valor da taxa "ad valorem"
            /// </summary>
            [SpedCampos(11, "VL_TX_ADV", "N", 0, 2, false)]
            public string VlTxAdv { get; set; }

        }

        /// <summary>
        ///   REGISTRO D160: CARGA TRANSPORTADA (CÓDIGO 08, 8B, 09, 10, 11, 26 e 27)
        /// </summary>
        public class RegistroD160 : RegistroBaseSped
        {

            public RegistroD160()
            {
                Reg = "D160";
            }

            /// <summary>
            ///   Identificação do número do despacho 
            /// </summary>
            [SpedCampos(2, "DESPACHO", "C", 0, 0, false)]
            public string Despacho { get; set; }

            /// <summary>
            ///    CNPJ ou CPF do remetente das mercadorias que constam na nota fiscal.
            /// </summary>
            [SpedCampos(3, "CNPJ_CPF_REM", "N", 14, 0, false)]
            public string CnpjCpfRem { get; set; }

            /// <summary>
            ///   Inscrição Estadual do remetente das mercadorias que constam na nota fiscal.
            /// </summary>
            [SpedCampos(4, "IE_REM", "C", 14, 0, false)]
            public string IeRem { get; set; }

            /// <summary>
            ///    Código do Município de origem, conforme tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(5, "COD_MUN_ORI", "N", 7, 0, true)]
            public string CodMunOri { get; set; }

            /// <summary>
            ///   CNPJ ou CPF do destinatário das mercadorias que constam na nota fiscal.
            /// </summary>
            [SpedCampos(6, "CNPJ_CPF_DEST", "N", 14, 0, false)]
            public string CnpjCpfDest { get; set; }

            /// <summary>
            ///   Inscrição Estadual do destinatáriodas mercadorias que constam na nota fiscal.
            /// </summary>
            [SpedCampos(7, "IE_DEST", "C", 14, 0, false)]
            public string IeDest { get; set; }

            /// <summary>
            ///   Código do Município de destino, conforme tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(8, "COD_MUN_DEST", "N", 7, 0, true)]
            public string CodMunDest { get; set; }

            public RegistroD161 RegD161s { get; set; }
            public List<RegistroD162> RegD162s { get; set; }
        }

        /// <summary>
        ///  REGISTRO D161: LOCAL DA COLETA E ENTREGA (CÓDIGO 08, 8B, 09, 10, 11 e 26)
        /// </summary>
        public class RegistroD161 : RegistroBaseSped
        {

            public RegistroD161()
            {
                Reg = "D161";
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
            [SpedCampos(2, "IND_CARGA", "N", 1, 0, true)]
            public string IndCarga { get; set; }

            /// <summary>
            ///    Número do CNPJ ou CPF do local da coleta.
            /// </summary>
            [SpedCampos(3, "CNPJ_CPF_COL", "C", 14, 0, false)]
            public string CnpjCpfCol { get; set; }

            /// <summary>
            ///   Inscrição Estadual do contribuinte do local de coleta.
            /// </summary>
            [SpedCampos(4, "IE_Col", "C", 14, 0, false)]
            public string IeCol { get; set; }

            /// <summary>
            ///    Código do Município do local de  coleta, conforme tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(5, "COD_MUN_COL", "N", 7, 0, true)]
            public string CodMunCol { get; set; }

            /// <summary>
            ///   Número do CNPJ ou CPF do local da entrega
            /// </summary>
            [SpedCampos(6, "CNPJ_CPF_ENTG", "C", 14, 0, false)]
            public string CnpjCpfEntg { get; set; }

            /// <summary>
            ///   Inscrição  Estadual  do  contribuinte  do  local  de entrega
            /// </summary>
            [SpedCampos(7, "IE_ENTG", "C", 14, 0, false)]
            public string IeEntg { get; set; }

            /// <summary>
            ///    Código do Município do local de entrega, conforme tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(8, "COD_MUN_ENTG", "N", 7, 0, true)]
            public string CodMunEntg { get; set; }
        }

        /// <summary>
        ///   REGISTRO  D162: IDENTIFICAÇÃO DOS DOCUMENTOS FISCAIS (CÓDIGOS 08, 8B, 09, 10, 11, 26 E 27)
        /// </summary>
        public class RegistroD162 : RegistroBaseSped
        {

            public RegistroD162()
            {
                Reg = "D162";
            }

            /// <summary>
            ///    Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, false)]
            public string CodMod { get; set; }

            /// <summary>
            ///   Série do documento fiscal
            /// </summary>
            [SpedCampos(3, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///    Número do documento fiscal
            /// </summary>
            [SpedCampos(4, "NUM_DOC", "N", 9, 0, true)]
            public string NumDoc { get; set; }

            /// <summary>
            ///   Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(5, "DT_DOC", "N", 8, 0, false)]
            public string DtDoc { get; set; }

            /// <summary>
            ///   Valor total do documento fiscal 
            /// </summary>
            [SpedCampos(6, "VL_DOC", "N", 0, 2, false)]
            public string VlDoc { get; set; }

            /// <summary>
            ///   Valor das mercadorias constantes no documento fiscal
            /// </summary>
            [SpedCampos(7, "VL_MERC", "N", 0, 2, false)]
            public string VlMerc { get; set; }

            /// <summary>
            ///  Quantidade de volumes transportados
            /// </summary>
            [SpedCampos(8, "QTD_VOL", "N", 0, 0, true)]
            public string QtdVol { get; set; }


            /// <summary>
            ///   Peso bruto dos volumes transportados (em kg)
            /// </summary>
            [SpedCampos(9, "PESO_BRT", "N", 0, 2, false)]
            public string PesoBrt { get; set; }


            /// <summary>
            ///    Peso líquido dos volumes transportados (em kg)
            /// </summary>
            [SpedCampos(10, "PESO_LIQ", "N", 0, 2, false)]
            public string PesoLiq { get; set; }
        }

        /// <summary>
        ///    REGISTRO  D170: COMPLEMENTO DO CONHECIMENTO MULTIMODAL DE CARGAS (CÓDIGO 26)
        /// </summary>
        public class RegistroD170 : RegistroBaseSped
        {
            public RegistroD170()
            {
                Reg = "D170";
            }

            /// <summary>
            ///    Código do participante (campo 02 do Registro 0150):
            /// </summary>
            /// <remarks>
            ///   -consignatário, se houver
            /// </remarks>
            [SpedCampos(2, "COD_PART_CONSG", "C", 60, 0, false)]
            public string CodPartConsg { get; set; }

            /// <summary>
            ///    Código do participante (campo 02 do Registro 0150):
            /// </summary>
            /// <remarks>
            ///  -redespachante, se houver
            /// </remarks>
            [SpedCampos(3, "COD_PART_RED", "C", 60, 0, false)]
            public string CodPartRed { get; set; }

            /// <summary>
            ///    Código do município de origem do serviço, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(4, "COD_MUN_ORIG", "N", 7, 0, true)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///    Código do município de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(5, "COD_MUN_DEST", "N", 7, 0, true)]
            public string CodMunDest { get; set; }

            /// <summary>
            ///    Registro do operador de transporte multimodal
            /// </summary>
            [SpedCampos(6, "OTM", "C", 0, 0, true)]
            public string Otm { get; set; }

            /// <summary>
            ///    Indicador da natureza do frete:
            /// </summary>
            /// <remarks>
            ///    0- Negociável;
            ///    <para />
            ///    1-Não negociável
            /// </remarks>
            [SpedCampos(7, "IND_NAT_FRT", "C", 1, 0, true)]
            public string IndNatFrt { get; set; }

            /// <summary>
            ///   Valor líquido do frete
            /// </summary>
            [SpedCampos(8, "VL_LIQ_FRT", "N", 0, 2, true)]
            public string VlLinqFrt { get; set; }

            /// <summary>
            ///   Valor do gris (gerenciamento de risco)
            /// </summary>
            [SpedCampos(9, "VL_GRIS", "N", 0, 2, false)]
            public string VlGris { get; set; }

            /// <summary>
            ///   Somatório dos valores de pedágio
            /// </summary>
            [SpedCampos(10, "VL_PDG", "N", 0, 2, false)]
            public string VlPdg { get; set; }

            /// <summary>
            ///    Outros valores
            /// </summary>
            [SpedCampos(11, "VL_OUT", "N", 0, 2, false)]
            public string VlOut { get; set; }

            /// <summary>
            ///    Valor total do frete
            /// </summary>
            [SpedCampos(12, "VL_FRT", "N", 0, 2, true)]
            public string VlFrt { get; set; }

            /// <summary>
            ///    Placa de identificação do veículo
            /// </summary>
            [SpedCampos(13, "VEIC_ID", "C", 7, 0, false)]
            public string VeicId { get; set; }

            /// <summary>
            ///   Sigla da UF da placa do veículo
            /// <summary>
            [SpedCampos(14, "UF_ID", "C", 2, 0, false)]
            public string UfId { get; set; }
        }

        /// <summary>
        ///  REGISTRO D180: MODAIS (CÓDIGO 26)
        /// </summary>
        public class RegistroD180 : RegistroBaseSped
        {

            public RegistroD180()
            {
                Reg = "D180";
            }

            /// <summary>
            ///   Número de ordem sequencial do modal
            /// </summary>
            [SpedCampos(2, "NUM_SEQ", "N", 0, 0, true)]
            public string NumSeq { get; set; }

            /// <summary>
            ///    Indicador do emitente do documento fiscal:
            /// </summary>
            /// <remarks>
            ///    0 - Emissão própria;
            ///    <para />
            ///    1 -Terceiros
            /// </remarks>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true)]
            public string IndEmit { get; set; }

            /// <summary>
            ///   CNPJ ou CPF do participante emitente do modal
            /// </summary>
            [SpedCampos(4, "CNPJ_CPF_EMIT", "N", 14, 0, true)]
            public string CnpjCpfEmit { get; set; }

            /// <summary>
            ///   Sigla da unidade da federação do participante emitente do modal
            /// </summary>
            [SpedCampos(5, "UF_EMIT", "C", 2, 0, true)]
            public string UfEmit { get; set; }

            /// <summary>
            ///    Inscrição Estadual do participante emitente do modal
            /// </summary>
            [SpedCampos(6, "IE_EMIT", "C", 14, 0, false)]
            public string IeEmit { get; set; }

            /// <summary>
            ///    Código do município de origem do serviço, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(7, "COD_MUN_ORIG", "N", 7, 0, true)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///    CNPJ/CPF do participante tomador do serviço
            /// </summary>
            [SpedCampos(8, "CNPJ_CPF_TOM", "N", 14, 0, true)]
            public string CnpjCpfTom { get; set; }

            /// <summary>
            ///    Sigla da unidade da federação do participante tomador do serviço
            /// </summary>
            [SpedCampos(9, "UF_TOM", "C", 2, 0, true)]
            public string UfTom { get; set; }

            /// <summary>
            ///     Inscrição Estadual do participante tomador do serviço
            /// </summary>
            [SpedCampos(10, "IE_TOM", "C", 14, 0, false)]
            public string IeTom { get; set; }

            /// <summary>
            ///     Código do município de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(11, "COD_MUN_DEST", "N", 7, 0, true)]
            public string CodMunDest { get; set; }

            /// <summary>
            ///    Código do modelo do documento fiscal, conforme a Tabela 4.1.1 
            /// </summary>
            [SpedCampos(12, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///    Série do documento fiscal
            /// </summary>
            [SpedCampos(13, "SER", "C", 4, 0, true)]
            public string Ser { get; set; }

            /// <summary>
            ///    Subsérie do documento fiscal
            /// <summary>
            [SpedCampos(14, "SUB", "N", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///    Número do documento fiscal
            /// </summary>
            [SpedCampos(15, "NUM_DOC", "N", 9, 0, true)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(16, "DT_DOC", "N", 8, 0, true)]
            public string DtDoc { get; set; }

            /// <summary>
            ///     Valor total do documento fiscal
            /// </summary>
            [SpedCampos(17, "VL_DOC", "N", 0, 2, true)]
            public string VlDoc { get; set; }
        }


        /// <summary>
        ///     REGISTRO D190: REGISTRO ANALÍTICO DOS DOCUMENTOS (CÓDIGO 07, 08, 8B, 09, 10, 11, 26, 27 e 57).
        /// </summary>
        public class RegistroD190 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroD190"/>.
            /// </summary>
            public RegistroD190()
            {
                Reg = "D190";
            }

            /// <summary>
            ///     Código da Situação Tributária referente ao ICMS, conforme a Tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação, conforme a tabela indicada no item 4.2.2
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, true)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor da operação correspondente à combinação de CST_ICMS, CFOP, e alíquota do ICMS.
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///   Parcela correspondente ao "Valor da base de cálculo do ICMS" 
            ///   <para />
            ///   referente à combinação CST_ICMS, CFOP,e alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do ICMS" referente à combinação CST_ICMS,  CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///   Valor não tributado em função da redução da base de cálculo do ICMS,
            ///   <para />
            ///   referente à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(8, "VL_RED_BC", "N", 0, 2, true)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Código da observação do lançamento fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(9, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO D195: OBSERVAÇÕES DO LANÇAMENTO FISCAL
        /// </summary>
        public class RegistroD195 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="RegistroD195"/>.
            /// </summary>
            public RegistroD195()
            {
                Reg = "D195";
            }

            /// <summary>
            ///     Código da observação do lançamento fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(2, "COD_OBS", "C", 6, 0, true)]
            public string CodObs { get; set; }

            /// <summary>
            ///     Descrição complementar do código de observação
            /// </summary>
            [SpedCampos(3, "TXT_COMPL", "C", 0, 0, false)]
            public string TxtCompl { get; set; }

            public List<RegistroD197> RegD197s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D197: OUTRAS OBRIGAÇÕES TRIBUTÁRIAS, AJUSTES E INFORMAÇÕES DE VALORES PROVENIENTES DE DOCUMENTO FISCAL.
        /// </summary>
        public class RegistroD197 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroD197" />.
            /// </summary>
            public RegistroD197()
            {
                Reg = "C197";
            }

            /// <summary>
            ///     Código do ajustes/benefício/incentivo, conforme tabela indicada no item 5.3
            /// </summary>
            [SpedCampos(2, "COD_AJ", "C", 10, 0, true)]
            public string CodAj { get; set; }

            /// <summary>
            ///     Descrição complementar do ajuste do documento fiscal
            /// </summary>
            [SpedCampos(3, "DESCR_COMPL_AJ", "C", 999, 0, false)]
            public string DescrComplAj { get; set; }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(4, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Base de cálculo do ICMS ou do ICMS ST
            /// </summary>
            [SpedCampos(5, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS ou do ICMS ST
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Outros valores
            /// </summary>
            [SpedCampos(8, "VL_OUTROS", "N", 0, 2, false)]
            public decimal VlOutros { get; set; }
        }

        /// <summary>
        ///    REGISTRO D300: REGISTRO ANALÍTICO DOS BILHETES CONSOLIDADOS DE PASSAGEM RODOVIÁRIO (CÓDIGO 13), 
        ///    <para />
        ///    DE PASSAGEM AQUAVIÁRIO (CÓDIGO 14), DE PASSAGEM E NOTA DE BAGAGEM (CÓDIGO 15) E DE PASSAGEM FERROVIÁRIO (CÓDIGO 16)
        /// </summary>
        public class RegistroD300 : RegistroBaseSped
        {
            public RegistroD300()
            {
                Reg = "D300";
            }

            /// <summary>
            ///   Código do modelo do documento fiscal, conforme a Tabela 4.1.1 
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///   Série do documento fiscal
            /// </summary>
            [SpedCampos(3, "SER", "C", 4, 0, true)]
            public string Ser { get; set; }

            /// <summary>
            ///   Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(4, "SUB", "N", 4, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///    Número do primeiro documento fiscal emitido (mesmo modelo, série e subsérie)
            /// </summary>
            [SpedCampos(5, "NUM_DOC_INI", "N", 6, 0, true)]
            public string NumDocIni { get; set; }

            /// <summary>
            ///   Número do último documento fiscal emitido (mesmo modelo, série e subsérie)
            /// </summary>
            [SpedCampos(6, "NUM_DOC_FIN", "N", 0, 0, true)]
            public string NumDocFin { get; set; }

            /// <summary>
            ///   Código da Situação Tributária, conforme a Tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(7, "CST_ICMS", "N", 3, 0, true)]
            public string CstIcms { get; set; }

            /// <summary>
            ///   Código Fiscal de Operação e Prestação conforme tabela indicada no item 4.2.2
            /// </summary>
            [SpedCampos(8, "CFOP", "N", 4, 0, true)]
            public string Cfop { get; set; }

            /// <summary>
            ///   Alíquota do ICMS
            /// </summary>
            [SpedCampos(9, "ALIQ_ICMS", "N", 6, 2, false)]
            public string AliqIcms { get; set; }

            /// <summary>
            ///   Data da emissão dos documentos fiscais
            /// </summary>
            [SpedCampos(10, "DT_DOC", "N", 8, 0, true)]
            public string DtDoc { get; set; }

            /// <summary>
            ///   Valor total acumulado das operações correspondentes à combinação de CST_ICMS, CFOP
            ///   <para />
            ///   e alíquota do ICMS, incluídas as despesas acessórias e acréscimos. 
            /// </summary>
            [SpedCampos(11, "VL_OPR", "N", 0, 2, true)]
            public string VlOpr { get; set; }

            /// <summary>
            ///   Valor total dos descontos
            /// </summary>
            [SpedCampos(12, "VL_DESC", "N", 0, 2, false)]
            public string VlDesc { get; set; }

            /// <summary>
            ///   Valor total da prestação de serviço
            /// </summary>
            [SpedCampos(13, "VL_SERV", "N", 0, 2, true)]
            public string VlServ { get; set; }

            /// <summary>
            ///   Valor de seguro
            /// </summary>
            [SpedCampos(14, "VL_SEG", "N", 0, 2, false)]
            public string VlSeg { get; set; }

            /// <summary>
            ///   Valor de outras despesas
            /// </summary>
            [SpedCampos(15, "VL_OUT_DESP", "N", 0, 2, false)]
            public string VlOutDesp { get; set; }

            /// <summary>
            ///   Valor total da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(16, "VL_BC_ICMS", "N", 0, 2, true)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///   Valor total do ICMS
            /// </summary>
            [SpedCampos(17, "VL_ICMS", "N", 0, 2, true)]
            public string VlIcms { get; set; }

            /// <summary>
            ///   Valor não tributado em função da redução da base de cálculo do ICMS, 
            ///   <para />
            ///   referente à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(18, "VL_RED_BC", "N", 0, 2, true)]
            public string VlRedBc { get; set; }

            /// <summary>
            ///   Código da observação do lançamento fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(19, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(20, "COD_CTA", "C", 0, 0, false)]
            public string CodCta { get; set; }

            public List<RegistroD301> RegD301s { get; set; }
            public List<RegistroD310> RegD310s { get; set; }
        }

        /// <summary>
        ///    REGISTRO D301: DOCUMENTOS CANCELADOS DOS BILHETES DE PASSAGEM RODOVIÁRIO (CÓDIGO 13), 
        ///    <para />
        ///    DE PASSAGEM AQUAVIÁRIO (CÓDIGO 14), DE PASSAGEM E NOTA DE BAGAGEM (CÓDIGO 15) E DE PASSAGEM FERROVIÁRIO (CÓDIGO 16). 
        /// </summary>
        public class RegistroD301 : RegistroBaseSped
        {
            public RegistroD301()
            {
                Reg = "D301";
            }

            /// <summary>
            ///   Número do documento fiscal cancelado 
            /// </summary>
            [SpedCampos(2, "NUM_DOC_CANC", "N", 0, 0, true)]
            public string NumDocCanc { get; set; }

        }
        /// <summary>
        ///    REGISTRO D310: COMPLEMENTO DOS BILHETES (CÓDIGO 13, 14, 15 E 16).
        /// </summary>
        public class RegistroD310 : RegistroBaseSped
        {
            public RegistroD310()
            {
                Reg = "D310";
            }

            /// <summary>
            ///    Código do município de origem do serviço, conforme a tabela IBGE
            /// </summary>
            [SpedCampos(2, "COD_MUN_ORIG", "N", 7, 0, true)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///    Valor total da prestação de serviço
            /// </summary>
            [SpedCampos(3, "VL_SERV", "N", 0, 2, true)]
            public string VlServ { get; set; }

            /// <summary>
            ///    Valor total da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(4, "VL_BC_ICMS", "N", 0, 2, false)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///    Valor total do ICMS
            /// </summary>
            [SpedCampos(5, "VL_ICMS", "N", 0, 2, false)]
            public string VlIcms { get; set; }
        }

        /// <summary>
        ///   REGISTRO D350: EQUIPAMENTO ECF (CÓDIGOS 2E, 13, 14, 15 e 16)
        /// </summary>
        public class RegistroD350 : RegistroBaseSped
        {
            public RegistroD350()
            {
                Reg = "D350";
            }

            /// <summary>
            ///    Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///   Modelo do equipamento
            /// </summary>
            [SpedCampos(3, "ECF_MOD", "C", 20, 0, true)]
            public string EcfMod { get; set; }

            /// <summary>
            ///   Número de série de fabricação do ECF
            /// </summary>
            [SpedCampos(4, "ECF_FAB", "C", 21, 0, true)]
            public string EcfFab { get; set; }

            /// <summary>
            ///   Número do caixa atribuído ao ECF
            /// </summary>
            [SpedCampos(5, "ECF_CX", "N", 3, 0, true)]
            public string EcfCx { get; set; }

            public List<RegistroD355> RegD355s { get; set; }
        }

        /// <summary>
        ///  REGISTRO D355: REDUÇÃO Z (CÓDIGOS 2E, 13, 14, 15 e 16). 
        /// </summary>
        public class RegistroD355 : RegistroBaseSped
        {
            public RegistroD355()
            {
                Reg = "D355";
            }

            /// <summary>
            ///   Data do movimento a que se refere a Redução Z
            /// </summary>
            [SpedCampos(2, "DT_DOC", "N", 8, 0, true)]
            public string DtDoc { get; set; }

            /// <summary>
            ///   Posição do Contador de Reinício de Operação
            /// </summary>
            [SpedCampos(3, "CRO", "N", 3, 0, true)]
            public string Cro { get; set; }

            /// <summary>
            ///   Posição do Contador de Redução Z
            /// </summary>
            [SpedCampos(4, "CRZ", "N", 6, 0, true)]
            public string Crz { get; set; }

            /// <summary>
            ///   Número do Contador de Ordem de Operação do último documento emitido no dia. (Número do COO na Redução Z)
            /// </summary>
            [SpedCampos(5, "NUM_COO_FIN", "N", 9, 0, true)]
            public string NumCooFin { get; set; }

            /// <summary>
            ///   Valor do Grande Total final
            /// </summary>
            [SpedCampos(6, "GT_FIN", "N", 0, 2, true)]
            public string GtFin { get; set; }

            /// <summary>
            ///   Valor da venda bruta
            /// </summary>
            [SpedCampos(7, "VL_BRT", "N", 0, 2, true)]
            public string VlBrt { get; set; }

            public RegistroD360 RegD360s { get; set; }
            public List<RegistroD365> RegD365s { get; set; }
            public List<RegistroD390> RegD390s { get; set; }
        }

        /// <summary>
        ///   REGISTRO D360: PIS E COFINS TOTALIZADOS NO DIA (CÓDIGOS 2E, 13, 14, 15 e 16).
        /// </summary>
        public class RegistroD360 : RegistroBaseSped
        {
            public RegistroD360()
            {
                Reg = "D360";
            }

            /// <summary>
            ///   Valor total do PIS
            /// </summary>
            [SpedCampos(2, "VL_PIS", "N", 0, 2, false)]
            public string VlPis { get; set; }

            /// <summary>
            ///   Valor total da COFINS
            /// </summary>
            [SpedCampos(3, "VL_COFINS", "N", 0, 2, false)]
            public string VlCofins { get; set; }

        }

        /// <summary>
        ///   REGISTRO D365: REGISTRO DOS TOTALIZADORES PARCIAIS DA  REDUÇÃO Z (CÓDIGOS 2E, 13, 14, 15 e 16).
        /// </summary>
        public class RegistroD365 : RegistroBaseSped
        {
            public RegistroD365()
            {
                Reg = "D365";
            }

            /// <summary>
            ///   Código do totalizador, conforme Tabela 4.4.6
            /// </summary>
            [SpedCampos(2, "COD_TOT_PAR", "C", 7, 0, true)]
            public string CodTotPar { get; set; }

            /// <summary>
            ///   Valor acumulado no totalizador, relativo à respectiva Redução Z.
            /// </summary>
            [SpedCampos(3, "VLR_ACUM_TOT", "N", 0, 2, true)]
            public string VlrAcumTot { get; set; }

            /// <summary>
            ///   Número do totalizador quando ocorrer mais de uma situação com a mesma carga tributária efetiva.
            /// </summary>
            [SpedCampos(4, "NR_TOT", "N", 2, 0, false)]
            public string NrTot { get; set; }

            /// <summary>
            ///   Descrição da situação tributária relativa ao totalizador parcial, 
            ///   <para />
            ///   quando houver mais de um com a mesma carga tributária efetiva.
            /// </summary>
            [SpedCampos(5, "DESCR_NR_TOT", "C", 0, 0, false)]
            public string DescrNrTot { get; set; }

            public List<RegistroD370> RegD370s { get; set; }
        }

        /// <summary>
        ///   REGISTRO D370: COMPLEMENTO DOS DOCUMENTOS INFORMADOS (CÓDIGOS 13, 14, 15 e 16 e 2E)
        /// </summary>
        public class RegistroD370 : RegistroBaseSped
        {
            public RegistroD370()
            {
                Reg = "D370";
            }

            /// <summary>
            ///   Código do município de origem do serviço, conforme a tabela IBGE
            /// </summary>
            [SpedCampos(2, "COD_MUN_ORIG", "N", 7, 0, true)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///   Valor total da prestação de serviço
            /// </summary>
            [SpedCampos(3, "VL_SERV", "N", 0, 2, true)]
            public string VlServ { get; set; }

            /// <summary>
            ///   Quantidade de bilhetes emitidos
            /// </summary>
            [SpedCampos(4, "QTD_BILH", "N", 0, 0, true)]
            public string QtdBilh { get; set; }

            /// <summary>
            ///   Valor total da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(5, "VL_BC_ICMS", "N", 0, 2, false)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///   Valor total do ICMS
            /// </summary>
            [SpedCampos(6, "VL_ICMS", "N", 0, 2, false)]
            public string VlIcms { get; set; }

        }

        /// <summary>
        ///   REGISTRO D390: REGISTRO ANALÍTICO DO MOVIMENTO DIÁRIO (CÓDIGOS 13, 14, 15, 16 E 2E).
        /// </summary>
        public class RegistroD390 : RegistroBaseSped
        {
            public RegistroD390()
            {
                Reg = "D390";
            }

            /// <summary>
            ///   Código da Situação Tributária, conforme a Tabela indicada no item 4.3.1.
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public string CstIcms { get; set; }

            /// <summary>
            ///   Código Fiscal de Operação e Prestação
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public string Cfop { get; set; }

            /// <summary>
            ///   Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false)]
            public string AliqIcms { get; set; }

            /// <summary>
            ///   Valor da operação correspondente à combinação de CST_ICMS, CFOP, 
            ///   <para />
            ///   e alíquota do ICMS, incluídas as despesas acessórias e acréscimos 
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public string VlOpr { get; set; }

            /// <summary>
            ///   Valor da base de cálculo do ISSQN
            /// </summary>
            [SpedCampos(6, "VL_BC_ISSQN", "N", 0, 2, false)]
            public string VlBcIssqn { get; set; }

            /// <summary>
            ///   Alíquota do ISSQN
            /// </summary>
            [SpedCampos(7, "ALIQ_ISSQN", "N", 6, 2, false)]
            public string AliqIssqn { get; set; }

            /// <summary>
            ///   Valor do ISSQN
            /// </summary>
            [SpedCampos(8, "VL_ISSQN", "N", 0, 2, false)]
            public string VlIssqn { get; set; }

            /// <summary>
            ///   Base de cálculo do ICMS acumulada relativa à alíquota informada
            /// </summary>
            [SpedCampos(9, "VL_BC_ICMS", "N", 0, 2, true)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///   Valor do ICMS acumulado relativo à alíquota informada
            /// </summary>
            [SpedCampos(10, "VL_ICMS", "N", 0, 2, true)]
            public string VlIcms { get; set; }

            /// <summary>
            ///   Código da observação do lançamento fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(11, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///   REGISTRO D400: RESUMO DE MOVIMENTO DIÁRIO - RMD (CÓDIGO 18).
        /// </summary>
        public class RegistroD400 : RegistroBaseSped
        {
            public RegistroD400()
            {
                Reg = "D400";
            }

            /// <summary>
            ///   Código do participante (campo 02 do Registro 0150):-agência, filial ou posto
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, true)]
            public string CodPart { get; set; }

            /// <summary>
            ///   Código do modelo do documento fiscal, conforme a Tabela 4.1.1 
            /// </summary>
            [SpedCampos(3, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///   Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(4, "COD_SIT", "N", 2, 0, true)]
            public string CodSit { get; set; }

            /// <summary>
            ///    Série do documento fiscal
            /// </summary>
            [SpedCampos(5, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///   Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(6, "SUB", "N", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///   Número do documento fiscal resumo.
            /// </summary>
            [SpedCampos(7, "NUM_DOC", "N", 6, 0, true)]
            public string NumDoc { get; set; }

            /// <summary>
            ///   Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(8, "DT_DOC", "N", 8, 0, true)]
            public string DtDoc { get; set; }

            /// <summary>
            ///   Valor total do documento fiscal
            /// </summary>
            [SpedCampos(9, "VL_DOC", "N", 0, 2, true)]
            public string VlDoc { get; set; }

            /// <summary>
            ///   Valor acumulado dos descontos
            /// </summary>
            [SpedCampos(10, "VL_DESC", "N", 0, 2, false)]
            public string VlDesc { get; set; }

            /// <summary>
            ///   Valor acumulado da prestação de serviço
            /// </summary>
            [SpedCampos(11, "VL_SERV", "N", 0, 2, true)]
            public string VlServ { get; set; }

            /// <summary>
            ///   Valor total da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(12, "VL_BC_ICMS", "N", 0, 2, false)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///   Valor total do ICMS
            /// </summary>
            [SpedCampos(13, "VL_ICMS", "N", 0, 2, false)]
            public string VlIcms { get; set; }

            /// <summary>
            ///   Valor do PIS
            /// </summary>
            [SpedCampos(14, "VL_PIS", "N", 0, 2, false)]
            public string VlPis { get; set; }

            /// <summary>
            ///   Valor da COFINS
            /// </summary>
            [SpedCampos(15, "VL_COFINS", "N", 0, 2, false)]
            public string VlOfins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(16, "COD_CTA", "C", 0, 0, false)]
            public string CodCta { get; set; }

            public List<RegistroD410> RegD410s { get; set; }
            public List<RegistroD420> RegD420s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D410: DOCUMENTOS INFORMADOS (CÓDIGOS 13, 14, 15 E 16).
        /// </summary>
        public class RegistroD410 : RegistroBaseSped
        {
            public RegistroD410()
            {
                Reg = "D410";
            }

            /// <summary>
            ///   Código do modelo do documento fiscal , conforme a Tabela 4.1.1 
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///   Série do documento fiscal 
            /// </summary>
            [SpedCampos(3, "SER", "C", 4, 0, true)]
            public string Ser { get; set; }

            /// <summary>
            ///   Subsérie do documento fisca
            /// </summary>
            [SpedCampos(4, "SUB", "N", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///   Número do documento fiscal inicial (mesmo modelo, série e subsérie)
            /// </summary>
            [SpedCampos(5, "NUM_DOC_INI", "N", 6, 0, true)]
            public string NumDocIni { get; set; }

            /// <summary>
            ///   Número do documento fiscal final(mesmo modelo, série e subsérie)
            /// </summary>
            [SpedCampos(6, "NUM_DOC_FIN", "N", 0, 0, true)]
            public string NumDocFin { get; set; }

            /// <summary>
            ///   Data da emissão dos documentos fiscais
            /// </summary>
            [SpedCampos(7, "DT_DOC", "N", 8, 0, true)]
            public string DtDoc { get; set; }

            /// <summary>
            ///   Código da Situação Tributária, conforme a Tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(8, "CST_ICMS", "N", 3, 0, true)]
            public string CstIcms { get; set; }

            /// <summary>
            ///   Código Fiscal de Operação e Prestação
            /// </summary>
            [SpedCampos(9, "CFOP", "N", 4, 0, true)]
            public string Cfop { get; set; }

            /// <summary>
            ///   Alíquota do ICMS
            /// </summary>
            [SpedCampos(10, "ALIQ_ICMS", "N", 6, 2, false)]
            public string AliqIcms { get; set; }

            /// <summary>
            ///   Valor total acumulado das operações correspondentes à combinação de CST_ICMS, CFOP
            ///   <para />
            ///   e alíquota do ICMS,incluídas as despesas acessórias e acréscimos. 
            /// </summary>
            [SpedCampos(11, "VL_OPR", "N", 0, 2, true)]
            public string VlOpr { get; set; }

            /// <summary>
            ///   Valor acumulado dos descontos
            /// </summary>
            [SpedCampos(12, "VL_DESC", "N", 0, 2, false)]
            public string VlDesc { get; set; }

            /// <summary>
            ///   Valor acumulado da prestação de serviço
            /// </summary>
            [SpedCampos(13, "VL_SERV", "N", 0, 2, true)]
            public string VlServ { get; set; }

            /// <summary>
            ///   Valor acumulado da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(14, "VL_BC_ICMS", "N", 0, 2, true)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///   Valor acumulado do ICMS
            /// </summary>
            [SpedCampos(15, "VL_ICMS", "N", 0, 2, true)]
            public string VlIcms { get; set; }

            public List<RegistroD411> RegD411s { get; set; }

        }

        /// <summary>
        ///   REGISTRO D411: DOCUMENTOS CANCELADOS DOS DOCUMENTOS INFORMADOS (CÓDIGO 13, 14, 15 e 16).
        /// </summary>
        public class RegistroD411 : RegistroBaseSped
        {
            public RegistroD411()
            {
                Reg = "D411";
            }

            /// <summary>
            ///   Número do documento fiscal cancelado
            /// </summary>
            [SpedCampos(2, "NUM_DOC_CANC", "N", 0, 0, true)]
            public string NumDocCanc { get; set; }

        }

        /// <summary>
        ///   REGISTRO D420: COMPLEMENTO DOS DOCUMENTOS INFORMADOS (CÓDIGO 13, 14,15 e 16).
        /// </summary>
        public class RegistroD420 : RegistroBaseSped
        {
            public RegistroD420()
            {
                Reg = "D420";
            }

            /// <summary>
            ///   Código do município de origem do serviço, conforme a tabela IBGE
            /// </summary>
            [SpedCampos(2, "COD_MUN_ORIG", "N", 7, 0, true)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///   Valor total da prestação de serviço
            /// </summary>
            [SpedCampos(3, "VL_SERV", "N", 0, 2, true)]
            public string VlServ { get; set; }

            /// <summary>
            ///   Valor total da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(4, "VL_BC_ICMS", "N", 0, 2, true)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///    Valor total do ICMS
            /// </summary>
            [SpedCampos(5, "VL_ICMS", "N", 0, 2, true)]
            public string VlIcms { get; set; }

        }

        /// <summary>
        ///     REGISTRO D500: NOTA FISCAL DE SERVIÇO DE COMUNICAÇÃO (CÓDIGO 21) E NOTA FISCAL DE SERVIÇO DE TELECOMUNICAÇÃO (CÓDIGO 22)
        /// </summary>
        public class RegistroD500 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD500"/>.
            /// </summary>
            public RegistroD500()
            {
                Reg = "D500";
            }

            /// <summary>
            ///     Indicador do tipo de operação:
            ///     <para />
            ///     0 - Aquisição;
            ///     <para />
            ///     1 - Prestação;
            /// </summary>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true)]
            public string IndOper { get; set; }

            /// <summary>
            ///     Indicador do emitente do documento fiscal:
            ///     <para />
            ///     0 - Emissao própria;
            ///     <para />
            ///     1 - Terceiros;
            /// </summary>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true)]
            public string IndEmit { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150);
            ///     <para />
            ///     -do prestador do serviço, no caso de aquisição;
            ///     <para />
            ///     -do tomador do serviço, no caso de prestação;
            /// </summary>
            [SpedCampos(4, "COD_PART", "C", 60, 0, true)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(5, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(6, "COD_SIT", "N", 2, 0, true)]
            public string CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(7, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(8, "SUB", "C", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(9, "NUM_DOC", "N", 9, 0, true)]
            public decimal NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(10, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Data da entrada(aquisição) ou da saida(prestação do serviço)
            /// </summary>
            [SpedCampos(11, "DT_A_P", "N", 8, 0, false)]
            public DateTime? DtAP { get; set; }

            /// <summary>
            ///     Valor total do documento fiscal
            /// </summary>
            [SpedCampos(12, "VL_DOC", "N", 0, 2, true)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(13, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Valor da prestação de serviços
            /// </summary>
            [SpedCampos(14, "VL_SERV", "N", 0, 2, true)]
            public decimal VlServ { get; set; }

            /// <summary>
            ///     Valor total dos serviços não-tributados pelo ICMS
            /// </summary>
            [SpedCampos(15, "VL_SERV_NT", "N", 0, 2, false)]
            public decimal VlServNt { get; set; }

            /// <summary>
            ///     Valores cobrados em nome de terceiros
            /// </summary>
            [SpedCampos(16, "VL_TERC", "N", 0, 2, false)]
            public decimal VlTerc { get; set; }

            /// <summary>
            ///     Valor de outras despesas indicadas no documento fiscal
            /// </summary>
            [SpedCampos(17, "VL_DA", "N", 0, 2, false)]
            public decimal VlDa { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(18, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS
            /// </summary>
            [SpedCampos(19, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Código da informação complementar (campo 02 do Registro 0450)
            /// </summary>
            [SpedCampos(20, "COD_INF", "C", 6, 0, false)]
            public string CodInf { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(21, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(22, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(23, "COD_CTA", "C", 0, 0, false)]
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
            [SpedCampos(24, "TP_ASSINANTE", "N", 1, 0, false)]
            public string TpAssinante { get; set; }

            public List<RegistroD510> RegD510s { get; set; }
            public List<RegistroD530> RegD530s { get; set; }
            public List<RegistroD590> RegD590s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D510: ITENS DO DOCUMENTO - NOTA FISCAL DE SERVIÇO DE COMUNICAÇÃO (CÓDIGO 21) E SERVIÇO DE TELECOMUNICAÇÃO (CÓDIGO 22).
        /// </summary>
        public class RegistroD510 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD510"/>.
            /// </summary>
            public RegistroD510()
            {
                Reg = "D510";
            }

            /// <summary>
            ///     Número sequencial do item no documento fiscal
            /// </summary>
            [SpedCampos(2, "NUM_ITEM", "N", 3, 0, true)]
            public int NumItem { get; set; }

            /// <summary>
            ///     Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Código de classificação do item do serviço de comunicação ou de telecomunicação, conforme a Tabela 4.4.1
            /// </summary>
            [SpedCampos(4, "COD_CLASS", "N", 4, 0, true)]
            public int CodClass { get; set; }

            /// <summary>
            ///     Quantidade do item
            /// </summary>
            [SpedCampos(5, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Unidade do item (Campo 02 do registro 0190)
            /// </summary>
            [SpedCampos(6, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///     Valor do item
            /// </summary>
            [SpedCampos(7, "VL_ITEM", "N", 0, 2, true)]
            public decimal Vl_Item { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(8, "VL_DESC", "N", 0, 2, false)]
            public decimal Vl_Desc { get; set; }

            /// <summary>
            ///     Código da Situação Tributária, conforme a Tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(9, "CST_ICMS", "N", 3, 0, true)]
            public decimal CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação
            /// </summary>
            [SpedCampos(10, "CFOP", "N", 4, 0, true)]
            public decimal Cfop { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(11, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(12, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS creditado/debitado
            /// </summary>
            [SpedCampos(13, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS de outras UFs
            /// </summary>
            [SpedCampos(14, "VL_BC_ICMS_UF", "N", 0, 2, false)]
            public decimal VlBcIcmsUf { get; set; }

            /// <summary>
            ///     Valor do ICMS de outras UFs
            /// </summary>
            [SpedCampos(15, "VL_ICMS_UF", "N", 0, 2, false)]
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
            [SpedCampos(16, "IND_REC", "C", 1, 0, true)]
            public string IndRec { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150) receptor da receita, terceiro da operação, se houver.
            /// </summary>
            [SpedCampos(17, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(18, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(19, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(20, "COD_CTA", "C", 0, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO D530: TERMINAL FATURADO.
        /// </summary>
        public class RegistroD530 : RegistroBaseSped
        {
            /// <summary>
            ///    Inicializa uma nova instância da classe <see cref="RegistroD530"/>.
            /// </summary>
            public RegistroD530()
            {
                Reg = "D530";
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
            [SpedCampos(2, "IND_SERV", "C", 1, 0, true)]
            public string IndServ { get; set; }

            /// <summary>
            ///     Data em que se iniciou a prestação do serviço
            /// </summary>
            [SpedCampos(3, "DT_INI_SERV", "N", 8, 0, false)]
            public DateTime? DtIniServ { get; set; }

            /// <summary>
            ///     Data em que se encerrou a prestação do serviço
            /// </summary>
            [SpedCampos(4, "DT_FIN_SERV", "N", 8, 0, false)]
            public DateTime? DtFinServ { get; set; }

            /// <summary>
            ///     Período fiscal da prestação do serviço (MMAAAA)
            /// </summary>
            [SpedCampos(5, "PER_FISCAL", "MA", 6, 0, true)]
            public DateTime PerFiscal { get; set; }

            /// <summary>
            ///     Código de área do terminal faturado
            /// </summary>
            [SpedCampos(6, "COD_AREA", "C", int.MaxValue, 0, false)]
            public string CodArea { get; set; }

            /// <summary>
            ///     Identificação do terminal faturado
            /// </summary>
            [SpedCampos(7, "TERMINAL", "N", int.MaxValue, 0, false)]
            public string Terminal { get; set; }
        }

        /// <summary>
        ///     REGISTRO D590: REGISTRO ANALÍTICO DO DOCUMENTO (CÓDIGO 21 E 22).
        /// </summary>
        public class RegistroD590 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD590"/>.
            /// </summary>
            public RegistroD590()
            {
                Reg = "D590";
            }

            /// <summary>
            ///     Código da Situação Tributária, conforme a tabela indicada no item 4.3.1.
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação, conforme a tabela indicada no item 4.2.2.
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS.
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor da operação correspondente à combinação de CST_ICMS, CFOP, 
            ///     <para />
            ///     e alíquota do ICMS, incluídas as despesas acessórias e acrescímos.
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor da base de cálculo do ICMS" referente à combinação CST_ICMS, CFOP, e alíquota do ICMS. 
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do ICMS" referente à combinação CST_ICMS, CFOP, e alíquota do ICMS.
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao valor da base de cálculo do ICMS de outras UFs, referente à combinação de CST_ICMS, CFOP, e alíquota do ICMS. 
            /// </summary>
            [SpedCampos(8, "VL_BC_ICMS_UF", "N", 0, 2, true)]
            public decimal VlBcIcmsUf { get; set; }

            /// <summary>
            ///     Parcela correspondente ao valor do ICMS de outras UFs, referente à combinação de CST_ICMS, CFOP, e alíquota do ICMS. 
            /// </summary>
            [SpedCampos(9, "VL_ICMS_UF", "N", 0, 2, true)]
            public decimal VlIcmsUf { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do ICMS, referente à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(10, "VL_RED_BC", "N", 0, 2, true)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Código da observação (campo 02 do Registro 0460).
            /// </summary>
            [SpedCampos(11, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO D600: CONSOLIDAÇÃO DA PRESTAÇÃO DE SERVIÇOS - NOTAS DE SERVIÇO DE COMUNICAÇÃO (CÓDIGO  21) E DE SERVIÇO DE TELECOMUNICAÇÃO (CÓDIGO 22).
        /// </summary>
        public class RegistroD600 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD600"/>.
            /// </summary>
            public RegistroD600()
            {
                Reg = "D600";
            }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código do município dos terminais faturados, conforme a tabela IBGE
            /// </summary>
            [SpedCampos(3, "COD_MUN", "N", 7, 0, true)]
            public string CodMun { get; set; }

            /// <summary>
            ///   Série do documento fiscal
            /// </summary>
            [SpedCampos(4, "SER", "C", 4, 0, true)]
            public string Ser { get; set; }

            /// <summary>
            ///   Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(5, "SUB", "N", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Código de classe de consumo dos serviços de comunicação ou de telecomunicação, conforme a Tabela 4.4.4
            /// </summary>
            [SpedCampos(6, "COD_CONS", "N", 2, 0, true)]
            public string CodCons { get; set; }

            /// <summary>
            ///     Quantidade de documentos consolidados neste registro
            /// </summary>
            [SpedCampos(7, "QTD_CONS", "N", 0, 0, true)]
            public string QtdCons { get; set; }

            /// <summary>
            ///    Data dos documentos consolidados
            /// </summary>
            [SpedCampos(8, "DT_DOC", "N", 8, 0, true)]
            public DateTime? DtDoc { get; set; }

            /// <summary>
            ///     Valor total acumulado dos documentos fiscais
            /// </summary>
            [SpedCampos(9, "VL_DOC", "N", 0, 2, true)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Valor acumulado dos descontos
            /// </summary>
            [SpedCampos(10, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Valor acumulado das prestações de serviços tributados pelo ICMS
            /// </summary>
            [SpedCampos(11, "VL_SERV", "N", 0, 2, true)]
            public decimal VlServ { get; set; }

            /// <summary>
            ///     Valor acumulado dos serviços não-tributados pelo ICMS
            /// </summary>
            [SpedCampos(12, "VL_SERV_NT", "N", 0, 2, false)]
            public decimal VlServNt { get; set; }

            /// <summary>
            ///     Valores cobrados em nome de terceiros
            /// </summary>
            [SpedCampos(13, "VL_TERC", "N", 0, 2, false)]
            public decimal VlTerc { get; set; }

            /// <summary>
            ///     Valor acumulado das despesas acessórias
            /// </summary>
            [SpedCampos(14, "VL_DA", "N", 0, 2, false)]
            public decimal VlDa { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(15, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor acumulado do ICMS
            /// </summary>
            [SpedCampos(16, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(17, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(18, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            public List<RegistroD610> RegD610s { get; set; }
            public List<RegistroD690> RegD690s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D610: ITENS DO DOCUMENTO CONSOLIDADO (CÓDIGO 21 E 22).
        /// </summary>
        public class RegistroD610 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD610"/>.
            /// </summary>
            public RegistroD610()
            {
                Reg = "D610";
            }

            /// <summary>
            ///     Código de classificação do item do serviço de comunicação ou de telecomunicação, conforme a Tabela 4.4.1
            /// </summary>
            [SpedCampos(2, "COD_CLASS", "N", 4, 0, true)]
            public int CodClass { get; set; }


            /// <summary>
            ///     Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade acumulada do item
            /// </summary>
            [SpedCampos(4, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Unidade do item (Campo 02 do registro 0190)
            /// </summary>
            [SpedCampos(5, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///    Valor acumulado do item
            /// </summary>
            [SpedCampos(6, "VL_ITEM", "N", 0, 2, true)]
            public decimal Vl_Item { get; set; }

            /// <summary>
            ///     Valor acumulado dos descontos
            /// </summary>
            [SpedCampos(7, "VL_DESC", "N", 0, 2, false)]
            public decimal Vl_Desc { get; set; }

            /// <summary>
            ///     Código da Situação Tributária, conforme a Tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(8, "CST_ICMS", "N", 3, 0, true)]
            public decimal CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação conforme tabela indicada no item 4.2.2.
            /// </summary>
            [SpedCampos(9, "CFOP", "N", 4, 0, true)]
            public decimal Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(10, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(11, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS creditado/debitado
            /// </summary>
            [SpedCampos(12, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS de outras UFs
            /// </summary>
            [SpedCampos(13, "VL_BC_ICMS_UF", "N", 0, 2, false)]
            public decimal VlBcIcmsUf { get; set; }

            /// <summary>
            ///     Valor do ICMS de outras UFs
            /// </summary>
            [SpedCampos(14, "VL_ICMS_UF", "N", 0, 2, false)]
            public decimal VlIcmsUf { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do ICMS,referente à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(15, "VL_RED_BC", "N", 0, 2, false)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Valor acumulado do PIS
            /// </summary>
            [SpedCampos(16, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor acumulado da COFINS
            /// </summary>
            [SpedCampos(17, "VL_COFINS", "N", 0, 2, false)]
            public string VlCofins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(18, "COD_CTA", "C", 0, 0, false)]
            public decimal CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO D690: REGISTRO ANALÍTICO DOS DOCUMENTOS (CÓDIGOS 21 e 22).
        /// </summary>
        public class RegistroD690 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD690"/>.
            /// </summary>
            public RegistroD690()
            {
                Reg = "D690";
            }

            /// <summary>
            ///   Código da Situação Tributária, conforme a tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public decimal CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação conforme tabela indicada no item 4.2.2.
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public decimal Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///    Valor da operação correspondente à combinação  de  CST_ICMS,  CFOP,  e  alíquota do  ICMS,  incluídas  as  despesas  acessórias  e acréscimos 
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Parcela  correspondente  ao  “Valor  da  base  de cálculo   do   ICMS”   referente   à   combinação CST_ICMS, CFOP, e alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela  correspondente  ao  "Valor  do  ICMS" referente  à  combinação  CST_ICMS,  CFOP,  e alíquota do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Parcela  correspondente  ao  valor  da  base  de cálculo  do  ICMS  de  outras  UFs,  referente  à combinação  de  CST_ICMS,  CFOP  e  alíquota do ICMS.
            /// </summary>
            [SpedCampos(8, "VL_BC_ICMS_UF", "N", 0, 2, true)]
            public decimal VlBcIcmsUf { get; set; }

            /// <summary>
            ///    Parcela  correspondente  ao  valor  do  ICMS  de outras  UFs,  referente  à  combinação  de  CST ICMS, CFOP, e alíquota do ICMS.
            /// </summary>
            [SpedCampos(9, "VL_ICMS_UF", "N", 0, 2, true)]
            public decimal VlIcmsUf { get; set; }

            /// <summary>
            ///     Valor  não  tributado  em  função  da  redução  da base    de    cálculo    do    ICMS,    referente    à combinação  de  CST_ICMS,  CFOP  e  alíquota do ICMS.
            /// </summary>
            [SpedCampos(10, "VL_RED_BC", "N", 0, 2, true)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            /// Código  da  observação  do  lançamento  fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(11, "COD_OBS", "C", 6, 0, false)]
            public int CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO D695: CONSOLIDAÇÃO DA PRESTAÇÃO DE SERVIÇOS – NOTAS DE SERVIÇO DE COMUNICAÇÃO (CÓDIGO  21) E DE SERVIÇO DE TELECOMUNICAÇÃO (CÓDIGO 22) 
        ///     (EMPRESAS OBRIGADAS À ENTREGA DOS ARQUIVOS PREVISTOS NO CONVÊNIO ICMS 115/03).
        /// </summary>
        public class RegistroD695 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD695"/>.
            /// </summary>
            public RegistroD695()
            {
                Reg = "D695";
            }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///   Série do documento fiscal
            /// </summary>
            [SpedCampos(3, "SER", "C", 4, 0, true)]
            public string Ser { get; set; }

            /// <summary>
            ///     Número de ordem inicial
            /// </summary>
            [SpedCampos(4, "NRO_ORD_INI", "N", 9, 0, true)]
            public string NroOrdIni { get; set; }

            /// <summary>
            ///    Número de ordem final
            /// </summary>
            [SpedCampos(5, "NRO_ORD_FIN", "N", 9, 0, true)]
            public string NroOrdFin { get; set; }

            /// <summary>
            ///  Data de emissão inicial dos documentos / Data inicial de vencimento da fatura
            /// </summary>
            [SpedCampos(6, "DT_DOC_INI", "N", 8, 0, true)]
            public string DtDocIni { get; set; }

            /// <summary>
            ///  Data de emissão final dos documentos / Data final do vencimento da fatura
            /// </summary>
            [SpedCampos(7, "DT_DOC_FIN", "N", 8, 0, true)]
            public string DtDocFin { get; set; }

            /// <summary>
            ///  Nome do arquivo Mestre de Documento Fiscal
            /// </summary>
            [SpedCampos(8, "NOM_MEST", "C", 33, 0, true)]
            public string NomMest { get; set; }

            /// <summary>
            ///  Chave de codificação digital do arquivo Mestre de Documento Fiscal
            /// </summary>
            [SpedCampos(9, "CHV_COD_DIG", "C", 32, 0, true)]
            public string ChvCodDig{ get; set; }

            public List<RegistroD696> RegD696s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D696: REGISTRO ANALÍTICO DOS DOCUMENTOS (CÓDIGO 21 E 22).
        /// </summary>
        public class RegistroD696 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD696"/>.
            /// </summary>
            public RegistroD696()
            {
                Reg = "D696";
            }

            /// <summary>
            ///   Código da Situação Tributária, conforme a tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public decimal CstIcms { get; set; }

            /// <summary>
            ///     Código Fiscal de Operação e Prestação conforme tabela indicada no item 4.2.2.
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public decimal Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///    Valor da operação correspondente à combinação  de  CST_ICMS,  CFOP,  e  alíquota do  ICMS,  incluídas  as  despesas  acessórias  e acréscimos 
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Parcela  correspondente  ao  “Valor  da  base  de cálculo   do   ICMS”   referente   à   combinação CST_ICMS, CFOP, e alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela  correspondente  ao  "Valor  do  ICMS" referente  à  combinação  CST_ICMS,  CFOP,  e alíquota do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Parcela  correspondente  ao  valor  da  base  de cálculo  do  ICMS  de  outras  UFs,  referente  à combinação  de  CST_ICMS,  CFOP  e  alíquota do ICMS.
            /// </summary>
            [SpedCampos(8, "VL_BC_ICMS_UF", "N", 0, 2, true)]
            public decimal VlBcIcmsUf { get; set; }

            /// <summary>
            ///    Parcela  correspondente  ao  valor  do  ICMS  de outras  UFs,  referente  à  combinação  de  CST ICMS, CFOP, e alíquota do ICMS.
            /// </summary>
            [SpedCampos(9, "VL_ICMS_UF", "N", 0, 2, true)]
            public decimal VlIcmsUf { get; set; }

            /// <summary>
            ///     Valor  não  tributado  em  função  da  redução  da base    de    cálculo    do    ICMS,    referente    à combinação  de  CST_ICMS,  CFOP  e  alíquota do ICMS.
            /// </summary>
            [SpedCampos(10, "VL_RED_BC", "N", 0, 2, true)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            /// Código  da  observação  do  lançamento  fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(11, "COD_OBS", "C", 6, 0, false)]
            public int CodObs { get; set; }

            public List<RegistroD697> RegD697s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D697:  REGISTRO  DE  INFORMAÇÕES  DE  OUTRAS  UFs,  RELATIVAMENTE AOS SERVIÇOS “NÃO-MEDIDOS” DE TELEVISÃO POR ASSINATURA VIA SATÉLITE.
        /// </summary>
        public class RegistroD697 : RegistroBaseSped
        {
            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroD697"/>.
            /// </summary>
            public RegistroD697()
            {
                Reg = "D697";
            }

            /// <summary>
            ///    Sigla da unidade da federação
            /// </summary>
            [SpedCampos(2, "Uf", "C", 2, 0, true)]
            public decimal Uf { get; set; }

            // <summary>
            ///    Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(3, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS 
            /// </summary>
            [SpedCampos(4, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }
        }

        /// <summary>
        ///     REGISTRO D990: ENCERRAMENTO DO BLOCO D.
        /// </summary>
        public class RegistroD990 : RegistroBaseSped
        {
            /// <summary>
            ///    Inicializa uma nova instância da classe <see cref="RegistroD990"/>.
            /// </summary>
            public RegistroD990()
            {
                Reg = "D990";
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco D
            /// </summary>
            [SpedCampos(2, "QTD_LIN_D", "N", int.MaxValue, 0, true)]
            public int QtdLinD { get; set; }
        }
    }
}
