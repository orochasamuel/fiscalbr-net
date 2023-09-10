using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface IEscreverLinhasSped
    {
        string EscreverLinha(IRegistroSped reg, DateTime? competencia, bool? removerQuebraLinha);
        string[] EscreverLinhas(List<IRegistroSped> regs, DateTime? competencia, bool? removerQuebraLinha);
    }
}
