
namespace AdventOfCode;

public class ScratchCardCollection
{
    private List<ScratchCard> scratchCardList;

    public ScratchCardCollection() { }

    public ScratchCardCollection(IEnumerable<ScratchCard> scratchCardList)
    {
        this.scratchCardList = scratchCardList.ToList();
    }

    public int TotalScratchCards => scratchCardList.Where(x => x.Score == 0).Count();

    public virtual int TotalScore => scratchCardList.Sum(x => x.Score);
}