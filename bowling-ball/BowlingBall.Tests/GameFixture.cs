using System;
using BowlingBall.Definition;
using BowlingBall.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            var game = new Game();
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }

        [TestMethod]
        public void TestGameClass()
        {
            IGame firstplay = new Game();
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
            Game PlayWith10 = new Game();
            int[] RollList = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

            for (int i = 0; i < 12; i++)
            {
                PlayWith10.Roll(RollList[i]);
            }
            //PlayWith10.Play(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            //PlayWith10.CalculateScore();

            Assert.AreEqual(300, PlayWith10.GetScore());
        }

        [TestMethod]
        public void TestWithSpareAndStrikeAtEnd()
        {
            Game SpareandStrike = new Game();
            int[] RollList = new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 };

            //SpareandStrike.CalculateScore();
            for (int i = 0; i < 19; i++)
            {
                SpareandStrike.Roll(RollList[i]);
            }

            Assert.AreEqual(143, SpareandStrike.GetScore());
        }

        [TestMethod]
        public void Test3StrikeAtEnd()
        {
            Game SpareandStrike = new Game();
            int[] RollList = new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 };

            for (int i = 0; i < 19; i++)
            {
                SpareandStrike.Roll(RollList[i]);
            }
            Assert.AreEqual(163, SpareandStrike.GetScore());
        }

        [TestMethod]
        public void TestWithoutExtraThrow()
        {
            Game WithoutExtraThrow = new Game();
            //WithoutExtraThrow.Play(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            int[] RollList = new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 };

            //WithoutExtraThrow.CalculateScore();

            for (int i = 0; i < 18; i++)
            {
                WithoutExtraThrow.Roll(RollList[i]);
            }

            Assert.AreEqual(131, WithoutExtraThrow.GetScore());
        }

        [TestMethod]
        public void TestAllThrowWithAllValue1()
        {
            Game PlayWith1 = new Game();
            // PlayWith1.Play(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });

            int[] RollList = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            for (int i = 0; i < 20; i++)
            {
                PlayWith1.Roll(RollList[i]);
            }

            //PlayWith1.CalculateScore();

            Assert.AreEqual(20, PlayWith1.GetScore());
        }

        [TestMethod]
        public void TestAllThrowWithAllValue0()
        {
            Game PlayWith0 = new Game();
            //PlayWith0.Play(new int[] { 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            int[] RollList = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < 19; i++)
            {
                PlayWith0.Roll(RollList[i]);
            }

            //PlayWith0.CalculateScore();

            Assert.AreEqual(0, PlayWith0.GetScore());
        }

        [TestMethod]
        public void TestAllThrowWithAllValue2()
        {
            Game PlayWith2 = new Game();
            //PlayWith2.Play(new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,2 });
            int[] RollList = new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };

            for (int i = 0; i < 20; i++)
            {
                PlayWith2.Roll(RollList[i]);
            }

            //   PlayWith2.CalculateScore();

            Assert.AreEqual(40, PlayWith2.GetScore());
        }

        [TestMethod]
        public void TestAllThrowWithAllValue3()
        {
            Game PlayWith3 = new Game();
            // PlayWith3.Play(new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });

            int[] RollList = new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };

            for (int i = 0; i < 20; i++)
            {
                PlayWith3.Roll(RollList[i]);
            }

            //PlayWith3.CalculateScore();

            Assert.AreEqual(60, PlayWith3.GetScore()); ;
        }

        [TestMethod]
        public void TestAllThrowWithAllValue4()
        {
            Game PlayWith4 = new Game();
            //  PlayWith4.Play(new int[] { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 });

            int[] RollList = new int[] { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            //PlayWith4.CalculateScore();

            for (int i = 0; i < 20; i++)
            {
                PlayWith4.Roll(RollList[i]);
            }

            Assert.AreEqual(80, PlayWith4.GetScore());
        }

        [TestMethod]
        public void TestAllThrowWithAllValue5WithExtraThrow()
        {
            Game PlayWith5 = new Game();
            //PlayWith5.Play(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,5 });
            //PlayWith5.CalculateScore();

            int[] RollList = new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };


            for (int i = 0; i < 20; i++)
            {
                PlayWith5.Roll(RollList[i]);
            }

            Assert.AreEqual(145, PlayWith5.GetScore());
        }

        [TestMethod]
        public void TestAllThrowWithAllValue6and4WithoutExtraThrow()
        {
            Game PlayWith6 = new Game();
            // PlayWith6.Play(new int[] { 6, 4, 6, 4, 6,4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4 });

            int[] RollList = new int[] { 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4 };
            for (int i = 0; i < 20; i++)
            {
                PlayWith6.Roll(RollList[i]);
            }

            // PlayWith6.CalculateScore();

            Assert.AreEqual(154, PlayWith6.GetScore());
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
