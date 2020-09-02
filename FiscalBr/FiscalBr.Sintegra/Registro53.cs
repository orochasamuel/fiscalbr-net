using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    /// <summary>
    /// REGISTRO TIPO 53 - SUBSTITUIÇÃO TRIBUTÁRIA
    /// </summary>
    public class Registro53 : RegistroBaseSintegra
    {
        public Registro53()
        {
            Tipo = "53";
        }

        /// <summary>
        /// CNPJ do contribuinte substituído
        /// </summary>
        [SintegraCampos(2, "CNPJ", "N", 14, 0, true)]
        public string Cnpj { get; set; }

        /// <summary>
        /// Inscrição estadual do contribuinte substituído
        /// </summary>
        [SintegraCampos(3, "INSCRIÇÃO ESTADUAL", "X", 14, 0, true)]
        public string InscrEstadual { get; set; }

        /// <summary>
        /// Data de emissão na saída ou recebimento na entrada
        /// </summary>
        [SintegraCampos(4, "DATA DE EMISSÃO/RECEBIMENTO", "X", 8, 0, true)]
        public DateTime DataEmissaoRecbto { get; set; }

        /// <summary>
        /// Sigla da unidade da federação do contribuinte substituído
        /// </summary>
        [SintegraCampos(5, "UF", "X", 2, 0, true)]
        public string Uf { get; set; }

        /// <summary>
        /// Código do modelo da nota fiscal
        /// </summary>
        [SintegraCampos(6, "MODELO", "N", 2, 0, true)]
        public int Modelo { get; set; }

        /// <summary>
        /// Série da nota fiscal
        /// </summary>
        [SintegraCampos(7, "SÉRIE", "X", 3, 0, true)]
        public string Serie { get; set; }

        /// <summary>
        /// Número da nota fiscal
        /// </summary>
        [SintegraCampos(8, "NÚMERO", "N", 6, 0, true)]
        public int Numero { get; set; }

        /// <summary>
        /// Código fiscal da operação ou prestação
        /// </summary>
        [SintegraCampos(9, "CFOP", "N", 4, 0, true)]
        public int Cfop { get; set; }

        /// <summary>
        /// Emitente da nota fiscal
        /// P - Próprio; ou
        /// T - Terceiros
        /// </summary>
        [SintegraCampos(10, "EMITENTE", "X", 1, 0, true)]
        public string Emitente { get; set; }

        /// <summary>
        /// Base de cálculo de retenção do ICMS (com 2 decimais)
        /// </summary>
        [SintegraCampos(11, "BASE ICMS ST", "N", 13, 2, false)]
        public decimal? BaseIcmsSt { get; set; }

        /// <summary>
        /// ICMS retido pelo substituto (com 2 decimais)
        /// </summary>
        [SintegraCampos(12, "ICMS RETIDO", "N", 13, 2, false)]
        public decimal? VlIcmsRetido { get; set; }

        /// <summary>
        /// Soma das despesas acessórias (frete, seguro e outras - com 2 decimais)
        /// </summary>
        [SintegraCampos(13, "DESPESAS ACESSÓRIAS", "N", 13, 2, false)]
        public decimal? VlDespesasAcessorias { get; set; }

        /// <summary>
        /// Situação da nota fiscal
        /// N - Normal;
        /// S - Cancelado;
        /// E - Normal Extemporâneo; e
        /// X - Cancelado Extemporâneo.
        /// </summary>
        [SintegraCampos(14, "SITUAÇÃO", "X", 1, 0, true)]
        public string Situacao { get; set; }

        /// <summary>
        /// Código que identificca o tipo de antecipação tributária
        /// </summary>
        [SintegraCampos(15, "CÓDIGO DE ANTECIPAÇÃO", "X", 1, 0, true)]
        public string CodigoAntecipacao { get; set; }

        /// <summary>
        /// Brancos
        /// </summary>
        [SintegraCampos(16, "BRANCOS", "X", 29, 0, true)]
        public string Brancos
        {
            get
            {
                return new string(' ', 29);
            }
        }
    }
}
