using System.Text.RegularExpressions;

namespace AdventOfCode;

public class ScratchCard
{
    public ScratchCard() { }

    public ScratchCard(string cardString)
    {
        var parts = cardString.Replace("Card", "")
            .Split(":");

        var numberParts = parts[1].Split("|");
        var winningNumberString = numberParts[0];
        var playedNumbersString = numberParts[1];

        var winningNumbersMatch = Regex.Matches(winningNumberString, @"\d+");
        var playedNumbersMatch = Regex.Matches(playedNumbersString, @"\d+");
        WinningNumbers = winningNumbersMatch.Select(x => int.Parse(x.Value));
        PlayedNumbers = playedNumbersMatch.Select(x => int.Parse(x.Value));
    }

    public IEnumerable<int> WinningNumbers { get; set; }

    public IEnumerable<int> PlayedNumbers { get; set; }

    public int Score => CountWinningNumbers() == 0 ? 0 : (int)Math.Pow(2, CountWinningNumbers() - 1);

    public int NumberOfWinningNumbers => CountWinningNumbers();

    public int Copies { get; set; } = 1;

    private int CountWinningNumbers()
    {
        return PlayedNumbers.Where(x => WinningNumbers.Contains(x)).Count();
    }
}