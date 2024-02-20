using Microsoft.VisualStudio.TestTools.UnitTesting;
using tesztelosdolgozat;
using System;
using System.IO;

namespace YourProject.Tests
{
    [TestClass]
    public class OsztasTests
    {
        [TestMethod]
        public void TobbOszto_CorrectResultsForSingleNumber()
        {
            int numberofattempts = 1;
            string input = "7\n";  
            Console.SetIn(new StringReader(input));


            Osztas osztasInstance = new Osztas();
            osztasInstance.TobbOszto(numberofattempts);

            Assert.AreEqual(1, Osztas.eredmeny[0]); 
        }

        [TestMethod]
        public void TobbOszto_CorrectResultsForMultipleNumbers()
        {

            int numberofattempts = 2;
            string input = "7\n8\n";  
            Console.SetIn(new StringReader(input));

            
            Osztas osztasInstance = new Osztas();
            osztasInstance.TobbOszto(numberofattempts);

            
            CollectionAssert.AreEqual(new[] { 1, 2 }, Osztas.eredmeny); 
        }

        [TestMethod]
        public void TobbOszto_CorrectResultsForFiveNumbers()
        {

            int numberofattempts = 5;
            string input = "2\n4\n6\n8\n10\n";
            Console.SetIn(new StringReader(input));


            Osztas osztasInstance = new Osztas();
            osztasInstance.TobbOszto(numberofattempts);


            CollectionAssert.AreEqual(new[] { 0, 2, 0, 2, 0 }, Osztas.eredmeny);
        }

    }
}
