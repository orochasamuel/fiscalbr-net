using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalBr.Test.Sped.Enums
{
    public class IndicadorTipoLeiauteBlocoKTest
    {
        [Theory]
        [InlineData(IndTpLeiaute.Simplificado)]
        [InlineData(IndTpLeiaute.Completo)]
        [InlineData(IndTpLeiaute.RestritoSaldoEstoque)]
        public void IndTipoLeiauteTest(IndTpLeiaute v)
        {
            Assert.Equal(v.ToString("D"), v.ToDefaultValue());
        }
    }
}
