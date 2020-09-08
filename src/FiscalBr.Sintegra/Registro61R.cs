using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    public class Registro61R : RegistroBaseSintegra
    {
        public Registro61R()
        {
            Tipo = "61";
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
        public DateTime DataEmissao { get; set; }

        /// <summary>
        /// Código da mercadoria/produto do informante
        /// </summary>
        [SintegraCampos(4, "CÓD. PRODUTO", "X", 14, 0, true)]
        public string CodItem { get; set; }

        /// <summary>
        /// Quantidade da mercadoria/produto acumulada vendida no mês
        /// </summary>
        [SintegraCampos(5, "QUANTIDADE", "N", 13, 3, true)]
        public decimal Quantidade { get; set; }

        /// <summary>
        /// Valor bruto do produto acumulado da venda do produto no mês
        /// </summary>
        [SintegraCampos(6, "VALOR PRODUTO/SERVIÇO", "N", 16, 2, true)]
        public decimal ValorItem { get; set; }

        /// <summary>
        /// Base de cálculo do ICMS acumulada no mês
        /// </summary>
        [SintegraCampos(7, "BASE CÁLCULO ICMS", "N", 16, 2, false)]
        public decimal? BaseCalculoIcms { get; set; }

        /// <summary>
        /// Montante do imposto
        /// </summary>
        [SintegraCampos(8, "ALIQUOTA DO PRODUTO", "N", 4, 2, false)]
        public decimal? AliquotaIcms { get; set; }

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
