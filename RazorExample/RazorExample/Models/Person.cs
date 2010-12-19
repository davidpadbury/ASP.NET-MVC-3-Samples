using System.Collections.Generic;

namespace RazorExample.Models
{
    public class Person
    {
        public static IEnumerable<Person> ListAll()
        {
            return new[]
                       {
                           new Person
                               {
                                   Name = "David Padbury",
                                   ImageUrl = "/Content/DavidPadbury.png"
                               },
                           new Person
                               {
                                   Name = "Scott Weinstein",
                                   ImageUrl = "/Content/ScottWeinstein.png"
                               },
                           new Person
                               {
                                   Name = "Daniel Moore",
                                   ImageUrl = "/Content/DanMoore.png"
                               }
                       };
        }

        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}