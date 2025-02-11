using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
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


        public static object GetPropValue(IRegistroSped src, string prop) 
        {
            var property = src.GetType().GetProperty(prop);
            return GetPropValue(src, property);
        }

        private static ConcurrentDictionary<PropertyInfo, Func<object, object>> PropertyGetMethodsCache = new ConcurrentDictionary<PropertyInfo, Func<object, object>>();
        public static object GetPropValue(IRegistroSped src, PropertyInfo prop) 
        {
            var method = PropertyGetMethodsCache.GetOrAdd(prop, (property) => {

                if (TypeHelpers.IsEnumProperty(property?.PropertyType))
                    return (obj) => TypeHelpers.GetEnumDefaultValueByType(property.PropertyType, property.GetValue(obj));

                return property.GetValue;
            });
            return method(src);
        }
        public virtual bool Validar()
        {
            return true;
        }
    }
}
