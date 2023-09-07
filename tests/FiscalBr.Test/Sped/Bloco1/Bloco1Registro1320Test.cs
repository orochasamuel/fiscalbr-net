using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiscalBr.Common.Sped;
using Xunit;

namespace FiscalBr.Test.Sped.Bloco1
{
    public class Bloco1Registro1320Test
    {
        [Theory]
        [InlineData("pt-BR")]
        public void Ler_Registro_1320_EFDFiscal(string currentCulture)
        {
            string linha = "|1320|1|1234567890|Motivo 1|Interventor 1|51077662000109|00695196090|100,13|55,20|10|40|";
             
            var registro = (FiscalBr.EFDFiscal.Bloco1.Registro1320)LerCamposSped.LerCampos(linha, Constantes.ArquivoDigital.Sped.EFDFiscal, 0); 

            Assert.Equal("1320", registro.Reg);
            Assert.Equal(1, registro.NumBico);
            Assert.Equal(1234567890, registro.NrInterv);
            Assert.Equal("Motivo 1", registro.MotInterv);
            Assert.Equal("Interventor 1", registro.NomInterv);
            Assert.Equal("51077662000109", registro.CnpjInterv);
            Assert.Equal("00695196090", registro.CpfInterv);
            Assert.Equal(100.13M, registro.ValFecha);
            Assert.Equal(55.20M, registro.ValAbert);
            Assert.Equal(10M, registro.VolAferi);
            Assert.Equal(40M, registro.VolVendas); 
        }        
    }
}