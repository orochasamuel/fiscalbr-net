using FiscalBr.Common;
using System;
using System.Globalization;
using Xunit;

namespace FiscalBr.Tests.Sped
{
    public class Registro0000Test
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

        [Fact]
        public void Ler_Registro_0000_EFDFiscal()
        {
            //var source = @"|0000|015|0|01012021|31012021|BANCO DO BRASIL S.A.|00000000000191||GO|123456789|5204508|||A|1|";

            //var expectedResult = new EFDFiscal.Bloco0.Registro0000
            //{
            //    CodVer = Common.CodigoVersaoLeiaute.V15,
            //    CodFin = Common.IndCodFinalidadeArquivo.RemessaArquivoOriginal,
            //    DtIni = new DateTime(2021, 1, 1),
            //    DtFin = new DateTime(2021, 1, 31),
            //    Nome = "BANCO DO BRASIL S.A.",
            //    Cnpj = "00000000000191",
            //    Uf = "GO",
            //    Ie = "123456789",
            //    CodMun = "5204508",
            //    IndPerfil = Common.IndPerfilArquivo.A,
            //    IndAtiv = Common.IndTipoAtividade.Outros
            //};

            //var currentResult = (EFDFiscal.Bloco0.Registro0000)Common.Sped.LerCamposSped.LerCampos(source);

            //Assert.Equal(expectedResult.CodVer, currentResult.CodVer);
            //Assert.Equal(expectedResult.CodFin, currentResult.CodFin);
            //Assert.Equal(expectedResult.DtIni.ToString(new CultureInfo("pt-BR")), 
            //    currentResult.DtIni.ToString(new CultureInfo("pt-BR")));
            //Assert.Equal(expectedResult.DtFin.ToString(new CultureInfo("pt-BR")), 
            //    currentResult.DtFin.ToString(new CultureInfo("pt-BR")));
            //Assert.Equal(expectedResult.Nome, currentResult.Nome);
            //Assert.Equal(expectedResult.Cnpj, currentResult.Cnpj);
            //Assert.Equal(expectedResult.Uf, currentResult.Uf);
            //Assert.Equal(expectedResult.Ie, currentResult.Ie);
            //Assert.Equal(expectedResult.CodMun, currentResult.CodMun);
            //Assert.Equal(expectedResult.IndPerfil, currentResult.IndPerfil);
            //Assert.Equal(expectedResult.IndAtiv, currentResult.IndAtiv);
        }
    }
}
