using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface IEscreverArquivoSped
    {
        void EscreverArquivo(string caminho, Encoding encoding);
    }
}
