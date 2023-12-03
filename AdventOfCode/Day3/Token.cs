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
}

public class SymbolToken : Token
{
    public string Value { get; set; }
}
