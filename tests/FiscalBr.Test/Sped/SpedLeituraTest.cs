using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace FiscalBr.Test.Sped
{
    public class SpedLeituraTest
    {
        [Fact]
        public void LeituraArquivoEFDContribuicoesSimplesApropriacaoDireta()
        {
            /*
             * http://sped.rfb.gov.br/pagina/show/1609
             */
            var exampleFromSped = 
              @"|0000|002|0|||01042011|30042011|EMPRESA YYY|77777777000191|MG|3106200||00|0|
|0001|0|
|0110|1|1|1|4|
|0140|1|EMPRESA YYY|77777777000191|MG||3106200|||
|0990|5|
|A001|1|
|A990|2|
|C001|1|
|C990|2|
|D001|1|
|D990|2|
|F001|1|
|F990|2|
|M001|0|
|M200|0|0|0|0|0|0|0|0|0|0|0|0|
|M600|0|0|0|0|0|0|0|0|0|0|0|0|
|M990|4|
|1001|1|
|1990|2|
|9001|0|
|9900|0000|1|
|9900|0001|1|
|9900|0110|1|
|9900|0140|1|
|9900|0990|1|
|9900|1001|1|
|9900|1990|1|
|9900|9001|1|
|9900|9990|1|
|9900|9999|1|
|9900|A001|1|
|9900|A990|1|
|9900|C001|1|
|9900|C990|1|
|9900|D001|1|
|9900|D990|1|
|9900|F001|1|
|9900|F990|1|
|9900|M001|1|
|9900|M200|1|
|9900|M600|1|
|9900|M990|1|
|9900|9900|23|
|9990|26|
|9999|45|
";

            File.WriteAllText("SpedTest1.txt", exampleFromSped);

            var efdContribFile = new FiscalBr.EFDContribuicoes.ArquivoEFDContribuicoes();

            efdContribFile.Ler("SpedTest1.txt");

            Assert.Equal("EMPRESA YYY", efdContribFile.Bloco0.Reg0000.Nome);
        }

        [Fact]
        public void Leitura_Arquivo_EFDFiscal_ASSINADA_Com_Dados_Ficticios()
        {
            var exampleFile =
              @"|0000|017|0|01022023|28022023|EMPRESA YYY|77777777000191||GO|3106200|5204508|||A|1|
|0001|0|
|0005|EMPRESA YYY|75680424|RUA A||QUADRA B LOTE C|BAIRRO D||||
|0100|CONTADOR A||123456|||||||||FALECOM@R6CONSULTORIA.COM.BR|5204508|
|0990|5|
|B001|1|
|B990|2|
|C001|1|
|C990|2|
|D001|1|
|D990|2|
|E001|0|
|E100|01022023|28022023|
|E110|0|0|0|0|0|0|0|0|0|0|0|0|0|0|
|E990|4|
|G001|1|
|G990|2|
|H001|0|
|H005|31122022|0|01|
|H990|3|
|K001|1|
|K990|2|
|1001|0|
|1010|N|N|N|N|N|N|N|N|N|N|N|N|N|
|1990|3|
|9001|0|
|9900|0000|1|
|9900|0001|1|
|9900|0005|1|
|9900|0100|1|
|9900|0990|1|
|9900|B001|1|
|9900|B990|1|
|9900|C001|1|
|9900|C990|1|
|9900|D001|1|
|9900|D990|1|
|9900|E001|1|
|9900|E100|1|
|9900|E110|1|
|9900|E990|1|
|9900|G001|1|
|9900|G990|1|
|9900|H001|1|
|9900|H005|1|
|9900|H990|1|
|9900|K001|1|
|9900|K990|1|
|9900|1001|1|
|9900|1010|1|
|9900|1990|1|
|9900|9001|1|
|9900|9990|1|
|9900|9999|1|
|9900|9900|29|
|9990|32|
|9999|57|
APÓS O REGISTRO 9999 FICA A ASSINATURA DO ARQUIVO, AGORA
QUALQUER INFORMAÇÃO APÓS ESSE REGISTRO SERÁ DESPREZADA NA LEITURA
";

            File.WriteAllText("SpedTest2.txt", exampleFile);

            var efdFiscalFile = new FiscalBr.EFDFiscal.ArquivoEFDFiscal();

            efdFiscalFile.Ler("SpedTest2.txt");

            Assert.Equal("EMPRESA YYY", efdFiscalFile.Bloco0.Reg0000.Nome);
        }
    }
}
