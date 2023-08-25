using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface IArquivoSped : IEscreverSped, ILerSped
    {
        LeiauteArquivoSped ArquivoSped { get; }
        CodigoVersaoLeiaute VersaoLeiaute { get; }
    }
}
