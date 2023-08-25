using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface ICampoSpedVersao
    {
        CodigoVersaoLeiaute[] ObterListaComVersoesLeiaute();
        int ObterVersaoLeiaute(CodigoVersaoLeiaute? versao);
    }
}
