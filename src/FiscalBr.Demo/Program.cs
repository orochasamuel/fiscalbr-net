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
            sped.AoProcessarLinha += Sped_AoLerLinha;
            sped.Ler(@"c:\temp\sped.txt", Encoding.GetEncoding("iso-8859-1"));

            Console.WriteLine("Arquivo lido!");
            Console.Read();

            //Manuesar, ex: adicionar bloco H

            sped.GerarLinhas();

            sped.CalcularBloco9();

            sped.Escrever(@"c:\temp\sped3.txt");
            Console.WriteLine("Arquivo salvo!");

            Console.Read();
        }

        private static void Sped_AoLerLinha(object sender, Common.Sped.SpedEventArgs e)
        {
            Console.WriteLine(e.Linha);
        }

    }
}
