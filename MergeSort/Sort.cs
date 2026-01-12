namespace MergeSort
{
    internal class Sort
    {
        public T[] SortData<T>(T[] data) where T : IComparable<T>
        {
            if (data.Length <= 1)
                return data;

            int mid = data.Length / 2;

            T[] left = new T[mid];
            T[] right = new T[data.Length - mid];

            Array.Copy(data, 0, left, 0, left.Length);
            Array.Copy(data, mid, right, 0, right.Length);

            left = SortData(left);
            right = SortData(right);

            return Merge(left, right);
        }

        private T[] Merge<T>(T[] left, T[] right) where T : IComparable<T>
        {
            int i = 0, j = 0, k = 0;
            T[] result = new T[left.Length + right.Length];

            while (i < left.Length && j < right.Length)
            {
                if (left[i].CompareTo(right[j]) <= 0)
                {
                    result[k++] = left[i++];
                }
                else
                {
                    result[k++] = right[j++];
                }
            }

            while (i < left.Length)
                result[k++] = left[i++];

            while (j < right.Length)
                result[k++] = right[j++];

            return result;
        }
    }
}
