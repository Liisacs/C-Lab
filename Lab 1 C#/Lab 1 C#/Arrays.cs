using System;

namespace Lab1CSharp
{
    public class Arrays
    {
        public int FindFirst(int[] arr, int x)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == x) return i;
            return -1;
        }

        public int MaxAbs(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (Math.Abs(arr[i]) > Math.Abs(max)) max = arr[i];
            return max;
        }

        public int[] AddArray(int[] arr, int[] ins, int pos)
        {
            int[] result = new int[arr.Length + ins.Length];
            for (int i = 0; i < pos; i++) result[i] = arr[i];
            for (int i = 0; i < ins.Length; i++) result[pos + i] = ins[i];
            for (int i = pos; i < arr.Length; i++) result[i + ins.Length] = arr[i];
            return result;
        }

        public int[] ReverseBack(int[] arr)
        {
            int[] reversed = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                reversed[i] = arr[arr.Length - 1 - i];
            return reversed;
        }

        public int[] FindAll(int[] arr, int x)
        {
            int count = 0;
            foreach (var num in arr) if (num == x) count++;
            int[] indexes = new int[count];
            for (int i = 0, j = 0; i < arr.Length; i++)
                if (arr[i] == x) indexes[j++] = i;
            return indexes;
        }
    }
}