using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var gradeBook = new Book( "Tom's Grade Book ");
            var Statistics = new Statistics();
            gradeBook.AddGrade( 89.1 );
            gradeBook.AddGrade( 90.5 );
            gradeBook.AddGrade( 77.5 );
            Statistics = gradeBook.GetStatistics();

            //Console.WriteLine( "Statics for " + name );
            Console.WriteLine( "    Lowest grade is " + Statistics.Low );
            Console.WriteLine( "    Highest grade is " + Statistics.High );
            Console.WriteLine( "    Average grade is " + Statistics.Average ); 
            
        }
    }
}
