using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalBr.Test.Sped.Enums
{
    public class CodigoVersaoLeiauteSpedTest
    {
        [Theory]
        [InlineData(CodVersaoSpedECF.V1)]
        [InlineData(CodVersaoSpedECF.V2)]
        [InlineData(CodVersaoSpedECF.V3)]
        [InlineData(CodVersaoSpedECF.V4)]
        [InlineData(CodVersaoSpedECF.V5)]
        [InlineData(CodVersaoSpedECF.V6)]
        [InlineData(CodVersaoSpedECF.V7)]
        [InlineData(CodVersaoSpedECF.V8)]
        [InlineData(CodVersaoSpedECF.V9)]
        public void CodigoVersaoLeiauteSpedEcfTest(CodVersaoSpedECF v)
        {
            Assert.Equal(v.ToString("D").PadLeft(4, '0'), v.ToDefaultValue());
        }

        [Theory]
        [InlineData(CodVersaoSpedContrib.V1)]
        [InlineData(CodVersaoSpedContrib.V2)]
        [InlineData(CodVersaoSpedContrib.V3)]
        [InlineData(CodVersaoSpedContrib.V4)]
        [InlineData(CodVersaoSpedContrib.V5)]
        [InlineData(CodVersaoSpedContrib.V6)]
        public void CodigoVersaoLeiauteSpedContribTest(CodVersaoSpedContrib v)
        {
            Assert.Equal(v.ToString("D").PadLeft(3, '0'), v.ToDefaultValue());
        }

        [Theory]
        [InlineData(CodVersaoSpedFiscal.V2)]
        [InlineData(CodVersaoSpedFiscal.V3)]
        [InlineData(CodVersaoSpedFiscal.V4)]
        [InlineData(CodVersaoSpedFiscal.V5)]
        [InlineData(CodVersaoSpedFiscal.V6)]
        [InlineData(CodVersaoSpedFiscal.V7)]
        [InlineData(CodVersaoSpedFiscal.V8)]
        [InlineData(CodVersaoSpedFiscal.V9)]
        [InlineData(CodVersaoSpedFiscal.V10)]
        [InlineData(CodVersaoSpedFiscal.V11)]
        [InlineData(CodVersaoSpedFiscal.V12)]
        [InlineData(CodVersaoSpedFiscal.V13)]
        [InlineData(CodVersaoSpedFiscal.V14)]
        [InlineData(CodVersaoSpedFiscal.V15)]
        [InlineData(CodVersaoSpedFiscal.V16)]
        [InlineData(CodVersaoSpedFiscal.V17)]
        public void CodigoVersaoLeiauteSpedFiscalTest(CodVersaoSpedFiscal v)
        {
            Assert.Equal(v.ToString("D").PadLeft(3, '0'), v.ToDefaultValue());
        }

        [Theory]
        [InlineData(VersaoLeiauteSped.V2, CodVersaoSpedContrib.V2)]
        [InlineData(null, CodVersaoSpedContrib.V6)]
        public void ObterEnumVersaoEFDContribTest(VersaoLeiauteSped? versaoAtual, CodVersaoSpedContrib? resultadoEsperado)
        {
            var maiorVersao = (int)EnumHelpers.GetEnumMaxValue<CodVersaoSpedContrib>();

            // Arrange
            var efd = new ArquivoEFDContribuicoesV2(versaoAtual ?? (VersaoLeiauteSped)maiorVersao);

            // Act
            var enumAtual = (CodVersaoSpedContrib)efd.ObterEnumVersaoLeiaute();

            // Assert
            Assert.Equal(resultadoEsperado, enumAtual);
        }

        [Theory]
        [InlineData(VersaoLeiauteSped.V2, 2)]
        [InlineData(VersaoLeiauteSped.V3, 3)]
        [InlineData(VersaoLeiauteSped.V4, 4)]
        [InlineData(VersaoLeiauteSped.V5, 5)]
        [InlineData(VersaoLeiauteSped.V6, 6)]
        [InlineData(null, 6)]
        public void ObterIntVersaoEFDContribTest(VersaoLeiauteSped? v, int versaoEsperada)
        {
            // Arrange
            var efd = new ArquivoEFDContribuicoesV2();

            // Act
            var versaoAtual = efd.ObterVersaoLeiaute(v);

            // Assert
            Assert.Equal(versaoEsperada, versaoAtual);
        }

        [Theory]
        [InlineData(VersaoLeiauteSped.V2, CodVersaoSpedFiscal.V2)]
        [InlineData(null, CodVersaoSpedFiscal.V19)]
        public void ObterEnumVersaoEFDFiscalTest(VersaoLeiauteSped? v, CodVersaoSpedFiscal? resultadoEsperado)
        {
            var maiorVersao = (int)EnumHelpers.GetEnumMaxValue<CodVersaoSpedFiscal>();

            // Arrange
            var efd = new ArquivoEFDFiscalV2(v ?? (VersaoLeiauteSped)maiorVersao);

            // Act
            var enumAtual = (CodVersaoSpedFiscal)efd.ObterEnumVersaoLeiaute();

            // Assert
            Assert.Equal(resultadoEsperado, enumAtual);
        }

        [Theory]
        [InlineData(VersaoLeiauteSped.V2, 2)]
        [InlineData(VersaoLeiauteSped.V3, 3)]
        [InlineData(VersaoLeiauteSped.V9, 9)]
        [InlineData(VersaoLeiauteSped.V10, 10)]
        [InlineData(VersaoLeiauteSped.V17, 17)]
        [InlineData(null, 18)]
        public void ObterIntVersaoEFDFiscalTest(VersaoLeiauteSped? v, int versaoEsperada)
        {
            // Arrange
            var efd = new ArquivoEFDFiscalV2();

            // Act
            var versaoAtual = efd.ObterVersaoLeiaute(v);

            // Assert
            Assert.Equal(versaoEsperada, versaoAtual);
        }

        [Theory]
        [InlineData(6)]
        public void ObterNumeroVersoesEFDContribTest(int qtdEsperada)
        {
            var efd = new ArquivoEFDContribuicoesV2();

            var qtdAtual = efd.ObterVersoesLeiaute(efd.ArquivoSped).Count();

            Assert.Equal(qtdEsperada, qtdAtual);
        }

        [Theory]
        [InlineData(18)]
        public void ObterNumeroVersoesEFDFiscalTest(int qtdEsperada)
        {
            var efd = new ArquivoEFDFiscalV2();

            var qtdAtual = efd.ObterVersoesLeiaute(efd.ArquivoSped).Count();

            Assert.Equal(qtdEsperada, qtdAtual);
        }
    }
}
