
namespace AdventOfCode;

public class ScratchCardCollection
{
    private IEnumerable<ScratchCard> scratchCardList;

    public ScratchCardCollection() { }

    public ScratchCardCollection(IEnumerable<ScratchCard> scratchCardList)
    {
        this.scratchCardList = scratchCardList;
    }

    public virtual int TotalScore => scratchCardList.Sum(x => x.Score);
}