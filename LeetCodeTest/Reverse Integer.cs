using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest
{
    class Reverse_Integer
    {
        public static void Main()
        {
            var x = -2147483648;
            var y = Reverse(x);
            Console.WriteLine(y);
            Console.ReadKey();
        }

        private static int Reverse(int x)
        {
            var value = 0.0;
            while (x != 0)
            {
                value = value * 10 + x % 10;

                if (value > int.MaxValue || value < int.MinValue)
                    return 0;

                x /= 10;
            }
            return (int)value;
        }
    }
}
