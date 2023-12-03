namespace AdventOfCode;

public class DataNewLineSplitter : IDataSplitter
{
    public IEnumerable<string> Split(string input)
    {
        return input.Split('\n');
    }
}
