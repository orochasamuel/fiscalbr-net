using System;
using System.ComponentModel;

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

    /// <summary>
    ///     Código da finalidae do arquivo
    /// </summary>
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

    /// <summary>
    ///     Indicador do tipo de atividade
    /// </summary>
    public enum IndTipoAtividade
    {
        /// <summary>
        ///     Industrial ou equiparado a industrial
        /// </summary>
        [DefaultValue("0")] IndustrialOuEquiparado,

        /// <summary>
        ///     Outros
        /// </summary>
        [DefaultValue("1")] Outros
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
        /// Conhecimento de Transporte Eletrônico - CT-e (OS)
        /// </summary>
        [DefaultValue("67")] Mod67
    }

    /// <summary>
    ///     Tipo do item - Atividades industriais, comerciais e serviços
    /// </summary>
    public enum IndTipoItem
    {
        /// <summary>
        ///     Mercadoria para revenda: produto adquirido para comercialização
        /// </summary>
        [DefaultValue("00")] MercadoriaRevenda,

        /// <summary>
        ///     Matéria-prima: a mercadoria que componha, física e/ou quimicamente, um produto em processo  ou  produto acabado e
        ///     que não seja oriunda do processo produtivo.  A mercadoria recebida para industrialização é classificada como Tipo
        ///     01, pois  não decorre do processo produtivo, mesmo que no processo de  produção se produza mercadoria similar
        ///     classificada como Tipo 03;
        /// </summary>
        [DefaultValue("01")] MateriaPrima,

        /// <summary>
        ///     Embalagem
        /// </summary>
        [DefaultValue("02")] Embalagem,

        /// <summary>
        ///     Produto em processo: o  produto  que  possua  as  seguintes  características,  cumulativamente:  oriundo  do
        ///     processo  produtivo; e, preponderantemente, consumido  no  processo  produtivo.  Dentre  os  produtos  em  processo
        ///     está  incluído  o  produto  resultante  caracterizado  como   retorno  de  produção.  Um  produto  em  processo  é
        ///     caracterizado  como  retorno  de  produção  quando  é  resultante  de  uma  fase  de  produção  e  é  destinado,
        ///     rotineira  e exclusivamente, a uma fase de produção anterior à qual o mesmo foi gerado. No “retorno de produção”, o
        ///     produto retorna (é consumido) a uma fase de produção anterior à qual ele foi gerado. Isso é uma excepcionalidade,
        ///     pois o normal  é  o  produto  em  processo  ser  consumido  em  uma  fase  de  produção  posterior  à  qual  ele
        ///     foi  gerado, e acontece, portanto, em poucos processos produtivos.
        /// </summary>
        [DefaultValue("03")] ProdutoProcesso,

        /// <summary>
        ///     Produto acabado: o  produto  que  possua  as  seguintes  características,  cumulativamente:  oriundo  do  processo
        ///     produtivo; produto  final  resultante  do  objeto  da    atividade  econômica  do    contribuinte; e  pronto  para
        ///     ser comercializado;
        /// </summary>
        [DefaultValue("04")] ProdutoAcabado,

        /// <summary>
        ///     Subproduto: o  produto  que  possua  as  seguintes    características,  cumulativamente:  oriundo  do  processo
        ///     produtivo  e  não  é  objeto  da  produção  principal  do  estabelecimento; tem    aproveitamento  econômico; não
        ///     se enquadre no conceito de produto  em  processo (Tipo 03) ou de produto acabado (Tipo 04);
        /// </summary>
        [DefaultValue("05")] Subproduto,

        /// <summary>
        ///     Produto intermediário: aquele que, embora não se integrando ao novo produto, for consumido no processo de
        ///     industrialização.
        /// </summary>
        [DefaultValue("06")] ProdutoIntermediario,

        /// <summary>
        ///     Material de uso e consumo
        /// </summary>
        [DefaultValue("07")] MaterialUsoConsumo,

        /// <summary>
        ///     Ativo imobilizado
        /// </summary>
        [DefaultValue("08")] AtivoImobilizado,

        /// <summary>
        ///     Serviços
        /// </summary>
        [DefaultValue("09")] Servicos,

        /// <summary>
        ///     Outros insumos
        /// </summary>
        [DefaultValue("10")] OutrosInsumos,

        /// <summary>
        ///     Outras
        /// </summary>
        [DefaultValue("99")] Outras
    }

    /// <summary>
    ///     Identificação do tipo de mercadoria
    /// </summary>
    public enum IndTipoMercadoria
    {
        /// <summary>
        ///     Bem: uma mercadoria será considerada "bem" quando possua todas as condições necessárias para ser utilizado nas
        ///     atividades do estabelecimento.
        /// </summary>
        [DefaultValue("1")] Bem,

        /// <summary>
        ///     Componente: uma mercadoria será considerada "componente" quando fizer parte de um bem móvel que estiver sendo
        ///     construído no estabelecimento do contribuinte, onde somente o bem móvel resultante é que possuirá as condições
        ///     necessárias para ser utilizado nas atividades do estabelecimento.
        /// </summary>
        [DefaultValue("2")] Componente
    }

    /// <summary>
    ///     Código da Natureza da conta/grupo de contas
    /// </summary>
    public enum IndNaturezaConta
    {
        /// <summary>
        ///     Contas de ativo
        /// </summary>
        [DefaultValue("01")] ContasAtivo,

        /// <summary>
        ///     Contas de passivo
        /// </summary>
        [DefaultValue("02")] ContasPassivo,

        /// <summary>
        ///     Patrimônio líquido
        /// </summary>
        [DefaultValue("03")] PatrimonioLiquido,

        /// <summary>
        ///     Contas de resultado
        /// </summary>
        [DefaultValue("04")] ContasResultado,

        /// <summary>
        ///     Contas de compensação
        /// </summary>
        [DefaultValue("05")] ContasCompensacao,

        /// <summary>
        ///     Outras
        /// </summary>
        [DefaultValue("09")] Outras
    }

    /// <summary>
    ///     Indicador do tipo de conta
    /// </summary>
    public enum IndTipoConta
    {
        /// <summary>
        ///     Sintética (grupo de contas)
        /// </summary>
        [DefaultValue("S")] S,

        /// <summary>
        ///     Analítica (conta)
        /// </summary>
        [DefaultValue("A")] A
    }

    /// <summary>
    ///     Indicador do tipo de operação
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
    public enum IndTipoOperacaoServico
    {
        /// <summary>
        ///     Aquisição
        /// </summary>
        [DefaultValue("0")] Aquisicao,

        /// <summary>
        ///     Prestação
        /// </summary>
        [DefaultValue("1")] Prestacao
    }

    /// <summary>
    ///     Indicador do emitente do documento fiscal/título
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
    public enum IndTipoFrete
    {
        [DefaultValue("0")] ContaEmitente,
        [DefaultValue("1")] ContaDestinatarioRemetente,
        [DefaultValue("2")] ContaTerceiros,
        [DefaultValue("9")] SemCobrancaFrete
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
        [DefaultValue("1")] LeasingVeiculosFaturamentoDireto
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
    public enum IndClasseConsumoEnergia
    {
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
        /// <summary>
        ///     Monofásico
        /// </summary>
        [DefaultValue("1")]
        Monofasico,

        /// <summary>
        ///     Bifásico
        /// </summary>
        [DefaultValue("2")]
        Bifasico,

        /// <summary>
        ///     Trifásico
        /// </summary>
        [DefaultValue("3")]
        Trifasico
    }

    public enum IndCodGrupoTensao
    {
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

    public enum IndTipoAjuste
    {
        /// <summary>
        ///     Ajuste de redução
        /// </summary>
        [DefaultValue(0)]
        Reducao,

        /// <summary>
        ///     Ajuste de acréscimo
        /// </summary>
        [DefaultValue(1)]
        Acrescimo
    }
}