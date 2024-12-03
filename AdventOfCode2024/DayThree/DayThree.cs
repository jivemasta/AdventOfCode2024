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
        return String.Join("", File.ReadAllLines(fileName));
    }

    public static int ParseMemorySimple(string testString)
    {
        return mulRegex().Matches(testString).Select(m => Convert.ToInt32(m.Groups[1].Value) * Convert.ToInt32(m.Groups[2].Value)).Sum();
    }

    public static int ParseMemoryConditional(string testString)
    {
        int total = 0;
        bool enable = true;
        foreach (string? instruction in conditionalRegex().Matches(testString).Select(m => m.Value))
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
                        total += Convert.ToInt32(mulRegex().Match(instruction).Groups[1].Value) * Convert.ToInt32(mulRegex().Match(instruction).Groups[2].Value);
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

