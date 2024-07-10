using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class ContractResponse
    {
        [JsonProperty("contracts")]
        public List<SmarketContract> contracts;
    }
}