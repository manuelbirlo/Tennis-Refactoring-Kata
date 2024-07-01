using Tennis.Interfaces;
using Tennis.Constants;

namespace Tennis.ScoreHandlers
{
    // A concrete handler for default scoring in the chain of responsibility (neither player has won or has an advantage.).
    public class DefaultScoreHandler : IScoreHandler
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
        /// Handles the scoring in case of a default score: neither player has won or has an advantage.
        /// In case neither player has won or has an advantage, the responsibility is passed to the next score handler in the chain of responsibility.
        /// </summary>
        /// <param name="pointsPlayerOne">The points of player one.</param>
        /// <param name="pointsPlayerTwo">The points of player two.</param>
        /// <returns>A string representing the score if neither player has won or has an advantage, otherwise a delegation to the next score handler is triggered.</returns>
        public string Handle(int pointsPlayerOne, int pointsPlayerTwo)
        {
            var scores = new[] 
            { 
                ScoreConstants.Love, 
                ScoreConstants.Fifteen, 
                ScoreConstants.Thirty, 
                ScoreConstants.Forty 
            };

            if (IsDefaultScore(pointsPlayerOne, pointsPlayerTwo))
            {
                return $"{scores[pointsPlayerOne]}-{scores[pointsPlayerTwo]}";
            }

            return nextScoreHandler?.Handle(pointsPlayerOne, pointsPlayerTwo);
        }

        /// <summary>
        /// Determines whether the current score is a default score.
        /// </summary>
        /// <param name="pointsPlayerOne">The points of player one.</param>
        /// <param name="pointsPlayerTwo">The points of player two.</param>
        /// <returns>A boolean indicating whether the score is a default score.</returns>
        private bool IsDefaultScore(int pointsPlayerOne, int pointsPlayerTwo)
        {
            return pointsPlayerOne < 4 && pointsPlayerTwo < 4 && (pointsPlayerOne + pointsPlayerTwo != 6);
        }
    }
}