using System;

namespace Domain.CSharp.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer()
            {
                ID = "ID",
                Name = "NAME",
            };

            var person = new Person("First Name", "Last Name"); 

            Console.WriteLine("Hello World!");
        }
    }
}
