using System.Runtime.CompilerServices;

namespace gyakorlas1003
{
    class Kor:Pont
    {
       
        static int kdb = 0;
        private Pont kp { get; set; }
        private double r { get; set; }
        public Kor(Pont kp,double r)
        {
            this.kp = kp; 
            this.r = r;
            kdb++;
        }

        public Kor(int x,int y,int r)
        {
            kp = new Pont(x, y);
            this.r = r;
            kdb++;
        }

        public Kor()
        {
            kp= new Pont();
            r = 1;
            kdb++;
        }
        public double Kerulet() 
        {
            return 2 * r * Math.PI;
        }
        public double Terulet()
        {
            return Math.Pow(r,2) * Math.PI;
        }
        public void Kiir() 
        {
            Console.WriteLine(kdb);
        }
        public void Eltol(int xeltol, int yeltol)
        {
            kp.x += xeltol;
            kp.y += yeltol;
        }

        public override string? ToString()
        {
            return $"Kör sugara: {r}, Középpontja: {kp}, " +
                $"Kerülete: {Kerulet()}, Terület: {Terulet()}";
        }
    }
    class Pont
    {
        private static readonly int Xd = 1;
        private static int Yd = 2;
        
        public int x { get; set; }
        public int y { get; set; }

        public int xeltol { get; set; }
        public int yeltol { get; set; }
        public Pont()
        {
            x=Xd; 
            y=Yd;
        }

        public Pont(int x, int y)
        {
            this.x = x; 
            this.y = y;
        }

        public override string? ToString()
        {
            return $"X: {x} Y: {y}";
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Kor k = new Kor(1,4,5);
            Console.WriteLine(k);
            Kor k2 = new Kor(new Pont(2,5),3);
            k2.Eltol(-1, -1);
            Console.WriteLine(k2);
            Kor k3 = new Kor();
            Console.WriteLine(k3);
        }
    }
}