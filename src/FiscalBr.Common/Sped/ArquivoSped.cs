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
            Linhas = new List<string>();
            Erros = new List<string>();
        }

        public virtual void Ler(string path, Encoding encoding = null)
        {
            Erros = new List<string>();

            Linhas = File.ReadAllLines(path, encoding ?? Encoding.Default).ToList();

            //Remove linhas em branco
            Linhas.RemoveAll(l => string.IsNullOrEmpty(l.Trim()));
        }

        /// <summary>
        /// Calcula o Bloco 9 - 
        /// É necessário que as linhas já estejam geradas. Gere manualmente ou utilize a função "GerarLinhas()".
        /// </summary>
        /// <param name="totalizarblocos">Calcula o totalizados de todos os blocos, ex: 0990, C990, ...</param>
        public virtual void CalcularBloco9(bool totalizarblocos = true)
        {
            if (Linhas == null || !Linhas.Any())
                throw new Exception("Não é possível calcular o bloco 9 sem as linhas. Execute a função \"GerarLinhas()\", gere as linhas manualemnte ou leia um arquivo para preencher as linhas.");
        }

        /// <summary>
        /// Serealiza o objeto no atributo "Linhas"
        /// </summary>
        public virtual void GerarLinhas()
        {
            Linhas = new List<string>();
        }

        public void Escrever(string path, Encoding encoding = null)
        {
            if (Linhas == null || !Linhas.Any())
                throw new Exception("Não é possível escrever sem as linhas. Execute a função \"GerarLinhas()\", gere as linhas manualemnte ou leia um arquivo para preencher as linhas.");

            File.WriteAllLines(path, Linhas.ToArray(), encoding ?? Encoding.Default);
        }

        /// <summary>
        /// Adicionar um objeto do tipo RegistroBaseSped no atributo "Linhas".
        /// Caso existe alguma falha na geração, adiciona a falha no atributo "Erros"
        /// </summary>
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
