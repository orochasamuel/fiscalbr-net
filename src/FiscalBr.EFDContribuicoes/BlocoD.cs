using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDContribuicoes
{
    /// <summary>
    ///     BLOCO D: DOCUMENTOS FISCAIS ii - SERVIÇOS (ICMS)
    /// </summary>
    public class BlocoD
    {
        public RegistroD001 RegD001 { get; set; }
        public RegistroD990 RegD990 { get; set; }

        /// <summary>
        ///     REGISTRO D001: ABERTURA DO BLOCO D
        /// </summary>
        public class RegistroD001 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroD001"/>.
            /// </summary>
            public RegistroD001()
            {
                Reg = "D001";
            }

            /// <summary>
            ///     Indicador de movimento: 0 - Bloco com dados informados; 1 - Bloco sem dados informados.
            /// </summary>
            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroD010> RegD010s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D010: IDENTIFICAÇÃO DO ESTABELECIMENTO
        /// </summary>
        public class RegistroD010 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD010"/>
            /// </summary>
            public RegistroD010()
            {
                Reg = "D010";
            }

            /// <summary>
            ///     Número de inscrição do estabelecimento no CNPJ
            /// </summary>
            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            public List<RegistroD100> RegD100s { get; set; }
            public List<RegistroD200> RegD200s { get; set; }
            public List<RegistroD300> RegD300s { get; set; }
            public List<RegistroD350> RegD350s { get; set; }
            public List<RegistroD500> RegD500s { get; set; }
            public List<RegistroD600> RegD600s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D100: AQUISIÇÃO DE SERVIÇOS DE TRANSPORTE - NOTA FISCAL DE SERVIÇO DE
        ///     TRANSPORTE (CÓDIGO 07) E CONHECIMENTOS DE TRANSPORTE RODOVIÁRIO DE CARGAS
        ///     (CODIGO 08), CONHECIMENTO DE TRASPORTE DE CARGAS AVULSO (CODIGO 8B),
        ///     AQUAVIÁRIO DE CARGAS (CODIGO 09), AÉREO (CÓDIGO 10), FERROVÁRIO DE CARGAS
        ///     (CÓDIGO 11), MULTIMODAL DE CARGAS (CODIGO 26), NOTA FISCAL DE TRANSPORTE
        ///     FERROVIÁRIO DE CARGA (CÓDIGO 27) E CONHECIMENTO DE TRANSPORTE ELETRÔNICO - 
        ///     CT-e (CÓDIGO 57)
        /// </summary>
        public class RegistroD100 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD100"/>
            /// </summary>
            public RegistroD100()
            {
                Reg = "D100";
            }

            /// <summary>
            ///     Indicador do tipo de operação:
            ///     0- Aquisição
            /// </summary>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true)]
            public int IndOper
            {
                get
                {
                    return 0;
                }
            }

            /// <summary>
            ///     Indicador do emitente do documento fiscal:
            ///     0- Emissão própria
            ///     1- Emissão por terceiros
            /// </summary>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true)]
            public int IndEmit { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do registro 0150).
            /// </summary>
            [SpedCampos(4, "COD_PART", "C", 60, 0, true)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(5, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(6, "COD_SIT", "C", 2, 0, true)]
            public int CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(7, "SER", "C", 5, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal            
            /// </summary>
            [SpedCampos(8, "SUB", "C", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(9, "NUM_DOC", "N", 9, 0, true)]
            public long NumDoc { get; set; }

            /// <summary>
            ///     Chave do conhecimento de Transporte Eletrônico
            /// </summary>
            [SpedCampos(10, "CHV_CTE", "N", 44, 0, false)]
            public string ChvCTe { get; set; }

            /// <summary>
            ///     Data de referência/emissão dos documentos fiscais
            /// </summary>
            [SpedCampos(11, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Data da aquisição ou da prestação do serviço
            /// </summary>
            [SpedCampos(12, "DT_A_P", "N", 8, 0, false)]
            public DateTime? DtAP { get; set; }

            /// <summary>
            ///     Tipo de conehcimento de Transporte Eletrônico conforme
            ///     definido no Manual de Integração do CT-e
            /// </summary>
            [SpedCampos(13, "TP_CT-e", "N", 1, 0, false)]
            public int? TpCTe { get; set; }

            /// <summary>
            ///     Chave do CT-e de referência cujos valores foram
            ///     completamentados (opção "1" do campo anterior) ou cujo
            ///     débito foi anulado (opção "2" do campo anterior).
            /// </summary>
            [SpedCampos(14, "CHV_CTE_REF", "N", 44, 0, false)]
            public string ChvCTeRef { get; set; }

            /// <summary>
            ///     Valor do documento fiscal
            /// </summary>
            [SpedCampos(15, "VL_DOC", "N", 0, 2, true)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Valor do desconto
            /// </summary>
            [SpedCampos(16, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            /// <summary>
            ///     Indicador do tipo do frete:
            ///     0- Por conta de terceiros
            ///     1- Por conta do emitente
            ///     2- Por conta do destinatário
            ///     9- Sem cobrança de frete
            ///     
            ///     Obs.: A partir de 01/07/2012 passartá a ser
            ///     Indicador do tipo do frete:
            ///     0- Por conta do emitente
            ///     1- Por conta do destinatario/remetente
            ///     2- Por conta de terceiros
            ///     9- Sem cobrança de frete
            /// </summary>
            [SpedCampos(17, "IND_FRT", "C", 1, 0, true)]
            public int IndFrt { get; set; }

            /// <summary>
            ///     Valor total da prestação de serviço
            /// </summary>
            [SpedCampos(18, "VL_SERV", "N", 0, 2, true)]
            public decimal VlServ { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(19, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal? VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS
            /// </summary>
            [SpedCampos(20, "VL_ICMS", "N", 0, 2, false)]
            public decimal? VlIcms { get; set; }

            /// <summary>
            ///     Valor não-tributado do ICMS
            /// </summary>
            [SpedCampos(21, "VL_NT", "N", 0, 2, false)]
            public decimal? VlNT { get; set; }

            /// <summary>
            ///     Codigo da informação complementar do documento fiscal (campo 02 do Registro 0450)
            /// </summary>
            [SpedCampos(22, "COD_INF", "C", 6, 0, false)]
            public string CodInf { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(23, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            public List<RegistroD101> RegD101s { get; set; }
            public List<RegistroD105> RegD105s { get; set; }
            public List<RegistroD111> RegD111s { get; set; }
        }

        /// <summary>
        ///     REGISTRO D101: COMPLEMENTO DO DOCUMENTO DE TRANSPORTE (Códigos 07, 08, 
        ///     8B, 09, 10, 11, 26, 27 e 57) - PIS/PASEP
        /// </summary>
        public class RegistroD101 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD101"/>
            /// </summary>
            public RegistroD101()
            {
                Reg = "D101";
            }

            /// <summary>
            ///     Indicador da Natureza do Frete Contratado, referente a:
            ///     0- Operações de vendas, com ônus suportado pelo estabelecimento vendedor;
            ///     1- Operações de vendas, com ônus suportado pelo adquirente;
            ///     2- Operações de compras (bens para revenda, matérias-prima e outros produtos, geradores de crédito);
            ///     3- Operações de compras (bens para revenda, matérias-prima e outros produtos, não geradores de crédito);
            ///     4- Transferência de produtos acabados entre estabelecimentos da pessoa jurídica;
            ///     5- Transferência de produtos em elaboração entre estabelecimentos da pessoa jurídica;
            ///     9- Outras.
            /// </summary>
            [SpedCampos(2, "IND_NAT_FRT", "C", 1, 0, true)]
            public int IndNatFrt { get; set; }

            /// <summary>
            ///     Valor total dos itens
            /// </summary>
            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao PIS/PASEP
            /// </summary>
            [SpedCampos(4, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Código da Base de Cálculo do Crédito, conforme a Tabela indicada no item 4.3.7
            /// </summary>
            [SpedCampos(5, "NAT_BC_CRED", "C", 2, 0, false)]
            public string NatBcCred { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS/PASEP
            /// </summary>
            [SpedCampos(6, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(7, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal? AliqPis { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(8, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(9, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO D105: COMPLEMENTO DO DOCUMENTO DE TRANSPORTE (Códigos 07, 08, 
        ///     8B, 09, 10, 11, 26, 27 e 57) - COFINS
        /// </summary>
        public class RegistroD105 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD105"/>
            /// </summary>
            public RegistroD105()
            {
                Reg = "D105";
            }

            /// <summary>
            ///     Indicador da Natureza do Frete Contratado, referente a:
            ///     0- Operações de vendas, com ônus suportado pelo estabelecimento vendedor;
            ///     1- Operações de vendas, com ônus suportado pelo adquirente;
            ///     2- Operações de compras (bens para revenda, matérias-prima e outros produtos, geradores de crédito);
            ///     3- Operações de compras (bens para revenda, matérias-prima e outros produtos, não geradores de crédito);
            ///     4- Transferência de produtos acabados entre estabelecimentos da pessoa jurídica;
            ///     5- Transferência de produtos em elaboração entre estabelecimentos da pessoa jurídica;
            ///     9- Outras.
            /// </summary>
            [SpedCampos(2, "IND_NAT_FRT", "C", 1, 0, true)]
            public int IndNatFrt { get; set; }

            /// <summary>
            ///     Valor total dos itens
            /// </summary>
            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao COFINS
            /// </summary>
            [SpedCampos(4, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Código da Base de Cálculo do Crédito, conforme a Tabela indicada no item 4.3.7
            /// </summary>
            [SpedCampos(5, "NAT_BC_CRED", "C", 2, 0, false)]
            public string NatBcCred { get; set; }

            /// <summary>
            ///     Valor da base de cálculo da COFINS
            /// </summary>
            [SpedCampos(6, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal? VlBcCofins { get; set; }

            /// <summary>
            ///     Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(7, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal? AliqCofins { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(8, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(9, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO D111: Processo Referenciado
        /// </summary>
        public class RegistroD111 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD111"/>
            /// </summary>
            public RegistroD111()
            {
                Reg = "D111";
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
        ///     REGISTRO D200: Resumo da Escrituração Diária –Prestação de Serviços de Transporte:
        ///     Nota Fiscal de Serviço de Transporte (Código 07), Conhecimento de Transporte Rodoviário de Cargas (Código 08), 
        ///     Conhecimento de Transporte de Cargas Avulso (Código 8B), Conhecimento de Transporte Aquaviário de Cargas (Código 09),
        ///     Conhecimento de Transporte Aéreo (Código 10), Conhecimento de Transporte Ferroviário de Cargas  (Código  11),  
        ///     Conhecimento  de Transporte Multimodal de Cargas (Código 26), Nota Fiscal de Transporte Ferroviário de Carga (Código 27),
        ///     Conhecimento de Transporte Eletrônico –CT-E (Código 57),
        ///     Bilhete de Passagem Eletrônico -BP-e (Código 63) e Conhecimento de Transporte Eletrônico para Outros Serviços –CT-e OS, modelo 67. 
        /// </summary>
        public class RegistroD200 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD200"/>
            /// </summary>
            public RegistroD200()
            {
                Reg = "D200";
            }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(3, "COD_SIT", "N", 2, 0, true)]
            public IndCodSitDoc CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(4, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(5, "SUB", "N", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número  do  documento  fiscal  inicial  emitido  no período (mesmo modelo, série e subsérie).
            /// </summary>
            [SpedCampos(6, "NUM_DOC_INI", "N", 9, 0, true)]
            public string NumDocIni { get; set; }

            /// <summary>
            ///    Número  do documento  fiscal  final  emitido  no período (mesmo modelo, série e subsérie).
            /// </summary>
            [SpedCampos(7, "NUM_DOC_FIN", "N", 9, 0, true)]
            public string NumDocFin { get; set; }

            /// <summary>
            ///     Código  Fiscal  de  Operação  e  Prestação  conforme tabela indicada no item 4.2.2
            /// </summary>
            [SpedCampos(8, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///   Data do dia de referência do resumo diário  
            /// </summary>
            [SpedCampos(9, "DT_REF", "N", 8, 0, true)]
            public DateTime DtRef { get; set; }

            /// <summary>
            ///    Valor total dos documentos fiscais
            /// </summary>
            [SpedCampos(10, "VL_DOC", "N", 0, 2, true)]
            public string VlDoc { get; set; }

            /// <summary>
            ///     Valor total dos descontos
            /// </summary>
            [SpedCampos(11, "VL_DESC", "N", 0, 2, false)]
            public string VlDesc { get; set; }

            public List<RegistroD201> RegD201s { get; set; }
            public List<RegistroD205> RegD205s { get; set; }
            public List<RegistroD209> RegD209s { get; set; }

        }

        /// <summary>
        ///     REGISTRO D201: Totalização do Resumo Diário –PIS/Pasep
        /// </summary>
        public class RegistroD201 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD201"/>
            /// </summary>
            public RegistroD201()
            {
                Reg = "D201";
            }

            /// <summary>
            ///    Código  da  Situação  Tributária  referente  ao PIS/PASEP
            /// </summary>
            [SpedCampos(2, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor total dos itens
            /// </summary>
            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public string VlItem { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS/PASEP (em valor)
            /// </summary>
            [SpedCampos(4, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            /// <summary>
            ///     Aliquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(5, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal? AliqPis { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(6, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(7, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO D205: Totalização do Resumo Diário –Cofins
        /// </summary>
        public class RegistroD205 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD205"/>
            /// </summary>
            public RegistroD205()
            {
                Reg = "D205";
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
            [SpedCampos(4, "VL_BC_COFINS", "N", 0, 2, false)]
            public string VlBcCofins { get; set; }

            /// <summary>
            ///    Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(5, "ALIQ_COFINS", "N", 8, 4, false)]
            public string AliqCofins { get; set; }

            /// <summary>
            ///    Valor da COFINS
            /// </summary>
            [SpedCampos(6, "VL_COFINS", "N", 0, 2, false)]
            public string VlCofins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(7, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO D209: Processo Referenciado
        /// </summary>
        public class RegistroD209 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD209"/>
            /// </summary>
            public RegistroD209()
            {
                Reg = "D209";
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
        ///     REGISTRO D300: 
        /// </summary>
        public class RegistroD300 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD300"/>
            /// </summary>
            public RegistroD300()
            {
                Reg = "D300";
            }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(3, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(4, "SUB", "N", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número  do  documento  fiscal  inicial  emitido  no período (mesmo modelo, série e subsérie).
            /// </summary>
            [SpedCampos(5, "NUM_DOC_INI", "N", 6, 0, false)]
            public string NumDocIni { get; set; }

            /// <summary>
            ///    Número  do documento  fiscal  final  emitido  no período (mesmo modelo, série e subsérie).
            /// </summary>
            [SpedCampos(6, "NUM_DOC_FIN", "N", 6, 0, false)]
            public string NumDocFin { get; set; }

            /// <summary>
            ///     Código  Fiscal  de  Operação  e  Prestação  conforme tabela indicada no item 4.2.2
            /// </summary>
            [SpedCampos(7, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///   Data do dia de referência do resumo diário  
            /// </summary>
            [SpedCampos(8, "DT_REF", "N", 8, 0, true)]
            public DateTime DtRef { get; set; }

            /// <summary>
            ///    Valor total dos documentos fiscais
            /// </summary>
            [SpedCampos(9, "VL_DOC", "N", 0, 2, true)]
            public string VlDoc { get; set; }

            /// <summary>
            ///     Valor total dos descontos
            /// </summary>
            [SpedCampos(10, "VL_DESC", "N", 0, 2, false)]
            public string VlDesc { get; set; }

            /// <summary>
            ///    Código  da  Situação  Tributária  referente  ao PIS/PASEP
            /// </summary>
            [SpedCampos(11, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS/PASEP (em valor)
            /// </summary>
            [SpedCampos(12, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            /// <summary>
            ///     Aliquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(13, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal? AliqPis { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(14, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///   Código da Situação Tributária referente a COFINS.
            /// </summary>
            [SpedCampos(15, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

            /// <summary>
            ///     Valor da base de cálculo da COFINS
            /// </summary>
            [SpedCampos(16, "VL_BC_COFINS", "N", 0, 2, false)]
            public string VlBcCofins { get; set; }

            /// <summary>
            ///    Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(17, "ALIQ_COFINS", "N", 8, 4, false)]
            public string AliqCofins { get; set; }

            /// <summary>
            ///    Valor da COFINS
            /// </summary>
            [SpedCampos(18, "VL_COFINS", "N", 0, 2, false)]
            public string VlCofins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(7, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

            public List<RegistroD309> RegD309s { get; set; }

        }

        /// <summary>
        ///     REGISTRO D309: Processo Referenciado
        /// </summary>
        public class RegistroD309 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD309"/>
            /// </summary>
            public RegistroD309()
            {
                Reg = "D309";
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
        ///     REGISTRO D350: Resumo Diário de Cupom Fiscal Emitido Por ECF -(Código: 2E, 13, 14, 15 e 16)
        /// </summary>
        public class RegistroD350 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD350"/>
            /// </summary>
            public RegistroD350()
            {
                Reg = "D350";
            }

            /// <summary>
            ///     Código  do  modelo  do  documento  fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Modelo do equipamento
            /// </summary>
            [SpedCampos(3, "ECF_MOD", "C", 20, 0, true)]
            public string EcfMod { get; set; }

            /// <summary>
            ///     Número de série de fabricação do ECF
            /// </summary>
            [SpedCampos(4, "ECF_FAB", "C", 21, 0, true)]
            public string EcfFab { get; set; }

            /// <summary>
            ///     Data do movimento a que se refere a Redução Z
            /// </summary>
            [SpedCampos(5, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///   Posição do Contador de Reinício de Operação
            /// </summary>
            [SpedCampos(6, "CRO", "N", 3, 0, true)]
            public string Cro { get; set; }

            /// <summary>
            ///     Posição do Contador de Redução Z
            /// </summary>
            [SpedCampos(7, "CRZ", "N", 6, 0, true)]
            public int Crz { get; set; }

            /// <summary>
            ///  Número do Contador de Ordem de Operação do último documento emitido no dia. (Número do COO na Redução Z) 
            /// </summary>
            [SpedCampos(8, "NUM_COO_FIN", "N", 6, 0, true)]
            public string NumCooFin { get; set; }

            /// <summary>
            ///   Valor do Grande Total final
            /// </summary>
            [SpedCampos(9, "GT_FIN", "N", 0, 2, true)]
            public string GtFin { get; set; }

            /// <summary>
            ///    Valor da venda bruta
            /// </summary>
            [SpedCampos(10, "VL_BRT", "N", 0, 2, true)]
            public string VlDesc { get; set; }

            /// <summary>
            ///    Código da Situação Tributária referente ao PIS/PASEP
            /// </summary>
            [SpedCampos(11, "CST_PIS", "N", 2, 0, true)]
            public string CstPis { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS/PASEP
            /// </summary>
            [SpedCampos(12, "VL_BC_PIS", "N", 0, 2, false)]
            public string VlBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(13, "ALIQ_PIS", "N", 8, 4, false)]
            public string AliqPis { get; set; }

            /// <summary>
            ///    Quantidade –Base de cálculo PIS/PASEP
            /// </summary>
            [SpedCampos(14, "QUANT_BC_PIS", "N", 0, 3, false)]
            public string QuantBcPis { get; set; }

            /// <summary>
            ///    Alíquota do PIS/PASEP (em reais)
            /// </summary>
            [SpedCampos(15, "ALIQ_PIS_QUANT", "N", 0, 4, false)]
            public string AliqPisQuant { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(16, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///   Código da Situação Tributária referente a COFINS.
            /// </summary>
            [SpedCampos(17, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

            /// <summary>
            ///     Valor da base de cálculo da COFINS
            /// </summary>
            [SpedCampos(18, "VL_BC_COFINS", "N", 0, 2, false)]
            public string VlBcCofins { get; set; }

            /// <summary>
            ///    Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(19, "ALIQ_COFINS", "N", 8, 4, false)]
            public string AliqCofins { get; set; }

            /// <summary>
            ///    Quantidade –Base de cálculo da COFINS
            /// </summary>
            [SpedCampos(20, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public string QuantBcCofins { get; set; }

            /// <summary>
            ///   Alíquota da COFINS (em reais)
            /// </summary>
            [SpedCampos(21, "ALIQ_COFINS_QUANT", "N", 0, 4, false)]
            public string AliqCofinsQuant { get; set; }

            /// <summary>
            ///    Valor da COFINS
            /// </summary>
            [SpedCampos(22, "VL_COFINS", "N", 0, 2, false)]
            public string VlCofins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(23, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

            public List<RegistroD359> RegD359s { get; set; }

        }

        /// <summary>
        ///     REGISTRO D359: Processo Referenciado
        /// </summary>
        public class RegistroD359 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD359"/>
            /// </summary>
            public RegistroD359()
            {
                Reg = "D359";
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
        ///     REGISTRO D500: NOTA FISCAL DE SERVIÇO DE COMUNICAÇÃO (CÓDIGO 21) E NOTA FISCAL DE SERVIÇO DE TELECOMUNICAÇÃO (CÓDIGO 22) - DOCUMENTOS DE AQUISIÇÃO COM DIREITO A CRÉDITO
        /// </summary>
        public class RegistroD500 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="RegistroD500"/>.
            /// </summary>
            public RegistroD500()
            {
                Reg = "D500";
            }

            /// <summary>
            ///     Indicador do tipo de operação:
            ///     0 - Aquisição;
            /// </summary>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true)]
            public string IndOper { get; set; }

            /// <summary>
            ///     Indicador do emitente do documento fiscal:
            ///     0 - Emissao própria;
            ///     1 - Terceiros;
            /// </summary>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true)]
            public string IndEmit { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150);
            ///     -do prestador do serviço, no caso de aquisição;
            ///     -do tomador do serviço, no caso de prestação;
            /// </summary>
            [SpedCampos(4, "COD_PART", "C", 60, 0, true)]
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
            public decimal CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(7, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(8, "SUB", "C", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(9, "NUM_DOC", "N", 9, 0, true)]
            public decimal NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(10, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Data da entrada(aquisição)
            /// </summary>
            [SpedCampos(11, "DT_A_P", "N", 8, 0, true)]
            public DateTime DtAP { get; set; }

            /// <summary>
            ///     Valor total do documento fiscal
            /// </summary>
            [SpedCampos(12, "VL_DOC", "N", 0, 2, true)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(13, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Valor da prestação de serviços
            /// </summary>
            [SpedCampos(14, "VL_SERV", "N", 0, 2, true)]
            public decimal VlServ { get; set; }

            /// <summary>
            ///     Valor total dos serviços não-tributados pelo ICMS
            /// </summary>
            [SpedCampos(15, "VL_SERV_NT", "N", 0, 2, false)]
            public decimal VlServNt { get; set; }

            /// <summary>
            ///     Valores cobrados em nome de terceiros
            /// </summary>
            [SpedCampos(16, "VL_TERC", "N", 0, 2, false)]
            public decimal VlTerc { get; set; }

            /// <summary>
            ///     Valor de outras despesas indicadas no documento fiscal
            /// </summary>
            [SpedCampos(17, "VL_DA", "N", 0, 2, false)]
            public decimal VlDa { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(18, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS
            /// </summary>
            [SpedCampos(19, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Código da informação complementar (campo 02 do Registro 0450)
            /// </summary>
            [SpedCampos(20, "COD_INF", "C", 6, 0, false)]
            public string CodInf { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(21, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(22, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            public List<RegistroD501> RegD501s { get; set; }
            public List<RegistroD505> RegD505s { get; set; }
            public List<RegistroD509> RegD509s { get; set; }
        }

        /// <summary>
        /// REGISTRO D501: COMPLEMENTO DA OPERAÇÃO (CÓDIGO 21 e 22) - PIS/Pasep
        /// </summary>
        public class RegistroD501 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD501"/>
            /// </summary>
            public RegistroD501()
            {
                Reg = "D501";
            }

            /// <summary>
            /// Código da situação tributária referente ao PIS/PASEP
            /// </summary>
            [SpedCampos(2, "CST_PIS", "C", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            /// Valor total dos itens (serviços)
            /// </summary>
            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            /// Código da base de cálculo do crédito:
            /// 
            /// 01 - Aquisição de bens para revenda
            /// 02 - Aquisição de bens utilizados como insumos
            /// 03 - Aquisição de serviços utilizados como insumos
            /// 04 - Energia elétrica e térmica, inclusive sob a forma de vapor
            /// 05 - Aluguéis de prédios
            /// 06 - Aluguéis de máquinas e equipamentos 
            /// 07 - Armazenagem de mercadoria e frete na operação de venda
            /// 08 - Contraprestação de arredamento mercantil
            /// 09 - Máquinas, equipamentos e outros bens incorporados ao ativo imobilizado (crédito sobre encargo de depreciação)
            /// 10 - Máquinas, equipamentos e outros bens incorporados ao ativo imobilizado (crédito com base no valor de aquisição)
            /// 11 - Amortização e depreciação de edificações e benefícios em imóveis
            /// 12 - Devolução de vendas sujeitas à incidência não-cumulativa
            /// 13 - Outras operações com direito a crédito (inclusive os créditos presumidos sobre receitas)
            /// 14 - Atividade de transporte de cargas - subcontratação
            /// 15 - Atividade imobiliária - Custo incorrido de unidade imobiliária
            /// 16 - Atividade imobiliária - Custo orçado de unidade não concluída
            /// 17 - Atividade de prestação de serviço de limpeza, conservação e manutenção - vale-transporte, vale-refeitção ou vale-alimentação, fardamento ou uniforme.
            /// 18 - Estoque de abertura de bens
            /// </summary>
            [SpedCampos(4, "NAT_BC_CRED", "N", 2, 0, false)]
            public string NatBcCred { get; set; }

            /// <summary>
            /// Valor da base de cálculo do PIS/PASEP
            /// </summary>
            [SpedCampos(5, "VL_BC_PIS", "C", 0, 2, false)]
            public decimal VlBcPis { get; set; }

            /// <summary>
            /// Alíquota do PIS/PASEP
            /// </summary>
            [SpedCampos(6, "ALIQ_PIS", "N", 8, 0, false)]
            public decimal AliqPis { get; set; }

            /// <summary>
            /// Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(7, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            /// Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(8, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        /// REGISTRO D505: COMPLEMENTO DA OPERAÇÃO (CÓDIGO 21 e 22) - Cofins
        /// </summary>
        public class RegistroD505 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD505"/>
            /// </summary>
            public RegistroD505()
            {
                Reg = "D505";
            }

            /// <summary>
            /// Código da situação tributária referente ao Cofins
            /// </summary>
            [SpedCampos(2, "CST_COFINS", "C", 2, 0, true)]
            public int CstCofins { get; set; }

            /// <summary>
            /// Valor total dos itens (serviços)
            /// </summary>
            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            /// Código da base de cálculo do crédito:
            /// <remarks>
            /// 01 - Aquisição de bens para revenda<para />
            /// 02 - Aquisição de bens utilizados como insumos<para />
            /// 03 - Aquisição de serviços utilizados como insumos<para />
            /// 04 - Energia elétrica e térmica, inclusive sob a forma de vapor<para />
            /// 05 - Aluguéis de prédios<para />
            /// 06 - Aluguéis de máquinas e equipamentos<para />
            /// 07 - Armazenagem de mercadoria e frete na operação de venda<para />
            /// 08 - Contraprestação de arredamento mercantil<para />
            /// 09 - Máquinas, equipamentos e outros bens incorporados ao ativo imobilizado (crédito sobre encargo de depreciação)<para />
            /// 10 - Máquinas, equipamentos e outros bens incorporados ao ativo imobilizado (crédito com base no valor de aquisição)<para />
            /// 11 - Amortização e depreciação de edificações e benefícios em imóveis<para />
            /// 12 - Devolução de vendas sujeitas à incidência não-cumulativa<para />
            /// 13 - Outras operações com direito a crédito (inclusive os créditos presumidos sobre receitas)<para />
            /// 14 - Atividade de transporte de cargas - subcontratação<para />
            /// 15 - Atividade imobiliária - Custo incorrido de unidade imobiliária<para />
            /// 16 - Atividade imobiliária - Custo orçado de unidade não concluída<para />
            /// 17 - Atividade de prestação de serviço de limpeza, conservação e manutenção - vale-transporte, vale-refeitção ou vale-alimentação, fardamento ou uniforme<para />
            /// 18 - Estoque de abertura de bens<para />
            /// </remarks>
            /// </summary>
            [SpedCampos(4, "NAT_BC_CRED", "N", 2, 0, false)]
            public int NatBcCred { get; set; }

            /// <summary>
            /// Valor da base de cálculo do COFINS
            /// </summary>
            [SpedCampos(5, "VL_BC_COFINS", "C", 0, 2, false)]
            public decimal VlBcCofins { get; set; }

            /// <summary>
            /// Alíquota do COFINS
            /// </summary>
            [SpedCampos(6, "ALIQ_COFINS", "N", 8, 0, false)]
            public decimal AliqCofins { get; set; }

            /// <summary>
            /// Valor do COFINS
            /// </summary>
            [SpedCampos(7, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            /// <summary>
            /// Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(8, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO D509: Processo Referenciado
        /// </summary>
        public class RegistroD509 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD509"/>
            /// </summary>
            public RegistroD509()
            {
                Reg = "D509";
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
        ///     REGISTRO D600: Consolidação da Prestação de Serviços -Notas de Serviço de Comunicação (Código 21) e de Serviço de Telecomunicação (Código 22)
        /// </summary>
        public class RegistroD600 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD600"/>
            /// </summary>
            public RegistroD600()
            {
                Reg = "D600";
            }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///    Código do município dos pontos de consumo, conforme a tabela IBGE
            /// </summary>
            [SpedCampos(3, "COD_MUN", "N", 7, 0, false)]
            public string CodMun { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(4, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(5, "SUB", "N", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///    Indicador do tipo de receita:
            ///    0-Receita própria -serviços prestados;
            ///    1-Receita própria -cobrança de débitos;
            ///    2-Receita  própria -venda  de  serviço  pré-pago –faturamento de períodos anteriores;
            ///    3-Receita  própria -venda  de  serviço  pré-pago –faturamento no período;
            ///    4-Outras receitas próprias de serviços de comunicação e telecomunicação;
            ///    5-Receita própria -co-faturamento;
            ///    6-Receita própria –serviços a faturar em período futuro;
            ///    7–Outras receitas próprias de natureza não-cumulativa;
            ///    8 -Outras receitas de terceiros
            ///    9 –Outras receitas
            /// </summary>
            [SpedCampos(6, "IND_REC", "N", 1, 0, true)]
            public string IndRec { get; set; }

            /// <summary>
            ///    Quantidade de documentos consolidados neste registro
            /// </summary>
            [SpedCampos(7, "QTD_CONS", "N", 0, 0, true)]
            public string QtdCons { get; set; }

            /// <summary>
            ///    Data Inicial dos documentos consolidados no período
            /// </summary>
            [SpedCampos(8, "DT_DOC_INI", "N", 8, 0, true)]
            public DateTime DtDocIni { get; set; }

            /// <summary>
            ///     Data Final dos documentos consolidados no período
            /// </summary>
            [SpedCampos(9, "DT_DOC_FIN", "N", 0, 2, true)]
            public DateTime DtDocFin { get; set; }

            /// <summary>
            ///    Valor total dos documentos fiscais
            /// </summary>
            [SpedCampos(10, "VL_DOC", "N", 0, 2, true)]
            public int  VlDoc { get; set; }

            /// <summary>
            ///     Valor total dos descontos
            /// </summary>
            [SpedCampos(11, "VL_DESC", "N", 0, 2, false)]
            public int VlDesc { get; set; }

            /// <summary>
            ///     Valor acumulado das prestações de serviços tributados pelo ICMS
            /// </summary>
            [SpedCampos(12, "VL_SERV", "N", 0, 2, true)]
            public int VlServ { get; set; }

            /// <summary>
            ///   Valor acumulado dos serviços não-tributados pelo ICMS
            /// </summary>
            [SpedCampos(13, "VL_SERV_NT", "N", 0, 2, false)]
            public decimal VlSerNt { get; set; }

            /// <summary>
            ///     Valores cobrados em nome de terceiros
            /// </summary>
            [SpedCampos(14, "VL_TERC", "N", 0, 2, false)]
            public decimal VlTerc { get; set; }

            /// <summary>
            ///    Valor acumulado das despesas acessórias
            /// </summary>
            [SpedCampos(15, "VL_DA", "N", 0, 2, false)]
            public decimal VlDa { get; set; }

            /// <summary>
            ///   Valor acumulado da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(16, "VL_BC_ICMS", "N", 0, 2, false)]
            public string VlBcIcms { get; set; }

            /// <summary>
            ///    Valor acumulado do ICMS 
            /// </summary>
            [SpedCampos(17, "VL_ICMS", "N", 0, 2, false)]
            public string VlIcms { get; set; }

            /// <summary>
            ///    Valor acumulado do PIS/PASEP
            /// </summary>
            [SpedCampos(18, "VL_PIS", "N", 0, 2, true)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///    Valor acumulado da COFINS
            /// </summary>
            [SpedCampos(19, "VL_COFINS", "N", 0, 2, true)]
            public decimal VlCofins { get; set; }

            public List<RegistroD601> RegD601s { get; set; }
            public List<RegistroD605> RegD605s { get; set; }
            public List<RegistroD609> RegD609s { get; set; }

        }

        /// <summary>
        ///     REGISTRO D601: Complemento  da  Consolidação  da  Prestação  de  Serviços  (Códigos  21  e  22) -PIS/Pasep
        /// </summary>
        public class RegistroD601 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD601"/>
            /// </summary>
            public RegistroD601()
            {
                Reg = "D601";
            }

            /// <summary>
            ///   Código  de  classificação  do  item  do  serviço  de comunicação ou de telecomunicação, conforme a Tabela 4.4.1
            /// </summary>
            [SpedCampos(2, "COD_CLASS", "N", 4, 0, true)]
            public decimal CodClass { get; set; }

            /// <summary>
            ///   Valor total dos itens (serviços)
            /// </summary>
            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Valor  acumulado  dos descontos/exclusões  da  base  de cálculo
            /// </summary>
            [SpedCampos(4, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///    Código  da  Situação  Tributária  referente  ao PIS/PASEP
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
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(8, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(9, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO D605: Complemento da Consolidação da Prestação de Serviços (Códigos21 e 22) –Cofins
        /// </summary>
        public class RegistroD605 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD605"/>
            /// </summary>
            public RegistroD605()
            {
                Reg = "D605";
            }

            /// <summary>
            ///   Código  de  classificação  do  item  do  serviço  de comunicação ou de telecomunicação, conforme a Tabela 4.4.1
            /// </summary>
            [SpedCampos(2, "COD_CLASS", "N", 4, 0, true)]
            public decimal CodClass { get; set; }

            /// <summary>
            ///   Valor total dos itens (serviços)
            /// </summary>
            [SpedCampos(3, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Valor  acumulado  dos descontos/exclusões  da  base  de cálculo
            /// </summary>
            [SpedCampos(4, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///   Código da Situação Tributária referente a COFINS.
            /// </summary>
            [SpedCampos(5, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

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
            ///    Valor da COFINS
            /// </summary>
            [SpedCampos(8, "VL_COFINS", "N", 0, 2, false)]
            public string VlCofins { get; set; }

            /// <summary>
            ///    Código da conta analítica contábil debitada/creditada 
            /// </summary>
            [SpedCampos(9, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO D609: Processo Referenciado
        /// </summary>
        public class RegistroD609 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroD609"/>
            /// </summary>
            public RegistroD609()
            {
                Reg = "D609";
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
        ///     REGISTRO D990: ENCERRAMENTO DO BLOCO D.
        /// </summary>
        public class RegistroD990 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="RegistroD990"/>.
            /// </summary>
            public RegistroD990()
            {
                Reg = "D990";
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco D
            /// </summary>
            [SpedCampos(2, "QTD_LIN_D", "N", int.MaxValue, 0, true)]
            public int QtdLinD { get; set; }
        }
    }
}
