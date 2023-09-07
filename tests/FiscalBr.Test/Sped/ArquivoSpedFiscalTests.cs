using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalBr.Test.Sped
{
    public class ArquivoSpedFiscalTests
    {
        [Fact]
        public void EscreverArquivoEFDFiscalV2()
        {
            var efdFiscal = new ArquivoEFDFiscalV2(CodigoVersaoLeiaute.V2, LeiauteArquivoSped.EFDFiscal);

            //var expectResult = $"|D001|0|{Environment.NewLine}";

            //var d001 = new FiscalBr.EFDFiscal.BlocoD.RegistroD001New(true);

            //var currentResult = efdFiscal.EscreverLinha(d001, efdFiscal.VersaoLeiaute);

            //Assert.Equal(expectResult, currentResult);
        }
    }
}
