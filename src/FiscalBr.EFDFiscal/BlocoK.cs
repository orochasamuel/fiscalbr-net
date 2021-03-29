using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDFiscal
{
    /// <summary>
    ///     BLOCO K: CONTROLE DA PRODUÇÃO E DO ESTOQUE
    /// </summary>
    public class BlocoK
    {
        public RegistroK001 RegK001 { get; set; }
        public RegistroK990 RegK990 { get; set; }

        /// <summary>
        ///     REGISTRO K001: ABERTURA DO BLOCO K
        /// </summary>
        public class RegistroK001 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK001" />.
            /// </summary>
            public RegistroK001()
            {
                Reg = "K001";
            }

            /// <summary>
            ///     Indicador de movimento
            /// </summary>
            /// <remarks>
            ///     0 - Bloco com dados informados
            ///     <para />
            ///     1 - Bloco sem dados informados
            /// </remarks>
            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroK100> RegK100s { get; set; }
        }

        /// <summary>
        ///     REGISTRO K100: PERÍODO DE APURAÇÃO DO ICMS/IPI
        /// </summary>
        public class RegistroK100 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK100" />.
            /// </summary>
            public RegistroK100()
            {
                Reg = "K100";
            }

            /// <summary>
            ///     Data inicial a que a apuração se refere
            /// </summary>
            [SpedCampos(2, "DT_INI", "N", 8, 0, true)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///     Data final a que a apuração se refere
            /// </summary>
            [SpedCampos(3, "DT_FIN", "N", 8, 0, true)]
            public DateTime DtFin { get; set; }

            public List<RegistroK200> RegK200s { get; set; }
            public List<RegistroK210> RegK210s { get; set; }
            public List<RegistroK220> RegK220s { get; set; }
            public List<RegistroK230> RegK230s { get; set; }
            public List<RegistroK250> RegK250s { get; set; }
            public List<RegistroK260> RegK260s { get; set; }
            public List<RegistroK270> RegK270s { get; set; }
            public List<RegistroK280> RegK280s { get; set; }
            public List<RegistroK290> RegK290s { get; set; }
            public List<RegistroK300> RegK300s { get; set; }
        }

        /// <summary>
        ///     REGISTRO K200: ESTOQUE ESCRITURADO
        /// </summary>
        public class RegistroK200 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK200" />.
            /// </summary>
            public RegistroK200()
            {
                Reg = "K200";
            }

            /// <summary>
            ///     Data do estoque final
            /// </summary>
            [SpedCampos(2, "DT_EST", "N", 8, 0, true)]
            public DateTime DtEst { get; set; }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade em estoque
            /// </summary>
            [SpedCampos(4, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Indicador do tipo de estoque
            /// </summary>
            /// <remarks>
            ///     0 - Estoque de propriedade do informante e em seu poder
            ///     <para />
            ///     1 - Estoque de propriedade do informante e em posse de terceiros
            ///     <para />
            ///     2 - Estoque de propriedade de terceiros e em posse do informante
            /// </remarks>
            [SpedCampos(5, "IND_EST", "C", 1, 0, true)]
            public int IndEst { get; set; }

            /// <summary>
            ///     Código do participante
            /// </summary>
            /// <remarks>
            ///     - proprietário/possuidor que não seja o informante do arquivo
            /// </remarks>
            [SpedCampos(6, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }
        }

        /// <summary>
        ///     REGISTRO K210: DESMONTAGEM DE MERCADORIAS – ITEM DE ORIGEM
        /// </summary>
        public class RegistroK210 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK210" />.
            /// </summary>
            public RegistroK210()
            {
                Reg = "K210";
            }

            /// <summary>
            ///     Data de início da ordem de serviço
            /// </summary>
            [SpedCampos(2, "DT_INI_OS", "N", 8, 0, false)]
            public DateTime? DtIniOS { get; set; }

            /// <summary>
            ///     Data de conclusão da ordem de serviço
            /// </summary>
            [SpedCampos(3, "DT_FIN_OS", "N", 8, 0, false)]
            public DateTime? DtFinOS { get; set; }

            /// <summary>
            ///     Código de identificação da ordem de serviço
            /// </summary>
            [SpedCampos(4, "COD_DOC_OS", "C", 30, 0, false)]
            public string CodDocOS { get; set; }

            /// <summary>
            ///     Código do item de origem (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(5, "COD_ITEM_ORI", "C", 60, 0, true)]
            public string CodItemOri { get; set; }

            /// <summary>
            ///    Quantidade de origem – saída do estoque
            /// </summary>
            [SpedCampos(6, "QTD_ORI", "N", 0, 3, true)]
            public decimal QtdOri { get; set; }

            public List<RegistroK215> RegK215s { get; set; }
        }

        /// <summary>
        ///     REGISTRO K215: DESMONTAGEM DE MERCADORIAS – ITENS DE DESTINO
        /// </summary>
        public class RegistroK215 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK215" />.
            /// </summary>
            public RegistroK215()
            {
                Reg = "K215";
            }

            /// <summary>
            ///     Código do item de destino (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM_DES", "C", 60, 0, true)]
            public string CodItemDes { get; set; }

            /// <summary>
            ///    Quantidade de destino – entrada em estoque
            /// </summary>
            [SpedCampos(3, "QTD_DES", "N", 0, 3, true)]
            public decimal QtdDes { get; set; }
        }

        /// <summary>
        ///     REGISTRO K220: OUTRAS MOVIMENTAÇÕES INTERNAS ENTRE MERCADORIAS
        /// </summary>
        public class RegistroK220 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK220" />.
            /// </summary>
            public RegistroK220()
            {
                Reg = "K220";
            }

            /// <summary>
            ///     Data da movimentação interna
            /// </summary>
            [SpedCampos(2, "DT_MOV", "N", 8, 0, true)]
            public DateTime DtMov { get; set; }

            /// <summary>
            ///     Código do item de origem
            /// </summary>
            [SpedCampos(3, "COD_ITEM_ORI", "C", 60, 0, true)]
            public string CodItemOri { get; set; }

            /// <summary>
            ///     Código do item de destino
            /// </summary>
            [SpedCampos(4, "COD_ITEM_DEST", "C", 60, 0, true)]
            public string CodItemDest { get; set; }

            /// <summary>
            ///     Quantidade movimentada
            /// </summary>
            [SpedCampos(5, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Quantidade movimentada do item de destino
            ///     Guia Prático EFD-ICMS/IPI – Versão 2.0.21
            ///     Atualização: 22/08/2017
            /// </summary>
            [SpedCampos(6, "QTD_DEST", "N", 3, 0, false)]
            public string QtdDest { get; set; }
        }

        /// <summary>
        ///     REGISTRO K230: ITENS PRODUZIDOS
        /// </summary>
        public class RegistroK230 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK230" />.
            /// </summary>
            public RegistroK230()
            {
                Reg = "K230";
            }

            /// <summary>
            ///     Data de início da ordem de produção
            /// </summary>
            [SpedCampos(2, "DT_INI_OP", "N", 8, 0, false)]
            public DateTime DtIniOp { get; set; }

            /// <summary>
            ///     Data de conclusão da ordem de produção
            /// </summary>
            [SpedCampos(3, "DT_FIN_OP", "N", 8, 0, false)]
            public DateTime? DtFinOp { get; set; }

            /// <summary>
            ///     Código de identificação da ordem de produção
            /// </summary>
            [SpedCampos(4, "COD_DOC_OP", "C", 30, 0, false)]
            public string CodDocOp { get; set; }

            /// <summary>
            ///     Código do item produzido
            /// </summary>
            [SpedCampos(5, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade de produção acabada
            /// </summary>
            [SpedCampos(6, "QTD_ENC", "N", 0, 3, true)]
            public decimal QtdEnc { get; set; }

            public List<RegistroK235> RegK235s { get; set; }
        }

        /// <summary>
        ///     REGISTRO K235: INSUMOS CONSUMIDOS
        /// </summary>
        public class RegistroK235 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK235" />.
            /// </summary>
            public RegistroK235()
            {
                Reg = "K235";
            }

            /// <summary>
            ///     Data de saída do estoque para alocação ao produto
            /// </summary>
            [SpedCampos(2, "DT_SAÍDA", "N", 8, 0, true)]
            public DateTime DtSaida { get; set; }

            /// <summary>
            ///     Código do item componente/insumo
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade consumida do item
            /// </summary>
            [SpedCampos(4, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Código do insumo que foi substituído, caso ocorra a substituição
            /// </summary>
            [SpedCampos(5, "COD_INS_SUBST", "C", 60, 0, false)]
            public string CodInsSubst { get; set; }
        }

        /// <summary>
        ///     REGISTRO K250: INDUSTRIALIZAÇÃO EFETUADA POR TERCEIROS - ITENS PRODUZIDOS
        /// </summary>
        public class RegistroK250 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK250" />.
            /// </summary>
            public RegistroK250()
            {
                Reg = "K250";
            }

            /// <summary>
            ///     Data do reconhecimento da produção ocorrida no terceiro
            /// </summary>
            [SpedCampos(2, "DT_PROD", "N", 8, 0, true)]
            public DateTime DtProd { get; set; }

            /// <summary>
            ///     Código do item produzido
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade produzida
            /// </summary>
            [SpedCampos(4, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            public List<RegistroK255> RegK255s { get; set; }
        }

        /// <summary>
        ///     REGISTRO K255: INDUSTRIALIZAÇÃO EM TERCEIROS - INSUMOS CONSUMIDOS
        /// </summary>
        public class RegistroK255 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK255" />.
            /// </summary>
            public RegistroK255()
            {
                Reg = "K255";
            }

            /// <summary>
            ///     Data do reconhecimento do consumo do insumo referente ao produto informado no campo 04 do Registro K250
            /// </summary>
            [SpedCampos(2, "DT_CONS", "N", 8, 0, true)]
            public DateTime DtCons { get; set; }

            /// <summary>
            ///     Código do insumo
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade de consumo do insumo
            /// </summary>
            [SpedCampos(4, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }

            /// <summary>
            ///     Código do insumo que foi substituído, caso ocorra a substituição
            /// </summary>
            [SpedCampos(5, "COD_INS_SUBST", "C", 60, 0, false)]
            public string CodInsSubst { get; set; }
        }

        /// <summary>
        ///     REGISTRO K260: REPROCESSAMENTO/REPARO DE PRODUTO/INSUMO
        /// </summary>
        public class RegistroK260 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK260"/>.
            /// </summary>
            public RegistroK260()
            {
                Reg = "K260";
            }

            /// <summary>
            ///     Código de identificação da ordem de produção, no reprocessamento, ou da ordem de serviço, no reparo
            /// </summary>
            [SpedCampos(2, "COD_OP_OS", "C", 30, 0, false)]
            public string CodOpOS { get; set; }

            /// <summary>
            ///     Código do produto/insumo a ser reprocessado/reparado ou já reprocessado/reparado(campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(3, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Data de saída do estoque
            /// </summary>
            [SpedCampos(4, "DT_SAiDA", "N", 8, 0, true)]
            public DateTime DtSaida { get; set; }

            /// <summary>
            ///    Quantidade de saída do estoque
            /// </summary>
            [SpedCampos(5, "QTD_SAIDA", "N", 0, 3, true)]
            public decimal QtdSaida { get; set; }

            /// <summary>
            ///     Data de retorno ao estoque (entrada) 
            /// </summary>
            [SpedCampos(6, "DT_RET", "N", 8, 0, false)]
            public DateTime? DtReg { get; set; }

            /// <summary>
            ///    Quantidade de retorno ao estoque (entrada)
            /// </summary>
            [SpedCampos(7, "QTD_RET", "N", 0, 3, false)]
            public decimal? QtdRet { get; set; }

            public List<RegistroK265> RegK265s { get; set; }
        }

        /// <summary>
        ///     REGISTRO K265: REPROCESSAMENTO/REPARO – MERCADORIAS CONSUMIDAS E/OU RETORNADAS
        /// </summary>
        public class RegistroK265 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK265" />.
            /// </summary>
            public RegistroK265()
            {
                Reg = "K265";
            }

            /// <summary>
            ///     Código da mercadoria (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///    Quantidade consumida – saída do estoque
            /// </summary>
            [SpedCampos(3, "QTD_CONS", "N", 0, 3, false)]
            public decimal? QtdCons { get; set; }

            /// <summary>
            ///    Quantidade retornada – entrada em estoque
            /// </summary>
            [SpedCampos(4, "QTD_RET", "N", 0, 3, false)]
            public decimal? QtdRet { get; set; }
        }

        /// <summary>
        ///     REGISTRO K270: CORREÇÃO DE APONTAMENTO DOS REGISTROS K210, K220, K230, K250 , K260, K291, K292, K301 E K302
        /// </summary>
        public class RegistroK270 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK270"/>.
            /// </summary>
            public RegistroK270()
            {
                Reg = "K270";
            }

            /// <summary>
            ///     Data inicial do período de apuração em que ocorreu o apontamento que está sendo corrigido
            /// </summary>
            [SpedCampos(2, "DT_INI_AP", "N", 8, 0, false)]
            public DateTime? DtIniAP { get; set; }

            /// <summary>
            ///     Data final do período de apuração em que ocorreu o apontamento que está sendo corrigido
            /// </summary>
            [SpedCampos(3, "DT_FIN_AP", "N", 8, 0, false)]
            public DateTime? DtFinAP { get; set; }

            /// <summary>
            ///     Código de identificação da ordem de produção ou da ordem de serviço que está sendo corrigida
            /// </summary>
            [SpedCampos(4, "COD_OP_OS", "C", 30, 0, false)]
            public string CodOpOs { get; set; }

            /// <summary>
            ///     Código da mercadoria que está sendo corrigido (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(5, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Quantidade de correção positiva de apontamento ocorrido em período de apuração anterior
            /// </summary>
            [SpedCampos(6, "QTD_COR_POS", "N", 0, 3, false)]
            public decimal? QtdCorPos { get; set; }

            /// <summary>
            ///     Quantidade de correção negativa de apontamento ocorrido em período de apuração anterior
            /// </summary>
            [SpedCampos(7, "QTD_COR_NEG", "N", 0, 3, false)]
            public decimal? QtdCorNeg { get; set; }

            /// <summary>
            ///     1 - correção de apontamento de produção e/ou consumo relativo aos Registros K230/K235;
            ///     2 - correção de apontamento de produção e/ou consumo relativo aos Registros K250/K255;
            ///     3 - correção de apontamento de desmontagem e/ou consumo relativo aos Registros K210/K215;
            ///     4 - correção de apontamento de reprocessamento/reparo e/ou consumo relativo aos Registros K260/K265;
            ///     5 - correção de apontamento de movimentação interna relativo ao Registro K220.
            ///     6 – correção de apontamento de produção relativo ao Registro K291; 
            ///     7 – correção de apontamento de consumo relativo ao Registro K292;
            ///     8 – correção de apontamento de produção relativo ao Registro K301;
            ///     9 – correção de apontamento de consumo relativo ao Registro K302.
            /// </summary>
            [SpedCampos(8, "ORIGEM", "C", 1, 0, true)]
            public string Origem { get; set; }

            public List<RegistroK275> RegK275s { get; set; }
        }

        /// <summary>
        ///     REGISTRO K275: CORREÇÃO DE APONTAMENTO E RETORNO DE INSUMOS DOS REGISTROS K215, K220, K235, K255 E K265.
        /// </summary>
        public class RegistroK275 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK275" />.
            /// </summary>
            public RegistroK275()
            {
                Reg = "K275";
            }

            /// <summary>
            ///     Código da mercadoria (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///    Quantidade de correção positiva de apontamento ocorrido em período de apuração anterior
            /// </summary>
            [SpedCampos(3, "QTD_COR_POS", "N", 0, 3, false)]
            public decimal? QtdCorPos { get; set; }

            /// <summary>
            ///    Quantidade de correção negativa de apontamento ocorrido em período de apuração anterior
            /// </summary>
            [SpedCampos(4, "QTD_COR NEG", "N", 0, 3, false)]
            public decimal? QtdCorNeg { get; set; }

            /// <summary>
            ///    Código do insumo que foi substituído, caso ocorra a substituição, relativo aos Registros K235/K255
            /// </summary>
            [SpedCampos(5, "COD_INS_SUBST", "C", 60, 0, false)]
            public string CodInstSubst { get; set; }
        }

        /// <summary>
        ///     REGISTRO K280: CORREÇÃO DE APONTAMENTO – ESTOQUE ESCRITURADO
        /// </summary>
        public class RegistroK280 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK280" />.
            /// </summary>
            public RegistroK280()
            {
                Reg = "K280";
            }

            /// <summary>
            ///     Código da mercadoria (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///    Quantidade de correção positiva de apontamento ocorrido em período de apuração anterior
            /// </summary>
            [SpedCampos(3, "QTD_COR_POS", "N", 0, 3, false)]
            public decimal? QtdCorPos { get; set; }

            /// <summary>
            ///    Quantidade de correção negativa de apontamento ocorrido em período de apuração anterior
            /// </summary>
            [SpedCampos(4, "QTD_COR NEG", "N", 0, 3, false)]
            public decimal? QtdCorNeg { get; set; }

            /// <summary>
            ///     Indicador do tipo de estoque:
            ///         0 = Estoque de propriedade do informante e em seu poder;
            ///         1 = Estoque de propriedade do informante e em posse de terceiros;
            ///         2 = Estoque de propriedade de terceiros e em posse do informante
            /// </summary>
            [SpedCampos(5, "IND_EST", "C", 1, 0, true)]
            public string IndEst { get; set; }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150):
            ///         - proprietário/possuidor que não seja o informante do arquivo
            /// </summary>
            [SpedCampos(6, "COD_PART", "C", 60, 0, false)]
            public string CodPart { get; set; }
        }

        /// <summary>
        ///     REGISTRO K290: PRODUÇÃO CONJUNTA – ORDEM DE PRODUÇÃ
        /// </summary>
        public class RegistroK290 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK290" />.
            /// </summary>
            public RegistroK290()
            {
                Reg = "K290";
            }

            /// <summary>
            ///     Data de início da ordem de produção
            /// </summary>
            [SpedCampos(2, "DT_INI_OP", "N", 8, 0, false)]
            public DateTime? DtIniOp { get; set; }

            /// <summary>
            ///     Data de conclusão da ordem de produção
            /// </summary>
            [SpedCampos(3, "DT_FIN_OP", "N", 8, 0, false)]
            public DateTime? DtFinOp { get; set; }

            /// <summary>
            ///     Código de identificação da ordem de produção
            /// </summary>
            [SpedCampos(3, "COD_DOC_OP", "C", 30, 0, false)]
            public string CodDocOp { get; set; }

            public List<RegistroK291> RegK291s { get; set; }
            public List<RegistroK292> RegK292s { get; set; }
        }

        /// <summary>
        ///     REGISTRO K291: PRODUÇÃO CONJUNTA - ITENS PRODUZIDOS
        /// </summary>
        public class RegistroK291 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK291" />.
            /// </summary>
            public RegistroK291()
            {
                Reg = "K291";
            }

            /// <summary>
            ///     Código do item produzido (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///    Quantidade de produção acabada
            /// </summary>
            [SpedCampos(3, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }
        }

        /// <summary>
        ///     REGISTRO K292: PRODUÇÃO CONJUNTA – INSUMOS CONSUMIDOS
        /// </summary>
        public class RegistroK292 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK292" />.
            /// </summary>
            public RegistroK292()
            {
                Reg = "K292";
            }

            /// <summary>
            ///     Código do insumo/componente consumido (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///    Quantidade consumida
            /// </summary>
            [SpedCampos(3, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }
        }

        /// <summary>
        ///     REGISTRO K300: PRODUÇÃO CONJUNTA – INDUSTRIALIZAÇÃO EFETUADA POR TERCEIROS
        /// </summary>
        public class RegistroK300 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK300" />.
            /// </summary>
            public RegistroK300()
            {
                Reg = "K300";
            }

            /// <summary>
            ///    Data do reconhecimento da produção ocorrida no terceiro
            /// </summary>
            [SpedCampos(2, "DT_PROD", "N", 8, 0, true)]
            public DateTime DtProd { get; set; }

            public List<RegistroK301> RegK301s { get; set; }
            public List<RegistroK302> RegK302s { get; set; }
        }

        /// <summary>
        ///     REGISTRO K301: PRODUÇÃO CONJUNTA – INDUSTRIALIZAÇÃO EFETUADA POR TERCEIROS – ITENS PRODUZIDOS
        /// </summary>
        public class RegistroK301 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK301" />.
            /// </summary>
            public RegistroK301()
            {
                Reg = "K301";
            }

            /// <summary>
            ///     Código do item produzido (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///    Quantidade produzida
            /// </summary>
            [SpedCampos(3, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }
        }

        /// <summary>
        ///     REGISTRO K302: PRODUÇÃO CONJUNTA – INDUSTRIALIZAÇÃO EFETUADA POR TERCEIROS – INSUMOS CONSUMIDOS
        /// </summary>
        public class RegistroK302 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK302" />.
            /// </summary>
            public RegistroK302()
            {
                Reg = "K302";
            }

            /// <summary>
            ///     Código do insumo (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///    Quantidade consumida
            /// </summary>
            [SpedCampos(3, "QTD", "N", 0, 3, true)]
            public decimal Qtd { get; set; }
        }

        /// <summary>
        ///     REGISTRO K990: ENCERRAMENTO DO BLOCO K
        /// </summary>
        public class RegistroK990 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroK990" />.
            /// </summary>
            public RegistroK990()
            {
                Reg = "K990";
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco K
            /// </summary>
            [SpedCampos(2, "QTD_LIN_K", "N", int.MaxValue, 0, true)]
            public int QtdLinK { get; set; }
        }
    }
}