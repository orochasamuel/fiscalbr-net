using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDContribuicoes
{
    public class Bloco1
    {

        public Registro1001 Reg1001 { get; set; }
        public Registro1990 Reg1990 { get; set; }

        public class Registro1001 : RegistroBaseSped
        {
            public Registro1001()
            {
                Reg = "1001";
            }

            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }

            public List<Registro1010> Reg1010s { get; set; }
            public List<Registro1020> Reg1020s { get; set; }
            public List<Registro1050> Reg1050s { get; set; }
            public List<Registro1100> Reg1100s { get; set; }
            public List<Registro1200> Reg1200s { get; set; }
            public List<Registro1300> Reg1300s { get; set; }
            public List<Registro1500> Reg1500s { get; set; }
            public List<Registro1600> Reg1600s { get; set; }
            public List<Registro1700> Reg1700s { get; set; }
            public List<Registro1800> Reg1800s { get; set; }
            public List<Registro1900> Reg1900s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1010: Processo Referenciado –Ação Judicial
        /// </summary>
        public class Registro1010 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1010"/>
            /// </summary>
            public Registro1010()
            {
                Reg = "1010";
            }

            /// <summary>
            ///    Identificação do Número do Processo Judicial
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 20, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///    Identificação da Seção Judiciária
            /// </summary>
            [SpedCampos(3, "ID_SEC_JUD", "C", 0, 0, true)]
            public string IndSecJud { get; set; }

            ///<summary>
            ///    Identificação da Vara
            /// </summary>
            [SpedCampos(4, "ID_VARA", "C", 2, 0, true)]
            public decimal IdVara { get; set; }

            /// <summary>
            ///    Indicador da Natureza da Ação Judicial, impetrada na Justiça Federal:
            ///    01 –Decisão judicial transitada em julgado, a favor da pessoa jurídica.
            ///    02 –Decisão judicial não transitada em julgado, a favor da pessoa jurídica.
            ///    03 –Decisão judicial oriunda de liminar em mandado de segurança.04 –Decisão judicial oriunda de liminar em medida cautelar.
            ///    05 –Decisão judicial oriunda de antecipação de tutela.
            ///    06 -Decisão judicial vinculada a depósito administrativo ou judicial em montante integral.
            ///    07 –Medida judicial em que a pessoa jurídica não é o autor.
            ///    08 –Súmula vinculante aprovada pelo STF ou STJ.
            ///    09 –Decisão judicial oriunda de liminar em mandado de segurança coletivo.
            ///    12 –Decisão judicial não transitada em julgado, a favor da pessoa jurídica-Exigibilidade suspensa de contribuição.
            ///    13 –Decisão judicial oriunda de liminar em mandado de segurança-Exigibilidade suspensa de contribuição.
            ///    14 –Decisão judicial oriunda de liminar em medida cautelar-Exigibilidade suspensa de contribuição.
            ///    15 –Decisão judicial oriunda de antecipação de tutela-Exigibilidade suspensa de contribuição.
            ///    16 -Decisão judicial vinculada a depósito administrativo ou judicial em montante integral-Exigibilidade suspensa de contribuição.
            ///    17 –Medida judicial em que a pessoa jurídica não é o autor-Exigibilidade suspensa de contribuição.
            ///    19 –Decisão judicial oriunda de liminar em mandado de segurança coletivo-Exigibilidade suspensa de contribuição.
            ///    99 -Outros.
            /// </summary>
            [SpedCampos(5, "IND_NAT_ACAO", "C", 2, 0, true)]
            public decimal IndNatAcao { get; set; }

            /// <summary>
            ///    Descrição Resumida dos Efeitos Tributários abrangidos pela Decisão Judicial proferida.
            /// </summary>
            [SpedCampos(6, "DESC_DEC_JUD", "C", 100, 0, false)]
            public decimal DescDecJud { get; set; }

            /// <summary>
            ///    Data da Sentença/Decisão Judicial
            /// </summary>
            [SpedCampos(7, "DT_SENT_JUD", "N", 8, 0, false)]
            public DateTime DtSentJud { get; set; }

            public List<Registro1011> Reg1011s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1011: Detalhamento das Contribuições com Exigibilidade Suspensa
        /// </summary>
        public class Registro1011 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1011"/>
            /// </summary>
            public Registro1011()
            {
                Reg = "1011";
            }

            /// <summary>
            ///    Registro da escrituração que terá o detalhamento das  contribuições  sociais  com  exigibilidade suspensa (Blocos A, C, D, F e I, 1800)
            /// </summary>
            [SpedCampos(2, "REG_REF", "C", 4, 0, false)]
            public string RegRef { get; set; }

            /// <summary>
            ///    Chave do documento eletrônico
            /// </summary>
            [SpedCampos(3, "CHAVE_DOC", "C", 90, 0, false)]
            public string ChaveDoc { get; set; }

            /// <summary>
            ///    Código  do  participante  (Campo  02  do  Registro 0150)
            /// </summary>
            [SpedCampos(4, "COD_PART", "C", 60, 0, false)]
            public decimal CodPart { get; set; }

            /// <summary>
            ///    Código do item (campo 02 do Registro 0200
            /// </summary>
            [SpedCampos(5, "COD_ITEM", "C", 60, 0, false)]
            public decimal CodItem { get; set; }

            /// <summary>
            ///    Data da Operação (ddmmaaaa)
            /// </summary>
            [SpedCampos(6, "DT_OPER", "N", 8, 0, true)]
            public DateTime DtOper { get; set; }

            /// <summary>
            ///    Valor da Operação/Item
            /// </summary>
            [SpedCampos(7, "VL_OPER", "N", 0, 2, true)]
            public int VlOper { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao PIS/PASEP, conforme a Tabela indicada no item 4.3.3.
            /// </summary>
            [SpedCampos(8, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///   Base de cálculo do Crédito de PIS/PASEP no período (06 –07)
            /// </summary>
            [SpedCampos(9, "VL_BC_PIS", "N", 0, 4, false)]
            public string VlBcPis { get; set; }

            /// <summary>
            ///   Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(10, "ALIQ_PIS", "N", 8, 4, false)]
            public string AliqPis { get; set; }

            /// <summary>
            ///     Valor do Crédito de PIS/PASEP
            /// </summary>
            [SpedCampos(11, "VL_PIS", "N", 0, 2, false)]
            public string VlPis { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente a COFINS, conforme a Tabela indicada no item 4.3.4.
            /// </summary>
            [SpedCampos(12, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

            /// <summary>
            ///   Base de Cálculo do Crédito da COFINS no período (06 –07)
            /// </summary>
            [SpedCampos(13, "VL_BC_COFINS", "N", 0, 4, false)]
            public string VlBcCofins { get; set; }

            /// <summary>
            ///     Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(14, "ALIQ_COFINS", "N", 8, 4, false)]
            public string AliqCofins { get; set; }

            /// <summary>
            ///   Valor do crédito da COFINS
            /// </summary>
            [SpedCampos(15, "VL_COFINS", "N", 0, 2, false)]
            public string VlCofins { get; set; }

            /// <summary>
            ///    Código da Situação Tributária conforme decisão judicial,  referente  ao  PIS/PASEP,  conforme  a Tabela indicada no item 4.3.3.
            /// </summary>
            [SpedCampos(16, "CST_PIS_SUSP", "N", 2, 0, true)]
            public string CstPisSusp { get; set; }

            /// <summary>
            ///  Base de cálculo do PIS/PASEP, conforme decisão judicial
            /// </summary>
            [SpedCampos(17, "VL_BC_PIS_SUSP", "N", 0, 4, false)]
            public string VlBcPisSusp { get; set; }

            /// <summary>
            ///    Alíquota  do  PIS/PASEP,  conforme  decisão judicia
            /// </summary>
            [SpedCampos(18, "ALIQ_PIS_SUSP", "N", 8, 4, false)]
            public string AliqPisSusp { get; set; }

            /// <summary>
            ///  Valor do PIS/PASEP, conforme decisão judicial
            /// </summary>
            [SpedCampos(19, "VL_PIS_SUSP", "N", 0, 2, false)]
            public string VlPisSusp { get; set; }

            /// <summary>
            ///  Código da Situação Tributária conforme decisão judicial, referente a COFINS, conforme a Tabela indicada no item 4.3.4.
            /// </summary>
            [SpedCampos(20, "CST_COFINS_SUSP", "N", 2, 0, true)]
            public string CstCofinsSusp { get; set; }

            /// <summary>
            ///  Base  de  cálculo  da  COFINS,  conforme  decisão judicial
            /// </summary>
            [SpedCampos(21, "VL_BC_COFINS_SUSP", "N", 0, 4, false)]
            public string VlBcCofinsSusp { get; set; }

            /// <summary>
            ///  Alíquota da COFINS, conforme decisão judicial
            /// </summary>
            [SpedCampos(22, "ALIQ_COFINS_SUSP", "N", 8, 4, false)]
            public string AliqCofinsSusp { get; set; }

            /// <summary>
            ///  Valor da COFINS, conforme decisão judicia
            /// </summary>
            [SpedCampos(23, "VL_COFINS_SUSP", "N", 0, 2, false)]
            public string VlCofinsSusp { get; set; }

            /// <summary>
            ///  Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(24, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///   Código do Centro de Custos
            /// </summary>
            [SpedCampos(25, "COD_CCUS", "C", 255, 0, false)]
            public string CodCcus { get; set; }

            /// <summary>
            ///     Descrição do Documento/Operação
            /// </summary>
            [SpedCampos(26, "DESC_DOC_OPER", "C", 0, 0, false)]
            public string DescDocOper { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1020: Processo Referenciado –Processo Administrativo
        /// </summary>
        public class Registro1020 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1020"/>
            /// </summary>
            public Registro1020()
            {
                Reg = "1020";
            }

            /// <summary>
            ///    Identificação  do  Processo  Administrativo  ou  da  Decisão Administrativa
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 20, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///    Indicador da Natureza da Ação, decorrente de Processo Administrativo na Secretaria da Receita Federal do Brasil:
            ///    01 –Processo Administrativo de Consulta
            ///    02 –Despacho Decisório
            ///    03 –Ato Declaratório Executivo
            ///    04 –Ato Declaratório Interpretativo
            ///    05 –Decisão Administrativa de DRJ ou do CARF
            ///    06 –Auto de Infração
            ///    99 –Outros
            /// </summary>
            [SpedCampos(3, "IND_NAT_ACAO", "C", 2, 0, true)]
            public string IndNatAcao { get; set; }

            /// <summary>
            ///    Data do Despacho/Decisão Administrativa
            /// </summary>
            [SpedCampos(4, "DT_DEC_ADM", "N", 8, 0, true)]
            public DateTime DtDecAdm { get; set; }

        }

        /// <summary>
        ///     REGISTRO 1050:  Detalhamento de Ajustes de Base de Cálculo –Valores Extra Apuração
        /// </summary>
        public class Registro1050 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1050"/>
            /// </summary>
            public Registro1050()
            {
                Reg = "1050";
            }

            /// <summary>
            ///    Data de referência do ajuste (ddmmaaaa)
            /// </summary>
            [SpedCampos(2, "DT_REF", "N", 8, 0, true)]
            public DateTime DtRef { get; set; }

            /// <summary>
            ///   Indicador da natureza do ajuste da base de cálculo, conforme Tabela Externa 4.3.18
            /// </summary>
            [SpedCampos(3, "IND_AJ_BC", "C", 2, 0, true)]
            public string IndAjBc { get; set; }

            /// <summary>
            ///    CNPJ do estabelecimento a que se refere o ajuste
            /// </summary>
            [SpedCampos(4, "CNPJ", "N", 14, 0, true)]
            public decimal Cnpj { get; set; }

            /// <summary>
            ///    Valor total do ajuste
            /// </summary>
            [SpedCampos(5, "VL_AJ_TOT", "N", 0, 2, true)]
            public decimal VlAjTot { get; set; }

            /// <summary>
            ///    Parcela do ajuste a apropriar na base de cálculo referente ao CST 01
            /// </summary>
            [SpedCampos(6, "VL_AJ_CST01", "N", 0, 2, true)]
            public decimal VlAjCst01 { get; set; }

            /// <summary>
            ///    Parcela do ajuste a apropriar na base de cálculo referente ao CST 02
            /// </summary>
            [SpedCampos(7, "VL_AJ_CST02", "N", 0, 2, true)]
            public int VlAjCst02 { get; set; }

            /// <summary>
            ///     Parcela do ajuste a apropriar na base de cálculo referente ao CST 03
            /// </summary>
            [SpedCampos(8, "VL_AJ_CST03", "N", 0, 2, true)]
            public int VlAjCst03 { get; set; }

            /// <summary>
            ///   Parcela do ajuste a apropriar na base de cálculo referente ao CST 04
            /// </summary>
            [SpedCampos(9, "VL_AJ_CST04", "N", 0, 2, true)]
            public string VlAjCst04 { get; set; }

            /// <summary>
            ///   Parcela do ajuste a apropriar na base de cálculo referente ao CST 05
            /// </summary>
            [SpedCampos(10, "VL_AJ_CST05", "N", 0, 2, true)]
            public string VlAjCst05 { get; set; }

            /// <summary>
            ///     Parcela do ajuste a apropriar na base de cálculo referente ao CST 06
            /// </summary>
            [SpedCampos(11, "VL_AJ_CST06", "N", 0, 2, true)]
            public string VlAjCst06 { get; set; }

            /// <summary>
            ///     Parcela do ajuste a apropriar na base de cálculo referente ao CST 07
            /// </summary>
            [SpedCampos(12, "VL_AJ_CST07", "N", 0, 2, true)]
            public string VlAjCst07 { get; set; }

            /// <summary>
            ///  Parcela do ajuste a apropriar na base de cálculo referente ao CST 08 
            /// </summary>
            [SpedCampos(13, "VL_AJ_CST08", "N", 0, 2, true)]
            public string VlAjCst08 { get; set; }

            /// <summary>
            ///     Parcela do ajuste a apropriar na base de cálculo referente ao CST 09
            /// </summary>
            [SpedCampos(14, "VL_AJ_CST09", "N", 0, 2, true)]
            public string VlAjCst09 { get; set; }

            /// <summary>
            ///  Parcela do ajuste a apropriar na base de cálculo referente ao CST 49
            /// </summary>
            [SpedCampos(15, "VL_AJ_CST49", "N", 0, 2, true)]
            public string VlAjCst49 { get; set; }

            /// <summary>
            ///    Parcela do ajuste a apropriar na base de cálculo referente ao CST 99
            /// </summary>
            [SpedCampos(16, "VL_AJ_CST99", "N", 0, 2, true)]
            public string VlAjCst99 { get; set; }

            /// <summary>
            ///  Indicador de apropriação do ajuste:
            ///  01 –Referente ao PIS/Pasep e a Cofins
            ///  02 –Referente unicamente ao PIS/Pasep
            ///  03 –Referente unicamente à Cofins
            /// </summary>
            [SpedCampos(17, "IND_APROP", "C", 2, 0, false)]
            public string IndAprop { get; set; }

            /// <summary>
            ///    Número do recibo da escrituração a que se refere o ajuste
            /// </summary>
            [SpedCampos(18, "NUM_REC", "C", 80, 0, false)]
            public string NumRec { get; set; }

            /// <summary>
            ///  Informação complementar do registro
            /// </summary>
            [SpedCampos(19, "INFO_COMPL", "C", 0, 0, false)]
            public string InfoCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1100: Controle de Créditos Fiscais –PIS/Pasep
        /// </summary>
        public class Registro1100 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1100"/>
            /// </summary>
            public Registro1100()
            {
                Reg = "1100";
            }

            /// <summary>
            ///    Período de Apuração do Crédito (MM/AAAA)
            /// </summary>
            [SpedCampos(2, "PER_APU_CRED", "N", 6, 0, true)]
            public string PerApuCred { get; set; }

            /// <summary>
            ///    Indicador da origem do crédito:
            ///    01 –Crédito decorrente de operações próprias;
            ///    02 –Crédito transferido por pessoa jurídica sucedida.
            /// </summary>
            [SpedCampos(3, "ORIG_CRED", "N", 2, 0, true)]
            public string OrigCred { get; set; }

            ///<summary>
            ///    CNPJ da pessoa jurídica cedente do crédito (se ORIG_CRED = 02).
            /// </summary>
            [SpedCampos(4, "CNPJ_SUC", "N", 14, 0, false)]
            public decimal CnpjSuc { get; set; }

            /// <summary>
            ///    Código do Tipo do Crédito, conforme Tabela 4.3.6.
            /// </summary>
            [SpedCampos(5, "COD_CRED", "N", 3, 0, true)]
            public decimal CodCred { get; set; }

            /// <summary>
            ///    Valor total do crédito apurado na Escrituração Fiscal Digital (Registro M100) ou em demonstrativo DACON (Fichas 06A e 06B) de período anterior. 
            /// </summary>
            [SpedCampos(6, "VL_CRED_APU", "N", 0, 2, true)]
            public decimal VlCredApu { get; set; }

            /// <summary>
            ///    Valor de Crédito Extemporâneo Apurado (Registro 1101), referente a Período Anterior, Informado no Campo 02 –PER_APU_CRED
            /// </summary>
            [SpedCampos(7, "VL_CRED_EXT_APU", "N", 0, 2, false)]
            public int VlCredExtApu { get; set; }

            /// <summary>
            ///     Valor Total do Crédito Apurado (06 + 07)
            /// </summary>
            [SpedCampos(8, "VL_TOT_CRED_APU", "N", 0, 2, true)]
            public int VlTotCredApu { get; set; }

            /// <summary>
            ///   Valor do Crédito utilizado mediante Desconto, em Período(s)  Anterior(es).
            /// </summary>
            [SpedCampos(9, "VL_CRED_DESC_PA_ANT", "N", 0, 2, true)]
            public string VlCredDescPaAnt { get; set; }

            /// <summary>
            ///   Valor do Crédito utilizado mediante Pedido de Ressarcimento, em Período(s) Anterior(es).
            /// </summary>
            [SpedCampos(10, "VL_CRED_PER_PA_ANT", "N", 0, 2, false)]
            public string VlCredPerPaAnt { get; set; }

            /// <summary>
            ///     Valor do Crédito utilizado mediante Declaração de Compensação Intermediária (Crédito de Exportação), em Período(s) Anterior(es).
            /// </summary>
            [SpedCampos(11, "VL_CRED_DCOMP_PA_ANT", "N", 0, 2, false)]
            public string VlCredDcompPaAnt { get; set; }

            /// <summary>
            ///     Saldo do Crédito Disponível para Utilização neste Período de Escrituração (08 –09 –10 -11).
            /// </summary>
            [SpedCampos(12, "SD_CRED_DISP_EFD", "N", 0, 2, true)]
            public string SdCredDispEfd { get; set; }

            /// <summary>
            ///   Valor do Crédito descontado neste período de escrituração.
            /// </summary>
            [SpedCampos(13, "VL_CRED_DESC_EFD", "N", 0, 2, false)]
            public string VlCredDescEfd { get; set; }

            /// <summary>
            ///     Valor do Crédito objeto de Pedido de Ressarcimento (PER) neste período de escrituração.
            /// </summary>
            [SpedCampos(14, "VL_CRED_PER_EFD", "N", 0, 2, false)]
            public string VlCredPerEfd { get; set; }

            /// <summary>
            ///  Valor do Crédito utilizado mediante Declaração de Compensação Intermediária neste período de escrituração.
            /// </summary>
            [SpedCampos(15, "VL_CRED_DCOMP_EFD", "N", 0, 2, false)]
            public string VlCredDcompEfd { get; set; }

            /// <summary>
            ///    Valor do crédito transferido em evento de cisão, fusão ou incorporação.
            /// </summary>
            [SpedCampos(16, "VL_CRED_TRANS", "N", 0, 2, false)]
            public string VlCredTrans { get; set; }

            /// <summary>
            ///  Valor do crédito utilizado por outras formas.
            /// </summary>
            [SpedCampos(17, "VL_CRED_OUT", "N", 0, 2, false)]
            public string VlCredOut { get; set; }

            /// <summary>
            ///    Saldo de créditos a utilizar em período de apuração futuro (12 –13 –14 –15 –16 -17).
            /// </summary>
            [SpedCampos(18, "SLD_CRED_FIM", "N", 0, 2, false)]
            public string SldCredFim { get; set; }

            public List<Registro1101> Reg1101s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1101: Apuração  de  Crédito  Extemporâneo -Documentos  e  Operações  de  Períodos Anteriores –PIS/Pasep
        /// </summary>
        public class Registro1101 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1101"/>
            /// </summary>
            public Registro1101()
            {
                Reg = "1101";
            }

            /// <summary>
            ///    Código do participante (Campo 02 do Registro 0150)
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///    Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            /// <summary>
            ///    Código do modelo do documento fiscal, conforme a Tabela 4.1.1.
            /// </summary>
            [SpedCampos(4, "COD_MOD", "C", 2, 0, false)]
            public decimal CodMod { get; set; }

            /// <summary>
            ///    Série do documento fiscal
            /// </summary>
            [SpedCampos(5, "SER", "C", 4, 0, false)]
            public decimal Ser { get; set; }

            /// <summary>
            ///    Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(6, "SUB_SER", "C", 3, 0, false)]
            public decimal SubSer { get; set; }

            /// <summary>
            ///    Número do documento fiscal
            /// </summary>
            [SpedCampos(7, "NUM_DOC", "N", 9, 0, false)]
            public int NumDoc { get; set; }

            /// <summary>
            ///     Data da Operação (ddmmaaaa)
            /// </summary>
            [SpedCampos(8, "DT_OPER", "N", 8, 0, true)]
            public DateTime DtOPer { get; set; }

            /// <summary>
            ///   Chave da Nota Fiscal Eletrônica
            /// </summary>
            [SpedCampos(9, "CHV_NFE", "N", 44, 0, false)]
            public string ChvNfe { get; set; }

            /// <summary>
            ///   Valor da Operação
            /// </summary>
            [SpedCampos(10, "VL_OPER", "N", 0, 2, true)]
            public string VlOper { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(11, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            /// <summary>
            ///     Código da Base de Cálculo do Crédito, conforme a Tabela indicada no item 4.3.7.
            /// </summary>
            [SpedCampos(12, "NAT_BC_CRED", "C", 2, 0, true)]
            public string NatBcCred { get; set; }

            /// <summary>
            ///   Indicador da origem do crédito:
            ///   0 –Operação no Mercado Interno
            ///   1 –Operação de Importação
            /// </summary>
            [SpedCampos(13, "IND_ORIG_CRED", "C", 1, 0, true)]
            public string IndOrigCred { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao PIS/PASEP, conforme a Tabela indicada no item 4.3.3.
            /// </summary>
            [SpedCampos(14, "CST_PIS", "N", 8, 4, false)]
            public string CstPis { get; set; }

            /// <summary>
            ///  Base de Cálculo do Crédito de PIS/PASEP (em valor ou em quantidade).
            /// </summary>
            [SpedCampos(15, "VL_BC_PIS", "N", 0, 3, true)]
            public string VlBcPis { get; set; }

            /// <summary>
            ///    Alíquota do PIS/PASEP (em percentual ou em reais).
            /// </summary>
            [SpedCampos(16, "ALIQ_PIS", "N", 0, 4, true)]
            public string AliqPis { get; set; }

            /// <summary>
            ///  Valor do Crédito de PIS/PASEP.
            /// </summary>
            [SpedCampos(17, "VL_PIS", "N", 0, 2, true)]
            public string VlPis { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada.
            /// </summary>
            [SpedCampos(18, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///  Código do Centro de Custos.
            /// </summary>
            [SpedCampos(19, "COD_CCUS", "C", 255, 0, false)]
            public string CodCcus { get; set; }

            /// <summary>
            ///  Descrição complementar do Documento/Operação.
            /// </summary>
            [SpedCampos(20, "DESC_COMPL", "C", 0, 0, false)]
            public string DescCompl { get; set; }

            /// <summary>
            ///  Mês/Ano da Escrituração em que foi registrado o documento/operação (Crédito pelo método da Apropriação Direta).
            /// </summary>
            [SpedCampos(21, "PER_ESCRIT", "N", 6, 0, false)]
            public string PerEscrit { get; set; }

            /// <summary>
            ///    CNPJ do estabelecimento gerador do crédito extemporâneo (Campo 04  do Registro 0140)
            /// </summary>
            [SpedCampos(22, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }


            public List<Registro1102> Reg1102s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1102:  Detalhamento do Crédito Extemporaneo Vinculado a Mais de Um Tipo de Receita –PIS/Pasep
        /// </summary>
        public class Registro1102 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1102"/>
            /// </summary>
            public Registro1102()
            {
                Reg = "1102";
            }

            /// <summary>
            ///    Parcela  do  Crédito  de  PIS/PASEP,  vinculada  a Receita Tributada no Mercado Interno
            /// </summary>
            [SpedCampos(2, "VL_CRED_PIS_TRIB_MI", "N", 0, 2, false)]
            public string VlCredPisTribMi { get; set; }

            /// <summary>
            ///    Parcela  do  Crédito  de  PIS/PASEP,  vinculada  a Receita Não Tributada no Mercado Interno
            /// </summary>
            [SpedCampos(3, "VL_CRED_PIS_NT_MI", "N", 0, 2, false)]
            public string VlCredPisNtMi { get; set; }

            /// <summary>
            ///    Parcela  do  Crédito  de  PIS/PASEP,  vinculada  a Receita de Exportação
            /// </summary>
            [SpedCampos(4, "VL_CRED_PIS_ EXP", "N", 0, 2, false)]
            public decimal VlCredPisExp { get; set; }

        }

        /// <summary>
        ///     REGISTRO 1200: Contribuição Social Extemporânea –PIS/Pasep
        /// </summary>
        public class Registro1200 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1200"/>
            /// </summary>
            public Registro1200()
            {
                Reg = "1200";
            }

            /// <summary>
            ///    Período de Apuração da Contribuição Social Extemporânea (MMAAAA).
            /// </summary>
            [SpedCampos(2, "PER_APUR_ANT", "N", 6, 0, true)]
            public string PerApurAnt { get; set; }

            /// <summary>
            ///    Natureza da Contribuição a Recolher, conforme Tabela 4.3.5.
            /// </summary>
            [SpedCampos(3, "NAT_CONT_REC", "C", 2, 0, true)]
            public string NatContRec { get; set; }

            /// <summary>
            ///    Valor da Contribuição Apurada.
            /// </summary>
            [SpedCampos(4, "VL_CONT_APUR", "N", 0, 2, true)]
            public decimal VlContApur { get; set; }

            /// <summary>
            ///    Valor do Crédito de PIS/PASEP a Descontar, da Contribuição Social Extemporânea.
            /// </summary>
            [SpedCampos(5, "VL_CRED_PIS_DESC", "N", 0, 2, true)]
            public decimal VlCredPisDesc { get; set; }

            /// <summary>
            ///    Valor da Contribuição Social Extemporânea Devida.
            /// </summary>
            [SpedCampos(6, "VL_CONT_DEV", "N", 0, 2, true)]
            public decimal VlContDev { get; set; }

            /// <summary>
            ///    Valor de Outras Deduções.
            /// </summary>
            [SpedCampos(7, "VL_OUT_DED", "N", 0, 2, true)]
            public int VlOutDed { get; set; }

            /// <summary>
            ///     Valor da Contribuição Social Extemporânea a pagar.
            /// </summary>
            [SpedCampos(8, "VL_CONT_EXT", "N", 0, 2, true)]
            public int VlContExt { get; set; }

            /// <summary>
            ///   Valor da Multa.
            /// </summary>
            [SpedCampos(9, "VL_MUL", "N", 0, 2, false)]
            public string VlMul { get; set; }

            /// <summary>
            ///   Valor dos Juros.
            /// </summary>
            [SpedCampos(10, "VL_JUR", "N", 0, 2, false)]
            public string VlJur { get; set; }

            /// <summary>
            ///     Data do Recolhimento.
            /// </summary>
            [SpedCampos(11, "DT_RECOL", "N", 8, 0, false)]
            public DateTime DtRecolS { get; set; }

            public List<Registro1210> Reg1210s { get; set; }
            public List<Registro1220> Reg1220s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1210:  Detalhamento aa Contribuição Social Extemporânea –PIS/Pasep
        /// </summary>
        public class Registro1210 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1210"/>
            /// </summary>
            public Registro1210()
            {
                Reg = "1210";
            }

            /// <summary>
            ///    Número de inscrição do estabelecimento no CNPJ (Campo 04 do Registro 0140).
            /// </summary>
            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            /// <summary>
            ///    Código da Situação Tributária referente ao PIS/PASEP, conforme a Tabela indicada no item 4.3.3
            /// </summary>
            [SpedCampos(3, "CST_PIS", "N", 2, 0, true)]
            public string CstPis { get; set; }

            /// <summary>
            ///    Código do participante (Campo 02 do Registro 0150)
            /// </summary>
            [SpedCampos(4, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///    Data da Operação (ddmmaaaa)
            /// </summary>
            [SpedCampos(5, "DT_OPER", "N", 8, 0, true)]
            public DateTime DtOper { get; set; }

            /// <summary>
            ///    Valor da Operação/Item
            /// </summary>
            [SpedCampos(6, "VL_OPER", "N", 0, 2, true)]
            public int VlOper { get; set; }

            /// <summary>
            ///   Base de cálculo do Crédito de PIS/PASEP no período (06 –07)
            /// </summary>
            [SpedCampos(7, "VL_BC_PIS", "N", 0, 3, true)]
            public string VlBcPis { get; set; }

            /// <summary>
            ///   Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(8, "ALIQ_PIS", "N", 0, 4, true)]
            public string AliqPis { get; set; }

            /// <summary>
            ///     Valor do Crédito de PIS/PASEP
            /// </summary>
            [SpedCampos(9, "VL_PIS", "N", 0, 2, true)]
            public string VlPis { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada.
            /// </summary>
            [SpedCampos(10, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Descrição complementar do Documento/Operação
            /// </summary>
            [SpedCampos(11, "DESC_COMPL", "C", 0, 0, false)]
            public string DescCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1220: Demonstração do Crédito a Descontar a Contribuição Extemporânea –PIS/Pasep
        /// </summary>
        public class Registro1220 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1220"/>
            /// </summary>
            public Registro1220()
            {
                Reg = "1220";
            }

            /// <summary>
            ///    Período de Apuração do Crédito (MM/AAAA)
            /// </summary>
            [SpedCampos(2, "PER_APU_CRED", "N", 6, 0, true)]
            public string PerApuCred { get; set; }

            /// <summary>
            ///    Indicador da origem do crédito:01 –Crédito decorrente de operações próprias;02 –Crédito transferido por pessoa jurídica sucedida.
            /// </summary>
            [SpedCampos(3, "ORIG_CRED", "N", 2, 0, true)]
            public string OrigCred { get; set; }

            ///<summary>
            ///    Código do Tipo do Crédito, conforme Tabela 4.3.6.
            /// </summary>
            [SpedCampos(4, "COD_CRED", "N", 3, 0, true)]
            public string CodCred { get; set; }

            /// <summary>
            ///    Valor do Crédito a Descontar
            /// </summary>
            [SpedCampos(5, "VL_CRED", "N", 0, 2, true)]
            public decimal VlCred { get; set; }

        }

        /// <summary>
        ///     REGISTRO 1300: Controle dos Valores Retidos na Fonte –PIS/Pasep
        /// </summary>
        public class Registro1300 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1300"/>
            /// </summary>
            public Registro1300()
            {
                Reg = "1300";
            }

            /// <summary>
            ///    Indicador de Natureza da Retenção na Fonte até 2013:
            ///    01 -Retenção por Órgãos, Autarquias e Fundações Federais
            ///    02 -Retenção por outras Entidades da Administração Pública Federal
            ///    03 -Retenção por Pessoas Jurídicas de Direito Privado
            ///    04 -Recolhimento por Sociedade Cooperativa
            ///    05 -Retenção por Fabricante de Máquinas e Veículos
            ///    99 -Outras Retenções
            ///    Indicador de Natureza da Retenção na Fonte, a partir de 2014:
            ///    Retenção Rendimentos sujeitos ao Regime Não Cumulativo (PJ Tributada pelo Lucro Real) e ao Regime Cumulativo (PJ Tributada pelo Lucro Presumido/Arbitrado):
            ///    01 -Retenção por Órgãos, Autarquias e Fundações Federais
            ///    02 -Retenção por outras Entidades da Administração Pública Federal
            ///    03 -Retenção por Pessoas Jurídicas de Direito Privado
            ///    04 -Recolhimento por Sociedade Cooperativa
            ///    05 -Retenção por Fabricante de Máquinas e Veículos
            ///    99 -Outras Retenções -Rendimentos sujeitos à regra geral de incidência (não cumulativa ou cumulativa
            ///    Retenção Rendimentos sujeitos ao Regime Cumulativo, auferido por Pessoa Jurídica Tributada pelo Lucro Real:
            ///    51 -Retenção por Órgãos, Autarquias e Fundações Federais
            ///    52 -Retenção por outras Entidades da Administração Pública Federal
            ///    53 -Retenção por Pessoas Jurídicas de Direito Privado
            ///    54 -Recolhimento por Sociedade Cooperativa
            ///    55 -Retenção por Fabricante de Máquinas e Veículos
            ///    59 -Outras Retenções -Rendimentos sujeitos à regra específica de incidência cumulativa (art. 8º da Lei nº 10.637/2002 e art. 10 da Lei nº 10.833/2003)
            /// </summary>
            [SpedCampos(2, "IND_NAT_RET", "N", 2, 0, true)]
            public string IndNatRet { get; set; }

            /// <summary>
            ///    Período do Recebimento e da Retenção (MM/AAAA)
            /// </summary>
            [SpedCampos(3, "PR_REC_RET", "N", 6, 0, true)]
            public string PrRecRet { get; set; }

            ///<summary>
            ///    Valor Total da Retenção
            /// </summary>
            [SpedCampos(4, "VL_RET_APU", "N", 0, 2, true)]
            public decimal VlRetApu { get; set; }

            /// <summary>
            ///    Valor da Retenção deduzida da Contribuição devida no período da escrituração e em períodos anteriores.
            /// </summary>
            [SpedCampos(5, "VL_RET_DED", "N", 0, 2, true)]
            public decimal VlRetDed { get; set; }

            /// <summary>
            ///    Valor da Retenção utilizada mediante Pedido de Restituição.
            /// </summary>
            [SpedCampos(6, "VL_RET_PER", "N", 0, 2, true)]
            public decimal VlRetPer { get; set; }

            /// <summary>
            ///    Valor da Retenção utilizada mediante Declaração de Compensação.
            /// </summary>
            [SpedCampos(7, "VL_RET_DCOMP", "N", 0, 2, true)]
            public int VlRetDcompl { get; set; }

            /// <summary>
            ///     Saldo de Retenção a utilizar em períodos de apuração futuros (04 –05 -06 -07).
            /// </summary>
            [SpedCampos(8, "SLD_RET", "N", 0, 2, true)]
            public int SldRet { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1500: Controle de Créditos Fiscais –Cofins
        /// </summary>
        public class Registro1500 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1500"/>
            /// </summary>
            public Registro1500()
            {
                Reg = "1500";
            }

            /// <summary>
            ///    Período de Apuração do Crédito (MM/AAAA)
            /// </summary>
            [SpedCampos(2, "PER_APU_CRED", "N", 6, 0, true)]
            public string PerApuCred { get; set; }

            /// <summary>
            ///    Indicador da origem do crédito:
            ///    01 –Crédito decorrente de operações próprias;
            ///    02 –Crédito transferido por pessoa jurídica sucedida.
            /// </summary>
            [SpedCampos(3, "ORIG_CRED", "N", 2, 0, true)]
            public string OrigCred { get; set; }

            ///<summary>
            ///    CNPJ  da  pessoa  jurídica  cedente  do  crédito  (se ORIG_CRED = 02).
            /// </summary>
            [SpedCampos(4, "CNPJ_SUC", "N", 14, 0, false)]
            public decimal CnpjSuc { get; set; }

            /// <summary>
            ///    Código do Tipo do Crédito, conforme Tabela 4.3.6.
            /// </summary>
            [SpedCampos(5, "COD_CRED", "N", 3, 0, true)]
            public decimal CodCred { get; set; }

            /// <summary>
            ///    Valor Total  do  crédito  apurado  na  Escrituração  Fiscal Digital (Registro M500) ou em demonstrativo DACON (Fichas 16A e 16B) de período anterior.
            /// </summary>
            [SpedCampos(6, "VL_CRED_APU", "N", 0, 2, true)]
            public decimal VlCredApu { get; set; }

            /// <summary>
            ///    Valor  de  Crédito Extemporâneo  Apurado  (Registro 1501),  referente  a  Período  Anterior,  Informado  no Campo 02 –PER_APU_CRED
            /// </summary>
            [SpedCampos(7, "VL_CRED_EXT_APU", "N", 0, 2, false)]
            public int VlCredExtApu { get; set; }

            /// <summary>
            ///     Valor Total do Crédito Apurado (06 + 07)
            /// </summary>
            [SpedCampos(8, "VL_TOT_CRED_APU", "N", 0, 2, true)]
            public int VlTotCredApu { get; set; }

            /// <summary>
            ///   Valor  do  Crédito  utilizado  mediante  Desconto,  em Período(s)  Anterior(es)
            /// </summary>
            [SpedCampos(9, "VL_CRED_DESC_PA_ANT", "N", 0, 2, true)]
            public string VlCredDescPaAnt { get; set; }

            /// <summary>
            ///   Valor  do  Crédito  utilizado  mediante  Pedido  de Ressarcimento, em Período(s) Anterior(es).
            /// </summary>
            [SpedCampos(10, "VL_CRED_PER_PA_ANT", "N", 0, 2, false)]
            public string VlCredPerPaAnt { get; set; }

            /// <summary>
            ///     Valor  do  Crédito utilizado  mediante  Declaração  de Compensação Intermediária (Crédito de Exportação), em Período(s) Anterior(es)
            /// </summary>
            [SpedCampos(11, "VL_CRED_DCOMP_PA_ANT", "N", 0, 2, false)]
            public string VlCredDcompPaAnt { get; set; }

            /// <summary>
            ///     Saldo  do  Crédito  Disponível  para  Utilização  neste Período de Escrituração (08-09-10-11)
            /// </summary>
            [SpedCampos(12, "SD_CRED_DISP_EFD", "N", 0, 2, true)]
            public string SdCredDispEfd { get; set; }

            /// <summary>
            ///   Valor  do  Crédito  descontado  neste  período  de escrituração
            /// </summary>
            [SpedCampos(13, "VL_CRED_DESC_EFD", "N", 0, 2, false)]
            public string VlCredDescEfd { get; set; }

            /// <summary>
            ///     Valor  do  Crédito  objeto  de  Pedido  de  Ressarcimento (PER) neste período de escrituração
            /// </summary>
            [SpedCampos(14, "VL_CRED_PER_EFD", "N", 0, 2, false)]
            public string VlCredPerEfd { get; set; }

            /// <summary>
            ///  Valor  do  Crédito utilizado  mediante  Declaração  de Compensação   Intermediária   neste   período   de escrituração
            /// </summary>
            [SpedCampos(15, "VL_CRED_DCOMP_EFD", "N", 0, 2, false)]
            public string VlCredDcompEfd { get; set; }

            /// <summary>
            ///    Valor do crédito transferido em evento de cisão, fusão ou incorporação
            /// </summary>
            [SpedCampos(16, "VL_CRED_TRANS", "N", 0, 2, false)]
            public string VlCredTrans { get; set; }

            /// <summary>
            ///  Valor do crédito utilizado por outras formas
            /// </summary>
            [SpedCampos(17, "VL_CRED_OUT", "N", 0, 2, false)]
            public string VlBcPisSusp { get; set; }

            /// <summary>
            ///    Saldo  de  créditos  a  utilizar  em  período  de  apuração futuro (12-13-14-15-16-17)
            /// </summary>
            [SpedCampos(18, "SLD_CRED_FIM", "N", 0, 2, true)]
            public string SldCredFim { get; set; }

            public List<Registro1501> Reg1501s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1501:  Apuração  de  Crédito  Extemporâneo -Documentos  e  Operações  de  Períodos Anteriores –Cofins
        /// </summary>
        public class Registro1501 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1501"/>
            /// </summary>
            public Registro1501()
            {
                Reg = "1501";
            }

            /// <summary>
            ///    Código do participante (Campo 02 do Registro 0150)
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///    Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            /// <summary>
            ///    Código do modelo do documento fiscal, conforme a Tabela 4.1.1.
            /// </summary>
            [SpedCampos(4, "COD_MOD", "C", 2, 0, false)]
            public decimal CodMod { get; set; }

            /// <summary>
            ///    Série do documento fiscal
            /// </summary>
            [SpedCampos(5, "SER", "C", 4, 0, false)]
            public decimal Ser { get; set; }

            /// <summary>
            ///    Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(6, "SUB_SER", "C", 3, 0, false)]
            public decimal SubSer { get; set; }

            /// <summary>
            ///    Número do documento fiscal
            /// </summary>
            [SpedCampos(7, "NUM_DOC", "N", 9, 0, false)]
            public int NumDoc { get; set; }

            /// <summary>
            ///     Data da Operação (ddmmaaaa)
            /// </summary>
            [SpedCampos(8, "DT_OPER", "N", 8, 0, true)]
            public DateTime DtOPer { get; set; }

            /// <summary>
            ///   Chave da Nota Fiscal Eletrônica
            /// </summary>
            [SpedCampos(9, "CHV_NFE", "N", 44, 0, false)]
            public string ChvNfe { get; set; }

            /// <summary>
            ///   Valor da Operação
            /// </summary>
            [SpedCampos(10, "VL_OPER", "N", 0, 2, true)]
            public string VlOper { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(11, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            /// <summary>
            ///     Código da Base de Cálculo do Crédito, conforme a Tabela indicada no item 4.3.7.
            /// </summary>
            [SpedCampos(12, "NAT_BC_CRED", "C", 2, 0, true)]
            public string NatBcCred { get; set; }

            /// <summary>
            ///   Indicador da origem do crédito:
            ///   0 –Operação no Mercado Interno
            ///   1 –Operação de Importação
            /// </summary>
            [SpedCampos(13, "IND_ORIG_CRED", "C", 1, 0, true)]
            public string IndOrigCred { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente a COFINS, conforme a Tabela indicada no item 4.3.4.
            /// </summary>
            [SpedCampos(14, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

            /// <summary>
            ///   Base de Cálculo do Crédito da COFINS no período (06 –07)
            /// </summary>
            [SpedCampos(15, "VL_BC_COFINS", "N", 0, 3, true)]
            public string VlBcCofins { get; set; }

            /// <summary>
            ///     Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(16, "ALIQ_COFINS", "N", 0, 4, true)]
            public string AliqCofins { get; set; }

            /// <summary>
            ///   Valor do crédito da COFINS
            /// </summary>
            [SpedCampos(17, "VL_COFINS", "N", 0, 2, true)]
            public string VlCofins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada.
            /// </summary>
            [SpedCampos(18, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///  Código do Centro de Custos.
            /// </summary>
            [SpedCampos(19, "COD_CCUS", "C", 255, 0, false)]
            public string CodCcus { get; set; }

            /// <summary>
            ///  Descrição complementar do Documento/Operação.
            /// </summary>
            [SpedCampos(20, "DESC_COMPL", "C", 0, 0, false)]
            public string DescCompl { get; set; }

            /// <summary>
            ///  Mês/Ano da Escrituração em que foi registrado o documento/operação (Crédito pelo método da Apropriação Direta).
            /// </summary>
            [SpedCampos(21, "PER_ESCRIT", "N", 6, 0, false)]
            public string PerEscrit { get; set; }

            /// <summary>
            ///    CNPJ do estabelecimento gerador do crédito extemporâneo (Campo 04  do Registro 0140)
            /// </summary>
            [SpedCampos(22, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            public List<Registro1502> Reg1502s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1502:Detalhamento do Crédito Extemporâneo Vinculado a Mais de Um Tipo de Receita –Cofins 
        /// </summary>
        public class Registro1502 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1502"/>
            /// </summary>
            public Registro1502()
            {
                Reg = "1502";
            }

            /// <summary>
            ///    Parcela  do  Crédito  de  COFINS,  vinculada  a Receita Tributada no Mercado Interno
            /// </summary>
            [SpedCampos(2, "VL_CRED_COFINS_TRIB_MI", "N", 0, 2, false)]
            public string VlCredCofinsTribMi { get; set; }

            /// <summary>
            ///    Parcela  do  Crédito  de  COFINS,  vinculada  a Receita Não Tributada no Mercado Interno
            /// </summary>
            [SpedCampos(3, "VL_CRED_COFINS_NT_MI", "N", 0, 2, false)]
            public string VlCredCofinsNtMi { get; set; }

            /// <summary>
            ///    Parcela  do  Crédito  de  COFINS,  vinculada  a Receita de Exportação
            /// </summary>
            [SpedCampos(4, "VL_CRED_COFINS_ EXP", "N", 0, 2, false)]
            public decimal VlCredCofinsExp { get; set; }

        }

        /// <summary>
        ///     REGISTRO 1600: Contribuição Social Extemporânea –Cofins
        /// </summary>
        public class Registro1600 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1600"/>
            /// </summary>
            public Registro1600()
            {
                Reg = "1600";
            }

            /// <summary>
            ///    Período de Apuração da Contribuição Social Extemporânea (MMAAAA).
            /// </summary>
            [SpedCampos(2, "PER_APUR_ANT", "N", 6, 0, true)]
            public string PerApurAnt { get; set; }

            /// <summary>
            ///    Natureza da Contribuição a Recolher, conforme Tabela 4.3.5.
            /// </summary>
            [SpedCampos(3, "NAT_CONT_REC", "C", 2, 0, true)]
            public string NatContRec { get; set; }

            /// <summary>
            ///    Valor da Contribuição Apurada.
            /// </summary>
            [SpedCampos(4, "VL_CONT_APUR", "N", 0, 2, true)]
            public decimal VlContApur { get; set; }

            /// <summary>
            ///    Valor do Crédito de COFINS a Descontar, da Contribuição Social Extemporânea.
            /// </summary>
            [SpedCampos(5, "VL_CRED_COFINS_DESC", "N", 0, 2, true)]
            public decimal VlCredPisDesc { get; set; }

            /// <summary>
            ///    Valor da Contribuição Social Extemporânea Devida.
            /// </summary>
            [SpedCampos(6, "VL_CONT_DEV", "N", 0, 2, true)]
            public decimal VlContDev { get; set; }

            /// <summary>
            ///    Valor de Outras Deduções.
            /// </summary>
            [SpedCampos(7, "VL_OUT_DED", "N", 0, 2, true)]
            public int VlOutDed { get; set; }

            /// <summary>
            ///     Valor da Contribuição Social Extemporânea a pagar.
            /// </summary>
            [SpedCampos(8, "VL_CONT_EXT", "N", 0, 2, true)]
            public int VlContExt { get; set; }

            /// <summary>
            ///   Valor da Multa.
            /// </summary>
            [SpedCampos(9, "VL_MUL", "N", 0, 2, false)]
            public string VlMul { get; set; }

            /// <summary>
            ///   Valor dos Juros.
            /// </summary>
            [SpedCampos(10, "VL_JUR", "N", 0, 2, false)]
            public string VlJur { get; set; }

            /// <summary>
            ///     Data do Recolhimento.
            /// </summary>
            [SpedCampos(11, "DT_RECOL", "N", 8, 0, false)]
            public DateTime DtRecolS { get; set; }

            public List<Registro1610> Reg1610s { get; set; }
            public List<Registro1620> Reg1620s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1610: Detalhamento da Contribuição Social Extemporânea –Cofins
        /// </summary>
        public class Registro1610 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1610"/>
            /// </summary>
            public Registro1610()
            {
                Reg = "1610";
            }

            /// <summary>
            ///    CNPJ do estabelecimento gerador do crédito extemporâneo (Campo 04  do Registro 0140)
            /// </summary>
            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente a COFINS, conforme a Tabela indicada no item 4.3.4.
            /// </summary>
            [SpedCampos(3, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

            /// <summary>
            ///    Código do participante (Campo 02 do Registro 0150)
            /// </summary>
            [SpedCampos(4, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Data da Operação (ddmmaaaa)
            /// </summary>
            [SpedCampos(5, "DT_OPER", "N", 8, 0, true)]
            public DateTime DtOPer { get; set; }

            /// <summary>
            ///   Valor da Operação
            /// </summary>
            [SpedCampos(6, "VL_OPER", "N", 0, 2, true)]
            public string VlOper { get; set; }

            /// <summary>
            ///   Base de Cálculo do Crédito da COFINS no período (06 –07)
            /// </summary>
            [SpedCampos(7, "VL_BC_COFINS", "N", 0, 3, true)]
            public string VlBcCofins { get; set; }

            /// <summary>
            ///     Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(8, "ALIQ_COFINS", "N", 0, 4, true)]
            public string AliqCofins { get; set; }

            /// <summary>
            ///   Valor do crédito da COFINS
            /// </summary>
            [SpedCampos(9, "VL_COFINS", "N", 0, 2, true)]
            public string VlCofins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada.
            /// </summary>
            [SpedCampos(10, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///  Descrição complementar do Documento/Operação.
            /// </summary>
            [SpedCampos(11, "DESC_COMPL", "C", 0, 0, false)]
            public string DescCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1620: Demonstração do Crédito a Descontar da Contribuição Extemporânea –Cofins
        /// </summary>
        public class Registro1620 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1620"/>
            /// </summary>
            public Registro1620()
            {
                Reg = "1620";
            }

            /// <summary>
            ///    Período de Apuração do Crédito (MM/AAAA)
            /// </summary>
            [SpedCampos(2, "PER_APU_CRED", "N", 6, 0, true)]
            public string PerApuCred { get; set; }

            /// <summary>
            ///    Indicador da origem do crédito:
            ///    01 –Crédito decorrente de operações próprias;
            ///    02 –Crédito transferido por pessoa jurídica sucedida
            /// </summary>
            [SpedCampos(3, "ORIG_CRED", "N", 2, 0, true)]
            public string OrigCred { get; set; }

            /// <summary>
            ///    Código do Tipo do Crédito, conforme Tabela 4.3.6.
            /// </summary>
            [SpedCampos(4, "COD_CRED", "N", 3, 0, true)]
            public decimal CodCred { get; set; }

            /// <summary>
            ///    Valor do Crédito a Descontar
            /// </summary>
            [SpedCampos(5, "VL_CRED", "N", 0, 2, true)]
            public decimal VlCred { get; set; }

        }

        /// <summary>
        ///     REGISTRO 1700: Controle dos Valores Retidos na Fonte –Cofins
        /// </summary>
        public class Registro1700 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1700"/>
            /// </summary>
            public Registro1700()
            {
                Reg = "1700";
            }

            /// <summary>
            ///    Indicador de Natureza da Retenção na Fonte até 2013:
            ///    01 -Retenção por Órgãos, Autarquias e Fundações Federais
            ///    02 -Retenção por outras Entidades da Administração Pública Federal
            ///    03 -Retenção por Pessoas Jurídicas de Direito Privado
            ///    04 -Recolhimento por Sociedade Cooperativa
            ///    05 -Retenção por Fabricante de Máquinas e Veículos
            ///    99 -Outras Retenções
            ///    Indicador de Natureza da Retenção na Fonte, a partir de 2014:
            ///    Retenção Rendimentos sujeitos ao Regime Não Cumulativo (PJ Tributada pelo Lucro Real) e ao Regime Cumulativo (PJ Tributada pelo Lucro Presumido/Arbitrado):
            ///    01 -Retenção por Órgãos, Autarquias e Fundações Federais
            ///    02 -Retenção por outras Entidades da Administração Pública Federal
            ///    03 -Retenção por Pessoas Jurídicas de Direito Privado
            ///    04 -Recolhimento por Sociedade Cooperativa
            ///    05 -Retenção por Fabricante de Máquinas e Veículos
            ///    99 -Outras Retenções -Rendimentos sujeitos à regra geral de incidência (não cumulativa ou cumulativa
            ///    Retenção Rendimentos sujeitos ao Regime Cumulativo, auferido por Pessoa Jurídica Tributada pelo Lucro Real:
            ///    51 -Retenção por Órgãos, Autarquias e Fundações Federais
            ///    52 -Retenção por outras Entidades da Administração Pública Federal
            ///    53 -Retenção por Pessoas Jurídicas de Direito Privado
            ///    54 -Recolhimento por Sociedade Cooperativa
            ///    55 -Retenção por Fabricante de Máquinas e Veículos
            ///    59 -Outras Retenções -Rendimentos sujeitos à regra específica de incidência cumulativa (art. 8º da Lei nº 10.637/2002 e art. 10 da Lei nº 10.833/2003)
            /// </summary>
            [SpedCampos(2, "IND_NAT_RET", "N", 2, 0, true)]
            public string IndNatRet { get; set; }

            /// <summary>
            ///    Período do Recebimento e da Retenção (MM/AAAA)
            /// </summary>
            [SpedCampos(3, "PR_REC_RET", "N", 6, 0, true)]
            public string PrRecRet { get; set; }

            ///<summary>
            ///    Valor Total da Retenção
            /// </summary>
            [SpedCampos(4, "VL_RET_APU", "N", 0, 2, true)]
            public decimal VlRetApu { get; set; }

            /// <summary>
            ///    Valor da Retenção deduzida da Contribuição devida no período da escrituração e em períodos anteriores.
            /// </summary>
            [SpedCampos(5, "VL_RET_DED", "N", 0, 2, true)]
            public decimal VlRetDed { get; set; }

            /// <summary>
            ///    Valor da Retenção utilizada mediante Pedido de Restituição.
            /// </summary>
            [SpedCampos(6, "VL_RET_PER", "N", 0, 2, true)]
            public decimal VlRetPer { get; set; }

            /// <summary>
            ///    Valor da Retenção utilizada mediante Declaração de Compensação.
            /// </summary>
            [SpedCampos(7, "VL_RET_DCOMP", "N", 0, 2, true)]
            public int VlRetDcompl { get; set; }

            /// <summary>
            ///     Saldo de Retenção a utilizar em períodos de apuração futuros (04 –05 -06 -07).
            /// </summary>
            [SpedCampos(8, "SLD_RET", "N", 0, 2, true)]
            public int SldRet { get; set; }
        }

        /// <summary>
        /// REGISTRO 1800: INCORPORAÇÃO IMOBILIÁRIA - RET
        /// </summary>
        /// <remarks>
        /// Este registro dever ser preenchido pela pessoa jurídica que executa empreendimentos objeto de incorporação <para/>
        /// imobiliária e que apuram contribuição social com base em Regimes Especiais de Tributação - RET. As normas <para/>
        /// relativas ao RET, nas modalidades previstas na legislação tributária, encontram-se dispostas na Instrução <para/>
        /// Normativa RFB nº 1.435/2013.
        /// </remarks>
        public class Registro1800 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1800" />.
            /// </summary>
            public Registro1800()
            {
                Reg = "1800";
            }

            /// <summary>
            /// Empreendimento objeto de Incorporação Imobiliária, optante pelo RET <para/>
            /// </summary>
            /// <example>
            /// Exemplo de preechimento
            /// <code>
            /// reg1800.IncImob = "Empreendimento XYZ [11222333456789]"
            /// </code>
            /// </example>
            /// <remarks>
            /// Preenchimento: identifique o empreendimento objeto de incorporação imobiliária, optante pelo RET, <para/>
            /// informando o respectivo CNPJ do empreendimento, de acordo com o inciso XIII do art. 4º da IN RFB nº 1.634, <para/>
            /// de 2016, no formato "XXXXXXXXYYYYZZ"
            /// </remarks>
            [SpedCampos(2, "INC_IMOB", "C", 90, 0, true)]
            public string IncImob { get; set; }

            /// <summary>
            /// Receitas recebidas pela incorporadora na venda das unidades imobiliárias que compõem a incorporação
            /// </summary>
            [SpedCampos(3, "REC_RECEB_RET", "N", Int16.MaxValue, 2, true)]
            public decimal RecRecebRet { get; set; }

            /// <summary>
            /// Receitas Financeiras e Variações Monetárias decorrentes das vendas submentidas ao RET
            /// </summary>
            [SpedCampos(4, "REC_FIN_RET", "N", Int16.MaxValue, 2, false)]
            public decimal? RecFinRet { get; set; }

            /// <summary>
            /// Base de Cálculo do Recolhimento Unificado
            /// </summary>
            [SpedCampos(5, "BC_RET", "N", Int16.MaxValue, 2, true)]
            public decimal BcRet { get; set; }

            /// <summary>
            /// Alíquota do Recolhimento Unificado
            /// </summary>
            [SpedCampos(6, "ALIQ_RET", "N", 6, 2, true)]
            public decimal AliqRet { get; set; }

            /// <summary>
            /// Valor do Recolhimento Unificado
            /// </summary>
            [SpedCampos(7, "VL_REC_UNI", "N", Int16.MaxValue, 2, true)]
            public decimal VlRecUni { get; set; }

            /// <summary>
            /// Data do Recolhimento Unificado
            /// </summary>
            [SpedCampos(8, "DT_REC_UNI", "N", 8, 0, false)]
            public DateTime? DtRecUni { get; set; }

            /// <summary>
            /// Código da Receita
            /// </summary>
            [SpedCampos(9, "COD_REC", "C", 4, 0, false)]
            public string CodRec { get; set; }

            public List<Registro1809> Reg1809s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1809:Processo Referenciado 
        /// </summary>
        public class Registro1809 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="Registro1809"/>
            /// </summary>
            public Registro1809()
            {
                Reg = "1809";
            }

            /// <summary>
            ///     Identificação do processo ou ato concessório
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 20, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///    Indicador da origem do processo:
            ///    1 -Justiça Federal;
            ///    3 –Secretaria da Receita Federal do Brasil;
            ///    9 –Outros
            /// </summary>
            [SpedCampos(3, "IND_PROC", "C", 1, 0, true)]
            public string IndProc { get; set; }

        }

        public class Registro1900 : RegistroBaseSped
        {
            public Registro1900()
            {
                Reg = "1900";
            }

            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            [SpedCampos(3, "COD_MOD", "C", 2, 0, true)]
            public int CodMod { get; set; }

            [SpedCampos(4, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            [SpedCampos(5, "SUB_SER", "C", 4, 0, false)]
            public string SubSer { get; set; }

            [SpedCampos(6, "COD_SIT", "N", 2, 0, false)]
            public int CodSit { get; set; }

            [SpedCampos(7, "VL_TOT_REC", "N", 0, 2, true)]
            public decimal VlTotRec { get; set; }

            [SpedCampos(8, "QUANT_DOC", "N", 2, 0, false)]
            public int QuantDoc { get; set; }

            [SpedCampos(9, "CST_PIS", "N", 2, 0, false)]
            public int CstPis { get; set; }

            [SpedCampos(10, "CST_COFINS", "N", 2, 0, false)]
            public int CstCofins { get; set; }

            [SpedCampos(11, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            [SpedCampos(12, "INF_COMPL", "C", 0, 0, false)]
            public string InfCompl { get; set; }

            [SpedCampos(13, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class Registro1990 : RegistroBaseSped
        {
            public Registro1990()
            {
                Reg = "1990";
            }

            [SpedCampos(2, "QTD_LIN_1", "N", int.MaxValue, 0, true)]
            public int QtdLin1 { get; set; }
        }
    }
}
