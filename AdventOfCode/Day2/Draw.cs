

using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Draw
{
    public Draw() { }
    
    public Draw(string drawPart)
    {
        Match redMatch = Regex.Match(drawPart, @"(\d+) red");
        NoRed = redMatch.Success ? int.Parse(redMatch.Groups[1].Value) : 0;

        Match greenMatch = Regex.Match(drawPart, @"(\d+) green");
        NoGreen = greenMatch.Success ? int.Parse(greenMatch.Groups[1].Value) : 0;

        Match blueMatch = Regex.Match(drawPart, @"(\d+) blue");
        NoBlue = blueMatch.Success ? int.Parse(blueMatch.Groups[1].Value) : 0;
    }

    public int NoRed { get; set; }
    public int NoGreen { get; set; }
    public int NoBlue { get; set; }
}
