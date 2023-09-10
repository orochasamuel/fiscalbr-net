using FiscalBr.Common.ValueObjects;

namespace FiscalBr.Test.ValueObjects
{
    public class ValidarEmailTests
    {
        [Theory]
        [InlineData("oi@fiscalbr.com", true)]
        [InlineData("@fiscalbr.com", false)]
        [InlineData("fiscalbr.com", false)]
        [InlineData("fiscalbr.", false)]
        [InlineData("fiscalbr", false)]
        public void ValidarEmailTest(string email, bool resultadoEsperado)
        {
            Email emailAtual = email;
            Assert.Equal(resultadoEsperado, emailAtual.EhValido);
        }

        [Fact]
        public void ValidarIgualdadeEmailValidoTest()
        {
            Email one = "oi@fiscalbr.com";
            Email two = "oi@fiscalbr.com";

            Assert.True(EqualityComparer<Email>.Default.Equals(one, two)); // True
            Assert.True(object.Equals(one, two)); // True
            Assert.True(one.Equals(two)); // True
            Assert.True(one == two); // True
        }

        [Fact]
        public void ValidarIgualdadeEmailInvalidoTest()
        {
            Email one = "fiscalbr.com";
            Email two = "fiscalbr.com";

            Assert.True(EqualityComparer<Email>.Default.Equals(one, two)); // True
            Assert.True(object.Equals(one, two)); // True
            Assert.True(one.Equals(two)); // True
            Assert.True(one == two); // True
        }
    }
}
