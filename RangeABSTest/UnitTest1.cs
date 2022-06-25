namespace RangeABSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void endPointsTest1()
        {
            Range r1 = new Range("[2,6)");
            string result = r1.endPoints();
            Assert.AreEqual("[2,6) endPoints = {2,5}", result);
        }
        [TestMethod]
        public void endPointsTest2()
        {
            Range r1 = new Range("[2,6]");
            string result = r1.endPoints();
            Assert.AreEqual("[2,6] endPoints = {2,6}", result);
        }
        [TestMethod]
        public void endPointsTest3()
        {
            Range r1 = new Range("(2,6)");
            string result = r1.endPoints();
            Assert.AreEqual("(2,6) endPoints = {3,5}", result);
        }
        [TestMethod]
        public void endPointsTest4()
        {
            Range r1 = new Range("(2,6]");
            string result = r1.endPoints();
            Assert.AreEqual("(2,6] endPoints = {3,6}", result);
        }
        [TestMethod]
        public void getAllPointsTest1()
        {
            Range r1 = new Range("[2,6)");
            string result = r1.GetAllPoints();
            Assert.AreEqual("[2,6) allPoints = {2,3,4,5}", result);
        }
        [TestMethod]
        public void integerRangeContainTest1()
        {
            List<int> IntegerRange = new List<int>();
            IntegerRange.Add(2);
            IntegerRange.Add(4);
            Range r1 = new Range("[2,6)");
            string result = r1.IntegerRangeContain(IntegerRange);
            Assert.AreEqual("[2,6) contains {2,4}", result);
        }
        [TestMethod]
        public void integerRangeContainTest2()
        {
            List<int> IntegerRange = new List<int>();
            IntegerRange.Add(-1);
            IntegerRange.Add(1);
            IntegerRange.Add(6);
            IntegerRange.Add(10);
            Range r1 = new Range("[2,6)");
            string result = r1.IntegerRangeContain(IntegerRange);
            Assert.AreEqual("[2,6) doesn’t contain {-1,1,6,10}", result);
        }
        [TestMethod]
        public void containsRangeTest1()
        {
            List<int> IntegerRange = new List<int>();
            IntegerRange.Add(-1);
            IntegerRange.Add(1);
            IntegerRange.Add(6);
            IntegerRange.Add(10);
            Range r1 = new Range("[2,6)");
            string result = r1.IntegerRangeContain(IntegerRange);
            Assert.AreEqual("[2,6) doesn’t contain {-1,1,6,10}", result);
        }
    }
}