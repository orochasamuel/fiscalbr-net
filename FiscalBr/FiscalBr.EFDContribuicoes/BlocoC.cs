using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.EFDContribuicoes
{
    public class BlocoC
    {
        /// <summary>
        ///     ABERTURA DO BLOCO C
        /// </summary>
        public class RegistroC001 : RegistroBaseSped
        {
            public RegistroC001()
            {
                Reg = "C001";
            }

            /// <summary>
            ///     Indicador de movimento: 0 - Bloco com dados informados; 1 - Bloco sem dados informados.
            /// </summary>
            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }
        }

        /// <summary>
        ///     IDENTIFICAÇÃO DO ESTABELECIMNTO
        /// </summary>
        public class RegistroC010 : RegistroBaseSped
        {
            public RegistroC010()
            {
                Reg = "C010";
            }

            /// <summary>
            ///     Número de inscrição do estabelecimento no CNPJ
            /// </summary>
            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            /// <summary>
            ///     Indicador da apuração das contribuições e créditos, na
            ///     escrituração das operações por NF-e e ECF no período:
            ///     1 - Apuração com base nos registros de consolidação das
            ///     operações por NF-e (C180 e C190) e por ECF(C490)
            ///     2 - Apuração com base no registro individualizado de NFe
            ///     (C100 e C170) e ECF (C400)
            /// </summary>
            [SpedCampos(3, "IND_ESCRI", "C", 1, 0, false)]
            public int IndEscri { get; set; }
            
        }

        /// <summary>
        ///     REGISTRO C100: Nota fiscal, Nota fiscal avulsa, Nota fiscal de produtor, NF-e e NFC-e
        /// </summary>
        public class RegistroC100 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC100" />.
            /// </summary>
            public RegistroC100()
            {
                Reg = "C100";
            }

            /// <summary>
            ///     Indicador do tipo de operação:
            ///     0 - Entrada;
            ///     1 - Saída.
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
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(5, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(6, "COD_SIT", "N", 2, 0, true)]
            public int CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(7, "SER", "C", 3, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(8, "NUM_DOC", "N", 9, 0, true)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Chave da nota fiscal eletrônica
            /// </summary>
            [SpedCampos(9, "CHV_NFE", "N", 44, 0, false)]
            public string ChvNfe { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(10, "DT_DOC", "N", 8, 0, false)]
            public DateTime? DtDoc { get; set; }

            /// <summary>
            ///     Data da entrada ou da saída
            /// </summary>
            [SpedCampos(11, "DT_E_S", "N", 8, 0, false)]
            public DateTime? DtEs { get; set; }

            /// <summary>
            ///     Valor total do documento fiscal
            /// </summary>
            [SpedCampos(12, "VL_DOC", "N", 0, 2, false)]
            public decimal? VlDoc { get; set; }

            /// <summary>
            ///     Indicador do tipo de pagamento:
            ///     0 - À vista;
            ///     1 - A prazo;
            ///     2 - Outros (a partir de 01/07/2012).
            /// </summary>
            [SpedCampos(13, "IND_PGTO", "C", 1, 0, false)]
            public int? IndPgto { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(14, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            /// <summary>
            ///     Abatimento não tributado e não comercial.
            ///     Ex.: desconto ICMS nas remessas para ZFM.
            /// </summary>
            [SpedCampos(15, "VL_ABAT_NT", "N", 0, 2, false)]
            public decimal? VlAbatNt { get; set; }

            /// <summary>
            ///     Valor total das mercadorias e serviços
            /// </summary>
            [SpedCampos(16, "VL_MERC", "N", 0, 2, false)]
            public decimal? VlMerc { get; set; }

            /// <summary>
            ///     Indicador do tipo do frete:
            ///     0 - Por conta do emitente;
            ///     1 - Por conta do destinatário/remetente;
            ///     2 - Por conta de terceiros;
            ///     9 - Sem cobrança de frete.
            /// </summary>
            [SpedCampos(17, "IND_FRT", "C", 1, 0, false)]
            public int? IndFrt { get; set; }

            /// <summary>
            ///     Valor do frete indicado no documento fiscal
            /// </summary>
            [SpedCampos(18, "VL_FRT", "N", 0, 2, false)]
            public decimal? VlFrt { get; set; }

            /// <summary>
            ///     Valor do seguro indicado no documento fiscal
            /// </summary>
            [SpedCampos(19, "VL_SEG", "N", 0, 2, false)]
            public decimal? VlSeg { get; set; }

            /// <summary>
            ///     Valor de outras despesas acessórias
            /// </summary>
            [SpedCampos(20, "VL_OUT_DA", "N", 0, 2, false)]
            public decimal? VlOutDa { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(21, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal? VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS
            /// </summary>
            [SpedCampos(22, "VL_ICMS", "N", 0, 2, false)]
            public decimal? VlIcms { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS substituição tributária
            /// </summary>
            [SpedCampos(23, "VL_BC_ICMS_ST", "N", 0, 2, false)]
            public decimal? VlBcIcmsSt { get; set; }

            /// <summary>
            ///     Valor do ICMS retido por substituição tributária
            /// </summary>
            [SpedCampos(24, "VL_ICMS_ST", "N", 0, 2, false)]
            public decimal? VlIcmsSt { get; set; }

            /// <summary>
            ///     Valor total do IPI
            /// </summary>
            [SpedCampos(25, "VL_IPI", "N", 0, 2, false)]
            public decimal? VlIpi { get; set; }

            /// <summary>
            ///     Valor total do PIS
            /// </summary>
            [SpedCampos(26, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Valor total da COFINS
            /// </summary>
            [SpedCampos(27, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     Valor total do PIS retido por substituição tributária
            /// </summary>
            [SpedCampos(28, "VL_PIS_ST", "N", 0, 2, false)]
            public decimal? VlPisSt { get; set; }

            /// <summary>
            ///     Valor total da COFINS retido por substituição tributária
            /// </summary>
            [SpedCampos(29, "VL_COFINS_ST", "N", 0, 2, false)]
            public decimal? VlCofinsSt { get; set; }

        }

        /// <summary>
        ///     INFORMAÇÃO COMPLEMENTAR DA NOTA FISCAL (CÓDIGO 01, 1B, 04 e 55)
        /// </summary>
        public class RegistroC110 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC110" />.
            /// </summary>
            public RegistroC110()
            {
                Reg = "C110";
            }

            /// <summary>
            ///     Código da informação complementar do documento fiscal (campo 02 do Registro 0450)
            /// </summary>
            [SpedCampos(2, "COD_INF", "C", 6, 0, true)]
            public string CodInf { get; set; }

            /// <summary>
            ///     Descrição complementar do código de referência
            /// </summary>
            [SpedCampos(3, "TXT_COMPL", "C", 999, 0, false)]
            public string TxtCompl { get; set; }

        }

        /// <summary>
        ///     REGISTRO 170: ITENS DO DOCUMENTO (CÓDIGO 01, 1B, 04 e 55)
        /// </summary>
        public class RegistroC170 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC170" />.
            /// </summary>
            public RegistroC170()
            {
                Reg = "C170";
            }

            /// <summary>
            ///     Número sequencial do item no documento fiscal
            /// </summary>
            [SpedCampos(2, "NUM_ITEM", "N", 3, 0, true)]
            public int NumItem { get; set; }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Descrição complementar do item como adotado no documento fiscal
            /// </summary>
            [SpedCampos(4, "DESCR_COMPL", "C", 999, 0, false)]
            public string DescrCompl { get; set; }

            /// <summary>
            ///     Quantidade do item
            /// </summary>
            [SpedCampos(5, "QTD", "N", 0, 5, false)]
            public decimal? Qtd { get; set; }

            /// <summary>
            ///     Unidade do item
            /// </summary>
            [SpedCampos(6, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///     Valor total do item (mercadorias ou serviços)
            /// </summary>
            [SpedCampos(7, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Valor do desconto comercial
            /// </summary>
            [SpedCampos(8, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Indicador de movimentação física do item/produto
            /// </summary>
            /// <remarks>
            ///     0 - Sim
            ///     <para />
            ///     1 - Não
            /// </remarks>
            [SpedCampos(9, "IND_MOV", "C", 1, 0, true)]
            public IndMovFisicaItem IndMov { get; set; }

            /// <summary>
            ///     Código da situação tributária referente ao ICMS
            /// </summary>
            [SpedCampos(10, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(11, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Código da natureza da operação
            /// </summary>
            [SpedCampos(12, "COD_NAT", "C", 10, 0, false)]
            public string CodNat { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(13, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(14, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS creditado/debitado
            /// </summary>
            [SpedCampos(15, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor da base de cálculo referente à substituição tributária
            /// </summary>
            [SpedCampos(16, "VL_BC_ICMS_ST", "N", 0, 2, false)]
            public decimal VlBcIcmsSt { get; set; }

            /// <summary>
            ///     Alíquota do ICMS da substituição tributária na unidade da federação de destino
            /// </summary>
            [SpedCampos(17, "ALIQ_ST", "N", 0, 2, false)]
            public decimal AliqSt { get; set; }

            /// <summary>
            ///     Valor do ICMS referente à substituição tributária
            /// </summary>
            [SpedCampos(18, "VL_ICMS_ST", "N", 0, 2, false)]
            public decimal VlIcmsSt { get; set; }

            /// <summary>
            ///     Indicador do período de apuração do IPI
            /// </summary>
            /// <remarks>
            ///     0 - Mensal
            ///     <para />
            ///     1 - Decendial
            /// </remarks>
            [SpedCampos(19, "IND_APUR", "C", 1, 0, false)]
            public IndPeriodoApuracaoIpi IndApur { get; set; }

            /// <summary>
            ///     Código da situação tributária referente ao IPI
            /// </summary>
            [SpedCampos(20, "CST_IPI", "C", 2, 0, false)]
            public string CstIpi { get; set; }

            /// <summary>
            ///     Código de enquadramento legal do IPI
            /// </summary>
            [SpedCampos(21, "COD_ENQ", "C", 3, 0, false)]
            public string CodEnq { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do IPI
            /// </summary>
            [SpedCampos(22, "VL_BC_IPI", "N", 0, 2, false)]
            public decimal VlBcIpi { get; set; }

            /// <summary>
            ///     Alíquota do IPI
            /// </summary>
            [SpedCampos(23, "ALIQ_IPI", "N", 6, 2, false)]
            public decimal AliqIpi { get; set; }

            /// <summary>
            ///     Valor do IPI creditado/debitado
            /// </summary>
            [SpedCampos(24, "VL_IPI", "N", 0, 2, false)]
            public decimal VlIpi { get; set; }

            /// <summary>
            ///     Código da situação tributária referente ao PIS
            /// </summary>
            [SpedCampos(25, "CST_PIS", "N", 2, 0, false)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS
            /// </summary>
            [SpedCampos(26, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal VlBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS (em percentual)
            /// </summary>
            [SpedCampos(27, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal AliqPis { get; set; }

            /// <summary>
            ///     Quantidade - Base de cálculo PIS
            /// </summary>
            [SpedCampos(28, "QUANT_BC_PIS", "N", 0, 3, false)]
            public decimal? QuantBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS (em reais)
            /// </summary>
            [SpedCampos(29, "ALIQ_PIS_QUANT", "N", 0, 4, false)]
            public decimal? AliqPisQuant { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(30, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Código da situação tributária referente ao COFINS
            /// </summary>
            [SpedCampos(31, "CST_COFINS", "N", 2, 0, false)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Valor da base de cálculo da COFINS
            /// </summary>
            [SpedCampos(32, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal VlBcCofins { get; set; }

            /// <summary>
            ///     Alíquota do COFINS (em percentual)
            /// </summary>
            [SpedCampos(33, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal AliqCofins { get; set; }

            /// <summary>
            ///     Quantidade - Base de cálculo COFINS
            /// </summary>
            [SpedCampos(34, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public decimal? QuantBcCofins { get; set; }

            /// <summary>
            ///     Alíquota da COFINS (em reais)
            /// </summary>
            [SpedCampos(35, "ALIQ_COFINS_QUANT", "N", 0, 4, false)]
            public decimal? AliqCofinsQuant { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(36, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(37, "COD_CTA", "C", 999, 0, false)]
            public string CodCta { get; set; }

        }

        /// <summary>
        ///     REGISTRO ANALÍTICO DO COMCUMENTO (CÓDIGO  65)
        /// </summary>
        public class RegistroC175 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC175" />.
            /// </summary>
            public RegistroC175()
            {
                Reg = "C175";
            }

            /// <summary>
            ///     Código fiscal da operação e prestação
            /// </summary>
            [SpedCampos(2, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Valor da operação na combinação de CFOP, CST e alíquotas,
            ///     correpondente ao somatório do valor das mercadorias e produtos
            ///     constantes no documento
            /// </summary>
            [SpedCampos(3, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Valor do desconto comercial / Exclusão
            /// </summary>
            [SpedCampos(4, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            /// <summary>
            ///     Código da Situaçao Tributaria referente ao PIS/PASEP, conforme
            ///     a Tabela indicada no item 4.3.3
            /// </summary>
            [SpedCampos(5, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS/PASEP (em valor)
            /// </summary>
            [SpedCampos(6, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            /// <summary>
            ///     Aliquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(7, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal? AliqPis { get; set; }
            
            /// <summary>
            ///     Base de cálculo do PIS/PASEP (em quantidade)
            /// </summary>
            [SpedCampos(8, "QUANT_BC_PIS", "N", 0, 3, false)]
            public decimal? QuantBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em reais)
            /// </summary>
            [SpedCampos(9, "ALIQ_PIS_QUANT", "N", 0, 4, false)]
            public decimal? AliqPisQuant { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(10, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Código da Situaçao Tributaria referente a COFINS, conforme
            ///     a Tabela indicada no item 4.3.4
            /// </summary>
            [SpedCampos(11, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Valor da base de cálculo da Cofins
            /// </summary>
            [SpedCampos(12, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal? VlBcCofins { get; set; }

            /// <summary>
            ///     Aliquota da Cofins (em percentual)   
            /// </summary>
            [SpedCampos(13, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal? AliqCofins { get; set; }

            /// <summary>
            ///     Base de cálculo da Cofins (em quantidade)
            /// </summary>
            [SpedCampos(14, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public decimal? QuantBcCofins { get; set; }

            /// <summary>
            ///     Alíquota da Cofins (em reais)
            /// </summary>
            [SpedCampos(15, "ALIQ_COFINS_QUANT", "N", 0, 4, false)]
            public decimal? AliqCofinsQuant { get; set; }

            /// <summary>
            ///     Valor da Cofins
            /// </summary>
            [SpedCampos(16, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica contáil debitada/creditada
            /// </summary>
            [SpedCampos(17, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Informação complementar
            /// </summary>
            [SpedCampos(18, "INFO_COMPL", "C", int.MaxValue, 0, false)]
            public string InfoCompl { get; set; }
        }

        public class RegistroC180 : RegistroBaseSped
        {
            public RegistroC180()
            {
                Reg = "C180";
            }

            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            [SpedCampos(3, "DT_DOC_INI", "N", 8, 0, true)]
            public DateTime DtDocIni { get; set; }

            [SpedCampos(4, "DT_DOC_FIN", "N", 8, 0, true)]
            public DateTime DtDocFin { get; set; }

            [SpedCampos(5, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            [SpedCampos(6, "COD_NCM", "C", 8, 0, false)]
            public string CodNcm { get; set; }

            [SpedCampos(7, "EX_IPI", "C", 3, 0, false)]
            public string ExIpi { get; set; }

            [SpedCampos(8, "VL_TOT_ITEM", "N", 0, 2, true)]
            public decimal VlTotItem { get; set; }

        }

        public class RegistroC181 : RegistroBaseSped
        {
            public RegistroC181()
            {
                Reg = "C181";
            }

            [SpedCampos(2, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            [SpedCampos(4, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            [SpedCampos(5, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            [SpedCampos(6, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            [SpedCampos(7, "ALIQ_PIS", "N", 0, 4, false)]
            public decimal? AliqPis { get; set; }

            [SpedCampos(8, "QUANT_BC_PIS", "N", 0, 3, false)]
            public decimal? QuantBcPis { get; set; }

            [SpedCampos(9, "ALIQ_PIS_QUANT", "N", 0, 4, false)]
            public decimal? AliqPisQuant { get; set; }

            [SpedCampos(10, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            [SpedCampos(11, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class RegistroC185 : RegistroBaseSped
        {
            public RegistroC185()
            {
                Reg = "C185";
            }

            [SpedCampos(2, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            [SpedCampos(4, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            [SpedCampos(5, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            [SpedCampos(6, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal? VlBcCofins { get; set; }

            [SpedCampos(7, "ALIQ_COFINS", "N", 0, 4, false)]
            public decimal? AliqCofins { get; set; }

            [SpedCampos(8, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public decimal? QuantBcCofins { get; set; }

            [SpedCampos(9, "ALIQ_COFINS_QUANT", "N", 0, 4, false)]
            public decimal? AliqCofinsQuant { get; set; }

            [SpedCampos(10, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            [SpedCampos(11, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class RegistroC190 : RegistroBaseSped
        {
            public RegistroC190()
            {
                Reg = "C190";
            }

            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            [SpedCampos(3, "DT_REF_INI", "N", 8, 0, true)]
            public DateTime DtRefIni { get; set; }

            [SpedCampos(4, "DT_REF_FIN", "N", 8, 0, true)]
            public DateTime DtRefFin { get; set; }

            [SpedCampos(5, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            [SpedCampos(6, "COD_NCM", "C", 8, 0, false)]
            public string CodNcm { get; set; }

            [SpedCampos(7, "EX_IPI", "C", 3, 0, false)]
            public string ExIpi { get; set; }

            [SpedCampos(8, "VL_TOT_ITEM", "N", 0, 2, true)]
            public decimal VlTotItem { get; set; }

        }

        public class RegistroC191 : RegistroBaseSped
        {
            public RegistroC191()
            {
                Reg = "C191";
            }

            [SpedCampos(2, "CNPJ_CPF_PART", "C", 14, 0, true)]
            public string CnpjCpfPart { get; set; }

            [SpedCampos(3, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(4, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            [SpedCampos(5, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            [SpedCampos(6, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            [SpedCampos(7, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            [SpedCampos(8, "ALIQ_PIS", "N", 0, 4, false)]
            public decimal? AliqPis { get; set; }

            [SpedCampos(9, "QUANT_BC_PIS", "N", 0, 3, false)]
            public decimal? QuantBcPis { get; set; }

            [SpedCampos(10, "ALIQ_PIS_QUANT", "N", 0, 4, false)]
            public decimal? AliqPisQuant { get; set; }

            [SpedCampos(11, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            [SpedCampos(12, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class RegistroC195 : RegistroBaseSped
        {
            public RegistroC195()
            {
                Reg = "C195";
            }

            [SpedCampos(2, "CNPJ_CPF_PART", "C", 14, 0, true)]
            public string CnpjCpfPart { get; set; }

            [SpedCampos(3, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(4, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            [SpedCampos(5, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            [SpedCampos(6, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            [SpedCampos(7, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal? VlBcCofins { get; set; }

            [SpedCampos(8, "ALIQ_COFINS", "N", 0, 4, false)]
            public decimal? AliqCofins { get; set; }

            [SpedCampos(9, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public decimal? QuantBcCofins { get; set; }

            [SpedCampos(10, "ALIQ_COFINS_QUANT", "N", 0, 4, false)]
            public decimal? AliqCofinsQuant { get; set; }

            [SpedCampos(11, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            [SpedCampos(12, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class RegistroC199 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC199" />.
            /// </summary>
            public RegistroC199()
            {
                Reg = "C199";
            }

            /// <summary>
            ///     Documento de importação
            /// </summary>
            /// <remarks>
            ///     0 - Declaração de Importação
            ///     <para />
            ///     1 - Declaração Simplificada de Importação
            /// </remarks>
            [SpedCampos(2, "COD_DOC_IMP", "C", 1, 0, true)]
            public int CodDocImp { get; set; }

            /// <summary>
            ///     Número do documento de importação
            /// </summary>
            [SpedCampos(3, "NUM_DOC_IMP", "C", 12, 0, true)]
            public string NumDocImp { get; set; }

            /// <summary>
            ///     Valor pago de PIS na importação
            /// </summary>
            [SpedCampos(4, "VL_PIS_IMP", "N", 0, 2, false)]
            public decimal VlPisImp { get; set; }

            /// <summary>
            ///     Valor pago de COFINS na importação
            /// </summary>
            [SpedCampos(5, "VL_COFINS_IMP", "N", 0, 2, false)]
            public decimal VlCofinsImp { get; set; }

            /// <summary>
            ///     Número do Ato Concessório do regime Drawback
            /// </summary>
            [SpedCampos(6, "NUM_ACDRAW", "C", 20, 0, false)]
            public string NumAcDraw { get; set; }
        }

        public class RegistroC380 : RegistroBaseSped
        {
            public RegistroC380()
            {
                Reg = "C380";
            }

            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            [SpedCampos(3, "DT_DOC_INI", "N", 8, 0, true)]
            public DateTime DtDocIni { get; set; }

            [SpedCampos(4, "DT_DOC_FIN", "N", 8, 0, true)]
            public DateTime DtDocFin { get; set; }

            [SpedCampos(5, "NUM_DOC_INI", "N", 6, 0, false)]
            public string NumDocIni { get; set; }

            [SpedCampos(6, "NUM_DOC_FIN", "N", 6, 0, false)]
            public string NumDocFin { get; set; }

            [SpedCampos(7, "VL_DOC", "N", 0, 2, false)]
            public decimal VlDoc { get; set; }

            [SpedCampos(8, "VL_DOC_CANC", "N", 0, 2, false)]
            public decimal VlDocCanc { get; set; }

        }

        public class RegistroC381 : RegistroBaseSped
        {
            public RegistroC381()
            {
                Reg = "C381";
            }

            [SpedCampos(2, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            [SpedCampos(4, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            [SpedCampos(5, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            [SpedCampos(6, "ALIQ_PIS", "N", 0, 4, false)]
            public decimal? AliqPis { get; set; }

            [SpedCampos(7, "QUANT_BC_PIS", "N", 0, 3, false)]
            public decimal? QuantBcPis { get; set; }

            [SpedCampos(8, "ALIQ_PIS_QUANT", "N", 0, 4, false)]
            public decimal? AliqPisQuant { get; set; }

            [SpedCampos(9, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            [SpedCampos(10, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class RegistroC385 : RegistroBaseSped
        {
            public RegistroC385()
            {
                Reg = "C385";
            }

            [SpedCampos(2, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            [SpedCampos(4, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            [SpedCampos(5, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal? VlBcCofins { get; set; }

            [SpedCampos(6, "ALIQ_COFINS", "N", 0, 4, false)]
            public decimal? AliqCofins { get; set; }

            [SpedCampos(7, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public decimal? QuantBcCofins { get; set; }

            [SpedCampos(8, "ALIQ_COFINS_QUANT", "N", 0, 4, false)]
            public decimal? AliqCofinsQuant { get; set; }

            [SpedCampos(9, "VL_COFINS", "N", 0, 2, true)]
            public decimal? VlCofins { get; set; }

            [SpedCampos(10, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class RegistroC395 : RegistroBaseSped
        {
            public RegistroC395()
            {
                Reg = "C395";
            }

            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            [SpedCampos(3, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            [SpedCampos(4, "SER", "C", 3, 0, true)]
            public string Ser { get; set; }

            [SpedCampos(5, "SUB_SER", "C", 3, 0, false)]
            public string SubSer { get; set; }

            [SpedCampos(6, "NUM_DOC", "C", 6, 0, true)]
            public string NumDoc { get; set; }

            [SpedCampos(7, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            [SpedCampos(8, "VL_DOC", "N", 0, 2, true)]
            public decimal? VlDoc { get; set; }
        }

        public class RegistroC396 : RegistroBaseSped
        {
            public RegistroC396()
            {
                Reg = "C396";
            }

            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public decimal? VlItem { get; set; }

            [SpedCampos(4, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            [SpedCampos(5, "NAT_BC_CRED", "C", 2, 0, true)]
            public string NatBcCred { get; set; }

            [SpedCampos(6, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(7, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            [SpedCampos(8, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal? AliqPis { get; set; }

            [SpedCampos(9, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            [SpedCampos(10, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(11, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal? VlBcCofins { get; set; }

            [SpedCampos(12, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal? AliqCofins { get; set; }

            [SpedCampos(13, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            [SpedCampos(14, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class RegistroC400 : RegistroBaseSped
        {
            public RegistroC400()
            {
                Reg = "C400";
            }

            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            [SpedCampos(3, "ECF_MOD", "C", 20, 0, true)]
            public string EcfMod { get; set; }

            [SpedCampos(4, "ECF_FAB", "C", 20, 0, true)]
            public string EcfFab { get; set; }

            [SpedCampos(5, "ECF_CX", "N", 3, 0, true)]
            public int EcfCx { get; set; }
        }

        public class RegistroC405 : RegistroBaseSped
        {
            public RegistroC405()
            {
                Reg = "C405";
            }

            [SpedCampos(2, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            [SpedCampos(3, "CRO", "N", 3, 0, true)]
            public int Cro { get; set; }

            [SpedCampos(4, "CRZ", "N", 6, 0, true)]
            public int Crz { get; set; }

            [SpedCampos(5, "NUM_COO_FIN", "N", 6, 0, true)]
            public int NumCooFin { get; set; }

            [SpedCampos(6, "GT_FIN", "N", 0, 2, true)]
            public decimal GtFin { get; set; }

            [SpedCampos(7, "VL_BRT", "N", 0, 2, true)]
            public decimal VlBrt { get; set; }
        }

        public class RegistroC481 : RegistroBaseSped
        {
            public RegistroC481()
            {
                Reg = "C481";
            }

            [SpedCampos(2, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            [SpedCampos(4, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            [SpedCampos(5, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal? AliqPis { get; set; }

            [SpedCampos(6, "QUANT_BC_PIS", "N", 0, 3, false)]
            public decimal? QuantBcPis { get; set; }

            [SpedCampos(7, "ALIQ_PIS_QUANT", "N", 0, 4, false)]
            public decimal? AliqPisQuant { get; set; }

            [SpedCampos(8, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            [SpedCampos(9, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            [SpedCampos(10, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class RegistroC485 : RegistroBaseSped
        {
            public RegistroC485()
            {
                Reg = "C485";
            }

            [SpedCampos(2, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            [SpedCampos(4, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal? VlBcCofins { get; set; }

            [SpedCampos(5, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal? AliqCofins { get; set; }

            [SpedCampos(6, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public decimal? QuantBcCofins { get; set; }

            [SpedCampos(7, "ALIQ_COFINS_QUANT", "N", 0, 4, false)]
            public decimal? AliqCofinsQuant { get; set; }

            [SpedCampos(8, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            [SpedCampos(9, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            [SpedCampos(10, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class RegistroC500 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC500" />.
            /// </summary>
            public RegistroC500()
            {
                Reg = "C500";
            }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150):
            ///     - do emitente do documento ou do remetente das mercadorias, no caso de entradas;
            ///     - do adquirente, no caso de saídas.
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(3, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(4, "COD_SIT", "N", 2, 0, true)]
            public IndCodSitDoc CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(5, "SER", "C", 3, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(6, "SUB", "N", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(7, "NUM_DOC", "N", 9, 0, true)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(8, "DT_DOC", "N", 8, 0, false)]
            public DateTime? DtDoc { get; set; }

            /// <summary>
            ///     Data da entrada 
            /// </summary>
            [SpedCampos(9, "DT_ENT", "N", 8, 0, false)]
            public DateTime? DtEnt { get; set; }

            /// <summary>
            ///     Valor total do documento fiscal
            /// </summary>
            [SpedCampos(10, "VL_DOC", "N", 0, 2, false)]
            public decimal? VlDoc { get; set; }


            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(11, "VL_ICMS", "N", 0, 2, false)]
            public decimal? VlIcms { get; set; }

            /// <summary>
            ///     Abatimento não tributado e não comercial.
            ///     Ex.: desconto ICMS nas remessas para ZFM.
            /// </summary>
            [SpedCampos(12, "COD_INF", "C", 6, 2, false)]
            public string CodInf { get; set; }

            /// <summary>
            ///     Valor total do PIS
            /// </summary>
            [SpedCampos(13, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Valor total da COFINS
            /// </summary>
            [SpedCampos(14, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }
        }
        
        public class RegistroC501 : RegistroBaseSped
        {
            public RegistroC501()
            {
                Reg = "C501";
            }

            [SpedCampos(2, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            [SpedCampos(4, "NAT_BC_CRED", "C", 2, 0, false)]
            public string NatBcCred { get; set; }

            [SpedCampos(5, "VL_BC_PIS", "N", 0, 2, true)]
            public decimal? VlBcPis { get; set; }

            [SpedCampos(6, "ALIQ_PIS", "N", 0, 4, true)]
            public decimal? AliqPis { get; set; }

            [SpedCampos(7, "VL_PIS", "N", 0, 2, true)]
            public decimal? VlPis { get; set; }

            [SpedCampos(8, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class RegistroC505 : RegistroBaseSped
        {
            public RegistroC505()
            {
                Reg = "C505";
            }

            [SpedCampos(2, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            [SpedCampos(4, "NAT_BC_CRED", "C", 2, 0, false)]
            public string NatBcCred { get; set; }

            [SpedCampos(5, "VL_BC_COFINS", "N", 0, 2, true)]
            public decimal? VlBcCofins { get; set; }

            [SpedCampos(6, "ALIQ_COFINS", "N", 0, 4, true)]
            public decimal? AliqCofins { get; set; }

            [SpedCampos(7, "VL_COFINS", "N", 0, 2, true)]
            public decimal? VlCofins { get; set; }

            [SpedCampos(8, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO C860: IDENTIFICAÇÃO DO EQUIPAMENTO SAT-CFE
        /// </summary>
        public class RegistroC860 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC860" />.
            /// </summary>
            public RegistroC860()
            {
                Reg = "C860";
            }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Número de série do equipamento SAT
            /// </summary>
            [SpedCampos(3, "NR_SAT", "C", 9, 0, true)]
            public string NrSAT { get; set; }

            /// <summary>
            ///     Data de emissão dos documentos fiscais
            /// </summary>
            [SpedCampos(4, "DT_DOC", "N", 8, 0, false)]
            public DateTime? DtDoc { get; set; }

            /// <summary>
            ///     Número do documento inicial
            /// </summary>
            [SpedCampos(4, "DOC_INI", "N", 9, 0, false)]
            public int? DocIni { get; set; }

            /// <summary>
            ///     Número do documento final
            /// </summary>
            [SpedCampos(4, "DOC_FIM", "N", 9, 0, false)]
            public int? DocFim { get; set; }
        }

        /// <summary>
        ///     REGISTRO C870: RESUMO DIÁRIO DE DOCUMENTOS EMITIDOS POR EQUIPAMENTO
        ///     SAT-CF-E (CÓDIGO 59) - PIS/PASEP E COFINS
        /// </summary>
        public class RegistroC870 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC870"/>.
            /// </summary>
            public RegistroC870()
            {
                Reg = "C870";
            }

            /// <summary>
            ///     Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Valor total dos itens
            /// </summary>
            [SpedCampos(4, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Valor da exclusão/desconto comercial dos itens
            /// </summary>
            [SpedCampos(5, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao PIS/PASEP
            /// </summary>
            [SpedCampos(6, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS/PASEP
            /// </summary>
            [SpedCampos(7, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(8, "ALIQ_PIS", "N", 0, 2, false)]
            public decimal? AliqPis { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(9, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente a Cofins
            /// </summary>
            [SpedCampos(10, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Valor da base de cálculo da COFINS
            /// </summary>
            [SpedCampos(11, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal? VlBcCofins { get; set; }

            /// <summary>
            ///     Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(12, "ALIQ_COFINS", "N", 0, 2, false)]
            public decimal? AliqCofins { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(13, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica debitada/creditada
            /// </summary>
            [SpedCampos(14, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO C880: RESUMO DIÁRIO DE DOCUMENTOS EMITIDOS POR EQUIPAMENTO
        ///     SAT-CF-E (CÓDIGO 59) - PIS/PASEP E COFINS APURADO POR UNIDADE DE MEDIDA DE
        ///     PRODUTO
        /// </summary>
        public class RegistroC880:RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC880"/>.
            /// </summary>
            public RegistroC880()
            {
                Reg = "C880";
            }

            /// <summary>
            ///     Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Valor total dos itens
            /// </summary>
            [SpedCampos(4, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Valor da exclusão/desconto comercial dos itens
            /// </summary>
            [SpedCampos(5, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao PIS/PASEP
            /// </summary>
            [SpedCampos(6, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Base de cálculo em quantidade - PIS/PASEP
            /// </summary>
            [SpedCampos(7, "QUANT_BC_PIS", "N", 0, 3, false)]
            public decimal? QuantBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em reais)
            /// </summary>
            [SpedCampos(8, "ALIQ_PIS_QUANT", "N", 0, 4, false)]
            public decimal? AliqPis { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(9, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente a Cofins
            /// </summary>
            [SpedCampos(10, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Base de cálculo em quantidade - COFINS
            /// </summary>
            [SpedCampos(11, "QUANT_BC_COFINS", "N", 0, 4, false)]
            public decimal? QuantBcCofins { get; set; }

            /// <summary>
            ///     Alíquota da COFINS (em reais)
            /// </summary>
            [SpedCampos(12, "ALIQ_COFINS_QUANT", "N", 0, 4, false)]
            public decimal? AliqCofins { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(13, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica debitada/creditada
            /// </summary>
            [SpedCampos(14, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }              
        
        public class RegistroC990 : RegistroBaseSped
        {
            public RegistroC990()
            {
                Reg = "C990";
            }

            [SpedCampos(2, "QTD_LIN_C", "N", int.MaxValue, 0, true)]
            public int QtdLinC { get; set; }
        }
    }
}
