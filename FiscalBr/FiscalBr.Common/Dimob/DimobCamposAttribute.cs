using System;

namespace FiscalBr.Common.Dimob
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DimobCamposAttribute : Attribute
    {
        public DimobCamposAttribute(int ordem, string campo, int inicio, int fim, int tamanho, string formato)
        {
            OrdemAtt = ordem;
            CampoAtt = campo;
            InicioAtt = inicio;
            FimAtt = fim;
            TamanhoAtt = tamanho;
            FormatoAtt = formato;
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

        protected int InicioAtt;

        public int Inicio
        {
            get
            {
                return InicioAtt;
            }
        }

        protected int FimAtt;

        public int Fim
        {
            get
            {
                return FimAtt;
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

        protected string FormatoAtt;

        public string Formato
        {
            get
            {
                return FormatoAtt;
            }
        }
    }
}
