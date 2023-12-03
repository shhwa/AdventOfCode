
namespace AdventOfCode;

public interface IGameValidator
{
    bool Validate(Game game, Bag bag);
}

public class GameValidator : IGameValidator
{
    public bool Validate(Game game, Bag bag)
    {
        return !game.Draws.Any(draw => draw.NoRed > bag.NoRed 
                                    || draw.NoGreen > bag.NoGreen 
                                    || draw.NoBlue > bag.NoBlue);
    }
}
