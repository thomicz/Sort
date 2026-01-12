using System.Diagnostics;

namespace BubbleSort
{
    internal class Sort
    {
        public T[] SortData<T>(T[] data) where T : IComparable<T>
        {
            int length = data.Length;

            Stopwatch sw = Stopwatch.StartNew();

            while (!IsSorted(data))
            {
                for (int i = 0; i < length - 1; i++)
                {
                    if (data[i].CompareTo(data[i + 1]) > 0)
                    {
                        T temp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                    }
                }
            }

            sw.Stop();
            Console.WriteLine($"Time: {sw.Elapsed}");

            return data;
        }

        private bool IsSorted<T>(T[] data) where T : IComparable<T>
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (data[i].CompareTo(data[i + 1]) > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
