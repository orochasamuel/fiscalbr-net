using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDFiscal
{
    /// <summary>
    ///     BLOCO C: DOCUMENTOS FISCAIS I - MERCADORIAS (ICMS/IPI)
    /// </summary>
    public class BlocoC
    {
        public RegistroC001 RegC001 { get; set; }
        public RegistroC990 RegC990 { get; set; }

        /// <summary>
        ///     REGISTRO C001: ABERTURA DO BLOCO C
        /// </summary>
        public class RegistroC001 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC001" />.
            /// </summary>
            public RegistroC001()
            {
                Reg = "C001";
            }

            /// <summary>
            ///     Indicador de movimento: 0 - Bloco com dados informados; 1 - Bloco sem dados informados.
            /// </summary>
            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroC100> RegC100s { get; set; }
            public List<RegistroC300> RegC300s { get; set; }
            public List<RegistroC350> RegC350s { get; set; }
            public List<RegistroC400> RegC400s { get; set; }
            public List<RegistroC495> RegC495s { get; set; }
            public List<RegistroC500> RegC500s { get; set; }
            public List<RegistroC600> RegC600s { get; set; }
            public List<RegistroC700> RegC700s { get; set; }
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
            ///     9 - Sem pagamento (até 30/06/2012).
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

            public List<RegistroC101> RegC101s { get; set; }
            public List<RegistroC105> RegC105s { get; set; }
            public List<RegistroC110> RegC110s { get; set; }
            public List<RegistroC120> RegC120s { get; set; }
            public List<RegistroC130> RegC130s { get; set; }
            public List<RegistroC140> RegC140s { get; set; }
            public List<RegistroC160> RegC160s { get; set; }
            public List<RegistroC165> RegC165s { get; set; }
            public List<RegistroC170> RegC170s { get; set; }
            public List<RegistroC185> RegC185s { get; set; }
            public List<RegistroC186> RegC186s { get; set; }
            public List<RegistroC190> RegC190s { get; set; }
            public List<RegistroC195> RegC195s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C101: INFORMAÇÃO COMPLEMENTAR DOS DOCUMENTOS FISCAIS QUANDO DAS OPERAÇÕES INTERESTADUAIS DESTINADAS A
        ///     CONSUMIDOR FINAL NÃO CONTRIBUINTE EC 87/15 (CÓDIGO 55)
        /// </summary>
        public class RegistroC101 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC101" />.
            /// </summary>
            public RegistroC101()
            {
                Reg = "C101";
            }

            /// <summary>
            ///     Valor total relativo ao Fundo de Combate à Pobreza (FCP) da UF de destino
            /// </summary>
            [SpedCampos(2, "VL_FCP_UF_DEST", "N", 0, 2, true)]
            public decimal VlFcpUfDest { get; set; }

            /// <summary>
            ///     Valor total do ICMS Interestadual para a UF de destino
            /// </summary>
            [SpedCampos(3, "VL_ICMS_UF_DEST", "N", 0, 2, true)]
            public decimal VlIcmsUfDest { get; set; }

            /// <summary>
            ///     Valor total do ICMS Interestadual para a UF do remetente
            /// </summary>
            [SpedCampos(4, "VL_ICMS_UF_REM", "N", 0, 2, true)]
            public decimal VlIcmsUfRem { get; set; }
        }

        /// <summary>
        ///     OPERAÇÕES COM ICMS ST RECOLHIDO PARA UF DIVERSA DO DESTINATÁRIO DO DOCUMENTO FISCAL (CÓDIGO 55)
        /// </summary>
        public class RegistroC105 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC105" />.
            /// </summary>
            public RegistroC105()
            {
                Reg = "C105";
            }

            /// <summary>
            ///     Indicador do tipo de operação
            /// </summary>
            /// <remarks>
            ///     0 - Combustíveis e lubrificantes;
            ///     <para />
            ///     1 - Leasing de veículos ou faturamento direto.
            /// </remarks>
            [SpedCampos(2, "OPER", "N", 1, 0, true)]
            public IndTipoOperacaoStUfDiversa Oper { get; set; }

            /// <summary>
            ///     Sigla da UF de destino do ICMS_ST
            /// </summary>
            [SpedCampos(3, "UF", "C", 2, 0, true)]
            public string Uf { get; set; }
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

            public List<RegistroC111> RegC111s { get; set; }
            public List<RegistroC112> RegC112s { get; set; }
            public List<RegistroC113> RegC113s { get; set; }
            public List<RegistroC114> RegC114s { get; set; }
            public List<RegistroC115> RegC115s { get; set; }
            public List<RegistroC116> RegC116s { get; set; }
        }

        /// <summary>
        ///     PROCESSO REFERENCIADO
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
            ///     Identificação do processo ou ato concessório.
            /// </summary>
            [SpedCampos(2, "NUM_PROC", "C", 15, 0, true)]
            public string NumProc { get; set; }

            /// <summary>
            ///     Indicador da origem do processo:
            ///     0 - SEFAZ;
            ///     1 - Justiça Federal;
            ///     2 - Justiça Estadual;
            ///     3 - SECEX/SRF;
            ///     9 - Outros.
            /// </summary>
            [SpedCampos(3, "IND_PROC", "C", 1, 0, true)]
            public int IndProc { get; set; }
        }

        /// <summary>
        ///     DOCUMENTO DE ARRECADAÇÃO REFERENCIADO
        /// </summary>
        public class RegistroC112 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC112" />.
            /// </summary>
            public RegistroC112()
            {
                Reg = "C112";
            }

            /// <summary>
            ///     Código do modelo do documento de arrecadação:
            ///     0 - documento estadual de arrecadação
            ///     1 - GNRE
            /// </summary>
            [SpedCampos(2, "COD_DA", "C", 1, 0, true)]
            public int CodDa { get; set; }

            /// <summary>
            ///     Unidade federada beneficiária do recolhimento
            /// </summary>
            [SpedCampos(3, "UF", "C", 2, 0, true)]
            public string Uf { get; set; }

            /// <summary>
            ///     Número do documento de arrecadação
            /// </summary>
            [SpedCampos(4, "NUM_DA", "C", 999, 0, false)]
            public string NumDa { get; set; }

            /// <summary>
            ///     Código completo da autenticação bancária
            /// </summary>
            [SpedCampos(5, "COD_AUT", "C", 999, 0, false)]
            public string Cod_Aut { get; set; }

            /// <summary>
            ///     Valor do total do documento de arrecadação (principal, atualização monetária, juros e multa)
            /// </summary>
            [SpedCampos(6, "VL_DA", "N", 0, 2, true)]
            public decimal VlDa { get; set; }

            /// <summary>
            ///     Data de vencimento do documento de arrecadação
            /// </summary>
            [SpedCampos(6, "DT_VCTO", "N", 8, 0, true)]
            public DateTime DtVcto { get; set; }

            /// <summary>
            ///     Data de pagamento do documento de arrecadação ou data do vencimento, no caso de ICMS antecipado a recolher.
            /// </summary>
            [SpedCampos(7, "DT_PGTO", "N", 8, 0, true)]
            public DateTime DtPgto { get; set; }
        }

        /// <summary>
        ///     DOCUMENTO FISCAL REFERENCIADO
        /// </summary>
        public class RegistroC113 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC113" />.
            /// </summary>
            public RegistroC113()
            {
                Reg = "C113";
            }

            /// <summary>
            ///     Indicador do tipo de operação:
            ///     0 - Entrada/aquisição
            ///     1 - Saída/prestação
            /// </summary>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true)]
            public int IndOper { get; set; }

            /// <summary>
            ///     Indicador do emitente do título:
            ///     0 - Emissão própria
            ///     1 - Terceiros
            /// </summary>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true)]
            public int IndEmit { get; set; }

            /// <summary>
            ///     Código do participante emitente do documento referenciado
            /// </summary>
            [SpedCampos(4, "COD_PART", "C", 60, 0, true)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do documento fiscal
            /// </summary>
            [SpedCampos(5, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(6, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(7, "SUB", "C", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(8, "NUM_DOC", "N", 9, 0, true)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(9, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Chave de acesso do documento fiscal
            /// </summary>
            [SpedCampos(10, "CHV_DOCe", "C", 44, 0, false)]
            public string ChvDoc { get; set; }


        }

        /// <summary>
        ///     CUPOM FISCAL REFERENCIADO
        /// </summary>
        public class RegistroC114 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC114" />.
            /// </summary>
            public RegistroC114()
            {
                Reg = "C114";
            }

            /// <summary>
            ///     Código do modelo do documento fiscal
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Número de série de fabricação do ECF
            /// </summary>
            [SpedCampos(3, "ECF_FAB", "C", 21, 0, true)]
            public string EcfFab { get; set; }

            /// <summary>
            ///     Número do caixa atribuído ao ECF
            /// </summary>
            [SpedCampos(4, "ECF_CX", "N", 3, 0, true)]
            public int EcfCx { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(5, "NUM_DOC", "N", 9, 0, true)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(6, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }
        }

        /// <summary>
        ///     REGISTRO C115: LOCAL DA COLETA E/OU ENTREGA (CÓDIGO 01, 1B E 04)
        /// </summary>
        public class RegistroC115 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC115" />.
            /// </summary>
            public RegistroC115()
            {
                Reg = "C115";
            }

            /// <summary>
            ///     Indicador do tipo de transporte
            /// </summary>
            /// <remarks>
            ///     0 - Rodoviário;
            ///     1 - Ferroviário;
            ///     2 - Rodo-Ferroviário;
            ///     3 - Aquaviário;
            ///     4 - Dutoviário;
            ///     5 - Aéreo;
            ///     9 - Outros.
            /// </remarks>
            [SpedCampos(2, "IND_CARGA", "N", 1, 0, true)]
            public IndTipoTransporte IndCarga { get; set; }

            /// <summary>
            ///     Número do CNPJ do contribuinte do local de coleta
            /// </summary>
            [SpedCampos(3, "CNPJ_COL", "N", 14, 0, false)]
            public string CnpjCol { get; set; }

            /// <summary>
            ///     Inscrição estadual do contribuinte do local de coleta
            /// </summary>
            [SpedCampos(4, "IE_COL", "C", 14, 0, false)]
            public string IeCol { get; set; }

            /// <summary>
            ///     CPF do contribuinte do local de coleta das mercadorias
            /// </summary>
            [SpedCampos(5, "CPF_COL", "N", 11, 0, false)]
            public string CpfCol { get; set; }

            /// <summary>
            ///     Código do município do local de coleta
            /// </summary>
            [SpedCampos(6, "COD_MUN_COL", "N", 7, 0, false)]
            public string CodMunCol { get; set; }

            /// <summary>
            ///     Número do CNPJ do contribuinte do local de entrega
            /// </summary>
            [SpedCampos(7, "CNPJ_ENTG", "N", 14, 0, false)]
            public string CnpjEntg { get; set; }

            /// <summary>
            ///     Inscrição estadual do contribuinte do local de entrega
            /// </summary>
            [SpedCampos(8, "IE_ENTG", "C", 14, 0, false)]
            public string IeEntg { get; set; }

            /// <summary>
            ///     CPF do contribuinte do local de entrega
            /// </summary>
            [SpedCampos(9, "CPF_ENTG", "N", 11, 0, false)]
            public string CpfEntg { get; set; }

            /// <summary>
            ///     Código do município do local de entrega
            /// </summary>
            [SpedCampos(10, "COD_MUN_ENTG", "N", 7, 0, false)]
            public string CodMunEntg { get; set; }
        }

        /// <summary>
        ///     REGISTRO C116: CUPOM FISCAL ELETRÔNICO REFERENCIADO
        /// </summary>
        public class RegistroC116 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC116" />.
            /// </summary>
            public RegistroC116()
            {
                Reg = "C116";
            }

            /// <summary>
            ///     Código do modelo do documento fiscal
            /// </summary>
            /// <remarks>
            ///     Preenchimento: Deve corresponder ao código do Cupom Fiscal Eletrônico (59).
            /// </remarks>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Número de série do equipamento SAT
            /// </summary>
            [SpedCampos(3, "NR_SAT", "N", 9, 0, true)]
            public string NrSat { get; set; }

            /// <summary>
            ///     Chave do cupom fiscal eletrônico
            /// </summary>
            [SpedCampos(4, "CHV_CFE", "N", 44, 0, true)]
            public string ChvCfe { get; set; }

            /// <summary>
            ///     Número do cupom fiscal eletrônico
            /// </summary>
            [SpedCampos(5, "NUM_CFE", "N", 6, 0, true)]
            public int NumCfe { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            /// <remarks>
            ///     Preenchimento: Informar a data de emissão do documento, no formato "ddmmaaaa".
            /// </remarks>
            [SpedCampos(6, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }
        }

        /// <summary>
        ///     REGISTRO C120: COMPLEMENTO DE DOCUMENTO - OPERAÇÕES DE IMPORTAÇÃO (CÓDIGOS 01 E 55)
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
            [SpedCampos(4, "PIS_IMP", "N", 0, 2, false)]
            public decimal PisImp { get; set; }

            /// <summary>
            ///     Valor pago de COFINS na importação
            /// </summary>
            [SpedCampos(5, "COFINS_IMP", "N", 0, 2, false)]
            public decimal CofinsImp { get; set; }

            /// <summary>
            ///     Número do Ato Concessório do regime Drawback
            /// </summary>
            [SpedCampos(6, "NUM_ACDRAW", "C", 20, 0, false)]
            public string NumAcDraw { get; set; }
        }

        /// <summary>
        ///     REGISTRO C130: ISSQN, IRRF E PREVIDÊNCIA SOCIAL
        /// </summary>
        public class RegistroC130 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC130" />.
            /// </summary>
            public RegistroC130()
            {
                Reg = "C130";
            }

            /// <summary>
            ///     Valor dos serviços sob não-incidência ou não tributados pelo ICMS
            /// </summary>
            [SpedCampos(2, "VL_SERV_NT", "N", 0, 2, true)]
            public decimal VlServNt { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ISSQN
            /// </summary>
            [SpedCampos(3, "VL_BC_ISSQN", "N", 0, 2, true)]
            public decimal VlBcIssqn { get; set; }

            /// <summary>
            ///     Valor do ISSQN
            /// </summary>
            [SpedCampos(4, "VL_ISSQN", "N", 0, 2, false)]
            public decimal VlIssqn { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do imposto de renda retido na fonte
            /// </summary>
            [SpedCampos(5, "VL_BC_IRRF", "N", 0, 2, false)]
            public decimal VlBcIrrf { get; set; }

            /// <summary>
            ///     Valor do imposto de renda retido na fonte
            /// </summary>
            [SpedCampos(6, "VL_IRRF", "N", 0, 2, false)]
            public decimal VlIrrf { get; set; }

            /// <summary>
            ///     Valor da base de cálculo de retenção da previdência social
            /// </summary>
            [SpedCampos(7, "VL_BC_PREV", "N", 0, 2, false)]
            public decimal VlBcPrev { get; set; }

            /// <summary>
            ///     Valor destacado para retenção da previdência social
            /// </summary>
            [SpedCampos(8, "VL_PREV", "N", 0, 2, false)]
            public decimal VlPrev { get; set; }
        }

        /// <summary>
        ///     REGISTRO C140: FATURA (CÓDIGO 01)
        /// </summary>
        public class RegistroC140 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC140" />.
            /// </summary>
            public RegistroC140()
            {
                Reg = "C140";
            }

            /// <summary>
            ///     Indicador do emitente do título
            /// </summary>
            /// <remarks>
            ///     0 - Emissão própria;
            ///     <para />
            ///     1 - Terceiros.
            /// </remarks>
            [SpedCampos(2, "IND_EMIT", "C", 1, 0, true)]
            public int IndEmit { get; set; }

            /// <summary>
            ///     Indicador do tipo de título de crédito
            /// </summary>
            /// <remarks>
            ///     00 - Duplicata;
            ///     <para />
            ///     01 - Cheque;
            ///     <para />
            ///     02 - Promissória;
            ///     <para />
            ///     03 - Recibo;
            ///     <para />
            ///     99 - Outros (descrever)
            /// </remarks>
            [SpedCampos(3, "IND_TIT", "C", 2, 0, true)]
            public int IndTit { get; set; }

            /// <summary>
            ///     Descrição complementar do título de crédito
            /// </summary>
            [SpedCampos(4, "DESC_TIT", "C", 999, 0, false)]
            public string DescTit { get; set; }

            /// <summary>
            ///     Número ou código identificador do título de crédito
            /// </summary>
            [SpedCampos(5, "NUM_TIT", "C", 999, 0, true)]
            public string NumTit { get; set; }

            /// <summary>
            ///     Quantidade de parcelas a receber/pagar
            /// </summary>
            [SpedCampos(6, "QTD_PARC", "N", 2, 0, true)]
            public int QtdParc { get; set; }

            /// <summary>
            ///     Valor total dos títulos de créditos
            /// </summary>
            [SpedCampos(7, "VL_TIT", "N", 0, 2, true)]
            public decimal VlTit { get; set; }

            public List<RegistroC141> RegC141s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C141: VENCIMENTO DA FATURA (CÓDIGO 01)
        /// </summary>
        public class RegistroC141 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC141" />.
            /// </summary>
            public RegistroC141()
            {
                Reg = "C141";
            }

            /// <summary>
            ///     Número da parcela a receber/pagar
            /// </summary>
            [SpedCampos(2, "NUM_PARC", "N", 2, 0, true)]
            public int NumParc { get; set; }

            /// <summary>
            ///     Data de vencimento da parcela
            /// </summary>
            [SpedCampos(3, "DT_VCTO", "N", 8, 0, true)]
            public DateTime DtVcto { get; set; }

            /// <summary>
            ///     Valor da parcela a receber/pagar
            /// </summary>
            [SpedCampos(4, "VL_PARC", "N", 0, 2, true)]
            public decimal VlParc { get; set; }
        }

        /// <summary>
        ///     REGISTRO 160: VOLUMES TRANSPORTADOS (CÓDIGO 01 E 04) - EXCETO COMBUSTÍVEIS
        /// </summary>
        public class RegistroC160 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC160" />.
            /// </summary>
            public RegistroC160()
            {
                Reg = "C160";
            }

            /// <summary>
            ///     Código do participante transportador, se houver
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Placa de identificação do veículo automotor
            /// </summary>
            [SpedCampos(3, "VEIC_ID", "C", 7, 0, false)]
            public string VeicId { get; set; }

            /// <summary>
            ///     Quantidade de volumes transportados
            /// </summary>
            [SpedCampos(4, "QTD_VOL", "N", int.MaxValue, 0, true)]
            public int QtdVol { get; set; }

            /// <summary>
            ///     Peso bruto dos volumes transportados (em Kg)
            /// </summary>
            [SpedCampos(5, "PESO_BRT", "N", 0, 2, true)]
            public decimal PesoBrt { get; set; }

            /// <summary>
            ///     Peso líquido dos volumes transportados (em Kg)
            /// </summary>
            [SpedCampos(6, "PESO_LIQ", "N", 0, 2, true)]
            public decimal PesoLiq { get; set; }

            /// <summary>
            ///     Sigla da UF da placa do veículo
            /// </summary>
            [SpedCampos(7, "UF_ID", "C", 2, 0, false)]
            public string UfId { get; set; }
        }

        /// <summary>
        ///     REGISTRO C165: OPERAÇÕES COM COMBUSTÍVEIS (CÓDIGO 01)
        /// </summary>
        public class RegistroC165 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC165" />.
            /// </summary>
            public RegistroC165()
            {
                Reg = "C165";
            }

            /// <summary>
            ///     Código do participante transportador, se houver
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Placa de identificação do veículo
            /// </summary>
            [SpedCampos(3, "VEIC_ID", "C", 7, 0, true)]
            public string VeicId { get; set; }

            /// <summary>
            ///     Código de autorização fornecido pela SEFAZ (combustíveis)
            /// </summary>
            [SpedCampos(4, "COD_AUT", "C", 999, 0, false)]
            public string CodAut { get; set; }

            /// <summary>
            ///     Número do passe fiscal
            /// </summary>
            [SpedCampos(5, "NR_PASSE", "C", 999, 0, false)]
            public string NrPasse { get; set; }

            /// <summary>
            ///     Hora da saída das mercadorias
            /// </summary>
            [SpedCampos(6, "HORA", "H", 6, 0, true)]
            public DateTime Hora { get; set; }

            /// <summary>
            ///     Temperatura em graus Celsius utilizada para quantificação do volume de combustível
            /// </summary>
            [SpedCampos(7, "TEMPER", "N", 0, 1, false)]
            public decimal Temper { get; set; }

            /// <summary>
            ///     Quantidade de volumes transportados
            /// </summary>
            [SpedCampos(8, "QTD_VOL", "N", 0, 0, true)]
            public int QtdVol { get; set; }

            /// <summary>
            ///     Peso bruto dos volumes transportados (em Kg)
            /// </summary>
            [SpedCampos(9, "PESO_BRT", "N", 0, 2, true)]
            public decimal PesoBrt { get; set; }

            /// <summary>
            ///     Peso líquido dos volumes transportados (em Kg)
            /// </summary>
            [SpedCampos(10, "PESO_LIQ", "N", 0, 2, true)]
            public decimal PesoLiq { get; set; }

            /// <summary>
            ///     Nome do motorista
            /// </summary>
            [SpedCampos(11, "NOM_MOT", "C", 60, 0, false)]
            public string NomMot { get; set; }

            /// <summary>
            ///     CPF do motorista
            /// </summary>
            [SpedCampos(12, "CPF", "N", 11, 0, false)]
            public string Cpf { get; set; }

            /// <summary>
            ///     Sigla da UF da placa do veículo
            /// </summary>
            [SpedCampos(13, "UF_ID", "C", 2, 0, false)]
            public string UfId { get; set; }
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
            [SpedCampos(5, "QTD", "N", 0, 5, true)]
            public decimal Qtd { get; set; }

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
            public decimal? VlBcIpi { get; set; }

            /// <summary>
            ///     Alíquota do IPI
            /// </summary>
            [SpedCampos(23, "ALIQ_IPI", "N", 6, 2, false)]
            public decimal? AliqIpi { get; set; }

            /// <summary>
            ///     Valor do IPI creditado/debitado
            /// </summary>
            [SpedCampos(24, "VL_IPI", "N", 0, 2, false)]
            public decimal? VlIpi { get; set; }

            /// <summary>
            ///     Código da situação tributária referente ao PIS
            /// </summary>
            [SpedCampos(25, "CST_PIS", "N", 2, 0, false)]
            public int? CstPis { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS
            /// </summary>
            [SpedCampos(26, "VL_BC_PIS", "N", 0, 2, false)]
            public decimal? VlBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS (em percentual)
            /// </summary>
            [SpedCampos(27, "ALIQ_PIS", "N", 8, 4, false)]
            public decimal? AliqPis { get; set; }

            /// <summary>
            ///     Quantidade - Base de cálculo PIS
            /// </summary>
            [SpedCampos(28, "QUANT_BC_PIS", "N", 0, 3, false)]
            public decimal? QuantBcPis { get; set; }

            /// <summary>
            ///     Alíquota do PIS (em reais)
            /// </summary>
            [SpedCampos(29, "ALIQ_PIS", "N", 0, 4, false)]
            public decimal? AliqPisReais { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(30, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Código da situação tributária referente ao COFINS
            /// </summary>
            [SpedCampos(31, "CST_COFINS", "N", 2, 0, false)]
            public int? CstCofins { get; set; }

            /// <summary>
            ///     Valor da base de cálculo da COFINS
            /// </summary>
            [SpedCampos(32, "VL_BC_COFINS", "N", 0, 2, false)]
            public decimal? VlBcCofins { get; set; }

            /// <summary>
            ///     Alíquota do COFINS (em percentual)
            /// </summary>
            [SpedCampos(33, "ALIQ_COFINS", "N", 8, 4, false)]
            public decimal? AliqCofins { get; set; }

            /// <summary>
            ///     Quantidade - Base de cálculo COFINS
            /// </summary>
            [SpedCampos(34, "QUANT_BC_COFINS", "N", 0, 3, false)]
            public decimal? QuantBcCofins { get; set; }

            /// <summary>
            ///     Alíquota da COFINS (em reais)
            /// </summary>
            [SpedCampos(35, "ALIQ_COFINS", "N", 0, 4, false)]
            public decimal? AliqCofinsReais { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(36, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(37, "COD_CTA", "C", 999, 0, false)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Valor do abatimento não tributado e não comercial
            /// </summary>
            [SpedCampos(38, "VL_ABAT_NT", "N", 0, 2, false)]
            public decimal? VlAbatNt { get; set; }

            public List<RegistroC171> RegC171s { get; set; }
            public RegistroC172 RegC172 { get; set; }
            public List<RegistroC173> RegC173s { get; set; }
            public List<RegistroC174> RegC174s { get; set; }
            public List<RegistroC175> RegC175s { get; set; }
            public List<RegistroC176> RegC176s { get; set; }
            public RegistroC177 RegC177 { get; set; }
            public RegistroC178 RegC178 { get; set; }
            public RegistroC179 RegC179 { get; set; }
            public RegistroC180 RegC180 { get; set; }
            public List<RegistroC181> RegC181 { get; set; }
        }

        /// <summary>
        ///     REGISTRO C171: ARMAZENAMENTO DE COMBUSTÍVEIS
        /// </summary>
        public class RegistroC171 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC171" />.
            /// </summary>
            public RegistroC171()
            {
                Reg = "C171";
            }

            /// <summary>
            ///     Tanque onde foi armazenda o combustível
            /// </summary>
            [SpedCampos(2, "NUM_TANQUE", "C", 3, 0, true)]
            public string NumTanque { get; set; }

            /// <summary>
            ///     Quantidade ou volume armazenado
            /// </summary>
            [SpedCampos(3, "QTDE", "N", 0, 3, true)]
            public decimal Qtde { get; set; }
        }

        /// <summary>
        ///     REGISTRO C172: OPERAÇÕES COM ISSQN
        /// </summary>
        public class RegistroC172 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC172" />.
            /// </summary>
            public RegistroC172()
            {
                Reg = "C172";
            }

            /// <summary>
            ///     Valor da base de cálculo do ISSQN
            /// </summary>
            [SpedCampos(2, "VL_BC_ISSQN", "N", 0, 2, true)]
            public decimal VlBcIssqn { get; set; }

            /// <summary>
            ///     Alíquota do ISSQN
            /// </summary>
            [SpedCampos(3, "ALIQ_ISSQN", "N", 6, 2, true)]
            public decimal AliqIssqn { get; set; }

            /// <summary>
            ///     Valor do ISSQN
            /// </summary>
            [SpedCampos(4, "VL_ISSQN", "N", 0, 2, true)]
            public decimal VlIssqn { get; set; }
        }

        /// <summary>
        ///     REGISTRO C173: OPERAÇÕES COM MEDICAMENTOS
        /// </summary>
        public class RegistroC173 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC173" />.
            /// </summary>
            public RegistroC173()
            {
                Reg = "C173";
            }

            /// <summary>
            ///     Número do lote de fabricação do medicamento
            /// </summary>
            [SpedCampos(4, "LOTE_MED", "C", 1024, 0, true)]
            public string LoteMed { get; set; }

            /// <summary>
            ///     Quantidade de item por lote
            /// </summary>
            [SpedCampos(4, "QTD_ITEM", "N", 0, 3, true)]
            public decimal QtdItem { get; set; }

            /// <summary>
            ///     Data de fabricação do medicamento
            /// </summary>
            [SpedCampos(4, "DT_FAB", "N", 8, 0, true)]
            public DateTime DtFab { get; set; }

            /// <summary>
            ///     Data de expiração da validade do medicamento
            /// </summary>
            [SpedCampos(4, "DT_VAL", "N", 8, 0, true)]
            public DateTime DtVal { get; set; }

            /// <summary>
            ///     Indicador de tipo de refer~encia da base de cálculo do ICMS (ST) do produto farmacêutico
            /// </summary>
            /// <remarks>
            ///     0 - Base de cálculo referente ao preço tabelado ou preço máximo sugerido
            ///     1 - Base cálculo - Margem de valor agregado
            ///     2 - Base de cálculo referente à Lista Negativa
            ///     3 - Base de cálculo referente à Lista Positiva
            ///     4 - Base de cálculo referente à Lista Neutra
            /// </remarks>
            [SpedCampos(4, "IND_MED", "C", 1, 0, true)]
            public int IndMed { get; set; }

            /// <summary>
            ///     Tipo de produto
            /// </summary>
            /// <remarks>
            ///     0 - Similar
            ///     1 - Genérico
            ///     2 - Ético ou de marca
            /// </remarks>
            [SpedCampos(4, "TP_PROD", "C", 1, 0, true)]
            public int TpProd { get; set; }

            /// <summary>
            ///     Valor do preço tabelado ou valor do preço máximo
            /// </summary>
            [SpedCampos(4, "VL_TAB_MAX", "N", 0, 2, true)]
            public decimal VlTabMax { get; set; }
        }

        /// <summary>
        ///     REGISTRO C174: OPERAÇÕES COM ARMAS DE FOGO
        /// </summary>
        public class RegistroC174 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC174" />.
            /// </summary>
            public RegistroC174()
            {
                Reg = "C174";
            }

            /// <summary>
            ///     Indicador do tipo de arma de fogo
            /// </summary>
            /// <remarks>
            ///     0 - Uso permitido
            ///     1 - Uso restrito
            /// </remarks>
            [SpedCampos(2, "IND_ARM", "C", 1, 0, true)]
            public int IndArm { get; set; }

            /// <summary>
            ///     Numeração de série de fabricação da arma
            /// </summary>
            [SpedCampos(3, "NUM_ARM", "C", 1024, 0, true)]
            public string NumArm { get; set; }

            /// <summary>
            ///     Descrição da arma, compreendendo: número do cano, calibre, marca, capacidade de cartunhos, tipo de funcionamento,
            ///     quantidade de canos, comprimento, tipo de alma, quantidade e sentido das raias e demais elementos que permitam sua
            ///     perfeita identificação
            /// </summary>
            [SpedCampos(4, "DESCR_COMPL", "C", 1024, 0, true)]
            public string DescrCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO C175: OPERAÇÕES COM VEÍCULOS NOVOS
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
            ///     Indicador do tipo de operação com veículo
            /// </summary>
            /// <remarks>
            ///     0 - Venda para concessionária
            ///     1 - Faturamento direto
            ///     2 - Venda direta
            ///     3 - Venda da concessionária
            ///     9 - Outros
            /// </remarks>
            [SpedCampos(2, "IND_VEIC_OPER", "C", 1, 0, true)]
            public int IndVeicOper { get; set; }

            /// <summary>
            ///     CNPJ da concessionária
            /// </summary>
            [SpedCampos(3, "CNPJ", "N", 14, 0, false)]
            public string Cnpj { get; set; }

            /// <summary>
            ///     Sigla da unidade da federação da concessionária
            /// </summary>
            [SpedCampos(4, "UF", "C", 2, 0, false)]
            public string Uf { get; set; }

            /// <summary>
            ///     Chassi do veículo
            /// </summary>
            [SpedCampos(5, "CHASSI_VEIC", "C", 17, 0, true)]
            public string ChassiVeic { get; set; }
        }

        /// <summary>
        ///     REGISTRO C176: RESSARCIMENTO DE ICMS EM OPERAÇÕES COM SUBSTITUIÇÃO TRIBUTÁRIA
        /// </summary>
        public class RegistroC176 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC176" />.
            /// </summary>
            public RegistroC176()
            {
                Reg = "C176";
            }

            /// <summary>
            ///     Código do modelo do documento fiscal relativa a última entrada
            /// </summary>
            [SpedCampos(2, "COD_MOD_ULT_E", "C", 2, 0, true)]
            public string CodModUltE { get; set; }

            /// <summary>
            ///     Número do documento fiscal relativa a última entrada
            /// </summary>
            [SpedCampos(3, "NUM_DOC_ULT_E", "N", 9, 0, true)]
            public long NumDocUltE { get; set; }

            /// <summary>
            ///     Série do documento fiscal relativa a última entrada
            /// </summary>
            [SpedCampos(4, "SER_ULT_E", "C", 3, 0, false)]
            public string SerUltE { get; set; }

            /// <summary>
            ///     Data relativa a última entrada da mercadoria
            /// </summary>
            [SpedCampos(5, "DT_ULT_E", "N", 8, 0, true)]
            public DateTime DtUltE { get; set; }

            /// <summary>
            ///     Código do participante (do emitente do documento relativa a última entrada)
            /// </summary>
            [SpedCampos(6, "COD_PART_ULT_E", "C", 60, 0, true)]
            public string CodPartUltE { get; set; }

            /// <summary>
            ///     Quantidade do item relativa a última entrada
            /// </summary>
            [SpedCampos(7, "QUANT_ULT_E", "N", 0, 3, true)]
            public decimal QuantUltE { get; set; }

            /// <summary>
            ///     Valor unitário da mercadoria constante na NF relativa a última entrada inclusive despesas acessórias
            /// </summary>
            [SpedCampos(8, "VL_UNIT_ULT_E", "N", 0, 3, true)]
            public decimal VlUnitUltE { get; set; }

            /// <summary>
            ///     Valor unitário da base de cálculo do imposto pago por substituição
            /// </summary>
            [SpedCampos(9, "VL_UNIT_BC_ST", "N", 0, 3, true)]
            public decimal VlUnitBcSt { get; set; }
        }

        /// <summary>
        ///     REGISTRO C177: OPERAÇÕES COM PRODUTOS SUJEITOS A SELO DE CONTROLE DE IPI
        /// </summary>
        public class RegistroC177 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC177" />.
            /// </summary>
            public RegistroC177()
            {
                Reg = "C177";
            }

            /// <summary>
            ///     Código do selo de controle do IPI
            /// </summary>
            [SpedCampos(2, "COD_SELO_IPI", "C", 6, 0, true)]
            public string CodSeloIpi { get; set; }

            /// <summary>
            ///     Quantidade de selo de controle de IPI aplicada
            /// </summary>
            [SpedCampos(3, "QT_SELO_IPI", "N", 12, 0, true)]
            public double QtSeloIpi { get; set; }
        }

        /// <summary>
        ///     REGISTRO C178: OPERAÇÕES COM PRODUTOS SUJEITOS À TRIBUTAÇÃO DE IPI POR UNIDADE OU QUANTIDADE DE PRODUTO
        /// </summary>
        public class RegistroC178 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC178" />.
            /// </summary>
            public RegistroC178()
            {
                Reg = "C178";
            }

            /// <summary>
            ///     Código da classe de enquadramento do IPI
            /// </summary>
            [SpedCampos(2, "CL_ENQ", "C", 5, 0, true)]
            public string ClEnq { get; set; }

            /// <summary>
            ///     Valor por unidade padrão de tributação
            /// </summary>
            [SpedCampos(3, "VL_UNID", "N", 0, 2, true)]
            public decimal VlUnid { get; set; }

            /// <summary>
            ///     Quantidade total de produtos na unidade padrão de tributação
            /// </summary>
            [SpedCampos(4, "QUANT_PAD", "N", 0, 3, true)]
            public decimal QuantPad { get; set; }
        }

        /// <summary>
        ///     REGISTRO C179: INFORMAÇÕES COMPLEMENTARES ST (CÓDIGO 01)
        /// </summary>
        public class RegistroC179 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC179" />.
            /// </summary>
            public RegistroC179()
            {
                Reg = "C179";
            }

            /// <summary>
            ///     Valor da base de cálculo ST na origem/destino em operações interestaduais
            /// </summary>
            [SpedCampos(2, "BC_ST_ORIG_DEST", "N", 0, 2, true)]
            public decimal BcStOrigDest { get; set; }

            /// <summary>
            ///     Valor do ICMS-ST a repassar/deduzir em operações interestaduais
            /// </summary>
            [SpedCampos(3, "ICMS_ST_REP", "N", 0, 2, true)]
            public decimal IcmsStRep { get; set; }

            /// <summary>
            ///     Valor do ICMS-ST a complementar à UF de destino
            /// </summary>
            [SpedCampos(4, "ICMS_ST_COMPL", "N", 0, 2, false)]
            public decimal IcmsStCompl { get; set; }

            /// <summary>
            ///     Valor da base de cálculo de retenção em remessa promovida por substituído intermediário
            /// </summary>
            [SpedCampos(5, "BC_RET", "N", 0, 2, false)]
            public decimal BcRet { get; set; }

            /// <summary>
            ///     Valor da parcela do imposto retido em remessa promovida por substituído intermediário
            /// </summary>
            [SpedCampos(6, "ICMS_RET", "N", 0, 2, false)]
            public decimal IcmsRet { get; set; }
        }

        public class RegistroC180 : RegistroBaseSped
        {
            public RegistroC180()
            {
                Reg = "C180";
            }

            [SpedCampos(2, "COD_RESP_RET", "N", 1, 0, true)]
            public int CodRespRet { get; set; }

            [SpedCampos(3, "QUANT_CONV", "N", 9, 6, true)]
            public decimal QuantConv { get; set; }

            [SpedCampos(4, "UNID", "C", 100, 0, true)]
            public string Unid { get; set; }

            [SpedCampos(5, "VL_UNIT_CONV", "N", 9, 6, true)]
            public decimal VlUnitConv { get; set; }

            [SpedCampos(6, "VL_UNIT_ICMS_OP_CONV", "N", 9, 6, true)]
            public decimal VlUnitIcmsOpConv { get; set; }

            [SpedCampos(7, "VL_UNIT_BC_ICMS_ST_CONV", "N", 9, 6, true)]
            public decimal VlUnitBcIcmsStConv { get; set; }

            [SpedCampos(8, "VL_UNIT_ICMS_ST_CONV", "N", 9, 6, true)]
            public decimal VlUnitIcmsStConv { get; set; }

            [SpedCampos(9, "VL_UNIT_FCP_ST_CONV", "N", 9, 6, false)]
            public decimal VlUnitFcpStConv { get; set; }

            [SpedCampos(10, "COD_DA", "C", 100, 0, false)]
            public int CodDa { get; set; }

            [SpedCampos(11, "NUM_DA", "C", 100, 0, false)]
            public string NumDa { get; set; }
        }

        /// <summary>
        ///     REGISTRO C181:INFORMAÇÕES COMPLEMENTARES DAS OPERAÇÕES DE DEVOLUÇÃO DE SAÍDAS DE MERCADORIAS SUJEITAS À SUBSTITUIÇÃO TRIBUTÁRIA (CÓDIGO 01, 1B, 04 e 55).
        /// </summary>
        public class RegistroC181 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC181" />.
            /// </summary>
            public RegistroC181()
            {
                Reg = "C181";
            }

            /// <summary>
            ///     Código do motivo da restituição ou complementação conforme Tabela 5.7
            /// </summary>
            [SpedCampos(2, "COD_MOT_REST_COMPL", "C", 5, 0, true)]
            public int CodMotRestCompl { get; set; }

            /// <summary>
            ///     Quantidade do item
            /// </summary>
            [SpedCampos(3, "QUANT_CONV", "N", 0, 6, true)]
            public int QuantConv { get; set; }

            /// <summary>
            ///    Unidade adotada para informar o campo QUANT_CONV.
            /// </summary>
            [SpedCampos(4, "UNID", "C", 6, 0, true)]
            public int Unid { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal de saída, conforme a tabela indicada no item 4.1.1 
            /// </summary>
            [SpedCampos(5, "COD_MOD_SAIDA", "C", 2, 0, true)]
            public int CodModSaida { get; set; }

            /// <summary>
            ///     Número de série do documento de saída em papel 
            /// </summary>
            [SpedCampos(6, "SERIE_SAIDA", "C", 3, 0, false)]
            public int SerieSaida { get; set; }

            /// <summary>
            ///    Número de série de fabricação do equipamento ECF 
            /// </summary>
            [SpedCampos(7, "ECF_FAB_SAIDA", "C", 21, 0, false)]
            public int EcfFabSaida { get; set; }

            /// <summary>
            ///     Número do documento fiscal de saída
            /// </summary>
            [SpedCampos(8, "NUM_DOC_SAIDA", "N", 9, 0, false)]
            public int NumDocSaida { get; set; }

            /// <summary>
            ///    Chave do documento fiscal eletrônico de saída  
            /// </summary>
            [SpedCampos(9, "CHV_DFE_SAIDA", "N", 44, 0, false)]
            public int ChvDfeSaida { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal de saída
            /// </summary>
            [SpedCampos(10, "DT_DOC_SAIDA", "N", 8, 0, true)]
            public int DtDocSaida { get; set; }

            /// <summary>
            ///    Número do item em que foi escriturada a saída em um registro C185, C380, C480 ou C815 quando o contribuinte informar a saída em um arquivo de perfil A.
            /// </summary>
            [SpedCampos(11, "NUM_ITEM_SAIDA", "N", 3, 0, false)]
            public int NumItemSaida { get; set; }

            /// <summary>
            ///    Valor unitário da mercadoria, considerando a unidade utilizada para informar o campo “QUANT_CONV”, correspondente ao valor do campo VL_UNIT_CONV, preenchido na ocasião da saída
            /// </summary>
            [SpedCampos(12, "VL_UNIT_CONV_SAIDA", "N", 0, 6, false)]
            public int VlUnitConvSaida { get; set; }

            /// <summary>
            ///     Valor médio unitário do ICMS OP, das mercadorias em estoque, correspondente ao valor do campo VL_UNIT_ICMS_OP_ESTOQUE_CONV, preenchido na ocasião da saída
            /// </summary>
            [SpedCampos(13, "VL_UNIT_ICMS_OP_ESTOQUE_CONV_SAIDA", "N", 0, 6, false)]
            public int VlUnitIcmsOpEstoqueConvSaida { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS ST, incluindo FCP ST, das mercadorias em estoque, correspondente ao valor do campo VL_UNIT_ICMS_ST_ESTOQUE_CONV, preenchido na ocasião da saída
            /// </summary>
            [SpedCampos(14, "VL_UNIT_ICMS_ST_ESTOQUE_CONV_SAIDA", "N", 0, 6, false)]
            public int VlUnitIcmsStEstoqueConvSaida { get; set; }

            /// <summary>
            ///     Valor médio unitário do FCP ST agregado ao ICMS das mercadorias em estoque, correspondente ao valor do campo VL_UNIT_FCP_ICMS_ST_ESTOQUE_CONV, preenchido na ocasião da saída
            /// </summary>
            [SpedCampos(15, "VL_UNIT_FCP_ICMS_ST_ESTOQUE_CONV_SAIDA", "N", 0, 6, false)]
            public int VlUnitFcpIcmsStEstoqueConvSaida { get; set; }

            /// <summary>
            ///     Valor unitário para o ICMS na operação, correspondente ao valor do campo VL_UNIT_ICMS_NA_OPERACAO_CONV, preenchido na ocasião da saída
            /// </summary>
            [SpedCampos(16, "VL_UNIT_ICMS_NA_OPERACAO_CONV_SAIDA", "N", 0, 6, false)]
            public int VlUnitIcmsNaOperacaoConvSaida { get; set; }

            /// <summary>
            ///     Valor unitário do ICMS correspondente ao valor do campo VL_UNIT_ICMS_OP_CONV, preenchido na ocasião da saída
            /// </summary>
            [SpedCampos(17, "VL_UNIT_ICMS_OP_CONV_SAIDA", "N", 0, 6, false)]
            public int VlUnitIcmsOpConvSaida { get; set; }

            /// <summary>
            ///    Valor unitário do total do ICMS ST, incluindo FCP ST, a ser restituído/ressarcido, correspondente ao estorno do complemento apurado na operação de saída.
            /// </summary>
            [SpedCampos(18, "VL_UNIT_ICMS_ST_CONV_SAIDA", "N", 0, 6, false)]
            public int VlUnitIcmsStConvSaida { get; set; }

            /// <summary>
            ///     Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_REST”, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(19, "VL_UNIT_FCP_ST_CONV_REST", "N", 0, 6, false)]
            public int VlUnitFcpStConvRest { get; set; }

            /// <summary>
            ///    Valor unitário do estorno do ressarcimento/restituição, incluindo FCP ST, apurado na operação de saída.
            /// </summary>
            [SpedCampos(20, "VL_UNIT_ICMS_ST_CONV_COMPL", "N", 0, 6, false)]
            public int VlUnitIcmsStConvCompl { get; set; }

            /// <summary>
            ///   Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_COMPL”, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(21, "VL_UNIT_FCP_ST_CONV_COMPL", "N", 0, 6, false)]
            public int VlUnitFcpStConvCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO C185:INFORMAÇÕES COMPLEMENTARES DAS OPERAÇÕES DE SAÍDA DE MERCADORIAS SUJEITAS À SUBSTITUIÇÃO TRIBUTÁRIA (CÓDIGO 01, 1B, 04, 55 e 65).
        /// </summary>
        public class RegistroC185 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC185" />.
            /// </summary>
            public RegistroC185()
            {
                Reg = "C185";
            }

            [SpedCampos(2, "NUM_ITEM", "N", 3, 0, true)]
            public int NumItem { get; set; }

            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            [SpedCampos(4, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            [SpedCampos(5, "CFOP", "C", 4, 0, true)]
            public string Cfop { get; set; }

            [SpedCampos(6, "COD_MOT_REST_COMPL", "C", 5, 0, true)]
            public string CodMotRestCompl { get; set; }

            [SpedCampos(7, "QUANT_CONV", "N", 9, 6, true)]
            public decimal QuantConv { get; set; }

            [SpedCampos(8, "UNID", "C", 100, 0, true)]
            public string Unid { get; set; }

            [SpedCampos(9, "VL_UNIT_CONV", "N", 9, 6, true)]
            public decimal VlUnitConv { get; set; }

            [SpedCampos(10, "VL_UNIT_ICMS_NA_OPERACAO_CONV", "N", 9, 6, false)]
            public decimal VlUnitIcmsNaOperacaoConv { get; set; }

            [SpedCampos(11, "VL_UNIT_ICMS_OP_CONV", "N", 9, 6, false)]
            public decimal VlUnitIcmsOpConv { get; set; }

            [SpedCampos(12, "VL_UNIT_BC_ICMS_ST_ESTOQUE_CONV", "N", 9, 6, false)]
            public decimal VlUnitBcIcmsStEstoqueConv { get; set; }

            [SpedCampos(13, "VL_UNIT_ICMS_ST_ESTOQUE_CONV", "N", 9, 6, false)]
            public decimal VlUnitIcmsStEstoqueConv { get; set; }

            [SpedCampos(14, "VL_UNIT_FCP_ICMS_ST_ESTOQUE_CONV", "N", 9, 6, false)]
            public decimal VlUnitFcpIcmsStEstoqueConv { get; set; }

            [SpedCampos(15, "VL_UNIT_ICMS_ST_CONV_REST", "N", 9, 6, false)]
            public decimal VlUnitIcmsStConvRest { get; set; }

            [SpedCampos(16, "VL_UNIT_FCP_ST_CONV_REST", "N", 9, 6, false)]
            public decimal VlUnitFcpStConvRest { get; set; }

            [SpedCampos(17, "VL_UNIT_ICMS_ST_CONV_COMPL", "N", 9, 6, false)]
            public decimal VlUnitIcmsStConvCompl { get; set; }

            [SpedCampos(18, "VL_UNIT_FCP_ST_CONV_COMPL", "N", 9, 6, false)]
            public decimal VlUnitFcpStConvCompl { get; set; }

        }
        /// <summary>
        ///     REGISTRO C186:INFORMAÇÕES COMPLEMENTARES DAS OPERAÇÕES DE DEVOLUÇÃO DE ENTRADAS DE MERCADORIAS SUJEITAS À SUBSTITUIÇÃO TRIBUTÁRIA (CÓDIGO 01, 1B, 04 e 55).
        /// </summary>
        public class RegistroC186 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC186" />.
            /// </summary>
            public RegistroC186()
            {
                Reg = "C186";
            }

            /// <summary>
            ///    Número  sequencial do item no documento fiscal de saída
            /// </summary>
            [SpedCampos(2, "NUM_ITEM", "N", 3, 0, true)]
            public int NumItem { get; set; }

            /// <summary>
            ///     Código  do  item  (campo  02  do  Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public int CodItem { get; set; }

            /// <summary>
            ///     Código da Situação Tributária referente ao ICMS no documento fiscal de saída
            /// </summary>
            [SpedCampos(4, "CST_ICMS", "N", 3, 0, true)]
            public string CstIcms { get; set; }

            /// <summary>
            ///    Código  Fiscal  de  Operação  e  Prestação  no documento fiscal de saída
            /// </summary>
            [SpedCampos(5, "CFOP", "N", 4, 0, true)]
            public string Cfop { get; set; }

            /// <summary>
            ///     Código do motivo da  restituição ou complementação conforme Tabela 5.7
            /// </summary>
            [SpedCampos(6, "COD_MOT_REST_COMPL", "C", 5, 0, true)]
            public string CodMotRestCompl { get; set; }

            /// <summary>
            ///    Quantidade do item no documento fiscal de saída de acordo com as instruções de preenchimento.
            /// </summary>
            [SpedCampos(7, "QUANT_CONV", "N", 0, 6, true)]
            public decimal QuantConv { get; set; }

            /// <summary>
            ///     Unidade adotada para informar o campo QUANT_CONV.
            /// </summary>
            [SpedCampos(8, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal de entrada, conforme a tabela indicada no item 4.1.1 
            /// </summary>
            [SpedCampos(9, "COD_MOD_ENTRADA", "C", 2, 0, true)]
            public string CodModEntrada { get; set; }

            /// <summary>
            ///    Número de série do documento de entrada em papel
            /// </summary>
            [SpedCampos(10, "SERIE_ENTRADA", "C", 3, 0, false)]
            public string SerieEntrada { get; set; }

            /// <summary>
            ///    Número do documento fiscal de entrada
            /// </summary>
            [SpedCampos(11, "NUM_DOC_ENTRADA", "N", 9, 0, false)]
            public decimal NumDocEntrada { get; set; }

            /// <summary>
            ///     Chave do documento fiscal eletrônico de entrada 
            /// </summary>
            [SpedCampos(12, "CHV_DFE_ENTRADA", "N", 44, 0, false)]
            public string ChvDfeEntrada { get; set; }

            /// <summary>
            ///   Data da emissão do documento fiscal de entrada
            /// </summary>
            [SpedCampos(13, "DT_DOC_ENTRADA", "N", 8, 0, true)]
            public string DtDocEntrada { get; set; }

            /// <summary>
            ///   Item do documento fiscal de entrada
            /// </summary>
            [SpedCampos(14, "NUM_ITEM_ENTRADA", "N", 3, 0, true)]
            public string NumItemEntrada { get; set; }

            /// <summary>
            ///    Valor unitário da mercadoria, considerando a unidade utilizada para informar o campo “QUANT_CONV”, correspondente ao valor do campo VL_UNIT_CONV, preenchido na ocasião da entrada
            /// </summary>
            [SpedCampos(15, "VL_UNIT_CONV_ENTRADA", "N", 0, 6, false)]
            public string VlUnitConvEntrada { get; set; }

            /// <summary>
            ///   Valor unitário do ICMS correspondente ao valor do campo VL_UNIT_ICMS_OP_CONV,  preenchido na ocasião da entrada
            /// </summary>
            [SpedCampos(16, "VL_UNIT_ICMS_OP_CONV_ENTRADA", "N", 0, 6, false)]
            public string VlUnitIcmsOpConvEntrada { get; set; }

            /// <summary>
            ///    Valor unitário da base de cálculo doimposto pago ou retido anteriormentepor substituição, correspondente ao valor do campo VL_UNIT_BC_ICMS_ST_CONV, preenchido na ocasião da entrada
            /// </summary>
            [SpedCampos(17, "VL_UNIT_BC_ICMS_ST_CONV_ENTRADA", "N", 0, 6, false)]
            public string VlUnitBcIcmsStConvEntrada { get; set; }

            /// <summary>
            ///    Valor unitário do imposto pago ou retido anteriormente por substituição, inclusive FCP se devido, correspondente ao valor do campo VL_UNIT_ICMS_ST_CONV, preenchido na ocasião da entrada
            /// </summary>
            [SpedCampos(18, "VL_UNIT_ICMS_ST_CONV_ENTRADA", "N", 0, 6, false)]
            public string VlUnitIcmsStConvEntrada { get; set; }

            /// <summary>
            ///   Valor unitário do FCP_ST, correspondente ao valor do campo VL_UNIT_FCP_ST_CONV, preenchido na ocasião da entrada
            /// </summary>
            [SpedCampos(19, "VL_UNIT_FCP_ST_CONV_ENTRADA", "N", 0, 6, false)]
            public string VlUnitFcpStConvEntrada { get; set; }
        }

        /// <summary>
        ///     REGISTRO C190: REGISTRO ANALÍTICO DO DOCUMENTO (CÓDIGO 01, 1B, 04, 55 e 65)
        /// </summary>
        public class RegistroC190 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC190" />.
            /// </summary>
            public RegistroC190()
            {
                Reg = "C190";
            }

            /// <summary>
            ///     Código da situação tributária do ICMS
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação do agrupamento de itens
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, true)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor da operação na combinação de CST_ICMS, CFOP e alíquota do ICMS,
            ///     correspondente ao somatório do valor das mercadorias, despesas acessórias
            ///     (frete, seguros e outras despesas acessórias), ICMS_ST e IPI.
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor da base de cálculo do ICMS" referente à
            ///     combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do ICMS" referente à combinação de CST_ICMS,
            ///     CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor da base de cálculo do ICMS" da substituição
            ///     tributária referente à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(8, "VL_BC_ICMS_ST", "N", 0, 2, true)]
            public decimal VlBcIcmsSt { get; set; }

            /// <summary>
            ///     Parcela correspondente ao valor creditado/debitado do ICMS da substituição
            ///     tributária, referente à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(9, "VL_ICMS_ST", "N", 0, 2, true)]
            public decimal VlIcmsSt { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do ICMS, referente
            ///     à combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(10, "VL_RED_BC", "N", 0, 2, true)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do IPI" referente à combinação CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(11, "VL_IPI", "N", 0, 2, true)]
            public decimal VlIpi { get; set; }

            /// <summary>
            ///     Código da observação do lançamento fiscal
            /// </summary>
            [SpedCampos(12, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }

            public RegistroC191 RegC191 { get; set; }
        }

        /// <summary>
        ///     REGISTRO C191: INFORMAÇÕES DO FUNDO DE COMBATE À POBREZA – FCP – NA NF-e (CÓDIGO 55) E NA NFC-E (CÓDIGO 65)
        /// </summary>
        public class RegistroC191 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC191" />.
            /// </summary>
            public RegistroC191()
            {
                Reg = "C191";
            }

            /// <summary>
            ///    Valor do Fundo de Combate à Pobreza (FCP) vinculado à operação própria, na combinação de CST_ICMS, CFOP ealíquota do ICMS
            /// </summary>
            [SpedCampos(2, "VL_FCP_OP", "N", 0, 2, false)]
            public decimal VlFcpOp { get; set; }

            /// <summary>
            ///    Valor do Fundo de Combate à Pobreza (FCP) vinculado à operação de substituição tributária, na combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(3, "VL_FCP_ST", "N", 0, 2, false)]
            public decimal VlFcpSt { get; set; }

            /// <summary>
            ///   Valor relativo ao Fundo de Combate à Pobreza (FCP) retido anteriormente nas operações com SubstituiçãoTributárias, na combinação de CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "VL_FCP_RET", "N", 0, 2, false)]
            public decimal VlFcpRet { get; set; }
        }

        /// <summary>
        ///     REGISTRO C195: OBSERVAÇOES DO LANÇAMENTO FISCAL (CÓDIGO 01, 1B, 04 E 55)
        /// </summary>
        public class RegistroC195 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC195" />.
            /// </summary>
            public RegistroC195()
            {
                Reg = "C195";
            }

            /// <summary>
            ///     Código da observação do lançamento fiscal
            /// </summary>
            [SpedCampos(2, "COD_OBS", "C", 6, 0, true)]
            public string CodObs { get; set; }

            /// <summary>
            ///     Descrição complementar do código de observação
            /// </summary>
            [SpedCampos(3, "TXT_COMPL", "C", 999, 0, false)]
            public string TxtCompl { get; set; }

            public List<RegistroC197> RegC197s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C197: OUTRAS OBRIGAÇÕES TRIBUTÁRIAS, AJUSTES E INFORMAÇÕES DE VALORES PROVENIENTES DE DOCUMENTO FISCAL.
        /// </summary>
        public class RegistroC197 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC197" />.
            /// </summary>
            public RegistroC197()
            {
                Reg = "C197";
            }

            /// <summary>
            ///     Código do ajuste/benefício/incentivo
            /// </summary>
            [SpedCampos(2, "COD_AJ", "C", 10, 0, true)]
            public string CodAj { get; set; }

            /// <summary>
            ///     Descrição complementar do ajuste do documento fiscal
            /// </summary>
            [SpedCampos(3, "DESCR_COMPL_AJ", "C", 999, 0, false)]
            public string DescrComplAj { get; set; }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(4, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Base de cálculo do ICMS ou do ICMS ST
            /// </summary>
            [SpedCampos(5, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS ou do ICMS ST
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Outros valores
            /// </summary>
            [SpedCampos(8, "VL_OUTROS", "N", 0, 2, false)]
            public decimal VlOutros { get; set; }
        }

        /// <summary>
        ///     REGISTRO C300: RESUMO DIÁRIO DAS NOTAS FISCAIS DE VENDA A CONSUMIDOR (CÓDIGO 02)
        /// </summary>
        public class RegistroC300 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC300" />.
            /// </summary>
            public RegistroC300()
            {
                Reg = "C300";
            }

            /// <summary>
            ///     Código do modelo do docuemnto fiscal
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public int CodMod { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(3, "SER", "C", 4, 0, true)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(4, "SUB", "C", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal inicial
            /// </summary>
            [SpedCampos(5, "NUM_DOC_INI", "N", 6, 0, true)]
            public int NumDocIni { get; set; }

            /// <summary>
            ///     Número do documento fical final
            /// </summary>
            [SpedCampos(6, "NUM_DOC_FIN", "N", 6, 0, true)]
            public int NumDocFin { get; set; }

            /// <summary>
            ///     Data da emissão dos documentos fiscais
            /// </summary>
            [SpedCampos(7, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Valor total dos documentos
            /// </summary>
            [SpedCampos(8, "VL_DOC", "N", 0, 2, true)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Valor total do PIS
            /// </summary>
            [SpedCampos(9, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor total da COFINS
            /// </summary>
            [SpedCampos(10, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(11, "COD_CTA", "C", 999, 0, false)]
            public string CodCta { get; set; }

            public List<RegistroC310> RegC310s { get; set; }
            public List<RegistroC320> RegC320s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C310: DOCUMENTOS CANCELADOS DE NOTAS FISCAIS DE VENDA A CONSUMIDOR (CÓDIGO 02).
        /// </summary>
        public class RegistroC310 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC310" />.
            /// </summary>
            public RegistroC310()
            {
                Reg = "C310";
            }

            /// <summary>
            ///     Número do documento fiscal cancelado
            /// </summary>
            [SpedCampos(2, "NUM_DOC_CANC", "N", 999, 0, true)]
            public int NumDocCanc { get; set; }
        }

        /// <summary>
        ///     REGISTRO C320: REGISTRO ANALÍTICO DO RESUMO DIÁRIO DAS NOTAS FISCAIS DE VENDA A CONSUMIDOR (CÓDIGO 02).
        /// </summary>
        public class RegistroC320 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC320" />.
            /// </summary>
            public RegistroC320()
            {
                Reg = "C320";
            }

            /// <summary>
            ///     Código da situação tributária referente  ao ICMS
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal da operação e prestação
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor total acumulado das operações correspondentes à combinação de CST_ICMS, CFOP e alíquota do ICMS, incluídas as
            ///     despesas acessórias e acréscimos
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS, referente à combinação de CST_ICMS, CFOP, alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor acumulado do ICMS, referente à combinação de CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do ICMS, referente à combinação de CST_ICMS, CFOP, e
            ///     alíquota do ICMS
            /// </summary>
            [SpedCampos(8, "VL_RED_BC", "N", 0, 2, true)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Código da observação do lançamento fiscal
            /// </summary>
            [SpedCampos(9, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }

            public List<RegistroC321> RegC321s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C321: ITENS DO RESUMO DIÁRIO DOS DOCUMENTOS (CÓDIGO 02)
        /// </summary>
        public class RegistroC321 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC321" />.
            /// </summary>
            public RegistroC321()
            {
                Reg = "C321";
            }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade acumulada do item
            /// </summary>
            [SpedCampos(3, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Unidade do item
            /// </summary>
            [SpedCampos(4, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///     Valor acumulado do item
            /// </summary>
            [SpedCampos(5, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Valor do desconto acumulado
            /// </summary>
            [SpedCampos(6, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(7, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor acumulado do ICMS debitado
            /// </summary>
            [SpedCampos(8, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor acumulado do PIS
            /// </summary>
            [SpedCampos(9, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor acumulado da COFINS
            /// </summary>
            [SpedCampos(10, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            public RegistroC330 RegC1330 { get; set; }

        }
        /// <summary>
        ///     REGISTRO C330: INFORMAÇÕES COMPLEMENTARES DAS OPERAÇÕES DE SAÍDA DE MERCADORIAS SUJEITAS À SUBSTITUIÇÃO TRIBUTÁRIA (CÓDIGO 02)
        /// </summary>
        public class RegistroC330 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC330" />.
            /// </summary>
            public RegistroC330()
            {
                Reg = "C330";
            }

            /// <summary>
            ///    Código do motivo  da restituição ou complementação conforme Tabela 5.7
            /// </summary>
            [SpedCampos(2, "COD_MOT_REST_COMPL", "C", 5, 0, true)]
            public int CodMotRestCompl { get; set; }

            /// <summary>
            ///   Quantidade do item 
            /// </summary>
            [SpedCampos(3, "QUANT_CONV", "N", 0, 6, true)]
            public int QuantConv { get; set; }

            /// <summary>
            ///    Unidade adotada para informar o campo QUANT_CONV.
            /// </summary>
            [SpedCampos(4, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///    Valor unitário da mercadoria, considerando a  unidade  utilizada  para  informar  o  campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(5, "VL_UNIT_CONV", "N", 0, 6, true)]
            public string VlUnitConv { get; set; }

            /// <summary>
            ///     Valor unitário para o ICMS na operação, caso não houvesse a ST, considerando unidade utilizada para informar o campo “QUANT_CONV”, aplicando-se a mesma redução da base de cálculo do ICMS ST na tributação, se houver.
            /// </summary>
            [SpedCampos(6, "VL_UNIT_ICMS_NA_OPERACAO_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsNaOperacaoConv { get; set; }

            /// <summary>
            ///   Valor unitário do ICMS OP calculado conforme a legislação de cada UF,considerando a unidade utilizada para informar o campo “QUANT_CONV”, utilizado para cálculo de ressarcimento/restituição de ST, no desfazimento da substituição tributária, quando se utiliza a fórmula descrita nas instruções de preenchimento do campo 11, no item a1).
            /// </summary>
            [SpedCampos(7, "VL_UNIT_ICMS_OP_CONV", "N", 0, 6, false)]
            public decimal VlUnitIcmsOpConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS que o contribuinte teria se creditado referente à operação de entrada das mercadorias em estoque caso estivesse submetida ao regime comum de tributação, calculado conforme a legislação de cada UF,considerando a unidade utilizada para informar o campo “QUANT_CONV”
            /// </summary>
            [SpedCampos(8, "VL_UNIT_ICMS_OP_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsOpEstoqueConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS ST, incluindo FCP ST, das mercadorias em estoque, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(9, "VL_UNIT_ICMS_ST_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsStEstoqueConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do FCP ST agregado ao ICMS das mercadorias em estoque, considerando unidade utilizada parainformar o campo “QUANT_CONV”
            /// </summary>
            [SpedCampos(10, "VL_UNIT_FCP_ICMS_ST_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitFcpIcmsStEstoqueConv { get; set; }

            /// <summary>
            ///    Valor unitário do total do ICMS ST, incluindo FCP ST, a ser restituído/ressarcido, calculado conforme a legislação de cada  UF,  considerando  a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(11, "VL_UNIT_ICMS_ST_CONV_REST", "N", 0, 6, false)]
            public decimal VlUnitIcmsStConvRest { get; set; }

            /// <summary>
            ///    Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_REST”, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(12, "VL_UNIT_FCP_ST_CONV_REST", "N", 0, 6, false)]
            public string VlUnitFcpStConvRest { get; set; }

            /// <summary>
            ///   Valor unitário do complemento do ICMS, incluindo FCP ST, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(13, "VL_UNIT_ICMS_ST_CONV_COMPL", "N", 0, 6, false)]
            public string VlUnitIcmsStConvCompl { get; set; }

            /// <summary>
            ///   Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_COMPL”, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(14, "VL_UNIT_FCP_ST_CONV_COMPL", "N", 0, 6, false)]
            public string VlUnitFcpStConvCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO C350: NOTA FISCAL DE VENDA A CONSUMIDOR (CÓDIGO 02)
        /// </summary>
        public class RegistroC350 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC350" />.
            /// </summary>
            public RegistroC350()
            {
                Reg = "C350";
            }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(2, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(3, "SUB_SER", "C", 3, 0, false)]
            public string SubSer { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(4, "NUM_DOC", "C", 3, 0, true)]
            public int NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(5, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     CNPJ ou CPF do destinatário
            /// </summary>
            [SpedCampos(6, "CNPJ_CPF", "N", 14, 0, false)]
            public string CnpjCpf { get; set; }

            /// <summary>
            ///     Valor das mercadorias constatnes no documento fiscal
            /// </summary>
            [SpedCampos(7, "VL_MERC", "N", 0, 2, true)]
            public decimal VlMerc { get; set; }

            /// <summary>
            ///     Valor total do documento fiscal
            /// </summary>
            [SpedCampos(8, "VL_DOC", "N", 0, 2, true)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(9, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Valor total do PIS
            /// </summary>
            [SpedCampos(10, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor total da COFINS
            /// </summary>
            [SpedCampos(11, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(12, "COD_CTA", "C", 999, 0, false)]
            public string CodCta { get; set; }

            public List<RegistroC370> RegC370s { get; set; }
            public List<RegistroC370> RegC390s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C370: ITENS DO DOCUMENTO (CÓDIGO 02)
        /// </summary>
        public class RegistroC370 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC370" />.
            /// </summary>
            public RegistroC370()
            {
                Reg = "C370";
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
            ///     Quantidade do item
            /// </summary>
            [SpedCampos(4, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Unidade do item
            /// </summary>
            [SpedCampos(5, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///     Valor total do item
            /// </summary>
            [SpedCampos(6, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Valor total do desconto no item
            /// </summary>
            [SpedCampos(7, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            public RegistroC380 RegC380 { get; set; }

        }

        /// <summary>
        ///     REGISTRO C380: INFORMAÇÕES COMPLEMENTARES DAS OPERAÇÕES DE SAÍDA DE MERCADORIAS SUJEITAS À SUBSTITUIÇÃO TRIBUTÁRIA (CÓDIGO 02)
        /// </summary>
        public class RegistroC380 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC380" />.
            /// </summary>
            public RegistroC380()
            {
                Reg = "C380";
            }

            /// <summary>
            ///    Código do motivo  da restituição ou complementação conforme Tabela 5.7
            /// </summary>
            [SpedCampos(2, "COD_MOT_REST_COMPL", "C", 5, 0, true)]
            public int CodMotRestCompl { get; set; }

            /// <summary>
            ///   Quantidade do item 
            /// </summary>
            [SpedCampos(3, "QUANT_CONV", "N", 0, 6, true)]
            public int QuantConv { get; set; }

            /// <summary>
            ///    Unidade adotada para informar o campo QUANT_CONV.
            /// </summary>
            [SpedCampos(4, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///    Valor unitário da mercadoria, considerando a  unidade  utilizada  para  informar  o  campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(5, "VL_UNIT_CONV", "N", 0, 6, true)]
            public string VlUnitConv { get; set; }

            /// <summary>
            ///     Valor unitário para o ICMS na operação, caso não houvesse a ST, considerando unidade utilizada para informar o campo “QUANT_CONV”, aplicando-se a mesma redução da base de cálculo do ICMS ST na tributação, se houver.
            /// </summary>
            [SpedCampos(6, "VL_UNIT_ICMS_NA_OPERACAO_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsNaOperacaoConv { get; set; }

            /// <summary>
            ///   Valor unitário do ICMS OP calculado conforme a legislação de cada UF,considerando a unidade utilizada para informar o campo “QUANT_CONV”, utilizado para cálculo de ressarcimento/restituição de ST, no desfazimento da substituição tributária, quando se utiliza a fórmula descrita nas instruções de preenchimento do campo 11, no item a1).
            /// </summary>
            [SpedCampos(7, "VL_UNIT_ICMS_OP_CONV", "N", 0, 6, false)]
            public decimal VlUnitIcmsOpConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS que o contribuinte teria se creditado referente à operação de entrada das mercadorias em estoque caso estivesse submetida ao regime comum de tributação, calculado conforme a legislação de cada UF,considerando a unidade utilizada para informar o campo “QUANT_CONV”
            /// </summary>
            [SpedCampos(8, "VL_UNIT_ICMS_OP_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsOpEstoqueConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS ST, incluindo FCP ST, das mercadorias em estoque, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(9, "VL_UNIT_ICMS_ST_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsStEstoqueConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do FCP ST agregado ao ICMS das mercadorias em estoque, considerando unidade utilizada parainformar o campo “QUANT_CONV”
            /// </summary>
            [SpedCampos(10, "VL_UNIT_FCP_ICMS_ST_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitFcpIcmsStEstoqueConv { get; set; }

            /// <summary>
            ///    Valor unitário do total do ICMS ST, incluindo FCP ST, a ser restituído/ressarcido, calculado conforme a legislação de cada  UF,  considerando  a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(11, "VL_UNIT_ICMS_ST_CONV_REST", "N", 0, 6, false)]
            public decimal VlUnitIcmsStConvRest { get; set; }

            /// <summary>
            ///    Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_REST”, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(12, "VL_UNIT_FCP_ST_CONV_REST", "N", 0, 6, false)]
            public string VlUnitFcpStConvRest { get; set; }

            /// <summary>
            ///   Valor unitário do complemento do ICMS, incluindo FCP ST, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(13, "VL_UNIT_ICMS_ST_CONV_COMPL", "N", 0, 6, false)]
            public string VlUnitIcmsStConvCompl { get; set; }

            /// <summary>
            ///   Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_COMPL”, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(14, "VL_UNIT_FCP_ST_CONV_COMPL", "N", 0, 6, false)]
            public string VlUnitFcpStConvCompl { get; set; }

            /// <summary>
            ///     Código da situação tributária referente ao ICMS
            /// </summary>
            [SpedCampos(15, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal da operação e prestação
            /// </summary>
            [SpedCampos(16, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }
        }

        /// <summary>
        ///     REGISTRO C390: REGISTRO ANALÍTICO DAS NOTAS FISCAIS DE VENDA A CONSUMIDOR (CÓDIGO 02)
        /// </summary>
        public class RegistroC390 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC390" />.
            /// </summary>
            public RegistroC390()
            {
                Reg = "C390";
            }

            /// <summary>
            ///     Código da situação tributária
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal da operação e prestação
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor total acumulado das operações correspondentes à combinação de CST_ICMS, CFOP e alíquota do ICMS, incluídas as
            ///     despesas acessórias e acréscimos
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS, referente à combinação de CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor acumulado do ICMS, referente à combinação de CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do ICMS, referente à combinação de CST_ICMS, CFOP e
            ///     alíquota do ICMS
            /// </summary>
            [SpedCampos(8, "VL_RED_BC", "N", 0, 2, false)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Código da observação do lançamento fiscal
            /// </summary>
            [SpedCampos(9, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO C400: EQUIPAMENTO ECF (CÓDIGO 02, 2D e 60).
        /// </summary>
        public class RegistroC400 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC400" />.
            /// </summary>
            public RegistroC400()
            {
                Reg = "C400";
            }

            /// <summary>
            ///     Código do modelo do documento fiscal
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
            ///     Número de caixa atribuído ao ECF
            /// </summary>
            [SpedCampos(5, "ECF_CX", "N", 3, 0, true)]
            public int EcfCx { get; set; }

            public List<RegistroC405> RegC405s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C405: REDUÇÃO Z (CÓDIGO 02, 2D e 60).
        /// </summary>
        public class RegistroC405 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC405" />.
            /// </summary>
            public RegistroC405()
            {
                Reg = "C405";
            }

            /// <summary>
            ///     Data do movimento a que se refere a redução Z
            /// </summary>
            [SpedCampos(2, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Posição do Contador de Reinício de Operação
            /// </summary>
            [SpedCampos(3, "CRO", "N", 3, 0, true)]
            public int Cro { get; set; }

            /// <summary>
            ///     Posição do Contador de Redução Z
            /// </summary>
            [SpedCampos(4, "CRZ", "N", 6, 0, true)]
            public int Crz { get; set; }

            /// <summary>
            ///     Número do Contador de Ordem de Operação do último documento emitido no dia (Número do COO na Redução Z)
            /// </summary>
            [SpedCampos(5, "NUM_COO_FIN", "N", 9, 0, true)]
            public double NumCoofin { get; set; }

            /// <summary>
            ///     Valor do Grante Total Final
            /// </summary>
            [SpedCampos(6, "GT_FIN", "N", 0, 2, true)]
            public decimal GtFin { get; set; }

            /// <summary>
            ///     Valor da venda bruta
            /// </summary>
            [SpedCampos(7, "VL_BRT", "N", 0, 2, true)]
            public decimal VlBrt { get; set; }

            public List<RegistroC410> RegC410s { get; set; }
            public List<RegistroC420> RegC420s { get; set; }
            public List<RegistroC460> RegC460s { get; set; }
            public List<RegistroC490> RegC490s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C410: PIS E COFINS TOTALIZADOS NO DIA (CÓDIGO 02 e 2D).
        /// </summary>
        public class RegistroC410 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC410" />.
            /// </summary>
            public RegistroC410()
            {
                Reg = "C410";
            }

            /// <summary>
            ///     Valor total do PIS
            /// </summary>
            [SpedCampos(2, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor total da COFINS
            /// </summary>
            [SpedCampos(3, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }
        }

        /// <summary>
        ///     REGISTRO C420: REGISTRO DOS TOTALIZADORES PARCIAIS DA REDUÇÃO Z (COD 02, 2D e 60).
        /// </summary>
        public class RegistroC420 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC420" />.
            /// </summary>
            public RegistroC420()
            {
                Reg = "C420";
            }

            /// <summary>
            ///     Código do totalizador
            /// </summary>
            [SpedCampos(2, "COD_TOT_PAR", "C", 7, 0, true)]
            public string CodTotPar { get; set; }

            /// <summary>
            ///     Valor acumulado no totalizador, relativo à respectiva Redução Z
            /// </summary>
            [SpedCampos(3, "VLR_ACUM_TOT", "N", 0, 2, true)]
            public decimal VlrAcumTot { get; set; }

            /// <summary>
            ///     Número do totalizador quando ocorrer mais de uma situação com a mesma carga tributária efetiva
            /// </summary>
            [SpedCampos(4, "NR_TOT", "BLANK", 2, 0, false)]
            public int? NrTot { get; set; }

            /// <summary>
            ///     Descrição da situação tributária relativa ao totalizador parcial, quando houver mais de um com a mesma carga
            ///     tributária efetiva
            /// </summary>
            [SpedCampos(5, "DESCR_NR_TOT", "C", 999, 0, false)]
            public string DescrNrTot { get; set; }

            public List<RegistroC425> RegC425s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C425: RESUMO DE ITENS DO MOVIMENTO DIÁRIO (CÓDIGO 02 e 2D).
        /// </summary>
        public class RegistroC425 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC425" />.
            /// </summary>
            public RegistroC425()
            {
                Reg = "C425";
            }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade acumulada do item
            /// </summary>
            [SpedCampos(3, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Unidade do item
            /// </summary>
            [SpedCampos(4, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///     Valor acumulado do item
            /// </summary>
            [SpedCampos(5, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(6, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Vaor da COFINS
            /// </summary>
            [SpedCampos(7, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            public List<RegistroC430> RegC430 { get; set; }

        }

        /// <summary>
        ///     REGISTRO C430: INFORMAÇÕES COMPLEMENTARES DAS OPERAÇÕES DE SAÍDA DE MERCADORIAS SUJEITAS À SUBSTITUIÇÃO TRIBUTÁRIA (CÓDIGO 02, 2D e 60).
        /// </summary>
        public class RegistroC430 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC430" />.
            /// </summary>
            public RegistroC430()
            {
                Reg = "C430";
            }

            /// <summary>
            ///    Código do motivo  da restituição ou complementação conforme Tabela 5.7
            /// </summary>
            [SpedCampos(2, "COD_MOT_REST_COMPL", "C", 5, 0, true)]
            public int CodMotRestCompl { get; set; }

            /// <summary>
            ///   Quantidade do item 
            /// </summary>
            [SpedCampos(3, "QUANT_CONV", "N", 0, 6, true)]
            public int QuantConv { get; set; }

            /// <summary>
            ///    Unidade adotada para informar o campo QUANT_CONV.
            /// </summary>
            [SpedCampos(4, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///    Valor unitário da mercadoria, considerando a  unidade  utilizada  para  informar  o  campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(5, "VL_UNIT_CONV", "N", 0, 6, true)]
            public string VlUnitConv { get; set; }

            /// <summary>
            ///     Valor unitário para o ICMS na operação, caso não houvesse a ST, considerando unidade utilizada para informar o campo “QUANT_CONV”, aplicando-se a mesma redução da base de cálculo do ICMS ST na tributação, se houver.
            /// </summary>
            [SpedCampos(6, "VL_UNIT_ICMS_NA_OPERACAO_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsNaOperacaoConv { get; set; }

            /// <summary>
            ///   Valor unitário do ICMS OP calculado conforme a legislação de cada UF,considerando a unidade utilizada para informar o campo “QUANT_CONV”, utilizado para cálculo de ressarcimento/restituição de ST, no desfazimento da substituição tributária, quando se utiliza a fórmula descrita nas instruções de preenchimento do campo 11, no item a1).
            /// </summary>
            [SpedCampos(7, "VL_UNIT_ICMS_OP_CONV", "N", 0, 6, false)]
            public decimal VlUnitIcmsOpConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS que o contribuinte teria se creditado referente à operação de entrada das mercadorias em estoque caso estivesse submetida ao regime comum de tributação, calculado conforme a legislação de cada UF,considerando a unidade utilizada para informar o campo “QUANT_CONV”
            /// </summary>
            [SpedCampos(8, "VL_UNIT_ICMS_OP_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsOpEstoqueConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS ST, incluindo FCP ST, das mercadorias em estoque, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(9, "VL_UNIT_ICMS_ST_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsStEstoqueConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do FCP ST agregado ao ICMS das mercadorias em estoque, considerando unidade utilizada parainformar o campo “QUANT_CONV”
            /// </summary>
            [SpedCampos(10, "VL_UNIT_FCP_ICMS_ST_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitFcpIcmsStEstoqueConv { get; set; }

            /// <summary>
            ///    Valor unitário do total do ICMS ST, incluindo FCP ST, a ser restituído/ressarcido, calculado conforme a legislação de cada  UF,  considerando  a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(11, "VL_UNIT_ICMS_ST_CONV_REST", "N", 0, 6, false)]
            public decimal VlUnitIcmsStConvRest { get; set; }

            /// <summary>
            ///    Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_REST”, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(12, "VL_UNIT_FCP_ST_CONV_REST", "N", 0, 6, false)]
            public string VlUnitFcpStConvRest { get; set; }

            /// <summary>
            ///   Valor unitário do complemento do ICMS, incluindo FCP ST, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(13, "VL_UNIT_ICMS_ST_CONV_COMPL", "N", 0, 6, false)]
            public string VlUnitIcmsStConvCompl { get; set; }

            /// <summary>
            ///   Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_COMPL”, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(14, "VL_UNIT_FCP_ST_CONV_COMPL", "N", 0, 6, false)]
            public string VlUnitFcpStConvCompl { get; set; }

            /// <summary>
            ///     Código da situação tributária referente ao ICMS
            /// </summary>
            [SpedCampos(15, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal da operação e prestação
            /// </summary>
            [SpedCampos(16, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }
        }

        /// <summary>
        ///     REGISTRO C460: DOCUMENTO FISCAL EMITIDO POR ECF (CÓDIGO 02, 2D e 60).
        /// </summary>
        public class RegistroC460 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC460" />.
            /// </summary>
            public RegistroC460()
            {
                Reg = "C460";
            }

            /// <summary>
            ///     Código do modelo do documento fiscal
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código de situação do documento fiscal
            /// </summary>
            [SpedCampos(3, "COD_SIT", "N", 2, 0, true)]
            public int CodSit { get; set; }

            /// <summary>
            ///     Número do documento fiscal (COO)
            /// </summary>
            [SpedCampos(4, "NUM_DOC", "N", 9, 0, true)]
            public double NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(5, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Valor total do documento fiscal
            /// </summary>
            [SpedCampos(6, "VL_DOC", "N", 0, 2, true)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(7, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(8, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     CPF ou CNPJ do adquirente
            /// </summary>
            [SpedCampos(9, "CPF_CNPJ", "N", 14, 0, false)]
            public string CpfCnpj { get; set; }

            /// <summary>
            ///     Nome do adquirente
            /// </summary>
            [SpedCampos(10, "NOM_ADQ", "C", 60, 0, false)]
            public string NomeAdq { get; set; }

            public RegistroC465 RegC465 { get; set; }
            public List<RegistroC470> RegC470s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C465: COMPLEMENTO DO CUPOM FISCAL ELETRÔNICO EMITIDO POR ECF – CF-e-ECF (CÓDIGO 60).
        /// </summary>
        public class RegistroC465 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC465" />.
            /// </summary>
            public RegistroC465()
            {
                Reg = "C465";
            }

            /// <summary>
            ///     Chave do cupom fiscal eletrônico
            /// </summary>
            [SpedCampos(2, "CHV_CFE", "N", 44, 0, true)]
            public string ChvCfe { get; set; }

            /// <summary>
            ///     Número do contador de cupom fiscal
            /// </summary>
            [SpedCampos(3, "NUM_CCF", "N", 9, 0, true)]
            public double NumCcf { get; set; }
        }

        /// <summary>
        ///     REGISTRO C470: ITENS DO DOCUMENTO FISCAL EMITIDO POR ECF (CÓDIGO 02 e 2D).
        /// </summary>
        public class RegistroC470 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC470" />.
            /// </summary>
            public RegistroC470()
            {
                Reg = "C470";
            }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade do item
            /// </summary>
            [SpedCampos(3, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Quantidade cancelada, no caso de cancelamento parcial do item
            /// </summary>
            [SpedCampos(4, "QTD_CANC", "N", 0, 3, false)]
            public decimal QtdCanc { get; set; }

            /// <summary>
            ///     Unidade do item
            /// </summary>
            [SpedCampos(5, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///     Valor total do item
            /// </summary>
            [SpedCampos(6, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Código da situação tributária
            /// </summary>
            [SpedCampos(7, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(8, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS - carga tributária efetiva em percentual
            /// </summary>
            [SpedCampos(9, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(10, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(11, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            public RegistroC480 RegC480 { get; set; }
        }

        /// <summary>
        ///     REGISTRO C480: INFORMAÇÕES COMPLEMENTARES DAS OPERAÇÕES DE SAÍDA DE MERCADORIAS SUJEITAS À SUBSTITUIÇÃO TRIBUTÁRIA (CÓDIGO 02, 2D e 60).
        /// </summary>
        public class RegistroC480 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC480" />.
            /// </summary>
            public RegistroC480()
            {
                Reg = "C480";
            }

            /// <summary>
            ///    Código do motivo  da restituição ou complementação conforme Tabela 5.7
            /// </summary>
            [SpedCampos(2, "COD_MOT_REST_COMPL", "C", 5, 0, true)]
            public int CodMotRestCompl { get; set; }

            /// <summary>
            ///   Quantidade do item 
            /// </summary>
            [SpedCampos(3, "QUANT_CONV", "N", 0, 6, true)]
            public int QuantConv { get; set; }

            /// <summary>
            ///    Unidade adotada para informar o campo QUANT_CONV.
            /// </summary>
            [SpedCampos(4, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///    Valor unitário da mercadoria, considerando a  unidade  utilizada  para  informar  o  campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(5, "VL_UNIT_CONV", "N", 0, 6, true)]
            public string VlUnitConv { get; set; }

            /// <summary>
            ///     Valor unitário para o ICMS na operação, caso não houvesse a ST, considerando unidade utilizada para informar o campo “QUANT_CONV”, aplicando-se a mesma redução da base de cálculo do ICMS ST na tributação, se houver.
            /// </summary>
            [SpedCampos(6, "VL_UNIT_ICMS_NA_OPERACAO_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsNaOperacaoConv { get; set; }

            /// <summary>
            ///   Valor unitário do ICMS OP calculado conforme a legislação de cada UF,considerando a unidade utilizada para informar o campo “QUANT_CONV”, utilizado para cálculo de ressarcimento/restituição de ST, no desfazimento da substituição tributária, quando se utiliza a fórmula descrita nas instruções de preenchimento do campo 11, no item a1).
            /// </summary>
            [SpedCampos(7, "VL_UNIT_ICMS_OP_CONV", "N", 0, 6, false)]
            public decimal VlUnitIcmsOpConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS que o contribuinte teria se creditado referente à operação de entrada das mercadorias em estoque caso estivesse submetida ao regime comum de tributação, calculado conforme a legislação de cada UF,considerando a unidade utilizada para informar o campo “QUANT_CONV”
            /// </summary>
            [SpedCampos(8, "VL_UNIT_ICMS_OP_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsOpEstoqueConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS ST, incluindo FCP ST, das mercadorias em estoque, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(9, "VL_UNIT_ICMS_ST_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsStEstoqueConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do FCP ST agregado ao ICMS das mercadorias em estoque, considerando unidade utilizada parainformar o campo “QUANT_CONV”
            /// </summary>
            [SpedCampos(10, "VL_UNIT_FCP_ICMS_ST_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitFcpIcmsStEstoqueConv { get; set; }

            /// <summary>
            ///    Valor unitário do total do ICMS ST, incluindo FCP ST, a ser restituído/ressarcido, calculado conforme a legislação de cada  UF,  considerando  a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(11, "VL_UNIT_ICMS_ST_CONV_REST", "N", 0, 6, false)]
            public decimal VlUnitIcmsStConvRest { get; set; }

            /// <summary>
            ///    Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_REST”, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(12, "VL_UNIT_FCP_ST_CONV_REST", "N", 0, 6, false)]
            public string VlUnitFcpStConvRest { get; set; }

            /// <summary>
            ///   Valor unitário do complemento do ICMS, incluindo FCP ST, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(13, "VL_UNIT_ICMS_ST_CONV_COMPL", "N", 0, 6, false)]
            public string VlUnitIcmsStConvCompl { get; set; }

            /// <summary>
            ///   Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_COMPL”, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(14, "VL_UNIT_FCP_ST_CONV_COMPL", "N", 0, 6, false)]
            public string VlUnitFcpStConvCompl { get; set; }

            /// <summary>
            ///     Código da situação tributária referente ao ICMS
            /// </summary>
            [SpedCampos(15, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal da operação e prestação
            /// </summary>
            [SpedCampos(16, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }
        }

        /// <summary>
        ///     REGISTRO C490: REGISTRO ANALÍTICO DO MOVIMENTO DIÁRIO (CÓDIGO 02, 2D e 60).
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
            ///     Código da situação tributária
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor da operação correspondente à combinação de CST_ICMS, CFOP e alíquota do ICMS, incluídas as despesas
            ///     acessórias e acréscimos
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS, referente à combinação de CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor acumulado do ICMS, referente à combinação de CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Código da observação do lançamento fiscal
            /// </summary>
            [SpedCampos(8, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO C495: RESUMO MENSAL DE ITENS DO ECF POR ESTABELECIMENTO (CÓDIGO 02 e 2D).
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
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(2, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade acumulada do item
            /// </summary>
            [SpedCampos(4, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Quantidade cancelada acumulada, no caso de cancelamento parcial do item
            /// </summary>
            [SpedCampos(5, "QTD_CANC", "N", 0, 3, false)]
            public decimal QtdCanc { get; set; }

            /// <summary>
            ///     Unidade do item
            /// </summary>
            [SpedCampos(6, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///     Valor acumulado do item
            /// </summary>
            [SpedCampos(7, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Valor acumulado dos descontos
            /// </summary>
            [SpedCampos(8, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Valor acumulado dos cancelamentos
            /// </summary>
            [SpedCampos(9, "VL_CANC", "N", 0, 2, false)]
            public decimal VlCanc { get; set; }

            /// <summary>
            ///     Valor acumulado dos acréscimos
            /// </summary>
            [SpedCampos(10, "VL_ACMO", "N", 0, 2, false)]
            public decimal VlAcmo { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(11, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor acumulado do ICMS
            /// </summary>
            [SpedCampos(12, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor das saídas isentas do ICMS
            /// </summary>
            [SpedCampos(13, "VL_ISEN", "N", 0, 2, false)]
            public decimal VlIsen { get; set; }

            /// <summary>
            ///     Valor das saídas sob não-incidência ou não-tributadas pelo ICMS
            /// </summary>
            [SpedCampos(14, "VL_NT", "N", 0, 2, false)]
            public decimal VlNt { get; set; }

            /// <summary>
            ///     Valor das aídas de mercadorias adquiridas com substituição tributária do ICMS
            /// </summary>
            [SpedCampos(15, "VL_ICMS_ST", "N", 0, 2, false)]
            public decimal VlIcmsSt { get; set; }
        }

        /// <summary>
        ///     REGISTRO C500: NOTA FISCAL/CONTA DE ENERGIA ELÉTRICA (CÓDIGO 06), NOTA FISCAL/CONTA DE FORNECIMENTO D'ÁGUA CANALIZADA (CÓDIGO 29) E NOTA FISCAL CONSUMO FORNECIMENTO DE GÁS (CÓDIGO 28)
        /// </summary>
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
            ///     Inicializa uma nova instância da classe <see cref="RegistroC500" />.
            /// </summary>
            public RegistroC500(IndClasseConsumoEnergia indConsumoEnergia, IndCodTipoLigacao indTipoLigacao, IndCodGrupoTensao indGrupoTensao)
            {
                Reg = "C500";
                this.CodCons = (int)indConsumoEnergia;
                this.TpLigacao = (int)indTipoLigacao;
                this.CodGrupoTensao = (int)indGrupoTensao;
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC500" />.
            /// </summary>
            public RegistroC500(IndClasseConsumoAgua indConsumoAgua)
            {
                Reg = "C500";
                this.CodCons = (int)indConsumoAgua;
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC500" />.
            /// </summary>
            public RegistroC500(IndClasseConsumoGas indConsumoGas)
            {
                Reg = "C500";
                this.CodCons = (int)indConsumoGas;
            }

            /// <summary>
            ///     Indicador do tipo de operação
            /// </summary>
            /// <remarks>
            ///     0 - Entrada
            ///     <para />
            ///     1 - Saída
            /// </remarks>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true)]
            public IndTipoOperacaoProduto IndOper { get; set; }

            /// <summary>
            ///     Indicador do emitente do documento fiscal
            /// </summary>
            /// <remarks>
            ///     0 - Emissão própria
            ///     <para />
            ///     1 - Terceiros
            /// </remarks>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true)]
            public IndEmitente IndEmit { get; set; }

            /// <summary>
            ///     Código do participante
            /// </summary>
            /// <remarks>
            ///     - do adquirente, no caso das saídas
            ///     <para />
            ///     - do fornecedor no caso de entradas
            /// </remarks>
            [SpedCampos(4, "COD_PART", "C", 60, 0, true)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal
            /// </summary>
            [SpedCampos(5, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal
            /// </summary>
            [SpedCampos(6, "COD_SIT", "N", 2, 0, true)]
            public IndCodSitDoc CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(7, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(8, "SUB", "N", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Código de classe de consumo de energia elétrica ou gás
            /// </summary>
            /// <remarks>
            ///     01 - Comercial
            ///     <para />
            ///     02 - Consumo Próprio
            ///     <para />
            ///     03 - Iluminação Pública
            ///     <para />
            ///     04 - Industrial
            ///     <para />
            ///     05 - Poder Público
            ///     <para />
            ///     06 - Residencial
            ///     <para />
            ///     07 - Rural
            ///     <para />
            ///     08 - Serviço Público
            ///     <para />
            ///     - Código de classe de consumo de fornecimento d'água
            /// </remarks>
            [SpedCampos(9, "COD_CONS", "C", 2, 0, true)]
            public int CodCons { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(10, "NUM_DOC", "N", 9, 0, true)]
            public long NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(11, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Data da entrada ou da saída
            /// </summary>
            [SpedCampos(12, "DT_E_S", "N", 8, 0, true)]
            public DateTime DtEs { get; set; }

            /// <summary>
            ///     Valor total do documento fiscal
            /// </summary>
            [SpedCampos(13, "VL_DOC", "N", 0, 2, true)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(14, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Valor total fornecido/consumido
            /// </summary>
            [SpedCampos(15, "VL_FORN", "N", 0, 2, true)]
            public decimal VlForn { get; set; }

            /// <summary>
            ///     Valor total dos serviços não-tributados pelo ICMS
            /// </summary>
            [SpedCampos(16, "VL_SERV_NT", "N", 0, 2, false)]
            public decimal VlServNt { get; set; }

            /// <summary>
            ///     Valor total cobrado em nome de terceiros
            /// </summary>
            [SpedCampos(17, "VL_TERC", "N", 0, 2, false)]
            public decimal VlTerc { get; set; }

            /// <summary>
            ///     Valor total das despesas acessórias indicadas no documento fiscal
            /// </summary>
            [SpedCampos(18, "VL_DA", "N", 0, 2, false)]
            public decimal VlDa { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(19, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor acumulado do ICMS
            /// </summary>
            [SpedCampos(20, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS substituição tributária
            /// </summary>
            [SpedCampos(21, "VL_BC_ICMS_ST", "N", 0, 2, false)]
            public decimal VlBcIcmsSt { get; set; }

            /// <summary>
            ///     Valor acumulado do ICMS retido por substituição tributária
            /// </summary>
            [SpedCampos(22, "VL_ICMS_ST", "N", 0, 2, false)]
            public decimal VlIcmsSt { get; set; }

            /// <summary>
            ///     Código da informação complementar do documento fiscal
            /// </summary>
            [SpedCampos(23, "COD_INF", "C", 6, 0, false)]
            public string CodInf { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(24, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(25, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     Código do tipo de ligação
            /// </summary>
            /// <remarks>
            ///     1 - Monofásico
            ///     <para />
            ///     2 - Bifásico
            ///     <para />
            ///     3 - Trifásico
            /// </remarks>
            [SpedCampos(26, "TP_LIGACAO", "C", 1, 0, false)]
            public int? TpLigacao { get; set; }

            /// <summary>
            ///     Código do grupo de tensão
            /// </summary>
            /// <remarks>
            ///     01 - A1 - Alta tensão (230kV ou mais)
            ///     <para />
            ///     02 - A2 - Alta tensão (88 a 138kV)
            ///     <para />
            ///     03 - A3 - Alta tensão (69kV)
            ///     <para />
            ///     04 - A3a - Alta tensão (30kV a 44kV)
            ///     <para />
            ///     05 - A4 - Alta tensão (2,3kV a 25kV)
            ///     <para />
            ///     06 - AS - Alta tensão subterrâneo
            ///     07 - B1 - Residencial
            ///     08 - B1 - Residencial baixa renda
            ///     09 - B2 - Rural
            ///     10 - B2 - Cooperativa de eletrificação rural
            ///     11 - B2 - Serviço público de irrigação
            ///     12 - B3 - Demais classes
            ///     13 - B4a - Iluminação pública - rede de distribuição
            ///     14 - B4b - Iluminação pública - bulbo de lâmpada
            /// </remarks>
            [SpedCampos(27, "COD_GRUPO_TENSAO", "C", 2, 0, false)]
            public int? CodGrupoTensao { get; set; }

            /// <summary>
            ///     Chave da Nota Fiscal de Energia Elétrica Eletrônica
            /// </summary>
            [SpedCampos(28, "CHV_DOCe", "C", 44, 0, false)]
            public string ChvDoce { get; set; }

            /// <summary>
            ///     Finalidade da emissão do documento eletrônico
            /// </summary>
            /// <remarks>
            ///     1 – Normal
            ///     2 – Substituição
            ///     3 – Normal com ajuste
            /// </remarks>
            [SpedCampos(29, "FIN_DOCe", "C", 1, 0, false)]
            public string FinDoce { get; set; }

            /// <summary>
            ///     Chave da nota referenciada, substituída.
            /// </summary>
            [SpedCampos(30, "CHV_DOCe_REF ", "C", 44, 0, false)]
            public string ChvDoceRef { get; set; }

            /// <summary>
            ///     Indicador do Destinatário/Acessante
            /// </summary>
            /// <remarks>
            ///     1 – Contribuinte do ICMS;
            ///     2 – Contribuinte Isento de Inscrição no Cadastro de Contribuintes do ICMS;
            ///     9 – Não Contribuinte
            /// </remarks>
            [SpedCampos(31, "IND_DEST", "C", 1, 0, false)]
            public string IndDest { get; set; }

            /// <summary>
            ///     Código do município do destinatário conforme a tabela do IBGE.
            /// </summary>
            [SpedCampos(32, "COD_MUN_DEST", "C", 7, 0, false)]
            public string CodMunDest { get; set; }

            /// <summary>
            ///     Código da conta analíica contábil debitada/creditada
            /// </summary>
            [SpedCampos(33, "COD_CTA", "C", 99, 0, false)]
            public string CodCta { get; set; }

            public List<RegistroC510> RegC510s { get; set; }
            public List<RegistroC590> RegC590s { get; set; }
            public RegistroC595 RegC595 { get; set; }
        }

        /// <summary>
        ///     REGISTRO C510: ITENS DO DOCUMENTO NOTA FISCAL/CONTA ENERGIA ELÉTRICA (CÓDIGO 06),
        ///     NOTA FISCAL/CONTA DE FORNECIMENTO D'ÁGUA CANALIZADA (CÓDIGO 29) E NOTA FISCAL/CONTA
        ///     DE FORNECIMENTO DE GÁS (CÓDIGO 28)
        /// </summary>
        public class RegistroC510 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC510" />.
            /// </summary>
            public RegistroC510()
            {
                Reg = "C510";
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
            ///     Código de classificação do item de energia elétrica
            /// </summary>
            [SpedCampos(4, "COD_CLASS", "N", 4, 0, false)]
            public int CodClass { get; set; }

            /// <summary>
            ///     Quantidade do item
            /// </summary>
            [SpedCampos(5, "QTD", "N", 0, 3, false)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Unidade do item
            /// </summary>
            [SpedCampos(6, "UNID", "C", 6, 0, false)]
            public string Unid { get; set; }

            /// <summary>
            ///     Valor do item
            /// </summary>
            [SpedCampos(7, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(8, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Código da situação tributária
            /// </summary>
            [SpedCampos(9, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(10, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(11, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(12, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS creditado/debitado
            /// </summary>
            [SpedCampos(13, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor da base de cálculo referente à substituição tributária
            /// </summary>
            [SpedCampos(14, "VL_BC_ICMS_ST", "N", 0, 2, false)]
            public decimal VlBcIcmsSt { get; set; }

            /// <summary>
            ///     Alíquota do ICMS da substituição tributária na unidade da federação de destino
            /// </summary>
            [SpedCampos(15, "ALIQ_ST", "N", 6, 2, false)]
            public decimal AliqSt { get; set; }

            /// <summary>
            ///     Valor do ICMS referente à substituição tributária
            /// </summary>
            [SpedCampos(16, "VL_ICMS_ST", "N", 0, 2, false)]
            public decimal VlIcmsSt { get; set; }

            /// <summary>
            ///     Indicador do tipo de receita
            /// </summary>
            /// <remarks>
            ///     0 - Receita própria
            ///     <para />
            ///     1 - Receita de terceiros
            /// </remarks>
            [SpedCampos(17, "IND_REC", "C", 1, 0, true)]
            public int IndRec { get; set; }

            /// <summary>
            ///     Código do participante receptor da receita
            /// </summary>
            [SpedCampos(18, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(19, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor do COFINS
            /// </summary>
            [SpedCampos(20, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analíica contábil debitada/creditada
            /// </summary>
            [SpedCampos(21, "COD_CTA", "C", 99, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO C590: REGISTRO ANALÍTICO DO DOCUMENTO - NOTA FISCAL/CONTA
        ///     DE ENERGIA ELÉTRICA (CÓDIGO 06), NOTA FISCAL/CONTA DE FORNECIMENTO
        ///     D'ÁGUA CANALIZADA (CÓDIGO 29) E NOTA FISCAL CONSUMO FORNECIMENTO DE
        ///     GÁS (CÓDIGO 28)
        /// </summary>
        public class RegistroC590 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC590" />.
            /// </summary>
            public RegistroC590()
            {
                Reg = "C590";
            }

            /// <summary>
            ///     Código da situação tributária
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestaçaõ do agrupamento de itens
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor da operação correspondete à combinação de
            ///     CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor da base de cálculo
            ///     do ICMS" referente à combinação de CST_ICMS, CFOP e
            ///     alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela corresponde ao "Valor do ICMS" referente à
            ///     combinação de CST_ICMS, CFOP e alíquoa do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Parcela corresponde ao "Valor da base de cálculo do
            ///     ICMS" da substituição tributária referente à combinação
            ///     de CST_ICMS, CFOP alíquota do ICMS.
            /// </summary>
            [SpedCampos(8, "VL_BC_ICMS_ST", "N", 0, 2, true)]
            public decimal VlBcIcmsSt { get; set; }

            /// <summary>
            ///     Parcela corresponde ao valor creditado/debitado do ICMS
            ///     da substituição tributária, referente à combinação de CST_ICMS,
            ///     CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(9, "VL_ICMS_ST", "N", 0, 2, true)]
            public decimal VlIcmsSt { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do
            ///     ICMS, referente à combinação de CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(10, "VL_RED_BC", "N", 0, 2, true)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Código da observação do lançamento fiscal
            /// </summary>
            [SpedCampos(11, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }
        }

        public class RegistroC591 : RegistroBaseSped
        {
            public RegistroC591()
            {
                Reg = "C591";
            }

            [SpedCampos(2, "VL_FCP_OP", "N", 12, 2, false)]
            public decimal VlFcpOp { get; set; }

            [SpedCampos(3, "VL_FCP_ST", "N", 12, 2, false)]
            public decimal VlFcpSt { get; set; }
        }

        public class RegistroC595 : RegistroBaseSped
        {
            public RegistroC595()
            {
                Reg = "C595";
            }

            [SpedCampos(2, "COD_OBS", "C", 6, 0, true)]
            public string CodObs { get; set; }

            [SpedCampos(3, "TXT_COMPL", "C", 100, 0, false)]
            public string TxtCompl { get; set; }
        }

        public class RegistroC597 : RegistroBaseSped
        {
            public RegistroC597()
            {
                Reg = "C597";
            }

            [SpedCampos(2, "COD_AJ", "C", 10, 0, true)]
            public string CodAj { get; set; }

            [SpedCampos(3, "DESCR_COMPL_AJ", "C", 100, 0, false)]
            public string DescrComplAj { get; set; }

            [SpedCampos(4, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            [SpedCampos(5, "VL_BC_ICMS", "N", 12, 2, false)]
            public decimal VlBcIcms { get; set; }

            [SpedCampos(6, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            [SpedCampos(7, "VL_ICMS", "N", 12, 2, false)]
            public decimal VlIcms { get; set; }

            [SpedCampos(8, "VL_OUTROS", "N", 12, 2, false)]
            public decimal VlOutros { get; set; }
        }

        /// <summary>
        ///     REGISTRO C600: CONSOLIDAÇÃO DIÁRIA DE NOTAS FISCAIS (EMPRESAS NÃO OBRIGADAS AO CONVÊNIO ICMS 115/03)
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
            ///     Código do modelo do documento fiscal
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código do município dos pontos de consumo, conforme a tabela IBGE
            /// </summary>
            [SpedCampos(3, "COD_MUN", "N", 7, 0, true)]
            public int CodMun { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(4, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(5, "SUB", "N", 3, 0, false)]
            public int Sub { get; set; }

            /// <summary>
            ///     Código de classe de consumo de energia elétrica ou gás
            /// </summary>
            /// <remarks>
            ///     01 - Comercial
            ///     02 - Consumo próprio
            ///     03 - Iluminação pública
            ///     04 - Industrial
            ///     05 - Poder público
            ///     06 - Residencial
            ///     07 - Rural
            ///     08 - Serviço público
            ///     - Código de classe de consumo de fornecimento d'água
            /// </remarks>
            [SpedCampos(6, "COD_CONS", "C", 2, 0, true)]
            public int CodCons { get; set; }

            /// <summary>
            ///     Quantidade de documentos consolidados neste registro
            /// </summary>
            [SpedCampos(7, "QTD_CONS", "N", int.MaxValue, 0, true)]
            public int QtdCons { get; set; }

            /// <summary>
            ///     Quantidade de documentos cancelados
            /// </summary>
            [SpedCampos(8, "QTD_CANC", "N", int.MaxValue, 0, false)]
            public int QtdCanc { get; set; }

            /// <summary>
            ///     Data dos documentos consolidados
            /// </summary>
            [SpedCampos(9, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Valor total dos documentos
            /// </summary>
            [SpedCampos(10, "VL_DOC", "N", 0, 2, true)]
            public decimal VlDoc { get; set; }

            /// <summary>
            ///     Valor acumulado dos descontos
            /// </summary>
            [SpedCampos(11, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Consumo total acumulado, em kWh (Código 06)
            /// </summary>
            [SpedCampos(12, "CONS", "N", int.MaxValue, 2, false)]
            public double Cons { get; set; }

            /// <summary>
            ///     Valor acumulado do fornecimento
            /// </summary>
            [SpedCampos(13, "VL_FORN", "N", 0, 2, false)]
            public decimal VlForn { get; set; }

            /// <summary>
            ///     Valor acumulado dos serviços não-tributados pelo ICMS
            /// </summary>
            [SpedCampos(14, "VL_SERV_NT", "N", 0, 2, false)]
            public decimal VlServNt { get; set; }

            /// <summary>
            ///     Valores cobrados em nome de terceiros
            /// </summary>
            [SpedCampos(15, "VL_TERC", "N", 0, 2, false)]
            public decimal VlTerc { get; set; }

            /// <summary>
            ///     Valor acumulado das despesas acessórias
            /// </summary>
            [SpedCampos(16, "VL_DA", "N", 0, 2, false)]
            public decimal VlDa { get; set; }

            /// <summary>
            ///     Valor acumulados da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(17, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor acumulado do ICMS
            /// </summary>
            [SpedCampos(18, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS substituição tributária
            /// </summary>
            [SpedCampos(19, "VL_BC_ICMS_ST", "N", 0, 2, false)]
            public decimal VlBcIcmsSt { get; set; }

            /// <summary>
            ///     Valor acumulado do ICMS retido por substituição tributária
            /// </summary>
            [SpedCampos(20, "VL_ICMS_ST", "N", 0, 2, false)]
            public decimal VlIcmsSt { get; set; }

            /// <summary>
            ///     Valor acumulado do PIS
            /// </summary>
            [SpedCampos(21, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor acumulado do COFINS
            /// </summary>
            [SpedCampos(22, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            public List<RegistroC601> RegC601s { get; set; }
            public List<RegistroC610> RegC610s { get; set; }
            public List<RegistroC690> RegC690s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C601: DOCUMENTOS CANCELADOS - CONSOLIDAÇÃO DIÁRIA DE NOTAS FISCAIS
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
            ///     Número do documento fiscal cancelado
            /// </summary>
            [SpedCampos(2, "NUM_DOC_CANC", "N", 9, 0, true)]
            public double NumDocCanc { get; set; }
        }

        /// <summary>
        ///     REGISTRO C610: ITENS DO DOCUMENTO CONSOLIDADO (EMPRESAS NÃO OBRIGADAS AO CONVÊNIO ICMS 115/03)
        /// </summary>
        public class RegistroC610 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC610" />.
            /// </summary>
            public RegistroC610()
            {
                Reg = "C610";
            }

            /// <summary>
            ///     Código de classificação do item de energia elétrica
            /// </summary>
            [SpedCampos(2, "COD_CLASS", "N", 4, 0, false)]
            public int CodClass { get; set; }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade acumulada do item
            /// </summary>
            [SpedCampos(4, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Unidade do item
            /// </summary>
            [SpedCampos(5, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///     Valor acumulado do item
            /// </summary>
            [SpedCampos(6, "VL_ITEM", "N", 0, 2, true)]
            public decimal VlItem { get; set; }

            /// <summary>
            ///     Valor acumulado dos descontos
            /// </summary>
            [SpedCampos(7, "VL_DESC", "N", 0, 2, false)]
            public decimal VlDesc { get; set; }

            /// <summary>
            ///     Código da situação tributária
            /// </summary>
            [SpedCampos(8, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(9, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(10, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(11, "VL_BC_ICMS", "N", 0, 2, false)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor acumulado do ICMS debitado
            /// </summary>
            [SpedCampos(12, "VL_ICMS", "N", 0, 2, false)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS substituição tributária
            /// </summary>
            [SpedCampos(13, "VL_BC_ICMS_ST", "N", 0, 2, false)]
            public decimal VlBcIcmsSt { get; set; }

            /// <summary>
            ///     Valor do ICMS retido por substituição tributária
            /// </summary>
            [SpedCampos(14, "VL_ICMS_ST", "N", 0, 2, false)]
            public decimal VlIcmsSt { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(15, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(16, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(17, "COD_CTA", "N", 99, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO C690: REGISTRO ANALÍTICO DOS DOCUMENTOS
        /// </summary>
        public class RegistroC690 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC690" />.
            /// </summary>
            public RegistroC690()
            {
                Reg = "C690";
            }

            /// <summary>
            ///     Código da situação tributária
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal de operaçaõ e prestação
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor da operação correspondente à combinação de CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor da base de cálculo do ICMS"
            ///     referente à combinação CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do ICMS" referente à
            ///     combinação CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do ICMS, referente
            ///     à combinaçaõ de CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(8, "VL_RED_BC", "N", 0, 2, true)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS substituição tributária
            /// </summary>
            [SpedCampos(9, "VC_BC_ICMS_ST", "N", 0, 2, true)]
            public decimal VlBcIcmsSt { get; set; }

            /// <summary>
            ///     Valor do ICMS retido por substituição tributária
            /// </summary>
            [SpedCampos(10, "VL_ICMS_ST", "N", 0, 2, true)]
            public decimal VlIcmsSt { get; set; }

            /// <summary>
            ///     Código da observação do lançamento fiscal
            /// </summary>
            [SpedCampos(11, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO C700: CONSOLIDAÇÃO DOS DOCUMENTOS (EMPRESAS OBRIGADAS
        ///     À ENTREGA DO ARQUIVO PREVISTO NO CONVÊNIO ICMS 115/03)
        /// </summary>
        public class RegistroC700 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC700" />.
            /// </summary>
            public RegistroC700()
            {
                Reg = "C700";
            }

            /// <summary>
            ///     Código do modelo do documento fiscal
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(3, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Número de ordem inicial
            /// </summary>
            [SpedCampos(4, "NRO_ORD_INI", "N", 9, 0, true)]
            public double NroOrdIni { get; set; }

            /// <summary>
            ///     Número de ordem final
            /// </summary>
            [SpedCampos(5, "NRO_ORD_FIN", "N", 9, 0, true)]
            public double NroOrdFin { get; set; }

            /// <summary>
            ///     Data de emissão inicial dos documentos /
            ///     Data inicial de vencimento da fatura
            /// </summary>
            [SpedCampos(6, "DT_DOC_INI", "N", 8, 0, true)]
            public DateTime DtDocIni { get; set; }

            /// <summary>
            ///     Data de emissão final dos documentos /
            ///     Data final do vencimento da fatura
            /// </summary>
            [SpedCampos(7, "DT_DOC_FIN", "N", 8, 0, true)]
            public DateTime DtDocFin { get; set; }

            /// <summary>
            ///     Nome do arquivo mestre do documento fiscal
            /// </summary>
            [SpedCampos(8, "NOM_MEST", "C", 15, 0, true)]
            public string Nom_Mest { get; set; }

            /// <summary>
            ///     Chave de codificação digital do arquivo mestre de documento fiscal
            /// </summary>
            [SpedCampos(9, "CHV_COD_DIG", "C", 32, 0, true)]
            public string ChvCodDig { get; set; }

            public List<RegistroC790> RegC790s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C790: REGISTRO ANALÍTICO DOS DOCUMENTOS
        /// </summary>
        public class RegistroC790 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC790" />.
            /// </summary>
            public RegistroC790()
            {
                Reg = "C790";
            }

            /// <summary>
            ///     Código da situação tributária
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal de operaçaõ e prestação
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor da operação correspondente à combinação
            ///     de CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor da base de cálculo
            ///     do ICMS" referente à combinação CST_ICMS, CFOP e
            ///     alíquota do ICMS
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do ICMS" referente
            ///     à combinação CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS substituição tributária
            /// </summary>
            [SpedCampos(8, "VL_BC_ICMS_ST", "N", 0, 2, true)]
            public decimal VlBcIcmsSt { get; set; }

            /// <summary>
            ///     Valor do ICMS retido por substituição tributária
            /// </summary>
            [SpedCampos(9, "VL_ICMS_ST", "N", 0, 2, true)]
            public decimal VlIcmsSt { get; set; }

            /// <summary>
            ///     Valor não tributado em função da redução da base de cálculo do ICMS,
            ///     referente à combinação de CST_ICMS, CFOP e alíquota do ICMS
            /// </summary>
            [SpedCampos(10, "VL_RED_BC", "N", 0, 2, true)]
            public decimal VlRedBc { get; set; }

            /// <summary>
            ///     Código da observação do lançamento fiscal
            /// </summary>
            [SpedCampos(11, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }

            public List<RegistroC791> RegC791s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C791: REGISTRO DE INFORMAÇÕES DE ST POR UF (COD 06)
        /// </summary>
        public class RegistroC791 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC791" />.
            /// </summary>
            public RegistroC791()
            {
                Reg = "C791";
            }

            /// <summary>
            ///     Sigla da unidade da federaçaõ a que se refere a retenção ST
            /// </summary>
            [SpedCampos(2, "UF", "C", 2, 0, true)]
            public string Uf { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS substituição tributária
            /// </summary>
            [SpedCampos(3, "VL_BC_ICMS_ST", "N", 0, 2, true)]
            public decimal VlBcIcmsSt { get; set; }

            /// <summary>
            ///     Valor do ICMS retido por substituição tributária
            /// </summary>
            [SpedCampos(4, "VL_ICMS_ST", "N", 0, 2, true)]
            public decimal VlIcmsSt { get; set; }
        }

        /// <summary>
        ///     REGISTRO C800: REGISTRO CUPOM FISCAL ELETRÔNICO - CF-E (CÓDIGO 59)
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
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Código da situação do documento fiscal, conforme a Tabela 4.1.2
            /// </summary>
            [SpedCampos(3, "COD_SIT", "N", 2, 0, true)]
            public int CodSit { get; set; }

            /// <summary>
            ///     Número do Cupom Fiscal Eletrônico
            /// </summary>
            [SpedCampos(4, "NUM_CFE", "N", 6, 0, true)]
            public int NumCfe { get; set; }

            /// <summary>
            ///     Data da emissão do Cupom Fiscal Eletrônico
            /// </summary>
            [SpedCampos(5, "DT_DOC", "N", 8, 0, false)]
            public DateTime? DtDoc { get; set; }

            /// <summary>
            ///     Valor total do Cupom Fiscal Eletrônico
            /// </summary>
            [SpedCampos(6, "VL_CFE", "N", 0, 2, false)]
            public decimal? VlCfe { get; set; }

            /// <summary>
            ///     Valor total do PIS
            /// </summary>
            [SpedCampos(7, "VL_PIS", "N", 0, 2, false)]
            public decimal? VlPis { get; set; }

            /// <summary>
            ///     Valor total da COFINS
            /// </summary>
            [SpedCampos(8, "VL_COFINS", "N", 0, 2, false)]
            public decimal? VlCofins { get; set; }

            /// <summary>
            ///     CNPJ ou CPF do destinatário
            /// </summary>
            [SpedCampos(9, "CNPJ_CPF", "N", 14, 0, false)]
            public string CnpjCpf { get; set; }

            /// <summary>
            ///     Número de série do equipamento SAT
            /// </summary>
            [SpedCampos(10, "NR_SAT", "N", 9, 0, true)]
            public string NrSat { get; set; }

            /// <summary>
            ///     Chave da Cupom Fiscal Eletrônico
            /// </summary>
            [SpedCampos(11, "CHV_CFE", "N", 44, 0, true)]
            public string ChvCfe { get; set; }

            /// <summary>
            ///     Valor total do desconto
            /// </summary>
            [SpedCampos(12, "VL_DESC", "N", 0, 2, false)]
            public decimal? VlDesc { get; set; }

            /// <summary>
            ///     Valor total das mercadorias e serviços
            /// </summary>
            [SpedCampos(13, "VL_MERC", "N", 0, 2, false)]
            public decimal? VlMerc { get; set; }

            /// <summary>
            ///     Valor de outras despesas acessórias
            /// </summary>
            [SpedCampos(14, "VL_OUT_DA", "N", 0, 2, false)]
            public decimal? VlOutDa { get; set; }

            /// <summary>
            ///     Valor do ICMS 
            /// </summary>
            [SpedCampos(15, "VL_ICMS", "N", 0, 2, false)]
            public decimal? VlIcms { get; set; }

            /// <summary>
            ///     Valor total do PIS retido por substituição tributária
            /// </summary>
            [SpedCampos(16, "VL_PIS_ST", "N", 0, 2, false)]
            public decimal? VlPisSt { get; set; }

            /// <summary>
            ///     Valor total da COFINS retido por substituição tributária
            /// </summary>
            [SpedCampos(17, "VL_COFINS_ST", "N", 0, 2, false)]
            public decimal? VlCofinsSt { get; set; }

            public List<RegistroC810> RegC810s { get; set; }
            public List<RegistroC850> RegC850s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C810: ITENS DO DOCUMENTO DO CUPOM FISCAL ELETRÔNICO – SAT (CF-E-SAT) (CÓDIGO 59):
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
            ///    Número do item no documento fiscal
            /// </summary>
            [SpedCampos(2, "NUM_ITEM", "N", 3, 0, true)]
            public string NumItem { get; set; }

            /// <summary>
            ///    Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            // <summary>
            ///     Quantidade do item
            /// </summary>
            [SpedCampos(4, "QTD", "N", 0, 5, true)]
            public int Qtd { get; set; }

            /// <summary>
            ///    Unidade do item (Campo 02 do registro 0190)
            /// </summary>
            [SpedCampos(5, "UNID", "C", 6, 0, true)]
            public int Unid { get; set; }

            /// <summary>
            ///     Valor total do item(mercadorias ou serviços)
            /// </summary>
            [SpedCampos(6, "VL_ITEM", "N", 0, 2, true)]
            public int VlItem { get; set; }

            /// <summary>
            ///     Código da situação tributária referente ao ICMS
            /// </summary>
            [SpedCampos(7, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal da operação e prestação
            /// </summary>
            [SpedCampos(8, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }
            
            public RegistroC815 RegC815s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C810: ITENS DO DOCUMENTO DO CUPOM FISCAL ELETRÔNICO – SAT (CF-E-SAT) (CÓDIGO 59):
        /// </summary>
        public class RegistroC815 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC815" />.
            /// </summary>
            public RegistroC815()
            {
                Reg = "C815";
            }

            /// <summary>
            ///  Código   do   motivo   da   restituição   ou complementação conforme Tabela 5.7
            /// </summary>
            [SpedCampos(2, "COD_MOT_REST_COMPL", "N", 5, 0, true)]
            public int CodMotRestCompl { get; set; }

            /// <summary>
            ///   Quantidade do item 
            /// </summary>
            [SpedCampos(3, "QUANT_CONV", "N", 0, 6, true)]
            public int QuantConv { get; set; }

            /// <summary>
            ///    Unidade adotada para informar o campo QUANT_CONV.
            /// </summary>
            [SpedCampos(4, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///    Valor unitário da mercadoria, considerando a  unidade  utilizada  para  informar  o  campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(5, "VL_UNIT_CONV", "N", 0, 6, true)]
            public string VlUnitConv { get; set; }

            /// <summary>
            ///     Valor unitário para o ICMS na operação, caso não houvesse a ST, considerando unidade utilizada para informar o campo “QUANT_CONV”, aplicando-se a mesma redução da base de cálculo do ICMS ST na tributação, se houver.
            /// </summary>
            [SpedCampos(6, "VL_UNIT_ICMS_NA_OPERACAO_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsNaOperacaoConv { get; set; }

            /// <summary>
            ///   Valor unitário do ICMS OP calculado conforme a legislação de cada UF,considerando a unidade utilizada para informar o campo “QUANT_CONV”, utilizado para cálculo de ressarcimento/restituição de ST, no desfazimento da substituição tributária, quando se utiliza a fórmula descrita nas instruções de preenchimento do campo 11, no item a1).
            /// </summary>
            [SpedCampos(7, "VL_UNIT_ICMS_OP_CONV", "N", 0, 6, false)]
            public decimal VlUnitIcmsOpConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS que o contribuinte teria se creditado referente à operação de entrada das mercadorias em estoque caso estivesse submetida ao regime comum de tributação, calculado conforme a legislação de cada UF,considerando a unidade utilizada para informar o campo “QUANT_CONV”
            /// </summary>
            [SpedCampos(8, "VL_UNIT_ICMS_OP_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsOpEstoqueConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS ST, incluindo FCP ST, das mercadorias em estoque, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(9, "VL_UNIT_ICMS_ST_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitIcmsStEstoqueConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do FCP ST agregado ao ICMS das mercadorias em estoque, considerando unidade utilizada parainformar o campo “QUANT_CONV”
            /// </summary>
            [SpedCampos(10, "VL_UNIT_FCP_ICMS_ST_ESTOQUE_CONV", "N", 0, 6, false)]
            public string VlUnitFcpIcmsStEstoqueConv { get; set; }

            /// <summary>
            ///    Valor unitário do total do ICMS ST, incluindo FCP ST, a ser restituído/ressarcido, calculado conforme a legislação de cada  UF,  considerando  a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(11, "VL_UNIT_ICMS_ST_CONV_REST", "N", 0, 6, false)]
            public decimal VlUnitIcmsStConvRest { get; set; }

            /// <summary>
            ///    Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_REST”, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(12, "VL_UNIT_FCP_ST_CONV_REST", "N", 0, 6, false)]
            public string VlUnitFcpStConvRest { get; set; }

            /// <summary>
            ///   Valor unitário do complemento do ICMS, incluindo FCP ST, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(13, "VL_UNIT_ICMS_ST_CONV_COMPL", "N", 0, 6, false)]
            public string VlUnitIcmsStConvCompl { get; set; }

            /// <summary>
            ///   Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_COMPL”, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(14, "VL_UNIT_FCP_ST_CONV_COMPL", "N", 0, 6, false)]
            public string VlUnitFcpStConvCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO C850: REGISTRO ANALÍTICO DO CF-E (CÓDIGO 59)
        /// </summary>
        public class RegistroC850 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC850" />.
            /// </summary>
            public RegistroC850()
            {
                Reg = "C850";
            }

            /// <summary>
            ///     Código da situação tributária do ICMS
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação do agrupamento de itens
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor total do CF-E na combinação de CST_ICMS, CFOP e alíquota do ICMS,
            ///     correspondente ao somatório do valor líquido dos itens.
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS referente à
            ///     combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do ICMS" referente à combinação de CST_ICMS,
            ///     CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Código da observação do lançamento fiscal
            /// </summary>
            /// <remarks>
            ///     Preenchimento: este campo só deve ser informado pelos contribuintes localizados em UF que determine em
            ///     sua legislação o seu preenchimento. Validação: o código informado deve constar do registro 0460.
            /// </remarks>
            [SpedCampos(8, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO C860: IDENTIFICAÇÃO DO EQUIPAMENTO SAT-CF-E (CÓDIGO 59)
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
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Número de série do equipamento SAT
            /// </summary>
            [SpedCampos(3, "NR_SAT", "N", 9, 0, true)]
            public string NrSat { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            /// <remarks>
            ///     Preenchimento: Informar a data de emissão do documento, no formato "ddmmaaaa".
            /// </remarks>
            [SpedCampos(4, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Número do documento inicial
            /// </summary>
            /// <remarks>
            ///     Preenchimento: informar o número do primeiro CF-e-SAT emitido, mesmo que cancelado, no período, pelo equipamento.
            /// </remarks>
            [SpedCampos(5, "DOC_INI", "N", 6, 0, true)]
            public int NumDocIni { get; set; }

            /// <summary>
            ///     Número do documento final
            /// </summary>
            /// <remarks>
            ///     Preenchimento: informar o número do último CF-e-SAT emitido, mesmo que cancelado, no período, pelo equipamento.
            /// </remarks>
            [SpedCampos(6, "DOC_FIM", "N", 6, 0, true)]
            public int NumDocFin { get; set; }

            public List<RegistroC870> RegC870s { get; set; }
            public List<RegistroC890> RegC890s { get; set; }
        }

        /// <summary>
        ///     REGISTRO C870: ITENS DO RESUMO DIÁRIO DOS DOCUMENTOS (CF-E-SAT) (CÓDIGO 59)
        /// </summary>
        public class RegistroC870 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC870" />.
            /// </summary>
            public RegistroC870()
            {
                Reg = "C870";
            }

            /// <summary>
            ///    Código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            // <summary>
            ///     Quantidade do item
            /// </summary>
            [SpedCampos(3, "QTD", "N", 0, 5, true)]
            public int Qtd { get; set; }

            /// <summary>
            ///    Unidade do item (Campo 02 do registro 0190)
            /// </summary>
            [SpedCampos(4, "UNID", "C", 6, 0, true)]
            public int Unid { get; set; }

            /// <summary>
            ///     Código da situação tributária referente ao ICMS
            /// </summary>
            [SpedCampos(5, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal da operação e prestação
            /// </summary>
            [SpedCampos(6, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            public RegistroC880 RegC880s { get; set; }
        }


        /// <summary>
        ///     REGISTRO C880: INFORMAÇÕES COMPLEMENTARES DAS OPERAÇÕES DE SAÍDA DE MERCADORIAS SUJEITAS À SUBSTITUIÇÃO TRIBUTÁRIA (CF-E-SAT) (CÓDIGO 59)
        /// </summary>
        public class RegistroC880 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC880" />.
            /// </summary>
            public RegistroC880()
            {
                Reg = "C880";
            }

            /// <summary>
            ///  Código   do   motivo   da   restituição   ou complementação conforme Tabela 5.7
            /// </summary>
            [SpedCampos(2, "COD_MOT_REST_COMPL", "N", 5, 0, true)]
            public int CodMotRestCompl { get; set; }

            /// <summary>
            ///   Quantidade do item 
            /// </summary>
            [SpedCampos(3, "QUANT_CONV", "N", 0, 6, true)]
            public int QuantConv { get; set; }

            /// <summary>
            ///    Unidade adotada para informar o campo QUANT_CONV.
            /// </summary>
            [SpedCampos(4, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///    Valor unitário da mercadoria, considerando a  unidade  utilizada  para  informar  o  campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(5, "VL_UNIT_CONV", "N", 0, 3, true)]
            public string VlUnitConv { get; set; }

            /// <summary>
            ///     Valor unitário para o ICMS na operação, caso não houvesse a ST, considerando unidade utilizada para informar o campo “QUANT_CONV”, aplicando-se a mesma redução da base de cálculo do ICMS ST na tributação, se houver.
            /// </summary>
            [SpedCampos(6, "VL_UNIT_ICMS_NA_OPERACAO_CONV", "N", 0, 3, false)]
            public string VlUnitIcmsNaOperacaoConv { get; set; }

            /// <summary>
            ///   Valor unitário do ICMS OP calculado conforme a legislação de cada UF,considerando a unidade utilizada para informar o campo “QUANT_CONV”, utilizado para cálculo de ressarcimento/restituição de ST, no desfazimento da substituição tributária, quando se utiliza a fórmula descrita nas instruções de preenchimento do campo 11, no item a1).
            /// </summary>
            [SpedCampos(7, "VL_UNIT_ICMS_OP_CONV", "N", 0, 6, false)]
            public decimal VlUnitIcmsOpConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS que o contribuinte teria se creditado referente à operação de entrada das mercadorias em estoque caso estivesse submetida ao regime comum de tributação, calculado conforme a legislação de cada UF,considerando a unidade utilizada para informar o campo “QUANT_CONV”
            /// </summary>
            [SpedCampos(8, "VL_UNIT_ICMS_OP_ESTOQUE_CONV", "N", 0, 3, false)]
            public string VlUnitIcmsOpEstoqueConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do ICMS ST, incluindo FCP ST, das mercadorias em estoque, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(9, "VL_UNIT_ICMS_ST_ESTOQUE_CONV", "N", 0, 3, false)]
            public string VlUnitIcmsStEstoqueConv { get; set; }

            /// <summary>
            ///    Valor médio unitário do FCP ST agregado ao ICMS das mercadorias em estoque, considerando unidade utilizada parainformar o campo “QUANT_CONV”
            /// </summary>
            [SpedCampos(10, "VL_UNIT_FCP_ICMS_ST_ESTOQUE_CONV", "N", 0, 3, false)]
            public string VlUnitFcpIcmsStEstoqueConv { get; set; }

            /// <summary>
            ///    Valor unitário do total do ICMS ST, incluindo FCP ST, a ser restituído/ressarcido, calculado conforme a legislação de cada  UF,  considerando  a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(11, "VL_UNIT_ICMS_ST_CONV_REST", "N", 0, 3, false)]
            public decimal VlUnitIcmsStConvRest { get; set; }

            /// <summary>
            ///    Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_REST”, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(12, "VL_UNIT_FCP_ST_CONV_REST", "N", 0, 3, false)]
            public string VlUnitFcpStConvRest { get; set; }

            /// <summary>
            ///   Valor unitário do complemento do ICMS, incluindo FCP ST, considerando a unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(13, "VL_UNIT_ICMS_ST_CONV_COMPL", "N", 0, 3, false)]
            public string VlUnitIcmsStConvCompl { get; set; }

            /// <summary>
            ///   Valor unitário correspondente à parcela de ICMS FCP ST que compõe o campo “VL_UNIT_ICMS_ST_CONV_COMPL”, considerando unidade utilizada para informar o campo “QUANT_CONV”.
            /// </summary>
            [SpedCampos(14, "VL_UNIT_FCP_ST_CONV_COMPL", "N", 0, 3, false)]
            public string VlUnitFcpStConvCompl { get; set; }

        }

        /// <summary>
        ///     REGISTRO C890: RESUMO DIÁRIO DE CF-E (CÓDIGO 59) POR EQUIPAMENTO SAT-CF-E
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
            ///     Código da situação tributária referente ao ICMS
            /// </summary>
            [SpedCampos(2, "CST_ICMS", "N", 3, 0, true)]
            public int CstIcms { get; set; }

            /// <summary>
            ///     Código fiscal de operação e prestação
            /// </summary>
            [SpedCampos(3, "CFOP", "N", 4, 0, true)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Alíquota do ICMS
            /// </summary>
            [SpedCampos(4, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }

            /// <summary>
            ///     Valor total do CF-E na combinação de CST_ICMS, CFOP e alíquota do ICMS,
            ///     correspondente ao somatório do valor líquido dos itens.
            /// </summary>
            [SpedCampos(5, "VL_OPR", "N", 0, 2, true)]
            public decimal VlOpr { get; set; }

            /// <summary>
            ///     Valor acumulado da base de cálculo do ICMS referente à
            ///     combinação de CST_ICMS, CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(6, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor do ICMS" referente à combinação de CST_ICMS,
            ///     CFOP e alíquota do ICMS.
            /// </summary>
            [SpedCampos(7, "VL_ICMS", "N", 0, 2, true)]
            public decimal VlIcms { get; set; }

            /// <summary>
            ///     Código da observação do lançamento fiscal
            /// </summary>
            /// <remarks>
            ///     Preenchimento: este campo só deve ser informado pelos contribuintes localizados em UF que determine em
            ///     sua legislação o seu preenchimento. Validação: o código informado deve constar do registro 0460.
            /// </remarks>
            [SpedCampos(8, "COD_OBS", "C", 6, 0, false)]
            public string CodObs { get; set; }
        }

        /// <summary>
        ///     REGISTRO C990: ENCERRAMENTO DO BLOCO C
        /// </summary>
        public class RegistroC990 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroC990" />.
            /// </summary>
            public RegistroC990()
            {
                Reg = "C990";
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco C
            /// </summary>
            [SpedCampos(3, "QTD_LIN_C", "N", int.MaxValue, 0, true)]
            public int QtdLinC { get; set; }
        }
    }
}
