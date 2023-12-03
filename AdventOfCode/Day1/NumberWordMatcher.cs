using System.Text.RegularExpressions;

namespace AdventOfCode;

public class NumberWordMatcher : INumberMatcher
{
    private readonly NumberWordParser numberWordParser;

    public NumberWordMatcher(NumberWordParser numberWordParser)
    {
        this.numberWordParser = numberWordParser;
    }

    public int Match(string input)
    {
        Match firstMatch = Regex.Match(input, @"(\d|one|two|three|four|five|six|seven|eight|nine)");
        Match lastMatch = Regex.Match(input, @".*(\d|one|two|three|four|five|six|seven|eight|nine)");
        return int.Parse(
            string.Join("", numberWordParser.Parse(firstMatch.Value), numberWordParser.Parse(lastMatch.Groups[1].Value))
        );
    }
}
