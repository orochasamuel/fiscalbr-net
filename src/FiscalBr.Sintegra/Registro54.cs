using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    /// <summary>
    /// REGISTRO TIPO 54 - PRODUTO
    /// </summary>
    public class Registro54 : RegistroBaseSintegra
    {
        public Registro54()
        {
            Tipo = "54";
        }

        /// <summary>
        /// CNPJ do remetente nas entradas e do destinatário nas saídas
        /// </summary>
        [SintegraCampos(2, "CNPJ", "N", 14, 0, true)]
        public string Cnpj { get; set; }

        /// <summary>
        /// Código do modelo da nota fiscal
        /// </summary>
        [SintegraCampos(3, "MODELO", "N", 2, 0, true)]
        public int Modelo { get; set; }

        /// <summary>
        /// Série da nota fiscal
        /// </summary>
        [SintegraCampos(4, "SÉRIE", "X", 3, 0, true)]
        public string Serie { get; set; }

        /// <summary>
        /// Número da nota fiscal
        /// </summary>
        [SintegraCampos(5, "NÚMERO", "N", 6, 0, true)]
        public int Numero { get; set; }

        /// <summary>
        /// Código fiscal da operação ou prestação
        /// </summary>
        [SintegraCampos(6, "CFOP", "N", 4, 0, true)]
        public int Cfop { get; set; }

        /// <summary>
        /// Código da situação tributária
        /// </summary>
        [SintegraCampos(7, "CST", "X", 3, 0, true)]
        public string Cst { get; set; }

        /// <summary>
        /// Número de ordem do item na nota fiscal
        /// </summary>
        [SintegraCampos(8, "NÚMERO DO ITEM", "N", 3, 0, true)]
        public int NumeroItem { get; set; }

        /// <summary>
        /// Código do produto ou serviço do informante
        /// </summary>
        [SintegraCampos(9, "CÓDIGO PRODUTO/SERVIÇO", "X", 14, 0, true)]
        public string CodProdutoServico { get; set; }

        /// <summary>
        /// Quantidade do produto (com 3 decimais)
        /// </summary>
        [SintegraCampos(10, "QUANTIDADE", "N", 11, 3, true)]
        public decimal Quantidade { get; set; }

        /// <summary>
        /// Valor bruto do produto (valor unitário multiplicado por quantidade) - com 2 decimais
        /// </summary>
        [SintegraCampos(11, "VALOR DO PRODUTO/SERVIÇO", "N", 12, 2, true)]
        public decimal VlProdutoServico { get; set; }

        /// <summary>
        /// Valor do desconto concedido no item (com 2 decimais)
        /// </summary>
        [SintegraCampos(12, "VALOR DESCONTO/DESPESA ACESSÓRIA", "N", 12, 2, false)]
        public decimal? VlDescontoDespesaAc { get; set; }

        /// <summary>
        /// Base de cálculo do ICMS (com 2 decimais)
        /// </summary>
        [SintegraCampos(13, "BASE CÁLCULO ICMS", "N", 12, 2, false)]
        public decimal? BaseCalculoIcms { get; set; }

        /// <summary>
        /// Base de cálculo do ICMS de retenção na Substituição Tributária (com 2 decimais)
        /// </summary>
        [SintegraCampos(14, "BASE CÁLCULO ICMS ST", "N", 12, 2, false)]
        public decimal? BaseCalculoIcmsSt { get; set; }

        /// <summary>
        /// Valor do IPI (com 2 decimais)
        /// </summary>
        [SintegraCampos(15, "VALOR DO IPI", "N", 12, 2, false)]
        public decimal? VlIpi { get; set; }

        /// <summary>
        /// Alíquota utilizada no cálculo do ICMS (com 2 decimais)
        /// </summary>
        [SintegraCampos(16, "ALÍQUOTA DO ICMS", "N", 4, 2, false)]
        public decimal? AliquotaIcms { get; set; }
    }
}
