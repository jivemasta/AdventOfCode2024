using AdventOfCode2024.Extensions;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.DayOne
{
    public partial class DayOne
    {
        private static int DistanceFunction(int left, int right) => Math.Abs(left - right);

        public static int PartOne()
        {
            (List<int> leftList, List<int> rightList) = LoadLists(@"DayOne\DayOneInput.txt");
            return CalculateDistance(leftList, rightList);
        }

        internal static int PartTwo()
        {
            (List<int> leftList, List<int> rightList) = LoadLists(@"DayOne\DayOneInput.txt");
            return CalculateSimilarityScore(leftList, rightList);
        }

        public static int CalculateDistance(List<int> leftList, List<int> rightList)
        {
            // Zip the two lists together using the distance function.
            return leftList.Order().Zip(rightList.Order(), DistanceFunction).Sum();
        }

        public static (List<int> LeftList, List<int> RightList) LoadLists(string fileName)
        {
            List<int> leftList = [];
            List<int> rightList = [];

            foreach (string line in File.ReadLines(fileName))
            {
                leftList.Add(Convert.ToInt32(InputListsSplit().Match(line).Groups["left"].Value));
                rightList.Add(Convert.ToInt32(InputListsSplit().Match(line).Groups["right"].Value));
            }

            return (leftList, rightList);
        }

        public static int CalculateSimilarityScore(List<int> leftList, List<int> rightList)
        {
            int result = 0;

            // Get the count for each distinct value in both lists
            Dictionary<int, int> leftListCounts = leftList.GetInstanceCount();
            Dictionary<int, int> rightListCounts = rightList.GetInstanceCount();

            // Since we know how many times the value appears in the left and right list, we just have to
            // multiply the the count in both lists together, then multiply by the key value
            foreach (int key in leftListCounts.Keys)
            {
                if (rightListCounts.TryGetValue(key, out int rightlistCount))
                {
                    result += rightlistCount * leftListCounts[key] * key;
                }
            }

            return result;
        }

        [GeneratedRegex(@"(?<left>\d+)\s+(?<right>\d+)")]
        private static partial Regex InputListsSplit();
    }
}
