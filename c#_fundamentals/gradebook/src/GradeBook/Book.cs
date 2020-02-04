using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        private List<double> grades;
        private string name;
        private double highGrade;
        private double lowGrade;

        //CREATING ACCESOR
        public string Name { get => this.name; }

        public Book(string name)
        {
            this.grades = new List<double>();
            this.name = name;
            this.highGrade = double.MinValue;
            this.lowGrade = double.MaxValue;
        }

        public void AddGrade(double grade)
        {
            // SORT OF VALIDATION
            if (grade >= 0 && grade <= 100)
                this.grades.Add(grade);
        }

        public double GetAvgGrade()
        {
            var result = 0.0;

            foreach (var grade in this.grades)
            {
                result += grade;
                this.lowGrade = Math.Min(this.lowGrade, grade);
                this.highGrade = Math.Max(this.highGrade, grade);
            }

            // SORT OF VALIDATION - AVOID DIVISION BY ZERO
            if (this.grades.Count.Equals(0))
                return result;

            return result / this.grades.Count;
        }

        public void PrintStatistics()
        {
            System.Console.WriteLine($"The book \"{this.Name}\" has average grade {this.GetAvgGrade():N1}");
            System.Console.WriteLine($"The highest grade is {this.highGrade} but the lowest value is {this.lowGrade}.");
        }

    }
}