using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface ISped : ICampoSpedAtributo, ICampoSpedPropriedade, ICampoSpedVersao, IFormatarCampoSped
    {
        string PreencherCampo(object valor, string tpAttr, string tpProp, int tamanho, int qtdCasas, bool ehObrigatorio);
    }
}
