using System;

namespace FiscalBr.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SpedRegistrosAttribute : Attribute
    {
        public SpedRegistrosAttribute(string obrigatoriedadeInicial, string obrigatoriedadeFinal)
        {
            ObrigatoriedadeInicialAtt = obrigatoriedadeInicial;
            ObrigatoriedadeFinalAtt = obrigatoriedadeFinal;
        }

        protected string ObrigatoriedadeInicialAtt;

        public string ObrigatoriedadeInicial
        {
            get
            {
                return ObrigatoriedadeInicialAtt;
            }
        }

        protected string ObrigatoriedadeFinalAtt;

        public string ObrigatoriedadeFinal
        {
            get
            {
                return ObrigatoriedadeFinalAtt;
            }
        }
    }
}
