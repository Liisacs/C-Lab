using System;

namespace Lab1CSharp
{
    public class Conditions
    {
        public int Abs(int x)
        {
            return x < 0 ? -x : x;
        }

        public bool Is35(int x)
        {
            bool div3 = x % 3 == 0;
            bool div5 = x % 5 == 0;
            return (div3 || div5) && !(div3 && div5);
        }

        public int Max3(int x, int y, int z)
        {
            int max = x;
            if (y > max) max = y;
            if (z > max) max = z;
            return max;
        }

        public int Sum2(int x, int y)
        {
            int sum = x + y;
            return sum >= 10 && sum <= 19 ? 20 : sum;
        }

        public string Day(int x)
        {
            switch (x)
            {
                case 1: return "понедельник";
                case 2: return "вторник";
                case 3: return "среда";
                case 4: return "четверг";
                case 5: return "пятница";
                case 6: return "суббота";
                case 7: return "воскресенье";
                default: return "это не день недели";
            }
        }
    }
}