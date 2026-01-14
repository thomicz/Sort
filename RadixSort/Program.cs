namespace RadixSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Sort s = new Sort();
            DataLoader d = new DataLoader();
            long[] data = d.LoadNumber(@"C:\Users\Tomáš Dvořák\Desktop\random_10M_interval.txt");
            long[] sortedData = s.SortData(data);
            Console.WriteLine("Sorted array: " + string.Join(", ", sortedData));
        }
    }
}
