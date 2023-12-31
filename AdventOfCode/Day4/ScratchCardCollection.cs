
namespace AdventOfCode;

public class ScratchCardCollection
{
    private List<ScratchCard> scratchCardList;

    public ScratchCardCollection() { }

    public ScratchCardCollection(IEnumerable<ScratchCard> scratchCardList)
    {
        this.scratchCardList = scratchCardList.ToList();
    }

    public int TotalScratchCards => scratchCardList.Sum(x => x.Copies);

    public void MakeCopiesOfScratchCards()
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
                if (index < scratchCardList.Count)
                {
                    scratchCardList[index].Copies += scratchCard.Copies;
                }
            }
        }
    }

    public virtual int TotalScore => scratchCardList.Sum(x => x.Score);
}