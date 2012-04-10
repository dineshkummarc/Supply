using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMovie.Models;
using Microsoft.CSharp;
using System; 

namespace UnitTest
{
    public class TestBase
    { 

        public void Describes(string description)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine(description);
            Console.WriteLine("----------------------------------");
        }
        public void IsPending()
        {
            Console.WriteLine(" {0} -- PENDING", GetCaller());
            Assert.Inconclusive();
        }
        public string GetCaller()
        {
            StackTrace stack = new StackTrace();
            return stack.GetFrame(2).GetMethod().Name.Replace("_", " ");

        }
    }
}
