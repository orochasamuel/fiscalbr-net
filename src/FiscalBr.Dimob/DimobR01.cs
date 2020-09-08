using FiscalBr.Common.Dimob;
using System;

namespace FiscalBr.Dimob
{
    /// <summary>
    /// Ficha Dados Iniciais - Tipo R01
    /// </summary>
    public class DimobR01 : RegistroBaseDimob
    {
        public DimobR01()
        {
            Tipo = "R01";
        }

        [DimobCampos(2, "CNPJ do declarante", 4, 17, 14, "CNPJ")]
        public string CnpjDeclarante { get; set; }

        [DimobCampos(3, "Ano-calendário", 18, 21, 4, "ANO")]
        public int AnoCalendario { get; set; }

        /// <summary>
        /// "0" - Não, "1" - Sim
        /// </summary>
        [DimobCampos(4, "Declaração retificadora", 22, 22, 1, "N")]
        public int DeclaracaoRetificadora { get; set; }

        [DimobCampos(5, "Número do recibo", 23, 32, 10, "N")]
        public int NumeroRecibo { get; set; }

        /// <summary>
        /// "0" - Não, "1" - Sim
        /// </summary>
        [DimobCampos(6, "Situação especial", 33, 33, 1, "N")]
        public int SituacaoEspecial { get; set; }

        [DimobCampos(7, "Data do evento situação especial", 34, 41, 8, "N")]
        public DateTime? DataEventoSituacaoEspecial { get; set; }

        /// <summary>
        /// "00" - Normal, "01" - Extinção, "02" - Fusão, "03" - Incorporação/Incorporada, "04" - Cisão Total
        /// </summary>
        [DimobCampos(8, "Código da situação especial", 42, 43, 2, "N")]
        public int CodigoSituacaoEspecial { get; set; }

        [DimobCampos(9, "Nome empresarial", 44, 103, 60, "X")]
        public string NomeEmpresarial { get; set; }

        [DimobCampos(10, "CPF responsável perante à RFB", 104, 114, 11, "CPF")]
        public string CpfResponsavelEmpresa { get; set; }

        [DimobCampos(11, "Endereço completo do contribuinte", 115, 234, 120, "X")]
        public string EnderecoCompleto { get; set; }

        [DimobCampos(12, "UF do contribuinte", 235, 236, 2, "X")]
        public string UfContribuinte { get; set; }

        [DimobCampos(13, "Código do município do contribuinte", 237, 240, 4, "N")]
        public int CodigoMunicipio { get; set; }

        [DimobCampos(14, "Reservado", 241, 260, 20, "Branco(s)")]
        public string Reservado1 { get; private set; }

        [DimobCampos(15, "Reservado", 261, 270, 10, "Branco(s)")]
        public string Reservado2 { get; private set; }
    }
}
