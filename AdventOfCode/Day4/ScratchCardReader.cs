
namespace AdventOfCode;

public class ScratchCardReader : IScratchCardReader
{
    public ScratchCardReader()
    {
    }

    public IEnumerable<ScratchCard> Read(string exampleData)
    {
        return exampleData.Split(Environment.NewLine)
            .Select(x => new ScratchCard(x));
    }
}