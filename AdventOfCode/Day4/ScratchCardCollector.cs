
namespace AdventOfCode;

public class ScratchCardCollector : IScratchCardCollector
{
    public ScratchCardCollector()
    {
    }

    public ScratchCardCollection Collect(IEnumerable<ScratchCard> scratchCardList)
    {
        return new ScratchCardCollection(scratchCardList);
    }
}
