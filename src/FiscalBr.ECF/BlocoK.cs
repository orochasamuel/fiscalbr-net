using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.ECF
{
    public class BlocoK
    {
        public class RegK001 : RegistroBaseSped
        {
            public RegK001()
            {
                Reg = "K001";
            }

            [SpedCampos(2, "IND_DAD", "N", 1, 0, true)]
            public int IndDad { get; set; }
        }

        public class RegK030 : RegistroBaseSped
        {
            public RegK030()
            {
                Reg = "K030";
            }

            [SpedCampos(2, "DT_INI", "N", 8, 0, true)]
            public DateTime DtIni { get; set; }

            [SpedCampos(3, "DT_FIN", "N", 8, 0, true)]
            public DateTime DtFin { get; set; }

            [SpedCampos(4, "PER_APUR", "C", 3, 0, true)]
            public string PerApur { get; set; }
        }

        public class RegK155 : RegistroBaseSped
        {
            public RegK155()
            {
                Reg = "K155";
            }

            [SpedCampos(2, "COD_CTA", "C", 0, 0, true)]
            public string CodCta { get; set; }

            [SpedCampos(3, "COD_CCUS", "C", 0, 0, false)]
            public string CodCcus { get; set; }

            [SpedCampos(4, "VL_SLD_INI", "N", 19, 2, true)]
            public decimal VlSldIni { get; set; }

            [SpedCampos(5, "IND_VL_SLD_INI", "C", 1, 0, true)]
            public string IndVlSldIni { get; set; }

            [SpedCampos(6, "VL_DEB", "N", 19, 2, true)]
            public decimal VlDeb { get; set; }

            [SpedCampos(7, "VL_CRED", "N", 19, 2, true)]
            public decimal VlCred { get; set; }

            [SpedCampos(8, "VL_SLD_FIN", "N", 19, 2, true)]
            public decimal VlSldFin { get; set; }

            [SpedCampos(9, "IND_VL_SLD_FIN", "C", 1, 0, true)]
            public string IndVlSldFin { get; set; }
        }

        public class RegK156 : RegistroBaseSped
        {
            public RegK156()
            {
                Reg = "K156";
            }

            [SpedCampos(2, "COD_CTA_REF", "C", 0, 0, true)]
            public string CodCtaRef { get; set; }

            [SpedCampos(3, "VL_SLD_FIN", "N", 19, 2, true)]
            public decimal VlSldFin { get; set; }

            [SpedCampos(4, "IND_VL_SLD_FIN", "C", 1, 0, true)]
            public string IndVlSldFin { get; set; }
        }

        public class RegK355 : RegistroBaseSped
        {
            public RegK355()
            {
                Reg = "K355";
            }

            [SpedCampos(2, "COD_CTA", "C", 0, 0, true)]
            public string CodCta { get; set; }

            [SpedCampos(3, "COD_CCUS", "C", 0, 0, false)]
            public string CodCcus { get; set; }

            [SpedCampos(4, "VL_SLD_FIN", "N", 19, 2, true)]
            public decimal VlSldFin { get; set; }

            [SpedCampos(5, "IND_VL_SLD_FIN", "C", 1, 0, true)]
            public string IndVlSldFin { get; set; }
        }

        public class RegK356 : RegistroBaseSped
        {
            public RegK356()
            {
                Reg = "K356";
            }

            [SpedCampos(2, "COD_CTA_REF", "C", 0, 0, true)]
            public string CodCtaRef { get; set; }

            [SpedCampos(3, "VL_SLD_FIN", "N", 19, 2, true)]
            public decimal VlSldFin { get; set; }

            [SpedCampos(4, "IND_VL_SLD_FIN", "C", 1, 0, true)]
            public string IndVlSldFin { get; set; }
        }

        public class RegK990 : RegistroBaseSped
        {
            public RegK990()
            {
                Reg = "K990";
            }

            [SpedCampos(2, "QTD_LIN", "N", 0, 0, true)]
            public int QtdLin { get; set; }
        }
    }
}