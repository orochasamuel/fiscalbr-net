using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FiscalBr.Common.Sped.Enums
{
    /// <summary>
    ///     Código da Natureza da conta/grupo de contas
    /// </summary>
    public enum IndTipoNaturezaContaContabil
    {
        /// <summary>
        ///     Contas de ativo
        /// </summary>
        [DefaultValue("01")] ContasAtivo = 1,

        /// <summary>
        ///     Contas de passivo
        /// </summary>
        [DefaultValue("02")] ContasPassivo,

        /// <summary>
        ///     Patrimônio líquido
        /// </summary>
        [DefaultValue("03")] PatrimonioLiquido,

        /// <summary>
        ///     Contas de resultado
        /// </summary>
        [DefaultValue("04")] ContasResultado,

        /// <summary>
        ///     Contas de compensação
        /// </summary>
        [DefaultValue("05")] ContasCompensacao,

        /// <summary>
        ///     Outras
        /// </summary>
        [DefaultValue("09")] Outras = 9
    }
}
