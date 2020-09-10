using Xunit;
using FiscalBr.Dimob;

namespace FiscalBr.Tests.Dimob
{
    public class DimobHeaderTest
    {
        [Fact]
        public void DimobHeader()
        {
            const string expectedResult = "DIMOB                                                                                                                                                                                                                                                                                                                                                                                 ";

            var currentResult = new DimobHeader();

            //Assert
            Assert.Equal(expectedResult, currentResult.ToString());
        }
    }
}
