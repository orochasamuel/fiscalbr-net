using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    public class Registro60I : RegistroBaseSintegra
    {
        public Registro60I()
        {
            Tipo = "60";
        }

        /// <summary>
        /// Subtipo "I"
        /// </summary>
        [SintegraCampos(2, "SUBTIPO", "X", 1, 0, true)]
        public string Subtipo => "I";

        /// <summary>
        /// Data de emissão do documento fiscal
        /// </summary>
        [SintegraCampos(3, "DATA DE EMISSÃO", "N", 8, 0, true)]
        public DateTime DataEmissao { get; set; }

        /// <summary>
        /// Número de série de fabricação do equipamento
        /// </summary>
        [SintegraCampos(4, "NÚM. SÉRIE FAB.", "X", 20, 0, true)]
        public string NumFabricacao { get; set; }

        /// <summary>
        /// Código do modelo do documento fiscal
        /// </summary>
        [SintegraCampos(5, "MODELO DO DOCUMENTO", "X", 2, 0, true)]
        public string ModeloDoc { get; set; }

        /// <summary>
        /// Número do contador de ordem de operação (COO)
        /// </summary>
        [SintegraCampos(6, "NÚM. ORDEM OPERAÇÃO", "N", 6, 0, true)]
        public int NumCoo { get; set; }

        /// <summary>
        /// Número de ordem do item no documento fiscal
        /// </summary>
        [SintegraCampos(7, "NÚM. DO ITEM", "N", 3, 0, true)]
        public int NumItem { get; set; }

        /// <summary>
        /// Código da mercadoria/produto ou serviço do informante
        /// </summary>
        [SintegraCampos(8, "CÓD. PRODUTO/SERVIÇO", "X", 14, 0, true)]
        public string CodItem { get; set; }

        /// <summary>
        /// Quantidade da mercadoria/produto
        /// </summary>
        [SintegraCampos(9, "QUANTIDADE", "N", 13, 3, true)]
        public decimal Quantidade { get; set; }

        /// <summary>
        /// Valor líquido (valor bruto menos descontos) da mercadoria/produto
        /// </summary>
        [SintegraCampos(10, "VALOR PRODUTO/SERVIÇO", "N", 13, 2, true)]
        public decimal ValorItem { get; set; }

        /// <summary>
        /// Base de cálculo do ICMS do item
        /// </summary>
        [SintegraCampos(11, "BASE CÁLCULO ICMS", "N", 12, 2, false)]
        public decimal? BaseCalculoIcms { get; set; }

        /// <summary>
        /// Identificador da situação tributária/alíquota do ICMS
        /// </summary>
        [SintegraCampos(12, "SITUAÇÃO TRIBUTÁRIA", "X", 4, 0, true)]
        public string SituacaoTributaria { get; set; }

        /// <summary>
        /// Montante do imposto
        /// </summary>
        [SintegraCampos(13, "VALOR DO ICMS", "N", 12, 2, false)]
        public decimal? ValorIcms { get; set; }

        /// <summary>
        /// Brancos
        /// </summary>
        [SintegraCampos(14, "BRANCOS", "X", 16, 0, true)]
        public string Brancos
        {
            get
            {
                return new string(' ', 16);
            }
        }
    }
}
