using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FiscalBr.Common.Sped;

namespace FiscalBr.Test.Sped.Bloco1
{
    public class Bloco1Registro1391Test
    {
        [Fact]
        public void Ler_Registro_1391_EFDFiscal()
        {
            string linha = "|1391|01012023|123,41|123,42|123,43|123,44|123,45|123,46|123,47|123,48|123,49|123,40|123,41|123,42|123,43|123,44|Observações|COD_ITEM|01|123,45|";

            var registro = (FiscalBr.EFDFiscal.Bloco1.Registro1391)LerCamposSped.LerCampos(linha, "EFDFiscal", 0);

            Assert.Equal("1391", registro.Reg);
            Assert.Equal(new DateTime(2023, 01, 01), registro.DtRegistro);
            Assert.Equal(123.41M, registro.QtdMoid);
            Assert.Equal(123.42M, registro.EstqIni);
            Assert.Equal(123.43M, registro.QtdProduz);
            Assert.Equal(123.44M, registro.EntAnidHid);
            Assert.Equal(123.45M, registro.OutrEntr);
            Assert.Equal(123.46M, registro.Perda);
            Assert.Equal(123.47M, registro.Cons);
            Assert.Equal(123.48M, registro.SaiAniHid);
            Assert.Equal(123.49M, registro.Saidas);
            Assert.Equal(123.40M, registro.EstqFin);
            Assert.Equal(123.41M, registro.EstqIniMel);
            Assert.Equal(123.42M, registro.ProdDiaMel);
            Assert.Equal(123.43M, registro.UtilMel);
            Assert.Equal(123.44M, registro.ProdAlcMel);
            Assert.Equal("Observações", registro.Obs);
            Assert.Equal("COD_ITEM", registro.CodItem);
            Assert.Equal(1, registro.TpResiduo);
            Assert.Equal(123.45M, registro.QtdResiduo);
        }
    }
}