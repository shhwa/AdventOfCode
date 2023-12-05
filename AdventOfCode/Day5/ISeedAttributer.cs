namespace AdventOfCode.Day5
{
    public interface ISeedAttributer
    {
        ISeedAttributePolicy CreatePolicy(string attributes);
    }

    public class SeedAttributer : ISeedAttributer
    {
        public ISeedAttributePolicy CreatePolicy(string attributes)
        {
            var mapStrings = attributes.Split(Environment.NewLine + Environment.NewLine);

            var maps = mapStrings.Select(x => Map.Parse(x));

            return new MappingSeedAttributePolicy(maps);
        }
    }
}