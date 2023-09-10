using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface ICampoSpedAtributo
    {
        bool ExisteAtributoSpedNaPropriedade(PropertyInfo prop, int versao);
        //SpedCamposAttribute[] ObterAtributosSpedDoCache(PropertyInfo prop);
        //SpedCamposAttribute ObterAtributoSpedDaPropriedade(PropertyInfo prop);
        SpedCamposAttribute ObterAtributoSpedDaPropriedade(PropertyInfo prop, int? versao);
        SpedRegistrosAttribute ObterAtributoRegistroSped(Type tipo);
        string ObterTipoDoAtributo(SpedCamposAttribute attr);
    }
}
