using System.Collections.Frozen;
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

            seed1.AddAttribute("location", 1);
            seed2.AddAttribute("location", 10);

            var bestSeed = bestSeedFinder.FindBest(new [] { seed1, seed2 });

            Assert.That(bestSeed, Is.EqualTo(seed1));
        }

        [Test]
        public void SeedAttributePolicyShouldApplyAttributes()
        {
            Map map1 = new Map("first", "seed", new [] { new Range(1, 2, 100) });

            Map map2 = new Map("second", "first", new [] { new Range(1, 2, 100) });

            ISeedAttributePolicy seedAttributePolicy = new MappingSeedAttributePolicy(new [ ]{ map1, map2 });

            var seed = new Seed(1);

            seedAttributePolicy.AddAttributes(seed);

            Assert.That(seed.Attributes.Count(), Is.EqualTo(3));
            Assert.That(seed.GetAttributeValue("first"), Is.EqualTo(2));
            Assert.That(seed.GetAttributeValue("second"), Is.EqualTo(3));
        }

        [Test]
        public void MapShouldCreateFromString()
        {
            Map map = Map.Parse(@"seed-to-soil map:
50 98 2
52 50 48");
            
            
            Assert.That(map.AttributeToOutput, Is.EqualTo("soil"));
            Assert.That(map.AttributeToRead, Is.EqualTo("seed"));
            Assert.That(map.ranges.Count(), Is.EqualTo(2));
            Assert.That(map.ranges.First().source, Is.EqualTo(98));
            Assert.That(map.ranges.First().destination, Is.EqualTo(50));
            Assert.That(map.ranges.First().length, Is.EqualTo(2));
        }

        [Test]
        public void AttributerShouldCreatePolicy()
        {
            ISeedAttributer seedAttributer = new SeedAttributer();

            var policy = seedAttributer.CreatePolicy(
@"seed-to-first map:
2 1 2

first-to-second map:
3 2 2"    );

            var seed = new Seed(1);
            policy.AddAttributes(seed);

            Assert.That(seed.GetAttributeValue("first"), Is.EqualTo(2));
            Assert.That(seed.GetAttributeValue("second"), Is.EqualTo(3));
        }

        [Test]
        public void Part1Example()
        {
            SeedSelector seedSelector = new SeedSelector(
                new SeedReader(),
                new SeedAttributer(),
                new ClosestSeedFinder()
            );

            var seed = seedSelector.Select(Par1ExampleSeedData, Part1ExampleAttributeData);

            Assert.That(seed.GetAttributeValue("seed"), Is.EqualTo(13));
        }

        private string Par1ExampleSeedData = "seeds: 79 14 55 13";

        private string Part1ExampleAttributeData = @"seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4";
    }
}
