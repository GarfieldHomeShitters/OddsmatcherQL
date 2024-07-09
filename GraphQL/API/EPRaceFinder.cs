using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace GraphQL.API
{
    public class EPRaceFinder
    {
        private const string _listUri = "https://matchedbettingblog.com/extra-place-offers-today/";
        private async Task<string> FetchHtmlAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_listUri);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        
        public async Task<List<string>> GetRaceTimesAsync()
        {
            string htmlContent = await FetchHtmlAsync();
            var context = BrowsingContext.New(Configuration.Default);
            var document = await context.OpenAsync(req => req.Content(htmlContent));
            
            var raceNodes = document.QuerySelectorAll("h2.mbb-offer-list__extra-places__race");
            List<string> raceTimes = new List<string>();
            foreach (var node in raceNodes)
            {
                raceTimes.Add(node.TextContent.Trim());
            }

            return raceTimes;
        }
    }
}