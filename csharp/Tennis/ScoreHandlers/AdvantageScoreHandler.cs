using Tennis.Interfaces;
using Tennis.Constants;

namespace Tennis.ScoreHandlers
{
    // A concrete handler for advantage scores in the chain of responsibility.
    public class AdvantageScoreHandler : IScoreHandler
    {
        // A reference to the next score handler in the chain of responsibility.
        private IScoreHandler nextScoreHandler;

        /// <summary>
        /// Sets the next handler in the chain.
        /// </summary>
        /// <param name="nextHandler">The next score handler in the chain of responsibility.</param>
        /// <returns>The next score handler (method chaining).</returns>
        public IScoreHandler SetNext(IScoreHandler nextHandler)
        {
            nextScoreHandler = nextHandler;
            return nextHandler;
        }

        /// <summary>
        /// Handles the scoring in case of an advantage score: one player has an advantage.
        /// In case no advantage is detected, the responsibility is passed to the next score handler in the chain of responsibility.
        /// </summary>
        /// <param name="pointsPlayerOne">The points of player one.</param>
        /// <param name="pointsPlayerTwo">The points of player two.</param>
        /// <returns>A string representing the score if advantage is detected, otherwise a delegation to the next score handler is triggered.</returns>
        public string Handle(int pointsPlayerOne, int pointsPlayerTwo)
        {
            if (IsAdvantageScenario(pointsPlayerOne, pointsPlayerTwo))
            {
                int pointDifference = pointsPlayerOne - pointsPlayerTwo;
                switch (pointDifference)
                {
                    case 1:
                        return ScoreConstants.AdvantagePlayer1;
                    case -1:
                        return ScoreConstants.AdvantagePlayer2;
                }
            }

            return nextScoreHandler?.Handle(pointsPlayerOne, pointsPlayerTwo);
        }

        /// <summary>
        /// Determines whether the current score is an advantage scenario.
        /// </summary>
        /// <param name="pointsPlayerOne">The points of player one.</param>
        /// <param name="pointsPlayerTwo">The points of player two.</param>
        /// <returns>A boolean indicating whether the score is an advantage scenario.</returns>
        private bool IsAdvantageScenario(int pointsPlayerOne, int pointsPlayerTwo)
        {
            return pointsPlayerOne >= 3 && pointsPlayerTwo >= 3;
        }
    }
}