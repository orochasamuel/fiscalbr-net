using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDFiscal
{
    /// <summary>
    ///     BLOCO G: CONTROLE DO CRÉDITO DE ICMS DO ATIVO PERMANENTE CIAP
    /// </summary>
    public class BlocoG
    {
        public RegistroG001 RegG001 { get; set; }
        public RegistroG990 RegG990 { get; set; }

        /// <summary>
        ///     REGISTRO G001: ABERTURA DO BLOCO G
        /// </summary>
        public class RegistroG001 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroG001" />.
            /// </summary>
            public RegistroG001()
            {
                Reg = "G001";
            }

            /// <summary>
            ///     Indicador de movimento:
            ///     0 - Bloco com dados informados;
            ///     1 - Bloco sem dados informados.
            /// </summary>
            [SpedCampos(2, "IND_MOV", "N", 1, 0, true)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroG110> RegG110s { get; set; }
        }

        /// <summary>
        ///     REGISTRO G110: ICMS - ATIVO PERMANENTE - CIAP
        /// </summary>
        public class RegistroG110 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroG110" />.
            /// </summary>
            public RegistroG110()
            {
                Reg = "G110";
            }

            /// <summary>
            ///     Data final a que a apuração se refere
            /// </summary>
            [SpedCampos(2, "DT_INI", "N", 8, 0, true)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///     Data final a que a apuração se refere
            /// </summary>
            [SpedCampos(3, "DT_FIN", "N", 8, 0, true)]
            public DateTime DtFin { get; set; }

            /// <summary>
            ///     Saldo inicial de ICMS do CIAP, composto por ICMS de bens que entraram anteriormente ao período de apuração
            ///     (somatório dos campos 05 a 08 dos registros G125)
            /// </summary>
            [SpedCampos(4, "SALDO_IN_ICMS", "N", 0, 2, true)]
            public decimal SaldoInIcms { get; set; }

            /// <summary>
            ///     Somatório das parcelas de ICMS passível de apropriação de cada bem (campo 10 do G125)
            /// </summary>
            [SpedCampos(5, "SOM_PARC", "N", 0, 2, true)]
            public decimal SomParc { get; set; }

            /// <summary>
            ///     Valor do somatório das saídas tributadas e saídas para exportação
            /// </summary>
            [SpedCampos(6, "VL_TRIB_EXP", "N", 0, 2, true)]
            public decimal VlTribExp { get; set; }

            /// <summary>
            ///     Valor total de saídas
            /// </summary>
            [SpedCampos(7, "VL_TOTAL", "N", 0, 2, true)]
            public decimal VlTotal { get; set; }

            /// <summary>
            ///     Índice de participação do valor do somatório das saídas tributadas e saídas para exportação no valor total de
            ///     saídas (campo 06 dividido pelo campo 07)
            /// </summary>
            [SpedCampos(8, "IND_PER_SAI", "N", 0, 8, true)]
            public decimal IndPerSai { get; set; }

            /// <summary>
            ///     Valor de ICMS a ser apropriado na apuração do ICMS, corresponde à multiplicação do campo 05 pelo campo 08.
            /// </summary>
            [SpedCampos(9, "ICMS_APROP", "N", 0, 2, true)]
            public decimal IcmsAprop { get; set; }

            /// <summary>
            ///     Valor de outros créditos a ser apropriado na apuração do ICMS, corresponde ao somatório do campo 09 do registro
            ///     G126.
            /// </summary>
            [SpedCampos(10, "SOM_ICMS_OC", "N", 0, 2, true)]
            public decimal SomIcmsOc { get; set; }

            public List<RegistroG125> RegG125s { get; set; }
        }

        /// <summary>
        ///     REGISTRO G125: MOVIMENTAÇÃO DE BEM OU COMPONENTE DO ATIVO IMOBILIZADO
        /// </summary>
        public class RegistroG125 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroG125" />.
            /// </summary>
            public RegistroG125()
            {
                Reg = "G125";
            }

            /// <summary>
            ///     Código individualizado do bem ou componente adotado no controle patrimonial do estabelecimento informante
            /// </summary>
            [SpedCampos(2, "COD_IND_BEM", "C", 2, 0, true)]
            public string CodIndBem { get; set; }

            /// <summary>
            ///     Data da movimentação ou do saldo inicial
            /// </summary>
            [SpedCampos(3, "DT_MOV", "N", 0, 2, true)]
            public DateTime DtMov { get; set; }

            /// <summary>
            ///     Tipo de movimentação do bem ou componente.
            /// </summary>
            /// <remarks>
            ///     SI = Saldo inicial de bens imobilizados
            ///     IM = Imobilização de bem individual
            ///     IA = Imobilização em andamento - componente
            ///     CI = Conclusão de imobilização em andamento - bem resultante
            ///     MC = Imobilização oriunda do ativo circulante
            ///     BA = Baixa do bem - fim do período de apropriação
            ///     AT = Alienação ou Transferência
            ///     PE = Perecimento, Extravio ou Deterioração
            ///     OT = Outras Saídas do Imobilizado
            /// </remarks>
            [SpedCampos(4, "TIPO_MOV", "N", 0, 2, true)]
            public string TipoMov { get; set; }

            /// <summary>
            ///     Valor do ICMS da operação própria na entrada do bem ou componente
            /// </summary>
            [SpedCampos(5, "VL_IMOB_ICMS_OP", "N", 0, 2, false)]
            public decimal VlImobIcmsOp { get; set; }

            /// <summary>
            ///     Valor do ICMS da operação por sub. tributária na entrada do bem ou componente
            /// </summary>
            [SpedCampos(6, "VL_IMOB_ICMS_ST", "N", 0, 2, false)]
            public decimal VlImobIcmsSt { get; set; }

            /// <summary>
            ///     Valor do ICMS sobre frete do conhecimento de transporte na entrada do bem ou componente
            /// </summary>
            [SpedCampos(7, "VL_IMOB_ICMS_FRT", "N", 0, 2, false)]
            public decimal VlImobIcmsFrt { get; set; }

            /// <summary>
            ///     Valor do ICMS - diferencial de alíquota, conforme doc. de arrecação, na entrada do bem ou componente
            /// </summary>
            [SpedCampos(8, "VL_IMOB_ICMS_DIF", "N", 0, 2, false)]
            public decimal VlImobIcmsDif { get; set; }

            /// <summary>
            ///     Número da parcela do ICMS
            /// </summary>
            [SpedCampos(9, "NUM_PARC", "N", 3, 0, false)]
            public int NumParc { get; set; }

            /// <summary>
            ///     Valor da parcela do ICMS passível de apropriação (antes da aplicação da participação percentual do valor das saídas
            ///     tributadas/exportação sobre as saídas totais)
            /// </summary>
            [SpedCampos(10, "VL_PARC_PASS", "N", 0, 2, false)]
            public decimal VlParcPass { get; set; }

            public List<RegistroG126> RegG126s { get; set; }
            public List<RegistroG130> RegG305s { get; set; }
        }

        /// <summary>
        ///     REGISTRO G126: OUTROS CRÉDITOS CIAP
        /// </summary>
        public class RegistroG126 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroG126" />.
            /// </summary>
            public RegistroG126()
            {
                Reg = "G126";
            }

            /// <summary>
            ///     Data inicial do período de apuração
            /// </summary>
            [SpedCampos(2, "DT_INI", "N", 8, 0, true)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///     Data final do período de apuração
            /// </summary>
            [SpedCampos(3, "DT_FIM", "N", 8, 0, true)]
            public DateTime DtFim { get; set; }

            /// <summary>
            ///     Número de parcela do ICMS
            /// </summary>
            [SpedCampos(4, "NUM_PARC", "N", 3, 02, true)]
            public int NumParc { get; set; }

            /// <summary>
            ///     Valor da parcela de ICMS passível de apropriação - antes da aplicação da participação percentual do valor das
            ///     saídas tributadas/exportação sobre as saídas totais
            /// </summary>
            [SpedCampos(5, "VL_PARC_PASS", "N", 0, 2, true)]
            public decimal VlParcPass { get; set; }

            /// <summary>
            ///     Valor do somatório das saídas tributadas e saídas para exportação no período indicado neste registro
            /// </summary>
            [SpedCampos(6, "VL_TRIB_OC", "N", 0, 2, true)]
            public decimal VlTribOc { get; set; }

            /// <summary>
            ///     Valor total de saídas no período indicado neste registro
            /// </summary>
            [SpedCampos(7, "VL_TOTAL", "N", 0, 2, true)]
            public decimal VlTotal { get; set; }

            /// <summary>
            ///     Índice de participação do valor do somatório das saídas tributadas e saídas para exportação no valor total de
            ///     saídas (campo 06 dividido pelo campo 07)
            /// </summary>
            [SpedCampos(8, "IND_PER_SAI", "N", 0, 8, true)]
            public decimal IndPerSai { get; set; }

            /// <summary>
            ///     Valor de outros créditos de ICMS a ser apropriado na apuração (campo 05 vezes o campo 08)
            /// </summary>
            [SpedCampos(9, "VL_PARC_APROP", "N", 0, 2, true)]
            public decimal VlParcAprop { get; set; }
        }

        /// <summary>
        ///     REGISTRO G130: IDENTIFICAÇÃO DO DOCUMENTO FISCAL
        /// </summary>
        public class RegistroG130 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroG130" />.
            /// </summary>
            public RegistroG130()
            {
                Reg = "G130";
            }

            /// <summary>
            ///     Indicador do emitente do documento fiscal
            /// </summary>
            /// <remarks>
            ///     0 - Emissão própria
            ///     1 - Terceiros
            /// </remarks>
            [SpedCampos(2, "IND_EMIT", "C", 1, 0, true)]
            public int IndEmit { get; set; }

            /// <summary>
            ///     Código do participante
            /// </summary>
            /// <remarks>
            ///     - do emitente do documento ou do remetente das mercadorias no caso das entradas;
            ///     - do adquirente, no caso de saídas
            /// </remarks>
            [SpedCampos(3, "COD_PART", "C", 60, 0, true)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo de documento fiscal
            /// </summary>
            [SpedCampos(4, "COD_MOD", "C", 2, 0, true)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(5, "SERIE", "C", 3, 0, false)]
            public string Serie { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(6, "NUM_DOC", "N", 9, 0, true)]
            public long NumDoc { get; set; }

            /// <summary>
            ///     Chave do documento fiscal eletrônico
            /// </summary>
            [SpedCampos(7, "CHV_NFE_CTE", "N", 44, 0, false)]
            public string ChvNfeCte { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(8, "DT_DOC", "N", 8, 0, true)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Número do documento de arrecadação estadual, se houver
            /// </summary>
            [SpedCampos(9, "NUM_DA", "C", 99, 0, false)]
            public string NumDa { get; set; }

            public List<RegistroG140> RegG140s { get; set; }
        }

        /// <summary>
        ///     REGISTRO G140: IDENTIFICAÇÃO DO ITEM DO DOCUMENTO FISCAL
        /// </summary>
        public class RegistroG140 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroG140" />.
            /// </summary>
            public RegistroG140()
            {
                Reg = "G140";
            }

            /// <summary>
            ///     Número sequencial do item no documento fiscal
            /// </summary>
            [SpedCampos(2, "NUM_ITEM", "N", 3, 0, true)]
            public int NumItem { get; set; }

            /// <summary>
            ///     Código correspondente do bem no documento fiscal (campo 02 do registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade, deste item da nota fiscal, que foi aplicada neste bem, expressa na mesma unidade constante no documento fiscal de entrada
            /// </summary>
            [SpedCampos(4, "QTDE", "N", 0, 5, true)]
            public decimal Qtde { get; set; }

            /// <summary>
            ///     Unidade do item constante no documento fiscal de entrada
            /// </summary>
            [SpedCampos(5, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///     Valor do ICMS da Operação Própria na entrada do item, proporcional à quantidade aplicada no bem ou componente.
            /// </summary>
            [SpedCampos(6, "VL_ICMS_OP_APLICADO", "N", 0, 2, true)]
            public decimal VlIcmsOpAplicado { get; set; }

            /// <summary>
            ///     Valor do ICMS ST na entrada do item, proporcional à quantidade aplicada no bem ou componente.
            /// </summary>
            [SpedCampos(7, "VL_ICMS_ST_APLICADO", "N", 0, 2, true)]
            public decimal VlIcmsStAplicado { get; set; }

            /// <summary>
            ///     Valor do ICMS sobre Frete do Conhecimento de Transporte na entrada do item, proporcional à quantidade aplicada no bem ou componente.
            /// </summary>
            [SpedCampos(8, "VL_ICMS_FRT_APLICADO", "N", 0, 2, true)]
            public decimal VlIcmsFrtAplicado { get; set; }

            /// <summary>
            ///     Valor do ICMS Diferencial de Alíquota, na entrada do item, proporcional à quantidade aplicada no bem ou componente.
            /// </summary>
            [SpedCampos(9, "VL_ICMS_DIF_APLICADO", "N", 0, 2, true)]
            public decimal VlIcmsDifAplicado { get; set; }
        }

        /// <summary>
        ///     REGISTRO G990: ENCERRAMENTO DO BLOCO G
        /// </summary>
        public class RegistroG990 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroG990" />.
            /// </summary>
            public RegistroG990()
            {
                Reg = "G990";
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco G
            /// </summary>
            [SpedCampos(2, "QTD_LIN_G", "N", int.MaxValue, 0, true)]
            public int QtdLinG { get; set; }
        }
    }
}
