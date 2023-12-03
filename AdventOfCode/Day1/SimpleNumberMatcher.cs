using System.Text.RegularExpressions;

namespace AdventOfCode;

public class SimpleNumberMatcher : INumberMatcher
{
    public int Match(string input)
    {
        MatchCollection values = Regex.Matches(input, @"\d");
        return int.Parse(
            string.Join("", values[0], values[values.Count()-1])
        );
    }
}
