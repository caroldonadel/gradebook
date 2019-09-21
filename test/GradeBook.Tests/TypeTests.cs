using System;
using Xunit; 

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests  // type tests, how do reference types behave, how do value types behave? 
    
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage; //log é um metodo, metodos sao chamados,  para usar delegates com mais de um metodo eu chamo o primeiro aqui, atribuo algo a variavel do delegate e depois usando += atribuo o outro metodo a ela, pode ser o mesmo metodo outra vez
           // log = new WriteLogDelegate(ReturnMessage);   igual classe, esse é o jeito "longo" de instancializar um delegate
            log += ReturnMessage;
            log+= IncrementCount;
            var result = log("Hello!");//chamando o metodo

            Assert.Equal(3, count); //testando quantas vezes os metodos do delegate sao chamados 
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void ValueTypesAlsoPassByValue() //TEST 6
        {
            var x = GetInt();
            SetInt(ref x); //nao vai alterar x pq c# vai usar pass by value, esse x utilizado é uma copia(a nao ser que se use a keyword ref)

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)//METHOD 6
        {
            z = 42;
        }

        private int GetInt()//METHOD 5
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef() //TEST 5 - 
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)//METHOD 4
        {
            book = new Book(name); 
        }
        
        [Fact]
        public void CSharpIsPassByValue() //TEST 4 - when I say that book = a new Book, am I writing that value into the book1 variable? Is there a way for this method to reach out and touch my book1 variable? Or am I just making changes to this local parameter? 
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)//METHOD 3
        {
            book = new Book(name); 
        }

        [Fact]
        public void CanSetNameFromReference() //TEST 3 - check to see if we can change the name of a book and how that happens. 
        { 
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");//named this test CanSetNameFromReference because what I'm passing to this method is a reference
            
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void StringBehaveLikeValueTypes() // TEST 7 
        { 
            string name = "Scott";
            var upper = MakeUppercase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUppercase(string parameter)
        {
            parameter.ToUpper();
            return parameter.ToUpper();
        }

        private void SetName(Book book, string name)//METHOD 2
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects() //TEST 1 - every time I invoke GetBook, I'm creating a new and unique and distinct object in memory
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }
        [Fact]
        public void TwoVarsCanReferenceObject() //TEST 2 - Can two different variables reference the same object somehow? 
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;/*I'm not making a copy of some book object and placing that into the book2 variable.
             Instead, what this line of code will do is take the value that inside of book1, that value is a pointer, it's a reference,
              and we're going to copy that value into the book2 variable. So we will have the same pointer value, where a pointer is just
               some number that's going to lead us to some memory cell that's in our computer. */

            Assert.Same(book1, book2); //os pointers sao iguais apenas, as duas variaveis fazem referencia igual para o mesmo objeto
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)//METHOD 1
        {
            return new Book(name);
        }
    }
}
