using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FiscalBr.Common.Sped
{
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

        public virtual void Ler(string path, Encoding encoding = null, int codVersaoLayout = 0)
        {
            if (!File.Exists(path))
                throw new Exception("O arquivo não existe! Verifique e tente novamente.");

            Erros = new List<string>();

            // TODO: Alterar para remover os espaços em branco antes do primeiro pipe e após o último pipe.
            Linhas = File.ReadAllLines(path, encoding ?? Encoding.Default).ToList();

            if (ExisteAssinaturaNoArquivo())
                RemoverLinhasDeAssinatura();

            RemoverLinhasVazias();
        }

        public virtual void Ler(string[] source)
        {
            if (source == null || source.Length == 0) throw new Exception("Nada a ser lido! Verifique e tente novamente");

            Erros = new List<string>();

            Linhas = source.ToList();

            if (ExisteAssinaturaNoArquivo())
                RemoverLinhasDeAssinatura();

            RemoverLinhasVazias();
        }

        private void RemoverLinhasVazias()
        {
            //Remove linhas em branco
            Linhas.RemoveAll(l => string.IsNullOrEmpty(l.Trim()));
        }

        private void RemoverLinhasDeAssinatura()
        {
            var index9999 = Linhas.FindIndex(p => p.StartsWith("|9999"));

            var startsAt = index9999 + 1;
            var countedToDelete = Linhas.Count - startsAt;

            Linhas.RemoveRange(startsAt, countedToDelete);
        }

        private bool ExisteAssinaturaNoArquivo()
        {
            var index9999 = Linhas.FindIndex(p => p.StartsWith("|9999"));

            if (index9999 < 0)
                return false;

            if (Linhas.Count > index9999 + 1)
                return true;

            return false;
        }

        public int ObterVersaoLayout()
        {
            var versaoLayout = ObterUltimaVersaoDisponivelLayout();

            if (Linhas.Count > 0)
            {
                var index0000 = Linhas.FindIndex(p => p.StartsWith("|0000"));

                if (index0000 < 0)
                    return versaoLayout;

                var primeiraLinha = Linhas.ElementAt(index0000);

                var dados = primeiraLinha.Split('|');

                /*
                 * [0] Primeiro pipe estará em branco
                 * [1] Segundo pipe é do Registro 0000
                 * [2] Terceiro pipe é o que queremos, a versão do layout
                 */
                var versaoLayoutArquivoLido = dados[2].ToInt();

                if (versaoLayoutArquivoLido > 0 && versaoLayoutArquivoLido != versaoLayout)
                    versaoLayout = versaoLayoutArquivoLido;
            }

            return versaoLayout;
        }

        private int ObterUltimaVersaoDisponivelLayout()
        {
            return Enum.GetValues(typeof(VersaoLeiauteSped)).Cast<int>().Max();
        }

        private int ObterPrimeiraVersaoLayout()
        {
            return Enum.GetValues(typeof(VersaoLeiauteSped)).Cast<int>().Min();
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
        protected void EscreverLinha(RegistroSped registro)
        {
            string erro;
            string texto = registro.EscreverCampos(out erro, null, true);

            if (!string.IsNullOrEmpty(erro))
                Erros.Add(erro);

            Linhas.Add(texto);
        }

        protected virtual void GerarComFilhos(object registro)
        {
            if (registro == null)
                return;

            //Testa antes porque porque pode-se tratar de um bloco
            if (registro is RegistroSped)
                EscreverLinha(registro as RegistroSped);

            var tipo = registro.GetType();

            var propriedades = tipo
                                .GetProperties()
                                .ToList();

            foreach (var propriedade in propriedades)
            {
                var valor = propriedade.GetValue(registro);

                if (valor == null)
                    continue;

                if (valor is RegistroSped)
                    GerarComFilhos(valor);

                //Lista de objetos
                else if (valor is System.Collections.IList)
                {
                    var lista = (System.Collections.IList)valor;

                    foreach (var item in lista)
                        GerarComFilhos(item);
                }
            }

        }
    }

}
