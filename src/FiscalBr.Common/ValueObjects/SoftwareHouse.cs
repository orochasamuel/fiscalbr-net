using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.ValueObjects
{
    public class SoftwareHouse : ValueObject
    {
        protected SoftwareHouse() { }

        public SoftwareHouse(string razaoSocial, string cpfCnpj, string email)
        {
            RazaoSocial = razaoSocial;
            CpfCnpj = cpfCnpj;
            Email = email;
        }

        //public SoftwareHouse(string razaoSocial, CpfCnpj cpfCnpj, Email email)
        //{
        //    RazaoSocial = razaoSocial;
        //    CpfCnpj = cpfCnpj;
        //    Email = email;
        //}

        public string RazaoSocial { get; } = string.Empty;

        public CpfCnpj CpfCnpj { get; } = null;

        public Email Email { get; } = null;

        public override string ToString() => $"[{CpfCnpj}] {RazaoSocial}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RazaoSocial;
            yield return CpfCnpj;
            yield return Email;
        }
    }
}
