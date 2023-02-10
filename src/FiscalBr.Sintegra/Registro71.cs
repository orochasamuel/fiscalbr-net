using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    /// <summary>
    /// REGISTRO TIPO 71 - Informações da Carga Transportada Referente a: 
    ///     Conhecimento de Transporte Rodoviário de Cargas
    ///     Conhecimento de Transporte Aquaviário de Cargas
    ///     Conhecimento Aéreo
    ///     Conhecimento de Transporte Ferroviário de Cargas
    /// </summary>
    public class Registro71 : RegistroBaseSintegra
    {
        public Registro71()
        {
            Tipo = "71";
        }
        /// <summary>
        /// CNPJ do tomador do serviço
        /// </summary>
        [SintegraCampos(2, "CNPJ", "N", 14, 0, true)]
        public string Cnpj { get; set; }

        /// <summary>
        /// Inscrição estadual do tomador do serviço
        /// </summary>
        [SintegraCampos(3, "INSCRICAO ESTADUAL", "X", 14, 0, true)]
        public string InscrEstadual { get; set; }

        /// <summary>
        /// Data de emissão do conhecimento
        /// </summary>
        [SintegraCampos(4, "DATE DE EMISSÃO/UTILIZAÇÃO", "N", 8, 0, true)]
        public DateTime DataEmissaoRecebimento { get; set; }

        /// <summary>
        /// Unidade da Federação do tomador do serviço
        /// </summary>
        [SintegraCampos(5, "UF", "X", 2, 0, true)]
        public string Uf { get; set; }

        /// <summary>
        /// Modelo do conhecimento
        /// </summary>
        [SintegraCampos(6, "MODELO", "N", 2, 0, true)]
        public int Modelo { get; set; }

        /// <summary>
        /// Série do conhecimento
        /// </summary>
        [SintegraCampos(7, "SERIE", "X", 1, 0, true)]
        public string Serie { get; set; }

        /// <summary>
        /// Subsérie do conhecimento
        /// </summary>
        [SintegraCampos(8, "SUBSERIE", "X", 2, 0, true)]
        public string Subserie { get; set; }

        /// <summary>
        /// Número do conhecimento
        /// </summary>
        [SintegraCampos(9, "NUMERO", "N", 6, 0, true)]
        public int Numero { get; set; }

        /// <summary>
        /// Unidade da Federação do remetente, se o destinatário for o tomador ou 
        /// unidade da Federação do destinatário, se o remetente for o tomador
        /// </summary>
        [SintegraCampos(10, "UF", "X", 2, 0, true)]
        public string UfRemetenteDestinatario { get; set; }

        /// <summary>
        /// CNPJ do remetente, se o destinatário for o tomador ou 
        /// CNPJ do destinatário, se o remetente for o tomador
        /// </summary>
        [SintegraCampos(11, "CNPJ", "N", 14, 0, true)]
        public string CnpjRemetenteDestinatario { get; set; }

        /// <summary>
        /// Inscrição Estadual do remetente, se o destinatário for o tomador
        /// ou Inscrição Estadual do destinatário, se o remetente for o tomador
        /// </summary>
        [SintegraCampos(12, "INSCRICAO ESTADUAL", "X", 14, 0, true)]
        public string InscrEstadualRemetenteDestinatario { get; set; }

        /// <summary>
        /// Data de emissão da nota fiscal que acoberta a carga transportada
        /// </summary>
        [SintegraCampos(13, "DATE DE EMISSÃO NOTA FISCAL", "N", 8, 0, true)]
        public DateTime DataEmissaoNotaFiscal { get; set; }

        /// <summary>
        /// Modelo da nota fiscal que acoberta a carga transportada
        /// </summary>
        [SintegraCampos(14, "MODELO", "N", 2, 0, true)]
        public int ModeloNotaFiscal { get; set; }

        /// <summary>
        /// Série da nota fiscal que acoberta a carga transportada
        /// </summary>
        [SintegraCampos(15, "SERIE", "X", 3, 0, true)]
        public string SerieNotaFiscal { get; set; }

        /// <summary>
        /// Número da nota fiscal que acoberta a carga transportada
        /// </summary>
        [SintegraCampos(16, "NUMERO", "N", 6, 0, true)]
        public int NumeroNotaFiscal { get; set; }

        /// <summary>
        /// Valor total da nota fiscal que acoberta a carga transportada (com duas decimais)
        /// </summary>
        [SintegraCampos(17, "VALOR TOTAL NOTA FISCAL", "N", 14, 2, false)]
        public Decimal ValorTotalNotaFiscal { get; set; }

        /// <summary>
        /// Brancos
        /// </summary>
        [SintegraCampos(18, "Brancos", "X", 12, 0, false)]
        public string Brancos { get; set; }
    }
}