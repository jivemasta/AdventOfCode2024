namespace AdventOfCode2024Tests
{
    [TestClass]
    public sealed class DayTwoTests
    {
        [TestMethod]
        public void PartOneSample()
        {
            IEnumerable<IEnumerable<int>> readings = DayTwo.LoadReadings(@"DayTwo\DayTwoSampleInput.txt");
            int results = readings.Select(r => DayTwo.SafetyCheck(r.ToList())).Where(c => c == true).Count();
            Assert.AreEqual(2, results);
        }

        [TestMethod]
        public void SafetyCheckSafe()
        {
            Assert.IsTrue(DayTwo.SafetyCheck([7, 6, 4, 2, 1]));
            Assert.IsTrue(DayTwo.SafetyCheck([1, 3, 6, 7, 9]));
        }

        [TestMethod]
        public void SafetyCheckUnsafe()
        {
            Assert.IsFalse(DayTwo.SafetyCheck([1, 2, 7, 8, 9]));
            Assert.IsFalse(DayTwo.SafetyCheck([9, 7, 6, 2, 1]));
            Assert.IsFalse(DayTwo.SafetyCheck([1, 3, 2, 4, 5]));
            Assert.IsFalse(DayTwo.SafetyCheck([8, 6, 4, 4, 1]));
        }

        [TestMethod]
        public void PartOneTest()
        {
            DayTwo.PartOne();
        }

        [TestMethod]
        public void PartTwoSample()
        {
            IEnumerable<IEnumerable<int>> readings = DayTwo.LoadReadings(@"DayTwo\DayTwoSampleInput.txt");
            int results = readings.Select(r => DayTwo.SafetyCheckDamper(r.ToList())).Where(c => c == true).Count();
            Assert.AreEqual(4, results);
        }

        [TestMethod]
        public void DamperChecks()
        {
            Assert.IsTrue(DayTwo.SafetyCheckDamper([7, 6, 4, 2, 1]));
            Assert.IsFalse(DayTwo.SafetyCheckDamper([1, 2, 7, 8, 9]));
        }

        [TestMethod]
        public void PartTwoTest()
        {
            Assert.Fail();
        }
    }
}
