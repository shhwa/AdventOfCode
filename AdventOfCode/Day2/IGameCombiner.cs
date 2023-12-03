
namespace AdventOfCode;

public interface IGameCombiner
{
    int CombineGames(IEnumerable<AnalysedGame> games);
}

public class GameCombiner : IGameCombiner
{
    public int CombineGames(IEnumerable<AnalysedGame> games)
    {
        return games
            .Where(g => g.Valid)
            .Sum(g => g.Id);
    }
}

public class MinimumGameBagCombiner : IGameCombiner
{
    public int CombineGames(IEnumerable<AnalysedGame> games)
    {
        return games
            .Select(g => g as BagMinimisedGame)
            .Sum(g => g.MinRed * g.MinGreen * g.MinBlue);
    }
}
