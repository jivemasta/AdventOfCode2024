namespace AdventOfCode2024Tests
{
    [TestClass]
    public sealed class DayThreeTests
    {
        [TestMethod]
        public void PartOneSample()
        {
            string testString = DayThree.LoadMemory(@"DayThree\DayThreeSample.txt");
            Assert.AreEqual(161, DayThree.ParseMemorySimple(testString));
        }

        [TestMethod]
        public void PartOneTest()
        {
            Assert.AreEqual(170778545, DayThree.ParseMemorySimple(DayThree.LoadMemory(@"DayThree\DayThreeInput.txt")));
        }

        [TestMethod]
        public void PartTwoSample()
        {
            string testString = @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
            Assert.AreEqual(48, DayThree.ParseMemoryConditional(testString));
        }
    }
}
