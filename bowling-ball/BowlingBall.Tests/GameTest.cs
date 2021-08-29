using BowlingBall.Definition;
using BowlingBall.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Test
{

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestGameClass()
        {
            IGame firstplay = new Game(5, 10, 2);
            Assert.IsInstanceOfType(firstplay, typeof(Game));
        }

        [TestMethod]
        public void TestFrameClass()
        {
            IFrame frame = new Frame();
            Assert.IsInstanceOfType(frame, typeof(Frame));
        }
        [TestMethod]
        
        public void TestAllThrowWithAllValue10()
        {
            Game PlayWith10 = new Game(10, 10, 2);
            PlayWith10.Play(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            PlayWith10.CalculateScore();

            Assert.AreEqual(300, PlayWith10.FinalScore);
        }

        [TestMethod]
        public void TestWithSpareAndStrikeAtEnd()
        {
            Game SpareandStrike = new Game(10, 10, 2);
            SpareandStrike.Play(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });

            SpareandStrike.CalculateScore();

            Assert.AreEqual(143, SpareandStrike.FinalScore);
        }

        [TestMethod]
        public void Test3StrikeAtEnd()
        {
            Game SpareandStrike = new Game(10, 10, 2);
            SpareandStrike.Play(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });

            SpareandStrike.CalculateScore();

            Assert.AreEqual(163, SpareandStrike.FinalScore);
        }

        [TestMethod]
        public void TestWithoutExtraThrow()
        {
            Game WithoutExtraThrow = new Game(10, 10, 2);
            WithoutExtraThrow.Play(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });

            WithoutExtraThrow.CalculateScore();

            Assert.AreEqual(131, WithoutExtraThrow.FinalScore);
        }

        [TestMethod]
        public void TestAllThrowWithAllValue1()
        {
            Game PlayWith1 = new Game(10, 10, 2);
            PlayWith1.Play(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            PlayWith1.CalculateScore();

            Assert.AreEqual(20, PlayWith1.FinalScore);
        }

        [TestMethod]
        public void TestAllThrowWithAllValue0()
        {
            Game PlayWith0 = new Game(10, 10, 2);
            PlayWith0.Play(new int[] { 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            PlayWith0.CalculateScore();

            Assert.AreEqual(0, PlayWith0.FinalScore);
        }

        [TestMethod]
        public void TestAllThrowWithAllValue2()
        {
            Game PlayWith2 = new Game(10, 10, 2);
            PlayWith2.Play(new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,2 });
            PlayWith2.CalculateScore();

            Assert.AreEqual(40, PlayWith2.FinalScore);
        }

        [TestMethod]
        public void TestAllThrowWithAllValue3()
        {
            Game PlayWith3 = new Game(10, 10, 2);
            PlayWith3.Play(new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
            PlayWith3.CalculateScore();

            Assert.AreEqual(60, PlayWith3.FinalScore);
        }

        [TestMethod]
        public void TestAllThrowWithAllValue4()
        {
            Game PlayWith4 = new Game(10, 10, 2);
            PlayWith4.Play(new int[] { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 });
            PlayWith4.CalculateScore();

            Assert.AreEqual(80, PlayWith4.FinalScore);
        }

        [TestMethod]
        public void TestAllThrowWithAllValue5WithExtraThrow()
        {
            Game PlayWith5 = new Game(10, 10, 2);
            PlayWith5.Play(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,5 });
            PlayWith5.CalculateScore();

            Assert.AreEqual(150, PlayWith5.FinalScore);
        }

        [TestMethod]
        public void TestAllThrowWithAllValue6and4WithoutExtraThrow()
        {
            Game PlayWith6 = new Game(10, 10, 2);
            PlayWith6.Play(new int[] { 6, 4, 6, 4, 6,4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4 });
            PlayWith6.CalculateScore();

            Assert.AreEqual(154, PlayWith6.FinalScore);
        }


        [TestMethod]
        public void TestWith5Frame()
        {
            Game PlayWith6 = new Game(5, 10, 2);
            PlayWith6.Play(new int[] { 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6 });
            PlayWith6.CalculateScore();

            Assert.AreEqual(80, PlayWith6.FinalScore);
        }








    }
}