using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.ECF
{
    public class BlocoJ
    {
        public class RegJ001 : RegistroBaseSped
        {
            public RegJ001()
            {
                Reg = "J001";
            }

            /// <summary>
            ///     Valores validos: [0;1]
            /// </summary>
            [SpedCampos(2, "IND_DAD", "N", 1, 0, true)]
            public int IndDad { get; set; }
        }

        public class RegJ050 : RegistroBaseSped
        {
            public RegJ050()
            {
                Reg = "J050";
            }

            [SpedCampos(2, "DT_ALT", "N", 8, 0, true)]
            public DateTime DtAlt { get; set; }

            [SpedCampos(3, "COD_NAT", "C", 2, 0, true)]
            public string CodNat { get; set; }

            [SpedCampos(4, "IND_CTA", "C", 1, 0, true)]
            public string IndCta { get; set; }

            [SpedCampos(5, "NÍVEL", "N", 1, 0, true)]
            public int Nivel { get; set; }

            [SpedCampos(6, "COD_CTA", "C", 0, 0, true)]
            public string CodCta { get; set; }

            [SpedCampos(7, "COD_CTA_SUP", "C", 0, 0, false)]
            public string CodCtaSup { get; set; }

            [SpedCampos(8, "CTA", "C", 0, 0, true)]
            public string Cta { get; set; }
        }

        public class RegJ051 : RegistroBaseSped
        {
            public RegJ051()
            {
                Reg = "J051";
            }

            [SpedCampos(2, "COD_CCUS", "C", 0, 0, false)]
            public string CodCus { get; set; }

            [SpedCampos(3, "COD_CTA_REF", "C", 0, 0, true)]
            public string CodCtaRef { get; set; }
        }

        public class RegJ053 : RegistroBaseSped
        {
            public RegJ053()
            {
                Reg = "J053";
            }

            [SpedCampos(2, "COD_IDT", "C", 6, 0, true)]
            public string CodIdt { get; set; }

            [SpedCampos(3, "COD_CNT_CORR", "C", 0, 0, true)]
            public string CodCntCorr { get; set; }

            [SpedCampos(4, "NAT_SUB_CNT", "C", 2, 0, true)]
            public string NatSubCnt { get; set; }
        }

        public class RegJ100 : RegistroBaseSped
        {
            public RegJ100()
            {
                Reg = "J100";
            }

            [SpedCampos(2, "DT_ALT", "N", 8, 0, true)]
            public DateTime DtAlt { get; set; }

            [SpedCampos(3, "COD_CCUS", "C", 0, 0, true)]
            public string CodCus { get; set; }

            [SpedCampos(4, "CCUS", "C", 0, 0, true)]
            public string CCus { get; set; }
        }

        public class RegJ990 : RegistroBaseSped
        {
            public RegJ990()
            {
                Reg = "J990";
            }

            [SpedCampos(2, "QTD_LIN", "N", 0, 0, true)]
            public int QtdLin { get; set; }
        }
    }
}