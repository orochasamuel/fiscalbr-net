using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface ICampoSpedPropriedade
    {
        bool EhPropriedadeSomenteLeitura(PropertyInfo prop);
        List<PropertyInfo> ObterListaComPropriedadesDoTipo(Type t);
        string ObterTipoDaPropriedade(PropertyInfo prop);
    }
}
