using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        List<double> grades;
        public string Name;

        public Book(string name)
        {
            Name = name;
            grades = new List<double>();
        }

        public void AddLetterGrade(char letter)
        {
            if( letter != 'A' && letter != 'B' && letter != 'C' && letter != 'D' && letter != 'F' )
            {
                throw new ArgumentException( $"Invalide {nameof(letter)}" );
            }

            switch(letter)
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
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade( double grade )
        {
            if(grade <= 100 && grade >= 0 ){
                grades.Add( grade );
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
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

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
                
            }

            return result;
        }
    }
}