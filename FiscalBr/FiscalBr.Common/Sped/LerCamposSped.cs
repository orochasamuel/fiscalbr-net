using System;
using System.Collections.Generic;
using System.IO;

namespace FiscalBr.Common
{
    public static class LerCamposSped
    {
        public static List<string> DecodeSpedFile(string filePath)
        {
            var list = new List<string>();

            if (File.Exists(filePath) == false)
                throw new Exception("Falha ao encontrar arquivo.");

            using (var file = new StreamReader(filePath))
            {
                string actualLine;
                while ((actualLine = file.ReadLine()) != null)
                {
                    list.Add(actualLine);
                }
            }

            return list;
        }

        public static string ReturnPosition(string text, int position)
        {
            for (var i = 0; i < position - 1; i++)
            {
                var initialIndex = text.IndexOf("|", StringComparison.Ordinal);
                var finalIndex = text.IndexOf("|", initialIndex + 1, StringComparison.Ordinal);

                text = text.Remove(initialIndex, (finalIndex - initialIndex));
            }

            var firstPipeIndexBlock = text.IndexOf("|", StringComparison.Ordinal);
            var secondPipeIndexBlock =
                text.IndexOf("|", firstPipeIndexBlock + 1, StringComparison.Ordinal);

            return text.Substring(firstPipeIndexBlock + 1, secondPipeIndexBlock - 1).ToStringSafe();
        }
    }
}
