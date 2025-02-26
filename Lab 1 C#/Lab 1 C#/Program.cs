using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab1CSharp
{
    class Program
    {
        static void Main()
        {
            TestMethods();
            TestConditions();
            TestLoops();
            TestArrays();
        }

        static void TestMethods()
        {
            Methods m = new Methods();
            Console.WriteLine(m.Fraction(5.25)); // 0.25
            Console.WriteLine(m.CharToNum('3')); // 3
            Console.WriteLine(m.Is2Digits(32)); // True
            Console.WriteLine(m.IsInRange(5, 1, 3)); // True
            Console.WriteLine(m.AreEqual(3, 3, 3)); // True
        }

        static void TestConditions()
        {
            Conditions c = new Conditions();
            Console.WriteLine(c.Abs(-3)); // 3
            Console.WriteLine(c.Is35(5)); // True
            Console.WriteLine(c.Max3(5, 7, 7)); //7
            Console.WriteLine(c.Sum2(5, 7)); //20
            Console.WriteLine(c.Day(5)); //пятница
        }

        static void TestLoops()
        {
            Loops l = new Loops();
            Console.WriteLine(l.ListNumbers(5)); //0 1 2 3 4 5
            Console.WriteLine(l.EvenNumbers(9)); //0 2 4 6 8
            Console.WriteLine(l.NumberLength(12567)); //5
            l.Square(3);
            l.RightTriangle(3);
        }

        static void TestArrays()
        {
            Arrays a = new Arrays();
            Console.WriteLine(a.FindFirst(new int[] { 1, 2, 3, 4, 2 }, 2)); //1
            Console.WriteLine(a.MaxAbs(new int[] { 1, -2, -7, 4 })); //-7
            int[] arr = a.AddArray(new int[] { 1, 2, 3 }, new int[] { 7, 8 }, 2);
            Console.WriteLine(string.Join(",", arr)); //1,2,3,7,8,4
            int[] reversed = a.ReverseBack(new int[] { 1, 2, 3 });
            Console.WriteLine(string.Join(",", reversed)); //3,2,1
            int[] indexes = a.FindAll(new int[] { 1, 2, 3, 2 }, 2);
            Console.WriteLine(string.Join(",", indexes)); //1,3
        }
    }
}