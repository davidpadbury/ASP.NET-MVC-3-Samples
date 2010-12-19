using System.Collections.Generic;

namespace RazorEmailerExample
{
    public class Person
    {
        public static IEnumerable<Person> ListAll()
        {
            return new Person[]
                       {
                           new Person {Name = "David"},
                           new Person {Name = "Scott"},
                           new Person {Name = "Daniel"}
                       };
        }
        public string Name { get; set; }
    }
}