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

            var source = new EFDFiscal.BlocoC.RegistroC100()
                .PreencherDFeCancelado(
                IndTipoOperacaoProduto.Saida,
                IndEmitente.EmissaoPropria,
                IndCodMod.Mod65,
                "123456789", // Número da NFC-e
                "001", // Série da NFC-e
                "1234567890...44" // Chave da NFC-e
                );

            var currentResult = Utils.EscreverCampos(
                source,
                VersaoLeiauteSped.V17,
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

            var source = new EFDFiscal.BlocoC.RegistroC100()
                .PreencherDFeDenegado(
                IndTipoOperacaoProduto.Saida,
                IndEmitente.EmissaoPropria,
                IndCodMod.Mod65,
                "123456789", // Número da NFC-e
                "001", // Série da NFC-e
                "1234567890...44" // Chave da NFC-e
                );

            var currentResult = Utils.EscreverCampos(
                source,
                VersaoLeiauteSped.V17,
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

            var source = new EFDFiscal.BlocoC.RegistroC100()
                .PreencherDFeInutilizado(
                IndTipoOperacaoProduto.Saida,
                IndEmitente.EmissaoPropria,
                IndCodMod.Mod65,
                "123456789", // Número da NFC-e
                "001" // Série da NFC-e
                );

            var currentResult = Utils.EscreverCampos(
                source,
                VersaoLeiauteSped.V17,
                new DateTime(2023, 01, 01),
                false,
                true
                );

            Assert.Equal(expectedResult, currentResult);
        }

        [Fact]
        public void Teste_Leitura_Isolada_C100_indmod_1B()
        {
            var expectedResult =
            @"|C100|0|1|F000408|1B|00|001|1862||11012020|11012020|1370|1|0|0|1370|9|0|0|0|1090|196,2|0|0|0|17,99|82,84|0|0|";

            File.WriteAllText("SpedTestC100.1Bv17.txt", expectedResult);

            var efdFiscalFile = new FiscalBr.EFDFiscal.ArquivoEFDFiscal();

            efdFiscalFile.Ler("SpedTestC100.1Bv17.txt");
            Assert.Equal("1862", efdFiscalFile.BlocoC?.RegC001?.RegC100s?.FirstOrDefault()?.NumDoc);
            Assert.Equal(IndCodMod.Mod1B, efdFiscalFile.BlocoC?.RegC001?.RegC100s?.FirstOrDefault()?.CodMod);
        }

        private void SetCulture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
        }
    }
}
