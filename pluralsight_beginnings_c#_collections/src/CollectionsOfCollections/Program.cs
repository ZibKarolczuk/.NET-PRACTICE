using System;
using System.Collections.Generic;

namespace CollectionsOfCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            var countries = new List<Country>() {
                new Country("Belgium", "BEL", "Central Europe", 116e5),
                new Country("Turkey", "TUR", "South Europe", 841e5),
                new Country("France", "FRA", "Central Europe", 652e5),
                new Country("Germany", "GET", "Central Europe", 837e5),
                new Country("Rusia", "RUS", "East Europe", 144e6),
                new Country("United Kingdom", "GBR", "North Europe", 677e5),
                new Country("Italy", "ITA", "Central Europe", 605e5),
                new Country("Spain", "ESP", "West Europe", 67e5),
                new Country("Ukraine", "UKR", "East Europe", 438e5),
                new Country("Poland", "POL", "East Europe", 379e5),
                new Country("Romania", "ROM", "East Europe", 193e5),
                new Country("Kazakhstan", "KZH", "East Europe", 187e5),
                new Country("Netherlands", "NED", "Central Europe", 171e5),
                new Country("Grece", "GRE", "Central South", 104e5),
                new Country("Czech Republic", "CZE", "East Europe", 107e5),
                new Country("Sweden", "SWE", "North Europe", 101e5),
                new Country("Portugal", "POR", "West Europe", 102e5),
                new Country("Azerbaijan", "AZR", "East Europe", 10e6)
            };

            var countriesRegions = new Dictionary<string, List<Country>>();

            foreach (var country in countries)
            {
                if (!countriesRegions.ContainsKey(country.Region))
                {
                    countriesRegions.Add(country.Region, new List<Country>());
                }
                countriesRegions[country.Region].Add(country);
            }

            foreach (var region in countriesRegions.Keys)
            {
                System.Console.WriteLine($"{region}:");
                foreach (var country in countriesRegions[region])
                {
                    System.Console.WriteLine($"..{country.Name}");
                }
                System.Console.WriteLine("");
            }

        }
    }
}
