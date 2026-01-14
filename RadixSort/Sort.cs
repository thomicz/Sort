namespace RadixSort
{
    internal class Sort
    {
        public long[] SortData(long[] data)
        {
            if (data == null || data.Length <= 1)
            {
                return data;
            }

            List<long> positives = new List<long>();
            List<long> negatives = new List<long>();

            foreach (var num in data)
            {
                if (num >= 0)
                {
                    positives.Add(num);
                }
                else
                {
                    negatives.Add(-num); 
                }
            }

            ulong[] posArray = RadixSortArray(positives.ToArray());
            ulong[] negArray = RadixSortArray(negatives.ToArray());

            long[] sortedNegatives = new long[negArray.Length];
            for (int i = 0; i < negArray.Length; i++)
            {
                sortedNegatives[i] = -(long)negArray[negArray.Length - 1 - i];
            }

           
            long[] result = new long[sortedNegatives.Length + posArray.Length];

            Array.Copy(sortedNegatives, result, sortedNegatives.Length);

            for (int i = 0; i < posArray.Length; i++)
            {
                result[sortedNegatives.Length + i] = (long)posArray[i];
            }

            return result;
        }

        private ulong[] RadixSortArray(long[] data)
        {
            int n = data.Length;

            ulong[] arr = Array.ConvertAll(data, x => (ulong)x);
            ulong max = 0;

            foreach (var num in arr)
            {
                if (num > max) max = num;
            }

            for (ulong exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSortByDigit(arr, exp);
            }
            return arr;
        }

        public string[] RadixSortStrings(string[] data)
        {
            int maxLength = 0;

            foreach (var s in data)
            {
                if (s.Length > maxLength)
                {
                    maxLength = s.Length;
                }
            }

            for (int pos = maxLength - 1; pos >= 0; pos--)
            {
                CountingSortByChar(data, pos);
            }

            return data;
        }

        private void CountingSortByChar(string[] data, int pos)
        {
            int n = data.Length;
            string[] output = new string[n];
            int[] count = new int[256];

            for (int i = 0; i < n; i++)
            {
                int c = pos < data[i].Length ? data[i][pos] : 0;
                count[c]++;
            }

            for (int i = 1; i < 256; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int c = pos < data[i].Length ? data[i][pos] : 0;
                output[count[c] - 1] = data[i];
                count[c]--;
            }

            for (int i = 0; i < n; i++)
            {
                data[i] = output[i];
            }
        }


        private void CountingSortByDigit(ulong[] data, ulong exp)
        {
            int n = data.Length;
            ulong[] output = new ulong[n];
            int[] count = new int[10];

            for (int i = 0; i < n; i++)
            {
                int digit = (int)((data[i] / exp) % 10);
                count[digit]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int digit = (int)((data[i] / exp) % 10);
                output[count[digit] - 1] = data[i];
                count[digit]--;
            }

            for (int i = 0; i < n; i++)
            {
                data[i] = output[i];
            }
        }
    }
}
