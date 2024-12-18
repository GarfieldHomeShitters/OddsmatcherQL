using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL.Datatypes;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace GraphQL.API
{
    public class APIService
    {
        private readonly IGraphQLClient GraphQlClient;

        public APIService()
        {
            var client = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            });
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br, zstd");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            client.DefaultRequestHeaders.Add("Dnt", "1");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-site");
            client.DefaultRequestHeaders.Add("Sec-Gpc", "1");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.3");
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            GraphQlClient = new GraphQLHttpClient("https://api.oddsplatform.profitaccumulator.com/graphql", new NewtonsoftJsonSerializer(), client);
        }

        public async Task<GetBestMatch[]> FetchAPIData(string[] Bookmakers, string[] Sports, decimal minOdds, decimal maxOdds, decimal minRating, decimal maxRating, bool snr, int skip = 0, bool todayOnly = false, int limit = 100, bool excludeDraws = false)
        {
            string defaultQueryVariables = File.ReadAllText("X:\\Projects\\MatchedBetting\\GraphQL\\GraphQL\\Configs\\AllBookmakers.json");
            Dictionary<string, object> _Variables = JsonConvert.DeserializeObject<Dictionary<string, object>>(defaultQueryVariables);

            Bookmakers = Bookmakers.Select(s => s.ToLowerInvariant()).ToArray();

            Array.Sort(Bookmakers);

            _Variables["bookmaker"] = Bookmakers.Select(s => s.Replace(" ", "")).ToArray();
            _Variables["permittedSports"] = Sports;
            _Variables["minOdds"] = minOdds.ToString("0.##");
            _Variables["maxOdds"] = maxOdds.ToString("0.##");
            _Variables["minRating"] = minRating.ToString("0.##");
            _Variables["maxRating"] = maxRating.ToString("0.##");
            _Variables["cap"] = (int)Math.Floor(maxRating);
            _Variables["skip"] = skip;
            _Variables["limit"] = limit;
            if (todayOnly)
            {
                _Variables["timeframeStart"] = DateTime.Today.ToString("yyyy-MM-ddTHH:mm:sszzz");
                _Variables["timeframeEnd"] = DateTime.Today.AddDays(1).AddMinutes(-25).ToString("yyyy-MM-ddTHH:mm:sszzz");
            }

            if (excludeDraws)
            {
                _Variables["excludeDraw"] = true;
                _Variables["permittedMarketGroups"] = new List<string>{"match-odds"};
                // "permittedMarketGroups": ["win-market","match-odds","over-under","half-time-full-time","correct-score","both-teams-to-score"]
            }

            GraphQLRequest APIRequest = new GraphQLRequest
            {
                OperationName = "GetBestMatches",
                Variables = _Variables,
                Query = File.ReadAllText("X:\\Projects\\MatchedBetting\\GraphQL\\GraphQL\\Default\\baseQuery.txt")
            };

            var apiResponse = await GraphQlClient.SendQueryAsync<Data>(APIRequest);
            if (apiResponse.Errors != null)
            {
                foreach (var error in apiResponse.Errors)
                {
                    MessageBox.Show($"{error.Message}", "Error with API");
                }

                return new GetBestMatch[] { }; // Just return no data here.
            }

            return apiResponse.Data.GetBestMatches;
        }

        public async Task<List<GetBestMatch>> getAllRaceData(string[] Bookmakers)
        {
            string[] Sports = new string[] { "horseracing" };
            int skip = 0;
            List<GetBestMatch> _allMatches = new List<GetBestMatch>();
            GetBestMatch[] newMatches = await FetchAPIData(Bookmakers, Sports, 1m, 999m, 0, 200, false, skip, true, 1000);
            // while (newMatches.Length >= 100 && !(_allMatches.Contains(newMatches.Last())))
            // {
            //     foreach (GetBestMatch match in newMatches) _allMatches.Add(match);
            //     newMatches = await FetchAPIData(Bookmakers, Sports, 1m, 999m, 0, 200, false, skip, true);
            //     skip += newMatches.Length;
            // }
            //_allMatches.Add(newMatches);
            return newMatches.ToList();
        }
    }
}