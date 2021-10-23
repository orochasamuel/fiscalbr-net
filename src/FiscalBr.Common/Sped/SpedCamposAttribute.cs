using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class SpedCamposAttribute : Attribute
    {
        public SpedCamposAttribute(int ordem, string campo, string tipo, int tamanho, int qtdCasasDecimais, bool isObrigatorio, int versao)
        {
            OrdemAtt = ordem;
            CampoAtt = campo;
            TipoAtt = tipo;
            TamanhoAtt = tamanho;
            QtdCasasAtt = qtdCasasDecimais;
            IsObrigatorioAtt = isObrigatorio;
            VersaoAtt = versao;
        }

        protected int OrdemAtt;

        public int Ordem
        {
            get
            {
                return OrdemAtt;
            }
        }

        protected string CampoAtt;

        public string Campo
        {
            get
            {
                return CampoAtt;
            }
        }

        protected string TipoAtt;

        public string Tipo
        {
            get
            {
                return TipoAtt;
            }
        }

        protected int TamanhoAtt;

        public int Tamanho
        {
            get
            {
                return TamanhoAtt;
            }
        }

        protected int QtdCasasAtt;

        public int QtdCasas
        {
            get
            {
                return QtdCasasAtt;
            }
        }

        protected bool IsObrigatorioAtt;

        public bool IsObrigatorio
        {
            get
            {
                return IsObrigatorioAtt;
            }
        }

        protected int VersaoAtt;

        public int Versao
        {
            get
            {
                return VersaoAtt;
            }
        }
    }
}
