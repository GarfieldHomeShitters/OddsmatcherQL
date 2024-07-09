using RestSharp;

namespace GraphQL.API
{
    public class SmarketsClient
    {
        private RestClient _Client;

        public SmarketsClient()
        {
            _Client = new RestClient("https://api.smarkets.com/v3/");
        }
        
    }
}