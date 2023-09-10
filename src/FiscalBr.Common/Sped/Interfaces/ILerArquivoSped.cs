using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface ILerArquivoSped
    {
        void LerArquivo(string[] linhas);
        void LerArquivo(List<string> linhas);
        void LerArquivo(string caminho, Encoding encoding, VersaoLeiauteSped? versao);
        List<IRegistroSped> LerArquivo(string[] linhas, LeiauteArquivoSped tipo, VersaoLeiauteSped? versao);
    }
}
