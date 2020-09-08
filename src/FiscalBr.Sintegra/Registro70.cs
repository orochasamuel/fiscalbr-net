using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    /// <summary>
    /// REGISTRO TIPO 70 - OPERAÇÕES DE TRANSPORTE
    /// </summary>
    public class Registro70 : RegistroBaseSintegra
    {
        public Registro70()
        {
            Tipo = "70";
        }

        /// <summary>
        /// CNPJ do emitente do documento, no caso de aquisição de serviço; CNPJ do tomador do serviço, no caso de emissão do documento
        /// </summary>
        [SintegraCampos(2, "CNPJ", "N", 14, 0, true)]
        public string Cnpj { get; set; }

        /// <summary>
        /// Inscrição estadual do emitente do documento, no caso de aquisição de serviço; Inscrição estadual do tomador do serviço, no caso de emissão do documento
        /// </summary>
        [SintegraCampos(3, "INSCRICAO ESTADUAL", "X", 14, 0, true)]
        public string InscrEstadual { get; set; }

        /// <summary>
        /// Data de emissão para o prestador, ou data de utilização do serviço para o tomador
        /// </summary>
        [SintegraCampos(4, "DATE DE EMISSÃO/UTILIZAÇÃO", "N", 8, 0, true)]
        public DateTime DataEmissaoRecebimento { get; set; }

        /// <summary>
        /// Sigla da unidade da federação do emitente do documento, no caso de aquisição de serviço, ou do tomador do serviço, no caso de emissão do documento
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
        [SintegraCampos(7, "SERIE", "X", 1, 0, true)]
        public string Serie { get; set; }

        /// <summary>
        /// Série da nota fiscal
        /// </summary>
        [SintegraCampos(8, "SUBSERIE", "X", 2, 0, true)]
        public string Subserie { get; set; }

        /// <summary>
        /// Número da nota fiscal
        /// </summary>
        [SintegraCampos(9, "NUMERO", "N", 6, 0, true)]
        public int Numero { get; set; }

        /// <summary>
        /// Código fiscal de operação ou prestação
        /// </summary>
        [SintegraCampos(10, "CFOP", "N", 4, 0, true)]
        public int Cfop { get; set; }

        /// <summary>
        /// Valor total do documento fiscal (com 2 decimais)
        /// </summary>
        [SintegraCampos(11, "VALOR TOTAL", "N", 13, 2, true)]
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Base de cálculo do ICMS (com 2 decimais)
        /// </summary>
        [SintegraCampos(12, "BASE DE CALCULO", "N", 14, 2, false)]
        public decimal? BaseCalculoIcms { get; set; }

        /// <summary>
        /// Montante do imposto (com 2 decimais)
        /// </summary>
        [SintegraCampos(13, "VALOR DO ICMS", "N", 14, 2, false)]
        public decimal? ValorIcms { get; set; }

        /// <summary>
        /// Valor amparado por isenção ou não incidência (com 2 decimais)
        /// </summary>
        [SintegraCampos(14, "ISENTA OU NÃO TRIBUTADA", "N", 14, 2, false)]
        public decimal? ValorIsentaOuNaoTributadas { get; set; }

        /// <summary>
        /// Valor que não confira débito ou crédito do ICMS (com 2 decimais)
        /// </summary>
        [SintegraCampos(15, "OUTRAS", "N", 14, 2, false)]
        public decimal? ValorOutras { get; set; }

        /// <summary>
        /// Modalidade do frete
        /// 1 - CIF
        /// 2 - FOB
        /// 0 - OUTROS
        /// </summary>
        [SintegraCampos(16, "CIF/FOB/OUTROS", "N", 1, 0, true)]
        public int ModalidadeFrete{ get; set; }

        /// <summary>
        /// Situação da nota fiscal
        /// TODO: Criar "extrator" de valores do Enum para esses casos.
        /// </summary>
        [SintegraCampos(17, "SITUACAO DA NOTA FISCAL", "X", 1, 0, true)]
        public string Situacao { get; set; }
    }
}
