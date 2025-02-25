using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schumann.Library.Tests.Math
{
    [TestClass]
    public class CalculatorTests
    {

        //arrange
        Calculator calcc = new Calculator();


        //naming: MethodName_Scenario_Expectedoutcome
        [TestMethod]
        public void Add_AddsToWholeNumbers_SumOfThoseTwoNumbers()
        {
            //act 
            var result = calcc.Add(5, 7);

            //assert
            Assert.AreEqual(12, result);
        }
    }
}
