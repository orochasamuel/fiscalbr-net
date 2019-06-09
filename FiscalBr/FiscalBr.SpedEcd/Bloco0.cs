using FiscalBr.Common;
using System;

namespace FiscalBr.SpedEcd
{
    public class Bloco0
    {
        /// <summary>
        /// REGISTRO 0000: ABERTURA DO ARQUIVO DIGITAL E IDENTIFICAÇÃO DO EMPRESÁRIO OU DA SOCIEDADE EMPRESÁRIA
        /// </summary>
        public class Registro0000 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0000"/>.
            /// </summary>
            public Registro0000()
            {
                Reg = "0000";
            }

            /// <summary>
            /// Texto fixo contendo "LECD"
            /// </summary>
            [SpedCampos(2, "LECD", "C", 4, 0, true)]
            public string Lecd {
                get { return "LECD"; } }

            /// <summary>
            /// Data inicial das informações contidas no arquivo
            /// </summary>
            [SpedCampos(3, "DT_INI", "N", 8, 0, true)]
            public DateTime DtIni { get; set; }

            /// <summary>
            /// Data final das informações contidas no arquivo
            /// </summary>
            [SpedCampos(4, "DT_FIN", "N", 8, 0, true)]
            public DateTime DtFin { get; set; }

            /// <summary>
            /// Nome empresarial da pessoa jurídica
            /// </summary>
            [SpedCampos(5, "NOME", "C", Int16.MaxValue, 0, true)]
            public string Nome { get; set; }

            /// <summary>
            /// Número de inscrição da pessoa jurídica no CNPJ
            /// </summary>
            /// <remarks>
            /// Observação: Esse CNPJ é sempre da Sócia Ostensiva, no caso do arquivo da SCP.
            /// </remarks>
            [SpedCampos(6, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            /// <summary>
            /// Sigla da unidade da federação da pessoa jurídica
            /// </summary>
            [SpedCampos(7, "UF", "C", 2, 0, true)]
            public string Uf { get; set; }

            /// <summary>
            /// Inscrição Estadual da pessoa jurídica
            /// </summary>
            [SpedCampos(8, "IE", "C", Int16.MaxValue, 0, false)]
            public string Ie { get; set; }

            /// <summary>
            /// Código do município do domicílio fiscal da pessoa jurídica, conforme tabela do IBGE - Instituto Brasileiro de Geografia e Estatística
            /// </summary>
            [SpedCampos(9, "COD_MUN", "N", 7, 0, false)]
            public string CodMun { get; set; }

            /// <summary>
            /// Inscrição Municipal da pessoa jurídica
            /// </summary>
            [SpedCampos(10, "IM", "C", Int16.MaxValue, 0, false)]
            public string Im { get; set; }

            /// <summary>
            /// Indicador de situação especial
            /// </summary>
            [SpedCampos(11, "IND_SIT_ESP", "N", 1, 0, false)]
            public Int16? IndSitEsp { get; set; }

            /// <summary>
            /// Indicador de situação no início do período
            /// </summary>
            [SpedCampos(12, "IND_SIT_INI_PER", "N", 1, 0, true)]
            public Int16 IndSitIniPer { get; set; }

            /// <summary>
            /// Indicador de existência de NIRE
            /// </summary>
            /// <remarks>
            /// 0 - Empresa não possui registro na Junta Comercial (não possui NIRE); <para/>
            /// 1 - Empresa possui registro na Junta Comercial (possui NIRE)
            /// </remarks>
            [SpedCampos(13, "IND_NIRE", "N", 1, 0, true)]
            public Int16 IndNire { get; set; }

            /// <summary>
            /// Indicador de finalidade da escrituração
            /// </summary>
            /// <remarks>
            /// 0 - Original; <para/>
            /// 1 - Substituta
            /// </remarks>
            [SpedCampos(14, "IND_FIN_ESC", "N", 1, 0, true)]
            public IndCodFinalidadeArquivo IndFinEsc { get; set; }

            /// <summary>
            /// Hash da escrituração substituída
            /// </summary>
            [SpedCampos(15, "COD_HASH_SUB", "C", 40, 0, false)]
            public string CodHashSub { get; set; }

            /// <summary>
            /// Indicador de entidade sujeita a auditoria independente
            /// </summary>
            /// <remarks>
            /// 0 - Empresa não é entidade sujeita a auditoria independente; <para/>
            /// 1 - Empresa é entidade sujeita a auditoria independente - Ativo Total superior a R$ 240.000.000,00 ou Receita Bruta Anual superior a R$ 300.000.000,00
            /// </remarks>
            [SpedCampos(16, "IND_GRANDE_PORTE", "N", 1, 0, true)]
            public Int16 IndGrandePorte { get; set; }

            /// <summary>
            /// Indicador do tipo de ECD
            /// </summary>
            /// <remarks>
            /// 0 - ECD de empresa não participante de SCP como sócio ostensivo; <para/>
            /// 1 - ECD de empresa participante de SCP como sócio ostensivo; <para/>
            /// 2 - ECD da SCP
            /// </remarks>
            [SpedCampos(17, "TIP_ECD", "N", 1, 0, true)]
            public Int16 TipEcd { get; set; }

            /// <summary>
            /// CNPJ da SCP (Art. 4º, XVII, da IN RFB nº 1.634, de 6 de maio de 2016)
            /// </summary>
            /// <remarks>
            /// Observação: Só deve ser preenchido pela própria SCP com o CNPJ da SCP (Não é preenchido pelo sócio ostensivo)
            /// </remarks>
            [SpedCampos(18, "COD_SCP", "N", 14, 0, false)]
            public string CodScp { get; set; }

            /// <summary>
            /// Identificação de moeda funcional. Indica que a escrituração abrange valores com base na moeda funcional (art. 287 da IN RFB nº 1.700, de 14 de março de 2017)
            /// </summary>
            /// <remarks>
            /// Observação: Nessa situação, deverá ser utilizado o registro I020 para informação de campos adicionais
            /// </remarks>
            [SpedCampos(19, "IDENT_MF", "C", 1, 0, true)]
            public SimOuNao IdentMf { get; set; }

            /// <summary>
            /// Escrituração Contábeis Consolidadas <para/>
            /// Deve ser preenchido pela empresa controladora obrigada a informar demonstrações contábeis consolidadas, <para/>
            /// nos termos da Lei nº 6.404/76 e do Pronunciamento Técnico CPC 36 - Demonstrações Consolidadas
            /// </summary>
            /// <remarks>
            /// S - Sim; <para/>
            /// N - Não
            /// </remarks>
            [SpedCampos(20, "IND_ESC_CONS", "C", 1, 0, true)]
            public SimOuNao IndEscCons { get; set; }
        }

        /// <summary>
        /// REGISTRO 0001: ABERTURA DO BLOCO 0
        /// </summary>
        public class Registro0001 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0001"/>.
            /// </summary>
            public Registro0001()
            {
                Reg = "0001";
            }

            /// <summary>
            /// Indicador de Movimento
            /// </summary>
            /// <remarks>
            /// 0 - Bloco com dados informados <para/>
            /// 1 - Bloco sem dados informados
            /// </remarks>
            [SpedCampos(2, "IND_DAD", "N", 1, 0, true)]
            public IndMovimento IndDad { get; set; }
        }

        /// <summary>
        /// REGISTRO 0007: OUTRAS INSCRIÇÕES CADASTRAIS DA PESSOA JURÍDICA
        /// </summary>
        public class Registro0007 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0007"/>.
            /// </summary>
            public Registro0007()
            {
                Reg = "0007";
            }

            /// <summary>
            /// Código da instituição responsável pela administração do cadastro
            /// </summary>
            [SpedCampos(2, "COD_ENT_REF", "C", 2, 0, true)]
            public CodigoEntidade CodEntRef { get; set; }

            /// <summary>
            /// Código cadastral da pessoa jurídica na instituição identificada
            /// </summary>
            [SpedCampos(3, "COD_INSCR", "C", Int16.MaxValue, 0, false)]
            public string CodInscr { get; set; }
        }

        /// <summary>
        /// REGISTRO 0020: ESCRITURAÇÃO CONTÁBIL DESCENTRALIZADA
        /// </summary>
        public class Registro0020 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0020"/>.
            /// </summary>
            public Registro0020()
            {
                Reg = "0020";
            }

            /// <summary>
            /// Indicador de descentraliação
            /// </summary>
            /// <remarks>
            /// 0 - Escrituração da matriz <para/>
            /// 1 - Escrituração da filial
            /// </remarks>
            [SpedCampos(2, "IND_DEC", "N", 1, 0, true)]
            public int IndDec { get; set; }

            /// <summary>
            /// Número da inscrição da pessoa jurídica no CNPJ da matriz ou da filial
            /// </summary>
            [SpedCampos(3, "CNPJ", "N", 14, 0, true)]
            public string Cnpj { get; set; }

            /// <summary>
            /// Sigla da unidade da federação da matriz ou da filial
            /// </summary>
            [SpedCampos(4, "UF", "C", 2, 0, true)]
            public string Uf { get; set; }

            /// <summary>
            /// Inscrição estadual da matriz ou da filial
            /// </summary>
            [SpedCampos(5, "IE", "C", Int16.MaxValue, 0, false)]
            public string Ie { get; set; }

            /// <summary>
            /// Código do município do domicílio da matriz ou da filial
            /// </summary>
            [SpedCampos(6, "COD_MUN", "N", 7, 0, false)]
            public string CodMun { get; set; }

            /// <summary>
            /// Número da inscrição municipal da matriz ou da filial
            /// </summary>
            [SpedCampos(7, "IM", "C", Int16.MaxValue, 0, false)]
            public string Im { get; set; }

            /// <summary>
            /// Número da identificação do registro de empresas da matriz ou da filial na Junta Comercial
            /// </summary>
            [SpedCampos(8, "NIRE", "N", 11, 0, false)]
            public string Nire { get; set; }
        }

        /// <summary>
        /// REGISTRO 0035: IDENTIFICAÇÃO DA SCP
        /// </summary>
        public class Registro0035 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0035"/>.
            /// </summary>
            public Registro0035()
            {
                Reg = "0035";
            }

            /// <summary>
            /// CNPJ da SCP
            /// </summary>
            [SpedCampos(2, "COD_SCP", "C", 14, 0, true)]
            public string CodScp { get; set; }

            /// <summary>
            /// Nome da SCP
            /// </summary>
            [SpedCampos(3, "NOME_SCP", "C", Int16.MaxValue, 0, false)]
            public string NomeScp { get; set; }
        }

        /// <summary>
        /// REGISTRO 0150: TABELA DE CADASTRO DO PARTICIPANTE
        /// </summary>
        public class Registro0150 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0150"/>.
            /// </summary>
            public Registro0150()
            {
                Reg = "0150";
            }

            /// <summary>
            /// Código de identificação do participante no arquivo criado pela própria pessoa jurídica
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", Int16.MaxValue, 0, true)]
            public string CodPart { get; set; }

            /// <summary>
            /// Nome pessoal ou empresarial do participante
            /// </summary>
            [SpedCampos(3, "NOME", "C", Int16.MaxValue, 0, true)]
            public string Nome { get; set; }

            /// <summary>
            /// Código do país do participante
            /// </summary>
            [SpedCampos(4, "COD_PAIS", "N", 5, 0, true)]
            public string CodPais { get; set; }

            /// <summary>
            /// CNPJ do participante
            /// </summary>
            [SpedCampos(5, "CNPJ", "N", 14, 0, false)]
            public string Cnpj { get; set; }

            /// <summary>
            /// CPF do participante
            /// </summary>
            [SpedCampos(6, "CPF", "N", 11, 0, false)]
            public string Cpf { get; set; }

            /// <summary>
            /// Número de Identificação do Trabalhador, Pis, Pasep, SUS
            /// </summary>
            [SpedCampos(7, "NIT", "N", 11, 0, false)]
            public string Nit { get; set; }

            /// <summary>
            /// Sigla da unidade da federação do participante
            /// </summary>
            [SpedCampos(8, "UF", "C", 2, 0, false)]
            public string Uf { get; set; }

            /// <summary>
            /// Inscrição Estadual do participante
            /// </summary>
            [SpedCampos(9, "IE", "C", Int16.MaxValue, 0, false)]
            public string Ie { get; set; }

            /// <summary>
            /// Inscrição Estadual do participante na unidade da federação do destinatário, na condição de contribuinte substituto
            /// </summary>
            [SpedCampos(10, "IE_ST", "C", Int16.MaxValue, 0, false)]
            public string IeSt { get; set; }

            /// <summary>
            /// Código do município
            /// </summary>
            [SpedCampos(11, "COD_MUN", "N", 7, 0, false)]
            public string CodMun { get; set; }

            /// <summary>
            /// Inscrição Municipal do participante
            /// </summary>
            [SpedCampos(12, "IM", "C", Int16.MaxValue, 0, false)]
            public string Im { get; set; }

            /// <summary>
            /// Número de inscrição do participante na Suframa
            /// </summary>
            [SpedCampos(13, "SUFRAMA", "C", 9, 0, false)]
            public string Suframa { get; set; }
        }

        /// <summary>
        /// REGISTRO 0180: IDENTIFICAÇÃO DO RELACIONAMENTO COM O PARTICIPANTE
        /// </summary>
        public class Registro0180 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0180"/>.
            /// </summary>
            public Registro0180()
            {
                Reg = "0180";
            }

            /// <summary>
            /// Código do relacionamento
            /// </summary>
            [SpedCampos(2, "COD_REL", "N", 2, 0, true)]
            public Int16 CodRel { get; set; }

            /// <summary>
            /// Data do início do relacionamento
            /// </summary>
            [SpedCampos(3, "DT_INI_REL", "N", 8, 0, true)]
            public DateTime DtIniRel { get; set; }

            /// <summary>
            /// Data do término do relacionamento
            /// </summary>
            [SpedCampos(4, "DT_FIN_REL", "N", 8, 0, false)]
            public DateTime DtFinRel { get; set; }
        }

        /// <summary>
        /// REGISTRO 0990: ENCERRAMENTO DO BLOCO 0
        /// </summary>
        public class Registro0990 : RegistroBaseSped
        {
            /// <summary>
            /// Inicializa uma nova instância da classe <see cref="Registro0990"/>.
            /// </summary>
            public Registro0990()
            {
                Reg = "0990";
            }

            /// <summary>
            /// Quantidade total de linhas do Bloco 0
            /// </summary>
            [SpedCampos(2, "QTD_LIN_0", "N", Int32.MaxValue, 0, true)]
            public int QtdLin0 { get; set; }
        }
    }
}
