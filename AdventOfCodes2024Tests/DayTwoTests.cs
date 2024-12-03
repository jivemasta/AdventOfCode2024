namespace AdventOfCode2024Tests
{
    [TestClass]
    public sealed class DayTwoTests
    {
        [TestMethod]
        public void PartOneSample()
        {
            IEnumerable<IEnumerable<int>> readings = DayTwo.LoadReadings(@"DayTwo\DayTwoSampleInput.txt");
            int results = readings.Select(r => DayTwo.EvaluateReadings(r.ToList())).Where(c => c == true).Count();
            Assert.AreEqual(2, results);
        }

        [TestMethod]
        public void SafetyCheckSafe()
        {
            Assert.IsTrue(DayTwo.EvaluateReadings([7, 6, 4, 2, 1]));
            Assert.IsTrue(DayTwo.EvaluateReadings([1, 3, 6, 7, 9]));
        }

        [TestMethod]
        public void SafetyCheckUnsafe()
        {
            Assert.IsFalse(DayTwo.EvaluateReadings([1, 2, 7, 8, 9]));
            Assert.IsFalse(DayTwo.EvaluateReadings([9, 7, 6, 2, 1]));
            Assert.IsFalse(DayTwo.EvaluateReadings([1, 3, 2, 4, 5]));
            Assert.IsFalse(DayTwo.EvaluateReadings([8, 6, 4, 4, 1]));
        }

        [TestMethod]
        public void PartOneTest()
        {
            DayTwo.PartOne();
        }
    }
}
