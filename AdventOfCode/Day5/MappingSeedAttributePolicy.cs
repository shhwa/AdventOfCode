namespace AdventOfCode.Day5
{
    public class MappingSeedAttributePolicy : ISeedAttributePolicy
    {
        private readonly IEnumerable<Map> maps;

        public MappingSeedAttributePolicy(IEnumerable<Map> maps)
        {
            this.maps = maps;
        }
        public void AddAttributes(Seed seed)
        {
            maps.ToList().ForEach(m => {
                var inputValue = seed.GetAttributeValue(m.AttributeToRead);
                seed.AddAttribute(m.AttributeToOutput, m.Lookup[inputValue]);
            });
        }
    }
}