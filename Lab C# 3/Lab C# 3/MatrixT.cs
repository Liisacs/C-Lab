using System;

namespace lol
{
    public static class MatrixTasks
    {
        public static int FindShortestPath(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int maxRow = 0, maxCol = 0, minRow = 0, minCol = 0;

            // Поиск макс и мин элементов
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > matrix[maxRow, maxCol])
                    {
                        maxRow = i;
                        maxCol = j;
                    }
                    if (matrix[i, j] < matrix[minRow, minCol])
                    {
                        minRow = i;
                        minCol = j;
                    }
                }
            }

            // BFS для поиска пути
            bool[,] visited = new bool[rows, cols];
            Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
            queue.Enqueue((maxRow, maxCol, 0));
            visited[maxRow, maxCol] = true;

            while (queue.Count > 0)
            {
                (int i, int j, int steps) = queue.Dequeue();
                if (i == minRow && j == minCol) return steps;

                // Проверка 8 соседних ячеек
                for (int di = -1; di <= 1; di++)
                {
                    for (int dj = -1; dj <= 1; dj++)
                    {
                        if (di == 0 && dj == 0) continue;
                        int ni = i + di;
                        int nj = j + dj;
                        if (ni >= 0 && ni < rows && nj >= 0 && nj < cols && !visited[ni, nj])
                        {
                            visited[ni, nj] = true;
                            queue.Enqueue((ni, nj, steps + 1));
                        }
                    }
                }
            }
            return -1;
        }
    }
}