using Microsoft.VisualStudio.TestTools.UnitTesting;
using visualtest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace visualtest.Tests
{
    [TestClass()]
    public class MatekTests
    {
        [TestMethod()]
        public void NegyzetTest()
        {
            Matek m = new Matek(3);

            Assert.AreEqual(9, m.Negyzet());
        }
        [TestMethod()]
        public void Osszeg()
        {
            Matek m = new Matek(3);

            Assert.AreEqual(11, m.Osszeg(7));

            Assert.IsTrue(true, "nagyon nagyon nagyon.. nagyon nagyon jo");

        }
    }
}