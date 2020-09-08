using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.EFDContribuicoes
{
    public class BlocoF
    {
        public class RegistroF001 : RegistroBaseSped
        {
            public RegistroF001()
            {
                Reg = "F001";
            }

            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }
        }

        /// <summary>
        /// Identificação do Estabelecimento
        /// </summary>
        public class RegistroF010 : RegistroBaseSped
        {
            public RegistroF010()
            {
                Reg = "F010";
            }

            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }
        }

        /// <summary>
        /// DEMAIS DOCUMENTOS E OPERAÇÕES GERADORAS DE CONTRIBUIÇÃO E CRÉDITOS
        /// </summary>
        public class RegistroF100 : RegistroBaseSped
        {
            public RegistroF100()
            {
                Reg = "F100";
            }

            [SpedCampos(2, "IND_OPER", "N", 1, 0, true)]
            public int IndOper { get; set; }

            [SpedCampos(3, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            [SpedCampos(4, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            [SpedCampos(5, "DT_OPER", "N", 8, 0, true)]
            public DateTime DtOper { get; set; }

            [SpedCampos(6, "VL_OPER", "N", 0, 2, true)]
            public decimal VlOper { get; set; }

            [SpedCampos(7, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(8, "VL_BC_PIS", "N", 0, 4, false)]
            public decimal VlBcPis { get; set; }

            [SpedCampos(9, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal AliqPis { get; set; }

            [SpedCampos(10, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            [SpedCampos(11, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(12, "VL_BC_COFINS", "N", 0, 4, false)]
            public decimal VlBcCofins { get; set; }

            [SpedCampos(13, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal AliqCofins { get; set; }

            [SpedCampos(14, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            [SpedCampos(15, "NAT_BC_CRED", "C", 2, 0, false)]
            public string NatBcCred { get; set; }

            [SpedCampos(16, "IND_ORIG_CRED", "C", 1, 0, false)]
            public string IndOrigCred { get; set; }

            [SpedCampos(17, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            [SpedCampos(18, "COD_CCUS", "C", 60, 0, false)]
            public string CodCcus { get; set; }

            [SpedCampos(19, "DESC_DOC_OPER", "C", int.MaxValue, 0, false)]
            public string DescDocOper { get; set; }
        }

        /// <summary>
        ///     REGISTRO F150: CRÉDITO PRESUMIDO SOBRE ESTOQUE DE ABERTURA
        /// </summary>
        public class RegistroF150 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroF150" />.
            /// </summary>
            public RegistroF150()
            {
                Reg = "F150";
            }

            /// <summary>
            ///     Texto fixo contendo "18" Código da Base de Cálculo do Crédito sobre Estoque de Abertura, conforme a Tabela indicada no item 4.3.7.
            /// </summary>
            [SpedCampos(2, "NAT_BC_CRED", "C", 2, 0, true)]
            public string NatBCCred { get; set; }

            /// <summary>
            ///     Valor Total do Estoque de Abertura
            /// </summary>
            [SpedCampos(3, "VL_TOT_EST", "N", int.MaxValue, 2, true)]
            public decimal VlTotEst { get; set; }

            /// <summary>
            ///     Parcela do estoque de abertura referente a bens, produtos e mercadorias importados, ou adquiridas no mercado interno sem direito ao crédito
            /// </summary>
            [SpedCampos(4, "EST_IMP", "N", int.MaxValue, 2, false)]
            public decimal EstImp { get; set; }

            /// <summary>
            ///     Valor da Base de Cálculo do Crédito sobre o Estoque de Abertura (03 – 04)
            /// </summary>
            [SpedCampos(5, "VL_BC_EST", "N", int.MaxValue, 2, true)]
            public decimal VlBcEst { get; set; }

            /// <summary>
            ///     Valor da Base de Cálculo Mensal do Crédito sobre o Estoque de Abertura (1/12 avos do campo 05)
            /// </summary>
            [SpedCampos(6, "VL_BC_MEN_EST", "N", int.MaxValue, 2, true)]
            public decimal VlBcMenEst { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao PIS/PASEP, conforme a Tabela indicada no item 4.3.3.
            /// </summary>
            [SpedCampos(7, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(8, "ALIQ_PIS", "N", 8, 4, true)]
            public decimal AliqPis { get; set; }

            /// <summary>
            ///     Valor Mensal do Crédito Presumido Apurado para o Período - PIS/PASEP (06 x 08)
            /// </summary>
            [SpedCampos(9, "VL_CRED_PIS", "N", int.MaxValue, 2, true)]
            public decimal VlCredPis { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao COFINS, conforme a Tabela indicada no item 4.3.4
            /// </summary>
            [SpedCampos(10, "CST_COFINS", "N", 2, 0, true)]
            public decimal CstCofins { get; set; }

            /// <summary>
            ///     Alíquota do COFINS (em percentual)
            /// </summary>
            [SpedCampos(11, "ALIQ_COFINS", "N", 8, 4, true)]
            public decimal AliqCofins { get; set; }

            /// <summary>
            ///     Valor Mensal do Crédito Presumido Apurado para o Período - COFINS(06 x 11)
            /// </summary>
            [SpedCampos(12, "VL_CRED_COFINS", "N", int.MaxValue, 2, true)]
            public decimal VlCredCofins { get; set; }

            /// <summary>
            ///     Descrição do estoque
            /// </summary>
            [SpedCampos(13, "DESC_EST", "C", 100, 0, false)]
            public string DescEst { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(14, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        /// OPERAÇÕES DA ATIVIDADE IMOBILIÁRIA - UNIDADE IMOBILIÁRIA VENDIDA
        /// </summary>
        public class RegistroF200 : RegistroBaseSped
        {
            public RegistroF200()
            {
                Reg = "F200";
            }

            [SpedCampos(2, "IND_OPER", "N", 2, 0, true)]
            public int IndOper { get; set; }

            [SpedCampos(3, "UNID_IMOB", "N", 2, 0, true)]
            public int UnidImob { get; set; }

            [SpedCampos(4, "IDENT_EMP", "C", int.MaxValue, 0, true)]
            public string IdentEmp { get; set; }

            [SpedCampos(5, "DESC_UNID_IMOB", "C", 90, 0, false)]
            public string DescUnidImob { get; set; }

            [SpedCampos(6, "NUM_CONT", "C", 90, 0, false)]
            public string NumCont { get; set; }

            [SpedCampos(7, "CPF_CNPJ_ADQU", "C", 14, 0, true)]
            public string CpfCnpjAdqu { get; set; }

            [SpedCampos(8, "DT_OPER", "N", 8, 0, true)]
            public DateTime DtOper { get; set; }

            [SpedCampos(9, "VL_TOT_VEND", "N", 0, 2, true)]
            public decimal VlTotVend { get; set; }

            [SpedCampos(10, "VL_REC_ACUM", "N", 0, 2, false)]
            public decimal VlRecAcum { get; set; }

            [SpedCampos(11, "VL_TOT_REC", "N", 0, 2, true)]
            public decimal VlTotRec { get; set; }

            [SpedCampos(12, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(13, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal VlBcPis { get; set; }

            [SpedCampos(14, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal AliqPis { get; set; }

            [SpedCampos(15, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            [SpedCampos(16, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(17, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal VlBcCofins { get; set; }

            [SpedCampos(18, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal AliqCofins { get; set; }

            [SpedCampos(19, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            [SpedCampos(20, "PERC_REC_RECEB", "N", 6, 2, false)]
            public decimal PercRecReceb { get; set; }

            [SpedCampos(21, "IND_NAT_EMP", "N", 1, 0, false)]
            public int IndNatEmp { get; set; }

            [SpedCampos(22, "INF_COMP", "C", 90, 0, false)]
            public string InfComp { get; set; }
        }

        /// <summary>
        /// CONSOLIDAÇÃO DAS OPERAÇÕES DA PESSOA JURÍDICA SUBMETIDA AO REGIME DE TRIBUTAÇÃO COM BASE NO LUCRO PRESUMIDO  – INCIDÊNCIA DO PIS/PASEP E DA COFINS PELO REGIME DE CAIXA
        /// </summary>
        public class RegistroF500 : RegistroBaseSped
        {
            public RegistroF500()
            {
                Reg = "F500";
            }

            [SpedCampos(2, "VL_REC_CAIXA", "N", int.MaxValue, 2, true)]
            public decimal VlRecCaixa { get; set; }

            [SpedCampos(3, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(4, "VL_DESC_PIS", "N", int.MaxValue, 2, false)]
            public decimal VlDescPis { get; set; }

            [SpedCampos(5, "VL_BC_PIS", "N", int.MaxValue, 2, false)]
            public decimal VlBcPis { get; set; }

            [SpedCampos(6, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal AliqPis { get; set; }

            [SpedCampos(7, "VL_PIS", "N", int.MaxValue, 2, false)]
            public decimal VlPis { get; set; }

            [SpedCampos(8, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(9, "VL_DESC_COFINS", "N", int.MaxValue, 2, false)]
            public decimal VlDescCofins { get; set; }

            [SpedCampos(10, "VL_BC_COFINS", "N", int.MaxValue, 2, false)]
            public decimal VlBcCofins { get; set; }

            [SpedCampos(11, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal AliqCofins { get; set; }

            [SpedCampos(12, "VL_COFINS", "N", int.MaxValue, 2, false)]
            public decimal VlCofins { get; set; }

            [SpedCampos(13, "COD_MOD", "C", 2, 0, false)]
            public int? CodMod { get; set; }

            [SpedCampos(14, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            [SpedCampos(15, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            [SpedCampos(16, "INFO_COMPL", "C", int.MaxValue, 0, false)]
            public string InfoCompl { get; set; }
        }

        public class RegistroF525 : RegistroBaseSped
        {
            public RegistroF525()
            {
                Reg = "F525";
            }

            [SpedCampos(2, "VL_REC", "N", int.MaxValue, 2, true)]
            public decimal VlRec { get; set; }

            [SpedCampos(3, "IND_REC", "C", 2, 0, true)]
            public int IndRec { get; set; }

            [SpedCampos(4, "CNPJ_CPF", "C", 14, 0, false)]
            public string CnpjCpf { get; set; }

            [SpedCampos(5, "NUM_DOC", "C", 60, 0, false)]
            public string NumDoc { get; set; }

            [SpedCampos(6, "VL_REC,DET", "C", 60, 0, false)]
            public string CodItem { get; set; }

            [SpedCampos(7, "VL_REC_DET", "N", int.MaxValue, 2, true)]
            public decimal VlRecDet { get; set; }

            [SpedCampos(8, "CST_PIS", "N", 2, 0, false)]
            public int CstPis { get; set; }

            [SpedCampos(9, "CST_COFINS", "N", 2, 0, false)]
            public int CstCofins { get; set; }

            [SpedCampos(10, "INFO_COMPL", "C", 0, 0, false)]
            public string InfoCompl { get; set; }

            [SpedCampos(11, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class RegistroF550 : RegistroBaseSped
        {
            public RegistroF550()
            {
                Reg = "F550";
            }

            [SpedCampos(2, "VL_REC_COMP", "N", int.MaxValue, 2, true)]
            public decimal VlRecComp { get; set; }

            [SpedCampos(3, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(4, "VL_DESC_PIS", "N", int.MaxValue, 2, false)]
            public decimal VlDescPis { get; set; }

            [SpedCampos(5, "VL_BC_PIS", "N", int.MaxValue, 2, false)]
            public decimal VlBcPis { get; set; }

            [SpedCampos(6, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal AliqPis { get; set; }

            [SpedCampos(7, "VL_PIS", "N", int.MaxValue, 2, false)]
            public decimal VlPis { get; set; }

            [SpedCampos(8, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(9, "VL_DESC_COFINS", "N", int.MaxValue, 2, false)]
            public decimal VlDescCofins { get; set; }

            [SpedCampos(10, "VL_BC_COFINS", "N", int.MaxValue, 2, false)]
            public decimal VlBcCofins { get; set; }

            [SpedCampos(11, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal AliqCofins { get; set; }

            [SpedCampos(12, "VL_COFINS", "N", int.MaxValue, 2, false)]
            public decimal VlCofins { get; set; }

            [SpedCampos(13, "COD_MOD", "C", 2, 0, false)]
            public int? CodMod { get; set; }

            [SpedCampos(14, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            [SpedCampos(15, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            [SpedCampos(16, "INFO_COMPL", "C", 0, 0, false)]
            public string InfoCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO F560: CONSOLIDAÇÃO DAS OPERAÇÕES DA PESSOA JURÍDICA SUBMETIDA AO REGIME 
        ///     DE TRIBUTAÇÃO COM BASE NO LUCRO PRESUMIDO – INCIDÊNCIA DO PIS/PASEP E DA COFINS 
        ///     PELO REGIME DE COMPETÊNCIA (APURAÇÃO DA CONTRIBUIÇÃO POR UNIDADE DE MEDIDA DE PRODUTO
        ///     – ALÍQUOTA EM REAIS)
        /// </summary>
        public class RegistroF560 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroF560" />.
            /// </summary>
            public RegistroF560()
            {
                Reg = "F560";
            }

            /// <summary>
            ///     Valor total da receita auferida, referente à combinação de CST e Alíquota.
            /// </summary>
            [SpedCampos(2, "VL_REC_COMP", "N", int.MaxValue, 2, true)]
            public decimal VlRecComp { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao PIS/PASEP 
            /// </summary>
            [SpedCampos(3, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor do desconto / exclusão
            /// </summary>
            [SpedCampos(4, "VL_DESC_PIS", "N", int.MaxValue, 2, false)]
            public decimal? VlDescPis { get; set; }

            /// <summary>
            ///     Base de cálculo em quantidade - PIS/PASEP
            /// </summary>
            [SpedCampos(5, "QUANT_BC_PIS", "N", int.MaxValue, 3, false)]
            public decimal? QuantBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em reais)
            /// </summary>
            [SpedCampos(6, "ALIQ_PIS_QUANT", "N", 8, 4, false)]
            public decimal? AliqPisQuant { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(7, "VL_PIS", "N", int.MaxValue, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente a COFINS
            /// </summary>
            [SpedCampos(8, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Valor do desconto / exclusão
            /// </summary>
            [SpedCampos(9, "VL_DESC_COFINS", "N", int.MaxValue, 2, false)]
            public decimal? VlDescCofins { get; set; }

            /// <summary>
            ///      Base de cálculo em quantidade - COFINS
            /// </summary>
            [SpedCampos(10, "QUANT_BC_COFINS", "N", int.MaxValue, 3, false)]
            public decimal? QuantBcCofins { get; set; }

            /// <summary>
            ///     Alíquota do COFINS (em reais)
            /// </summary>
            [SpedCampos(11, "ALIQ_COFINS_QUANT", "N", 8, 4, false)]
            public decimal? AliqCofinsQuant { get; set; }

            /// <summary>
            ///     Valor do COFINS
            /// </summary>
            [SpedCampos(12, "VL_COFINS", "N", int.MaxValue, 2, false)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(13, "COD_MOD", "C", 2, 0, false)]
            public int? CodMod { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(14, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada / creditada 
            /// </summary>
            [SpedCampos(15, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Informação complementar 
            /// </summary>
            [SpedCampos(16, "INFO_COMPL", "C", int.MaxValue, 0, false)]
            public string InfoCompl { get; set; }
        }

        /// <summary>
        /// CONTRIBUIÇÃO RETIDA NA FONTE
        /// </summary>
        public class RegistroF600 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroF600" />.
            /// </summary>
            public RegistroF600()
            {
                Reg = "F600";
            }

            /// <summary>
            /// Indicador de Natureza da Retenção na Fonte
            /// </summary>
            /// <remarks>
            /// 01 - Retenção por Órgãos, Autarquias e Fundações Federais
            /// <para />
            /// 02 - Retenção por outras Entidades da Administração Pública Federal
            /// <para />
            /// 03 - Retenção por Pessoas Jurídicas de Direito Privado
            /// <para />
            /// 04 - Recolhimento por Sociedade Cooperativa
            /// <para />
            /// 05 - Retenção por Fabricante de Máquinas e Veículos
            /// <para />
            /// 99 - Outras Retenções
            /// </remarks>
            [SpedCampos(2, "IND_NAT_RET", "N", 2, 0, true)]
            public int IndNatRet { get; set; }

            /// <summary>
            /// Data da retenção
            /// </summary>
            [SpedCampos(3, "DT_RET", "N", 8, 0, true)]
            public DateTime DtRet { get; set; }

            /// <summary>
            /// Base de cálculo da retenção ou do acolhimento (sociedade cooperativa)
            /// </summary>
            [SpedCampos(4, "VL_BC_RET", "N", int.MaxValue, 4, true)]
            public decimal VlBcRet { get; set; }

            /// <summary>
            /// Valor total retido na fonte / recolhido (sociedade cooperativa)
            /// </summary>
            [SpedCampos(5, "VL_RET", "N", int.MaxValue, 2, true)]
            public decimal VlRet { get; set; }

            /// <summary>
            /// Código da receita
            /// </summary>
            [SpedCampos(6, "COD_REC", "C", 4, 0, false)]
            public string CodRec { get; set; }

            /// <summary>
            /// Indicador da natureza da receita
            /// </summary>
            /// <remarks>
            /// 0 - Receita de Natureza Não Cumulativa
            /// <para />
            /// 1 - Receita de Natureza Cumulativa
            /// </remarks>
            [SpedCampos(7, "IND_NAT_REC", "N", 1, 0, false)]
            public int? IndNatRec { get; set; }

            /// <summary>
            /// CNPJ da fonte pagadora ou da PJ beneficiária
            /// </summary>
            /// <remarks>
            /// - Fonte pagadora responsável pela retenção / recolhimento (no caso de o registro ser escriturado pela pessoa jurídica beneficiária da retenção); ou
            /// <para />
            /// - Pessoa jurídica beneficiária da retenção / recolhimento (no caso de o registro ser escriturado pela pessoa jurídica responsável pela retenção).
            /// </remarks>
            [SpedCampos(8, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            /// <summary>
            /// Valor retido na fonte - parcela referente ao PIS/Pasep
            /// </summary>
            [SpedCampos(9, "VL_RET_PIS", "N", int.MaxValue, 2, true)]
            public decimal VlRetPis { get; set; }

            /// <summary>
            /// Valor retido na fonte - parcela referente a COFINS
            /// </summary>
            [SpedCampos(10, "VL_RET_COFINS", "N", int.MaxValue, 2, true)]
            public decimal VlRetCofins { get; set; }

            /// <summary>
            /// Indicador da condição da pessoa jurídica declarante
            /// </summary>
            /// <remarks>
            /// 0 - Beneficiária da retenção / recolhimento
            /// <para />
            /// 1 - Responsável pelo recolhimento
            /// </remarks>
            [SpedCampos(11, "IND_DEC", "N", 1, 0, true)]
            public int IndDec { get; set; }
        }

        /// <summary>
        ///     REGISTRO F700: DEDUÇÕES DIVERSAS
        /// </summary>
        public class RegistroF700 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroF700" />.
            /// </summary>
            public RegistroF700()
            {
                Reg = "F700";
            }

            /// <summary>
            ///     Indicador de Origem de Deduções Diversas: 
            ///     01 – Créditos Presumidos - Medicamentos 
            ///     02 – Créditos Admitidos no Regime Cumulativo – Bebidas Frias 
            ///     03 – Contribuição Paga pelo Substituto Tributário - ZFM 
            ///     04 – Substituição Tributária – Não Ocorrência do Fato Gerador Presumido 
            ///     99 - Outras Deduções 
            /// </summary>
            [SpedCampos(2, "IND_ORI_DED", "N", 2, 0, true)]
            public int IndOriDed { get; set; }

            /// <summary>
            ///     Indicador da Natureza da Dedução: 
            ///     0 – Dedução de Natureza Não Cumulativa 
            ///     1 – Dedução de Natureza Cumulativa
            /// </summary>
            [SpedCampos(3, "IND_NAT_DED", "N", 1, 0, true)]
            public int IndNatDed { get; set; }

            /// <summary>
            ///     Valor a Deduzir - PIS/PASEP
            /// </summary>
            [SpedCampos(4, "VL_DED_PIS", "N", int.MaxValue, 2, true)]
            public decimal VlDedPis { get; set; }

            /// <summary>
            ///     Valor a Deduzir – Cofins
            /// </summary>
            [SpedCampos(5, "VL_DED_COFINS", "N", int.MaxValue, 2, true)]
            public decimal VlDedCofins { get; set; }

            /// <summary>
            ///     Valor da Base de Cálculo da Operação que ensejou o Valor a Deduzir informado nos Campos 04 e 05
            /// </summary>
            [SpedCampos(6, "VL_BC_OPER", "N", int.MaxValue, 2, false)]
            public decimal? VlBcOper { get; set; }

            /// <summary>
            ///     CNPJ da Pessoa Jurídica relacionada à Operação que ensejou o Valor a Deduzir informado nos Campos 04 e 05.
            /// </summary>
            [SpedCampos(7, "CNPJ", "N", 14, 0, false)]
            public string Cnpj { get; set; }

            /// <summary>
            ///     Informações Complementares do Documento/Operação que ensejou o Valor a Deduzir informado nos Campos 04 e 05.
            /// </summary>
            [SpedCampos(8, "INF_COMP", "C", 90, 0, false)]
            public string InfoComp { get; set; }
        }

        public class RegistroF990 : RegistroBaseSped
        {
            public RegistroF990()
            {
                Reg = "F990";
            }

            [SpedCampos(2, "QTD_LIN_F", "N", int.MaxValue, 0, true)]
            public int QtdLinF { get; set; }
        }
    }
}
