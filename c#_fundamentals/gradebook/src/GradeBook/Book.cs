using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        event GradeAddedDelegate GradeAdded;
        string Name { get; }
        Statistics GetStatistics();
        void PrintStatistics();
    }

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        //CREATING ACCESOR - EASIER APPROACH (COMPILER TAKE CARE OF THE REST!)
        // THIS IS CALLED AUTOPROPERTY IN C#
        public string Name
        {
            get;
            // private set;
            set;
        }
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
        public abstract void PrintStatistics();
    }

    public class InMemoryBook : Book
    {
        private List<double> grades;
        // private string name;

        //CREATING ACCESOR

        // private string _name;
        // public string Name
        // {
        //     get
        //     {
        //         return _name;
        //     }
        //     set
        //     {
        //         if (!String.IsNullOrEmpty(value))
        //         {
        //             _name = value;
        //         }
        //     }
        // }

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

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'E':
                    AddGrade(50);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            // PRACTICE SAME LOGIC WITH FOREACH LOOP:

            // foreach (var grade in this.grades)
            // {
            //     result.Average += grade;
            //     result.Low = Math.Min(result.Low, grade);
            //     result.High = Math.Max(result.High, grade);
            // }


            // PRACTICE SAME LOGIC WITH DO-WHILE LOOP:

            // var index = 0;
            // do
            // {
            //     result.Average += grades[index];
            //     result.Low = Math.Min(result.Low, grades[index]);
            //     result.High = Math.Max(result.High, grades[index]);
            //     index++;
            // } while (index < grades.Count);


            // PRACTICE SAME LOGIC WITH WHILE LOOP:

            // var index = 0;

            // while (index < grades.Count)
            // {
            //     result.Average += grades[index];
            //     result.Low = Math.Min(result.Low, grades[index]);
            //     result.High = Math.Max(result.High, grades[index]);
            //     index++;
            // }


            // PRACTICE SAME LOGIC WITH FOR LOOP:

            for (var index = 0; index < grades.Count; index++)
            {
                if (grades[index] < 60)
                {
                    // break
                    // continue;
                }

                result.Average += grades[index];
                result.Low = Math.Min(result.Low, grades[index]);
                result.High = Math.Max(result.High, grades[index]);
            }

            // SORT OF VALIDATION - AVOID DIVISION BY ZERO
            if (!this.grades.Count.Equals(0))
                result.Average /= this.grades.Count;

            switch (result.Average)
            {
                case var d when d > 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d > 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d > 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d > 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        public override void PrintStatistics()
        {
            var statistics = this.GetStatistics();
            System.Console.WriteLine($"The book \"{this.Name}\" has average grade {statistics.Average:N1}");
            System.Console.WriteLine($"ISBN is {InMemoryBook.ISBN}");
            System.Console.WriteLine($"The highest grade is {statistics.High}");
            System.Console.WriteLine($"The lowest value is {statistics.Low}");
            System.Console.WriteLine($"The letter grade is {statistics.Letter}");
        }

    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);

                // writer.Close(); // Not a great solution as file still open if exception occurs
                // writer.Dispose(); // Much better

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            };
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        public override void PrintStatistics() { }
    }
}