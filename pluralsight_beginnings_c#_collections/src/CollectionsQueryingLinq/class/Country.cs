namespace CollectionsQueryingLinq
{
    public class Country
    {
        public string Name { get; }
        public string Code { get; }
        public double Population { get; }

        public Country(string name, string code, double population)
        {
            Name = name;
            Code = code;
            Population = population;
        }
    }
}