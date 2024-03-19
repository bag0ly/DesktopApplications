using System;
using System.IO;

namespace Playfair
{
    public class PlayfairKodolo
    {
        char[,] kulcstabla = new char[5, 5];

        public PlayfairKodolo(string path)
        {
            string[] adatok = File.ReadAllLines(path);

            for (int i = 0; i < adatok.Length; i++)
            {
                for (int j = 0; j < adatok[i].Length; j++)
                {
                    kulcstabla[i, j] = adatok[i][j];
                }
            }
        }

        public int SorIndex(char karakter)
        {
            for (int i = 0; i < kulcstabla.GetLength(0); i++)
            {
                for (int j = 0; j < kulcstabla.GetLength(1); j++)
                {
                    if (char.ToUpper(kulcstabla[i, j]) == karakter || char.ToLower(kulcstabla[i, j]) == karakter)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public int OszlopIndex(char karakter)
        {
            for (int i = 0; i < kulcstabla.GetLength(0); i++)
            {
                for (int j = 0; j < kulcstabla.GetLength(1); j++)
                {
                    if (char.ToUpper(kulcstabla[i, j]) == karakter || char.ToLower(kulcstabla[i, j]) == karakter)
                    {
                        return j;
                    }
                }
            }
            return -1;
        }

        public string KodolBetupar(string par)
        {
            var a = (SorIndex(par[0]), OszlopIndex(par[0]));
            var b = (SorIndex(par[1]), OszlopIndex(par[1]));

            if (a.Item1 == b.Item1)
            {
                int kovetkezo1 = a.Item2 == 4 ? 0 : a.Item2 + 1;
                int kovetkezo2 = b.Item2 == 4 ? 0 : b.Item2 + 1;

                return $"{kulcstabla[a.Item1, kovetkezo1]}{kulcstabla[b.Item1, kovetkezo2]}";
            }

            if (a.Item2 == b.Item2)
            {
                int kovetkezo1 = a.Item1 == 4 ? 0 : a.Item1 + 1;
                int kovetkezo2 = b.Item1 == 4 ? 0 : b.Item1 + 1;

                return $"{kulcstabla[kovetkezo1, a.Item2]}{kulcstabla[kovetkezo2, b.Item2]}";
            }

            return $"{kulcstabla[a.Item1, b.Item2]}{kulcstabla[b.Item1, a.Item2]}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PlayfairKodolo playfair = new PlayfairKodolo("kulcstabla.txt");

            Console.WriteLine("6.feladat: Kérek egy betűt: ");
            string betu = Console.ReadLine();
            int sor = playfair.SorIndex(betu.ToUpper()[0]);
            int oszlop = playfair.OszlopIndex(betu.ToUpper()[0]);

            Console.WriteLine($"A {sor}. sorban és a {oszlop}. oszlopban található");

            Console.WriteLine("8.feladat: Kérek egy karakter párt: ");
            string par = Console.ReadLine();
            Console.WriteLine($"Kódolva: {playfair.KodolBetupar(par)}");

            Console.ReadLine();
        }
    }
}
