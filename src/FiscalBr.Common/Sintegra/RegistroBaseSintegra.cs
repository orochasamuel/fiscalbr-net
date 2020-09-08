using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sintegra
{
    public class RegistroBaseSintegra
    {
        [SintegraCampos(1, "TIPO", "N", 2, 0, true)]
        public string Tipo { get; set; }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
