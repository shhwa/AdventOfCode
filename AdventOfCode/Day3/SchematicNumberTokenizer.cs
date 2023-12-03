using System.Text.RegularExpressions;

namespace AdventOfCode;

public class SchematicNumberTokenizer : SchematicTokenizer
{
    protected override string MatchPattern()
    {
        return @"\d+";
    }

    protected override NumberToken CreateToken(int lineCounter, Match match)
    {
        return new NumberToken
        {
            Value = int.Parse(match.Value),
            X = match.Index,
            Y = lineCounter,
            Length = match.Value.Length
        };
    }
}
