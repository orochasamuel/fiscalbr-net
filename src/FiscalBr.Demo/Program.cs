using FiscalBr.EFDFiscal;
using Newtonsoft.Json;
using System;

namespace FiscalBr.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var sped = new ArquivoEFDFiscal();
            sped.AoLerLinha += Sped_AoLerLinha;
            sped.Ler(@"c:\temp\sped.txt");
            
            sped.CalcularBloco9();

            string json = JsonConvert.SerializeObject(sped.Bloco9);

            Console.Read();
        }

        private static void Sped_AoLerLinha(object sender, Common.Sped.SpedEventArgs e)
        {
            Console.WriteLine(e.Linha);
        }

    }
}
