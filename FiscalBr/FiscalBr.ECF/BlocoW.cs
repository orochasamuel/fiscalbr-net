using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.ECF
{
    public class BlocoW
    {
        public class RegW001 : RegistroBaseSped
        {
            public RegW001()
            {
                Reg = "W001";
            }

            [SpedCampos(2, "IND_DAD", "N", 1, 0, true)]
            public int IndDad { get; set; }
        }

        public class RegW100 : RegistroBaseSped
        {
            public RegW100()
            {
                Reg = "W100";
            }

            [SpedCampos(2, "NOME_MULTINACIONAL", "C", 0, 0, true)]
            public string NomeMultinacional { get; set; }

            [SpedCampos(3, "IND_CONTROLADORA", "C", 1, 0, true)]
            public string IndControladora { get; set; }

            [SpedCampos(4, "NOME_CONTROLADORA", "C", 0, 0, true)]
            public string NomeControladora { get; set; }

            [SpedCampos(5, "JURISDICAO_CONTROLADORA", "C", 2, 0, true)]
            public string JurisdicaoControladora { get; set; }

            [SpedCampos(6, "TIN_CONTROLADORA", "C", 0, 0, true)]
            public string TinControladora { get; set; }

            [SpedCampos(7, "IND_ENTREGA", "N", 1, 0, true)]
            public int IndEntrega { get; set; }

            [SpedCampos(8, "IND_MODALIDADE", "N", 1, 0, true)]
            public int IndModalidade { get; set; }

            [SpedCampos(9, "NOME_SUBSTITUTA", "C", 0, 0, false)]
            public string NomeSubstituta { get; set; }

            [SpedCampos(10, "JURISDICAO_SUBSTITUTA", "C", 2, 0, false)]
            public string JurisdicaoSubstituta { get; set; }

            [SpedCampos(11, "TIN_SUBSTITUTA", "N", 14, 0, false)]
            public string TinSubstituta { get; set; }

            [SpedCampos(12, "DT_INI", "N", 8, 0, false)]
            public DateTime? DtIni { get; set; }

            [SpedCampos(13, "DT_FIN", "N", 8, 0, false)]
            public DateTime? DtFin { get; set; }

            [SpedCampos(14, "TIP_MOEDA", "C", 3, 0, false)]
            public string TipMoeda { get; set; }

            [SpedCampos(15, "IND_IDIOMA", "C", 2, 0, false)]
            public string IndIdioma { get; set; }
        }

        public class RegW200 : RegistroBaseSped
        {
            public RegW200()
            {
                Reg = "W200";
            }

            [SpedCampos(2, "JURISDICAO", "C", 2, 0, false)]
            public string Jurisdicao { get; set; }

            [SpedCampos(3, "VL_REC_NAO_REL_EST", "NS", 19, 2, false)]
            public decimal? VlRecNaoRelEst { get; set; }

            [SpedCampos(4, "VL_REC_NAO_REL", "NS", 19, 2, true)]
            public decimal? VlRecNaoRel { get; set; }

            [SpedCampos(5, "VL_REC_REL_EST", "NS", 19, 2, false)]
            public decimal? VlRecRelEst { get; set; }

            [SpedCampos(6, "VL_REC_REL", "NS", 19, 2, true)]
            public decimal? VlRecRel { get; set; }

            [SpedCampos(7, "VL_REC_TOTAL_EST", "NS", 19, 2, false)]
            public decimal? VlRecTotalEst { get; set; }

            [SpedCampos(8, "VL_REC_TOTAL", "NS", 19, 2, true)]
            public decimal? VlRecTotal { get; set; }

            [SpedCampos(9, "VL_LUC_PREJ_ANTES_IR_EST", "NS", 19, 2, false)]
            public decimal? VlLucPrejAntesIrEst { get; set; }

            [SpedCampos(10, "VL_LUC_PREJ_ANTES_IR", "NS", 19, 2, true)]
            public decimal? VlLucPrejAntesIr { get; set; }

            [SpedCampos(11, "VL_IR_PAGO_EST", "NS", 19, 2, false)]
            public decimal? VlIrPagoEst { get; set; }

            [SpedCampos(12, "VL_IR_PAGO", "NS", 19, 2, true)]
            public decimal? VlIrPago { get; set; }

            [SpedCampos(13, "VL_IR_DEVIDO_EST", "NS", 19, 2, false)]
            public decimal? VlIrDevidoEst { get; set; }

            [SpedCampos(14, "VL_IR_DEVIDO", "NS", 19, 2, true)]
            public decimal? VlIrDevido { get; set; }

            [SpedCampos(15, "VL_CAP_SOC_EST", "NS", 19, 2, false)]
            public decimal? VlCapSocEst { get; set; }

            [SpedCampos(16, "VL_CAP_SOC", "NS", 19, 2, true)]
            public decimal? VlCapSoc { get; set; }

            [SpedCampos(17, "VL_LUC_ACUM_EST", "NS", 19, 2, false)]
            public decimal? VlLucAcumEst { get; set; }

            [SpedCampos(18, "VL_LUC_ACUM", "NS", 19, 2, true)]
            public decimal? VlLucAcum { get; set; }

            [SpedCampos(19, "VL_ATIV_TANG_EST", "NS", 19, 2, false)]
            public decimal? VlAtivTangEst { get; set; }

            [SpedCampos(20, "VL_ATIV_TANG", "NS", 19, 2, true)]
            public decimal? VlAtivTang { get; set; }

            [SpedCampos(21, "NUM_EMP", "N", 7, 2, true)]
            public decimal? NumEmp { get; set; }
        }

        public class RegW250 : RegistroBaseSped
        {
            public RegW250()
            {
                Reg = "W250";
            }

            [SpedCampos(2, "JUR_DIFERENTE", "C", 2, 0, false)]
            public string JurDiferente { get; set; }

            [SpedCampos(3, "NOME", "C", 0, 0, true)]
            public string Nome { get; set; }

            [SpedCampos(4, "TIN", "C", 0, 0, true)]
            public string Tin { get; set; }

            [SpedCampos(5, "JURISDICAO_TIN", "C", 2, 0, false)]
            public string JurisdicaoTin { get; set; }

            [SpedCampos(6, "NI", "C", 0, 0, false)]
            public string Ni { get; set; }

            [SpedCampos(7, "JURISDICAO_NI", "C", 2, 0, false)]
            public string JurisdicaoNi { get; set; }

            [SpedCampos(8, "TIPO_NI", "C", 0, 0, false)]
            public string TipoNi { get; set; }

            [SpedCampos(9, "TIP_END", "C", 7, 0, true)]
            public string TipEnd { get; set; }

            [SpedCampos(10, "ENDEREÇO", "C", 150, 0, true)]
            public string Endereco { get; set; }

            [SpedCampos(11, "NUM_TEL", "C", 15, 0, false)]
            public string NumTel { get; set; }

            [SpedCampos(12, "EMAIL", "C", 115, 0, false)]
            public string Email { get; set; }

            [SpedCampos(13, "ATIV_1", "C", 1, 0, true)]
            public string Ativ1 { get; set; }

            [SpedCampos(14, "ATIV_2", "C", 1, 0, true)]
            public string Ativ2 { get; set; }

            [SpedCampos(15, "ATIV_3", "C", 1, 0, true)]
            public string Ativ3 { get; set; }

            [SpedCampos(16, "ATIV_4", "C", 1, 0, true)]
            public string Ativ4 { get; set; }

            [SpedCampos(17, "ATIV_5", "C", 1, 0, true)]
            public string Ativ5 { get; set; }

            [SpedCampos(18, "ATIV_6", "C", 1, 0, true)]
            public string Ativ6 { get; set; }

            [SpedCampos(19, "ATIV_7", "C", 1, 0, true)]
            public string Ativ7 { get; set; }

            [SpedCampos(20, "ATIV_8", "C", 1, 0, true)]
            public string Ativ8 { get; set; }

            [SpedCampos(21, "ATIV_9", "C", 1, 0, true)]
            public string Ativ9 { get; set; }

            [SpedCampos(22, "ATIV_10", "C", 1, 0, true)]
            public string Ativ10 { get; set; }

            [SpedCampos(23, "ATIV_11", "C", 1, 0, true)]
            public string Ativ11 { get; set; }

            [SpedCampos(24, "ATIV_12", "C", 1, 0, true)]
            public string Ativ12 { get; set; }

            [SpedCampos(25, "ATIV_13", "C", 1, 0, true)]
            public string Ativ13 { get; set; }

            [SpedCampos(26, "DESC_OUTROS", "C", 255, 0, false)]
            public string DescOutros { get; set; }

            [SpedCampos(27, "OBSERVAÇÃO", "C", 1000, 0, false)]
            public string Observacao { get; set; }
        }

        public class RegW300 : RegistroBaseSped
        {
            public RegW300()
            {
                Reg = "W300";
            }

            [SpedCampos(2, "JURISDICAO", "C", 0, 0, false)]
            public string Jurisdicao { get; set; }

            [SpedCampos(3, "IND_REC_NAO_REL", "C", 1, 0, false)]
            public string IndRecNaoRel { get; set; }

            [SpedCampos(4, "IND_REC_REL", "C", 1, 0, false)]
            public string IndRecRel { get; set; }

            [SpedCampos(5, "IND_REC_TOTAL", "C", 1, 0, false)]
            public string IndRecTotal { get; set; }

            [SpedCampos(6, "IND_LUC_PREJ_ANTES_IR", "C", 1, 0, false)]
            public string IndLucPrejAntesIr { get; set; }

            [SpedCampos(7, "IND_IR_PAGO", "C", 1, 0, false)]
            public string IndIrPago { get; set; }

            [SpedCampos(8, "IND_IR_DEVIDO", "C", 1, 0, false)]
            public string IndIrDevido { get; set; }

            [SpedCampos(9, "IND_CAP_SOC", "C", 1, 0, false)]
            public string IndCapSoc { get; set; }

            [SpedCampos(10, "IND_LUC_ACUM", "C", 1, 0, false)]
            public string IndLucAcum { get; set; }

            [SpedCampos(11, "IND_ATIV_TANG", "C", 1, 0, false)]
            public string IndAtivTang { get; set; }

            [SpedCampos(12, "IND_NUM_EMP", "C", 1, 0, false)]
            public string IndNumEmp { get; set; }

            [SpedCampos(13, "OBSERVAÇÃO", "C", 4000, 0, true)]
            public string Observacao { get; set; }

            [SpedCampos(14, "FIM_OBSERVACAO", "C", 4000, 0, true)]
            public string FimObservacao { get; set; }
        }

        public class RegW990 : RegistroBaseSped
        {
            public RegW990()
            {
                Reg = "W990";
            }

            [SpedCampos(2, "QTD_LIN", "N", 0, 0, true)]
            public int QtdLin { get; set; }
        }
    }
}