using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace FiscalBr.Common
{
    public static class Validar
    {
        /// <summary>
        /// Verifica a consistência da inscrição estadual
        /// </summary>
        /// <param name="vInsc">Número da I.E.</param>
        /// <param name="vUF">UF da I.E.</param>
        /// <returns>0 - Válido; 1 - Inválido</returns>
        //[DllImport("DllInscE32.dll")]
        //public static extern int ConsisteInscricaoEstadual(string vInsc, string vUF);

        /// <summary>
        /// Valida a inscrição estadual por UF
        /// </summary>
        /// <param name="pInscr"></param>
        /// <param name="pUF"></param>
        /// <returns>true - Válido; false - Inválido</returns>
        public static bool InscEstadual(string pInscr, string pUF)
        {
            bool retorno = false;

            string strBase, strBase2, strOrigem, strDigito1, strDigito2;
            int intPos, intValor, intResto, intNumero, intPeso, intDig;
            int intSoma = 0;

            strBase = "";
            strBase2 = "";
            strOrigem = "";

            if ((pInscr.Trim().ToUpper() == "ISENTO"))
                return true;

            for (intPos = 1; intPos <= pInscr.Trim().Length; intPos++)
            {
                if (
                    (("0123456789P".IndexOf(pInscr.Substring((intPos - 1), 1), 0,
                        System.StringComparison.OrdinalIgnoreCase) + 1) > 0))
                    strOrigem = (strOrigem + pInscr.Substring((intPos - 1), 1));
            }

            switch (pUF.ToUpper())
            {
                #region AC

                case "AC":
                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    if (((strBase.Substring(0, 2) == "01") && (strBase.Substring(2, 2) != "00")))
                    {
                        intSoma = 0;
                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);

                        strDigito1 =
                            ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                                (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                        {
                            retorno = true;
                        }
                    }
                    break;

                #endregion AC

                #region AL

                case "AL":
                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    if ((strBase.Substring(0, 2) == "24"))
                    {
                        intSoma = 0;
                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intSoma = (intSoma * 10);
                        intResto = (intSoma % 11);

                        strDigito1 =
                            ((intResto == 10) ? "0" : Convert.ToString(intResto)).Substring(
                                (((intResto == 10) ? "0" : Convert.ToString(intResto)).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);
                        if ((strBase2 == strOrigem))
                        {
                            retorno = true;
                        }
                    }
                    break;

                #endregion AL

                #region AM

                case "AM":
                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;
                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }
                    if ((intSoma < 11))
                    {
                        strDigito1 =
                            Convert.ToString((11 - intSoma)).Substring((Convert.ToString((11 - intSoma)).Length - 1));
                    }
                    else
                    {
                        intResto = (intSoma % 11);
                        strDigito1 =
                            ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                                (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    }

                    strBase2 = (strBase.Substring(0, 8) + strDigito1);
                    if ((strBase2 == strOrigem))
                    {
                        retorno = true;
                    }
                    break;

                #endregion AM

                #region AP

                case "AP":
                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intPeso = 0;
                    intDig = 0;
                    if ((strBase.Substring(0, 2) == "03"))
                    {
                        intNumero = int.Parse(strBase.Substring(0, 8));
                        if (((intNumero >= 3000001) && (intNumero <= 3017000)))
                        {
                            intPeso = 5;
                            intDig = 0;
                        }
                        else if (((intNumero >= 3017001) && (intNumero <= 3019022)))
                        {
                            intPeso = 9;
                            intDig = 1;
                        }
                        else if ((intNumero >= 3019023))
                        {
                            intPeso = 0;
                            intDig = 0;
                        }

                        intSoma = intPeso;
                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        intValor = (11 - intResto);
                        if ((intValor == 10))
                        {
                            intValor = 0;
                        }
                        else if ((intValor == 11))
                        {
                            intValor = intDig;
                        }

                        strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);
                        if ((strBase2 == strOrigem))
                        {
                            retorno = true;
                        }
                    }
                    break;

                #endregion AP

                #region BA

                case "BA":
                    strBase = (strOrigem.Trim() + "00000000").Substring(0, 8);
                    if ((("0123458".IndexOf(strBase.Substring(0, 1), 0, System.StringComparison.OrdinalIgnoreCase) + 1) >
                         0))
                    {
                        intSoma = 0;
                        for (intPos = 1; (intPos <= 6); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (8 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 10);

                        strDigito2 =
                            ((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Substring(
                                (((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 6) + strDigito2);

                        intSoma = 0;
                        for (intPos = 1; (intPos <= 7); intPos++)
                        {
                            intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                            intValor = (intValor * (9 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 10);

                        strDigito1 =
                            ((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Substring(
                                (((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Length - 1));
                    }
                    else
                    {
                        intSoma = 0;
                        for (intPos = 1; (intPos <= 6); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (8 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);

                        strDigito2 =
                            ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                                (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 6) + strDigito2);

                        intSoma = 0;
                        for (intPos = 1; (intPos <= 7); intPos++)
                        {
                            intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                            intValor = (intValor * (9 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);

                        strDigito1 =
                            ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                                (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    }

                    strBase2 = (strBase.Substring(0, 6) + (strDigito1 + strDigito2));
                    if ((strBase2 == strOrigem))
                    {
                        retorno = true;
                    }
                    break;

                #endregion BA

                #region CE

                case "CE":
                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    intSoma = 0;
                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    intValor = (11 - intResto);
                    if ((intValor > 9))
                    {
                        intValor = 0;
                    }

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);
                    if ((strBase2 == strOrigem))
                    {
                        retorno = true;
                    }
                    break;

                #endregion CE

                #region DF

                case "DF":
                    strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);
                    if ((strBase.Substring(0, 3) == "073"))
                    {
                        intSoma = 0;
                        intPeso = 2;
                        for (intPos = 11; (intPos <= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);
                            if ((intPeso > 9))
                            {
                                intPeso = 2;
                            }
                        }

                        intResto = (intSoma % 11);

                        strDigito1 =
                            ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                                (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 11) + strDigito1);

                        intSoma = 0;
                        intPeso = 2;
                        for (intPos = 12; (intPos <= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);
                            if ((intPeso > 9))
                            {
                                intPeso = 2;
                            }
                        }

                        intResto = (intSoma % 11);

                        strDigito2 =
                            ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                                (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 12) + strDigito2);
                        if ((strBase2 == strOrigem))
                        {
                            retorno = true;
                        }
                    }
                    break;

                #endregion DF

                #region ES

                case "ES":
                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    intSoma = 0;
                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);

                    strDigito1 =
                        ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                            (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                    {
                        retorno = true;
                    }
                    break;

                #endregion ES

                #region GO

                case "GO":
                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((("10,11,15".IndexOf(strBase.Substring(0, 2), 0, System.StringComparison.OrdinalIgnoreCase) + 1) >
                         0))
                    {
                        intSoma = 0;
                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);

                        if ((intResto == 0))
                        {
                            strDigito1 = "0";
                        }
                        else if ((intResto == 1))
                        {
                            intNumero = int.Parse(strBase.Substring(0, 8));

                            strDigito1 = (((intNumero >= 10103105)
                                           && (intNumero <= 10119997))
                                ? "1"
                                : "0").Substring(((((intNumero >= 10103105)
                                                    && (intNumero <= 10119997))
                                    ? "1"
                                    : "0").Length - 1));
                        }
                        else
                        {
                            strDigito1 =
                                Convert.ToString((11 - intResto))
                                    .Substring((Convert.ToString((11 - intResto)).Length - 1));
                        }

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);
                        if ((strBase2 == strOrigem))
                        {
                            retorno = true;
                        }
                    }
                    break;

                #endregion GO

                #region MA

                case "MA":

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "12"))

                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)

                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            intValor = (intValor * (10 - intPos));

                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);

                        strDigito1 =
                            ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                                (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))

                        {
                            retorno = true;
                        }
                    }

                    break;

                #endregion MA

                #region MT

                case "MT":

                    strBase = (strOrigem.Trim() + "0000000000").Substring(0, 10);

                    intSoma = 0;

                    intPeso = 2;

                    for (intPos = 10; (intPos <= 1); intPos = (intPos + -1))

                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                        intValor = (intValor * intPeso);

                        intSoma = (intSoma + intValor);

                        intPeso = (intPeso + 1);

                        if ((intPeso > 9))

                        {
                            intPeso = 2;
                        }
                    }

                    intResto = (intSoma % 11);

                    strDigito1 =
                        ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                            (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                    strBase2 = (strBase.Substring(0, 10) + strDigito1);

                    if ((strBase2 == strOrigem))

                    {
                        retorno = true;
                    }

                    break;

                #endregion MT

                #region MS

                case "MS":

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "28"))

                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)

                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            intValor = (intValor * (10 - intPos));

                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);

                        strDigito1 =
                            ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                                (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))

                        {
                            retorno = true;
                        }
                    }

                    break;

                #endregion MS

                #region MG

                case "MG":

                    strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);

                    strBase2 = (strBase.Substring(0, 3) + ("0" + strBase.Substring(3, 8)));

                    intNumero = 2;

                    for (intPos = 1; (intPos <= 12); intPos++)

                    {
                        intValor = int.Parse(strBase2.Substring((intPos - 1), 1));

                        intNumero = ((intNumero == 2) ? 1 : 2);

                        intValor = (intValor * intNumero);

                        if ((intValor > 9))

                        {
                            strDigito1 = string.Format("00", intValor);

                            intValor = (int.Parse(strDigito1.Substring(0, 1)) +
                                        int.Parse(strDigito1.Substring((strDigito1.Length - 1))));
                        }

                        intSoma = (intSoma + intValor);
                    }

                    intValor = intSoma;

                    while ((string.Format("000", intValor).Substring((string.Format("000", intValor).Length - 1)) != "0"))

                    {
                        intValor = (intValor + 1);

                        strDigito1 =
                            string.Format("00", (intValor - intSoma))
                                .Substring((string.Format("00", (intValor - intSoma)).Length - 1));

                        strBase2 = (strBase.Substring(0, 11) + strDigito1);

                        intSoma = 0;

                        intPeso = 2;

                        for (intPos = 12; (intPos <= 1); intPos = (intPos + -1))

                        {
                            intValor = int.Parse(strBase2.Substring((intPos - 1), 1));

                            intValor = (intValor * intPeso);

                            intSoma = (intSoma + intValor);

                            intPeso = (intPeso + 1);

                            if ((intPeso > 11))

                            {
                                intPeso = 2;
                            }
                        }

                        intResto = (intSoma % 11);

                        strDigito2 =
                            ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                                (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase2 + strDigito2);

                        if ((strBase2 == strOrigem))

                        {
                            retorno = true;
                        }
                    }

                    break;

                #endregion MG

                #region PA

                case "PA":

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "15"))

                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)

                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            intValor = (intValor * (10 - intPos));

                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);

                        strDigito1 =
                            ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                                (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))

                        {
                            retorno = true;
                        }
                    }

                    break;

                #endregion PA

                #region PB

                case "PB":

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)

                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                        intValor = (intValor * (10 - intPos));

                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);

                    intValor = (11 - intResto);

                    if ((intValor > 9))

                    {
                        intValor = 0;
                    }

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));

                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))

                    {
                        retorno = true;
                    }

                    break;

                #endregion PB

                #region PE

                case "PE":

                    strBase = (strOrigem.Trim() + "00000000000000").Substring(0, 14);

                    intSoma = 0;

                    intPeso = 2;

                    for (intPos = 13; (intPos <= 1); intPos = (intPos + -1))

                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                        intValor = (intValor * intPeso);

                        intSoma = (intSoma + intValor);

                        intPeso = (intPeso + 1);

                        if ((intPeso > 9))

                        {
                            intPeso = 2;
                        }
                    }

                    intResto = (intSoma % 11);

                    intValor = (11 - intResto);

                    if ((intValor > 9))

                    {
                        intValor = (intValor - 10);
                    }

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));

                    strBase2 = (strBase.Substring(0, 13) + strDigito1);

                    if ((strBase2 == strOrigem))

                    {
                        retorno = true;
                    }

                    break;

                #endregion PE

                #region PI

                case "PI":

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)

                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                        intValor = (intValor * (10 - intPos));

                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);

                    strDigito1 =
                        ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                            (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))

                    {
                        retorno = true;
                    }

                    break;

                #endregion PI

                #region PR

                case "PR":

                    strBase = (strOrigem.Trim() + "0000000000").Substring(0, 10);

                    intSoma = 0;

                    intPeso = 2;

                    for (intPos = 8; (intPos <= 1); intPos = (intPos + -1))

                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                        intValor = (intValor * intPeso);

                        intSoma = (intSoma + intValor);

                        intPeso = (intPeso + 1);

                        if ((intPeso > 7))

                        {
                            intPeso = 2;
                        }
                    }

                    intResto = (intSoma % 11);

                    strDigito1 =
                        ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                            (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    intSoma = 0;

                    intPeso = 2;

                    for (intPos = 9; (intPos <= 1); intPos = (intPos + -1))

                    {
                        intValor = int.Parse(strBase2.Substring((intPos - 1), 1));

                        intValor = (intValor * intPeso);

                        intSoma = (intSoma + intValor);

                        intPeso = (intPeso + 1);

                        if ((intPeso > 7))

                        {
                            intPeso = 2;
                        }
                    }

                    intResto = (intSoma % 11);

                    strDigito2 =
                        ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                            (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                    strBase2 = (strBase2 + strDigito2);

                    if ((strBase2 == strOrigem))

                    {
                        retorno = true;
                    }

                    break;

                #endregion PR

                #region RJ

                case "RJ":

                    strBase = (strOrigem.Trim() + "00000000").Substring(0, 8);

                    intSoma = 0;

                    intPeso = 2;

                    for (intPos = 7; (intPos <= 1); intPos = (intPos + -1))

                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                        intValor = (intValor * intPeso);

                        intSoma = (intSoma + intValor);

                        intPeso = (intPeso + 1);

                        if ((intPeso > 7))

                        {
                            intPeso = 2;
                        }
                    }

                    intResto = (intSoma % 11);

                    strDigito1 =
                        ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                            (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                    strBase2 = (strBase.Substring(0, 7) + strDigito1);

                    if ((strBase2 == strOrigem))

                    {
                        retorno = true;
                    }

                    break;

                #endregion RJ

                #region RN

                case "RN":

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "20"))

                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)

                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            intValor = (intValor * (10 - intPos));

                            intSoma = (intSoma + intValor);
                        }

                        intSoma = (intSoma * 10);

                        intResto = (intSoma % 11);

                        strDigito1 =
                            ((intResto > 9) ? "0" : Convert.ToString(intResto)).Substring(
                                (((intResto > 9) ? "0" : Convert.ToString(intResto)).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))

                        {
                            retorno = true;
                        }
                    }

                    break;

                #endregion RN

                #region RO

                case "RO":

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    strBase2 = strBase.Substring(3, 5);

                    intSoma = 0;

                    for (intPos = 1; (intPos <= 5); intPos++)

                    {
                        intValor = int.Parse(strBase2.Substring((intPos - 1), 1));

                        intValor = (intValor * (7 - intPos));

                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);

                    intValor = (11 - intResto);

                    if ((intValor > 9))

                    {
                        intValor = (intValor - 10);
                    }

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));

                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))

                    {
                        retorno = true;
                    }

                    break;

                #endregion RO

                #region RR

                case "RR":

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "24"))

                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)

                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            intValor = (intValor * (10 - intPos));

                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 9);

                        strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))

                        {
                            retorno = true;
                        }
                    }

                    break;

                #endregion RR

                #region RS

                case "RS":

                    strBase = (strOrigem.Trim() + "0000000000").Substring(0, 10);

                    intNumero = int.Parse(strBase.Substring(0, 3));

                    if (((intNumero > 0)
                         && (intNumero < 468)))

                    {
                        intSoma = 0;

                        intPeso = 2;

                        for (intPos = 9; (intPos <= 1); intPos = (intPos + -1))

                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            intValor = (intValor * intPeso);

                            intSoma = (intSoma + intValor);

                            intPeso = (intPeso + 1);

                            if ((intPeso > 9))

                            {
                                intPeso = 2;
                            }
                        }

                        intResto = (intSoma % 11);

                        intValor = (11 - intResto);

                        if ((intValor > 9))

                        {
                            intValor = 0;
                        }

                        strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));

                        strBase2 = (strBase.Substring(0, 9) + strDigito1);

                        if ((strBase2 == strOrigem))

                        {
                            retorno = true;
                        }
                    }

                    break;

                #endregion RS

                #region SC

                case "SC":

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)

                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                        intValor = (intValor * (10 - intPos));

                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);

                    strDigito1 =
                        ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                            (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))

                    {
                        retorno = true;
                    }

                    break;

                #endregion SC

                #region SE

                case "SE":

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)

                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                        intValor = (intValor * (10 - intPos));

                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);

                    intValor = (11 - intResto);

                    if ((intValor > 9))

                    {
                        intValor = 0;
                    }

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));

                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))

                    {
                        retorno = true;
                    }

                    break;

                #endregion SE

                #region SP

                case "SP":

                    if ((strOrigem.Substring(0, 1) == "P"))

                    {
                        strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);

                        strBase2 = strBase.Substring(1, 8);

                        intSoma = 0;

                        intPeso = 1;

                        for (intPos = 1; (intPos <= 8); intPos++)

                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            intValor = (intValor * intPeso);

                            intSoma = (intSoma + intValor);

                            intPeso = (intPeso + 1);

                            if ((intPeso == 2))

                            {
                                intPeso = 3;
                            }

                            if ((intPeso == 9))

                            {
                                intPeso = 10;
                            }
                        }

                        intResto = (intSoma % 11);

                        strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));

                        strBase2 = (strBase.Substring(0, 8)
                                    + (strDigito1 + strBase.Substring(10, 3)));
                    }

                    else

                    {
                        strBase = (strOrigem.Trim() + "000000000000").Substring(0, 12);

                        intSoma = 0;

                        intPeso = 1;

                        for (intPos = 1; (intPos <= 8); intPos++)

                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            intValor = (intValor * intPeso);

                            intSoma = (intSoma + intValor);

                            intPeso = (intPeso + 1);

                            if ((intPeso == 2))

                            {
                                intPeso = 3;
                            }

                            if ((intPeso == 9))

                            {
                                intPeso = 10;
                            }
                        }

                        intResto = (intSoma % 11);

                        strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));

                        strBase2 = (strBase.Substring(0, 8)
                                    + (strDigito1 + strBase.Substring(9, 2)));

                        intSoma = 0;

                        intPeso = 2;

                        for (intPos = 11; (intPos <= 1); intPos = (intPos + -1))

                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            intValor = (intValor * intPeso);

                            intSoma = (intSoma + intValor);

                            intPeso = (intPeso + 1);

                            if ((intPeso > 10))

                            {
                                intPeso = 2;
                            }
                        }

                        intResto = (intSoma % 11);

                        strDigito2 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));

                        strBase2 = (strBase2 + strDigito2);
                    }

                    if ((strBase2 == strOrigem))

                    {
                        retorno = true;
                    }

                    break;

                #endregion SP

                #region TO

                case "TO":

                    strBase = (strOrigem.Trim() + "00000000000").Substring(0, 11);

                    if ((("01,02,03,99".IndexOf(strBase.Substring(2, 2), 0, System.StringComparison.OrdinalIgnoreCase) +
                          1)
                         > 0))

                    {
                        strBase2 = (strBase.Substring(0, 2) + strBase.Substring(4, 6));

                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)

                        {
                            intValor = int.Parse(strBase2.Substring((intPos - 1), 1));

                            intValor = (intValor * (10 - intPos));

                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);

                        strDigito1 =
                            ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring(
                                (((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 10) + strDigito1);

                        if ((strBase2 == strOrigem))

                        {
                            retorno = true;
                        }
                    }
                    break;

                    #endregion TO
            }
            return retorno;
        }
    }
}
