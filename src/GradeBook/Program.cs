using System; 
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's Grade Book");
            book.GradeAdded += OnGradeAdded; //PASSO 5 -  add um metodo na variavel do delegate
             
           // book.GetStatistics(); 

            while(true)
            {
                Console.Write("Enter a grade or q to quit");
                var input = Console.ReadLine();
                

                if(input == "q")
                {
                    break;
                }

                try{
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                   }

                catch(ArgumentException ex)    
                   {
                       Console.WriteLine(ex.Message);
                   }
                catch(FormatException ex)
                   {
                       Console.WriteLine(ex.Message);
                   }
            };

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
                      
        }
        static void OnGradeAdded(object sender, EventArgs e) //PASSO 4 - criando metodo com assinatura especifica que vai ser add na variavel do delegate
        {
            Console.WriteLine("A grade was added");
        }
    }
}
