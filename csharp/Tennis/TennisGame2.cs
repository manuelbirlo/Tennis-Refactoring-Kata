using Tennis.Interfaces;
using Tennis.ScoringStrategies;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;

        // Holds a reference to a scoring strategy
        private readonly IScoringStrategy scoringStrategy;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            p1point = 0;
            p2point = 0;
            scoringStrategy = new DefaultScoringStrategy();
        }

        public string GetScore()
        {
            return scoringStrategy.GetScore(p1point, p2point);
        }

        public void SetP1Score(int points)
        {
            p1point = points;
        }

        public void SetP2Score(int points)
        {
            p2point = points;
        }

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

