using FiscalBr.Common;
using FiscalBr.Common.Sped;
using FiscalBr.Common.Sped.Enums;
using FiscalBr.Common.Sped.Interfaces;
using FiscalBr.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FiscalBr.EFDContribuicoes
{
    public sealed class ArquivoEFDContribuicoesV2 : ArquivoSpedV2
    {
        public Bloco0 Bloco0 { get; set; }
        public Bloco1 Bloco1 { get; set; }
        public Bloco9 Bloco9 { get; set; }
        public BlocoA BlocoA { get; set; }
        public BlocoC BlocoC { get; set; }
        public BlocoD BlocoD { get; set; }
        public BlocoF BlocoF { get; set; }
        public BlocoI BlocoI { get; set; }
        public BlocoM BlocoM { get; set; }
        public BlocoP BlocoP { get; set; }

        public ArquivoEFDContribuicoesV2(
            VersaoLeiauteSped versaoLeiaute = VersaoLeiauteSped.V6
            ) : base(LeiauteArquivoSped.EFDContrib, versaoLeiaute)
        {
        }

        public override IRegistroSped LerLinha(string linha, LeiauteArquivoSped tipo, VersaoLeiauteSped? versao)
        {
            throw new NotImplementedException();
        }
    }
}
