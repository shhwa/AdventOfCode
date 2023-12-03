using System.Text.RegularExpressions;

namespace AdventOfCode;

public class SchematicSymbolTokenizer : SchematicTokenizer
{
    protected override Token CreateToken(int lineCounter, Match match)
    {
        return new SymbolToken
        {
            Value = match.Value,
            X = match.Index,
            Y = lineCounter,
            Length = match.Value.Length
        };
    }

    protected override string MatchPattern()
    {
        return @"[^\w\.\n]";
    }
}