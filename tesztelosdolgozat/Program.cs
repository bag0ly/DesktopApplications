using System;
using System.Collections.Generic;

namespace tesztelosdolgozat
{
    public class Osztas
    {
        public static List<int> eredmeny = new List<int>();

        public void TobbOszto(int numberofattempts)
        {
            for (int i = 0; i < numberofattempts; i++)
            {
                int x = int.Parse(Console.ReadLine());
                int paros = 0;
                int paratlan = 0;

                for (int j = 1; j <= x; j++)
                {
                    if (x % j == 0)
                    {
                        if (j % 2 == 0)
                        {
                            paros++;
                        }
                        else
                        {
                            paratlan++;
                        }
                    }
                }
                if (paros == paratlan)
                {
                    eredmeny.Add(0);
                }
                else if (paratlan > paros)
                {
                    eredmeny.Add(1);
                }
                else
                {
                    eredmeny.Add(2);
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberofattempts = int.Parse(Console.ReadLine());

            Osztas osztasInstance = new Osztas();
            osztasInstance.TobbOszto(numberofattempts);

            foreach (int x in Osztas.eredmeny)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();
        }
    }
}
