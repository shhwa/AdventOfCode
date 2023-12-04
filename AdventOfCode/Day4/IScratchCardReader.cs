namespace AdventOfCode;

public interface IScratchCardReader
{
    IEnumerable<ScratchCard> Read(string exampleData);
}
