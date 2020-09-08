using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FiscalBr.Common
{
    public static class MetodosAuxiliares
    {
        public static Nullable<T> ToNullable<T>(this string s) where T : struct
        {
            Nullable<T> result = new Nullable<T>();
            try
            {
                if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                    result = (T)conv.ConvertFrom(s);
                }
            }
            catch
            {
            }
            return result;
        }

        public static long ToLong(this string s)
        {
            long result = new long();
            try
            {
                if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(long));
                    result = (long)conv.ConvertFrom(s);
                }
                else result = 0;
            }
            catch
            {
            }
            return result;
        }

        public static string ToStringSafe(this object obj)
        {
            if (obj == null)
                return String.Empty;

            var resultado = obj.ToString();

            // remove caracteres de escapebind
            resultado = resultado.Replace("\r", string.Empty);
            resultado = resultado.Replace("\n", string.Empty);

            return resultado;
        }

        public static int ToInt(this string s)
        {
            if (String.IsNullOrEmpty(s))
                return 0;

            int valorRetornar = 0;
            int.TryParse(s, out valorRetornar);
            return valorRetornar;
        }

        public static int? ToNullableInt(this string s)
        {
            if (String.IsNullOrEmpty(s))
                return new int?();

            int valorretornar = 0;
            int.TryParse(s, out valorretornar);
            return valorretornar;
        }

        public static decimal ToDecimal(this string s)
        {
            decimal result = new decimal();
            try
            {
                if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(decimal));
                    result = (decimal)conv.ConvertFrom(s);
                }
                else result = 0;
            }
            catch
            {
            }
            return result;
        }

        public static double ToDouble(this string s)
        {
            double result = new double();
            try
            {
                if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(double));
                    result = (double)conv.ConvertFrom(s);
                }
                else result = 0;
            }
            catch
            {
            }
            return result;
        }

        public static DateTime ToDateTime(this string s)
        {
            DateTime result = new DateTime();

            if (String.IsNullOrEmpty(s))
                return result;

            try
            {
                if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(DateTime));
                    result = (DateTime)conv.ConvertFrom(s);
                }
                else result = new DateTime();
            }
            catch
            {
            }
            return result;
        }

        public static DateTime? ToDateTimeNullable(this string s)
        {
            var result = new DateTime?();

            if (String.IsNullOrEmpty(s))
                return null;

            try
            {
                if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(DateTime));
                    result = (DateTime)conv.ConvertFrom(s);
                }
                else result = new DateTime();
            }
            catch
            {
            }
            return result;
        }

        public static bool ToBool(this string s)
        {
            if (s == null)
                return false;

            if (s == "true")
                return true;

            if (s.ToLower() == "sim")
                return true;

            return false;
        }

        public static bool? ToBoolNullable(this string s)
        {
            if (String.IsNullOrEmpty(s))
                return new bool?();

            return s.ToBool();
        }

        public static string ToBoolString(this bool b)
        {
            if (b == true)
                return "Sim";
            else
                return "Não";
        }

        /// <summary>
        /// Retorna uma instância do objeto nula
        /// </summary>
        /// <param name="obj">Objeto alvo do método de extensão</param>
        /// <returns>Retorna própria instância do objeto ou uma nova instância com dados default</returns>
        public static T ToBind<T>(this T obj) where T : class, new()
        {
            if (obj != null)
                return obj;

            return new T();
        }


        /// <summary>
        /// Retorna uma instância do objeto nula
        /// </summary>
        /// <param name="obj">Objeto alvo do método de extensão</param>
        /// <returns>Retorna própria instância do objeto ou uma nova instância com dados default</returns>
        public static IList<T> ToBind<T>(this IList<T> obj) where T : class, new()
        {
            if (obj != null)
                return obj;

            return new List<T>();
        }

        /// <summary>
        /// Método de Extensão: Remove um caractere de uma string.
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="caractereRemover">Caractere a se remover</param>
        /// <returns>Retorna a String</returns>
        public static string DeletarCaractere(this string s, string caractereRemover)
        {
            var stringRemover = s;

            while (stringRemover.IndexOf(caractereRemover) > 0)
            {
                var indice = s.IndexOf(caractereRemover);
                stringRemover = stringRemover.Remove(indice, 1);
            }

            return stringRemover;
        }

        /// <summary>
        /// Remove todos os caracteres encontrados na lista de caracteres
        /// </summary>
        /// <param name="s"></param>
        /// <param name="caracteres"></param>
        /// <returns></returns>
        public static string DeletarCaracteres(this string s, string[] caracteresRemover)
        {
            var stringVerificar = s;

            foreach (var caractere in caracteresRemover)
            {
                while (stringVerificar.IndexOf(caractere) > 0)
                {
                    var indice = stringVerificar.IndexOf(caractere);
                    stringVerificar = stringVerificar.Remove(indice, 1);
                }
            }

            return stringVerificar;
        }

        /// <summary>
        /// Utilizado para preencher uma string
        /// </summary>
        /// <param name="conteudoLinha">Informar uma linha com espaços em branco preenchidos</param>
        /// <param name="de">Posição inicial</param>
        /// <param name="ate">Posição final</param>
        /// <param name="valorPreencher">Valor que deve ser inserido na posição</param>
        public static string PreencherValorNaLinha(this string conteudoLinha, int de, int ate, string valorPreencher)
        {
            int inicio = de - 1;

            var tamanhoPreenchimento = ate - inicio;
            if (valorPreencher.Length != tamanhoPreenchimento)
            {
                throw new Exception("Valor a Preencher: " + valorPreencher +
                                    " é diferente do tamanho do preenchimento informado. Posição inicial: " + de +
                                    " até " + ate);
            }

            conteudoLinha = conteudoLinha.Remove(inicio, ate - inicio);

            conteudoLinha = conteudoLinha.Insert(inicio, valorPreencher);

            return conteudoLinha;
        }

        public static DateTime ObterProximoMesPrimeiroDia(this DateTime date)
        {
            return ObterPrimeiroDiaMesAtual(date).AddMonths(1);
        }

        public static DateTime ObterPrimeiroDiaMesAtual(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime ObterUltimoDiaMesAtual(this DateTime date)
        {
            return
                new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month)).AddHours(23)
                    .AddMinutes(59)
                    .AddSeconds(59);
        }

        // This extension method is broken out so you can use a similar pattern with 
        // other MetaData elements in the future. This is your base method for each.
        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        // This method creates a specific call to the above method, requesting the
        // Description MetaData attribute.
        public static string ToDefaultValue(this Enum value)
        {
            var attribute = value.GetAttribute<DefaultValueAttribute>();
            return attribute == null ? value.ToStringSafe() : attribute.Value.ToStringSafe();
        }
    }
}
