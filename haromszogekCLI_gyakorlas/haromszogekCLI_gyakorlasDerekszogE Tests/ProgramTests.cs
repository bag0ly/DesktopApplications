using Microsoft.VisualStudio.TestTools.UnitTesting;
using haromszogekCLI_gyakorlas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haromszogekCLI_gyakorlas.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void DerekszogETest()
        {
            Assert.IsTrue(Math.Pow(3, 2) + Math.Pow(4, 2) == Math.Pow(5, 2));
        }
    }
}