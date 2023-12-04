namespace AdventOfCode;

public class ScratchCardCounter
{
    private IScratchCardReader scratchCardReader;
    private IScratchCardCollector scratchCardCollector;

    public ScratchCardCounter(IScratchCardReader scratchCardReader, IScratchCardCollector scratchCardCollector)
    {
        this.scratchCardReader = scratchCardReader;
        this.scratchCardCollector = scratchCardCollector;
    }

    public ScratchCardCollection Count(string data)
    {
        var scratchCards = scratchCardReader.Read(data);
        var collection = scratchCardCollector.Collect(scratchCards);

        return collection;
    }
}
