using Tennis.Interfaces;
using Tennis.Constants;

namespace Tennis.ScoreHandlers
{
    // A concrete handler for win scores in the chain of responsibility.
    public class WinScoreHandler : IScoreHandler
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
        /// Handles the scoring in case of a win score: a win is detected.
        /// In case no win is detected, the responsibility is passed to the next score handler in the chain of responsibility.
        /// </summary>
        /// <param name="pointsPlayerOne">The points of player one.</param>
        /// <param name="pointsPlayerTwo">The points of player two.</param>
        /// <returns>A string representing the score if a win is detected, otherwise a delegation to the next score handler is triggered.</returns>
        public string Handle(int pointsPlayerOne, int pointsPlayerTwo)
        {
            if (IsWin(pointsPlayerOne, pointsPlayerTwo))
            {
                return ScoreConstants.WinForPlayer1;
            }
            
            if (IsWin(pointsPlayerTwo, pointsPlayerOne))
            {
                return ScoreConstants.WinForPlayer2;
            }

            return nextScoreHandler?.Handle(pointsPlayerOne, pointsPlayerTwo);
        }

        /// <summary>
        /// Determines whether the given player has won.
        /// </summary>
        /// <param name="pointsCurrentPlayer">The points of the current player being checked.</param>
        /// <param name="pointsOpponent">The points of the opponent player.</param>
        /// <returns>A boolean indicating whether the current player has won.</returns>
        private bool IsWin(int pointsCurrentPlayer, int pointsOpponent)
        {
            return pointsCurrentPlayer >= 4 && pointsCurrentPlayer >= pointsOpponent + 2;
        }
    }
}