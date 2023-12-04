
namespace AdventOfCode;

public class ScratchCardCollection
{
    private List<ScratchCard> scratchCardList;

    public ScratchCardCollection() { }

    public ScratchCardCollection(IEnumerable<ScratchCard> scratchCardList)
    {
        this.scratchCardList = scratchCardList.ToList();
    }

    public int TotalScratchCards => CountScratchCards();

    private int CountScratchCards()
    {
        foreach(var scratchCard in scratchCardList)
        {
            var numberOfCardsToCopy = scratchCard.NumberOfWinningNumbers;
            if (numberOfCardsToCopy == 0)
            {
                continue;
            }

            foreach(var index in Enumerable.Range(scratchCardList.IndexOf(scratchCard)+1, numberOfCardsToCopy))
            {
                scratchCardList[index].Copies += scratchCard.Copies;
            }
        }

        return scratchCardList.Sum(x => x.Copies);
    }

    public virtual int TotalScore => scratchCardList.Sum(x => x.Score);
}