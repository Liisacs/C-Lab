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
    public static class Lab4
    {
        // Задание 1: Перенести первый элемент в конец списка
        public static void MoveFirstToLast(List<int> list)
        {
            if (list.Count == 0) return;
            int first = list[0];
            list.RemoveAt(0);
            list.Add(first);
        }

        // Задание 2: Удалить элементы с одинаковыми соседями
        public static void RemoveElementsWithSameNeighbors(LinkedList<int> list)
        {
            if (list.Count < 2) return;

            var nodesToRemove = new List<LinkedListNode<int>>();

            var current = list.First;
            var prev = current;
            current = current.Next;

            while (current != null)
            {
                var next = current.Next;
                if (current != list.First && current != list.Last)
                {
                    if (current.Previous.Value == current.Next.Value)
                        nodesToRemove.Add(current);
                }
                else if (current == list.First)
                {
                    if (current.Value == list.Last.Value)
                        nodesToRemove.Add(current);
                }
                else if (current == list.Last)
                {
                    if (current.Value == list.First.Value)
                        nodesToRemove.Add(current);
                }
                prev = current;
                current = next;
            }

            foreach (var node in nodesToRemove)
                list.Remove(node);
        }

        // Задание 3: Анализ заказов в кафе
        public static void AnalyzeOrders(Dictionary<string, HashSet<string>> ordersByCustomer)
        {
            var allDishes = new HashSet<string>();
            var commonToAll = new HashSet<string>();
            var orderedBySome = new HashSet<string>();
            var orderedByNone = new HashSet<string>();

            // Найти все блюда
            foreach (var dishes in ordersByCustomer.Values)
                allDishes.UnionWith(dishes);

            // Блюда, заказанные всеми
            commonToAll.UnionWith(ordersByCustomer.First().Value);
            foreach (var dishes in ordersByCustomer.Skip(1))
                commonToAll.IntersectWith(dishes.Value);

            // Блюда, заказанные хотя бы одним
            orderedBySome.UnionWith(allDishes);

            // Блюда, не заказанные никем (дополнение)
            orderedByNone = new HashSet<string>();
            foreach (var dish in allDishes)
                if (!orderedBySome.Contains(dish))
                    orderedByNone.Add(dish);

            Console.WriteLine("Common to all: " + string.Join(", ", commonToAll));
            Console.WriteLine("Ordered by some: " + string.Join(", ", orderedBySome));
            Console.WriteLine("Ordered by none: " + string.Join(", ", orderedByNone));
        }

        // Задание 4: Согласные буквы в одном слове
        public static void PrintConsonantsInSingleWord(string text)
        {
            var words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var consonantsPerWord = new Dictionary<char, int>();

            foreach (var word in words)
            {
                var consonants = new HashSet<char>();
                foreach (var c in word)
                {
                    if ("бвгджзйклмнпрстфхцчшщ".Contains(c))
                        consonants.Add(c);
                }

                foreach (var c in consonants)
                {
                    if (consonantsPerWord.ContainsKey(c))
                        consonantsPerWord[c]++;
                    else
                        consonantsPerWord[c] = 1;
                }
            }

            var result = consonantsPerWord
                .Where(kvp => kvp.Value == 1)
                .OrderBy(kvp => kvp.Key)
                .Select(kvp => kvp.Key);

            Console.WriteLine("Согласные в одном слове: " + string.Join(", ", result));
        }

        public static (int, int, int) GetCheapestCounts()
        {
            var magazines = ParseMagazineDataFromFile("magazines.txt");
            return CalculateCheapestStoreCounts(magazines);
        }

        private static List<Magazine> ParseMagazineDataFromFile(string filePath)
        {
            var magazines = new List<Magazine>();
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 4) continue; // пропускаем некорректные строки

                if (!int.TryParse(parts[2], out int fatness) ||
                    !int.TryParse(parts[3], out int price))
                    continue; // пропускаем строки с ошибками

                magazines.Add(new Magazine
                {
                    Company = parts[0],
                    Street = parts[1],
                    Fatness = fatness,
                    Price = price
                });
            }
            return magazines;
        }

        private static (int fifteen, int twenty, int twentyFive) CalculateCheapestStoreCounts(List<Magazine> magazines)
        {
            var result = (fifteen: 0, twenty: 0, twentyFive: 0);

            foreach (var fatness in new[] { 15, 20, 25 })
            {
                var group = magazines.Where(m => m.Fatness == fatness).ToList();
                if (!group.Any()) continue;

                int minPrice = group.Min(m => m.Price);
                switch (fatness)
                {
                    case 15:
                        result.fifteen = group.Count(m => m.Price == minPrice);
                        break;
                    case 20:
                        result.twenty = group.Count(m => m.Price == minPrice);
                        break;
                    case 25:
                        result.twentyFive = group.Count(m => m.Price == minPrice);
                        break;
                }
            }

            return result;
        }
    }

    public class Magazine
    {
        public string Company { get; set; }
        public string Street { get; set; }
        public int Fatness { get; set; }
        public int Price { get; set; }
    }
}

