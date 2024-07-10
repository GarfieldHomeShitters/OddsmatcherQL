using System;

namespace GraphQL.Datatypes
{
    public class HorseExtraPlace
    {
        public decimal stake;
        public decimal backWinOdds;
        public decimal backPlaceOdds;
        public decimal layWinOdds;
        public decimal layPlaceOdds;
        public decimal ProfitLossRegular;
        public decimal ProfitLossExtraPlace;
        public decimal ImpliedOdds;
        public decimal Rating;
        public decimal stakeWin;
        public decimal stakePlace;
        public decimal liabilityWin;
        public decimal liabilityPlace;
        private decimal winRet;
        private decimal placeRet;
        private decimal laywinRet;
        private decimal layplaceRet;
        public decimal rating;

        public HorseExtraPlace(decimal Stake, decimal backWin, decimal backPlace, decimal layWin, decimal layPlace)
        {
            stake = Stake;
            backWinOdds = backWin;
            backPlaceOdds = backPlace;
            layWinOdds = layWin;
            layPlaceOdds = layPlace;
        }

        public HorseExtraPlace(Horse horse, decimal stake)
        {
            backWinOdds = horse.backOdds;
            layWinOdds = horse.layOdds;
            backPlaceOdds = horse.backPlaceOdds;
            layPlaceOdds = horse.layPlaceOdds;
        }
        
        public void calculateProfitLoss()
        {
            decimal horseWins = (winRet + placeRet) - (2 * stake) + -liabilityWin + -liabilityPlace;
            decimal horsePlaces = (placeRet + layplaceRet) - (stake * 2) + -liabilityWin + -liabilityPlace;
            decimal horseNoPlaceNoWin = (laywinRet + layplaceRet) - (stake * 2) + -liabilityWin + -liabilityPlace;
            ProfitLossExtraPlace = (placeRet + laywinRet + layplaceRet) - (2 * stake) - liabilityWin - liabilityPlace;
            ProfitLossRegular = Math.Min(Math.Min(horseWins, horsePlaces), horseNoPlaceNoWin);
            rating = ((stake - ProfitLossRegular) / stake) * 100;
        }

        private void calc()
        {
            winRet = (stake * backWinOdds);
            placeRet = (stake * backPlaceOdds);
            liabilityWin = (winRet * layWinOdds - winRet) / layWinOdds;
            liabilityPlace = (placeRet * layPlaceOdds - placeRet) / layPlaceOdds;
            stakeWin = liabilityWin / (layWinOdds - 1);
            stakePlace = liabilityPlace / (layPlaceOdds - 1);
            laywinRet = liabilityWin + stakePlace;
            layplaceRet = liabilityPlace + stakePlace;
        }
    }
}