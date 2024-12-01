using AdventOfCode2024.DayOne;

namespace AdventOfCode2024Tests
{
    [TestClass]
    public sealed class DayOneTests
    {
        [TestMethod]
        public void DayOneSample()
        {
            (List<int> leftList, List<int> rightList) = DayOne.LoadLists(@"DayOne\DayOneSampleInput.txt");
            Assert.AreEqual(11, DayOne.CalculateDistance(leftList, rightList));
        }

        [TestMethod]
        public void DayOnePartOneTest()
        {
            (List<int> leftList, List<int> rightList) = DayOne.LoadLists(@"DayOne\DayOnePartOneInput.txt");
            Assert.AreEqual(765748, DayOne.CalculateDistance(leftList, rightList));
        }

        [TestMethod]
        public void DayOnePartTwoTest()
        {
            Assert.Fail();
        }
    }
}
