using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FiscalBr.Common.Sped
{
    public sealed class SpedEventArgs : EventArgs
    {
        public string Linha { get; set; }
        public RegistroSped Registro { get; set; }
    }
}
