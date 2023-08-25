using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped.Interfaces
{
    public interface IRegistroSped
    {
        string Reg { get; }
        bool Validar();
    }
}
