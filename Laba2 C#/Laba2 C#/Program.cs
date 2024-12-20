
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
            var regex = new Regex(@"[,\s;.]+");
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
                    Console.WriteLine("Эллемент '{item}' невозможно конвертировать в тип {typeof(T)}.");
                }
            }
            return resultList;
        }
    }

    class main
    {
        static void Main(string[] args)
        {
            var character1 = new skills(70, 50, 30, "Archer");
            var character2 = new skills(40, 80, 20, "Warrior");

            Console.WriteLine(character1.ToString());
            Console.WriteLine(character2.ToString());

            character1.combat(character1, character2);

            var character3 = new skills(character1);
            Console.WriteLine("Копия через конструктор копирования:");
            Console.WriteLine(character3.ToString());

            var r1 = Console.ReadLine()!.Pars<byte>();
            var r2 = Console.ReadLine()!.Pars<byte>();

            Time t1 = new Time(r1[0], r1[1]);
            Time t2 = new Time(r2[0], r2[1]);

            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString());
            Console.WriteLine((t1 - t2).ToString());
        }
    }
}
