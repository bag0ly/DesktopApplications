namespace haromszogekCLI_gyakorlas
{
    public class Haromszogek
    {
        public Haromszogek(string sor)
        {
            string[] strings = sor.Split(' ');
            A = Convert.ToInt32(strings[0]);
            B = Convert.ToInt32(strings[1]);
            C = Convert.ToInt32(strings[2]);
        }

        public int A { get;private set; }
        public int B { get;private set; }
        public int C { get;private set; }


    }
    public class Program
    {
        public static bool DerekszogE(int a, int b, int c)
        {
            return Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2);
        }

        static List<Haromszogek> haromszogeks = new List<Haromszogek>();
        static void Main(string[] args)
        {
            foreach (var item in File.ReadAllLines("haromszogek2.csv"))
            {
                Haromszogek haromszogek = new Haromszogek(item);
                haromszogeks.Add(haromszogek);
            }
            Console.WriteLine(haromszogeks.Count());

            var derekszogek = haromszogeks.Where(x => DerekszogE(x.A, x.B, x.C)).ToList();
            foreach (var item in derekszogek)
            {
                Console.WriteLine($"a: {item.A} b: {item.B} c: {item.C}");
            }


            Console.ReadKey();
        }
    }
}
