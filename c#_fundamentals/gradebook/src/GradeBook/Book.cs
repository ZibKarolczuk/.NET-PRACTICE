using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        // private string name;
        public string Name;

        //CREATING ACCESOR
        // public string Name { get => { return this.name} };

        public Book(string name)
        {
            this.grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            // SORT OF VALIDATION
            if (grade >= 0 && grade <= 100)
                this.grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in this.grades)
            {
                result.Average += grade;
                result.Low = Math.Min(result.Low, grade);
                result.High = Math.Max(result.High, grade);
            }

            // SORT OF VALIDATION - AVOID DIVISION BY ZERO
            if (!this.grades.Count.Equals(0))
                result.Average /= this.grades.Count;

            return result;
        }

        public void PrintStatistics()
        {
            var statistics = this.GetStatistics();
            System.Console.WriteLine($"The book \"{this.Name}\" has average grade {statistics.Average:N1}");
            System.Console.WriteLine($"The highest grade is {statistics.High} but the lowest value is {statistics.Low}.");
        }

    }
}