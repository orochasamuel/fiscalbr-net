using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.EFDContribuicoes
{
    /// <summary>
    /// BLOCO 0: ABERTURA, IDENTIFICAÇÃO E REFERÊNCIAS
    /// </summary>
    public class Bloco0
    {
        /// <summary>
        /// REGISTRO 0000: ABERTURA DO ARQUIVO DIGITAL E IDENTIFICAÇÃO DA PESSOA JURÍDICA
        /// </summary>
        public class Registro0000 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0000" />.
            /// </summary>
            public Registro0000()
            {
                Reg = "0000";
            }

            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0000" />.
            /// </summary>
            /// <param name="cdVersao">Código da versão do leiaute</param>
            /// <param name="tpEscrituracao">Tipo de escrituração</param>
            /// <param name="dtInicial">Data inicial das informações contidas no arquivo</param>
            /// <param name="dtFinal">Data final das informações contidas no arquivo</param>
            /// <param name="rzSocial">Nome empresarial da pessoa jurídica</param>
            /// <param name="nrCnpj">Número de inscrição do estabelecimento matriz da pessoa jurídica no CNPJ</param>
            /// <param name="uf">Sigla da Unidade da Federação da pessoa jurídica</param>
            /// <param name="cdMunicipio">Código do município do domicílio fiscal da pessoa jurídica</param>
            /// <param name="idAtividade">Indicador de tipo de atividade preponderante</param>
            public Registro0000(
                int cdVersao,
                int tpEscrituracao,
                DateTime dtInicial,
                DateTime dtFinal,
                string rzSocial,
                string nrCnpj,
                string uf,
                string cdMunicipio,
                int idAtividade
                )
            {
                Reg = "0000";
                CodVer = cdVersao;
                TipoEscrit = tpEscrituracao;
                DtIni = dtInicial;
                DtFin = dtFinal;
                Nome = rzSocial;
                Cnpj = nrCnpj;
                Uf = uf;
                CodMun = cdMunicipio;
                IndAtiv = idAtividade;
            }

            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0000" />.
            /// </summary>
            /// <param name="cdVersao">Código da versão do leiaute</param>
            /// <param name="tpEscrituracao">Tipo de escrituração</param>
            /// <param name="idSituacaoEspecial">Indicador de situação especial</param>
            /// <param name="nrReciboAnterior">Número do Recibo da Escrituração anterior a ser retificada</param>
            /// <param name="dtInicial">Data inicial das informações contidas no arquivo</param>
            /// <param name="dtFinal">Data final das informações contidas no arquivo</param>
            /// <param name="rzSocial">Nome empresarial da pessoa jurídica</param>
            /// <param name="nrCnpj">Número de inscrição do estabelecimento matriz da pessoa jurídica no CNPJ</param>
            /// <param name="uf">Sigla da Unidade da Federação da pessoa jurídica</param>
            /// <param name="cdMunicipio">Código do município do domicílio fiscal da pessoa jurídica</param>
            /// <param name="suframa">Inscrição da pessoa jurídica na Suframa</param>
            /// <param name="idNaturezaPj">Indicador da natureza da pessoa jurídica</param>
            /// <param name="idAtividade">Indicador de tipo de atividade preponderante</param>
            public Registro0000(
                int cdVersao,
                int tpEscrituracao,
                int idSituacaoEspecial,
                string nrReciboAnterior,
                DateTime dtInicial,
                DateTime dtFinal,
                string rzSocial,
                string nrCnpj,
                string uf,
                string cdMunicipio,
                string suframa,
                int idNaturezaPj,
                int idAtividade
                )
            {
                Reg = "0000";
                CodVer = cdVersao;
                TipoEscrit = tpEscrituracao;
                IndSitEsp = idSituacaoEspecial;
                NumRecAnterior = nrReciboAnterior;
                DtIni = dtInicial;
                DtFin = dtFinal;
                Nome = rzSocial;
                Cnpj = nrCnpj;
                Uf = uf;
                CodMun = cdMunicipio;
                Suframa = suframa;
                IndNatPj = idNaturezaPj;
                IndAtiv = idAtividade;
            }

            /// <summary>
            /// Código da versão do leiaute
            /// </summary>
            [SpedCampos(2, "COD_VER", "N", 3, 0, true)]
            public int CodVer { get; set; }

            /// <summary>
            /// Tipo de escrituração:
            /// <remarks>
            /// 0 - Original; <para/>
            /// 1 - Retificadora.2
            /// </remarks>
            /// </summary>
            [SpedCampos(3, "TIPO_ESCRIT", "N", 1, 0, true)]
            public int TipoEscrit { get; set; }

            /// <summary>
            /// Indicador de situação especial:
            /// <remarks>
            /// 0 - Abertura; <para/>
            /// 1 - Cisão; <para/>
            /// 2 - Fusão; <para/>
            /// 3 - Incorporação; <para/>
            /// 4 - Encerramento.
            /// </remarks>
            /// </summary>
            [SpedCampos(4, "IND_SIT_ESP", "N", 1, 0, false)]
            public int? IndSitEsp { get; set; }

            /// <summary>
            /// Número do Recibo da Escrituração anterior a ser retificada, utilizado quando TIPO_ESCRIT for igual a 1
            /// </summary>
            [SpedCampos(5, "NUM_REC_ANTERIOR", "C", 41, 0, false)]
            public string NumRecAnterior { get; set; }

            /// <summary>
            /// Data inicial das informações contidas no arquivo
            /// </summary>
            [SpedCampos(6, "DT_INI", "N", 8, 0, true)]
            public DateTime DtIni { get; set; }

            /// <summary>
            /// Data final das informações contidas no arquivo
            /// </summary>
            [SpedCampos(7, "DT_FIN", "N", 8, 0, true)]
            public DateTime DtFin { get; set; }

            /// <summary>
            /// Nome empresarial da pessoa jurídica
            /// </summary>
            [SpedCampos(8, "NOME", "C", 100, 0, true)]
            public string Nome { get; set; }

            /// <summary>
            /// Número de inscrição do estabelecimento matriz da pessoa jurídica no CNPJ
            /// </summary>
            [SpedCampos(9, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            /// <summary>
            /// Sigla da Unidade da Federação da pessoa jurídica
            /// </summary>
            [SpedCampos(10, "UF", "C", 2, 0, true)]
            public string Uf { get; set; }

            /// <summary>
            /// Código do município do domicílio fiscal da pessoa jurídica, conforme a tabela IBGE
            /// </summary>
            [SpedCampos(11, "COD_MUN", "N", 7, 0, true)]
            public string CodMun { get; set; }

            /// <summary>
            /// Inscrição da pessoa jurídica na Suframa
            /// </summary>
            [SpedCampos(12, "SUFRAMA", "C", 9, 0, false)]
            public string Suframa { get; set; }

            /// <summary>
            /// Indicador da natureza da pessoa jurídica:
            /// <remarks>
            /// 00 - Pessoa jurídica em geral (não participante de SCP como sócia ostensiva); <para/>
            /// 01 - Sociedade cooperativa (não participante de SCP como sócia ostensiva); <para/>
            /// 02 - Entidade sujeita ao PIS/Pasep exclusivamente com base na Folha de Salários; <para/>
            /// 03 - Pessoa jurídica em geral participante de SCP como sócia ostensiva; <para/>
            /// 04 - Sociedade cooperativa participante de SCP como sócia ostensiva; <para/>
            /// 05 - Sociedade em Conta de Participação - SCP.
            /// </remarks>
            /// </summary>
            [SpedCampos(13, "IND_NAT_PJ", "N", 2, 0, false)]
            public int? IndNatPj { get; set; }

            /// <summary>
            /// Indicador de tipo de atividade preponderante:
            /// <remarks>
            /// 0 - Industrial ou equiparado a industrial; <para/>
            /// 1 - Prestador de serviços; <para/>
            /// 2 - Atividade de comércio; <para/>
            /// 3 - Pessoas jurídicas referidas nos §§ 6º, 8º e 9º do art. 3º da Lei nº 9.718, de 1998; <para/>
            /// 4 - Atividade imobiliária; <para/>
            /// 9 - Outros.
            /// </remarks>
            /// </summary>
            [SpedCampos(14, "IND_ATIV", "N", 1, 0, true)]
            public int IndAtiv { get; set; }
        }

        /// <summary>
        /// REGISTRO 0001: ABERTURA DO BLOCO 0
        /// </summary>
        public class Registro0001 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0000" />.
            /// </summary>
            public Registro0001()
            {
                Reg = "0001";
            }

            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0000" />.
            /// </summary>
            /// <param name="indicador">Indicador de movimento</param>
            public Registro0001(IndMovimento indicador)
            {
                Reg = "0001";
                IndMov = indicador;
            }

            /// <summary>
            /// Indicador de movimento:
            /// <remarks>
            /// 0 - Bloco com dados informados; <para/>
            /// 1 - Bloco sem dados informados.
            /// </remarks>
            /// </summary>
            [SpedCampos(2, "IND_MOV", "C", 1, 0, true)]
            public IndMovimento IndMov { get; set; }
        }

        public class Registro0035 : RegistroBaseSped
        {
            public Registro0035()
            {
                Reg = "0035";
            }

            [SpedCampos(2, "COD_SCP", "N", 14, 0, false)]
            public string CodScp { get; set; }

            [SpedCampos(3, "DESC_SCP", "C", int.MaxValue, 0, false)]
            public string DescScp { get; set; }

            [SpedCampos(4, "INF_COMP", "C", int.MaxValue, 0, false)]
            public string InfComp { get; set; }
        }

        public class Registro0100 : RegistroBaseSped
        {
            public Registro0100()
            {
                Reg = "0100";
            }

            [SpedCampos(2, "NOME", "C", 100, 0, true)]
            public string Nome { get; set; }

            [SpedCampos(3, "CPF", "N", 11, 0, true)]
            public string Cpf { get; set; }

            [SpedCampos(4, "CRC", "C", 15, 0, true)]
            public string Crc { get; set; }

            [SpedCampos(5, "CNPJ", "N", 14, 0, false)]
            public string Cnpj { get; set; }

            [SpedCampos(6, "CEP", "N", 8, 0, false)]
            public string Cep { get; set; }

            [SpedCampos(7, "END", "C", 60, 0, false)]
            public string End { get; set; }

            [SpedCampos(8, "NUM", "C", 0, 0, false)]
            public string Num { get; set; }

            [SpedCampos(9, "COMPL", "C", 60, 0, false)]
            public string Compl { get; set; }

            [SpedCampos(10, "BAIRRO", "C", 60, 0, false)]
            public string Bairro { get; set; }

            [SpedCampos(11, "FONE", "C", 11, 0, false)]
            public string Fone { get; set; }

            [SpedCampos(12, "FAX", "C", 11, 0, false)]
            public string Fax { get; set; }

            [SpedCampos(13, "EMAIL", "C", 0, 0, false)]
            public string Email { get; set; }

            [SpedCampos(14, "COD_MUN", "N", 7, 0, false)]
            public string CodMun { get; set; }
        }

        public class Registro0110 : RegistroBaseSped
        {
            public Registro0110()
            {
                Reg = "0110";
            }

            [SpedCampos(2, "COD_INC_TRIB", "N", 1, 0, true)]
            public int CodIncTrib { get; set; }

            [SpedCampos(3, "IND_APRO_CRED", "BLANK", 1, 0, false)]
            public int? IndAproCred { get; set; }

            [SpedCampos(4, "COD_TIPO_CONT", "BLANK", 1, 0, false)]
            public int? CodTipoCont { get; set; }

            [SpedCampos(5, "IND_REG_CUM", "BLANK", 1, 0, false)]
            public int? IndRegCum { get; set; }
        }

        /// <summary>
        ///     Registro 0111: Tabela de Receita Bruta Mensal Para Fins de Rateio de Créditos Comuns 
        /// </summary>
        public class Registro0111 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0111" />.
            /// </summary>
            public Registro0111()
            {
                Reg = "0111";
            }

            /// <summary>
            ///     Receita Bruta Não-Cumulativa - Tributada no Mercado Interno
            /// </summary>
            [SpedCampos(2, "REC_BRU_NCUM_TRIB_MI", "N", int.MaxValue, 2, true)]
            public decimal RecBruNCumTribMI { get; set; }

            /// <summary>
            ///     Receita Bruta Não-Cumulativa - Não Tributada no Mercado Interno
            ///     (Vendas com suspensão, alíquota zero, isenção e sem incidência das contribuições)
            /// </summary>
            [SpedCampos(3, "REC_BRU_NCUM_NT_MI", "N", int.MaxValue, 2, true)]
            public decimal RecBruNCumNTMI { get; set; }

            /// <summary>
            ///     Receita Bruta Não-Cumulativa - Exportação
            /// </summary>
            [SpedCampos(4, "REC_BRU_NCUM_EXP", "N", int.MaxValue, 2, true)]
            public decimal RedBruNCumExp { get; set; }

            /// <summary>
            ///     Receita Bruta Cumulativa
            /// </summary>
            [SpedCampos(5, "REC_BRU_CUM", "N", int.MaxValue, 2, true)]
            public decimal RecBruCum { get; set; }

            /// <summary>
            ///     Receita Bruta Total
            /// </summary>
            [SpedCampos(6, "REC_BRU_TOTAL", "N", int.MaxValue, 2, true)]
            public decimal RecBruTotal { get; set; }
        }

        /// <summary>
        ///     Registro 0120: Identificação de EFD-Contribuições Sem Dados a Escriturar 
        /// </summary>
        public class Registro0120 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0120" />.
            /// </summary>
            public Registro0120()
            {
                Reg = "0120";
            }

            /// <summary>
            ///     Mês de referência do ano-calendário da escrituração sem dados, dispensada da entrega.
            /// </summary>
            [SpedCampos(2, "MES_REFER", "MA", 6, 0, true)]
            public DateTime MesRefer { get; set; }

            /// <summary>
            ///     Informação complementar do registro. No caso de escrituração sem dados, deve ser informado o real motivo dessa situação.
            /// </summary>
            /// <remarks>
            /// 01 - Pessoa jurídica imune ou isenta do IRPJ; <para/>
            /// 02 - Órgãos públicos, autarquias e fundações públicas; <para/>
            /// 03 - Pessoa jurídica inativa; <para/>
            /// 04 - Pessoa jurídica em geral, que não realizou operações geradoras de receitas (tributáveis ou não) ou de créditos; <para/>
            /// 05 - Sociedade em Conta de Participação - SCP, que não realizou operações geradoras de receitas (tributáveis ou não) ou de créditos; <para/>
            /// 06 - Sociedade Cooperativa, que não realizou operações geradoras de receitas (tributáveis ou não) ou de créditos; <para/>
            /// 07 - Escrituração decorrente de incorporação, fusão ou cisão, sem operações geradoras de receitas (tributáveis ou não) ou de créditos; <para/>
            /// 09 - Demais hipóteses de dispensa de escrituração, relacionadas no art. 5º, da IN RFB nº 1.252, de 2012.
            /// </remarks>
            [SpedCampos(3, "INF_COMP", "C", 90, 0, true)]
            public string InfComp { get; set; }
        }

        public class Registro0140 : RegistroBaseSped
        {
            public Registro0140()
            {
                Reg = "0140";
            }

            [SpedCampos(2, "COD_EST", "C", 60, 0, false)]
            public string CodEst { get; set; }

            [SpedCampos(3, "NOME", "C", 100, 0, true)]
            public string Nome { get; set; }

            [SpedCampos(4, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            [SpedCampos(5, "UF", "C", 2, 0, true)]
            public string Uf { get; set; }

            [SpedCampos(6, "IE", "C", 14, 0, false)]
            public string Ie { get; set; }

            [SpedCampos(7, "COD_MUN", "N", 7, 0, true)]
            public string CodMun { get; set; }

            [SpedCampos(8, "IM", "C", 0, 0, false)]
            public string Im { get; set; }

            [SpedCampos(9, "SUFRAMA", "C", 9, 0, false)]
            public string Suframa { get; set; }
        }

        /// <summary>
        ///     REGISTRO 0150: TABELA DE CADASTRO DO PARTICIPANTE
        /// </summary>
        public class Registro0150 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0150" />.
            /// </summary>
            public Registro0150()
            {
                Reg = "0150";
            }

            /// <summary>
            ///     Código de identificação do participante no arquivo.
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, true)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Nome pessoal ou empresarial do participante.
            /// </summary>
            [SpedCampos(3, "NOME", "C", 100, 0, true)]
            public string Nome { get; set; }

            /// <summary>
            ///     Código do país do participante, conforme a tabela indicada no item 3.2.1.
            /// </summary>
            [SpedCampos(4, "COD_PAIS", "N", 5, 0, true)]
            public string CodPais { get; set; }

            /// <summary>
            ///     CNPJ do participante.
            /// </summary>
            [SpedCampos(5, "CNPJ", "N", 14, 0, false)]
            public string Cnpj { get; set; }

            /// <summary>
            ///     CPF do participante.
            /// </summary>
            [SpedCampos(6, "CPF", "N", 11, 0, false)]
            public string Cpf { get; set; }

            /// <summary>
            ///     Inscrição Estadual do participante.
            /// </summary>
            [SpedCampos(7, "IE", "C", 14, 0, false)]
            public string Ie { get; set; }

            /// <summary>
            ///     Código do município, conforme a tabela IBGE.
            /// </summary>
            [SpedCampos(8, "COD_MUN", "N", 7, 0, false)]
            public string CodMun { get; set; }

            /// <summary>
            ///     Número de inscrição do participante na SUFRAMA
            /// </summary>
            [SpedCampos(9, "SUFRAMA", "C", 9, 0, false)]
            public string Suframa { get; set; }

            /// <summary>
            ///     Logradouro e endereço do imóvel.
            /// </summary>
            [SpedCampos(10, "END", "C", 60, 0, true)]
            public string End { get; set; }

            /// <summary>
            ///     Número do imóvel.
            /// </summary>
            [SpedCampos(11, "NUM", "C", 10, 0, false)]
            public string Num { get; set; }

            /// <summary>
            ///     Dados complementares do endereço.
            /// </summary>
            [SpedCampos(12, "COMPL", "C", 60, 0, false)]
            public string Compl { get; set; }

            /// <summary>
            ///     Bairro em que o imóvel está situado.
            /// </summary>
            [SpedCampos(13, "BAIRRO", "C", 60, 0, false)]
            public string Bairro { get; set; }
        }

        /// <summary>
        ///     REGISTRO 0190: IDENTIFICAÇÃO DAS UNIDADES DE MEDIDA
        /// </summary>
        public class Registro0190 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0190" />.
            /// </summary>
            public Registro0190()
            {
                Reg = "0190";
            }

            /// <summary>
            ///     Código da unidade de medida.
            /// </summary>
            [SpedCampos(2, "UNID", "C", 6, 0, true)]
            public string Unid { get; set; }

            /// <summary>
            ///     Descrição da unidade de medida.
            /// </summary>
            [SpedCampos(3, "DESCR", "C", int.MaxValue, 0, true)]
            public string Descr { get; set; }
        }

        /// <summary>
        ///     REGISTRO 0200: IDENTIFICAÇÃO DO ITEM (PRODUTOS E SERVIÇOS)
        /// </summary>
        public class Registro0200 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0200" />.
            /// </summary>
            public Registro0200()
            {
                Reg = "0200";
            }

            /// <summary>
            ///     Código do item.
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Descrição do item.
            /// </summary>
            [SpedCampos(3, "DESCR_ITEM", "C", int.MaxValue, 0, true)]
            public string DescrItem { get; set; }

            /// <summary>
            ///     Representação alfanumérica do código de barra do produto, se houver.
            /// </summary>
            [SpedCampos(4, "COD_BARRA", "C", 99, 0, false)]
            public string CodBarra { get; set; }

            /// <summary>
            ///     Código anterior do item com relação à última informação apresentada.
            /// </summary>
            [SpedCampos(5, "COD_ANT_ITEM", "C", 60, 0, false)]
            public string CodAntItem { get; private set; }

            /// <summary>
            ///     Unidade de medida utilizada na quantificação de estoques.
            /// </summary>
            [SpedCampos(6, "UNID_INV", "C", 6, 0, true)]
            public string UnidInv { get; set; }

            /// <summary>
            ///     Tipo do item - Atividades Industriais, Comerciais e Serviços: 00 - Mercadoria para Revenda; 01 - Matéria-Prima; 02
            ///     - Embalagem; 03 - Produto em Processo; 04 - Produto Acabado; 05 - Subproduto; 06 - Produto Intermediário; 07 -
            ///     Material de Uso e Consumo; 08 - Ativo Imobilizado; 09 - Serviços; 10 - Outros insumos; 99 - Outras.
            /// </summary>
            [SpedCampos(7, "TIPO_ITEM", "N", 2, 0, true)]
            public string TipoItem { get; set; }

            /// <summary>
            ///     Código da Nomenclatura Comum do Mercosul
            /// </summary>
            [SpedCampos(8, "COD_NCM", "C", 8, 0, false)]
            public string CodNcm { get; set; }

            /// <summary>
            ///     Código EX, conforme a TIPI
            /// </summary>
            [SpedCampos(9, "EX_IPI", "C", 3, 0, false)]
            public string ExIpi { get; set; }

            /// <summary>
            ///     Código do gênero do item
            /// </summary>
            [SpedCampos(10, "COD_GEN", "N", 2, 0, false)]
            public string CodGen { get; set; }

            /// <summary>
            ///     Código do serviço conforme a lista do Anexo I da Lei Complementar Federal n 116/2003.
            /// </summary>
            [SpedCampos(11, "COD_LST", "C", 5, 0, false)]
            public string CodLst { get; set; }

            /// <summary>
            ///     Alíquota de ICMS aplicável ao item nas operações internas.
            /// </summary>
            [SpedCampos(12, "ALIQ_ICMS", "N", 6, 2, false)]
            public decimal AliqIcms { get; set; }
        }

        /// <summary>
        ///     REGISTRO 0205: ALTERAÇÃO DO ITEM
        /// </summary>
        public class Registro0205 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0205" />.
            /// </summary>
            public Registro0205()
            {
                Reg = "0205";
            }

            /// <summary>
            ///     Descrição anterior do item
            /// </summary>
            [SpedCampos(2, "DESCR_ANT_ITEM", "C", int.MaxValue, 0, false)]
            public string DescrAntItem { get; set; }

            /// <summary>
            ///     Data inicial de utilização da descrição do item.
            /// </summary>
            [SpedCampos(3, "DT_INI", "N", 8, 0, true)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///     Data final de utilização da descrição do item.
            /// </summary>
            [SpedCampos(4, "DT_FIM", "N", 8, 0, true)]
            public DateTime DtFin { get; set; }

            /// <summary>
            ///     Código anterior do item com relação à última informação apresentada.
            /// </summary>
            [SpedCampos(5, "COD_ANT_ITEM", "C", 60, 0, false)]
            public string CodAntItem { get; set; }
        }

        /// <summary>
        ///     REGISTRO 0400: TABELA DE NATUREZA DA OPERAÇÃO/PRESTAÇÃO
        /// </summary>
        public class Registro0400 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0400" />.
            /// </summary>
            public Registro0400()
            {
                Reg = "0400";
            }

            /// <summary>
            ///     Código da natureza da operação/prestação
            /// </summary>
            [SpedCampos(2, "COD_NAT", "C", 10, 0, true)]
            public string CodNat { get; set; }

            /// <summary>
            ///     Descrição da natureza da operação/prestação
            /// </summary>
            [SpedCampos(3, "DESCR_NAT", "C", 250, 0, true)]
            public string DescrNat { get; set; }
        }

        /// <summary>
        ///     REGISTRO 0450: TABELA DE INFORMAÇÃO COMPLEMENTAR DO DOCUMENTO FISCAL
        /// </summary>
        public class Registro0450 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0450" />.
            /// </summary>
            public Registro0450()
            {
                Reg = "0450";
            }

            /// <summary>
            ///     Código da informação complementar do documento fiscal
            /// </summary>
            [SpedCampos(2, "COD_INF", "C", 6, 0, true)]
            public string CodInf { get; set; }

            /// <summary>
            ///     Texto livre da informação complementar existente no
            ///     documento fiscal, inclusive espécie de normas legais,
            ///     poder normativo, número, capitulação, data e demais
            ///     referências pertinentes com indicação referentes ao
            ///     tributo.
            /// </summary>
            [SpedCampos(3, "TXT", "C", int.MaxValue, 0, true)]
            public string Txt { get; set; }
        }

        /// <summary>
        ///     REGISTRO 0500: PLANO DE CONTAS CONTÁBEIS
        /// </summary>
        public class Registro0500 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0500" />.
            /// </summary>
            public Registro0500()
            {
                Reg = "0500";
            }

            /// <summary>
            ///     Data de inclusão/alteração
            /// </summary>
            [SpedCampos(2, "DT_ALT", "N", 8, 0, true)]
            public DateTime DtAlt { get; set; }

            /// <summary>
            ///     Código da natureza da conta/grupo de contas.
            /// </summary>
            /// <remarks>
            ///     01 - Contas de ativo;<para/>
            ///     02 - Contas de passivo;<para/>
            ///     03 - Patrimônio líquido;<para/>
            ///     04 - Contas de resultado;<para/>
            ///     05 - Contas de compensação; e<para/>
            ///     09 - Outras.
            /// </remarks>
            [SpedCampos(3, "COD_NAT_CC", "C", 2, 0, true)]
            public string CodNatCc { get; set; }

            /// <summary>
            ///     Indicador do tipo de conta.
            /// </summary>
            /// <remarks>
            ///  S - Sintética (grupo de contas); e<para/>
            ///  A - Analítica (conta).
            /// </remarks>
            [SpedCampos(4, "IND_CTA", "C", 1, 0, true)]
            public string IndCta { get; set; }

            /// <summary>
            ///     Nível da conta analítica/grupo de contas.
            /// </summary>
            [SpedCampos(5, "NIVEL", "N", 5, 0, true)]
            public int Nivel { get; set; }

            /// <summary>
            ///     Código da conta analítica/grupo de contas.
            /// </summary>
            [SpedCampos(6, "COD_CTA", "C", 255, 0, true)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Nome da conta analítica/grupo de contas.
            /// </summary>
            [SpedCampos(7, "NOME_CTA", "C", 60, 0, true)]
            public string NomeCta { get; set; }

            /// <summary>
            ///     Codigo da conta correlacionada no Plano de Contas Referenciado, publicado pela RFB.
            /// </summary>
            [SpedCampos(8, "COD_CTA_REF", "C", 60, 0, false)]
            public string CodCtaRef { get; set; }

            /// <summary>
            ///     CNPJ do estabelecimento, no caso da conta informada no campo COD_CTA ser específica de um estabelecimento.
            /// </summary>
            [SpedCampos(9, "CNPJ_EST", "N", 14, 0, false)]
            public string CnpjEst { get; set; }
        }

        /// <summary>
        ///     REGISTRO 0600: CENTRO DE CUSTOS
        /// </summary>
        public class Registro0600 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0600" />.
            /// </summary>
            public Registro0600()
            {
                Reg = "0600";
            }

            /// <summary>
            ///     Data da inclusão/alteração
            /// </summary>
            [SpedCampos(2, "DT_ALT", "N", 8, 0, true)]
            public DateTime DtAlt { get; set; }

            /// <summary>
            ///     Código do centro de custos.
            /// </summary>
            [SpedCampos(3, "COD_CCUS", "C", 255, 0, true)]
            public string CodCcus { get; set; }

            /// <summary>
            ///     Nome do centro de custos.
            /// </summary>
            [SpedCampos(4, "CCUS", "C", 60, 0, true)]
            public string Ccus { get; set; }
        }

        /// <summary>
        ///     REGISTRO 0900: COMPOSIÇÃO DAS RECEITAS DO PERÍODO - RECEITA BRUTA E DEMAIS RECEIRAS
        ///</summary>
        public class Registro0900 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0900" />.
            /// </summary>
            public Registro0900()
            {
                Reg = "0900";
            }
            
            /// <summary>
            ///     Receita total referente aos registros escriturados no Bloco A
            /// </summary>
            [SpedCampos(2, "REC_TOTAL_BLOCO_A", "N", int.MaxValue, 2, true)]
            public decimal RecTotalBlocoA { get; set; }
            
            /// <summary>
            ///     Parcela da receita total escriturada no Bloco A (campo 02), não classificada como receita bruta
            /// </summary>
            [SpedCampos(3, "REC_NRB_BLOCO_A", "N", int.MaxValue, 2, false)]
            public decimal? RecNrbBlocoA { get; set; }
            
            /// <summary>
            ///     Receita total referente aos registros escriturados no Bloco C
            /// </summary>
            [SpedCampos(4, "REC_TOTAL_BLOCO_C", "N", int.MaxValue, 2, true)]
            public decimal RecTotalBlocoC { get; set; }

            /// <summary>
            ///     Parcela da receita total escriturada no Bloco C (campo 04), não classificada como receita bruta
            /// </summary>
            [SpedCampos(5, "REC_NRB_BLOCO_C", "N", int.MaxValue, 2, false)]
            public decimal? RecNrbBlocoC { get; set; }

            /// <summary>
            ///     Receita total referente aos registros escriturados no Bloco D
            /// </summary>
            [SpedCampos(6, "REC_TOTAL_BLOCO_D", "N", int.MaxValue, 2, true)]
            public decimal RecTotalBlocoD { get; set; }

            /// <summary>
            ///     Parcela da receita total escriturada no Bloco D (campo 06), não classificada como receita bruta
            /// </summary>
            [SpedCampos(7, "REC_NRB_BLOCO_D", "N", int.MaxValue, 2, false)]
            public decimal? RecNrbBlocoD { get; set; }

            /// <summary>
            ///     Receita total referente aos registros escriturados no Bloco F
            /// </summary>
            [SpedCampos(8, "REC_TOTAL_BLOCO_F", "N", int.MaxValue, 2, true)]
            public decimal RecTotalBlocoF { get; set; }

            /// <summary>
            ///     Parcela da receita total escriturada no Bloco F (campo 08), não classificada como receita bruta
            /// </summary>
            [SpedCampos(9, "REC_NRB_BLOCO_F", "N", int.MaxValue, 2, false)]
            public decimal? RecNrbBlocoF { get; set; }

            /// <summary>
            ///     Receita total referente aos registros escriturados no Bloco I
            /// </summary>
            [SpedCampos(10, "REC_TOTAL_BLOCO_I", "N", int.MaxValue, 2, true)]
            public decimal RecTotalBlocoI { get; set; }

            /// <summary>
            ///     Parcela da receita total escriturada no Bloco I (campo 10) não classificada como receita bruta
            /// </summary>
            [SpedCampos(11, "REC_NRB_BLOCO_I", "N", int.MaxValue, 2, false)]
            public decimal? RecNrbBlocoI { get; set; }

            /// <summary>
            ///     Receita total referente aos registros escriturados no Bloco 1 (RET)
            /// </summary>
            [SpedCampos(12, "REC_TOTAL_BLOCO_1", "N", int.MaxValue, 2, true)]
            public decimal RecTotalBloco1 { get; set; }

            /// <summary>
            ///     Parcela da receita total escriturada no Bloco 1 (campo 12), não classificada como receita bruta
            /// </summary>
            [SpedCampos(13, "REC_NRB_BLOCO_1", "N", int.MaxValue, 2, false)]
            public decimal? RecNrbBloco1 { get; set; }

            /// <summary>
            ///     Receita bruta total (soma dos campos 02, 04, 06, 08, 10 e 12)
            /// </summary>
            [SpedCampos(14, "REC_TOTAL_PERIODO", "N", int.MaxValue, 2, true)]
            public decimal RecTotalPeriodo
            {
                get
                {
                    return 
                        RecTotalBlocoA + 
                        RecTotalBlocoC + 
                        RecTotalBlocoD + 
                        RecTotalBlocoF + 
                        RecTotalBlocoI + 
                        RecTotalBloco1;
                }
            }

            /// <summary>
            ///     Parcela da receita total escriturada (campo 14), não classificada como receita bruta (soma dos campos 03, 05, 07, 09, 11 e 13)
            /// </summary>
            [SpedCampos(15, "REC_TOTAL_NRB_PERIODO", "N", int.MaxValue, 2, false)]
            public decimal? RecTotalNrbPeriodo
            {
                get
                {
                    return 
                        RecNrbBlocoA.GetValueOrDefault() + 
                        RecNrbBlocoC.GetValueOrDefault() + 
                        RecNrbBlocoD.GetValueOrDefault() + 
                        RecNrbBlocoF.GetValueOrDefault() + 
                        RecNrbBlocoI.GetValueOrDefault() + 
                        RecNrbBloco1.GetValueOrDefault();
                }
            }
        }

        /// <summary>
        ///     REGISTRO 0990: ENCERRAMENTO DO BLOCO 0
        /// </summary>
        public class Registro0990 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0990" />.
            /// </summary>
            public Registro0990()
            {
                Reg = "0990";
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0990" />.
            /// </summary>
            /// <param name="qtdLinhas">Quantidade total de linhas do Bloco 0</param>
            public Registro0990(int qtdLinhas)
            {
                Reg = "0990";
                QtdLin0 = qtdLinhas;
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco 0
            /// </summary>
            [SpedCampos(2, "QTD_LIN_0", "N", int.MaxValue, 0, true)]
            public int QtdLin0 { get; private set; }
        }
    }
}
