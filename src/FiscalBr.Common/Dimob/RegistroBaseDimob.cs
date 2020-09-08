namespace FiscalBr.Common.Dimob
{
    public class RegistroBaseDimob
    {
        [DimobCampos(1, "Tipo", 1, 3, 3, "X")]
        public string Tipo { get; set; }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
