using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FiscalBr.Common.Sped.Enums
{
    public enum TipoAtivSpedFiscal
    {
        /// <summary>
        ///     Industrial ou equiparado a industrial
        /// </summary>
        [DefaultValue("0")] IndustrialOuEquiparado,

        /// <summary>
        ///     Outros
        /// </summary>
        [DefaultValue("1")] Outros
    }
}
