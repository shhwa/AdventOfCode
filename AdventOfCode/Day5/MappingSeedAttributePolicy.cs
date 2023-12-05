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

                var range = m.ranges.SingleOrDefault(r => r.source <= inputValue && r.source + r.length >= inputValue);
                var output = range == null ? inputValue : range.destination - range.source + inputValue;

                seed.AddAttribute(m.AttributeToOutput, output);
            });
        }
    }
}