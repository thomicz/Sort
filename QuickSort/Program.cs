namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Sort sorter = new Sort();
            DataLoader d = new DataLoader();

            double[] dataNumber = d.LoadNumber(@"C:\Users\Tomáš Dvořák\Desktop\random_10M_interval.txt");
            //string[] dataString = d.LoadString(@"C:\Users\Tomáš Dvořák\Desktop\random_words_10M.txt");

            var sortedData = sorter.SortData(dataNumber);

            //Console.WriteLine("Sorted array: " + string.Join(", ", sortedData));
        }
    }
}
