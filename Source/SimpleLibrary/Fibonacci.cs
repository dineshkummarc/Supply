using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleLibrary
{
    public class Fibonacci
    {
        public static int Calculate(int x)
        {
            if (x <= 0)
                return 0;

            if (x == 1)
                return 1;

            return Calculate(x - 1) + Calculate(x - 2);
        }
    }
}
