using FakeItEasy;

namespace AdventOfCode.Day5
{
    public class Day5
    {
        [Test]
        public void SeedSelectorShouldSelectSeed()
        {
            ISeedReader seedReader = A.Fake<ISeedReader>();
            ISeedAttributer seedAttributer = A.Fake<ISeedAttributer>();
            ISeedAttributePolicy seedAttributePolicy = A.Fake<ISeedAttributePolicy>();
            IBestSeedFinder bestSeedFinder = A.Fake<IBestSeedFinder>();

            SeedSelector seedSelector = new SeedSelector(
                seedReader,
                seedAttributer,
                bestSeedFinder
            );

            string seedInput = "a string";
            string attributeInput = "another string";

            Seed seed1 = new Seed(1);
            Seed seed2 = new Seed(2);

            A.CallTo(() => seedReader.Read(seedInput)).Returns(new [] { seed1, seed2 });
            A.CallTo(() => bestSeedFinder.FindBest(new [] { seed1, seed2 })).Returns(seed1);
            A.CallTo(() => seedAttributer.CreatePolicy(attributeInput)).Returns(seedAttributePolicy);

            Seed selectedSeed = seedSelector.Select(seedInput, attributeInput);
            
            A.CallTo(() => seedAttributePolicy.AddAttributes(seed1)).MustHaveHappened();
            A.CallTo(() => seedAttributePolicy.AddAttributes(seed2)).MustHaveHappened();
            Assert.That(selectedSeed, Is.EqualTo(seed1));
        }

        [Test]
        public void SeedReaderShouldReadSeeds()
        {
            ISeedReader seedReader = new SeedReader();

            var seeds = seedReader.Read("seeds: 79 14 55 13");

            Assert.That(seeds.Count(), Is.EqualTo(4));
            Assert.That(seeds.First().Id, Is.EqualTo(79));
            Assert.That(seeds.Last().Id, Is.EqualTo(13));
        }

        [Test]
        public void BestSeedFinderShouldFindClosestSeed()
        {
            IBestSeedFinder bestSeedFinder = new ClosestSeedFinder();
            var seed1 = new Seed(1);
            var seed2 = new Seed(2);

            seed1.AddAttribute("Location", 1);
            seed2.AddAttribute("Location", 10);

            var bestSeed = bestSeedFinder.FindBest(new [] { seed1, seed2 });

            Assert.That(bestSeed, Is.EqualTo(seed1));
        }

        [Test]
        public void SeedAttributePolicyShouldApplyAttributes()
        {
            Map map1 = new Map("first", "seed", new Dictionary<int, int> {
                { 1, 2 },
                { 2, 3 }
            });

            Map map2 = new Map("second", "first", new Dictionary<int, int> {
                { 2, 3 },
                { 3, 4 }
            });

            ISeedAttributePolicy seedAttributePolicy = new MappingSeedAttributePolicy(new [ ]{ map1, map2 });

            var seed = new Seed(1);

            seedAttributePolicy.AddAttributes(seed);

            Assert.That(seed.Attributes.Count(), Is.EqualTo(3));
            Assert.That(seed.GetAttributeValue("first"), Is.EqualTo(2));
            Assert.That(seed.GetAttributeValue("second"), Is.EqualTo(3));
        }
    }
}
