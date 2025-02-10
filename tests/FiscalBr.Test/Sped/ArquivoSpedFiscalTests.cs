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
            // Arrange
            var efdContrib = new ArquivoEFDContribuicoesV2();
            var efdFiscal = new ArquivoEFDFiscalV2(
                "FiscalBrOffice",
                "00000000000191",
                "oi@fiscalbr.com"
                );

            // Act
            var enumContrib = (CodVersaoSpedContrib)efdContrib.ObterEnumVersaoLeiaute();
            var enumFiscal = (CodVersaoSpedFiscal)efdFiscal.ObterEnumVersaoLeiaute();

            // Assert
            Assert.Equal(CodVersaoSpedContrib.V6, enumContrib);
            Assert.Equal(CodVersaoSpedFiscal.V19, enumFiscal);
        }
    }
}
