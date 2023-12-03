
namespace AdventOfCode;

public interface IGameAnalyser
{
    AnalysedGame Analyse(Game game, Bag bag);
}

public class GameValidator : IGameAnalyser
{
    public AnalysedGame Analyse(Game game, Bag bag)
    {
        return new AnalysedGame
        {
            Draws = game.Draws,
            Id = game.Id,
            Valid = !game.Draws.Any(draw => draw.NoRed > bag.NoRed 
                                    || draw.NoGreen > bag.NoGreen 
                                    || draw.NoBlue > bag.NoBlue)
        };
    }
}

public class GameBagMinimiser : IGameAnalyser
{
    public AnalysedGame Analyse(Game game, Bag bag)
    {
        return new BagMinimisedGame {
            Id = game.Id,
            Draws = game.Draws,
            MinRed = game.Draws.Max(x => x.NoRed),
            MinGreen = game.Draws.Max(x => x.NoGreen),
            MinBlue = game.Draws.Max(x => x.NoBlue)
        };
    }
}