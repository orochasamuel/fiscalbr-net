using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.ECF
{
    public class BlocoN
    {
        public class RegN001 : RegistroBaseSped
        {
            public RegN001()
            {
                Reg = "N001";
            }

            [SpedCampos(2, "IND_DAD", "N", 1, 0, true)]
            public int IndDad { get; set; }
        }

        public class RegN030 : RegistroBaseSped
        {
            public RegN030()
            {
                Reg = "N030";
            }

            [SpedCampos(2, "DT_INI", "N", 8, 0, true)]
            public DateTime DtIni { get; set; }

            [SpedCampos(3, "DT_FIN", "N", 8, 0, true)]
            public DateTime DtFin { get; set; }

            [SpedCampos(4, "PER_APUR", "C", 3, 0, true)]
            public string PerApur { get; set; }
        }

        public class RegN500 : RegistroBaseSped
        {
            public RegN500()
            {
                Reg = "N500";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegN600 : RegistroBaseSped
        {
            public RegN600()
            {
                Reg = "N600";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegN610 : RegistroBaseSped
        {
            public RegN610()
            {
                Reg = "N610";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegN615 : RegistroBaseSped
        {
            public RegN615()
            {
                Reg = "N615";
            }

            [SpedCampos(2, "BASE_CALC", "N", 19, 2, true)]
            public decimal BaseCalc { get; set; }

            [SpedCampos(3, "PER_INCEN_ FINOR", "N", 8, 1, true)]
            public decimal PerIncenFinor { get; set; }

            [SpedCampos(4, "VL_LIQ_INCEN_ FINOR", "NS", 19, 2, true)]
            public decimal VlLiqIncenFinor { get; set; }

            [SpedCampos(5, "PER_INCEN_ FINAM", "N", 8, 4, true)]
            public decimal PerIncenFinam { get; set; }

            [SpedCampos(6, "VL_LIQ_INCEN_FINAM", "NS", 19, 2, true)]
            public decimal VlLiqIncenFinam { get; set; }

            [SpedCampos(7, "VL_TOTAL", "NS", 19, 2, true)]
            public decimal VlTotal { get; set; }
        }

        public class RegN620 : RegistroBaseSped
        {
            public RegN620()
            {
                Reg = "N620";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegN630 : RegistroBaseSped
        {
            public RegN630()
            {
                Reg = "N630";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegN650 : RegistroBaseSped
        {
            public RegN650()
            {
                Reg = "N650";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegN660 : RegistroBaseSped
        {
            public RegN660()
            {
                Reg = "N660";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegN670 : RegistroBaseSped
        {
            public RegN670()
            {
                Reg = "N670";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegN990 : RegistroBaseSped
        {
            public RegN990()
            {
                Reg = "N990";
            }

            [SpedCampos(2, "QTD_LIN", "N", 0, 0, true)]
            public int QtdLin { get; set; }
        }
    }
}