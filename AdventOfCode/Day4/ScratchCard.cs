using System.Text.RegularExpressions;

namespace AdventOfCode;

public class ScratchCard
{
    public ScratchCard(string x)
    {
        var parts = x.Replace("Card", "")
            .Split(":");

        var numberParts = parts[1].Split("|");
        var winningNumberString = numberParts[0];

        var numbers = Regex.Matches(winningNumberString, @"\d+");
        WinningNumbers = numbers.Select(x => int.Parse(x.Value));
    }

    public IEnumerable<int> WinningNumbers { get; set; }
}