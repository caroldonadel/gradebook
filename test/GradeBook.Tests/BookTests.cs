using System;
using Xunit; //namespace contain the types and APIs to interact w the xunit framework
/*When I'm writing code inside of a project, like when I'm writing the code inside of the Main method  
inside of the Program class, I have access to other classes that are in the same project.
 But if I try to access a class that is in a different project, then I need to tell the C# compiler, I am using this
  other project,--> add reference */
/*In this case, we are in a namespace that is underneath the GradeBook namespace where the Book exists, 
so in this case, I do not need a using statement */

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]/*think of an attribute as a little piece of data that is attached to the symbol that follows it.
         So Fact is a little piece of data that is attached to this method, Test1.
          And the way xUnit uses this attribute is that xUnit, when it loads up your test project to find the tests inside
         and execute them and tell you what passed and what failed, it goes looking for methods that have this Fact attribute
          attached */
        public void BookCalculatesAnAverageGrade() //name your tests properly
        {
            //arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(85.6, result.Average, 1); 
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
             /*the API that you are going to use is an API provided by a class named Assert. 
            So this is in the xUnit namespace. And if I use the dot operator in the IntelliSense window, 
            I can see a number of different static methods available on that class that I can invoke to check different 
            conditions or to make assertions. */
            /*So with Equal, I pass in two values, and the Equal assertion will make sure those two values match.
             And we usually think of these two values as the expected value and the actual value. So the expected 
             value is, what do I expect the result to be?  */
        }

        /*[Fact]
        public void ChecksIfAInvalidGradeIsAddedToBook()
        {
            var book = new Book("");
            book.AddGrade(105);
            
            Assert.DoesNotContain(105, book.grades);
        } */

        /* [Fact]
        public void Test1()
        {
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            
            var result = book.GetStatistics();

            Assert.Equal(book.index, (book.grades.Count));
        } */
    }
}
