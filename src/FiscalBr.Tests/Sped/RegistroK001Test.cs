using FiscalBr.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace FiscalBr.Tests.Sped
{
    public class RegistroK001Test
    {
        [Fact]
        public void Escrever_Registro_K001_EFDFiscal_V9()
        {
            var source = new EFDFiscal.BlocoK.RegistroK001
            {
                IndMov = Common.IndMovimento.BlocoSemDados
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(
                source,
                CodigoVersaoLeiaute.V9,
                new DateTime(2015, 01, 01)
                );

            Assert.Null(currentResult);
        }

        [Fact]
        public void Escrever_Registro_K001_EFDFiscal_V10()
        {
            var expectedResult =
                $"|K001|1|{Environment.NewLine}";

            var source = new EFDFiscal.BlocoK.RegistroK001
            {
                IndMov = Common.IndMovimento.BlocoSemDados
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(
                source,
                CodigoVersaoLeiaute.V10,
                new DateTime(2016, 01, 01)
                );

            Assert.NotNull(currentResult);
            Assert.Equal(expectedResult, currentResult);
        }

        [Fact]
        public void Escrever_Registro_K001_EFDFiscal_V11()
        {
            var expectedResult =
                $"|K001|1|{Environment.NewLine}";

            var source = new EFDFiscal.BlocoK.RegistroK001
            {
                IndMov = Common.IndMovimento.BlocoSemDados
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(
                source,
                CodigoVersaoLeiaute.V11,
                new DateTime(2017, 01, 01)
                );

            Assert.NotNull(currentResult);
            Assert.Equal(expectedResult, currentResult);
        }
    }
}
