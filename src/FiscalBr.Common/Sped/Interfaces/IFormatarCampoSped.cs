using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface IFormatarCampoSped
    {
        string FormatarCampoDateTime(DateTime v);
        string FormatarCampoDateTime(DateTime v, string format);
        string FormatarCampoDateTime(DateTime? v);
        string FormatarCampoDateTime(DateTime? v, string format);
        string FormatarCampoDecimal(decimal v);
        string FormatarCampoDecimal(decimal v, int qtdCasas);
        string FormatarCampoDecimal(decimal? v);
        string FormatarCampoDecimal(decimal? v, int qtdCasas);
        string FormatarCampoInt(int v);
        string FormatarCampoInt(int v, int tamanho);
        string FormatarCampoInt(int? v);
        string FormatarCampoInt(int? v, int tamanho);
        string FormatarCampoString(string v);
        string FormatarCampoString(string v, int tamanho);
        string FormatarCampoString(string v, int tamanho, char caractere);
    }
}
