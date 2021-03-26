using System.Collections.Generic;
using System.Linq;

using FiscalBr.Common.Sped;

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

        public override void Ler(string path)
        {
            base.Ler(path);

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

                    case "0100":

                        if (Bloco0.Reg0001.Reg0100s == null)
                            Bloco0.Reg0001.Reg0100s = new List<Bloco0.Registro0100>();

                        Bloco0.Reg0001.Reg0100s.Add((Bloco0.Registro0100)registro);
                        break;

                    case "0150":
                        if (Bloco0.Reg0001.Reg0150s == null)
                            Bloco0.Reg0001.Reg0150s = new List<Bloco0.Registro0150>();

                        Bloco0.Reg0001.Reg0150s.Add((Bloco0.Registro0150)registro);
                        break;

                    case "0175":
                        var reg0150 = Bloco0.Reg0001.Reg0150s.Last();

                        if (reg0150.Reg0175s == null)
                            reg0150.Reg0175s = new List<Bloco0.Registro0175>();

                        reg0150.Reg0175s.Add((Bloco0.Registro0175)registro);
                        break;

                    case "0190":
                        if (Bloco0.Reg0001.Reg0190s == null)
                            Bloco0.Reg0001.Reg0190s = new List<Bloco0.Registro0190>();

                        Bloco0.Reg0001.Reg0190s.Add((Bloco0.Registro0190)registro);
                        break;

                    case "0200":
                        if (Bloco0.Reg0001.Reg0200s == null)
                            Bloco0.Reg0001.Reg0200s = new List<Bloco0.Registro0200>();

                        Bloco0.Reg0001.Reg0200s.Add((Bloco0.Registro0200)registro);
                        break;

                    case "0205":
                        var reg0200 = Bloco0.Reg0001.Reg0200s.Last();

                        if (reg0200.Reg0205s == null)
                            reg0200.Reg0205s = new List<Bloco0.Registro0205>();

                        reg0200.Reg0205s.Add((Bloco0.Registro0205)registro);
                        break;

                    case "0206":
                        reg0200 = Bloco0.Reg0001.Reg0200s.Last();
                        reg0200.Reg0206 = (Bloco0.Registro0206)registro;
                        break;

                    case "0210":
                        reg0200 = Bloco0.Reg0001.Reg0200s.Last();

                        if (reg0200.Reg0210s == null)
                            reg0200.Reg0210s = new List<Bloco0.Registro0210>();

                        reg0200.Reg0210s.Add((Bloco0.Registro0210)registro);
                        break;

                    case "0220":
                        reg0200 = Bloco0.Reg0001.Reg0200s.Last();

                        if (reg0200.Reg0220s == null)
                            reg0200.Reg0220s = new List<Bloco0.Registro0220>();

                        reg0200.Reg0220s.Add((Bloco0.Registro0220)registro);
                        break;

                    case "0300":
                        if (Bloco0.Reg0001.Reg0300s == null)
                            Bloco0.Reg0001.Reg0300s = new List<Bloco0.Registro0300>();

                        Bloco0.Reg0001.Reg0300s.Add((Bloco0.Registro0300)registro);
                        break;

                    case "00305":
                        var reg0300 = Bloco0.Reg0001.Reg0300s.Last();
                        reg0300.Reg0305 = (Bloco0.Registro0305)registro;
                        break;

                    case "0400":
                        if (Bloco0.Reg0001.Reg0400s == null)
                            Bloco0.Reg0001.Reg0400s = new List<Bloco0.Registro0400>();

                        Bloco0.Reg0001.Reg0400s.Add((Bloco0.Registro0400)registro);
                        break;

                    case "0450":
                        if (Bloco0.Reg0001.Reg0450s == null)
                            Bloco0.Reg0001.Reg0450s = new List<Bloco0.Registro0450>();

                        Bloco0.Reg0001.Reg0450s.Add((Bloco0.Registro0450)registro);
                        break;

                    case "0460":
                        if (Bloco0.Reg0001.Reg0460s == null)
                            Bloco0.Reg0001.Reg0460s = new List<Bloco0.Registro0460>();

                        Bloco0.Reg0001.Reg0460s.Add((Bloco0.Registro0460)registro);
                        break;

                    case "0500":
                        if (Bloco0.Reg0001.Reg0500s == null)
                            Bloco0.Reg0001.Reg0500s = new List<Bloco0.Registro0500>();

                        Bloco0.Reg0001.Reg0500s.Add((Bloco0.Registro0500)registro);
                        break;

                    case "0600":
                        if (Bloco0.Reg0001.Reg0600s == null)
                            Bloco0.Reg0001.Reg0600s = new List<Bloco0.Registro0600>();

                        Bloco0.Reg0001.Reg0600s.Add((Bloco0.Registro0600)registro);
                        break;

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
        public void LerBloco1()
        {
            Bloco1 = new Bloco1();

            var niveis = new List<RegistroBaseSped>();

            for (int i = 0; i < Linhas.Count; i++)
            {
                var linha = Linhas[i];
                var registro = (RegistroBaseSped)LerCamposSped.LerCampos(linha, file: "EFDFiscal");

                switch (registro.Reg)
                {
                    case "1001": Bloco1.Reg1001 = (Bloco1.Registro1001)registro; break;






                    case "1990": Bloco1.Reg1990 = (Bloco1.Registro1990)registro; break;
                }

                var args = new SpedEventArgs()
                {
                    Linha = linha,
                    Registro = registro
                };
                AoLerLinhaRaise(this, args);
            }
        }

        public override void CalcularBloco9()
        {
            base.CalcularBloco9();

            Bloco9 = new Bloco9();
            Bloco9.Reg9001 = new Bloco9.Registro9001() { IndMov = Common.IndMovimento.BlocoComDados };
            Bloco9.Reg9001.Reg9900s = new List<Bloco9.Registro9900>();

            int totalBloco0 = 0; //, totalBloco1 = 0,...

            #region Bloco 0
            if (Bloco0.Reg0000 != null)
            {
                Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0000", QtdRegBlc = 1 });
                totalBloco0++;
            }

            if (Bloco0.Reg0001 != null)
            {
                Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0001", QtdRegBlc = 1 });
                totalBloco0++;

                if (Bloco0.Reg0001.Reg0002 != null)
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0002", QtdRegBlc = 1 });
                    totalBloco0++;
                }

                if (Bloco0.Reg0001.Reg0005 != null)
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0005", QtdRegBlc = 1 });
                    totalBloco0++;
                }

                if (Bloco0.Reg0001.Reg0015s != null && Bloco0.Reg0001.Reg0015s.Any())
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0015", QtdRegBlc = Bloco0.Reg0001.Reg0015s.Count });
                    totalBloco0 += Bloco0.Reg0001.Reg0015s.Count;
                }

                if (Bloco0.Reg0001.Reg0100s != null && Bloco0.Reg0001.Reg0100s.Any())
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0100", QtdRegBlc = Bloco0.Reg0001.Reg0100s.Count });
                    totalBloco0 += Bloco0.Reg0001.Reg0100s.Count;
                }

                if (Bloco0.Reg0001.Reg0150s != null && Bloco0.Reg0001.Reg0150s.Any())
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0150", QtdRegBlc = Bloco0.Reg0001.Reg0150s.Count });
                    totalBloco0 += Bloco0.Reg0001.Reg0150s.Count;

                    int quantidade = Bloco0.Reg0001.Reg0150s.Sum(r => r.Reg0175s == null ? 0 : r.Reg0175s.Count());
                    if (quantidade > 0)
                        Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "01750", QtdRegBlc = quantidade });
                    totalBloco0 += quantidade;
                }

                if (Bloco0.Reg0001.Reg0190s != null && Bloco0.Reg0001.Reg0190s.Any())
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0190", QtdRegBlc = Bloco0.Reg0001.Reg0190s.Count });
                    totalBloco0 += Bloco0.Reg0001.Reg0190s.Count;
                }

                if (Bloco0.Reg0001.Reg0200s != null && Bloco0.Reg0001.Reg0200s.Any())
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0200", QtdRegBlc = Bloco0.Reg0001.Reg0200s.Count });
                    totalBloco0 += Bloco0.Reg0001.Reg0200s.Count;

                    int quantidade = Bloco0.Reg0001.Reg0200s.Sum(r => r.Reg0205s == null ? 0 : r.Reg0205s.Count());
                    if (quantidade > 0)
                        Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0205", QtdRegBlc = quantidade });
                    totalBloco0 += quantidade;

                    quantidade = Bloco0.Reg0001.Reg0200s.Sum(r => r.Reg0206 == null ? 0 : 1);
                    if (quantidade > 0)
                        Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0206", QtdRegBlc = quantidade });
                    totalBloco0 += quantidade;

                    quantidade = Bloco0.Reg0001.Reg0200s.Sum(r => r.Reg0210s == null ? 0 : r.Reg0210s.Count());
                    if (quantidade > 0)
                        Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0210", QtdRegBlc = quantidade });
                    totalBloco0 += quantidade;

                    quantidade = Bloco0.Reg0001.Reg0200s.Sum(r => r.Reg0220s == null ? 0 : r.Reg0220s.Count());
                    if (quantidade > 0)
                        Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0220", QtdRegBlc = quantidade });
                    totalBloco0 += quantidade;
                }

                if (Bloco0.Reg0001.Reg0300s != null && Bloco0.Reg0001.Reg0300s.Any())
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0300", QtdRegBlc = Bloco0.Reg0001.Reg0300s.Count });
                    totalBloco0 += Bloco0.Reg0001.Reg0300s.Count;

                    int quantidade = Bloco0.Reg0001.Reg0300s.Sum(r => r.Reg0305 == null ? 0 : 1);
                    if (quantidade > 0)
                        Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0305", QtdRegBlc = quantidade });
                    totalBloco0 += quantidade;
                }

                if (Bloco0.Reg0001.Reg0400s != null && Bloco0.Reg0001.Reg0400s.Any())
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0400", QtdRegBlc = Bloco0.Reg0001.Reg0400s.Count });
                    totalBloco0 += Bloco0.Reg0001.Reg0400s.Count;
                }

                if (Bloco0.Reg0001.Reg0450s != null && Bloco0.Reg0001.Reg0450s.Any())
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0450", QtdRegBlc = Bloco0.Reg0001.Reg0450s.Count });
                    totalBloco0 += Bloco0.Reg0001.Reg0450s.Count;
                }

                if (Bloco0.Reg0001.Reg0460s != null && Bloco0.Reg0001.Reg0460s.Any())
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0460", QtdRegBlc = Bloco0.Reg0001.Reg0460s.Count });
                    totalBloco0 += Bloco0.Reg0001.Reg0460s.Count;
                }

                if (Bloco0.Reg0001.Reg0500s != null && Bloco0.Reg0001.Reg0500s.Any())
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0500", QtdRegBlc = Bloco0.Reg0001.Reg0500s.Count });
                    totalBloco0 += Bloco0.Reg0001.Reg0500s.Count;
                }

                if (Bloco0.Reg0001.Reg0600s != null && Bloco0.Reg0001.Reg0600s.Any())
                {
                    Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0600", QtdRegBlc = Bloco0.Reg0001.Reg0600s.Count });
                    totalBloco0 += Bloco0.Reg0001.Reg0600s.Count;
                }

                Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900() { RegBlc = "0990", QtdRegBlc = 1 });
                totalBloco0++;
            }

            Bloco0.Reg0990 = new Bloco0.Registro0990() { QtdLin0 = totalBloco0 };
            #endregion

            //Bloco B, C, D, E, G, H, K e 1 

            #region Bloco 9
            Bloco9.Reg9990 = new Bloco9.Registro9990()
            {
                QtdLin9 = Bloco9.Reg9001.Reg9900s.Count + 3 /* 9001, 9900 e 9990  */
            };

            Bloco9.Reg9999 = new Bloco9.Registro9999()
            {
                QtdLin = totalBloco0 + /* totalBloco1 + ... */ Bloco9.Reg9990.QtdLin9 + 1
            };
            #endregion
        }

        public override void Escrever(string path)
        {
            base.Escrever(path);

            //EscreverLinha(Bloco0.Reg0000);
        }

        public void EscreverBloco0()
        {

        }
    }
}
