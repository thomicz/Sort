using System.Diagnostics;

namespace InsertionSort
{
    internal class Sort
    {
        public T[] SortData<T>(T[] data) where T : IComparable<T>
        {
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 1; i < data.Length; i++)
            {
                T key = data[i];
                int j = i - 1;

                while (j >= 0 && data[j].CompareTo(key) > 0)
                {
                    data[j + 1] = data[j];
                    j--;
                }

                data[j + 1] = key;
            }

            sw.Stop();
            Console.WriteLine($"Time: {sw.Elapsed}");

            return data;
        }
    }
}
