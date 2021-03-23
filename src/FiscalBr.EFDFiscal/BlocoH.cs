using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDFiscal
{
    /// <summary>
    ///     BLOCO H: INVENTÁRIO FÍSICO
    /// </summary>
    public class BlocoH
    {
        public RegistroH001 RegH001 { get; set; }
        public RegistroH990 RegH990 { get; set; }

        /// <summary>
        ///     REGISTRO H001: ABERTURA DO BLOCO H
        /// </summary>
        public class RegistroH001 : RegistroBaseSped
        {
            /// <summary>
            ///  Inicializa uma nova instância da classe <see cref="RegistroH001" />.
            /// </summary>
            public RegistroH001()
            {
                Reg = "H001";
            }

            /// <summary>
            ///     Indicador de movimento: 0 - Bloco com dados informados; 1 - Bloco sem dados informados.
            /// </summary>
            [SpedCampos(2, "IND_MOV", "N", 1, 0, true)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroH005> RegH005s { get; set; }
        }

        /// <summary>
        ///     REGISTRO H005: TOTAIS DO INVENTÁRIO
        /// </summary>
        public class RegistroH005 : RegistroBaseSped
        {
            /// <summary>
            ///  Inicializa uma nova instância da classe <see cref="RegistroH005" />.
            /// </summary>
            public RegistroH005()
            {
                Reg = "H005";
            }

            /// <summary>
            ///     Data do inventário
            /// </summary>
            [SpedCampos(2, "DT_INV", "N", 8, 0, true)]
            public DateTime DtInv { get; set; }

            /// <summary>
            ///     Valor total do estoque
            /// </summary>
            [SpedCampos(3, "VL_INV", "N", 0, 2, true)]
            public decimal VlInv { get; set; }

            /// <summary>
            ///     Informe o motivo do Inventário:
            ///     01 – No final no período;
            ///     02 – Na mudança de forma de tributação da mercadoria (ICMS);
            ///     03 – Na solicitação da baixa cadastral, paralisação temporária e outras situações;
            ///     04 – Na alteração de regime de pagamento – condição do contribuinte;
            ///     05 – Por determinação dos fiscos.
            /// </summary>
            [SpedCampos(4, "MOT_INV", "C", 2, 0, true)]
            public int MotInv { get; set; }

            public List<RegistroH010> RegH010s { get; set; }
        }

        /// <summary>
        ///     REGISTRO H010: INVENTÁRIO
        /// </summary>
        public class RegistroH010 : RegistroBaseSped
        {
            /// <summary>
            ///  Inicializa uma nova instância da classe <see cref="RegistroH010" />.
            /// </summary>
            public RegistroH010()
            {
                Reg = "H010";
            }

            /// <summary>
            ///     Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Unidade do item
            /// </summary>
            [SpedCampos(3, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///     Quantidade do item
            /// </summary>
            [SpedCampos(4, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Valor unitário do item
            /// </summary>
            [SpedCampos(5, "VL_UNIT", "N", 0, 6, true)]
            public decimal VlUnit { get; set; }

            /// <summary>
            ///     Valor do item
            /// </summary>
            [SpedCampos(6, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Indicador de propriedade/posse do item: 0- Item de propriedade do informante e em seu poder; 1- Item de propriedade
            ///     do informante em posse de terceiros; 2- Item de propriedade de terceiros em posse do informante
            /// </summary>
            [SpedCampos(7, "IND_PROP", "C", 1, 0, true)]
            public int IndProp { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150): - proprietário/possuidor que não seja o informante do arquivo
            /// </summary>
            [SpedCampos(8, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Descrição complementar.
            /// </summary>
            [SpedCampos(9, "TXT_COMPL", "C", 0, 0, false)]
            public string TxtCompl { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(10, "COD_CTA", "C", int.MaxValue, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Valor do item para efeitos do Imposto de Renda.
            /// </summary>
            [SpedCampos(11, "VL_ITEM_IR", "N", 0, 2, false)]
            public decimal VlItemIr { get; set; }

            public List<RegistroH020> RegH020s { get; set; }
            public RegistroH030 RegH030 { get; set; }
        }

        /// <summary>
        ///     REGISTRO H020: Informação complementar do Inventário.
        /// </summary>
        public class RegistroH020 : RegistroBaseSped
        {
            /// <summary>
            ///  Inicializa uma nova instância da classe <see cref="RegistroH020" />.
            /// </summary>
            public RegistroH020()
            {
                Reg = "H020";
            }

            /// <summary>
            ///     Código da Situação Tributária referente ao ICMS, conforme a Tabela indicada no item 4.3.1
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public string CstIcms { get; set; }

            /// <summary>
            ///     Informe a base de cálculo do ICMS
            /// </summary>
            [SpedCampos(3, "BC_ICMS", "N", 0, 2, true)]
            public decimal BcIcms { get; set; }

            /// <summary>
            ///     Informe o valor do ICMS a ser debitado ou creditado
            /// </summary>
            [SpedCampos(2, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }
        }

        /// <summary>
        ///     REGISTRO H030: 
        /// </summary>
        public class RegistroH030 : RegistroBaseSped
        {
            /// <summary>
            ///  Inicializa uma nova instância da classe <see cref="RegistroH030" />.
            /// </summary>
            public RegistroH030()
            {
                Reg = "H030";
            }

            /// <summary>
            ///     Valor médio unitário do ICMS OP
            /// </summary>
            [SpedCampos(2, "VL_ICMS_OP", "N", 0, 6, true)]
            public string VlIcmsOp { get; set; }

            /// <summary>
            ///     Valor médio unitário da base de cálculo do ICMS ST
            /// </summary>
            [SpedCampos(3, "VL_BC_ICMS_ST", "N", 0, 6, true)]
            public string VlBcIcmsSt { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS ST
            /// </summary>
            [SpedCampos(4, "VL_ICMS_ST", "N", 0, 6, true)]
            public string VlIcmsSt { get; set; }

            /// <summary>
            ///    Valor médio unitário do FCP
            /// </summary>
            [SpedCampos(5, "VL_FCP", "N", 0, 6, true)]
            public string VlFcp { get; set; }
        }

        /// <summary>
        ///     REGISTRO H990: ENCERRAMENTO DO BLOCO H.
        /// </summary>
        public class RegistroH990 : RegistroBaseSped
        {
            /// <summary>
            ///  Inicializa uma nova instância da classe <see cref="RegistroH990" />.
            /// </summary>
            public RegistroH990()
            {
                Reg = "H990";
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco H
            /// </summary>
            [SpedCampos(2, "QTD_LIN_H", "N", int.MaxValue, 0, true)]
            public int QtdLinH { get; set; }
        }
    }
}
