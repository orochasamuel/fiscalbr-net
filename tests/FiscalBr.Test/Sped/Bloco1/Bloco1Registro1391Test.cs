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
        [Theory]
        [InlineData("pt-BR")]
        public void Ler_Registro_1391_EFDFiscal(string currentCulture)
        {
            string linha = "|1391|01012023|123,41|123,42|123,43|123,44|123,45|123,46|123,47|123,48|123,49|123,40|123,41|123,42|123,43|123,44|Observações|COD_ITEM|01|123,45|";

            var registro = (FiscalBr.EFDFiscal.Bloco1.Registro1391)LerCamposSped.LerCampos(linha, Constantes.ArquivoDigital.Sped.EFDFiscal, 0);

            Assert.Equal("1391", registro.Reg);
            Assert.Equal(new DateTime(2023, 01, 01), registro.DtRegistro);
            Assert.Equal(Convert.ToDecimal(123.41, new CultureInfo(currentCulture)), registro.QtdMoid);
            Assert.Equal(Convert.ToDecimal(123.42, new CultureInfo(currentCulture)), registro.EstqIni);
            Assert.Equal(Convert.ToDecimal(123.43, new CultureInfo(currentCulture)), registro.QtdProduz);
            Assert.Equal(Convert.ToDecimal(123.44, new CultureInfo(currentCulture)), registro.EntAnidHid);
            Assert.Equal(Convert.ToDecimal(123.45, new CultureInfo(currentCulture)), registro.OutrEntr);
            Assert.Equal(Convert.ToDecimal(123.46, new CultureInfo(currentCulture)), registro.Perda);
            Assert.Equal(Convert.ToDecimal(123.47, new CultureInfo(currentCulture)), registro.Cons);
            Assert.Equal(Convert.ToDecimal(123.48, new CultureInfo(currentCulture)), registro.SaiAniHid);
            Assert.Equal(Convert.ToDecimal(123.49, new CultureInfo(currentCulture)), registro.Saidas);
            Assert.Equal(Convert.ToDecimal(123.40, new CultureInfo(currentCulture)), registro.EstqFin);
            Assert.Equal(Convert.ToDecimal(123.41, new CultureInfo(currentCulture)), registro.EstqIniMel);
            Assert.Equal(Convert.ToDecimal(123.42, new CultureInfo(currentCulture)), registro.ProdDiaMel);
            Assert.Equal(Convert.ToDecimal(123.43, new CultureInfo(currentCulture)), registro.UtilMel);
            Assert.Equal(Convert.ToDecimal(123.44, new CultureInfo(currentCulture)), registro.ProdAlcMel);
            Assert.Equal("Observações", registro.Obs);
            Assert.Equal("COD_ITEM", registro.CodItem);
            Assert.Equal(1, registro.TpResiduo);
            Assert.Equal(Convert.ToDecimal(123.45, new CultureInfo(currentCulture)), registro.QtdResiduo);
        }
    }
}