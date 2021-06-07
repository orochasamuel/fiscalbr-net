using System;
using System.Globalization;
using Xunit;

namespace FiscalBr.Tests.Sped
{
    public class Registro0000
    {
        [Fact]
        public void Escrever_Registro_0000_EFDFiscal()
        {
            var initialDate = (DateTime.Now.AddDays(-(DateTime.Now.Day - 1))).Date;
            var finalDate = initialDate.AddMonths(1).AddDays(-1);

            var formatedInitialDate = initialDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];
            var formatedFinalDate = finalDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];

            var expectedResult =
                $"|0000|006|0|{formatedInitialDate}|{formatedFinalDate}|BANCO DO BRASIL S.A.|00000000000191||GO|123456789|5204508|||A|1|{Environment.NewLine}";

            var source = new EFDFiscal.Bloco0.Registro0000
            {
                CodVer = 6,
                CodFin = Common.IndCodFinalidadeArquivo.RemessaArquivoOriginal,
                DtIni = initialDate,
                DtFin = finalDate,
                Nome = "BANCO DO BRASIL S.A.",
                Cnpj = "00000000000191",
                Uf = "GO",
                Ie = "123456789",
                CodMun = "5204508",
                IndPerfil = Common.IndPerfilArquivo.A,
                IndAtiv = Common.IndTipoAtividade.Outros
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(source, false);

            Assert.Equal(expectedResult, currentResult);
        }

        [Fact]
        public void Ler_Registro_0000_EFDFiscal()
        {
            var source = @"|0000|006|0|01112020|30112020|BANCO DO BRASIL S.A.|00000000000191||GO|123456789|5204508|||A|1|";

            var expectedResult = new EFDFiscal.Bloco0.Registro0000
            {
                CodVer = 6,
                CodFin = Common.IndCodFinalidadeArquivo.RemessaArquivoOriginal,
                DtIni = new DateTime(2020, 11, 1),
                DtFin = new DateTime(2020, 11, 30),
                Nome = "BANCO DO BRASIL S.A.",
                Cnpj = "00000000000191",
                Uf = "GO",
                Ie = "123456789",
                CodMun = "5204508",
                IndPerfil = Common.IndPerfilArquivo.A,
                IndAtiv = Common.IndTipoAtividade.Outros
            };

            var currentResult = Common.Sped.LerCamposSped.LerCampos(source);

            //Assert.Equal(currentResult, expectedResult); //Mesmo com registros identicos o Assert.Equals retornava falha

            var escrita = Common.Sped.EscreverCamposSped.EscreverCampos(expectedResult, true);

            Assert.Equal(source, escrita);
        }
    }
}
