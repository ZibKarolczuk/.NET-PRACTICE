using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsQueryingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var countries = new List<Country>() {
                new Country("Belgium", "BEL", 116e5),
                new Country("Turkey", "TUR", 841e5),
                new Country("France", "FRA", 652e5),
                new Country("Germany", "GET", 837e5),
                new Country("Rusia", "RUS", 144e6),
                new Country("United Kingdom", "GBR", 677e5),
                new Country("Italy", "ITA", 605e5),
                new Country("Spain", "ESP", 467e5),
                new Country("Ukraine", "UKR", 438e5),
                new Country("Poland", "POL", 379e5),
                new Country("Romania", "ROM", 193e5),
                new Country("Kazakhstan", "KZH", 187e5),
                new Country("Netherlands", "NED", 171e5),
                new Country("Grece", "GRE", 104e5),
                new Country("Czech Republic", "CZE", 107e5),
                new Country("Sweden", "SWE", 101e5),
                new Country("Portugal", "POR", 102e5),
                new Country("Azerbaijan", "AZR", 10e6)
            };

            List<Country> countriesSorted = countries.OrderBy(x => x.Name).ToList();
            List<Country> countriesTenByCodes = countries.OrderByDescending(x => x.Name).Take(10).ToList();
            List<Country> countriesFiltered = countries.Where(x => x.Population > 30000000).OrderBy(x => x.Name).ToList();

            List<Country> countriesFilteredOutSomeString = countries.Where(x => !x.Code.Contains('E')).OrderBy(x => x.Population).ToList();
            GetResultByProvidedLinq(countriesFilteredOutSomeString);

            //ORIGIN OF LINQ QUERY, BETTER NOT USE IT AS FUNCTIONALITIES ARE A FEW
            var countriesFilteredOutQuerySynttax = from country in countries
                                                   where !country.Name.Contains('r')
                                                   select country;
            // GetResultByProvidedLinq(countriesFilteredOutQuerySynttax);
        }

        static void GetResultByProvidedLinq(List<Country> countries)
        {
            foreach (var c in countries)
            {
                PrintCountry(c);
            }
        }

        static void PrintCountry(Country country)
        {
            System.Console.WriteLine($"{country.Code}, {country.Name} has population of {country.Population} people.");
        }
    }
}
