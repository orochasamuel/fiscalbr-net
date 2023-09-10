namespace FiscalBr.Test.Sped.Bloco0
{
    public class Bloco0Registro100Test
    {
        [Fact]
        public void Escrever_Registro_0100_Sem_Dados_Contador_EFDFiscal()
        {
            var expectedResult =
                $"|0100||||||||||||||{Environment.NewLine}";

            var source = new EFDFiscal.Bloco0.Registro0100
            {

                Nome = "",
                Cpf = "",
                Crc = "",
                Cnpj = "",
                Cep = "",
                End = "",
                Num = "",
                Compl = "",
                Bairro = "",
                Fone = "",
                Fax = "",
                Email = "",
                CodMun = "",
                
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(
                source,
                VersaoLeiauteSped.V17,
                DateTime.Now,
                false,
                true
                );

            currentResult = currentResult.Replace(Constantes.StructuralError, "");

            Assert.Equal(expectedResult, currentResult);
        }
    }
}
