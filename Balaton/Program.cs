namespace Balaton
{
    public class Haz 
    {
        public int Adoszam { get; private set; }
        public string Utca_neve { get; private set; }
        public string Hazszam { get; private set; }
        public char Adosav { get; private set; }
        public int Alapterulet { get; private set; }

        public Haz(string sor) 
        {
            string[] strings = sor.Split(' ');
            Adoszam = Convert.ToInt32(strings[0]);
            Utca_neve = strings[1];
            Hazszam = strings[2];
            Adosav = Convert.ToChar(strings[3]);
            Alapterulet = Convert.ToInt32(strings[4]);
        }

        public void setAdosav(char adosav) 
        {
            this.Adosav = adosav;
        }
    }
    
    public class Program
    {
        public static int Ado(char adosav, int alapterulet)
        {
            int fizetendo = 0;
            switch (adosav)
            {
                case 'A':
                    fizetendo = 800 * alapterulet;
                    break;
                case 'B':
                    fizetendo = 600 * alapterulet;
                    break;
                case 'C':
                    fizetendo = 100 * alapterulet;
                    break;
            }
            if (fizetendo < 10000)
            {
                return 0;
            }
            return fizetendo;
        }
        static public List<Haz> hazak = new List<Haz>();
        static void Main(string[] args)
        {
            foreach (var item in File.ReadAllLines("utca.txt").Skip(1)) 
            {
                Haz h = new Haz(item);
                hazak.Add(h);
            }
            Console.WriteLine("2.feladat. A mintában "+hazak.Count()+" telek szerepel.");

            //3.feladat
            string beker = "";
            do
            {
                Console.WriteLine("Kérek egy adószámot: ");
                beker = Console.ReadLine();
            } while (beker.Count()<5);

            int number;
            if (int.TryParse(beker, out number))
            {
                var idealis =  hazak.Where(h => h.Adoszam == number).ToList();
                if (idealis.Any())
                {
                    foreach (var item in idealis)
                    {
                        Console.WriteLine($"{item.Utca_neve} utca {item.Hazszam}");
                    }
                }
                else
                {
                    Console.WriteLine("Nem szerepel az adatállományban.");
                }
            }
            else 
            {
                Console.WriteLine("Nem szerepel az adatállományban.");
            }

            //5.feladat
            var asav = hazak.Where(h => h.Adosav=='A').ToList();
            var bsav = hazak.Where(h => h.Adosav == 'B').ToList();
            var csav = hazak.Where(h => h.Adosav == 'C').ToList();

            Console.WriteLine($"A sávban {asav.Count()} telek esik, az adó {asav.Sum(x => Ado(x.Adosav, x.Alapterulet))}");

            Console.WriteLine($"A sávban {bsav.Count()} telek esik, az adó {bsav.Sum(x => Ado(x.Adosav, x.Alapterulet))}");

            Console.WriteLine($"A sávban {csav.Count()} telek esik, az adó {csav.Sum(x => Ado(x.Adosav, x.Alapterulet))}");

            //6.feladat
            using (StreamWriter sw = new StreamWriter("utca2.txt")) 
            {
                foreach (var item in hazak)
                {
                    sw.WriteLine($"{item.Adoszam} {item.Utca_neve} {item.Hazszam} {item.Adosav} {item.Alapterulet} {Ado(item.Adosav,item.Alapterulet)}");
                }
            }

                Console.ReadKey();
        }
    }
}
