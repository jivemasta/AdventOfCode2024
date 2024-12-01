using AdventOfCode2024.DayOne;

namespace AdventOfCode2024Tests
{
    [TestClass]
    public sealed class DayOneTests
    {
        [TestMethod]
        public void DayOnePartOneSample()
        {
            (List<int> leftList, List<int> rightList) = DayOne.LoadLists(@"DayOne\DayOneSampleInput.txt");
            Assert.AreEqual(11, DayOne.CalculateDistance(leftList, rightList));
        }

        [TestMethod]
        public void DayOnePartOneTest()
        {
            (List<int> leftList, List<int> rightList) = DayOne.LoadLists(@"DayOne\DayOneInput.txt");
            Assert.AreEqual(765748, DayOne.CalculateDistance(leftList, rightList));
        }

        [TestMethod]
        public void DayOnePartTwoSample()
        {
            (List<int> leftList, List<int> rightList) = DayOne.LoadLists(@"DayOne\DayOneSampleInput.txt");
            Assert.AreEqual(31, DayOne.CalculateSimilarityScore(leftList, rightList));
        }

        [TestMethod]
        public void DayOnePartTwoTest()
        {
            (List<int> leftList, List<int> rightList) = DayOne.LoadLists(@"DayOne\DayOneInput.txt");
            Assert.AreEqual(27732508, DayOne.CalculateSimilarityScore(leftList, rightList));
        }
    }
}
