using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Definition
{
    /// <summary>
    /// Iframe interface for Score Thorws value, Get score, Get Extra throw value
    /// </summary>
    public interface IFrame
    {
        #region Fields 
        /// <summary>
        /// Stores each throw values
        /// </summary>
         int[] Scores { get; set; }

        /// <summary>
        /// Indiciates Strike in Frame
        /// </summary>
         bool IsStrike { get; set; }

        /// <summary>
        /// Indiciates Spare in Frame
        /// </summary>
         bool IsSpare { get; set; }

        /// <summary>
        /// Indictes Last frame from the list 
        /// </summary>
         bool IsLastFrame { get; set; }

        /// <summary>
        /// Indictes Frame is Complete
        /// </summary>
         bool IsFrameComplete { get; set; }

        /// <summary>
        ///  Returns Score of throws for a Frame
        /// </summary>
         int FrameScore { get; set; }
        #endregion

        #region Declarations

        /// <summary>
        /// Get Total scores of a Frame with Bonus score
        /// </summary>
        /// <param name="bouns">Bonus of next frame</param>
        /// <returns>Returns Score</returns>
         int GetScore(int bouns = 0);

        /// <summary>
        /// Returns First attempt score
        /// </summary>
        /// <returns>First attempt score</returns>
         int GetFirstScore();

        /// <summary>
        /// Returns Second attemps Score
        /// </summary>
        /// <returns>Score</returns>
         int GetSecondScore();

        /// <summary>
        /// Returns value of Extra Throw in case of last frame.
        /// </summary>
        /// <returns>Score</returns>
         int GetExtraThrowValue();
        #endregion
    }
}
