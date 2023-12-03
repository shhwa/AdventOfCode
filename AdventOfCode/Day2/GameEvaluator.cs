
namespace AdventOfCode;

public class GameEvaluator
{
    private readonly IGameInterpreter gameInterpreter;
    private readonly IGameAnalyser gameAnalyser;
    private readonly IGameCombiner gameCombiner;
    public GameEvaluator(IGameInterpreter gameInterpreter, IGameAnalyser gameValidator, IGameCombiner gameCombiner)
    {
        this.gameInterpreter = gameInterpreter;
        this.gameAnalyser = gameValidator;
        this.gameCombiner = gameCombiner;
    }

    public int Evaluate(string exampleData, Bag bag)
    {
        var games = gameInterpreter.ReadGames(exampleData);
        var analysedGames = games.Select(g => gameAnalyser.Analyse(g, bag));
        var result = gameCombiner.CombineGames(analysedGames);

        return result;
    }
}
