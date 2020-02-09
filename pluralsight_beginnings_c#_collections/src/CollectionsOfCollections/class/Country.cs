namespace CollectionsOfCollections
{
    public class Country
    {
        public string Name { get; }
        public string Code { get; }
        public string Region { get; }
        public double Population { get; }

        public Country(string name, string code, string region, double population)
        {
            Name = name;
            Code = code;
            Region = region;
            Population = population;
        }
    }
}