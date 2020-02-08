using System;
using System.Collections.Generic;

namespace DictionaryIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            Country poland = new Country("Poland", "POL", 40000000);
            Country czechia = new Country("Czech republic", "CZE", 10000000);
            Country germany = new Country("Germany", "GER", 70000000);

            var countries = new Dictionary<string, Country>(){
                {poland.Code, poland},
                {czechia.Code, czechia},
                {germany.Code, germany}
            };

            // countries.Add(poland.Code, poland);
            // countries.Add(czechia.Code, czechia);
            // countries.Add(germany.Code, germany);

            Country countryRead = countries["POL"];
            System.Console.WriteLine($"Poland read from dictionary is {countryRead.Name}");

            foreach (var c in countries)
            {
                System.Console.WriteLine(countries[c.Key].Name);
                System.Console.WriteLine(c.Value.Name);
                System.Console.WriteLine(".");
            }
            foreach (var c in countries.Values)
            {
                System.Console.WriteLine(c.Name);
            }

            string codeCountry = "POL";
            bool exists = countries.TryGetValue(codeCountry, out Country country);
            if (exists)
            {
                System.Console.WriteLine($"Exists such country {country.Name}");
            }
            else
            {
                System.Console.WriteLine($"No such country {codeCountry}");
            }

        }
    }
}
