using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        List<double> grades;
        string name;

        public Book(string name)
        {
            this.name = name;
            grades = new List<double>();
        }

        public void AddGrade( double grade )
        {
            grades.Add( grade );
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            var sumAllGrades = 0.0;
            result.Average = 0.0;
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            foreach( var grade in grades )
            {
                sumAllGrades += grade;
                result.Low = Math.Min( grade, result.Low );
                result.High = Math.Max( grade, result.High );
            }

            result.Average = sumAllGrades / grades.Count;

            return result;
        }
    }
}