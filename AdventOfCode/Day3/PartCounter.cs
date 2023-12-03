namespace AdventOfCode;

public class PartCounter
{
    private readonly IEnumerable<ISchematicTokenizer> schematicTokenizers;
    private readonly ITokenCombiner tokenCombiner;

    public PartCounter(IEnumerable<ISchematicTokenizer> schematicTokenizers, ITokenCombiner tokenCombiner)
    {
        this.schematicTokenizers = schematicTokenizers;
        this.tokenCombiner = tokenCombiner;
    }

    public int Count(string schematic)
    {
        var tokens = schematicTokenizers.SelectMany(tokenizer => tokenizer.Tokenize(schematic));
        var result = tokenCombiner.Combine(tokens);

        return result;
    }
}
