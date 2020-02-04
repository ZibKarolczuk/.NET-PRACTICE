using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>() { 34.1, 10.3, 7.1, 4.2, 17.99 };
            grades.Add(56.1);

            if (args.Length > 0)
            {
                Console.WriteLine($"Good morning, {args[0]} !");
                System.Console.WriteLine($"The average grade is {avgArray(grades):N1}");
            }
            else
            {
                Console.WriteLine("Hello User!");
            }
        }

        public static double avgArray(List<double> array)
        {
            var result = 0.0;
            foreach (var number in array)
            {
                result += number;
            }

            result /= array.Count;
            return result;
        }
    }
}
