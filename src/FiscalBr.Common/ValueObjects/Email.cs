using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FiscalBr.Common.ValueObjects
{
    public class Email
    {
        // Obrigatório para funcionar com EF
        protected Email()
        {
        }

        public Email(string address)
        {
            if (string.IsNullOrEmpty(address) || address.Length < 5)
                throw new ArgumentException(nameof(address));

            Address = address.ToLower().Trim();
            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            if (!Regex.IsMatch(address, pattern))
                throw new Exception("E-mail inválido!");
        }

        public string Address { get; } = string.Empty;

        public static implicit operator string(Email email) => email.Address;

        public static implicit operator Email(string address) => new Email(address);

        public override string ToString() => Address;
    }
}
