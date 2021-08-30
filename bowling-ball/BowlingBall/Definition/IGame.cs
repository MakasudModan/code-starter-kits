using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Definition
{
    /// <summary>
    ///  Iframe interface contains Numbers of Thorws, Frames,Assign Score to each frame, Calculate total Score
    /// </summary>
    public interface IGame
    {
        #region Fields
        /// <summary>
        /// List of Throws for a single game
        /// </summary>
        int[] Throws { get; set; }

        /// <summary>
        /// Number of Frames for a single game
        /// </summary>
         List<IFrame> Frames { get; set; }

        /// <summary>
        ///  Returns Final Score 
        /// </summary>
         int FinalScore { get; set; }

        /// <summary>
        /// Indicates Last Frame in a single game
        /// </summary>
         bool IsLastFrame { get; set; }
        #endregion

        #region Declarations 

        /// <summary>
        ///  Register all the throws into seperate frames
        /// </summary>
        /// <param name="throws">List of throw</param>
         void Play(int[] throws);

        /// <summary>
        /// Calculate Total Score of each frame
        /// </summary>
         void CalculateScore();
        #endregion
    }
}
