using FakeItEasy;

namespace AdventOfCode;

public class Day4
{
    [Test]
    public void ScratchCardCounterGetsTotalWinningPoints()
    {
        var scratchCardReader = A.Fake<IScratchCardReader>();
        var scratchCardCollector = A.Fake<IScratchCardCollector>();

        ScratchCardCounter scratchCardCounter = new ScratchCardCounter(
            scratchCardReader,
            scratchCardCollector
        );

        var scratchCardList = new List<ScratchCard>();
        var scratchCardCollection = A.Fake<ScratchCardCollection>();

        A.CallTo(() => scratchCardReader.Read(ExampleData)).Returns(scratchCardList);
        A.CallTo(() => scratchCardCollector.Collect(scratchCardList)).Returns(scratchCardCollection);

        Assert.That(scratchCardCounter.Count(ExampleData), Is.EqualTo(scratchCardCollection));
    }

    [Test]
    public void ScratchCardReaderShouldGetWinningNumbers()
    {
        ScratchCardReader reader = new ScratchCardReader();

        var cards = reader.Read("Card 1: 1  2 3 |");

        Assert.That(cards.Single().WinningNumbers, Is.EqualTo(new int[] { 1, 2, 3 } ));
    }

    [Test]
    public void ScratchCardReaderShouldGetPlayedNumbers()
    {
        ScratchCardReader reader = new ScratchCardReader();

        var cards = reader.Read("Card 1: 1  2 3 | 5  6 7 8");

        Assert.That(cards.Single().PlayedNumbers, Is.EqualTo(new int[] { 5, 6, 7, 8 } ));
    }

    [Test]
    public void ScratchCardReaderShouldGetManyCards()
    {
        ScratchCardReader reader = new ScratchCardReader();

        var cards = reader.Read(@"Card 1: 1  2 3 | 5  6 7 8
Card 2: 9  10 11 | 12  31 14 15");

        Assert.That(cards.Count(), Is.EqualTo(2));
    }

    [Test]
    public void CardCollectorShouldCreateACollectionWithTotalScore()
    {
        ScratchCardCollector scratchCardCollector = new ScratchCardCollector();

        var collection = scratchCardCollector.Collect(new List<ScratchCard> {
            new ScratchCard { PlayedNumbers = new [] { 1, 2, 3}, WinningNumbers = new [] { 1, 2, 6 } },
            new ScratchCard { PlayedNumbers = new [] { 1, 2, 3}, WinningNumbers = new [] { 1, 2, 3 } }
        });

        Assert.That(collection.TotalScore, Is.EqualTo(6));
    }

    [TestCase("Card 1: 1 | 2", 0)]
    [TestCase("Card 1: 1 | 1", 1)]
    [TestCase("Card 1: 1 2 | 1", 1)]
    [TestCase("Card 1: 1 2 | 1 2", 2)]
    [TestCase("Card 1: 1 2 3 | 1 2 3", 4)]
    public void ScratchCardShouldCalculateScore(string cardString, int expectedScore)
    {
        ScratchCard scratchCard = new ScratchCard(cardString);

        Assert.That(scratchCard.Score, Is.EqualTo(expectedScore));
    }

    public string ExampleData = @"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";
}
