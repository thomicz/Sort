namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Sort sorter = new Sort();
            DataLoader d = new DataLoader();

            double[] dataNumber = d.LoadNumber(@"");
            //string[] dataString = d.LoadString(@"");

            var sortedData = sorter.SortData(dataNumber);

            //Console.WriteLine("Sorted array: " + string.Join(", ", sortedData));
        }
    }
}

