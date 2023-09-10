namespace FiscalBr.Test.Sped.BlocoD
{
    public class BlocoDRegistro500Test
    {
        [Fact]
        public void Escrever_Registro_D500_EFDFiscal_V2()
        {
            var today = DateTime.Today;

            var formattedToday = today.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];

            var expectedResult =
                $"|D500|0|1||66|00|||123456789|{formattedToday}||0,00|0,00|0,00|0,00|0,00|0,00|0,00|0,00||0,00|0,00||{Environment.NewLine}";

            var source = new EFDFiscal.BlocoD.RegistroD500
            {
                IndOper = IndTipoOperacaoServico.Aquisicao,
                IndEmit = IndEmitente.Terceiros,
                CodMod = IndCodMod.Mod66,
                CodSit = IndCodSitDoc.DocumentoRegular,
                NumDoc = 123456789,
                DtDoc = today

            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(
                source,
                VersaoLeiauteSped.V2,
                DateTime.Now,
                false,
                true
                );

            currentResult = currentResult.Replace(Constantes.StructuralError, "");

            Assert.Equal(expectedResult, currentResult);
        }
    }
}
