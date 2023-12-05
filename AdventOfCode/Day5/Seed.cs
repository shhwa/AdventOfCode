
namespace AdventOfCode.Day5
{
    public class Seed
    {
        public Seed(long id)
        {
            Id = id;
            Attributes = new List<SeedAttribute> { new SeedAttribute { Name = "seed", Value = Id } };
        }

        public long Id { get;set; }

        public IEnumerable<SeedAttribute> Attributes { get; set; }

        public long GetAttributeValue(string name)
        {
            return Attributes.Single(a => a.Name == name).Value;
        }

        public void AddAttribute(string name, long value)
        {
            Attributes = Attributes.Concat(new [] { new SeedAttribute { Name = name, Value = value }});
        }
    }
}