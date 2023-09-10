using FiscalBr.Common.Tipos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FiscalBr.Common.ValueObjects
{
    public class CpfCnpj : ValueObject
    {
        public readonly bool EhCpf;

        public readonly bool EhValido;

        protected CpfCnpj() { }

        public CpfCnpj(string value)
        {
            // TODO: Diminuir a quantidade de ifs
            if (string.IsNullOrEmpty(value) || value.Length < 11)
            {
                EhValido = false;
                return;
            }

            // Remover outros caracteres e deixar somente números
            Numero = value.Trim();

            if (Numero.Length == 0)
            {
                EhValido = false;
                return;
            }

            if (Numero.Length > 11)
            {
                Cnpj = Numero;
                EhCpf = false;

                EhValido = Cnpj.EhValido;
            }
            else
            {
                Cpf = Numero;
                EhCpf = true;

                EhValido = Cpf.EhValido;
            }
        }

        private Cpf Cpf { get; } = null;
        private Cnpj Cnpj { get; } = null;

        public string Numero { get; } = string.Empty;

        public static implicit operator string(CpfCnpj cpfCnpj) => cpfCnpj.Numero;

        public static implicit operator CpfCnpj(string cpfCnpj) => new CpfCnpj(cpfCnpj);

        public override string ToString() => Numero;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Cpf;
            yield return Cnpj;
            yield return Numero;
        }
    }
}
