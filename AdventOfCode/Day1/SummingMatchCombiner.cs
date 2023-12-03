namespace AdventOfCode;

public class SummingMatchCombiner : IMatchCombiner
{
    public int Combine(IEnumerable<int> input)
    {
        return input.Sum(x => x);
    }
}
