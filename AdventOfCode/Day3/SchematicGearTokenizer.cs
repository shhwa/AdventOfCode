using System.Text.RegularExpressions;

namespace AdventOfCode;

public class SchematicGearTokenizer : SchematicTokenizer
{
    protected override string MatchPattern()
    {
        return @"\*";
    }

    protected override Token CreateToken(int lineCounter, Match match)
    {
        return new GearToken
        {
            X = match.Index,
            Y = lineCounter,
            Length = match.Value.Length
        };
    }
}
