using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;

namespace FiscalBr.EFDContribuicoes
{
    /// <summary>
    ///     BLOCO 9: CONTROLE E ENCERRAMENTO DO ARQUIVO DIGITAL
    /// </summary>
    public class Bloco9
    {
        /// <summary>
        ///     REGISTRO 9001: ABERTURA DO BLOCO 9
        /// </summary>
        public class Registro9001 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro9001" />.
            /// </summary>
            public Registro9001()
            {
                Reg = "9001";
            }

            /// <summary>
            ///     0 - Bloco com dados informados; 1 - Bloco sem dados informados.
            /// </summary>
            [SpedCampos(2, "IND_MOV", "N", 1, 0, true)]
            public IndMovimento IndMov { get; set; }
        }

        /// <summary>
        ///     REGISTRO 9900: REGISTRO DO ARQUIVO
        /// </summary>
        public class Registro9900 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro9900" />.
            /// </summary>
            public Registro9900()
            {
                Reg = "9900";
            }

            /// <summary>
            ///     Registro que será totalizado no próximo campo.
            /// </summary>
            [SpedCampos(2, "REG_BLC", "C", 4, 0, true)]
            public string RegBlc { get; set; }

            /// <summary>
            ///     Total de registros do tipo informado no campo anterior.
            /// </summary>
            [SpedCampos(3, "QTD_REG_BLC", "N", int.MaxValue, 0, true)]
            public int QtdRegBlc { get; set; }
        }

        /// <summary>
        ///     REGISTRO 9990: ENCERRAMENTO DO BLOCO 9
        /// </summary>
        public class Registro9990 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro9990" />.
            /// </summary>
            public Registro9990()
            {
                Reg = "9990";
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco 9.
            /// </summary>
            [SpedCampos(2, "QTD_LIN_9", "N", int.MaxValue, 0, true)]
            public int QtdLin9 { get; set; }
        }

        /// <summary>
        ///     REGISTRO 9999: ENCERRAMENTO DO ARQUIVO DIGITAL
        /// </summary>
        public class Registro9999 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="Registro9999" />.
            /// </summary>
            public Registro9999()
            {
                Reg = "9999";
            }

            /// <summary>
            ///     Quantidade total de linhas do arquivo digital.
            /// </summary>
            [SpedCampos(2, "QTD_LIN", "N", int.MaxValue, 0, true)]
            public int QtdLin { get; set; }
        }
    }
}
