using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola_fb
{
    public class Iskola 
    {
        //2.feladat
        public int Isk_kezd_ev {get; private set; }
        public char Osztaly { get; private set; }
        public string Diaknev { get; private set; }

        public Iskola(string sor)
        {
            string[] strings = sor.Split(';');
            Isk_kezd_ev = int.Parse(strings[0]);
            Osztaly = char.Parse(strings[1]);
            Diaknev = strings[2];
        }

        //4.feladat 
        public string AzonGen(Iskola iskola)
        {
            string evfolyam = iskola.Isk_kezd_ev.ToString().Substring(3, 1);
            string osztalyjel = iskola.Osztaly.ToString();
            string[] nev = iskola.Diaknev.ToString().Split(' ');


            return evfolyam + osztalyjel + nev[0].Substring(0, 3).ToLower() + nev[1].Substring(0,3).ToLower();

        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Iskola> iskola = new List<Iskola>();
            string path = "nevek.txt";
            foreach (var item in File.ReadAllLines(path))
            {
                iskola.Add(new Iskola(item));
            }

            //3.feldat

            foreach (Iskola item in iskola)
            {
                Console.WriteLine($"{item.Isk_kezd_ev}, {item.Osztaly}, {item.Diaknev}");
            }
            Console.WriteLine("3.feladat: "+iskola.Count());


            //4.feladat
            string elso = "";
            string utolso = "";
            foreach (Iskola item in iskola) 
            {
                elso = item.AzonGen(iskola[0]);
                utolso = item.AzonGen(iskola[iskola.Count()-1]);

            }

            Console.WriteLine($"4.feladat: Azonosító az elsőre :{elso} Azonosító az utolsóra: {utolso}");


            //6.feladat
            using (StreamWriter sw = new StreamWriter("osszestanulosesazon.txt"))
            {
                foreach (Iskola item in iskola)
                {
                    sw.WriteLine($"Neve: {item.Diaknev} Azon: {item.AzonGen(item)}");
                }
            }





        }
    }
}
