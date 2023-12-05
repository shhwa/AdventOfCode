namespace AdventOfCode.Day5
{
    public class SeedSelector
    {
        private readonly ISeedReader seedReader;
        private ISeedAttributer seedAttributer;
        private IBestSeedFinder bestSeedFinder;

        public SeedSelector(ISeedReader seedReader, ISeedAttributer seedAttributer, IBestSeedFinder bestSeedFinder)
        {
            this.seedReader = seedReader;
            this.seedAttributer = seedAttributer;
            this.bestSeedFinder = bestSeedFinder;
        }

        public Seed Select(string seedsData, string attributes)
        {
            var seeds = seedReader.Read(seedsData).ToList();
            ISeedAttributePolicy policy = seedAttributer.CreatePolicy(attributes);

            seeds.ForEach(policy.AddAttributes);

            return bestSeedFinder.FindBest(seeds);
        }
    }
}