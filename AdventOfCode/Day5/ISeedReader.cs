namespace AdventOfCode.Day5
{
    public interface ISeedReader
    {
        IEnumerable<Seed> Read(string seedInput);
    }

    public class SeedReader : ISeedReader
    {
        public IEnumerable<Seed> Read(string seedInput)
        {
            return seedInput
                .Replace("seeds: ", "")
                .Split(" ")
                .Select(x => new Seed(int.Parse(x)));
        }
    }
}