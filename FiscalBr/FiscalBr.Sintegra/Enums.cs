using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiscalBr.Sintegra
{
    public enum CodEstruturaArquivo
    {
        /// <summary>
        /// Estrutura conforme Convênio ICMS 57/95, na versão estabalecidade pelo Convênio ICMS 31/99 e com as alterações promovidas até o Convênio ICMS 30/02.
        /// </summary>
        Cod1 = 1,
        /// <summary>
        /// Estrutura conforme Convênio ICMS 57/95, na versão estabelecida pelo Convênio ICMS 69/02 e com as alterações promovidas pelo Convênio ICMS 142/02.
        /// </summary>
        Cod2 = 2,
        /// <summary>
        /// Estrutura conforme Convênio ICMS 57/95, com as alterações promovidas pelo Convênio ICMS 76/03.
        /// </summary>
        Cod3 = 3
    }

    public enum CodNaturezaOperacoes
    {
        /// <summary>
        /// Interestaduais somente operações sujeitas ao regime de Substituição Tributária
        /// </summary>
        Cod1 = 1,
        /// <summary>
        /// Interestaduais - operações com ou sem Substituição Tributária
        /// </summary>
        Cod2 = 2,
        /// <summary>
        /// Totalidade das operações do informante
        /// </summary>
        Cod3 = 3
    }

    public enum CodFinalidadeArquivo
    {
        /// <summary>
        /// Normal
        /// </summary>
        Cod1 = 1,
        /// <summary>
        /// Retificação total
        /// </summary>
        Cod2 = 2,
        /// <summary>
        /// Retificação aditiva (vedado)
        /// </summary>
        Cod3 = 3,
        /// <summary>
        /// Desfazimento
        /// </summary>
        Cod5 = 5
    }
}
