namespace QuickSort
{
    internal class Sort
    {
        public T[] SortData<T>(T[] data) where T : IComparable<T>
        {
            if (data == null || data.Length <= 1)
            {
                return data;
            }

            QuickSort(data, 0, data.Length - 1);
            return data;
        }

        private void QuickSort<T>(T[] data, int left, int right) where T : IComparable<T>
        {
            if (left >= right)
            {
                return;
            }

            int pivotIndex = Partition(data, left, right);

            QuickSort(data, left, pivotIndex - 1);
            QuickSort(data, pivotIndex + 1, right);
        }

        private int Partition<T>(T[] data, int left, int right) where T : IComparable<T>
        {
            T middle = data[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (data[j].CompareTo(middle) <= 0)
                {
                    i++;
                    Swap(data, i, j);
                }
            }

            Swap(data, i + 1, right);
            return i + 1;
        }

        private void Swap<T>(T[] data, int i, int j)
        {
            T temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
}
