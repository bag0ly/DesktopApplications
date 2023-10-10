using System.Data.Common;

namespace dolgozat_fb
{
    internal class Program
    {
        static List<string> noi = new List<string>();
        static List<string> ferfi = new List<string>();
        static List<string> vezetek = new List<string>();
        static List<Tanulo> tanulok = new List<Tanulo>();
        static Random rnd = new Random();
        class Tanulo 
        {

            private double Atlag { get; set; }
            public double atlag
            {
                get =>Atlag; set
                {
                    if (value <= 5.0 && value >= 1.0)
                    {
                        Atlag = value;
                    }
                }
            }
            public readonly int kor;
            private string nev { get; set; }
            private string osztaly { get; set; }
            public int darab;
            protected string iskola;

            public Tanulo(double atlag, string nev, string osztaly)
            {
                this.atlag = atlag;
                this.nev = nev;
                this.osztaly = osztaly;
                kor=rnd.Next(14, 20);
                darab++;
            }
            public string GetNev()
            {
                return nev;
            }
            public string SetNev(string nev) 
            {
                return this.nev = nev;
            }

            public override string? ToString()
            {
                return $"Név:{nev}, Kor:{kor}év, Osztály:{osztaly}, Átlag:{atlag}";
            }
        }
        static void Main(string[] args)
        {
            StreamReader sr_ferfi = new StreamReader("ferfi.txt");
            while (!sr_ferfi.EndOfStream)
            {
                string sor = sr_ferfi.ReadLine();
                ferfi.Add(sor);
            }
            StreamReader sr_noi = new StreamReader("noi.txt");
            while (!sr_noi.EndOfStream)
            {
                string sor = sr_noi.ReadLine();
                noi.Add(sor);
            }
            StreamReader sr_vezetek = new StreamReader("vezeteknevek.txt");
            while (!sr_vezetek.EndOfStream)
            {
                string sor = sr_vezetek.ReadLine();
                vezetek.Add(sor);
            }
            string[] osztalyB = { "A", "B", "C", "D", "E" };
            int[] osztalySz = { 9, 10, 11, 12, 13, 14 };

            double atlag;
            string fnev;
            string Nnev;
            string osztaly;
            Tanulo tanulo;
            for (int i = 0; i < 20; i++)
            {
                atlag = 1.0 + rnd.NextDouble() * (5.0 - 1.0);
                fnev = vezetek[rnd.Next(1, vezetek.Count - 1)] + " " + ferfi[rnd.Next(1, ferfi.Count - 1)];
                Nnev = vezetek[rnd.Next(1, vezetek.Count - 1)] + " " + noi[rnd.Next(1, noi.Count - 1)];
                osztaly = osztalySz[rnd.Next(1, osztalySz.Length - 1)].ToString() + osztalyB[rnd.Next(1, osztalyB.Length - 1)];
                tanulok.Add(new Tanulo(Math.Round(atlag, 2), fnev, osztaly));
                if (i > 10)
                {
                    tanulok.Add(new Tanulo(Math.Round(atlag, 2), Nnev, osztaly));
                }
                
            }
            Console.WriteLine("A legokosabb diák: "+tanulok.MaxBy(x=>x.atlag));
            var sort = tanulok.OrderBy(x => x.kor).Take(16);
            foreach (var t in sort) Console.WriteLine(t.ToString());


        }
    }
}