namespace GraphQL.Datatypes
{
    public class Horse
    {
        public string Name;
        public decimal backOdds;
        public decimal layOdds;
        public decimal backPlaceOdds;
        public decimal layPlaceOdds;

        public Horse(string Name, decimal backOdds, decimal layOdds)
        {
            this.Name = Name;
            this.backOdds = backOdds;
            this.layOdds = layOdds;
            backPlaceOdds = ((backOdds - 1) / 5) + 1;
        }

        public void addLayPlaceOdds(decimal odds)
        {
            this.layPlaceOdds = odds;
        }
    }
}