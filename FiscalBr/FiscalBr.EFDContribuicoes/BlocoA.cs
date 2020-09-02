using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.EFDContribuicoes
{
    public class BlocoA
    {
        public class RegistroA001 : RegistroBaseSped
        {
            public RegistroA001()
            {
                Reg = "A001";
            }

            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }
        }
        
        /// <summary>
        /// IDENTIFICAÇÃO DO ESTABELECIMENTO
        /// </summary>
        public class RegistroA010 : RegistroBaseSped
        {
            public RegistroA010()
            {
                Reg = "A010";
            }

            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

        }
        
        /// <summary>
        /// DOCUMENTO - NOTA FISCAL DE SERVIÇO
        /// </summary>
        public class RegistroA100 : RegistroBaseSped
        {
            public RegistroA100()
            {
                Reg = "A100";
            }

            /// <summary>
            ///     Indicador do tipo de operação:
            ///     0 - Serviço Contratado pelo Estabelecimento;
            ///     1 - Serviço Prestado pelo Estabelecimento.
            /// </summary>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true)]
            public int IndOper { get; set; }

            /// <summary>
            ///     Indicador do emitente do documento fiscal:
            ///     0 - Emissão própria;
            ///     1 - Terceiros;
            /// </summary>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true)]
            public int IndEmit { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150):
            ///     - do emitente do documento ou do remetente das mercadorias, no caso de entradas;
            ///     - do adquirente, no caso de saídas.
            /// </summary>
            [SpedCampos(4, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(5, "COD_SIT", "N", 2, 0, true)]
            public int CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(6, "SER", "C", 20, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(7, "SUB", "C", 20, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal ou documento internacional equivalente
            /// </summary>
            [SpedCampos(8, "NUM_DOC", "N", 60, 0, true)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Chave/Código de Verificação da nota fiscal de serviço eletrônica
            /// </summary>
            [SpedCampos(9, "CHV_NFSE", "N", 60, 0, false)]
            public string ChvNfse { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(10, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Data de Execução / Conclusão do Serviço
            /// </summary>
            [SpedCampos(11, "DT_EXE_SERV", "N", 8, 0, false)]
            public DateTime? DtExeServ { get; set; }

            /// <summary>
            ///     Valor total do documento
            /// </summary>
            [SpedCampos(12, "VL_DOC", "N", 0, 2, true)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Indicador do tipo de pagamento:
            ///     0 - À vista;
            ///     1 - A prazo;
            ///     9 - Sem pagamento (até 30/06/2012).
            /// </summary>
            [SpedCampos(13, "IND_PGTO", "C", 1, 0, true)]
            public int IndPgto { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(14, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS/PASEP
            /// </summary>
            [SpedCampos(15, "VL_BC_PIS", "N", 0, 2, true)]
            public decimal VlBcPis { get; set; }

            /// <summary>
            ///     Valor total do PIS
            /// </summary>
            [SpedCampos(16, "VL_PIS", "N", 0, 2, true)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da base de cálculo da COFINS
            /// </summary>
            [SpedCampos(17, "VL_BC_COFINS", "N", 0, 2, true)]
            public decimal VlBcCofins { get; set; }

            /// <summary>
            ///     Valor total da COFINS
            /// </summary>
            [SpedCampos(18, "VL_COFINS", "N", 0, 2, true)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Valor total do PIS Retido na Fonte
            /// </summary>
            [SpedCampos(19, "VL_PIS_RET", "N", 0, 2, false)]
            public decimal? VlPisRet { get; set; }

            /// <summary>
            ///     Valor total da COFINS Retido na Fonte
            /// </summary>
            [SpedCampos(20, "VL_COFINS_RET", "N", 0, 2, false)]
            public decimal? VlCofinsRet { get; set; }

            /// <summary>
            ///     Valor do ISS
            /// </summary>
            [SpedCampos(21, "VL_ISS", "N", 0, 2, false)]
            public decimal? VlIss { get; set; }
        }
        
        /// <summary>
        /// COMPLEMENTO DO DOCUMENTO - INFORMAÇÃO COMPLEMENTAR DA NF
        /// </summary>
        public class RegistroA110 : RegistroBaseSped
        {
            public RegistroA110()
            {
                Reg = "A110";
            }

            [SpedCampos(2, "COD_INF", "C", 6, 0, true)]
            public string CodInf { get; set; }

            [SpedCampos(3, "TXT_COMPL", "C", int.MaxValue, 0, false)]
            public string TxtCompl { get; set; }
        }
        
        /// <summary>
        /// COMPLEMENTO DO DOCUMENTO - ITENS DO DOCUMENTO
        /// </summary>
        public class RegistroA170 : RegistroBaseSped
        {
            public RegistroA170()
            {
                Reg = "A170";
            }

            /// <summary>
            /// Número seqüencial do item no documento fiscal
            /// </summary>
            [SpedCampos(2, "NUM_ITEM", "N", 4, 0, true)]
            public int NumItem { get; set; }

            /// <summary>
            /// Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            /// Descrição complementar do item como adotado no documento fiscal
            /// </summary>
            [SpedCampos(4, "DESCR_COMPL", "C", int.MaxValue, 0, false)]
            public string DescrCompl { get; set; }

            /// <summary>
            /// Valor total do item (mercadorias ou serviços)
            /// </summary>
            [SpedCampos(5, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            /// Valor do desconto do item / Exclusão
            /// </summary>
            [SpedCampos(6, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            /// Código da Base de Cálculo do Crédito, conforme a Tabela indicada no item 4.3.7, caso seja informado
            /// código representativo de crédito no Campo 09 (CST_PIS) ou no Campo 13 (CST_COFINS).
            /// </summary>
            [SpedCampos(7, "NAT_BC_CRED", "C", 2, 0, false)]
            public string NatBcCred { get; set; }

            /// <summary>
            /// Indicador da origem do crédito:
            /// 0 – Operação no Mercado Interno
            /// 1 – Operação de Importação
            /// </summary>
            [SpedCampos(8, "IND_ORIG_CRED", "C", 1, 0, false)]
            public string IndOrigCred { get; set; }

            /// <summary>
            /// Código da Situação Tributária referente ao PIS/PASEP – Tabela 4.3.3.
            /// </summary>
            [SpedCampos(9, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS/PASEP
            /// </summary>
            [SpedCampos(10, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal VlBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(11, "ALIQ_PIS", "N", 0, 2, false)]
            public decimal AliqPis { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(12, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            /// Código da Situação Tributária referente ao COFINS – Tabela 4.3.4.
            /// </summary>
            [SpedCampos(13, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Valor da base de cálculo da COFINS
            /// </summary>
            [SpedCampos(14, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal VlBcCofins { get; set; }

            /// <summary>
            /// Alíquota do COFINS (em percentual)
            /// </summary>
            [SpedCampos(15, "ALIQ_COFINS", "N", 0, 2, false)]
            public decimal AliqCofins { get; set; }

            /// <summary>
            ///     Valor total da COFINS
            /// </summary>
            [SpedCampos(16, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            /// <summary>
            /// Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(17, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            /// Código do centro de custos
            /// </summary>
            [SpedCampos(18, "COD_CCUS", "C", 60, 0, false)]
            public string CodCcus { get; set; }
        }


        public class RegistroA990 : RegistroBaseSped
        {
            public RegistroA990()
            {
                Reg = "A990";
            }

            [SpedCampos(2, "QTD_LIN_A", "N", int.MaxValue, 0, true)]
            public int QtdLinA { get; set; }
        }
    }
}
