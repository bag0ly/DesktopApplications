using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toto
{
    internal class Program
    {
        class EredmenyElemzo
        {
            private string Eredmenyek;

            private int DontetlenekSzama
            {
                get
                {
                    return Megszamol('X');
                }
            }

            private int Megszamol(char kimenet)
            {
                int darab = 0;
                foreach (var i in Eredmenyek)
                {
                    if (i == kimenet) darab++;
                }
                return darab;
            }

            public bool NemvoltDontetlenMerkozes
            {
                get
                {
                    return DontetlenekSzama == 0;
                }
            }

            public EredmenyElemzo(string eredmenyek) // konstruktor
            {
                Eredmenyek = eredmenyek;
            }
        }
        class Toto 
        {
            public Toto(string sor)
            {
                string[] darabok = sor.Split(';');
                Ev = int.Parse(darabok[0]);
                Het = int.Parse(darabok[1]);
                Fordulo = int.Parse(darabok[2]);
                T13p1 = int.Parse(darabok[3]);
                Ny13p1 = int.Parse(darabok[4]);
                Eredmenyek = darabok[5];

            }

            public int Ev { get; set; }
            public int Het { get; set; }
            public int Fordulo { get; set; }
            public int T13p1 { get; set; }
            public int Ny13p1 { get; set;}
            public string Eredmenyek { get; set; }
        }
        static void Main(string[] args)
        {
            List<Toto> eredmenyek = new List<Toto>();
            //2.feladat
            foreach (string sor in File.ReadAllLines("toto.txt").Skip(1)) 
            {
                eredmenyek.Add(new Toto(sor));
            }
            //3.feladat
            Console.WriteLine("3.feladat: Fordulók száma: {0}", eredmenyek.Count());
            //4.feladat
            int db_teli = 0;
            foreach (var item in eredmenyek)
            {
                db_teli += item.T13p1;
            }
            Console.WriteLine("4.feladat: Telitalálatos szelvényel száma: {0}",db_teli);
            //5.feladat
            double vegosszeg = 0;
            foreach (var item in eredmenyek)
            {
                if (item.Ny13p1>0 || item.T13p1>0)
                {
                    vegosszeg += (item.Ny13p1 * item.T13p1)/eredmenyek.Count();
                }
            }
            Console.WriteLine(vegosszeg);
            //6.feladat
            int legnagyobb = eredmenyek.Max(e => e.Ny13p1);
            int maxIndex = eredmenyek.FindIndex(e => e.Ny13p1 == legnagyobb);

            Console.WriteLine($"6.feladat: " +
                $"\nLegnagyobb " +
                $"\n\tÉv: {eredmenyek[maxIndex].Ev} " +
                $"\n\tHét: {eredmenyek[maxIndex].Het} " +
                $"\n\tForduló: {eredmenyek[maxIndex].Fordulo} " +
                $"\n\tTelitalálat :{eredmenyek[maxIndex].T13p1} " +
                $"\n\tNyeremény: {eredmenyek[maxIndex].Ny13p1} " +
                $"\n\tEredmények: {eredmenyek[maxIndex].Eredmenyek}");

            int legkisebb = eredmenyek  .Where(e => e.Ny13p1>0)
                                        .Min(e => e.Ny13p1);
            int minIndex = eredmenyek.FindIndex(e => e.Ny13p1==legkisebb);

            Console.WriteLine(
                $"\n Legkisebb " +
                $"\n\tÉv: {eredmenyek[minIndex].Ev} " +
                $"\n\tHét: {eredmenyek[minIndex].Het} " +
                $"\n\tForduló: {eredmenyek[minIndex].Fordulo} " +
                $"\n\tTelitalálat :{eredmenyek[minIndex].T13p1} " +
                $"\n\tNyeremény: {eredmenyek[minIndex].Ny13p1} " +
                $"\n\tEredmények: {eredmenyek[minIndex].Eredmenyek}");

            //8.feladat
            bool VoltDontetlen = false;
            foreach (var item in eredmenyek)
            {
                if (!new EredmenyElemzo(item.Eredmenyek).NemvoltDontetlenMerkozes)
                {
                    VoltDontetlen = false;
                }
                else { VoltDontetlen = true; }
            }

            Console.WriteLine(VoltDontetlen ? "Nem volt döntetlen nélküli forduló" : "Volt döntetlen nélküli forduló");




        }
    }
}
