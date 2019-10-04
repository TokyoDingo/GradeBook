using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {            
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            Statistics result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);      
            Assert.Equal('B', result.Letter);      
        }
        
        [Fact]
        public void GradeMustBeGreaterThanZero()
        {            
            var book = new Book("");
            var errorWasThrown = false;

            try
            {
                book.AddGrade(-1);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex);
                errorWasThrown = true;
            }

            Assert.True(errorWasThrown);            
        }
        
        [Fact]
        public void GradeMustBeLessThan100()
        {            
            var book = new Book("");
            var errorWasThrown = false;

            try
            {
                book.AddGrade(105);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex);
                errorWasThrown = true;
            }

            Assert.True(errorWasThrown);            
        }

        [Fact]
        public void LetterGradeIsValid()
        {
            var book = new Book("");
            var errorWasThrown = false;

            try{
                book.AddLetterGrade('E');
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex);
                errorWasThrown = true;
            }

            Assert.True(errorWasThrown);
        }        

        [Fact]
        public void LetterGradeAIs90()
        {
            var book = new Book("");

            book.AddLetterGrade('A');
            var stat = book.GetStatistics();

            Assert.Equal(90, stat.High);
        }      

        [Fact]
        public void LetterGradeBIs80()
        {
            var book = new Book("");

            book.AddLetterGrade('B');
            var stat = book.GetStatistics();

            Assert.Equal(80, stat.High);
        }

        [Fact]
        public void LetterGradeCIs70()
        {
            var book = new Book("");

            book.AddLetterGrade('C');
            var stat = book.GetStatistics();

            Assert.Equal(70, stat.High);
        }

        [Fact]
        public void LetterGradeDIs60()
        {
            var book = new Book("");

            book.AddLetterGrade('D');
            var stat = book.GetStatistics();

            Assert.Equal(60, stat.High);
        }

        [Fact]
        public void LetterGradeFIsZero()
        {
            var book = new Book("");

            book.AddLetterGrade('F');
            var stat = book.GetStatistics();

            Assert.Equal(0, stat.High);
        }
    }
}
