using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDFiscal
{
    /// <summary>
    ///     BLOCO B: ESCRITURAÇÃO E APURAÇÃO DO ISS
    /// </summary>
    public class BlocoB
    {
        public RegistroB001 RegB001 { get; set; }
        public RegistroB990 RegB990 { get; set; }

        /// <summary>
        ///     REGISTRO B001: ABERTURA DO BLOCO B
        /// </summary>
        public class RegistroB001 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB001" />.
            /// </summary>
            public RegistroB001()
            {
                Reg = "B001";
            }

            /// <summary>
            ///     Indicador de movimento: 0 - Bloco com dados informados; 1 - Bloco sem dados informados.
            /// </summary>
            [SpedCampos(2, "IND_DAD", "C", 1, 0, true)]
            public int IndDad { get; set; }

            public RegistroB020 RegB020 { get; set; }
            public RegistroB030 RegB030 { get; set; }
            public RegistroB350 RegB350 { get; set; }
            public RegistroB420 RegB420 { get; set; }
            public RegistroB440 RegB440 { get; set; }
            public RegistroB460 RegB460 { get; set; }
            public RegistroB470 RegB470 { get; set; }
            public RegistroB500 RegB500 { get; set; }
           
        }

        /// <summary>
        ///   REGISTRO B020: NOTA FISCAL (CÓDIGO 01),NOTA FISCAL DE SERVIÇOS (CÓDIGO 03), NOTA FISCAL DE SERVIÇOS AVULSA (CÓDIGO 3B), NOTA FISCAL DE PRODUTOR (CÓDIGO 04), CONHECIMENTO DE  TRANSPORTE  RODOVIÁRIO DE CARGAS (CÓDIGO 08), NF-e (CÓDIGO 55) e NFC-e (CÓDIGO 65).
        /// </summary>
        public class RegistroB020 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB020" />.
            /// </summary>
            public RegistroB020()
            {
                Reg = "B020";
            }

            /// <summary>
            ///    Indicador do tipo de operação: 0 - Aquisição; 1 - Prestação.
            /// </summary>
            [SpedCampos(2, "IND_OPER", "C", 1, 0, true)]
            public int IndOper { get; set; }

            /// <summary>
            ///   Indicador do emitente do documento fiscal: 0 - Emissão própria;1 -Terceiros
            /// </summary>
            [SpedCampos(3, "IND_EMIT", "C", 1, 0, true)]
            public int IndEmit { get; set; }

            /// <summary>
            ///   Código do participante (campo 02 do Registro 0150):-do prestador, no caso de declarante na condição de tomador;- do tomador, no caso de declarante na condição de prestador
            /// </summary>
            [SpedCampos(4, "IND_PART", "C", 1, 60, false)]
            public int IndPart { get; set; }

            /// <summary>
            ///   Código do modelo do documento fiscal, conforme a Tabela 4.1.3
            /// </summary>
            [SpedCampos(5, "COD_MOD", "C", 2, 0, true)]
            public int CodMod { get; set; }

            /// <summary>
            ///    Código   da   situação   do   documento conforme tabela 4.1.2
            /// </summary>
            [SpedCampos(6, "COD_SIT", "N", 2, 0, true)]
            public int CodSit { get; set; }

            /// <summary>
            ///    Série do documento fiscal
            /// </summary>
            [SpedCampos(7, "SER", "C", 3, 0, false)]
            public int Ser { get; set; }

            /// <summary>
            ///    Número do documento fiscal
            /// </summary>
            [SpedCampos(8, "NUM_DOC", "N", 9, 0, true)]
            public int NumDoc { get; set; }

            /// <summary>
            ///    Chave da Nota Fiscal Eletrônica
            /// </summary>
            [SpedCampos(9, "CHV_NFE", "N", 44, 0, false)]
            public int ChvNfe { get; set; }

            /// <summary>
            ///    Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(10, "DT_DOC", "N", 8, 0, true)]
            public int DtDoc { get; set; }

            /// <summary>
            ///    Código do município onde o serviço foi prestado, conforme a tabela IBGE.
            /// </summary>
            [SpedCampos(11, "COD_MUN_SERV", "C", 7, 0, true)]
            public int CodMunServ { get; set; }

            /// <summary>
            ///    Valor contábil (valor total do documento)
            /// </summary>
            [SpedCampos(12, "VL_CONT", "N", 2, 0, true)]
            public int VlCont { get; set; }

            /// <summary>
            ///   Valor do material fornecido por terceiros na prestação do serviço
            /// </summary>
            [SpedCampos(13, "VL_MAT_TERC", "N", 0, 2, true)]
            public int VlMatTerc { get; set; }

            /// <summary>
            ///    Valor da subempreitada
            /// </summary>
            [SpedCampos(14, "VL_SUB", "N", 0, 2, true)]
            public int VlSub { get; set; }

            /// <summary>
            ///    Valor das operações  isentas  ou  não-tributadas pelo ISS
            /// </summary>
            [SpedCampos(15, "VL_ISNT_ISS", "N", 0, 2, true)]
            public int VlIsntIss { get; set; }

            /// <summary>
            ///    Valor da dedução da base de cálculo
            /// </summary>
            [SpedCampos(16, "VL_DED_BC", "N", 0, 2, true)]
            public int VlDedBc { get; set; }

            /// <summary>
            ///    Valor da base de cálculo do ISS
            /// </summary>
            [SpedCampos(17, "VL_BC_ISS", "N", 0, 2, true)]
            public int VlBcIss { get; set; }

            /// <summary>
            ///    Valor da base de cálculo de retenção do ISS
            /// </summary>
            [SpedCampos(18, "VL_BC_ISS_RT", "N", 0, 2, true)]
            public int VlBcIssRt { get; set; }

            /// <summary>
            ///    Valor do ISS retido pelo tomador
            /// </summary>
            [SpedCampos(19, "VL_ISS_RT", "N", 0, 2, true)]
            public int VlIssRt { get; set; }

            /// <summary>
            ///    Valor do ISS destacado
            /// </summary>
            [SpedCampos(20, "VL_ISS", "N", 0, 2, true)]
            public int VlIss { get; set; }

            /// <summary>
            ///    Código da observação do lançamento   fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(21, "COD_INF_OBS", "C", 60, 0, false)]
            public int CodInfObs { get; set; }

            public List<RegistroB025> RegB025 { get; set; }
        }

        /// <summary>
        ///   REGISTRO B025: DETALHAMENTO POR COMBINAÇÃO DE ALÍQUOTA E ITEM DA LISTA DE SERVIÇOS DA LC 116/2003)
        /// </summary>
        public class RegistroB025 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB025" />.
            /// </summary>
            public RegistroB025()
            {
                Reg = "B025";
            }

            /// <summary>
            ///   Parcela  correspondente  ao  “Valor Contábil”  referente  à  combinação da alíquota e item da lista
            /// </summary>
            [SpedCampos(2, "VL_CONT_P", "N", 0, 2, true)]
            public int VlContP { get; set; }

            /// <summary>
            ///   Parcela correspondente ao “Valor da base de cálculo do ISS” referente à combinação da alíquota e item da lista
            /// </summary>
            [SpedCampos(3, "VL_BC_ISS_P", "N", 0, 2, true)]
            public int VlBcIssP { get; set; }

            /// <summary>
            ///   Alíquota do ISS
            /// </summary>
            [SpedCampos(4, "ALIQ_ISS", "N", 0, 2, true)]
            public int AliqIss { get; set; }

            /// <summary>
            ///   Parcela correspondente  ao  “Valor do ISS” referente à combinação da alíquota e item da lista
            /// </summary>
            [SpedCampos(5, "VL_ISS_P", "N", 0, 2, true)]
            public int VlIssP { get; set; }

            /// <summary>
            ///    Parcela correspondente ao “Valor das operações isentas ou não-tributadas pelo ISS” referente à combinação da alíquota e item da lista
            /// </summary>
            [SpedCampos(6, "VL_ISNT_ISS_P", "N", 0, 2, true)]
            public int VlIsntIssP { get; set; }

            /// <summary>
            ///    Item da lista de serviços, conforme Tabela 4.6.3
            /// </summary>
            [SpedCampos(7, "COD_SERV", "C", 4, 0, true)]
            public int CodServ { get; set; }

        }

        /// <summary>
        ///   REGISTRO B030: NOTA FISCAL DE SERVIÇOS SIMPLIFICADA (CÓDIGO 3A)
        /// </summary>
        public class RegistroB030 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB030" />.
            /// </summary>
            public RegistroB030()
            {
                Reg = "B030";
            }

            /// <summary>
            ///    Código do modelo do documento fiscal, conforme a Tabela 4.1.3
            /// </summary>
            [SpedCampos(2, "COD_MOD", "C", 2, 0, true)]
            public int CodMod { get; set; }

            /// <summary>
            ///  Série do documento fiscal
            /// </summary>
            [SpedCampos(3, "SER", "C", 3, 0, false)]
            public int Ser { get; set; }

            /// <summary>
            ///   Número do primeiro documento fiscal emitido no dia
            /// </summary>
            [SpedCampos(4, "NUM_DOC_INI", "N", 9, 0, true)]
            public int NumDocIni { get; set; }

            /// <summary>
            ///   Número  do  último  documento  fiscal emitido no dia
            /// </summary>
            [SpedCampos(5, "NUM_DOC_FIN", "N", 9, 0, true)]
            public int NumDocFin { get; set; }

            /// <summary>
            ///   Data   da   emissão   dos   documentos fiscais
            /// </summary>
            [SpedCampos(6, "DT_DOC", "N", 8, 0, true)]
            public int DtDoc { get; set; }

            /// <summary>
            ///   Quantidade de documentos cancelados
            /// </summary>
            [SpedCampos(7, "QTD_DOC", "N", 0, 0, true)]
            public int QtdDoc { get; set; }

            /// <summary>
            ///   Valor contábil (valor total acumulado dos documentos)
            /// </summary>
            [SpedCampos(8, "VL_CONT", "N", 0, 2, true)]
            public int VlCont { get; set; }

            /// <summary>
            ///   Valor acumulado das operações isentas ou não-tributadas pelo ISS
            /// </summary>
            [SpedCampos(9, "VL_ISNT_ISS", "N", 0, 0, true)]
            public int VlIsntIss { get; set; }

            /// <summary>
            ///    Valor acumulado da base de cálculo do ISS
            /// </summary>
            [SpedCampos(10, "VL_BC_ISS", "N", 0, 2, true)]
            public int VlBcIss { get; set; }

            /// <summary>
            ///    Valor acumulado do ISS destacado
            /// </summary>
            [SpedCampos(11, "VL_ISS", "N", 0, 2, true)]
            public int VlIss { get; set; }

            /// <summary>
            ///   Código da observação do lançamento fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(12, "CodInfObs", "C", 60, 0, false)]
            public int CodInfObs{ get; set; }

        }

        /// <summary>
        ///   REGISTRO B035: DETALHAMENTO POR COMBINAÇÃO DE ALÍQUOTA E ITEM DA LISTA DE SERVIÇOS DA LC 116/2003)
        /// </summary>
        public class RegistroB035 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB035" />.
            /// </summary>
            public RegistroB035()
            {
                Reg = "B035";
            }

            /// <summary>
            ///   Parcela correspondente ao “Valor Contábil” referente  à combinação  da  alíquota e item da lista
            /// </summary>
            [SpedCampos(2, "VL_CONT_P", "N", 0, 2, true)]
            public int VlContP { get; set; }

            /// <summary>
            ///  Parcela correspondente ao “Valor  da  base  de  cálculo  do ISS”  referente  à  combinação  da alíquota e item da lista
            /// </summary>
            [SpedCampos(3, "VL_BC_ISS_P", "N", 0, 2, true)]
            public int VlBcIssP { get; set; }

            /// <summary>
            ///   Alíquota do ISS
            /// </summary>
            [SpedCampos(4, "ALIQ_ISS", "N", 0, 2, true)]
            public int AlinqIss { get; set; }

            /// <summary>
            ///   Parcela correspondente ao “Valor do ISS” referente à combinação da alíquota e item da lista
            /// </summary>
            [SpedCampos(5, "VL_ISS_P", "N", 0, 2, true)]
            public int VlIssP { get; set; }

            /// <summary>
            ///   Parcela correspondente ao “Valor  das operações isentas  ou não-tributadas pelo ISS” referente  à  combinação da alíquota e item da lista
            /// </summary>
            [SpedCampos(6, "VL_ISNT_ISS_P", "N", 0, 2, true)]
            public int VlIsntIssP { get; set; }

            /// <summary>
            ///   Item  da lista de serviços, conforme Tabela 4.6.3.
            /// </summary>
            [SpedCampos(7, "COD_SERV", "C", 4, 0, true)]
            public int CodServ { get; set; }

        }

        /// <summary>
        ///  REGISTRO B350: SERVIÇOS PRESTADOS POR INSTITUIÇÕES FINANCEIRAS
        /// </summary>
        public class RegistroB350 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB350" />.
            /// </summary>
            public RegistroB350()
            {
                Reg = "B350";
            }

            /// <summary>
            ///    Código da conta do plano de contas
            /// </summary>
            [SpedCampos(2, "COD_CTD", "C", 0, 0, true)]
            public int CodCtd { get; set; }

            /// <summary>
            ///  Descrição da conta no plano de contas
            /// </summary>
            [SpedCampos(3, "CTA_ISS", "C", 0, 0, true)]
            public int CtaIss { get; set; }

            /// <summary>
            ///   Código COSIF a que está subordinada a conta do ISS das instituições financeiras
            /// </summary>
            [SpedCampos(4, "CTA_COSIF", "N", 8, 0, true)]
            public int CtaCosif { get; set; }

            /// <summary>
            ///   Quantidade de ocorrências na conta
            /// </summary>
            [SpedCampos(5, "QTD_OCOR", "N", 0, 0, true)]
            public int QtdOcor { get; set; }

            /// <summary>
            ///   Item da lista de serviços, conforme Tabela 4.6.3.
            /// </summary>
            [SpedCampos(6, "COD_SERV", "N", 4, 0, true)]
            public int CodServ { get; set; }

            /// <summary>
            ///  Valor contábil
            /// </summary>
            [SpedCampos(7, "VL_CONT", "N", 0, 2, true)]
            public int VlCont { get; set; }

            /// <summary>
            ///   Valor da base de cálculo do ISS
            /// </summary>
            [SpedCampos(8, "VL_BC_ISS", "N", 0, 2, true)]
            public int VlBcIss { get; set; }

            /// <summary>
            ///   Alíquota do ISS
            /// </summary>
            [SpedCampos(9, "ALIQ_ISS", "N", 0, 2, true)]
            public int AliqIss { get; set; }

            /// <summary>
            ///    Valor do ISS
            /// </summary>
            [SpedCampos(10, "VL_ISS", "N", 0, 2, true)]
            public int VlIss { get; set; }

            /// <summary>
            ///    Código da observação do lançamento fiscal (campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(11, "COD_INF_OBS", "C", 60, 0, false)]
            public int CodInfObs { get; set; }

        }

        /// <summary>
        ///     REGISTRO B420: TOTALIZAÇÃO DOS VALORES DE SERVIÇOS PRESTADOS POR COMBINAÇÃO DE ALÍQUOTA E ITEM DA LISTA DE SERVIÇOS DA LC 116/2003
        /// </summary>
        public class RegistroB420 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB420" />.
            /// </summary>
            public RegistroB420()
            {
                Reg = "B420";
            }

            /// <summary>
            ///  Totalização do Valor  ontábil das prestações  do  declarante  referente à combinação da alíquota e item da lista
            /// </summary>
            [SpedCampos(2, "VL_CONT", "N", 0, 2, true)]
            public int VlCont { get; set; }

            /// <summary>
            ///   Totalização do Valor da base de cálculo do ISS das prestações do declarante referente à combinação da alíquota e item da lista
            /// </summary>
            [SpedCampos(3, "VL_BC_ISS", "N", 0, 2, true)]
            public int VlBcIss { get; set; }

            /// <summary>
            ///    Alíquota do ISS
            /// </summary>
            [SpedCampos(4, "ALIQ_ISS", "N", 0, 2, true)]
            public int AliqIss { get; set; }

            /// <summary>
            ///    Totalização do valor das operações isentas ou não-tributadas pelo ISS referente à combinação da alíquota e item da lista
            /// </summary>
            [SpedCampos(5, "VL_ISNT_ISS", "N", 0, 2, true)]
            public int VlIsntIss { get; set; }

            /// <summary>
            ///   Totalização, por combinação da alíquota e item da lista, do Valor do ISS
            /// </summary>
            [SpedCampos(6, "VL_ISS", "N", 0, 2, true)]
            public int VlIss { get; set; }

            /// <summary>
            ///   Item da lista de serviços, conforme Tabela 4.6.3.
            /// </summary>
            [SpedCampos(7, "COD_SERV", "C", 0, 0, true)]
            public int CodServ { get; set; }

        }

        /// <summary>
        ///     REGISTRO B440: TOTALIZAÇÃO DOS VALORES RETIDOS REGISTRO
        /// </summary>
        public class RegistroB440 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB440" />.
            /// </summary>
            public RegistroB440()
            {
                Reg = "B440";
            }

            /// <summary>
            ///  Indicador do tipo de operação:
            ///  0 - Aquisição;
            ///  1 - Prestação
            /// </summary>
            [SpedCampos(2, "IND_OPER", "N", 0, 2, true)]
            public int IndOper { get; set; }

            /// <summary>
            ///   Código  do  participante  (campo  02 do Registro 0150):
            ///   - do prestador, no caso de aquisição de serviço pelo declarante;
            ///   - do tomador, no caso de prestação de serviço pelo declarante
            /// </summary>
            [SpedCampos(3, "COD_PART", "C", 0, 0, true)]
            public int CodPart { get; set; }

            /// <summary>
            ///    Totalização do Valor Contábil das prestações e/ou aquisições do declarante pela combinação de tipo de operação e participante.
            /// </summary>
            [SpedCampos(4, "VL_CONT_RT", "N", 0, 2, true)]
            public int VlContRt { get; set; }

            /// <summary>
            ///    Totalização do Valor da base de cálculo de etenção do ISS das prestações e/ou aquisições do declarante pela combinação de tipo de operação e participante.
            /// </summary>
            [SpedCampos(5, "VL_BC_ISS_RT", "N", 0, 2, true)]
            public int VlBcIssRt { get; set; }

            /// <summary>
            ///   Totalização do Valor do ISS retido pelo tomador das prestações e/ou aquisições do declarante pela combinação de tipo de operação e participante.
            /// </summary>
            [SpedCampos(6, "VL_ISS_RT", "N", 0, 2, true)]
            public int VlIssRt { get; set; }
        }

        /// <summary>
        ///    REGISTRO B460: DEDUÇÕES DO ISS
        /// </summary>
        public class RegistroB460 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB460" />.
            /// </summary>
            public RegistroB460()
            {
                Reg = "B460";
            }

            /// <summary>
            ///   Indicador do tipo de dedução:
            ///   0 - Compensação do ISS calculado a maior; 
            ///   1 - Benefício fiscal por incentivo à cultura;
            ///   2 - Decisão administrativa ou judicial;
            ///   9 - Outro
            /// </summary>
            [SpedCampos(2, "IND_DED", "C", 1, 0, true)]
            public int IndDed { get; set; }

            /// <summary>
            ///   Valor da dedução
            /// </summary>
            [SpedCampos(3, "VL_DED", "N", 0, 2, true)]
            public int VlDed { get; set; }

            /// <summary>
            ///   Número  do  processo  ao  qual  o ajuste está vinculado, se houver
            /// </summary>
            [SpedCampos(4, "NUM_PROC", "C", 0, 0, false)]
            public int NumProc { get; set; }

            /// <summary>
            ///   Indicador da origem do processo:
            ///   0 - Sefin;
            ///   1 - Justiça Federal;
            ///   2 - Justiça Estadual;
            ///   9 - Outros
            /// </summary>
            [SpedCampos(5, "IND_PROC", "C", 1, 0, false)]
            public int IndProc { get; set; }

            /// <summary>
            ///   Descrição do processo que embasou o lançamento
            /// </summary>
            [SpedCampos(6, "PROC", "C", 0, 0, false)]
            public int Proc { get; set; }

            /// <summary>
            ///   Código da observação do lançamento fiscal(campo 02 do Registro 0460)
            /// </summary>
            [SpedCampos(7, "COD_INF_OBS", "C", 60, 0, true)]
            public int CodInfObs { get; set; }

            /// <summary>
            ///  Indicador da obrigação onde será aplicada a dedução:
            ///  0 - ISS Próprio;-ISS Substituto (devido pelas aquisições de serviços do declarante).
            ///    - ISS Uniprofissionais
            /// </summary>
            [SpedCampos(8, "IND_OBR", "C", 1, 0, true)]
            public int IndObr { get; set; }

        }

        /// <summary>
        ///  REGISTRO B470: APURAÇÃO DO ISS
        /// </summary>
        public class RegistroB470 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB470" />.
            /// </summary>
            public RegistroB470()
            {
                Reg = "B470";
            }

            /// <summary>
            ///   A - Valor total referente às prestações de serviço do período
            /// </summary>
            [SpedCampos(2, "VL_CONT", "N", 0, 2, true)]
            public int VlCont { get; set; }

            /// <summary>
            ///    B - Valor total do material fornecido por terceiros na prestação do serviço
            /// </summary>
            [SpedCampos(3, "VL_MAT_TERC", "N", 0, 2, true)]
            public int VlMatTerc { get; set; }

            /// <summary>
            ///    C - Valor do material próprio utilizado na prestação do serviço
            /// </summary>
            [SpedCampos(4, "VL_MAT_PROP", "N", 0, 2, true)]
            public int VlMatProp { get; set; }

            /// <summary>
            ///    D - Valor total das subempreitadas
            /// </summary>
            [SpedCampos(5, "VL_SUB", "N", 0, 2, true)]
            public int VlSub { get; set; }

            /// <summary>
            ///   E - Valor total das operações isentas ou não-tributadas pelo ISS
            /// </summary>
            [SpedCampos(6, "VL_ISNT", "N", 0, 2, true)]
            public int VlIsnt { get; set; }

            /// <summary>
            ///    F - Valor total das deduções da base de cálculo (B + C + D + E)
            /// </summary>
            [SpedCampos(7, "VL_DED_BC", "N", 0, 2, true)]
            public int VlDedBc { get; set; }

            /// <summary>
            ///   G - Valor total da base de cálculo do ISS
            /// </summary>
            [SpedCampos(8, "VL_BC_ISS", "N", 0, 2, true)]
            public int VlBcIss { get; set; }

            /// <summary>
            ///    H - Valor total da base de cálculo de retenção do ISS referente às prestações do declarante.
            /// </summary>
            [SpedCampos(9, "VL_BC_ISS_RT", "N", 0, 2, true)]
            public int VlBcIssRt { get; set; }

            /// <summary>
            ///   I - Valor total do ISS destacado
            /// </summary>
            [SpedCampos(10, "VL_ISS", "N", 0, 2, true)]
            public int VlIss { get; set; }

            /// <summary>
            ///   J - Valor total do ISS retido pelo tomador nas prestações do declarante
            /// </summary>
            [SpedCampos(11, "VL_ISS_RT", "N", 0, 2, true)]
            public int VlIssRt { get; set; }

            /// <summary>
            ///  K - Valor total das deduções do ISS próprio
            /// </summary>
            [SpedCampos(12, "VL_DED", "N", 0, 2, true)]
            public int VlDed { get; set; }

            /// <summary>
            ///   L - Valor total apurado do ISS próprio a recolher (I -J -K)
            /// </summary>
            [SpedCampos(13, "VL_ISS_REC", "N", 0, 2, true)]
            public int VlIssRec { get; set; }

            /// <summary>
            ///   M - Valor total do ISS substituto a recolher pelas aquisições do declarante (tomador)
            /// </summary>
            [SpedCampos(14, "VL_ISS_ST", "N", 0, 2, true)]
            public int VlIssSt { get; set; }

            /// <summary>
            ///   N - Valor do ISS próprio a recolher pela Sociedade Uniprofissional
            /// </summary>
            [SpedCampos(15, "VL_ISS_REC_UNI", "N", 0, 2, true)]
            public int VlIssRecUni { get; set; }

        }

        /// <summary>
        ///   REGISTRO B500: APURAÇÃO DO ISS SOCIEDADE UNIPROFISSIONAL
        /// </summary>
        public class RegistroB500 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB500" />.
            /// </summary>
            public RegistroB500()
            {
                Reg = "B500";
            }

            /// <summary>
            ///    Valor  mensal  das  receitas  auferidas  pela  sociedade uniprofissional
            /// </summary>
            [SpedCampos(2, "VL_REC", "N", 0, 2, true)]
            public int VlRec { get; set; }

            /// <summary>
            ///  Série do documento fiscal
            /// </summary>
            [SpedCampos(3, "QTD_PROF", "N", 0, 0, true)]
            public int QtdProf { get; set; }

            /// <summary>
            ///   Número do primeiro documento fiscal emitido no dia
            /// </summary>
            [SpedCampos(4, "VL_OR", "N", 0, 2, true)]
            public int VlOr { get; set; }

            public RegistroB510 RegB510 { get; set; }

        }

        /// <summary>
        ///   REGISTRO B510: UNIPROFISSIONAL - EMPREGADOS E SÓCIOS
        /// </summary>
        public class RegistroB510 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB510" />.
            /// </summary>
            public RegistroB510()
            {
                Reg = "B510";
            }

            /// <summary>
            ///   Indicador de habilitação:0- Profissional habilitado1- Profissional não habilitado
            /// </summary>
            [SpedCampos(2, "IND_PROF", "C", 1, 0, true)]
            public int IndProf { get; set; }

            /// <summary>
            ///  Indicador de escolaridade: 0- Nível superior 1- Nível médio
            /// </summary>
            [SpedCampos(3, "IND_ESC", "C", 1, 0, true)]
            public int IndEsc { get; set; }

            /// <summary>
            ///   Indicador de participação societária: 0 - Sócio 1 - Não sócio
            /// </summary>
            [SpedCampos(4, "IND_SOC", "C", 1, 0, true)]
            public int IndSoc { get; set; }

            /// <summary>
            ///   Número de inscrição do profissional no CPF.
            /// </summary>
            [SpedCampos(5, "CPF", "N", 11, 0, true)]
            public int Cpf { get; set; }

            /// <summary>
            ///  Nome do profissional
            /// </summary>
            [SpedCampos(6, "NOME", "C", 100, 0, true)]
            public int Nome { get; set; }

        }

        /// <summary>
        ///     REGISTRO B990: ENCERRAMENTO DO BLOCO B
        /// </summary>
        public class RegistroB990 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB990" />.
            /// </summary>
            public RegistroB990()
            {
                Reg = "B990";
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco B
            /// </summary>
            [SpedCampos(3, "QTD_LIN_B", "N", int.MaxValue, 0, true)]
            public int QtdLinB { get; set; }
        }
    }
}
