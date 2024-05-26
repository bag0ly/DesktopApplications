using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balaton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balaton.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AdoTest()
        {
            Assert.AreEqual(Program.Ado('A',49), 39200);
            Assert.AreEqual(Program.Ado('B', 217), 130200);
            Assert.AreEqual(Program.Ado('C', 180), 18000);
            Assert.AreEqual(Program.Ado('C', 90), 0);
        }
    }
}