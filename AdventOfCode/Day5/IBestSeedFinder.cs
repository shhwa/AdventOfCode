using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode.Day5
{
    public interface IBestSeedFinder
    {
        Seed FindBest(IEnumerable<Seed> seeds);
    }

    public class ClosestSeedFinder : IBestSeedFinder
    {
        public Seed FindBest(IEnumerable<Seed> seeds)
        {
            return seeds
                .OrderBy(seed => seed.GetAttributeValue("location"))
                .First();
        }
    }
}