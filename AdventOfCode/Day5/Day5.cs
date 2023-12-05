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
    }
}
