using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    /// <summary>
    /// REGISTRO TIPO 51 - IPI
    /// </summary>
    public class Registro51 : RegistroBaseSintegra
    {
        public Registro51()
        {
            Tipo = "51";
        }

        /// <summary>
        /// CNPJ do remetente nas entradas e do destinatário nas saídas
        /// </summary>
        [SintegraCampos(2, "CNPJ", "N", 14, 0, true)]
        public string Cnpj { get; set; }

        /// <summary>
        /// Inscrição estadual do remetente nas entradas e do destinatário nas saídas
        /// </summary>
        [SintegraCampos(3, "INSCRIÇÃO ESTADUAL", "X", 14, 0, true)]
        public string InscrEstadual { get; set; }

        /// <summary>
        /// Data de emissão na saída ou recebimento na entrada
        /// </summary>
        [SintegraCampos(4, "DATA DE EMISSÃO/RECEBIMENTO", "N", 8, 0, true)]
        public DateTime DataEmissaoRecbto { get; set; }

        /// <summary>
        /// Sigla da unidade da federação do remetente nas entradas e do destinatário nas saídas
        /// </summary>
        [SintegraCampos(5, "UF", "X", 2, 0, true)]
        public string Uf { get; set; }

        /// <summary>
        /// Série da nota fiscal
        /// </summary>
        [SintegraCampos(6, "SÉRIE", "X", 3, 0, true)]
        public string Serie { get; set; }

        /// <summary>
        /// Número da nota fiscal
        /// </summary>
        [SintegraCampos(7, "NÚMERO", "N", 6, 0, true)]
        public int Numero { get; set; }

        /// <summary>
        /// Código fiscal de operação ou prestação
        /// </summary>
        [SintegraCampos(8, "CFOP", "N", 4, 0, true)]
        public int Cfop { get; set; }

        /// <summary>
        /// Valor total da nota fiscal (com 2 decimais)
        /// </summary>
        [SintegraCampos(9, "VALOR TOTAL", "N", 13, 2, true)]
        public decimal VlTotal { get; set; }

        /// <summary>
        /// Montante do IPI (com 2 decimais)
        /// </summary>
        [SintegraCampos(10, "VALOR DO IPI", "N", 13, 2, false)]
        public decimal? VlIpi { get; set; }

        /// <summary>
        /// Valor amparado por isenção ou não incidência do IPI (com 2 decimais)
        /// </summary>
        [SintegraCampos(11, "ISENTA OU NÃO TRIBUTADA", "N", 13, 2, false)]
        public decimal? VlIsentaNTribIpi { get; set; }

        /// <summary>
        /// Valor que não confira débito ou crédito do IPI (com 2 decimais)
        /// </summary>
        [SintegraCampos(12, "OUTRAS", "N", 13, 2, false)]
        public decimal? VlOutrasIpi { get; set; }

        /// <summary>
        /// Brancos
        /// </summary>
        [SintegraCampos(13, "BRANCOS", "X", 20, 0, true)]
        public string Brancos
        {
            get
            {
                return new string(' ', 20);
            }
        }

        /// <summary>
        /// Situação da nota fiscal
        /// </summary>
        [SintegraCampos(14, "SITUAÇÃO", "X", 1, 0, true)]
        public string Situacao { get; set; }
    }
}
