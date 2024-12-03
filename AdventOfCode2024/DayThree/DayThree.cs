using AdventOfCode2024.Extensions;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;
public static partial class DayThree
{
    public static int PartOne()
    {
        return ParseMemorySimple(LoadMemory(@"DayThree\DayThreeInput.txt"));
    }

    public static object PartTwo()
    {
        return ParseMemoryConditional(LoadMemory(@"DayThree\DayThreeInput.txt"));
    }

    public static string LoadMemory(string fileName)
    {
        return string
            .Join("", File.ReadAllLines(fileName));
    }

    public static int ParseMemorySimple(string testString)
    {
        return mulRegex().Matches(testString)
                         .Select(m => m.Groups[1].Value.ToInt() * m.Groups[2].Value.ToInt())
                         .Sum();
    }

    public static int ParseMemoryConditional(string testString)
    {
        int total = 0;
        bool enable = true;
        IEnumerable<string> instructions = conditionalRegex().Matches(testString)
                                                             .Select(m => m.Value);

        foreach (string instruction in instructions)
        {
            switch (instruction)
            {
                case "do()":
                    enable = true;
                    break;
                case "don't()":
                    enable = false;
                    break;
                default:
                    if (enable)
                        total += mulRegex().Match(instruction).Groups[1].Value.ToInt() * mulRegex().Match(instruction).Groups[2].Value.ToInt();
                    break;
            }
        }

        return total;
    }

    [GeneratedRegex(@"mul\((\d{1,3}),(\d{1,3})\)")]
    private static partial Regex mulRegex();

    [GeneratedRegex(@"(?:mul\((\d{1,3}),(\d{1,3})\))|(?:do\(\))|(?:don't\(\))")]
    private static partial Regex conditionalRegex();
}

