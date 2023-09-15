using System.ComponentModel;

namespace FiscalBr.Common.Sped.Enums
{
    public enum IndTipoOperacaoServico
    {
        /// <summary>
        ///     Aquisição
        /// </summary>
        [DefaultValue("0")] Aquisicao,

        /// <summary>
        ///     Prestação
        /// </summary>
        [DefaultValue("1")] Prestacao
    }
}
