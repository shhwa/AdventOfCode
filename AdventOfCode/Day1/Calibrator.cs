namespace AdventOfCode;

public class Calibrator
{
    private readonly IDataSplitter dataSplitter;
    private readonly INumberMatcher numberMatcher;
    private readonly IMatchCombiner matchCombiner;

    public Calibrator(IDataSplitter dataSplitter, INumberMatcher numberMatcher, IMatchCombiner matchCombiner)
    {
        this.dataSplitter = dataSplitter;
        this.numberMatcher = numberMatcher;
        this.matchCombiner = matchCombiner;
    }
    public int Calibrate(string data)
    {
        return matchCombiner.Combine(
            dataSplitter
                .Split(data)
                .Select(x => numberMatcher.Match(x))
        );
    }
}
