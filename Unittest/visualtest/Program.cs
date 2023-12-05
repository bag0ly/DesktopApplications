using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("visualtestTests")]

namespace visualtest
{
    class Matek 
    {
        public int a;

        public Matek(int a)
        {
            this.a = a;
        }
        public int Negyzet() 
        {
            return a*a;
        }
        public int Osszeg(int b) 
        {
            return (a + b);
        }

        public int Eloszt(int a, int b) 
        {
            return (a / b);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
