using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Ania z zielonego wzgórza");
            System.Console.WriteLine($"Please rate a book \"{book.Name}\".\n");

            while (true)
            {
                System.Console.Write("Enter your grade or press 'q' to quit: ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                var grade = double.Parse(input);
                book.AddGrade(grade);
            }

            System.Console.WriteLine("");
            book.PrintStatistics();
        }
    }
}
