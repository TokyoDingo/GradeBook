using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the title of your grade book.");
            var name = Console.ReadLine();

            var gradeBook = new Book( name );
            var Statistics = new Statistics();

            gradeBook.GradeAdded += OnGradeAdded;

            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if(input == "q")
                {
                    break;
                }

                try{
                    var grade = double.Parse(input);
                    gradeBook.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //finally
                //{
                //   Console.WriteLine("**");
                //}
            }

            Statistics = gradeBook.GetStatistics();

            Console.WriteLine( $"Statics for {gradeBook.Name}" );
            Console.WriteLine( $"    Lowest grade is {Statistics.Low}" );
            Console.WriteLine( $"    Highest grade is {Statistics.High}" );
            Console.WriteLine( $"    Average grade is {Statistics.Average}" ); 
            Console.WriteLine( $"    Letter grade is {Statistics.Letter}" ); 
            
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
    }
}
