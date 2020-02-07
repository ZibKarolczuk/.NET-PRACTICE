using System.IO;

namespace ArrayDaysOfWeek
{
    public class CsvReader
    {
        public const string CSV_FILE_PATH = "files/countries.csv";
        public static Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[nCountries];

            using (StreamReader sr = new StreamReader(CSV_FILE_PATH))
            {
                for (var i = 0; i < nCountries; i++)
                {
                    string csvLine = sr.ReadLine();
                    countries[i] = ReadCountryFromCsvLine(csvLine);
                }
            }
            return countries;
        }

        public static Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(",");
            Country result = new Country();

            result.Name = parts[0];
            result.Code = parts[1];
            result.Population = long.Parse(parts[2]);

            return result;
        }
    }

}