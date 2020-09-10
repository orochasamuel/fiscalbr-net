using Xunit;
using FiscalBr.Dimob;

namespace FiscalBr.Tests.Dimob
{
    public class DimobTrailerTest
    {
        [Fact]
        public void DimobTrailer()
        {
            const string expectedResult = "T9                                                                                                   ";

            var currentResult = new DimobT9();

            //Assert
            Assert.Equal(expectedResult, currentResult.ToString());
        }
    }
}
