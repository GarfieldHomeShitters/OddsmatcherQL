using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;


namespace GraphQL
{
    public partial class Oddsmatcher : Form
    {
        private readonly IGraphQLClient GraphQlClient;

        public Oddsmatcher()
        {
            GraphQlClient = new GraphQLHttpClient("https://api.oddsplatform.profitaccumulator.com/graphql", new NewtonsoftJsonSerializer());
            InitializeComponent();
        }

    }
}