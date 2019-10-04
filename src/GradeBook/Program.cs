using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook gradeBook = createNewDiskGradeBook();

            EnterGrades(gradeBook);

            OutputStatistics(gradeBook);
        }

        private static IBook createNewInMemoryGradeBook()
        {
            Console.WriteLine("Enter the title of your grade book.");

            var gradeBook = new InMemoryBook(Console.ReadLine());

            gradeBook.GradeAdded += OnGradeAdded; // Subscribe to grade added event

            return gradeBook;
        }

        private static IBook createNewDiskGradeBook()
        {
            Console.WriteLine("Enter the title of your grade book.");

            var gradeBook = new DiskBook(Console.ReadLine());

            gradeBook.GradeAdded += OnGradeAdded; // Subscribe to grade added event

            return gradeBook;
        }

        private static void EnterGrades(IBook gradeBook)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    gradeBook.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //finally
                //{
                //   Console.WriteLine("**");
                //}
            }
        }

        private static void OutputStatistics(IBook gradeBook)
        {
            var Statistics = gradeBook.GetStatistics();

            Console.WriteLine($"Statics for {gradeBook.Name}");
            Console.WriteLine($"    Lowest grade is {Statistics.Low}");
            Console.WriteLine($"    Highest grade is {Statistics.High}");
            Console.WriteLine($"    Average grade is {Statistics.Average}");
            Console.WriteLine($"    Average Letter grade is {Statistics.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
    }
}
