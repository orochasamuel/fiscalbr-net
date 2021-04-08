using System;
using System.Collections;
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

        #region Leitura
        public override void Ler(string path, Encoding encoding = null)
        {
            base.Ler(path, encoding);

            foreach (var linha in Linhas)
            {
                var registro = (RegistroBaseSped)LerCamposSped.LerCampos(linha, file: "EFDFiscal");

                var args = new SpedEventArgs()
                {
                    Linha = linha,
                    Registro = registro
                };
                AoProcessarLinhaRaise(this, args);

                if (linha.StartsWith("|0"))
                    LerBloco0(registro);
                else if (linha.StartsWith("|1"))
                    LerBloco1(registro);
                else if (linha.StartsWith("|9"))
                    LerBloco9(registro);
                else if (linha.StartsWith("|B"))
                    LerBlocoB(registro);
                else if (linha.StartsWith("|C"))
                    LerBlocoC(registro);
                else if (linha.StartsWith("|D"))
                    LerBlocoD(registro);
                else if (linha.StartsWith("|E"))
                    LerBlocoE(registro);
                else if (linha.StartsWith("|G"))
                    LerBlocoG(registro);
                else if (linha.StartsWith("|H"))
                    LerBlocoH(registro);
                else if (linha.StartsWith("|K"))
                    LerBlocoK(registro);
                else
                    break;
            }
        }

        private void LerBloco0(RegistroBaseSped registro)
        {
            if (Bloco0 == null)
                Bloco0 = new Bloco0();

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
        }

        private void LerBloco1(RegistroBaseSped registro)
        {
            if (Bloco1 == null)
                Bloco1 = new Bloco1();

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
        }

        private void LerBloco9(RegistroBaseSped registro)
        {
            if (Bloco9 == null)
                Bloco9 = new Bloco9();

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
        }

        private void LerBlocoB(RegistroBaseSped registro)
        {
            if (BlocoB == null)
                BlocoB = new BlocoB();

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
        }

        private void LerBlocoC(RegistroBaseSped registro)
        {
            if (BlocoC == null)
                BlocoC = new BlocoC();

            switch (registro.Reg)
            {
                case "C001": BlocoC.RegC001 = (BlocoC.RegistroC001)registro; break;

                #region C100 e filhos
                case "C100":
                    if (BlocoC.RegC001.RegC100s == null)
                        BlocoC.RegC001.RegC100s = new List<BlocoC.RegistroC100>();

                    BlocoC.RegC001.RegC100s.Add((BlocoC.RegistroC100)registro);
                    break;

                case "C101":
                    var regC100 = BlocoC.RegC001.RegC100s.Last();
                    regC100.RegC101 = (BlocoC.RegistroC101)registro;
                    break;

                case "C105":
                    regC100 = BlocoC.RegC001.RegC100s.Last();
                    regC100.RegC105 = (BlocoC.RegistroC105)registro; break;

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

                case "C130":
                    regC100 = BlocoC.RegC001.RegC100s.Last();
                    regC100.RegC130 = (BlocoC.RegistroC130)registro;
                    break;

                case "C140":
                    regC100 = BlocoC.RegC001.RegC100s.Last();
                    regC100.RegC140 = (BlocoC.RegistroC140)registro;
                    break;

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

                case "C172":
                    regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last();
                    regC170.RegC172 = (BlocoC.RegistroC172)registro;
                    break;

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

                case "C177":
                    regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last();
                    regC170.RegC177 = (BlocoC.RegistroC177)registro;
                    break;

                case "C178":
                    regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last();
                    regC170.RegC178 = (BlocoC.RegistroC178)registro;
                    break;

                case "C179":
                    regC170 =
                        BlocoC.RegC001.RegC100s.Last().RegC170s.Last();
                    regC170.RegC179 = (BlocoC.RegistroC179)registro;
                    break;

                case "C180":
                    regC170 = BlocoC.RegC001.RegC100s.Last().RegC170s.Last();
                    regC170.RegC180 = (BlocoC.RegistroC180)registro;
                    break;

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

                case "C191":
                    var regC190 = BlocoC.RegC001.RegC100s.Last().RegC190s.Last();
                    regC190.RegC191 = (BlocoC.RegistroC191)registro;
                    break;

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

                #endregion

                case "C300":
                    if (BlocoC.RegC001.RegC300s == null)
                        BlocoC.RegC001.RegC300s = new List<BlocoC.RegistroC300>();

                    BlocoC.RegC001.RegC300s.Add((BlocoC.RegistroC300)registro);
                    break;

                case "C310":
                    var regC300 = BlocoC.RegC001.RegC300s.Last();

                    if (regC300.RegC310s == null)
                        regC300.RegC310s = new List<BlocoC.RegistroC310>();

                    regC300.RegC310s.Add((BlocoC.RegistroC310)registro);
                    break;

                case "C320":
                    regC300 = BlocoC.RegC001.RegC300s.Last();

                    if (regC300.RegC320s == null)
                        regC300.RegC320s = new List<BlocoC.RegistroC320>();

                    regC300.RegC320s.Add((BlocoC.RegistroC320)registro);
                    break;

                case "C321":
                    var regC320 = BlocoC.RegC001.RegC300s.Last().RegC320s.Last();

                    if (regC320.RegC321s == null)
                        regC320.RegC321s = new List<BlocoC.RegistroC321>();

                    regC320.RegC321s.Add((BlocoC.RegistroC321)registro);
                    break;

                case "C330":
                    var regC321 = BlocoC.RegC001.RegC300s.Last().RegC320s.Last().RegC321s.Last();
                    regC321.RegC330 = (BlocoC.RegistroC330)registro;
                    break;

                case "C350":
                    if (BlocoC.RegC001.RegC350s == null)
                        BlocoC.RegC001.RegC350s = new List<BlocoC.RegistroC350>();

                    BlocoC.RegC001.RegC350s.Add((BlocoC.RegistroC350)registro);
                    break;

                case "C370":
                    var regC350 = BlocoC.RegC001.RegC350s.Last();

                    if (regC350.RegC370s == null)
                        regC350.RegC370s = new List<BlocoC.RegistroC370>();

                    regC350.RegC370s.Add((BlocoC.RegistroC370)registro);
                    break;

                case "C380":
                    var regC370 = BlocoC.RegC001.RegC350s.Last().RegC370s.Last();
                    regC370.RegC380 = (BlocoC.RegistroC380)registro;
                    break;

                case "C390":
                    regC350 = BlocoC.RegC001.RegC350s.Last();

                    if (regC350.RegC390s == null)
                        regC350.RegC390s = new List<BlocoC.RegistroC390>();

                    regC350.RegC390s.Add((BlocoC.RegistroC390)registro);
                    break;

                case "C400":
                    if (BlocoC.RegC001.RegC400s == null)
                        BlocoC.RegC001.RegC400s = new List<BlocoC.RegistroC400>();
                    BlocoC.RegC001.RegC400s.Add((BlocoC.RegistroC400)registro);
                    break;

                case "C405":
                    var regC400 = BlocoC.RegC001.RegC400s.Last();

                    if (regC400.RegC405s == null)
                        regC400.RegC405s = new List<BlocoC.RegistroC405>();

                    regC400.RegC405s.Add((BlocoC.RegistroC405)registro);
                    break;

                case "C410":
                    var regC405 = BlocoC.RegC001.RegC400s.Last().RegC405s.Last();
                    regC405.RegC410 = (BlocoC.RegistroC410)registro;
                    break;

                case "C420":
                    regC405 = BlocoC.RegC001.RegC400s.Last().RegC405s.Last();

                    if (regC405.RegC420s == null)
                        regC405.RegC420s = new List<BlocoC.RegistroC420>();

                    regC405.RegC420s.Add((BlocoC.RegistroC420)registro);
                    break;

                case "C425":
                    var regC420 = BlocoC.RegC001.RegC400s.Last().RegC405s.Last().RegC420s.Last();

                    if (regC420.RegC425s == null)
                        regC420.RegC425s = new List<BlocoC.RegistroC425>();

                    regC420.RegC425s.Add((BlocoC.RegistroC425)registro);
                    break;

                case "C430":
                    var regC425 = BlocoC.RegC001.RegC400s.Last().RegC405s.Last().RegC420s.Last().RegC425s.Last();

                    if (regC425.RegC430 == null)
                        regC425.RegC430 = new List<BlocoC.RegistroC430>();

                    regC425.RegC430.Add((BlocoC.RegistroC430)registro);
                    break;

                case "C460":
                    regC405 = BlocoC.RegC001.RegC400s.Last().RegC405s.Last();

                    if (regC405.RegC460s == null)
                        regC405.RegC460s = new List<BlocoC.RegistroC460>();

                    regC405.RegC460s.Add((BlocoC.RegistroC460)registro);
                    break;

                case "C465":
                    var regC460 = BlocoC.RegC001.RegC400s.Last().RegC405s.Last().RegC460s.Last();
                    regC460.RegC465 = (BlocoC.RegistroC465)registro;
                    break;

                case "C470":
                    regC460 = BlocoC.RegC001.RegC400s.Last().RegC405s.Last().RegC460s.Last();

                    if (regC460.RegC470s == null)
                        regC460.RegC470s = new List<BlocoC.RegistroC470>();

                    regC460.RegC470s.Add((BlocoC.RegistroC470)registro);
                    break;

                case "C480":
                    var regC470 = BlocoC.RegC001.RegC400s.Last().RegC405s.Last().RegC460s.Last().RegC470s.Last();
                    regC470.RegC480 = (BlocoC.RegistroC480)registro;
                    break;

                case "C490":
                    regC405 = BlocoC.RegC001.RegC400s.Last().RegC405s.Last();

                    if (regC405.RegC490s == null)
                        regC405.RegC490s = new List<BlocoC.RegistroC490>();

                    regC405.RegC490s.Add((BlocoC.RegistroC490)registro);
                    break;

                case "C495":
                    if (BlocoC.RegC001.RegC495s == null)
                        BlocoC.RegC001.RegC495s = new List<BlocoC.RegistroC495>();

                    BlocoC.RegC001.RegC495s.Add((BlocoC.RegistroC495)registro);
                    break;

                case "C500":
                    if (BlocoC.RegC001.RegC500s == null)
                        BlocoC.RegC001.RegC500s = new List<BlocoC.RegistroC500>();
                    BlocoC.RegC001.RegC500s.Add((BlocoC.RegistroC500)registro);
                    break;

                case "C510":
                    var regC500 = BlocoC.RegC001.RegC500s.Last();

                    if (regC500.RegC510s == null)
                        regC500.RegC510s = new List<BlocoC.RegistroC510>();

                    regC500.RegC510s.Add((BlocoC.RegistroC510)registro);
                    break;

                case "C590":
                    regC500 = BlocoC.RegC001.RegC500s.Last();

                    if (regC500.RegC590s == null)
                        regC500.RegC590s = new List<BlocoC.RegistroC590>();

                    regC500.RegC590s.Add((BlocoC.RegistroC590)registro);
                    break;

                case "C591":
                    var regC590 = BlocoC.RegC001.RegC500s.Last().RegC590s.Last();
                    regC590.RegC591 = (BlocoC.RegistroC591)registro;
                    break;

                case "C595":
                    regC500 = BlocoC.RegC001.RegC500s.Last();

                    if (regC500.RegC595s == null)
                        regC500.RegC595s = new List<BlocoC.RegistroC595>();

                    regC500.RegC595s.Add((BlocoC.RegistroC595)registro);
                    break;

                case "C597":
                    var regC595 = BlocoC.RegC001.RegC500s.Last().RegC595s.Last();

                    if (regC595.RegC597s == null)
                        regC595.RegC597s = new List<BlocoC.RegistroC597>();

                    regC595.RegC597s.Add((BlocoC.RegistroC597)registro);
                    break;

                case "C600":
                    if (BlocoC.RegC001.RegC600s == null)
                        BlocoC.RegC001.RegC600s = new List<BlocoC.RegistroC600>();

                    BlocoC.RegC001.RegC600s.Add((BlocoC.RegistroC600)registro);
                    break;

                case "C601":
                    var regC600 = BlocoC.RegC001.RegC600s.Last();

                    if (regC600.RegC601s == null)
                        regC600.RegC601s = new List<BlocoC.RegistroC601>();

                    regC600.RegC601s.Add((BlocoC.RegistroC601)registro);
                    break;

                case "C610":
                    regC600 = BlocoC.RegC001.RegC600s.Last();

                    if (regC600.RegC610s == null)
                        regC600.RegC610s = new List<BlocoC.RegistroC610>();

                    regC600.RegC610s.Add((BlocoC.RegistroC610)registro);
                    break;

                case "C690":
                    regC600 = BlocoC.RegC001.RegC600s.Last();

                    if (regC600.RegC690s == null)
                        regC600.RegC690s = new List<BlocoC.RegistroC690>();

                    regC600.RegC690s.Add((BlocoC.RegistroC690)registro);
                    break;

                case "C700":
                    if (BlocoC.RegC001.RegC700s == null)
                        BlocoC.RegC001.RegC700s = new List<BlocoC.RegistroC700>();
                    BlocoC.RegC001.RegC700s.Add((BlocoC.RegistroC700)registro);
                    break;

                case "C790":
                    var regC700 = BlocoC.RegC001.RegC700s.Last();

                    if (regC700.RegC790s == null)
                        regC700.RegC790s = new List<BlocoC.RegistroC790>();

                    regC700.RegC790s.Add((BlocoC.RegistroC790)registro);
                    break;

                case "C791":
                    var regC790 = BlocoC.RegC001.RegC700s.Last().RegC790s.Last();

                    if (regC790.RegC791s == null)
                        regC790.RegC791s = new List<BlocoC.RegistroC791>();

                    regC790.RegC791s.Add((BlocoC.RegistroC791)registro);
                    break;

                case "C800":
                    if (BlocoC.RegC001.RegC800s == null)
                        BlocoC.RegC001.RegC800s = new List<BlocoC.RegistroC800>();
                    BlocoC.RegC001.RegC800s.Add((BlocoC.RegistroC800)registro);
                    break;

                case "C810":
                    var regC800 = BlocoC.RegC001.RegC800s.Last();

                    if (regC800.RegC810s == null)
                        regC800.RegC810s = new List<BlocoC.RegistroC810>();

                    regC800.RegC810s.Add((BlocoC.RegistroC810)registro);
                    break;

                case "C815":
                    var regC810 = BlocoC.RegC001.RegC800s.Last().RegC810s.Last();
                    regC810.RegC815s = (BlocoC.RegistroC815)registro;
                    break;

                case "C850":
                    regC800 = BlocoC.RegC001.RegC800s.Last();

                    if (regC800.RegC850s == null)
                        regC800.RegC850s = new List<BlocoC.RegistroC850>();

                    regC800.RegC850s.Add((BlocoC.RegistroC850)registro);
                    break;

                case "C860":
                    if (BlocoC.RegC001.RegC860s == null)
                        BlocoC.RegC001.RegC860s = new List<BlocoC.RegistroC860>();
                    BlocoC.RegC001.RegC860s.Add((BlocoC.RegistroC860)registro);
                    break;

                case "C870":
                    var regC860 = BlocoC.RegC001.RegC860s.Last();

                    if (regC860.RegC870s == null)
                        regC860.RegC870s = new List<BlocoC.RegistroC870>();

                    regC860.RegC870s.Add((BlocoC.RegistroC870)registro);
                    break;

                case "C880":
                    var regC870 = BlocoC.RegC001.RegC860s.Last().RegC870s.Last();
                    regC870.RegC880 = (BlocoC.RegistroC880)registro;
                    break;

                case "C890":
                    regC860 = BlocoC.RegC001.RegC860s.Last();

                    if (regC860.RegC890s == null)
                        regC860.RegC890s = new List<BlocoC.RegistroC890>();

                    regC860.RegC890s.Add((BlocoC.RegistroC890)registro);
                    break;

                case "C990": BlocoC.RegC990 = (BlocoC.RegistroC990)registro; break;
            }
        }

        private void LerBlocoD(RegistroBaseSped registro)
        {
            if (BlocoD == null)
                BlocoD = new BlocoD();

            switch (registro.Reg)
            {
                case "D001": BlocoD.RegD001 = (BlocoD.RegistroD001)registro; break;

                case "D100":
                    if (BlocoD.RegD001.RegD100s == null)
                        BlocoD.RegD001.RegD100s = new List<BlocoD.RegistroD100>();

                    BlocoD.RegD001.RegD100s.Add((BlocoD.RegistroD100)registro);
                    break;

                case "D101": BlocoD.RegD001.RegD100s.Last().RegD101 = (BlocoD.RegistroD101)registro; break;

                case "D110":
                    var regD100 = BlocoD.RegD001.RegD100s.Last();

                    if (regD100.RegD110s == null)
                        regD100.RegD110s = new List<BlocoD.RegistroD110>();

                    regD100.RegD110s.Add((BlocoD.RegistroD110)registro);
                    break;

                case "D120":
                    var regD110 = BlocoD.RegD001.RegD100s.Last().RegD110s.Last();

                    if (regD110.RegD120s == null)
                        regD110.RegD120s = new List<BlocoD.RegistroD120>();

                    regD110.RegD120s.Add((BlocoD.RegistroD120)registro);
                    break;

                case "D130":
                    regD100 = BlocoD.RegD001.RegD100s.Last();

                    if (regD100.RegD130s == null)
                        regD100.RegD130s = new List<BlocoD.RegistroD130>();

                    regD100.RegD130s.Add((BlocoD.RegistroD130)registro);
                    break;

                case "D140":
                    regD100 = BlocoD.RegD001.RegD100s.Last();
                    regD100.RegD140 = (BlocoD.RegistroD140)registro;
                    break;

                case "D150":
                    regD100 = BlocoD.RegD001.RegD100s.Last();
                    regD100.RegD150 = (BlocoD.RegistroD150)registro;
                    break;

                case "D160":
                    regD100 = BlocoD.RegD001.RegD100s.Last();

                    if (regD100.RegD160s == null)
                        regD100.RegD160s = new List<BlocoD.RegistroD160>();

                    regD100.RegD160s.Add((BlocoD.RegistroD160)registro);
                    break;

                case "D161":
                    var regD160 = BlocoD.RegD001.RegD100s.Last().RegD160s.Last();
                    regD160.RegD161 = (BlocoD.RegistroD161)registro;
                    break;

                case "D162":
                    regD160 = BlocoD.RegD001.RegD100s.Last().RegD160s.Last();

                    if (regD160.RegD162s == null)
                        regD160.RegD162s = new List<BlocoD.RegistroD162>();

                    regD160.RegD162s.Add((BlocoD.RegistroD162)registro);
                    break;

                case "D170":
                    regD100 = BlocoD.RegD001.RegD100s.Last();
                    regD100.RegD170 = (BlocoD.RegistroD170)registro;
                    break;

                case "D180":
                    regD100 = BlocoD.RegD001.RegD100s.Last();

                    if (regD100.RegD180s == null)
                        regD100.RegD180s = new List<BlocoD.RegistroD180>();

                    regD100.RegD180s.Add((BlocoD.RegistroD180)registro);
                    break;

                case "D190":
                    regD100 = BlocoD.RegD001.RegD100s.Last();

                    if (regD100.RegD190s == null)
                        regD100.RegD190s = new List<BlocoD.RegistroD190>();

                    regD100.RegD190s.Add((BlocoD.RegistroD190)registro);
                    break;

                case "D195":
                    regD100 = BlocoD.RegD001.RegD100s.Last();

                    if (regD100.RegD195s == null)
                        regD100.RegD195s = new List<BlocoD.RegistroD195>();

                    regD100.RegD195s.Add((BlocoD.RegistroD195)registro);
                    break;

                case "D197":
                    var regD195 = BlocoD.RegD001.RegD100s.Last().RegD195s.Last();

                    if (regD195.RegD197s == null)
                        regD195.RegD197s = new List<BlocoD.RegistroD197>();

                    regD195.RegD197s.Add((BlocoD.RegistroD197)registro);
                    break;

                case "D300":
                    if (BlocoD.RegD001.RegD300s == null)
                        BlocoD.RegD001.RegD300s = new List<BlocoD.RegistroD300>();

                    BlocoD.RegD001.RegD300s.Add((BlocoD.RegistroD300)registro);
                    break;

                case "D301":
                    var regD300 = BlocoD.RegD001.RegD300s.Last();

                    if (regD300.RegD301s == null)
                        regD300.RegD301s = new List<BlocoD.RegistroD301>();

                    regD300.RegD301s.Add((BlocoD.RegistroD301)registro);
                    break;

                case "D310":
                    regD300 = BlocoD.RegD001.RegD300s.Last();

                    if (regD300.RegD310s == null)
                        regD300.RegD310s = new List<BlocoD.RegistroD310>();

                    regD300.RegD310s.Add((BlocoD.RegistroD310)registro);
                    break;

                case "D350":
                    if (BlocoD.RegD001.RegD350s == null)
                        BlocoD.RegD001.RegD350s = new List<BlocoD.RegistroD350>();
                    BlocoD.RegD001.RegD350s.Add((BlocoD.RegistroD350)registro);
                    break;

                case "D355":
                    var regD350 = BlocoD.RegD001.RegD350s.Last();

                    if (regD350.RegD355s == null)
                        regD350.RegD355s = new List<BlocoD.RegistroD355>();

                    regD350.RegD355s.Add((BlocoD.RegistroD355)registro);
                    break;

                case "D360":
                    var regD355 = BlocoD.RegD001.RegD350s.Last().RegD355s.Last();
                    regD355.RegD360s = (BlocoD.RegistroD360)registro;
                    break;

                case "D365":
                    regD355 = BlocoD.RegD001.RegD350s.Last().RegD355s.Last();

                    if (regD355.RegD365s == null)
                        regD355.RegD365s = new List<BlocoD.RegistroD365>();

                    regD355.RegD365s.Add((BlocoD.RegistroD365)registro);
                    break;

                case "D370":
                    var regD365 = BlocoD.RegD001.RegD350s.Last().RegD355s.Last().RegD365s.Last();

                    if (regD365.RegD370s == null)
                        regD365.RegD370s = new List<BlocoD.RegistroD370>();

                    regD365.RegD370s.Add((BlocoD.RegistroD370)registro);
                    break;

                case "D390":
                    regD355 = BlocoD.RegD001.RegD350s.Last().RegD355s.Last();

                    if (regD355.RegD390s == null)
                        regD355.RegD390s = new List<BlocoD.RegistroD390>();

                    regD355.RegD390s.Add((BlocoD.RegistroD390)registro);
                    break;

                case "D400":
                    if (BlocoD.RegD001.RegD400s == null)
                        BlocoD.RegD001.RegD400s = new List<BlocoD.RegistroD400>();

                    BlocoD.RegD001.RegD400s.Add((BlocoD.RegistroD400)registro);
                    break;

                case "D410":
                    var regD400 = BlocoD.RegD001.RegD400s.Last();

                    if (regD400.RegD410s == null)
                        regD400.RegD410s = new List<BlocoD.RegistroD410>();

                    regD400.RegD410s.Add((BlocoD.RegistroD410)registro);
                    break;

                case "D411":
                    var regD410 = BlocoD.RegD001.RegD400s.Last().RegD410s.Last();

                    if (regD410.RegD411s == null)
                        regD410.RegD411s = new List<BlocoD.RegistroD411>();

                    regD410.RegD411s.Add((BlocoD.RegistroD411)registro);
                    break;

                case "D420":
                    regD400 = BlocoD.RegD001.RegD400s.Last();

                    if (regD400.RegD420s == null)
                        regD400.RegD420s = new List<BlocoD.RegistroD420>();

                    regD400.RegD420s.Add((BlocoD.RegistroD420)registro);
                    break;

                case "D500":
                    if (BlocoD.RegD001.RegD500s == null)
                        BlocoD.RegD001.RegD500s = new List<BlocoD.RegistroD500>();

                    BlocoD.RegD001.RegD500s.Add((BlocoD.RegistroD500)registro);
                    break;

                case "D510":
                    var regD500 = BlocoD.RegD001.RegD500s.Last();

                    if (regD500.RegD510s == null)
                        regD500.RegD510s = new List<BlocoD.RegistroD510>();

                    regD500.RegD510s.Add((BlocoD.RegistroD510)registro);
                    break;

                case "D530":
                    regD500 = BlocoD.RegD001.RegD500s.Last();

                    if (regD500.RegD530s == null)
                        regD500.RegD530s = new List<BlocoD.RegistroD530>();

                    regD500.RegD530s.Add((BlocoD.RegistroD530)registro);
                    break;

                case "D590":
                    regD500 = BlocoD.RegD001.RegD500s.Last();

                    if (regD500.RegD590s == null)
                        regD500.RegD590s = new List<BlocoD.RegistroD590>();

                    regD500.RegD590s.Add((BlocoD.RegistroD590)registro);
                    break;

                case "D600":
                    if (BlocoD.RegD001.RegD600s == null)
                        BlocoD.RegD001.RegD600s = new List<BlocoD.RegistroD600>();

                    BlocoD.RegD001.RegD600s.Add((BlocoD.RegistroD600)registro);
                    break;

                case "D610":
                    var regD600 = BlocoD.RegD001.RegD600s.Last();

                    if (regD600.RegD610s == null)
                        regD600.RegD610s = new List<BlocoD.RegistroD610>();

                    regD600.RegD610s.Add((BlocoD.RegistroD610)registro);
                    break;

                case "D690":
                    regD600 = BlocoD.RegD001.RegD600s.Last();

                    if (regD600.RegD690s == null)
                        regD600.RegD690s = new List<BlocoD.RegistroD690>();

                    regD600.RegD690s.Add((BlocoD.RegistroD690)registro);
                    break;

                case "D695":
                    if (BlocoD.RegD001.RegD695s == null)
                        BlocoD.RegD001.RegD695s = new List<BlocoD.RegistroD695>();

                    BlocoD.RegD001.RegD695s.Add((BlocoD.RegistroD695)registro);
                    break;

                case "D696":
                    var regD695 = BlocoD.RegD001.RegD695s.Last();

                    if (regD695.RegD696s == null)
                        regD695.RegD696s = new List<BlocoD.RegistroD696>();

                    regD695.RegD696s.Add((BlocoD.RegistroD696)registro);
                    break;

                case "D697":
                    var regD696 = BlocoD.RegD001.RegD695s.Last().RegD696s.Last();

                    if (regD696.RegD697s == null)
                        regD696.RegD697s = new List<BlocoD.RegistroD697>();

                    regD696.RegD697s.Add((BlocoD.RegistroD697)registro);
                    break;

                case "D990": BlocoD.RegD990 = (BlocoD.RegistroD990)registro; break;
            }
        }

        private void LerBlocoE(RegistroBaseSped registro)
        {
            if (BlocoE == null)
                BlocoE = new BlocoE();

            switch (registro.Reg)
            {
                case "E001": BlocoE.RegE001 = (BlocoE.RegistroE001)registro; break;
                case "E100":
                    if (BlocoE.RegE001.RegE100s == null)
                        BlocoE.RegE001.RegE100s = new List<BlocoE.RegistroE100>();
                    BlocoE.RegE001.RegE100s.Add((BlocoE.RegistroE100)registro);
                    break;
                case "E110":
                    var regE100 = BlocoE.RegE001.RegE100s.Last();
                    regE100.RegE110 = (BlocoE.RegistroE110)registro;
                    break;

                case "E111":
                    var regE110 = BlocoE.RegE001.RegE100s.Last().RegE110;

                    if (regE110.RegE111s == null)
                        regE110.RegE111s = new List<BlocoE.RegistroE111>();

                    regE110.RegE111s.Add((BlocoE.RegistroE111)registro);
                    break;

                case "E112":
                    var regE111 = BlocoE.RegE001.RegE100s.Last().RegE110.RegE111s.Last();

                    if (regE111.RegE112s == null)
                        regE111.RegE112s = new List<BlocoE.RegistroE112>();

                    regE111.RegE112s.Add((BlocoE.RegistroE112)registro);
                    break;

                case "E113":
                    regE111 = BlocoE.RegE001.RegE100s.Last().RegE110.RegE111s.Last();

                    if (regE111.RegE113s == null)
                        regE111.RegE113s = new List<BlocoE.RegistroE113>();

                    regE111.RegE113s.Add((BlocoE.RegistroE113)registro);
                    break;

                case "E115":
                    regE110 = BlocoE.RegE001.RegE100s.Last().RegE110;

                    if (regE110.RegE115s == null)
                        regE110.RegE115s = new List<BlocoE.RegistroE115>();

                    regE110.RegE115s.Add((BlocoE.RegistroE115)registro);
                    break;

                case "E116":
                    regE110 = BlocoE.RegE001.RegE100s.Last().RegE110;

                    if (regE110.RegE116s == null)
                        regE110.RegE116s = new List<BlocoE.RegistroE116>();

                    regE110.RegE116s.Add((BlocoE.RegistroE116)registro);
                    break;

                case "E200":
                    if (BlocoE.RegE001.RegE200s == null)
                        BlocoE.RegE001.RegE200s = new List<BlocoE.RegistroE200>();
                    BlocoE.RegE001.RegE200s.Add((BlocoE.RegistroE200)registro);
                    break;

                case "E210":
                    var regE200 = BlocoE.RegE001.RegE200s.Last();
                    regE200.RegE210 = (BlocoE.RegistroE210)registro;
                    break;

                case "E220":
                    var regE210 = BlocoE.RegE001.RegE200s.Last().RegE210;

                    if (regE210.RegE220s == null)
                        regE210.RegE220s = new List<BlocoE.RegistroE220>();

                    regE210.RegE220s.Add((BlocoE.RegistroE220)registro);
                    break;

                case "E230":
                    var regE220 = BlocoE.RegE001.RegE200s.Last().RegE210.RegE220s.Last();

                    if (regE220.RegE230s == null)
                        regE220.RegE230s = new List<BlocoE.RegistroE230>();

                    regE220.RegE230s.Add((BlocoE.RegistroE230)registro);
                    break;

                case "E240":
                    regE220 = BlocoE.RegE001.RegE200s.Last().RegE210.RegE220s.Last();

                    if (regE220.RegE240s == null)
                        regE220.RegE240s = new List<BlocoE.RegistroE240>();

                    regE220.RegE240s.Add((BlocoE.RegistroE240)registro);
                    break;
                case "E250":
                    regE210 = BlocoE.RegE001.RegE200s.Last().RegE210;

                    if (regE210.RegE250s == null)
                        regE210.RegE250s = new List<BlocoE.RegistroE250>();

                    regE210.RegE250s.Add((BlocoE.RegistroE250)registro);
                    break;

                case "E300":
                    if (BlocoE.RegE001.RegE300s == null)
                        BlocoE.RegE001.RegE300s = new List<BlocoE.RegistroE300>();

                    BlocoE.RegE001.RegE300s.Add((BlocoE.RegistroE300)registro);
                    break;

                case "E310": var regE300 = BlocoE.RegE001.RegE300s.Last(); regE300.RegE310 = (BlocoE.RegistroE310)registro; break;

                case "E311":
                    var regE310 = BlocoE.RegE001.RegE300s.Last().RegE310;

                    if (regE310.RegE311s == null)
                        regE310.RegE311s = new List<BlocoE.RegistroE311>();

                    regE310.RegE311s.Add((BlocoE.RegistroE311)registro);
                    break;

                case "E312":
                    var regE311 = BlocoE.RegE001.RegE300s.Last().RegE310.RegE311s.Last();

                    if (regE311.RegE312s == null)
                        regE311.RegE312s = new List<BlocoE.RegistroE312>();

                    regE311.RegE312s.Add((BlocoE.RegistroE312)registro);
                    break;

                case "E313":
                    regE311 = BlocoE.RegE001.RegE300s.Last().RegE310.RegE311s.Last();

                    if (regE311.RegE313s == null)
                        regE311.RegE313s = new List<BlocoE.RegistroE313>();

                    regE311.RegE313s.Add((BlocoE.RegistroE313)registro);
                    break;

                case "E316":
                    regE310 = BlocoE.RegE001.RegE300s.Last().RegE310;

                    if (regE310.RegE316s == null)
                        regE310.RegE316s = new List<BlocoE.RegistroE316>();

                    regE310.RegE316s.Add((BlocoE.RegistroE316)registro);
                    break;

                case "E500":
                    if (BlocoE.RegE001.RegE500s == null)
                        BlocoE.RegE001.RegE500s = new List<BlocoE.RegistroE500>();

                    BlocoE.RegE001.RegE500s.Add((BlocoE.RegistroE500)registro);
                    break;

                case "E510":
                    var regE500 = BlocoE.RegE001.RegE500s.Last();

                    if (regE500.RegE510s == null)
                        regE500.RegE510s = new List<BlocoE.RegistroE510>();

                    regE500.RegE510s.Add((BlocoE.RegistroE510)registro);
                    break;

                case "E520": regE500 = BlocoE.RegE001.RegE500s.Last(); regE500.RegE520 = (BlocoE.RegistroE520)registro; break;

                case "E530":
                    var regE520 = BlocoE.RegE001.RegE500s.Last().RegE520;

                    if (regE520.RegE530s == null)
                        regE520.RegE530s = new List<BlocoE.RegistroE530>();

                    regE520.RegE530s.Add((BlocoE.RegistroE530)registro);
                    break;

                case "E531":
                    var regE530 = BlocoE.RegE001.RegE500s.Last().RegE520.RegE530s.Last();

                    if (regE530.RegE531s == null)
                        regE530.RegE531s = new List<BlocoE.RegistroE531>();

                    regE530.RegE531s.Add((BlocoE.RegistroE531)registro);
                    break;

                case "E990": BlocoE.RegE990 = (BlocoE.RegistroE990)registro; break;
            }
        }

        private void LerBlocoG(RegistroBaseSped registro)
        {
            if (BlocoG == null)
                BlocoG = new BlocoG();

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
        }

        private void LerBlocoH(RegistroBaseSped registro)
        {
            if (BlocoH == null)
                BlocoH = new BlocoH();

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
        }

        private void LerBlocoK(RegistroBaseSped registro)
        {
            if (BlocoK == null)
                BlocoK = new BlocoK();

            switch (registro.Reg)
            {
                case "K001": BlocoK.RegK001 = (BlocoK.RegistroK001)registro; break;
                case "K100":
                    if (BlocoK.RegK001.RegK100s == null)
                        BlocoK.RegK001.RegK100s = new List<BlocoK.RegistroK100>();

                    BlocoK.RegK001.RegK100s.Add((BlocoK.RegistroK100)registro);
                    break;

                case "K200":
                    var regK100 = BlocoK.RegK001.RegK100s.Last();

                    if (regK100.RegK200s == null)
                        regK100.RegK200s = new List<BlocoK.RegistroK200>();

                    regK100.RegK200s.Add((BlocoK.RegistroK200)registro);
                    break;

                case "K210":
                    regK100 = BlocoK.RegK001.RegK100s.Last();

                    if (regK100.RegK210s == null)
                        regK100.RegK210s = new List<BlocoK.RegistroK210>();

                    regK100.RegK210s.Add((BlocoK.RegistroK210)registro);
                    break;

                case "K215":
                    var regK210 = BlocoK.RegK001.RegK100s.Last().RegK210s.Last();

                    if (regK210.RegK215s == null)
                        regK210.RegK215s = new List<BlocoK.RegistroK215>();

                    regK210.RegK215s.Add((BlocoK.RegistroK215)registro);
                    break;

                case "K220":
                    regK100 = BlocoK.RegK001.RegK100s.Last();

                    if (regK100.RegK220s == null)
                        regK100.RegK220s = new List<BlocoK.RegistroK220>();

                    regK100.RegK220s.Add((BlocoK.RegistroK220)registro);
                    break;

                case "K230":
                    regK100 = BlocoK.RegK001.RegK100s.Last();

                    if (regK100.RegK230s == null)
                        regK100.RegK230s = new List<BlocoK.RegistroK230>();

                    regK100.RegK230s.Add((BlocoK.RegistroK230)registro);
                    break;

                case "K235":
                    var regK230 = BlocoK.RegK001.RegK100s.Last().RegK230s.Last();

                    if (regK230.RegK235s == null)
                        regK230.RegK235s = new List<BlocoK.RegistroK235>();

                    regK230.RegK235s.Add((BlocoK.RegistroK235)registro);
                    break;

                case "K250":
                    regK100 = BlocoK.RegK001.RegK100s.Last();

                    if (regK100.RegK250s == null)
                        regK100.RegK250s = new List<BlocoK.RegistroK250>();

                    regK100.RegK250s.Add((BlocoK.RegistroK250)registro);
                    break;

                case "K255":
                    var regK250 = BlocoK.RegK001.RegK100s.Last().RegK250s.Last();

                    if (regK250.RegK255s == null)
                        regK250.RegK255s = new List<BlocoK.RegistroK255>();

                    regK250.RegK255s.Add((BlocoK.RegistroK255)registro);
                    break;

                case "K260":
                    regK100 = BlocoK.RegK001.RegK100s.Last();

                    if (regK100.RegK260s == null)
                        regK100.RegK260s = new List<BlocoK.RegistroK260>();

                    regK100.RegK260s.Add((BlocoK.RegistroK260)registro);
                    break;

                case "K265":
                    var regK260 = BlocoK.RegK001.RegK100s.Last().RegK260s.Last();

                    if (regK260.RegK265s == null)
                        regK260.RegK265s = new List<BlocoK.RegistroK265>();

                    regK260.RegK265s.Add((BlocoK.RegistroK265)registro);
                    break;

                case "K270":
                    regK100 = BlocoK.RegK001.RegK100s.Last();

                    if (regK100.RegK270s == null)
                        regK100.RegK270s = new List<BlocoK.RegistroK270>();

                    regK100.RegK270s.Add((BlocoK.RegistroK270)registro);
                    break;

                case "K275":
                    var regK270 = BlocoK.RegK001.RegK100s.Last().RegK270s.Last();

                    if (regK270.RegK275s == null)
                        regK270.RegK275s = new List<BlocoK.RegistroK275>();

                    regK270.RegK275s.Add((BlocoK.RegistroK275)registro);
                    break;

                case "K280":
                    regK100 = BlocoK.RegK001.RegK100s.Last();

                    if (regK100.RegK280s == null)
                        regK100.RegK280s = new List<BlocoK.RegistroK280>();

                    regK100.RegK280s.Add((BlocoK.RegistroK280)registro);
                    break;

                case "K290":
                    regK100 = BlocoK.RegK001.RegK100s.Last();

                    if (regK100.RegK290s == null)
                        regK100.RegK290s = new List<BlocoK.RegistroK290>();

                    regK100.RegK290s.Add((BlocoK.RegistroK290)registro);
                    break;

                case "K291":
                    var regK290 = BlocoK.RegK001.RegK100s.Last().RegK290s.Last();

                    if (regK290.RegK291s == null)
                        regK290.RegK291s = new List<BlocoK.RegistroK291>();

                    regK290.RegK291s.Add((BlocoK.RegistroK291)registro);
                    break;

                case "K292":
                    regK290 = BlocoK.RegK001.RegK100s.Last().RegK290s.Last();

                    if (regK290.RegK292s == null)
                        regK290.RegK292s = new List<BlocoK.RegistroK292>();

                    regK290.RegK292s.Add((BlocoK.RegistroK292)registro);
                    break;

                case "K300":
                    regK100 = BlocoK.RegK001.RegK100s.Last();

                    if (regK100.RegK300s == null)
                        regK100.RegK300s = new List<BlocoK.RegistroK300>();

                    regK100.RegK300s.Add((BlocoK.RegistroK300)registro);
                    break;

                case "K301":
                    var regK300 = BlocoK.RegK001.RegK100s.Last().RegK300s.Last();

                    if (regK300.RegK301s == null)
                        regK300.RegK301s = new List<BlocoK.RegistroK301>();

                    regK300.RegK301s.Add((BlocoK.RegistroK301)registro);
                    break;

                case "K302":
                    regK300 = BlocoK.RegK001.RegK100s.Last().RegK300s.Last();

                    if (regK300.RegK302s == null)
                        regK300.RegK302s = new List<BlocoK.RegistroK302>();

                    regK300.RegK302s.Add((BlocoK.RegistroK302)registro);
                    break;

                case "K990": BlocoK.RegK990 = (BlocoK.RegistroK990)registro; break;
            }
        }
        #endregion

        public override void CalcularBloco9(bool totalizarblocos = true)
        {
            base.CalcularBloco9(totalizarblocos);

            #region Totalizar blocos
            if (totalizarblocos) //Calcula os X990 de todos os blocos e readiciona as linhas de totalização -> |X990|
            {
                var registros = Linhas
                    .Where(x => x.Length > 6 && x.Substring(2, 3) != "990") // Pega só as linhas que não se tratam de totalizadores
                    .Select(x => x.Substring(1, 4));

                if (Bloco0 != null)
                    Bloco0.Reg0990 = new Bloco0.Registro0990() { QtdLin0 = registros.Where(x => x.StartsWith("0")).Count() + 1 };

                if (Bloco1 != null)
                    Bloco1.Reg1990 = new Bloco1.Registro1990() { QtdLin1 = registros.Where(x => x.StartsWith("1")).Count() + 1 };

                if (BlocoB != null)
                    BlocoB.RegB990 = new BlocoB.RegistroB990() { QtdLinB = registros.Where(x => x.StartsWith("B")).Count() + 1 };

                if (BlocoC != null)
                    BlocoC.RegC990 = new BlocoC.RegistroC990() { QtdLinC = registros.Where(x => x.StartsWith("C")).Count() + 1 };

                if (BlocoD != null)
                    BlocoD.RegD990 = new BlocoD.RegistroD990() { QtdLinD = registros.Where(x => x.StartsWith("D")).Count() + 1 };

                if (BlocoE != null)
                    BlocoE.RegE990 = new BlocoE.RegistroE990() { QtdLinE = registros.Where(x => x.StartsWith("E")).Count() + 1 };

                if (BlocoG != null)
                    BlocoG.RegG990 = new BlocoG.RegistroG990() { QtdLinG = registros.Where(x => x.StartsWith("G")).Count() + 1 };

                if (BlocoH != null)
                    BlocoH.RegH990 = new BlocoH.RegistroH990() { QtdLinH = registros.Where(x => x.StartsWith("H")).Count() + 1 };

                if (BlocoK != null)
                    BlocoK.RegK990 = new BlocoK.RegistroK990() { QtdLinK = registros.Where(x => x.StartsWith("K")).Count() + 1 };

                GerarLinhas(); //Gera as linhas novamente com os totalizadores calculados
            }
            #endregion

            #region Bloco 9
            Linhas.RemoveAll(x => x.Length > 6 && x[1] == '9'); //Remove todas as linhas do Bloco 9, as linhas serão readicionadas posteriormente

            Bloco9 = new Bloco9()
            {
                Reg9001 = new Bloco9.Registro9001()
                {
                    IndMov = Common.IndMovimento.BlocoComDados,
                    Reg9900s = new List<Bloco9.Registro9900>()
                },
                Reg9990 = new Bloco9.Registro9990(),
                Reg9999 = new Bloco9.Registro9999()
            };

            var diferentes = Linhas
                    .Where(x => x.Length > 6)
                    .Select(x => x.Substring(1, 4))
                    .Distinct();

            foreach (var registro in diferentes)
            {
                var _9900 = new Bloco9.Registro9900()
                {
                    RegBlc = registro,
                    QtdRegBlc = Linhas.Where(x => x.StartsWith($"|{registro}|")).Count()
                };

                Bloco9.Reg9001.Reg9900s.Add(_9900);
            }

            Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900()
            {
                RegBlc = "9001",
                QtdRegBlc = 1
            });

            Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900()
            {
                RegBlc = "9900",
                QtdRegBlc = Bloco9.Reg9001.Reg9900s.Count() + 3 /* 9900, 9990 e 9999*/
            });

            Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900()
            {
                RegBlc = "9990",
                QtdRegBlc = 1
            });

            Bloco9.Reg9001.Reg9900s.Add(new Bloco9.Registro9900()
            {
                RegBlc = "9999",
                QtdRegBlc = 1
            });

            Bloco9.Reg9990 = new Bloco9.Registro9990()
            {
                QtdLin9 = Bloco9.Reg9001.Reg9900s.Count + 3 /* 9001, 9990 e 9999 */
            };

            Bloco9.Reg9999 = new Bloco9.Registro9999()
            {
                QtdLin = Linhas.Count + Bloco9.Reg9001.Reg9900s.Count + 3 /*9001, 9990 e 9999*/
            };

            GerarComFilhos(Bloco9);
            #endregion
        }

        public override void GerarLinhas()
        {
            base.GerarLinhas();

            GerarComFilhos(Bloco0);

            GerarComFilhos(BlocoB);

            GerarComFilhos(BlocoC);

            GerarComFilhos(BlocoD);

            GerarComFilhos(BlocoE);

            GerarComFilhos(BlocoG);

            GerarComFilhos(BlocoH);

            GerarComFilhos(BlocoK);

            GerarComFilhos(Bloco1);

            GerarComFilhos(Bloco9);
        }

        private void GerarComFilhos(object registro)
        {
            if (registro == null)
                return;

            //Testa antes porque porque pode-se tratar de um bloco
            if (registro is RegistroBaseSped)
                EscreverLinha(registro as RegistroBaseSped);

            var tipo = registro.GetType();

            var propriedades = tipo
                                .GetProperties()
                                .ToList();

            foreach (var propriedade in propriedades)
            {
                var valor = propriedade.GetValue(registro);

                if (valor == null)
                    continue;

                if (valor is RegistroBaseSped)
                    GerarComFilhos(valor);

                //Lista de objetos
                else if (valor is IList)
                {
                    var lista = (IList)valor;

                    foreach (var item in lista)
                        GerarComFilhos(item);
                }

            }

        }
    }
}
