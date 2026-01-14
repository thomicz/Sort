namespace QuickSort
{
    internal class DataLoader
    {
        public double[] LoadNumber(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Soubor nebyl nalezen.", path);

            var numbers = new List<double>();
            foreach (var line in File.ReadAllLines(path))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmed))
                    continue;

                if (double.TryParse(trimmed, System.Globalization.NumberStyles.Float,
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    out double num))
                    numbers.Add(num);
                else
                    Console.WriteLine($"Neplatná hodnota: '{line}'");
            }

            return numbers.ToArray();
        }

        public string[] LoadString(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Soubor nebyl nalezen.", path);

            var data = new List<string>();

            foreach (var line in File.ReadAllLines(path))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmed))
                    continue;

                data.Add(trimmed);
            }

            return data.ToArray();
        }
    }
}
