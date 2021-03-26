using FiscalBr.EFDFiscal;
using Newtonsoft.Json;
using System;
using System.Text;

namespace FiscalBr.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var sped = new ArquivoEFDFiscal();
            sped.AoLerLinha += Sped_AoLerLinha;
            sped.Ler(@"c:\temp\sped.txt", Encoding.GetEncoding("iso-8859-1"));
            
            sped.CalcularBloco9();

            sped.GerarLinhas();

            sped.Escrever(@"c:\temp\sped2.txt", Encoding.UTF8);

            Console.Read();
        }

        private static void Sped_AoLerLinha(object sender, Common.Sped.SpedEventArgs e)
        {
            Console.WriteLine(e.Linha);
        }

    }
}
