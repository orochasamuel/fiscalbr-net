using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalBr.Test.Sintegra
{
    public class Registro10Test
    {
        [Fact]
        public void Sintegra_Gerar_Registro_10()
        {
            var linhas = new List<string>();

            #region ...

            var initialDate = DateTime.Now.AddDays(-(DateTime.Now.Day - 1)).Date;
            var finalDate = initialDate.AddMonths(1).AddDays(-1);

            var expectedResult =
                $"|0000|015|0|BANCO DO BRASIL S.A.|00000000000191||GO|123456789|5204508|||A|1|{Environment.NewLine}";

            #endregion ...

            var source = new FiscalBr.Sintegra.Registro10(
                "00000000000191",
                "123456789",
                "BANCO DO BRASIL S.A.",
                "",
                "",
                "",
                initialDate,
                finalDate,
                FiscalBr.Sintegra.CodFinalidadeArquivo.Cod1,
                FiscalBr.Sintegra.CodEstruturaArquivo.Cod3,
                FiscalBr.Sintegra.CodNaturezaOperacoes.Cod3
                );

            var linhaEscrita = Common.Sintegra.EscreverCamposSintegra.EscreverCampos(source);

            linhas.Add(linhaEscrita);

            var reg90 = new FiscalBr.Sintegra.Registro90(
                "CNPJ",
                "IE",
                linhas
                );

            var reg90Escrito = reg90.EscreverRegistro90();

            // Adiciona Registro 90 escrito nas linhas
            linhas.Add(reg90Escrito);

            //Assert.Equal(expectedResult, currentResult);
        }
    }
}
