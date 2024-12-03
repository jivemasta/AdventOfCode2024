using AdventOfCode2024.Extensions;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public partial class DayTwo
{
    public enum Direction
    {
        Up,
        Down,
        None
    }

    public static int PartOne()
    {
        return LoadReadings(@"DayTwo\DayTwoInput.txt")
            .Select(r => EvaluateReadings(r.ToList()))
            .Where(c => c == true).Count();
    }

    public static string PartTwo()
    {
        throw new NotImplementedException();
    }

    public static bool EvaluateReadings(List<int> numberList)
    {
        List<bool> safetyChecks = [];
        Direction direction = GetDirection(numberList[0], numberList[1]);
        foreach ((int Index, int Value) i in numberList.Enumerate())
        {
            // break out on last value of list
            if (i.Index + 1 == numberList.Count)
                break;
            safetyChecks.Add(SafetyCheck(direction, i.Value, numberList[i.Index + 1]));
        }
        return safetyChecks.All(c => c == true);
    }

    public static bool EvaluateReadingsDamper(List<int> numberList)
    {
        List<bool> safetyChecks = [];
        Direction direction = GetDirection(numberList[0], numberList[1]);
        foreach ((int Index, int Value) i in numberList.Enumerate())
        {
            // break out on last value of list
            if (i.Index + 1 == numberList.Count)
                break;
            bool check = SafetyCheck(direction, i.Value, numberList[i.Index + 1]);
            if (check == false)
            {
                if (i.Index + 2 > numberList.Count + 1) continue;
                if (SafetyCheck(direction, i.Value, numberList[i.Index + 2]) != true)
                {
                    safetyChecks.Add(false);
                    continue;
                }
            }
            safetyChecks.Add(SafetyCheck(direction, i.Value, numberList[i.Index + 1]));
        }
        return safetyChecks.All(c => c == true);
    }

    private static bool SafetyCheck(Direction direction, int first, int second)
    {
        if (GetDirection(first, second) != direction) return false;
        if (Math.Abs(first - second) > 3) return false;
        return true;
    }

    private static Direction GetDirection(int numberOne, int numberTwo)
    {
        return (numberOne - numberTwo) switch
        {
            0 => Direction.None,
            < 0 => Direction.Up,
            > 0 => Direction.Down
        };
    }

    public static IEnumerable<IEnumerable<int>> LoadReadings(string filename)
    {
        return File
            .ReadLines(filename)
            .Select(line => readingRegex()
                            .Matches(line)
                            .Select(m => Convert.ToInt32(m.Value))
                            );
    }

    [GeneratedRegex(@"(\d+)")]
    private static partial Regex readingRegex();
}
