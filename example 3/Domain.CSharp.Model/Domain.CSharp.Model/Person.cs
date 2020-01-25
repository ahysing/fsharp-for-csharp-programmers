using System;

namespace Domain.CSharp.Model
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = firstName;
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
     }   
}