using System;

namespace lol
{
    public class Matrix
    {
        public int[,] Data { get; private set; }

        // Конструктор для первого массива (ввод по столбцам от последних элементов)
        public Matrix(int n, int m)
        {
            Data = new int[n, m];
            Console.WriteLine("Введите элементы массива по столбцам (снизу вверх):");
            for (int j = 0; j < m; j++)
            {
                for (int i = n - 1; i >= 0; i--)
                    Data[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Конструктор для второго массива (четырехзначные числа из нечетных цифр)
        public Matrix(int n)
        {
            Data = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Генерация 4-х значного числа из нечетных цифр
                    int num = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        int digit = rnd.Next(1, 10);
                        if (digit % 2 == 0) digit++;
                        num = num * 10 + digit;
                    }
                    Data[i, j] = num;
                }
            }
        }

        // Транспонирование матрицы
        public Matrix Transpose()
        {
            int rows = Data.GetLength(0);
            int cols = Data.GetLength(1);
            Matrix transposed = new Matrix(cols, rows);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    transposed.Data[j, i] = Data[i, j];
            return transposed;
        }

        // Умножение матрицы на скаляр
        public static Matrix operator *(int scalar, Matrix matrix)
        {
            Matrix result = new Matrix(matrix.Data.GetLength(0), matrix.Data.GetLength(1));
            for (int i = 0; i < result.Data.GetLength(0); i++)
                for (int j = 0; j < result.Data.GetLength(1); j++)
                    result.Data[i, j] = matrix.Data[i, j] * scalar;
            return result;
        }

        // Умножение матриц
        public static Matrix operator *(Matrix a, Matrix b)
        {
            int size = a.Data.GetLength(0);
            Matrix result = new Matrix(size, size);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < size; k++)
                        sum += a.Data[i, k] * b.Data[k, j];
                    result.Data[i, j] = sum;
                }
            return result;
        }

        // Вычитание матриц
        public static Matrix operator -(Matrix a, Matrix b)
        {
            int rows = a.Data.GetLength(0);
            int cols = a.Data.GetLength(1);
            Matrix result = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result.Data[i, j] = a.Data[i, j] - b.Data[i, j];
            return result;
        }

        // Вывод матрицы
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                    str += Data[i, j].ToString().PadLeft(5);
                str += "\n";
            }
            return str;
        }
    }
}