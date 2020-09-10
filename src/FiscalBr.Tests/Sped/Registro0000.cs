using System;
using System.Globalization;
using Xunit;

namespace FiscalBr.Tests.Sped
{
    public class Registro0000
    {
        [Fact]
        public void EFDFiscal()
        {
            var initialDate = (DateTime.Now.AddDays(-(DateTime.Now.Day - 1))).Date;
            var finalDate = initialDate.AddMonths(1).AddDays(-1);

            var formatedInitialDate = initialDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];
            var formatedFinalDate = finalDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];

            var expectedResult = 
                $"|0000|006|0|{formatedInitialDate}|{formatedFinalDate}|BANCO DO BRASIL S.A.|00000000000191||GO|123456789|5204508|||A|1|{Environment.NewLine}";

            var currentResult = new EFDFiscal.Bloco0.Registro0000();

            currentResult.CodVer = 6;
            currentResult.CodFin = Common.IndCodFinalidadeArquivo.RemessaArquivoOriginal;
            currentResult.DtIni = initialDate;
            currentResult.DtFin = finalDate;
            currentResult.Nome = "BANCO DO BRASIL S.A.";
            currentResult.Cnpj = "00000000000191";
            currentResult.Uf = "GO";
            currentResult.Ie = "123456789";
            currentResult.CodMun = "5204508";
            currentResult.IndPerfil = Common.IndPerfilArquivo.A;
            currentResult.IndAtiv = Common.IndTipoAtividade.Outros;

            var currentResultString = Common.Sped.EscreverCamposSped.EscreverCampos(currentResult, false);

            Assert.Equal(expectedResult, currentResultString);
        }
    }
}
