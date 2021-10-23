using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.ECF
{
    public class BlocoP
    {
        public class RegP001 : RegistroBaseSped
        {
            public RegP001()
            {
                Reg = "P001";
            }

            [SpedCampos(2, "IND_DAD", "N", 1, 0, true, 15)]
            public int IndDad { get; set; }
        }

        public class RegP030 : RegistroBaseSped
        {
            public RegP030()
            {
                Reg = "P030";
            }

            [SpedCampos(2, "DT_INI", "N", 8, 0, true, 15)]
            public DateTime DtIni { get; set; }

            [SpedCampos(3, "DT_FIN", "N", 8, 0, true, 15)]
            public DateTime DtFin { get; set; }

            [SpedCampos(4, "PER_APUR", "C", 3, 0, true, 15)]
            public string PerApur { get; set; }
        }

        public class RegP100 : RegistroBaseSped
        {
            public RegP100()
            {
                Reg = "P100";
            }

            [SpedCampos(2, "CODIGO", "C", 50, 0, true, 15)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false, 15)]
            public string Descricao { get; set; }

            [SpedCampos(4, "TIPO", "C", 1, 0, true, 15)]
            public string Tipo { get; set; }

            [SpedCampos(5, "NIVEL", "N", 3, 0, false, 15)]
            public int Nivel { get; set; }

            [SpedCampos(6, "COD_NAT", "C", 2, 0, false, 15)]
            public string CodNat { get; set; }

            [SpedCampos(7, "COD_CTA_SUP", "C", 0, 0, false, 15)]
            public string CodCtaSup { get; set; }

            [SpedCampos(8, "VAL_CTA_REF_INI", "N", 19, 2, true, 15)]
            public decimal ValCtaRefIni { get; set; }

            [SpedCampos(9, "IND_VAL_CTA_REF_INI", "C", 1, 0, true, 15)]
            public string IndValCtaRefIni { get; set; }

            [SpedCampos(10, "VAL_CTA_REF_FIN", "N", 19, 2, true, 15)]
            public decimal ValCtaRefFin { get; set; }

            [SpedCampos(11, "IND_ VAL_CTA_REF_FIN", "C", 1, 0, true, 15)]
            public string IndValCtaRefFin { get; set; }
        }

        public class RegP130 : RegistroBaseSped
        {
            public RegP130()
            {
                Reg = "P130";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true, 15)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false, 15)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false, 15)]
            public decimal? Valor { get; set; }
        }

        public class RegP150 : RegistroBaseSped
        {
            public RegP150()
            {
                Reg = "P150";
            }

            [SpedCampos(2, "CODIGO", "C", 50, 0, true, 15)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false, 15)]
            public string Descricao { get; set; }

            [SpedCampos(4, "TIPO", "C", 1, 0, true, 15)]
            public string Tipo { get; set; }

            [SpedCampos(5, "NIVEL", "N", 3, 0, false, 15)]
            public int Nivel { get; set; }

            [SpedCampos(6, "COD_NAT", "C", 1, 0, false, 15)]
            public string CodNat { get; set; }

            [SpedCampos(7, "COD_CTA_SUP", "C", 0, 0, false, 15)]
            public string CodCtaSup { get; set; }

            [SpedCampos(8, "VALOR", "N", 19, 2, true, 15)]
            public decimal Valor { get; set; }

            [SpedCampos(9, "IND_ VALOR", "C", 1, 0, true, 15)]
            public string IndValor { get; set; }
        }

        public class RegP200 : RegistroBaseSped
        {
            public RegP200()
            {
                Reg = "P200";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true, 15)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false, 15)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false, 15)]
            public decimal? Valor { get; set; }
        }

        public class RegP230 : RegistroBaseSped
        {
            public RegP230()
            {
                Reg = "P230";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true, 15)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false, 15)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false, 15)]
            public decimal? Valor { get; set; }
        }

        public class RegP300 : RegistroBaseSped
        {
            public RegP300()
            {
                Reg = "P300";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true, 15)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false, 15)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false, 15)]
            public decimal? Valor { get; set; }
        }

        public class RegP400 : RegistroBaseSped
        {
            public RegP400()
            {
                Reg = "P400";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true, 15)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false, 15)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false, 15)]
            public decimal? Valor { get; set; }
        }

        public class RegP500 : RegistroBaseSped
        {
            public RegP500()
            {
                Reg = "P500";
            }

            [SpedCampos(2, "CODIGO", "C", 0, 0, true, 15)]
            public string Codigo { get; set; }

            [SpedCampos(3, "DESCRICAO", "C", 0, 0, false, 15)]
            public string Descricao { get; set; }

            [SpedCampos(4, "VALOR", "NS", 19, 2, false, 15)]
            public decimal? Valor { get; set; }
        }

        public class RegP990 : RegistroBaseSped
        {
            public RegP990()
            {
                Reg = "P990";
            }

            [SpedCampos(2, "QTD_LIN", "N", 0, 0, true, 15)]
            public int QtdLin { get; set; }
        }
    }
}