using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalBr.Test.Validacoes
{
    public class ValidarInscricaoEstadualTest
    {
        [Description("Tenta validar inscrições que sabemos serem válidas")]
        [Theory]
        [InlineData("105044873", "GO")] // Óticas Brasil - Goiânia
        [InlineData("142270790110", "SP")] // Ambev - SP
        public void SomenteInscricosValidas(string ie, string uf)
        {
            Assert.True(FiscalBr.Common.Validar.InscEstadual(ie, uf));
        }

        [Theory]
        [InlineData("ISENTO", "AC")]
        [InlineData("ISENTO", "CE")]
        [InlineData("ISENTO", "MA")]
        [InlineData("ISENTO", "GO")]
        [InlineData("ISENTO", "SP")]
        public void ValidarInscricaoEstadualIsento(string ie, string uf)
        {
            Assert.True(FiscalBr.Common.Validar.InscEstadual(ie, uf));
        }

        [Theory]
        [InlineData("ISENTA", "AC")]
        [InlineData("ISENTA", "CE")]
        [InlineData("ISENTA", "MA")]
        [InlineData("ISENTA", "GO")]
        public void ValidarInscricaoEstadualIsenta(string ie, string uf)
        {
            Assert.False(FiscalBr.Common.Validar.InscEstadual(ie, uf));
        }
    }
}
