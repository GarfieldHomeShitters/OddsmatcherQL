using System;

namespace GraphQL.Datatypes
{
    public class HorseExtraPlace
    {
        public string Name { get; private set; }
        public decimal stake {get; private set;}
        public decimal backWinOdds {get; private set;}
        public decimal backPlaceOdds {get; private set;}
        public decimal layWinOdds {get; private set;}
        public decimal layPlaceOdds {get; private set;}
        public decimal ProfitLossRegular {get; private set;}
        public decimal ProfitLossExtraPlace {get; private set;}
        //public decimal ImpliedOdds {get; private set;}
        public decimal stakeWin {get; private set;}
        public decimal stakePlace {get; private set;}
        public decimal liabilityWin {get; private set;}
        public decimal liabilityPlace {get; private set;}
        private decimal winRet;
        private decimal placeRet;
        private decimal laywinRet;
        private decimal layplaceRet;
        public decimal rating {get; private set;}

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
            Name = horse.Name;
            backWinOdds = horse.backOdds;
            layWinOdds = horse.layOdds;
            backPlaceOdds = horse.backPlaceOdds;
            layPlaceOdds = horse.layPlaceOdds;
            this.stake = stake;
        }
        
        public void calculateProfitLoss()
        {
            calc();
            decimal horseWins = (winRet + placeRet) - (2 * stake) + -liabilityWin + -liabilityPlace;
            decimal horsePlaces = (placeRet + laywinRet) - (stake * 2) + -liabilityWin + -liabilityPlace;
            decimal horseNoPlaceNoWin = (laywinRet + layplaceRet) - (stake * 2) + -liabilityWin + -liabilityPlace;
            ProfitLossExtraPlace = (placeRet + laywinRet + layplaceRet) - (2 * stake) - liabilityWin - liabilityPlace;
            ProfitLossRegular = Math.Min(Math.Min(horseWins, horsePlaces), horseNoPlaceNoWin);
            rating = (((2*stake) + ProfitLossRegular) / (2*stake)) * 100;
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