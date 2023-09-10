using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface IArquivoSped : IEscreverSped, ILerSped
    {
        LeiauteArquivoSped ArquivoSped { get; }
        VersaoLeiauteSped? VersaoLeiaute { get; }

        int ObterVersaoLeiaute(VersaoLeiauteSped? versaoLeiaute);
        int[] ObterVersoesLeiaute(LeiauteArquivoSped? leiauteSped);
        Enum ObterEnumVersaoLeiaute();
    }
}
