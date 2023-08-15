using FiscalBr.Common;

namespace FiscalBr.Test.Sped
{
    public class SpedEnumTest
    {
        [Theory]
        [InlineData(CodigoVersaoLeiaute.V2)]
        [InlineData(CodigoVersaoLeiaute.V3)]
        [InlineData(CodigoVersaoLeiaute.V4)]
        [InlineData(CodigoVersaoLeiaute.V5)]
        [InlineData(CodigoVersaoLeiaute.V6)]
        [InlineData(CodigoVersaoLeiaute.V7)]
        [InlineData(CodigoVersaoLeiaute.V8)]
        [InlineData(CodigoVersaoLeiaute.V9)]
        [InlineData(CodigoVersaoLeiaute.V10)]
        [InlineData(CodigoVersaoLeiaute.V11)]
        [InlineData(CodigoVersaoLeiaute.V12)]
        [InlineData(CodigoVersaoLeiaute.V13)]
        [InlineData(CodigoVersaoLeiaute.V14)]
        [InlineData(CodigoVersaoLeiaute.V15)]
        [InlineData(CodigoVersaoLeiaute.V16)]
        [InlineData(CodigoVersaoLeiaute.V17)]
        public void CodigoVersaoLeiauteTest(CodigoVersaoLeiaute v)
        {
            Assert.Equal(v.ToString("D").PadLeft(3, '0'), v.ToDefaultValue());
        }

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
