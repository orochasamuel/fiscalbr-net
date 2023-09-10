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

        void CalcularBloco9(bool totalizarBlocos);
        //void GerarBlocoSped(IBlocoSped blocoSped);
        //void GerarRegistroSped(IRegistroSped registroSped);

        int ObterVersaoLeiaute(VersaoLeiauteSped? versaoLeiaute);
        int[] ObterVersoesLeiaute(LeiauteArquivoSped? leiauteSped);
        Enum ObterEnumVersaoLeiaute();
    }
}
