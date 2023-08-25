using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FiscalBr.Common.Sped.Interfaces;

namespace FiscalBr.Common.Sped
{
    public abstract class RegistroSped : IRegistroSped
    {
        [SpedCampos(1, "REG", "C", 4, 0, true, 2)]
        public string Reg { get; private set; }

        protected RegistroSped()
        {
        }

        /// <summary>
        /// Inicializa o valor do campo REG no registro SPED
        /// </summary>
        /// <param name="reg"></param>
        public RegistroSped(string reg)
        {
            Reg = reg;
        }

        public static object GetPropValue(IRegistroSped src, string propName)
        {
            var property = src.GetType().GetProperty(propName);

            var propertyValue = property?.GetValue(src);

            if (TypeHelpers.IsEnumProperty(property?.PropertyType))
                propertyValue = TypeHelpers.GetEnumDefaultValueByType(property.PropertyType, propertyValue);

            return propertyValue;
        }

        public virtual bool Validar()
        {
            return true;
        }
    }
}
