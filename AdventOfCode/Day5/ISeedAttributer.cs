namespace AdventOfCode.Day5
{
    public interface ISeedAttributer
    {
        ISeedAttributePolicy CreatePolicy(string attributes);
    }
}