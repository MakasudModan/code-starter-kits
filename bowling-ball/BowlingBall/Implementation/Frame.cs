using BowlingBall.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Implementation
{
  /// <summary>
  /// Frame Class to store each throw values and calculate individual score 
  /// </summary>
    public class Frame : IFrame
    {

        #region Private Fields 
        private int[] scores;
        private bool Isstrike = false;
        private bool Isspare = false;
        private bool IslastFrame = false;
        private int frameScore;
        #endregion

        #region Public Fields 
        public int[] Scores
        {
            get { return scores; }
            set { scores = value; }
        }

        public int FrameScore
        {
            get { return frameScore; }
            set { frameScore = value; }
        }
        public bool IsStrike
        {
            get { return Isstrike; }
            set { Isstrike = value; }
        }
        public bool IsSpare
        {
            get { return Isspare; }
            set { Isspare = value; }
        }
        public bool IsLastFrame
        {
            get { return IslastFrame; }
            set { IslastFrame = value; }
        }

        #endregion

        #region Public Methods
        public int GetFirstScore()
        {
            return Scores[0];
        }

        public int GetScore(int bonus = 0)
        {
            return this.GetFirstScore() + this.GetSecondScore() + bonus ;
        }

        public int GetSecondScore()
        {
            return Scores[1];
        }

        public int GetExtraThrowValue()
        {
            if (Scores.Length > 2)
                return Scores[2];
            else
                return 0;
        }

        #endregion
    }
}
