using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    public class Registro60R : RegistroBaseSintegra
    {
        public Registro60R()
        {
            Tipo = "60";
        }

        /// <summary>
        /// Subtipo "R"
        /// </summary>
        [SintegraCampos(2, "SUBTIPO", "X", 1, 0, true)]
        public string Subtipo => "R";

        /// <summary>
        /// Mês e ano de emissão dos documentos fiscais
        /// *OBS: Formato DP = Data Parcial
        /// </summary>
        [SintegraCampos(3, "MÊS/ANO EMISSÃO", "DP", 6, 0, true)]
        public DateTime MesAnoEmissao { get; set; }

        /// <summary>
        /// Código da mercadoria/produto ou serviço do informante
        /// </summary>
        [SintegraCampos(4, "CÓD. PRODUTO/SERVIÇO", "X", 14, 0, true)]
        public string CodItem { get; set; }

        /// <summary>
        /// Quantidade da mercadoria/produto no mês
        /// </summary>
        [SintegraCampos(5, "QUANTIDADE", "N", 13, 3, true)]
        public decimal Quantidade { get; set; }

        /// <summary>
        /// Valor líquido (valor bruto menos descontos) da mercadoria/produto ou serviço acumulado no mês
        /// </summary>
        [SintegraCampos(6, "VALOR PRODUTO/SERVIÇO", "N", 16, 2, true)]
        public decimal ValorItem { get; set; }

        /// <summary>
        /// Base de cálculo do ICMS acumulado no mês
        /// </summary>
        [SintegraCampos(7, "BASE CÁLCULO ICMS", "N", 16, 2, false)]
        public decimal? BaseCalculoIcms { get; set; }

        /// <summary>
        /// Identificador da situação tributária/alíquota do ICMS
        /// </summary>
        [SintegraCampos(8, "SITUAÇÃO TRIBUTÁRIA", "X", 4, 0, true)]
        public string SituacaoTributaria { get; set; }

        /// <summary>
        /// Brancos
        /// </summary>
        [SintegraCampos(9, "BRANCOS", "X", 54, 0, true)]
        public string Brancos
        {
            get
            {
                return new string(' ', 54);
            }
        }
    }
}
