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

        [Fact]
        public void Leitura_Arquivo_EFDFiscal_ASSINADA_Com_Dados_Ficticios_SEM_0000()
        {
            var exampleFile =
              @"|0001|0|
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

            File.WriteAllText("SpedTest3.txt", exampleFile);

            var efdFiscalFile = new FiscalBr.EFDFiscal.ArquivoEFDFiscal();

            efdFiscalFile.Ler("SpedTest3.txt");

            Assert.Equal("EMPRESA YYY", efdFiscalFile.Bloco0.Reg0001.Reg0005.Fantasia);
        }

        [Fact]
        public void Teste_Leitura_Quantidade_Propriedades_EFDFiscal_C500_V2()
        {
            var line = "|C500|1|0|CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)|66|00|9999|000|06|123456789|01012009|01012009|99,99|9,99|0,00|0,00|0,00|0,00|90,00|22,50|0,00|0,00|CODINF|1,49|6,84|{Environment.NewLine}";

            #region ...

            line = line.TrimStart().Substring(1);

            line = line.Remove(line.LastIndexOf('|'));

            // Retorna o registro sem os 'pipes'. Ex: |0000| -> 0000
            var registro = line.Substring(0, line.IndexOf('|', 1));

            var bloco = registro.Substring(0, 1);

            var toInstantiate = $"FiscalBr.{Constantes.ArquivoDigital.Sped.EFDFiscal}.Bloco{bloco}+Registro{registro}, FiscalBr.{Constantes.ArquivoDigital.Sped.EFDFiscal}";

            var objectType = Type.GetType(toInstantiate);

            #endregion ...

            // ...

            var propriedades = FiscalBr.Common.Sped.LerCamposSped.ObtemListaComPropriedadesOrdenadas(objectType, 2);

            Assert.Equal(25, propriedades.Count);
        }

        [Fact]
        public void Teste_Leitura_Quantidade_Propriedades_EFDFiscal_C500_V3()
        {
            var line = "|C500|1|0|CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)|66|00|9999|000|06|123456789|01012009|01012009|99,99|9,99|0,00|0,00|0,00|0,00|90,00|22,50|0,00|0,00|CODINF|1,49|6,84|1|01|{Environment.NewLine}";

            #region ...

            var file = "EFDFiscal";

            line = line.TrimStart().Substring(1);

            line = line.Remove(line.LastIndexOf('|'));

            // Retorna o registro sem os 'pipes'. Ex: |0000| -> 0000
            var registro = line.Substring(0, line.IndexOf('|', 1));

            var bloco = registro.Substring(0, 1);

            var toInstantiate = $"FiscalBr.{file}.Bloco{bloco}+Registro{registro}, FiscalBr.{file}";

            var objectType = Type.GetType(toInstantiate);

            #endregion ...

            // ...

            var propriedades = FiscalBr.Common.Sped.LerCamposSped.ObtemListaComPropriedadesOrdenadas(objectType, 3);

            Assert.Equal(27, propriedades.Count);
        }

        [Fact]
        public void Teste_Leitura_Quantidade_Propriedades_EFDFiscal_C500_V10()
        {
            var line = "|C500|1|0|CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)|66|00|9999|000|06|123456789|01012009|01012009|99,99|9,99|0,00|0,00|0,00|0,00|90,00|22,50|0,00|0,00|CODINF|1,49|6,84|1|01|{Environment.NewLine}";

            #region ...

            var file = "EFDFiscal";

            line = line.TrimStart().Substring(1);

            line = line.Remove(line.LastIndexOf('|'));

            // Retorna o registro sem os 'pipes'. Ex: |0000| -> 0000
            var registro = line.Substring(0, line.IndexOf('|', 1));

            var bloco = registro.Substring(0, 1);

            var toInstantiate = $"FiscalBr.{file}.Bloco{bloco}+Registro{registro}, FiscalBr.{file}";

            var objectType = Type.GetType(toInstantiate);

            #endregion ...

            // ...

            var propriedades = FiscalBr.Common.Sped.LerCamposSped.ObtemListaComPropriedadesOrdenadas(objectType, 10);

            Assert.Equal(27, propriedades.Count);
        }

        [Fact]
        public void Teste_Leitura_Quantidade_Propriedades_EFDFiscal_C500_V14()
        {
            var line = "|C500|1|0|CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)|66|00|9999|000|06|123456789|01012009|01012009|99,99|9,99|0,00|0,00|0,00|0,00|90,00|22,50|0,00|0,00|CODINF|1,49|6,84|1|01|01234567890123456789012345678901234567890123|1||9|1234|3.1.01.01.001|{Environment.NewLine}";

            #region ...

            var file = "EFDFiscal";

            line = line.TrimStart().Substring(1);

            line = line.Remove(line.LastIndexOf('|'));

            // Retorna o registro sem os 'pipes'. Ex: |0000| -> 0000
            var registro = line.Substring(0, line.IndexOf('|', 1));

            var bloco = registro.Substring(0, 1);

            var toInstantiate = $"FiscalBr.{file}.Bloco{bloco}+Registro{registro}, FiscalBr.{file}";

            var objectType = Type.GetType(toInstantiate);

            #endregion ...

            // ...

            var propriedades = FiscalBr.Common.Sped.LerCamposSped.ObtemListaComPropriedadesOrdenadas(objectType, 14);

            Assert.Equal(33, propriedades.Count);
        }

        [Fact]
        public void Teste_Leitura_Quantidade_Propriedades_EFDFiscal_C500_V16()
        {
            var line = @"|C500|1|0|CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)|66|00|9999|000|06|123456789|01012009|01012009|99,99|9,99|0,00|0,00|0,00|0,00|90,00|22,50|0,00|0,00|CODINF|1,49|6,84|1|01|01234567890123456789012345678901234567890123|1||9|1234|3.1.01.01.001|06|1234|1111|123456789|01012009|1,00|1,00|";

            #region ...

            var file = "EFDFiscal";

            line = line.TrimStart().Substring(1);

            line = line.Remove(line.LastIndexOf('|'));

            // Retorna o registro sem os 'pipes'. Ex: |0000| -> 0000
            var registro = line.Substring(0, line.IndexOf('|', 1));

            var bloco = registro.Substring(0, 1);

            var toInstantiate = $"FiscalBr.{file}.Bloco{bloco}+Registro{registro}, FiscalBr.{file}";

            var objectType = Type.GetType(toInstantiate);

            #endregion ...

            // ...

            var propriedades = FiscalBr.Common.Sped.LerCamposSped.ObtemListaComPropriedadesOrdenadas(objectType, 16);

            Assert.Equal(40, propriedades.Count);
        }

        [Fact]
        public void Teste_Leitura_Quantidade_Propriedades_EFDFiscal_C500_V17()
        {
            var line = @"|C500|1|0|CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)|66|00|9999|000|06|123456789|01012009|01012009|99,99|9,99|0,00|0,00|0,00|0,00|90,00|22,50|0,00|0,00|CODINF|1,49|6,84|1|01|01234567890123456789012345678901234567890123|1||9|1234|3.1.01.01.001|06|1234|1111|123456789|01012009|1,00|1,00|";

            #region ...

            var file = "EFDFiscal";

            line = line.TrimStart().Substring(1);

            line = line.Remove(line.LastIndexOf('|'));

            // Retorna o registro sem os 'pipes'. Ex: |0000| -> 0000
            var registro = line.Substring(0, line.IndexOf('|', 1));

            var bloco = registro.Substring(0, 1);

            var toInstantiate = $"FiscalBr.{file}.Bloco{bloco}+Registro{registro}, FiscalBr.{file}";

            var objectType = Type.GetType(toInstantiate);

            #endregion ...

            // ...

            var propriedades = FiscalBr.Common.Sped.LerCamposSped.ObtemListaComPropriedadesOrdenadas(objectType, 17);

            Assert.Equal(40, propriedades.Count);
        }

        [Fact]
        public void Teste_Leitura_Isolada_C500_SEM_Registro_0000_V16()
        {
            var expectedResult = @"|C500|1|0|CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)|66|00|9999|000|06|123456789|01012009|01012009|99,99|9,99|0,00|0,00|0,00|0,00|90,00|22,50|0,00|0,00|CODINF|1,49|6,84|1|01|01234567890123456789012345678901234567890123|1||9|1234|3.1.01.01.001|06|1234|1111|123456789|01012009|1,00|1,00|";

            File.WriteAllText("SpedTestC500v16.txt", expectedResult);

            var efdFiscalFile = new FiscalBr.EFDFiscal.ArquivoEFDFiscal();

            efdFiscalFile.Ler("SpedTestC500v16.txt");

            Assert.Equal("123456789", efdFiscalFile.BlocoC?.RegC001?.RegC500s?.FirstOrDefault()?.NumDoc);
        }

        [Fact]
        public void Teste_Leitura_Isolada_C500_SEM_Registro_0000_V16_VNova()
        {
            var expectedResult = @"|C500|1|0|CLIENTE 1 (USAR CPF/CNPJ PREFERENCIALMENTE)|66|00|9999|000|06|123456789|01012009|01012009|99,99|9,99|0,00|0,00|0,00|0,00|90,00|22,50|0,00|0,00|CODINF|1,49|6,84|1|01|01234567890123456789012345678901234567890123|1||9|1234|3.1.01.01.001|06|1234|1111|123456789|01012009|1,00|1,00|";

            File.WriteAllText("SpedTestC500v16.txt", expectedResult);

            var efdFiscalFile = new FiscalBr.EFDFiscal.ArquivoEFDFiscalV2(VersaoLeiauteSped.V16);

            efdFiscalFile.LerArquivo("SpedTestC500v16.txt");

            Assert.Equal("123456789", efdFiscalFile.BlocoC?.RegC001?.RegC500s?.FirstOrDefault()?.NumDoc);
        }
    }
}
