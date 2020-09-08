using FiscalBr.Common.Dimob;
using System;

namespace FiscalBr.Dimob
{
    /// <summary>
    /// Intermediação de Venda - Tipo R04
    /// </summary>
    public class DimobR04 : RegistroBaseDimob
    {
        public DimobR04()
        {
            Tipo = "R04";
        }

        [DimobCampos(2, "CNPJ do declarante", 4, 17, 14, "CNPJ")]
        public string CnpjDeclarante { get; set; }

        [DimobCampos(3, "Ano-calendário", 18, 21, 4, "ANO")]
        public int AnoCalendario { get; set; }

        [DimobCampos(4, "Sequencial da Venda", 22, 26, 5, "N")]
        public int SequencialLocacao { get; set; }

        [DimobCampos(5, "CPF/CNPJ do Comprador", 27, 40, 14, "CPF/CNPJ")]
        public string CpfCnpjComprador { get; set; }

        [DimobCampos(6, "Nome/Nome Empresarial do Comprador", 41, 100, 60, "X")]
        public string NomeComprador { get; set; }

        [DimobCampos(7, "CPF/CNPJ do Vendedor", 101, 114, 14, "CPF/CNPJ")]
        public string CpfCnpjVendedor { get; set; }

        [DimobCampos(8, "Nome/Nome Empresarial do Vendedor", 115, 174, 60, "X")]
        public string NomeVendedor { get; set; }

        [DimobCampos(9, "Número do contrato", 175, 180, 6, "X")]
        public string NumeroContrato { get; set; }

        [DimobCampos(10, "Data do contrato", 181, 188, 8, "DATA")]
        public DateTime DataContrato { get; set; }

        [DimobCampos(11, "Valor da Venda", 189, 202, 14, "R$")]
        public decimal ValorVenda { get; set; }

        [DimobCampos(12, "Valor da Comissão", 203, 216, 14, "R$")]
        public decimal ValorComissao { get; set; }

        /// <summary>
        /// "U" - Imóvel Urbano; "R" - Imóvel Rural
        /// </summary>
        [DimobCampos(13, "Tipo do Imóvel", 217, 217, 1, "X")]
        public string TipoImovel { get; set; }

        [DimobCampos(14, "Endereço do Imóvel", 218, 277, 60, "X")]
        public string EnderecoImovel { get; set; }

        [DimobCampos(15, "CEP", 278, 285, 8, "N")]
        public string Cep { get; set; }

        [DimobCampos(16, "Código do Município do Imóvel", 286, 289, 4, "N")]
        public int CodigoMunicipio { get; set; }

        [DimobCampos(17, "Reservado", 290, 309, 20, "Branco(s)")]
        public string Reservado1 { get; private set; }

        [DimobCampos(18, "UF", 310, 311, 2, "X")]
        public string Uf { get; set; }

        [DimobCampos(19, "Reservado", 312, 321, 10, "Branco(s)")]
        public string Reservado2 { get; private set; }
    }
}
