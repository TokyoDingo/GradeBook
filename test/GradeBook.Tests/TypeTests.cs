using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Tom";
            var upper = MakeUppercase(name);

            Assert.Equal("Tom", name);
            Assert.Equal("TOM", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {            
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }
        
        [Fact]
        public void CSharpCanPassByRef()
        {            
            var book1 = GetBook("Book 1");
            GetBookSetNameByRef(ref book1,"New Name");

            Assert.Equal( "New Name", book1.Name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {            
            var book1 = GetBook("Book 1");
            GetBookSetName(book1,"New Name");

            Assert.Equal( "Book 1", book1.Name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {            
            var book1 = GetBook("Book 1");
            SetName(book1,"New Name");

            Assert.Equal( "New Name", book1.Name);
        }

        [Fact]
        public void GetBookReturnDifferentObjects()
        {            
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.NotSame(book1, book2);
        }
        
        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {            
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
        }


        Book GetBook(string name)
        {
            return new Book(name);
        }

        private void SetName( Book book, string name)
        {
            book.Name = name;
        }

        private void GetBookSetName( Book book, string name)
        {
            book = new Book(name);
        }

        private void GetBookSetNameByRef( ref Book book, string name)
        {
            book = new Book(name);
        }
    
        private int GetInt()
        {
            return 3;
        }
        
        private void SetInt(ref int z)
        {
            z = 42;
        }
    }
}
