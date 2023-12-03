
namespace AdventOfCode;

public interface IGameCombiner
{
    int CombineGames(IEnumerable<Game> games);
}

public class GameCombiner : IGameCombiner
{
    public int CombineGames(IEnumerable<Game> games)
    {
        return games.Sum(g => g.Id);
    }
}
