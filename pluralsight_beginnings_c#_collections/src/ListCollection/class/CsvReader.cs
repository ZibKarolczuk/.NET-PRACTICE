using System.Collections.Generic;
using System.IO;

namespace ListCollection
{
    public class CsvReader
    {
        public const string CSV_FILE_PATH = "files/countries.csv";
        public static List<Country> ReadCountries()
        {
            List<Country> countries = new List<Country>();

            using (StreamReader sr = new StreamReader(CSV_FILE_PATH))
            {
                string csvLine;
                while ((csvLine = sr.ReadLine()) != null)
                {
                    countries.Add(ReadCountryFromCsvLine(csvLine));
                }
            }
            return countries;
        }

        public static Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(",");
            Country result = new Country();

            result.Name = parts[0].Replace("\"", null).Trim();
            result.Code = parts[1];
            result.Population = long.Parse(parts[2]);

            return result;
        }
    }

}