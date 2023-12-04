
namespace AdventOfCode;

public interface IScratchCardCollector
{
    ScratchCardCollection Collect(IEnumerable<ScratchCard> scratchCardList);
}
