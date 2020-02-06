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
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            // foreach (var day in daysOfWeek)
            // {
            //     System.Console.WriteLine(day.ToUpper());
            // }

            System.Console.Write("Write n'th number of week [1 - form Monday]: ");

            var line = System.Console.ReadLine();
            var index = int.Parse(line) - 1;

            System.Console.WriteLine($"You have selected {daysOfWeek[index]}");
        }
    }
}
