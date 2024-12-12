using FiscalBr.Common;
using FiscalBr.Common.Sped;
using FiscalBr.Common.Sped.Interfaces;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDContribuicoes
{
    public class BlocoM : IBlocoSped
    {
        public RegistroM001 RegM001 { get; set; }
        public RegistroM990 RegM990 { get; set; }

        public class RegistroM001 : RegistroSped
        {
            public RegistroM001() : base("M001")
            {
            }

            [SpedCampos(2, "IND_MOV", "C", 1, 0, true, 2)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroM100> RegM100s { get; set; }
            public RegistroM200 RegM200 { get; set; }
            public List<RegistroM300> RegM300s { get; set; }
            public RegistroM350 RegM350 { get; set; }
            public List<RegistroM400> RegM400s { get; set; }
            public List<RegistroM500> RegM500s { get; set; }
            public RegistroM600 RegM600 { get; set; }
            public List<RegistroM700> RegM700s { get; set; }
            public List<RegistroM800> RegM800s { get; set; }
        }

        /// <summary>
        ///     REGISTRO M100: CRÉDITO DE PIS/PASEP RELATIVO AO PERIODO
        /// </summary>
        public class RegistroM100 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM100"/>
            /// </summary>
            public RegistroM100() : base("M100")
            {
            }

            /// <summary>
            ///     Código de Tipo de C´redito apurado no período, conforme a Tabela 4.3.6
            /// </summary>
            [SpedCampos(2, "COD_CRED", "C", 3, 0, true, 2)]
            public string CodCred { get; set; }

            /// <summary>
            ///     Indicador de Crédito Oriundo de:
            ///     0- Operações próprias
            ///     1- Evento de incorporação, cisão ou fusão
            /// </summary>
            [SpedCampos(3, "IND_CRED_ORI", "N", 1, 0, true, 2)]
            public int IndCredOri { get; set; }

            /// <summary>
            ///     Valor da base de Cálculo do Crédito
            /// </summary>
            [SpedCampos(4, "VL_BC_PIS", "N", 0, 2, false, 2)]
            public decimal? VlBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(5, "ALIQ_PIS", "N", 8, 4, false, 2)]
            public decimal? AliqPis { get; set; }

            /// <summary>
            ///     Quantidade - Base de cálculo do PIS
            /// </summary>
            [SpedCampos(6, "QUANT_BC_PIS", "N", 0, 3, false, 2)]
            public decimal? QuantBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS (em reais)
            /// </summary>
            [SpedCampos(7, "ALI_PIS_QUANT", "N", 0, 4, false, 2)]
            public decimal? AliqPisQuant { get; set; }

            /// <summary>
            ///     Valor total do crédito apurado no período
            /// </summary>
            [SpedCampos(8, "VL_CRED", "N", 0, 2, true, 2)]
            public decimal VlCred { get; set; }

            /// <summary>
            ///     Valor total dos ajustes de acréscimo
            /// </summary>
            [SpedCampos(9, "VL_AJUS_ACRES", "N", 0, 2, true, 2)]
            public decimal VlAjusAcres { get; set; }

            /// <summary>
            ///     Valor total dos ajustes de redução
            /// </summary>
            [SpedCampos(10, "VL_AJUS_REDUC", "N", 0, 2, true, 2)]
            public decimal VlAjusReduc { get; set; }

            /// <summary>
            ///     Valor total do crédito diferido no período
            /// </summary>
            [SpedCampos(11, "VL_CRED_DIF", "N", 0, 2, true, 2)]
            public decimal VlCredDif { get; set; }

            /// <summary>
            ///     Valor Total do Crédito Disponível relativo ao Período (08  09 – 10 – 11)
            /// </summary>
            [SpedCampos(12, "VL_CRED_DISP", "N", 0, 2, true, 2)]
            public decimal VlCredDisp { get; set; }

            /// <summary>
            ///     Indicador de opção de utilização do crédito disponível no período: 
            ///     0 – Utilização do valor total para desconto da 
            ///     contribuição apurada no período, no Registro M200; 
            ///     1 – Utilização de valor parcial para desconto da 
            ///     contribuição apurada no período, no Registro M200. 
            /// </summary>
            [SpedCampos(13, "IND_DESC_CRED", "C", 1, 0, true, 2)]
            public int IndDescCred { get; set; }

            /// <summary>
            ///     Valor do Crédito disponível, descontado  da contribuição
            ///     apurada no próprio período.
            ///     Se IND_DESC_CRED=0, informar o valor total do Campo 12;
            ///     Se IND_DESC_CRED=1, informar o valor parcial do Campo 12
            /// </summary>
            [SpedCampos(14, "VL_CRED_DESC", "N", 0, 2, false, 2)]
            public decimal? VlCredDesc { get; set; }

            /// <summary>
            ///     Saldo de créditos a utilizar em períodos futuros (12 – 14)
            /// </summary>
            [SpedCampos(15, "VL_CRED_DESC", "N", 0, 2, true, 2)]
            public decimal SldCred { get; set; }

            public List<RegistroM105> RegM105s { get; set; }
            public List<RegistroM110> RegM110s { get; set; }
        }

        /// <summary>
        ///     REGISTRO M105: DETALHAMENTO DA BASE DE CALCULO DO CRÉDITO APURADO NO PERÍODO – PIS/PASEP
        /// </summary>
        public class RegistroM105 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM105"/>.
            /// </summary>
            public RegistroM105() : base("M105")
            {
            }

            /// <summary>
            ///     Código da Base de Cálculo do Crédito apurado no período, conforme a Tabela 4.3.7. 
            /// </summary>
            [SpedCampos(2, "NAT_BC_CRED", "C", 2, 0, true, 2)]
            public string NatBcCred { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao crédito de PIS/Pasep (Tabela 4.3.3) 
            ///     vinculado ao tipo de crédito escriturado em M100
            /// </summary>
            [SpedCampos(3, "CST_PIS", "N", 2, 0, true, 2)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor Total da Base de Cálculo escriturada nos documentos e operações (Blocos "A", "C", "D", e "F"), 
            ///     referente ao CST_PIS informado no Campo 03.
            /// </summary>
            [SpedCampos(4, "VL_BC_PIS_TOT", "N", 0, 2, false, 2)]
            public decimal? VlBcPisTot { get; set; }

            /// <summary>
            ///     Parcela do Valor Total da Base de Cálculo informada no Campo 04, 
            ///     vinculada a receitas com incidência cumulativa. 
            ///     Campo de preenchimento específico para a pessoa jurídica sujeita 
            ///     ao regime cumulativo e não-cumulativo da contribuição 
            ///     (COD_INC_TRIB = 3 do Registro 0110) 
            /// </summary>
            [SpedCampos(5, "VL_BC_PIS_CUM", "N", 0, 2, false, 2)]
            public decimal? VlBcPisCum { get; set; }

            /// <summary>
            ///     Valor Total da Base de Cálculo do Crédito, 
            ///     vinculada a receitas com incidência não-cumulativa (Campo 04 – Campo 05)
            /// </summary>
            [SpedCampos(6, "VL_BC_PIS_NC", "N", 0, 2, false, 2)]
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
            [SpedCampos(7, "VL_BC_PIS", "N", 0, 2, false, 2)]
            public decimal? VlBcPis { get; set; }

            /// <summary>
            ///     Quantidade Total da Base de Cálculo do Crédito apurado em Unidade de Medida de Produto, 
            ///     escriturada nos documentos e operações (Blocos "A", "C", "D" e "F"), 
            ///     referente ao CST_PIS informado no Campo 03 
            /// </summary>
            [SpedCampos(8, "QUANT_BC_PIS_TOT", "N", 0, 3, false, 2)]
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
            [SpedCampos(9, "QUANT_BC_PIS", "N", 0, 3, false, 2)]
            public decimal? QuantBcPis { get; set; }

            /// <summary>
            ///     Descrição do crédito
            /// </summary>
            [SpedCampos(10, "DESC_CRED", "C", 60, 0, false, 2)]
            public string DescCred { get; set; }
        }

        /// <summary>
        ///     REGISTRO M110: AJUSTES DO CRÉDITO DE PIS/PASEP APURADO
        /// </summary>
        public class RegistroM110 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM110" />.
            /// </summary>
            public RegistroM110() : base("M110")
            {
            }

            /// <summary>
            ///     Indicador do tipo de ajuste: 
            ///     0 - Ajuste de redução; 
            ///     1 - Ajuste de acréscimo
            /// </summary>
            [SpedCampos(2, "IND_AJ", "C", 1, 0, true, 2)]
            public IndTipoAjuste IndAj { get; set; }

            /// <summary>
            ///     Valor do ajuste
            /// </summary>
            [SpedCampos(3, "VL_AJ", "N", int.MaxValue, 2, true, 2)]
            public decimal VlAj { get; set; }

            /// <summary>
            ///     Código do ajuste, conforme a Tabela indicada no item 4.3.8.
            /// </summary>
            [SpedCampos(4, "COD_AJ", "C", 2, 0, true, 2)]
            public string CodAj { get; set; }

            /// <summary>
            ///     Número do processo, documento ou ato concessório ao qual o ajuste está vinculado, se houver.
            /// </summary>
            [SpedCampos(5, "NUM_DOC", "C", int.MaxValue, 0, false, 2)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Descrição resumida do ajuste.
            /// </summary>
            [SpedCampos(6, "DESCR_AJ", "C", int.MaxValue, 0, false, 2)]
            public string DescrAj { get; set; }

            /// <summary>
            ///     Data de referência do ajuste (ddmmaaaa)
            /// </summary>
            [SpedCampos(7, "DT_REF", "N", 8, 0, false, 2)]
            public DateTime? DtRef { get; set; }

            public List<RegistroM115> RegM115s { get; set; }
        }

        /// <summary>
        ///     REGISTRO M115: DETALHAMENTO DOS AJUSTES DO CRÉDITO DE PIS/PASEP APURADO
        /// </summary>
        public class RegistroM115 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM115" />.
            /// </summary>
            public RegistroM115() : base("M115")
            {
            }

            /// <summary>
            ///     Detalhamento do valor do crédito reduzido ou acrescido, informado no
            ///     Campo 03 (VL_AJ) do registro M110. 
            /// </summary>
            [SpedCampos(2, "DET_VALOR_AJ", "N", 0, 2, true, 2)]
            public decimal DetValorAj { get; set; }

            /// <summary>
            ///     Código de Situação Tributária referente à operação detalhada neste registro. 
            /// </summary>
            [SpedCampos(3, "CST_PIS", "N", 2, 0, false, 2)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Detalhamento da base de cálculo geradora de ajuste de crédito 
            /// </summary>
            [SpedCampos(4, "DET_BC_CRED", "N", 0, 3, false, 2)]
            public decimal? DetBcCred { get; set; }

            /// <summary>
            ///     Detalhamento da alíquota a que se refere o ajuste de crédito
            /// </summary>
            [SpedCampos(5, "DET_ALIQ", "N", 8, 4, false, 2)]
            public decimal? DetAliq { get; set; }

            /// <summary>
            ///     Data da operação a que se refere o ajuste informado neste registro. 
            /// </summary>
            [SpedCampos(6, "DT_OPER_AJ", "N", 8, 0, true, 2)]
            public DateTime DtOperAj { get; set; }

            /// <summary>
            ///     Descrição da(s) operação(ões) a que se refere o valor informado no 
            ///     Campo 02 (DET_VALOR_AJ)
            /// </summary>
            [SpedCampos(7, "DESC_AJ", "C", 0, 0, false, 2)]
            public string DescAj { get; set; }

            /// <summary>
            ///     Código da conta contábil debitada/creditada 
            /// </summary>
            [SpedCampos(8, "COD_CTA", "C", 60, 0, false, 2)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Informação complementar
            /// </summary>
            [SpedCampos(9, "INFO_COMPL", "C", 0, 0, false, 2)]
            public string InfoCompl { get; set; }
        }

        public class RegistroM200 : RegistroSped
        {
            public RegistroM200() : base("M200")
            {
            }

            [SpedCampos(2, "VL_TOT_CONT_NC_PER", "N", 0, 2, true, 2)]
            public decimal VlTotContNcPer { get; set; }

            [SpedCampos(3, "VL_TOT_CRED_DESC", "N", 0, 2, true, 2)]
            public decimal VlTotCredDesc { get; set; }

            [SpedCampos(4, "VL_TOT_CRED_DESC_ANT", "N", 0, 2, true, 2)]
            public decimal VlTotCredDescAnt { get; set; }

            [SpedCampos(5, "VL_TOT_CONT_NC_DEV", "N", 0, 2, true, 2)]
            public decimal VlTotContNcDev { get; set; }

            [SpedCampos(6, "VL_RET_NC", "N", 0, 2, true, 2)]
            public decimal VlRetNc { get; set; }

            [SpedCampos(7, "VL_OUT_DED_NC", "N", 0, 2, true, 2)]
            public decimal VlOutDedNc { get; set; }

            [SpedCampos(8, "VL_CONT_NC_REC", "N", 0, 2, true, 2)]
            public decimal VlContNcRec { get; set; }

            [SpedCampos(9, "VL_TOT_CONT_CUM_PER", "N", 0, 2, true, 2)]
            public decimal VlTotContCumPer { get; set; }

            [SpedCampos(10, "VL_RET_CUM", "N", 0, 2, true, 2)]
            public decimal VlRetCum { get; set; }

            [SpedCampos(11, "VL_OUT_DED_CUM", "N", 0, 2, true, 2)]
            public decimal VlOutDedCum { get; set; }

            [SpedCampos(12, "VL_CONT_CUM_REC", "N", 0, 2, true, 2)]
            public decimal VlContCumRec { get; set; }

            [SpedCampos(13, "VL_TOT_CONT_REC", "N", 0, 2, true, 2)]
            public decimal VlTotContRec { get; set; }

            public List<RegistroM205> RegM205s { get; set; }
            public List<RegistroM210> RegM210s { get; set; }
        }

        public class RegistroM205 : RegistroSped
        {
            public RegistroM205() : base("M205")
            {
            }

            [SpedCampos(2, "NUM_CAMPO", "C", 2, 0, true, 2)]
            public int NumCampo { get; set; }

            [SpedCampos(3, "COD_REC", "C", 6, 0, true, 2)]
            public int CodRec { get; set; }

            [SpedCampos(4, "VL_DEBITO", "N", 0, 2, true, 2)]
            public decimal VlDebito { get; set; }
        }

        public class RegistroM210 : RegistroSped
        {
            public RegistroM210() : base("M210")
            {
            }

            [SpedCampos(2, "COD_CONT", "C", 2, 0, true, 2)]
            public int CodCont { get; set; }

            [SpedCampos(3, "VL_REC_BRT", "N", int.MaxValue, 2, true, 2)]
            public decimal VlRecBrt { get; set; }

            [SpedCampos(4, "VL_BC_CONT", "N", int.MaxValue, 2, true, 2)]
            public decimal VlBcCont { get; set; }

            [SpedCampos(5, "VL_AJUS_ACRES_BC_PIS", "N", int.MaxValue, 2, true, 2)]
            public decimal VlAjusAcresBcPis { get; set; }

            [SpedCampos(6, "VL_AJUS_REDUC_BC_PIS", "N", int.MaxValue, 2, true, 2)]
            public decimal VlAjusReducBcPis { get; set; }

            [SpedCampos(7, "VL_BC_CONT_AJUS", "N", int.MaxValue, 2, true, 2)]
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

            [SpedCampos(8, "ALIQ_PIS", "N", 8, 4, false, 2)]
            public decimal? AliqPis { get; set; }

            [SpedCampos(9, "QUANT_BC_PIS", "N", int.MaxValue, 3, false, 2)]
            public decimal? QuantBcPis { get; set; }

            [SpedCampos(10, "ALIQ_PIS_QUANT", "N", int.MaxValue, 4, false, 2)]
            public decimal? AliqPisQuant { get; set; }

            [SpedCampos(11, "VL_CONT_APUR", "N", int.MaxValue, 2, true, 2)]
            public decimal VlContApur { get; set; }

            [SpedCampos(12, "VL_AJUS_ACRES", "N", int.MaxValue, 2, true, 2)]
            public decimal VlAjusAcres { get; set; }

            [SpedCampos(13, "VL_AJUS_REDUC", "N", int.MaxValue, 2, true, 2)]
            public decimal VlAjusReduc { get; set; }

            [SpedCampos(14, "VL_CONT_DIFER", "N", int.MaxValue, 2, false, 2)]
            public decimal? VlContDifer { get; set; }

            [SpedCampos(15, "VL_CONT_DIFER_ANT", "N", int.MaxValue, 2, false, 2)]
            public decimal? VlContDiferAnt { get; set; }

            [SpedCampos(16, "VL_CONT_PER", "N", int.MaxValue, 2, true, 2)]
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

            public RegistroM211 RegM211 { get; set; }
            public List<RegistroM215> RegM215s { get; set; }
            public List<RegistroM220> RegM220s { get; set; }
            public List<RegistroM230> RegM230s { get; set; }
        }

        /// <summary>
        ///     REGISTRO M211: Sociedades Cooperativas –Composição da Base de Calculo –PIS/Pasep
        /// </summary>
        public class RegistroM211 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroM211"/>
            /// </summary>
            public RegistroM211() : base("M211")
            {
            }

            /// <summary>
            ///     Indicador do Tipo de Sociedade Cooperativa:
            ///     01 –Cooperativa de Produção Agropecuária;
            ///     02 –Cooperativa de Consumo;
            ///     03 –Cooperativa de Crédito;
            ///     04 –Cooperativa de Eletrificação Rural;
            ///     05 –Cooperativa de Transporte Rodoviário de Cargas;
            ///     06 –Cooperativa de Médicos;
            ///     99 –Outras.
            /// </summary>
            [SpedCampos(2, "IND_TIP_COOP", "N", 2, 0, true, 2)]
            public string IndTipCoop { get; set; }

            /// <summary>
            ///    Valor  da  Base  de  Cálculo  da  Contribuição, conforme Registros escriturados nos Blocos A, C, D e F, antes das Exclusões das Cooperativas.
            /// </summary>
            [SpedCampos(3, "VL_BC_CONT_ANT_EXC_COOP", "N", 0, 2, true, 2)]
            public string VlBcContAntExcCoop { get; set; }

            /// <summary>
            ///     Valor de Exclusão Especifica das Cooperativas em Geral,  decorrente  das  Sobras Apuradas  na  DRE, destinadas a constituição do Fundo de Reserva e do FATES.
            /// </summary>
            [SpedCampos(4, "VL_EXC_COOP_GER", "N", 0, 2, false, 2)]
            public string VlExcCoopGer { get; set; }

            /// <summary>
            ///    Valor das Exclusões da Base de Cálculo Especifica do  Tipo  da  Sociedade  Cooperativa,  conforme Campo 02 (IND_TIP_COOP).
            /// </summary>
            [SpedCampos(5, "VL_EXC_ESP_COOP", "N", 0, 2, false, 2)]
            public string VlExcEspCoop { get; set; }

            /// <summary>
            ///     Valor  da  Base  de  Cálculo,  Após  as  Exclusões Especificas da Sociedade Cooperativa (04 –05 –06) –Transportar para M210.
            /// </summary>
            [SpedCampos(6, "VL_BC_CONT", "N", 0, 2, true, 2)]
            public string VlBcCont { get; set; }

        }

        /// <summary>
        ///     REGISTRO M215: Ajustes da Base de Cálculo da Contribuição para o PIS/Pasep Apurada
        /// </summary>
        public class RegistroM215 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroM215"/>
            /// </summary>
            public RegistroM215() : base("M215")
            {
            }

            /// <summary>
            ///     Indicador do tipo de ajuste da base de cálculo:
            ///     0 -Ajuste de redução;
            ///     1 -Ajuste de acréscimo.
            /// </summary>
            [SpedCampos(2, "IND_AJ_BC", "C", 1, 0, true, 2)]
            public string IndAjBc { get; set; }

            /// <summary>
            ///    Valor do ajuste de base de cálculo
            /// </summary>
            [SpedCampos(3, "VL_AJ_BC", "N", 18, 2, true, 2)]
            public decimal VlAjBc { get; set; }

            /// <summary>
            ///    Código do ajuste, conforme a Tabela indicada no item 4.3.18
            /// </summary>
            [SpedCampos(4, "COD_AJ_BC", "C", 2, 0, true, 2)]
            public string CodAjBc { get; set; }

            /// <summary>
            ///   Número do processo, documento ou ato concessório ao qual o ajuste está vinculado, se houver.
            /// </summary>
            [SpedCampos(5, "NUM_DOC", "C", 0, 0, false, 2)]
            public string NumDoc { get; set; }

            /// <summary>
            ///    Descrição resumida do ajuste na base de cálculo.
            /// </summary>
            [SpedCampos(6, "DESCR_AJ_BC", "C", 0, 0, false, 2)]
            public string DescrAjBc { get; set; }

            /// <summary>
            ///  Data de referência do ajuste (ddmmaaaa)
            /// </summary>
            [SpedCampos(7, "DT_REF", "N", 8, 0, false, 2)]
            public DateTime DtRef { get; set; }

            /// <summary>
            ///   Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(8, "COD_CTA", "C", 255, 0, false, 2)]
            public string CodCta { get; set; }

            /// <summary>
            ///   CNPJ do estabelecimento a que se refere o ajuste
            /// </summary>
            [SpedCampos(9, "CNPJ", "N", 14, 0, true, 2)]
            public string Cnpj { get; set; }

            /// <summary>
            ///  Informação complementar do registro
            /// </summary>
            [SpedCampos(10, "INFO_COMPL", "C", 0, 0, false, 2)]
            public string InfoCompl { get; set; }
        }

        public class RegistroM220 : RegistroSped
        {
            public RegistroM220() : base("M220")
            {
            }

            [SpedCampos(2, "IND_AJ", "C", 1, 0, true, 2)]
            public IndTipoAjuste IndAj { get; set; }

            [SpedCampos(3, "VL_AJ", "N", 0, 2, true, 2)]
            public decimal VlAj { get; set; }

            [SpedCampos(4, "COD_AJ", "C", 2, 0, true, 2)]
            public int CodAj { get; set; }

            [SpedCampos(5, "NUM_DOC", "C", Int16.MaxValue, 0, false, 2)]
            public string NumDoc { get; set; }

            [SpedCampos(6, "DESCR_AJ", "C", Int16.MaxValue, 0, false, 2)]
            public string DescrAj { get; set; }

            [SpedCampos(7, "DT_REF", "N", 8, 0, false, 2)]
            public DateTime? DtRef { get; set; }

            public List<RegistroM225> RegM225s { get; set; }
        }

        [SpedRegistros("01/10/2015", null)]
        public class RegistroM225 : RegistroSped
        {
            public RegistroM225() : base("M225")
            {
            }

            [SpedCampos(2, "DET_VALOR_AJ", "N", 0, 2, true, 2)]
            public decimal DetValorAj { get; set; }

            [SpedCampos(3, "CST_PIS", "N", 2, 0, false, 2)]
            public int CstPis { get; set; }

            [SpedCampos(4, "DET_BC_CRED", "N", 0, 3, false, 2)]
            public decimal? DetBcCred { get; set; }

            [SpedCampos(5, "DET_ALIQ", "N", 8, 4, false, 2)]
            public decimal? DetAliq { get; set; }

            [SpedCampos(6, "DT_OPER_AJ", "N", 8, 0, true, 2)]
            public DateTime DtOperAj { get; set; }

            [SpedCampos(7, "DESC_AJ", "C", Int16.MaxValue, 0, false, 2)]
            public string DescAj { get; set; }

            [SpedCampos(8, "COD_CTA", "C", Int16.MaxValue, 0, false, 2)]
            public string CodCta { get; set; }

            [SpedCampos(9, "INFO_COMPL", "C", Int16.MaxValue, 0, false, 2)]
            public string InfoCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO M230: Informações Adicionais de Diferimento
        /// </summary>
        public class RegistroM230 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroM230"/>
            /// </summary>
            public RegistroM230() : base("M230")
            {
            }

            /// <summary>
            ///   CNPJ da pessoa jurídica de direito público, empresa pública,  sociedade  de  economia  mista  ou  suas subsidiárias.
            /// </summary>
            [SpedCampos(2, "CNPJ", "N", 14, 0, true, 2)]
            public string Cnpj { get; set; }

            /// <summary>
            ///     Valor Total das vendas no período
            /// </summary>
            [SpedCampos(3, "VL_VEND", "N", 0, 2, true, 2)]
            public string VlVend { get; set; }

            /// <summary>
            ///    Valor Total não recebido no período
            /// </summary>
            [SpedCampos(4, "VL_NAO_RECEB", "N", 0, 2, true, 2)]
            public string VlNaoReceb { get; set; }

            /// <summary>
            ///    Valor da Contribuição diferida no período
            /// </summary>
            [SpedCampos(5, "VL_CONT_DIF", "N", 0, 2, true, 2)]
            public string VlContDif { get; set; }

            /// <summary>
            ///    Valor do Crédito diferido no período
            /// </summary>
            [SpedCampos(6, "VL_CRED_DIF", "N", 0, 2, false, 2)]
            public string VlCredDif { get; set; }

            /// <summary>
            ///    Código  de  Tipo  de  Crédito  diferido  no  período, conforme a Tabela 4.3.6.
            /// </summary>
            [SpedCampos(7, "COD_CRED", "C", 3, 0, false, 2)]
            public string CodCred { get; set; }
        }

        /// <summary>
        ///     REGISTRO M300: CONTRIBUIÇÃO DE PIS/PASEP DIFERIDA EM PREIODOS ANTERIORES - 
        ///     VALORES A PAGAR NO PERÍODO
        /// </summary>
        public class RegistroM300 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classse <see cref="RegistroM300"/>
            /// </summary>
            public RegistroM300() : base("M300")
            {
            }

            /// <summary>
            ///     Código da contribuição social diferida em períodos anteriores, conforme a Tabela 4.3.5. 
            /// </summary>
            [SpedCampos(2, "COD_CONT", "C", 2, 0, true, 2)]
            public string CodCont { get; set; }

            /// <summary>
            ///     Valor da Contribuição Apurada, diferida em períodos anteriores.
            /// </summary>
            [SpedCampos(3, "VL_CONT_APUR_DIFER", "N", int.MaxValue, 2, true, 2)]
            public decimal VlContApurDifer { get; set; }

            /// <summary>
            ///     Natureza do Crédito Diferido, vinculado à receita tributada no mercado interno, a descontar:
            ///     01 – Crédito a Alíquota Básica; 
            ///     02 – Crédito a Alíquota Diferenciada; 
            ///     03 – Crédito a Alíquota por Unidade de Produto; 
            ///     04 – Crédito Presumido da Agroindústria. 
            /// </summary>
            [SpedCampos(4, "NAT_CRED_DESC", "C", 2, 0, false, 2)]
            public int? NatCredDesc { get; set; }

            /// <summary>
            ///     Valor do Crédito a Descontar vinculado à contribuição diferida. 
            /// </summary>
            [SpedCampos(5, "VL_CRED_DESC_DIFER", "N", int.MaxValue, 2, false, 2)]
            public decimal? VlCredDescDifer { get; set; }

            /// <summary>
            ///     Valor da Contribuição a Recolher, diferida em períodos anteriores (Campo 03 – Campo 05)
            /// </summary>
            [SpedCampos(6, "VL_CONT_DIFER_ANT", "N", int.MaxValue, 2, true, 2)]
            public decimal VlContDiferAnt { get; set; }

            /// <summary>
            ///     Período de apuração da contribuição social e dos créditos diferidos (MMAAAA) 
            /// </summary>
            [SpedCampos(7, "PER_APUR", "MA", 6, 0, true, 2)]
            public DateTime PerApur { get; set; }

            /// <summary>
            ///     Data de recebimento da receita, objeto de diferimento 
            /// </summary>
            [SpedCampos(8, "DT_RECEB", "N", 8, 0, false, 2)]
            public DateTime? DtReceb { get; set; }

        }

        /// <summary>
        ///     REGISTRO M350: PIS/PASEP - FOLHA DE SALÁRIOS
        /// </summary>
        public class RegistroM350 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classse <see cref="RegistroM350"/>
            /// </summary>
            public RegistroM350() : base("M350")
            {
            }

            /// <summary>
            ///     Valor Total da Folha de Salários 
            /// </summary>
            [SpedCampos(2, "VL_TOT_FOL", "N", int.MaxValue, 2, true, 2)]
            public decimal VlTotFol { get; set; }

            /// <summary>
            ///     Valor Total das Exclusões à Base de Cálculo 
            /// </summary>
            [SpedCampos(3, "VL_EXC_BC", "N", int.MaxValue, 2, true, 2)]
            public decimal VlExcBc { get; set; }

            /// <summary>
            ///     Valor Total da Base de Cálculo 
            /// </summary>
            [SpedCampos(4, "VL_TOT_BC", "N", int.MaxValue, 2, true, 2)]
            public decimal VlTotBc { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP – Folha de Salários
            /// </summary>
            [SpedCampos(5, "ALIQ_PIS_FOL", "N", 6, 2, true, 2)]
            public decimal AliqPisFol { get; set; }

            /// <summary>
            ///     Valor Total da Contribuição Social sobre a Folha de Salários 
            /// </summary>
            [SpedCampos(6, "VL_TOT_CONT_FOL", "N", int.MaxValue, 2, true, 2)]
            public decimal VlTotContFol { get; set; }
        }

        /// <summary>
        ///     REGISTRO M400: RECEITAS ISENTAS, NÃO ALCANÇADAS PELA INCIDÊNCIA DA
        ///     CONTRIBUIÇÃO, SUJEITAS A ALÍQUOTA ZERO OU DE VENDAS COM SUSPENSÃO - PIS/PASEP
        /// </summary>
        public class RegistroM400 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classse <see cref="RegistroM400"/>
            /// </summary>
            public RegistroM400() : base("M400")
            {
            }

            /// <summary>
            ///     Código de Situação Tributária – CST das demais receitas 
            ///     auferidas no período, sem incidência da contribuição, ou 
            ///     sem contribuição apurada a pagar, conforme a Tabela 4.3.3.
            /// </summary>
            [SpedCampos(2, "CST_PIS", "C", 2, 0, true, 2)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor total da receita bruta no período. 
            /// </summary>
            [SpedCampos(3, "VL_TOT_REC", "N", 0, 2, true, 2)]
            public decimal VlTotRec { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada.
            /// </summary>
            [SpedCampos(4, "COD_CTA", "C", 60, 0, false, 2)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Descrição Complementar da Natureza da Receita.
            /// </summary>
            [SpedCampos(4, "DESC_COMPL", "C", int.MaxValue, 0, false, 2)]
            public string DescCompl { get; set; }

            public List<RegistroM410> RegM410s { get; set; }
        }

        /// <summary>
        ///     REGISTRO M410: DETALHAMENTO DAS RECEITAS ISENTAS, NÃO ALCANÇADAS PELA 
        ///     INCIDÊNCIA DA CONTRIBUIÇÃO, SUJEITAS A ALÍQUOTA ZERO OU DE VENDAS COM
        ///     SUSPENSÃO – PIS/PASEP 
        /// </summary>
        public class RegistroM410 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM410"/>
            /// </summary>
            public RegistroM410() : base("M410")
            {
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
            [SpedCampos(2, "NAT_REC", "C", 3, 0, true, 2)]
            public string NatRec { get; set; }

            /// <summary>
            ///     Valor da receita bruta no período, relativo a natureza da receita (NAT_REC)
            /// </summary>
            [SpedCampos(3, "VL_REC", "N", 0, 2, true, 2)]
            public decimal VlRec { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada.
            /// </summary>
            [SpedCampos(4, "COD_CTA", "C", 60, 0, false, 2)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Descrição Complementar da Natureza da Receita.
            /// </summary>
            [SpedCampos(5, "DESC_COMPL", "C", int.MaxValue, 0, false, 2)]
            public string DescCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO M500: CRÉDITO DE COFINS RELATIVO AO PERIODO
        /// </summary>
        public class RegistroM500 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM500"/>
            /// </summary>
            public RegistroM500() : base("M500")
            {
            }

            /// <summary>
            ///     Código de Tipo de C´redito apurado no período, conforme a Tabela 4.3.6
            /// </summary>
            [SpedCampos(2, "COD_CRED", "C", 3, 0, true, 2)]
            public string CodCred { get; set; }

            /// <summary>
            ///     Indicador de Crédito Oriundo de:
            ///     0- Operações próprias
            ///     1- Evento de incorporação, cisão ou fusão
            /// </summary>
            [SpedCampos(3, "IND_CRED_ORI", "N", 1, 0, true, 2)]
            public int IndCredOri { get; set; }

            /// <summary>
            ///     Valor da base de Cálculo do Crédito
            /// </summary>
            [SpedCampos(4, "VL_BC_COFINS", "N", 0, 2, false, 2)]
            public decimal? VlBcCofins { get; set; }

            /// <summary>
            ///     Alíquota do COFINS (em percentual)
            /// </summary>
            [SpedCampos(5, "ALIQ_COFINS", "N", 8, 4, false, 2)]
            public decimal? AliqCofins { get; set; }

            /// <summary>
            ///     Quantidade - Base de cálculo do COFINS
            /// </summary>
            [SpedCampos(6, "QUANT_BC_COFINS", "N", 0, 3, false, 2)]
            public decimal? QuantBcCofins { get; set; }

            /// <summary>
            ///     Alíquota do Cofins (em reais)
            /// </summary>
            [SpedCampos(7, "ALI_COFINS_QUANT", "N", 0, 4, false, 2)]
            public decimal? AliqCofinsQuant { get; set; }

            /// <summary>
            ///     Valor total do crédito apurado no período
            /// </summary>
            [SpedCampos(8, "VL_CRED", "N", 0, 2, true, 2)]
            public decimal VlCred { get; set; }

            /// <summary>
            ///     Valor total dos ajustes de acréscimo
            /// </summary>
            [SpedCampos(9, "VL_AJUS_ACRES", "N", 0, 2, true, 2)]
            public decimal VlAjusAcres { get; set; }

            /// <summary>
            ///     Valor total dos ajustes de redução
            /// </summary>
            [SpedCampos(10, "VL_AJUS_REDUC", "N", 0, 2, true, 2)]
            public decimal VlAjusReduc { get; set; }

            /// <summary>
            ///     Valor total do crédito diferido no período
            /// </summary>
            [SpedCampos(11, "VL_CRED_DIFER", "N", 0, 2, true, 2)]
            public decimal VlCredDifer { get; set; }

            /// <summary>
            ///     Valor Total do Crédito Disponível relativo ao Período (08 + 09 – 10 – 11)
            /// </summary>
            [SpedCampos(12, "VL_CRED_DISP", "N", 0, 2, true, 2)]
            public decimal VlCredDisp { get; set; }

            /// <summary>
            ///     Indicador de opção de utilização do crédito disponível no período: 
            ///     0 – Utilização do valor total para desconto da 
            ///     contribuição apurada no período, no Registro M200; 
            ///     1 – Utilização de valor parcial para desconto da 
            ///     contribuição apurada no período, no Registro M200. 
            /// </summary>
            [SpedCampos(13, "IND_DESC_CRED", "C", 1, 0, true, 2)]
            public int IndDescCred { get; set; }

            /// <summary>
            ///     Valor do Crédito disponível, descontado  da contribuição
            ///     apurada no próprio período.
            ///     Se IND_DESC_CRED=0, informar o valor total do Campo 12;
            ///     Se IND_DESC_CRED=1, informar o valor parcial do Campo 12
            /// </summary>
            [SpedCampos(14, "VL_CRED_DESC", "N", 0, 2, false, 2)]
            public decimal? VlCredDesc { get; set; }

            /// <summary>
            ///     Saldo de créditos a utilizar em períodos futuros (12 – 14)
            /// </summary>
            [SpedCampos(15, "VL_CRED_DESC", "N", 0, 2, true, 2)]
            public decimal SldCred { get; set; }

            public List<RegistroM505> RegM505s { get; set; }
            public List<RegistroM510> RegM510s { get; set; }
        }
        /// <summary>
        ///     REGISTRO M505: DETALHAMENTO DA BASE DE CALCULO DO CRÉDITO APURADO NO PERÍODO – COFINS
        /// </summary>
        public class RegistroM505 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM505"/>.
            /// </summary>
            public RegistroM505() : base("M505")
            {
            }

            /// <summary>
            ///     Código da Base de Cálculo do Crédito apurado no período, conforme a Tabela 4.3.7. 
            /// </summary>
            [SpedCampos(2, "NAT_BC_CRED", "C", 2, 0, true, 2)]
            public string NatBcCred { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao crédito de COFINS (Tabela 4.3.3) 
            ///     vinculado ao tipo de crédito escriturado em M100
            /// </summary>
            [SpedCampos(3, "CST_COFINS", "N", 2, 0, true, 2)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Valor Total da Base de Cálculo escriturada nos documentos e operações (Blocos "A", "C", "D", e "F"), 
            ///     referente ao CST_COFINS informado no Campo 03.
            /// </summary>
            [SpedCampos(4, "VL_BC_COFINS_TOT", "N", 0, 2, false, 2)]
            public decimal? VlBcCofinsTot { get; set; }

            /// <summary>
            ///     Parcela do Valor Total da Base de Cálculo informada no Campo 04, 
            ///     vinculada a receitas com incidência cumulativa. 
            ///     Campo de preenchimento específico para a pessoa jurídica sujeita 
            ///     ao regime cumulativo e não-cumulativo da contribuição 
            ///     (COD_INC_TRIB = 3 do Registro 0110) 
            /// </summary>
            [SpedCampos(5, "VL_BC_COFINS_CUM", "N", 0, 2, false, 2)]
            public decimal? VlBcCofinsCum { get; set; }

            /// <summary>
            ///     Valor Total da Base de Cálculo do Crédito, 
            ///     vinculada a receitas com incidência não-cumulativa (Campo 04 – Campo 05)
            /// </summary>
            [SpedCampos(6, "VL_BC_COFINS_NC", "N", 0, 2, false, 2)]
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
            [SpedCampos(7, "VL_BC_COFINS", "N", 0, 2, false, 2)]
            public decimal? VlBcCofins { get; set; }

            /// <summary>
            ///     Quantidade Total da Base de Cálculo do Crédito apurado em Unidade de Medida de Produto, 
            ///     escriturada nos documentos e operações (Blocos "A", "C", "D" e "F"), 
            ///     referente ao CST_COFINS informado no Campo 03 
            /// </summary>
            [SpedCampos(8, "QUANT_BC_COFINS_TOT", "N", 0, 3, false, 2)]
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
            [SpedCampos(9, "QUANT_BC_COFINS", "N", 0, 3, false, 2)]
            public decimal? QuantBcCofins { get; set; }

            /// <summary>
            ///     Descrição do crédito
            /// </summary>
            [SpedCampos(10, "DESC_CRED", "C", 60, 0, false, 2)]
            public string DescCred { get; set; }
        }

        /// <summary>
        ///     REGISTRO M510: AJUSTES DO CRÉDITO DE COFINS APURADO
        /// </summary>
        public class RegistroM510 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM510" />.
            /// </summary>
            public RegistroM510() : base("M510")
            {
            }

            /// <summary>
            ///     Indicador do tipo de ajuste: 
            ///     0 - Ajuste de redução; 
            ///     1 - Ajuste de acréscimo
            /// </summary>
            [SpedCampos(2, "IND_AJ", "C", 1, 0, true, 2)]
            public IndTipoAjuste IndAj { get; set; }

            /// <summary>
            ///     Valor do ajuste
            /// </summary>
            [SpedCampos(3, "VL_AJ", "N", Int16.MaxValue, 2, true, 2)]
            public decimal VlAj { get; set; }

            /// <summary>
            ///     Código do ajuste, conforme a Tabela indicada no item 4.3.8.
            /// </summary>
            [SpedCampos(4, "COD_AJ", "C", 2, 0, true, 2)]
            public string CodAj { get; set; }

            /// <summary>
            ///     Número do processo, documento ou ato concessório ao qual o ajuste está vinculado, se houver.
            /// </summary>
            [SpedCampos(5, "NUM_DOC", "C", Int16.MaxValue, 0, false, 2)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Descrição resumida do ajuste.
            /// </summary>
            [SpedCampos(6, "DESCR_AJ", "C", Int16.MaxValue, 0, false, 2)]
            public string DescrAj { get; set; }

            /// <summary>
            ///     Data de referência do ajuste (ddmmaaaa)
            /// </summary>
            [SpedCampos(7, "DT_REF", "N", 8, 0, false, 2)]
            public DateTime? DtRef { get; set; }

            public List<RegistroM515> RegM515s { get; set; }
        }

        /// <summary>
        ///     REGISTRO M515: DETALHAMENTO DOS AJUSTES DO CRÉDITO DE COFINS APURADO
        /// </summary>
        public class RegistroM515 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM515" />.
            /// </summary>
            public RegistroM515() : base("M515")
            {
            }

            /// <summary>
            ///     Detalhamento do valor do crédito reduzido ou acrescido, informado no
            ///     Campo 03 (VL_AJ) do registro M110. 
            /// </summary>
            [SpedCampos(2, "DET_VALOR_AJ", "N", 0, 2, true, 2)]
            public decimal DetValorAj { get; set; }

            /// <summary>
            ///     Código de Situação Tributária referente à operação detalhada neste registro. 
            /// </summary>
            [SpedCampos(3, "CST_COFINS", "N", 2, 0, false, 2)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Detalhamento da base de cálculo geradora de ajuste de crédito 
            /// </summary>
            [SpedCampos(4, "DET_BC_CRED", "N", 0, 3, false, 2)]
            public decimal? DetBcCred { get; set; }

            /// <summary>
            ///     Detalhamento da alíquota a que se refere o ajuste de crédito
            /// </summary>
            [SpedCampos(5, "DET_ALIQ", "N", 8, 4, false, 2)]
            public decimal? DetAliq { get; set; }

            /// <summary>
            ///     Data da operação a que se refere o ajuste informado neste registro. 
            /// </summary>
            [SpedCampos(6, "DT_OPER_AJ", "N", 8, 0, true, 2)]
            public DateTime DtOperAj { get; set; }

            /// <summary>
            ///     Descrição da(s) operação(ões) a que se refere o valor informado no 
            ///     Campo 02 (DET_VALOR_AJ)
            /// </summary>
            [SpedCampos(7, "DESC_AJ", "C", Int16.MaxValue, 0, false, 2)]
            public string DescAj { get; set; }

            /// <summary>
            ///     Código da conta contábil debitada/creditada 
            /// </summary>
            [SpedCampos(8, "COD_CTA", "C", Int16.MaxValue, 0, false, 2)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Informação complementar
            /// </summary>
            [SpedCampos(9, "INFO_COMPL", "C", Int16.MaxValue, 0, false, 2)]
            public string InfoCompl { get; set; }
        }


        /// <summary>
        ///     REGISTRO M600: CONSOLIDAÇÃO DA CONTRIBUIÇÃO PARA A SEGURIDADE SOCIAL - COFINS DO PERIODO
        /// </summary>
        public class RegistroM600 : RegistroSped
        {
            public RegistroM600() : base("M600")
            {
            }

            [SpedCampos(2, "VL_TOT_CONT_NC_PER", "N", 0, 2, true, 2)]
            public decimal VlTotContNcPer { get; set; }

            [SpedCampos(3, "VL_TOT_CRED_DESC", "N", 0, 2, true, 2)]
            public decimal VlTotCredDesc { get; set; }

            [SpedCampos(4, "VL_TOT_CRED_DESC_ANT", "N", 0, 2, true, 2)]
            public decimal VlTotCredDescAnt { get; set; }

            [SpedCampos(5, "VL_TOT_CONT_NC_DEV", "N", 0, 2, true, 2)]
            public decimal VlTotContNcDev { get; set; }

            [SpedCampos(6, "VL_RET_NC", "N", 0, 2, true, 2)]
            public decimal VlRetNc { get; set; }

            [SpedCampos(7, "VL_OUT_DED_NC", "N", 0, 2, true, 2)]
            public decimal VlOutDedNc { get; set; }

            [SpedCampos(8, "VL_CONT_NC_REC", "N", 0, 2, true, 2)]
            public decimal VlContNcRec { get; set; }

            [SpedCampos(9, "VL_TOT_CONT_CUM_PER", "N", 0, 2, true, 2)]
            public decimal VlTotContCumPer { get; set; }

            [SpedCampos(10, "VL_RET_CUM", "N", 0, 2, true, 2)]
            public decimal VlRetCum { get; set; }

            [SpedCampos(11, "VL_OUT_DED_CUM", "N", 0, 2, true, 2)]
            public decimal VlOutDedCum { get; set; }

            [SpedCampos(12, "VL_CONT_CUM_REC", "N", 0, 2, true, 2)]
            public decimal VlContCumRec { get; set; }

            [SpedCampos(13, "VL_TOT_CONT_REC", "N", 0, 2, true, 2)]
            public decimal VlTotContRec { get; set; }

            public List<RegistroM605> RegM605s { get; set; }
            public List<RegistroM610> RegM610s { get; set; }
        }

        public class RegistroM605 : RegistroSped
        {
            public RegistroM605() : base("M605")
            {
            }

            [SpedCampos(2, "NUM_CAMPO", "C", 2, 0, true, 2)]
            public int NumCampo { get; set; }

            [SpedCampos(3, "COD_REC", "C", 6, 0, true, 2)]
            public int CodRec { get; set; }

            [SpedCampos(4, "VL_DEBITO", "N", 0, 2, true, 2)]
            public decimal VlDebito { get; set; }
        }

        public class RegistroM610 : RegistroSped
        {
            public RegistroM610() : base("M610")
            {
            }

            [SpedCampos(2, "COD_CONT", "C", 2, 0, true, 2)]
            public int CodCont { get; set; }

            [SpedCampos(3, "VL_REC_BRT", "N", 0, 2, true, 2)]
            public decimal VlRecBrt { get; set; }

            [SpedCampos(4, "VL_BC_CONT", "N", 0, 2, true, 2)]
            public decimal VlBcCont { get; set; }

            [SpedCampos(5, "VL_AJUS_ACRES_BC_COFINS", "N", 0, 2, true, 2)]
            public decimal VlAjusAcresBcCofins { get; set; }

            [SpedCampos(6, "VL_AJUS_REDUC_BC_COFINS", "N", 0, 2, true, 2)]
            public decimal VlAjusReducBcCofins { get; set; }

            [SpedCampos(7, "VL_BC_CONT_AJUS", "N", 0, 2, true, 2)]
            public decimal VlBcContAjus
            {
                get
                {
                    return
                        VlBcCont +
                        VlAjusAcresBcCofins -
                        VlAjusReducBcCofins;
                }
            }

            [SpedCampos(8, "ALIQ_COFINS", "N", 8, 4, false, 2)]
            public decimal? AliqCofins { get; set; }

            [SpedCampos(9, "QUANT_BC_COFINS", "N", 0, 3, false, 2)]
            public decimal? QuantBcCofins { get; set; }

            [SpedCampos(10, "ALIQ_COFINS_QUANT", "N", 0, 4, false, 2)]
            public decimal? AliqCofinsQuant { get; set; }

            [SpedCampos(11, "VL_CONT_APUR", "N", 0, 2, true, 2)]
            public decimal VlContApur { get; set; }

            [SpedCampos(12, "VL_AJUS_ACRES", "N", 0, 2, true, 2)]
            public decimal VlAjusAcres { get; set; }

            [SpedCampos(13, "VL_AJUS_REDUC", "N", 0, 2, true, 2)]
            public decimal VlAjusReduc { get; set; }

            [SpedCampos(14, "VL_CONT_DIFER", "N", 0, 2, false, 2)]
            public decimal? VlContDifer { get; set; }

            [SpedCampos(15, "VL_CONT_DIFER_ANT", "N", 0, 2, false, 2)]
            public decimal? VlContDiferAnt { get; set; }

            [SpedCampos(16, "VL_CONT_PER", "N", 0, 2, true, 2)]
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

            public RegistroM611 RegM611 { get; set; }
            public List<RegistroM615> RegM615s { get; set; }
            public List<RegistroM620> RegM620s { get; set; }
            public List<RegistroM630> RegM630s { get; set; }
        }

        /// <summary>
        ///     REGISTRO M611: Sociedades Cooperativas –Composição da Base de Calculo –Cofins
        /// </summary>
        public class RegistroM611 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroM611"/>
            /// </summary>
            public RegistroM611() : base("M611")
            {
            }

            /// <summary>
            ///     Indicador do Tipo de Sociedade Cooperativa:
            ///     01 –Cooperativa de Produção Agropecuária;
            ///     02 –Cooperativa de Consumo;
            ///     03 –Cooperativa de Crédito;
            ///     04 –Cooperativa de Eletrificação Rural;
            ///     05 –Cooperativa de Transporte Rodoviário de Cargas;
            ///     06 –Cooperativa de Médicos;
            ///     99 –Outras.
            /// </summary>
            [SpedCampos(2, "IND_TIP_COOP", "N", 0, 0, true, 2)]
            public string IndTipCoop { get; set; }

            /// <summary>
            ///    Valor da Base de Cálculo da Contribuição, conforme Registros escriturados nos Blocos A, C, D e F, antes das Exclusões das Sociedades Cooperativas.
            /// </summary>
            [SpedCampos(3, "VL_BC_CONT_ANT_EXC_COOP", "N", 0, 2, true, 2)]
            public string VlBcContAntExcCoop { get; set; }

            /// <summary>
            ///    Valor de Exclusão Especifica das Cooperativas em Geral,  decorrente  das  Sobras  Apuradas  na  DRE, destinadas a constituição do Fundo de Reserva e do FATES.
            /// </summary>
            [SpedCampos(4, "VL_EXC_COOP_GER", "N", 0, 2, false, 2)]
            public string VlExcCoopGer { get; set; }

            /// <summary>
            ///    Valor das Exclusões da Base de Cálculo Especifica do Tipo da Sociedade Cooperativa, conforme Campo 02 (IND_TIP_COOP).
            /// </summary>
            [SpedCampos(5, "VL_EXC_ESP_COOP", "N", 0, 2, false, 2)]
            public string VlExcEspCoop { get; set; }

            /// <summary>
            ///    Valor  da  Base  de  Cálculo,  Após  as  Exclusões Especificas da Sociedade Cooperativa (04 –05 –06) –Transportar para M610.
            /// </summary>
            [SpedCampos(6, "VL_BC_CONT", "N", 0, 2, true, 2)]
            public string VlBcCont { get; set; }

        }

        /// <summary>
        ///     REGISTRO M615: Ajustes da Base de Cálculo da COFINS Apurada 
        /// </summary>
        public class RegistroM615 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroM615"/>
            /// </summary>
            public RegistroM615() : base("M615")
            {
            }

            /// <summary>
            ///     Indicador do tipo de ajuste da base de cálculo:
            ///     0 -Ajuste de redução;
            ///     1 -Ajuste de acréscimo.
            /// </summary>
            [SpedCampos(2, "IND_AJ_BC", "C", 1, 0, true, 2)]
            public string IndAjBc { get; set; }

            /// <summary>
            ///    Valor do ajuste de base de cálculo
            /// </summary>
            [SpedCampos(3, "VL_AJ_BC", "N", 18, 2, true, 2)]
            public decimal VlAjBc { get; set; }

            /// <summary>
            ///    Código do ajuste, conforme a Tabela indicada no item 4.3.18
            /// </summary>
            [SpedCampos(4, "COD_AJ_BC", "C", 2, 0, true, 2)]
            public string CodAjBc { get; set; }

            /// <summary>
            ///   Número do processo, documento ou ato concessório ao qual o ajuste está vinculado, se houver.
            /// </summary>
            [SpedCampos(5, "NUM_DOC", "C", 0, 0, false, 2)]
            public string NumDoc { get; set; }

            /// <summary>
            ///    Descrição resumida do ajuste na base de cálculo.
            /// </summary>
            [SpedCampos(6, "DESCR_AJ_BC", "C", 0, 0, false, 2)]
            public string DescrAjBc { get; set; }

            /// <summary>
            ///  Data de referência do ajuste (ddmmaaaa)
            /// </summary>
            [SpedCampos(7, "DT_REF", "N", 8, 0, false, 2)]
            public DateTime DtRef { get; set; }

            /// <summary>
            ///   Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(8, "COD_CTA", "C", 255, 0, false, 2)]
            public string CodCta { get; set; }

            /// <summary>
            ///   CNPJ do estabelecimento a que se refere o ajuste
            /// </summary>
            [SpedCampos(9, "CNPJ", "N", 14, 0, true, 2)]
            public string Cnpj { get; set; }

            /// <summary>
            ///  Informação complementar do registro
            /// </summary>
            [SpedCampos(10, "INFO_COMPL", "C", 0, 0, false, 2)]
            public string InfoCompl { get; set; }

        }

        public class RegistroM620 : RegistroSped
        {
            public RegistroM620() : base("M620")
            {
            }

            [SpedCampos(2, "IND_AJ", "C", 1, 0, true, 2)]
            public IndTipoAjuste IndAj { get; set; }

            [SpedCampos(3, "VL_AJ", "N", 0, 2, true, 2)]
            public decimal VlAj { get; set; }

            [SpedCampos(4, "COD_AJ", "C", 2, 0, true, 2)]
            public int CodAj { get; set; }

            [SpedCampos(5, "NUM_DOC", "C", Int16.MaxValue, 0, false, 2)]
            public string NumDoc { get; set; }

            [SpedCampos(6, "DESCR_AJ", "C", Int16.MaxValue, 0, false, 2)]
            public string DescrAj { get; set; }

            [SpedCampos(7, "DT_REF", "N", 8, 0, false, 2)]
            public DateTime? DtRef { get; set; }

            public List<RegistroM625> RegM625s { get; set; }

        }

        [SpedRegistros("01/10/2015", null)]
        public class RegistroM625 : RegistroSped
        {
            public RegistroM625() : base("M625")
            {
            }

            [SpedCampos(2, "DET_VALOR_AJ", "N", 0, 2, true, 2)]
            public decimal DetValorAj { get; set; }

            [SpedCampos(3, "CST_COFINS", "N", 2, 0, false, 2)]
            public int CstCofins { get; set; }

            [SpedCampos(4, "DET_BC_CRED", "N", 0, 3, false, 2)]
            public decimal? DetBcCred { get; set; }

            [SpedCampos(5, "DET_ALIQ", "N", 8, 4, false, 2)]
            public decimal? DetAliq { get; set; }

            [SpedCampos(6, "DT_OPER_AJ", "N", 8, 0, true, 2)]
            public DateTime DtOperAj { get; set; }

            [SpedCampos(7, "DESC_AJ", "C", Int16.MaxValue, 0, false, 2)]
            public string DescAj { get; set; }

            [SpedCampos(8, "COD_CTA", "C", Int16.MaxValue, 0, false, 2)]
            public string CodCta { get; set; }

            [SpedCampos(9, "INFO_COMPL", "C", Int16.MaxValue, 0, false, 2)]
            public string InfoCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO M630: Informações Adicionais de Diferimento
        /// </summary>
        public class RegistroM630 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroM630"/>
            /// </summary>
            public RegistroM630() : base("M630")
            {
            }

            /// <summary>
            ///   CNPJ da pessoa jurídica de direito público, empresa pública,  sociedade  de  economia  mista  ou  suas subsidiárias.
            /// </summary>
            [SpedCampos(2, "CNPJ", "N", 14, 0, true, 2)]
            public string Cnpj { get; set; }

            /// <summary>
            ///     Valor Total das vendas no período
            /// </summary>
            [SpedCampos(3, "VL_VEND", "N", 0, 2, true, 2)]
            public string VlVend { get; set; }

            /// <summary>
            ///    Valor Total não recebido no período
            /// </summary>
            [SpedCampos(4, "VL_NAO_RECEB", "N", 0, 2, true, 2)]
            public string VlNaoReceb { get; set; }

            /// <summary>
            ///    Valor da Contribuição diferida no período
            /// </summary>
            [SpedCampos(5, "VL_CONT_DIF", "N", 0, 2, true, 2)]
            public string VlContDif { get; set; }

            /// <summary>
            ///    Valor do Crédito diferido no período
            /// </summary>
            [SpedCampos(6, "VL_CRED_DIF", "N", 0, 2, false, 2)]
            public string VlCredDif { get; set; }

            /// <summary>
            ///    Código  de  Tipo  de  Crédito  diferido  no  período, conforme a Tabela 4.3.6.
            /// </summary>
            [SpedCampos(7, "COD_CRED", "C", 3, 0, false, 2)]
            public string CodCred { get; set; }

        }

        /// <summary>
        ///     REGISTRO M700: CONTRIBUIÇÃO DE PIS/PASEP DIFERIDA EM PREIODOS ANTERIORES - 
        ///     VALORES A PAGAR NO PERÍODO
        /// </summary>
        public class RegistroM700 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classse <see cref="RegistroM700"/>
            /// </summary>
            public RegistroM700() : base("M700")
            {
            }

            /// <summary>
            ///     Código da contribuição social diferida em períodos anteriores, conforme a Tabela 4.3.5. 
            /// </summary>
            [SpedCampos(2, "COD_CONT", "C", 2, 0, true, 2)]
            public string CodCont { get; set; }

            /// <summary>
            ///     Valor da Contribuição Apurada, diferida em períodos anteriores.
            /// </summary>
            [SpedCampos(3, "VL_CONT_APUR_DIFER", "N", int.MaxValue, 2, true, 2)]
            public decimal VlContApurDifer { get; set; }

            /// <summary>
            ///     Natureza do Crédito Diferido, vinculado à receita tributada no mercado interno, a descontar:
            ///     01 – Crédito a Alíquota Básica; 
            ///     02 – Crédito a Alíquota Diferenciada; 
            ///     03 – Crédito a Alíquota por Unidade de Produto; 
            ///     04 – Crédito Presumido da Agroindústria. 
            /// </summary>
            [SpedCampos(4, "NAT_CRED_DESC", "C", 2, 0, false, 2)]
            public int? NatCredDesc { get; set; }

            /// <summary>
            ///     Valor do Crédito a Descontar vinculado à contribuição diferida. 
            /// </summary>
            [SpedCampos(5, "VL_CRED_DESC_DIFER", "N", int.MaxValue, 2, false, 2)]
            public decimal? VlCredDescDifer { get; set; }

            /// <summary>
            ///     Valor da Contribuição a Recolher, diferida em períodos anteriores (Campo 03 – Campo 05)
            /// </summary>
            [SpedCampos(6, "VL_CONT_DIFER_ANT", "N", int.MaxValue, 2, true, 2)]
            public decimal VlContDiferAnt { get; set; }

            /// <summary>
            ///     Período de apuração da contribuição social e dos créditos diferidos (MMAAAA) 
            /// </summary>
            [SpedCampos(7, "PER_APUR", "MA", 6, 0, true, 2)]
            public DateTime PerApur { get; set; }

            /// <summary>
            ///     Data de recebimento da receita, objeto de diferimento 
            /// </summary>
            [SpedCampos(8, "DT_RECEB", "N", 8, 0, false, 2)]
            public DateTime? DtReceb { get; set; }

        }

        /// <summary>
        ///     REGISTRO M800: RECEITAS ISENTAS, NÃO ALCANÇADAS PELA INCIDÊNCIA DA 
        ///     CONTRIBUIÇÃO, SUJEITAS A ALÍQUOTA ZERO OU DE VENDAS COM SUSPENSÃO – COFINS 
        /// </summary>
        public class RegistroM800 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classse <see cref="RegistroM800"/>
            /// </summary>
            public RegistroM800() : base("M800")
            {
            }

            /// <summary>
            ///     Código de Situação Tributária – CST das demais receitas 
            ///     auferidas no período, sem incidência da contribuição, ou 
            ///     sem contribuição apurada a pagar, conforme a Tabela 4.3.3.
            /// </summary>
            [SpedCampos(2, "CST_COFINS", "C", 2, 0, true, 2)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Valor total da receita bruta no período. 
            /// </summary>
            [SpedCampos(3, "VL_TOT_REC", "N", 0, 2, true, 2)]
            public decimal VlTotRec { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada.
            /// </summary>
            [SpedCampos(4, "COD_CTA", "C", 60, 0, false, 2)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Descrição Complementar da Natureza da Receita.
            /// </summary>
            [SpedCampos(4, "DESC_COMPL", "C", int.MaxValue, 0, false, 2)]
            public string DescCompl { get; set; }

            public List<RegistroM810> RegM810s { get; set; }
        }

        /// <summary>
        ///     REGISTRO M810: DETALHAMENTO DAS RECEITAS ISENTAS, NÃO ALCANÇADAS PELA 
        ///     INCIDÊNCIA DA CONTRIBUIÇÃO, SUJEITAS A ALÍQUOTA ZERO OU DE VENDAS COM
        ///     SUSPENSÃO – cofins
        /// </summary>
        public class RegistroM810 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroM810"/>
            /// </summary>
            public RegistroM810() : base("M810")
            {
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
            [SpedCampos(2, "NAT_REC", "C", 3, 0, true, 2)]
            public string NatRec { get; set; }

            /// <summary>
            ///     Valor da receita bruta no período, relativo a natureza da receita (NAT_REC)
            /// </summary>
            [SpedCampos(3, "VL_REC", "N", 0, 2, true, 2)]
            public decimal VlRec { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada.
            /// </summary>
            [SpedCampos(4, "COD_CTA", "C", 60, 0, false, 2)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Descrição Complementar da Natureza da Receita.
            /// </summary>
            [SpedCampos(5, "DESC_COMPL", "C", int.MaxValue, 0, false, 2)]
            public string DescCompl { get; set; }
        }

        public class RegistroM990 : RegistroSped
        {
            public RegistroM990() : base("M990")
            {
            }

            [SpedCampos(2, "QTD_LIN_M", "N", int.MaxValue, 0, true, 2)]
            public int QtdLinM { get; set; }
        }
    }
}