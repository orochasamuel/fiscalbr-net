using FiscalBr.Common;
using FiscalBr.Common.Sped;
using FiscalBr.Common.Sped.Enums;
using FiscalBr.Common.Sped.Interfaces;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDFiscal
{
    /// <summary>
    ///     BLOCO 0: ABERTURA, IDENTIFICAÇÃO E REFERÊNCIAS
    /// </summary>
    public class Bloco0 : IBlocoSped
    {
        public Registro0000 Reg0000 { get; set; }
        public Registro0001 Reg0001 { get; set; }
        public Registro0990 Reg0990 { get; set; }

        /// <summary>
        ///     REGISTRO 0000: ABERTURA DO ARQUIVO DIGITAL E IDENTIFICAÇÃO DA ENTIDADE
        /// </summary>
        public class Registro0000 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0000" />.
            /// </summary>
            public Registro0000() : base("0000")
            {
            }

            #region Propriedades

            /// <summary>
            ///     Código da versão do leiaute conforme a tabela indicada no Ato COTEPE.
            /// </summary>
            [SpedCampos(2, "COD_VER", "N", 3, 0, true, 2)]
            public CodVersaoSpedFiscal CodVer { get; set; }

            /// <summary>
            ///     Código da finalidade do arquivo
            /// </summary>
            /// <remarks>
            ///     0 - Remessa do arquivo original
            ///     1 - Remessa do arquivo substituto
            /// </remarks>
            [SpedCampos(3, "COD_FIN", "N", 1, 0, true, 2)]
            public IndCodFinalidadeArquivo CodFin { get; set; }

            /// <summary>
            ///     Data inicial das informações contidas no arquivo.
            /// </summary>
            [SpedCampos(4, "DT_INI", "N", 8, 0, true, 2)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///     Data final das informações contidas no arquivo.
            /// </summary>
            [SpedCampos(5, "DT_FIN", "N", 8, 0, true, 2)]
            public DateTime DtFin { get; set; }

            /// <summary>
            ///     Nome empresarial da entidade.
            /// </summary>
            [SpedCampos(6, "NOME", "C", 100, 0, true, 2)]
            public string Nome { get; set; }

            /// <summary>
            ///     Número de inscrição da entidade no CNPJ.
            /// </summary>
            [SpedCampos(7, "CNPJ", "N", 14, 0, false, 2)]
            public string Cnpj { get; set; }

            /// <summary>
            ///     Número de inscrição da entidade no CPF.
            /// </summary>
            [SpedCampos(8, "CPF", "N", 11, 0, false, 2)]
            public string Cpf { get; set; }

            /// <summary>
            ///     Sigla da unidade da federação da entidade.
            /// </summary>
            [SpedCampos(9, "UF", "C", 2, 0, true, 2)]
            public string Uf { get; set; }

            /// <summary>
            ///     Inscrição Estadual da entidade.
            /// </summary>
            [SpedCampos(10, "IE", "C", 14, 0, true, 2)]
            public string Ie { get; set; }

            /// <summary>
            ///     Código do município do domicílio fiscal da entidade, conforme a tabela IBGE.
            /// </summary>
            [SpedCampos(11, "COD_MUN", "N", 7, 0, true, 2)]
            public string CodMun { get; set; }

            /// <summary>
            ///     Inscrição Municipal da entidade.
            /// </summary>
            [SpedCampos(12, "IM", "C", int.MaxValue, 0, false, 2)]
            public string Im { get; set; }

            /// <summary>
            ///     Inscrição da entidade na SUFRAMA.
            /// </summary>
            [SpedCampos(13, "SUFRAMA", "C", 9, 0, false, 2)]
            public string Suframa { get; set; }

            /// <summary>
            ///     Perfil de apresentação do arquivo fiscal:
            ///     A - Perfil A;
            ///     B - Perfil B;
            ///     C - Perfil C.
            /// </summary>
            [SpedCampos(14, "IND_PERFIL", "LE", 1, 0, true, 2)]
            public IndPerfilArquivo IndPerfil { get; set; }

            /// <summary>
            ///     Indicador de tipo de atividade:
            ///     0 - Industrial ou equiparado a industrial;
            ///     1 - Outros.
            /// </summary>
            [SpedCampos(15, "IND_ATIV", "N", 1, 0, true, 2)]
            public TipoAtivSpedFiscal IndAtiv { get; set; }

            #endregion Propriedades

            public Registro0000 ComVersaoLayout(CodVersaoSpedFiscal valor)
            {
                this.CodVer = valor;
                return this;
            }

            public Registro0000 ComFinalidade(IndCodFinalidadeArquivo valor)
            {
                this.CodFin = valor;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0001: ABERTURA DO BLOCO 0
        /// </summary>
        public class Registro0001 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0001" />.
            /// </summary>
            public Registro0001() : base("0001")
            {
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0001" />.
            /// </summary>
            public Registro0001(IndMovimento indMovimento) : base("0001")
            {
                IndMov = indMovimento;
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0001" />.
            /// </summary>
            public Registro0001(bool temMovimento) : base("0001")
            {
                IndMov = temMovimento ? IndMovimento.BlocoComDados : IndMovimento.BlocoSemDados;
            }

            /// <summary>
            ///     Indicador de movimento
            /// </summary>
            /// <remarks>
            ///     0 - Bloco com dados informados;
            ///     <para />
            ///     1 - Bloco sem dados informados.
            /// </remarks>
            [SpedCampos(2, "IND_MOV", "N", 1, 0, true, 2)]
            public IndMovimento IndMov { get; set; }
            
            public Registro0002 Reg0002 { get; set; }
            public Registro0005 Reg0005 { get; set; }
            public List<Registro0015> Reg0015s { get; set; }
            public List<Registro0100> Reg0100s { get; set; }
            public List<Registro0150> Reg0150s { get; set; }
            public List<Registro0190> Reg0190s { get; set; }
            public List<Registro0200> Reg0200s { get; set; }
            public List<Registro0300> Reg0300s { get; set; }
            public List<Registro0400> Reg0400s { get; set; }
            public List<Registro0450> Reg0450s { get; set; }
            public List<Registro0460> Reg0460s { get; set; }
            public List<Registro0500> Reg0500s { get; set; }
            public List<Registro0600> Reg0600s { get; set; }

            public Registro0001 ComIndicadorMovimento(bool valor)
            {
                this.IndMov = valor ? IndMovimento.BlocoComDados : IndMovimento.BlocoSemDados;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0002: CLASSIFICAÇÃO DO ESTABELECIMENTO INDUSTRIAL OU EQUIPARADO A INDUSTRIAL
        /// </summary>
        public class Registro0002 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0002" />.
            /// </summary>
            public Registro0002() : base("0002")
            {
            }

            /// <summary>
            ///     Informar a classificação do estabelecimento conforme tabela 4.5.5
            /// </summary>
            [SpedCampos(2, "CLAS_ESTAB_IND", "C", 2, 0, true, 2)]
            public ClassEstabIndustrial ClassEstabInd { get; set; }

            public Registro0002 ComTipoEstabelecimento(ClassEstabIndustrial v)
            {
                ClassEstabInd = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0005: DADOS COMPLEMENTARES DA ENTIDADE
        /// </summary>
        public class Registro0005 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0005" />.
            /// </summary>
            public Registro0005() : base("0005")
            {
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0005" />.
            /// </summary>
            public Registro0005(
                string fant,
                string cep,
                string end,
                string bairro
                ) : base("0005")
            {
                Fantasia = fant;
                Cep = cep;
                End = end;
                Bairro = bairro;
            }

            /// <summary>
            ///     Nome de fantasia associado ao nome empresarial.
            /// </summary>
            [SpedCampos(2, "FANTASIA", "C", 60, 0, true, 2)]
            public string Fantasia { get; set; }

            /// <summary>
            ///     Código de endeçamento postal.
            /// </summary>
            [SpedCampos(3, "CEP", "N", 8, 0, true, 2)]
            public string Cep { get; set; }

            /// <summary>
            ///     Logradouro e endereço do imóvel.
            /// </summary>
            [SpedCampos(4, "END", "C", 60, 0, true, 2)]
            public string End { get; set; }

            /// <summary>
            ///     Número do imóvel.
            /// </summary>
            [SpedCampos(5, "NUM", "C", 10, 0, false, 2)]
            public string Num { get; set; }

            /// <summary>
            ///     Dados complementares do endereço.
            /// </summary>
            [SpedCampos(6, "COMPL", "C", 60, 0, false, 2)]
            public string Compl { get; set; }

            /// <summary>
            ///     Bairro em que o imóvel está situado.
            /// </summary>
            [SpedCampos(7, "BAIRRO", "C", 60, 0, true, 2)]
            public string Bairro { get; set; }

            /// <summary>
            ///     Número do telefone (DDD+FONE).
            /// </summary>
            [SpedCampos(8, "FONE", "C", 11, 0, false, 2)]
            public string Fone { get; set; }

            /// <summary>
            ///     Número do fax.
            /// </summary>
            [SpedCampos(9, "FAX", "C", 11, 0, false, 2)]
            public string Fax { get; set; }

            /// <summary>
            ///     Endereço do correio eletrônico.
            /// </summary>
            [SpedCampos(10, "EMAIL", "C", int.MaxValue, 0, false, 2)]
            public string Email { get; set; }

            public Registro0005 ComFantasia(string v)
            {
                Fantasia = v;
                return this;
            }

            public Registro0005 ComCep(string v)
            {
                Cep = v;
                return this;
            }

            public Registro0005 ComEndereco(string v)
            {
                End = v;
                return this;
            }

            public Registro0005 ComNumero(string v)
            {
                Num = v;
                return this;
            }

            public Registro0005 ComComplemento(string v)
            {
                Compl = v;
                return this;
            }

            public Registro0005 ComBairro(string v)
            {
                Bairro = v;
                return this;
            }

            public Registro0005 ComTelefone(string v)
            {
                Fone = v;
                return this;
            }

            public Registro0005 ComFax(string v)
            {
                Fax = v;
                return this;
            }

            public Registro0005 ComEmail(string v)
            {
                Email = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0015: DADOS DO CONTRIBUINTE SUBSTITUTO
        /// </summary>
        public class Registro0015 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0015" />.
            /// </summary>
            public Registro0015() : base("0015")
            {
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0015" />.
            /// </summary>
            public Registro0015(
                string uf,
                string insc
                ) : base("0015")
            {
                UfSt = uf;
                IeSt = insc;
            }

            /// <summary>
            ///     Sigla da unidade da federação do contribuinte substituído.
            /// </summary>
            [SpedCampos(2, "UF_ST", "C", 2, 0, true, 2)]
            public string UfSt { get; set; }

            /// <summary>
            ///     Inscrição Estadual do contribuinte substituto na unidade da federação do contribuinte substituído.
            /// </summary>
            [SpedCampos(3, "IE_ST", "C", 14, 0, true, 2)]
            public string IeSt { get; set; }

            public Registro0015 ComUf(string v)
            {
                UfSt = v;
                return this;
            }

            public Registro0015 ComInscricaoSt(string v)
            {
                IeSt = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0100: DADOS DO CONTABILISTA
        /// </summary>
        public class Registro0100 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0100" />.
            /// </summary>
            public Registro0100() : base("0100")
            {
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0100" />.
            /// </summary>
            public Registro0100(
                string nome,
                string cpf,
                string crc,
                string email,
                string codMun
                ) : base("0100")
            {
                Nome = nome;
                Cpf = cpf;
                Crc = crc;
                Email = email;
                CodMun = codMun;
            }

            /// <summary>
            ///     Nome do contabilista.
            /// </summary>
            [SpedCampos(2, "NOME", "C", 100, 0, true, 2)]
            public string Nome { get; set; }

            /// <summary>
            ///     Número de inscrição do contabilista no CPF.
            /// </summary>
            [SpedCampos(3, "CPF", "N", 11, 0, true, 2)]
            public string Cpf { get; set; }

            /// <summary>
            ///     Número de inscrição do contabilista no Conselho Regional de Contabilidade.
            /// </summary>
            [SpedCampos(4, "CRC", "C", 15, 0, true, 2)]
            public string Crc { get; set; }

            /// <summary>
            ///     Número de inscrição do escritório de contabilidade no CNPJ, se houver.
            /// </summary>
            [SpedCampos(5, "CNPJ", "N", 14, 0, false, 2)]
            public string Cnpj { get; set; }

            /// <summary>
            ///     Código de endereçamento postal.
            /// </summary>
            [SpedCampos(6, "CEP", "N", 8, 0, false, 2)]
            public string Cep { get; set; }

            /// <summary>
            ///     Logradouro e endereço do imóvel.
            /// </summary>
            [SpedCampos(7, "END", "C", 60, 0, false, 2)]
            public string End { get; set; }

            /// <summary>
            ///     Número do imóvel.
            /// </summary>
            [SpedCampos(8, "NUM", "C", 10, 0, false, 2)]
            public string Num { get; set; }

            /// <summary>
            ///     Dados complementares do endereço.
            /// </summary>
            [SpedCampos(9, "COMPL", "C", 60, 0, false, 2)]
            public string Compl { get; set; }

            /// <summary>
            ///     Bairro em que o imóvel está situado.
            /// </summary>
            [SpedCampos(10, "BAIRRO", "C", 60, 0, false, 2)]
            public string Bairro { get; set; }

            /// <summary>
            ///     Número de telefone (DDD+FONE).
            /// </summary>
            [SpedCampos(11, "FONE", "C", 11, 0, false, 2)]
            public string Fone { get; set; }

            /// <summary>
            ///     Número do fax.
            /// </summary>
            [SpedCampos(12, "FAX", "C", 11, 0, false, 2)]
            public string Fax { get; set; }

            /// <summary>
            ///     Endereço do correio eletrônico.
            /// </summary>
            [SpedCampos(13, "EMAIL", "C", int.MaxValue, 0, true, 2)]
            public string Email { get; set; }

            /// <summary>
            ///     Código do município, conforme tabela IBGE.
            /// </summary>
            [SpedCampos(14, "COD_MUN", "N", 7, 0, true, 2)]
            public string CodMun { get; set; }

            public Registro0100 ComNome(string v)
            {
                Nome = v;
                return this;
            }

            public Registro0100 ComCpf(string v)
            {
                Cpf = v;
                return this;
            }

            public Registro0100 ComCrc(string v)
            {
                Crc = v;
                return this;
            }

            public Registro0100 ComCnpj(string v)
            {
                Cnpj = v;
                return this;
            }

            public Registro0100 ComCep(string v)
            {
                Cep = v;
                return this;
            }

            public Registro0100 ComEndereco(string v)
            {
                End = v;
                return this;
            }

            public Registro0100 ComNumero(string v)
            {
                Num = v;
                return this;
            }

            public Registro0100 ComComplemento(string v)
            {
                Compl = v;
                return this;
            }

            public Registro0100 ComBairro(string v)
            {
                Bairro = v;
                return this;
            }

            public Registro0100 ComTelefone(string v)
            {
                Fone = v;
                return this;
            }

            public Registro0100 ComFax(string v)
            {
                Fax = v;
                return this;
            }

            public Registro0100 ComEmail(string v)
            {
                Email = v;
                return this;
            }

            public Registro0100 ComCodMunicipio(string v)
            {
                CodMun = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0150: TABELA DE CADASTRO DO PARTICIPANTE
        /// </summary>
        public class Registro0150 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0150" />.
            /// </summary>
            public Registro0150() : base("0150")
            {
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0150" />.
            /// </summary>
            public Registro0150(
                string cod,
                string nome,
                string codPais,
                string end
                ) : base("0150")
            {
                CodPart = cod;
                Nome = nome;
                CodPais = codPais;
                End = end;
            }

            /// <summary>
            ///     Código de identificação do participante no arquivo.
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, true, 2)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Nome pessoal ou empresarial do participante.
            /// </summary>
            [SpedCampos(3, "NOME", "C", 100, 0, true, 2)]
            public string Nome { get; set; }

            /// <summary>
            ///     Código do país do participante, conforme a tabela indicada no item 3.2.1.
            /// </summary>
            [SpedCampos(4, "COD_PAIS", "N", 5, 0, true, 2)]
            public string CodPais { get; set; }

            /// <summary>
            ///     CNPJ do participante.
            /// </summary>
            [SpedCampos(5, "CNPJ", "N", 14, 0, false, 2)]
            public string Cnpj { get; set; }

            /// <summary>
            ///     CPF do participante.
            /// </summary>
            [SpedCampos(6, "CPF", "N", 11, 0, false, 2)]
            public string Cpf { get; set; }

            /// <summary>
            ///     Inscrição Estadual do participante.
            /// </summary>
            [SpedCampos(7, "IE", "C", 14, 0, false, 2)]
            public string Ie { get; set; }

            /// <summary>
            ///     Código do município, conforme a tabela IBGE.
            /// </summary>
            [SpedCampos(8, "COD_MUN", "N", 7, 0, false, 2)]
            public string CodMun { get; set; }

            /// <summary>
            ///     Número de inscrição do participante na SUFRAMA
            /// </summary>
            [SpedCampos(9, "SUFRAMA", "C", 9, 0, false, 2)]
            public string Suframa { get; set; }

            /// <summary>
            ///     Logradouro e endereço do imóvel.
            /// </summary>
            [SpedCampos(10, "END", "C", 60, 0, true, 2)]
            public string End { get; set; }

            /// <summary>
            ///     Número do imóvel.
            /// </summary>
            [SpedCampos(11, "NUM", "C", 10, 0, false, 2)]
            public string Num { get; set; }

            /// <summary>
            ///     Dados complementares do endereço.
            /// </summary>
            [SpedCampos(12, "COMPL", "C", 60, 0, false, 2)]
            public string Compl { get; set; }

            /// <summary>
            ///     Bairro em que o imóvel está situado.
            /// </summary>
            [SpedCampos(13, "BAIRRO", "C", 60, 0, false, 2)]
            public string Bairro { get; set; }

            public List<Registro0175> Reg0175s { get; set; }

            public Registro0150 ComCodigoParticipante(string v)
            {
                CodPart = v;
                return this;
            }

            public Registro0150 ComNomeRazaoSocial(string v)
            {
                Nome = v;
                return this;
            }

            public Registro0150 ComCodigoPais(string v)
            {
                CodPais = v;
                return this;
            }

            public Registro0150 ComCnpj(string v)
            {
                Cnpj = v;
                return this;
            }

            public Registro0150 ComCpf(string v)
            {
                Cpf = v;
                return this;
            }

            public Registro0150 ComInscricaoEstadual(string v)
            {
                Ie = v;
                return this;
            }

            public Registro0150 ComCodMunicipio(string v)
            {
                CodMun = v;
                return this;
            }

            public Registro0150 ComSuframa(string v)
            {
                Suframa = v;
                return this;
            }

            public Registro0150 ComEndereco(string v)
            {
                End = v;
                return this;
            }

            public Registro0150 ComNumero(string v)
            {
                Num = v;
                return this;
            }

            public Registro0150 ComComplemento(string v)
            {
                Compl = v;
                return this;
            }

            public Registro0150 ComBairro(string v)
            {
                Bairro = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0175: ALTERAÇÃO DA TABELA DE CADASTRO DE PARTICIPANTE
        /// </summary>
        public class Registro0175 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0175" />.
            /// </summary>
            public Registro0175() : base("0175")
            {
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0175" />.
            /// </summary>
            public Registro0175(
                DateTime dataAlteracao,
                string numeroCampo,
                string conteudoAnterior
                ) : base("0175")
            {
                DtAlt = dataAlteracao;
                NrCampo = numeroCampo;
                ContAnt = conteudoAnterior;
            }

            /// <summary>
            ///     Data de alteração do cadastro.
            /// </summary>
            [SpedCampos(2, "DT_ALT", "N", 8, 0, true, 2)]
            public DateTime DtAlt { get; set; }

            /// <summary>
            ///     Número do campo alterado (campos 03 a 13, exceto 07)
            /// </summary>
            [SpedCampos(3, "NR_CAMPO", "C", 2, 0, true, 2)]
            public string NrCampo { get; set; }

            /// <summary>
            ///     Conteúdo anterior do campo.
            /// </summary>
            [SpedCampos(4, "CONT_ANT", "C", 100, 0, true, 2)]
            public string ContAnt { get; set; }

            public Registro0175 ComDataAlteracao(DateTime v)
            {
                DtAlt = v;
                return this;
            }

            public Registro0175 ComNumeroCampo(string v)
            {
                NrCampo = v;
                return this;
            }

            public Registro0175 ComConteudoAnterior(string v)
            {
                ContAnt = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0190: IDENTIFICAÇÃO DAS UNIDADES DE MEDIDA
        /// </summary>
        public class Registro0190 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0190" />.
            /// </summary>
            public Registro0190() : base("0190")
            {
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0190" />.
            /// </summary>
            public Registro0190(
                string unidade,
                string descricao
                ) : base("0190")
            {
                Unid = unidade;
                Descr = descricao;
            }

            /// <summary>
            ///     Código da unidade de medida.
            /// </summary>
            [SpedCampos(2, "UNID", "C", 6, 0, true, 2)]
            public string Unid { get; set; }

            /// <summary>
            ///     Descrição da unidade de medida.
            /// </summary>
            [SpedCampos(3, "DESCR", "C", int.MaxValue, 0, true, 2)]
            public string Descr { get; set; }

            public Registro0190 ComCodigoOuSigla(string v)
            {
                Unid = v;
                return this;
            }

            public Registro0190 ComDescricao(string v)
            {
                Descr = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0200: IDENTIFICAÇÃO DO ITEM (PRODUTOS E SERVIÇOS)
        /// </summary>
        public class Registro0200 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0200" />.
            /// </summary>
            public Registro0200() : base("0200")
            {
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0200" />.
            /// </summary>
            public Registro0200(
                string codItem,
                string descItem,
                string unidItem,
                IndTipoItem tipoItem
                ) : base("0200")
            {
                CodItem = codItem;
                DescrItem = descItem;
                UnidInv = unidItem;
                TipoItem = tipoItem;
            }

            /// <summary>
            ///     Código do item.
            /// </summary>
            [SpedCampos(2, "COD_ITEM", "C", 60, 0, true, 2)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Descrição do item.
            /// </summary>
            [SpedCampos(3, "DESCR_ITEM", "C", int.MaxValue, 0, true, 2)]
            public string DescrItem { get; set; }

            /// <summary>
            ///     Representação alfanumérica do código de barra do produto, se houver.
            /// </summary>
            [SpedCampos(4, "COD_BARRA", "C", 99, 0, false, 2)]
            public string CodBarra { get; set; }

            /// <summary>
            ///     Código anterior do item com relação à última informação apresentada.
            ///     Conforme Guia_Prático_da_EFD_Versao_2.0.17 -> "informar no 0205"
            /// </summary>
            [SpedCampos(5, "COD_ANT_ITEM", "C", 60, 0, false, 2)]
            public string CodAntItem
            {
                get
                {
                    return string.Empty;
                }
            }

            /// <summary>
            ///     Unidade de medida utilizada na quantificação de estoques.
            /// </summary>
            [SpedCampos(6, "UNID_INV", "C", 6, 0, true, 2)]
            public string UnidInv { get; set; }

            /// <summary>
            ///     Tipo do item - Atividades Industriais, Comerciais e Serviços: 00 - Mercadoria para Revenda; 01 - Matéria-Prima; 02
            ///     - Embalagem; 03 - Produto em Processo; 04 - Produto Acabado; 05 - Subproduto; 06 - Produto Intermediário; 07 -
            ///     Material de Uso e Consumo; 08 - Ativo Imobilizado; 09 - Serviços; 10 - Outros insumos; 99 - Outras.
            /// </summary>
            [SpedCampos(7, "TIPO_ITEM", "N", 2, 0, true, 2)]
            public IndTipoItem TipoItem { get; set; }

            /// <summary>
            ///     Código da Nomenclatura Comum do Mercosul
            /// </summary>
            [SpedCampos(8, "COD_NCM", "C", 8, 0, false, 2)]
            public string CodNcm { get; set; }

            /// <summary>
            ///     Código EX, conforme a TIPI
            /// </summary>
            [SpedCampos(9, "EX_IPI", "C", 3, 0, false, 2)]
            public string ExIpi { get; set; }

            /// <summary>
            ///     Código do gênero do item
            /// </summary>
            [SpedCampos(10, "COD_GEN", "N", 2, 0, false, 2)]
            public string CodGen { get; set; }

            /// <summary>
            ///     Código do serviço conforme a lista do Anexo I da Lei Complementar Federal n 116/2003.
            /// </summary>
            [SpedCampos(11, "COD_LST", "C", 5, 0, false, 2)]
            public string CodLst { get; set; }

            /// <summary>
            ///     Alíquota de ICMS aplicável ao item nas operações internas.
            /// </summary>
            [SpedCampos(12, "ALIQ_ICMS", "N", 6, 2, false, 2)]
            public decimal? AliqIcms { get; set; }

            /// <summary>
            ///     Código Especificador da Substituição Tributária
            ///     Guia Prático EFD-ICMS/IPI – Versão 2.0.20
            ///     Atualização: 07/12/2016
            /// </summary>
            [SpedCampos(13, "CEST", "C", 7, 0, false, 2)]
            public string Cest { get; set; }

            public List<Registro0205> Reg0205s { get; set; }
            public Registro0206 Reg0206 { get; set; }
            public List<Registro0210> Reg0210s { get; set; }
            public List<Registro0220> Reg0220s { get; set; }
            public List<Registro0221> Reg0221s { get; set; }

            public Registro0200 ComCodigoItem(string v)
            {
                CodItem = v;
                return this;
            }

            public Registro0200 ComDescricaoItem(string v)
            {
                DescrItem = v;
                return this;
            }

            public Registro0200 ComCodBarras(string v)
            {
                CodBarra = v;
                return this;
            }

            public Registro0200 ComUnidade(string v)
            {
                UnidInv = v;
                return this;
            }

            public Registro0200 ComTipoItem(IndTipoItem v)
            {
                TipoItem = v;
                return this;
            }

            public Registro0200 ComCodigoNcm(string v)
            {
                CodNcm = v;
                return this;
            }

            public Registro0200 ComCodigoExIpi(string v)
            {
                ExIpi = v;
                return this;
            }

            public Registro0200 ComCodigoGenero(string v)
            {
                CodGen = v;
                return this;
            }

            public Registro0200 ComCodigoServico(string v)
            {
                CodLst = v;
                return this;
            }

            public Registro0200 ComAliqIcms(decimal v)
            {
                AliqIcms = v;
                return this;
            }

            public Registro0200 ComCodigoCest(string v)
            {
                Cest = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0205: ALTERAÇÃO DO ITEM
        /// </summary>
        public class Registro0205 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0205" />.
            /// </summary>
            public Registro0205() : base("0205")
            {
            }

            /// <summary>
            ///     Descrição anterior do item
            /// </summary>
            [SpedCampos(2, "DESCR_ANT_ITEM", "C", int.MaxValue, 0, false, 2)]
            public string DescrAntItem { get; set; }

            /// <summary>
            ///     Data inicial de utilização da descrição do item.
            /// </summary>
            [SpedCampos(3, "DT_INI", "N", 8, 0, true, 2)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///     Data final de utilização da descrição do item.
            /// </summary>
            [SpedCampos(4, "DT_FIM", "N", 8, 0, true, 2)]
            public DateTime DtFin { get; set; }

            /// <summary>
            ///     Código anterior do item com relação à última informação apresentada.
            /// </summary>
            [SpedCampos(5, "COD_ANT_ITEM", "C", 60, 0, false, 3)]
            public string CodAntItem { get; set; }

            public Registro0205 ComDescricaoAnterior(string v)
            {
                DescrAntItem = v;
                return this;
            }

            public Registro0205 ComDataInicial(DateTime v)
            {
                DtIni = v;
                return this;
            }

            public Registro0205 ComDataFinal(DateTime v)
            {
                DtFin = v;
                return this;
            }

            public Registro0205 ComCodigoAnterior(string v)
            {
                CodAntItem = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0206: CÓDIGO DE PRODUTO CONFORME TABELA PUBLICADA PELA ANP (COMBUSTÍVEIS)
        /// </summary>
        public class Registro0206 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0206" />.
            /// </summary>
            public Registro0206() : base("0206")
            {
            }

            /// <summary>
            ///     Código do combustível, conforme tabela publicada pela ANP.
            /// </summary>
            [SpedCampos(2, "COD_COMB", "C", int.MaxValue, 0, true, 2)]
            public string CodComb { get; set; }

            public Registro0206 ComCodigo(string v)
            {
                CodComb = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0210: CONSUMO ESPECÍFICO PADRONIZADO
        /// </summary>
        public class Registro0210 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0210" />.
            /// </summary>
            public Registro0210() : base("0210")
            {
            }

            /// <summary>
            ///     Código do item componente/insumo (campo 02 do Registro 0200).
            /// </summary>
            [SpedCampos(2, "COD_ITEM_COMP", "C", 60, 0, true, 10)]
            public string CodItemComp { get; set; }

            /// <summary>
            ///     Quantidade do item componente/insumo para se produzir uma unidade do item composto/resultante.
            /// </summary>
            [SpedCampos(3, "QTD_COMP", "N", int.MaxValue, 6, true, 10)]
            public decimal QtdComp { get; set; }

            /// <summary>
            ///     Perda/quebra normal percentual do insumo/componente para se produzir uma unidade do item composto/resultante.
            /// </summary>
            [SpedCampos(4, "PERDA", "N", int.MaxValue, 4, true, 10)]
            public decimal Perda { get; set; }

            public Registro0210 ComCodigoItem(string v)
            {
                CodItemComp = v;
                return this;
            }

            public Registro0210 ComQuantidade(decimal v)
            {
                QtdComp = v;
                return this;
            }

            public Registro0210 ComPerda(decimal v)
            {
                Perda = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0220: FATORES DE CONVERSÃO DE UNIDADES
        /// </summary>
        public class Registro0220 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0220" />.
            /// </summary>
            public Registro0220() : base("0220")
            {
            }

            /// <summary>
            ///     Unidade comercial a ser convertida na unidade de estoque, referida no registro 0200.
            /// </summary>
            [SpedCampos(2, "UNID_CONV", "C", 6, 0, true, 2)]
            public string UnidConv { get; set; }

            /// <summary>
            ///     Fator de conversão: fator utilizado para converter (multiplicar) a unidade a ser convertida na unidade adotada no
            ///     inventário.
            /// </summary>
            [SpedCampos(3, "FAT_CONV", "N", 10, 6, true, 2)]
            public decimal FatConv { get; set; }

            /// <summary>
            ///     Representação alfanumérica do código de barra da unidade comercial do produto, se houver
            /// </summary>
            [SpedCampos(4, "COD_BARRA", "C", int.MaxValue, 0, false, 16)]
            public string CodBarra { get; set; }

            public Registro0220 ComUnidade(string v)
            {
                UnidConv = v;
                return this;
            }

            public Registro0220 ComFatorConversao(decimal v)
            {
                FatConv = v;
                return this;
            }

            public Registro0220 ComCodBarras(string v)
            {
                CodBarra = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0221: CORRELAÇÃO ENTRE CÓDIGOS DE ITENS COMERCIALIZADOS
        /// </summary>
        [SpedRegistros("01/01/2023", "")]
        public class Registro0221 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0221" />.
            /// </summary>
            public Registro0221() : base("0221")
            {
            }

            /// <summary>
            ///     Informar o código do item atômico contido no item informado no 0200 Pai.
            /// </summary>
            [SpedCampos(2, "COD_ITEM_ATOMICO", "C", 60, 0, true, 17)]
            public string CodItemAtomico { get; set; }

            /// <summary>
            ///     Informar quantos itens atômicos estão contidos no item informado no 0200 Pai.
            /// </summary>
            [SpedCampos(3, "QTD_CONTIDA", "N", int.MaxValue, 6, true, 17)]
            public decimal QtdContida { get; set; }

            public Registro0221 ComCodItem(string v)
            {
                CodItemAtomico = v;
                return this;
            }

            public Registro0221 ComQuantidade(decimal v)
            {
                QtdContida = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0300: CADASTRO DE BENS OU COMPONENTES DO ATIVO IMOBILIZADO
        /// </summary>
        public class Registro0300 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0300" />.
            /// </summary>
            public Registro0300() : base("0300")
            {
            }

            /// <summary>
            ///     Código individualizado do bem ou componente adotado
            ///     no controle patrimonial do estabelecimento informante.
            /// </summary>
            [SpedCampos(2, "COD_IND_BEM", "C", 60, 0, true, 4)]
            public string CodIndBem { get; set; }

            /// <summary>
            ///     Identificação do tipo de mercadoria: 1 = bem; 2 = componente.
            /// </summary>
            [SpedCampos(3, "IDENT_MERC", "C", 1, 0, true, 4)]
            public IndTipoMercadoria IdentMerc { get; set; }

            /// <summary>
            ///     Descrição do bem ou componente (modelo, marca e outras
            ///     características necessárias a sua individualização.
            /// </summary>
            [SpedCampos(4, "DESCR_ITEM", "C", 255, 0, true, 4)]
            public string DescrItem { get; set; }

            /// <summary>
            ///     Código de cadastro do bem principal nos casos em
            ///     que o bem ou componente (campo 02) esteja
            ///     vinculado a um bem principal.
            /// </summary>
            [SpedCampos(5, "COD_PRNC", "C", 60, 0, false, 4)]
            public string CodPrnc { get; set; }

            /// <summary>
            ///     Código da conta analítica de contabilização do bem
            ///     ou componente (campo 06 do Registro 0500)
            /// </summary>
            [SpedCampos(6, "COD_CTA", "C", 60, 0, true, 4)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Número total de parcelas a serem apropriadas,
            ///     segundo a legislação de cada unidade federada.
            /// </summary>
            [SpedCampos(7, "NR_PARC", "N", 3, 0, false, 4)]
            public int NrParc { get; set; }

            public Registro0305 Reg0305 { get; set; }

            public Registro0300 ComCodigoBem(string v)
            {
                CodIndBem = v;
                return this;
            }

            public Registro0300 ComTipoMercadoria(IndTipoMercadoria v)
            {
                IdentMerc = v;
                return this;
            }

            public Registro0300 ComDescricao(string v)
            {
                DescrItem = v;
                return this;
            }

            public Registro0300 ComCodigoBemPrincipal(string v)
            {
                CodPrnc = v;
                return this;
            }

            public Registro0300 ComContaContabil(string v)
            {
                CodCta = v;
                return this;
            }

            public Registro0300 ComNumeroParcelas(int v)
            {
                NrParc = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0305: INFORMAÇÃO SOBRE A UTILIZAÇÃO DO BEM
        /// </summary>
        public class Registro0305 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0305" />.
            /// </summary>
            public Registro0305() : base("0305")
            {
            }

            /// <summary>
            ///     Código do centro de custo onde o bem está sendo ou será
            ///     utilizado (campo 03 do Registro 0600)
            /// </summary>
            [SpedCampos(2, "COD_CCUS", "C", 60, 0, true, 4)]
            public string CodCcus { get; set; }

            /// <summary>
            ///     Descrição sucinta da função do bem na atividade do estabelecimento
            /// </summary>
            [SpedCampos(3, "FUNC", "C", 255, 0, true, 4)]
            public string Func { get; set; }

            /// <summary>
            ///     Vida útil estimada do bem, em número de meses
            /// </summary>
            [SpedCampos(4, "VIDA_UTIL", "N", 3, 0, false, 4)]
            public int VidaUtil { get; set; }

            public Registro0305 ComCodigoCentroCusto(string v)
            {
                CodCcus = v;
                return this;
            }

            public Registro0305 ComDescricaoFuncaoBem(string v)
            {
                Func = v;
                return this;
            }

            public Registro0305 ComVidaUtilEmMeses(int v)
            {
                VidaUtil = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0400: TABELA DE NATUREZA DA OPERAÇÃO/PRESTAÇÃO
        /// </summary>
        public class Registro0400 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0400" />.
            /// </summary>
            public Registro0400() : base("0400")
            {
            }

            /// <summary>
            ///     Código da natureza da operação/prestação
            /// </summary>
            [SpedCampos(2, "COD_NAT", "C", 10, 0, true, 2)]
            public string CodNat { get; set; }

            /// <summary>
            ///     Descrição da natureza da operação/prestação
            /// </summary>
            [SpedCampos(3, "DESCR_NAT", "C", int.MaxValue, 0, true, 2)]
            public string DescrNat { get; set; }

            public Registro0400 ComCodigoNatureza(string v)
            {
                CodNat = v;
                return this;
            }

            public Registro0400 ComDescricaoNatureza(string v)
            {
                DescrNat = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0450: TABELA DE INFORMAÇÃO COMPLEMENTAR DO DOCUMENTO FISCAL
        /// </summary>
        public class Registro0450 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0450" />.
            /// </summary>
            public Registro0450() : base("0450")
            {
            }

            /// <summary>
            ///     Código da informação complementar do documento fiscal
            /// </summary>
            [SpedCampos(2, "COD_INF", "C", 6, 0, true, 2)]
            public string CodInf { get; set; }

            /// <summary>
            ///     Texto livre da informação complementar existente no
            ///     documento fiscal, inclusive espécie de normas legais,
            ///     poder normativo, número, capitulação, data e demais
            ///     referências pertinentes com indicação referentes ao
            ///     tributo.
            /// </summary>
            [SpedCampos(3, "TXT", "C", int.MaxValue, 0, true, 2)]
            public string Txt { get; set; }

            public Registro0450 ComCodInformacaoComplementar(string v)
            {
                CodInf = v;
                return this;
            }

            public Registro0450 ComTxtInformacaoComplementar(string v)
            {
                Txt = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0460: TABELA DE OBSERVAÇÕES DO LANÇAMENTO FISCAL
        /// </summary>
        public class Registro0460 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0460" />.
            /// </summary>
            public Registro0460() : base("0460")
            {
            }

            /// <summary>
            ///     Código da observação do lançamento fiscal
            /// </summary>
            [SpedCampos(2, "COD_OBS", "C", 6, 0, true, 2)]
            public string CodObs { get; set; }

            /// <summary>
            ///     Descrição da observação vinculada ao lançamento fiscal
            /// </summary>
            [SpedCampos(3, "TXT", "C", int.MaxValue, 0, true, 2)]
            public string Txt { get; set; }

            public Registro0460 ComCodigoObservacao(string v)
            {
                CodObs = v;
                return this;
            }

            public Registro0460 ComDescricaoObservacao(string v)
            {
                Txt = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0500: PLANO DE CONTAS CONTÁBEIS
        /// </summary>
        public class Registro0500 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0500" />.
            /// </summary>
            public Registro0500() : base("0500")
            {
            }

            /// <summary>
            ///     Data de inclusão/alteração
            /// </summary>
            [SpedCampos(2, "DT_ALT", "N", 8, 0, true, 4)]
            public DateTime DtAlt { get; set; }

            /// <summary>
            ///     Código da natureza da conta/grupo de contas:
            ///     01 - Contas de ativo;
            ///     02 - Contas de passivo;
            ///     03 - Patrimônio líquido;
            ///     04 - Contas de resultado;
            ///     05 - Contas de compensação;
            ///     09 - Outras.
            /// </summary>
            [SpedCampos(3, "COD_NAT_CC", "C", 2, 0, true, 4)]
            public IndTipoNaturezaContaContabil CodNatCc { get; set; }

            /// <summary>
            ///     Indicador do tipo de conta: S - Sintética (grupo de contas); A - Analítica (conta).
            /// </summary>
            [SpedCampos(4, "IND_CTA", "C", 1, 0, true, 4)]
            public IndTipoContaContabil IndCta { get; set; }

            /// <summary>
            ///     Nível da conta analítica/grupo de contas.
            /// </summary>
            [SpedCampos(5, "NIVEL", "N", 5, 0, true, 4)]
            public int Nivel { get; set; }

            /// <summary>
            ///     Código da conta analítica/grupo de contas.
            /// </summary>
            [SpedCampos(6, "COD_CTA", "C", 60, 0, true, 4)]
            public string CodCta { get; set; }

            /// <summary>
            ///     Nome da conta analítica/grupo de contas.
            /// </summary>
            [SpedCampos(7, "NOME_CTA", "C", 60, 0, true, 4)]
            public string NomeCta { get; set; }

            public Registro0500 ComData(DateTime v)
            {
                DtAlt = v;
                return this;
            }

            public Registro0500 ComNaturezaContaContabil(IndTipoNaturezaContaContabil v)
            {
                CodNatCc = v;
                return this;
            }

            public Registro0500 ComTipoContaContabil(IndTipoContaContabil v)
            {
                IndCta = v;
                return this;
            }

            public Registro0500 ComNivel(int v)
            {
                Nivel = v;
                return this;
            }

            public Registro0500 ComCodigoContaContabil(string v)
            {
                CodCta = v;
                return this;
            }

            public Registro0500 ComNomeContaContabil(string v)
            {
                NomeCta = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0600: CENTRO DE CUSTOS
        /// </summary>
        public class Registro0600 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0600" />.
            /// </summary>
            public Registro0600() : base("0600")
            {
            }

            /// <summary>
            ///     Data da inclusão/alteração
            /// </summary>
            [SpedCampos(2, "DT_ALT", "N", 8, 0, true, 4)]
            public DateTime DtAlt { get; set; }

            /// <summary>
            ///     Código do centro de custos.
            /// </summary>
            [SpedCampos(3, "COD_CCUS", "C", 60, 0, true, 4)]
            public string CodCcus { get; set; }

            /// <summary>
            ///     Nome do centro de custos.
            /// </summary>
            [SpedCampos(4, "CCUS", "C", 60, 0, true, 4)]
            public string Ccus { get; set; }

            public Registro0600 ComData(DateTime v)
            {
                DtAlt = v;
                return this;
            }

            public Registro0600 ComCodigoCentroCusto(string v)
            {
                CodCcus = v;
                return this;
            }

            public Registro0600 ComDescricaoCentroCusto(string v)
            {
                Ccus = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO 0990: ENCERRAMENTO DO BLOCO 0
        /// </summary>
        public class Registro0990 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro0990" />.
            /// </summary>
            public Registro0990() : base("0990")
            {
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco 0.
            /// </summary>
            [SpedCampos(2, "QTD_LIN_0", "N", int.MaxValue, 0, true, 2)]
            public int QtdLin0 { get; set; }
        }
    }
}
