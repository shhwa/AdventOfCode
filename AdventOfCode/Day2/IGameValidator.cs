
namespace AdventOfCode;

public interface IGameValidator
{
    ValidatedGame Validate(Game game, Bag bag);
}

public class GameValidator : IGameValidator
{
    public ValidatedGame Validate(Game game, Bag bag)
    {
        return new ValidatedGame
        {
            Draws = game.Draws,
            Id = game.Id,
            Valid = !game.Draws.Any(draw => draw.NoRed > bag.NoRed 
                                    || draw.NoGreen > bag.NoGreen 
                                    || draw.NoBlue > bag.NoBlue)
        };
    }
}
