
namespace AdventOfCode;

public interface IGameInterpreter
{
    IEnumerable<Game> ReadGames(string data);
}

public class GameInterpreter : IGameInterpreter
{
    public IEnumerable<Game> ReadGames(string data)
    {
        return data
            .Split(Environment.NewLine)
            .Select(gameLine => new Game(gameLine));
    }
}