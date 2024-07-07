using System;

namespace GraphQL.Datatypes
{
    public class MatchedEvent
    {
        public DateTime startAt { get; private set; }
        public string eventName { get; private set; }
        public string selectionID { get; private set; }
        public string bookmaker { get; private set; }
        public decimal backOdds { get; private set; }
        public decimal layOdds { get; private set; }
        public decimal rating { get; private set; }
        public decimal snrRating { get; private set; }
        public decimal backStake { get; private set; }
        public decimal profitLoss { get; private set; }
        public decimal liability { get; private set; }
        public decimal exchangeStake { get; private set; }
        private decimal backReturn { get; set; }
        private bool SnR { get; set; }

        public MatchedEvent(GetBestMatch bestMatch, bool isSnR, decimal backStake = 5.00m)
        {
            startAt = DateTime.TryParse(bestMatch.StartAt, out DateTime parsedDate) ? parsedDate : DateTime.Now;
            eventName = bestMatch.EventName;
            selectionID = bestMatch.SelectionId;
            bookmaker = bestMatch.Back.Bookmaker.DisplayName;
            backOdds = decimal.TryParse(bestMatch.Back.Odds, out decimal parsedBackOdds) ? parsedBackOdds : bestMatch.Back.Odds.Length; // No idea what to do in this situation to be honest
            layOdds = decimal.TryParse(bestMatch.Lay.Odds, out decimal parsedLayOdds) ? parsedLayOdds : bestMatch.Lay.Odds.Length;
            rating = decimal.TryParse(bestMatch.Rating, out decimal parsedRating) ? parsedRating : bestMatch.Rating.GetHashCode(); // Again not a scoobie but hey ho
            snrRating = decimal.TryParse(bestMatch.Snr, out decimal parsedSnR) ? parsedSnR : bestMatch.Snr.GetHashCode();
            this.backStake = backStake;
            SnR = isSnR;

            calculateValues();
        }

        public void calculateValues(decimal backStake = 5.00m)
        {
            this.backStake = backStake;
            calculateReturn();
            calculateStakeAndLiability();
            calculateProfitLoss();
        }

        void calculateReturn()
        {
            decimal tempRet = backOdds * backStake;
            backReturn = SnR ? tempRet - backStake : tempRet;
        }

        void calculateStakeAndLiability()
        {
            liability = (backReturn * layOdds - backReturn) / layOdds;
            exchangeStake = liability / (layOdds - 1);
        }

        void calculateProfitLoss()
        {
            profitLoss = SnR ? backReturn - liability : backReturn - backStake - liability;
        }
    }
}