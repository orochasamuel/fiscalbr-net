using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    /// <summary>
    /// REGISTRO TIPO 75 - CÓDIGO DO PRODUTO OU SERVIÇO
    /// </summary>
    public class Registro75 : RegistroBaseSintegra
    {
        public Registro75()
        {
            Tipo = "75";
        }

        /// <summary>
        /// Data inicial do período de validade das informações
        /// </summary>
        [SintegraCampos(2, "DATA INICIAL", "N", 8, 0, true)]
        public DateTime DataInicial { get; set; }

        /// <summary>
        /// Data final do período de validade das informações
        /// </summary>
        [SintegraCampos(3, "DATA FINAL", "N", 8, 0, true)]
        public DateTime DataFinal { get; set; }

        /// <summary>
        /// Código do produto ou serviço utilizado pelo contribuinte
        /// </summary>
        [SintegraCampos(4, "CÓDIGO DO PRODUTO OU SERVIÇO", "X", 14, 0, true)]
        public string CodItem { get; set; }

        /// <summary>
        /// Codificação da nomenclatura comum do mercosul
        /// </summary>
        [SintegraCampos(5, "CÓDIGO NCM", "X", 8, 0, true)]
        public string CodNcm { get; set; }

        /// <summary>
        /// Descrição do produto ou serviço
        /// </summary>
        [SintegraCampos(6, "DESCRIÇÃO", "X", 53, 0, true)]
        public string Descricao { get; set; }

        /// <summary>
        /// Unidade de medida de comercialização do produto (un, kg, mt, m3, sc, frd, kWh, etc.)
        /// </summary>
        [SintegraCampos(7, "UNIDADE DE MEDIDA DE COMERCIALIZAÇÃO", "X", 6, 0, true)]
        public string UnidadeMedida { get; set; }

        /// <summary>
        /// Alíquota do IPI do produto
        /// </summary>
        [SintegraCampos(8, "ALÍQUOTA IPI", "N", 5, 2, false)]
        public decimal? AliquotaIpi { get; set; }

        /// <summary>
        /// Alíquota do ICMS aplicável a mercadoria ou serviços nas operações ou prestações internas ou naquelas que se tiverem iniciado no exterior
        /// </summary>
        [SintegraCampos(9, "ALÍQUOTA ICMS", "N", 4, 2, false)]
        public decimal? AliquotaIcms { get; set; }

        /// <summary>
        /// % de redução na base de cálculo do ICMS, nas operações internas
        /// </summary>
        [SintegraCampos(10, "REDUÇÃO BASE ICMS", "N", 5, 2, false)]
        public decimal? ReducaoBaseIcms { get; set; }

        /// <summary>
        /// Base de cálculo do ICMS de substituição tributária
        /// </summary>
        [SintegraCampos(11, "BASE CÁLCULO ICMS ST", "N", 13, 2, false)]
        public decimal? BaseCalculoSt { get; set; }
    }
}
