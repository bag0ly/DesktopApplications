using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iskola_fb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola_fb.Tests
{
    [TestClass()]
    public class IskolaTests
    {
        [TestMethod()]
        public void AzonGenTest()
        {
            Iskola bodnar = new Iskola("2006;c;Bodnar Szilvia");
            Iskola krizsan = new Iskola("2006;c;Krizsan Vivien Evelin");


            Assert.AreEqual(bodnar.AzonGen(bodnar),"6cbodszi");
            Assert.AreEqual(krizsan.AzonGen(krizsan),"6ckriviv");


        }
    }
}