using FiscalBr.Common;

namespace FiscalBr.Test.Sped
{
    public class SpedEnumTest
    {
        [Theory]
        [InlineData(IndTipoFrete.ContaDestinatarioFob)]
        [InlineData(IndTipoFrete.ContaRemetenteCif)]
        [InlineData(IndTipoFrete.ContaProprioDestinatario)]
        [InlineData(IndTipoFrete.ContaProprioRemetente)]
        [InlineData(IndTipoFrete.ContaTerceiros)]
        [InlineData(IndTipoFrete.SemCobrancaFrete)]
        public void IndTipoFreteTest(IndTipoFrete v)
        {
            Assert.Equal(v.ToString("D"), v.ToDefaultValue());
        }

        [Fact]
        public void ConverterIntParaEnumTipoSemFreteTest()
        {
            var indicadorFreteInt = 9; // Sem frete

            var indicadorFreteEnum = (IndTipoFrete)indicadorFreteInt;

            Assert.Equal(IndTipoFrete.SemCobrancaFrete, indicadorFreteEnum);
        }
    }
}
