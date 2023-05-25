using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalBr.Test.Sped.Bloco0
{
    public class Bloco0Registro001Test
    {
        [Fact]
        public void Escrever_Arquivo_EFDFiscal_0001_Com_Movimento()
        {
            var resultadoEsperado = $"|0001|0|{Environment.NewLine}";

            var resultadoEsperadoArray = new string[] { resultadoEsperado };

            var arquivoGerado = new ArquivoEFDFiscal();

            arquivoGerado.Bloco0 = new EFDFiscal.Bloco0();

            arquivoGerado.Bloco0.Reg0001 = new EFDFiscal.Bloco0.Registro0001(IndMovimento.BlocoComDados);

            arquivoGerado.GerarLinhas();

            var arquivoLido = new ArquivoEFDFiscal();

            arquivoLido.Ler(resultadoEsperadoArray);

            arquivoLido.GerarLinhas();

            Assert.Equivalent(arquivoGerado, arquivoLido, true);
        }

        [Fact]
        public void Escrever_Registro_0001_Com_Movimento_EFDFiscal()
        {
            var expectedResult = $"|0001|0|{Environment.NewLine}";

            var source1 = new EFDFiscal.Bloco0.Registro0001
            {
                IndMov = IndMovimento.BlocoComDados
            };

            var currentResult1 = Common.Sped.EscreverCamposSped.EscreverCampos(source1);

            var source2 = new EFDFiscal.Bloco0.Registro0001(IndMovimento.BlocoComDados);

            var currentResult2 = Common.Sped.EscreverCamposSped.EscreverCampos(source2);

            var source3 = new EFDFiscal.Bloco0.Registro0001(true);

            var currentResult3 = Common.Sped.EscreverCamposSped.EscreverCampos(source3);

            var source4 = new EFDFiscal.Bloco0.Registro0001().ComIndicadorMovimento(true);

            var currentResult4 = Common.Sped.EscreverCamposSped.EscreverCampos(source4);

            Assert.Equal(expectedResult, currentResult1);
            Assert.Equal(expectedResult, currentResult2);
            Assert.Equal(expectedResult, currentResult3);
            Assert.Equal(expectedResult, currentResult4);
        }

        [Fact]
        public void Escrever_Arquivo_EFDFiscal_0001_Sem_Movimento()
        {
            var resultadoEsperado = $"|0001|1|{Environment.NewLine}";

            var resultadoEsperadoArray = new string[] { resultadoEsperado };

            var arquivoGerado = new ArquivoEFDFiscal();

            arquivoGerado.Bloco0 = new EFDFiscal.Bloco0();

            arquivoGerado.Bloco0.Reg0001 = new EFDFiscal.Bloco0.Registro0001(IndMovimento.BlocoSemDados);

            arquivoGerado.GerarLinhas();

            var arquivoLido = new ArquivoEFDFiscal();

            arquivoLido.Ler(resultadoEsperadoArray);

            arquivoLido.GerarLinhas();

            Assert.Equivalent(arquivoGerado, arquivoLido, true);
        }

        [Fact]
        public void Escrever_Registro_0001_Sem_Movimento_EFDFiscal()
        {
            var expectedResult = $"|0001|1|{Environment.NewLine}";

            var source1 = new EFDFiscal.Bloco0.Registro0001
            {
                IndMov = IndMovimento.BlocoSemDados
            };

            var currentResult1 = Common.Sped.EscreverCamposSped.EscreverCampos(source1);

            var source2 = new EFDFiscal.Bloco0.Registro0001(IndMovimento.BlocoSemDados);

            var currentResult2 = Common.Sped.EscreverCamposSped.EscreverCampos(source2);

            var source3 = new EFDFiscal.Bloco0.Registro0001(false);

            var currentResult3 = Common.Sped.EscreverCamposSped.EscreverCampos(source3);

            var source4 = new EFDFiscal.Bloco0.Registro0001().ComIndicadorMovimento(false);

            var currentResult4 = Common.Sped.EscreverCamposSped.EscreverCampos(source4);

            Assert.Equal(expectedResult, currentResult1);
            Assert.Equal(expectedResult, currentResult2);
            Assert.Equal(expectedResult, currentResult3);
            Assert.Equal(expectedResult, currentResult4);
        }
    }
}
