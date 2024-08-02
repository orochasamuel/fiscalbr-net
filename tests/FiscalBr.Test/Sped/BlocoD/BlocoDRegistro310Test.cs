using FiscalBr.Common.Sped.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalBr.Test.Sped.BlocoD
{
    public class BlocoDRegistro310Test
    {
        [Fact]
        public void Escrever_Registro_D310_EFDFiscal()
        {
            var expectedResult =
                $"|D310|3550308|0,00|0,00|0,00|{Environment.NewLine}";

            var source = new EFDFiscal.BlocoD.RegistroD310()
            {
                CodMunOrig = "3550308",
                VlServ = 0M,
                VlBcIcms = 0M,
                VlIcms = 0M,
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(source, VersaoLeiauteSped.V2);

            Assert.Equal(expectedResult, currentResult);
        }
    }
}
