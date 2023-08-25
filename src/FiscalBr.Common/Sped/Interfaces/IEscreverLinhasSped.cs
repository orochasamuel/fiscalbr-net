using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface IEscreverLinhasSped
    {
        string EscreverLinha(IRegistroSped reg);
        string EscreverLinha(IRegistroSped reg, CodigoVersaoLeiaute? versao);
        string EscreverLinha(IRegistroSped reg, CodigoVersaoLeiaute? versao, DateTime? competencia);
        string EscreverLinha(IRegistroSped reg, CodigoVersaoLeiaute? versao, DateTime? competencia, bool? removerQuebraLinha);
        string[] EscreverLinhas(IRegistroSped[] regs);
        string[] EscreverLinhas(IRegistroSped[] regs, CodigoVersaoLeiaute? versao);
        string[] EscreverLinhas(List<IRegistroSped> regs);
        string[] EscreverLinhas(List<IRegistroSped> regs, CodigoVersaoLeiaute? versao);
    }
}
