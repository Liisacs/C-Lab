using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Lab4CSharp
{
    class main
    {
        static void Main()
        {
            Console.WriteLine("Задание 1:");
            var list1 = new List<int> { 1, 2, 3, 4 };
            Console.WriteLine("Исходный список: " + string.Join(", ", list1));
            Lab4.MoveFirstToLast(list1);
            Console.WriteLine("После переноса: " + string.Join(", ", list1));

            Console.WriteLine("\nЗадание 2:");
            var list2 = new LinkedList<int>(new[] { 2, 1, 2, 3 });
            Console.WriteLine("Исходный список: " + string.Join(", ", list2));
            Lab4.RemoveElementsWithSameNeighbors(list2);
            Console.WriteLine("После удаления: " + string.Join(", ", list2));

            Console.WriteLine("\nЗадание 3:");
            var orders = new Dictionary<string, HashSet<string>>
            {
                { "Посетитель1", new HashSet<string> { "Суп", "Салат" } },
                { "Посетитель2", new HashSet<string> { "Суп", "Пицца" } },
                { "Посетитель3", new HashSet<string> { "Суп", "Салат", "Пицца" } }
            };
            Lab4.AnalyzeOrders(orders);

            Console.WriteLine("\nЗадание 4:");
            Lab4.PrintConsonantsInSingleWord("Пример текста на русском языке.");

            Console.WriteLine("\nЗадание 5:");
            var result = Lab4.GetCheapestCounts();
            Console.WriteLine($"15%: {result.Item1}, 20%: {result.Item2}, 25%: {result.Item3}");
        }
    }
}