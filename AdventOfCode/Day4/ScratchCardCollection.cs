
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
        var si = 0;
        var scratchCardCopyCounter = scratchCardList.ToDictionary(x => si++, x => 1);

        for(int scratchCardIndex = 0; scratchCardIndex < scratchCardList.Count; scratchCardIndex++)
        {
            var score = scratchCardList[scratchCardIndex].NumberOfWinningNumbers;

            for (int copyingCardIndex = 1; copyingCardIndex <= score; copyingCardIndex++)
            {
                if (scratchCardCopyCounter.Count > scratchCardIndex + copyingCardIndex)
                {
                    scratchCardCopyCounter[scratchCardIndex+copyingCardIndex] += scratchCardCopyCounter[scratchCardIndex];
                }
            }
            
        }

        return scratchCardCopyCounter.Sum(x => x.Value);
    }

    public virtual int TotalScore => scratchCardList.Sum(x => x.Score);
}