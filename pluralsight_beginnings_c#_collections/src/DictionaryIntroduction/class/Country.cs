namespace DictionaryIntroduction
{
    public class Country
    {
        public string Name;
        public string Code;
        public long Population;
        public Country() { }
        public Country(string name, string code, long population)
        {
            Name = name;
            Code = code;
            Population = population;
        }
    }
}