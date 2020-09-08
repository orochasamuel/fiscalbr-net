using FiscalBr.Common;
using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDFiscal
{
    /// <summary>
    ///     BLOCO B: ESCRITURAÇÃO E APURAÇÃO DO ISS
    /// </summary>
    public class BlocoB
    {
        /// <summary>
        ///     REGISTRO C001: ABERTURA DO BLOCO C
        /// </summary>
        public class RegistroB001 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB001" />.
            /// </summary>
            public RegistroB001()
            {
                Reg = "B001";
            }

            /// <summary>
            ///     Indicador de movimento: 0 - Bloco com dados informados; 1 - Bloco sem dados informados.
            /// </summary>
            [SpedCampos(2, "IND_MOV", "N", 1, 0, true)]
            public IndMovimento IndMov { get; set; }            
        }

        /// <summary>
        ///     REGISTRO B990: ENCERRAMENTO DO BLOCO B
        /// </summary>
        public class RegistroB990 : RegistroBaseSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroB990" />.
            /// </summary>
            public RegistroB990()
            {
                Reg = "B990";
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco B
            /// </summary>
            [SpedCampos(3, "QTD_LIN_B", "N", int.MaxValue, 0, true)]
            public int QtdLinB { get; set; }
        }
    }
}
