namespace RangeABSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void endPointsTest1()
        {
            RangeABST.Range r1 = new RangeABST.Range("[2,6)");
            string result = r1.endPoints();
            Assert.AreEqual("[2,6) endPoints = {2,5}", result);
        }
        [TestMethod]
        public void endPointsTest2()
        {
            RangeABST.Range r1 = new RangeABST.Range("[2,6]");
            string result = r1.endPoints();
            Assert.AreEqual("[2,6] endPoints = {2,6}", result);
        }
        [TestMethod]
        public void endPointsTest3()
        {
            RangeABST.Range r1 = new RangeABST.Range("(2,6)");
            string result = r1.endPoints();
            Assert.AreEqual("(2,6) endPoints = {3,5}", result);
        }
        [TestMethod]
        public void endPointsTest4()
        {
            RangeABST.Range r1 = new RangeABST.Range("(2,6]");
            string result = r1.endPoints();
            Assert.AreEqual("(2,6] endPoints = {3,6}", result);
        }
        [TestMethod]
        public void getAllPointsTest1()
        {
            RangeABST.Range r1 = new RangeABST.Range("[2,6)");
            string result = r1.GetAllPoints();
            Assert.AreEqual("[2,6) allPoints = {2,3,4,5}", result);
        }
        [TestMethod]
        public void integerRangeContainTest1()
        {
            List<int> IntegerRange = new List<int>();
            IntegerRange.Add(2);
            IntegerRange.Add(4);
            RangeABST.Range r1 = new RangeABST.Range("[2,6)");
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
            RangeABST.Range r1 = new RangeABST.Range("[2,6)");
            string result = r1.IntegerRangeContain(IntegerRange);
            Assert.AreEqual("[2,6) doesn't contain {-1,1,6,10}", result);
        }
        [TestMethod]
        public void containsRangeTest1()
        {

            RangeABST.Range r1 = new RangeABST.Range("[2,5)");
            string result = r1.ContainRange("[7,10)");
            Assert.AreEqual("[2,5) doesn't contain [7,10)", result);
        }
        [TestMethod]
        public void containsRangeTest2()
        {

            RangeABST.Range r1 = new RangeABST.Range("[2,5)");
            string result = r1.ContainRange("[3,10)");
            Assert.AreEqual("[2,5) doesn't contain [3,10)", result);
        }
        [TestMethod]
        public void containsRangeTest3()
        {

            RangeABST.Range r1 = new RangeABST.Range("[3,5)");
            string result = r1.ContainRange("[2,10)");
            Assert.AreEqual("[3,5) doesn't contain [2,10)", result);
        }
        [TestMethod]
        public void containsRangeTest4()
        {

            RangeABST.Range r1 = new RangeABST.Range("[2,10)");
            string result = r1.ContainRange("[3,5]");
            Assert.AreEqual("[2,10) contains [3,5]", result);
        }
        [TestMethod]
        public void containsRangeTest5()
        {

            RangeABST.Range r1 = new RangeABST.Range("[3,5]");
            string result = r1.ContainRange("[3,5)");
            Assert.AreEqual("[3,5] contains [3,5)", result);
        }
        [TestMethod]
        public void OverLapsTest1()
        {

            RangeABST.Range r1 = new RangeABST.Range("[2,5)");
            string result = r1.OverlapRange("[7,10");
            Assert.AreEqual("[2,5) doesn't overlap with [7,10)", result);
        }
        [TestMethod]
        public void OverLapsTest2()
        {

            RangeABST.Range r1 = new RangeABST.Range("[2,10)");
            string result = r1.OverlapRange("[3,5)");
            Assert.AreEqual("[2,10) overlaps with [3,5)", result);
        }
        [TestMethod]
        public void OverLapsTest3()
        {

            RangeABST.Range r1 = new RangeABST.Range("[3,5)");
            string result = r1.OverlapRange("[3,5)");
            Assert.AreEqual("[3,5) overlaps with [3,5)", result);
        }
        [TestMethod]
        public void OverLapsTest4()
        {

            RangeABST.Range r1 = new RangeABST.Range("[2,5)");
            string result = r1.OverlapRange("[3,10)");
            Assert.AreEqual("[2,5) overlaps with [3,10)", result);
        }
        [TestMethod]
        public void OverLapsTest5()
        {

            RangeABST.Range r1 = new RangeABST.Range("[3,5)");
            string result = r1.OverlapRange("[2,10)");
            Assert.AreEqual("[3,5) overlaps with [2,10)", result);
        }
        [TestMethod]
        public void EqualsTest1()
        {

            RangeABST.Range r1 = new RangeABST.Range("[3,5)");
            string result = r1.Equals("[3,5)");
            Assert.AreEqual("[3,5) equals [3,5)", result);
        }
        [TestMethod]
        public void EqualsTest2()
        {

            RangeABST.Range r1 = new RangeABST.Range("[2,10)");
            string result = r1.Equals("[3,5)");
            Assert.AreEqual("[2,10) neq [3,5)", result);
        }
        [TestMethod]
        public void EqualsTest3()
        {

            RangeABST.Range r1 = new RangeABST.Range("[2,5)");
            string result = r1.Equals("[3,10)");
            Assert.AreEqual("[2,5) neq [3,10)", result);
        }
        [TestMethod]
        public void EqualsTest4()
        {

            RangeABST.Range r1 = new RangeABST.Range("[3,5)");
            string result = r1.Equals("[2,10)");
            Assert.AreEqual("[3,5) neq [2,10)", result);
        }
    }
}