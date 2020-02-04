using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Ania z zielonego wzgórza");

            book.AddGrade(89.4);
            book.AddGrade(50.7);
            book.AddGrade(98.9);

            book.PrintStatistics();
        }
    }
}
