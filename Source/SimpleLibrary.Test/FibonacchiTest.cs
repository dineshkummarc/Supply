using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace SimpleLibrary.Test
{ 
        public class FibonacciTest
        {
            [Test]
            public void Fibonacci_of_number_greater_than_one()
            {
                int result = Fibonacci.Calculate(6);
                Assert.AreEqual(8, result);
            }


            //[Test]
            //[ExpectedException(typeof(ArgumentOutOfRangeException))]
            //public void Fibonacci_of_negative_number_does_not_exist()
            //{
            //    Fibonacci.Calculate(-1);
            //}
        } 
}
