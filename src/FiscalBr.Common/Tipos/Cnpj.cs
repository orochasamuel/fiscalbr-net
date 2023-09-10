using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Tipos
{
    public struct Cnpj
    {
        private readonly string _value;

        public readonly bool EhValido;
        static readonly int[] Multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        static readonly int[] Multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        private Cnpj(string value)
        {
            _value = value;

            if (value == null)
            {
                EhValido = false;
                return;
            }

            var digitosIdenticos = true;
            var ultimoDigito = -1;
            var posicao = 0;
            var totalDigito1 = 0;
            var totalDigito2 = 0;

            foreach (var c in _value)
            {
                if (char.IsDigit(c))
                {
                    var digito = c - '0';
                    if (posicao != 0 && ultimoDigito != digito)
                    {
                        digitosIdenticos = false;
                    }

                    ultimoDigito = digito;
                    if (posicao < 12)
                    {
                        totalDigito1 += digito * Multiplicador1[posicao];
                        totalDigito2 += digito * Multiplicador2[posicao];
                    }
                    else if (posicao == 12)
                    {
                        var dv1 = (totalDigito1 % 11);
                        dv1 = dv1 < 2
                            ? 0
                            : 11 - dv1;

                        if (digito != dv1)
                        {
                            EhValido = false;
                            return;
                        }

                        totalDigito2 += dv1 * Multiplicador2[12];
                    }
                    else if (posicao == 13)
                    {
                        var dv2 = (totalDigito2 % 11);

                        dv2 = dv2 < 2
                            ? 0
                            : 11 - dv2;

                        if (digito != dv2)
                        {
                            EhValido = false;
                            return;
                        }
                    }

                    posicao++;
                }
            }

            EhValido = (posicao == 14) && !digitosIdenticos;
        }

        public static Cnpj Parse(string cnpj)
        {
            if (TryParse(cnpj, out var result))
            {
                return result;
            }
            throw new ArgumentException(nameof(cnpj));
        }

        public static bool TryParse(string value, out Cnpj cnpj)
        {
            cnpj = new Cnpj(value);
            return true;
        }

        //public static implicit operator Cnpj(long value)
        //    => Parse(value);

        public static implicit operator Cnpj(string value)
            => Parse(value);

        public override string ToString()
            => _value;
    }

    //public static bool ValidarCNPJ(Cnpj cnpj)
    //    => cnpj.EhValido;
}
