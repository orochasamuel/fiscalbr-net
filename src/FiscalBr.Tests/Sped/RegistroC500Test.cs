using FiscalBr.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace FiscalBr.Tests.Sped
{
    public class RegistroC500Test
    {
        [Fact]
        public void Escrever_Registro_C500_EFDFiscal_V15()
        {
            var expectedResult =
               $"|C500|0|1|04065033000170|06|00|U||00|14971920|18022022|24022022|5599,98|0,00|5599,98|5599,98|0,00|0,00|0,00|0,00|0,00|0,00||||||||||||{Environment.NewLine}";

            var source = new EFDFiscal.BlocoC.RegistroC500
            {
                CodMod = "06",
                IndOper = IndTipoOperacaoProduto.Entrada,
                CodSit = IndCodSitDoc.DocumentoRegular,
                IndEmit = IndEmitente.Terceiros,
                CodPart = "04065033000170",
                NumDoc = 14971920,
                Ser = "U",
                DtDoc = new DateTime(2022,02,18),
                DtEs = new DateTime(2022, 02, 24),
                VlDoc = 5599.98M,
                VlForn = 5599.98M,
                VlServNt = 5599.98M,
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(
                source,
                CodigoVersaoLeiaute.V15,
                new DateTime(2021, 02, 01)
                );

            Assert.Equal(expectedResult, currentResult);
        }

        [Fact]
        public void Escrever_Registro_C500_EFDFiscal_V16()
        {
            var expectedResult =
               $"|C500|0|1|04065033000170|06|00|U||00|14971920|18022022|24022022|5599,98|0,00|5599,98|5599,98|0,00|0,00|0,00|0,00|0,00|||||||||||||||||||{Environment.NewLine}";

            var source = new EFDFiscal.BlocoC.RegistroC500
            {
                CodMod = "06",
                IndOper = IndTipoOperacaoProduto.Entrada,
                CodSit = IndCodSitDoc.DocumentoRegular,
                IndEmit = IndEmitente.Terceiros,
                CodPart = "04065033000170",
                NumDoc = 14971920,
                Ser = "U",
                DtDoc = new DateTime(2022, 02, 18),
                DtEs = new DateTime(2022, 02, 24),
                VlDoc = 5599.98M,
                VlForn = 5599.98M,
                VlServNt = 5599.98M,
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(
                source,
                CodigoVersaoLeiaute.V16,
                new DateTime(2022, 01, 01)
                );

            Assert.Equal(expectedResult, currentResult);
        }


    }
}
