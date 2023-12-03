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

        PartCounter partCounter = new PartCounter(new [] { tokenizer }, tokenCombiner);

        var tokens = new List<Token>();

        A.CallTo(() => tokenizer.Tokenize(ExampleSchematic)).Returns(tokens);
        A.CallTo(() => tokenCombiner.Combine(tokens)).Returns(5);

        int result = partCounter.Count(ExampleSchematic);

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void NumberTokenizerGetsAllNumbersFromSchematic()
    {
        SchematicTokenizer schematicTokenizer = new SchematicNumberTokenizer();
        var result = schematicTokenizer.Tokenize("1.2345");

        Assert.That(result.First(), Is.TypeOf<NumberToken>());
        Assert.That(((NumberToken)result.First()).Value, Is.EqualTo(1));

        Assert.That(result.Last(), Is.TypeOf<NumberToken>());
        Assert.That(((NumberToken)result.Last()).Value, Is.EqualTo(2345));
    }

    [Test]
    public void NumberTokenizerGetsAllNumbersFromSchematicInMultipleLines()
    {
        SchematicTokenizer schematicTokenizer = new SchematicNumberTokenizer();
        var result = schematicTokenizer.Tokenize(
            "1.2345\n"
            + "2.3456"
        ).ToList();

        Assert.That(result[0], Is.TypeOf<NumberToken>());
        Assert.That(((NumberToken)result[0]).Value, Is.EqualTo(1));
        Assert.That(((NumberToken)result[1]).Value, Is.EqualTo(2345));
        Assert.That(((NumberToken)result[2]).Value, Is.EqualTo(2));
        Assert.That(((NumberToken)result[3]).Value, Is.EqualTo(3456));
    }

    [Test]
    public void SymbolTokenizerGetsAllSymbolsFromSchematic()
    {
        SchematicTokenizer schematicTokenizer = new SchematicSymbolTokenizer();
        var result = schematicTokenizer.Tokenize(
            "$.123£\n"
            + "$.123%*\n"
        ).ToList();

        Assert.That(result[0], Is.TypeOf<SymbolToken>());
        Assert.That(((SymbolToken)result[0]).Value, Is.EqualTo("$"));
        Assert.That(((SymbolToken)result[1]).Value, Is.EqualTo("£"));
        Assert.That(((SymbolToken)result[2]).Value, Is.EqualTo("$"));
        Assert.That(((SymbolToken)result[3]).Value, Is.EqualTo("%"));
        Assert.That(((SymbolToken)result[4]).Value, Is.EqualTo("*"));
    }

    [Test]
    public void TokenCombinerSumsNumberTokensAdjacentToSymbolTokensWhenThereIsOneNumberAndOneSymbol()
    {
        var tokenCombiner = new TokenCombiner();

        var result = tokenCombiner.Combine(new List<Token> {
            new TestNumberToken { Value = 12, Length = 2, X = 2, Y = 3, IsTouching = true },
            new TestNumberToken { Value = 9, Length = 2, X = 2, Y = 4, IsTouching = false },
        });

        Assert.That(result, Is.EqualTo(12));
    }

    [Test]
    public void NumberTokenEvaluatesWhetherItsTouchingAnySymbolWhenSymbolIsTopLeft()
    {
        NumberToken numberToken = new NumberToken
        {
            Length = 2,
            Value = 12,
            X = 5,
            Y = 6
        };

        SymbolToken symbolToken = new SymbolToken
        {
            Length = 1,
            Value = "%",
            X = 4,
            Y = 5
        };

        Assert.That(numberToken.IsTouchingAnyOf(new []{ symbolToken }), Is.EqualTo(true));
    }

    [Test]
    public void NumberTokenEvaluatesWhetherItsTouchingAnySymbolWhenSymbolIsTopRight()
    {
        NumberToken numberToken = new NumberToken
        {
            Length = 2,
            Value = 12,
            X = 5,
            Y = 6
        };

        SymbolToken symbolToken = new SymbolToken
        {
            Length = 1,
            Value = "%",
            X = 7,
            Y = 5
        };

        Assert.That(numberToken.IsTouchingAnyOf(new []{ symbolToken }), Is.EqualTo(true));
    }

        [Test]
    public void NumberTokenEvaluatesWhetherItsTouchingAnySymbolWhenSymbolIsBottomLeft()
    {
        NumberToken numberToken = new NumberToken
        {
            Length = 2,
            Value = 12,
            X = 5,
            Y = 6
        };

        SymbolToken symbolToken = new SymbolToken
        {
            Length = 1,
            Value = "%",
            X = 4,
            Y = 7
        };

        Assert.That(numberToken.IsTouchingAnyOf(new []{ symbolToken }), Is.EqualTo(true));
    }

    [Test]
    public void NumberTokenEvaluatesWhetherItsTouchingAnySymbolWhenSymbolIsBottomRight()
    {
        NumberToken numberToken = new NumberToken
        {
            Length = 2,
            Value = 12,
            X = 5,
            Y = 6
        };

        SymbolToken symbolToken = new SymbolToken
        {
            Length = 1,
            Value = "%",
            X = 7,
            Y = 7
        };

        Assert.That(numberToken.IsTouchingAnyOf(new []{ symbolToken }), Is.EqualTo(true));
    }

    private class TestNumberToken : NumberToken
    {
        public bool IsTouching { get; set;}

        public override bool IsTouchingAnyOf(IEnumerable<SymbolToken> symbols)
        {
            return IsTouching;
        }
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
