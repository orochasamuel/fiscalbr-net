using FiscalBr.Common.Dimob;
using System;

namespace FiscalBr.Dimob
{
    /// <summary>
    /// Construção e Incorporação - Tipo R03
    /// </summary>
    public class DimobR03 : RegistroBaseDimob
    {
        public DimobR03()
        {
            Tipo = "R03";
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

        [DimobCampos(7, "Número do contrato", 101, 106, 6, "X")]
        public string NumeroContrato { get; set; }

        [DimobCampos(8, "Data do contrato", 107, 114, 8, "DATA")]
        public DateTime DataContrato { get; set; }

        [DimobCampos(9, "Valor da Operação", 115, 128, 14, "R$")]
        public decimal ValorOperacao { get; set; }

        [DimobCampos(10, "Valor Pago no Ano", 129, 142, 14, "R$")]
        public decimal ValorPagoAno { get; set; }

        /// <summary>
        /// "U" - Imóvel Urbano; "R" - Imóvel Rural
        /// </summary>
        [DimobCampos(11, "Tipo do Imóvel", 143, 143, 1, "X")]
        public string TipoImovel { get; set; }

        [DimobCampos(12, "Endereço do Imóvel", 144, 203, 60, "X")]
        public string EnderecoImovel { get; set; }

        [DimobCampos(13, "CEP", 204, 211, 8, "N")]
        public string Cep { get; set; }

        [DimobCampos(14, "Código do Município do Imóvel", 212, 215, 4, "N")]
        public int CodigoMunicipio { get; set; }

        [DimobCampos(15, "Reservado", 216, 235, 20, "Branco(s)")]
        public string Reservado1 { get; private set; }

        [DimobCampos(16, "UF", 236, 237, 2, "X")]
        public string Uf { get; set; }

        [DimobCampos(17, "Reservado", 238, 247, 10, "Branco(s)")]
        public string Reservado2 { get; private set; }
    }
}
