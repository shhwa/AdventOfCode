using System.Collections.Frozen;
using FakeItEasy;

namespace AdventOfCode;

public class Day3
{
    [Test]
    public void PartCounterCountsParts()
    {
        ISchematicTokenizer tokenizer = A.Fake<ISchematicTokenizer>();
        ITokenCombiner tokenCombiner = A.Fake<ITokenCombiner>();

        PartCounter partCounter = new PartCounter(tokenizer, tokenCombiner);

        var tokens = new List<Token>();

        A.CallTo(() => tokenizer.Tokenize(ExampleSchematic)).Returns(tokens);
        A.CallTo(() => tokenCombiner.Combine(tokens)).Returns(5);

        int result = partCounter.Count(ExampleSchematic);

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void TokenizerGetsAllNumbersFromSchematic()
    {
        SchematicTokenizer schematicTokenizer = new SchematicTokenizer();
        var result = schematicTokenizer.Tokenize("1.2345");

        Assert.That(result.First(), Is.TypeOf<NumberToken>());
        Assert.That(((NumberToken)result.First()).Value, Is.EqualTo(1));

        Assert.That(result.Last(), Is.TypeOf<NumberToken>());
        Assert.That(((NumberToken)result.Last()).Value, Is.EqualTo(2345));
    }

    public string ExampleSchematic = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";
}
