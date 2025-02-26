using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace lol
{
    public class Lab3Tasks
    {
        // Задание 4: Найти разность максимального и минимального элементов бинарного файла
        public static int FindMaxMinDifference(string filePath)
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
            {
                int max = int.MinValue;
                int min = int.MaxValue;
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int num = reader.ReadInt32();
                    if (num > max) max = num;
                    if (num < min) min = num;
                }
                return max - min;
            }
        }

        // Генерация бинарного файла для задания 4
        public static void GenerateBinaryFile(string filePath, int size)
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
            {
                Random random = new Random();
                for (int i = 0; i < size; i++)
                {
                    writer.Write(random.Next(int.MinValue, int.MaxValue));
                }
            }
        }

        // Задание 5: Проверка наличия пассажира с одним предметом багажа массой <m
        [XmlRoot("Passenger")]
        public class Passenger
        {
            [XmlElement("Baggage")]
            public List<BaggageItem> Baggage { get; set; }
        }

        public class BaggageItem
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
            [XmlAttribute("mass")]
            public int Mass { get; set; }
        }

        public static void GenerateBaggageFile(string filePath, int passengersCount)
        {
            var passengers = new List<Passenger>();
            var random = new Random();

            for (int i = 0; i < passengersCount; i++)
            {
                var passenger = new Passenger();
                int bagCount = random.Next(1, 5);
                passenger.Baggage = new List<BaggageItem>();
                for (int j = 0; j < bagCount; j++)
                {
                    passenger.Baggage.Add(new BaggageItem
                    {
                        Name = $"Bag{j + 1}",
                        Mass = random.Next(1, 100)
                    });
                }
                passengers.Add(passenger);
            }

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Passenger>));
                serializer.Serialize(stream, passengers);
            }
        }

        public static bool CheckSingleLightBaggage(string filePath, int m)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Passenger>));
                List<Passenger> passengers = (List<Passenger>)serializer.Deserialize(stream);
                foreach (var passenger in passengers)
                {
                    if (passenger.Baggage.Count == 1 && passenger.Baggage[0].Mass < m)
                        return true;
                }
                return false;
            }
        }

        // Задание 6: Количество вхождений максимального элемента в текстовый файл
        public static void GenerateTextFile(string filePath, int size)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                Random random = new Random();
                for (int i = 0; i < size; i++)
                {
                    writer.WriteLine(random.Next(1, 100));
                }
            }
        }

        public static int CountMaxOccurrences(string filePath)
        {
            int max = int.MinValue;
            int count = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    int num = int.Parse(reader.ReadLine());
                    if (num > max)
                    {
                        max = num;
                        count = 1;
                    }
                    else if (num == max)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        // Задание 7: Произведение элементов кратных k (текстовый файл с несколькими числами в строке)
        public static void GenerateMultiNumberTextFile(string filePath, int lines, int numbersPerLine)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                Random random = new Random();
                for (int i = 0; i < lines; i++)
                {
                    for (int j = 0; j < numbersPerLine; j++)
                    {
                        writer.Write(random.Next(1, 100));
                        if (j < numbersPerLine - 1) writer.Write(" ");
                    }
                    writer.WriteLine();
                }
            }
        }

        public static long CalculateProductWithDivisor(string filePath, int k)
        {
            long product = 1;
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string[] numbers = reader.ReadLine().Split();
                    foreach (string numStr in numbers)
                    {
                        int num = int.Parse(numStr);
                        if (num % k == 0)
                            product *= num;
                    }
                }
            }
            return product;
        }

        // Задание 8: Копирование строк без цифр
        public static void CopyLinesWithoutDigits(string sourcePath, string destinationPath)
        {
            using (StreamReader reader = new StreamReader(sourcePath))
            using (StreamWriter writer = new StreamWriter(destinationPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!Regex.IsMatch(line, @"\d"))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}