using System;
using System.Xml.Serialization;

namespace lol
{
    
    class Program
    {
        static void Main()
        {
            // Тестирование задания 1
            Matrix matrix1 = new Matrix(3, 2); // Первый массив
            Matrix matrix2 = new Matrix(3); // Второй массив
            Console.WriteLine("Сгенерированная матрица:\n" + matrix2);

            // Тестирование задания 2 
            int[,] testMatrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Кратчайший путь: " + MatrixTasks.FindShortestPath(testMatrix));

            // Тестирование задания 3 (7*A*(Вт - C))
            Matrix A = new Matrix(2, 2);
            Matrix B = new Matrix(2).Transpose();
            Matrix C = new Matrix(2, 2);
            Matrix result = 7 * A * (B - C);
            Console.WriteLine("Результат вычисления матричного выражения:\n" + result);

            // задание 4
            string binFilePath = "binaryFile.bin";
            Console.WriteLine("Введите K: ");
            Lab3Tasks.GenerateBinaryFile(binFilePath, 100);
            Console.WriteLine($"Разность макс и мин: {Lab3Tasks.FindMaxMinDifference(binFilePath)}");

            // Задание 5
            string baggageFilePath = "baggage.xml";
            Lab3Tasks.GenerateBaggageFile(baggageFilePath, 50);
            Console.WriteLine($"Есть пассажир с легким багажом: {Lab3Tasks.CheckSingleLightBaggage(baggageFilePath, 20)}");

            // Задание 6
            string textFilePath = "numbers.txt";
            Lab3Tasks.GenerateTextFile(textFilePath, 100);
            Console.WriteLine($"Количество макс элементов: {Lab3Tasks.CountMaxOccurrences(textFilePath)}");

            // Задание 7
            string multiNumberFilePath = "multi_numbers.txt";
            Lab3Tasks.GenerateMultiNumberTextFile(multiNumberFilePath, 20, 5);
            Console.WriteLine($"Произведение кратных 5: {Lab3Tasks.CalculateProductWithDivisor(multiNumberFilePath, 5)}");

            // Задание 8
            string sourceText = "source.txt";
            string destinationText = "filtered.txt";
            
            using (StreamWriter writer = new StreamWriter(sourceText))
            {
                writer.WriteLine("Строка без цифр");
                writer.WriteLine("Строка123");
                writer.WriteLine("Тест");
            }
            Lab3Tasks.CopyLinesWithoutDigits(sourceText, destinationText);
            Console.WriteLine("Строки без цифр скопированы в filtered.txt");
        }
    }
}