using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    /// <summary>
    /// REGISTRO TIPO 50 - NOTAS FISCAIS DE ENTRADA/SAÍDA
    /// </summary>
    public class Registro50 : RegistroBaseSintegra
    {
        public Registro50()
        {
            Tipo = "50";
        }

        /// <summary>
        /// CNPJ do remetente nas entradas e do destinatário nas saídas
        /// </summary>
        [SintegraCampos(2, "CNPJ", "N", 14, 0, true)]
        public string Cnpj { get; set; }

        /// <summary>
        /// Inscrição estadual do remetente nas entrada e do destinatário nas saídas
        /// </summary>
        [SintegraCampos(3, "INSCRICAO ESTADUAL", "X", 14, 0, true)]
        public string InscrEstadual { get; set; }

        /// <summary>
        /// Data de emissão na saída ou de recebimento na entrada
        /// </summary>
        [SintegraCampos(4, "DATE DE EMISSÃO/RECEBIMENTO", "N", 8, 0, true)]
        public DateTime DataEmissaoRecebimento { get; set; }

        /// <summary>
        /// Sigla da unidade da federação do remetente nas entradas e do destinatário nas saídas
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
        [SintegraCampos(7, "SERIE", "X", 3, 0, true)]
        public string Serie { get; set; }

        /// <summary>
        /// Número da nota fiscal
        /// </summary>
        [SintegraCampos(8, "NUMERO", "N", 6, 0, true)]
        public int Numero { get; set; }

        /// <summary>
        /// Código fiscal de operação ou prestação
        /// </summary>
        [SintegraCampos(9, "CFOP", "N", 4, 0, true)]
        public int Cfop { get; set; }

        /// <summary>
        /// Emitente da nota fiscal
        /// P - Próprio; ou
        /// T - Terceiros
        /// </summary>
        [SintegraCampos(10, "EMITENTE DA NF", "X", 1, 0, true)]
        public string Emitente { get; set; }

        /// <summary>
        /// Valor total da nota fiscal (com 2 decimais)
        /// </summary>
        [SintegraCampos(11, "VALOR TOTAL", "N", 13, 2, true)]
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Base de cálculo do ICMS (com 2 decimais)
        /// </summary>
        [SintegraCampos(12, "BASE DE CALCULO", "N", 13, 2, false)]
        public decimal? BaseCalculoIcms { get; set; }

        /// <summary>
        /// Montante do imposto (com 2 decimais)
        /// </summary>
        [SintegraCampos(13, "VALOR DO ICMS", "N", 13, 2, false)]
        public decimal? ValorIcms { get; set; }

        /// <summary>
        /// Valor amparado por isenção ou não incidência (com 2 decimais)
        /// </summary>
        [SintegraCampos(14, "ISENTA OU NÃO TRIBUTADA", "N", 13, 2, false)]
        public decimal? ValorIsentaOuNaoTributadas { get; set; }

        /// <summary>
        /// Valor que não confira débito ou crédito do ICMS (com 2 decimais)
        /// </summary>
        [SintegraCampos(15, "OUTRAS", "N", 13, 2, false)]
        public decimal? ValorOutras { get; set; }

        /// <summary>
        /// Alíquota do ICMS (com 2 decimais)
        /// </summary>
        [SintegraCampos(16, "ALIQUOTA DO ICMS", "N", 4, 2, false)]
        public decimal? AliquotaIcms { get; set; }

        /// <summary>
        /// Situação da nota fiscal
        /// TODO: Criar "extrator" de valores do Enum para esses casos.
        /// </summary>
        [SintegraCampos(17, "SITUACAO DA NOTA FISCAL", "X", 1, 0, true)]
        public string SituacaoNotaFiscal { get; set; }
    }
}
