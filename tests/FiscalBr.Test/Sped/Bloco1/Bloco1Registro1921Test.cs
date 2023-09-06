using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FiscalBr.Test.Sped.Bloco1
{
    public class Bloco1Registro1921Test
    {
        [Fact]
        public void Ler_Registro_1921_EFDFiscal()
        {
            //instanciar array de strings
            string[] source = new string[7];
            source[0] = "|1001|0|1|";
            source[1] = "|1900|1|Descrição Complementar|";
            source[2] = "|1910|01012023|31012023|";
            source[3] = "|1920|1000.00|500.00|1500.00|300.00|2000.00|1000.00|500.00|500.00|200.00|3000.00|500.00|50.00|";
            source[4] = "|1921|COD123|Descrição Complementar do Ajuste|100.00|";
            source[5] = "|1922|123456|1234567890|1|Descrição do Processo|Texto Complementar do Ajuste|";
            source[6] = "|1923|FornecedorA|01|123|001|987654321|01012023|Item001|100.00|";

            var sped = new ArquivoEFDFiscal();
            sped.Ler(source);

            //Bloco 1
            Assert.Equal("1900", sped.Bloco1.Reg1001.Reg1900s[0].Reg);
            Assert.Equal("1910", sped.Bloco1.Reg1001.Reg1900s[0].Reg1910s[0].Reg);
            Assert.Equal("1921", sped.Bloco1.Reg1001.Reg1900s[0].Reg1910s[0].Reg1920.Reg1921s[0].Reg);
            Assert.Equal("1922", sped.Bloco1.Reg1001.Reg1900s[0].Reg1910s[0].Reg1920.Reg1921s[0].Reg1922s[0].Reg);
            Assert.Equal("1923", sped.Bloco1.Reg1001.Reg1900s[0].Reg1910s[0].Reg1920.Reg1921s[0].Reg1923s[0].Reg);
            
        }
    }
}