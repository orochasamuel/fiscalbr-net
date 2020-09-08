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
            /// Inicializa uma nova instância da classe <see cref="RegistroD001"/>.
            /// </summary>
            public RegistroD001()
            {
                Reg = "D001";
            }

            /// <summary>
            ///     Indicador de movimento: 0 - Bloco com dados informados; 1 - Bloco sem dados informados.
            /// </summary>
            [SpedCampos(2, "IND_MOV", "N", 1, 0, true)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroD100> RegD100s { get; set; }
            //public List<RegistroD300> RegD300s { get; set; } -> //To do
            //public List<RegistroD350> RegD350s { get; set; } -> //To do
            //public List<RegistroD400> RegD400s { get; set; } -> //To do
            public List<RegistroD500> RegD500s { get; set; }
            //public List<RegistroD600> RegD600s { get; set; } -> //To do
            //public List<RegistroD695> RegD695s { get; set; } -> //To do
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
            ///     0- Aquisição;
            ///     1- Prestação
            /// </summary>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true)]
            public int IndOper { get; set; }

            /// <summary>
            ///     Indicador do emitente do documento fiscal:
            ///     0 - Emissão própria;
            ///     1 - Terceiros;
            /// </summary>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true)]
            public int IndEmit { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150):
            ///     - do emitente do documento ou do remetente das mercadorias, no caso de entradas;
            ///     - do adquirente, no caso de saídas.
            /// </summary>
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
            ///     Chave do CT-e de referência cujos valores foram complementados (opção “1” do campo anterior) ou cujo débito foi
            ///     anulado(opção “2” do campo anterior).
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
            ///     0- Por conta de terceiros;
            ///     1- Por conta do emitente;
            ///     2- Por conta do destinatário;
            ///     9- Sem cobrança de frete.
            /// </summary>
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
            ///     Guia Prático EFD-ICMS/IPI – Versão 2.0.21
            ///     Atualização: 22/08/2017
            /// </summary>
            [SpedCampos(24, "COD_MUN_ORIG", "N", 7, 0, false)]
            public string CodMunOrig { get; set; }

            /// <summary>
            ///     Código do município de destino, conforme a tabela IBGE (Preencher com 9999999, se Exterior)
            ///     Guia Prático EFD-ICMS/IPI – Versão 2.0.21
            ///     Atualização: 22/08/2017
            /// </summary>
            [SpedCampos(25, "COD_MUN_DEST", "N", 7, 0, false)]
            public string CodMunDest { get; set; }

            public RegistroD101 RegD101 { get; set; }
            public List<RegistroD110> RegD110 { get; set; }
            //public List<RegistroD130> RegD130s { get; set; } -> //To do
            //public List<RegistroD140> RegD140s { get; set; } -> //To do
            //public List<RegistroD150> RegD150s { get; set; } -> //To do
            //public List<RegistroD160> RegD160s { get; set; } -> //To do
            //public List<RegistroD170> RegD170s { get; set; } -> //To do
            //public List<RegistroD180> RegD180s { get; set; } -> //To do
            public List<RegistroD190> RegD190s { get; set; }
            public List<RegistroD195> RegD195s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D101: INFORMAÇÃO COMPLEMENTAR DOS DOCUMENTOS FISCAIS QUANDO 
        ///     DAS PRESTAÇÕES INTERESTADUAIS DESTINADAS A CONSUMIDOR 
        ///     FINAL NÃO CONTRIBUINTE EC 87/15 (CÓDIGOS 57 e 67)
        /// </summary>
        public class RegistroD101 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="RegistroD101"/>.
            /// </summary>
            public RegistroD101()
            {
                Reg = "D101";
            }

            /// <summary>
            /// Valor total relativo ao Fundo de Combate à Pobreza (FCP) da UF de destino
            /// </summary>
            [SpedCampos(2, "VL_FCP_UF_DEST", "N", 0, 2, true)]
            public decimal VlFcpUfDest { get; set; }

            /// <summary>
            /// Valor total do ICMS Interestadual para a UF de destino
            /// </summary>
            [SpedCampos(3, "VL_ICMS_UF_DEST", "N", 0, 2, true)]
            public decimal VlIcmsUfDest { get; set; }

            /// <summary>
            /// Valor total do ICMS Interestaduak para a UF do remetente
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
            /// Inicializa uma nova instância da classe <see cref="RegistroD110"/>.
            /// </summary>
            public RegistroD110()
            {
                Reg = "D110";
            }

            /// <summary>
            /// Numero sequencial do item no documento fiscal
            /// </summary>
            [SpedCampos(2, "NUM_ITEM", "N", 3, 0, true)]
            public decimal NumItem { get; set; }

            /// <summary>
            /// Codigo do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            /// Valor do serviço
            /// </summary>
            [SpedCampos(4, "VL_SERV", "N", 0, 2, true)]
            public decimal VlServ { get; set; }

            /// <summary>
            /// Outros valores
            /// </summary>
            [SpedCampos(5, "VL_OUT", "N", 0, 2, false)]
            public decimal VlOut { get; set; }
        }

        /// <summary>
        ///     REGISTRO D120: COMPLEMENTO DA NOTA FISCAL DE SERVIÇOS DE TRANSPORTE (CODIGO 07)
        /// </summary>
        public class RegistroD120 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="RegistroD120"/>.
            /// </summary>
            public RegistroD120()
            {
                Reg = "D120";
            }

            /// <summary>
            /// Codigo do municipio de origem do serviço, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(2, "COD_MUN_ORIG", "N", 7, 0, true)]
            public decimal CodMunOrig { get; set; }

            /// <summary>
            /// Codigo do municipio de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior)
            /// </summary>
            [SpedCampos(3, "COD_MUN_DEST", "N", 7, 0, true)]
            public decimal CodMunDest { get; set; }

            /// <summary>
            /// Placa de identificacao do veiculo
            /// </summary>
            [SpedCampos(4, "VEIC_ID", "C", 7, 0, false)]
            public decimal VeicId { get; set; }

            /// <summary>
            /// Sigla da UF da placa do veiculo
            /// </summary>
            [SpedCampos(5, "UF_ID", "C", 2, 0, false)]
            public decimal UfId { get; set; }
        }

        /// <summary>
        ///     REGISTRO D190: REGISTRO ANALÍTICO DOS DOCUMENTOS (CÓDIGO 07, 08, 8B, 09, 10, 11, 26, 27 e 57).
        /// </summary>
        public class RegistroD190 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="RegistroD190"/>.
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
            ///     Parcela correspondente ao "Valor da base de cálculo do ICMS" referente à combinação CST_ICMS, CFOP, e alíquota do
            ///     ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do ICMS" referente à combinação CST_ICMS,  CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do ICMS, referente à combinação de CST_ICMS, CFOP e
            ///     alíquota do ICMS.
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
        ///     REGISTRO D500: NOTA FISCAL DE SERVIÇO DE COMUNICAÇÃO (CÓDIGO 21) E NOTA FISCAL DE SERVIÇO DE TELECOMUNICAÇÃO (CÓDIGO 22)
        /// </summary>
        public class RegistroD500 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="RegistroD500"/>.
            /// </summary>
            public RegistroD500()
            {
                Reg = "D500";
            }

            /// <summary>
            ///     Indicador do tipo de operação:
            ///     0 - Aquisição;
            ///     1 - Prestação;
            /// </summary>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true)]
            public Int16 IndOper { get; set; }

            /// <summary>
            ///     Indicador do emitente do documento fiscal:
            ///     0 - Emissao própria;
            ///     1 - Terceiros;
            /// </summary>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true)]
            public Int16 IndEmit { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150);
            ///     -do prestador do serviço, no caso de aquisição;
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
            public Int16 CodSit { get; set; }

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
            ///     1 - Comercial/Industrial
            ///     2 - Poder Público
            ///     3 - Residencial/Pessoa física
            ///     4 - Público
            ///     5 - Semi-Público
            ///     6 - Outros
            /// </summary>
            [SpedCampos(24, "TP_ASSINANTE", "N", 1, 0, false)]
            public Int16 TpAssinante { get; set; }

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
            /// Inicializa uma nova instância da classe <see cref="RegistroD510"/>.
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
            ///     0 - Receita própria - serviços prestados;
            ///     1 - Receita própria - cobrança de débitos;
            ///     2 - Receita própria - venda de mercadorias;
            ///     3 - Receita própria - venda de serviço pré-pago;
            ///     4 - Outras receitas próprias;
            ///     5 - Receitas de terceiros (co-faturamento);
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
            /// Inicializa uma nova instância da classe <see cref="RegistroD530"/>.
            /// </summary>
            public RegistroD530()
            {
                Reg = "D530";
            }

            /// <summary>
            ///     Indicador do tipo de serviço prestado:
            ///         0- Telefonia;
            ///         1- Comunicação de dados;
            ///         2- TV por assinatura;
            ///         3- Provimento de acesso à Internet;
            ///         4- Multimídia;
            ///         9- Outros
            /// </summary>
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
            [SpedCampos(6,"COD_AREA", "C", int.MaxValue, 0, false)]
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
            /// Inicializa uma nova instância da classe <see cref="RegistroD590"/>.
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
            ///     Valor da operação correspondente à combinação de CST_ICMS, CFOP, e alíquota do ICMS, incluídas as despesas acessórias e acrescímos.
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
        ///     REGISTRO D990: ENCERRAMENTO DO BLOCO D.
        /// </summary>
        public class RegistroD990 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="RegistroD990"/>.
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
