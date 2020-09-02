using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.EFDContribuicoes
{
    /// <summary>
    ///     BLOCO D: DOCUMENTOS FISCAIS ii - SERVIÇOS (ICMS)
    /// </summary>
    public class BlocoD
    {
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
