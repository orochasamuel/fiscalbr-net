using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FiscalBr.Common.Sped.Enums
{
    /// <summary>
    ///     Indicador do tipo de conta
    /// </summary>
    public enum IndTipoContaContabil
    {
        /// <summary>
        ///     Sintética (grupo de contas)
        /// </summary>
        [DefaultValue("S")] S,

        /// <summary>
        ///     Analítica (conta)
        /// </summary>
        [DefaultValue("A")] A
    }
}
