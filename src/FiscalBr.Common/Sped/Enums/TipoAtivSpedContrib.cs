using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FiscalBr.Common.Sped.Enums
{
    public enum TipoAtivSpedContrib
    {
        /// 0 - Industrial ou equiparado a industrial; <para/>
        /// 1 - Prestador de serviços; <para/>
        /// 2 - Atividade de comércio; <para/>
        /// 3 - Pessoas jurídicas referidas nos §§ 6º, 8º e 9º do art. 3º da Lei nº 9.718, de 1998; <para/>
        /// 4 - Atividade imobiliária; <para/>
        /// 9 - Outros.

        /// <summary>
        ///     Industrial ou equiparado a industrial
        /// </summary>
        [DefaultValue("0")] IndustrialOuEquiparado,
        [DefaultValue("1")] PrestadorServicos,
        [DefaultValue("2")] AtividadeComercio,
        [DefaultValue("3")] PjsLei9718de1998,
        [DefaultValue("4")] AtividadeImobiliaria,
        /// <summary>
        ///     Outros
        /// </summary>
        [DefaultValue("9")] Outros
    }
}
