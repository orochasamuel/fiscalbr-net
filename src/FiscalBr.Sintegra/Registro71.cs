using FiscalBr.Common.Sintegra;
using System;

namespace FiscalBr.Sintegra
{
    public class Registro71 : RegistroBaseSintegra
    {
        public Registro71()
        {
            Tipo = "71";
        }

        [SintegraCampos(2, "CNPJ", "N", 14, 0, true)]
        public string Cnpj { get; set; }
        [SintegraCampos(3, "INSCRICAO ESTADUAL", "X", 14, 0, true)]
        public string InscrEstadual { get; set; }
        [SintegraCampos(4, "DATE DE EMISSÃO/UTILIZAÇÃO", "N", 8, 0, true)]
        public DateTime DataEmissaoRecebimento { get; set; }
        [SintegraCampos(5, "UF", "X", 2, 0, true)]
        public string Uf { get; set; }
        [SintegraCampos(6, "MODELO", "N", 2, 0, true)]
        public int Modelo { get; set; }
        [SintegraCampos(7, "SERIE", "X", 1, 0, true)]
        public string Serie { get; set; }
        [SintegraCampos(8, "SUBSERIE", "X", 2, 0, true)]
        public string Subserie { get; set; }
        [SintegraCampos(9, "NUMERO", "N", 6, 0, true)]
        public int Numero { get; set; }
        [SintegraCampos(10, "UF", "X", 2, 0, true)]
        public string UfRemetenteDestinatario { get; set; }
        [SintegraCampos(11, "CNPJ", "N", 14, 0, true)]
        public string CnpjRemetenteDestinatario { get; set; }
        [SintegraCampos(12, "INSCRICAO ESTADUAL", "X", 14, 0, true)]
        public string InscrEstadualRemetenteDestinatario { get; set; }
        [SintegraCampos(13, "DATE DE EMISSÃO NOTA FISCAL", "N", 8, 0, true)]
        public DateTime DataEmissaoNotaFiscal { get; set; }
        [SintegraCampos(14, "MODELO", "N", 2, 0, true)]
        public int ModeloNotaFiscal { get; set; }
        [SintegraCampos(15, "SERIE", "X", 3, 0, true)]
        public string SerieNotaFiscal { get; set; }
        [SintegraCampos(16, "NUMERO", "N", 6, 0, true)]
        public int NumeroNotaFiscal { get; set; }
        [SintegraCampos(17, "VALOR TOTAL NOTA FISCAL", "N", 14, 2, false)]
        public Decimal ValorTotalNotaFiscal { get; set; }
        [SintegraCampos(18, "Brancos", "X", 12, 0, false)]
        public string Brancos { get; set; }
    }
}