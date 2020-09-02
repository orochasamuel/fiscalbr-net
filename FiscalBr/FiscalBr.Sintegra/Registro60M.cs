using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    public class Registro60M : RegistroBaseSintegra
    {
        public Registro60M()
        {
            Tipo = "60";
        }

        /// <summary>
        /// Subtipo "M"
        /// </summary>
        [SintegraCampos(2, "SUBTIPO", "X", 1, 0, true)]
        public string Subtipo => "M";

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
        /// Número atribuído pelo estabelecimento ao equipamento
        /// </summary>
        [SintegraCampos(5, "NÚM. ORDEM EQUIP.", "N", 3, 0, true)]
        public int NumSequencial { get; set; }

        /// <summary>
        /// Código do modelo do documento fiscal
        /// </summary>
        [SintegraCampos(6, "MODELO DO DOCUMENTO", "X", 2, 0, true)]
        public string ModeloDoc { get; set; }

        /// <summary>
        /// Número do primeiro documento fiscal emitido no dia
        /// </summary>
        [SintegraCampos(7, "CONTADOR DE ORDEM DE OPERAÇÃO INICIAL", "N", 6, 0, true)]
        public int NumCooInicial { get; set; }

        /// <summary>
        /// Número do último documento fiscal emitido no dia
        /// </summary>
        [SintegraCampos(8, "CONTADOR DE ORDEM DE OPERAÇÃO FINAL", "N", 6, 0, true)]
        public int NumCooFinal { get; set; }

        /// <summary>
        /// Número do contador de redução z
        /// </summary>
        [SintegraCampos(9, "CONTADOR DE REDUÇÃO Z", "N", 6, 0, true)]
        public int NumCrz { get; set; }

        /// <summary>
        /// Número do contador de reinício de operação
        /// </summary>
        [SintegraCampos(10, "CONTADOR DE REINICIO DE OPERAÇÃO", "N", 3, 0, true)]
        public int NumCro { get; set; }

        /// <summary>
        /// Valor acumulado no totalizador de venda bruta
        /// </summary>
        [SintegraCampos(11, "VALOR DE VENDA BRUTA", "N", 16, 2, true)]
        public decimal VlVendaBruta { get; set; }

        /// <summary>
        /// Valor acumulado no totalizador geral
        /// </summary>
        [SintegraCampos(12, "TOTALIZADOR GERAL DO EQUIP.", "N", 16, 2, true)]
        public decimal VlTotalizadorGeral { get; set; }

        /// <summary>
        /// Brancos
        /// </summary>
        [SintegraCampos(13, "BRANCOS", "X", 37, 0, true)]
        public string Brancos
        {
            get
            {
                return new string(' ', 37);
            }
        }
    }
}
