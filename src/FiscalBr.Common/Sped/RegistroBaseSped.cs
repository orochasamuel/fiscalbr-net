using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped
{
    [Obsolete]
    public class RegistroBaseSped
    {
        [SpedCampos(1, "REG", "C", 4, 0, true, 2)]
        public string Reg { get; set; }

        public static object GetPropValue(object src, string propName)
        {
            var property = src.GetType().GetProperty(propName);
            var propertyType = property.PropertyType;

            var propertyValue = property.GetValue(src, null);

            if (propertyType.IsEnum)
                propertyValue = GetEnumDefaultValueByType(propertyType, propertyValue);

            return propertyValue;
        }

        public static string GetEnumDefaultValueByType(Type type, object value)
        {
            /*
             * https://stackoverflow.com/questions/50604295/how-to-get-default-value-of-an-enum-from-a-type-variable
             */
            var enumObj = Enum.ToObject(type, value) as Enum;

            return enumObj.ToDefaultValue();
        }

        public virtual bool EhValido()
        {
            return true;
        }
    }
}