using FiscalBr.Common.Sped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiscalBr.EFDContribuicoes
{
    public sealed class ArquivoEFDContribuicoes : ArquivoSped
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

        public override void Ler(string path, Encoding encoding = null)
        {
            base.Ler(path, encoding);

            foreach (var linha in Linhas)
            {
                var registro = (RegistroBaseSped)LerCamposSped.LerCampos(linha, file: "EFDContribuicoes");

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
                else if (linha.StartsWith("|A"))
                    LerBlocoA(registro);
                else if (linha.StartsWith("|C"))
                    LerBlocoC(registro);
                else if (linha.StartsWith("|D"))
                    LerBlocoD(registro);
                else if (linha.StartsWith("|F"))
                    LerBlocoF(registro);
                else if (linha.StartsWith("|I"))
                    LerBlocoI(registro);
                else if (linha.StartsWith("|M"))
                    LerBlocoM(registro);
                else if (linha.StartsWith("|P"))
                    LerBlocoP(registro);
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

                case "0035":
                    var reg0001 = Bloco0.Reg0001;

                    if (reg0001.Reg0035s == null)
                        reg0001.Reg0035s = new List<Bloco0.Registro0035>();

                    reg0001.Reg0035s.Add((Bloco0.Registro0035)registro);
                    break;

                case "0100":
                    reg0001 = Bloco0.Reg0001;
                    if (reg0001.Reg0100s == null)
                        reg0001.Reg0100s = new List<Bloco0.Registro0100>();

                    reg0001.Reg0100s.Add((Bloco0.Registro0100)registro);
                    break;

                case "0110":
                    reg0001 = Bloco0.Reg0001;
                    reg0001.Reg0110 = (Bloco0.Registro0110)registro;
                    break;

                case "0111":
                    var reg0110 = Bloco0.Reg0001.Reg0110;
                    reg0110.Reg0111 = (Bloco0.Registro0111)registro;
                    break;

                case "0120":
                    reg0001 = Bloco0.Reg0001;

                    if (reg0001.Reg0120s == null)
                        reg0001.Reg0120s = new List<Bloco0.Registro0120>();

                    reg0001.Reg0120s.Add((Bloco0.Registro0120)registro);
                    break;

                case "0140":
                    reg0001 = Bloco0.Reg0001;

                    if (reg0001.Reg0140s == null)
                        reg0001.Reg0140s = new List<Bloco0.Registro0140>();

                    reg0001.Reg0140s.Add((Bloco0.Registro0140)registro);
                    break;

                case "0145":
                    var reg0140 = Bloco0.Reg0001.Reg0140s.Last();
                    reg0140.Reg0145 = (Bloco0.Registro0145)registro;
                    break;

                case "0150":
                    reg0140 = Bloco0.Reg0001.Reg0140s.Last();

                    if (reg0140.Reg0150s == null)
                        reg0140.Reg0150s = new List<Bloco0.Registro0150>();

                    reg0140.Reg0150s.Add((Bloco0.Registro0150)registro);
                    break;

                case "0190":
                    reg0140 = Bloco0.Reg0001.Reg0140s.Last();

                    if (reg0140.Reg0190s == null)
                        reg0140.Reg0190s = new List<Bloco0.Registro0190>();

                    reg0140.Reg0190s.Add((Bloco0.Registro0190)registro);
                    break;

                case "0200":
                    reg0140 = Bloco0.Reg0001.Reg0140s.Last();

                    if (reg0140.Reg0200s == null)
                        reg0140.Reg0200s = new List<Bloco0.Registro0200>();

                    reg0140.Reg0200s.Add((Bloco0.Registro0200)registro);
                    break;

                case "0205":
                    var reg0200 = Bloco0.Reg0001.Reg0140s.Last().Reg0200s.Last();

                    if (reg0200.Reg0205s == null)
                        reg0200.Reg0205s = new List<Bloco0.Registro0205>();

                    reg0200.Reg0205s.Add((Bloco0.Registro0205)registro);
                    break;

                case "0206":
                    reg0200 = Bloco0.Reg0001.Reg0140s.Last().Reg0200s.Last();
                    reg0200.Reg0206 = (Bloco0.Registro0206)registro;
                    break;

                case "0208":
                    reg0200 = Bloco0.Reg0001.Reg0140s.Last().Reg0200s.Last();
                    reg0200.Reg0208 = (Bloco0.Registro0208)registro;
                    break;

                case "0400":
                    reg0140 = Bloco0.Reg0001.Reg0140s.Last();

                    if (reg0140.Reg0400s == null)
                        reg0140.Reg0400s = new List<Bloco0.Registro0400>();

                    reg0140.Reg0400s.Add((Bloco0.Registro0400)registro);
                    break;

                case "0450":
                    reg0140 = Bloco0.Reg0001.Reg0140s.Last();

                    if (reg0140.Reg0450s == null)
                        reg0140.Reg0450s = new List<Bloco0.Registro0450>();

                    reg0140.Reg0450s.Add((Bloco0.Registro0450)registro);
                    break;

                case "0500":
                    reg0001 = Bloco0.Reg0001;

                    if (reg0001.Reg0500s == null)
                        reg0001.Reg0500s = new List<Bloco0.Registro0500>();

                    reg0001.Reg0500s.Add((Bloco0.Registro0500)registro);
                    break;

                case "0600":
                    reg0001 = Bloco0.Reg0001;

                    if (reg0001.Reg0600s == null)
                        reg0001.Reg0600s = new List<Bloco0.Registro0600>();

                    reg0001.Reg0600s.Add((Bloco0.Registro0600)registro);
                    break;

                case "0900":
                    reg0001 = Bloco0.Reg0001;
                    reg0001.Reg0900 = (Bloco0.Registro0900)registro;
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
                case "1010":
                    var reg1001 = Bloco1.Reg1001;

                    if (reg1001.Reg1010s == null)
                        reg1001.Reg1010s = new List<Bloco1.Registro1010>();

                    reg1001.Reg1010s.Add((Bloco1.Registro1010)registro);
                    break;

                case "1011":
                    var reg1010 = Bloco1.Reg1001.Reg1010s.Last();

                    if (reg1010.Reg1011s == null)
                        reg1010.Reg1011s = new List<Bloco1.Registro1011>();

                    reg1010.Reg1011s.Add((Bloco1.Registro1011)registro);
                    break;

                case "1020":
                    reg1001 = Bloco1.Reg1001;

                    if (reg1001.Reg1020s == null)
                        reg1001.Reg1020s = new List<Bloco1.Registro1020>();

                    reg1001.Reg1020s.Add((Bloco1.Registro1020)registro);
                    break;

                case "1050":
                    reg1001 = Bloco1.Reg1001;

                    if (reg1001.Reg1050s == null)
                        reg1001.Reg1050s = new List<Bloco1.Registro1050>();

                    reg1001.Reg1050s.Add((Bloco1.Registro1050)registro);
                    break;

                case "1100":
                    reg1001 = Bloco1.Reg1001;

                    if (reg1001.Reg1100s == null)
                        reg1001.Reg1100s = new List<Bloco1.Registro1100>();

                    reg1001.Reg1100s.Add((Bloco1.Registro1100)registro);
                    break;

                case "1101":
                    var reg1100 = Bloco1.Reg1001.Reg1100s.Last();

                    if (reg1100.Reg1101s == null)
                        reg1100.Reg1101s = new List<Bloco1.Registro1101>();

                    reg1100.Reg1101s.Add((Bloco1.Registro1101)registro);
                    break;

                case "1102":
                    var reg1101 = Bloco1.Reg1001.Reg1100s.Last().Reg1101s.Last();
                    reg1101.Reg1102 = (Bloco1.Registro1102)registro;
                    break;

                case "1200":
                    reg1001 = Bloco1.Reg1001;

                    if (reg1001.Reg1200s == null)
                        reg1001.Reg1200s = new List<Bloco1.Registro1200>();

                    reg1001.Reg1200s.Add((Bloco1.Registro1200)registro);
                    break;

                case "1210":
                    var reg1200 = Bloco1.Reg1001.Reg1200s.Last();

                    if (reg1200.Reg1210s == null)
                        reg1200.Reg1210s = new List<Bloco1.Registro1210>();

                    reg1200.Reg1210s.Add((Bloco1.Registro1210)registro);
                    break;

                case "1220":
                    reg1200 = Bloco1.Reg1001.Reg1200s.Last();

                    if (reg1200.Reg1220s == null)
                        reg1200.Reg1220s = new List<Bloco1.Registro1220>();

                    reg1200.Reg1220s.Add((Bloco1.Registro1220)registro);
                    break;

                case "1300":
                    reg1001 = Bloco1.Reg1001;

                    if (reg1001.Reg1300s == null)
                        reg1001.Reg1300s = new List<Bloco1.Registro1300>();

                    reg1001.Reg1300s.Add((Bloco1.Registro1300)registro);
                    break;

                case "1500":
                    reg1001 = Bloco1.Reg1001;

                    if (reg1001.Reg1500s == null)
                        reg1001.Reg1500s = new List<Bloco1.Registro1500>();

                    reg1001.Reg1500s.Add((Bloco1.Registro1500)registro);
                    break;

                case "1501":
                    var reg1500 = Bloco1.Reg1001.Reg1500s.Last();

                    if (reg1500.Reg1501s == null)
                        reg1500.Reg1501s = new List<Bloco1.Registro1501>();

                    reg1500.Reg1501s.Add((Bloco1.Registro1501)registro);
                    break;

                case "1502":
                    var reg1501 = Bloco1.Reg1001.Reg1500s.Last().Reg1501s.Last();
                    reg1501.Reg1502 = (Bloco1.Registro1502)registro;
                    break;

                case "1600":
                    reg1001 = Bloco1.Reg1001;

                    if (reg1001.Reg1600s == null)
                        reg1001.Reg1600s = new List<Bloco1.Registro1600>();

                    reg1001.Reg1600s.Add((Bloco1.Registro1600)registro);
                    break;

                case "1610":
                    var reg1600 = Bloco1.Reg1001.Reg1600s.Last();

                    if (reg1600.Reg1610s == null)
                        reg1600.Reg1610s = new List<Bloco1.Registro1610>();

                    reg1600.Reg1610s.Add((Bloco1.Registro1610)registro);
                    break;

                case "1620":
                    reg1600 = Bloco1.Reg1001.Reg1600s.Last();

                    if (reg1600.Reg1620s == null)
                        reg1600.Reg1620s = new List<Bloco1.Registro1620>();

                    reg1600.Reg1620s.Add((Bloco1.Registro1620)registro);
                    break;

                case "1700":
                    reg1001 = Bloco1.Reg1001;

                    if (reg1001.Reg1700s == null)
                        reg1001.Reg1700s = new List<Bloco1.Registro1700>();

                    reg1001.Reg1700s.Add((Bloco1.Registro1700)registro);
                    break;

                case "1800":
                    reg1001 = Bloco1.Reg1001;

                    if (reg1001.Reg1800s == null)
                        reg1001.Reg1800s = new List<Bloco1.Registro1800>();

                    reg1001.Reg1800s.Add((Bloco1.Registro1800)registro);
                    break;

                case "1809":
                    var reg1800 = Bloco1.Reg1001.Reg1800s.Last();

                    if (reg1800.Reg1809s == null)
                        reg1800.Reg1809s = new List<Bloco1.Registro1809>();

                    reg1800.Reg1809s.Add((Bloco1.Registro1809)registro);
                    break;

                case "1900":
                    reg1001 = Bloco1.Reg1001;

                    if (reg1001.Reg1900s == null)
                        reg1001.Reg1900s = new List<Bloco1.Registro1900>();

                    reg1001.Reg1900s.Add((Bloco1.Registro1900)registro);
                    break;

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

        private void LerBlocoA(RegistroBaseSped registro)
        {
            if (BlocoA == null)
                BlocoA = new BlocoA();

            switch (registro.Reg)
            {
                case "A001": BlocoA.RegA001 = (BlocoA.RegistroA001)registro; break;

                case "A010":
                    var regA001 = BlocoA.RegA001;

                    if (regA001.RegA010s == null)
                        regA001.RegA010s = new List<BlocoA.RegistroA010>();

                    regA001.RegA010s.Add((BlocoA.RegistroA010)registro);
                    break;

                case "A100":
                    var regA010 = BlocoA.RegA001.RegA010s.Last();

                    if (regA010.RegA100s == null)
                        regA010.RegA100s = new List<BlocoA.RegistroA100>();

                    regA010.RegA100s.Add((BlocoA.RegistroA100)registro);
                    break;

                case "A110":
                    var regA100 = BlocoA.RegA001.RegA010s.Last().RegA100s.Last();

                    if (regA100.RegA110s == null)
                        regA100.RegA110s = new List<BlocoA.RegistroA110>();

                    regA100.RegA110s.Add((BlocoA.RegistroA110)registro);
                    break;

                case "A111":
                    regA100 = BlocoA.RegA001.RegA010s.Last().RegA100s.Last();

                    if (regA100.RegA111s == null)
                        regA100.RegA111s = new List<BlocoA.RegistroA111>();

                    regA100.RegA111s.Add((BlocoA.RegistroA111)registro);
                    break;

                case "A120":
                    regA100 = BlocoA.RegA001.RegA010s.Last().RegA100s.Last();

                    if (regA100.RegA120s == null)
                        regA100.RegA120s = new List<BlocoA.RegistroA120>();

                    regA100.RegA120s.Add((BlocoA.RegistroA120)registro);
                    break;

                case "A170":
                    regA100 = BlocoA.RegA001.RegA010s.Last().RegA100s.Last();

                    if (regA100.RegA170s == null)
                        regA100.RegA170s = new List<BlocoA.RegistroA170>();

                    regA100.RegA170s.Add((BlocoA.RegistroA170)registro);
                    break;

                case "A990": BlocoA.RegA990 = (BlocoA.RegistroA990)registro; break;
            }
        }

        private void LerBlocoC(RegistroBaseSped registro)
        {
            if (BlocoC == null)
                BlocoC = new BlocoC();

            switch (registro.Reg)
            {
                case "C001": BlocoC.RegC001 = (BlocoC.RegistroC001)registro; break;

                case "C010":
                    var regC001 = BlocoC.RegC001;

                    if (regC001.RegC010s == null)
                        regC001.RegC010s = new List<BlocoC.RegistroC010>();

                    regC001.RegC010s.Add((BlocoC.RegistroC010)registro);
                    break;

                #region C100 e filhos
                case "C100":
                    var regC010 = BlocoC.RegC001.RegC010s.Last();

                    if (regC010.RegC100s == null)
                        regC010.RegC100s = new List<BlocoC.RegistroC100>();

                    regC010.RegC100s.Add((BlocoC.RegistroC100)registro);
                    break;

                case "C110":
                    var regC100 = BlocoC.RegC001.RegC010s.Last().RegC100s.Last();

                    if (regC100.RegC110s == null)
                        regC100.RegC110s = new List<BlocoC.RegistroC110>();

                    regC100.RegC110s.Add((BlocoC.RegistroC110)registro);
                    break;

                case "C111":
                    regC100 = BlocoC.RegC001.RegC010s.Last().RegC100s.Last();

                    if (regC100.RegC111s == null)
                        regC100.RegC111s = new List<BlocoC.RegistroC111>();

                    regC100.RegC111s.Add((BlocoC.RegistroC111)registro);
                    break;

                case "C120":
                    regC100 = BlocoC.RegC001.RegC010s.Last().RegC100s.Last();

                    if (regC100.RegC120s == null)
                        regC100.RegC120s = new List<BlocoC.RegistroC120>();

                    regC100.RegC120s.Add((BlocoC.RegistroC120)registro);
                    break;

                case "C170":
                    regC100 = BlocoC.RegC001.RegC010s.Last().RegC100s.Last();

                    if (regC100.RegC170s == null)
                        regC100.RegC170s = new List<BlocoC.RegistroC170>();

                    regC100.RegC170s.Add((BlocoC.RegistroC170)registro);
                    break;

                case "C175":
                    regC100 = BlocoC.RegC001.RegC010s.Last().RegC100s.Last();

                    if (regC100.RegC175s == null)
                        regC100.RegC175s = new List<BlocoC.RegistroC175>();

                    regC100.RegC175s.Add((BlocoC.RegistroC175)registro);
                    break;

                case "C180":
                    regC010 = BlocoC.RegC001.RegC010s.Last();

                    if (regC010.RegC180s == null)
                        regC010.RegC180s = new List<BlocoC.RegistroC180>();

                    regC010.RegC180s.Add((BlocoC.RegistroC180)registro);
                    break;

                case "C181":
                    var regC180 = BlocoC.RegC001.RegC010s.Last().RegC180s.Last();

                    if (regC180.RegC181s == null)
                        regC180.RegC181s = new List<BlocoC.RegistroC181>();

                    regC180.RegC181s.Add((BlocoC.RegistroC181)registro);
                    break;

                case "C185":
                    regC180 = BlocoC.RegC001.RegC010s.Last().RegC180s.Last();

                    if (regC180.RegC185s == null)
                        regC180.RegC185s = new List<BlocoC.RegistroC185>();

                    regC180.RegC185s.Add((BlocoC.RegistroC185)registro);
                    break;

                case "C188":
                    regC180 = BlocoC.RegC001.RegC010s.Last().RegC180s.Last();

                    if (regC180.RegC188s == null)
                        regC180.RegC188s = new List<BlocoC.RegistroC188>();

                    regC180.RegC188s.Add((BlocoC.RegistroC188)registro);
                    break;

                case "C190":
                    regC010 = BlocoC.RegC001.RegC010s.Last();

                    if (regC010.RegC190s == null)
                        regC010.RegC190s = new List<BlocoC.RegistroC190>();

                    regC010.RegC190s.Add((BlocoC.RegistroC190)registro);
                    break;

                case "C191":
                    var regC190 = BlocoC.RegC001.RegC010s.Last().RegC190s.Last();

                    if (regC190.RegC191s == null)
                        regC190.RegC191s = new List<BlocoC.RegistroC191>();

                    regC190.RegC191s.Add((BlocoC.RegistroC191)registro);
                    break;

                case "C195":
                    regC190 = BlocoC.RegC001.RegC010s.Last().RegC190s.Last();

                    if (regC190.RegC195s == null)
                        regC190.RegC195s = new List<BlocoC.RegistroC195>();

                    regC190.RegC195s.Add((BlocoC.RegistroC195)registro);
                    break;

                case "C198":
                    regC190 = BlocoC.RegC001.RegC010s.Last().RegC190s.Last();

                    if (regC190.RegC198s == null)
                        regC190.RegC198s = new List<BlocoC.RegistroC198>();

                    regC190.RegC198s.Add((BlocoC.RegistroC198)registro);
                    break;

                case "C199":
                    regC190 = BlocoC.RegC001.RegC010s.Last().RegC190s.Last();

                    if (regC190.RegC199s == null)
                        regC190.RegC199s = new List<BlocoC.RegistroC199>();

                    regC190.RegC199s.Add((BlocoC.RegistroC199)registro);
                    break;
                #endregion

                case "C380":
                    regC010 = BlocoC.RegC001.RegC010s.Last();

                    if (regC010.RegC380s == null)
                        regC010.RegC380s = new List<BlocoC.RegistroC380>();

                    regC010.RegC380s.Add((BlocoC.RegistroC380)registro);
                    break;

                case "C381":
                    var regC380 = BlocoC.RegC001.RegC010s.Last().RegC380s.Last();

                    if (regC380.RegC381s == null)
                        regC380.RegC381s = new List<BlocoC.RegistroC381>();

                    regC380.RegC381s.Add((BlocoC.RegistroC381)registro);
                    break;

                case "C385":
                    regC380 = BlocoC.RegC001.RegC010s.Last().RegC380s.Last();

                    if (regC380.RegC385s == null)
                        regC380.RegC385s = new List<BlocoC.RegistroC385>();

                    regC380.RegC385s.Add((BlocoC.RegistroC385)registro);
                    break;

                case "C395":
                    regC010 = BlocoC.RegC001.RegC010s.Last();

                    if (regC010.RegC395s == null)
                        regC010.RegC395s = new List<BlocoC.RegistroC395>();

                    regC010.RegC395s.Add((BlocoC.RegistroC395)registro);
                    break;

                case "C396":
                    var regC395 = BlocoC.RegC001.RegC010s.Last().RegC395s.Last();

                    if (regC395.RegC396s == null)
                        regC395.RegC396s = new List<BlocoC.RegistroC396>();

                    regC395.RegC396s.Add((BlocoC.RegistroC396)registro);
                    break;

                case "C400":
                    regC010 = BlocoC.RegC001.RegC010s.Last();

                    if (regC010.RegC400s == null)
                        regC010.RegC400s = new List<BlocoC.RegistroC400>();

                    regC010.RegC400s.Add((BlocoC.RegistroC400)registro);
                    break;

                case "C405":
                    var regC400 = BlocoC.RegC001.RegC010s.Last().RegC400s.Last();

                    if (regC400.RegC405s == null)
                        regC400.RegC405s = new List<BlocoC.RegistroC405>();

                    regC400.RegC405s.Add((BlocoC.RegistroC405)registro);
                    break;

                case "C481":
                    var regC405 = BlocoC.RegC001.RegC010s.Last().RegC400s.Last().RegC405s.Last();

                    if (regC405.RegC481s == null)
                        regC405.RegC481s = new List<BlocoC.RegistroC481>();

                    regC405.RegC481s.Add((BlocoC.RegistroC481)registro);
                    break;

                case "C485":
                    regC405 = BlocoC.RegC001.RegC010s.Last().RegC400s.Last().RegC405s.Last();

                    if (regC405.RegC485s == null)
                        regC405.RegC485s = new List<BlocoC.RegistroC485>();

                    regC405.RegC485s.Add((BlocoC.RegistroC485)registro);
                    break;

                case "C489":
                    regC400 = BlocoC.RegC001.RegC010s.Last().RegC400s.Last();

                    if (regC400.RegC489s == null)
                        regC400.RegC489s = new List<BlocoC.RegistroC489>();

                    regC400.RegC489s.Add((BlocoC.RegistroC489)registro);
                    break;

                case "C490":
                    regC010 = BlocoC.RegC001.RegC010s.Last();

                    if (regC010.RegC490s == null)
                        regC010.RegC490s = new List<BlocoC.RegistroC490>();

                    regC010.RegC490s.Add((BlocoC.RegistroC490)registro);
                    break;

                case "C491":
                    var regC490 = BlocoC.RegC001.RegC010s.Last().RegC490s.Last();

                    if (regC490.RegC491s == null)
                        regC490.RegC491s = new List<BlocoC.RegistroC491>();

                    regC490.RegC491s.Add((BlocoC.RegistroC491)registro);
                    break;

                case "C495":
                    regC490 = BlocoC.RegC001.RegC010s.Last().RegC490s.Last();

                    if (regC490.RegC495s == null)
                        regC490.RegC495s = new List<BlocoC.RegistroC495>();

                    regC490.RegC495s.Add((BlocoC.RegistroC495)registro);
                    break;

                case "C499":
                    regC490 = BlocoC.RegC001.RegC010s.Last().RegC490s.Last();

                    if (regC490.RegC499s == null)
                        regC490.RegC499s = new List<BlocoC.RegistroC499>();

                    regC490.RegC499s.Add((BlocoC.RegistroC499)registro);
                    break;

                case "C500":
                    regC010 = BlocoC.RegC001.RegC010s.Last();

                    if (regC010.RegC500s == null)
                        regC010.RegC500s = new List<BlocoC.RegistroC500>();

                    regC010.RegC500s.Add((BlocoC.RegistroC500)registro);
                    break;

                case "C501":
                    var regC500 = BlocoC.RegC001.RegC010s.Last().RegC500s.Last();

                    if (regC500.RegC501s == null)
                        regC500.RegC501s = new List<BlocoC.RegistroC501>();

                    regC500.RegC501s.Add((BlocoC.RegistroC501)registro);
                    break;

                case "C505":
                    regC500 = BlocoC.RegC001.RegC010s.Last().RegC500s.Last();

                    if (regC500.RegC505s == null)
                        regC500.RegC505s = new List<BlocoC.RegistroC505>();

                    regC500.RegC505s.Add((BlocoC.RegistroC505)registro);
                    break;

                case "C509":
                    regC500 = BlocoC.RegC001.RegC010s.Last().RegC500s.Last();

                    if (regC500.RegC509s == null)
                        regC500.RegC509s = new List<BlocoC.RegistroC509>();

                    regC500.RegC509s.Add((BlocoC.RegistroC509)registro);
                    break;

                case "C600":
                    regC010 = BlocoC.RegC001.RegC010s.Last();

                    if (regC010.RegC600s == null)
                        regC010.RegC600s = new List<BlocoC.RegistroC600>();

                    regC010.RegC600s.Add((BlocoC.RegistroC600)registro);
                    break;

                case "C601":
                    var regC600 = BlocoC.RegC001.RegC010s.Last().RegC600s.Last();

                    if (regC600.RegC601s == null)
                        regC600.RegC601s = new List<BlocoC.RegistroC601>();

                    regC600.RegC601s.Add((BlocoC.RegistroC601)registro);
                    break;

                case "C605":
                    regC600 = BlocoC.RegC001.RegC010s.Last().RegC600s.Last();

                    if (regC600.RegC605s == null)
                        regC600.RegC605s = new List<BlocoC.RegistroC605>();

                    regC600.RegC605s.Add((BlocoC.RegistroC605)registro);
                    break;

                case "C609":
                    regC600 = BlocoC.RegC001.RegC010s.Last().RegC600s.Last();

                    if (regC600.RegC609s == null)
                        regC600.RegC609s = new List<BlocoC.RegistroC609>();

                    regC600.RegC609s.Add((BlocoC.RegistroC609)registro);
                    break;

                case "C800":
                    regC010 = BlocoC.RegC001.RegC010s.Last();

                    if (regC010.RegC800s == null)
                        regC010.RegC800s = new List<BlocoC.RegistroC800>();

                    regC010.RegC800s.Add((BlocoC.RegistroC800)registro);
                    break;

                case "C810":
                    var regC800 = BlocoC.RegC001.RegC010s.Last().RegC800s.Last();

                    if (regC800.RegC810s == null)
                        regC800.RegC810s = new List<BlocoC.RegistroC810>();

                    regC800.RegC810s.Add((BlocoC.RegistroC810)registro);
                    break;

                case "C820":
                     regC800 = BlocoC.RegC001.RegC010s.Last().RegC800s.Last();

                    if (regC800.RegC820s == null)
                        regC800.RegC820s = new List<BlocoC.RegistroC820>();

                    regC800.RegC820s.Add((BlocoC.RegistroC820)registro);
                    break;

                case "C830":
                     regC800 = BlocoC.RegC001.RegC010s.Last().RegC800s.Last();

                    if (regC800.RegC830s == null)
                        regC800.RegC830s = new List<BlocoC.RegistroC830>();

                    regC800.RegC830s.Add((BlocoC.RegistroC830)registro);
                    break;

                case "C860":
                    regC010 = BlocoC.RegC001.RegC010s.Last();

                    if (regC010.RegC860s == null)
                        regC010.RegC860s = new List<BlocoC.RegistroC860>();

                    regC010.RegC860s.Add((BlocoC.RegistroC860)registro);
                    break;

                case "C870":
                    var regC860 = BlocoC.RegC001.RegC010s.Last().RegC860s.Last();

                    if (regC860.RegC870s == null)
                        regC860.RegC870s = new List<BlocoC.RegistroC870>();

                    regC860.RegC870s.Add((BlocoC.RegistroC870)registro);
                    break;

                case "C880":
                    regC860 = BlocoC.RegC001.RegC010s.Last().RegC860s.Last();

                    if (regC860.RegC880s == null)
                        regC860.RegC880s = new List<BlocoC.RegistroC880>();

                    regC860.RegC880s.Add((BlocoC.RegistroC880)registro);
                    break;

                case "C890":
                    regC860 = BlocoC.RegC001.RegC010s.Last().RegC860s.Last();

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

                case "D010":
                    var regD001 = BlocoD.RegD001;

                    if (regD001.RegD010s == null)
                        regD001.RegD010s = new List<BlocoD.RegistroD010>();

                    regD001.RegD010s.Add((BlocoD.RegistroD010)registro);
                    break;

                case "D100":
                    var regD010 = BlocoD.RegD001.RegD010s.Last();

                    if (regD010.RegD100s == null)
                        regD010.RegD100s = new List<BlocoD.RegistroD100>();

                    regD010.RegD100s.Add((BlocoD.RegistroD100)registro);
                    break;

                case "D101":
                    var regD100 = BlocoD.RegD001.RegD010s.Last().RegD100s.Last();

                    if (regD100.RegD101s == null)
                        regD100.RegD101s = new List<BlocoD.RegistroD101>();

                    regD100.RegD101s.Add((BlocoD.RegistroD101)registro);
                    break;

                case "D105":
                    regD100 = BlocoD.RegD001.RegD010s.Last().RegD100s.Last();

                    if (regD100.RegD105s == null)
                        regD100.RegD105s = new List<BlocoD.RegistroD105>();

                    regD100.RegD105s.Add((BlocoD.RegistroD105)registro);
                    break;

                case "D111":
                    regD100 = BlocoD.RegD001.RegD010s.Last().RegD100s.Last();

                    if (regD100.RegD111s == null)
                        regD100.RegD111s = new List<BlocoD.RegistroD111>();

                    regD100.RegD111s.Add((BlocoD.RegistroD111)registro);
                    break;

                case "D200":
                    regD010 = BlocoD.RegD001.RegD010s.Last();

                    if (regD010.RegD200s == null)
                        regD010.RegD200s = new List<BlocoD.RegistroD200>();

                    regD010.RegD200s.Add((BlocoD.RegistroD200)registro);
                    break;

                case "D201":
                    var regD200 = BlocoD.RegD001.RegD010s.Last().RegD200s.Last();

                    if (regD200.RegD201s == null)
                        regD200.RegD201s = new List<BlocoD.RegistroD201>();

                    regD200.RegD201s.Add((BlocoD.RegistroD201)registro);
                    break;

                case "D205":
                    regD200 = BlocoD.RegD001.RegD010s.Last().RegD200s.Last();

                    if (regD200.RegD205s == null)
                        regD200.RegD205s = new List<BlocoD.RegistroD205>();

                    regD200.RegD205s.Add((BlocoD.RegistroD205)registro);
                    break;

                case "D209":
                    regD200 = BlocoD.RegD001.RegD010s.Last().RegD200s.Last();

                    if (regD200.RegD209s == null)
                        regD200.RegD209s = new List<BlocoD.RegistroD209>();

                    regD200.RegD209s.Add((BlocoD.RegistroD209)registro);
                    break;

                case "D300":
                    regD010 = BlocoD.RegD001.RegD010s.Last();

                    if (regD010.RegD300s == null)
                        regD010.RegD300s = new List<BlocoD.RegistroD300>();

                    regD010.RegD300s.Add((BlocoD.RegistroD300)registro);
                    break;

                case "D309":
                    var regD300 = BlocoD.RegD001.RegD010s.Last().RegD300s.Last();

                    if (regD300.RegD309s == null)
                        regD300.RegD309s = new List<BlocoD.RegistroD309>();

                    regD300.RegD309s.Add((BlocoD.RegistroD309)registro);
                    break;

                case "D350":
                    regD010 = BlocoD.RegD001.RegD010s.Last();

                    if (regD010.RegD350s == null)
                        regD010.RegD350s = new List<BlocoD.RegistroD350>();

                    regD010.RegD350s.Add((BlocoD.RegistroD350)registro);
                    break;

                case "D359":
                    var regD350 = BlocoD.RegD001.RegD010s.Last().RegD350s.Last();

                    if (regD350.RegD359s == null)
                        regD350.RegD359s = new List<BlocoD.RegistroD359>();

                    regD350.RegD359s.Add((BlocoD.RegistroD359)registro);
                    break;

                case "D500":
                    regD010 = BlocoD.RegD001.RegD010s.Last();

                    if (regD010.RegD500s == null)
                        regD010.RegD500s = new List<BlocoD.RegistroD500>();

                    regD010.RegD500s.Add((BlocoD.RegistroD500)registro);
                    break;

                case "D501":
                    var regD500 = BlocoD.RegD001.RegD010s.Last().RegD500s.Last();

                    if (regD500.RegD501s == null)
                        regD500.RegD501s = new List<BlocoD.RegistroD501>();

                    regD500.RegD501s.Add((BlocoD.RegistroD501)registro);
                    break;

                case "D505":
                    regD500 = BlocoD.RegD001.RegD010s.Last().RegD500s.Last();

                    if (regD500.RegD505s == null)
                        regD500.RegD505s = new List<BlocoD.RegistroD505>();

                    regD500.RegD505s.Add((BlocoD.RegistroD505)registro);
                    break;

                case "D509":
                    regD500 = BlocoD.RegD001.RegD010s.Last().RegD500s.Last();

                    if (regD500.RegD509s == null)
                        regD500.RegD509s = new List<BlocoD.RegistroD509>();

                    regD500.RegD509s.Add((BlocoD.RegistroD509)registro);
                    break;

                case "D600":
                    regD010 = BlocoD.RegD001.RegD010s.Last();

                    if (regD010.RegD600s == null)
                        regD010.RegD600s = new List<BlocoD.RegistroD600>();

                    regD010.RegD600s.Add((BlocoD.RegistroD600)registro);
                    break;

                case "D601":
                    var regD600 = BlocoD.RegD001.RegD010s.Last().RegD600s.Last();

                    if (regD600.RegD601s == null)
                        regD600.RegD601s = new List<BlocoD.RegistroD601>();

                    regD600.RegD601s.Add((BlocoD.RegistroD601)registro);
                    break;

                case "D605":
                    regD600 = BlocoD.RegD001.RegD010s.Last().RegD600s.Last();

                    if (regD600.RegD605s == null)
                        regD600.RegD605s = new List<BlocoD.RegistroD605>();

                    regD600.RegD605s.Add((BlocoD.RegistroD605)registro);
                    break;

                case "D609":
                    regD600 = BlocoD.RegD001.RegD010s.Last().RegD600s.Last();

                    if (regD600.RegD609s == null)
                        regD600.RegD609s = new List<BlocoD.RegistroD609>();

                    regD600.RegD609s.Add((BlocoD.RegistroD609)registro);
                    break;

                case "D990": BlocoD.RegD990 = (BlocoD.RegistroD990)registro; break;
            }
        }

        private void LerBlocoF(RegistroBaseSped registro)
        {
            if (BlocoF == null)
                BlocoF = new BlocoF();

            switch (registro.Reg)
            {
                case "F001": BlocoF.RegF001 = (BlocoF.RegistroF001)registro; break;

                case "F010":
                    var regF001 = BlocoF.RegF001;

                    if (regF001.RegF010s == null)
                        regF001.RegF010s = new List<BlocoF.RegistroF010>();

                    regF001.RegF010s.Add((BlocoF.RegistroF010)registro);
                    break;

                case "F100":
                    var regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF100s == null)
                        regF010.RegF100s = new List<BlocoF.RegistroF100>();

                    regF010.RegF100s.Add((BlocoF.RegistroF100)registro);
                    break;

                case "F111":
                    var regF100 = BlocoF.RegF001.RegF010s.Last().RegF100s.Last();

                    if (regF100.RegF111s == null)
                        regF100.RegF111s = new List<BlocoF.RegistroF111>();

                    regF100.RegF111s.Add((BlocoF.RegistroF111)registro);
                    break;

                case "F120":
                    regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF120s == null)
                        regF010.RegF120s = new List<BlocoF.RegistroF120>();

                    regF010.RegF120s.Add((BlocoF.RegistroF120)registro);
                    break;

                case "F129":
                    var regF120 = BlocoF.RegF001.RegF010s.Last().RegF120s.Last();

                    if (regF120.RegF129s == null)
                        regF120.RegF129s = new List<BlocoF.RegistroF129>();

                    regF120.RegF129s.Add((BlocoF.RegistroF129)registro);
                    break;

                case "F130":
                    regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF130s == null)
                        regF010.RegF130s = new List<BlocoF.RegistroF130>();

                    regF010.RegF130s.Add((BlocoF.RegistroF130)registro);
                    break;

                case "F139":
                    var regF130 = BlocoF.RegF001.RegF010s.Last().RegF130s.Last();

                    if (regF130.RegF139s == null)
                        regF130.RegF139s = new List<BlocoF.RegistroF139>();

                    regF130.RegF139s.Add((BlocoF.RegistroF139)registro);
                    break;

                case "F150":
                    regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF150s == null)
                        regF010.RegF150s = new List<BlocoF.RegistroF150>();

                    regF010.RegF150s.Add((BlocoF.RegistroF150)registro);
                    break;

                case "F200":
                    regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF200s == null)
                        regF010.RegF200s = new List<BlocoF.RegistroF200>();

                    regF010.RegF200s.Add((BlocoF.RegistroF200)registro);
                    break;

                case "F205":
                    var regF200 = BlocoF.RegF001.RegF010s.Last().RegF200s.Last();
                    regF200.RegF205 = (BlocoF.RegistroF205)registro;
                    break;

                case "F210":
                    regF200 = BlocoF.RegF001.RegF010s.Last().RegF200s.Last();

                    if (regF200.RegF210s == null)
                        regF200.RegF210s = new List<BlocoF.RegistroF210>();

                    regF200.RegF210s.Add((BlocoF.RegistroF210)registro);
                    break;

                case "F211":
                    regF200 = BlocoF.RegF001.RegF010s.Last().RegF200s.Last();

                    if (regF200.RegF211s == null)
                        regF200.RegF211s = new List<BlocoF.RegistroF211>();

                    regF200.RegF211s.Add((BlocoF.RegistroF211)registro);
                    break;

                case "F500":
                    regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF500s == null)
                        regF010.RegF500s = new List<BlocoF.RegistroF500>();

                    regF010.RegF500s.Add((BlocoF.RegistroF500)registro);
                    break;

                case "F509":
                    var regF500 = BlocoF.RegF001.RegF010s.Last().RegF500s.Last();

                    if (regF500.RegF509s == null)
                        regF500.RegF509s = new List<BlocoF.RegistroF509>();

                    regF500.RegF509s.Add((BlocoF.RegistroF509)registro);
                    break;

                case "F510":
                    regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF510s == null)
                        regF010.RegF510s = new List<BlocoF.RegistroF510>();

                    regF010.RegF510s.Add((BlocoF.RegistroF510)registro);
                    break;

                case "F519":
                    var regF510 = BlocoF.RegF001.RegF010s.Last().RegF510s.Last();

                    if (regF510.RegF519s == null)
                        regF510.RegF519s = new List<BlocoF.RegistroF519>();

                    regF510.RegF519s.Add((BlocoF.RegistroF519)registro);
                    break;

                case "F525":
                    regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF525s == null)
                        regF010.RegF525s = new List<BlocoF.RegistroF525>();

                    regF010.RegF525s.Add((BlocoF.RegistroF525)registro);
                    break;

                case "F550":
                    regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF550s == null)
                        regF010.RegF550s = new List<BlocoF.RegistroF550>();

                    regF010.RegF550s.Add((BlocoF.RegistroF550)registro);
                    break;

                case "F559":
                    var regF550 = BlocoF.RegF001.RegF010s.Last().RegF550s.Last();

                    if (regF550.RegF559s == null)
                        regF550.RegF559s = new List<BlocoF.RegistroF559>();

                    regF550.RegF559s.Add((BlocoF.RegistroF559)registro);
                    break;

                case "F560":
                    regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF560s == null)
                        regF010.RegF560s = new List<BlocoF.RegistroF560>();

                    regF010.RegF560s.Add((BlocoF.RegistroF560)registro);
                    break;

                case "F569":
                    var regF560 = BlocoF.RegF001.RegF010s.Last().RegF560s.Last();

                    if (regF560.RegF569s == null)
                        regF560.RegF569s = new List<BlocoF.RegistroF569>();

                    regF560.RegF569s.Add((BlocoF.RegistroF569)registro);
                    break;

                case "F600":
                    regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF600s == null)
                        regF010.RegF600s = new List<BlocoF.RegistroF600>();

                    regF010.RegF600s.Add((BlocoF.RegistroF600)registro);
                    break;

                case "F700":
                    regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF700s == null)
                        regF010.RegF700s = new List<BlocoF.RegistroF700>();

                    regF010.RegF700s.Add((BlocoF.RegistroF700)registro);
                    break;

                case "F800":
                    regF010 = BlocoF.RegF001.RegF010s.Last();

                    if (regF010.RegF800s == null)
                        regF010.RegF800s = new List<BlocoF.RegistroF800>();

                    regF010.RegF800s.Add((BlocoF.RegistroF800)registro);
                    break;

                case "F990": BlocoF.RegF990 = (BlocoF.RegistroF990)registro; break;
            }
        }

        private void LerBlocoI(RegistroBaseSped registro)
        {
            if (BlocoI == null)
                BlocoI = new BlocoI();

            switch (registro.Reg)
            {
                case "I001": BlocoI.RegI001 = (BlocoI.RegistroI001)registro; break;

                case "I010":
                    var regI001 = BlocoI.RegI001;

                    if (regI001.RegI010s == null)
                        regI001.RegI010s = new List<BlocoI.RegistroI010>();

                    regI001.RegI010s.Add((BlocoI.RegistroI010)registro);
                    break;

                case "I100":
                    var regI010 = BlocoI.RegI001.RegI010s.Last();

                    if (regI010.RegI100s == null)
                        regI010.RegI100s = new List<BlocoI.RegistroI100>();

                    regI010.RegI100s.Add((BlocoI.RegistroI100)registro);
                    break;

                case "I199":
                    var reg100 = BlocoI.RegI001.RegI010s.Last().RegI100s.Last();

                    if (reg100.RegI199s == null)
                        reg100.RegI199s = new List<BlocoI.RegistroI199>();

                    reg100.RegI199s.Add((BlocoI.RegistroI199)registro);
                    break;

                case "I200":
                    reg100 = BlocoI.RegI001.RegI010s.Last().RegI100s.Last();

                    if (reg100.RegI200s == null)
                        reg100.RegI200s = new List<BlocoI.RegistroI200>();

                    reg100.RegI200s.Add((BlocoI.RegistroI200)registro);
                    break;

                case "I299":
                    var regI200 = BlocoI.RegI001.RegI010s.Last().RegI100s.Last().RegI200s.Last();

                    if (regI200.RegI299s == null)
                        regI200.RegI299s = new List<BlocoI.RegistroI299>();

                    regI200.RegI299s.Add((BlocoI.RegistroI299)registro);
                    break;

                case "I300":
                    regI200 = BlocoI.RegI001.RegI010s.Last().RegI100s.Last().RegI200s.Last();

                    if (regI200.RegI300s == null)
                        regI200.RegI300s = new List<BlocoI.RegistroI300>();

                    regI200.RegI300s.Add((BlocoI.RegistroI300)registro);
                    break;

                case "I399":
                    var regI300 = BlocoI.RegI001.RegI010s.Last().RegI100s.Last().RegI200s.Last().RegI300s.Last();

                    if (regI300.RegI399s == null)
                        regI300.RegI399s = new List<BlocoI.RegistroI399>();

                    regI300.RegI399s.Add((BlocoI.RegistroI399)registro);
                    break;

                case "I990": BlocoI.RegI990 = (BlocoI.RegistroI990)registro; break;
            }
        }

        private void LerBlocoM(RegistroBaseSped registro)
        {
            if (BlocoM == null)
                BlocoM = new BlocoM();

            switch (registro.Reg)
            {
                case "M001": BlocoM.RegM001 = (BlocoM.RegistroM001)registro; break;

                case "M100":
                    var regM001 = BlocoM.RegM001;

                    if (regM001.RegM100s == null)
                        regM001.RegM100s = new List<BlocoM.RegistroM100>();

                    regM001.RegM100s.Add((BlocoM.RegistroM100)registro);
                    break;

                case "M105":
                    var regM100 = BlocoM.RegM001.RegM100s.Last();

                    if (regM100.RegM105s == null)
                        regM100.RegM105s = new List<BlocoM.RegistroM105>();

                    regM100.RegM105s.Add((BlocoM.RegistroM105)registro);
                    break;

                case "M110":
                    regM100 = BlocoM.RegM001.RegM100s.Last();

                    if (regM100.RegM110s == null)
                        regM100.RegM110s = new List<BlocoM.RegistroM110>();

                    regM100.RegM110s.Add((BlocoM.RegistroM110)registro);
                    break;

                case "M115":
                    var regM110 = BlocoM.RegM001.RegM100s.Last().RegM110s.Last();

                    if (regM110.RegM115s == null)
                        regM110.RegM115s = new List<BlocoM.RegistroM115>();

                    regM110.RegM115s.Add((BlocoM.RegistroM115)registro);
                    break;

                case "M200":
                    regM001 = BlocoM.RegM001;
                    regM001.RegM200 = (BlocoM.RegistroM200)registro;
                    break;

                case "M205":
                    var regM200 = BlocoM.RegM001.RegM200;

                    if (regM200.RegM205s == null)
                        regM200.RegM205s = new List<BlocoM.RegistroM205>();

                    regM200.RegM205s.Add((BlocoM.RegistroM205)registro);
                    break;

                case "M210":
                    regM200 = BlocoM.RegM001.RegM200;

                    if (regM200.RegM210s == null)
                        regM200.RegM210s = new List<BlocoM.RegistroM210>();

                    regM200.RegM210s.Add((BlocoM.RegistroM210)registro);
                    break;

                case "M211":
                    var regM210 = BlocoM.RegM001.RegM200.RegM210s.Last();
                    regM210.RegM211 = (BlocoM.RegistroM211)registro;
                    break;

                case "M215":
                    regM210 = BlocoM.RegM001.RegM200.RegM210s.Last();

                    if (regM210.RegM215s == null)
                        regM210.RegM215s = new List<BlocoM.RegistroM215>();

                    regM210.RegM215s.Add((BlocoM.RegistroM215)registro);
                    break;

                case "M220":
                    regM210 = BlocoM.RegM001.RegM200.RegM210s.Last();

                    if (regM210.RegM220s == null)
                        regM210.RegM220s = new List<BlocoM.RegistroM220>();

                    regM210.RegM220s.Add((BlocoM.RegistroM220)registro);
                    break;

                case "M225":
                    var regM220 = BlocoM.RegM001.RegM200.RegM210s.Last().RegM220s.Last();

                    if (regM220.RegM225s == null)
                        regM220.RegM225s = new List<BlocoM.RegistroM225>();

                    regM220.RegM225s.Add((BlocoM.RegistroM225)registro);
                    break;

                case "M230":
                    regM210 = BlocoM.RegM001.RegM200.RegM210s.Last();

                    if (regM210.RegM230s == null)
                        regM210.RegM230s = new List<BlocoM.RegistroM230>();

                    regM210.RegM230s.Add((BlocoM.RegistroM230)registro);
                    break;

                case "M300":
                    regM001 = BlocoM.RegM001;

                    if (regM001.RegM300s == null)
                        regM001.RegM300s = new List<BlocoM.RegistroM300>();

                    regM001.RegM300s.Add((BlocoM.RegistroM300)registro);
                    break;

                case "M350":
                    regM001 = BlocoM.RegM001;
                    regM001.RegM350 = (BlocoM.RegistroM350)registro;
                    break;

                case "M400":
                    regM001 = BlocoM.RegM001;

                    if (regM001.RegM400s == null)
                        regM001.RegM400s = new List<BlocoM.RegistroM400>();

                    regM001.RegM400s.Add((BlocoM.RegistroM400)registro);
                    break;

                case "M410":
                    var regM400 = BlocoM.RegM001.RegM400s.Last();

                    if (regM400.RegM410s == null)
                        regM400.RegM410s = new List<BlocoM.RegistroM410>();

                    regM400.RegM410s.Add((BlocoM.RegistroM410)registro);
                    break;

                case "M500":
                    regM001 = BlocoM.RegM001;

                    if (regM001.RegM500s == null)
                        regM001.RegM500s = new List<BlocoM.RegistroM500>();

                    regM001.RegM500s.Add((BlocoM.RegistroM500)registro);
                    break;

                case "M505":
                    var regM500 = BlocoM.RegM001.RegM500s.Last();

                    if (regM500.RegM505s == null)
                        regM500.RegM505s = new List<BlocoM.RegistroM505>();

                    regM500.RegM505s.Add((BlocoM.RegistroM505)registro);
                    break;

                case "M510":
                    regM500 = BlocoM.RegM001.RegM500s.Last();

                    if (regM500.RegM510s == null)
                        regM500.RegM510s = new List<BlocoM.RegistroM510>();

                    regM500.RegM510s.Add((BlocoM.RegistroM510)registro);
                    break;

                case "M515":
                    var regM510 = BlocoM.RegM001.RegM500s.Last().RegM510s.Last();

                    if (regM510.RegM515s == null)
                        regM510.RegM515s = new List<BlocoM.RegistroM515>();

                    regM510.RegM515s.Add((BlocoM.RegistroM515)registro);
                    break;

                case "M600":
                    regM001 = BlocoM.RegM001;
                    regM001.RegM600 = (BlocoM.RegistroM600)registro;
                    break;

                case "M605":
                    var regM600 = BlocoM.RegM001.RegM600;

                    if (regM600.RegM605s == null)
                        regM600.RegM605s = new List<BlocoM.RegistroM605>();

                    regM600.RegM605s.Add((BlocoM.RegistroM605)registro);
                    break;

                case "M610":
                    regM600 = BlocoM.RegM001.RegM600;

                    if (regM600.RegM610s == null)
                        regM600.RegM610s = new List<BlocoM.RegistroM610>();

                    regM600.RegM610s.Add((BlocoM.RegistroM610)registro);
                    break;

                case "M611":
                    var regM610 = BlocoM.RegM001.RegM600.RegM610s.Last();
                    regM610.RegM611 = (BlocoM.RegistroM611)registro;
                    break;

                case "M615":
                    regM610 = BlocoM.RegM001.RegM600.RegM610s.Last();

                    if (regM610.RegM615s == null)
                        regM610.RegM615s = new List<BlocoM.RegistroM615>();

                    regM610.RegM615s.Add((BlocoM.RegistroM615)registro);
                    break;

                case "M620":
                    regM610 = BlocoM.RegM001.RegM600.RegM610s.Last();

                    if (regM610.RegM620s == null)
                        regM610.RegM620s = new List<BlocoM.RegistroM620>();

                    regM610.RegM620s.Add((BlocoM.RegistroM620)registro);
                    break;

                case "M625":
                    var regM620 = BlocoM.RegM001.RegM600.RegM610s.Last().RegM620s.Last();

                    if (regM620.RegM625s == null)
                        regM620.RegM625s = new List<BlocoM.RegistroM625>();

                    regM620.RegM625s.Add((BlocoM.RegistroM625)registro);
                    break;

                case "M630":
                    regM610 = BlocoM.RegM001.RegM600.RegM610s.Last();

                    if (regM610.RegM630s == null)
                        regM610.RegM630s = new List<BlocoM.RegistroM630>();

                    regM610.RegM630s.Add((BlocoM.RegistroM630)registro);
                    break;

                case "M700":
                    regM001 = BlocoM.RegM001;

                    if (regM001.RegM700s == null)
                        regM001.RegM700s = new List<BlocoM.RegistroM700>();

                    regM001.RegM700s.Add((BlocoM.RegistroM700)registro);
                    break;

                case "M800":
                    regM001 = BlocoM.RegM001;

                    if (regM001.RegM800s == null)
                        regM001.RegM800s = new List<BlocoM.RegistroM800>();

                    regM001.RegM800s.Add((BlocoM.RegistroM800)registro);
                    break;

                case "M810":
                    var regM800 = BlocoM.RegM001.RegM800s.Last();

                    if (regM800.RegM810s == null)
                        regM800.RegM810s = new List<BlocoM.RegistroM810>();

                    regM800.RegM810s.Add((BlocoM.RegistroM810)registro);
                    break;

                case "M990": BlocoM.RegM990 = (BlocoM.RegistroM990)registro; break;
            }
        }

        private void LerBlocoP(RegistroBaseSped registro)
        {
            if (BlocoP == null)
                BlocoP = new BlocoP();

            switch (registro.Reg)
            {
                case "P001": BlocoP.RegP001 = (BlocoP.RegistroP001)registro; break;

                case "P010":
                    var regP001 = BlocoP.RegP001;

                    if (regP001.RegP010s == null)
                        regP001.RegP010s = new List<BlocoP.RegistroP010>();

                    regP001.RegP010s.Add((BlocoP.RegistroP010)registro);
                    break;

                case "P100":
                    var regP010 = BlocoP.RegP001.RegP010s.Last();

                    if (regP010.RegP100s == null)
                        regP010.RegP100s = new List<BlocoP.RegistroP100>();

                    regP010.RegP100s.Add((BlocoP.RegistroP100)registro);
                    break;

                case "P110":
                    var regP100 = BlocoP.RegP001.RegP010s.Last().RegP100s.Last();

                    if (regP100.RegP110s == null)
                        regP100.RegP110s = new List<BlocoP.RegistroP110>();

                    regP100.RegP110s.Add((BlocoP.RegistroP110)registro);
                    break;

                case "P199":
                    regP100 = BlocoP.RegP001.RegP010s.Last().RegP100s.Last();

                    if (regP100.RegP199s == null)
                        regP100.RegP199s = new List<BlocoP.RegistroP199>();

                    regP100.RegP199s.Add((BlocoP.RegistroP199)registro);
                    break;

                case "P200":
                    regP001 = BlocoP.RegP001;

                    if (regP001.RegP200s == null)
                        regP001.RegP200s = new List<BlocoP.RegistroP200>();

                    regP001.RegP200s.Add((BlocoP.RegistroP200)registro);
                    break;

                case "P210":
                    var regP200 = BlocoP.RegP001.RegP200s.Last();

                    if (regP200.RegP210s == null)
                        regP200.RegP210s = new List<BlocoP.RegistroP210>();

                    regP200.RegP210s.Add((BlocoP.RegistroP210)registro);
                    break;


                case "P990": BlocoP.RegP990 = (BlocoP.RegistroP990)registro; break;
            }
        }

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

                if (BlocoA != null)
                    BlocoA.RegA990 = new BlocoA.RegistroA990() { QtdLinA = registros.Where(x => x.StartsWith("A")).Count() + 1 };

                if (BlocoC != null)
                    BlocoC.RegC990 = new BlocoC.RegistroC990() { QtdLinC = registros.Where(x => x.StartsWith("C")).Count() + 1 };

                if (BlocoD != null)
                    BlocoD.RegD990 = new BlocoD.RegistroD990() { QtdLinD = registros.Where(x => x.StartsWith("D")).Count() + 1 };

                if (BlocoF != null)
                    BlocoF.RegF990 = new BlocoF.RegistroF990() { QtdLinF = registros.Where(x => x.StartsWith("F")).Count() + 1 };

                if (BlocoI != null)
                    BlocoI.RegI990 = new BlocoI.RegistroI990() { QtdLinI = registros.Where(x => x.StartsWith("I")).Count() + 1 };

                if (BlocoM != null)
                    BlocoM.RegM990 = new BlocoM.RegistroM990() { QtdLinM = registros.Where(x => x.StartsWith("M")).Count() + 1 };

                if (BlocoP != null)
                    BlocoP.RegP990 = new BlocoP.RegistroP990() { QtdLinP = registros.Where(x => x.StartsWith("P")).Count() + 1 };

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

            GerarComFilhos(BlocoA);

            GerarComFilhos(BlocoC);

            GerarComFilhos(BlocoD);

            GerarComFilhos(BlocoF);

            GerarComFilhos(BlocoI);

            GerarComFilhos(BlocoM);

            GerarComFilhos(BlocoP);

            GerarComFilhos(Bloco1);

            GerarComFilhos(Bloco9);
        }
    }
}
