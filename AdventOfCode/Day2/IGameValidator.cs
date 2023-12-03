
namespace AdventOfCode;

public interface IGameValidator
{
    bool Validate(Game game, Bag bag);
}

public class GameValidator : IGameValidator
{
    public bool Validate(Game game, Bag bag)
    {
        return true;
    }
}
