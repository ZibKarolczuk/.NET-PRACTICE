﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // var book = new InMemoryBook("Ania z zielonego wzgórza");
            IBook book = new DiskBook("Ania z zielonego wzgórza");

            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAddedAds;

            System.Console.WriteLine($"Please rate a book \"{book.Name}\".\n");
            EnterGrades(book);

            System.Console.WriteLine("");
            book.PrintStatistics();
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                System.Console.Write("Enter your grade or press 'q' to quit: ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine($"... {ex.Message}");
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine($"... {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added");
        }

        static void OnGradeAddedAds(object sender, EventArgs e)
        {
            System.Console.WriteLine("Check rates online!");
        }
    }
}
