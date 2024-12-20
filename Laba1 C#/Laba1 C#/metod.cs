using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lol
{
    public class metod
    {
        public bool isInRange(int a, int b, int num)
        {
            if (a > b) (a, b) = (b, a);
            if (num >= a && num <= b) return true;
            else return false;
        }
        public int sum2(int a, int b)
        {
            int sum = a + b;
            if (sum >= 10 && sum < 20) return 20;
            else return sum;
        }
        public static void square(int x)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

    }
}
