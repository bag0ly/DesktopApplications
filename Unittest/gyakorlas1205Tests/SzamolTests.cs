using Microsoft.VisualStudio.TestTools.UnitTesting;
using gyakorlas1205;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;

namespace gyakorlas1205.Tests
{
    [TestClass()]
    public class SzamolTests
    {
        
        [TestMethod()]
        public void SzamolTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void KivonasTest()
        {
            Szamol sz = new Szamol(3,3,3);
            Assert.AreEqual(3,sz.Kivonas(4,1));
        }

        [TestMethod()]
        public void SzorzasTest()
        {
            Szamol sz = new Szamol(3, 3, 3);
            Assert.AreEqual(9, sz.Szorzas(3, 3));
        }

        [TestMethod()]
        public void GyokTest()
        {
            Szamol sz = new Szamol(3, 3, 3);
            Assert.AreEqual(3, sz.Gyok(9));
        }

        [TestMethod()]
        public void SzerkeszthetoEaHaromszogTest()
        {
            Szamol sz = new Szamol(3, 3, 3);
            Assert.IsTrue(sz.SzerkeszthetoEaHaromszog(3,3,3));
        }
    }
}