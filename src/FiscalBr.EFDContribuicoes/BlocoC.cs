using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDContribuicoes
{
    public class BlocoC
    {
        public RegistroC001 RegC001 { get; set; }
        public RegistroC990 RegC990 { get; set; }

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

            public List<RegistroC010> RegC010s { get; set; }

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

            public List<RegistroC100> RegC100s { get; set; }
            public List<RegistroC180> RegC180s { get; set; }
            public List<RegistroC190> RegC190s { get; set; }
            public List<RegistroC380> RegC380s { get; set; }
            public List<RegistroC395> RegC395s { get; set; }
            public List<RegistroC400> RegC400s { get; set; }
            public List<RegistroC490> RegC490s { get; set; }
            public List<RegistroC500> RegC500s { get; set; }
            public List<RegistroC600> RegC600s { get; set; }
            public List<RegistroC800> RegC800s { get; set; }
            public List<RegistroC860> RegC860s { get; set; }
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

            public List<RegistroC110> RegC110s { get; set; }
            public List<RegistroC111> RegC111s { get; set; }
            public List<RegistroC120> RegC120s { get; set; }
            public List<RegistroC170> RegC170s { get; set; }
            public List<RegistroC175> RegC175s { get; set; }
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
        ///     Registro C111: Processo Referenciado
        /// </summary>
        public class RegistroC111 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC111" />.
            /// </summary>
            public RegistroC111()
            {
                Reg = "C111";
            }

            /// <summary>
            ///     Identificação do processo ou ato concessório
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 20, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///    Indicador da origem do processo:
            ///    1 -Justiça Federal;
            ///    3 –Secretaria da Receita Federal do Brasil;
            ///    9 –Outros
            /// </summary>
            [SpedCampos(3, "IND_PROC", "C", 1, 0, true)]
            public string IndProc { get; set; }

        }

        /// <summary>
        ///     Registro C120: Complemento do Documento -Operações de Importação (Código 01)
        /// </summary>
        public class RegistroC120 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC120" />.
            /// </summary>
            public RegistroC120()
            {
                Reg = "C120";
            }

            /// <summary>
            ///     Documento de importação:
            ///     0 –Declaração de Importação;
            ///     1 –Declaração Simplificada de Importação;
            ///     A partir dos fatos geradores ocorridos em 01/2019:Documento de importação:
            ///     0 –Declaração de Importação;
            ///     1 –Declaração Simplificada de Importação;
            ///     2 –Declaração Única de Importação
            /// </summary>
            [SpedCampos(2, "COD_DOC_IMP", "C", 1, 0, true)]
            public string CodDocImp { get; set; }

            /// <summary>
            ///    Número do documento de Importação.
            /// </summary>
            [SpedCampos(3, "NUM_DOC_IMP", "C", 15, 0, true)]
            public string NumDocImp { get; set; }

            /// <summary>
            ///     Valor pago de PIS na importação
            /// </summary>
            [SpedCampos(4, "VL_PIS_IMP", "N", 0, 2, false)]
            public string VlPisImp { get; set; }

            /// <summary>
            ///     Valor pago de COFINS na importação
            /// </summary>
            [SpedCampos(5, "VL_COFINS_IMP", "N", 0, 2, false)]
            public string VlCofinsImp { get; set; }

            /// <summary>
            ///    Número do Ato Concessório do regimeDrawback
            /// </summary>
            [SpedCampos(6, "NUM_ACDRAW", "C", 20, 0, false)]
            public string NumAcdraw { get; set; }

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

            public List<RegistroC181> RegC181s { get; set; }
            public List<RegistroC185> RegC185s { get; set; }
            public List<RegistroC188> RegC188s { get; set; }

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

        /// <summary>
        ///     Registro C188: Processo Referenciado
        /// </summary>
        public class RegistroC188 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC188" />.
            /// </summary>
            public RegistroC188()
            {
                Reg = "C188";
            }

            /// <summary>
            ///     Identificação do processo ou ato concessório
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 20, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///    Indicador da origem do processo:
            ///    1 -Justiça Federal;
            ///    3 –Secretaria da Receita Federal do Brasil;
            ///    9 –Outros
            /// </summary>
            [SpedCampos(3, "IND_PROC", "C", 1, 0, true)]
            public string IndProc { get; set; }

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

            public List<RegistroC191> RegC191s { get; set; }
            public List<RegistroC195> RegC195s { get; set; }
            public List<RegistroC198> RegC198s { get; set; }
            public List<RegistroC199> RegC199s { get; set; }
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

        /// <summary>
        ///     Registro C198: Processo Referenciado
        /// </summary>
        public class RegistroC198 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC198" />.
            /// </summary>
            public RegistroC198()
            {
                Reg = "C198";
            }

            /// <summary>
            ///     Identificação do processo ou ato concessório
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 20, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///    Indicador da origem do processo:
            ///    1 -Justiça Federal;
            ///    3 –Secretaria da Receita Federal do Brasil;
            ///    9 –Outros
            /// </summary>
            [SpedCampos(3, "IND_PROC", "C", 1, 0, true)]
            public string IndProc { get; set; }

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

            public List<RegistroC381> RegC381s { get; set; }
            public List<RegistroC385> RegC385s { get; set; }

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

            public List<RegistroC396> RegC396s { get; set; }
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

            public List<RegistroC405> RegC405s { get; set; }
            public List<RegistroC489> RegC489s { get; set; }
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

            public List<RegistroC481> RegC481s { get; set; }
            public List<RegistroC485> RegC485s { get; set; }
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

        /// <summary>
        ///     Registro C489: Processo Referenciado
        /// </summary>
        public class RegistroC489 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC489" />.
            /// </summary>
            public RegistroC489()
            {
                Reg = "C489";
            }

            /// <summary>
            ///     Identificação do processo ou ato concessório
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 20, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///    Indicador da origem do processo:
            ///    1 -Justiça Federal;
            ///    3 –Secretaria da Receita Federal do Brasil;
            ///    9 –Outros
            /// </summary>
            [SpedCampos(3, "IND_PROC", "C", 1, 0, true)]
            public string IndProc { get; set; }

        }

        /// <summary>
        ///     Registro C490: Consolidação de Documentos Emitidos por ECF (Códigos 02, 2D, 59 e 60)
        /// </summary>
        public class RegistroC490 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC490" />.
            /// </summary>
            public RegistroC490()
            {
                Reg = "C490";
            }

            /// <summary>
            ///     Data de Emissão Inicial dos Documentos
            /// </summary>
            [SpedCampos(2, "DT_DOC_INI", "N", 8, 0, true)]
            public DateTime DtDocIni { get; set; }

            /// <summary>
            ///    Data de Emissão Final dos Document
            /// </summary>
            [SpedCampos(3, "DT_DOC_FIN", "N", 8, 0, true)]
            public DateTime DtDocFin { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(4, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            public List<RegistroC491> RegC491s { get; set; }
            public List<RegistroC495> RegC495s { get; set; }
            public List<RegistroC499> RegC499s { get; set; }
        }

        /// <summary>
        ///   Registro C491: Detalhamento da Consolidação de Documentos Emitidos por ECF (Códigos 02, 2D, 59 e 60) –PIS/Pasep
        /// </summary>
        public class RegistroC491 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC491" />.
            /// </summary>
            public RegistroC491()
            {
                Reg = "C491";
            }

            /// <summary>
            ///    Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            /// <summary>
            ///    Código da Situação Tributária referente ao PIS/PASEP
            /// </summary>
            [SpedCampos(3, "CST_PIS", "N", 2, 0, true)]
            public string CstPis { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(4, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            /// <summary>
            ///     Valor total dos itens
            /// </summary>
            [SpedCampos(5, "VL_ITEM", "N", 0, 2, true)]
            public string VlItem { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS/PASEP
            /// </summary>
            [SpedCampos(6, "VL_BC_PIS", "N", 0, 2, false)]
            public string VlBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(7, "ALIQ_PIS", "N", 8, 4, false)]
            public string AliqPis { get; set; }

            /// <summary>
            ///    Quantidade –Base de cálculo PIS/PASEP
            /// </summary>
            [SpedCampos(8, "QUANT_BC_PIS", "N", 0, 3, false)]
            public string QuantBcPis{ get; set; }

            /// <summary>
            ///    Alíquota do PIS/PASEP (em reais)
            /// </summary>
            [SpedCampos(9, "ALIQ_PIS_QUANT", "N", 0, 4, false)]
            public string AliqPisQuant { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(10, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(11, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

        }

        /// <summary>
        ///     Registro C495:  Detalhamento da Consolidação de Documentos Emitidos por ECF (Códigos 02, 2D, 59 e 60) –Cofins
        /// </summary>
        public class RegistroC495 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC495" />.
            /// </summary>
            public RegistroC495()
            {
                Reg = "C495";
            }

            /// <summary>
            ///    Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            /// <summary>
            ///   Código da Situação Tributária referente a COFINS.
            /// </summary>
            [SpedCampos(3, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(4, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            /// <summary>
            ///     Valor total dos itens
            /// </summary>
            [SpedCampos(5, "VL_ITEM", "N", 0, 2, true)]
            public string VlItem { get; set; }

            /// <summary>
            ///     Valor da base de cálculo da COFINS
            /// </summary>
            [SpedCampos(6, "VL_BC_COFINS", "N", 0, 2, false)]
            public string VlBcCofins { get; set; }

            /// <summary>
            ///    Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(7, "ALIQ_COFINS", "N", 8, 4, false)]
            public string AliqCofins { get; set; }

            /// <summary>
            ///    Quantidade –Base de cálculo da COFINS
            /// </summary>
            [SpedCampos(8, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public string QuantBcCofins { get; set; }

            /// <summary>
            ///   Alíquota da COFINS (em reais)
            /// </summary>
            [SpedCampos(9, "ALIQ_COFINS_QUANT", "N", 0, 4, false)]
            public string AliqCofinsQuant { get; set; }

            /// <summary>
            ///    Valor da COFINS
            /// </summary>
            [SpedCampos(10, "VL_COFINS", "N", 0, 2, false)]
            public string VlCofins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(11, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

        }

        /// <summary>
        ///     Registro C499: Processo Referenciado
        /// </summary>
        public class RegistroC499 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC499" />.
            /// </summary>
            public RegistroC499()
            {
                Reg = "C499";
            }

            /// <summary>
            ///     Identificação do processo ou ato concessório
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 20, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///    Indicador da origem do processo:
            ///    1 -Justiça Federal;
            ///    3 –Secretaria da Receita Federal do Brasil;
            ///    9 –Outros
            /// </summary>
            [SpedCampos(3, "IND_PROC", "C", 1, 0, true)]
            public string IndProc { get; set; }

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

            public List<RegistroC501> RegC501s { get; set; }
            public List<RegistroC505> RegC505s { get; set; }
            public List<RegistroC509> RegC509s { get; set; }
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
        ///     Registro C509: Processo Referenciado
        /// </summary>
        public class RegistroC509 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC509" />.
            /// </summary>
            public RegistroC509()
            {
                Reg = "C509";
            }

            /// <summary>
            ///     Identificação do processo ou ato concessório
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 20, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///    Indicador da origem do processo:
            ///    1 -Justiça Federal;
            ///    3 –Secretaria da Receita Federal do Brasil;
            ///    9 –Outros
            /// </summary>
            [SpedCampos(3, "IND_PROC", "C", 1, 0, true)]
            public string IndProc { get; set; }

        }

        /// <summary>
        ///     Registro C600: Consolidação Diária de Notas Fiscais/Contas Emitidas de Energia Elétrica (Código 06), Nota Fiscal de Energia Elétrica Eletrônica 
        ///     –NF3e (Código 66), Nota Fiscal/Conta de Fornecimento D'água Canalizada (Código 29) e Nota Fiscal/Conta de Fornecimento de Gás (Código 28) 
        ///     (Empresas Obrigadas ou não Obrigadas ao Convenio ICMS  115/03) –Documentos de Saída
        /// </summary>
        public class RegistroC600 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC600" />.
            /// </summary>
            public RegistroC600()
            {
                Reg = "C600";
            }

            /// <summary>
            ///     Código  do  modelo  do  documento  fiscal,  conforme  a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public int CodMod { get; set; }

            /// <summary>
            ///    Código do município dos pontos de consumo, conforme a tabela IBGE
            /// </summary>
            [SpedCampos(3, "COD_MUN", "N", 7, 0, false)]
            public string CodMun { get; set; }

            /// <summary>
            ///    Série do documento fiscal
            /// </summary>
            [SpedCampos(4, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///    Subsérie do documento fisca
            /// </summary>
            [SpedCampos(5, "SUB", "N", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///   Código de classe de consumo de energia elétrica, conforme a Tabela 4.4.5, ou Código de Consumo de Fornecimento D ́água –Tabela 4.4.2 ou Código da classe de consumo de gás canalizado conforme Tabela 4.4.3.
            /// </summary>
            [SpedCampos(6, "COD_CONS", "N", 2, 0, false)]
            public string CodCons{ get; set; }

            /// <summary>
            ///     Quantidade de documentos consolidados neste registro
            /// </summary>
            [SpedCampos(7, "QTD_CONS", "N", 0, 0, true)]
            public decimal QtdCons { get; set; }

            /// <summary>
            ///    Quantidade de documentos cancelados
            /// </summary>
            [SpedCampos(8, "QTD_CANC", "N", 0, 0, false)]
            public decimal QtdCanc { get; set; }

            /// <summary>
            ///     Data dos documentos consolidados
            /// </remarks>
            [SpedCampos(9, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Valor total dos documentos
            /// </summary>
            [SpedCampos(10, "VL_DOC", "N", 0, 2, true)]
            public int VlDoc { get; set; }

            /// <summary>
            ///   Valor acumulado dos descontos
            /// </summary>
            [SpedCampos(11, "VL_DESC", "N", 0, 2, false)]
            public int VlDesc { get; set; }

            /// <summary>
            ///     Consumo total acumulado, em kWh (Código 06)
            /// </summary>
            [SpedCampos(12, "CONS", "N", 0, 0, false)]
            public int Cons { get; set; }

            /// <summary>
            ///     Valor acumulado do fornecimento
            /// </summary>
            [SpedCampos(13, "VL_FORN", "N", 0, 2, false)]
            public string VlForn { get; set; }

            /// <summary>
            ///   Valor acumulado dos serviços não-tributados pelo ICMS
            /// </summary>
            [SpedCampos(14, "VL_SERV_NT", "N", 0, 2, false)]
            public decimal VlSerNt { get; set; }

            /// <summary>
            ///     Valores cobrados em nome de terceiros
            /// </summary>
            [SpedCampos(15, "VL_TERC", "N", 0, 2, false)]
            public decimal VlTerc { get; set; }

            /// <summary>
            ///    Valor acumulado das despesas acessórias
            /// </summary>
            [SpedCampos(16, "VL_DA", "N", 0, 2, false)]
            public decimal VlDa { get; set; }

            /// <summary>
            ///   Valor acumulado da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(17, "VL_BC_ICMS", "N", 0, 2, false)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///    Valor acumulado do ICMS 
            /// </summary>
            [SpedCampos(18, "VL_ICMS", "N", 0, 2, false)]
            public string VlIcms { get; set; }

            /// <summary>
            ///    Valor acumulado da base de cálculo do ICMS substituição tributária
            /// </remarks>
            [SpedCampos(19, "VL_BC_ICMS_ST", "N", 0, 2, false)]
            public int VlBcIcmsSt { get; set; }

            /// <summary>
            ///     Valor  acumulado  do  ICMS  retido  por  substituição tributária
            /// </summary>
            [SpedCampos(20, "VL_ICMS_ST", "N", 0, 2, false)]
            public string CstIpi { get; set; }

            /// <summary>
            ///    Valor acumulado do PIS/PASEP
            /// </summary>
            [SpedCampos(21, "VL_PIS", "N", 0, 2, true)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///    Valor acumulado da COFINS
            /// </summary>
            [SpedCampos(22, "VL_COFINS", "N", 0, 2, true)]
            public decimal VlCofins { get; set; }

            public List<RegistroC601> RegC601s { get; set; }
            public List<RegistroC605> RegC605s { get; set; }
            public List<RegistroC609> RegC609s { get; set; }
        }


        /// <summary>
        ///     Registro C601: Complemento da Consolidação Diária (Códigos 06, 28 e 29) –Documentos de Saídas -PIS/Pasep
        /// </summary>
        public class RegistroC601 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC601" />.
            /// </summary>
            public RegistroC601()
            {
                Reg = "C601";
            }

            /// <summary>
            ///    Código da Situação Tributária referente ao PIS/PASEP
            /// </summary>
            [SpedCampos(2, "CST_PIS", "N", 2, 0, true)]
            public string CstPis { get; set; }

            /// <summary>
            ///     Valor total dos itens
            /// </summary>
            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public string VlItem { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS/PASEP
            /// </summary>
            [SpedCampos(4, "VL_BC_PIS", "N", 0, 2, true)]
            public string VlBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(5, "ALIQ_PIS", "N", 8, 4, true)]
            public string AliqPis { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(6, "VL_PIS", "N", 0, 2, true)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(7, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     Registro C605: Complemento da Consolidação Diária (Códigos 06, 28 e 29) –Documentos de Saídas –Cofins
        /// </summary>
        public class RegistroC605 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC605" />.
            /// </summary>
            public RegistroC605()
            {
                Reg = "C605";
            }

            /// <summary>
            ///   Código da Situação Tributária referente a COFINS.
            /// </summary>
            [SpedCampos(2, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

            /// <summary>
            ///     Valor total dos itens
            /// </summary>
            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public string VlItem { get; set; }

            /// <summary>
            ///     Valor da base de cálculo da COFINS
            /// </summary>
            [SpedCampos(4, "VL_BC_COFINS", "N", 0, 2, true)]
            public string VlBcCofins { get; set; }

            /// <summary>
            ///    Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(5, "ALIQ_COFINS", "N", 8, 4, true)]
            public string AliqCofins { get; set; }

            /// <summary>
            ///    Valor da COFINS
            /// </summary>
            [SpedCampos(6, "VL_COFINS", "N", 0, 2, true)]
            public string VlCofins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(7, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     Registro C609: 
        /// </summary>
        public class RegistroC609 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC609" />.
            /// </summary>
            public RegistroC609()
            {
                Reg = "C609";
            }

            /// <summary>
            ///    Identificação do processo ou ato concessório
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 20, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///    Indicador da origem do processo:
            ///    1 -Justiça Federal;
            ///    3 –Secretaria da Receita Federal do Brasil
            ///    9 –Outros.
            /// </summary>
            [SpedCampos(3, "IND_PROC", "C", 1, 0, true)]
            public string IndProc { get; set; }

        }

        /// <summary>
        ///     Registro C800: Cupom Fiscal Eletrônico (Código 59)
        /// </summary>
        public class RegistroC800 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC800" />.
            /// </summary>
            public RegistroC800()
            {
                Reg = "C800";
            }

            /// <summary>
            ///     Código  do  modelo  do  documento  fiscal,  conforme  a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public int CodMod { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(3, "COD_SIT", "N", 2, 0, true)]
            public string CodSit { get; set; }

            /// <summary>
            ///     Número do Cupom Fiscal Eletrônico
            /// </summary>
            [SpedCampos(4, "NUM_CFE", "N", 9, 0, true)]
            public string NumCfe { get; set; }

            /// <summary>
            ///     Data da emissão do Cupom Fiscal Eletrônico
            /// </remarks>
            [SpedCampos(5, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Valor total do Cupom Fiscal Eletrônico
            /// </summary>
            [SpedCampos(6, "VL_CFE", "N", 0, 2, true)]
            public int VlCfe { get; set; }

            /// <summary>
            ///   Valor total do PIS
            /// </summary>
            [SpedCampos(7, "VL_PIS", "N", 0, 2, false)]
            public int VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(8, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     CNPJ ou CPF do destinatário
            /// </summary>
            [SpedCampos(9, "CNPJ_CPF", "N", 14, 0, false)]
            public int CnpjCpf { get; set; }

            /// <summary>
            ///   Número de Série do equipamento SAT
            /// </summary>
            [SpedCampos(10, "NR_SAT", "N", 9, 0, false)]
            public decimal? NtSat { get; set; }

            /// <summary>
            ///     Chave do Cupom Fiscal Eletrônico
            /// </summary>
            [SpedCampos(11, "CHV_CFE", "N", 44, 0, false)]
            public decimal? ChvCfe { get; set; }

            /// <summary>
            ///    Valor total do desconto/exclusão sobre item
            /// </summary>
            [SpedCampos(12, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            /// <summary>
            ///     Valor total das mercadorias e serviços
            /// </summary>
            [SpedCampos(13, "VL_MERC", "C", 60, 0, false)]
            public string VlMerc { get; set; }

            /// <summary>
            ///     Valor de outras desp. Acessórias (acréscimo)
            /// </summary>
            [SpedCampos(14, "VL_OUT_DA", "N", 0, 2, false)]
            public string VlOutDa { get; set; }

            /// <summary>
            ///     Valor do ICMS
            /// </summary>
            [SpedCampos(15, "VL_ICMS", "N", 0, 2, false)]
            public int VlIcms { get; set; }

            /// <summary>
            ///     Valor total do PIS retido por subst. trib.
            /// </summary>
            [SpedCampos(16, "VL_PIS_ST", "N", 0, 2, false)]
            public decimal VlPisSt { get; set; }

            /// <summary>
            ///    Valor total da COFINS retido por subst. trib.
            /// </summary>
            [SpedCampos(17, "VL_COFINS_ST", "N", 0, 2, false)]
            public decimal? VlCofinsSt { get; set; }

            public List<RegistroC810> RegC810s { get; set; }
            public List<RegistroC820> RegC820s { get; set; }
            public List<RegistroC830> RegC830s { get; set; }

        }

        /// <summary>
        ///     Registro C810: 
        /// </summary>
        public class RegistroC810 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC810" />.
            /// </summary>
            public RegistroC810()
            {
                Reg = "C810";
            }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(2, "CFOP", "N", 4, 0, true)]
            public string Cfop { get; set; }

            /// <summary>
            ///     Valor total dos itens
            /// </summary>
            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public string VlItem { get; set; }

            /// <summary>
            ///     Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(4, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao PIS/PASEP
            /// </summary>
            [SpedCampos(5, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS/PASEP
            /// </summary>
            [SpedCampos(6, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(7, "ALIQ_PIS", "N", 0, 2, false)]
            public decimal? AliqPis { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(8, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente a Cofins
            /// </summary>
            [SpedCampos(9, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Valor da base de cálculo da COFINS
            /// </summary>
            [SpedCampos(10, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal? VlBcCofins { get; set; }

            /// <summary>
            ///     Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(11, "ALIQ_COFINS", "N", 0, 2, false)]
            public decimal? AliqCofins { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(12, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica debitada/creditada
            /// </summary>
            [SpedCampos(13, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

        }

        /// <summary>
        ///     Registro C820: Detalhamento do Cupom Fiscal Eletrônico (Código 59) –PIS/Pasep e Cofins Apurado por Unidade de Medida de Produto
        /// </summary>
        public class RegistroC820 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC820" />.
            /// </summary>
            public RegistroC820()
            {
                Reg = "C820";
            }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(2, "CFOP", "N", 4, 0, true)]
            public string Cfop { get; set; }

            /// <summary>
            ///     Valor total dos itens
            /// </summary>
            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public string VlItem { get; set; }

            /// <summary>
            ///     Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(4, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao PIS/PASEP
            /// </summary>
            [SpedCampos(5, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Base de cálculo em quantidade - PIS/PASEP
            /// </summary>
            [SpedCampos(6, "QUANT_BC_PIS", "N", 0, 3, false)]
            public decimal? QuantBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em reais)
            /// </summary>
            [SpedCampos(7, "ALIQ_PIS_QUANT", "N", 0, 4, false)]
            public decimal? AliqPis { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(8, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente a Cofins
            /// </summary>
            [SpedCampos(9, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            /// <summary>
            ///    Quantidade –Base de cálculo da COFINS
            /// </summary>
            [SpedCampos(10, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public string QuantBcCofins { get; set; }

            /// <summary>
            ///   Alíquota da COFINS (em reais)
            /// </summary>
            [SpedCampos(11, "ALIQ_COFINS_QUANT", "N", 0, 4, false)]
            public string AliqCofinsQuant { get; set; }

            /// <summary>
            ///    Valor da COFINS
            /// </summary>
            [SpedCampos(12, "VL_COFINS", "N", 0, 2, false)]
            public string VlCofins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(13, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     Registro C830: 
        /// </summary>
        public class RegistroC830 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC830" />.
            /// </summary>
            public RegistroC830()
            {
                Reg = "C830";
            }

            /// <summary>
            ///    Identificação do processo ou ato concessório
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 20, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///    Indicador da origem do processo:
            ///    1 -Justiça Federal;
            ///    3 –Secretaria da Receita Federal do Brasil
            ///    9 -Outros.
            /// </summary>
            [SpedCampos(3, "IND_PROC", "C", 1, 0, true)]
            public string IndProc { get; set; }

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

            public List<RegistroC870> RegC870s { get; set; }
            public List<RegistroC880> RegC880s { get; set; }
            public List<RegistroC890> RegC890s { get; set; }
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

        /// <summary>
        ///     Registro C890: Processo Referenciado
        /// </summary>
        public class RegistroC890 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC890" />.
            /// </summary>
            public RegistroC890()
            {
                Reg = "C890";
            }

            /// <summary>
            ///    Identificação do processo ou ato concessório
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 20, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///    Indicador da origem do processo:
            ///    1 -Justiça Federal;
            ///    3 –Secretaria da Receita Federal do Brasil
            ///    9 -Outros.
            /// </summary>
            [SpedCampos(3, "IND_PROC", "C", 1, 0, true)]
            public string IndProc { get; set; }

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
