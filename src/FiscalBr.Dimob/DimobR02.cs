using FiscalBr.Common.Dimob;
using System;

namespace FiscalBr.Dimob
{
    /// <summary>
    /// Ficha de Locação - Tipo R02
    /// </summary>
    public class DimobR02 : RegistroBaseDimob
    {
        public DimobR02()
        {
            Tipo = "R02";
        }

        [DimobCampos(2, "CNPJ do declarante", 4, 17, 14, "CNPJ")]
        public string CnpjDeclarante { get; set; }

        [DimobCampos(3, "Ano-calendário", 18, 21, 4, "ANO")]
        public int AnoCalendario { get; set; }

        [DimobCampos(4, "Sequencial da Locação", 22, 26, 5, "N")]
        public int SequencialLocacao { get; set; }

        [DimobCampos(5, "CPF/CNPJ do Locador", 27, 40, 14, "CPF/CNPJ")]
        public string CpfCnpjLocador { get; set; }

        [DimobCampos(6, "Nome/Nome Empresarial do Locador", 41, 100, 60, "X")]
        public string NomeLocador { get; set; }

        [DimobCampos(7, "CPF/CNPJ do Locatário", 101, 114, 14, "CPF/CNPJ2")]
        public string CpfCnpjLocatario { get; set; }

        [DimobCampos(8, "Nome/Nome Empresarial do Locatário", 115, 174, 60, "X")]
        public string NomeLocatario { get; set; }

        [DimobCampos(9, "Número do contrato", 175, 180, 6, "X")]
        public string NumeroContrato { get; set; }

        [DimobCampos(10, "Data do contrato", 181, 188, 8, "DATA")]
        public DateTime DataContrato { get; set; }

        #region Janeiro

        [DimobCampos(11, "Valor do Aluguel no Mês de Janeiro", 189, 202, 14, "R$")]
        public decimal ValorAluguelJaneiro { get; set; }

        [DimobCampos(12, "Valor da Comissão no Mês de Janeiro", 203, 216, 14, "R$")]
        public decimal ValorComissaoJaneiro { get; set; }

        [DimobCampos(13, "Valor do Imposto no Mês de Janeiro", 217, 230, 14, "R$")]
        public decimal ValorImpostoJaneiro { get; set; }

        #endregion Janeiro

        #region Fevereiro

        [DimobCampos(14, "Valor do Aluguel no Mês de Fevereiro", 231, 244, 14, "R$")]
        public decimal ValorAluguelFevereiro { get; set; }

        [DimobCampos(15, "Valor da Comissão no Mês de Fevereiro", 245, 258, 14, "R$")]
        public decimal ValorComissaoFevereiro { get; set; }

        [DimobCampos(16, "Valor do Imposto no Mês de Fevereiro", 259, 272, 14, "R$")]
        public decimal ValorImpostoFevereiro { get; set; }

        #endregion Fevereiro

        #region Março

        [DimobCampos(17, "Valor do Aluguel no Mês de Março", 273, 286, 14, "R$")]
        public decimal ValorAluguelMarco { get; set; }

        [DimobCampos(18, "Valor da Comissão no Mês de Março", 287, 300, 14, "R$")]
        public decimal ValorComissaoMarco { get; set; }

        [DimobCampos(19, "Valor do Imposto no Mês de Março", 301, 314, 14, "R$")]
        public decimal ValorImpostoMarco { get; set; }

        #endregion Março

        #region Abril

        [DimobCampos(20, "Valor do Aluguel no Mês de Abril", 315, 328, 14, "R$")]
        public decimal ValorAluguelAbril { get; set; }

        [DimobCampos(21, "Valor da Comissão no Mês de Abril", 329, 342, 14, "R$")]
        public decimal ValorComissaoAbril { get; set; }

        [DimobCampos(22, "Valor do Imposto no Mês de Abril", 343, 356, 14, "R$")]
        public decimal ValorImpostoAbril { get; set; }

        #endregion Abril

        #region Maio

        [DimobCampos(23, "Valor do Aluguel no Mês de Maio", 357, 370, 14, "R$")]
        public decimal ValorAluguelMaio { get; set; }

        [DimobCampos(24, "Valor da Comissão no Mês de Maio", 371, 384, 14, "R$")]
        public decimal ValorComissaoMaio { get; set; }

        [DimobCampos(25, "Valor do Imposto no Mês de Maio", 385, 398, 14, "R$")]
        public decimal ValorImpostoMaio { get; set; }

        #endregion Maio

        #region Junho

        [DimobCampos(26, "Valor do Aluguel no Mês de Junho", 399, 412, 14, "R$")]
        public decimal ValorAluguelJunho { get; set; }

        [DimobCampos(27, "Valor da Comissão no Mês de Junho", 413, 426, 14, "R$")]
        public decimal ValorComissaoJunho { get; set; }

        [DimobCampos(28, "Valor do Imposto no Mês de Junho", 427, 440, 14, "R$")]
        public decimal ValorImpostoJunho { get; set; }

        #endregion Junho

        #region Julho

        [DimobCampos(29, "Valor do Aluguel no Mês de Julho", 441, 454, 14, "R$")]
        public decimal ValorAluguelJulho { get; set; }

        [DimobCampos(30, "Valor da Comissão no Mês de Julho", 455, 468, 14, "R$")]
        public decimal ValorComissaoJulho { get; set; }

        [DimobCampos(31, "Valor do Imposto no Mês de Julho", 469, 482, 14, "R$")]
        public decimal ValorImpostoJulho { get; set; }

        #endregion Julho

        #region Agosto

        [DimobCampos(32, "Valor do Aluguel no Mês de Agosto", 483, 496, 14, "R$")]
        public decimal ValorAluguelAgosto { get; set; }

        [DimobCampos(33, "Valor da Comissão no Mês de Agosto", 497, 510, 14, "R$")]
        public decimal ValorComissaoAgosto { get; set; }

        [DimobCampos(34, "Valor do Imposto no Mês de Agosto", 511, 524, 14, "R$")]
        public decimal ValorImpostoAgosto { get; set; }

        #endregion Agosto

        #region Setembro

        [DimobCampos(35, "Valor do Aluguel no Mês de Setembro", 525, 538, 14, "R$")]
        public decimal ValorAluguelSetembro { get; set; }

        [DimobCampos(36, "Valor da Comissão no Mês de Setembro", 539, 552, 14, "R$")]
        public decimal ValorComissaoSetembro { get; set; }

        [DimobCampos(37, "Valor do Imposto no Mês de Setembro", 553, 566, 14, "R$")]
        public decimal ValorImpostoSetembro { get; set; }

        #endregion Setembro

        #region Outubro

        [DimobCampos(38, "Valor do Aluguel no Mês de Outubro", 567, 580, 14, "R$")]
        public decimal ValorAluguelOutubro { get; set; }

        [DimobCampos(39, "Valor da Comissão no Mês de Outubro", 581, 594, 14, "R$")]
        public decimal ValorComissaoOutubro { get; set; }

        [DimobCampos(40, "Valor do Imposto no Mês de Outubro", 595, 608, 14, "R$")]
        public decimal ValorImpostoOutubro { get; set; }

        #endregion Outubro

        #region Novembro

        [DimobCampos(41, "Valor do Aluguel no Mês de Novembro", 609, 622, 14, "R$")]
        public decimal ValorAluguelNovembro { get; set; }

        [DimobCampos(42, "Valor da Comissão no Mês de Novembro", 623, 636, 14, "R$")]
        public decimal ValorComissaoNovembro { get; set; }

        [DimobCampos(43, "Valor do Imposto no Mês de Novembro", 637, 650, 14, "R$")]
        public decimal ValorImpostoNovembro { get; set; }

        #endregion Novembro

        #region Dezembro

        [DimobCampos(44, "Valor do Aluguel no Mês de Dezembro", 651, 664, 14, "R$")]
        public decimal ValorAluguelDezembro { get; set; }

        [DimobCampos(45, "Valor da Comissão no Mês de Dezembro", 665, 678, 14, "R$")]
        public decimal ValorComissaoDezembro { get; set; }

        [DimobCampos(46, "Valor do Imposto no Mês de Dezembro", 679, 692, 14, "R$")]
        public decimal ValorImpostoDezembro { get; set; }

        #endregion Dezembro

        /// <summary>
        /// "U" - Imóvel Urbano; "R" - Imóvel Rural
        /// </summary>
        [DimobCampos(47, "Tipo do Imóvel", 693, 693, 1, "X")]
        public string TipoImovel { get; set; }

        [DimobCampos(48, "Endereço do Imóvel", 694, 753, 60, "X")]
        public string EnderecoImovel { get; set; }

        [DimobCampos(49, "CEP", 754, 761, 8, "N")]
        public string Cep { get; set; }

        [DimobCampos(50, "Código do Município do Imóvel", 762, 765, 4, "N")]
        public int CodigoMunicipio { get; set; }

        [DimobCampos(51, "Reservado", 766, 785, 20, "Branco(s)")]
        public string Reservado1 { get; private set; }

        [DimobCampos(52, "UF", 786, 787, 2, "X")]
        public string Uf { get; set; }

        [DimobCampos(53, "Reservado", 788, 797, 10, "Branco(s)")]
        public string Reservado2 { get; private set; }
    }
}
