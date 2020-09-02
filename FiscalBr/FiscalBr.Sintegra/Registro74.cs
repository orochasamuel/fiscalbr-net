using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    /// <summary>
    /// REGISTRO TIPO 74 - REGISTRO DE INVENTÁRIO
    /// </summary>
    public class Registro74 : RegistroBaseSintegra
    {
        public Registro74()
        {
            Tipo = "74";
        }

        /// <summary>
        /// Data do inventário no formato AAAAMMDD
        /// </summary>
        [SintegraCampos(2, "DATA DO INVENTÁRIO", "DI", 8, 0, true)]
        public DateTime DataInventario { get; set; }

        /// <summary>
        /// Código do produto do informante
        /// </summary>
        [SintegraCampos(3, "CÓDIGO DO PRODUTO", "X", 14, 0, true)]
        public string CodigoProduto { get; set; }

        /// <summary>
        /// Quantidade do produto
        /// </summary>
        [SintegraCampos(4, "QUANTIDADE", "N", 13, 3, true)]
        public decimal Quantidade { get; set; }

        /// <summary>
        /// Valor bruto do produto (valor unit. x quant.)
        /// </summary>
        [SintegraCampos(5, "VALOR DO PRODUTO", "N", 13, 2, true)]
        public decimal ValorProduto { get; set; }

        /// <summary>
        /// Código de posse das mercadorias inventariadas
        /// 1 - Propriedade do informante e em seu poder.
        /// 2 - Propriedade do informante e em poder de terceiros.
        /// 3 - Propriedade de terceiros e em poder do informante.
        /// </summary>
        [SintegraCampos(6, "CÓDIGO DE POSSE DAS MERCADORIAS", "X", 1, 0, true)]
        public string CodigoPosseMerc { get; set; }

        /// <summary>
        /// CNPJ do possuidor da mercadoria de propriedade do informante, ou do proprietario da mercadoria em poder do informante
        /// </summary>
        [SintegraCampos(7, "CNPJ DO PROPRIETÁRIO", "N", 14, 0, true)]
        public string CnpjProprietario { get; set; }

        /// <summary>
        /// Inscrição estadual do possuidor da mercadoria em propriedade do informante, ou do proprietário da mercadoria em poder do informante
        /// </summary>
        [SintegraCampos(8, "INSCRIÇÃO ESTADUAL DO PROPRIETÁRIO", "X", 14, 0, true)]
        public string InscrEstadualProprietario { get; set; }

        /// <summary>
        /// Unidade da federação do possuidor da mercadoria de propriedade do informante, ou do proprietário da mercadoria em poder do informante
        /// </summary>
        [SintegraCampos(9, "UF DO PROPRIETÁRIO", "X", 2, 0, true)]
        public string UfProprietario { get; set; }

        /// <summary>
        /// Brancos
        /// </summary>
        [SintegraCampos(10, "BRANCOS", "X", 45, 0, true)]
        public string Brancos
        {
            get
            {
                return new string(' ', 45);
            }
        }
    }
}
