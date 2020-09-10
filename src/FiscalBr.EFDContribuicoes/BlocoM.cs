using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.EFDContribuicoes
{
    public class BlocoM
    {
        public class RegistroM001 : RegistroBaseSped
        {
            public RegistroM001()
            {
                Reg = "M001";
            }

            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }
        }

        /// <summary>
        ///     REGISTRO M100: CRÉDITO DE PIS/PASEP RELATIVO AO PERIODO
        /// </summary>
        public class RegistroM100 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM100"/>
            /// </summary>
            public RegistroM100()
            {
                Reg = "M100";
            }

            /// <summary>
            ///     Código de Tipo de C´redito apurado no período, conforme a Tabela 4.3.6
            /// </summary>
            [SpedCampos(2, "COD_CRED", "C", 3, 0, true)]
            public string CodCred { get; set; }

            /// <summary>
            ///     Indicador de Crédito Oriundo de:
            ///     0- Operações próprias
            ///     1- Evento de incorporação, cisão ou fusão
            /// </summary>
            [SpedCampos(3, "IND_CRED_ORI", "N", 1, 0, true)]
            public int IndCredOri { get; set; }

            /// <summary>
            ///     Valor da base de Cálculo do Crédito
            /// </summary>
            [SpedCampos(4, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(5, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal? AliqPis { get; set; }

            /// <summary>
            ///     Quantidade - Base de cálculo do PIS
            /// </summary>
            [SpedCampos(6, "QUANT_BC_PIS", "N", 0, 3, false)]
            public decimal? QuantBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS (em reais)
            /// </summary>
            [SpedCampos(7, "ALI_PIS_QUANT", "N", 0, 4, false)]
            public decimal? AliqPisQuant { get; set; }

            /// <summary>
            ///     Valor total do crédito apurado no período
            /// </summary>
            [SpedCampos(8, "VL_CRED", "N", 0, 2, true)]
            public decimal VlCred { get; set; }

            /// <summary>
            ///     Valor total dos ajustes de acréscimo
            /// </summary>
            [SpedCampos(9, "VL_AJUS_ACRES", "N", 0, 2, true)]
            public decimal VlAjusAcres { get; set; }

            /// <summary>
            ///     Valor total dos ajustes de redução
            /// </summary>
            [SpedCampos(10, "VL_AJUS_REDUC", "N", 0, 2, true)]
            public decimal VlAjusReduc { get; set; }

            /// <summary>
            ///     Valor total do crédito diferido no período
            /// </summary>
            [SpedCampos(11, "VL_CRED_DIF", "N", 0, 2, true)]
            public decimal VlCredDif { get; set; }

            /// <summary>
            ///     Valor Total do Crédito Disponível relativo ao Período (08  09 – 10 – 11)
            /// </summary>
            [SpedCampos(12, "VL_CRED_DISP", "N", 0, 2, true)]
            public decimal VlCredDisp { get; set; }

            /// <summary>
            ///     Indicador de opção de utilização do crédito disponível no período: 
            ///     0 – Utilização do valor total para desconto da 
            ///     contribuição apurada no período, no Registro M200; 
            ///     1 – Utilização de valor parcial para desconto da 
            ///     contribuição apurada no período, no Registro M200. 
            /// </summary>
            [SpedCampos(13, "IND_DESC_CRED", "C", 1, 0, true)]
            public int IndDescCred { get; set; }

            /// <summary>
            ///     Valor do Crédito disponível, descontado  da contribuição
            ///     apurada no próprio período.
            ///     Se IND_DESC_CRED=0, informar o valor total do Campo 12;
            ///     Se IND_DESC_CRED=1, informar o valor parcial do Campo 12
            /// </summary>
            [SpedCampos(14, "VL_CRED_DESC", "N", 0, 2, false)]
            public decimal? VlCredDesc { get; set; }

            /// <summary>
            ///     Saldo de créditos a utilizar em períodos futuros (12 – 14)
            /// </summary>
            [SpedCampos(15, "VL_CRED_DESC", "N", 0, 2, true)]
            public decimal SldCred { get; set; }
        }

        /// <summary>
        ///     REGISTRO M105: DETALHAMENTO DA BASE DE CALCULO DO CRÉDITO APURADO NO PERÍODO – PIS/PASEP
        /// </summary>
        public class RegistroM105 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM105"/>.
            /// </summary>
            public RegistroM105()
            {
                Reg = "M105";
            }

            /// <summary>
            ///     Código da Base de Cálculo do Crédito apurado no período, conforme a Tabela 4.3.7. 
            /// </summary>
            [SpedCampos(2, "NAT_BC_CRED", "C", 2, 0, true)]
            public string NatBcCred { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao crédito de PIS/Pasep (Tabela 4.3.3) 
            ///     vinculado ao tipo de crédito escriturado em M100
            /// </summary>
            [SpedCampos(3, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor Total da Base de Cálculo escriturada nos documentos e operações (Blocos "A", "C", "D", e "F"), 
            ///     referente ao CST_PIS informado no Campo 03.
            /// </summary>
            [SpedCampos(4, "VL_BC_PIS_TOT", "N", 0, 2, false)]
            public decimal? VlBcPisTot { get; set; }

            /// <summary>
            ///     Parcela do Valor Total da Base de Cálculo informada no Campo 04, 
            ///     vinculada a receitas com incidência cumulativa. 
            ///     Campo de preenchimento específico para a pessoa jurídica sujeita 
            ///     ao regime cumulativo e não-cumulativo da contribuição 
            ///     (COD_INC_TRIB = 3 do Registro 0110) 
            /// </summary>
            [SpedCampos(5, "VL_BC_PIS_CUM", "N", 0, 2, false)]
            public decimal? VlBcPisCum { get; set; }

            /// <summary>
            ///     Valor Total da Base de Cálculo do Crédito, 
            ///     vinculada a receitas com incidência não-cumulativa (Campo 04 – Campo 05)
            /// </summary>
            [SpedCampos(6, "VL_BC_PIS_NC", "N", 0, 2, false)]
            public decimal? VlBcPisNc { get; set; }

            /// <summary>
            ///     Valor da Base de Cálculo do Crédito, vinculada ao tipo de Crédito escriturado em M100. 
            ///     - Para os CST_PIS = "50", "51", "52", "60", "61" e "62": Informar o valor do Campo 06 (VL_BC_PIS_NC); 
            ///     - Para os CST_PIS = "53", "54", "55", "56", "63", "64" "65" e "66" 
            ///       (Crédito sobre operações vinculadas a mais de um tipo de receita): 
            ///       Informar a parcela do valor do Campo 06 (VL_BC_PIS_NC) vinculada especificamente ao tipo 
            ///       de crédito escriturado em M100. 
            ///
            ///       O valor deste campo será transportado para o Campo 04 (VL_BC_PIS) do registro M100.
            /// </summary>
            [SpedCampos(7, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            /// <summary>
            ///     Quantidade Total da Base de Cálculo do Crédito apurado em Unidade de Medida de Produto, 
            ///     escriturada nos documentos e operações (Blocos "A", "C", "D" e "F"), 
            ///     referente ao CST_PIS informado no Campo 03 
            /// </summary>
            [SpedCampos(8, "QUANT_BC_PIS_TOT", "N", 0, 3, false)]
            public decimal? QuantBcPisTot { get; set; }

            /// <summary>
            ///     Parcela da base de cálculo do crédito em quantidade (campo 08) 
            ///     vinculada ao tipo de crédito escriturado em M100. 
            ///     - Para os CST_PIS = "50", “51" e "52": Informar o valor do Campo 08 (QUANT_BC_PIS); 
            ///     - Para os CST_PIS = "53", “54", "55" e "56" (crédito vinculado a mais de um tipo de receita): 
            ///     Informar a parcela do valor do Campo 08 (QUANT_BC_PIS) vinculada 
            ///     ao tipo de crédito escriturado em M100. 
            ///
            ///O valor deste campo será transportado para o Campo 06 (QUANT_BC_PIS) do registro M100.
            /// </summary>
            [SpedCampos(9, "QUANT_BC_PIS", "N", 0, 3, false)]
            public decimal? QuantBcPis { get; set; }

            /// <summary>
            ///     Descrição do crédito
            /// </summary>
            [SpedCampos(10, "DESC_CRED", "C", 60, 0, false)]
            public string DescCred { get; set; }
        }

        /// <summary>
        ///     REGISTRO M110: AJUSTES DO CRÉDITO DE PIS/PASEP APURADO
        /// </summary>
        public class RegistroM110 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM110" />.
            /// </summary>
            public RegistroM110()
            {
                Reg = "M110";
            }

            /// <summary>
            ///     Indicador do tipo de ajuste: 
            ///     0 - Ajuste de redução; 
            ///     1 - Ajuste de acréscimo
            /// </summary>
            [SpedCampos(2, "IND_AJ", "C", 1, 0, true)]
            public IndTipoAjuste IndAj { get; set; }

            /// <summary>
            ///     Valor do ajuste
            /// </summary>
            [SpedCampos(3, "VL_AJ", "N", int.MaxValue, 2, true)]
            public decimal VlAj { get; set; }

            /// <summary>
            ///     Código do ajuste, conforme a Tabela indicada no item 4.3.8.
            /// </summary>
            [SpedCampos(4, "COD_AJ", "C", 2, 0, true)]
            public string CodAj { get; set; }

            /// <summary>
            ///     Número do processo, documento ou ato concessório ao qual o ajuste está vinculado, se houver.
            /// </summary>
            [SpedCampos(5, "NUM_DOC", "C", int.MaxValue, 0, false)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Descrição resumida do ajuste.
            /// </summary>
            [SpedCampos(6, "DESCR_AJ", "C", int.MaxValue, 0, false)]
            public string DescrAj { get; set; }

            /// <summary>
            ///     Data de referência do ajuste (ddmmaaaa)
            /// </summary>
            [SpedCampos(7, "DT_REF", "N", 8, 0, false)]
            public DateTime? DtRef { get; set; }
        }

        /// <summary>
        ///     REGISTRO M115: DETALHAMENTO DOS AJUSTES DO CRÉDITO DE PIS/PASEP APURADO
        /// </summary>
        public class RegistroM115 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM115" />.
            /// </summary>
            public RegistroM115()
            {
                Reg = "M115";
            }

            /// <summary>
            ///     Detalhamento do valor do crédito reduzido ou acrescido, informado no
            ///     Campo 03 (VL_AJ) do registro M110. 
            /// </summary>
            [SpedCampos(2, "DET_VALOR_AJ", "N", 0, 2, true)]
            public decimal DetValorAj { get; set; }

            /// <summary>
            ///     Código de Situação Tributária referente à operação detalhada neste registro. 
            /// </summary>
            [SpedCampos(3, "CST_PIS", "N", 2, 0, false)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Detalhamento da base de cálculo geradora de ajuste de crédito 
            /// </summary>
            [SpedCampos(4, "DET_BC_CRED", "N", 0, 3, false)]
            public decimal? DetBcCred { get; set; }

            /// <summary>
            ///     Detalhamento da alíquota a que se refere o ajuste de crédito
            /// </summary>
            [SpedCampos(5, "DET_ALIQ", "N", 8, 4, false)]
            public decimal? DetAliq { get; set; }

            /// <summary>
            ///     Data da operação a que se refere o ajuste informado neste registro. 
            /// </summary>
            [SpedCampos(6, "DT_OPER_AJ", "N", 8, 0, true)]
            public DateTime DtOperAj { get; set; }

            /// <summary>
            ///     Descrição da(s) operação(ões) a que se refere o valor informado no 
            ///     Campo 02 (DET_VALOR_AJ)
            /// </summary>
            [SpedCampos(7, "DESC_AJ", "C", 0, 0, false)]
            public string DescAj { get; set; }

            /// <summary>
            ///     Código da conta contábil debitada/creditada 
            /// </summary>
            [SpedCampos(8, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Informação complementar
            /// </summary>
            [SpedCampos(9, "INFO_COMPL", "C", 0, 0, false)]
            public string InfoCompl { get; set; }
        }

        public class RegistroM200 : RegistroBaseSped
        {
            public RegistroM200()
            {
                Reg = "M200";
            }

            [SpedCampos(2, "VL_TOT_CONT_NC_PER", "N", 0, 2, true)]
            public decimal VlTotContNcPer { get; set; }

            [SpedCampos(3, "VL_TOT_CRED_DESC", "N", 0, 2, true)]
            public decimal VlTotCredDesc { get; set; }

            [SpedCampos(4, "VL_TOT_CRED_DESC_ANT", "N", 0, 2, true)]
            public decimal VlTotCredDescAnt { get; set; }

            [SpedCampos(5, "VL_TOT_CONT_NC_DEV", "N", 0, 2, true)]
            public decimal VlTotContNcDev { get; set; }

            [SpedCampos(6, "VL_RET_NC", "N", 0, 2, true)]
            public decimal VlRetNc { get; set; }

            [SpedCampos(7, "VL_OUT_DED_NC", "N", 0, 2, true)]
            public decimal VlOutDedNc { get; set; }

            [SpedCampos(8, "VL_CONT_NC_REC", "N", 0, 2, true)]
            public decimal VlContNcRec { get; set; }

            [SpedCampos(9, "VL_TOT_CONT_CUM_PER", "N", 0, 2, true)]
            public decimal VlTotContCumPer { get; set; }

            [SpedCampos(10, "VL_RET_CUM", "N", 0, 2, true)]
            public decimal VlRetCum { get; set; }

            [SpedCampos(11, "VL_OUT_DED_CUM", "N", 0, 2, true)]
            public decimal VlOutDedCum { get; set; }

            [SpedCampos(12, "VL_CONT_CUM_REC", "N", 0, 2, true)]
            public decimal VlContCumRec { get; set; }

            [SpedCampos(13, "VL_TOT_CONT_REC", "N", 0, 2, true)]
            public decimal VlTotContRec { get; set; }
        }

        public class RegistroM205 : RegistroBaseSped
        {
            public RegistroM205()
            {
                Reg = "M205";
            }

            [SpedCampos(2, "NUM_CAMPO", "C", 2, 0, true)]
            public int NumCampo { get; set; }

            [SpedCampos(3, "COD_REC", "C", 6, 0, true)]
            public int CodRec { get; set; }

            [SpedCampos(4, "VL_DEBITO", "N", 0, 2, true)]
            public decimal VlDebito { get; set; }
        }

        public class RegistroM210 : RegistroBaseSped
        {
            public RegistroM210()
            {
                Reg = "M210";
            }

            [SpedCampos(2, "COD_CONT", "C", 2, 0, true)]
            public int CodCont { get; set; }

            [SpedCampos(3, "VL_REC_BRT", "N", int.MaxValue, 2, true)]
            public decimal VlRecBrt { get; set; }

            [SpedCampos(4, "VL_BC_CONT", "N", int.MaxValue, 2, true)]
            public decimal VlBcCont { get; set; }

            [SpedCampos(5, "VL_AJUS_ACRES_BC_PIS", "N", int.MaxValue, 2, true)]
            public decimal VlAjusAcresBcPis { get; set; }

            [SpedCampos(6, "VL_AJUS_REDUC_BC_PIS", "N", int.MaxValue, 2, true)]
            public decimal VlAjusReducBcPis { get; set; }

            [SpedCampos(7, "VL_BC_CONT_AJUS", "N", int.MaxValue, 2, true)]
            public decimal VlBcContAjus
            {
                get
                {
                    return 
                        VlBcCont + 
                        VlAjusAcresBcPis - 
                        VlAjusReducBcPis;
                } 
            }

            [SpedCampos(8, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal? AliqPis { get; set; }

            [SpedCampos(9, "QUANT_BC_PIS", "N", int.MaxValue, 3, false)]
            public decimal? QuantBcPis { get; set; }

            [SpedCampos(10, "ALIQ_PIS_QUANT", "N", int.MaxValue, 4, false)]
            public decimal? AliqPisQuant { get; set; }

            [SpedCampos(11, "VL_CONT_APUR", "N", int.MaxValue, 2, true)]
            public decimal VlContApur { get; set; }

            [SpedCampos(12, "VL_AJUS_ACRES", "N", int.MaxValue, 2, true)]
            public decimal VlAjusAcres { get; set; }

            [SpedCampos(13, "VL_AJUS_REDUC", "N", int.MaxValue, 2, true)]
            public decimal VlAjusReduc { get; set; }

            [SpedCampos(14, "VL_CONT_DIFER", "N", int.MaxValue, 2, false)]
            public decimal? VlContDifer { get; set; }

            [SpedCampos(15, "VL_CONT_DIFER_ANT", "N", int.MaxValue, 2, false)]
            public decimal? VlContDiferAnt { get; set; }

            [SpedCampos(16, "VL_CONT_PER", "N", int.MaxValue, 2, true)]
            public decimal VlContPer
            {
                get
                {
                    return
                        VlContApur + 
                        VlAjusAcres - 
                        VlAjusReduc - 
                        VlContDifer.GetValueOrDefault() + 
                        VlContDiferAnt.GetValueOrDefault();
                }
            }
        }

        public class RegistroM220 : RegistroBaseSped
        {
            public RegistroM220()
            {
                Reg = "M220";
            }

            [SpedCampos(2, "IND_AJ", "C", 1, 0, true)]
            public IndTipoAjuste IndAj { get; set; }

            [SpedCampos(3, "VL_AJ", "N", 0, 2, true)]
            public decimal VlAj { get; set; }

            [SpedCampos(4, "COD_AJ", "C", 2, 0, true)]
            public int CodAj { get; set; }

            [SpedCampos(5, "NUM_DOC", "C", Int16.MaxValue, 0, false)]
            public string NumDoc { get; set; }

            [SpedCampos(6, "DESCR_AJ", "C", Int16.MaxValue, 0, false)]
            public string DescrAj { get; set; }

            [SpedCampos(7, "DT_REF", "N", 8, 0, false)]
            public DateTime? DtRef { get; set; }
        }

        [SpedRegistros("01/10/2015", null)]
        public class RegistroM225 : RegistroBaseSped
        {
            public RegistroM225()
            {
                Reg = "M225";
            }

            [SpedCampos(2, "DET_VALOR_AJ", "N", 0, 2, true)]
            public decimal DetValorAj { get; set; }

            [SpedCampos(3, "CST_PIS", "N", 2, 0, false)]
            public int CstPis { get; set; }

            [SpedCampos(4, "DET_BC_CRED", "N", 0, 3, false)]
            public decimal? DetBcCred { get; set; }

            [SpedCampos(5, "DET_ALIQ", "N", 8, 4, false)]
            public decimal? DetAliq { get; set; }

            [SpedCampos(6, "DT_OPER_AJ", "N", 8, 0, true)]
            public DateTime DtOperAj { get; set; }

            [SpedCampos(7, "DESC_AJ", "C", Int16.MaxValue, 0, false)]
            public string DescAj { get; set; }

            [SpedCampos(8, "COD_CTA", "C", Int16.MaxValue, 0, false)]
            public string CodCta { get; set; }

            [SpedCampos(9, "INFO_COMPL", "C", Int16.MaxValue, 0, false)]
            public string InfoCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO M300: CONTRIBUIÇÃO DE PIS/PASEP DIFERIDA EM PREIODOS ANTERIORES - 
        ///     VALORES A PAGAR NO PERÍODO
        /// </summary>
        public class RegistroM300 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classse <see cref="RegistroM300"/>
            /// </summary>
            public RegistroM300()
            {
                Reg = "M300";
            }

            /// <summary>
            ///     Código da contribuição social diferida em períodos anteriores, conforme a Tabela 4.3.5. 
            /// </summary>
            [SpedCampos(2, "COD_CONT", "C", 2, 0, true)]
            public string CodCont { get; set; }

            /// <summary>
            ///     Valor da Contribuição Apurada, diferida em períodos anteriores.
            /// </summary>
            [SpedCampos(3, "VL_CONT_APUR_DIFER", "N", int.MaxValue, 2, true)]
            public decimal VlContApurDifer { get; set; }

            /// <summary>
            ///     Natureza do Crédito Diferido, vinculado à receita tributada no mercado interno, a descontar:
            ///     01 – Crédito a Alíquota Básica; 
            ///     02 – Crédito a Alíquota Diferenciada; 
            ///     03 – Crédito a Alíquota por Unidade de Produto; 
            ///     04 – Crédito Presumido da Agroindústria. 
            /// </summary>
            [SpedCampos(4, "NAT_CRED_DESC", "C", 2, 0, false)]
            public int? NatCredDesc { get; set; }

            /// <summary>
            ///     Valor do Crédito a Descontar vinculado à contribuição diferida. 
            /// </summary>
            [SpedCampos(5, "VL_CRED_DESC_DIFER", "N", int.MaxValue, 2, false)]
            public decimal? VlCredDescDifer { get; set; }

            /// <summary>
            ///     Valor da Contribuição a Recolher, diferida em períodos anteriores (Campo 03 – Campo 05)
            /// </summary>
            [SpedCampos(6, "VL_CONT_DIFER_ANT", "N", int.MaxValue, 2, true)]
            public decimal VlContDiferAnt { get; set; }

            /// <summary>
            ///     Período de apuração da contribuição social e dos créditos diferidos (MMAAAA) 
            /// </summary>
            [SpedCampos(7, "PER_APUR", "MA", 6, 0, true)]
            public DateTime PerApur { get; set; }

            /// <summary>
            ///     Data de recebimento da receita, objeto de diferimento 
            /// </summary>
            [SpedCampos(8, "DT_RECEB", "N", 8, 0, false)]
            public DateTime? DtReceb { get; set; }

        }

        /// <summary>
        ///     REGISTRO M350: PIS/PASEP - FOLHA DE SALÁRIOS
        /// </summary>
        public class RegistroM350 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classse <see cref="RegistroM350"/>
            /// </summary>
            public RegistroM350()
            {
                Reg = "M350";
            }

            /// <summary>
            ///     Valor Total da Folha de Salários 
            /// </summary>
            [SpedCampos(2, "VL_TOT_FOL", "N", int.MaxValue, 2, true)]
            public decimal VlTotFol { get; set; }

            /// <summary>
            ///     Valor Total das Exclusões à Base de Cálculo 
            /// </summary>
            [SpedCampos(3, "VL_EXC_BC", "N", int.MaxValue, 2, true)]
            public decimal VlExcBc { get; set; }

            /// <summary>
            ///     Valor Total da Base de Cálculo 
            /// </summary>
            [SpedCampos(4, "VL_TOT_BC", "N", int.MaxValue, 2, true)]
            public decimal VlTotBc { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP – Folha de Salários
            /// </summary>
            [SpedCampos(5, "ALIQ_PIS_FOL", "N", 6, 2, true)]
            public decimal AliqPisFol { get; set; }

            /// <summary>
            ///     Valor Total da Contribuição Social sobre a Folha de Salários 
            /// </summary>
            [SpedCampos(6, "VL_TOT_CONT_FOL", "N", int.MaxValue, 2, true)]
            public decimal VlTotContFol { get; set; }
        }

        /// <summary>
        ///     REGISTRO M400: RECEITAS ISENTAS, NÃO ALCANÇADAS PELA INCIDÊNCIA DA
        ///     CONTRIBUIÇÃO, SUJEITAS A ALÍQUOTA ZERO OU DE VENDAS COM SUSPENSÃO - PIS/PASEP
        /// </summary>
        public class RegistroM400 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classse <see cref="RegistroM400"/>
            /// </summary>
            public RegistroM400()
            {
                Reg = "M400";
            }

            /// <summary>
            ///     Código de Situação Tributária – CST das demais receitas 
            ///     auferidas no período, sem incidência da contribuição, ou 
            ///     sem contribuição apurada a pagar, conforme a Tabela 4.3.3.
            /// </summary>
            [SpedCampos(2, "CST_PIS", "C", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor total da receita bruta no período. 
            /// </summary>
            [SpedCampos(3, "VL_TOT_REC", "N", 0, 2, true)]
            public decimal VlTotRec { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada.
            /// </summary>
            [SpedCampos(4, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Descrição Complementar da Natureza da Receita.
            /// </summary>
            [SpedCampos(4, "DESC_COMPL", "C", int.MaxValue, 0, false)]
            public string DescCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO M410: DETALHAMENTO DAS RECEITAS ISENTAS, NÃO ALCANÇADAS PELA 
        ///     INCIDÊNCIA DA CONTRIBUIÇÃO, SUJEITAS A ALÍQUOTA ZERO OU DE VENDAS COM
        ///     SUSPENSÃO – PIS/PASEP 
        /// </summary>
        public class RegistroM410 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM410"/>
            /// </summary>
            public RegistroM410()
            {
                Reg = "M410";
            }

            /// <summary>
            ///     Natureza da Receita, conforme relação constante nas 
            ///     Tabelas de Detalhamento da Natureza da Receita por 
            ///     Situação Tributária abaixo: 
            ///     
            ///     - Tabela 4.3.10: Produtos Sujeitos à Incidência
            ///     Monofásica da Contribuição Social – Alíquotas 
            ///     Diferenciadas(CST 04 - Revenda); 
            ///     
            ///     - Tabela 4.3.11: Produtos Sujeitos à Incidência 
            ///     Monofásica da Contribuição Social – Alíquotas por 
            ///     Unidade de Medida de Produto(CST 04 - Revenda); 
            ///     
            ///     - Tabela 4.3.12: Produtos Sujeitos à Substituição 
            ///     Tributária da Contribuição Social(CST 05 - Revenda); 
            ///     
            ///     - Tabela 4.3.13: Produtos Sujeitos à Alíquota Zero da 
            ///     Contribuição Social(CST 06); 
            ///     
            ///     - Tabela 4.3.14: Operações com Isenção da Contribuição 
            ///     Social(CST 07); 
            ///     
            ///     - Tabela 4.3.15: Operações sem Incidência da
            ///     Contribuição Social(CST 08);
            ///     
            ///     - Tabela 4.3.16: Operações com Suspensão da 
            ///     Contribuição Social (CST 09). 
            /// </summary>
            [SpedCampos(2, "NAT_REC", "C", 3, 0, true)]
            public string NatRec { get; set; }

            /// <summary>
            ///     Valor da receita bruta no período, relativo a natureza da receita (NAT_REC)
            /// </summary>
            [SpedCampos(3, "VL_REC", "N", 0, 2, true)]
            public decimal VlRec { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada.
            /// </summary>
            [SpedCampos(4, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Descrição Complementar da Natureza da Receita.
            /// </summary>
            [SpedCampos(5, "DESC_COMPL", "C", int.MaxValue, 0, false)]
            public string DescCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO M500: CRÉDITO DE COFINS RELATIVO AO PERIODO
        /// </summary>
        public class RegistroM500 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM500"/>
            /// </summary>
            public RegistroM500()
            {
                Reg = "M500";
            }

            /// <summary>
            ///     Código de Tipo de C´redito apurado no período, conforme a Tabela 4.3.6
            /// </summary>
            [SpedCampos(2, "COD_CRED", "C", 3, 0, true)]
            public string CodCred { get; set; }

            /// <summary>
            ///     Indicador de Crédito Oriundo de:
            ///     0- Operações próprias
            ///     1- Evento de incorporação, cisão ou fusão
            /// </summary>
            [SpedCampos(3, "IND_CRED_ORI", "N", 1, 0, true)]
            public int IndCredOri { get; set; }

            /// <summary>
            ///     Valor da base de Cálculo do Crédito
            /// </summary>
            [SpedCampos(4, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal? VlBcCofins { get; set; }

            /// <summary>
            ///     Alíquota do COFINS (em percentual)
            /// </summary>
            [SpedCampos(5, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal? AliqCofins { get; set; }

            /// <summary>
            ///     Quantidade - Base de cálculo do COFINS
            /// </summary>
            [SpedCampos(6, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public decimal? QuantBcCofins { get; set; }

            /// <summary>
            ///     Alíquota do Cofins (em reais)
            /// </summary>
            [SpedCampos(7, "ALI_COFINS_QUANT", "N", 0, 4, false)]
            public decimal? AliqCofinsQuant { get; set; }

            /// <summary>
            ///     Valor total do crédito apurado no período
            /// </summary>
            [SpedCampos(8, "VL_CRED", "N", 0, 2, true)]
            public decimal VlCred { get; set; }

            /// <summary>
            ///     Valor total dos ajustes de acréscimo
            /// </summary>
            [SpedCampos(9, "VL_AJUS_ACRES", "N", 0, 2, true)]
            public decimal VlAjusAcres { get; set; }

            /// <summary>
            ///     Valor total dos ajustes de redução
            /// </summary>
            [SpedCampos(10, "VL_AJUS_REDUC", "N", 0, 2, true)]
            public decimal VlAjusReduc { get; set; }

            /// <summary>
            ///     Valor total do crédito diferido no período
            /// </summary>
            [SpedCampos(11, "VL_CRED_DIFER", "N", 0, 2, true)]
            public decimal VlCredDifer { get; set; }

            /// <summary>
            ///     Valor Total do Crédito Disponível relativo ao Período (08 + 09 – 10 – 11)
            /// </summary>
            [SpedCampos(12, "VL_CRED_DISP", "N", 0, 2, true)]
            public decimal VlCredDisp { get; set; }

            /// <summary>
            ///     Indicador de opção de utilização do crédito disponível no período: 
            ///     0 – Utilização do valor total para desconto da 
            ///     contribuição apurada no período, no Registro M200; 
            ///     1 – Utilização de valor parcial para desconto da 
            ///     contribuição apurada no período, no Registro M200. 
            /// </summary>
            [SpedCampos(13, "IND_DESC_CRED", "C", 1, 0, true)]
            public int IndDescCred { get; set; }

            /// <summary>
            ///     Valor do Crédito disponível, descontado  da contribuição
            ///     apurada no próprio período.
            ///     Se IND_DESC_CRED=0, informar o valor total do Campo 12;
            ///     Se IND_DESC_CRED=1, informar o valor parcial do Campo 12
            /// </summary>
            [SpedCampos(14, "VL_CRED_DESC", "N", 0, 2, false)]
            public decimal? VlCredDesc { get; set; }

            /// <summary>
            ///     Saldo de créditos a utilizar em períodos futuros (12 – 14)
            /// </summary>
            [SpedCampos(15, "VL_CRED_DESC", "N", 0, 2, true)]
            public decimal SldCred { get; set; }
        }
        /// <summary>
        ///     REGISTRO M505: DETALHAMENTO DA BASE DE CALCULO DO CRÉDITO APURADO NO PERÍODO – COFINS
        /// </summary>
        public class RegistroM505 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM505"/>.
            /// </summary>
            public RegistroM505()
            {
                Reg = "M505";
            }

            /// <summary>
            ///     Código da Base de Cálculo do Crédito apurado no período, conforme a Tabela 4.3.7. 
            /// </summary>
            [SpedCampos(2, "NAT_BC_CRED", "C", 2, 0, true)]
            public string NatBcCred { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao crédito de COFINS (Tabela 4.3.3) 
            ///     vinculado ao tipo de crédito escriturado em M100
            /// </summary>
            [SpedCampos(3, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Valor Total da Base de Cálculo escriturada nos documentos e operações (Blocos "A", "C", "D", e "F"), 
            ///     referente ao CST_COFINS informado no Campo 03.
            /// </summary>
            [SpedCampos(4, "VL_BC_COFINS_TOT", "N", 0, 2, false)]
            public decimal? VlBcCofinsTot { get; set; }

            /// <summary>
            ///     Parcela do Valor Total da Base de Cálculo informada no Campo 04, 
            ///     vinculada a receitas com incidência cumulativa. 
            ///     Campo de preenchimento específico para a pessoa jurídica sujeita 
            ///     ao regime cumulativo e não-cumulativo da contribuição 
            ///     (COD_INC_TRIB = 3 do Registro 0110) 
            /// </summary>
            [SpedCampos(5, "VL_BC_COFINS_CUM", "N", 0, 2, false)]
            public decimal? VlBcCofinsCum { get; set; }

            /// <summary>
            ///     Valor Total da Base de Cálculo do Crédito, 
            ///     vinculada a receitas com incidência não-cumulativa (Campo 04 – Campo 05)
            /// </summary>
            [SpedCampos(6, "VL_BC_COFINS_NC", "N", 0, 2, false)]
            public decimal? VlBcCofinsNc { get; set; }

            /// <summary>
            ///     Valor da Base de Cálculo do Crédito, vinculada ao tipo de Crédito escriturado em M500. 
            ///     - Para os CST_COFINS = "50", "51", "52", "60", "61" e "62": Informar o valor do Campo 06 (VL_BC_COFINS_NC); 
            ///     - Para os CST_COFINS = "53", "54", "55", "56", "63", "64" "65" e "66" 
            ///       (Crédito sobre operações vinculadas a mais de um tipo de receita): 
            ///       Informar a parcela do valor do Campo 06 (VL_BC_COFINS_NC) vinculada especificamente ao tipo 
            ///       de crédito escriturado em M500. 
            ///       O valor deste campo será transportado para o Campo 04 (VL_BC_COFINS) do registro M500.
            /// </summary>
            [SpedCampos(7, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal? VlBcCofins { get; set; }

            /// <summary>
            ///     Quantidade Total da Base de Cálculo do Crédito apurado em Unidade de Medida de Produto, 
            ///     escriturada nos documentos e operações (Blocos "A", "C", "D" e "F"), 
            ///     referente ao CST_COFINS informado no Campo 03 
            /// </summary>
            [SpedCampos(8, "QUANT_BC_COFINS_TOT", "N", 0, 3, false)]
            public decimal? QuantBcCofinsTot { get; set; }

            /// <summary>
            ///     Parcela da base de cálculo do crédito em quantidade (campo 08) 
            ///     vinculada ao tipo de crédito escriturado em M500. 
            ///     - Para os CST_COFINS = "50", “51" e "52": Informar o valor do Campo 08 (QUANT_BC_COFINS); 
            ///     - Para os CST_COFINS = "53", “54", "55" e "56" (crédito vinculado a mais de um tipo de receita): 
            ///     Informar a parcela do valor do Campo 08 (QUANT_BC_COFINS) vinculada 
            ///     ao tipo de crédito escriturado em M500. 
            ///     O valor deste campo será transportado para o Campo 06 (QUANT_BC_COFINS) do registro M500.
            /// </summary>
            [SpedCampos(9, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public decimal? QuantBcCofins { get; set; }

            /// <summary>
            ///     Descrição do crédito
            /// </summary>
            [SpedCampos(10, "DESC_CRED", "C", 60, 0, false)]
            public string DescCred { get; set; }
        }

        /// <summary>
        ///     REGISTRO M510: AJUSTES DO CRÉDITO DE COFINS APURADO
        /// </summary>
        public class RegistroM510 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM510" />.
            /// </summary>
            public RegistroM510()
            {
                Reg = "M510";
            }

            /// <summary>
            ///     Indicador do tipo de ajuste: 
            ///     0 - Ajuste de redução; 
            ///     1 - Ajuste de acréscimo
            /// </summary>
            [SpedCampos(2, "IND_AJ", "C", 1, 0, true)]
            public IndTipoAjuste IndAj { get; set; }

            /// <summary>
            ///     Valor do ajuste
            /// </summary>
            [SpedCampos(3, "VL_AJ", "N", Int16.MaxValue, 2, true)]
            public decimal VlAj { get; set; }

            /// <summary>
            ///     Código do ajuste, conforme a Tabela indicada no item 4.3.8.
            /// </summary>
            [SpedCampos(4, "COD_AJ", "C", 2, 0, true)]
            public string CodAj { get; set; }

            /// <summary>
            ///     Número do processo, documento ou ato concessório ao qual o ajuste está vinculado, se houver.
            /// </summary>
            [SpedCampos(5, "NUM_DOC", "C", Int16.MaxValue, 0, false)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Descrição resumida do ajuste.
            /// </summary>
            [SpedCampos(6, "DESCR_AJ", "C", Int16.MaxValue, 0, false)]
            public string DescrAj { get; set; }

            /// <summary>
            ///     Data de referência do ajuste (ddmmaaaa)
            /// </summary>
            [SpedCampos(7, "DT_REF", "N", 8, 0, false)]
            public DateTime? DtRef { get; set; }
        }

        /// <summary>
        ///     REGISTRO M515: DETALHAMENTO DOS AJUSTES DO CRÉDITO DE COFINS APURADO
        /// </summary>
        public class RegistroM515 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM515" />.
            /// </summary>
            public RegistroM515()
            {
                Reg = "M515";
            }

            /// <summary>
            ///     Detalhamento do valor do crédito reduzido ou acrescido, informado no
            ///     Campo 03 (VL_AJ) do registro M110. 
            /// </summary>
            [SpedCampos(2, "DET_VALOR_AJ", "N", 0, 2, true)]
            public decimal DetValorAj { get; set; }

            /// <summary>
            ///     Código de Situação Tributária referente à operação detalhada neste registro. 
            /// </summary>
            [SpedCampos(3, "CST_COFINS", "N", 2, 0, false)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Detalhamento da base de cálculo geradora de ajuste de crédito 
            /// </summary>
            [SpedCampos(4, "DET_BC_CRED", "N", 0, 3, false)]
            public decimal? DetBcCred { get; set; }

            /// <summary>
            ///     Detalhamento da alíquota a que se refere o ajuste de crédito
            /// </summary>
            [SpedCampos(5, "DET_ALIQ", "N", 8, 4, false)]
            public decimal? DetAliq { get; set; }

            /// <summary>
            ///     Data da operação a que se refere o ajuste informado neste registro. 
            /// </summary>
            [SpedCampos(6, "DT_OPER_AJ", "N", 8, 0, true)]
            public DateTime DtOperAj { get; set; }

            /// <summary>
            ///     Descrição da(s) operação(ões) a que se refere o valor informado no 
            ///     Campo 02 (DET_VALOR_AJ)
            /// </summary>
            [SpedCampos(7, "DESC_AJ", "C", Int16.MaxValue, 0, false)]
            public string DescAj { get; set; }

            /// <summary>
            ///     Código da conta contábil debitada/creditada 
            /// </summary>
            [SpedCampos(8, "COD_CTA", "C", Int16.MaxValue, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Informação complementar
            /// </summary>
            [SpedCampos(9, "INFO_COMPL", "C", Int16.MaxValue, 0, false)]
            public string InfoCompl { get; set; }
        }


        /// <summary>
        ///     REGISTRO M600: CONSOLIDAÇÃO DA CONTRIBUIÇÃO PARA A SEGURIDADE SOCIAL - COFINS DO PERIODO
        /// </summary>
        public class RegistroM600 : RegistroBaseSped
        {
            public RegistroM600()
            {
                Reg = "M600";
            }

            [SpedCampos(2, "VL_TOT_CONT_NC_PER", "N", 0, 2, true)]
            public decimal VlTotContNcPer { get; set; }

            [SpedCampos(3, "VL_TOT_CRED_DESC", "N", 0, 2, true)]
            public decimal VlTotCredDesc { get; set; }

            [SpedCampos(4, "VL_TOT_CRED_DESC_ANT", "N", 0, 2, true)]
            public decimal VlTotCredDescAnt { get; set; }

            [SpedCampos(5, "VL_TOT_CONT_NC_DEV", "N", 0, 2, true)]
            public decimal VlTotContNcDev { get; set; }

            [SpedCampos(6, "VL_RET_NC", "N", 0, 2, true)]
            public decimal VlRetNc { get; set; }

            [SpedCampos(7, "VL_OUT_DED_NC", "N", 0, 2, true)]
            public decimal VlOutDedNc { get; set; }

            [SpedCampos(8, "VL_CONT_NC_REC", "N", 0, 2, true)]
            public decimal VlContNcRec { get; set; }

            [SpedCampos(9, "VL_TOT_CONT_CUM_PER", "N", 0, 2, true)]
            public decimal VlTotContCumPer { get; set; }

            [SpedCampos(10, "VL_RET_CUM", "N", 0, 2, true)]
            public decimal VlRetCum { get; set; }

            [SpedCampos(11, "VL_OUT_DED_CUM", "N", 0, 2, true)]
            public decimal VlOutDedCum { get; set; }

            [SpedCampos(12, "VL_CONT_CUM_REC", "N", 0, 2, true)]
            public decimal VlContCumRec { get; set; }

            [SpedCampos(13, "VL_TOT_CONT_REC", "N", 0, 2, true)]
            public decimal VlTotContRec { get; set; }
        }

        public class RegistroM605 : RegistroBaseSped
        {
            public RegistroM605()
            {
                Reg = "M605";
            }

            [SpedCampos(2, "NUM_CAMPO", "C", 2, 0, true)]
            public int NumCampo { get; set; }

            [SpedCampos(3, "COD_REC", "C", 6, 0, true)]
            public int CodRec { get; set; }

            [SpedCampos(4, "VL_DEBITO", "N", 0, 2, true)]
            public decimal VlDebito { get; set; }
        }

        public class RegistroM610 : RegistroBaseSped
        {
            public RegistroM610()
            {
                Reg = "M610";
            }

            [SpedCampos(2, "COD_CONT", "C", 2, 0, true)]
            public int CodCont { get; set; }

            [SpedCampos(3, "VL_REC_BRT", "N", 0, 2, true)]
            public decimal VlRecBrt { get; set; }

            [SpedCampos(4, "VL_BC_CONT", "N", 0, 2, true)]
            public decimal VlBcCont { get; set; }

            [SpedCampos(5, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal? AliqCofins { get; set; }

            [SpedCampos(6, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public decimal? QuantBcCofins { get; set; }

            [SpedCampos(7, "ALIQ_COFINS_QUANT", "N", 0, 4, false)]
            public decimal? AliqCofinsQuant { get; set; }

            [SpedCampos(8, "VL_CONT_APUR", "N", 0, 2, true)]
            public decimal VlContApur { get; set; }

            [SpedCampos(9, "VL_AJUS_ACRES", "N", 0, 2, true)]
            public decimal VlAjusAcres { get; set; }

            [SpedCampos(10, "VL_AJUS_REDUC", "N", 0, 2, true)]
            public decimal VlAjusReduc { get; set; }

            [SpedCampos(11, "VL_CONT_DIFER", "N", 0, 2, false)]
            public decimal? VlContDifer { get; set; }

            [SpedCampos(12, "VL_CONT_DIFER_ANT", "N", 0, 2, false)]
            public decimal? VlContDiferAnt { get; set; }

            [SpedCampos(13, "VL_CONT_PER", "N", 0, 2, true)]
            public decimal VlContPer { get; set; }
        }

        public class RegistroM620 : RegistroBaseSped
        {
            public RegistroM620()
            {
                Reg = "M620";
            }

            [SpedCampos(2, "IND_AJ", "C", 1, 0, true)]
            public IndTipoAjuste IndAj { get; set; }

            [SpedCampos(3, "VL_AJ", "N", 0, 2, true)]
            public decimal VlAj { get; set; }

            [SpedCampos(4, "COD_AJ", "C", 2, 0, true)]
            public int CodAj { get; set; }

            [SpedCampos(5, "NUM_DOC", "C", Int16.MaxValue, 0, false)]
            public string NumDoc { get; set; }

            [SpedCampos(6, "DESCR_AJ", "C", Int16.MaxValue, 0, false)]
            public string DescrAj { get; set; }

            [SpedCampos(7, "DT_REF", "N", 8, 0, false)]
            public DateTime? DtRef { get; set; }
        }

        [SpedRegistros("01/10/2015", null)]
        public class RegistroM625 : RegistroBaseSped
        {
            public RegistroM625()
            {
                Reg = "M625";
            }

            [SpedCampos(2, "DET_VALOR_AJ", "N", 0, 2, true)]
            public decimal DetValorAj { get; set; }

            [SpedCampos(3, "CST_COFINS", "N", 2, 0, false)]
            public int CstCofins { get; set; }

            [SpedCampos(4, "DET_BC_CRED", "N", 0, 3, false)]
            public decimal? DetBcCred { get; set; }

            [SpedCampos(5, "DET_ALIQ", "N", 8, 4, false)]
            public decimal? DetAliq { get; set; }

            [SpedCampos(6, "DT_OPER_AJ", "N", 8, 0, true)]
            public DateTime DtOperAj { get; set; }

            [SpedCampos(7, "DESC_AJ", "C", Int16.MaxValue, 0, false)]
            public string DescAj { get; set; }

            [SpedCampos(8, "COD_CTA", "C", Int16.MaxValue, 0, false)]
            public string CodCta { get; set; }

            [SpedCampos(9, "INFO_COMPL", "C", Int16.MaxValue, 0, false)]
            public string InfoCompl { get; set; }
        }


        /// <summary>
        ///     REGISTRO M700: CONTRIBUIÇÃO DE PIS/PASEP DIFERIDA EM PREIODOS ANTERIORES - 
        ///     VALORES A PAGAR NO PERÍODO
        /// </summary>
        public class RegistroM700 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classse <see cref="RegistroM700"/>
            /// </summary>
            public RegistroM700()
            {
                Reg = "M700";
            }

            /// <summary>
            ///     Código da contribuição social diferida em períodos anteriores, conforme a Tabela 4.3.5. 
            /// </summary>
            [SpedCampos(2, "COD_CONT", "C", 2, 0, true)]
            public string CodCont { get; set; }

            /// <summary>
            ///     Valor da Contribuição Apurada, diferida em períodos anteriores.
            /// </summary>
            [SpedCampos(3, "VL_CONT_APUR_DIFER", "N", int.MaxValue, 2, true)]
            public decimal VlContApurDifer { get; set; }

            /// <summary>
            ///     Natureza do Crédito Diferido, vinculado à receita tributada no mercado interno, a descontar:
            ///     01 – Crédito a Alíquota Básica; 
            ///     02 – Crédito a Alíquota Diferenciada; 
            ///     03 – Crédito a Alíquota por Unidade de Produto; 
            ///     04 – Crédito Presumido da Agroindústria. 
            /// </summary>
            [SpedCampos(4, "NAT_CRED_DESC", "C", 2, 0, false)]
            public int? NatCredDesc { get; set; }

            /// <summary>
            ///     Valor do Crédito a Descontar vinculado à contribuição diferida. 
            /// </summary>
            [SpedCampos(5, "VL_CRED_DESC_DIFER", "N", int.MaxValue, 2, false)]
            public decimal? VlCredDescDifer { get; set; }

            /// <summary>
            ///     Valor da Contribuição a Recolher, diferida em períodos anteriores (Campo 03 – Campo 05)
            /// </summary>
            [SpedCampos(6, "VL_CONT_DIFER_ANT", "N", int.MaxValue, 2, true)]
            public decimal VlContDiferAnt { get; set; }

            /// <summary>
            ///     Período de apuração da contribuição social e dos créditos diferidos (MMAAAA) 
            /// </summary>
            [SpedCampos(7, "PER_APUR", "MA", 6, 0, true)]
            public DateTime PerApur { get; set; }

            /// <summary>
            ///     Data de recebimento da receita, objeto de diferimento 
            /// </summary>
            [SpedCampos(8, "DT_RECEB", "N", 8, 0, false)]
            public DateTime? DtReceb { get; set; }

        }

        /// <summary>
        ///     REGISTRO M800: RECEITAS ISENTAS, NÃO ALCANÇADAS PELA INCIDÊNCIA DA 
        ///     CONTRIBUIÇÃO, SUJEITAS A ALÍQUOTA ZERO OU DE VENDAS COM SUSPENSÃO – COFINS 
        /// </summary>
        public class RegistroM800 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classse <see cref="RegistroM800"/>
            /// </summary>
            public RegistroM800()
            {
                Reg = "M800";
            }

            /// <summary>
            ///     Código de Situação Tributária – CST das demais receitas 
            ///     auferidas no período, sem incidência da contribuição, ou 
            ///     sem contribuição apurada a pagar, conforme a Tabela 4.3.3.
            /// </summary>
            [SpedCampos(2, "CST_COFINS", "C", 2, 0, true)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Valor total da receita bruta no período. 
            /// </summary>
            [SpedCampos(3, "VL_TOT_REC", "N", 0, 2, true)]
            public decimal VlTotRec { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada.
            /// </summary>
            [SpedCampos(4, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Descrição Complementar da Natureza da Receita.
            /// </summary>
            [SpedCampos(4, "DESC_COMPL", "C", int.MaxValue, 0, false)]
            public string DescCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO M810: DETALHAMENTO DAS RECEITAS ISENTAS, NÃO ALCANÇADAS PELA 
        ///     INCIDÊNCIA DA CONTRIBUIÇÃO, SUJEITAS A ALÍQUOTA ZERO OU DE VENDAS COM
        ///     SUSPENSÃO – cofins
        /// </summary>
        public class RegistroM810 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM810"/>
            /// </summary>
            public RegistroM810()
            {
                Reg = "M810";
            }

            /// <summary>
            ///     Natureza da Receita, conforme relação constante nas 
            ///     Tabelas de Detalhamento da Natureza da Receita por 
            ///     Situação Tributária abaixo: 
            ///     
            ///     - Tabela 4.3.10: Produtos Sujeitos à Incidência
            ///     Monofásica da Contribuição Social – Alíquotas 
            ///     Diferenciadas(CST 04 - Revenda); 
            ///     
            ///     - Tabela 4.3.11: Produtos Sujeitos à Incidência 
            ///     Monofásica da Contribuição Social – Alíquotas por 
            ///     Unidade de Medida de Produto(CST 04 - Revenda); 
            ///     
            ///     - Tabela 4.3.12: Produtos Sujeitos à Substituição 
            ///     Tributária da Contribuição Social(CST 05 - Revenda); 
            ///     
            ///     - Tabela 4.3.13: Produtos Sujeitos à Alíquota Zero da 
            ///     Contribuição Social(CST 06); 
            ///     
            ///     - Tabela 4.3.14: Operações com Isenção da Contribuição 
            ///     Social(CST 07); 
            ///     
            ///     - Tabela 4.3.15: Operações sem Incidência da
            ///     Contribuição Social(CST 08);
            ///     
            ///     - Tabela 4.3.16: Operações com Suspensão da 
            ///     Contribuição Social (CST 09). 
            /// </summary>
            [SpedCampos(2, "NAT_REC", "C", 3, 0, true)]
            public string NatRec { get; set; }

            /// <summary>
            ///     Valor da receita bruta no período, relativo a natureza da receita (NAT_REC)
            /// </summary>
            [SpedCampos(3, "VL_REC", "N", 0, 2, true)]
            public decimal VlRec { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada.
            /// </summary>
            [SpedCampos(4, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Descrição Complementar da Natureza da Receita.
            /// </summary>
            [SpedCampos(5, "DESC_COMPL", "C", int.MaxValue, 0, false)]
            public string DescCompl { get; set; }
        }

        public class RegistroM990 : RegistroBaseSped
        {
            public RegistroM990()
            {
                Reg = "M990";
            }

            [SpedCampos(2, "QTD_LIN_M", "N", int.MaxValue, 0, true)]
            public int QtdLinM { get; set; }
        }
    }
}