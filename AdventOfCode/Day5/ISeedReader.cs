namespace AdventOfCode.Day5
{
    public interface ISeedReader
    {
        IEnumerable<Seed> Read(string seedInput);
    }
}