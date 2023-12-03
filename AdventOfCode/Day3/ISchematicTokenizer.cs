using System.Text.RegularExpressions;

namespace AdventOfCode;

public interface ISchematicTokenizer
{
    IEnumerable<Token> Tokenize(string schematic);
}

public class SchematicTokenizer : ISchematicTokenizer
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

    private static List<Token> FindNumberTokens(int lineCounter, string line)
    {
        var newTokens = new List<Token>();

        var matches = Regex.Matches(line, @"\d+");

        foreach (Match match in matches)
        {
            newTokens.Add(new NumberToken
            {
                Value = int.Parse(match.Value),
                X = match.Index,
                Y = lineCounter,
                Length = match.Value.Length
            });
        }

        return newTokens;
    }
}