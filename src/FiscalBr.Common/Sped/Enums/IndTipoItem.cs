using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FiscalBr.Common.Sped.Enums
{
    public enum IndTipoItem
    {
        [DefaultValue("00")] MercadoriaRevenda = 0,
        [DefaultValue("01")] MateriaPrima,
        [DefaultValue("02")] Embalagem,
        [DefaultValue("03")] ProdutoEmProcesso,
        [DefaultValue("04")] ProdutoAcabado,
        [DefaultValue("05")] Subproduto,
        [DefaultValue("06")] ProdutoIntermediario,
        [DefaultValue("07")] MaterialUsoConsumo,
        [DefaultValue("08")] AtivoImobilizado,
        [DefaultValue("09")] Servicos,
        [DefaultValue("10")] OutrosInsumos,
        [DefaultValue("99")] Outras = 99
    }
}
