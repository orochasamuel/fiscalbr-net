using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface ILerArquivoSped
    {
        List<IRegistroSped> LerArquivo(string caminho);
        List<IRegistroSped> LerArquivo(string caminho, LeiauteArquivoSped tipo);
        List<IRegistroSped> LerArquivo(string caminho, LeiauteArquivoSped tipo, CodigoVersaoLeiaute? versao);
        List<IRegistroSped> LerArquivo(string[] linhas);
        List<IRegistroSped> LerArquivo(string[] linhas, LeiauteArquivoSped tipo);
        List<IRegistroSped> LerArquivo(string[] linhas, LeiauteArquivoSped tipo, CodigoVersaoLeiaute? versao);
    }
}
