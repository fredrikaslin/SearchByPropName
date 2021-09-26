using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = Test(new SearchCriteria() { SearchProp = "Email", Value = "fredrik@mail.se" });
            Console.WriteLine(test.Email);
            Console.ReadLine();
        }

        public static Adress Test(SearchCriteria searchCriteria)
        {
            var adresses = GetAdresses();
            var selectedProperty = typeof(Adress).GetProperty(searchCriteria.SearchProp);
            var result = adresses.Where(x => selectedProperty.GetValue(x).ToString().Contains(searchCriteria.Value)).FirstOrDefault();
            
            return result;
        }

        public static List<Adress> GetAdresses()
        {
            return new List<Adress>()
            {
                new Adress()
                {
                    Email = "fredrik@mail.se"
                },
                new Adress()
                {
                    Email = "nått annat"
                }
            };
        }

        public class Adress 
        {
            public string PhoneNumener { get; set; }

            public string Email { get; set; }
            public string VadSomHelst { get; set; }

        }

        public class SearchCriteria
        {
            public string SearchProp { get; set; }
            public string Value { get; set; }
        }

        
    }
}
