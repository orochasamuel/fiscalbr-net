using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FiscalBr.Common.ValueObjects
{
    public class Email : ValueObject
    {
        public readonly bool EhValido;

        protected Email() { }

        public Email(string email)
        {
            if (string.IsNullOrEmpty(email) || email.Length < 5)
            {
                EhValido = false;
                return;
            }

            Endereco = email.ToLower().Trim();
            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            //if (!Regex.IsMatch(email, pattern))
            //{
            //    EhValido = false;
            //    return;
            //}

            EhValido = Regex.IsMatch(email, pattern);
        }

        public string Endereco { get; private set; } = string.Empty;

        public static implicit operator string(Email email) => email.Endereco;
        
        public static implicit operator Email(string email) => new Email(email);

        public override string ToString() => Endereco;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Endereco;
        }
    }
}
