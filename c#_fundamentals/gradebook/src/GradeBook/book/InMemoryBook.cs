using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        private List<double> grades;
        readonly string category = "Science";
        public const string ISBN = "12314-90231-23123-33";

        public override event GradeAddedDelegate GradeAdded;

        public InMemoryBook(string name) : base(name)
        {
            this.grades = new List<double>();
            category = "Thriller";
        }

        public override void AddGrade(double grade)
        {
            // SORT OF VALIDATION
            if (grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"invalid {nameof(grade)}");
            }
        }

        public override BookStatistics GetStatistics()
        {
            var result = new BookStatistics();

            foreach (var grade in grades)
            {
                result.Add(grade);
            }

            return result;
        }

        public override void PrintStatistics()
        {
            new BookSummary(this).GetBookSummary();
        }

    }


}