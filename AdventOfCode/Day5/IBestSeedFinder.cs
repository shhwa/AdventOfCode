namespace AdventOfCode.Day5
{
    public interface IBestSeedFinder
    {
        Seed FindBest(IEnumerable<Seed> seeds);
    }
}