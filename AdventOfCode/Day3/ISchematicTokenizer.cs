using System.Text.RegularExpressions;

namespace AdventOfCode;

public interface ISchematicTokenizer
{
    IEnumerable<Token> Tokenize(string schematic);
}

public abstract class SchematicTokenizer : ISchematicTokenizer
{
    public IEnumerable<Token> Tokenize(string schematic)
    {
        var lines = schematic.Split(Environment.NewLine);
        var lineCounter = 0;

        var tokens = new List<Token>();

        foreach(var line in lines)
        {
            tokens.AddRange(
                FindNumberTokens(lineCounter, line)
            );

            lineCounter++;
        }

        return tokens;
    }

    private List<Token> FindNumberTokens(int lineCounter, string line)
    {
        var newTokens = new List<Token>();

        var matches = Regex.Matches(line, MatchPattern());

        foreach (Match match in matches)
        {
            newTokens.Add(CreateToken(lineCounter, match));
        }

        return newTokens;
    }

    protected abstract string MatchPattern();

    protected abstract NumberToken CreateToken(int lineCounter, Match match);
}