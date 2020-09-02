using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.ECF
{
    public class BlocoU
    {
        public class RegU001 : RegistroBaseSped
        {
            public RegU001()
            {
                Reg = "U001";
            }

            [SpedCampos(2, "IND_DAD", "N", 1, 0, true)]
            public int IndDad { get; set; }
        }

        public class RegU030 : RegistroBaseSped
        {
            public RegU030()
            {
                Reg = "U030";
            }

            [SpedCampos(2, "DT_INI", "N", 8, 0, true)]
            public DateTime DtIni { get; set; }

            [SpedCampos(3, "DT_FIN", "N", 8, 0, true)]
            public DateTime DtFin { get; set; }

            [SpedCampos(4, "PER_APUR", "C", 3, 0, true)]
            public string PerApur { get; set; }
        }

        public class RegU100 : RegistroBaseSped
        {
            public RegU100()
            {
                Reg = "U100";
            }

            [SpedCampos(2, "CODIGO", "C", 50, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "TIPO", "C", 1, 0, true)]
            public string Tipo { get; set; }

            [SpedCampos(5, "NIVEL", "N", 3, 0, false)]
            public int Nivel { get; set; }

            [SpedCampos(6, "COD_NAT", "C", 2, 0, false)]
            public string CodNat { get; set; }

            [SpedCampos(7, "COD_CTA_SUP", "C", 0, 0, false)]
            public string CodCtaSup { get; set; }

            [SpedCampos(8, "VAL_CTA_REF_INI", "N", 19, 2, true)]
            public decimal ValCtaRefIni { get; set; }

            [SpedCampos(9, "IND_VAL_CTA_REF_INI", "C", 1, 0, true)]
            public string IndValCtaRefIni { get; set; }

            [SpedCampos(10, "VAL_CTA_REF_FIN", "N", 19, 2, true)]
            public decimal ValCtaRefFin { get; set; }

            [SpedCampos(11, "IND_ VAL_CTA_REF_FIN", "C", 1, 0, true)]
            public string IndValCtaRefFin { get; set; }
        }

        public class RegU150 : RegistroBaseSped
        {
            public RegU150()
            {
                Reg = "U150";
            }

            [SpedCampos(2, "CODIGO", "C", 50, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "TIPO", "C", 1, 0, true)]
            public string Tipo { get; set; }

            [SpedCampos(5, "NIVEL", "N", 3, 0, false)]
            public int Nivel { get; set; }

            [SpedCampos(6, "COD_NAT", "C", 1, 0, false)]
            public string CodNat { get; set; }

            [SpedCampos(7, "COD_CTA_SUP", "C", 0, 0, false)]
            public string CodCtaSup { get; set; }

            [SpedCampos(8, "VALOR", "N", 19, 2, true)]
            public decimal Valor { get; set; }

            [SpedCampos(9, "IND_ VALOR", "C", 1, 0, true)]
            public string IndValor { get; set; }
        }

        public class RegU180 : RegistroBaseSped
        {
            public RegU180()
            {
                Reg = "U180";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegU182 : RegistroBaseSped
        {
            public RegU182()
            {
                Reg = "U182";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false)]
            public decimal? Valor { get; set; }
        }

        public class RegU990 : RegistroBaseSped
        {
            public RegU990()
            {
                Reg = "U990";
            }

            [SpedCampos(2, "QTD_LIN", "N", 0, 0, true)]
            public int QtdLin { get; set; }
        }
    }
}