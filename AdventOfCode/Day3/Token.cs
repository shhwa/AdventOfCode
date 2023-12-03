
namespace AdventOfCode;

public class Token
{
    public int X { get; set; }
    public int Length { get; set; }
    public int Y { get; set; }
}

public class NumberToken : Token
{
    public int Value { get; set; }

    public virtual bool IsTouchingAnyOf(IEnumerable<SymbolToken> symbols)
    {
        return symbols.Any(
            s => s.X >= X-1 
              && s.X <= X + Length
              && s.Y >= Y-1
              && s.Y <= Y+1
        );
    }
}

public class SymbolToken : Token
{
    public string Value { get; set; }
}
