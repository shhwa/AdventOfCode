using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode;

public interface ITokenCombiner
{
    int Combine(IEnumerable<Token> tokens);
}

public class TokenCombiner : ITokenCombiner
{
    public int Combine(IEnumerable<Token> tokens)
    {
        var numbers = tokens.OfType<NumberToken>();
        var symbols = tokens.OfType<SymbolToken>();

        return numbers
            .Where(number => number.IsTouchingAnyOf(symbols))
            .Sum(n => n.Value);
    }
}
