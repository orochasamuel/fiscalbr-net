using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDContribuicoes
{
    public class BlocoI
    {
        public RegistroI001 RegI001 { get; set; }
        public RegistroI990 RegI990 { get; set; }

        public class RegistroI001 : RegistroBaseSped
        {
            public RegistroI001()
            {
                Reg = "I001";
            }

            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroI010> RegI010s { get; set; }
        }

        /// <summary>
        ///     REGISTRO I010: Identificação da Pessoa Juridica/Estabelecimento
        /// </summary>
        public class RegistroI010 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroI010"/>
            /// </summary>
            public RegistroI010()
            {
                Reg = "I010";
            }

            /// <summary>
            ///     Número de inscrição da pessoa jurídica no CNPJ.
            /// </summary>
            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            /// <summary>
            ///    Indicador de operações realizadas no período:
            ///    01 –Exclusivamente operações de Instituições Financeiras e Assemelhadas
            ///    02 –Exclusivamente operações de Seguros Privados
            ///    03 –Exclusivamente operações de Previdência Complementar
            ///    04 –Exclusivamente operações de Capitalização
            ///    05 –Exclusivamente operações de Planos de Assistência à Saúde
            ///    06 –Realizou operações referentes a mais de um dos indicadores acima
            /// </summary>
            [SpedCampos(3, "IND_ATIV", "N", 2, 0, true)]
            public string IndAtiv { get; set; }

            /// <summary>
            ///     Informação Complementar
            /// </summary>
            [SpedCampos(4, "INFO_COMPL", "C", 0, 0, true)]
            public string InfoCompl { get; set; }

            public List<RegistroI100> RegI100s { get; set; }
        }

        /// <summary>
        ///     REGISTRO I100: Consolidação das Operações do Período
        /// </summary>
        public class RegistroI100 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroI100"/>
            /// </summary>
            public RegistroI100()
            {
                Reg = "I100";
            }

            /// <summary>
            ///     Valor Total do Faturamento/Receita Bruta no Período
            /// </summary>
            [SpedCampos(2, "VL_REC", "N", 0, 2, true)]
            public string VlRec { get; set; }

            /// <summary>
            ///    Código de Situação Tributária referente à Receita informada no Campo 02 (Tabelas 4.3.3 e 4.3.4)
            /// </summary>
            [SpedCampos(3, "CST_PIS_COFINS", "N", 2, 0, true)]
            public string CstPisCofins { get; set; }

            /// <summary>
            ///    Valor Total das Deduções e Exclusões de Caráter Geral
            /// </summary>
            [SpedCampos(4, "VL_TOT_DED_GER", "N", 0, 2, true)]
            public string VlTotDedGer { get; set; }

            /// <summary>
            ///   Valor Total das Deduções e Exclusões de Caráter Específico
            /// </summary>
            [SpedCampos(5, "VL_TOT_DED_ESP", "N", 0, 2, true)]
            public string VlTotDedEsp { get; set; }

            /// <summary>
            ///     Valor da base de cálculo do PIS/PASEP
            /// </summary>
            [SpedCampos(6, "VL_BC_PIS", "N", 0, 2, true)]
            public string VlBcPis { get; set; }

            /// <summary>
            ///   Alíquota do PIS/PASEP (em percentual)
            /// </summary>
            [SpedCampos(7, "ALIQ_PIS", "N", 8, 2, true)]
            public string AliqPis { get; set; }

            /// <summary>
            ///   Valor do PIS/PASEP
            /// </summary>
            [SpedCampos(8, "VL_PIS", "N", 0, 2, true)]
            public string VlPis { get; set; }

            /// <summary>
            ///   Valor da base de cálculo da Cofins 
            /// </summary>
            [SpedCampos(9, "VL_BC_COFINS", "N", 0, 2, true)]
            public string VlBcCofins { get; set; }

            /// <summary>
            ///  Alíquota da COFINS (em percentual) 
            /// </summary>
            [SpedCampos(10, "ALIQ_COFINS", "N", 8, 2, true)]
            public string AliqCofins { get; set; }

            /// <summary>
            ///     Valor da COFINS
            /// </summary>
            [SpedCampos(11, "VL_COFINS", "N", 0, 2, true)]
            public string VlCofins { get; set; }

            /// <summary>
            ///     Informação Complementar dos dados informados no registro
            /// </summary>
            [SpedCampos(12, "INFO_COMPL", "C", 0, 0, true)]
            public string InfoCompl { get; set; }

            public List<RegistroI199> RegI199s { get; set; }
            public List<RegistroI200> RegI200s { get; set; }
        }

        /// <summary>
        ///     REGISTRO I199: Processo Referenciado
        /// </summary>
        public class RegistroI199 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroI199"/>
            /// </summary>
            public RegistroI199()
            {
                Reg = "I199";
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
        ///     REGISTRO I200: Composição das Receitas, Deduções e/ou Exclusões do Período
        /// </summary>
        public class RegistroI200 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroI200"/>
            /// </summary>
            public RegistroI200()
            {
                Reg = "I200";
            }

            /// <summary>
            ///     Informar o número do campo do registro “I100” (Campos 02, 04 ou 05), objeto de informação neste registro.
            /// </summary>
            [SpedCampos(2, "NUM_CAMPO", "C", 2, 0, true)]
            public string NumCampo { get; set; }

            /// <summary>
            ///    Código do tipo de detalhamento, conforme Tabelas 7.1.1 e/ou 7.1.2
            /// </summary>
            [SpedCampos(3, "COD_DET", "C", 5, 0, true)]
            public string CodDet { get; set; }

            /// <summary>
            ///    Valor  detalhado  referente  ao  campo  03 (COD_DET)  deste registro
            /// </summary>
            [SpedCampos(4, "DET_VALOR", "N", 0, 2, false)]
            public string DetValor { get; set; }

            /// <summary>
            ///   Código  da  conta  contábil  referente  ao  valor  informado  no campo 04 (DET_VALOR)
            /// </summary>
            [SpedCampos(5, "COD_CTA", "C", 255, 0, true)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Informação Complementar dos dados informados no registro
            /// </summary>
            [SpedCampos(6, "INFO_COMPL", "C", 0, 0, true)]
            public string InfoCompl { get; set; }

            public List<RegistroI299> RegI299s { get; set; }
            public List<RegistroI300> RegI300s { get; set; }
        }

        /// <summary>
        ///     REGISTRO I299: Processo Referenciado
        /// </summary>
        public class RegistroI299 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroI299"/>
            /// </summary>
            public RegistroI299()
            {
                Reg = "I299";
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
        ///     REGISTRO I300: Complemento das Operações –Detalhamento das Receitas, Deduções e/ou Exclusões Do Período
        /// </summary>
        public class RegistroI300 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroI300"/>
            /// </summary>
            public RegistroI300()
            {
                Reg = "I300";
            }

            /// <summary>
            ///     Código das Tabelas 7.1.3 (Receitas –Visão Analítica/Referenciada) e/ou 7.1.4 (Deduções e exclusões –Visão Analítica/Referenciada), objeto de complemento neste registro
            /// </summary>
            [SpedCampos(2, "COD_COMP", "C", 60, 0, true)]
            public string CodComp { get; set; }

            /// <summary>
            ///    Valor da receita, dedução ou exclusão, objeto de complemento/detalhamento neste registro,conforme código informado no campo 02 (especificados nas tabelas analíticas 7.1.3 e 7.1.4) ou no campo 04 (código da conta contábil)
            /// </summary>
            [SpedCampos(3, "DET_VALOR", "N", 0, 2, true)]
            public string DetValor { get; set; }

            /// <summary>
            ///     Código da conta contábil referente ao valor informado no campo 03
            /// </summary>
            [SpedCampos(4, "COD_CTA", "C", 255, 0, true)]
            public string CodCta { get; set; }

            /// <summary>
            ///   Informação  Complementar  dos  dados  informados  no registro
            /// </summary>
            [SpedCampos(5, "INFO_COMPL", "C", 0, 0, true)]
            public string InfoCompl { get; set; }

            public List<RegistroI399> RegI399s { get; set; }
        }

        /// <summary>
        ///     REGISTRO I399: Processo Referenciado
        /// </summary>
        public class RegistroI399 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma instância da classe <see cref="RegistroI399"/>
            /// </summary>
            public RegistroI399()
            {
                Reg = "I399";
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

        public class RegistroI990 : RegistroBaseSped
        {
            public RegistroI990()
            {
                Reg = "I990";
            }

            [SpedCampos(2, "QTD_LIN_I", "N", int.MaxValue, 0, true)]
            public int QtdLinI { get; set; }
        }
    }
}
