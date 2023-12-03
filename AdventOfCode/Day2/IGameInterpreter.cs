
namespace AdventOfCode;

public interface IGameInterpreter
{
    IEnumerable<Game> ReadGames(string data);
}
