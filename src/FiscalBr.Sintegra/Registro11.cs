using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    /// <summary>
    /// REGISTRO TIPO 11 - DADOS COMPLEMENTARES DO INFORMANTE
    /// </summary>
    public class Registro11 : RegistroBaseSintegra
    {
        /// <summary>
        /// Preencher Registro Tipo 11 do arquivo
        /// </summary>
        /// <param name="Logradouro">Logradouro do endereço do informante</param>
        /// <param name="Numero">Número do endereço do informante</param>
        /// <param name="Complemento">Complemento do endereço do informante</param>
        /// <param name="Bairro">Bairro do endereço do informante</param>
        /// <param name="Cep">Cep do endereço do informante</param>
        /// <param name="NomeContato">Nome para contato</param>
        /// <param name="NumeroContato">Número para contato</param>
        public Registro11(string Logradouro, string Numero, string Complemento, string Bairro, string Cep,
            string NomeContato, string NumeroContato)
        {
            Tipo = "11";
            this.Logradouro = Logradouro;
            this.Numero = string.IsNullOrEmpty(Numero) ? "00000" : Numero;
            this.Complemento = string.IsNullOrEmpty(Numero) && string.IsNullOrEmpty(Complemento) ? "s/nº" : Complemento;
            this.Bairro = Bairro;
            this.Cep = Cep;
            this.NomeContato = NomeContato;
            this.Telefone = NumeroContato;
        }

        /// <summary>
        /// Logradouro
        /// </summary>
        [SintegraCampos(2, "LOGRADOURO", "X", 34, 0, true)]
        public string Logradouro { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        [SintegraCampos(3, "NUMERO", "N", 5, 0, true)]
        public string Numero { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        [SintegraCampos(4, "COMPLEMENTO", "X", 22, 0, false)]
        public string Complemento { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        [SintegraCampos(5, "BAIRRO", "X", 15, 0, true)]
        public string Bairro { get; set; }

        /// <summary>
        /// Código de Enderaçamento Postal
        /// </summary>
        [SintegraCampos(6, "CEP", "N", 8, 0, true)]
        public string Cep { get; set; }

        /// <summary>
        /// Pessoa responsável para contatos
        /// </summary>
        [SintegraCampos(7, "NOME DO CONTATO", "X", 28, 0, true)]
        public string NomeContato { get; set; }

        /// <summary>
        /// Número dos telefones para contatos
        /// </summary>
        [SintegraCampos(8, "TELEFONE", "N", 12, 0, true)]
        public string Telefone { get; set; }
    }
}
