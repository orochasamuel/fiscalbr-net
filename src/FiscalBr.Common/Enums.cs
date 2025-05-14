using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FiscalBr.Common
{
    #region ECD

    public enum CodigoEntidade
    {
        /// <summary>
        ///     Nenhuma inscrição em outras entidades
        /// </summary>
        [DefaultValue("00")] None,

        /// <summary>
        ///     Banco Central do Brasil
        /// </summary>
        [DefaultValue("01")] BancoCentral,

        /// <summary>
        ///     Superintendência de Seguros Privados (Susep)
        /// </summary>
        [DefaultValue("02")] Susep,

        /// <summary>
        ///     Comissão de Valores Mobiliários (CVM)
        /// </summary>
        [DefaultValue("03")] Cvm,

        /// <summary>
        ///     Agência Nacional de Transportes Terrestres (ANTT)
        /// </summary>
        [DefaultValue("04")] Antt,

        /// <summary>
        ///     Tribunal Superior Eleitoral (TSE)
        /// </summary>
        [DefaultValue("05")] Tse,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Acre
        /// </summary>
        [DefaultValue("AC")] AC,

        /// <summary>
        ///     Secretaria da Fazenda do Estado de Alagoas
        /// </summary>
        [DefaultValue("AL")] AL,

        /// <summary>
        ///     Secretaria da Fazenda do Estado de Amazonas
        /// </summary>
        [DefaultValue("AM")] AM,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Amapá
        /// </summary>
        [DefaultValue("AP")] AP,

        /// <summary>
        ///     Secretaria da Fazenda do Estado da Bahia
        /// </summary>
        [DefaultValue("BA")] BA,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Distrito Federal
        /// </summary>
        [DefaultValue("DF")] DF,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Ceará
        /// </summary>
        [DefaultValue("CE")] CE,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Espírito Santo
        /// </summary>
        [DefaultValue("ES")] ES,

        /// <summary>
        ///     Secretaria da Fazenda do Estado de Goiás
        /// </summary>
        [DefaultValue("GO")] GO,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Maranhão
        /// </summary>
        [DefaultValue("MA")] MA,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Mato Grosso
        /// </summary>
        [DefaultValue("MT")] MT,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Mato Grosso do Sul
        /// </summary>
        [DefaultValue("MS")] MS,

        /// <summary>
        ///     Secretaria da Fazenda do Estado de Minas Gerais
        /// </summary>
        [DefaultValue("MG")] MG,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Pará
        /// </summary>
        [DefaultValue("PA")] PA,

        /// <summary>
        ///     Secretaria da Fazenda do Estado da Paraíba
        /// </summary>
        [DefaultValue("PB")] PB,

        /// <summary>
        ///     Secretaria da Fazenda do Estado de Pernambuco
        /// </summary>
        [DefaultValue("PE")] PE,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Paraná
        /// </summary>
        [DefaultValue("PR")] PR,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Piauí
        /// </summary>
        [DefaultValue("PI")] PI,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Rio de Janeiro
        /// </summary>
        [DefaultValue("RJ")] RJ,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Rio Grande do Norte
        /// </summary>
        [DefaultValue("RN")] RN,

        /// <summary>
        ///     Secretaria da Fazenda do Estado do Rio Grande do Sul
        /// </summary>
        [DefaultValue("RS")] RS,

        /// <summary>
        ///     Secretaria da Fazenda do Estado de Roraima
        /// </summary>
        [DefaultValue("RR")] RR,

        /// <summary>
        ///     Secretaria da Fazenda do Estado de Rondônia
        /// </summary>
        [DefaultValue("RO")] RO,

        /// <summary>
        ///     Secretaria da Fazenda do Estado de Santa Catarina
        /// </summary>
        [DefaultValue("SC")] SC,

        /// <summary>
        ///     Secretaria da Fazenda do Estado de São Paulo
        /// </summary>
        [DefaultValue("SP")] SP,

        /// <summary>
        ///     Secretaria da Fazenda do Estado de Sergipe
        /// </summary>
        [DefaultValue("SE")] SE,

        /// <summary>
        ///     Secretaria da Fazenda do Estado de Tocantins
        /// </summary>
        [DefaultValue("TO")] TO,
    }

    #endregion ECD

    public enum LeiauteArquivoSped
    {
        [DefaultValue("EFDContribuicoes")] EFDContrib,
        [DefaultValue("EFDFiscal")] EFDFiscal,
        [DefaultValue("ECD")] ECD,
        [DefaultValue("ECF")] ECF,
    }

    public enum VersaoLeiauteSped
    {
        [DefaultValue("01")] V1 = 1,
        [DefaultValue("02")] V2,
        [DefaultValue("03")] V3,
        [DefaultValue("04")] V4,
        [DefaultValue("05")] V5,
        [DefaultValue("06")] V6,
        [DefaultValue("07")] V7,
        [DefaultValue("08")] V8,
        [DefaultValue("09")] V9,
        [DefaultValue("10")] V10,
        [DefaultValue("11")] V11,
        [DefaultValue("12")] V12,
        [DefaultValue("13")] V13,
        [DefaultValue("14")] V14,
        [DefaultValue("15")] V15,
        [DefaultValue("16")] V16,
        [DefaultValue("17")] V17,
        [DefaultValue("18")] V18,
        [DefaultValue("19")] V19
    }

    public enum CodVersaoSpedECD
    {
        /// <summary>
        /// Até o Ano-Calendário 2012
        /// </summary>
        [DefaultValue("0001")] V1 = 1,

        /// <summary>
        /// Ano-Calendário 2013
        /// </summary>
        [DefaultValue("0002")] V2,

        /// <summary>
        /// Ano-Calendário 2014
        /// </summary>
        [DefaultValue("0003")] V3,

        /// <summary>
        /// Ano-Calendário 2015
        /// </summary>
        [DefaultValue("0004")] V4,

        /// <summary>
        /// Ano-Calendário 2016
        /// </summary>
        [DefaultValue("0005")] V5,

        /// <summary>
        /// Ano-Calendário 2017
        /// </summary>
        [DefaultValue("0006")] V6,

        /// <summary>
        /// Ano-Calendário 2018
        /// </summary>
        [DefaultValue("0007")] V7,

        /// <summary>
        /// Ano-Calendário 2019
        /// </summary>
        [DefaultValue("0008")] V8,

        /// <summary>
        /// Ano-Calendário 2020, 2021 e 2022
        /// </summary>
        [DefaultValue("0009")] V9,
    }

    public enum CodVersaoSpedECF
    {
        /// <summary>
        /// Ano-Calendário 2014 e Situações Especiais de 2015
        /// </summary>
        [DefaultValue("0001")] V1 = 1,

        /// <summary>
        /// Ano-Calendário 2015 e Situações Especiais de 2016
        /// </summary>
        [DefaultValue("0002")] V2,

        /// <summary>
        /// Ano-Calendário 2016 e Situações Especiais de 2017
        /// </summary>
        [DefaultValue("0003")] V3,

        /// <summary>
        /// Ano-Calendário 2017 e Situações Especiais de 2018
        /// </summary>
        [DefaultValue("0004")] V4,

        /// <summary>
        /// Ano-Calendário 2018 e Situações Especiais de 2019
        /// </summary>
        [DefaultValue("0005")] V5,

        /// <summary>
        /// Ano-Calendário 2019 e Situações Especiais de 2020
        /// </summary>
        [DefaultValue("0006")] V6,

        /// <summary>
        /// Ano-Calendário 2020 e Situações Especiais de 2021
        /// </summary>
        [DefaultValue("0007")] V7,

        /// <summary>
        /// Ano-Calendário 2021 e Situações Especiais de 2022
        /// </summary>
        [DefaultValue("0008")] V8,

        /// <summary>
        /// Ano-Calendário 2022 e Situações Especiais de 2023
        /// </summary>
        [DefaultValue("0009")] V9,
    }

    public enum CodVersaoSpedContrib
    {
        /// <summary>
        /// Código: 001
        /// Versão: 1.00
        /// Validade: 01/04/2011 - 30/06/2012
        /// </summary>
        [DefaultValue("001")] V1 = 1,

        /// <summary>
        /// Código: 002
        /// Versão: 2.00
        /// Validade: 01/04/2011 - 30/06/2012
        /// </summary>
        [DefaultValue("002")] V2,

        /// <summary>
        /// Código: 003
        /// Versão: 2.01A
        /// Validade: 01/07/2012 - 31/05/2018
        /// </summary>
        [DefaultValue("003")] V3,

        /// <summary>
        /// Código: 004
        /// Versão: 3.0.0
        /// Validade: 01/06/2018 - 31/12/2018
        /// </summary>
        [DefaultValue("004")] V4,

        /// <summary>
        /// Código: 005
        /// Versão: 3.1.0
        /// Validade: 01/01/2019 - 31/12/2019
        /// </summary>
        [DefaultValue("005")] V5,

        /// <summary>
        /// Código: 006
        /// Versão: 3.2.0
        /// Validade: 01/01/2020 - 31/12/20??
        /// </summary>
        [DefaultValue("006")] V6,
    }

    public enum CodVersaoSpedFiscal
    {
        /// <summary>
        /// Código: 002
        /// Versão: 1.01
        /// Validade: 01/01/2009 - 31/12/2009
        /// </summary>
        [DefaultValue("002")] V2 = 2,

        /// <summary>
        /// Código: 003
        /// Versão: 1.02
        /// Validade: 01/01/2010 - 31/12/2010
        /// </summary>
        [DefaultValue("003")] V3,

        /// <summary>
        /// Código: 004
        /// Versão: 1.03
        /// Validade: 01/01/2011 - 31/12/2011
        /// </summary>
        [DefaultValue("004")] V4,

        /// <summary>
        /// Código: 005
        /// Versão: 1.04
        /// Validade: 01/01/2012 - 30/06/2012
        /// </summary>
        [DefaultValue("005")] V5,

        /// <summary>
        /// Código: 006
        /// Versão: 1.05
        /// Validade: 01/07/2012 - 31/12/2012
        /// </summary>
        [DefaultValue("006")] V6,

        /// <summary>
        /// Código: 007
        /// Versão: 1.06
        /// Validade: 01/01/2013 - 31/12/2013
        /// </summary>
        [DefaultValue("007")] V7,

        /// <summary>
        /// Código: 008
        /// Versão: 1.07
        /// Validade: 01/01/2014 - 31/12/2014
        /// </summary>
        [DefaultValue("008")] V8,

        /// <summary>
        /// Código: 009
        /// Versão: 1.08
        /// Validade: 01/01/2015 - 31/12/2015
        /// </summary>
        [DefaultValue("009")] V9,

        /// <summary>
        /// Código: 010
        /// Versão: 1.09
        /// Validade: 01/01/2016 - 31/12/2016
        /// </summary>
        [DefaultValue("010")] V10,

        /// <summary>
        /// Código: 011
        /// Versão: 1.10
        /// Validade: 01/01/2017 - 31/12/2017
        /// </summary>
        [DefaultValue("011")] V11,

        /// <summary>
        /// Código: 012
        /// Versão: 1.11
        /// Validade: 01/01/2018 - 31/12/2018
        /// </summary>
        [DefaultValue("012")] V12,

        /// <summary>
        /// Código: 013
        /// Versão: 1.12
        /// Validade: 01/01/2019 - 31/12/2019
        /// </summary>
        [DefaultValue("013")] V13,

        /// <summary>
        /// Código: 014
        /// Versão: 1.13
        /// Validade: 01/01/2020 - 31/12/2020
        /// </summary>
        [DefaultValue("014")] V14,

        /// <summary>
        /// Código: 015
        /// Versão: 1.14
        /// Validade: 01/01/2021 - 31/12/2021
        /// </summary>
        [DefaultValue("015")] V15,

        /// <summary>
        /// Código: 016
        /// Versão: 1.15
        /// Validade: 01/01/2022 - 31/12/2022
        /// </summary>
        [DefaultValue("016")] V16,

        /// <summary>
        /// Código: 017
        /// Versão: 1.16
        /// Validade: 01/01/2023 - 31/12/2023
        /// </summary>
        [DefaultValue("017")] V17,

        /// <summary>
        /// Código: 018
        /// Versão: 1.17
        /// Validade: 01/01/2024 - 31/12/2024
        /// </summary>
        [DefaultValue("018")] V18,

        /// <summary>
        /// Código: 019
        /// Versão: 1.18
        /// Validade: 01/01/2025 - 31/12/2025
        /// </summary>
        [DefaultValue("019")] V19
    }

    public enum SimOuNao
    {
        /// <summary>
        ///     Não
        /// </summary>
        [DefaultValue("N")] N,

        /// <summary>
        ///     Sim
        /// </summary>
        [DefaultValue("S")] S
    }

    public enum IndMovimento
    {
        /// <summary>
        ///     Bloco com dados informados
        /// </summary>
        [DefaultValue("0")] BlocoComDados,

        /// <summary>
        ///     Bloco sem dados informados
        /// </summary>
        [DefaultValue("1")] BlocoSemDados
    }

    public enum IndTpLeiaute
    {
        /// <summary>
        ///     Leiaute simplificado
        /// </summary>
        [DefaultValue("0")] Simplificado,

        /// <summary>
        ///     Leiaute completo
        /// </summary>
        [DefaultValue("1")] Completo,

        /// <summary>
        ///     Leiaute restrito aos saldos de estoque
        /// </summary>
        [DefaultValue("2")] RestritoSaldoEstoque
    }

    /// <summary>
    ///     Código da finalidade do arquivo
    /// </summary>
    /// <remarks>
    ///     0 - Original
    ///     <para />
    ///     1 - Substituto
    /// </remarks>
    public enum IndCodFinalidadeArquivo
    {
        /// <summary>
        ///     Remessa do arquivo original
        /// </summary>
        [DefaultValue("0")] RemessaArquivoOriginal,

        /// <summary>
        ///     Remessa do arquivo substituto
        /// </summary>
        [DefaultValue("1")] RemessaArquivoSubstituto
    }

    /// <summary>
    ///     Classificacao do Estabelecimento Industrial
    /// </summary>
    public enum ClassEstabIndustrial
    {
        /// <summary>
        ///     Industrial - Transformação
        /// </summary>
        [DefaultValue("00")] IndustrialTransformacao,

        /// <summary>
        ///     Industrial - Beneficiamento
        /// </summary>
        [DefaultValue("01")] IndustrialBeneficiario,

        /// <summary>
        ///     Industrial - Montagem
        /// </summary>
        [DefaultValue("02")] IndustrialMontagem,

        /// <summary>
        ///     Industrial - Acondicionamento ou Reacondicionamento
        /// </summary>
        [DefaultValue("03")] IndustrialAcondicionamentoReacondicionamento,

        /// <summary>
        ///     Industrial - Renovação ou Recondicionamento
        /// </summary>
        [DefaultValue("04")] IndustrialRenovacaoRecndicionamento,

        /// <summary>
        ///     Equiparado a industrial - Por opção
        /// </summary>
        [DefaultValue("05")] EquiparadoIndustrialOpcao,

        /// <summary>
        ///     Equiparado a industrial - Importação Direta
        /// </summary>
        [DefaultValue("06")] EquiparadoIndustrialImportacaoDireta,

        /// <summary>
        ///     Equiparado a industrial - Por lei específica
        /// </summary>
        [DefaultValue("07")] EquiparadoIndustrialLeiEspecifica,

        /// <summary>
        ///     Equiparado a industrial - Não enquadrado nos códigos 05, 06 ou 07
        /// </summary>
        [DefaultValue("08")] EquiparadoIndustrialNaoEnqCodigo05_06_07,

        /// <summary>
        ///     Outros
        /// </summary>
        [DefaultValue("09")] Outros
    }

    /// <summary>
    ///     Perfil de apresentação do arquivo fiscal
    /// </summary>
    public enum IndPerfilArquivo
    {
        /// <summary>
        ///     Perfil A
        /// </summary>
        [DefaultValue("A")] A,

        /// <summary>
        ///     Perfil B
        /// </summary>
        [DefaultValue("B")] B,

        /// <summary>
        ///     Perfil C
        /// </summary>
        [DefaultValue("C")] C
    }

    public enum IndCodMod
    {
        /// <summary>
        /// Nota Fiscal
        /// </summary>
        [DefaultValue("01")] Mod1Ou1A,

        /// <summary>
        /// Nota Fiscal Avulsa
        /// </summary>
        [DefaultValue("1B")] Mod1B,

        /// <summary>
        /// Nota Fiscal de Venda a Consumidor
        /// </summary>
        [DefaultValue("02")] Mod02,

        /// <summary>
        /// Cupom Fiscal
        /// </summary>
        [DefaultValue("2D")] Mod2D,

        /// <summary>
        /// Cupom Fiscal Bilhete de Passagem
        /// </summary>
        [DefaultValue("2E")] Mod2E,

        /// <summary>
        /// Nota Fiscal de Produtor
        /// </summary>
        [DefaultValue("04")] Mod04,

        /// <summary>
        /// Nota Fiscal/Conta de Energia Elétrica
        /// </summary>
        [DefaultValue("06")] Mod06,

        /// <summary>
        /// Nota Fiscal de Serviço de Transporte
        /// </summary>
        [DefaultValue("07")] Mod07,

        /// <summary>
        /// Conhecimento de Transporte Rodoviário de Cargas
        /// </summary>
        [DefaultValue("08")] Mod08,

        /// <summary>
        /// Conhecimento de Transporte de Cargas Avulso
        /// </summary>
        [DefaultValue("8B")] Mod8B,

        /// <summary>
        /// Conhecimento de Transporte Aquaviário de Cargas
        /// </summary>
        [DefaultValue("09")] Mod09,

        /// <summary>
        /// Conhecimento Aéreo
        /// </summary>
        [DefaultValue("10")] Mod10,

        /// <summary>
        /// Conhecimento de Transporte Ferroviário de Cargas
        /// </summary>
        [DefaultValue("11")] Mod11,

        /// <summary>
        /// Bilhete de Passagem Rodoviário
        /// </summary>
        [DefaultValue("13")] Mod13,

        /// <summary>
        /// Bilhete de Passagem Aquaviário
        /// </summary>
        [DefaultValue("14")] Mod14,

        /// <summary>
        /// Bilhete de Passagem e Nota de Bagagem
        /// </summary>
        [DefaultValue("15")] Mod15,

        /// <summary>
        /// Bilhete de Passagem Ferroviário
        /// </summary>
        [DefaultValue("16")] Mod16,

        /// <summary>
        /// Resumo de Movimento Diário
        /// </summary>
        [DefaultValue("18")] Mod18,

        /// <summary>
        /// Nota Fiscal de Serviço de Comunicação
        /// </summary>
        [DefaultValue("21")] Mod21,

        /// <summary>
        /// Nota Fiscal de Serviço de Telecomunicação
        /// </summary>
        [DefaultValue("22")] Mod22,

        /// <summary>
        /// Conhecimento de Transporte Multimodal de Cargas
        /// </summary>
        [DefaultValue("26")] Mod26,

        /// <summary>
        /// Nota Fiscal de Transporte Ferroviário de Cargas
        /// </summary>
        [DefaultValue("27")] Mod27,

        /// <summary>
        /// Nota Fiscal/Conta de Fornecimento de Gás Canalizado
        /// </summary>
        [DefaultValue("28")] Mod28,

        /// <summary>
        /// Nota Fiscal/Conta de Fornecimento de Água Canalizada
        /// </summary>
        [DefaultValue("29")] Mod29,

        /// <summary>
        /// Nota Fiscal Eletrônica - NF-e
        /// </summary>
        [DefaultValue("55")] Mod55,

        /// <summary>
        /// Conhecimento de Transporte Eletrônico - CT-e
        /// </summary>
        [DefaultValue("57")] Mod57,

        /// <summary>
        /// Cupom Fiscal Eletrônico - CF-e (SAT)
        /// </summary>
        [DefaultValue("59")] Mod59,

        /// <summary>
        /// Cupom Fiscal Eletrônico - CF-e (ECF)
        /// </summary>
        [DefaultValue("60")] Mod60,

        /// <summary>
        /// Nota Fiscal Eletrônica p/ Consumidor Final - NFC-e
        /// </summary>
        [DefaultValue("65")] Mod65,

        /// <summary>
        /// Nota Fiscal de Energia Elétrica Eletrônica - NF3e
        /// </summary>
        [DefaultValue("66")] Mod66,

        /// <summary>
        /// Conhecimento de Transporte Eletrônico - CT-e (OS)
        /// </summary>
        [DefaultValue("67")] Mod67
    }

    /// <summary>
    ///     Indicador do tipo de operação
    /// <remarks>
    ///     <para />
    ///     0 - Entrada
    ///     <para />
    ///     1 - Saída
    /// </remarks>
    /// </summary>
    public enum IndTipoOperacaoProduto
    {
        /// <summary>
        ///     Entrada
        /// </summary>
        [DefaultValue("0")] Entrada,

        /// <summary>
        ///     Saída
        /// </summary>
        [DefaultValue("1")] Saida
    }

    /// <summary>
    ///     Indicador do tipo de operação
    /// </summary>


    /// <summary>
    ///     Indicador do emitente do documento fiscal/título
    /// <remarks>
    ///     <para />
    ///     0 - Emissão Própria
    ///     <para />
    ///     1 - Terceiros
    /// </remarks>
    /// </summary>
    public enum IndEmitente
    {
        /// <summary>
        ///     Emissão própria
        /// </summary>
        [DefaultValue("0")] EmissaoPropria,

        /// <summary>
        ///     Terceiros
        /// </summary>
        [DefaultValue("1")] Terceiros
    }

    /// <summary>
    ///     Código da situação do documento fiscal
    /// </summary>
    public enum IndCodSitDoc
    {
        [DefaultValue("00")] DocumentoRegular,
        [DefaultValue("01")] DocumentoRegularExtemporaneo,
        [DefaultValue("02")] DocumentoCancelado,
        [DefaultValue("03")] DocumentoCanceladoExtemporaneo,
        [DefaultValue("04")] DFeDenegado,
        [DefaultValue("05")] DFeInutilizado,
        [DefaultValue("06")] DocumentoFiscalComplementar,
        [DefaultValue("07")] DocumentoFiscalComplementarExtemporaneo,
        [DefaultValue("08")] DocumentoFiscalRegimeEspecial
    }

    /// <summary>
    ///     Indicador do tipo de pagamento
    /// </summary>
    public enum IndTipoPagamento
    {
        /// <summary>
        ///     Em branco
        /// </summary>
        [DefaultValue("")] None,

        /// <summary>
        ///     À vista
        /// </summary>
        [DefaultValue("0")] AVista,

        /// <summary>
        ///     A prazo
        /// </summary>
        [DefaultValue("1")] APrazo,

        /// <summary>
        ///     Outros
        /// </summary>
        [DefaultValue("2")] Outros,

        /// <summary>
        ///     Sem pagamento
        /// </summary>
        [DefaultValue("9")] SemPagamento
    }

    /// <summary>
    ///     Indicador do tipo de frete
    /// </summary>
    [DefaultValue(None)]
    public enum IndTipoFrete
    {
        [DefaultValue("")] None = -1,

        [DefaultValue("0")] ContaRemetenteCif = 0,
        [DefaultValue("1")] ContaDestinatarioFob = 1,
        [DefaultValue("2")] ContaTerceiros = 2,
        [DefaultValue("3")] ContaProprioRemetente = 3,
        [DefaultValue("4")] ContaProprioDestinatario = 4,

        [DefaultValue("9")] SemCobrancaFrete = 9,

        [DefaultValue("0")] ContaTerceirosPre2012 = 120,
        [DefaultValue("1")] ContaEmitentePre2012 = 121,
        [DefaultValue("2")] ContaDestinatarioPre2012 = 122,

        [DefaultValue("0")] ContaEmitentePre2018 = 180,
        [DefaultValue("1")] ContaDestinatarioRemetentePre2018 = 181,
        [DefaultValue("2")] ContaTerceirosPre2018 = 182
    }

    /// <summary>
    ///     Indicador do tipo de operação
    /// </summary>
    public enum IndTipoOperacaoStUfDiversa
    {
        /// <summary>
        ///     0 - Combustíveis e lubrificantes;
        /// </summary>
        [DefaultValue("0")] CombustiveisLubrificantes,

        /// <summary>
        ///     1 - Leasing de veículos ou faturamento direto.
        /// </summary>
        [DefaultValue("1")] LeasingVeiculosFaturamentoDireto,

        /// <summary>
        ///     2 - Recusa de recebimento (de acordo com as condições descritas nas instruções do Registro)
        /// </summary>
        [DefaultValue("2")] RecusaDeRecebimento
    }

    /// <summary>
    ///     Indicador da origem do processo
    /// </summary>
    public enum IndOrigemProcesso
    {
        /// <summary>
        ///     0 - SEFAZ
        /// </summary>
        [DefaultValue("0")] Sefaz,

        /// <summary>
        ///     1 - Justiça Federal
        /// </summary>
        [DefaultValue("1")] JusticaFederal,

        /// <summary>
        ///     2 - Justiça Estadual
        /// </summary>
        [DefaultValue("2")] JusticaEstadual,

        /// <summary>
        ///     3 - SECEX/SRF
        /// </summary>
        [DefaultValue("3")] Secexsrf,

        /// <summary>
        ///     9 - Outros
        /// </summary>
        [DefaultValue("9")] Outros
    }

    /// <summary>
    ///     Código do modelo do documento de arrecadação
    /// </summary>
    public enum IndCodModDocArrecadacao
    {
        /// <summary>
        ///     Documento estadual de arrecadação
        /// </summary>
        [DefaultValue("0")] DocumentoEstadual,

        /// <summary>
        ///     GNRE
        /// </summary>
        [DefaultValue("1")] Gnre
    }

    /// <summary>
    ///     Indicador do tipo de transporte
    /// </summary>
    public enum IndTipoTransporte
    {
        /// <summary>
        ///     Rodoviário
        /// </summary>
        [DefaultValue("0")] Rodoviario,

        /// <summary>
        ///     Ferroviário
        /// </summary>
        [DefaultValue("1")] Ferroviario,

        /// <summary>
        ///     Rodo-Ferroviário
        /// </summary>
        [DefaultValue("2")] RodoFerroviario,

        /// <summary>
        ///     Aquaviário
        /// </summary>
        [DefaultValue("3")] Aquaviario,

        /// <summary>
        ///     Dutoviário
        /// </summary>
        [DefaultValue("4")] Dutoviario,

        /// <summary>
        ///     Aéreo
        /// </summary>
        [DefaultValue("5")] Aereo,

        /// <summary>
        ///     Outros
        /// </summary>
        [DefaultValue("9")] Outros
    }

    /// <summary>
    ///     Documento de importação
    /// </summary>
    public enum IndDocumentoImportacao
    {
        /// <summary>
        ///     Declaração de Importação
        /// </summary>
        [DefaultValue("0")] DeclaracaoImportacao,

        /// <summary>
        ///     Declaração Simplificada de Importação
        /// </summary>
        [DefaultValue("1")] DeclaracaoSimplificadaImportacao
    }

    /// <summary>
    ///     Indicador do tipo de título de crédito
    /// </summary>
    public enum IndTipoTituloCred
    {
        /// <summary>
        ///     Duplicata
        /// </summary>
        [DefaultValue("00")] Duplicata,

        /// <summary>
        ///     Cheque
        /// </summary>
        [DefaultValue("01")] Cheque,

        /// <summary>
        ///     Promissória
        /// </summary>
        [DefaultValue("02")] Promissoria,

        /// <summary>
        ///     Recibo
        /// </summary>
        [DefaultValue("03")] Recibo,

        /// <summary>
        ///     Outros
        /// </summary>
        [DefaultValue("99")] Outros
    }

    /// <summary>
    ///     Indicador de período de apuração do IPI
    /// </summary>
    public enum IndPeriodoApuracaoIpi
    {
        [DefaultValue("")] None = 0,
        /// <summary>
        ///     Mensal
        /// </summary>
        [DefaultValue("0")] Mensal,

        /// <summary>
        ///     Decendial
        /// </summary>
        [DefaultValue("1")] Decendial
    }

    /// <summary>
    ///     Movimentação física do ITEM/PRODUTO
    /// </summary>
    public enum IndMovFisicaItem
    {
        /// <summary>
        ///     Sim
        /// </summary>
        [DefaultValue("0")] Sim,

        /// <summary>
        ///     Não
        /// </summary>
        [DefaultValue("1")] Nao
    }

    /// <summary>
    ///     Indicador de tipo de referência da base de cálculo do ICMS (ST) do produto farmacêutico
    /// </summary>
    public enum IndBaseProdFarmaceutico
    {
        /// <summary>
        ///     Base de cálculo referente ao preço tabelado ou preço máximo sugerido
        /// </summary>
        [DefaultValue("0")] BcPrecoTabeladoOuPrecoMaximo,

        /// <summary>
        ///     Base de cálculo - Margem de valor agregado
        /// </summary>
        [DefaultValue("1")] BcMargemValorAgregado,

        /// <summary>
        ///     Base de cálculo referente à Lista Negativa
        /// </summary>
        [DefaultValue("2")] BcListaNegativa,

        /// <summary>
        ///     Base de cálculo referente à Lista Positiva
        /// </summary>
        [DefaultValue("3")] BcListaPositiva,

        /// <summary>
        ///     Base de cálculo referente à Lista Neutra
        /// </summary>
        [DefaultValue("4")] BcListaNeutra
    }

    /// <summary>
    ///     Tipo de produto farmacêutico
    /// </summary>
    public enum IndTipoProdFarmaceutico
    {
        /// <summary>
        ///     Similar
        /// </summary>
        [DefaultValue("0")] Similar,

        /// <summary>
        ///     Genérico
        /// </summary>
        [DefaultValue("1")] Generico,

        /// <summary>
        ///     Ético ou de marca
        /// </summary>
        [DefaultValue("2")] EticoOuMarca
    }

    /// <summary>
    ///     Indicador do tipo de arma de fogo
    /// </summary>
    public enum IndTipoArmaFogo
    {
        /// <summary>
        ///     Uso permitido
        /// </summary>
        [DefaultValue("0")] UsoPermitido,

        /// <summary>
        ///     Uso restrito
        /// </summary>
        [DefaultValue("1")] UsoRestrito
    }

    /// <summary>
    ///     Indicador do tipo de operação com veículo
    /// </summary>
    public enum IndTipoOperacaoVeiculo
    {
        /// <summary>
        ///     Venda para concessionária
        /// </summary>
        [DefaultValue("0")] VendaParaConcessionaria,

        /// <summary>
        ///     Faturamento direto
        /// </summary>
        [DefaultValue("1")] FaturamentoDireto,

        /// <summary>
        ///     Venda direta
        /// </summary>
        [DefaultValue("2")] VendaDireta,

        /// <summary>
        ///     Venda da concessionária
        /// </summary>
        [DefaultValue("3")] VendaDaConcessionaria,

        /// <summary>
        ///     Outros
        /// </summary>
        [DefaultValue("9")] Outros
    }

    /// <summary>
    ///     Código de classe de consumo de energia elétrica
    /// </summary>
    public enum IndClasseConsumoEnergiaOuGas
    {
        [DefaultValue("")] None,
        /// <summary>
        ///     Comercial
        /// </summary>
        [DefaultValue("01")] Comercial,

        /// <summary>
        ///     Consumo Próprio
        /// </summary>
        [DefaultValue("02")] ConsumoProprio,

        /// <summary>
        ///     Iluminação Pública
        /// </summary>
        [DefaultValue("03")] IluminacaoPublica,

        /// <summary>
        ///     Industrial
        /// </summary>
        [DefaultValue("04")] Industrial,

        /// <summary>
        ///     Poder Público
        /// </summary>
        [DefaultValue("05")] PoderPublico,

        /// <summary>
        ///     Residencial
        /// </summary>
        [DefaultValue("06")] Residencial,

        /// <summary>
        ///     Rural
        /// </summary>
        [DefaultValue("07")] Rural,

        /// <summary>
        ///     Serviço Público
        /// </summary>
        [DefaultValue("08")] ServicoPublico
    }

    /// <summary>
    ///     Código de classe de consumo de água canalizada
    /// </summary>
    public enum IndClasseConsumoAgua
    {
        [DefaultValue("00")] ConsResidencialAte50,
        [DefaultValue("01")] ConsResidencialDe50A100,
        [DefaultValue("02")] ConsResidencialDe100A200,
        [DefaultValue("03")] ConsResidencialDe200A300,
        [DefaultValue("04")] ConsResidencialDe300A400,
        [DefaultValue("05")] ConsResidencialDe400A500,
        [DefaultValue("06")] ConsResidencialDe500A1000,
        [DefaultValue("07")] ConsResidencialAcima1000,
        [DefaultValue("20")] ConsComercialIndustrialAte50,
        [DefaultValue("21")] ConsComercialIndustrialDe50A100,
        [DefaultValue("22")] ConsComercialIndustrialDe100A200,
        [DefaultValue("23")] ConsComercialIndustrialDe200A300,
        [DefaultValue("24")] ConsComercialIndustrialDe300A400,
        [DefaultValue("25")] ConsComercialIndustrialDe400A500,
        [DefaultValue("26")] ConsComercialIndustrialDe500A1000,
        [DefaultValue("27")] ConsComercialIndustrialAcima1000,
        [DefaultValue("80")] ConsOrgaoPublico,
        [DefaultValue("90")] OutrosTiposConsumoAte50,
        [DefaultValue("91")] OutrosTiposConsumoDe50A100,
        [DefaultValue("92")] OutrosTiposConsumoDe100A200,
        [DefaultValue("93")] OutrosTiposConsumoDe200A300,
        [DefaultValue("94")] OutrosTiposConsumoDe300A400,
        [DefaultValue("95")] OutrosTiposConsumoDe400A500,
        [DefaultValue("96")] OutrosTiposConsumoDe500A1000,
        [DefaultValue("97")] OutrosTiposConsumoAcima1000,
        [DefaultValue("99")] RegPorDocumentoFiscalEmitido
    }

    /// <summary>
    ///     Código de classe de consumo de gás canalizado
    /// </summary>
    public enum IndClasseConsumoGas
    {
        [DefaultValue("00")] ConsResidencialAte50,
        [DefaultValue("01")] ConsResidencialDe50A100,
        [DefaultValue("02")] ConsResidencialDe100A200,
        [DefaultValue("03")] ConsResidencialDe200A300,
        [DefaultValue("04")] ConsResidencialDe300A400,
        [DefaultValue("05")] ConsResidencialDe400A500,
        [DefaultValue("06")] ConsResidencialDe500A1000,
        [DefaultValue("07")] ConsResidencialAcima1000,
        [DefaultValue("20")] ConsComercialIndustrialAte50,
        [DefaultValue("21")] ConsComercialIndustrialDe50A100,
        [DefaultValue("22")] ConsComercialIndustrialDe100A200,
        [DefaultValue("23")] ConsComercialIndustrialDe200A300,
        [DefaultValue("24")] ConsComercialIndustrialDe300A400,
        [DefaultValue("25")] ConsComercialIndustrialDe400A500,
        [DefaultValue("26")] ConsComercialIndustrialDe500A1000,
        [DefaultValue("27")] ConsComercialIndustrialAcima1000,
        [DefaultValue("80")] ConsOrgaoPublico,
        [DefaultValue("90")] OutrosTiposConsumoAte50,
        [DefaultValue("91")] OutrosTiposConsumoDe50A100,
        [DefaultValue("92")] OutrosTiposConsumoDe100A200,
        [DefaultValue("93")] OutrosTiposConsumoDe200A300,
        [DefaultValue("94")] OutrosTiposConsumoDe300A400,
        [DefaultValue("95")] OutrosTiposConsumoDe400A500,
        [DefaultValue("96")] OutrosTiposConsumoDe500A1000,
        [DefaultValue("97")] OutrosTiposConsumoAcima1000,
        [DefaultValue("99")] RegPorDocumentoFiscalEmitido
    }

    /// <summary>
    ///     Código do tipo de ligação
    /// </summary>
    public enum IndCodTipoLigacao
    {
        [DefaultValue("")] None,
        /// <summary>
        ///     Monofásico
        /// </summary>
        [DefaultValue("1")] Monofasico,

        /// <summary>
        ///     Bifásico
        /// </summary>
        [DefaultValue("2")] Bifasico,

        /// <summary>
        ///     Trifásico
        /// </summary>
        [DefaultValue("3")] Trifasico
    }

    public enum IndCodGrupoTensao
    {
        [DefaultValue("")] None,
        [DefaultValue("01")] A1,
        [DefaultValue("02")] A2,
        [DefaultValue("03")] A3,
        [DefaultValue("04")] A3a,
        [DefaultValue("05")] A4,
        [DefaultValue("06")] AS,
        [DefaultValue("07")] B1,
        [DefaultValue("08")] B1BaixaRenda,
        [DefaultValue("09")] B2Rural,
        [DefaultValue("10")] B2Cooperativa,
        [DefaultValue("11")] B2ServicoPublico,
        [DefaultValue("12")] B3DemaisClasses,
        [DefaultValue("13")] B4a,
        [DefaultValue("14")] B4b
    }

    public enum IndCodFinDoce
    {
        [DefaultValue("")] None,
        /// <summary>
        ///     Normal
        /// </summary>
        [DefaultValue("1")] Normal,

        /// <summary>
        ///     Substituição
        /// </summary>
        [DefaultValue("2")] Substituicao,

        /// <summary>
        ///     Normal com ajuste
        /// </summary>
        [DefaultValue("3")] NormalComAjuste
    }

    public enum IndCodDestAcessante
    {
        [DefaultValue("")] None,
        /// <summary>
        ///     Contribuinte do ICMS
        /// </summary>
        [DefaultValue("1")] ContribuinteIcms = 1,

        /// <summary>
        ///     Contribuinte Isento de Inscrição no Cadastro de Contribuintes do ICMS
        /// </summary>
        [DefaultValue("2")] ContribuinteIsento = 2,

        /// <summary>
        ///     Não Contribuinte
        /// </summary>
        [DefaultValue("9")] NaoContribuinte = 9
    }

    public enum IndTipoAjuste
    {
        /// <summary>
        ///     Ajuste de redução
        /// </summary>
        [DefaultValue("0")] Reducao,

        /// <summary>
        ///     Ajuste de acréscimo
        /// </summary>
        [DefaultValue("1")] Acrescimo
    }
}
