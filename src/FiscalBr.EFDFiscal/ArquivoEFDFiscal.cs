using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public override void Ler(string path, Encoding encoding = null)
        {
            base.Ler(path, encoding);

            LerBloco0();
            LerBloco1();
            LerBloco9();
            LerBlocoB();
            LerBlocoC();
            LerBlocoD();
            LerBlocoE();
            LerBlocoG();
            LerBlocoH();
            LerBlocoK();

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
                    case "1010": Bloco1.Reg1001.Reg1010 = (Bloco1.Registro1010)registro; break;

                    case "1100":
                        if (Bloco1.Reg1001.Reg1100s == null)
                            Bloco1.Reg1001.Reg1100s = new List<Bloco1.Registro1100>();

                        Bloco1.Reg1001.Reg1100s.Add((Bloco1.Registro1100)registro);
                        break;

                    case "1105":
                        var reg1100 = Bloco1.Reg1001.Reg1100s.Last();

                        if (reg1100.Reg1105s == null)
                            reg1100.Reg1105s = new List<Bloco1.Registro1105>();

                        reg1100.Reg1105s.Add((Bloco1.Registro1105)registro);
                        break;

                    case "1110":
                        var reg1105 = Bloco1.Reg1001.Reg1100s.Last().Reg1105s.Last();

                        if (reg1105.Reg1110s == null)
                            reg1105.Reg1110s = new List<Bloco1.Registro1110>();

                        reg1105.Reg1110s.Add((Bloco1.Registro1110)registro);
                        break;

                    case "1200":
                        if (Bloco1.Reg1001.Reg1200s == null)
                            Bloco1.Reg1001.Reg1200s = new List<Bloco1.Registro1200>();

                        Bloco1.Reg1001.Reg1200s.Add((Bloco1.Registro1200)registro);
                        break;

                    case "1210":
                        var reg1200 = Bloco1.Reg1001.Reg1200s.Last();

                        if (reg1200.Reg1210s == null)
                            reg1200.Reg1210s = new List<Bloco1.Registro1210>();

                        reg1200.Reg1210s.Add((Bloco1.Registro1210)registro);
                        break;

                    case "1250": Bloco1.Reg1001.Reg1250 = (Bloco1.Registro1250)registro; break;

                    case "1255":
                        var reg1250 = Bloco1.Reg1001.Reg1250;

                        if (reg1250.Reg1255s == null)
                            reg1250.Reg1255s = new List<Bloco1.Registro1255>();

                        reg1250.Reg1255s.Add((Bloco1.Registro1255)registro);
                        break;

                    case "1300":
                        if (Bloco1.Reg1001.Reg1300s == null)
                            Bloco1.Reg1001.Reg1300s = new List<Bloco1.Registro1300>();

                        Bloco1.Reg1001.Reg1300s.Add((Bloco1.Registro1300)registro);
                        break;

                    case "1310":
                        var reg1300 = Bloco1.Reg1001.Reg1300s.Last();

                        if (reg1300.Reg1310s == null)
                            reg1300.Reg1310s = new List<Bloco1.Registro1310>();

                        reg1300.Reg1310s.Add((Bloco1.Registro1310)registro);
                        break;

                    case "1320":
                        var reg1310 = Bloco1.Reg1001.Reg1300s.Last().Reg1310s.Last();

                        if (reg1310.Reg1320s == null)
                            reg1310.Reg1320s = new List<Bloco1.Registro1320>();

                        reg1310.Reg1320s.Add((Bloco1.Registro1320)registro);
                        break;

                    case "1350":
                        if (Bloco1.Reg1001.Reg1350s == null)
                            Bloco1.Reg1001.Reg1350s = new List<Bloco1.Registro1350>();

                        Bloco1.Reg1001.Reg1350s.Add((Bloco1.Registro1350)registro);
                        break;

                    case "1360":
                        var reg1350 = Bloco1.Reg1001.Reg1350s.Last();

                        if (reg1350.Reg1360s == null)
                            reg1350.Reg1360s = new List<Bloco1.Registro1360>();

                        reg1350.Reg1360s.Add((Bloco1.Registro1360)registro);
                        break;

                    case "1370":
                        reg1350 = Bloco1.Reg1001.Reg1350s.Last();

                        if (reg1350.Reg1370s == null)
                            reg1350.Reg1370s = new List<Bloco1.Registro1370>();

                        reg1350.Reg1370s.Add((Bloco1.Registro1370)registro);
                        break;

                    case "1390":
                        if (Bloco1.Reg1001.Reg1390s == null)
                            Bloco1.Reg1001.Reg1390s = new List<Bloco1.Registro1390>();

                        Bloco1.Reg1001.Reg1390s.Add((Bloco1.Registro1390)registro);
                        break;

                    case "1391":
                        var reg1390 = Bloco1.Reg1001.Reg1390s.Last();

                        if (reg1390.Reg1391s == null)
                            reg1390.Reg1391s = new List<Bloco1.Registro1391>();

                        reg1390.Reg1391s.Add((Bloco1.Registro1391)registro);
                        break;

                    case "1400":
                        if (Bloco1.Reg1001.Reg1400s == null)
                            Bloco1.Reg1001.Reg1400s = new List<Bloco1.Registro1400>();

                        Bloco1.Reg1001.Reg1400s.Add((Bloco1.Registro1400)registro);
                        break;

                    case "1500":
                        if (Bloco1.Reg1001.Reg1500s == null)
                            Bloco1.Reg1001.Reg1500s = new List<Bloco1.Registro1500>();

                        Bloco1.Reg1001.Reg1500s.Add((Bloco1.Registro1500)registro);
                        break;

                    case "1510":
                        var reg1500 = Bloco1.Reg1001.Reg1500s.Last();

                        if (reg1500.Reg1510s == null)
                            reg1500.Reg1510s = new List<Bloco1.Registro1510>();

                        reg1500.Reg1510s.Add((Bloco1.Registro1510)registro);
                        break;

                    case "1600":
                        if (Bloco1.Reg1001.Reg1600s == null)
                            Bloco1.Reg1001.Reg1600s = new List<Bloco1.Registro1600>();

                        Bloco1.Reg1001.Reg1600s.Add((Bloco1.Registro1600)registro);
                        break;

                    case "1700":
                        if (Bloco1.Reg1001.Reg1700s == null)
                            Bloco1.Reg1001.Reg1700s = new List<Bloco1.Registro1700>();

                        Bloco1.Reg1001.Reg1700s.Add((Bloco1.Registro1700)registro);
                        break;

                    case "1710":
                        var reg1700 = Bloco1.Reg1001.Reg1700s.Last();

                        if (reg1700.Reg1710s == null)
                            reg1700.Reg1710s = new List<Bloco1.Registro1710>();

                        reg1700.Reg1710s.Add((Bloco1.Registro1710)registro);
                        break;

                    case "1800": Bloco1.Reg1001.Reg1800 = (Bloco1.Registro1800)registro; break;

                    case "1900":
                        if (Bloco1.Reg1001.Reg1900s == null)
                            Bloco1.Reg1001.Reg1900s = new List<Bloco1.Registro1900>();

                        Bloco1.Reg1001.Reg1900s.Add((Bloco1.Registro1900)registro);
                        break;

                    case "1910":
                        var reg1900 = Bloco1.Reg1001.Reg1900s.Last();

                        if (reg1900.Reg1910s == null)
                            reg1900.Reg1910s = new List<Bloco1.Registro1910>();

                        reg1900.Reg1910s.Add((Bloco1.Registro1910)registro);
                        break;

                    case "1920":
                        var reg1910 = Bloco1.Reg1001.Reg1900s.Last().Reg1910s.Last();
                        reg1910.Reg1920 = (Bloco1.Registro1920)registro;
                        break;

                    case "1921":
                        var reg1920 = Bloco1.Reg1001.Reg1900s.Last().Reg1910s.Last().Reg1920;

                        if (reg1920.Reg1921s == null)
                            reg1920.Reg1921s = new List<Bloco1.Registro1921>();

                        reg1920.Reg1921s.Add((Bloco1.Registro1921)registro);
                        break;

                    case "1922":
                        var reg1921 = Bloco1.Reg1001.Reg1900s.Last().Reg1910s.Last().Reg1920.Reg1921s.Last();

                        if (reg1921.Reg1922s == null)
                            reg1921.Reg1922s = new List<Bloco1.Registro1922>();

                        reg1921.Reg1922s.Add((Bloco1.Registro1922)registro);
                        break;

                    case "1923":
                        reg1921 = Bloco1.Reg1001.Reg1900s.Last().Reg1910s.Last().Reg1920.Reg1921s.Last();

                        if (reg1921.Reg1922s == null)
                            reg1921.Reg1922s = new List<Bloco1.Registro1922>();

                        reg1921.Reg1922s.Add((Bloco1.Registro1922)registro);
                        break;

                    case "1925":
                        reg1920 = Bloco1.Reg1001.Reg1900s.Last().Reg1910s.Last().Reg1920;

                        if (reg1920.Reg1925s == null)
                            reg1920.Reg1925s = new List<Bloco1.Registro1925>();

                        reg1920.Reg1925s.Add((Bloco1.Registro1925)registro);
                        break;

                    case "1926":
                        reg1920 = Bloco1.Reg1001.Reg1900s.Last().Reg1910s.Last().Reg1920;

                        if (reg1920.Reg1926s == null)
                            reg1920.Reg1926s = new List<Bloco1.Registro1926>();

                        reg1920.Reg1926s.Add((Bloco1.Registro1926)registro);
                        break;

                    case "1960":
                        if (Bloco1.Reg1001.Reg1960s == null)
                            Bloco1.Reg1001.Reg1960s = new List<Bloco1.Registro1960>();

                        Bloco1.Reg1001.Reg1960s.Add((Bloco1.Registro1960)registro);
                        break;

                    case "1970":
                        if (Bloco1.Reg1001.Reg1970s == null)
                            Bloco1.Reg1001.Reg1970s = new List<Bloco1.Registro1970>();

                        Bloco1.Reg1001.Reg1970s.Add((Bloco1.Registro1970)registro);
                        break;

                    case "1975":
                        var reg1970 = Bloco1.Reg1001.Reg1970s.Last();

                        if (reg1970.Reg1975s == null)
                            reg1970.Reg1975s = new List<Bloco1.Registro1975>();

                        reg1970.Reg1975s.Add((Bloco1.Registro1975)registro);
                        break;

                    case "1980": Bloco1.Reg1001.Reg1980 = (Bloco1.Registro1980)registro; break;
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
        
        public void LerBloco9()
        {
            Bloco9 = new Bloco9();

            var niveis = new List<RegistroBaseSped>();

            for (int i = 0; i < Linhas.Count; i++)
            {
                var linha = Linhas[i];
                var registro = (RegistroBaseSped)LerCamposSped.LerCampos(linha, file: "EFDFiscal");

                switch (registro.Reg)
                {
                    case "9001": Bloco9.Reg9001 = (Bloco9.Registro9001)registro; break;

                    case "9900":
                        if (Bloco9.Reg9001.Reg9900s == null)
                            Bloco9.Reg9001.Reg9900s = new List<Bloco9.Registro9900>();

                        Bloco9.Reg9001.Reg9900s.Add((Bloco9.Registro9900)registro);
                        break;

                    case "9990": Bloco9.Reg9990 = (Bloco9.Registro9990)registro; break;
                    case "9999": Bloco9.Reg9999 = (Bloco9.Registro9999)registro; break;
                }

                var args = new SpedEventArgs()
                {
                    Linha = linha,
                    Registro = registro
                };
                AoLerLinhaRaise(this, args);
            }
        }
        
        public void LerBlocoB()
        {
            BlocoB = new BlocoB();

            var niveis = new List<RegistroBaseSped>();

            for (int i = 0; i < Linhas.Count; i++)
            {
                var linha = Linhas[i];
                var registro = (RegistroBaseSped)LerCamposSped.LerCampos(linha, file: "EFDFiscal");

                switch (registro.Reg)
                {
                    case "B001": BlocoB.RegB001 = (BlocoB.RegistroB001)registro; break;

                    case "B020":
                        if (BlocoB.RegB001.RegB020s == null)
                            BlocoB.RegB001.RegB020s = new List<BlocoB.RegistroB020>();

                        BlocoB.RegB001.RegB020s.Add((BlocoB.RegistroB020)registro);
                        break;

                    case "B025":
                        var regB020 = BlocoB.RegB001.RegB020s.Last();

                        if (regB020.RegB025 == null)
                            regB020.RegB025 = new List<BlocoB.RegistroB025>();

                        regB020.RegB025.Add((BlocoB.RegistroB025)registro);
                        break;

                    case "B030":
                        if (BlocoB.RegB001.RegB030s == null)
                            BlocoB.RegB001.RegB030s = new List<BlocoB.RegistroB030>();

                        BlocoB.RegB001.RegB030s.Add((BlocoB.RegistroB030)registro);
                        break;

                    case "B035":
                        var regB030 = BlocoB.RegB001.RegB030s.Last();

                        if (regB030.RegB035s == null)
                            regB030.RegB035s = new List<BlocoB.RegistroB035>();

                        regB030.RegB035s.Add((BlocoB.RegistroB035)registro);
                        break;

                    case "B350":
                        if (BlocoB.RegB001.RegB350s == null)
                            BlocoB.RegB001.RegB350s = new List<BlocoB.RegistroB350>();

                        BlocoB.RegB001.RegB350s.Add((BlocoB.RegistroB350)registro);
                        break;

                    case "B420":
                        if (BlocoB.RegB001.RegB420s == null)
                            BlocoB.RegB001.RegB420s = new List<BlocoB.RegistroB420>();

                        BlocoB.RegB001.RegB420s.Add((BlocoB.RegistroB420)registro);
                        break;

                    case "B440":
                        if (BlocoB.RegB001.RegB440s == null)
                            BlocoB.RegB001.RegB440s = new List<BlocoB.RegistroB440>();

                        BlocoB.RegB001.RegB440s.Add((BlocoB.RegistroB440)registro);
                        break;

                    case "B460":
                        if (BlocoB.RegB001.RegB460s == null)
                            BlocoB.RegB001.RegB460s = new List<BlocoB.RegistroB460>();

                        BlocoB.RegB001.RegB460s.Add((BlocoB.RegistroB460)registro);
                        break;

                    case "B470": BlocoB.RegB001.RegB470 = (BlocoB.RegistroB470)registro; break;
                    case "B500": BlocoB.RegB001.RegB500 = (BlocoB.RegistroB500)registro; break;

                    case "B510":
                        var regB500 = BlocoB.RegB001.RegB500;

                        if (regB500.RegB510s == null)
                            regB500.RegB510s = new List<BlocoB.RegistroB510>();

                        regB500.RegB510s.Add((BlocoB.RegistroB510)registro);
                        break;

                    case "B990": BlocoB.RegB990 = (BlocoB.RegistroB990)registro; break;
                }

                var args = new SpedEventArgs()
                {
                    Linha = linha,
                    Registro = registro
                };
                AoLerLinhaRaise(this, args);
            }
        }
        
        public void LerBlocoC()
        {
            BlocoC = new BlocoC();

            var niveis = new List<RegistroBaseSped>();

            for (int i = 0; i < Linhas.Count; i++)
            {
                var linha = Linhas[i];
                var registro = (RegistroBaseSped)LerCamposSped.LerCampos(linha, file: "EFDFiscal");

                switch (registro.Reg)
                {
                    case "C001": BlocoC.RegC001 = (BlocoC.RegistroC001)registro; break;

                    case "C100":
                        if (BlocoC.RegC001.RegC100s == null)
                            BlocoC.RegC001.RegC100s = new List<BlocoC.RegistroC100>();

                        BlocoC.RegC001.RegC100s.Add((BlocoC.RegistroC100)registro);
                        break;

                    case "C101": var regC100 = BlocoC.RegC001.RegC100s.Last(); regC100.RegC101 = (BlocoC.RegistroC101)registro; break;
                    case "C105": regC100 = BlocoC.RegC001.RegC100s.Last(); regC100.RegC105 = (BlocoC.RegistroC105)registro; break;

                    case "C110":
                        regC100 = BlocoC.RegC001.RegC100s.Last();

                        if (regC100.RegC110s == null)
                            regC100.RegC110s = new List<BlocoC.RegistroC110>();

                        regC100.RegC110s.Add((BlocoC.RegistroC110)registro);
                        break;

                    case "C111":
                        var regC110 = BlocoC.RegC001.RegC100s.Last().RegC110s.Last();

                        if (regC110.RegC111s == null)
                            regC110.RegC111s = new List<BlocoC.RegistroC111>();

                        regC110.RegC111s.Add((BlocoC.RegistroC111)registro);
                        break;

                    case "C112":
                        regC110 = BlocoC.RegC001.RegC100s.Last().RegC110s.Last();

                        if (regC110.RegC112s == null)
                            regC110.RegC112s = new List<BlocoC.RegistroC112>();

                        regC110.RegC112s.Add((BlocoC.RegistroC112)registro);
                        break;

                    case "C113":
                        regC110 = BlocoC.RegC001.RegC100s.Last().RegC110s.Last();

                        if (regC110.RegC113s == null)
                            regC110.RegC113s = new List<BlocoC.RegistroC113>();

                        regC110.RegC113s.Add((BlocoC.RegistroC113)registro);
                        break;

                    case "C114":
                        regC110 = BlocoC.RegC001.RegC100s.Last().RegC110s.Last();

                        if (regC110.RegC114s == null)
                            regC110.RegC114s = new List<BlocoC.RegistroC114>();

                        regC110.RegC114s.Add((BlocoC.RegistroC114)registro);
                        break;

                    case "C115":
                        regC110 = BlocoC.RegC001.RegC100s.Last().RegC110s.Last();

                        if (regC110.RegC115s == null)
                            regC110.RegC115s = new List<BlocoC.RegistroC115>();

                        regC110.RegC115s.Add((BlocoC.RegistroC115)registro);
                        break;

                    case "C116":
                        regC110 = BlocoC.RegC001.RegC100s.Last().RegC110s.Last();

                        if (regC110.RegC116s == null)
                            regC110.RegC116s = new List<BlocoC.RegistroC116>();

                        regC110.RegC116s.Add((BlocoC.RegistroC116)registro);
                        break;

                    case "C120":
                        regC100 = BlocoC.RegC001.RegC100s.Last();

                        if (regC100.RegC120s == null)
                            regC100.RegC120s = new List<BlocoC.RegistroC120>();

                        regC100.RegC120s.Add((BlocoC.RegistroC120)registro);
                        break;

                    case "C130": regC100 = BlocoC.RegC001.RegC100s.Last(); regC100.RegC130 = (BlocoC.RegistroC130)registro; break;
                    case "C140": regC100 = BlocoC.RegC001.RegC100s.Last(); regC100.RegC140 = (BlocoC.RegistroC140)registro; break;

                    case "C141":
                        var regC140 = BlocoC.RegC001.RegC100s.Last().RegC140;

                        if (regC140.RegC141s == null)
                            regC140.RegC141s = new List<BlocoC.RegistroC141>();

                        regC140.RegC141s.Add((BlocoC.RegistroC141)registro);
                        break;

                    case "C160": regC100 = BlocoC.RegC001.RegC100s.Last(); regC100.RegC160 = (BlocoC.RegistroC160)registro; break;

                    case "C165":
                        regC100 = BlocoC.RegC001.RegC100s.Last();

                        if (regC100.RegC165s == null)
                            regC100.RegC165s = new List<BlocoC.RegistroC165>();

                        regC100.RegC165s.Add((BlocoC.RegistroC165)registro);
                        break;

                    case "C170":
                        regC100 = BlocoC.RegC001.RegC100s.Last();
                        if (regC100.RegC170s == null)
                            regC100.RegC170s = new List<BlocoC.RegistroC170>();

                        regC100.RegC170s.Add((BlocoC.RegistroC170)registro);
                        break;

                    case "C171":
                        var regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last();
                        if (regC170.RegC171s == null)
                            regC170.RegC171s = new List<BlocoC.RegistroC171>();

                        regC170.RegC171s.Add((BlocoC.RegistroC171)registro);
                        break;

                    case "C172": regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last(); regC170.RegC172 = (BlocoC.RegistroC172)registro; break;

                    case "C173":
                        regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last();
                        if (regC170.RegC173s == null)
                            regC170.RegC173s = new List<BlocoC.RegistroC173>();

                        regC170.RegC173s.Add((BlocoC.RegistroC173)registro);
                        break;

                    case "C174":
                        regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last();
                        if (regC170.RegC174s == null)
                            regC170.RegC174s = new List<BlocoC.RegistroC174>();

                        regC170.RegC174s.Add((BlocoC.RegistroC174)registro);
                        break;

                    case "C175":
                        regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last();
                        if (regC170.RegC175s == null)
                            regC170.RegC175s = new List<BlocoC.RegistroC175>();

                        regC170.RegC175s.Add((BlocoC.RegistroC175)registro);
                        break;

                    case "C176":
                        regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last();
                        if (regC170.RegC176s == null)
                            regC170.RegC176s = new List<BlocoC.RegistroC176>();

                        regC170.RegC176s.Add((BlocoC.RegistroC176)registro);
                        break;

                    case "C177": regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last(); regC170.RegC177 = (BlocoC.RegistroC177)registro; break;
                    case "C178": regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last(); regC170.RegC178 = (BlocoC.RegistroC178)registro; break;
                    case "C179": regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last(); regC170.RegC179 = (BlocoC.RegistroC179)registro; break;
                    case "C180": regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last(); regC170.RegC180 = (BlocoC.RegistroC180)registro; break;

                    case "C181":
                        regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last();
                        if (regC170.RegC181s == null)
                            regC170.RegC181s = new List<BlocoC.RegistroC181>();

                        regC170.RegC181s.Add((BlocoC.RegistroC181)registro);
                        break;

                    case "C185":
                        regC100 = BlocoC.RegC001.RegC100s.Last();

                        if (regC100.RegC185s == null)
                            regC100.RegC185s = new List<BlocoC.RegistroC185>();

                        regC100.RegC185s.Add((BlocoC.RegistroC185)registro);
                        break;

                    case "C186":
                        regC100 = BlocoC.RegC001.RegC100s.Last();

                        if (regC100.RegC186s == null)
                            regC100.RegC186s = new List<BlocoC.RegistroC186>();

                        regC100.RegC186s.Add((BlocoC.RegistroC186)registro);
                        break;

                    case "C190":
                        regC100 = BlocoC.RegC001.RegC100s.Last();

                        if (regC100.RegC190s == null)
                            regC100.RegC190s = new List<BlocoC.RegistroC190>();

                        regC100.RegC190s.Add((BlocoC.RegistroC190)registro);
                        break;

                    case "C191": var regC190 = BlocoC.RegC001.RegC100s.Last().RegC190s.Last(); regC190.RegC191 = (BlocoC.RegistroC191)registro; break;

                    case "C195":
                        regC100 = BlocoC.RegC001.RegC100s.Last();

                        if (regC100.RegC195s == null)
                            regC100.RegC195s = new List<BlocoC.RegistroC195>();

                        regC100.RegC195s.Add((BlocoC.RegistroC195)registro);
                        break;

                    case "C197":
                        var regC195 = BlocoC.RegC001.RegC100s.Last().RegC195s.Last();

                        if (regC195.RegC197s == null)
                            regC195.RegC197s = new List<BlocoC.RegistroC197>();

                        regC195.RegC197s.Add((BlocoC.RegistroC197)registro);
                        break;

                    case "C300":
                    case "C310":
                    case "C320":
                    case "C321":
                    case "C330":
                    case "C350":
                    case "C370":
                    case "C380":
                    case "C390":
                    case "C400":
                    case "C405":
                    case "C410":
                    case "C420":
                    case "C425":
                    case "C430":
                    case "C460":
                    case "C465":
                    case "C470":
                    case "C480":
                    case "C490":
                    case "C495":
                    case "C500":
                    case "C510":
                    case "C590":

                    case "C990": BlocoC.RegC990 = (BlocoC.RegistroC990)registro; break;
                }

                var args = new SpedEventArgs()
                {
                    Linha = linha,
                    Registro = registro
                };
                AoLerLinhaRaise(this, args);
            }
        }
        
        public void LerBlocoD()
        {
            BlocoD = new BlocoD();

            var niveis = new List<RegistroBaseSped>();

            for (int i = 0; i < Linhas.Count; i++)
            {
                var linha = Linhas[i];
                var registro = (RegistroBaseSped)LerCamposSped.LerCampos(linha, file: "EFDFiscal");

                switch (registro.Reg)
                {
                    case "D001": BlocoD.RegD001 = (BlocoD.RegistroD001)registro; break;

                    case "D990": BlocoD.RegD990 = (BlocoD.RegistroD990)registro; break;
                }

                var args = new SpedEventArgs()
                {
                    Linha = linha,
                    Registro = registro
                };
                AoLerLinhaRaise(this, args);
            }
        }
        
        public void LerBlocoE()
        {
            BlocoE = new BlocoE();

            var niveis = new List<RegistroBaseSped>();

            for (int i = 0; i < Linhas.Count; i++)
            {
                var linha = Linhas[i];
                var registro = (RegistroBaseSped)LerCamposSped.LerCampos(linha, file: "EFDFiscal");

                switch (registro.Reg)
                {
                    case "E001": BlocoE.RegE001 = (BlocoE.RegistroE001)registro; break;

                    case "E990": BlocoE.RegE990 = (BlocoE.RegistroE990)registro; break;
                }

                var args = new SpedEventArgs()
                {
                    Linha = linha,
                    Registro = registro
                };
                AoLerLinhaRaise(this, args);
            }
        }
        
        public void LerBlocoG()
        {
            BlocoG = new BlocoG();

            var niveis = new List<RegistroBaseSped>();

            for (int i = 0; i < Linhas.Count; i++)
            {
                var linha = Linhas[i];
                var registro = (RegistroBaseSped)LerCamposSped.LerCampos(linha, file: "EFDFiscal");

                switch (registro.Reg)
                {
                    case "G001": BlocoG.RegG001 = (BlocoG.RegistroG001)registro; break;

                    case "G110":
                        if (BlocoG.RegG001.RegG110s == null)
                            BlocoG.RegG001.RegG110s = new List<BlocoG.RegistroG110>();

                        BlocoG.RegG001.RegG110s.Add((BlocoG.RegistroG110)registro);
                        break;

                    case "G125":
                        var regG110 = BlocoG.RegG001.RegG110s.Last();

                        if (regG110.RegG125s == null)
                            regG110.RegG125s = new List<BlocoG.RegistroG125>();

                        regG110.RegG125s.Add((BlocoG.RegistroG125)registro);
                        break;

                    case "G126":
                        var regG125 = BlocoG.RegG001.RegG110s.Last().RegG125s.Last();

                        if (regG125.RegG126s == null)
                            regG125.RegG126s = new List<BlocoG.RegistroG126>();

                        regG125.RegG126s.Add((BlocoG.RegistroG126)registro);
                        break;

                    case "G130":
                        regG125 = BlocoG.RegG001.RegG110s.Last().RegG125s.Last();
                        if (regG125.RegG130s == null)
                            regG125.RegG130s = new List<BlocoG.RegistroG130>();

                        regG125.RegG130s.Add((BlocoG.RegistroG130)registro);
                        break;

                    case "G140":
                        var regG130 = BlocoG.RegG001.RegG110s.Last().RegG125s.Last().RegG130s.Last();

                        if (regG130.RegG140s == null)
                            regG130.RegG140s = new List<BlocoG.RegistroG140>();

                        regG130.RegG140s.Add((BlocoG.RegistroG140)registro);
                        break;

                    case "G990": BlocoG.RegG990 = (BlocoG.RegistroG990)registro; break;
                }

                var args = new SpedEventArgs()
                {
                    Linha = linha,
                    Registro = registro
                };
                AoLerLinhaRaise(this, args);
            }
        }
        
        public void LerBlocoH()
        {
            BlocoH = new BlocoH();

            var niveis = new List<RegistroBaseSped>();

            for (int i = 0; i < Linhas.Count; i++)
            {
                var linha = Linhas[i];
                var registro = (RegistroBaseSped)LerCamposSped.LerCampos(linha, file: "EFDFiscal");

                switch (registro.Reg)
                {
                    case "H001": BlocoH.RegH001 = (BlocoH.RegistroH001)registro; break;

                    case "H005":
                        if (BlocoH.RegH001.RegH005s == null)
                            BlocoH.RegH001.RegH005s = new List<BlocoH.RegistroH005>();

                        BlocoH.RegH001.RegH005s.Add((BlocoH.RegistroH005)registro);
                        break;

                    case "H010":
                        var regH005 = BlocoH.RegH001.RegH005s.Last();

                        if (regH005.RegH010s == null)
                            regH005.RegH010s = new List<BlocoH.RegistroH010>();

                        regH005.RegH010s.Add((BlocoH.RegistroH010)registro);
                        break;

                    case "H020":
                        var regH010 = BlocoH.RegH001.RegH005s.Last().RegH010s.Last();

                        if (regH010.RegH020s == null)
                            regH010.RegH020s = new List<BlocoH.RegistroH020>();

                        regH010.RegH020s.Add((BlocoH.RegistroH020)registro);
                        break;

                    case "H030":
                        regH010 = BlocoH.RegH001.RegH005s.Last().RegH010s.Last();
                        regH010.RegH030 = (BlocoH.RegistroH030)registro; break;

                    case "H990": BlocoH.RegH990 = (BlocoH.RegistroH990)registro; break;
                }

                var args = new SpedEventArgs()
                {
                    Linha = linha,
                    Registro = registro
                };
                AoLerLinhaRaise(this, args);
            }
        }
        
        public void LerBlocoK()
        {
            BlocoK = new BlocoK();

            var niveis = new List<RegistroBaseSped>();

            for (int i = 0; i < Linhas.Count; i++)
            {
                var linha = Linhas[i];
                var registro = (RegistroBaseSped)LerCamposSped.LerCampos(linha, file: "EFDFiscal");

                switch (registro.Reg)
                {
                    case "K001": BlocoK.RegK001 = (BlocoK.RegistroK001)registro; break;

                    case "k990": BlocoK.RegK990 = (BlocoK.RegistroK990)registro; break;
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
                QtdLin = totalBloco0 + /* totalBloco1 + ... */ Bloco9.Reg9990.QtdLin9
            };
            #endregion
        }

        public override void GerarLinhas()
        {
            base.GerarLinhas();

            #region Bloco 0
            if (Bloco0 != null)
            {
                if (Bloco0.Reg0000 != null)
                    EscreverLinha(Bloco0.Reg0000);

                if (Bloco0.Reg0001 != null)
                {
                    EscreverLinha(Bloco0.Reg0001);

                    if (Bloco0.Reg0001.Reg0002 != null)
                        EscreverLinha(Bloco0.Reg0001.Reg0002);

                    if (Bloco0.Reg0001.Reg0005 != null)
                        EscreverLinha(Bloco0.Reg0001.Reg0005);

                    if (Bloco0.Reg0001.Reg0015s != null)
                        foreach (var reg in Bloco0.Reg0001.Reg0015s)
                            EscreverLinha(reg);

                    if (Bloco0.Reg0001.Reg0100s != null)
                    {
                        foreach (var reg in Bloco0.Reg0001.Reg0100s)
                            EscreverLinha(reg);
                    }

                    if (Bloco0.Reg0001.Reg0150s != null && Bloco0.Reg0001.Reg0150s.Any())
                    {
                        foreach (var reg in Bloco0.Reg0001.Reg0150s)
                        {
                            EscreverLinha(reg);

                            if (reg.Reg0175s != null)
                                foreach (var reg0175 in reg.Reg0175s)
                                    EscreverLinha(reg0175);
                        }
                    }

                    if (Bloco0.Reg0001.Reg0190s != null)
                    {
                        foreach (var reg in Bloco0.Reg0001.Reg0190s)
                            EscreverLinha(reg);
                    }

                    if (Bloco0.Reg0001.Reg0200s != null)
                    {
                        foreach (var reg in Bloco0.Reg0001.Reg0200s)
                        {
                            EscreverLinha(reg);

                            if (reg.Reg0205s != null)
                                foreach (var reg0205 in reg.Reg0205s)
                                    EscreverLinha(reg0205);

                            if (reg.Reg0206 != null)
                                EscreverLinha(reg.Reg0206);

                            if (reg.Reg0210s != null)
                                foreach (var reg0210 in reg.Reg0210s)
                                    EscreverLinha(reg0210);

                            if (reg.Reg0220s != null)
                                foreach (var reg0220 in reg.Reg0220s)
                                    EscreverLinha(reg0220);
                        }
                    }

                    if (Bloco0.Reg0001.Reg0300s != null)
                    {
                        foreach (var reg in Bloco0.Reg0001.Reg0300s)
                        {
                            EscreverLinha(reg);

                            if (reg.Reg0305 != null)
                                EscreverLinha(reg.Reg0305);
                        }
                    }

                    if (Bloco0.Reg0001.Reg0400s != null)
                    {
                        foreach (var reg in Bloco0.Reg0001.Reg0400s)
                            EscreverLinha(reg);
                    }

                    if (Bloco0.Reg0001.Reg0450s != null)
                    {
                        foreach (var reg in Bloco0.Reg0001.Reg0450s)
                            EscreverLinha(reg);
                    }

                    if (Bloco0.Reg0001.Reg0460s != null)
                    {
                        foreach (var reg in Bloco0.Reg0001.Reg0460s)
                            EscreverLinha(reg);
                    }

                    if (Bloco0.Reg0001.Reg0500s != null)
                    {
                        foreach (var reg in Bloco0.Reg0001.Reg0500s)
                            EscreverLinha(reg);
                    }

                    if (Bloco0.Reg0001.Reg0600s != null)
                    {
                        foreach (var reg in Bloco0.Reg0001.Reg0600s)
                            EscreverLinha(reg);
                    }
                }

                if (Bloco0.Reg0990 != null)
                    EscreverLinha(Bloco0.Reg0990);
            }
            #endregion

            //Bloco B, C, D, E, G, H, K e 1 

            #region Bloco 9
            if (Bloco9 != null)
            {
                if (Bloco9.Reg9001 != null)
                {
                    EscreverLinha(Bloco9.Reg9001);

                    if (Bloco9.Reg9001.Reg9900s != null)
                    {
                        foreach (var reg in Bloco9.Reg9001.Reg9900s)
                            EscreverLinha(reg);
                    }
                }

                if (Bloco9.Reg9990 != null)
                    EscreverLinha(Bloco9.Reg9990);

                if (Bloco9.Reg9999 != null)
                    EscreverLinha(Bloco9.Reg9999);
            }
            #endregion            
        }
    }
}
