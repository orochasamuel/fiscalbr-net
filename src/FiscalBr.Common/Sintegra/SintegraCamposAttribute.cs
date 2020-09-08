using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sintegra
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SintegraCamposAttribute : Attribute
    {
        public SintegraCamposAttribute(int ordem, string campo, string tipo, int tamanho, int qtdCasasDecimais, bool isObrigatorio)
        {
            OrdemAtt = ordem;
            CampoAtt = campo;
            TipoAtt = tipo;
            TamanhoAtt = tamanho;
            QtdCasasAtt = qtdCasasDecimais;
            IsObrigatorioAtt = isObrigatorio;
        }

        protected int OrdemAtt;

        public int Ordem => OrdemAtt;

        protected string CampoAtt;

        public string Campo => CampoAtt;

        protected string TipoAtt;

        public string Tipo => TipoAtt;

        protected int TamanhoAtt;

        public int Tamanho => TamanhoAtt;

        protected int QtdCasasAtt;

        public int QtdCasas => QtdCasasAtt;

        protected bool IsObrigatorioAtt;

        public bool IsObrigatorio => IsObrigatorioAtt;
    }
}
