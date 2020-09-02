using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.ECF
{
    public class Bloco0
    {
        /// <summary>
        ///     REGISTRO 0000: ABERTURA DO ARQUIVO DIGITAL E IDENTIFICAÇÃO DA PESSOA JURÍDICA
        /// </summary>
        public class Registro0000 : RegistroBaseSped
        {
            public Registro0000()
            {
                Reg = "0000";
            }

            /// <summary>
            ///     Texto fixo contendo a identificação do tipo de Sped (LECF)
            /// </summary>
            [SpedCampos(2, "NOME_ESC", "C", 4, 0, true)]
            public string NomeEsc { get; set; }

            /// <summary>
            ///     Código da versão do leiaute conforme ato da RFB.
            /// </summary>
            [SpedCampos(3, "COD_VER", "C", 4, 0, true)]
            public int CodVer { get; set; }

            /// <summary>
            ///     CNPJ do declarante.
            ///     No caso de SCP informar o CNPJ do sócio ostensivo no campo COD_SCP.
            /// </summary>
            [SpedCampos(4, "CNPJ", "N", 14, 0, false)]
            public string Cnpj { get; set; }

            /// <summary>
            ///     Nome empresarial
            /// </summary>
            [SpedCampos(5, "NOME", "C", 255, 0, false)]
            public string Nome { get; set; }

            /// <summary>
            ///     Indicador do início do período.
            /// </summary>
            [SpedCampos(6, "IND_SIT_INI_PER", "N", 1, 0, true)]
            public int IndSitIniPer { get; set; }

            /// <summary>
            ///     Indicador de situação especial e outros eventos.
            /// </summary>
            [SpedCampos(7, "SIT_ESPECIAL", "C", 1, 0, true)]
            public int SitEspecial { get; set; }

            /// <summary>
            ///     Patrimônio remanescente em caso de cisão (%).
            /// </summary>
            [SpedCampos(8, "PAT_REMAN_CIS", "N", 8, 4, false)]
            public decimal PatRemanCis { get; set; }

            /// <summary>
            ///     Data da situação especial ou evento.
            /// </summary>
            [SpedCampos(9, "DT_SIT_ESP", "N", 8, 0, false)]
            public DateTime DtSitEsp { get; set; }

            /// <summary>
            ///     Data do início do período.
            /// </summary>
            [SpedCampos(10, "DT_INI", "N", 8, 0, true)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///     Data do fim do período.
            /// </summary>
            [SpedCampos(11, "DT_FIN", "N", 8, 0, true)]
            public DateTime DtFin { get; set; }

            /// <summary>
            ///     Indicador de escrituração retificadora.
            /// </summary>
            [SpedCampos(12, "RETIFICADORA", "C", 1, 0, true)]
            public string Retificadora { get; set; }

            /// <summary>
            ///     Número do recibo da ECF anterior
            /// </summary>
            [SpedCampos(13, "NUM_REC", "C", 41, 0, false)]
            public string NumRec { get; set; }

            /// <summary>
            ///     Indicador do tipo da ECF.
            /// </summary>
            [SpedCampos(14, "TIP_ECF", "N", 1, 0, true)]
            public int TipEcf { get; set; }

            /// <summary>
            ///     Identificação da SCP
            /// </summary>
            [SpedCampos(15, "COD_SCP", "N", 14, 0, false)]
            public int CodScp { get; set; }
        }

        public class Reg0001 : RegistroBaseSped
        {
            public Reg0001()
            {
                Reg = "0001";
            }

            /// <summary>
            ///     Valores validos: [0;1]
            /// </summary>
            [SpedCampos(2, "IND_DAD", "N", 1, 0, true)]
            public int IndDad { get; set; }
        }

        public class Reg0010 : RegistroBaseSped
        {
            public Reg0010()
            {
                Reg = "0010";
            }

            [SpedCampos(2, "HASH_ECF_ANTERIOR", "C", 40, 0, false)]
            public string HashEcfAnterior { get; set; }

            [SpedCampos(3, "OPT_REFIS", "C", 1, 0, true)]
            public string OptRefis { get; set; }

            [SpedCampos(4, "OPT_PAES", "C", 1, 0, true)]
            public string OptPaes { get; set; }

            /// <summary>
            ///     Valores validos: [1;2;3;4;5;6;7;8;9]
            /// </summary>
            [SpedCampos(5, "FORMA_TRIB", "N", 1, 0, true)]
            public int FormaTrib { get; set; }

            /// <summary>
            ///     Valores validos: [T;A]
            /// </summary>
            [SpedCampos(6, "FORMA_APUR", "C", 1, 0, false)]
            public string FormaApur { get; set; }

            /// <summary>
            ///     Valores validos: [01;02;03]
            /// </summary>
            [SpedCampos(7, "COD_QUALIF_PJ", "N", 2, 0, false)]
            public int? CodQualifPj { get; set; }

            /// <summary>
            ///     Valores validos: [0;R;P;A;E]
            /// </summary>
            [SpedCampos(8, "FORMA_TRIB_PER", "C", 4, 0, false)]
            public string FormaTribPer { get; set; }

            [SpedCampos(9, "MES_BAL_RED", "C", 12, 0, false)]
            public string MesBalRed { get; set; }

            /// <summary>
            ///     Valores validos: [L;C]
            /// </summary>
            [SpedCampos(10, "TIP_ESC_PRE", "C", 1, 0, false)]
            public string TipEscPre { get; set; }

            /// <summary>
            ///     Valores validos: [01;02;03;04;05;06;07;08;09;10;11;12;13;14;15;99]
            /// </summary>
            [SpedCampos(11, "TIP_ENT", "N", 2, 0, false)]
            public int? TipEnt { get; set; }

            /// <summary>
            ///     Valores validos: [A;T;D]
            /// </summary>
            [SpedCampos(12, "FORMA_APUR_I", "C", 1, 0, false)]
            public string FormaApurI { get; set; }

            /// <summary>
            ///     Valores validos: [A;T;D]
            /// </summary>
            [SpedCampos(13, "APUR_CSLL", "C", 1, 0, false)]
            public string ApurCsll { get; set; }

            /// <summary>
            ///     Valores validos: [1;2]
            /// </summary>
            [SpedCampos(14, "IND_REC_RECEITA", "N", 1, 0, false)]
            public int? IndRecReceita { get; set; }
        }

        public class Reg0020 : RegistroBaseSped
        {
            public Reg0020()
            {
                Reg = "0020";
            }

            /// <summary>
            ///     Valores validos: [1;2;3]
            /// </summary>
            [SpedCampos(2, "IND_ALIQ_CSLL", "N", 1, 0, true)]
            public int IndAliqCsll { get; set; }

            [SpedCampos(3, "IND_QTE_SCP", "N", 3, 0, true)]
            public int IndQteScp { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(4, "IND_ADM_FUN_CLU", "C", 1, 0, true)]
            public string IndAdmFunCll { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(5, "IND_PART_CONS", "C", 1, 0, true)]
            public string IndPartCons { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(6, "IND_OP_EXT", "C", 1, 0, true)]
            public string IndOpExt { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(7, "IND_OP_VINC", "C", 1, 0, true)]
            public string IndOpVinc { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(8, "IND_PJ_ENQUAD", "C", 1, 0, true)]
            public string IndPjEnquad { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(9, "IND_PART_EXT", "C", 1, 0, true)]
            public string IndPartExt { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(10, "IND_ATIV_RURAL", "C", 1, 0, true)]
            public string IndAtivRural { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(11, "IND_LUC_EXP", "C", 1, 0, true)]
            public string IndLucExp { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(12, "IND_RED_ISEN", "C", 1, 0, true)]
            public string IndRedIsen { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(13, "IND_FIN", "C", 1, 0, true)]
            public string IndFin { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(14, "IND_DOA_ELEIT", "C", 1, 0, true)]
            public string IndDoaEleit { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(15, "IND_PART_COLIG", "C", 1, 0, true)]
            public string IndPartColig { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(16, "IND_VEND_EXP", "C", 1, 0, true)]
            public string IndVendExp { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(17, "IND_REC_EXT", "C", 1, 0, true)]
            public string IndRecExt { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(18, "IND_ATIV_EXT", "C", 1, 0, true)]
            public string IndAtivExt { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(19, "IND_COM_EXP", "C", 1, 0, true)]
            public string IndComExp { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(20, "IND_PGTO_EXT", "C", 1, 0, true)]
            public string IndPgtoExt { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(21, "IND_E-COM_TI", "C", 1, 0, true)]
            public string IndEComTi { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(22, "IND_ROY_REC", "C", 1, 0, true)]
            public string IndRoyRec { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(23, "IND_ROY_PAG", "C", 1, 0, true)]
            public string IndRoyPag { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(24, "IND_REND_SERV", "C", 1, 0, true)]
            public string IndRendServ { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(25, "IND_PGTO_REM", "C", 1, 0, true)]
            public string IndPgtoRem { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(26, "IND_INOV_TEC", "C", 1, 0, true)]
            public string IndInovTec { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(27, "IND_CAP_INF", "C", 1, 0, true)]
            public string IndCapInf { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(28, "IND_PJ_HAB", "C", 1, 0, true)]
            public string IndPjHab { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(29, "IND_POLO_AM", "C", 1, 0, true)]
            public string IndPoloAm { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(30, "IND_ZON_EXP", "C", 1, 0, true)]
            public string IndZonExp { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(31, "IND_AREA_COM", "C", 1, 0, true)]
            public string IndAreaCom { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(32, "IND_PAIS_A_PAIS", "C", 1, 0, true)]
            public string IndPaisAPais { get; set; }
        }

        public class Reg0021 : RegistroBaseSped
        {
            public Reg0021()
            {
                Reg = "0021";
            }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(2, "IND_REPES", "C", 1, 0, false)]
            public string IndRepes { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(3, "IND_RECAP", "C", 1, 0, false)]
            public string IndRecap { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(4, "IND_PADIS", "C", 1, 0, false)]
            public string IndPadis { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(5, "IND_PATVD", "C", 1, 0, false)]
            public string IndPatvd { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(6, "IND_REIDI", "C", 1, 0, false)]
            public string IndReidi { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(7, "IND_REPENEC", "C", 1, 0, false)]
            public string IndRepenec { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(8, "IND_REICOMP", "C", 1, 0, false)]
            public string IndReicomp { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(9, "IND_RETAERO", "C", 1, 0, false)]
            public string IndRetaero { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(10, "IND_RECINE", "C", 1, 0, false)]
            public string IndRecine { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(11, "IND_RESIDUOS_SOLID", "C", 1, 0, false)]
            public string IndResiduosSolid { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(12, "IND_RECOPA", "C", 1, 0, false)]
            public string IndRecopa { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(13, "IND_COPA_DO_MUND", "C", 1, 0, false)]
            public string IndCopaDoMund { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(14, "IND_RETID", "C", 1, 0, false)]
            public string IndRetid { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(15, "IND_REPNBL_REDES", "C", 1, 0, false)]
            public string IndRepnblRedes { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(16, "IND_REIF", "C", 1, 0, false)]
            public string IndReif { get; set; }

            /// <summary>
            ///     Valores validos: [S;N]
            /// </summary>
            [SpedCampos(17, "IND_OLIMPIADAS", "C", 1, 0, false)]
            public string IndOlimpiadas { get; set; }
        }

        public class Reg0030 : RegistroBaseSped
        {
            public Reg0030()
            {
                Reg = "0030";
            }

            [SpedCampos(2, "COD_NAT", "N", 4, 0, true)]
            public string CodNat { get; set; }

            [SpedCampos(3, "CNAE_FISCAL", "N", 7, 0, true)]
            public string CnaeFiscal { get; set; }

            [SpedCampos(4, "ENDERECO", "C", 150, 0, true)]
            public string Endereco { get; set; }

            [SpedCampos(5, "NUM", "C", 6, 0, true)]
            public string Num { get; set; }

            [SpedCampos(6, "COMPL", "C", 50, 0, false)]
            public string Compl { get; set; }

            [SpedCampos(7, "BAIRRO", "C", 50, 0, true)]
            public string Bairro { get; set; }

            [SpedCampos(8, "UF", "C", 2, 0, true)]
            public string Uf { get; set; }

            [SpedCampos(9, "COD_MUN", "C", 7, 0, true)]
            public string CodMun { get; set; }

            [SpedCampos(10, "CEP", "C", 8, 0, true)]
            public string Cep { get; set; }

            [SpedCampos(11, "NUM_TEL", "N", 15, 0, false)]
            public string NumTel { get; set; }

            [SpedCampos(12, "EMAIL", "C", 115, 0, true)]
            public string Email { get; set; }
        }

        public class Reg0035 : RegistroBaseSped
        {
            public Reg0035()
            {
                Reg = "0035";
            }

            [SpedCampos(2, "COD_SCP", "C", 14, 0, true)]
            public string CodScp { get; set; }

            [SpedCampos(3, "NOME_SCP", "C", 0, 0, false)]
            public string NomeScp { get; set; }
        }

        public class Reg0930 : RegistroBaseSped
        {
            public Reg0930()
            {
                Reg = "0930";
            }

            [SpedCampos(2, "IDENT_NOM", "C", 0, 0, true)]
            public string IdentNom { get; set; }

            /// <summary>
            ///     CPF 11 - CNPJ 14
            /// </summary>
            [SpedCampos(3, "IDENT_CPF_CNPJ", "N", 0, 0, true)]
            public string IdentCpfCnpj { get; set; }

            [SpedCampos(4, "IDENT_QUALIF", "C", 3, 0, true)]
            public string IdentQualif { get; set; }

            [SpedCampos(5, "IND_CRC", "C", 0, 0, false)]
            public string IndCrc { get; set; }

            [SpedCampos(6, "EMAIL", "C", 60, 0, true)]
            public string Email { get; set; }

            [SpedCampos(7, "FONE", "C", 14, 0, true)]
            public string Fone { get; set; }
        }

        public class Reg0990 : RegistroBaseSped
        {
            public Reg0990()
            {
                Reg = "0990";
            }

            [SpedCampos(2, "QTD_LIN", "N", 0, 0, true)]
            public int QtdLin { get; set; }
        }
    }
}