using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDContribuicoes
{
    public class BlocoF
    {
        public RegistroF001 RegF001 { get; set; }
        public RegistroF990 RegF990 { get; set; }

        public class RegistroF001 : RegistroBaseSped
        {
            public RegistroF001()
            {
                Reg = "F001";
            }

            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroF010> RegF010s { get; set; }

        }

        /// <summary>
        /// Identificação do Estabelecimento
        /// </summary>
        public class RegistroF010 : RegistroBaseSped
        {
            public RegistroF010()
            {
                Reg = "F010";
            }

            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            public List<RegistroF100> RegF100s { get; set; }
            public List<RegistroF120> RegF120s { get; set; }
            public List<RegistroF130> RegF130s { get; set; }
            public List<RegistroF150> RegF150s { get; set; }
            public List<RegistroF200> RegF200s { get; set; }
            public List<RegistroF500> RegF500s { get; set; }
            public List<RegistroF510> RegF510s { get; set; }
            public List<RegistroF525> RegF525s { get; set; }
            public List<RegistroF550> RegF550s { get; set; }
            public List<RegistroF560> RegF560s { get; set; }
            public List<RegistroF600> RegF600s { get; set; }
            public List<RegistroF700> RegF700s { get; set; }
            public List<RegistroF800> RegF800s { get; set; }
        }

        /// <summary>
        /// DEMAIS DOCUMENTOS E OPERAÇÕES GERADORAS DE CONTRIBUIÇÃO E CRÉDITOS
        /// </summary>
        public class RegistroF100 : RegistroBaseSped
        {
            public RegistroF100()
            {
                Reg = "F100";
            }

            [SpedCampos(2, "IND_OPER", "N", 1, 0, true)]
            public int IndOper { get; set; }

            [SpedCampos(3, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            [SpedCampos(4, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            [SpedCampos(5, "DT_OPER", "N", 8, 0, true)]
            public DateTime DtOper { get; set; }

            [SpedCampos(6, "VL_OPER", "N", 0, 2, true)]
            public decimal VlOper { get; set; }

            [SpedCampos(7, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(8, "VL_BC_PIS", "N", 0, 4, false)]
            public decimal VlBcPis { get; set; }

            [SpedCampos(9, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal AliqPis { get; set; }

            [SpedCampos(10, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            [SpedCampos(11, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(12, "VL_BC_COFINS", "N", 0, 4, false)]
            public decimal VlBcCofins { get; set; }

            [SpedCampos(13, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal AliqCofins { get; set; }

            [SpedCampos(14, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            [SpedCampos(15, "NAT_BC_CRED", "C", 2, 0, false)]
            public string NatBcCred { get; set; }

            [SpedCampos(16, "IND_ORIG_CRED", "C", 1, 0, false)]
            public string IndOrigCred { get; set; }

            [SpedCampos(17, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            [SpedCampos(18, "COD_CCUS", "C", 60, 0, false)]
            public string CodCcus { get; set; }

            [SpedCampos(19, "DESC_DOC_OPER", "C", int.MaxValue, 0, false)]
            public string DescDocOper { get; set; }

            public List<RegistroF111> RegF111s { get; set; }

        }

        /// <summary>
        ///     REGISTRO F111: Processo Referenciado
        /// </summary>
        public class RegistroF111 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF111"/>
            /// </summary>
            public RegistroF111()
            {
                Reg = "F111";
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
        ///     REGISTRO F120: Bens Incorporados ao Ativo Imobilizado –Operações Geradoras de Créditos com Base nos Encargos de Depreciação e Amortização
        /// </summary>
        public class RegistroF120 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF120"/>
            /// </summary>
            public RegistroF120()
            {
                Reg = "F120";
            }

            /// <summary>
            ///    Código da Base de Cálculo do Crédito sobre Bens Incorporados ao Ativo Imobilizado, 
            ///    conforme a Tabela indicada no item 4.3.7:09 = Crédito com Base nos Encargos de Depreciação;
            ///    11 = Crédito com Base nos Encargos de Amortização 
            /// </summary>
            [SpedCampos(2, "NAT_BC_CRED", "C", 2, 0, true)]
            public string NatBcCred { get; set; }

            /// <summary>
            ///  Identificação dos Bens/Grupo de Bens Incorporados ao Ativo Imobilizado:
            ///  01 = Edificações e Benfeitorias em Imóveis Próprios;
            ///  02 = Edificações e Benfeitorias em Imóveis de Terceiros;
            ///  03 = Instalações;
            ///  04 = Máquinas;
            ///  05 = Equipamentos;
            ///  06 = Veículos;
            ///  99 = Outros.
            /// </summary>
            [SpedCampos(3, "IDENT_BEM_IMOB", "N", 2, 0, true)]
            public string IndntBemImob { get; set; }

            /// <summary>
            ///     Indicador da origem do bem incorporado ao ativo imobilizado, gerador de crédito:
            ///     0 –Aquisição no Mercado Interno
            ///     1 –Aquisição no Mercado Externo (Importação)
            /// </summary>
            [SpedCampos(4, "IND_ORIG_CRED", "C", 1, 0, false)]
            public string IndOrigCred { get; set; }

            /// <summary>
            ///   Indicador da Utilização dos Bens Incorporados ao Ativo Imobilizado:
            ///   1 –Produção de Bens Destinados a Venda;
            ///   2 –Prestação de Serviços;
            ///   3 –Locação a Terceiros;
            ///   9 –Outros.
            /// </summary>
            [SpedCampos(5, "IND_UTIL_BEM_IMOB", "N", 1, 0, true)]
            public string IndUtilBemImob { get; set; }

            /// <summary>
            ///     Valor do Encargo de Depreciação/Amortização Incorrido no Período
            /// </summary>
            [SpedCampos(6, "VL_OPER_DEP", "N", 0, 2, true)]
            public string VlOperDep { get; set; }

            /// <summary>
            ///   Parcela do Valor do Encargo de Depreciação/Amortização a excluir da base de cálculo de Crédito
            /// </summary>
            [SpedCampos(7, "PARC_OPER_NAO_BC_CRED", "N", 0, 2, false)]
            public string ParcOperNaoBcCred { get; set; }

            /// <summary>
            ///   Código da Situação Tributária referente ao PIS/PASEP, conforme a Tabela indicada no item 4.3.3.
            /// </summary>
            [SpedCampos(8, "CST_PIS", "N", 2, 0, true)]
            public string CstPis { get; set; }

            /// <summary>
            ///   Base de cálculo do Crédito de PIS/PASEP no período (06 –07)
            /// </summary>
            [SpedCampos(9, "VL_BC_PIS", "N", 0, 2, false)]
            public string VlBcPis { get; set; }

            /// <summary>
            ///   Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(10, "ALIQ_PIS", "N", 8, 4, false)]
            public string AliqPis { get; set; }

            /// <summary>
            ///     Valor do Crédito de PIS/PASEP
            /// </summary>
            [SpedCampos(11, "VL_PIS", "N", 0, 2, false)]
            public string VlPis { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente a COFINS, conforme a Tabela indicada no item 4.3.4.
            /// </summary>
            [SpedCampos(12, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

            /// <summary>
            ///   Base de Cálculo do Crédito da COFINS no período (06 –07)
            /// </summary>
            [SpedCampos(13, "VL_BC_COFINS", "N", 0, 2, false)]
            public string VlBcCofins { get; set; }

            /// <summary>
            ///     Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(14, "ALIQ_COFINS", "N", 8, 4, false)]
            public string AliqCofins { get; set; }

            /// <summary>
            ///   Valor do crédito da COFINS
            /// </summary>
            [SpedCampos(15, "VL_COFINS", "N", 0, 2, false)]
            public string VlCofins { get; set; }

            /// <summary>
            ///   Código da conta analítica contábil debitada/creditada  
            /// </summary>
            [SpedCampos(16, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///   Código do Centro de Custos
            /// </summary>
            [SpedCampos(17, "COD_CCUS", "C", 255, 0, false)]
            public string CodCcus{ get; set; }

            /// <summary>
            ///   Descrição complementar do bem ou grupo de bens, com crédito apurado com base nos encargos de depreciação ou amortização.
            /// </summary>
            [SpedCampos(18, "DESC_ BEM_IMOB", "C", 0, 0, false)]
            public string DescBemImob { get; set; }

            public List<RegistroF129> RegF129s { get; set; }
        }

        /// <summary>
        ///     REGISTRO F129: Processo Referenciado
        /// </summary>
        public class RegistroF129 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF129"/>
            /// </summary>
            public RegistroF129()
            {
                Reg = "F129";
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
        ///     REGISTRO F130: Bens Incorporados ao Ativo Imobilizado –Operações Geradoras de Créditos com Base no Valor de Aquisição/Contribuição
        /// </summary>
        public class RegistroF130 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF130"/>
            /// </summary>
            public RegistroF130()
            {
                Reg = "F130";
            }

            /// <summary>
            ///    Texto fixo contendo "10" (Código da Base de Cálculo do Crédito sobre Bens Incorporados ao Ativo Imobilizado, conforme a Tabela indicada no item 4.3.7)
            /// </summary>
            [SpedCampos(2, "NAT_BC_CRED", "C", 2, 0, true)]
            public string NatBcCred { get; set; }

            /// <summary>
            ///   Identificação dos bens ou grupo de bens incorporados ao Ativo Imobilizado:
            ///   01 = Edificações e Benfeitorias;
            ///   03 = Instalações;
            ///   04 = Máquinas;
            ///   05 = Equipamentos;
            ///   06 = Veículos;
            ///   99 = Outros bens incorporados ao Ativo Imobilizado.
            /// </summary>
            [SpedCampos(3, "IDENT_BEM_IMOB", "N", 2, 0, true)]
            public string IndntBemImob { get; set; }

            /// <summary>
            ///     Indicador da origem do bem incorporado ao ativo imobilizado, gerador de crédito:
            ///     0 –Aquisição no Mercado Interno
            ///     1 –Aquisição no Mercado Externo (Importação)
            /// </summary>
            [SpedCampos(4, "IND_ORIG_CRED", "C", 1, 0, false)]
            public string IndOrigCred { get; set; }

            /// <summary>
            ///   Indicador da Utilização dos Bens Incorporados ao Ativo Imobilizado:
            ///   1 –Produção de Bens Destinados a Venda;
            ///   2 –Prestação de Serviços;
            ///   3 –Locação a Terceiros;
            ///   9 –Outros.
            /// </summary>
            [SpedCampos(5, "IND_UTIL_BEM_IMOB", "N", 1, 0, true)]
            public string IndUtilBemImob { get; set; }

            /// <summary>
            ///     Mês/Ano de Aquisição dos Bens Incorporados ao Ativo Imobilizado, com apuração de crédito com base no valor de aquisição.
            /// </summary>
            [SpedCampos(6, "MES_OPER_AQUIS", "N", 6, 0, false)]
            public string MesOperAquis{ get; set; }

            /// <summary>
            ///   Valor de Aquisição dos Bens Incorporados ao Ativo Imobilizado –Crédito com base no valor de aquisição.
            /// </summary>
            [SpedCampos(7, "VL_OPER_AQUIS", "N", 0, 2, true)]
            public string VlOperAquis { get; set; }

            /// <summary>
            ///   Parcela do Valor de Aquisição a excluir da base de cálculo de Crédito
            /// </summary>
            [SpedCampos(8, "PARC_OPER_NAO_BC_CRED", "N", 0, 2, false)]
            public string ParcOperNaoBcCred{ get; set; }

            /// <summary>
            ///   Valor da Base de Cálculo do Crédito sobre Bens Incorporados ao Ativo Imobilizado (07 –08)
            /// </summary>
            [SpedCampos(9, "VL_BC_CRED", "N", 0, 2, true)]
            public string VlBcCred { get; set; }

            /// <summary>
            ///  Indicador do Número de Parcelas a serem apropriadas (Crédito sobre Valor de Aquisição):
            ///  1 –Integral (Mês de Aquisição);
            ///  2 –12 Meses;
            ///  3 –24 Meses;
            ///  4 –48 Meses;
            ///  5 –6 Meses (Embalagens de bebidas frias)
            ///  9 –Outra periodicidade definida em Lei
            /// </summary>
            [SpedCampos(10, "IND_NR_PARC", "N", 1, 0, true)]
            public string IndNrParc { get; set; }

            /// <summary>
            ///   Código da Situação Tributária referente ao PIS/PASEP, conforme a Tabela indicada no item 4.3.3.
            /// </summary>
            [SpedCampos(11, "CST_PIS", "N", 2, 0, true)]
            public string CstPis { get; set; }

            /// <summary>
            ///   Base de cálculo do Crédito de PIS/PASEP no período (06 –07)
            /// </summary>
            [SpedCampos(12, "VL_BC_PIS", "N", 0, 2, false)]
            public string VlBcPis { get; set; }

            /// <summary>
            ///   Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(13, "ALIQ_PIS", "N", 8, 4, false)]
            public string AliqPis { get; set; }

            /// <summary>
            ///     Valor do Crédito de PIS/PASEP
            /// </summary>
            [SpedCampos(14, "VL_PIS", "N", 0, 2, false)]
            public string VlPis { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente a COFINS, conforme a Tabela indicada no item 4.3.4.
            /// </summary>
            [SpedCampos(15, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

            /// <summary>
            ///   Base de Cálculo do Crédito da COFINS no período (06 –07)
            /// </summary>
            [SpedCampos(16, "VL_BC_COFINS", "N", 0, 2, false)]
            public string VlBcCofins { get; set; }

            /// <summary>
            ///     Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(17, "ALIQ_COFINS", "N", 8, 4, false)]
            public string AliqCofins { get; set; }

            /// <summary>
            ///   Valor do crédito da COFINS
            /// </summary>
            [SpedCampos(18, "VL_COFINS", "N", 0, 2, false)]
            public string VlCofins { get; set; }

            /// <summary>
            ///   Código da conta analítica contábil debitada/creditada  
            /// </summary>
            [SpedCampos(19, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///   Código do Centro de Custos
            /// </summary>
            [SpedCampos(20, "COD_CCUS", "C", 255, 0, false)]
            public string CodCcus { get; set; }

            /// <summary>
            ///   Descrição complementar do bem ou grupo de bens, com crédito apurado com base nos encargos de depreciação ou amortização.
            /// </summary>
            [SpedCampos(21, "DESC_ BEM_IMOB", "C", 0, 0, false)]
            public string DescBemImob { get; set; }

            public List<RegistroF139> RegF139s { get; set; }
        }

        /// <summary>
        ///     REGISTRO F139: Processo Referenciado
        /// </summary>
        public class RegistroF139 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF139"/>
            /// </summary>
            public RegistroF139()
            {
                Reg = "F139";
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
        ///     REGISTRO F150: CRÉDITO PRESUMIDO SOBRE ESTOQUE DE ABERTURA
        /// </summary>
        public class RegistroF150 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroF150" />.
            /// </summary>
            public RegistroF150()
            {
                Reg = "F150";
            }

            /// <summary>
            ///     Texto fixo contendo "18" Código da Base de Cálculo do Crédito sobre Estoque de Abertura, conforme a Tabela indicada no item 4.3.7.
            /// </summary>
            [SpedCampos(2, "NAT_BC_CRED", "C", 2, 0, true)]
            public string NatBCCred { get; set; }

            /// <summary>
            ///     Valor Total do Estoque de Abertura
            /// </summary>
            [SpedCampos(3, "VL_TOT_EST", "N", int.MaxValue, 2, true)]
            public decimal VlTotEst { get; set; }

            /// <summary>
            ///     Parcela do estoque de abertura referente a bens, produtos e mercadorias importados, ou adquiridas no mercado interno sem direito ao crédito
            /// </summary>
            [SpedCampos(4, "EST_IMP", "N", int.MaxValue, 2, false)]
            public decimal EstImp { get; set; }

            /// <summary>
            ///     Valor da Base de Cálculo do Crédito sobre o Estoque de Abertura (03 – 04)
            /// </summary>
            [SpedCampos(5, "VL_BC_EST", "N", int.MaxValue, 2, true)]
            public decimal VlBcEst { get; set; }

            /// <summary>
            ///     Valor da Base de Cálculo Mensal do Crédito sobre o Estoque de Abertura (1/12 avos do campo 05)
            /// </summary>
            [SpedCampos(6, "VL_BC_MEN_EST", "N", int.MaxValue, 2, true)]
            public decimal VlBcMenEst { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao PIS/PASEP, conforme a Tabela indicada no item 4.3.3.
            /// </summary>
            [SpedCampos(7, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(8, "ALIQ_PIS", "N", 8, 4, true)]
            public decimal AliqPis { get; set; }

            /// <summary>
            ///     Valor Mensal do Crédito Presumido Apurado para o Período - PIS/PASEP (06 x 08)
            /// </summary>
            [SpedCampos(9, "VL_CRED_PIS", "N", int.MaxValue, 2, true)]
            public decimal VlCredPis { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao COFINS, conforme a Tabela indicada no item 4.3.4
            /// </summary>
            [SpedCampos(10, "CST_COFINS", "N", 2, 0, true)]
            public decimal CstCofins { get; set; }

            /// <summary>
            ///     Alíquota do COFINS (em percentual)
            /// </summary>
            [SpedCampos(11, "ALIQ_COFINS", "N", 8, 4, true)]
            public decimal AliqCofins { get; set; }

            /// <summary>
            ///     Valor Mensal do Crédito Presumido Apurado para o Período - COFINS(06 x 11)
            /// </summary>
            [SpedCampos(12, "VL_CRED_COFINS", "N", int.MaxValue, 2, true)]
            public decimal VlCredCofins { get; set; }

            /// <summary>
            ///     Descrição do estoque
            /// </summary>
            [SpedCampos(13, "DESC_EST", "C", 100, 0, false)]
            public string DescEst { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(14, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        /// OPERAÇÕES DA ATIVIDADE IMOBILIÁRIA - UNIDADE IMOBILIÁRIA VENDIDA
        /// </summary>
        public class RegistroF200 : RegistroBaseSped
        {
            public RegistroF200()
            {
                Reg = "F200";
            }

            [SpedCampos(2, "IND_OPER", "N", 2, 0, true)]
            public int IndOper { get; set; }

            [SpedCampos(3, "UNID_IMOB", "N", 2, 0, true)]
            public int UnidImob { get; set; }

            [SpedCampos(4, "IDENT_EMP", "C", int.MaxValue, 0, true)]
            public string IdentEmp { get; set; }

            [SpedCampos(5, "DESC_UNID_IMOB", "C", 90, 0, false)]
            public string DescUnidImob { get; set; }

            [SpedCampos(6, "NUM_CONT", "C", 90, 0, false)]
            public string NumCont { get; set; }

            [SpedCampos(7, "CPF_CNPJ_ADQU", "C", 14, 0, true)]
            public string CpfCnpjAdqu { get; set; }

            [SpedCampos(8, "DT_OPER", "N", 8, 0, true)]
            public DateTime DtOper { get; set; }

            [SpedCampos(9, "VL_TOT_VEND", "N", 0, 2, true)]
            public decimal VlTotVend { get; set; }

            [SpedCampos(10, "VL_REC_ACUM", "N", 0, 2, false)]
            public decimal VlRecAcum { get; set; }

            [SpedCampos(11, "VL_TOT_REC", "N", 0, 2, true)]
            public decimal VlTotRec { get; set; }

            [SpedCampos(12, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(13, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal VlBcPis { get; set; }

            [SpedCampos(14, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal AliqPis { get; set; }

            [SpedCampos(15, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            [SpedCampos(16, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(17, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal VlBcCofins { get; set; }

            [SpedCampos(18, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal AliqCofins { get; set; }

            [SpedCampos(19, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            [SpedCampos(20, "PERC_REC_RECEB", "N", 6, 2, false)]
            public decimal PercRecReceb { get; set; }

            [SpedCampos(21, "IND_NAT_EMP", "N", 1, 0, false)]
            public int IndNatEmp { get; set; }

            [SpedCampos(22, "INF_COMP", "C", 90, 0, false)]
            public string InfComp { get; set; }

            public RegistroF205 RegF205 { get; set; }
            public List<RegistroF210> RegF210s { get; set; }
            public List<RegistroF211> RegF211s { get; set; }
        }

        /// <summary>
        ///     REGISTRO F205: Operações da Atividade Imobiliária –Custo Incorrido da Unidade Imobiliária
        /// </summary>
        public class RegistroF205 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF205"/>
            /// </summary>
            public RegistroF205()
            {
                Reg = "F205";
            }

            /// <summary>
            ///    Valor  Total  do  Custo  Incorrido  da unidade imobiliária  acumulado  até  o  mês  anterior  ao  da escrituração
            /// </summary>
            [SpedCampos(2, "VL_CUS_INC_ACUM_ANT", "N", 0, 2, true)]
            public string VlCusIncAcumAnt { get; set; }

            /// <summary>
            ///   Valor  Total  do  Custo  Incorrido  da  unidade imobiliária no mês da escrituração
            /// </summary>
            [SpedCampos(3, "VL_CUS_INC_PER_ESC", "N", 0, 2, true)]
            public string VlCucIncPerEsc { get; set; }

            /// <summary>
            ///    Valor  Total  do  Custo  Incorrido  da  unidade imobiliária  acumulado  até  o  mês  da  escrituração (Campo 02 + 03)
            /// </summary>
            [SpedCampos(4, "VL_CUS_INC_ACUM", "N", 0, 2, true)]
            public string VlCusIncAcum { get; set; }

            /// <summary>
            ///   Parcela do Custo Incorrido sem direito ao crédito da atividade imobiliária, acumulado até o período.
            /// </summary>
            [SpedCampos(5, "VL_EXC_BC_CUS_INC_ACUM", "N", 0, 2, true)]
            public string VlExcBcCusIncAcum { get; set; }

            /// <summary>
            ///    Valor da Base de Cálculo do Crédito sobre o Custo Incorrido, acumulado até o período da escrituração (Campo 04 –05)
            /// </summary>
            [SpedCampos(6, "VL_BC_CUS_INC", "N", 0, 2, true)]
            public string VlBcCusINc { get; set; }

            /// <summary>
            ///  Código  da  Situação  Tributária  referente  ao PIS/PASEP,  conforme  a  Tabela  indicada  no  item 4.3.3.
            /// </summary>
            [SpedCampos(7, "CST_PIS", "N", 2, 0, true)]
            public string CstPis { get; set; }

            /// <summary>
            ///   Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(8, "ALIQ_PIS", "N", 8, 4, true)]
            public string AliqPis { get; set; }

            /// <summary>
            ///  Valor  Total  do  Crédito Acumulado  sobre  o  custo incorrido –PIS/PASEP (Campo 06 x 08)
            /// </summary>
            [SpedCampos(9, "VL_CRED_PIS_ACUM", "N", 0, 2, true)]
            public string VlCredPisAcum { get; set; }

            /// <summary>
            ///  Parcela do crédito descontada até o período anterior da escrituração –PIS/PASEP (proporcional à receita recebida até o mês anterior).
            /// </summary>
            [SpedCampos(10, "VL_CRED_PIS_DESC_ANT", "N", 0, 2, true)]
            public string VlCredPisDescAnt{ get; set; }

            /// <summary>
            ///  Parcela a descontar no período da escrituração  –PIS/PASEP  (proporcional  à  receita  recebida  no mês).
            /// </summary>
            [SpedCampos(11, "VL_CRED_PIS_DESC", "N", 0, 2, true)]
            public string VlCredPisDesc { get; set; }

            /// <summary>
            ///  Parcela  a  descontar  em  períodos  futuros   –PIS/PASEP (Campo 09 –10 –11).
            /// </summary>
            [SpedCampos(12, "VL_CRED_PIS_DESC_FUT", "N", 0, 2, true)]
            public string VlCredPisDescFut{ get; set; }

            /// <summary>
            ///   Código da Situação Tributária referente ao COFINS, conforme a Tabela indicada no item 4.3.4.
            /// </summary>
            [SpedCampos(13, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

            /// <summary>
            ///     Alíquota do COFINS (em percentual)
            /// </summary>
            [SpedCampos(14, "ALIQ_COFINS", "N", 8, 4, true)]
            public string AliqCofins { get; set; }

            /// <summary>
            ///     Valor  Total  do  Crédito Acumulado  sobre  o  custo incorrido -COFINS (Campo 06 x 14)
            /// </summary>
            [SpedCampos(15, "VL_CRED_COFINS_ACUM", "N", 0, 2, true)]
            public string VlCredCofinsAcum { get; set; }

            /// <summary>
            ///  Parcela do crédito descontada até o período anterior da escrituração –COFINS (proporcional à receita recebida até o mês anterior).
            /// </summary>
            [SpedCampos(16, "VL_CRED_COFINS_DESC_ANT", "N", 0, 2, true)]
            public string VlCredCofinsDescAnt { get; set; }

            /// <summary>
            ///    Parcela a descontar no período da escrituração  –COFINS (proporcional à receita recebida no mês).
            /// </summary>
            [SpedCampos(17, "VL_CRED_COFINS_DESC", "N", 0, 2, true)]
            public string VlCredCofinsDesc { get; set; }

            /// <summary>
            ///   Parcela a descontar em períodos futuros  –COFINS (Campo 15 –16 –17).
            /// </summary>
            [SpedCampos(18, "VL_CRED_COFINS_DESC_FUT", "N", 0, 2, true)]
            public string VlCredCofinsDescFut { get; set; }

        }

        /// <summary>
        ///     REGISTRO F210: Operações da Atividade Imobiliária -Custo Orçado da Unidade Imobiliária Vendida
        /// </summary>
        public class RegistroF210 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF210"/>
            /// </summary>
            public RegistroF210()
            {
                Reg = "F210";
            }

            /// <summary>
            ///     Valor Total do Custo Orçado para Conclusão da Unidade Vendida
            /// </summary>
            [SpedCampos(2, "VL_CUS_ORC", "N", 0, 2, true)]
            public string VlCusOrc { get; set; }

            /// <summary>
            ///   Valores Referentes a Pagamentos a Pessoas Físicas, Encargos Trabalhistas, Sociais e Previdenciários e à aquisição de bens e serviços não sujeitos ao pagamento das contribuições
            /// </summary>
            [SpedCampos(3, "VL_EXC", "N", 0, 2, true)]
            public string VlExc { get; set; }

            /// <summary>
            ///   Valor da Base de Calculo do Crédito sobre o Custo Orçado Ajustado (Campo 02 –03)
            /// </summary>
            [SpedCampos(4, "VL_CUS_ORC_AJU", "N", 0, 2, true)]
            public string VlCusOrcAju { get; set; }

            /// <summary>
            ///  Valor da Base de Cálculo do Crédito sobre o Custo Orçado  referente  ao  mês  da  escrituração, proporcionalizada em função da receita recebida no mês.
            /// </summary>
            [SpedCampos(5, "VL_BC_CRED", "N", 0, 2, true)]
            public string VlBcCred { get; set; }

            /// <summary>
            ///   Código da Situação Tributária referente ao PIS/PASEP, conforme a Tabela indicada no item 4.3.3
            /// </summary>
            [SpedCampos(6, "CST_PIS", "N", 2, 0, true)]
            public string CstPIs { get; set; }

            /// <summary>
            ///  Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(7, "ALIQ_PIS", "N", 8, 4, false)]
            public string AliqPis { get; set; }

            /// <summary>
            ///   Valor  do Crédito  sobre  o  custo  orçado  a  ser utilizado no período da escrituração -PIS/PASEP (Campo 05 x 07)
            /// </summary>
            [SpedCampos(8, "VL_CRED_PIS_UTIL", "N", 0, 2, false)]
            public string VlCredPisUtil { get; set; }

            /// <summary>
            ///  Código da Situação Tributária referente a COFINS, conforme aTabela indicada no item 4.3.4.
            /// </summary>
            [SpedCampos(9, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

            /// <summary>
            ///   Alíquota da COFINS (em percentual)
            /// </summary>
            [SpedCampos(10, "ALIQ_COFINS", "N", 8, 4, false)]
            public string AliqCofins { get; set; }

            /// <summary>
            /// Valor  do  Crédito  sobre  o  custo  orçado  a  ser utilizado  no  período  da  escrituração -COFINS (Campo 05 x 10)
            /// </summary>
            [SpedCampos(11, "VL_CRED_COFINS_UTIL", "N", 0, 2, false)]
            public string VlCredCofinsUtil { get; set; }

        }

        /// <summary>
        ///     REGISTRO F211: Processo Referenciado
        /// </summary>
        public class RegistroF211 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF211"/>
            /// </summary>
            public RegistroF211()
            {
                Reg = "F211";
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
        /// CONSOLIDAÇÃO DAS OPERAÇÕES DA PESSOA JURÍDICA SUBMETIDA AO REGIME DE TRIBUTAÇÃO COM BASE NO LUCRO PRESUMIDO  – INCIDÊNCIA DO PIS/PASEP E DA COFINS PELO REGIME DE CAIXA
        /// </summary>
        public class RegistroF500 : RegistroBaseSped
        {
            public RegistroF500()
            {
                Reg = "F500";
            }

            [SpedCampos(2, "VL_REC_CAIXA", "N", int.MaxValue, 2, true)]
            public decimal VlRecCaixa { get; set; }

            [SpedCampos(3, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(4, "VL_DESC_PIS", "N", int.MaxValue, 2, false)]
            public decimal VlDescPis { get; set; }

            [SpedCampos(5, "VL_BC_PIS", "N", int.MaxValue, 2, false)]
            public decimal VlBcPis { get; set; }

            [SpedCampos(6, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal AliqPis { get; set; }

            [SpedCampos(7, "VL_PIS", "N", int.MaxValue, 2, false)]
            public decimal VlPis { get; set; }

            [SpedCampos(8, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(9, "VL_DESC_COFINS", "N", int.MaxValue, 2, false)]
            public decimal VlDescCofins { get; set; }

            [SpedCampos(10, "VL_BC_COFINS", "N", int.MaxValue, 2, false)]
            public decimal VlBcCofins { get; set; }

            [SpedCampos(11, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal AliqCofins { get; set; }

            [SpedCampos(12, "VL_COFINS", "N", int.MaxValue, 2, false)]
            public decimal VlCofins { get; set; }

            [SpedCampos(13, "COD_MOD", "C", 2, 0, false)]
            public int? CodMod { get; set; }

            [SpedCampos(14, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            [SpedCampos(15, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            [SpedCampos(16, "INFO_COMPL", "C", int.MaxValue, 0, false)]
            public string InfoCompl { get; set; }

            public List<RegistroF509> RegF509s { get; set; }
        }

        /// <summary>
        ///     REGISTRO F509: Processo Referenciado
        /// </summary>
        public class RegistroF509 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF509"/>
            /// </summary>
            public RegistroF509()
            {
                Reg = "F509";
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
        ///     REGISTRO F510: Consolidação das Operações da Pessoa Jurídica Submetida ao Regime de Tributação Com Base no Lucro Presumido 
        ///     –Incidência do PIS/Pasep e da Cofins pelo Regime de Caixa (Apuração da Contribuição por Unidade de Medida de Produto –Alíquota em Reais)
        /// </summary>
        public class RegistroF510 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF510"/>
            /// </summary>
            public RegistroF510()
            {
                Reg = "F510";
            }

            /// <summary>
            ///     Valor  total  da  receita  recebida,  referente  à combinação de CST e Alíquota.
            /// </summary>
            [SpedCampos(2, "VL_REC_CAIXA", "N", 0, 2, true)]
            public string VlRecCaixa { get; set; }

            /// <summary>
            ///    Código  da  Situação  Tributária  referente  ao PIS/PASEP
            /// </summary>
            [SpedCampos(3, "CST_PIS", "N", 2, 0, true)]
            public string CstPis { get; set; }

            /// <summary>
            ///    Valor do desconto / exclusão
            /// </summary>
            [SpedCampos(4, "VL_DESC_PIS", "N", 0, 2, false)]
            public string VlDescPis { get; set; }

            /// <summary>
            ///  Base de cálculo em quantidade -PIS/PASEP
            /// </summary>
            [SpedCampos(5, "QUANT_BC_PIS", "N", 0, 3, false)]
            public string QuantBcPis { get; set; }

            /// <summary>
            ///    Alíquota do PIS/PASEP (em reais
            /// </summary>
            [SpedCampos(6, "ALIQ_PIS_QUANT", "N", 8, 4, false)]
            public string AliqPisQuant { get; set; }

            /// <summary>
            ///  Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(7, "VL_PIS", "N", 0, 2, false)]
            public string VlPis { get; set; }

            /// <summary>
            ///  Código da Situação Tributária referente a COFINS
            /// </summary>
            [SpedCampos(8, "CST_COFINS", "N", 2, 0, true)]
            public string CstCofins { get; set; }

            /// <summary>
            ///  Valor do desconto / exclusão
            /// </summary>
            [SpedCampos(9, "VL_DESC_COFINS", "N", 0, 2, false)]
            public string VlDescCofins{ get; set; }

            /// <summary>
            ///  Base de cálculo em quantidade -COFINS
            /// </summary>
            [SpedCampos(10, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public string QuantBcCofins { get; set; }

            /// <summary>
            ///  Alíquota da COFINS (em reais)
            /// </summary>
            [SpedCampos(11, "ALIQ_COFINS_QUANT", "N", 8, 4, false)]
            public string AliqCofinsQuant { get; set; }

            /// <summary>
            ///  Valor da COFINS
            /// </summary>
            [SpedCampos(12, "VL_COFINS", "N", 0, 2, false)]
            public string VlCofins { get; set; }

            /// <summary>
            ///   Código do modelo do documento fiscal conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(13, "COD_MOD", "C", 2, 0, false)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(14, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            /// <summary>
            ///     Código  da  conta  analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(15, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///  Informação complementar
            /// </summary>
            [SpedCampos(16, "INFO_COMPL", "C", 0, 0, false)]
            public string InfoCompl { get; set; }

            public List<RegistroF519> RegF519s { get; set; }
        }

        /// <summary>
        ///    Registro F519: Processo Referenciado
        /// </summary>
        public class RegistroF519 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF519"/>
            /// </summary>
            public RegistroF519()
            {
                Reg = "F519";
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

        public class RegistroF525 : RegistroBaseSped
        {
            public RegistroF525()
            {
                Reg = "F525";
            }

            [SpedCampos(2, "VL_REC", "N", int.MaxValue, 2, true)]
            public decimal VlRec { get; set; }

            [SpedCampos(3, "IND_REC", "C", 2, 0, true)]
            public int IndRec { get; set; }

            [SpedCampos(4, "CNPJ_CPF", "C", 14, 0, false)]
            public string CnpjCpf { get; set; }

            [SpedCampos(5, "NUM_DOC", "C", 60, 0, false)]
            public string NumDoc { get; set; }

            [SpedCampos(6, "VL_REC,DET", "C", 60, 0, false)]
            public string CodItem { get; set; }

            [SpedCampos(7, "VL_REC_DET", "N", int.MaxValue, 2, true)]
            public decimal VlRecDet { get; set; }

            [SpedCampos(8, "CST_PIS", "N", 2, 0, false)]
            public int CstPis { get; set; }

            [SpedCampos(9, "CST_COFINS", "N", 2, 0, false)]
            public int CstCofins { get; set; }

            [SpedCampos(10, "INFO_COMPL", "C", 0, 0, false)]
            public string InfoCompl { get; set; }

            [SpedCampos(11, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class RegistroF550 : RegistroBaseSped
        {
            public RegistroF550()
            {
                Reg = "F550";
            }

            [SpedCampos(2, "VL_REC_COMP", "N", int.MaxValue, 2, true)]
            public decimal VlRecComp { get; set; }

            [SpedCampos(3, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            [SpedCampos(4, "VL_DESC_PIS", "N", int.MaxValue, 2, false)]
            public decimal VlDescPis { get; set; }

            [SpedCampos(5, "VL_BC_PIS", "N", int.MaxValue, 2, false)]
            public decimal VlBcPis { get; set; }

            [SpedCampos(6, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal AliqPis { get; set; }

            [SpedCampos(7, "VL_PIS", "N", int.MaxValue, 2, false)]
            public decimal VlPis { get; set; }

            [SpedCampos(8, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            [SpedCampos(9, "VL_DESC_COFINS", "N", int.MaxValue, 2, false)]
            public decimal VlDescCofins { get; set; }

            [SpedCampos(10, "VL_BC_COFINS", "N", int.MaxValue, 2, false)]
            public decimal VlBcCofins { get; set; }

            [SpedCampos(11, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal AliqCofins { get; set; }

            [SpedCampos(12, "VL_COFINS", "N", int.MaxValue, 2, false)]
            public decimal VlCofins { get; set; }

            [SpedCampos(13, "COD_MOD", "C", 2, 0, false)]
            public int? CodMod { get; set; }

            [SpedCampos(14, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            [SpedCampos(15, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }

            [SpedCampos(16, "INFO_COMPL", "C", 0, 0, false)]
            public string InfoCompl { get; set; }

            public List<RegistroF559> RegF559s { get; set; }
        }

        /// <summary>
        ///     REGISTRO F559: Processo Referenciado
        /// </summary>
        public class RegistroF559 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF559"/>
            /// </summary>
            public RegistroF559()
            {
                Reg = "F559";
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
        ///     REGISTRO F560: CONSOLIDAÇÃO DAS OPERAÇÕES DA PESSOA JURÍDICA SUBMETIDA AO REGIME 
        ///     DE TRIBUTAÇÃO COM BASE NO LUCRO PRESUMIDO – INCIDÊNCIA DO PIS/PASEP E DA COFINS 
        ///     PELO REGIME DE COMPETÊNCIA (APURAÇÃO DA CONTRIBUIÇÃO POR UNIDADE DE MEDIDA DE PRODUTO
        ///     – ALÍQUOTA EM REAIS)
        /// </summary>
        public class RegistroF560 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroF560" />.
            /// </summary>
            public RegistroF560()
            {
                Reg = "F560";
            }

            /// <summary>
            ///     Valor total da receita auferida, referente à combinação de CST e Alíquota.
            /// </summary>
            [SpedCampos(2, "VL_REC_COMP", "N", int.MaxValue, 2, true)]
            public decimal VlRecComp { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao PIS/PASEP 
            /// </summary>
            [SpedCampos(3, "CST_PIS", "N", 2, 0, true)]
            public int CstPis { get; set; }

            /// <summary>
            ///     Valor do desconto / exclusão
            /// </summary>
            [SpedCampos(4, "VL_DESC_PIS", "N", int.MaxValue, 2, false)]
            public decimal? VlDescPis { get; set; }

            /// <summary>
            ///     Base de cálculo em quantidade - PIS/PASEP
            /// </summary>
            [SpedCampos(5, "QUANT_BC_PIS", "N", int.MaxValue, 3, false)]
            public decimal? QuantBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS/PASEP (em reais)
            /// </summary>
            [SpedCampos(6, "ALIQ_PIS_QUANT", "N", 8, 4, false)]
            public decimal? AliqPisQuant { get; set; }

            /// <summary>
            ///     Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(7, "VL_PIS", "N", int.MaxValue, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente a COFINS
            /// </summary>
            [SpedCampos(8, "CST_COFINS", "N", 2, 0, true)]
            public int CstCofins { get; set; }

            /// <summary>
            ///     Valor do desconto / exclusão
            /// </summary>
            [SpedCampos(9, "VL_DESC_COFINS", "N", int.MaxValue, 2, false)]
            public decimal? VlDescCofins { get; set; }

            /// <summary>
            ///      Base de cálculo em quantidade - COFINS
            /// </summary>
            [SpedCampos(10, "QUANT_BC_COFINS", "N", int.MaxValue, 3, false)]
            public decimal? QuantBcCofins { get; set; }

            /// <summary>
            ///     Alíquota do COFINS (em reais)
            /// </summary>
            [SpedCampos(11, "ALIQ_COFINS_QUANT", "N", 8, 4, false)]
            public decimal? AliqCofinsQuant { get; set; }

            /// <summary>
            ///     Valor do COFINS
            /// </summary>
            [SpedCampos(12, "VL_COFINS", "N", int.MaxValue, 2, false)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(13, "COD_MOD", "C", 2, 0, false)]
            public int? CodMod { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(14, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada / creditada 
            /// </summary>
            [SpedCampos(15, "COD_CTA", "C", 255, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Informação complementar 
            /// </summary>
            [SpedCampos(16, "INFO_COMPL", "C", int.MaxValue, 0, false)]
            public string InfoCompl { get; set; }

            public List<RegistroF569> RegF569s { get; set; }
        }

        /// <summary>
        ///     REGISTRO F569: Processo Referenciado
        /// </summary>
        public class RegistroF569 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF569"/>
            /// </summary>
            public RegistroF569()
            {
                Reg = "F569";
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
        /// CONTRIBUIÇÃO RETIDA NA FONTE
        /// </summary>
        public class RegistroF600 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroF600" />.
            /// </summary>
            public RegistroF600()
            {
                Reg = "F600";
            }

            /// <summary>
            /// Indicador de Natureza da Retenção na Fonte
            /// </summary>
            /// <remarks>
            /// 01 - Retenção por Órgãos, Autarquias e Fundações Federais
            /// <para />
            /// 02 - Retenção por outras Entidades da Administração Pública Federal
            /// <para />
            /// 03 - Retenção por Pessoas Jurídicas de Direito Privado
            /// <para />
            /// 04 - Recolhimento por Sociedade Cooperativa
            /// <para />
            /// 05 - Retenção por Fabricante de Máquinas e Veículos
            /// <para />
            /// 99 - Outras Retenções
            /// </remarks>
            [SpedCampos(2, "IND_NAT_RET", "N", 2, 0, true)]
            public int IndNatRet { get; set; }

            /// <summary>
            /// Data da retenção
            /// </summary>
            [SpedCampos(3, "DT_RET", "N", 8, 0, true)]
            public DateTime DtRet { get; set; }

            /// <summary>
            /// Base de cálculo da retenção ou do acolhimento (sociedade cooperativa)
            /// </summary>
            [SpedCampos(4, "VL_BC_RET", "N", int.MaxValue, 4, true)]
            public decimal VlBcRet { get; set; }

            /// <summary>
            /// Valor total retido na fonte / recolhido (sociedade cooperativa)
            /// </summary>
            [SpedCampos(5, "VL_RET", "N", int.MaxValue, 2, true)]
            public decimal VlRet { get; set; }

            /// <summary>
            /// Código da receita
            /// </summary>
            [SpedCampos(6, "COD_REC", "C", 4, 0, false)]
            public string CodRec { get; set; }

            /// <summary>
            /// Indicador da natureza da receita
            /// </summary>
            /// <remarks>
            /// 0 - Receita de Natureza Não Cumulativa
            /// <para />
            /// 1 - Receita de Natureza Cumulativa
            /// </remarks>
            [SpedCampos(7, "IND_NAT_REC", "N", 1, 0, false)]
            public int? IndNatRec { get; set; }

            /// <summary>
            /// CNPJ da fonte pagadora ou da PJ beneficiária
            /// </summary>
            /// <remarks>
            /// - Fonte pagadora responsável pela retenção / recolhimento (no caso de o registro ser escriturado pela pessoa jurídica beneficiária da retenção); ou
            /// <para />
            /// - Pessoa jurídica beneficiária da retenção / recolhimento (no caso de o registro ser escriturado pela pessoa jurídica responsável pela retenção).
            /// </remarks>
            [SpedCampos(8, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            /// <summary>
            /// Valor retido na fonte - parcela referente ao PIS/Pasep
            /// </summary>
            [SpedCampos(9, "VL_RET_PIS", "N", int.MaxValue, 2, true)]
            public decimal VlRetPis { get; set; }

            /// <summary>
            /// Valor retido na fonte - parcela referente a COFINS
            /// </summary>
            [SpedCampos(10, "VL_RET_COFINS", "N", int.MaxValue, 2, true)]
            public decimal VlRetCofins { get; set; }

            /// <summary>
            /// Indicador da condição da pessoa jurídica declarante
            /// </summary>
            /// <remarks>
            /// 0 - Beneficiária da retenção / recolhimento
            /// <para />
            /// 1 - Responsável pelo recolhimento
            /// </remarks>
            [SpedCampos(11, "IND_DEC", "N", 1, 0, true)]
            public int IndDec { get; set; }
        }

        /// <summary>
        ///     REGISTRO F700: DEDUÇÕES DIVERSAS
        /// </summary>
        public class RegistroF700 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroF700" />.
            /// </summary>
            public RegistroF700()
            {
                Reg = "F700";
            }

            /// <summary>
            ///     Indicador de Origem de Deduções Diversas: 
            ///     01 – Créditos Presumidos - Medicamentos 
            ///     02 – Créditos Admitidos no Regime Cumulativo – Bebidas Frias 
            ///     03 – Contribuição Paga pelo Substituto Tributário - ZFM 
            ///     04 – Substituição Tributária – Não Ocorrência do Fato Gerador Presumido 
            ///     99 - Outras Deduções 
            /// </summary>
            [SpedCampos(2, "IND_ORI_DED", "N", 2, 0, true)]
            public int IndOriDed { get; set; }

            /// <summary>
            ///     Indicador da Natureza da Dedução: 
            ///     0 – Dedução de Natureza Não Cumulativa 
            ///     1 – Dedução de Natureza Cumulativa
            /// </summary>
            [SpedCampos(3, "IND_NAT_DED", "N", 1, 0, true)]
            public int IndNatDed { get; set; }

            /// <summary>
            ///     Valor a Deduzir - PIS/PASEP
            /// </summary>
            [SpedCampos(4, "VL_DED_PIS", "N", int.MaxValue, 2, true)]
            public decimal VlDedPis { get; set; }

            /// <summary>
            ///     Valor a Deduzir – Cofins
            /// </summary>
            [SpedCampos(5, "VL_DED_COFINS", "N", int.MaxValue, 2, true)]
            public decimal VlDedCofins { get; set; }

            /// <summary>
            ///     Valor da Base de Cálculo da Operação que ensejou o Valor a Deduzir informado nos Campos 04 e 05
            /// </summary>
            [SpedCampos(6, "VL_BC_OPER", "N", int.MaxValue, 2, false)]
            public decimal? VlBcOper { get; set; }

            /// <summary>
            ///     CNPJ da Pessoa Jurídica relacionada à Operação que ensejou o Valor a Deduzir informado nos Campos 04 e 05.
            /// </summary>
            [SpedCampos(7, "CNPJ", "N", 14, 0, false)]
            public string Cnpj { get; set; }

            /// <summary>
            ///     Informações Complementares do Documento/Operação que ensejou o Valor a Deduzir informado nos Campos 04 e 05.
            /// </summary>
            [SpedCampos(8, "INF_COMP", "C", 90, 0, false)]
            public string InfoComp { get; set; }
        }

        /// <summary>
        ///     REGISTRO F800: Créditos Decorrentes de Eventos de Incorporação, Fusão e Cisão
        /// </summary>
        public class RegistroF800 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroF800"/>
            /// </summary>
            public RegistroF800()
            {
                Reg = "F800";
            }

            /// <summary>
            ///    ndicador da Natureza do Evento de Sucessão:
            ///    01 –Incorporação
            ///    02 –Fusão
            ///    03 –Cisão Total
            ///    04 –Cisão Parcial
            ///    99 –Outros
            /// </summary>
            [SpedCampos(2, "IND_NAT_EVEN", "N", 2, 0, true)]
            public string IndNatEven{ get; set; }

            /// <summary>
            ///    Data do Evento
            /// </summary>
            [SpedCampos(3, "DT_EVEN", "N", 8, 0, true)]
            public DateTime DtEven { get; set; }

            /// <summary>
            ///   CNPJ da Pessoa Jurídica Sucedida
            /// </summary>
            [SpedCampos(4, "CNPJ_SUCED", "N", 14, 0, true)]
            public decimal CnpjSuced { get; set; }

            /// <summary>
            ///  Período de Apuração do Crédito –Mês/Ano (MM/AAAA)
            /// </summary>
            [SpedCampos(5, "PA_CONT_CRED", "N", 6, 0, true)]
            public decimal PaContCred { get; set; }

            /// <summary>
            ///  Código do crédito transferido, conforme Tabela 4.3.6
            /// </summary>
            [SpedCampos(6, "COD_CRED", "N", 3, 0, true)]
            public string CodCred { get; set; }

            /// <summary>
            ///  Valor do Crédito Transferido de PIS/Pasep
            /// </summary>
            [SpedCampos(7, "VL_CRED_PIS", "N", 0, 2, true)]
            public int VlCredPis { get; set; }

            /// <summary>
            ///   Valor do Crédito Transferido de Cofins
            /// </summary>
            [SpedCampos(8, "VL_CRED_COFINS", "N", 0, 2, true)]
            public string VlCredCofins{ get; set; }

            /// <summary>
            ///  Percentual do crédito original transferido, no caso de evento de Cisão. 
            /// </summary>
            [SpedCampos(9, "PER_CRED_CIS", "N", 6, 2, false)]
            public decimal PerCredCis { get; set; }

        }

        public class RegistroF990 : RegistroBaseSped
        {
            public RegistroF990()
            {
                Reg = "F990";
            }

            [SpedCampos(2, "QTD_LIN_F", "N", int.MaxValue, 0, true)]
            public int QtdLinF { get; set; }
        }
    }
}
