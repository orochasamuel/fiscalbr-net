using FiscalBr.Common.Sped.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalBr.Test.Sped.BlocoD
{
    public class BlocoDRegistro300Test
    {
        [Fact]
        public void Escrever_Registro_D300_EFDFiscal()
        {
            var formattedDate = DateTime.Today.ToString(new CultureInfo("pt-BR")).Replace("/", "").Split(" ")[0];

            var expectedResult =
                $"|D300|13|1|1|1|5|040|5102|0,00|{formattedDate}|0,00|0,00|0,00|0,00|0,00|0,00|0,00|0,00|000001|010|{Environment.NewLine}";

            var source = new EFDFiscal.BlocoD.RegistroD300()
            {
                CodMod= IndCodMod.Mod13.ToDefaultValue(),
                Ser = "1",
                Sub = "1",
                NumDocIni = "1",
                NumDocFin = 5,
                CstIcms = "040",
                Cfop = "5102",
                AliqIcms = 0M,
                DtDoc = formattedDate,
                VlOpr = 0M,
                VlDesc = 0M,
                VlServ = 0M,
                VlSeg = 0M,
                VlOutDesp = 0M,
                VlBcIcms = 0M,
                VlIcms = 0M,
                VlRedBc = 0M,
                CodObs = "000001",
                CodCta = "010",
            };

            var currentResult = Common.Sped.EscreverCamposSped.EscreverCampos(source, VersaoLeiauteSped.V2);

            Assert.Equal(expectedResult, currentResult);
        }
    }
}
