using System;

namespace Lab1CSharp
{
    public class Methods
    {
        public double Fraction(double x)
        {
            return x - (int)x;
        }

        public int CharToNum(char x)
        {
            return x - '0';
        }

        public bool Is2Digits(int x)
        {
            return x >= 10 && x <= 99;
        }

        public bool IsInRange(int a, int b, int num)
        {
            int min = Math.Min(a, b);
            int max = Math.Max(a, b);
            return num >= min && num <= max;
        }

        public bool AreEqual(int a, int b, int c)
        {
            return a == b && b == c;
        }
    }
}