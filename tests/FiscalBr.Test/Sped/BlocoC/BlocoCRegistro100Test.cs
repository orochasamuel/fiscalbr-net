using C100EFDFiscal = FiscalBr.EFDFiscal.BlocoC.RegistroC100;
using Utils = FiscalBr.Common.Sped.EscreverCamposSped;

namespace FiscalBr.Test.Sped.BlocoC
{
    public class BlocoCRegistro100Test
    {
        [Fact]
        public void Escrever_Registro_C100_Cancelado_EFDFiscal_V17()
        {
            SetCulture();
            var expectedResult =
                $"|C100|1|0||65|02|001|123456789|1234567890...44|||||||||||||||||||||{Environment.NewLine}";

            var source = C100EFDFiscal.PreencherDFeCancelado(
                IndTipoOperacaoProduto.Saida,
                IndEmitente.EmissaoPropria,
                IndCodMod.Mod65,
                "123456789", // Número da NFC-e
                "001", // Série da NFC-e
                "1234567890...44" // Chave da NFC-e
                );

            var currentResult = Utils.EscreverCampos(
                source,
                CodigoVersaoLeiaute.V17,
                new DateTime(2023, 01, 01),
                false,
                true
                );

            Assert.Equal(expectedResult, currentResult);
        }

        [Fact]
        public void Escrever_Registro_C100_Denegado_EFDFiscal_V17()
        {
            SetCulture();
            var expectedResult =
                $"|C100|1|0||65|04|001|123456789|1234567890...44|||||||||||||||||||||{Environment.NewLine}";

            var source = C100EFDFiscal.PreencherDFeDenegado(
                IndTipoOperacaoProduto.Saida,
                IndEmitente.EmissaoPropria,
                IndCodMod.Mod65,
                "123456789", // Número da NFC-e
                "001", // Série da NFC-e
                "1234567890...44" // Chave da NFC-e
                );

            var currentResult = Utils.EscreverCampos(
                source,
                CodigoVersaoLeiaute.V17,
                new DateTime(2023, 01, 01),
                false,
                true
                );

            Assert.Equal(expectedResult, currentResult);
        }

        [Fact]
        public void Escrever_Registro_C100_Inutilizado_EFDFiscal_V17()
        {
            SetCulture();
            var expectedResult =
                $"|C100|1|0||65|05|001|123456789||||||||||||||||||||||{Environment.NewLine}";

            var source = C100EFDFiscal.PreencherDFeInutilizado(
                IndTipoOperacaoProduto.Saida,
                IndEmitente.EmissaoPropria,
                IndCodMod.Mod65,
                "123456789", // Número da NFC-e
                "001" // Série da NFC-e
                );

            var currentResult = Utils.EscreverCampos(
                source,
                CodigoVersaoLeiaute.V17,
                new DateTime(2023, 01, 01),
                false,
                true
                );

            Assert.Equal(expectedResult, currentResult);
        }

        private void SetCulture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
        }
    }
}
