using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDContribuicoes
{
    public class BlocoP
    {
        public RegistroP001 RegP001 { get; set; }
        public RegistroP990 RegP990 { get; set; }

        public class RegistroP001 : RegistroBaseSped
        {
            public RegistroP001()
            {
                Reg = "P001";
            }

            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroP010> RegP010s { get; set; }
            public List<RegistroP200> RegP200s { get; set; }
        }

        /// <summary>
        ///     REGISTRO P010: Identificação do Estabelecimento
        /// </summary>
        public class RegistroP010 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroP010"/>
            /// </summary>
            public RegistroP010()
            {
                Reg = "P010";
            }

            [SpedCampos(3, "CNPJ", "N", 14, 0, true)]
            public int Cnpj { get; set; }

            public List<RegistroP100> RegP100s { get; set; }
        }

        /// <summary>
        ///     REGISTRO P100:  Contribuição Previdenciária sobre a Receita Bruta
        /// </summary>
        public class RegistroP100 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroP100"/>
            /// </summary>
            public RegistroP100()
            {
                Reg = "P100";
            }

            /// <summary>
            ///     Data inicial a que a apuração se refere
            /// </summary>
            [SpedCampos(2, "DT_INI", "C", 8, 0, true)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///    Data final a que a apuração se refere
            /// </summary>
            [SpedCampos(3, "DT_FIN", "C", 8, 0, true)]
            public DateTime DtFin { get; set; }

            /// <summary>
            ///    Valor da Receita Bruta Total do Estabelecimento no Período
            /// </summary>
            [SpedCampos(4, "VL_REC_TOT_EST", "N", 0, 2, true)]
            public decimal VlRecTotEst { get; set; }

            /// <summary>
            ///     Código indicador correspondente à atividade sujeita a incidência da Contribuição Previdenciária sobre a Receita Bruta, conforme Tabela 5.1.1.
            /// </summary>
            [SpedCampos(5, "COD_ATIV_ECON", "C", 8, 0, true)]
            public decimal CodAtivEcon { get; set; }

            /// <summary>
            ///     Valor da Receita Bruta do Estabelecimento, correspondente às atividades/produtos referidos no Campo 05 (COD_ATIV_ECON)
            /// </summary>
            [SpedCampos(6, "VL_REC_ATIV_ESTAB", "N", 0, 2, true)]
            public decimal VlBcMenEst { get; set; }

            /// <summary>
            ///     Valor das Exclusões da Receita Bruta informada no Campo 06
            /// </summary>
            [SpedCampos(7, "VL_EXC", "N", 0, 2, false)]
            public int VlExc { get; set; }

            /// <summary>
            ///     Valor da Base de Cálculo da Contribuição Previdenciária sobre a Receita Bruta(Campo 08 = Campo 06 –Campo 07)
            /// </summary>
            [SpedCampos(8, "VL_BC_CONT", "N", 0, 2, true)]
            public decimal VlBcCont { get; set; }

            /// <summary>
            ///     Alíquota da Contribuição Previdenciária sobre a Receita Bruta
            /// </summary>
            [SpedCampos(9, "ALIQ_CONT", "N", 8, 4, true)]
            public decimal AliqCont { get; set; }

            /// <summary>
            ///     Valor da Contribuição Previdenciária Apurada sobre a Receita Bruta
            /// </summary>
            [SpedCampos(10, "VL_CONT_APU", "N", 0, 2, true)]
            public decimal VlContApu { get; set; }

            /// <summary>
            ///     Código da conta analítica contábil referente à Contribuição Previdenciária sobre a Receita Bruta
            /// </summary>
            [SpedCampos(11, "COD_CTA", "C", 255, 0, false)]
            public decimal CodCta { get; set; }

            /// <summary>
            ///    Informação complementar do registro
            /// </summary>
            [SpedCampos(12, "INFO_COMPL", "C",0, 0, false)]
            public decimal InfoCompl { get; set; }

            public List<RegistroP110> RegP110s { get; set; }
            public List<RegistroP199> RegP199s { get; set; }
        }

        /// <summary>
        ///     REGISTRO P110: Complemento da Escrituração –Detalhamento da Apuração da Contribuição
        /// </summary>
        public class RegistroP110 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroP110"/>
            /// </summary>
            public RegistroP110()
            {
                Reg = "P110";
            }

            /// <summary>
            ///     Informar  o  número  do  campo  do  registro “P100”, objeto de detalhamento neste registro
            /// </summary>
            [SpedCampos(2, "NUM_CAMPO", "C", 2, 0, true)]
            public string NumCampo { get; set; }

            /// <summary>
            ///    Código  do  tipo  de  detalhamento,  conforme Tabela 5.1.2
            /// </summary>
            [SpedCampos(3, "COD_DET", "C", 8, 0, false)]
            public string CodDet { get; set; }

            /// <summary>
            ///    Valor detalhado referente ao campo 02 deste registro
            /// </summary>
            [SpedCampos(4, "DET_VALOR", "N", 0, 2, true)]
            public decimal DetValor { get; set; }

            /// <summary>
            ///     Informação complementar do detalhamento.
            /// </summary>
            [SpedCampos(5, "INF_COMPL", "C", 0, 0, false)]
            public decimal InfCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO P199: Processo Referenciado
        /// </summary>
        public class RegistroP199 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroP199"/>
            /// </summary>
            public RegistroP199()
            {
                Reg = "P199";
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
        ///     REGISTRO P200:  Consolidação da Contribuição Previdenciária Sobre a Receita Bruta
        /// </summary>
        public class RegistroP200 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroP200"/>
            /// </summary>
            public RegistroP200()
            {
                Reg = "P200";
            }

            /// <summary>
            ///    Período de referencia da escrituração (MMAAAA) 
            /// </summary>
            [SpedCampos(2, "PER_REF", "N", 6, 0, true)]
            public string PerRef { get; set; }

            /// <summary>
            ///   V alor total apurado da Contribuição Previdenciária sobre a Receita Bruta (Somatório do Campo 10 “VL_CONT_APU“, do(s) Registro(s) P100)
            /// </summary>
            [SpedCampos(3, "VL_TOT_CONT_APU", "N", 0, 2, true)]
            public string VlTotContApu { get; set; }

            /// <summary>
            ///    Valor total de “Ajustes de redução” (Registro P210, Campo 03, quando Campo 02 = “0”)
            /// </summary>
            [SpedCampos(4, "VL_TOT_AJ_REDUC", "N", 0, 2, false)]
            public decimal VlTotAjuReduc { get; set; }

            /// <summary>
            ///     Valor total de “Ajustes de acréscimo” (Registro P210, Campo 03, quando Campo 02 = “1”)
            /// </summary>
            [SpedCampos(5, "VL_TOT_AJ_ACRES", "N", 0, 2, false)]
            public decimal VlTotAjAcres { get; set; }

            /// <summary>
            ///     Valor total da Contribuição Previdenciária sobre a Receita Bruta a recolher (Campo 03 –Campo 04 + Campo 05)
            /// </summary>
            [SpedCampos(6, "VL_TOT_CONT_DEV", "N", 0, 2, true)]
            public decimal VlTotContDev { get; set; }

            /// <summary>
            ///     Código de Receita referente à Contribuição Previdenciária, conforme informado em DCTF
            /// </summary>
            [SpedCampos(7, "COD_REC", "C", 6, 0, true)]
            public int CodRec { get; set; }

            public List<RegistroP210> RegP210s { get; set; }
        }

        /// <summary>
        ///     REGISTRO P210: Ajuste aa Contribuição Previdenciária Apurada Sobre a Receita Bruta
        /// </summary>
        public class RegistroP210 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroP210"/>
            /// </summary>
            public RegistroP210()
            {
                Reg = "P210";
            }

            /// <summary>
            ///    Indicador do tipo de ajuste:
            ///    0-Ajuste de redução;
            ///    1-Ajuste de acréscimo. 
            /// </summary>
            [SpedCampos(2, "IND_AJ", "C", 1, 0, true)]
            public string IndAj { get; set; }

            /// <summary>
            ///    Valor do ajuste
            /// </summary>
            [SpedCampos(3, "VL_AJ", "N", 0, 2, true)]
            public string VlAj { get; set; }

            /// <summary>
            ///    Código do ajuste, conforme a Tabela indicada no item 4.3.8., versão 1.01
            /// </summary>
            [SpedCampos(4, "COD_AJ", "C", 2, 0, true)]
            public decimal CodAj { get; set; }

            /// <summary>
            ///     Número do processo, documento ou ato concessório ao qual o ajuste está vinculado, se houver.
            /// </summary>
            [SpedCampos(5, "NUM_DOC", "C", 0, 0,false)]
            public decimal NumDoc { get; set; }

            /// <summary>
            ///     Descrição resumida do ajuste.
            /// </summary>
            [SpedCampos(6, "DESCR_AJ", "N", 8, 0, false)]
            public decimal DescrAj { get; set; }

            /// <summary>
            ///     Data de referência do ajuste (ddmmaaaa)
            /// </summary>
            [SpedCampos(7, "DT_REF", "N", 8, 0, false)]
            public DateTime DtRef { get; set; }
        }

        public class RegistroP990 : RegistroBaseSped
        {
            public RegistroP990()
            {
                Reg = "P990";
            }

            [SpedCampos(3, "QTD_LIN_P", "N", int.MaxValue, 0, true)]
            public int QtdLinP { get; set; }
        }
    }
}
