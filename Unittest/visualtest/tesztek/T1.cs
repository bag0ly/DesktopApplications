using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace visualtest.tesztek
{
    [TestFixture]
    internal class T1
    {
        Matek m;
        [SetUp]
        public void setuP() 
        {
             m = new Matek(4);
        }
        [Test]
        
        public void MatekNegyzet() 
        {
            //Matek m = new Matek(4);

            Assert.That(m.Negyzet(),Is.EqualTo(16));
        }
        [Test]
        [TestCase(7)]
        public void Osszeg(int i)
        {
            //Matek m = new Matek(4);

            Assert.That(m.Osszeg(i),Is.EqualTo(11));
        }

        [Test]
        public void Eloszt() 
        {
            //Assert.That(1, Is.EqualTo(m.Eloszt(3, 2)));
            Assert.Throws<DivideByZeroException>(
                () => 
                {
                    m.Eloszt(3, 0);
                }
                );
        }
    }
}
