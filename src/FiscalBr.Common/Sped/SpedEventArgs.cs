using System;
using FiscalBr.Common.Sped.Interfaces;

namespace FiscalBr.Common.Sped
{
    public sealed class SpedEventArgs : EventArgs
    {
        public string Linha { get; set; }
        public IRegistroSped Registro { get; set; }
    }
}
