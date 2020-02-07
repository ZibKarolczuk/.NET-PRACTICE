using System;
using System.Collections.Generic;

namespace ListCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                System.Console.WriteLine("List od countries:");

                List<Country> countries = CsvReader.ReadCountries();

                Country czech = new Country();
                czech.Name = "Czech Republic";
                czech.Population = 30000000;
                czech.Code = "CZE";

                var index = countries.FindIndex(x => x.Population < 1000);
                countries.Insert(index, czech);

                countries.Remove(czech);

                foreach (var country in countries)
                {
                    System.Console.WriteLine($"{country.Name}: {country.Population: ### ### ### ###}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
