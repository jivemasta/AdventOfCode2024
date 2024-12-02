using System.Text.RegularExpressions;
using AdventOfCode2024.Extensions;

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
            .Select(r => SafetyCheck(r.ToList()))
            .Where(c => c == true).Count();
    }

    public static string PartTwo()
    {
        throw new NotImplementedException();
    }

    public static bool SafetyCheck(List<int> numberList)
    {
        Direction direction = GetDirection(numberList[0], numberList[1]);
        foreach ((int Index, int Value) i in numberList.Enumerate())
        {
            // break out on last value of list
            if (i.Index + 1 == numberList.Count)
                break;

            if (GetDirection(i.Value, numberList[i.Index + 1]) != direction)
                return false;

            if (Math.Abs(i.Value - numberList[i.Index + 1]) > 3)
                return false;
        }
        return true;
    }

    public static bool SafetyCheckDamper(List<int> numberList)
    {
        throw new NotImplementedException();
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
