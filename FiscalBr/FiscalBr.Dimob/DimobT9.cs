using FiscalBr.Common.Dimob;

namespace FiscalBr.Dimob
{
    /// <summary>
    /// Trailler da Declaração - T9
    /// </summary>
    public class DimobT9 : RegistroBaseDimob
    {
        public DimobT9()
        {
            Tipo = "T9";
        }

        [DimobCampos(2, "Reservado", 3, 102, 99, "Branco(s)")]
        public string Reservado { get; private set; }
    }
}
