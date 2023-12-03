
namespace AdventOfCode;

public class GameEvaluator
{
    private readonly IGameInterpreter gameInterpreter;
    private readonly IGameValidator gameValidator;
    private readonly IGameCombiner gameCombiner;
    public GameEvaluator(IGameInterpreter gameInterpreter, IGameValidator gameValidator, IGameCombiner gameCombiner)
    {
        this.gameInterpreter = gameInterpreter;
        this.gameValidator = gameValidator;
        this.gameCombiner = gameCombiner;
    }

    public int Evaluate(string exampleData, Bag bag)
    {
        var games = gameInterpreter.ReadGames(exampleData);
        var validGames = games.Select(g => gameValidator.Validate(g, bag));
        var result = gameCombiner.CombineGames(validGames);

        return result;
    }
}
