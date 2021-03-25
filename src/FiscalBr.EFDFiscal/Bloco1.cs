using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDFiscal
{
    /// <summary>
    ///     BLOCO 1: OUTRAS INFORMAÇÕES
    /// </summary>
    public class Bloco1
    {
        public Registro1001 Reg1001 { get; set; }
        public Registro1990 Reg1990 { get; set; }

        /// <summary>
        ///     REGISTRO 1001: ABERTURA DO BLOCO 1
        /// </summary>
        public class Registro1001 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1001" />.
            /// </summary>
            public Registro1001()
            {
                Reg = "1001";
            }

            /// <summary>
            ///     Indicador de movimento
            /// </summary>
            /// <remarks>
            ///     0 - Bloco com dados informados
            ///     <para />
            ///     1 - Bloco sem dados informados
            /// </remarks>
            [SpedCampos(2, "IND_MOV", "N", 1, 0, true)]
            public IndMovimento IndMov { get; set; }

            public Registro1010 Reg1010 { get; set; }
            public List<Registro1100> Reg1100s { get; set; }
            public List<Registro1200> Reg1200s { get; set; }
            public Registro1250 Reg1250 { get; set; }
            public List<Registro1300> Reg1300s { get; set; }
            public List<Registro1350> Reg1350s { get; set; }
            public List<Registro1390> Reg1390s { get; set; }
            public List<Registro1400> Reg1400s { get; set; }
            public List<Registro1500> Reg1500s { get; set; }
            public List<Registro1600> Reg1600s { get; set; }
            public List<Registro1700> Reg1700s { get; set; }
            public List<Registro1800> Reg1800 { get; set; }
            public List<Registro1900> Reg1900s { get; set; }
            public List<Registro1960> Reg1960s { get; set; }
            public List<Registro1970> Reg1970s { get; set; }
            public Registro1980 Reg1980 { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1010: OBRIGATORIEDADE DE REGISTROS DO BLOCO 1
        /// </summary>
        public class Registro1010 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1010" />.
            /// </summary>
            public Registro1010()
            {
                Reg = "1010";
            }

            /// <summary>
            ///     Reg. 1100 - Ocorreu averbação (conclusão) de exportação no período: S - Sim; N - Não
            /// </summary>
            [SpedCampos(2, "IND_EXP", "LE", 1, 0, true)]
            public SimOuNao IndExp { get; set; }

            /// <summary>
            ///     Reg. 1200 - Existem informações acerca de créditos de ICMS a serem controlados, definidos pela Sefaz: S - Sim; N -
            ///     Não
            /// </summary>
            [SpedCampos(3, "IND_CCRF", "LE", 1, 0, true)]
            public SimOuNao IndCcrf { get; set; }

            /// <summary>
            ///     Reg. 1300 – É comercio varejista de combustíveis com movimentação e/ou estoque no período: S - Sim; N - Não
            /// </summary>
            [SpedCampos(4, "IND_COMB", "LE", 1, 0, true)]
            public SimOuNao IndComb { get; set; }

            /// <summary>
            ///     Reg. 1390 – Usinas de açúcar e/álcool – O estabelecimento é produtor de açúcar e/ou álcool carburante com
            ///     movimentação e/ou estoque no período: S - Sim; N - Não
            /// </summary>
            [SpedCampos(5, "IND_USINA", "LE", 1, 0, true)]
            public SimOuNao IndUsina { get; set; }

            /// <summary>
            ///     Reg 1400 – Sendo o registro obrigatório em sua Unidade de Federação, existem informações a serem prestadas neste
            ///     registro: S - Sim; N - Não
            /// </summary>
            [SpedCampos(6, "IND_VA", "LE", 1, 0, true)]
            public SimOuNao IndVa { get; set; }

            /// <summary>
            ///     Reg 1500 - A empresa é distribuidora de energia e ocorreu fornecimento de energia elétrica para consumidores de
            ///     outra UF: S - Sim; N - Não
            /// </summary>
            [SpedCampos(7, "IND_EE", "LE", 1, 0, true)]
            public SimOuNao IndEe { get; set; }

            /// <summary>
            ///     Reg 1600 - Realizou vendas com Cartão de Crédito ou de débito: S - Sim; N - Não
            /// </summary>
            [SpedCampos(8, "IND_CART", "LE", 1, 0, true)]
            public SimOuNao IndCart { get; set; }

            /// <summary>
            ///     Reg. 1700 – Foram emitidos documentos fiscais em papel no período em unidade da federação que exija o controle de
            ///     utilização de documentos fiscais: S - Sim; N - Não
            /// </summary>
            [SpedCampos(9, "IND_FORM", "LE", 1, 0, true)]
            public SimOuNao IndForm { get; set; }

            /// <summary>
            ///     Reg 1800 – A empresa prestou serviços de transporte aéreo de cargas e de passageiros: S - Sim; N - Não
            /// </summary>
            [SpedCampos(10, "IND_AER", "LE", 1, 0, true)]
            public SimOuNao IndAer { get; set; }

            /// <summary>
            ///     Reg. 1960 - Possui informações GIAF1? : S - Sim; N - Não
            /// </summary>
            [SpedCampos(11, "IND_GIAF1", "LE", 1, 0, true)]
            public SimOuNao IndGiaf1 { get; set; }

            /// <summary>
            ///     Reg. 1970 - Possui informações GIAF3? : S - Sim; N - Não
            /// </summary>
            [SpedCampos(12, "IND_GIAF3", "LE", 1, 0, true)]
            public SimOuNao IndGiaf3 { get; set; }

            /// <summary>
            ///     Reg. 1980 - Possui informações GIAF4? : S - Sim; N - Não
            /// </summary>
            [SpedCampos(13, "IND_GIAF4", "LE", 1, 0, true)]
            public SimOuNao IndGiaf4 { get; set; }

            /// <summary>
            ///     Reg. 1250 – Possui informações consolidadas de saldos de restituição, ressarcimento e complementação do ICMS?
            /// </summary>
            [SpedCampos(14, "IND_REST_RESSARC_COMPL_ICMS", "LE", 1, 0, true)]
            public SimOuNao IndRestRessarcComplIcms { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1100: REGISTRO DE INFORMAÇÕES SOBRE EXPORTAÇÃO
        /// </summary>
        public class Registro1100 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1100" />.
            /// </summary>
            public Registro1100()
            {
                Reg = "1100";
            }

            /// <summary>
            ///     0 - Declaração de Exportação; 1 - Declaração Simplificada de Exportação
            /// </summary>
            [SpedCampos(2, "IND_DOC", "N", 1, 0, true)]
            public int IndDoc { get; set; }

            /// <summary>
            ///     Número da declaração
            /// </summary>
            [SpedCampos(3, "NRO_DE", "N", 11, 0, true)]
            public int NroDe { get; set; }

            /// <summary>
            ///     Data da declaração
            /// </summary>
            [SpedCampos(4, "DT_DE", "N", 8, 0, true)]
            public DateTime DtDe { get; set; }

            /// <summary>
            ///     0 - Exportação Direta; 1 - Exportação Indireta
            /// </summary>
            [SpedCampos(5, "NAT_EXP", "N", 1, 0, true)]
            public int NatExp { get; set; }

            /// <summary>
            ///     Nro do registro de exportação
            /// </summary>
            [SpedCampos(6, "NRO_RE", "N", 12, 0, false)]
            public int NroRe { get; set; }

            /// <summary>
            ///     Data do registro de exportação
            /// </summary>
            [SpedCampos(7, "DT_RE", "N", 8, 0, false)]
            public DateTime DtRe { get; set; }

            /// <summary>
            ///     Nro do conhecimento de embarque
            /// </summary>
            [SpedCampos(8, "CHC_EMB", "C", 18, 0, false)]
            public string ChcEmb { get; set; }

            /// <summary>
            ///     Data do conhecimento de embarque
            /// </summary>
            [SpedCampos(9, "DT_CHC", "N", 8, 0, false)]
            public DateTime DtChc { get; set; }

            /// <summary>
            ///     Data da averbação da declaração de exportação
            /// </summary>
            [SpedCampos(10, "DT_AVB", "N", 8, 0, true)]
            public DateTime DtAvb { get; set; }

            /// <summary>
            ///     Tipo de conhecimento de embarque
            /// </summary>
            [SpedCampos(11, "TP_CHC", "N", 1, 0, true)]
            public int TpChc { get; set; }

            /// <summary>
            ///     Código do país de destino da mercadoria (conforme tabela do SISCOMEX)
            /// </summary>
            [SpedCampos(12, "PAIS", "N", 3, 0, true)]
            public int Pais { get; set; }

            public List<Registro1105> Reg1105s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1105: DOCUMENTOS FISCAIS DE EXPORTAÇÃO
        /// </summary>
        public class Registro1105 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1105" />.
            /// </summary>
            public Registro1105()
            {
                Reg = "1105";
            }

            /// <summary>
            ///     Código do modelo da NF
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Série da nota fiscal
            /// </summary>
            [SpedCampos(3, "SERIE", "C", 3, 0, false)]
            public string Serie { get; set; }

            /// <summary>
            ///     Nro da nota fiscal de exportação emitida pelo exportador
            /// </summary>
            [SpedCampos(4, "NUM_DOC", "N", 9, 0, true)]
            public int NumDoc { get; set; }

            /// <summary>
            ///     Chave da nota fiscal eletrônica
            /// </summary>
            [SpedCampos(5, "CHV_NFE", "N", 44, 0, false)]
            public string ChvNfe { get; set; }

            /// <summary>
            ///     Data da emissão da NF de exportação
            /// </summary>
            [SpedCampos(6, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(7, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            public List<Registro1110> Reg1110s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1110: OPERAÇÕES DE EXPORTAÇÃO INDIRETA - MERCADORIAS DE TERCEIROS
        /// </summary>
        public class Registro1110 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1110" />.
            /// </summary>
            public Registro1110()
            {
                Reg = "1110";
            }

            /// <summary>
            ///     Código do participante-fornecedor da mercadoria destinada à exportação
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, true)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo da NF
            /// </summary>
            [SpedCampos(3, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Série da nota fiscal
            /// </summary>
            [SpedCampos(4, "SERIE", "C", 3, 0, false)]
            public string Serie { get; set; }

            /// <summary>
            ///     Nro da nota fiscal recebida com fins específicos de exportação
            /// </summary>
            [SpedCampos(5, "NUM_DOC", "N", 9, 0, true)]
            public int NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão da NF de exportação
            /// </summary>
            [SpedCampos(6, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Chave da nota fiscal eletrônica
            /// </summary>
            [SpedCampos(7, "CHV_NFE", "N", 44, 0, false)]
            public string ChvNfe { get; set; }

            /// <summary>
            ///     Nro do memorando de exportação
            /// </summary>
            [SpedCampos(8, "NR_MEMO", "N", 0, 0, false)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade do item efetivamente exportado
            /// </summary>
            [SpedCampos(9, "QTD", "N", 0, 3, true)]
            public int Qtd { get; set; }

            /// <summary>
            ///     Unidade do item
            /// </summary>
            [SpedCampos(10, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1200: CONTROLE DE CRÉDITOS FISCAIS - ICMS
        /// </summary>
        public class Registro1200 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1200" />.
            /// </summary>
            public Registro1200()
            {
                Reg = "1200";
            }

            /// <summary>
            ///     Código de ajuste
            /// </summary>
            [SpedCampos(2, "COD_AJ_APUR", "C", 8, 0, true)]
            public string CodAjApur { get; set; }

            /// <summary>
            ///     Saldo de créditos fiscais de períodos anteriores
            /// </summary>
            [SpedCampos(3, "SLD_CRED", "N", 0, 2, true)]
            public decimal SldCred { get; set; }

            /// <summary>
            ///     Total de credito apropriado no mês
            /// </summary>
            [SpedCampos(4, "CRED_APR", "N", 0, 2, true)]
            public decimal CredApr { get; set; }

            /// <summary>
            ///     Total de créditos recebidos por transferência
            /// </summary>
            [SpedCampos(5, "CRED_RECEB", "N", 0, 2, true)]
            public decimal CredReceb { get; set; }

            /// <summary>
            ///     Total de créditos utilizados no período
            /// </summary>
            [SpedCampos(6, "CRED_UTIL", "N", 0, 2, true)]
            public decimal CredUtil { get; set; }

            /// <summary>
            ///     Saldo de crédito fiscal acumulado a transportar para o período seguinte
            /// </summary>
            [SpedCampos(7, "SLD_CRED_FIM", "N", 0, 2, true)]
            public decimal SldCredFim { get; set; }

            public List<Registro1210> Reg1210s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1210: UTILIZAÇÃO DE CRÉDITOS FISCAIS - ICMS
        /// </summary>
        public class Registro1210 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1210" />.
            /// </summary>
            public Registro1210()
            {
                Reg = "1210";
            }

            /// <summary>
            ///     Tipo de utilização do crédito
            /// </summary>
            [SpedCampos(2, "TIPO_UTIL", "C", 4, 0, true)]
            public string TipoUtil { get; set; }

            /// <summary>
            ///     Nro do documento utilizado na baixa de créditos
            /// </summary>
            [SpedCampos(3, "NR_DOC", "C", 0, 0, false)]
            public string NrDoc { get; set; }

            /// <summary>
            ///     Total de crédito utilizado
            /// </summary>
            [SpedCampos(4, "VL_CRED_UTIL", "N", 0, 2, true)]
            public decimal VlCredUtil { get; set; }

            /// <summary>
            ///     Chave de Documento Eletrônico
            /// </summary>
            [SpedCampos(5, "CHV_DOCe", "C", 44, 0, false)]
            public string ChvDocE { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1250: INFORMAÇÕES CONSOLIDADAS DE SALDOS DE RESTITUIÇÃO, RESSARCIMENTO E COMPLEMENTAÇÃO DO ICMS
        /// </summary>
        public class Registro1250 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1250" />.
            /// </summary>
            public Registro1250()
            {
                Reg = "1250";
            }

            /// <summary>
            ///    Informar o valor total do ICMS operação própria que o informante tem direito ao crédito, na forma prevista na legislação, referente às hipóteses de restituição em  que  há previsão deste crédito.
            /// </summary>
            [SpedCampos(2, "VL_CREDITO_ICMS_OP", "N", 0, 2, true)]
            public string VlCreditoIcmsOp { get; set; }

            /// <summary>
            ///     Informar o valor total do ICMS ST que o informante tem direito ao crédito, na forma prevista na legislação, referente às hipóteses de restituição em que há previsão deste crédito.
            /// </summary>
            [SpedCampos(3, "VL_ICMS_ST_REST", "N", 0, 2, true)]
            public decimal VlIcmsStRest { get; set; }

            /// <summary>
            ///     Informar o valor total do FCP_ST agregado ao valor do ICMS ST informado no campo “VL_ICMS_ST_REST”.
            /// </summary>
            [SpedCampos(4, "VL_FCP_ST_REST", "N", 0, 2, true)]
            public decimal VlFcpStRest { get; set; }

            /// <summary>
            ///     Informar o valor total do débito referente ao complemento do imposto, nos casos previstos na legislação.
            /// </summary>
            [SpedCampos(5, "VL_ICMS_ST_COMPL", "N", 0, 2, true)]
            public decimal VlIcmsStCompl { get; set; }

            /// <summary>
            ///    Informar  o valor total do FCP_ST agregado ao valor informado no campo “VL_ICMS_ST_COMPL"
            /// </summary>
            [SpedCampos(6, "VL_FCP_ST_COMPL", "N", 0, 2, true)]
            public decimal VlFcpStCompl { get; set; }

            public List<Registro1255> Reg1255s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1255: INFORMAÇÕES CONSOLIDADAS DE SALDOS DE RESTITUIÇÃO,RESSARCIMENTO E COMPLEMENTAÇÃO DO ICMS POR MOTIVO 
        /// </summary>
        public class Registro1255 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1255" />.
            /// </summary>
            public Registro1255()
            {
                Reg = "1255";
            }

            /// <summary>
            ///     Código  do  motivo  da restituição  ou  complementação conforme Tabela 5.7
            /// </summary>
            [SpedCampos(2, "COD_MOT_REST_COMPL", "C", 5, 2, true)]
            public string CodMotRestCompl { get; set; }

            /// <summary>
            ///     Informar o valor total do ICMS operação própria que o informante tem direito ao crédito, na forma prevista na legislação, referente às hipóteses de restituição em que há previsão deste crédito, para o mesmo “COD_MOT_REST_COMPL”
            /// </summary>
            [SpedCampos(3, "VL_CREDITO_ICMS_OP_MOT", "N", 0, 2, true)]
            public decimal VlCreditoIcmsOpMot { get; set; }

            /// <summary>
            ///     Informar o valor total do ICMS ST que o informante tem direito ao crédito, na forma prevista na legislação, referente às hipóteses de restituição em que há previsão deste crédito, para o mesmo “COD_MOT_REST_COMPL”
            /// </summary>
            [SpedCampos(4, "VL_ICMS_ST_REST_MOT", "N", 0, 2, true)]
            public decimal VlIcmsStRestMot { get; set; }

            /// <summary>
            ///     Informar o  alor total do FCP_ST agregado ao valor do ICMS ST informado no campo “VL_ICMS_ST_REST_MOT"
            /// </summary>
            [SpedCampos(5, "VL_FCP_ST_REST_MOT", "N", 0, 2, true)]
            public decimal VlFcpStRestMot { get; set; }

            /// <summary>
            ///     Informar o valor total do débito referente ao complemento do imposto, nos casos previstos na legislação, para o mesmo “COD_MOT_REST_COMPL”
            /// </summary>
            [SpedCampos(6, "VL_ICMS_ST_COMPL_MOT", "N", 0, 2, true)]
            public decimal VlIcmsStComplMot { get; set; }

            /// <summary>
            ///     Informar o valor total do FCP_ST agregado ao valor informado no campo “VL_ICMS_ST_COMPL_MOT”
            /// </summary>
            [SpedCampos(7, "VL_FCP_ST_COMPL_MOT", "N", 0, 2, true)]
            public decimal VlFcpStComplMot { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1300: MOVIMENTAÇÃO DIÁRIA DE COMBUSTÍVEIS
        /// </summary>
        public class Registro1300 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1300" />.
            /// </summary>
            public Registro1300()
            {
                Reg = "1300";
            }

            /// <summary>
            ///     Código do produto
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Data do fechamento da movimentação
            /// </summary>
            [SpedCampos(3, "DT_FECH", "N", 8, 0, true)]
            public DateTime DtFech { get; set; }

            /// <summary>
            ///     Estoque no início do dia (em litros)
            /// </summary>
            [SpedCampos(4, "ESTQ_ABERT", "N", 0, 3, true)]
            public decimal EstqAbert { get; set; }

            /// <summary>
            ///     Volume recebido no dia (em litros)
            /// </summary>
            [SpedCampos(5, "VOL_ENTR", "N", 0, 3, true)]
            public decimal VolEntr { get; set; }

            /// <summary>
            ///     Volume disponível no dia (em litros)
            /// </summary>
            [SpedCampos(6, "VOL_DISP", "N", 0, 3, true)]
            public decimal VolDisp { get; set; }

            /// <summary>
            ///     Volume total das saídas (em litros)
            /// </summary>
            [SpedCampos(7, "VOL_SAIDAS", "N", 0, 3, true)]
            public decimal VolSaidas { get; set; }

            /// <summary>
            ///     Estoque escritural (em litros)
            /// </summary>
            [SpedCampos(8, "ESTQ_ESCR", "N", 0, 3, true)]
            public decimal EstqEscr { get; set; }

            /// <summary>
            ///     Valor da perda (em litros)
            /// </summary>
            [SpedCampos(9, "VAL_AJ_PERDA", "N", 0, 3, true)]
            public decimal ValAjPerda { get; set; }

            /// <summary>
            ///     Valor do ganho (em litros)
            /// </summary>
            [SpedCampos(10, "VAL_AJ_GANHO", "N", 0, 3, true)]
            public decimal ValAjGanho { get; set; }

            /// <summary>
            ///     Estoque de fechamento (em litros)
            /// </summary>
            [SpedCampos(11, "FECH_FISICO", "N", 0, 3, true)]
            public decimal FechFisico { get; set; }

            public List<Registro1310> Reg1310s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1310: MOVIMENTAÇÃO DIÁRIA DE COMBUSTÍVEIS POR TANQUE
        /// </summary>
        public class Registro1310 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1310" />.
            /// </summary>
            public Registro1310()
            {
                Reg = "1310";
            }

            /// <summary>
            ///     Tanque que armazena o combustível
            /// </summary>
            [SpedCampos(2, "NUM_TANQUE", "C", 3, 0, true)]
            public string NumTanque { get; set; }

            /// <summary>
            ///     Estoque no início do dia (em litros)
            /// </summary>
            [SpedCampos(3, "ESTQ_ABERT", "N", 0, 3, true)]
            public decimal EstqAbert { get; set; }

            /// <summary>
            ///     Volume recebino no dia (em litros)
            /// </summary>
            [SpedCampos(4, "VOL_ENTR", "N", 0, 3, true)]
            public decimal VolEntr { get; set; }

            /// <summary>
            ///     Volume disponível (em litros)
            /// </summary>
            [SpedCampos(5, "VOL_DISP", "N", 0, 3, true)]
            public decimal VolDisp { get; set; }

            /// <summary>
            ///     Volume total das saídas (em litros)
            /// </summary>
            [SpedCampos(6, "VOL_SAIDAS", "N", 0, 3, true)]
            public decimal VolSaidas { get; set; }

            /// <summary>
            ///     Estoque escritural (em litros)
            /// </summary>
            [SpedCampos(7, "ESTQ_ESCR", "N", 0, 3, true)]
            public decimal EstqEscr { get; set; }

            /// <summary>
            ///     Valor da perda (em litros)
            /// </summary>
            [SpedCampos(8, "VAL_AJ_PERDA", "N", 0, 3, true)]
            public decimal ValAjPerda { get; set; }

            /// <summary>
            ///     Valor do ganho (em litros)
            /// </summary>
            [SpedCampos(9, "VAL_AJ_GANHO", "N", 0, 3, true)]
            public decimal VlAjGanho { get; set; }

            /// <summary>
            ///     Volume aferido no tanque, em litros. Estoque de fechamento físico do tanque
            /// </summary>
            [SpedCampos(10, "FECH_FISICO", "N", 0, 3, true)]
            public decimal FechFisico { get; set; }

            public List<Registro1320> Reg1320s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1320: VOLUME DE VENDAS
        /// </summary>
        public class Registro1320 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1320" />.
            /// </summary>
            public Registro1320()
            {
                Reg = "1320";
            }

            /// <summary>
            ///     Bico ligado à bomba
            /// </summary>
            [SpedCampos(2, "NUM_BICO", "N", 0, 0, true)]
            public long NumBico { get; set; }

            /// <summary>
            ///     Número da intervenção
            /// </summary>
            [SpedCampos(3, "NR_INTERV", "N", 0, 0, false)]
            public long? NrInterv { get; set; }

            /// <summary>
            ///     Motivo da intervenção
            /// </summary>
            [SpedCampos(4, "MOT_INTERV", "C", 50, 0, false)]
            public string MotInterv { get; set; }

            /// <summary>
            ///     Nome do interventor
            /// </summary>
            [SpedCampos(5, "NOM_INTERV", "C", 30, 0, false)]
            public string NomInterv { get; set; }

            /// <summary>
            ///     CNPJ da empresa responsável pela intervenção
            /// </summary>
            [SpedCampos(6, "CNPJ_INTERV", "N", 14, 0, false)]
            public string CnpjInterv { get; set; }

            /// <summary>
            ///     CPF do técnico responsável pela intervenção
            /// </summary>
            [SpedCampos(7, "CPF_INTERV", "N", 11, 0, false)]
            public string CpfInterv { get; set; }

            /// <summary>
            ///     Valor da leitura final do contador, no fechamento do bico
            /// </summary>
            [SpedCampos(8, "VAL_FECHA", "N", 0, 3, true)]
            public decimal ValFecha { get; set; }

            /// <summary>
            ///     Valor da leitura inicial do contador, na abertura do bico
            /// </summary>
            [SpedCampos(9, "VAL_ABERT", "N", 0, 3, true)]
            public decimal ValAbert { get; set; }

            /// <summary>
            ///     Aferições da bomba (em litros)
            /// </summary>
            [SpedCampos(10, "VOL_AFERI", "N", 0, 3, false)]
            public decimal VolAferi { get; set; }

            /// <summary>
            ///     Vendas do bico (em litros)
            /// </summary>
            [SpedCampos(11, "VOL_VENDAS", "N", 0, 3, true)]
            public decimal VolVendas { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1350: BOMBAS
        /// </summary>
        public class Registro1350 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1350" />.
            /// </summary>
            public Registro1350()
            {
                Reg = "1350";
            }

            /// <summary>
            ///     Número de série da bomba
            /// </summary>
            [SpedCampos(2, "SERIE", "C", 0, 0, true)]
            public string Serie { get; set; }

            /// <summary>
            ///     Nome do fabricante da bomba
            /// </summary>
            [SpedCampos(3, "FABRICANTE", "C", 60, 0, true)]
            public string Fabricante { get; set; }

            /// <summary>
            ///     Modelo da bomba
            /// </summary>
            [SpedCampos(4, "MODELO", "C", 0, 0, true)]
            public string Modelo { get; set; }

            /// <summary>
            ///     Identificador de medição: 0 - analógico; 1 - digital
            /// </summary>
            [SpedCampos(5, "TIPO_MEDICAO", "C", 1, 0, true)]
            public string TipoMedicao { get; set; }

            public List<Registro1360> Reg1360s { get; set; }
            public List<Registro1360> Reg1370s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1360: LACRES DA BOMBA
        /// </summary>
        public class Registro1360 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1360" />.
            /// </summary>
            public Registro1360()
            {
                Reg = "1360";
            }

            /// <summary>
            ///     Número do lacre associado na bomba
            /// </summary>
            [SpedCampos(2, "NUM_LACRE", "C", 20, 0, true)]
            public string NumLacre { get; set; }

            /// <summary>
            ///     Data de aplicação do lacre
            /// </summary>
            [SpedCampos(3, "DT_APLICACAO", "N", 8, 0, true)]
            public DateTime DtAplicacao { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1370: BICOS DA BOMBA
        /// </summary>
        public class Registro1370 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1370" />.
            /// </summary>
            public Registro1370()
            {
                Reg = "1370";
            }

            /// <summary>
            ///     Número sequencial do bico ligado a bomba
            /// </summary>
            [SpedCampos(2, "NUM_BICO", "N", 3, 0, true)]
            public int NumBico { get; set; }

            /// <summary>
            ///     Código do produto
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Tanque que armazena o combustível
            /// </summary>
            [SpedCampos(4, "NUM_TANQUE", "C", 3, 0, true)]
            public string NumTanque { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1390: CONTROLE DE PRODUÇÃO DE USINA
        /// </summary>
        public class Registro1390 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1390" />.
            /// </summary>
            public Registro1390()
            {
                Reg = "1390";
            }

            /// <summary>
            ///     01 - Alc. Etil. Hidratado Carburante; 02 - Alc. Etil. Anidro Carburante; 03 - Açúcar
            /// </summary>
            [SpedCampos(2, "COD_PROD", "N", 2, 0, true)]
            public int CodProd { get; set; }

            public List<Registro1391> Reg1391s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1391: PRODUÇÃO DIÁRIA DA USINA
        /// </summary>
        public class Registro1391 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1391" />.
            /// </summary>
            public Registro1391()
            {
                Reg = "1391";
            }

            /// <summary>
            ///     Data de produção
            /// </summary>
            [SpedCampos(2, "DT_REGISTRO", "C", 8, 0, true)]
            public DateTime DtRegistro { get; set; }

            /// <summary>
            ///     Quantidade de cana esmagada (toneladas)
            /// </summary>
            [SpedCampos(3, "QTD_MOID", "N", 0, 2, false)]
            public double? QtdMoid { get; set; }

            /// <summary>
            ///     Estoque inicial (litros / Kg)
            /// </summary>
            [SpedCampos(4, "ESTQ_INI", "N", 0, 2, true)]
            public double EstqIni { get; set; }

            /// <summary>
            ///     Quantidade produziada (litros / Kg)
            /// </summary>
            [SpedCampos(5, "QTD_PRODUZ", "N", 0, 2, false)]
            public double? QtdProduz { get; set; }

            /// <summary>
            ///     Entrada de álcool anidro/hidratado decorrente da transformação do álcool hidratado/anidro
            /// </summary>
            [SpedCampos(6, "ENT_ANID_HID", "N", 0, 2, false)]
            public double? EntAnidHid { get; set; }

            /// <summary>
            ///     Outras entradas (litros / Kg)
            /// </summary>
            [SpedCampos(7, "OUTR_ENTR", "N", 0, 2, false)]
            public double? OutrEntr { get; set; }

            /// <summary>
            ///     Evaporação (litros) ou quebra de peso (Kg)
            /// </summary>
            [SpedCampos(8, "PERDA", "N", 0, 2, false)]
            public double? Perda { get; set; }

            /// <summary>
            ///     Consumo (litros)
            /// </summary>
            [SpedCampos(9, "CONS", "N", 0, 2, false)]
            public double? Cons { get; set; }

            /// <summary>
            ///     Saída para transformação (litros)
            /// </summary>
            [SpedCampos(10, "SAI_ANI_HID", "N", 0, 2, false)]
            public double? SaiAniHid { get; set; }

            /// <summary>
            ///     Saídas (litros / Kg)
            /// </summary>
            [SpedCampos(11, "SAIDAS", "N", 0, 2, false)]
            public double? Saidas { get; set; }

            /// <summary>
            ///     Estoque final (litros / Kg)
            /// </summary>
            [SpedCampos(12, "ESTQ_FIN", "N", 0, 2, true)]
            public double EstqFin { get; set; }

            /// <summary>
            ///     Estoque inicial de mel residual (Kg)
            /// </summary>
            [SpedCampos(13, "ESTQ_INI_MEL", "N", 0, 2, false)]
            public double? EstqIniMel { get; set; }

            /// <summary>
            ///     Produção de mel residual (Kg) e entradas de mel (Kg)
            /// </summary>
            [SpedCampos(14, "PROD_DIA_MEL", "N", 0, 2, false)]
            public double? ProdDiaMel { get; set; }

            /// <summary>
            ///     Mel residual utilizado (Kg) e saídas de mel (Kg)
            /// </summary>
            [SpedCampos(15, "UTIL_MEL", "N", 0, 2, false)]
            public double? UtilMel { get; set; }

            /// <summary>
            ///     Produção de álcool (litros) ou açúcar (Kg) proveniente do mel residual
            /// </summary>
            [SpedCampos(16, "PROD_ALC_MEL", "N", 0, 2, false)]
            public double? ProdAlcMel { get; set; }

            /// <summary>
            ///     Observações
            /// </summary>
            [SpedCampos(17, "OBS", "C", 0, 0, false)]
            public string Obs { get; set; }

            /// <summary>
            ///     Informar o insumo conforme código do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(18, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Tipo de resíduo produzido
            /// </summary>
            /// <remarks>
            ///     01 – Bagaço de cana
            ///     02 - DDG
            ///     03 - WDG
            /// </remarks>
            [SpedCampos(19, "TP_RESIDUO", "N", 2, 0, false)]
            public int? TpResiduo { get; set; }

            /// <summary>
            ///     Quantidade de resíduo produzido (toneladas)
            /// </summary>
            [SpedCampos(19, "QTD_RESIDUO", "N", 0, 2, true)]
            public decimal QtdResiduo { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1400: INFORMAÇÃO SOBRE VALORES AGREGADOS
        /// </summary>
        public class Registro1400 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1400" />.
            /// </summary>
            public Registro1400()
            {
                Reg = "1400";
            }

            /// <summary>
            ///     Código do item - próprio IPM ou campo 02 do Registro 0200
            /// </summary>
            [SpedCampos(2, "COD_ITEM_IPM", "C", 60, 0, true)]
            public string CodItemIpm { get; set; }

            /// <summary>
            ///     Código IBGE do Município de origem/destino
            /// </summary>
            [SpedCampos(3, "MUN", "N", 7, 0, true)]
            public string Mun { get; set; }

            /// <summary>
            ///     Valor mensal correspondente ao município
            /// </summary>
            [SpedCampos(4, "VALOR", "N", 0, 2, true)]
            public decimal Valor { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1500: NOTA FISCAL/CONTA DE ENERGIA ELETRÉTRICA - OPERAÇÕES INTERESTADUAIS
        /// </summary>
        public class Registro1500 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1500" />.
            /// </summary>
            public Registro1500()
            {
                Reg = "1500";
            }

            /// <summary>
            ///     Indicador do tipo de operação
            /// </summary>
            /// <remarks>
            ///     1 - Saída
            /// </remarks>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true)]
            public int IndOper
            {
                get
                {
                    return 1;
                }
            }

            /// <summary>
            ///     Indicador do emitente do documento fiscal
            /// </summary>
            /// <remarks>
            ///     0 - Emissão própria
            /// </remarks>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true)]
            public int IndEmit
            {
                get
                {
                    return 0;
                }
            }

            /// <summary>
            ///     Código do participante
            /// </summary>
            /// <remarks>
            ///     - do adquirente, no caso das saídas
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
            public int CodSit { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(7, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(8, "SUB", "N", 3, 0, false)]
            public int Sub { get; set; }

            /// <summary>
            ///     Código de classe de consumo de energia elétrica
            /// </summary>
            /// <remarks>
            ///     01 - Comercial
            ///     02 - Consumo próprio
            ///     03 - Iluminação Pública
            ///     04 - Industrial
            ///     05 - Poder Público
            ///     06 - Residencial
            ///     07 - Rural
            ///     08 - Serviço Público
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
            ///     Valor total de despesas acessórias indicadas no documento fiscal
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
            ///     Valor acumulado do ICMS retido por substituição triutária
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
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(25, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Código de tipo de ligação
            /// </summary>
            /// <remarks>
            ///     1 - Monofásico
            ///     2 - Bifásico
            ///     3 - Trifásico
            /// </remarks>
            [SpedCampos(26, "TP_LIGACAO", "N", 1, 0, false)]
            public int TpLigacao { get; set; }

            /// <summary>
            ///     Código do grupo de tensão
            /// </summary>
            [SpedCampos(27, "COD_GRUPO_TENSAO", "C", 2, 0, false)]
            public int CodGrupoTensao { get; set; }

            public List<Registro1510> Reg1510s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1510: ITENS DO DOCUMENTO NOTA FISCAL/CONTA ENERGIA ELÉTRICA
        /// </summary>
        public class Registro1510 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1510" />.
            /// </summary>
            public Registro1510()
            {
                Reg = "1510";
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
            [SpedCampos(4, "COD_CLASS", "N", 4, 0, true)]
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
            ///     Alíquota do ICMS da substituição tributária na unidadde da federação de destino
            /// </summary>
            [SpedCampos(15, "ALIQ_ST", "N", 0, 2, false)]
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
            ///     1 - Receita de terceiros
            /// </remarks>
            [SpedCampos(17, "IND_REC", "C", 1, 0, true)]
            public int IndRec { get; set; }

            /// <summary>
            ///     Código do participante receptor da receita, terceiro da operação
            /// </summary>
            [SpedCampos(18, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Valor do PIS
            /// </summary>
            [SpedCampos(19, "VL_PIS", "N", 0, 2, false)]
            public decimal VlPis { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(20, "VL_COFINS", "N", 0, 2, false)]
            public decimal VlCofins { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil debitada/creditada
            /// </summary>
            [SpedCampos(21, "COD_CTA", "C", 99, 0, false)]
            public string CodCta { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1600: TOTAL DAS OPERAÇÕES COM CARTÃO DE CRÉDITO E/OU DÉBITO
        /// </summary>
        public class Registro1600 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1600" />.
            /// </summary>
            public Registro1600()
            {
                Reg = "1600";
            }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150): identificação da administradora do cartão de débito/crédito
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, true)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Valor total das operações realizadas no período referente a Cartão de Crédito
            /// </summary>
            [SpedCampos(3, "TOT_CREDITO", "N", 0, 2, true)]
            public decimal TotCredito { get; set; }

            /// <summary>
            ///     Valor total das operações realizadas no período referente a Cartão de Débito
            /// </summary>
            [SpedCampos(3, "TOT_DEBITO", "N", 0, 2, true)]
            public decimal TotDebito { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1700: DOCUMENTOS FISCAIS UTILIZADOS
        /// </summary>
        public class Registro1700 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1700" />.
            /// </summary>
            public Registro1700()
            {
                Reg = "1700";
            }

            /// <summary>
            ///     Código do dispositivo autorizado
            /// </summary>
            /// <remarks>
            ///     00 - Formulário de Segurança - impressor autônomo
            ///     01 - FS-DA - Formulário de Segurança para Impressão de DANFE
            ///     02 - Formulário de Segurança - NF-e
            ///     03 - Formulário Contínuo
            ///     04 - Blocos
            ///     05 - Jogos Soltos
            /// </remarks>
            [SpedCampos(2, "COD_DISP", "C", 2, 0, true)]
            public int CodDisp { get; set; }

            /// <summary>
            ///     Código do modelo do dispositivo autorizado
            /// </summary>
            [SpedCampos(3, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Série do dispositivo autorizado
            /// </summary>
            [SpedCampos(4, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do dispositivo autorizado
            /// </summary>
            [SpedCampos(5, "SUB", "C", 3, 0, false)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do dispositivo autorizado (utilizado) inicial
            /// </summary>
            [SpedCampos(6, "NUM_DOC_INI", "N", 12, 0, true)]
            public long NumDocIni { get; set; }

            /// <summary>
            ///     Número do dispositivo autorizado (utilizado) final
            /// </summary>
            [SpedCampos(7, "NUM_DOC_FIN", "N", 12, 0, true)]
            public long NumDocFin { get; set; }

            /// <summary>
            ///     Número da autorização, conforme dispositivo autorizado
            /// </summary>
            [SpedCampos(8, "NUM_AUT", "N", 60, 0, true)]
            public string NumAut { get; set; }

            public List<Registro1710> Reg1710s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1710: DOCUMENTOS FISCAIS CANCELADOS/INUTILIZADOS
        /// </summary>
        public class Registro1710 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1710" />.
            /// </summary>
            public Registro1710()
            {
                Reg = "1710";
            }

            /// <summary>
            ///     Número do dispositivo autorizado (inutilizado) inicial
            /// </summary>
            [SpedCampos(2, "NUM_DOC_INI", "N", 12, 0, true)]
            public long NumDocIni { get; set; }

            /// <summary>
            ///     Número do dispositivo autorizado (inutilizado) final
            /// </summary>
            [SpedCampos(3, "NUM_DOC_FIN", "N", 12, 0, true)]
            public long NumDocFin { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1800: DCTA - DEMONSTRATIVO DE CRÉDITO DO IMCS SOBRE TRANSPORTE AÉREO
        /// </summary>
        public class Registro1800 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1800" />.
            /// </summary>
            public Registro1800()
            {
                Reg = "1800";
            }

            /// <summary>
            ///     Valor das prestações cargas (tributado)
            /// </summary>
            [SpedCampos(2, "VL_CARGA", "N", 0, 2, true)]
            public decimal VlCarga { get; set; }

            /// <summary>
            ///     Valor das prestações passageiros/cargas(não tributado)
            /// </summary>
            [SpedCampos(3, "VL_PASS", "N", 0, 2, true)]
            public decimal VlPass { get; set; }

            /// <summary>
            ///     Valor total do faturamento
            /// </summary>
            [SpedCampos(4, "VL_FAT", "N", 0, 2, true)]
            public decimal VlFat { get; set; }

            /// <summary>
            ///     Índice para rateio
            /// </summary>
            [SpedCampos(5, "IND_RAT", "N", 8, 2, true)]
            public decimal IndRat { get; set; }

            /// <summary>
            ///     Valor total dos créditos do ICMS
            /// </summary>
            [SpedCampos(6, "VL_ICMS_ANT", "N", 0, 2, true)]
            public decimal VlIcmsAnt { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS
            /// </summary>
            [SpedCampos(7, "VL_BC_ICMS", "N", 0, 2, true)]
            public decimal VlBcIcms { get; set; }

            /// <summary>
            ///     Valor do ICMS apurado no cálculo
            /// </summary>
            [SpedCampos(8, "VL_ICMS_APUR", "N", 0, 2, true)]
            public decimal VlIcmsApur { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do ICMS apurada
            /// </summary>
            [SpedCampos(9, "VL_BC_ICMS_APUR", "N", 0, 2, true)]
            public decimal VlBcIcmsApur { get; set; }

            /// <summary>
            ///     Valor da diferença a ser levada a estorno de crédito na apuração
            /// </summary>
            [SpedCampos(10, "VL_DIF", "N", 0, 2, true)]
            public decimal VlDif { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1900: INDICADOR DE SUB-APURAÇÃO DO ICMS
        /// </summary>
        public class Registro1900 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1900" />.
            /// </summary>
            public Registro1900()
            {
                Reg = "1900";
            }

            /// <summary>
            ///     Indicador de outra apuração do ICMS
            /// </summary>
            /// <remarks>
            ///     3 - APURAÇÃO 1
            ///     4 - APURAÇÃO 2
            ///     5 - APURAÇÃO 3
            ///     6 - APURAÇÃO 4
            ///     7 - APURAÇÃO 5
            ///     8 - APURAÇÃO 6
            /// </remarks>
            [SpedCampos(2, "IND_APUR_ICMS", "C", 1, 0, true)]
            public int IndApurIcms { get; set; }

            /// <summary>
            ///     Descrição complementar de outra apuração do ICMS
            /// </summary>
            [SpedCampos(3, "DESCR_COMPL_OUT_APUR", "C", 1024, 0, true)]
            public string DescrComplOutApur { get; set; }

            public List<Registro1910> Reg1910s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1910: PERÍODO DA SUB-APURAÇÃO DO ICMS
        /// </summary>
        public class Registro1910 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1910" />.
            /// </summary>
            public Registro1910()
            {
                Reg = "1910";
            }

            /// <summary>
            ///     Data inicial da sub-apuração
            /// </summary>
            [SpedCampos(2, "DT_INI", "N", 8, 0, true)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///     Data final da sub-apuração
            /// </summary>
            [SpedCampos(3, "DT_FIN", "N", 8, 0, true)]
            public DateTime DtFin { get; set; }

            public Registro1920 Reg1920 { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1920: SUB-APURAÇÃO DO ICMS
        /// </summary>
        public class Registro1920 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1920" />.
            /// </summary>
            public Registro1920()
            {
                Reg = "1920";
            }

            /// <summary>
            ///     Valor total dos débitos por "Saídas e prestações com débito do imposto"
            /// </summary>
            [SpedCampos(2, "VL_TOT_TRANSF_DEBITOS_OA", "N", 0, 2, true)]
            public decimal VlTotTransfDebitosOa { get; set; }

            /// <summary>
            ///     Valor total de "Ajustes a débito"
            /// </summary>
            [SpedCampos(3, "VL_TOT_AJ_DEBITOS_OA", "N", 0, 2, true)]
            public decimal VlTotAjDebitosOa { get; set; }

            /// <summary>
            ///     Valor total de ajustes "Estornos de créditos"
            /// </summary>
            [SpedCampos(4, "VL_ESTORNOS_CRED_OA", "N", 0, 2, true)]
            public decimal VlEstornosCredOa { get; set; }

            /// <summary>
            ///     Valor total dos créditos por "Entradas e aquisições com crédito do imposto"
            /// </summary>
            [SpedCampos(5, "VL_TOT_TRANSF_CREDITOS_OA", "N", 0, 2, true)]
            public decimal VlTotTransfCreditosOa { get; set; }

            /// <summary>
            ///     Valor total de "Ajustes a crédito"
            /// </summary>
            [SpedCampos(6, "VL_TOT_AJ_CREDITOS_OA", "N", 0, 2, true)]
            public decimal VlTotAjCreditosOa { get; set; }

            /// <summary>
            ///     Valor total de ajustes "Estornos de Débitos"
            /// </summary>
            [SpedCampos(7, "VL_ESTORNOS_DEB_OA", "N", 0, 2, true)]
            public decimal VlEstornosDebOa { get; set; }

            /// <summary>
            ///     Valor total de "Saldo credor do período anterior"
            /// </summary>
            [SpedCampos(8, "VL_SLD_CREDOR_ANT_OA", "N", 0, 2, true)]
            public decimal VlSldCredorAntOa { get; set; }

            /// <summary>
            ///     Valor do saldo devedor apurado
            /// </summary>
            [SpedCampos(9, "VL_SLD_APURADO_OA", "N", 0, 2, true)]
            public decimal VlSldApuradoOa { get; set; }

            /// <summary>
            ///     Valor total de "Deduções"
            /// </summary>
            [SpedCampos(10, "VL_TOT_DED", "N", 0, 2, true)]
            public decimal VlTotDed { get; set; }

            /// <summary>
            ///     Valor total de "ICMS a recolher"
            /// </summary>
            [SpedCampos(11, "VL_ICMS_RECOLHER_OA", "N", 0, 2, true)]
            public decimal VlIcmsRecolherOa { get; set; }

            /// <summary>
            ///     Valor total de "Saldo credor a transportar para o período seguinte"
            /// </summary>
            [SpedCampos(12, "VL_SLD_CREDOR_TRANSP_OA", "N", 0, 2, true)]
            public decimal VlSldCredorTranspOa { get; set; }

            /// <summary>
            ///     Valores recolhidos ou a recolher, extra-apuração
            /// </summary>
            [SpedCampos(13, "DEB_ESP_OA", "N", 0, 2, true)]
            public decimal DebEspOa { get; set; }

            public List<Registro1921> Reg1921s { get; set; }
            public List<Registro1925> Reg1925s { get; set; }
            public List<Registro1926> Reg1926s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1921: AJUSTE/BENEFÍCIO/INCENTIVO DA SUB-APURAÇÃO DO ICMS
        /// </summary>
        public class Registro1921 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1921" />.
            /// </summary>
            public Registro1921()
            {
                Reg = "1921";
            }

            /// <summary>
            ///     Código de ajuste da SUB-APUARÇÃO e dedução
            /// </summary>
            [SpedCampos(2, "COD_AJ_APUR", "C", 8, 0, true)]
            public string CodAjApur { get; set; }

            /// <summary>
            ///     Descrição complementar do ajuste da apuração
            /// </summary>
            [SpedCampos(3, "DESCR_COMPL_AJ", "C", 1024, 0, false)]
            public string DescrComplAj { get; set; }

            /// <summary>
            ///     Valor do ajuste da apuração
            /// </summary>
            [SpedCampos(4, "VL_AJ_APUR", "N", 0, 2, true)]
            public decimal VlAjApur { get; set; }

            public List<Registro1922> Reg1922s { get; set; }
            public List<Registro1923> Reg1923s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1922: INFORMAÇÕES ADICIONAIS DOS AJUSTES DA SUB-APURAÇÃO DO ICMS
        /// </summary>
        public class Registro1922 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1922" />.
            /// </summary>
            public Registro1922()
            {
                Reg = "1922";
            }

            /// <summary>
            ///     Número do documento de arrecadação estadual, se houver
            /// </summary>
            [SpedCampos(2, "NUM_DA", "C", 100, 0, false)]
            public string NumDa { get; set; }

            /// <summary>
            ///     Número do processo ao qual o ajuste está vinculado, se houver
            /// </summary>
            [SpedCampos(3, "NUM_PROC", "C", 15, 0, false)]
            public string NumProc { get; set; }

            /// <summary>
            ///     Indicador da origem do processo
            /// </summary>
            /// <remarks>
            ///     0 - SEFAZ
            ///     1 - Justiça Federal
            ///     2 - Justiça Estadual
            ///     9 - Outros
            /// </remarks>
            [SpedCampos(4, "IND_PROC", "C", 1, 0, false)]
            public int IndProc { get; set; }

            /// <summary>
            ///     Descrição resumida do processo que embasou o lançamento
            /// </summary>
            [SpedCampos(5, "PROC", "C", 9999, 0, false)]
            public string Proc { get; set; }

            /// <summary>
            ///     Descrição complementar
            /// </summary>
            [SpedCampos(6, "TXT_COMPL", "C", 1024, 0, false)]
            public string TxtCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1923: INFORMAÇÕES ADICIONAIS DOS AJUSTES DA SUB-APURAÇÃO DO ICMS - IDENTIFICAÇÃO DOS DOCUMENTOS FISCAIS
        /// </summary>
        public class Registro1923 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1923" />.
            /// </summary>
            public Registro1923()
            {
                Reg = "1923";
            }

            /// <summary>
            ///     Código do participante
            /// </summary>
            /// <remarks>
            ///     - do emitente do documento ou do remetente das mercadorias, no caso das entradas
            ///     - do adquirente, no caso das saídas
            /// </remarks>
            [SpedCampos(2, "COD_PART", "C", 60, 0, true)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal
            /// </summary>
            [SpedCampos(3, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

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
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(6, "NUM_DOC", "N", 9, 0, true)]
            public long NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(7, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(8, "COD_ITEM", "C", 60, 0, false)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Valor do ajuste para a operação/item
            /// </summary>
            [SpedCampos(9, "VL_AJ_ITEM", "N", 0, 2, true)]
            public decimal VlAjItem { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1925: INFORMAÇÕES ADICIONAIS DA SUB-APURAÇÃO - VALORES DECLARATÓRIOS
        /// </summary>
        public class Registro1925 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1925" />.
            /// </summary>
            public Registro1925()
            {
                Reg = "1925";
            }

            /// <summary>
            ///     Código da informação adicional conforme tabela a ser definida pelas SEFAZ
            /// </summary>
            [SpedCampos(2, "COD_INF_ADIC", "C", 8, 0, true)]
            public string CodInfAdic { get; set; }

            /// <summary>
            ///     Valor referente à informação adicional
            /// </summary>
            [SpedCampos(3, "VL_INF_ADIC", "N", 0, 2, true)]
            public decimal VlInfAdic { get; set; }

            /// <summary>
            ///     Descrição complementar do ajuste
            /// </summary>
            [SpedCampos(4, "DESCR_COMPL_AJ", "C", 1024, 0, false)]
            public string DescrComplAj { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1926: OBRIGAÇÕES DO ICMS A RECOLHER - OPERAÇÕES REFERENTES À SUB-APURAÇÃO
        /// </summary>
        public class Registro1926 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1926" />.
            /// </summary>
            public Registro1926()
            {
                Reg = "1926";
            }

            /// <summary>
            ///     Código da obrigação a recolher
            /// </summary>
            [SpedCampos(2, "COD_OR", "C", 3, 0, true)]
            public string CodOr { get; set; }

            /// <summary>
            ///     Valor da obrigação a recolher
            /// </summary>
            [SpedCampos(3, "VL_OR", "N", 0, 2, true)]
            public decimal VlOr { get; set; }

            /// <summary>
            ///     Data de vencimento da obrigação
            /// </summary>
            [SpedCampos(4, "DT_VCTO", "N", 8, 0, true)]
            public DateTime DtVcto { get; set; }

            /// <summary>
            ///     Código de receita referente à obrigação, próprio da unidade da federação, conforme legislação estadual
            /// </summary>
            [SpedCampos(5, "COD_REC", "C", 100, 0, true)]
            public string CodRec { get; set; }

            /// <summary>
            ///     Número do processo ou auto de infração ao qual a obrigação está vinculada, se houver
            /// </summary>
            [SpedCampos(6, "NUM_PROC", "C", 15, 0, false)]
            public string NumProc { get; set; }

            /// <summary>
            ///     Indicador da orgiem do processo
            /// </summary>
            /// <remarks>
            ///     0 - SEFAZ
            ///     1 - Justiça Federal
            ///     2 - Justiça Estadual
            ///     9 - Outros
            /// </remarks>
            [SpedCampos(7, "IND_PROC", "C", 1, 0, false)]
            public int IndProc { get; set; }

            /// <summary>
            ///     Descrição resumida do processo que embasou o lançamento
            /// </summary>
            [SpedCampos(8, "PROC", "C", 1024, 0, false)]
            public string Proc { get; set; }

            /// <summary>
            ///     Descrição complementar das obrigações a recolher
            /// </summary>
            [SpedCampos(9, "TXT_COMPL", "C", 1024, 0, false)]
            public string TxtCompl { get; set; }

            /// <summary>
            ///     Mês de referência
            /// </summary>
            [SpedCampos(10, "MES_REF", "MA", 6, 0, true)]
            public DateTime MesRef { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1960: GIAF 1 - GUIA DE INFORMAÇÃO E APURAÇÃO DE INCENTIVOS FISCAIS E FINANCEIROS: INDÚSTRIA (CRÉDITO PRESUMIDO)
        /// </summary>
        public class Registro1960 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1960" />.
            /// </summary>
            public Registro1960()
            {
                Reg = "1960";
            }

            /// <summary>
            ///     Indicador da sub-apuração por tipo de benefício (conforme tabela 4.7.1)
            /// </summary>
            [SpedCampos(2, "IND_AP", "N", 2, 0, true)]
            public int IndAp{ get; set; }

            /// <summary>
            ///     Percentual de crédito presumido
            /// </summary>
            [SpedCampos(3, "G1_01", "N", 0, 2, true)]
            public int G101 { get; set; }

            /// <summary>
            ///     Saídas não incentivadas de PI 
            /// </summary>
            [SpedCampos(4, "G1_02", "N", 0, 2, true)]
            public int G102{ get; set; }

            /// <summary>
            ///     Saídas incentivadas de PI
            /// </summary>
            [SpedCampos(5, "G1_03", "N", 0, 2, true)]
            public int G103 { get; set; }

            /// <summary>
            ///     Saídas incentivadas de PI para fora do Nordeste
            /// </summary>
            [SpedCampos(6, "G1_04", "N", 0, 2, true)]
            public int G104 { get; set; }

            /// <summary>
            ///     Saldo devedor do ICMS antes das deduções do incentivo
            /// </summary>
            [SpedCampos(7, "G1_05", "N", 0, 2, true)]
            public int G105 { get; set; }

            /// <summary>
            ///     Saldo devedor do ICMS relativo à faixa incentivada de PI 
            /// </summary>
            [SpedCampos(8, "G1_06", "N", 0, 2, true)]
            public int G106 { get; set; }

            /// <summary>
            ///     Crédito presumido nas saídas incentivadas de PI para fora do Nordeste
            /// </summary>
            [SpedCampos(9, "G1_07", "N", 0, 2, true)]
            public int G107 { get; set; }

            /// <summary>
            ///    Saldo devedor relativo à faixa incentivada de PI após o crédito presumido nas saídas para fora do Nordeste
            /// </summary>
            [SpedCampos(10, "G1_08", "N", 0, 2, true)]
            public int G108 { get; set; }

            /// <summary>
            ///    Crédito presumido
            /// </summary>
            [SpedCampos(11, "G1_09", "N", 0, 2, true)]
            public int G109 { get; set; }

            /// <summary>
            ///     Dedução de incentivo da Indústria (crédito presumido)
            /// </summary>
            [SpedCampos(12, "G1_10", "N", 0, 2, true)]
            public int G110 { get; set; }

            /// <summary>
            ///     Saldo devedor do ICMS após deduções
            /// </summary>
            [SpedCampos(13, "G1_11", "N", 0, 2, true)]
            public int G111 { get; set; }

        }

        /// <summary>
        ///     REGISTRO 1970: GIAF 3 - GUIA DE INFORMAÇÃO E APURAÇÃO DE INCENTIVOS FISCAIS E FINANCEIROS: IMPORTAÇÃO (DIFERIMENTO NA ENTRADA E CRÉDITO PRESUMIDO NA SAÍDA SUBSEQUENTE)
        /// </summary>
        public class Registro1970 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1970" />.
            /// </summary>
            public Registro1970()
            {
                Reg = "1970";
            }

            /// <summary>
            ///     Indicador da sub-apuração por tipo de benefício (conforme tabela 4.7.1)
            /// </summary>
            [SpedCampos(2, "IND_AP", "N", 2, 0, true)]
            public int IndAp { get; set; }

            /// <summary>
            ///     Importações com ICMS diferido
            /// </summary>
            [SpedCampos(3, "G3_01", "N", 0, 2, true)]
            public int G301 { get; set; }

            /// <summary>
            ///     ICMS diferido nas importações
            /// </summary>
            [SpedCampos(4, "G3_02", "N", 0, 2, true)]
            public int G302 { get; set; }

            /// <summary>
            ///    Saídas não incentivadas de PI
            /// </summary>
            [SpedCampos(5, "G3_03", "N", 0, 2, true)]
            public int G303 { get; set; }

            /// <summary>
            ///   Percentual de incentivo nas saídas para fora do Estado
            /// </summary>
            [SpedCampos(6, "G3_04", "N", 0, 2, true)]
            public int G304 { get; set; }

            /// <summary>
            ///     Saídas incentivadas de PI para fora do Estado
            /// </summary>
            [SpedCampos(7, "G3_05", "N", 0, 2, true)]
            public int G305 { get; set; }

            /// <summary>
            ///     ICMS das saídas incentivadas de PI para fora do Estado
            /// </summary>
            [SpedCampos(8, "G3_06", "N", 0, 2, true)]
            public int G306 { get; set; }

            /// <summary>
            ///     Crédito presumido nas saídas para fora do Estado.
            /// </summary>
            [SpedCampos(9, "G3_07", "N", 0, 2, true)]
            public int G307 { get; set; }

            /// <summary>
            ///    Dedução de incentivo da Importação (crédito presumido)
            /// </summary>
            [SpedCampos(10, "G3_T", "N", 0, 2, true)]
            public int G3T { get; set; }

            /// <summary>
            ///    Saldo devedor do ICMS antes das deduções do incentivo
            /// </summary>
            [SpedCampos(11, "G3_08", "N", 0, 2, true)]
            public int G308 { get; set; }

            /// <summary>
            ///    Saldo devedor do ICMS após deduções do incentivo
            /// </summary>
            [SpedCampos(12, "G3_09", "N", 0, 2, true)]
            public int G309 { get; set; }

            public List<Registro1975> Registro1975s { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1975: GIAF 3 - GUIA DE INFORMAÇÃO E APURAÇÃO DE INCENTIVOS FISCAIS  E  FINANCEIROS: IMPORTAÇÃO (SAÍDAS INTERNAS POR FAIXA  DE ALÍQUOTA)
        /// </summary>
        public class Registro1975 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1975" />.
            /// </summary>
            public Registro1975()
            {
                Reg = "1975";
            }

            /// <summary>
            ///     Alíquota incidente sobre as importações-base
            /// </summary>
            [SpedCampos(2, "ALIQ_IMP_BASE", "N", 0, 2, true)]
            public int AliqImpBase { get; set; }

            /// <summary>
            ///     Saídas incentivadas de PI 
            /// </summary>
            [SpedCampos(3, "G3_10", "N", 0, 2, true)]
            public int G310 { get; set; }

            /// <summary>
            ///    Importações-base para o crédito presumido 
            /// </summary>
            [SpedCampos(4, "G3_11", "N", 0, 2, true)]
            public int G311 { get; set; }

            /// <summary>
            ///   Crédito presumido nas saídas internas
            /// </summary>
            [SpedCampos(5, "G3_12", "N", 0, 2, true)]
            public int G312 { get; set; }
        }

        /// <summary>
        ///     REGISTRO 1980: GIAF 4 GUIA DE INFORMAÇÃO E APURAÇÃO DE  INCENTIVOS FISCAIS E FINANCEIROS: CENTRAL DE DISTRIBUIÇÃO (ENTRADAS/SAÍDAS)
        /// </summary>
        public class Registro1980 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1980" />.
            /// </summary>
            public Registro1980()
            {
                Reg = "1980";
            }

            /// <summary>
            ///     Indicador da sub-apuração por tipo de benefício (conforme Tabela 4.7.1)
            /// </summary>
            [SpedCampos(2, "IND_AP", "N", 2, 0, true)]
            public int IndAp { get; set; }

            /// <summary>
            ///    Entradas (percentual de incentivo)
            /// </summary>
            [SpedCampos(3, "G4_01", "N", 0, 2, true)]
            public int G401 { get; set; }

            /// <summary>
            ///     Entradas não incentivadas de PI 
            /// </summary>
            [SpedCampos(4, "G4_02", "N", 0, 2, true)]
            public int G402 { get; set; }

            /// <summary>
            ///   Entradas incentivadas de PI
            /// </summary>
            [SpedCampos(5, "G4_03", "N", 0, 2, true)]
            public int G403 { get; set; }

            /// <summary>
            ///   Saídas (percentual de incentivo)
            /// </summary>
            [SpedCampos(6, "G4_04", "N", 0, 2, true)]
            public int G404 { get; set; }

            /// <summary>
            ///     Saídas não incentivadas de PI 
            /// </summary>
            [SpedCampos(7, "G4_05", "N", 0, 2, true)]
            public int G405 { get; set; }

            /// <summary>
            ///     Saídas incentivadas de P
            /// </summary>
            [SpedCampos(8, "G4_06", "N", 0, 2, true)]
            public int G406 { get; set; }

            /// <summary>
            ///     Saldo devedor do ICMS antes das deduções do incentivo (PI e itens não incentivados)
            /// </summary>
            [SpedCampos(9, "G4_07", "N", 0, 2, true)]
            public int G407 { get; set; }

            /// <summary>
            ///    Crédito presumido nas entradas incentivadas de PI 
            /// </summary>
            [SpedCampos(10, "G4_08", "N", 0, 2, true)]
            public int G408 { get; set; }

            /// <summary>
            ///    Crédito presumido nas saídas incentivadas de PI 
            /// </summary>
            [SpedCampos(11, "G4_09", "N", 0, 2, true)]
            public int G409 { get; set; }

            /// <summary>
            ///    Dedução de incentivo da Central de Distribuição (entradas/saídas)
            /// </summary>
            [SpedCampos(12, "G4_10", "N", 0, 2, true)]
            public int G410 { get; set; }

            /// <summary>
            ///    Saldo devedor do ICMS após deduções do incentivo
            /// </summary>
            [SpedCampos(13, "G4_11", "N", 0, 2, true)]
            public int G411 { get; set; }

            /// <summary>
            ///    Índice de recolhimento da central de distribuição
            /// </summary>
            [SpedCampos(14, "G4_12", "N", 0, 2, true)]
            public int G412 { get; set; }
        }


        /// <summary>
        ///     REGISTRO 1990: ENCERRAMENTO DO BLOCO 1
        /// </summary>
        public class Registro1990 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro1990" />.
            /// </summary>
            public Registro1990()
            {
                Reg = "1990";
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco 1.
            /// </summary>
            [SpedCampos(2, "QTD_LIN_1", "N", int.MaxValue, 0, true)]
            public int QtdLin1 { get; set; }
        }

    }
}
