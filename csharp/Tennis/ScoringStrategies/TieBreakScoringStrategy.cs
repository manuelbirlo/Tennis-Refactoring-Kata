using Tennis.Interfaces;
using Tennis.ScoreHandlers;

namespace Tennis.ScoringStrategies
{
    // The implementation of the tie break scoring strategy of the IScoringStrategy interface
    public class TieBreakScoringStrategy : IScoringStrategy
    {
        // Holds a reference to the concrete score first handler in the chain of responsibilities.
        private readonly IScoreHandler chainOfScoreHandlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="TieBreakScoringStrategy"/> class.
        /// </summary>
        public TieBreakScoringStrategy()
        {
            // The first handler in the chain of responsibilites: 
            // The first condition to check is if the scores are tied. 
            // In a Tennis tie-break, it appears to be common to have frequent ties as players alternate winning points. 
            // Starting with this tie-break handler ensures that ties are taken into account and handled immediately.
            chainOfScoreHandlers = new TiedScoreHandler();
            chainOfScoreHandlers.SetNext(new AdvantageScoreHandler())
                                .SetNext(new WinScoreHandler())
                                .SetNext(new DefaultScoreHandler());
        }

        // Gets the score based on the points of both players
        public string GetScore(int pointsPlayerOne, int pointsPlayerTwo)
        {
            return chainOfScoreHandlers.Handle(pointsPlayerOne, pointsPlayerTwo);
        }
    }
}

