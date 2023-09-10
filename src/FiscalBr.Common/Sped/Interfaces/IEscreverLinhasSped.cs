using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface IEscreverLinhasSped
    {
        string EscreverLinha(IRegistroSped reg);
        string EscreverLinha(IRegistroSped reg, DateTime? competencia);
        string EscreverLinha(IRegistroSped reg, DateTime? competencia, bool? removerQuebraLinha);
        string[] EscreverLinhas(IRegistroSped[] regs);
        string[] EscreverLinhas(IRegistroSped[] regs, DateTime? competencia);
        string[] EscreverLinhas(IRegistroSped[] regs, DateTime? competencia, bool? removerQuebraLinha);
        string[] EscreverLinhas(List<IRegistroSped> regs);
        string[] EscreverLinhas(List<IRegistroSped> regs, DateTime? competencia);
        string[] EscreverLinhas(List<IRegistroSped> regs, DateTime? competencia, bool? removerQuebraLinha);
    }
}
