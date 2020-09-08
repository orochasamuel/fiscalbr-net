using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    public class Registro60A : RegistroBaseSintegra
    {
        public Registro60A()
        {
            Tipo = "60";
        }

        /// <summary>
        /// Subtipo "A"
        /// </summary>
        [SintegraCampos(2, "SUBTIPO", "X", 1, 0, true)]
        public string Subtipo => "A";

        /// <summary>
        /// Data de emissão dos documentos fiscais
        /// </summary>
        [SintegraCampos(3, "DATA DE EMISSÃO", "N", 8, 0, true)]
        public DateTime DataEmissao { get; set; }

        /// <summary>
        /// Número de série de fabricação do equipamento
        /// </summary>
        [SintegraCampos(4, "NÚM. SÉRIE FAB.", "X", 20, 0, true)]
        public string NumFabricacao { get; set; }

        /// <summary>
        /// Identificação da situação tributária/alíquota do ICMS
        /// </summary>
        [SintegraCampos(5, "SITUAÇÃO TRIBUTÁRIA", "X", 4, 0, true)]
        public string SituacaoTributaria { get; set; }

        /// <summary>
        /// Valor acumulado no final do dia no totalizador parcial da situação tributária/alíquota
        /// </summary>
        [SintegraCampos(6, "VALOR ACUMULADO NO TOTALIZADOR PARCIAL", "N", 12, 2, true)]
        public decimal VlAcumuladoTotParcial { get; set; }

        /// <summary>
        /// Brancos
        /// </summary>
        [SintegraCampos(7, "BRANCOS", "X", 79, 0, true)]
        public string Brancos
        {
            get
            {
                return new string(' ', 79);
            }
        }
    }
}
