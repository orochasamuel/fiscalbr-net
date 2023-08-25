using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalBr.Test.Sped.BlocoD
{
    public class BlocoDRegistro001Test
    {
        [Fact]
        public void Escrever_Registro_D001_Com_Movimento_EFDContribuicoes()
        {
            var expectResult = $"|D001|0|{Environment.NewLine}";

            var source1 = new EFDContribuicoes.BlocoD.RegistroD001
            {
                IndMov = IndMovimento.BlocoComDados
            };

            var currentResult1 = Common.Sped.EscreverCamposSped.EscreverCampos(source1);

            //var source2 = new EFDContribuicoes.BlocoD.RegistroD001(IndMovimento.BlocoComDados);

            //var currentResult2 = Common.Sped.EscreverCamposSped.EscreverCampos(source2);

            //var source3 = new EFDContribuicoes.BlocoD.RegistroD001(true);

            //var currentResult3 = Common.Sped.EscreverCamposSped.EscreverCampos(source3);

            //var source4 = new EFDContribuicoes.BlocoD.RegistroD001().ComIndicadorMovimento(true);

            //var currentResult4 = Common.Sped.EscreverCamposSped.EscreverCampos(source4);

            Assert.Equal(expectResult, currentResult1);
            //Assert.Equal(expectResult, currentResult2);
            //Assert.Equal(expectResult, currentResult3);
            //Assert.Equal(expectResult, currentResult4);
        }

        [Fact]
        public void Escrever_Registro_C001_Sem_Movimento_EFDContribuicoes_e_EFDFiscal()
        {
            var expectResult = $"|C001|1|{Environment.NewLine}";

            var source1 = new EFDFiscal.BlocoC.RegistroC001
            {
                IndMov = IndMovimento.BlocoSemDados
            };

            var currentResult1 = Common.Sped.EscreverCamposSped.EscreverCampos(source1);

            var source2 = new EFDFiscal.BlocoC.RegistroC001(IndMovimento.BlocoSemDados);

            var currentResult2 = Common.Sped.EscreverCamposSped.EscreverCampos(source2);

            var source3 = new EFDFiscal.BlocoC.RegistroC001(false);

            var currentResult3 = Common.Sped.EscreverCamposSped.EscreverCampos(source3);

            var source4 = new EFDFiscal.BlocoC.RegistroC001().ComIndicadorMovimento(false);

            var currentResult4 = Common.Sped.EscreverCamposSped.EscreverCampos(source4);

            Assert.Equal(expectResult, currentResult1);
            Assert.Equal(expectResult, currentResult2);
            Assert.Equal(expectResult, currentResult3);
            Assert.Equal(expectResult, currentResult4);
        }

    }
}
