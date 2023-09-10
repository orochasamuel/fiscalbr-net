using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FiscalBr.Common
{
    public static class DateTimeHelpers
    {
        public static DateTime GetFirstDayOfNextMonth(this DateTime date)
        {
            return GetFirstDayOfCurrentMonth(date).AddMonths(1);
        }

        public static DateTime GetFirstDayOfCurrentMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime GetLastDayOfCurrentMonth(this DateTime date)
        {
            return
                new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month)).AddHours(23)
                    .AddMinutes(59)
                    .AddSeconds(59);
        }
    }

    public static class EnumHelpers
    {
        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        public static string GetEnumDefaultValueByType(Type type, object value)
        {
            /*
             * https://stackoverflow.com/questions/50604295/how-to-get-default-value-of-an-enum-from-a-type-variable
             */
            var enumObj = Enum.ToObject(type, value) as Enum;

            return enumObj.ToDefaultValue();
        }

        public static T GetEnumMaxValue<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Max();
        }

        public static int[] GetEnumValues<T>() where T : Enum
        {
            return (int[])Enum.GetValues(typeof(T));
        }

        public static string ToDefaultValue(this Enum value)
        {
            var attribute = value.GetAttribute<DefaultValueAttribute>();
            return attribute == null ? value.ToStringSafe() : attribute.Value.ToStringSafe();
        }
    }

    public static class StringHelpers
    {
        public static bool HasValue(this string @this)
        {
            return
               !string.IsNullOrEmpty(@this) &&
               !string.IsNullOrWhiteSpace(@this);
        }

        public static bool IsAlphaNumeric(this string @this)
        {
            return !Regex.IsMatch(@this, "[^a-zA-Z0-9]");
        }

        public static bool IsEmpty(this string @this)
        {
            return @this == "";
        }

        public static bool IsNotEmpty(this string @this)
        {
            return @this != "";
        }

        public static bool IsNotNullOrEmpty(this string @this)
        {
            return !string.IsNullOrEmpty(@this);
        }

        public static bool IsNotNullOrWhiteSpace(this string @this)
        {
            return !string.IsNullOrWhiteSpace(@this);
        }

        public static bool IsNumeric(this string @this)
        {
            return !Regex.IsMatch(@this, "[^0-9]");
        }

        public static TEnum ToEnum<TEnum>(this string @this)
        {
            Type enumType = typeof(TEnum);
            return (TEnum)Enum.Parse(enumType, @this);
        }

        public static TEnum ToEnum<TEnum>(this string @this, TEnum defaultValue)
        {
            if (@this.IsNotNullOrEmpty())
                return (TEnum)Enum.Parse(typeof(TEnum), @this, true);

            return defaultValue;
        }
    }

    public static class TypeHelpers
    {
        public static string GetEnumDefaultValueByType(this Type @this, object value)
        {
            /*
             * https://stackoverflow.com/questions/50604295/how-to-get-default-value-of-an-enum-from-a-type-variable
             */
            var enumObj = Enum.ToObject(@this, value) as Enum;

            return enumObj.ToDefaultValue();
        }

        public static bool IsEnumProperty(this Type @this)
        {
            return @this.IsEnum;
        }
    }
}
