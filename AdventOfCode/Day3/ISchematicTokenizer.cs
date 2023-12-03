namespace AdventOfCode;

public interface ISchematicTokenizer
{
    IEnumerable<Token> Tokenize(string schematic);
}