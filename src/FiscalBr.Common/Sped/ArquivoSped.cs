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
        public event EventHandler<SpedEventArgs> AoProcessarLinha;
        protected void AoProcessarLinhaRaise(object sender, SpedEventArgs e)
        {
            if (AoProcessarLinha != null)
                AoProcessarLinha.Invoke(sender, e);
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
            if (Linhas == null || !Linhas.Any())
                throw new Exception("Não é possível calcular o bloco 9 sem as linhas. Chame a função \"GerarLinhas()\" ou leia um arquivo pra fazer o calculo");
        }

        public virtual void GerarLinhas()
        {
            Linhas = new List<string>();
        }

        public void Escrever(string path, Encoding encoding = null) =>
            File.WriteAllLines(path, Linhas.ToArray(), encoding ?? Encoding.Default);

        protected void EscreverLinha(RegistroBaseSped registro)
        {
            string erro;
            string texto = registro.EscreverCampos(out erro, null, true);

            if (!string.IsNullOrEmpty(erro))
                Erros.Add(erro);

            Linhas.Add(texto);
        }      
    }

}
