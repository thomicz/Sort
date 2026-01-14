using System;
using System.Diagnostics;

namespace SelectionSort
{
    internal class Sort
    {
        public T[] SortData<T>(T[] data) where T : IComparable<T>
        {
            int length = data.Length;
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < length; j++)
                {
                    sw.Restart();

                    if (data[j].CompareTo(data[minIndex]) < 0)
                    {
                        minIndex = j;
                    }

                    sw.Stop();

                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"J: {j} I: {i}");
                    Console.WriteLine($"Time per cycle: {sw.Elapsed.TotalMilliseconds} ms");
                    Console.WriteLine("Sorting progress: " + (i * 100 / length) + "%");
                }

                Console.Clear();

                T temp = data[i];
                data[i] = data[minIndex];
                data[minIndex] = temp;
            }

            return data;
        }
    }
}
