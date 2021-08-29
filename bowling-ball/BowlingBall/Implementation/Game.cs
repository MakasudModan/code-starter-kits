using BowlingBall.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Implementation
{
    public class Game : IGame
    {
        #region Private Fields
        private List<IFrame> frames { get; set; }

        /// <summary>
        ///  Indicates numbers of throws in a single game
        /// </summary>
        private int[] throws { get; set; }

        /// <summary>
        /// Indicates last frame
        /// </summary>
        private bool IslastFrame { get; set; }

        /// <summary>
        /// Final socre
        /// </summary>
        private int finalScore { get; set; }

        /// <summary>
        /// Indicate Last frame in total frame
        /// </summary>
        public bool IsLastFrame { get { return IslastFrame; } set { IslastFrame = value; } }
        #endregion

        #region Public Fields

        /// <summary>
        /// Maximum numbers of frames in a single game 
        /// </summary>
        public int MaxFrames { get; set; }

        /// <summary>
        ///  Maximum score per frame
        /// </summary>
        public int MaxScorePerFrame { get; set; }
        
        /// <summary>
        /// Attempts per frame
        /// </summary>
        public int MaxAttemptPerFrame { get; set; }
        /// <summary>
        /// Frames in a single game
        /// </summary>
      
        /// <summary>
        /// Number of Frames in Game 
        /// </summary>
        public List<IFrame> Frames
        {
            get { return frames; }
            set { frames = value; }
        }

        /// <summary>
        /// Final score after all thorws
        /// </summary>
        public int FinalScore { get { return finalScore; } set { finalScore = value; } }

        /// <summary>
        /// Total Numbers of Throws in a Game 
        /// </summary>
        public int[] Throws
        {
            get { return throws; }
            set { throws = value; }
        }

        #endregion

        #region Constructor
        /// <summary>
        ///  Game class with configurable value
        /// </summary>
        /// <param name="maxFrames">Maximum Frame to be play </param>
        /// <param name="maxScorePerFrame">Maximum score per Frame</param>
        /// <param name="maxAttemptPerFrame">Attempt per Frame</param>
        public Game(int maxFrames, int maxScorePerFrame, int maxAttemptPerFrame)
        {
            MaxFrames = maxFrames;
            MaxScorePerFrame = maxScorePerFrame;
            MaxAttemptPerFrame = maxAttemptPerFrame;
            frames = new List<IFrame>();
            IslastFrame = false;
        }
        #endregion

        #region Private Methods 
        /// <summary>
        ///  Check for Strike
        /// </summary>
        /// <param name="throws">throws score</param>
        /// <returns>True or False</returns>
        private bool IsStrike(int throws)
        {
            return Throws[throws] == MaxScorePerFrame;
        }

        /// <summary>
        /// Check for the Spare
        /// </summary>
        /// <param name="throws">throws score</param>
        /// <returns>True or False</returns>
        private bool IsSpare(int throws)
        {
            int SecondValue = 0;

            if (Throws.Length >= throws + 1) // Check if second throw exist in the frame, this to avoid exception for wrong data input.
            {
                SecondValue = Throws[throws + 1];
            }
            return Throws[throws] + SecondValue == MaxScorePerFrame;
        }
        #endregion

        #region Public Method

        /// <summary>
        /// Allowcate throws to each frame
        /// </summary>
        /// <param name="throws">throws played by player</param>
        public void Play(int[] throws)
        {
            try
            {
                Throws = throws;
                for (int thorwCount = 0; thorwCount < throws.Length; thorwCount++)
                {
                    IFrame CurrentFrame = new Frame();
                    if (Frames.Count > 0 && Frames.Count == MaxFrames - 1)
                    {
                        CurrentFrame.Scores = new int[MaxAttemptPerFrame + 1];
                        CurrentFrame.IsLastFrame = true;
                        IslastFrame = true;
                    }
                    else
                        CurrentFrame.Scores = new int[MaxAttemptPerFrame];

                    if (IsStrike(thorwCount))
                    {

                        CurrentFrame.Scores[0] = MaxScorePerFrame; // This is as per configuration. 10.
                        CurrentFrame.Scores[1] = 0;  // Next value for current frame is zero as frame reached maximum score per frame
                        CurrentFrame.IsStrike = true;
                        Frames.Add(CurrentFrame);
                        if (IsLastFrame)
                        {
                            if (Throws.Length >= thorwCount)
                            {
                                CurrentFrame.Scores[1] = throws[thorwCount]; // Last frame's second value after Strike in first attempt.
                            }
                            if (Throws.Length >= thorwCount + 1)
                            {
                                CurrentFrame.Scores[2] = throws[thorwCount + 1];  // Last frame's extra value after Strike in first attempt or strike in second attempt. 
                            }
                            return;
                        }


                    }
                    else if (IsSpare(thorwCount))
                    {
                        CurrentFrame.Scores[0] = throws[thorwCount];
                        CurrentFrame.Scores[1] = throws[thorwCount + 1];
                        CurrentFrame.IsSpare = true;
                        Frames.Add(CurrentFrame);
                        if (IsLastFrame)
                        {
                            if (Throws.Length >= thorwCount + 1 && throws.Length > thorwCount + 2)  // Last frame is spare and Extra attempt not empty.
                            {
                                CurrentFrame.Scores[2] = throws[thorwCount + 2];
                            }
                            return;
                        }

                        thorwCount++;

                    }
                    else   // This for noraml frame
                    {
                        CurrentFrame.Scores[0] = throws[thorwCount];
                        if (Throws.Length >= thorwCount)  // If Current frame is last frame and have second attempt.
                            CurrentFrame.Scores[1] = throws[thorwCount + 1];
                        Frames.Add(CurrentFrame);
                        thorwCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                // log Exception and send email
                throw;
            }
        }

        /// <summary>
        /// Calculate each frame's score and final score
        /// </summary>
        public void CalculateScore()
        {
            try
            {
                // Get all Stike Frame 
                for (int frameCount = 0; frameCount < frames.Count; frameCount++)
                {
                    IFrame CurrentFrame = frames[frameCount];
                    if (CurrentFrame.IsLastFrame) // No need to check for Strike and Spare for last frame, Get extra throw value and calculate score.
                    {
                        FinalScore += CurrentFrame.GetScore(CurrentFrame.GetExtraThrowValue());
                        return;
                    }

                    if (CurrentFrame.IsStrike)
                    {
                        // Get next two throws value from next frame
                        IFrame NextFrame = frames[frameCount + 1];
                        int FirstValue = NextFrame.GetFirstScore();
                        int SecondValue = NextFrame.GetSecondScore();
                        if (SecondValue == 0 && !NextFrame.IsLastFrame) // In case next frame also have Strike and its not last frame.. e.g 10 10 10
                        {
                            SecondValue = frames[frameCount + 2].GetFirstScore(); // Next frame's first value 
                        }

                        FinalScore += CurrentFrame.GetScore(FirstValue + SecondValue);  // Get Next frame's score and add with current frame's score
                    }
                    else if (CurrentFrame.IsSpare)
                    {
                        FinalScore += CurrentFrame.GetScore(frames[frameCount + 1].GetFirstScore());  // Get Next frame's first throw score and add with current frame's score
                    }
                    else
                    {
                        FinalScore += CurrentFrame.GetScore(); // Get Current frame's score
                    }

                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                // log Exception and send email
                throw;
            }

        }
        #endregion
    }
}
