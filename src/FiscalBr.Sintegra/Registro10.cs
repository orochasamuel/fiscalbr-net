using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    /// <summary>
    /// REGISTRO TIPO 10 - MESTRE DO ESTABELECIMENTO
    /// </summary>
    public class Registro10 : RegistroBaseSintegra
    {
        /// <summary>
        /// Preencher Registro Tipo 10 do arquivo
        /// </summary>
        /// <param name="Cnpj">Inscrição CNPJ do informante</param>
        /// <param name="Ie">Inscrição estadual do informante</param>
        /// <param name="RazaoSocial">Razão social do informante</param>
        /// <param name="Municipio">Município do informante</param>
        /// <param name="Uf">UF do informante</param>
        /// <param name="Fax">FAX do informante</param>
        /// <param name="DataInicial">Data inicial das informações do arquivo</param>
        /// <param name="DataFinal">Data final das informações do arquivo</param>
        /// <param name="CodFin">Código de Finalidade do Arquivo. 1 - Normal; 2 - Retificadora; 3 - Vedado; 5 - Desfazimento.</param>
        /// <param name="CodEstrut">Código de Estrutura do Arquivo</param>
        /// <param name="CodNat">Código da Natureza das Operações</param>
        public Registro10(string Cnpj, string Ie, string RazaoSocial, string Municipio, string Uf, string Fax,
            DateTime DataInicial, DateTime DataFinal, CodFinalidadeArquivo CodFin,
            CodEstruturaArquivo CodEstrut = CodEstruturaArquivo.Cod3,
            CodNaturezaOperacoes CodNat = CodNaturezaOperacoes.Cod3)
        {
            Tipo = "10";
            this.Cnpj = Cnpj;
            this.InscrEstadual = Ie;
            this.NomeContribuinte = RazaoSocial;
            this.Municipio = Municipio;
            this.Uf = Uf;
            this.Fax = Fax;
            this.DataInicial = DataInicial;
            this.DataFinal = DataFinal;
            this.CodEstruturaArquivo = CodEstrut;
            this.CodNaturezaOperacoes = CodNat;
            this.CodFinalidadeArquivo = CodFin;
        }

        /// <summary>
        /// CGC/MF -> CNPJ do estabelecimento informante
        /// </summary>
        [SintegraCampos(2, "CNPJ", "N", 14, 0, true)]
        public string Cnpj { get; set; }

        /// <summary>
        /// Inscrição estadual do estabelecimento informante
        /// </summary>
        [SintegraCampos(3, "INSCRIÇÃO ESTADUAL", "X", 14, 0, true)]
        public string InscrEstadual { get; set; }

        /// <summary>
        /// Nome comercial (razão social/denominação) do contribuinte
        /// </summary>
        [SintegraCampos(4, "NOME DO CONTRIBUINTE", "X", 35, 0, true)]
        public string NomeContribuinte { get; set; }

        /// <summary>
        /// Município onde está domiciliado o estabelecimento informante
        /// </summary>
        [SintegraCampos(5, "MUNICÍPIO", "X", 30, 0, true)]
        public string Municipio { get; set; }

        /// <summary>
        /// Unidade da federação referente ao município
        /// </summary>
        [SintegraCampos(6, "UF", "X", 2, 0, true)]
        public string Uf { get; set; }

        /// <summary>
        /// Número do fax do estabelecimento informante
        /// </summary>
        [SintegraCampos(7, "FAX", "N", 10, 0, true)]
        public string Fax { get; set; }

        /// <summary>
        /// A data de início do período referente às informações prestadas
        /// </summary>
        [SintegraCampos(8, "DATA INICIAL", "N", 8, 0, true)]
        public DateTime DataInicial { get; set; }

        /// <summary>
        /// A data do fim do período referente às informações prestadas
        /// </summary>
        [SintegraCampos(9, "DATA FINAL", "N", 8, 0, true)]
        public DateTime DataFinal { get; set; }

        public CodEstruturaArquivo CodEstruturaArquivo { get; set; }

        /// <summary>
        /// Código da identificação da estrutura do arquivo magnético entregue
        /// </summary>
        [SintegraCampos(10, "CÓDIGO DA ESTRUTURA", "X", 1, 0, true)]
        public int CodEstrutura
        {
            get
            {
                var retorno = 3;

                switch (CodEstruturaArquivo)
                {
                    case CodEstruturaArquivo.Cod1:
                        retorno = 1;
                        break;
                    case CodEstruturaArquivo.Cod2:
                        retorno = 2;
                        break;
                    case CodEstruturaArquivo.Cod3:
                        retorno = 3;
                        break;
                }

                return retorno;
            }
        }

        public CodNaturezaOperacoes CodNaturezaOperacoes { get; set; }

        /// <summary>
        /// Código da identificação da natureza das operações informadas
        /// </summary>
        [SintegraCampos(11, "CÓDIGO DAS OPERAÇÕES", "X", 1, 0, true)]
        public int CodOperacoes
        {
            get
            {
                var retorno = 3;

                switch (CodNaturezaOperacoes)
                {
                    case CodNaturezaOperacoes.Cod1:
                        retorno = 1;
                        break;
                    case CodNaturezaOperacoes.Cod2:
                        retorno = 2;
                        break;
                    case CodNaturezaOperacoes.Cod3:
                        retorno = 3;
                        break;
                }

                return retorno;
            }
        }

        public CodFinalidadeArquivo CodFinalidadeArquivo { get; set; }

        /// <summary>
        /// Código de finalidade utilizado no arquivo magnético
        /// </summary>
        [SintegraCampos(12, "CÓDIGO DA FINALIDADE", "X", 1, 0, true)]
        public int CodFinalidade
        {
            get
            {
                var retorno = 3;

                switch (CodFinalidadeArquivo)
                {
                    case CodFinalidadeArquivo.Cod1:
                        retorno = 1;
                        break;
                    case CodFinalidadeArquivo.Cod2:
                        retorno = 2;
                        break;
                    case CodFinalidadeArquivo.Cod3:
                        retorno = 3;
                        break;
                    case CodFinalidadeArquivo.Cod5:
                        retorno = 5;
                        break;
                }

                return retorno;
            }
        }
    }
}
