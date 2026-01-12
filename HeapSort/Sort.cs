using System.Diagnostics;

namespace HeapSort
{
    internal class Sort
    {
        public T[] SortData<T>(T[] data) where T : IComparable<T>
        {
            Stopwatch sw = Stopwatch.StartNew();

            int length = data.Length;

            for (int i = length / 2 - 1; i >= 0; i--)
            {
                Heapify(data, length, i);
            }

            for (int i = length - 1; i > 0; i--)
            {
                T temp = data[0];
                data[0] = data[i];
                data[i] = temp;

                Heapify(data, i, 0);
            }

            sw.Stop();
            Console.WriteLine($"Time: {sw.Elapsed}");

            return data;
        }

        private void Heapify<T>(T[] data, int heapSize, int root) where T : IComparable<T>
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < heapSize && data[left].CompareTo(data[largest]) > 0)
            {
                largest = left;
            }

            if (right < heapSize && data[right].CompareTo(data[largest]) > 0)
            {
                largest = right;
            }

            if (largest != root)
            {
                T temp = data[root];
                data[root] = data[largest];
                data[largest] = temp;

                Heapify(data, heapSize, largest);
            }
        }
    }
}
