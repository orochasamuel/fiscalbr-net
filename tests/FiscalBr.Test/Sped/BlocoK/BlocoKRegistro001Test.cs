namespace FiscalBr.Test.Sped.BlocoK
{
    public class BlocoKRegistro001Test
    {
        private const string K001ComDados = $"|K001|0|";
        private const string K001SemDados = $"|K001|1|";

        public static readonly object[][] ArrayParaEscreverRegK001ComDadosDaEFDFiscalV9EAbaixo =
        {
            new object[] {
                VersaoLeiauteSped.V2,
                new DateTime(2009, 01, 01),
                IndMovimento.BlocoComDados
            },
            new object[] {
                VersaoLeiauteSped.V3,
                new DateTime(2010, 01, 01),
                IndMovimento.BlocoComDados
            },
            new object[] {
                VersaoLeiauteSped.V4,
                new DateTime(2011, 01, 01),
                IndMovimento.BlocoComDados
            },
            new object[] {
                VersaoLeiauteSped.V5,
                new DateTime(2012, 01, 01),
                IndMovimento.BlocoComDados
            },
            new object[] {
                VersaoLeiauteSped.V6,
                new DateTime(2012, 07, 01),
                IndMovimento.BlocoComDados
            },
            new object[] {
                VersaoLeiauteSped.V7,
                new DateTime(2013, 01, 01),
                IndMovimento.BlocoComDados
            },
            new object[] {
                VersaoLeiauteSped.V8,
                new DateTime(2014, 01, 01),
                IndMovimento.BlocoComDados
            },
            new object[] {
                VersaoLeiauteSped.V9,
                new DateTime(2015, 01, 01),
                IndMovimento.BlocoComDados
            }
        };

        public static readonly object[][] ArrayParaEscreverRegK001SemDadosDaEFDFiscalV9EAbaixo =
        {
            new object[] {
                VersaoLeiauteSped.V2,
                new DateTime(2009, 01, 01),
                IndMovimento.BlocoSemDados
            },
            new object[] {
                VersaoLeiauteSped.V3,
                new DateTime(2010, 01, 01),
                IndMovimento.BlocoSemDados
            },
            new object[] {
                VersaoLeiauteSped.V4,
                new DateTime(2011, 01, 01),
                IndMovimento.BlocoSemDados
            },
            new object[] {
                VersaoLeiauteSped.V5,
                new DateTime(2012, 01, 01),
                IndMovimento.BlocoSemDados
            },
            new object[] {
                VersaoLeiauteSped.V6,
                new DateTime(2012, 07, 01),
                IndMovimento.BlocoSemDados
            },
            new object[] {
                VersaoLeiauteSped.V7,
                new DateTime(2013, 01, 01),
                IndMovimento.BlocoSemDados
            },
            new object[] {
                VersaoLeiauteSped.V8,
                new DateTime(2014, 01, 01),
                IndMovimento.BlocoSemDados
            },
            new object[] {
                VersaoLeiauteSped.V9,
                new DateTime(2015, 01, 01),
                IndMovimento.BlocoSemDados
            }
        };

        public static readonly object[][] ArrayParaEscreverRegK001ComDadosDaEFDFiscalV10EAcima =
        {
            new object[] {
                VersaoLeiauteSped.V10,
                new DateTime(2016, 01, 01),
                IndMovimento.BlocoComDados,
                K001ComDados
            },
            new object[] {
                VersaoLeiauteSped.V11,
                new DateTime(2017, 01, 01),
                IndMovimento.BlocoComDados,
                K001ComDados
            },
            new object[] {
                VersaoLeiauteSped.V12,
                new DateTime(2018, 01, 01),
                IndMovimento.BlocoComDados,
                K001ComDados
            },
            new object[] {
                VersaoLeiauteSped.V13,
                new DateTime(2019, 01, 01),
                IndMovimento.BlocoComDados,
                K001ComDados
            },
            new object[] {
                VersaoLeiauteSped.V14,
                new DateTime(2020, 01, 01),
                IndMovimento.BlocoComDados,
                K001ComDados
            },
            new object[] {
                VersaoLeiauteSped.V15,
                new DateTime(2021, 01, 01),
                IndMovimento.BlocoComDados,
                K001ComDados
            },
            new object[] {
                VersaoLeiauteSped.V16,
                new DateTime(2022, 01, 01),
                IndMovimento.BlocoComDados,
                K001ComDados
            },
            new object[] {
                VersaoLeiauteSped.V17,
                new DateTime(2023, 01, 01),
                IndMovimento.BlocoComDados,
                K001ComDados
            }
        };

        public static readonly object[][] ArrayParaEscreverRegK001SemDadosDaEFDFiscalV10EAcima =
        {
            new object[] {
                VersaoLeiauteSped.V10,
                new DateTime(2016, 01, 01),
                IndMovimento.BlocoSemDados,
                K001SemDados
            },
            new object[] {
                VersaoLeiauteSped.V11,
                new DateTime(2017, 01, 01),
                IndMovimento.BlocoSemDados,
                K001SemDados
            },
            new object[] {
                VersaoLeiauteSped.V12,
                new DateTime(2018, 01, 01),
                IndMovimento.BlocoSemDados,
                K001SemDados
            },
            new object[] {
                VersaoLeiauteSped.V13,
                new DateTime(2019, 01, 01),
                IndMovimento.BlocoSemDados,
                K001SemDados
            },
            new object[] {
                VersaoLeiauteSped.V14,
                new DateTime(2020, 01, 01),
                IndMovimento.BlocoSemDados,
                K001SemDados
            },
            new object[] {
                VersaoLeiauteSped.V15,
                new DateTime(2021, 01, 01),
                IndMovimento.BlocoSemDados,
                K001SemDados
            },
            new object[] {
                VersaoLeiauteSped.V16,
                new DateTime(2022, 01, 01),
                IndMovimento.BlocoSemDados,
                K001SemDados
            },
            new object[] {
                VersaoLeiauteSped.V17,
                new DateTime(2023, 01, 01),
                IndMovimento.BlocoSemDados,
                K001SemDados
            }
        };

        [Theory]
        [MemberData(nameof(ArrayParaEscreverRegK001ComDadosDaEFDFiscalV9EAbaixo))]
        [MemberData(nameof(ArrayParaEscreverRegK001SemDadosDaEFDFiscalV9EAbaixo))]
        public void Escrever_Registro_K001_EFDFiscal_V09_E_Abaixo(
            VersaoLeiauteSped codVer,
            DateTime dataDec,
            IndMovimento indMov
            )
        {
            // Arrange
            var reg = new EFDFiscal.BlocoK.RegistroK001
            {
                IndMov = indMov
            };

            // Act
            var resultadoAtual = Common.Sped.EscreverCamposSped.EscreverCampos(
                reg,
                codVer,
                dataDec,
                true
                );

            // Assert
            Assert.Null(resultadoAtual);
        }

        [Theory]
        [MemberData(nameof(ArrayParaEscreverRegK001ComDadosDaEFDFiscalV10EAcima))]
        [MemberData(nameof(ArrayParaEscreverRegK001SemDadosDaEFDFiscalV10EAcima))]
        public void Escrever_Registro_K001_EFDFiscal_V10_E_Acima(
            VersaoLeiauteSped codVer,
            DateTime dataDec,
            IndMovimento indMov,
            string resultadoEsperado
            )
        {
            // Arrange
            var reg = new EFDFiscal.BlocoK.RegistroK001
            {
                IndMov = indMov
            };

            // Act
            var resultadoAtual = Common.Sped.EscreverCamposSped.EscreverCampos(
                reg,
                codVer,
                dataDec,
                true
                );

            // Assert
            Assert.NotNull(resultadoAtual);
            Assert.Equal(resultadoEsperado, resultadoAtual);
        }
    }
}
