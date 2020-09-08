using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    public class Registro60D : RegistroBaseSintegra
    {
        public Registro60D()
        {
            Tipo = "60";
        }

        /// <summary>
        /// Subtipo "D"
        /// </summary>
        [SintegraCampos(2, "SUBTIPO", "X", 1, 0, true)]
        public string Subtipo => "D";

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
        /// Código da mercadoria/produto ou serviço do informante
        /// </summary>
        [SintegraCampos(5, "CÓD. PRODUTO/SERVIÇO", "X", 14, 0, true)]
        public string CodItem { get; set; }

        /// <summary>
        /// Quantidade da mercadoria/produto
        /// </summary>
        [SintegraCampos(6, "QUANTIDADE", "N", 13, 3, true)]
        public decimal Quantidade { get; set; }

        /// <summary>
        /// Valor líquido (valor bruto menos descontos) da mercadoria/produto
        /// </summary>
        [SintegraCampos(7, "VALOR PRODUTO/SERVIÇO", "N", 16, 2, true)]
        public decimal ValorItem { get; set; }

        /// <summary>
        /// Base de cálculo do ICMS do item
        /// </summary>
        [SintegraCampos(8, "BASE CÁLCULO ICMS", "N", 16, 2, false)]
        public decimal? BaseCalculoIcms { get; set; }

        /// <summary>
        /// Identificador da situação tributária/alíquota do ICMS
        /// </summary>
        [SintegraCampos(9, "SITUAÇÃO TRIBUTÁRIA", "X", 4, 0, true)]
        public string SituacaoTributaria { get; set; }

        /// <summary>
        /// Montante do imposto
        /// </summary>
        [SintegraCampos(10, "VALOR DO ICMS", "N", 13, 2, false)]
        public decimal? ValorIcms { get; set; }

        /// <summary>
        /// Brancos
        /// </summary>
        [SintegraCampos(11, "BRANCOS", "X", 19, 0, true)]
        public string Brancos
        {
            get
            {
                return new string(' ', 19);
            }
        }
    }
}
