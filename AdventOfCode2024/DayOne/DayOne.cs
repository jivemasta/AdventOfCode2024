namespace AdventOfCode2024.DayOne
{
    public class DayOne
    {
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
            leftList.Sort();
            rightList.Sort();

            int i = 0;
            int result = 0;
            foreach (int item in leftList)
            {
                result += Math.Abs(item - rightList[i]);
                i++;
            }

            return result;
        }

        public static (List<int>, List<int>) LoadLists(string fileName)
        {
            List<int> leftList = [];
            List<int> rightList = [];

            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                IEnumerable<int> values = line.Split("   ").Select(v => Convert.ToInt32(v));
                leftList.Add(values.First());
                rightList.Add(values.Last());
            }

            return (leftList, rightList);
        }

        public static int CalculateSimilarityScore(List<int> leftList, List<int> rightList)
        {
            int result = 0;

            foreach (int item in leftList)
            {
                int count = rightList.Where(v => v == item).Count();
                result += item * count;
            }

            return result;
        }
    }
}
