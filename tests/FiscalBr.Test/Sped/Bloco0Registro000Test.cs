namespace FiscalBr.Test.Sped
{
    public class Bloco0Registro000Test
    {
        [Fact]
        public void Escrever_Registro_0000_EFDFiscal()
        {
            var initialDate = (DateTime.Now.AddDays(-(DateTime.Now.Day - 1))).Date;
            var finalDate = initialDate.AddMonths(1).AddDays(-1);

            var formatedInitialDate = initialDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];
            var formatedFinalDate = finalDate.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];

            var expectedResult =
                $"|0000|015|0|{formatedInitialDate}|{formatedFinalDate}|BANCO DO BRASIL S.A.|00000000000191||GO|123456789|5204508|||A|1|{Environment.NewLine}";

            var source = new EFDFiscal.Bloco0.Registro0000
            {
                CodVer = Common.CodigoVersaoLeiaute.V15,
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

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(source, CodigoVersaoLeiaute.V15);

            Assert.Equal(expectedResult, currentResult);
        }
    }
}
