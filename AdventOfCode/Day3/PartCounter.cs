namespace AdventOfCode;

public class PartCounter
{
    private readonly ISchematicTokenizer schematicTokenizer;
    private readonly ITokenCombiner tokenCombiner;

    public PartCounter(ISchematicTokenizer schematicTokenizer, ITokenCombiner tokenCombiner)
    {
        this.schematicTokenizer = schematicTokenizer;
        this.tokenCombiner = tokenCombiner;
    }

    public int Count(string schematic)
    {
        var tokens = schematicTokenizer.Tokenize(schematic);
        var result = tokenCombiner.Combine(tokens);

        return result;
    }
}
