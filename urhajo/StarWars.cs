using System;
using System.Collections.Generic;
using System.IO;

namespace urhajo
{
    interface IUrhajo
    {
        void Hiperugras();
        bool LeggyorsulE(IUrhajo obj, LazadoGep lg);
        double MilyenGyors();
    }

    interface IHiperhajtomu
    {
        void Hiperugras();
    }

    abstract class LazadoGep : IUrhajo
    {
        protected double sebesseg { get; set; }
        protected bool meghibasodottE { get; set; }

        public LazadoGep(double sebesseg, bool meghibasodottE)
        {
            this.sebesseg = sebesseg;
            this.meghibasodottE = meghibasodottE;
        }

        public abstract bool ElkapjaAVonosugar(LazadoGep lg);

        public double MilyenGyors()
        {
            return sebesseg;
        }

        public void Hiperugras()
        {
            throw new NotImplementedException();
        }

        public bool LeggyorsulE(IUrhajo obj, LazadoGep lg)
        {
            if (obj.MilyenGyors() > lg.sebesseg && !lg.meghibasodottE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class XWing : LazadoGep, IHiperhajtomu
    {
        public XWing(double sebesseg, bool meghibasodottE) : base(sebesseg, meghibasodottE)
        {
            // Az értékek hozzáadása a konstruktorban
        }

        public void Hiperugras()
        {
            Random rnd = new Random();
            sebesseg += rnd.Next(0, 101);
        }

        public override bool ElkapjaAVonosugar(LazadoGep lg)
        {
            if (lg.MilyenGyors() <= 1000 && lg.meghibasodottE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "X-Wingről van szó";
        }
    }

    class MilleniumFalcon : LazadoGep, IHiperhajtomu
    {
        protected double tapasztalat;

        public MilleniumFalcon(double tapasztalat) : base(0, false)
        {
            this.tapasztalat = tapasztalat;
        }

        public void Hiperugras()
        {
            tapasztalat += 500;
        }

        public override bool ElkapjaAVonosugar(LazadoGep lg)
        {
            // Implementáció hozzáadása
            return false;
        }

        public override string ToString()
        {
            return $"Millenium Falcon sebessége: {MilyenGyors()}, tapasztalata: {tapasztalat}";
        }
    }

    internal class StarWars
    {
        static List<IUrhajo> arlap = new List<IUrhajo>();

        static void Starwars(string utvonal)
        {
            using (StreamReader sr = new StreamReader(utvonal))
            {
                while (!sr.EndOfStream)
                {
                    string[] x = sr.ReadLine().Split(' ');

                    if (x.Length >= 3)
                    {
                        string nev = x[0];
                        double sebesseg = double.Parse(x[1]);
                        bool meghibasodott = bool.Parse(x[2]);

                        switch (nev)
                        {
                            case "XWing":
                                arlap.Add(new XWing(sebesseg, meghibasodott));
                                break;
                            case "MilleniumFalcon":
                                arlap.Add(new MilleniumFalcon(sebesseg));
                                break;
                            default:
                                Console.WriteLine("Ismeretlen űrhajótípus a fájlban.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hibás sor a fájlban.");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Starwars("Urhajok.txt");
            Console.WriteLine(arlap.Count);
        }
    }
}
