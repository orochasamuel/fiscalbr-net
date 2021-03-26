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
        public event EventHandler<SpedEventArgs> AoLerLinha;
        protected void AoLerLinhaRaise(object sender, SpedEventArgs e)
        {
            if (AoLerLinha != null)
                AoLerLinha.Invoke(sender, e);
        }

        public List<string> Linhas { get; private set; }
        public List<string> Erros { get; private set; }

        public ArquivoSped()
        {
        }

        public virtual void Ler(string path, Encoding encoding = null)
        {
            Erros = new List<string>();

            Linhas = File.ReadAllLines(path, encoding).ToList();

            //Remove linhas em branco
            Linhas.RemoveAll(l => string.IsNullOrEmpty(l.Trim()));
        }

        public virtual void CalcularBloco9()
        {
        }

        public virtual void GerarLinhas()
        {
            Linhas = new List<string>();
        }

        public void Escrever(string path, Encoding encoding = null)
        {
            File.WriteAllLines(path, Linhas.ToArray(), encoding);
        }

        protected void EscreverLinha(RegistroBaseSped registro)
        {
            string erro = string.Empty;
            string texto = registro.EscreverCampos(out erro, null, true);

            if (!string.IsNullOrEmpty(erro))
                Erros.Add(erro);

            Linhas.Add(texto);
        }

    }
}
