namespace AdventOfCode;

public class Game
{
    public Game() { }

    public Game(string gameLine)
    {
        var parts = gameLine.Split(':');

        Id = int.Parse(parts[0].Replace("Game ", ""));
        Draws = parts[1].Split(';').Select(drawPart => new Draw(drawPart));
    }

    public IEnumerable<Draw> Draws { get; set; }

    public int Id { get; set; }
}
