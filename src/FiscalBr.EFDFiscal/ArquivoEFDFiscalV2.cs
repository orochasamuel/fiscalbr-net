using FiscalBr.Common;
using FiscalBr.Common.Sped;

namespace FiscalBr.EFDFiscal
{
    public sealed class ArquivoEFDFiscalV2 : ArquivoSpedV2
    {
        public Bloco0 Bloco0 { get; set; }
        public Bloco1 Bloco1 { get; set; }
        public Bloco9 Bloco9 { get; set; }
        public BlocoB BlocoB { get; set; }
        public BlocoC BlocoC { get; set; }
        public BlocoD BlocoD { get; set; }
        public BlocoE BlocoE { get; set; }
        public BlocoG BlocoG { get; set; }
        public BlocoH BlocoH { get; set; }
        public BlocoK BlocoK { get; set; }

        public ArquivoEFDFiscalV2(
            VersaoLeiauteSped versaoLeiaute = VersaoLeiauteSped.V17
            ) : base(LeiauteArquivoSped.EFDFiscal, versaoLeiaute)
        {
        }

//        public ArquivoEFDFiscalV2(
//    CodigoVersaoLeiaute versaoLeiaute,
//       string nomeSoftwareHouse = "",
//    LeiauteArquivoSped arquivoSped = LeiauteArquivoSped.EFDFiscal
//    ) : base(versaoLeiaute, arquivoSped, nomeSoftwareHouse)
//        {
//        }

//        public ArquivoEFDFiscalV2(
//CodigoVersaoLeiaute versaoLeiaute,
//string nomeSoftwareHouse = "",
//string cnpjSoftwareHouse = "",
//LeiauteArquivoSped arquivoSped = LeiauteArquivoSped.EFDFiscal
//) : base(versaoLeiaute, arquivoSped, nomeSoftwareHouse, cnpjSoftwareHouse)
//        {
//        }
    }
}
