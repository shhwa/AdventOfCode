namespace AdventOfCode;

public class NumberWordParser
{
    public int Parse(string input)
    {
        if (int.TryParse(input, out var result))
        {
            return result;
        }

        switch (input)
        {
            case "one": return 1;
            case "two": return 2;
            case "three": return 3;
            case "four": return 4;
            case "five": return 5;
            case "six": return 6;
            case "seven": return 7;
            case "eight": return 8;
            case "nine": return 9;
            default: return 0;
        }
    }
}
