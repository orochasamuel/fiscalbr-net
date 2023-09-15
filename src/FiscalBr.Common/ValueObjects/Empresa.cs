using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.ValueObjects
{
    public class Empresa : ValueObject
    {
        protected Empresa() { }

        public Empresa(string razaoSocial, string cpfCnpj, string inscEstadual)
        {
            RazaoSocial = razaoSocial;
            CpfCnpj = cpfCnpj;
            InscEstadual = inscEstadual;
        }

        //public SoftwareHouse(string razaoSocial, CpfCnpj cpfCnpj, Email email)
        //{
        //    RazaoSocial = razaoSocial;
        //    CpfCnpj = cpfCnpj;
        //    Email = email;
        //}

        public string RazaoSocial { get; } = string.Empty;

        public CpfCnpj CpfCnpj { get; } = null;

        public string InscEstadual { get; } = string.Empty;

        public string InscMunicipal { get; } = string.Empty;

        public string InscSuframa { get; } = string.Empty;

        public string CodMunicipio { get; } = string.Empty;

        public string SiglaUf { get; } = string.Empty; 

        public override string ToString() => $"[{CpfCnpj}] {RazaoSocial}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RazaoSocial;
            yield return CpfCnpj;
            yield return InscEstadual;
            yield return InscMunicipal;
            yield return InscSuframa;
            yield return CodMunicipio;
            yield return SiglaUf;
        }
    }
}
