using System;

namespace Lab1CSharp
{
    public class Loops
    {
        public string ListNumbers(int x)
        {
            var result = "";
            for (int i = 0; i <= x; i++)
                result += i + " ";
            return result.Trim();
        }

        public string EvenNumbers(int x)
        {
            var result = "";
            for (int i = 0; i <= x; i += 2)
                result += i + " ";
            return result.Trim();
        }

        public int NumberLength(long x)
        {
            int count = 0;
            x = Math.Abs(x);
            do
            {
                count++;
                x /= 10;
            } while (x > 0);
            return count;
        }

        public void Square(int x)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }

        public void RightTriangle(int x)
        {
            for (int i = 1; i <= x; i++)
            {
                Console.Write(new string(' ', x - i));
                Console.WriteLine(new string('*', i));
            }
        }
    }
}