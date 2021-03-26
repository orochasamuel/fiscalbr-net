using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FiscalBr.Common.Sped
{
    public sealed class SpedEventArgs : EventArgs
    {
        public string Linha { get; set; }
        public RegistroBaseSped Registro { get; set; }
    }

    public abstract class ArquivoSped
    {
        public event EventHandler<EventArgs> AoLerLinha;
        protected void AoLerLinhaRaise(object sender, EventArgs e)
        {
            if (AoLerLinha != null)
                AoLerLinha.Invoke(sender, e);
        }

        public List<string> Linhas { get; private set; }

        public ArquivoSped()
        {
        }

        public virtual void Ler(string path)
        {
            Linhas = File.ReadAllLines(path).ToList();

            //Remove linhas em branco
            Linhas.RemoveAll(l => string.IsNullOrEmpty(l.Trim()));
        }

        public virtual void Escrever(string path)
        {
        }

        public virtual void CalcularBloco9()
        {
        }

    }
}
