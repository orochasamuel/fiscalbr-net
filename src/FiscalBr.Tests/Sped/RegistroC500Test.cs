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
        public void Escrever_Registro_C500_EFDFiscal_V2()
        {
            var expectedResult =
                $"|C500|1|0|CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)|66|00|9999|000|06|123456789|01012009|01012009|99,99|9,99|0,00|0,00|0,00|0,00|90,00|22,50|0,00|0,00|CODINF|1,49|6,84|{ Environment.NewLine}";

            var source = new EFDFiscal.BlocoC.RegistroC500
            {
                // V2
                IndOper = IndTipoOperacaoProduto.Saida,
                IndEmit = IndEmitente.EmissaoPropria,
                CodPart = "CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)",
                CodMod = "66", // NF3e - Nota Fiscal de Energia Elétrica Eletrônica
                CodSit = IndCodSitDoc.DocumentoRegular,
                Ser = "9999",
                Sub = "000",
                CodCons = IndClasseConsumoEnergiaOuGas.Residencial,
                NumDoc = 123456789,
                DtDoc = new DateTime(2009, 1, 1),
                DtEs = new DateTime(2009, 1, 1),
                VlDoc = 99.99M,
                VlDesc = 9.99M,
                VlForn = 0M,
                VlServNt = 0M,
                VlTerc = 0M,
                VlDa = 0M,
                VlBcIcms = 90M,
                VlIcms = 22.50M,
                VlBcIcmsSt = 0M,
                VlIcmsSt = 0M,
                CodInf = "CODINFOCOMPLEMENTAR",
                VlPis = 1.49M,
                VlCofins = 6.84M,
                // V3
                TpLigacao = IndCodTipoLigacao.Monofasico,
                CodGrupoTensao = IndCodGrupoTensao.A1,
                // V14
                ChvDoce = "01234567890123456789012345678901234567890123",
                FinDoce = IndCodFinDoce.Normal,
                ChvDoceRef = "",
                IndDest = IndCodDestAcessante.NaoContribuinte,
                CodMunDest = "1234",
                CodCta = "3.1.01.01.001",
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(
                source,
                CodigoVersaoLeiaute.V2,
                new DateTime(2015, 01, 01),
                false,
                true
                );

            Assert.Equal(expectedResult, currentResult);
        }

        [Fact]
        public void Escrever_Registro_C500_EFDFiscal_V3()
        {
            var expectedResult =
                $"|C500|1|0|CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)|66|00|9999|000|06|123456789|01012009|01012009|99,99|9,99|0,00|0,00|0,00|0,00|90,00|22,50|0,00|0,00|CODINF|1,49|6,84|1|01|{ Environment.NewLine}";

            var source = new EFDFiscal.BlocoC.RegistroC500
            {
                // V2
                IndOper = IndTipoOperacaoProduto.Saida,
                IndEmit = IndEmitente.EmissaoPropria,
                CodPart = "CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)",
                CodMod = "66", // NF3e - Nota Fiscal de Energia Elétrica Eletrônica
                CodSit = IndCodSitDoc.DocumentoRegular,
                Ser = "9999",
                Sub = "000",
                CodCons = IndClasseConsumoEnergiaOuGas.Residencial,
                NumDoc = 123456789,
                DtDoc = new DateTime(2009, 1, 1),
                DtEs = new DateTime(2009, 1, 1),
                VlDoc = 99.99M,
                VlDesc = 9.99M,
                VlForn = 0M,
                VlServNt = 0M,
                VlTerc = 0M,
                VlDa = 0M,
                VlBcIcms = 90M,
                VlIcms = 22.50M,
                VlBcIcmsSt = 0M,
                VlIcmsSt = 0M,
                CodInf = "CODINFOCOMPLEMENTAR",
                VlPis = 1.49M,
                VlCofins = 6.84M,
                // V3
                TpLigacao = IndCodTipoLigacao.Monofasico,
                CodGrupoTensao = IndCodGrupoTensao.A1,
                // V14
                ChvDoce = "01234567890123456789012345678901234567890123",
                FinDoce = IndCodFinDoce.Normal,
                ChvDoceRef = "",
                IndDest = IndCodDestAcessante.NaoContribuinte,
                CodMunDest = "1234",
                CodCta = "3.1.01.01.001",
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(
                source,
                CodigoVersaoLeiaute.V3,
                new DateTime(2015, 01, 01),
                false,
                true
                );

            Assert.Equal(expectedResult, currentResult);
        }

        [Fact]
        public void Escrever_Registro_C500_EFDFiscal_V14()
        {
            var expectedResult =
                $"|C500|1|0|CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)|66|00|9999|000|06|123456789|01012009|01012009|99,99|9,99|0,00|0,00|0,00|0,00|90,00|22,50|0,00|0,00|CODINF|1,49|6,84|1|01|01234567890123456789012345678901234567890123|1||9|1234|3.1.01.01.001|{ Environment.NewLine}";

            var source = new EFDFiscal.BlocoC.RegistroC500
            {
                // V2
                IndOper = IndTipoOperacaoProduto.Saida,
                IndEmit = IndEmitente.EmissaoPropria,
                CodPart = "CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)",
                CodMod = "66", // NF3e - Nota Fiscal de Energia Elétrica Eletrônica
                CodSit = IndCodSitDoc.DocumentoRegular,
                Ser = "9999",
                Sub = "000",
                CodCons = IndClasseConsumoEnergiaOuGas.Residencial,
                NumDoc = 123456789,
                DtDoc = new DateTime(2009, 1, 1),
                DtEs = new DateTime(2009, 1, 1),
                VlDoc = 99.99M,
                VlDesc = 9.99M,
                VlForn = 0M,
                VlServNt = 0M,
                VlTerc = 0M,
                VlDa = 0M,
                VlBcIcms = 90M,
                VlIcms = 22.50M,
                VlBcIcmsSt = 0M,
                VlIcmsSt = 0M,
                CodInf = "CODINFOCOMPLEMENTAR",
                VlPis = 1.49M,
                VlCofins = 6.84M,
                // V3
                TpLigacao = IndCodTipoLigacao.Monofasico,
                CodGrupoTensao = IndCodGrupoTensao.A1,
                // V14
                ChvDoce = "01234567890123456789012345678901234567890123",
                FinDoce = IndCodFinDoce.Normal,
                ChvDoceRef = "",
                IndDest = IndCodDestAcessante.NaoContribuinte,
                CodMunDest = "1234",
                CodCta = "3.1.01.01.001",
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(
                source,
                CodigoVersaoLeiaute.V14,
                new DateTime(2021, 01, 01),
                false,
                true
                );

            Assert.Equal(expectedResult, currentResult);
        }

        [Fact]
        public void Escrever_Registro_C500_EFDFiscal_V16()
        {
            var expectedResult =
                $"|C500|1|{Environment.NewLine}";

            var source = new EFDFiscal.BlocoC.RegistroC500
            {
                // V2
                IndOper = IndTipoOperacaoProduto.Saida,
                // V3
                TpLigacao = IndCodTipoLigacao.Monofasico,
                // V14
                FinDoce = IndCodFinDoce.Normal,
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(
                source,
                CodigoVersaoLeiaute.V16,
                new DateTime(2022, 01, 01),
                false,
                true
                );

            Assert.Equal(expectedResult, currentResult);
        }
    }
}
