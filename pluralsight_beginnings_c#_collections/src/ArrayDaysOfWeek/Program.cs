using System;

namespace ArrayDaysOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = {
                "Monday",
                "Tuesday",
                "Wensday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            System.Console.WriteLine("Before mispelling:");
            foreach (var day in daysOfWeek)
                System.Console.WriteLine(day.ToUpper());

            daysOfWeek[2] = "Wednesday";

            System.Console.WriteLine("\nAfter correction:");
            foreach (var day in daysOfWeek)
                System.Console.WriteLine(day.ToLower());

            System.Console.WriteLine("-- - --");

            try
            {
                System.Console.Write("\nWrite n'th number of week [1 - form Monday]: ");

                var line = System.Console.ReadLine();
                var index = int.Parse(line) - 1;

                System.Console.WriteLine($"You have selected {daysOfWeek[index]}");
            }
            catch (Exception ex)
            {
                // throw new IndexOutOfRangeException(ex.Message);
                System.Console.WriteLine(ex.Message);
            }

            System.Console.WriteLine("-- - --");

            try
            {
                System.Console.WriteLine("List od countries:");

                Country[] countries = CsvReader.ReadFirstNCountries(4);

                foreach (var country in countries)
                {
                    System.Console.WriteLine($"{country.Code}: {country.Population: ### ### ### ###}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
