using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalBr.Test.Sped.BlocoK
{
    public class BlocoKRegistro010Test
    {
        private const string K010Simplifi = $"|K010|0|";
        private const string K010Completo = $"|K010|1|";
        private const string K010Restrito = $"|K010|2|";

        [Theory]
        [InlineData(IndTpLeiaute.Simplificado, K010Simplifi)]
        [InlineData(IndTpLeiaute.Completo, K010Completo)]
        [InlineData(IndTpLeiaute.RestritoSaldoEstoque, K010Restrito)]
        public void Escrever_Registro_K010_EFDFiscal(IndTpLeiaute tpLeiaute, string resultadoEsperado)
        {
            var reg = new EFDFiscal.BlocoK.RegistroK010
            {
                IndTpLeiaute = tpLeiaute
            };

            var resultadoAtual = Common.Sped.EscreverCamposSped.EscreverCampos(
                reg,
                null,
                true
                );

            Assert.NotNull(resultadoAtual);
            Assert.Equal(resultadoEsperado, resultadoAtual);
        }
    }
}
