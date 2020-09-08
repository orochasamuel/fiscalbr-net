using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.EFDContribuicoes
{
    public class Bloco1
    {
        public class Registro1001 : RegistroBaseSped
        {
            public Registro1001()
            {
                Reg = "1001";
            }

            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }
        }

        /// <summary>
        /// REGISTRO 1800: INCORPORAÇÃO IMOBILIÁRIA - RET
        /// </summary>
        /// <remarks>
        /// Este registro dever ser preenchido pela pessoa jurídica que executa empreendimentos objeto de incorporação <para/>
        /// imobiliária e que apuram contribuição social com base em Regimes Especiais de Tributação - RET. As normas <para/>
        /// relativas ao RET, nas modalidades previstas na legislação tributária, encontram-se dispostas na Instrução <para/>
        /// Normativa RFB nº 1.435/2013.
        /// </remarks>
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
            /// Empreendimento objeto de Incorporação Imobiliária, optante pelo RET <para/>
            /// </summary>
            /// <example>
            /// Exemplo de preechimento
            /// <code>
            /// reg1800.IncImob = "Empreendimento XYZ [11222333456789]"
            /// </code>
            /// </example>
            /// <remarks>
            /// Preenchimento: identifique o empreendimento objeto de incorporação imobiliária, optante pelo RET, <para/>
            /// informando o respectivo CNPJ do empreendimento, de acordo com o inciso XIII do art. 4º da IN RFB nº 1.634, <para/>
            /// de 2016, no formato "XXXXXXXXYYYYZZ"
            /// </remarks>
            [SpedCampos(2, "INC_IMOB", "C", 90, 0, true)]
            public string IncImob { get; set; }

            /// <summary>
            /// Receitas recebidas pela incorporadora na venda das unidades imobiliárias que compõem a incorporação
            /// </summary>
            [SpedCampos(3, "REC_RECEB_RET", "N", Int16.MaxValue, 2, true)]
            public decimal RecRecebRet { get; set; }

            /// <summary>
            /// Receitas Financeiras e Variações Monetárias decorrentes das vendas submentidas ao RET
            /// </summary>
            [SpedCampos(4, "REC_FIN_RET", "N", Int16.MaxValue, 2, false)]
            public decimal? RecFinRet { get; set; }

            /// <summary>
            /// Base de Cálculo do Recolhimento Unificado
            /// </summary>
            [SpedCampos(5, "BC_RET", "N", Int16.MaxValue, 2, true)]
            public decimal BcRet { get; set; }

            /// <summary>
            /// Alíquota do Recolhimento Unificado
            /// </summary>
            [SpedCampos(6, "ALIQ_RET", "N", 6, 2, true)]
            public decimal AliqRet { get; set; }

            /// <summary>
            /// Valor do Recolhimento Unificado
            /// </summary>
            [SpedCampos(7, "VL_REC_UNI", "N", Int16.MaxValue, 2, true)]
            public decimal VlRecUni { get; set; }

            /// <summary>
            /// Data do Recolhimento Unificado
            /// </summary>
            [SpedCampos(8, "DT_REC_UNI", "N", 8, 0, false)]
            public DateTime? DtRecUni { get; set; }

            /// <summary>
            /// Código da Receita
            /// </summary>
            [SpedCampos(9, "COD_REC", "C", 4, 0, false)]
            public string CodRec { get; set; }
        }

        public class Registro1900 : RegistroBaseSped
        {
            public Registro1900()
            {
                Reg = "1900";
            }

            [SpedCampos(2, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            [SpedCampos(3, "COD_MOD", "C", 2, 0, true)]
            public int CodMod { get; set; }

            [SpedCampos(4, "SER", "C", 4, 0, false)]
            public string Ser { get; set; }

            [SpedCampos(5, "SUB_SER", "C", 4, 0, false)]
            public string SubSer { get; set; }

            [SpedCampos(6, "COD_SIT", "N", 2, 0, false)]
            public int CodSit { get; set; }

            [SpedCampos(7, "VL_TOT_REC", "N", 0, 2, true)]
            public decimal VlTotRec { get; set; }

            [SpedCampos(8, "QUANT_DOC", "N", 2, 0, false)]
            public int QuantDoc { get; set; }

            [SpedCampos(9, "CST_PIS", "N", 2, 0, false)]
            public int CstPis { get; set; }

            [SpedCampos(10, "CST_COFINS", "N", 2, 0, false)]
            public int CstCofins { get; set; }

            [SpedCampos(11, "CFOP", "N", 4, 0, false)]
            public string Cfop { get; set; }

            [SpedCampos(12, "INF_COMPL", "C", 0, 0, false)]
            public string InfCompl { get; set; }

            [SpedCampos(13, "COD_CTA", "C", 60, 0, false)]
            public string CodCta { get; set; }
        }

        public class Registro1990 : RegistroBaseSped
        {
            public Registro1990()
            {
                Reg = "1990";
            }

            [SpedCampos(2, "QTD_LIN_1", "N", int.MaxValue, 0, true)]
            public int QtdLin1 { get; set; }
        }
    }
}
