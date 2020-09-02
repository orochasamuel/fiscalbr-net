using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.ECF
{
    public class BlocoY
    {
        public class RegY001 : RegistroBaseSped
        {
            public RegY001()
            {
                Reg = "Y001";
            }

            [SpedCampos(2, "IND_DAD", "N", 1, 0, true)]
            public int IndDad { get; set; }
        }

        public class RegY520 : RegistroBaseSped
        {
            public RegY520()
            {
                Reg = "Y520";
            }

            [SpedCampos(2, "TIP_EXT", "C", 1, 0, true)]
            public string TipExt { get; set; }

            [SpedCampos(3, "PAIS", "N", 3, 0, true)]
            public int Pais { get; set; }

            [SpedCampos(4, "FORMA", "N", 1, 0, true)]
            public int Forma { get; set; }

            [SpedCampos(5, "NAT_OPER", "N", 5, 0, true)]
            public int NatOper { get; set; }

            [SpedCampos(6, "VL_PERIODO", "N", 19, 2, true)]
            public int VlPeriodo { get; set; }
        }

        public class RegY540 : RegistroBaseSped
        {
            public RegY540()
            {
                Reg = "Y540";
            }

            [SpedCampos(2, "CNPJ_ESTAB", "C", 14, 0, true)]
            public string CnpjEstab { get; set; }

            [SpedCampos(3, "VL_REC_ESTAB", "NS", 19, 2, true)]
            public decimal VlRecEstab { get; set; }

            [SpedCampos(4, "CNAE", "N", 7, 0, true)]
            public int Cnae { get; set; }
        }

        public class RegY550 : RegistroBaseSped
        {
            public RegY550()
            {
                Reg = "Y550";
            }

            [SpedCampos(2, "CNPJ_EXP", "C", 14, 0, true)]
            public string CnpjExp { get; set; }

            [SpedCampos(3, "COD_NCM", "N", 8, 0, true)]
            public int CodNcm { get; set; }

            [SpedCampos(4, "VL_VENDA", "N", 19, 2, true)]
            public decimal VlVenda { get; set; }
        }

        public class RegY560 : RegistroBaseSped
        {
            public RegY560()
            {
                Reg = "Y560";
            }

            [SpedCampos(2, "CNPJ", "C", 14, 0, true)]
            public string Cnpj { get; set; }

            [SpedCampos(3, "COD_NCM", "N", 8, 0, true)]
            public int CodNcm { get; set; }

            [SpedCampos(4, "VL_COMPRA", "N", 19, 2, false)]
            public decimal? VlCompra { get; set; }

            [SpedCampos(5, "VL_EXP", "N", 19, 2, false)]
            public decimal? VlExp { get; set; }
        }

        public class RegY570 : RegistroBaseSped
        {
            public RegY570()
            {
                Reg = "Y570";
            }

            [SpedCampos(2, "CNPJ_FON", "C", 14, 0, true)]
            public string CnpjFon { get; set; }

            [SpedCampos(3, "NOM_EMP", "C", 0, 0, true)]
            public string NomEmp { get; set; }

            [SpedCampos(4, "IND_ORG_PUB", "C", 1, 0, true)]
            public string IndOrgPub { get; set; }

            [SpedCampos(5, "COD_REC", "N", 4, 0, true)]
            public int CodRec { get; set; }

            [SpedCampos(6, "VL_REND", "N", 19, 2, true)]
            public decimal VlRend { get; set; }

            [SpedCampos(7, "IR_RET", "N", 19, 2, false)]
            public decimal? IrRet { get; set; }

            [SpedCampos(8, "CSLL_RET", "N", 19, 2, false)]
            public decimal? CsllRet { get; set; }
        }

        public class RegY580 : RegistroBaseSped
        {
            public RegY580()
            {
                Reg = "Y580";
            }

            [SpedCampos(2, "CNPJ", "C", 14, 0, true)]
            public string Cnpj { get; set; }

            [SpedCampos(3, "TIP_BENEF", "N", 2, 0, true)]
            public int TipBenef { get; set; }

            [SpedCampos(4, "FORM_DOA", "N", 2, 0, true)]
            public int FormDoa { get; set; }

            [SpedCampos(5, "VL_DOA", "N", 19, 2, true)]
            public decimal VlDoa { get; set; }
        }

        public class RegY590 : RegistroBaseSped
        {
            public RegY590()
            {
                Reg = "Y590";
            }

            [SpedCampos(2, "TIP_ATIVO", "C", 14, 0, true)]
            public string TipAtivo { get; set; }

            [SpedCampos(3, "PAIS", "N", 3, 0, true)]
            public int Pais { get; set; }

            [SpedCampos(4, "DISCRIMINACAO", "C", 0, 0, true)]
            public string Discriminacao { get; set; }

            [SpedCampos(5, "VL_ANT", "N", 19, 2, true)]
            public decimal VlAnt { get; set; }

            [SpedCampos(6, "VL_ATUAL", "N", 19, 2, true)]
            public decimal VlAtual { get; set; }
        }

        public class RegY600 : RegistroBaseSped
        {
            public RegY600()
            {
                Reg = "Y600";
            }

            [SpedCampos(2, "DT_ALT_SOC", "N", 8, 0, true)]
            public DateTime DtAltSoc { get; set; }

            [SpedCampos(3, "DT_FIM_SOC", "N", 8, 0, false)]
            public DateTime? DtFimSoc { get; set; }

            [SpedCampos(4, "PAIS", "N", 3, 0, true)]
            public int Pais { get; set; }

            [SpedCampos(5, "IND_QUALIF", "C", 2, 0, true)]
            public string IndQualif { get; set; }

            [SpedCampos(6, "CPF_CNPJ", "N", 14, 0, false)]
            public string CpfCnpj { get; set; }

            [SpedCampos(7, "NOM_EMP", "C", 0, 0, true)]
            public string NomEmp { get; set; }

            [SpedCampos(8, "QUALIF", "C", 2, 0, true)]
            public string Qualif { get; set; }

            [SpedCampos(9, "PERC_CAP_TOT", "N", 8, 4, true)]
            public decimal PercCapTot { get; set; }

            [SpedCampos(10, "PERC_CAP_VOT", "N", 8, 4, true)]
            public decimal PercCapVot { get; set; }

            [SpedCampos(11, "CPF_REP_LEG", "N", 11, 0, false)]
            public string CpfRepLeg { get; set; }

            [SpedCampos(12, "QUALIF_REP_LEG", "N", 2, 0, false)]
            public int? QualifRepLeg { get; set; }

            [SpedCampos(13, "VL_REM_TRAB", "N", 19, 2, false)]
            public decimal? VlRemTrab { get; set; }

            [SpedCampos(14, "VL_LUC_DIV", "N", 19, 2, false)]
            public decimal? VlLucDiv { get; set; }

            [SpedCampos(15, "VL_JUR_CAP", "N", 19, 2, false)]
            public decimal? VlJurCap { get; set; }

            [SpedCampos(16, "VL_DEM_REND", "N", 19, 2, false)]
            public decimal? VlDemRend { get; set; }

            [SpedCampos(17, "VL_IR_RET", "N", 19, 2, false)]
            public decimal? VlIrRet { get; set; }
        }

        public class RegY612 : RegistroBaseSped
        {
            public RegY612()
            {
                Reg = "Y612";
            }

            [SpedCampos(2, "CPF", "N", 11, 0, true)]
            public string Cpf { get; set; }

            [SpedCampos(3, "NOME", "C", 0, 0, true)]
            public string Nome { get; set; }

            [SpedCampos(4, "QUALIF", "N", 2, 0, true)]
            public int Qualif { get; set; }

            [SpedCampos(5, "VL_REM_TRAB", "N", 19, 2, false)]
            public decimal? VlRemTrab { get; set; }

            [SpedCampos(6, "VL_DEM_REND", "N", 19, 2, false)]
            public decimal? VlDemRend { get; set; }

            [SpedCampos(7, "VL_IR_RET", "N", 19, 2, false)]
            public decimal? VlIrRet { get; set; }
        }

        public class RegY620 : RegistroBaseSped
        {
            public RegY620()
            {
                Reg = "Y620";
            }

            [SpedCampos(2, "DT_EVENTO", "N", 8, 0, true)]
            public DateTime DtEvento { get; set; }

            [SpedCampos(3, "IND_RELAC", "N", 1, 0, true)]
            public int IndRelac { get; set; }

            [SpedCampos(4, "PAIS", "N", 3, 0, true)]
            public int Pais { get; set; }

            [SpedCampos(5, "CNPJ", "C", 14, 0, false)]
            public string Cnpj { get; set; }

            [SpedCampos(6, "NOM_EMP", "C", 0, 0, true)]
            public string NomEmp { get; set; }

            [SpedCampos(7, "VALOR_REAIS", "NS", 19, 2, true)]
            public decimal ValorReais { get; set; }

            [SpedCampos(8, "VALOR_ESTR", "NS", 19, 2, true)]
            public decimal ValorEstr { get; set; }

            [SpedCampos(9, "PERC_CAP_TOT", "N", 8, 4, true)]
            public decimal PercCapTot { get; set; }

            [SpedCampos(10, "PERC_CAP_VOT", "N", 8, 4, true)]
            public decimal PercCapVot { get; set; }

            [SpedCampos(11, "RES_EQ_PAT", "NS", 19, 2, false)]
            public decimal? ResEqPat { get; set; }

            [SpedCampos(12, "DATA_AQUIS", "N", 8, 0, true)]
            public DateTime DataAquis { get; set; }

            [SpedCampos(13, "IND_PROC_CART", "C", 1, 0, true)]
            public string IndProcCart { get; set; }

            [SpedCampos(14, "NUM_PROC_CART", "C", 0, 0, false)]
            public string NumProcCart { get; set; }

            [SpedCampos(15, "NOME_CART", "C", 0, 0, false)]
            public string NomeCart { get; set; }

            [SpedCampos(16, "IND_PROC_RFB", "C", 1, 0, true)]
            public string IndProcRfb { get; set; }

            [SpedCampos(17, "NUM_PROC_RFB", "C", 0, 0, false)]
            public string NumProcRfb { get; set; }
        }

        public class RegY630 : RegistroBaseSped
        {
            public RegY630()
            {
                Reg = "Y630";
            }

            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            [SpedCampos(3, "QTE_QUOT", "N", 0, 0, true)]
            public int QteQuot { get; set; }

            [SpedCampos(4, "QTE_QUOTA", "N", 0, 0, true)]
            public int QteQuota { get; set; }

            [SpedCampos(5, "PATR_FIN_PER", "N", 19, 2, true)]
            public decimal PatrFinPer { get; set; }

            [SpedCampos(6, "DAT_ABERT", "N", 8, 0, true)]
            public DateTime DatAbert { get; set; }

            [SpedCampos(7, "DAT_ENCER", "N", 8, 0, false)]
            public DateTime? DatEncer { get; set; }
        }

        public class RegY640 : RegistroBaseSped
        {
            public RegY640()
            {
                Reg = "Y640";
            }

            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            [SpedCampos(3, "COND_DECL", "N", 1, 0, true)]
            public int CondDecl { get; set; }

            [SpedCampos(4, "VL_CONS", "N", 19, 2, false)]
            public decimal? VlCons { get; set; }

            [SpedCampos(5, "CNPJ_LID", "C", 14, 0, true)]
            public string CnpjLid { get; set; }

            [SpedCampos(6, "VL_DECL", "N", 19, 2, true)]
            public decimal VlDecl { get; set; }
        }

        public class RegY650 : RegistroBaseSped
        {
            public RegY650()
            {
                Reg = "Y650";
            }

            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            [SpedCampos(3, "VL_PART", "N", 19, 2, true)]
            public decimal VlPart { get; set; }
        }

        public class RegY660 : RegistroBaseSped
        {
            public RegY660()
            {
                Reg = "Y660";
            }

            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            [SpedCampos(3, "NOM_EMP", "C", 0, 0, true)]
            public string NomEmp { get; set; }

            [SpedCampos(4, "PERC_PAT_LIQ", "N", 8, 4, false)]
            public decimal? PercPatLiq { get; set; }
        }

        public class RegY671 : RegistroBaseSped
        {
            public RegY671()
            {
                Reg = "Y671";
            }

            [SpedCampos(2, "VL_AQ_MAQ", "N", 19, 2, false)]
            public decimal? VlAqMaq { get; set; }

            [SpedCampos(3, "VL_DOA_CRIANCA", "N", 19, 2, false)]
            public decimal? VlDoaCrianca { get; set; }

            [SpedCampos(4, "VL_DOA_IDOSO", "N", 19, 2, false)]
            public decimal? VlDoaIdoso { get; set; }

            [SpedCampos(5, "VL_AQ_IMOBILIZADO", "N", 19, 2, false)]
            public decimal? VlAqImobilizado { get; set; }

            [SpedCampos(6, "VL_BX_IMOBILIZADO", "N", 19, 2, false)]
            public decimal? VlBxImobilizado { get; set; }

            [SpedCampos(7, "VL_INC_INI", "N", 19, 2, false)]
            public decimal? VlIncIni { get; set; }

            [SpedCampos(8, "VL_INC_FIN", "N", 19, 2, false)]
            public decimal? VlIncFin { get; set; }

            [SpedCampos(9, "VL_CSLL_DEPREC_INI", "N", 19, 2, false)]
            public decimal? VlCsllDeprecIni { get; set; }

            [SpedCampos(10, "VL_OC_SEM_IOF", "N", 19, 2, false)]
            public decimal? VlOcSemIof { get; set; }

            [SpedCampos(11, "VL_FOLHA_ALIQ_RED", "N", 19, 2, false)]
            public decimal? VlFolhaAliqRed { get; set; }

            [SpedCampos(12, "VL_ALIQ_RED", "N", 8, 4, false)]
            public decimal? VlAliqRed { get; set; }

            [SpedCampos(13, "IND_ALTER_CAPITAL", "N", 1, 0, false)]
            public int? IndAlterCapital { get; set; }

            [SpedCampos(14, "IND_BCN_CSLL", "N", 1, 0, false)]
            public int? IndBcnCsll { get; set; }
        }

        public class RegY672 : RegistroBaseSped
        {
            public RegY672()
            {
                Reg = "Y672";
            }

            [SpedCampos(2, "VL_CAPITAL_ANT", "N", 19, 2, false)]
            public decimal? VlCapitalAnt { get; set; }

            [SpedCampos(3, "VL_CAPITAL", "N", 19, 2, false)]
            public decimal? VlCapital { get; set; }

            [SpedCampos(4, "VL_ESTOQUE_ANT", "N", 19, 2, false)]
            public decimal? VlEstoqueAnt { get; set; }

            [SpedCampos(5, "VL_ESTOQUES", "N", 19, 2, false)]
            public decimal? VlEstoques { get; set; }

            [SpedCampos(6, "VL_CAIXA_ANT", "N", 19, 2, false)]
            public decimal? VlCaixaAnt { get; set; }

            [SpedCampos(7, "VL_CAIXA", "N", 19, 2, false)]
            public decimal? VlCaixa { get; set; }

            [SpedCampos(8, "VL_APLIC_FIN_ANT", "N", 19, 2, false)]
            public decimal? VlAplicFinAnt { get; set; }

            [SpedCampos(9, "VL_APLIC_FIN", "N", 19, 2, false)]
            public decimal? VlAplicFin { get; set; }

            [SpedCampos(10, "VL_CTA_REC_ANT", "N", 19, 2, false)]
            public decimal? VlCtaRecAnt { get; set; }

            [SpedCampos(11, "VL_CTA_REC", "N", 19, 2, false)]
            public decimal? VlCtaRec { get; set; }

            [SpedCampos(12, "VL_CTA_PAG_ANT", "N", 19, 2, false)]
            public decimal? VlCtaPagAnt { get; set; }

            [SpedCampos(13, "VL_CTA_PAG", "N", 19, 2, false)]
            public decimal? VlCtaPag { get; set; }

            [SpedCampos(14, "VL_COMPRA_MERC", "N", 19, 2, false)]
            public decimal? VlCompraMerc { get; set; }

            [SpedCampos(15, "VL_COMPRA_ATIVO", "N", 19, 2, false)]
            public decimal? VlCompraAtivo { get; set; }

            [SpedCampos(16, "VL_RECEITAS", "N", 19, 2, false)]
            public decimal? VlReceitas { get; set; }

            [SpedCampos(17, "TOT_ATIVO", "N", 19, 2, false)]
            public decimal? TotAtivo { get; set; }

            [SpedCampos(18, "VL_FOLHA", "N", 19, 2, false)]
            public decimal? VlFolha { get; set; }

            [SpedCampos(19, "VL_ALIQ_RED", "N", 8, 4, false)]
            public decimal? VlAliqRed { get; set; }

            [SpedCampos(20, "IND_AVAL_ESTOQ", "C", 1, 0, false)]
            public string IndAvalEstoq { get; set; }
        }

        public class RegY680 : RegistroBaseSped
        {
            public RegY680()
            {
                Reg = "Y680";
            }

            [SpedCampos(2, "MES", "C", 2, 0, true)]
            public int Mes { get; set; }
        }

        public class RegY681 : RegistroBaseSped
        {
            public RegY681()
            {
                Reg = "Y681";
            }

            [SpedCampos(2, "CODIGO", "C", 6, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegY682 : RegistroBaseSped
        {
            public RegY682()
            {
                Reg = "Y682";
            }

            [SpedCampos(2, "MES", "C", 2, 0, true)]
            public int Mes { get; set; }

            [SpedCampos(3, "ACRES_PATR", "N", 19, 2, true)]
            public decimal AcresPatr { get; set; }
        }

        public class RegY690 : RegistroBaseSped
        {
            public RegY690()
            {
                Reg = "Y690";
            }

            [SpedCampos(2, "MES", "C", 2, 0, true)]
            public int Mes { get; set; }

            [SpedCampos(3, "VL_REC_BRU", "N", 19, 2, true)]
            public decimal VlRecBru { get; set; }
        }

        public class RegY720 : RegistroBaseSped
        {
            public RegY720()
            {
                Reg = "Y720";
            }

            [SpedCampos(2, "LUC_LIQ", "N", 19, 2, true)]
            public decimal LucLiq { get; set; }

            [SpedCampos(3, "DT_LUC_LIQ", "N", 8, 0, true)]
            public DateTime DtLucLiq { get; set; }

            [SpedCampos(4, "REC_BRUT_ANT", "N", 19, 2, true)]
            public decimal RecBrutAnt { get; set; }
        }

        public class RegY800 : RegistroBaseSped
        {
            public RegY800()
            {
                Reg = "Y800";
            }

            [SpedCampos(2, "TIPO_DOC", "N", 3, 0, true)]
            public int TipoDoc { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, true)]
            public string Descricao { get; set; }

            [SpedCampos(4, "HASH", "C", 41, 0, true)]
            public string Hash { get; set; }

            [SpedCampos(5, "ARQ_RTF", "C", 0, 0, true)]
            public string ArqRtf { get; set; }

            [SpedCampos(6, "IND_FIM_RTF", "C", 7, 0, true)]
            public string IndFimRtf { get; set; }
        }

        public class RegY990 : RegistroBaseSped
        {
            public RegY990()
            {
                Reg = "Y990";
            }

            [SpedCampos(2, "QTD_LIN", "N", 0, 0, true)]
            public int QtdLin { get; set; }
        }
    }
}