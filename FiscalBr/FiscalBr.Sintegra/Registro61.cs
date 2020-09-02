using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    public class Registro61 : RegistroBaseSintegra
    {
        public Registro61()
        {
            Tipo = "61";
        }

        /// <summary>
        /// Brancos
        /// </summary>
        [SintegraCampos(2, "BRANCOS", "X", 14, 0, true)]
        public string Brancos1
        {
            get
            {
                return new string(' ', 14);
            }
        }

        /// <summary>
        /// Brancos
        /// </summary>
        [SintegraCampos(3, "BRANCOS", "X", 14, 0, true)]
        public string Brancos2
        {
            get
            {
                return new string(' ', 14);
            }
        }

        /// <summary>
        /// Data de emissão do(s) documento(s) fiscal(is)
        /// </summary>
        [SintegraCampos(4, "DATA DE EMISSÃO", "N", 8, 0, true)]
        public DateTime DataEmissao { get; set; }

        /// <summary>
        /// Modelo do(s) documento(s) fiscal(is)
        /// </summary>
        [SintegraCampos(5, "MODELO", "N", 2, 0, true)]
        public string Modelo { get; set; }

        /// <summary>
        /// Série do(s) documento(s) fiscal(is)
        /// </summary>
        [SintegraCampos(6, "SÉRIE", "X", 3, 0, true)]
        public string Serie { get; set; }

        /// <summary>
        /// Subsérie do(s) documento(s) fiscal(is)
        /// </summary>
        [SintegraCampos(7, "SUBSÉRIE", "X", 2, 0, true)]
        public string Subserie { get; set; }

        /// <summary>
        /// Número do primeiro documento fiscal emitido no dia do mesmo modelo, série e subsérie
        /// </summary>
        [SintegraCampos(8, "NÚMERO INICIAL DE ORDEM", "N", 6, 0, true)]
        public int NumInicial { get; set; }

        /// <summary>
        /// Número do último documento fiscal emitido no dia do mesmo modelo, série e subsérie
        /// </summary>
        [SintegraCampos(9, "NÚMERO FINAL DE ORDEM", "N", 6, 0, true)]
        public int NumFinal { get; set; }

        /// <summary>
        /// Valor total do(s) documento(s) fiscal(is)
        /// </summary>
        [SintegraCampos(10, "VALOR TOTAL", "N", 13, 2, true)]
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Base de cálculo do(s) documento(s) fiscal(is)
        /// </summary>
        [SintegraCampos(11, "BASE DE CÁLCULO ICMS", "N", 13, 2, false)]
        public decimal? BaseCalculoIcms { get; set; }

        /// <summary>
        /// Valor do montante do imposto
        /// </summary>
        [SintegraCampos(12, "VALOR DO ICMS", "N", 12, 2, false)]
        public decimal? ValorIcms { get; set; }

        /// <summary>
        /// Valor amparado por isenção ou não-incidência
        /// </summary>
        [SintegraCampos(13, "ISENTA OU NÃO TRIBUTADAS", "N", 13, 2, false)]
        public decimal? IsentaNaoTrib { get; set; }

        /// <summary>
        /// Valor que não confira débito ou crédito de ICMS
        /// </summary>
        [SintegraCampos(14, "OUTRAS", "N", 13, 2, false)]
        public decimal? Outras { get; set; }

        /// <summary>
        /// Alíquota do ICMS
        /// </summary>
        [SintegraCampos(15, "ALÍQUOTA", "N", 4, 2, false)]
        public decimal? Aliquota { get; set; }

        /// <summary>
        /// Brancos
        /// </summary>
        [SintegraCampos(16, "BRANCOS", "X", 1, 0, true)]
        public string Brancos3
        {
            get
            {
                return new string(' ', 1);
            }
        }
    }
}
