
using System.Text.RegularExpressions;

namespace AdventOfCode.Day5
{
    public record Map(string AttributeToOutput, string AttributeToRead, IEnumerable<Range> ranges)
    {
        internal static Map Parse(string description)
        {
            var parts = description.Split(Environment.NewLine);

            var header = parts[0];

            var attributeToRead = Regex.Match(header, @"(\w+)-").Groups[1].Value;
            var AttributeToOutput = Regex.Match(header, @"-to-(\w+)").Groups[1].Value;

            var ranges = parts.Skip(1).Select(p => {
                var rangeParts = p.Split(" ").Select(x => int.Parse(x)).ToList();

                return new Range(rangeParts[1], rangeParts[0], rangeParts[2]);
            });

            return new Map(AttributeToOutput, attributeToRead, ranges);
        }
    }

    public record Range (int source, int destination, int length);
}