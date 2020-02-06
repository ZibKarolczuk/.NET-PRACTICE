using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"out/{Name}.txt"))
            {
                writer.WriteLine(grade);
                // writer.Dispose(); // No needed as USING takes care of exceptions and closing resurce. Close() is not good idea

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            };
        }

        public override BookStatistics GetStatistics()
        {
            var result = new BookStatistics();
            using (var reader = File.OpenText($"out/{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }

        public override void PrintStatistics()
        {
            new BookSummary(this).GetBookSummary();
        }
    }
}