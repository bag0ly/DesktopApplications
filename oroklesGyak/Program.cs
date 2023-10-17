namespace oroklesGyak
{
    interface IArlap
    {
        double MennyibeKerul();
    }

    abstract class Peksutemeny : IArlap
    {
        protected int mennyiseg;
        private double alapAr;

        protected Peksutemeny(int mennyiseg, double alapar)
        {
            this.mennyiseg = mennyiseg;
            alapAr = alapar;
        }
        public int Mennyi() 
        {
           return mennyiseg;
        }

        public abstract void Megkostol();

        public double MennyibeKerul()
        {
            return alapAr * mennyiseg;
        }
        public override string? ToString()
        {
            return $"{mennyiseg}db - {MennyibeKerul()}Ft";
        }
    }

    class Pogacsa : Peksutemeny
    {
        public Pogacsa(int mennyiseg, double alapar) : base(mennyiseg, alapar)
        {
        }

        public override void Megkostol()
        {
            mennyiseg /= 2;
        }
        public override string ToString()
        {
            return $"Pogacsa {base.ToString()}";
        }
    }

    class Kave : IArlap
    {
        private bool habosE;
        const double CSESZEKAVE = 180;
        public double ar;

        public Kave(bool habosE)
        {
            this.habosE = habosE;
        }

        public double MennyibeKerul()
        {
            return habosE ? CSESZEKAVE * 1.5 : CSESZEKAVE;
        }

        public override string ToString()
        {
            return $"{(habosE ? "Habos" : "Nem habos")} kávé {MennyibeKerul()}Ft";
        }
        public bool kiIrHabos()
        {
            return habosE;
        }
    }
    internal class Futtato
    {
        static List<IArlap> arlap = new List<IArlap>();
        static void Vasarlok(string utvonal)
        {
            using (StreamReader sr = new StreamReader(utvonal))
            {
                while (!sr.EndOfStream) 
                {
                    string[] x = sr.ReadLine().Split(' ');
                    if (x[0] == "Pogacsa") arlap.Add(new Pogacsa(int.Parse(x[1]), double.Parse(x[2])));
                    else arlap.Add(new Kave(x[1]=="habos"));
                }
            }
        }
        static void Main(string[] args)
        {
            Vasarlok("Pekseg.txt");

            //1.feladat Számolja meg mennyi van összesen
            Console.WriteLine("------------");
            Console.WriteLine(arlap.Count);
            //2.feladat írja ki az itemeket
            Console.WriteLine("------------");
            Console.WriteLine(string.Join("\n", arlap));
            //3.feladat Csak a pogácsákat írd ki
            Console.WriteLine("------------");
            var pogacsaItems = arlap.OfType<Pogacsa>();
            foreach (var item in pogacsaItems)
            {
                Console.WriteLine(item);
            }
            //4.feladat Csak azokat a kávékat amik nem habosak
            Console.WriteLine("------------");
            var nemHabosKaveItems = arlap.OfType<Kave>().Where(kave => !kave.kiIrHabos());
            foreach (var item in nemHabosKaveItems)
            {
                Console.WriteLine(item);
            }
            //5.feladat Összesísd az árát és azt írasd ki
            Console.WriteLine("------------");
            var teljes = arlap.Sum(item => item.MennyibeKerul());
            Console.WriteLine($"Minden ennyibe kerül összesen: {teljes} Ft");
            //7.feladat Legdrágább dolog visszakérése
            Console.WriteLine("------------");
            var legDragabb = arlap.OrderByDescending(item => item.MennyibeKerul()).FirstOrDefault();
            Console.WriteLine($"Legdrágább dolog: {legDragabb}");
            //8.feladat írja ki az öss árát a pogácsáknak
            Console.WriteLine("------------");
            var osszPogacsaar = arlap.OfType<Pogacsa>().Sum(pogacsa => pogacsa.MennyibeKerul());
            Console.WriteLine($"Az össz ára a pogácsáknak: {osszPogacsaar} Ft");
            Console.WriteLine("------------");
            //9.feladat Számítsa ki a kávénak az átlag árát
            var atlagKavear = arlap.OfType<Kave>().Average(kave => kave.MennyibeKerul());
            Console.WriteLine($"Átlag Kávé ára: {atlagKavear} Ft");
            Console.WriteLine("------------");
            //10.feladat Adott egy minimum mennyiség és írja ki azokat a pogácsákat amik ezt meghaladják
            int min = 16; 
            var pogacsaMennyiseg = arlap.OfType<Pogacsa>().Where(pogacsa => pogacsa.Mennyi() > min);

            foreach (var item in pogacsaMennyiseg)
            {
                Console.WriteLine(item);
            }

        }
    }
}