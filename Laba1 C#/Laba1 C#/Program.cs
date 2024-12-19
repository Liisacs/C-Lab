
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace lol
{
    public static class al
    {
        public static void swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;

        }
        public static List<T> Pars<T>(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Введено 0 значений.");
            }
            var regex = new Regex(@"[,\s;></?|\!:.]+");
            var splitInput = regex.Split(input);
            splitInput = splitInput.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            var resultList = new List<T>();

            foreach (var item in splitInput)
            {
                try
                {
                    resultList.Add((T)Convert.ChangeType(item, typeof(T)));
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Эллемент '{item}' невозможно конвертировать в тип {typeof(T)}.");
                }
            }
            return resultList;
        }
    }

    class main
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var t = Console.ReadLine()!.Pars<int>();
                metod a = new metod();
                if (t.Count < 3)
                {
                    Console.WriteLine("Ошибка: не переданы 3 аргумента.");
                }
                else
                    Console.WriteLine(a.isInRange(t[0], t[1], t[2]));
            }
        }
    }
}
