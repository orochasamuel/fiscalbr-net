using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface ILerLinhasSped
    {
        IRegistroSped LerLinha(string linha);
        IRegistroSped LerLinha(string linha, LeiauteArquivoSped tipo);
        IRegistroSped LerLinha(string linha, LeiauteArquivoSped tipo, VersaoLeiauteSped? versao);
        List<IRegistroSped> LerLinhas(string[] linhas);
        List<IRegistroSped> LerLinhas(string[] linhas, LeiauteArquivoSped tipo);
        List<IRegistroSped> LerLinhas(string[] linhas, LeiauteArquivoSped tipo, VersaoLeiauteSped? versao);
        List<IRegistroSped> LerLinhas(List<string> linhas);
        List<IRegistroSped> LerLinhas(List<string> linhas, LeiauteArquivoSped tipo);
        List<IRegistroSped> LerLinhas(List<string> linhas, LeiauteArquivoSped tipo, VersaoLeiauteSped? versao);
    }
}
