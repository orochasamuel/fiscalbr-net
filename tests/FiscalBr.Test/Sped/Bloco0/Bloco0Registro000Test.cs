namespace FiscalBr.Test.Sped.Bloco0
{
    public class Bloco0Registro000Test
    {
        [Fact]
        public void Escrever_Registro_0000_EFDFiscal()
        {
            var initialDate = DateTime.Now.AddDays(-(DateTime.Now.Day - 1)).Date;
            var finalDate = initialDate.AddMonths(1).AddDays(-1);

            var formatedInitialDate = initialDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];
            var formatedFinalDate = finalDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];

            var expectedResult =
                $"|0000|015|0|{formatedInitialDate}|{formatedFinalDate}|BANCO DO BRASIL S.A.|00000000000191||GO|123456789|5204508|||A|1|{Environment.NewLine}";

            var source = new EFDFiscal.Bloco0.Registro0000
            {
                CodVer = CodVersaoSpedFiscal.V15,
                CodFin = IndCodFinalidadeArquivo.RemessaArquivoOriginal,
                DtIni = initialDate,
                DtFin = finalDate,
                Nome = "BANCO DO BRASIL S.A.",
                Cnpj = "00000000000191",
                Uf = "GO",
                Ie = "123456789",
                CodMun = "5204508",
                IndPerfil = IndPerfilArquivo.A,
                IndAtiv = Common.Sped.Enums.TipoAtivSpedFiscal.Outros
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(source, VersaoLeiauteSped.V15);

            Assert.Equal(expectedResult, currentResult);
        }

        [Fact]
        public void Escrever_Registro_0000_EFDFiscal_VNova()
        {
            var initialDate = DateTime.Now.AddDays(-(DateTime.Now.Day - 1)).Date;
            var finalDate = initialDate.AddMonths(1).AddDays(-1);

            var formatedInitialDate = initialDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];
            var formatedFinalDate = finalDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];

            var expectedResult =
                $"|0000|015|0|{formatedInitialDate}|{formatedFinalDate}|BANCO DO BRASIL S.A.|00000000000191||GO|123456789|5204508|||A|1|{Environment.NewLine}";

            var source = new EFDFiscal.Bloco0.Registro0000
            {
                CodVer = CodVersaoSpedFiscal.V15,
                CodFin = IndCodFinalidadeArquivo.RemessaArquivoOriginal,
                DtIni = initialDate,
                DtFin = finalDate,
                Nome = "BANCO DO BRASIL S.A.",
                Cnpj = "00000000000191",
                Uf = "GO",
                Ie = "123456789",
                CodMun = "5204508",
                IndPerfil = IndPerfilArquivo.A,
                IndAtiv = Common.Sped.Enums.TipoAtivSpedFiscal.Outros
            };

            var efd = new ArquivoEFDFiscalV2(VersaoLeiauteSped.V15);

            var currentResult = efd.EscreverLinha(source);

            Assert.Equal(expectedResult, currentResult);
        }

        [Fact]
        public void Escrever_Registro_0000_EFDFiscal_V18()
        {
            var initialDate = DateTime.Now.AddDays(-(DateTime.Now.Day - 1)).Date;
            var finalDate = initialDate.AddMonths(1).AddDays(-1);

            var formatedInitialDate = initialDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];
            var formatedFinalDate = finalDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];

            var expectedResult =
                $"|0000|018|0|{formatedInitialDate}|{formatedFinalDate}|BANCO DO BRASIL S.A.|00000000000191||GO|123456789|5204508|||A|1|{Environment.NewLine}";

            var source = new EFDFiscal.Bloco0.Registro0000
            {
                CodVer = CodVersaoSpedFiscal.V18,
                CodFin = IndCodFinalidadeArquivo.RemessaArquivoOriginal,
                DtIni = initialDate,
                DtFin = finalDate,
                Nome = "BANCO DO BRASIL S.A.",
                Cnpj = "00000000000191",
                Uf = "GO",
                Ie = "123456789",
                CodMun = "5204508",
                IndPerfil = IndPerfilArquivo.A,
                IndAtiv = Common.Sped.Enums.TipoAtivSpedFiscal.Outros
            };

            var efd = new ArquivoEFDFiscalV2(VersaoLeiauteSped.V18);

            var currentResult = efd.EscreverLinha(source);

            Assert.Equal(expectedResult, currentResult);
        }

        [Fact]
        public void Escrever_Registro_0000_EFDFiscal_V19()
        {
            var initialDate = DateTime.Now.AddDays(-(DateTime.Now.Day - 1)).Date;
            var finalDate = initialDate.AddMonths(1).AddDays(-1);

            var formatedInitialDate = initialDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];
            var formatedFinalDate = finalDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];

            var expectedResult =
                $"|0000|019|0|{formatedInitialDate}|{formatedFinalDate}|BANCO DO BRASIL S.A.|00000000000191||GO|123456789|5204508|||A|1|{Environment.NewLine}";

            var source = new EFDFiscal.Bloco0.Registro0000
            {
                CodVer = CodVersaoSpedFiscal.V19,
                CodFin = IndCodFinalidadeArquivo.RemessaArquivoOriginal,
                DtIni = initialDate,
                DtFin = finalDate,
                Nome = "BANCO DO BRASIL S.A.",
                Cnpj = "00000000000191",
                Uf = "GO",
                Ie = "123456789",
                CodMun = "5204508",
                IndPerfil = IndPerfilArquivo.A,
                IndAtiv = Common.Sped.Enums.TipoAtivSpedFiscal.Outros
            };

            var efd = new ArquivoEFDFiscalV2(VersaoLeiauteSped.V19);

            var currentResult = efd.EscreverLinha(source);

            Assert.Equal(expectedResult, currentResult);
        }
    }
}
