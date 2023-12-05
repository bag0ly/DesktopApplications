using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
[assembly:InternalsVisibleTo("gyakorlas1205Tests")]

namespace gyakorlas1205
{
    class Szamol
    {
        public int bef1, bef2;
        public int atf;

        public Szamol(int bef1, int bef2, int atf)
        {
            this.bef1 = bef1;
            this.bef2 = bef2;
            this.atf = atf;
        }

        public int Kivonas(int bef1,int bef2) 
        {
            return bef1 - bef2;   
        }
        public int Szorzas(int bef1, int bef2) 
        {
            return bef1 * bef2;
        }

        public double Gyok(int bef1) 
        {
            return Math.Sqrt(bef1);
        }

        public bool SzerkeszthetoEaHaromszog(int bef1, int bef2, int atf)
        {
            return (bef1 + bef2 > atf) && (bef1 + atf > bef2) && (atf + bef2 > bef1);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
