using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiscalBr.EFDFiscal
{
    public sealed class ArquivoEFDFiscal : ArquivoSped
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

        public override void Processar()
        {
            base.Processar();

            LerBloco0();
            //LerBloco9();
            //....
        }

        public void LerBloco0()
        {
            Bloco0 = new Bloco0();

            var niveis = new List<RegistroBaseSped>();

            for (int i = 0; i < Linhas.Count; i++)
            {
                var linha = Linhas[i];

                var registro = (RegistroBaseSped)LerCamposSped.LerCampos(linha, file: "EFDFiscal");

                switch (registro.Reg)
                {
                    case "0000": Bloco0.Reg0000 = (Bloco0.Registro0000)registro; break;
                    case "0001": Bloco0.Reg0001 = (Bloco0.Registro0001)registro; break;

                    case "0002": Bloco0.Reg0001.Reg0002 = (Bloco0.Registro0002)registro; break;
                    case "0005": Bloco0.Reg0001.Reg0005 = (Bloco0.Registro0005)registro; break;

                    case "0015":
                        if (Bloco0.Reg0001.Reg0015s == null)
                            Bloco0.Reg0001.Reg0015s = new List<Bloco0.Registro0015>();

                        Bloco0.Reg0001.Reg0015s.Add((Bloco0.Registro0015)registro);
                        break;

                    case "0100": Bloco0.Reg0001.Reg0005 = (Bloco0.Registro0005)registro; break;
                    case "0150":
                        if (Bloco0.Reg0001.Reg0150s == null)
                            Bloco0.Reg0001.Reg0150s = new List<Bloco0.Registro0150>();

                        Bloco0.Reg0001.Reg0150s.Add((Bloco0.Registro0150)registro);
                        break;

                    case "0175":
                        var registropai = Bloco0.Reg0001.Reg0150s.Last();

                        if (registropai.Reg0175s == null)
                            registropai.Reg0175s = new List<Bloco0.Registro0175>();

                        registropai.Reg0175s.Add((Bloco0.Registro0175)registro);
                        break;

                    case "0190":
                        if (Bloco0.Reg0001.Reg0190s == null)
                            Bloco0.Reg0001.Reg0190s = new List<Bloco0.Registro0190>();

                        Bloco0.Reg0001.Reg0190s.Add((Bloco0.Registro0190)registro);
                        break;

                    //outros campos...

                    case "0990": Bloco0.Reg0990 = (Bloco0.Registro0990)registro; break;
                }

                var args = new SpedEventArgs()
                {
                    Linha = linha,
                    Registro = registro
                };
                AoLerLinhaRaise(this, args);
            }
        }




    }
}
