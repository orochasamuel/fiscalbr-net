using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.EFDContribuicoes
{
    public class BlocoI
    {
        public class RegistroI001 : RegistroBaseSped
        {
            public RegistroI001()
            {
                Reg = "I001";
            }

            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }
        }

        public class RegistroI990 : RegistroBaseSped
        {
            public RegistroI990()
            {
                Reg = "I990";
            }

            [SpedCampos(2, "QTD_LIN_I", "N", int.MaxValue, 0, true)]
            public int QtdLinI { get; set; }
        }
    }
}
