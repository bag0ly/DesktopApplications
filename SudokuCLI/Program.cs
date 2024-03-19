using System.ComponentModel;
using System.Linq;

namespace SudokuCLI
{
    public class Feladvany
    {
        public string Kezdo { get; private set; }
        public int Meret { get; private set; }

        public Feladvany(string sor)
        {
            Kezdo = sor;
            Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
        }

        public void Kirajzol()
        {
            for (int i = 0; i < Kezdo.Length; i++)
            {
                if (Kezdo[i] == '0')
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write(Kezdo[i]);
                }
                if (i % Meret == Meret - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Feladvany> feladvany = new List<Feladvany>();
            foreach (string line in File.ReadAllLines("feladvanyok.txt"))
            {
                feladvany.Add(new Feladvany(line));
            }

            Console.WriteLine("4.feladat");

            int bekertszam = 0;
            do
            {
                Console.Write("Kérem a feladvány méretét: [4..9]");
                bekertszam = int.Parse(Console.ReadLine());
            } while (bekertszam<4 || bekertszam>9);

            var mennyi = feladvany.Where(x => x.Meret == bekertszam).Count();
            Console.WriteLine("Ennyi darab van: ",mennyi);

            List<Feladvany> meret = feladvany.Where(x => x.Meret == bekertszam).ToList();

            Feladvany random = meret[new Random().Next(meret.Count)];

            Console.WriteLine("5.feladat: A kiválasztott feladvány: ");

            var kitoltottseg = ((decimal)random.Kezdo.Count(x => x != '0') / random.Kezdo.Length)*100;
            Console.WriteLine($"6.feladat: A feladvány töltöttsége {Math.Round(kitoltottseg,0)}%");

            //7.feladat
            Console.WriteLine("7.feladat: A kiválasztott kirajzolása: ");
            random.Kirajzol();
            
           
        }
    }
}
