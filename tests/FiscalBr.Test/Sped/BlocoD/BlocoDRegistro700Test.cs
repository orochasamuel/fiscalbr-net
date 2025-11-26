using FiscalBr.Common.Sped.Enums;

namespace FiscalBr.Test.Sped.BlocoD
{
    public class BlocoDRegistro700Test
    {
        

        [Fact]
        public void Escrever_Registro_D700_EFDFiscal_V2()
        {
            var today = DateTime.Today;

            var formattedToday = today.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];

            var expectedResult =
                $"|D700|1|1||62|00|1|1|{formattedToday}||10,00||10,00|||||||||51251141557175000181620000000000461013182247|0|0|00||||||1100015|0,00|{Environment.NewLine}";

            var source = new EFDFiscal.BlocoD.RegistroD700
            {
                IndOper = IndTipoOperacaoServico.Prestacao,
                IndEmit = IndEmitente.Terceiros,
                CodMod = IndCodMod.Mod62,
                CodSit = IndCodSitDoc.DocumentoRegular,
                Ser = "1",
                NumDoc = "1",
                VlDoc = 10m,
                VlServ = 10m,
                ChvDoce = "51251141557175000181620000000000461013182247",
                CodMunDes = "1100015",
                DtDoc = today

            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(
                source,
                VersaoLeiauteSped.V19,
                DateTime.Now,
                false,
                true
                );

            currentResult = currentResult.Replace(Constantes.StructuralError, "");

            Assert.Equal(expectedResult, currentResult);
        }
    }
}
