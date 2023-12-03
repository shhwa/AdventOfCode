
namespace AdventOfCode;

public interface IGameCombiner
{
    int CombineGames(IEnumerable<ValidatedGame> games);
}

public class GameCombiner : IGameCombiner
{
    public int CombineGames(IEnumerable<ValidatedGame> games)
    {
        return games
            .Where(g => g.Valid)
            .Sum(g => g.Id);
    }
}
