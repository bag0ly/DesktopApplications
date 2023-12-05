using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace gyakorlas1205.teszt
{
    [TestFixture]
    internal class T1
    {
        Szamol sz;
        [SetUp]
        public void Setup() 
        {
            sz = new Szamol(3,3,3);
        }
        [Test]
        [TestCase(2,1,1)]
        [TestCase(5, 4, 1)]
        [TestCase(6, 5, 1)]
        public void Kivonas(int i1, int i2, int o)
        {
            Assert.That(o, Is.EqualTo(sz.Kivonas(i1, i2)));
        }
        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(5, 4, 20)]
        [TestCase(6, 5, 30)]
        public void Szorzas(int i1, int i2, int o)
        {
            Assert.That(o, Is.EqualTo(sz.Szorzas(i1, i2)));
        }
        [Test]
        public void Gyok(int i1,int o)
        {
            Assert.Throws<FormatException>(
                () =>
                {
                    sz.Gyok(Convert.ToInt32("a")); 
                }
                );
        }
        [Test]
        [TestCase(2, 1, 1)]
        [TestCase(5, 4, 1)]
        [TestCase(6, 5, 1)]
        public void SzerkeszthetoEaHaromszog(int i1, int i2, int i3)
        {
           Assert.That(sz.SzerkeszthetoEaHaromszog(i1,i2,i3));
        }
    }
}
