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
        public decimal profitLossQual { get; private set; }
        public decimal profitLossSnR { get; private set; }
        public decimal stakeQual { get; private set; }
        public decimal stakeSnR { get; private set; }
        public decimal liabilityQual { get; private set; }
        public decimal liabilitySnR { get; private set; }

        public MatchedEvent(GetBestMatch bestMatch, decimal backStake)
        {
            startAt = DateTime.TryParse(bestMatch.StartAt, out DateTime parsedDate) ? parsedDate : DateTime.Now;
            eventName = bestMatch.EventName;
            selectionID = bestMatch.SelectionId;
            bookmaker = bestMatch.Back.Bookmaker.DisplayName;
            backOdds = decimal.TryParse(bestMatch.Back.Odds, out decimal parsedBackOdds) ? parsedBackOdds : bestMatch.Back.Odds.Length; // No idea what to do in this situation to be honest
            layOdds = decimal.TryParse(bestMatch.Lay.Odds, out decimal parsedLayOdds) ? parsedLayOdds : bestMatch.Lay.Odds.Length;
            rating = decimal.TryParse(bestMatch.Rating, out decimal parsedRating) ? parsedRating : bestMatch.Rating.GetHashCode(); // Again not a scoobie but hey ho
            snrRating = decimal.TryParse(bestMatch.Snr, out decimal parsedSnR) ? parsedSnR : bestMatch.Snr.GetHashCode();

            decimal backReturnQual = backOdds * backStake;
            decimal backReturnSnR = backReturnQual - backStake;
            liabilityQual = (backReturnQual * layOdds - backReturnQual) / layOdds;
            liabilitySnR = (backReturnSnR * layOdds - backReturnSnR) / layOdds;
            stakeQual = liabilityQual / (layOdds - 1);
            stakeSnR = liabilitySnR / (layOdds - 1);
            profitLossQual = backReturnQual - backStake - liabilityQual;
            profitLossSnR = backReturnQual - liabilityQual;
        }
    }
}