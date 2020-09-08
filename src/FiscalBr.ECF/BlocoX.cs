using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.ECF
{
    public class BlocoX
    {
        public class RegX001 : RegistroBaseSped
        {
            public RegX001()
            {
                Reg = "X001";
            }

            [SpedCampos(2, "IND_DAD", "N", 1, 0, true)]
            public int IndDad { get; set; }
        }

        public class RegX280 : RegistroBaseSped
        {
            public RegX280()
            {
                Reg = "X280";
            }

            [SpedCampos(2, "IND_ATIV", "C", 2, 0, true)]
            public string IndAtiv { get; set; }

            [SpedCampos(3, "IND_PROJ", "C", 2, 0, true)]
            public string IndProj { get; set; }

            [SpedCampos(4, "ATO_CONC", "C", 30, 0, true)]
            public string AtoConc { get; set; }

            [SpedCampos(5, "VIG_INI", "N", 8, 0, true)]
            public string VigIni { get; set; }

            [SpedCampos(6, "VIG_FIM", "N", 8, 0, true)]
            public string VigFim { get; set; }
        }

        public class RegX291 : RegistroBaseSped
        {
            public RegX291()
            {
                Reg = "X291";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegX292 : RegistroBaseSped
        {
            public RegX292()
            {
                Reg = "X292";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegX300 : RegistroBaseSped
        {
            public RegX300()
            {
                Reg = "X300";
            }

            [SpedCampos(2, "NUM_ORDEM", "C", 0, 0, true)]
            public string NumOrdem { get; set; }

            [SpedCampos(3, "TIP_EXP", "N", 2, 0, true)]
            public int TipExp { get; set; }

            [SpedCampos(4, "DESC_EXP", "C", 0, 0, false)]
            public string DescExp { get; set; }

            [SpedCampos(5, "TOT_OPER", "N", 19, 2, false)]
            public decimal? TotOper { get; set; }

            [SpedCampos(6, "COD_NCM", "N", 8, 0, false)]
            public int? CodNcm { get; set; }

            [SpedCampos(7, "QTDE", "N", 2, 0, false)]
            public int? Qtde { get; set; }

            [SpedCampos(8, "UNI_MED", "C", 2, 0, false)]
            public string UniMed { get; set; }

            [SpedCampos(9, "IND_OPER", "C", 1, 0, false)]
            public string IndOper { get; set; }

            [SpedCampos(10, "TIP_MET", "C", 5, 0, false)]
            public string TipMet { get; set; }

            [SpedCampos(11, "VL_PAR", "N", 19, 2, false)]
            public decimal? VlPar { get; set; }

            [SpedCampos(12, "VL_PRAT", "N", 19, 2, false)]
            public decimal? VlPrat { get; set; }

            [SpedCampos(13, "VL_AJ", "N", 19, 2, false)]
            public decimal? VlAj { get; set; }

            [SpedCampos(14, "VL_JUR", "N", 19, 2, false)]
            public decimal? VlJur { get; set; }

            [SpedCampos(15, "VL_JUR_MIN", "N", 19, 4, false)]
            public decimal? VlJurMin { get; set; }

            [SpedCampos(16, "VL_JUR_MAX", "N", 19, 4, false)]
            public decimal? VlJurMax { get; set; }

            [SpedCampos(17, "COD_CNC", "N", 5, 0, false)]
            public int? CodCnc { get; set; }

            [SpedCampos(18, "TIP_MOEDA", "C", 3, 0, false)]
            public string TipMoeda { get; set; }
        }

        public class RegX310 : RegistroBaseSped
        {
            public RegX310()
            {
                Reg = "X310";
            }

            [SpedCampos(2, "NOME", "C", 0, 0, true)]
            public string Nome { get; set; }

            [SpedCampos(3, "PAIS", "C", 0, 0, true)]
            public string Pais { get; set; }

            [SpedCampos(4, "VL_OPER", "N", 19, 2, true)]
            public decimal VlOper { get; set; }

            [SpedCampos(5, "COND_PES", "N", 2, 0, true)]
            public int CondPes { get; set; }
        }

        public class RegX320 : RegistroBaseSped
        {
            public RegX320()
            {
                Reg = "X320";
            }

            [SpedCampos(2, "NUM_ORD", "C", 0, 0, true)]
            public string NumOrd { get; set; }

            [SpedCampos(3, "TIP_IMP", "N", 2, 0, true)]
            public int TipImp { get; set; }

            [SpedCampos(4, "DESC_IMP", "C", 0, 0, false)]
            public string DescImp { get; set; }

            [SpedCampos(5, "TOT_OPER", "N", 19, 2, false)]
            public decimal? TotOper { get; set; }

            [SpedCampos(6, "COD_NCM", "N", 8, 0, false)]
            public int? CodNcm { get; set; }

            [SpedCampos(7, "QTDE", "N", 19, 2, false)]
            public decimal? Qtde { get; set; }

            [SpedCampos(8, "UNI_MED", "C", 2, 0, false)]
            public string UniMed { get; set; }

            [SpedCampos(9, "TIP_MET", "C", 5, 0, false)]
            public string TipMet { get; set; }

            [SpedCampos(10, "VL_PAR", "N", 19, 2, false)]
            public decimal? VlPar { get; set; }

            [SpedCampos(11, "VL_PRAT", "N", 19, 2, false)]
            public decimal? VlPrat { get; set; }

            [SpedCampos(12, "VL_AJ", "N", 19, 2, true)]
            public decimal VlAj { get; set; }

            [SpedCampos(13, "VL_JUR", "N", 19, 2, false)]
            public decimal? VlJur { get; set; }

            [SpedCampos(14, "VL_JUR_MIN", "N", 7, 4, false)]
            public decimal? VlJurMin { get; set; }

            [SpedCampos(15, "VL_JUR_MAX", "N", 7, 4, false)]
            public decimal? VlJurMax { get; set; }

            [SpedCampos(16, "COD_CNC", "C", 5, 0, false)]
            public string CodCnc { get; set; }
        }

        public class RegX330 : RegistroBaseSped
        {
            public RegX330()
            {
                Reg = "X330";
            }

            [SpedCampos(2, "NOME", "C", 0, 0, true)]
            public string Nome { get; set; }

            [SpedCampos(3, "PAIS", "C", 0, 0, true)]
            public string Pais { get; set; }

            [SpedCampos(4, "VL_OPER", "N", 19, 2, true)]
            public decimal VlOper { get; set; }

            [SpedCampos(5, "COND_PES", "N", 2, 0, true)]
            public int CondPes { get; set; }
        }

        public class RegX340 : RegistroBaseSped
        {
            public RegX340()
            {
                Reg = "X340";
            }

            [SpedCampos(2, "RAZ_SOCIAL", "C", 0, 0, true)]
            public string RazaoSocial { get; set; }

            [SpedCampos(3, "NIF", "C", 0, 0, true)]
            public string Nif { get; set; }

            [SpedCampos(4, "IND_CONTROLE", "N", 2, 0, true)]
            public int IndControle { get; set; }

            [SpedCampos(5, "PAIS", "N", 3, 0, true)]
            public int Pais { get; set; }

            [SpedCampos(6, "IND_ISEN_PETR", "C", 0, 0, true)]
            public string IndIsenPetr { get; set; }

            [SpedCampos(7, "IND_CONSOL", "C", 0, 0, true)]
            public string IndConsol { get; set; }

            [SpedCampos(8, "MOT_NAO_CONSOL", "N", 0, 0, false)]
            public string MotNaoConsol { get; set; }

            [SpedCampos(9, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }
        }

        public class RegX350 : RegistroBaseSped
        {
            public RegX350()
            {
                Reg = "X350";
            }

            [SpedCampos(2, "REC_LIQ", "N", 19, 2, false)]
            public decimal? RecLiq { get; set; }

            [SpedCampos(3, "CUSTOS", "N", 19, 2, false)]
            public decimal? Custos { get; set; }

            [SpedCampos(4, "LUC_BRUTO", "NS", 19, 2, false)]
            public decimal? LucBruto { get; set; }

            [SpedCampos(5, "REC_AUFERIDAS", "N", 19, 2, false)]
            public decimal? RecAuferidas { get; set; }

            [SpedCampos(6, "REC_OUTRAS_OPER", "N", 19, 2, false)]
            public decimal? RecOutrasOper { get; set; }

            [SpedCampos(7, "DESP_BRASIL", "N", 19, 2, false)]
            public decimal? DespBrasil { get; set; }

            [SpedCampos(8, "DESP_OPER", "N", 19, 2, false)]
            public decimal? DespOper { get; set; }

            [SpedCampos(9, "LUC_OPER", "NS", 19, 2, false)]
            public decimal? LucOper { get; set; }

            [SpedCampos(10, "REC_PARTIC", "NS", 19, 2, false)]
            public decimal? RecPartic { get; set; }

            [SpedCampos(11, "REC_OUTRAS", "N", 19, 2, false)]
            public decimal? RecOutras { get; set; }

            [SpedCampos(12, "DESP_OUTRAS", "N", 19, 2, false)]
            public decimal? DespOutras { get; set; }

            [SpedCampos(13, "LUC_LIQ_ANT_IR", "NS", 19, 2, false)]
            public decimal? LucLiqAntIr { get; set; }

            [SpedCampos(14, "IMP_DEV", "NS", 19, 2, false)]
            public decimal? ImpDev { get; set; }

            [SpedCampos(15, "LUC_LIQ", "NS", 19, 2, false)]
            public decimal? LucLiq { get; set; }
        }

        public class RegX351 : RegistroBaseSped
        {
            public RegX351()
            {
                Reg = "X351";
            }

            [SpedCampos(2, "RES_INV_PER", "NS", 19, 2, false)]
            public decimal? ResInvPer { get; set; }

            [SpedCampos(3, "RES_INV_PER_REAL", "NS", 19, 2, false)]
            public decimal? ResInvPerReal { get; set; }

            [SpedCampos(4, "RES_ISEN_PETR_PER", "NS", 19, 2, false)]
            public decimal? ResIsenPetrPer { get; set; }

            [SpedCampos(5, "RES_ISEN_PETR_PER_REAL", "NS", 19, 2, false)]
            public decimal? ResIsenPetrPerReal { get; set; }

            [SpedCampos(6, "RES_NEG_ACUM", "N", 19, 2, false)]
            public decimal? ResNegAcum { get; set; }

            [SpedCampos(7, "RES_POS_TRIB", "N", 19, 2, false)]
            public decimal? ResPosTrib { get; set; }

            [SpedCampos(8, "RES_POS_TRIB_REAL", "N", 19, 2, false)]
            public decimal? ResPosTribReal { get; set; }

            [SpedCampos(9, "IMP_LUCR", "N", 19, 2, false)]
            public decimal? ImpLucr { get; set; }

            [SpedCampos(10, "IMP_LUCR_REAL", "N", 19, 2, false)]
            public decimal? ImpLucrReal { get; set; }

            [SpedCampos(11, "IMP_PAG_REND", "N", 19, 2, false)]
            public decimal? ImpPagRend { get; set; }

            [SpedCampos(12, "IMP_PAG_REND_REAL", "N", 19, 2, false)]
            public decimal? ImpPagRendReal { get; set; }

            [SpedCampos(13, "IMP_RET_EXT", "N", 19, 2, false)]
            public decimal? ImpRetExt { get; set; }

            [SpedCampos(14, "IMP_RET_EXT_REAL", "N", 19, 2, false)]
            public decimal? ImpRetExtReal { get; set; }

            [SpedCampos(15, "IMP_RET_BR", "N", 19, 2, false)]
            public decimal? ImpRetBr { get; set; }
        }

        public class RegX352 : RegistroBaseSped
        {
            public RegX352()
            {
                Reg = "X352";
            }

            [SpedCampos(2, "RES_PER", "NS", 19, 2, false)]
            public decimal? ResPer { get; set; }

            [SpedCampos(3, "RES_PER_REAL", "NS", 19, 2, false)]
            public decimal? ResPerReal { get; set; }

            [SpedCampos(4, "LUC_DISP", "N", 19, 2, false)]
            public decimal? LucDisp { get; set; }

            [SpedCampos(5, "LUC_DISP_REAL", "N", 19, 2, false)]
            public decimal? LucDispReal { get; set; }
        }

        public class RegX353 : RegistroBaseSped
        {
            public RegX353()
            {
                Reg = "X353";
            }

            [SpedCampos(2, "RES_NEG_UTIL", "N", 19, 2, false)]
            public decimal? ResNegUtil { get; set; }

            [SpedCampos(3, "RES_NEG_UTIL_REAL", "N", 19, 2, false)]
            public decimal? ResNegUtilReal { get; set; }

            [SpedCampos(4, "SALDO_RES_NEG_NAO_UTIL", "N", 19, 2, false)]
            public decimal? SaldoResNegNaoUtil { get; set; }

            [SpedCampos(5, "SALDO_RES_NEG_NAO_UTIL_REAL", "N", 19, 2, false)]
            public decimal? SaldoResNegNaoUtilReal { get; set; }
        }

        public class RegX354 : RegistroBaseSped
        {
            public RegX354()
            {
                Reg = "X354";
            }

            [SpedCampos(2, "RES_NEG", "N", 19, 2, false)]
            public decimal? ResNeg { get; set; }

            [SpedCampos(3, "RES_NEG_REAL", "N", 19, 2, false)]
            public decimal? ResNegReal { get; set; }

            [SpedCampos(4, "SALDO_RES_NEG", "N", 19, 2, false)]
            public decimal? SaldoResNeg { get; set; }
        }

        public class RegX355 : RegistroBaseSped
        {
            public RegX355()
            {
                Reg = "X355";
            }

            [SpedCampos(2, "REND_PASS_PROP", "N", 19, 2, false)]
            public decimal? RendPassProp { get; set; }

            [SpedCampos(3, "REND_PASS_PROP_REAL", "N", 19, 2, false)]
            public decimal? RendPassPropReal { get; set; }

            [SpedCampos(4, "REND_TOTAL", "N", 19, 2, false)]
            public decimal? RendTotal { get; set; }

            [SpedCampos(5, "REND_TOTAL_REAL", "N", 19, 2, false)]
            public decimal? RendTotalReal { get; set; }

            [SpedCampos(6, "REND_ATIV_PROP", "N", 19, 2, false)]
            public decimal? RendAtivProp { get; set; }

            [SpedCampos(7, "REND_ATIV_PROP_REAL", "N", 19, 2, false)]
            public decimal? RendAtivPropReal { get; set; }

            [SpedCampos(8, "PERCENTUAL", "N", 8, 4, false)]
            public decimal? Percentual { get; set; }
        }

        public class RegX356 : RegistroBaseSped
        {
            public RegX356()
            {
                Reg = "X356";
            }

            [SpedCampos(2, "PERC_PART", "N", 8, 4, false)]
            public decimal? PercPart { get; set; }

            [SpedCampos(3, "ATIVO_TOTAL", "N", 19, 2, false)]
            public decimal? AtivoTotal { get; set; }

            [SpedCampos(4, "PAT_LIQUIDO", "NS", 19, 2, false)]
            public decimal? PatLiquido { get; set; }
        }

        public class RegX390 : RegistroBaseSped
        {
            public RegX390()
            {
                Reg = "X390";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegX400 : RegistroBaseSped
        {
            public RegX400()
            {
                Reg = "X400";
            }

            [SpedCampos(2, "CODIGO", "C", 6, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegX410 : RegistroBaseSped
        {
            public RegX410()
            {
                Reg = "X410";
            }

            [SpedCampos(2, "PAIS", "N", 3, 0, true)]
            public int Pais { get; set; }

            [SpedCampos(3, "IND_HOME_DISP", "C", 1, 0, false)]
            public string IndHomeDisp { get; set; }

            [SpedCampos(4, "IND_SERV_DISP", "C", 1, 0, false)]
            public string IndServDisp { get; set; }
        }

        public class RegX420 : RegistroBaseSped
        {
            public RegX420()
            {
                Reg = "X420";
            }

            [SpedCampos(2, "TIP_ROY", "C", 1, 0, true)]
            public string TipRoy { get; set; }

            [SpedCampos(3, "PAIS", "N", 3, 0, true)]
            public int Pais { get; set; }

            [SpedCampos(4, "VL_EXPL_DIR_SW", "N", 19, 2, false)]
            public decimal? VlExplDirSw { get; set; }

            [SpedCampos(5, "VL_EXPL_DIR_AUT", "N", 19, 2, false)]
            public decimal? VlExpDirAut { get; set; }

            [SpedCampos(6, "VL_EXPL_MARCA", "N", 19, 2, false)]
            public decimal? VlExplMarca { get; set; }

            [SpedCampos(7, "VL_EXPL_PAT", "N", 19, 2, false)]
            public decimal? VlExplPat { get; set; }

            [SpedCampos(8, "VL_EXPL_KNOW", "N", 19, 2, false)]
            public decimal? VlExplKnow { get; set; }

            [SpedCampos(9, "VL_EXPL_FRANQ", "N", 19, 2, false)]
            public decimal? VlExplFranq { get; set; }

            [SpedCampos(10, "VL_EXPL_INT", "N", 19, 2, false)]
            public decimal? VlExplInt { get; set; }
        }

        public class RegX430 : RegistroBaseSped
        {
            public RegX430()
            {
                Reg = "X430";
            }

            [SpedCampos(2, "PAIS", "N", 3, 0, true)]
            public int Pais { get; set; }

            [SpedCampos(3, "VL_SERV_ASSIST", "N", 0, 2, false)]
            public decimal? VlServAssist { get; set; }

            [SpedCampos(4, "VL_SERV_SEM_ASSIST", "N", 19, 2, false)]
            public decimal? VlServSemAssist { get; set; }

            [SpedCampos(5, "VL_SERV_SEM_ASSIST_EXT", "N", 19, 2, false)]
            public decimal? VlServSemAssistExt { get; set; }

            [SpedCampos(6, "VL_JURO", "N", 19, 2, false)]
            public decimal? VlJuro { get; set; }

            [SpedCampos(7, "VL_DEMAIS_JUROS", "N", 19, 2, false)]
            public decimal? VlDemaisJuros { get; set; }

            [SpedCampos(8, "VL_DIVID", "N", 19, 2, false)]
            public decimal? VlDivid { get; set; }
        }

        public class RegX450 : RegistroBaseSped
        {
            public RegX450()
            {
                Reg = "X450";
            }

            [SpedCampos(2, "PAIS", "N", 3, 0, true)]
            public int Pais { get; set; }

            [SpedCampos(3, "VL_SERV_ASSIST", "N", 19, 2, false)]
            public decimal? VlServAssist { get; set; }

            [SpedCampos(4, "VL_SERV_SEM_ASSIST", "N", 19, 2, false)]
            public decimal? VlServSemAssist { get; set; }

            [SpedCampos(5, "VL_SERV_SEM_ASSIST_EXT", "N", 19, 2, false)]
            public decimal? VlServSemAssistExt { get; set; }

            [SpedCampos(6, "VL_JURO_PF", "N", 19, 2, false)]
            public decimal? VlJuroPf { get; set; }

            [SpedCampos(7, "VL_JURO_PJ", "N", 19, 2, false)]
            public decimal? VlJuroPj { get; set; }

            [SpedCampos(8, "VL_DEMAIS_JUROS", "N", 19, 2, false)]
            public decimal? VlDemaisJuros { get; set; }

            [SpedCampos(8, "VL_DIVID_PF", "N", 19, 2, false)]
            public decimal? VlDividaPf { get; set; }

            [SpedCampos(8, "VL_DIVID_PJ", "N", 19, 2, false)]
            public decimal? VlDividaPj { get; set; }
        }

        public class RegX460 : RegistroBaseSped
        {
            public RegX460()
            {
                Reg = "X460";
            }

            [SpedCampos(2, "CODIGO", "C", 6, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegX470 : RegistroBaseSped
        {
            public RegX470()
            {
                Reg = "X470";
            }

            [SpedCampos(2, "CODIGO", "C", 6, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegX480 : RegistroBaseSped
        {
            public RegX480()
            {
                Reg = "X480";
            }

            [SpedCampos(2, "CODIGO", "C", 6, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegX490 : RegistroBaseSped
        {
            public RegX490()
            {
                Reg = "X490";
            }

            [SpedCampos(2, "CODIGO", "C", 6, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegX500 : RegistroBaseSped
        {
            public RegX500()
            {
                Reg = "X500";
            }

            [SpedCampos(2, "CODIGO", "C", 6, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegX510 : RegistroBaseSped
        {
            public RegX510()
            {
                Reg = "X510";
            }

            [SpedCampos(2, "CODIGO", "C", 6, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegX990 : RegistroBaseSped
        {
            public RegX990()
            {
                Reg = "X990";
            }

            [SpedCampos(2, "QTD_LIN", "N", 0, 0, true)]
            public int QtdLin { get; set; }
        }
    }
}