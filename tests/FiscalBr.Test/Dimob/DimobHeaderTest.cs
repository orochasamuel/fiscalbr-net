namespace FiscalBr.Test.Dimob
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
