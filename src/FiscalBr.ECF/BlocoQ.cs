using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.ECF
{
    public class BlocoQ
    {
        public class RegQ001 : RegistroBaseSped
        {
            public RegQ001()
            {
                Reg = "Q001";
            }

            [SpedCampos(2, "IND_DAD", "N", 1, 0, true)]
            public int IndDad { get; set; }
        }

        public class RegQ100 : RegistroBaseSped
        {
            public RegQ100()
            {
                Reg = "Q100";
            }

            [SpedCampos(2, "DATA", "N", 8, 0, true)]
            public DateTime Data { get; set; }

            [SpedCampos(3, "NUM_DOC", "C", 0, 0, false)]
            public string NumDoc { get; set; }

            [SpedCampos(4, "HIST", "C", 0, 0, true)]
            public string Hist { get; set; }

            [SpedCampos(5, "VL_ENTRADA", "N", 19, 2, false)]
            public decimal? VlEntrada { get; set; }

            [SpedCampos(6, "VL_SAIDA", "N", 19, 2, false)]
            public decimal? VlSaida { get; set; }

            [SpedCampos(7, "SLD_FIN", "NS", 19, 2, true)]
            public decimal SldFin { get; set; }
        }

        public class RegQ990 : RegistroBaseSped
        {
            public RegQ990()
            {
                Reg = "Q990";
            }

            [SpedCampos(2, "QTD_LIN", "N", 0, 0, true)]
            public int QtdLin { get; set; }
        }
    }
}