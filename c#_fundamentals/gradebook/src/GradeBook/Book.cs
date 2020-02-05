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
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"invalid {nameof(grade)}");
            }
        }

        public void AddLetterGrade(char letter)
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

        public Statistics GetStatistics()
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

        public void PrintStatistics()
        {
            var statistics = this.GetStatistics();
            System.Console.WriteLine($"The book \"{this.Name}\" has average grade {statistics.Average:N1}");
            System.Console.WriteLine($"The highest grade is {statistics.High}");
            System.Console.WriteLine($"The lowest value is {statistics.Low}");
            System.Console.WriteLine($"The letter grade is {statistics.Letter}");
        }

    }
}