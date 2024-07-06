using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Syncfusion.Windows.Forms.Tools;


namespace GraphQL
{
    public partial class Oddsmatcher : Form
    {
        private readonly IGraphQLClient GraphQlClient;
        private readonly DirectoryInfo configs;
        private readonly string[] Bookmakers;
        private readonly string[] Sports;
        public Oddsmatcher()
        {
            // TODO: Make paths relative?? Not releasing so who really cared but for best practise.
            configs = new DirectoryInfo("X:\\Projects\\MatchedBetting\\GraphQL\\GraphQL\\Configs");
            Bookmakers = File.ReadAllLines($"X:\\Projects\\MatchedBetting\\GraphQL\\GraphQL\\Default\\availableBookmakers.txt");
            Sports = File.ReadAllLines($"X:\\Projects\\MatchedBetting\\GraphQL\\GraphQL\\Default\\availableSports.txt");
            GraphQlClient = new GraphQLHttpClient("https://api.oddsplatform.profitaccumulator.com/graphql", new NewtonsoftJsonSerializer());
            InitializeComponent();
        }

        private void Oddsmatcher_Load(object sender, EventArgs e)
        {
            foreach (var bookmaker in Bookmakers) multiBookmaker.Items.Add(bookmaker);
        }

        private void bookmakerDeselectButton_Click(object sender, EventArgs e) { multiBookmaker.UnSelectAll(); }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            
        }
        
        private void minOddsNumeric_ValueChanged(object sender, EventArgs e) { maxOddsNumeric.Minimum = minOddsNumeric.Value; }
        private void maxOddsNumeric_ValueChanged(object sender, EventArgs e) { minOddsNumeric.Maximum = maxOddsNumeric.Value; }
        private void ratingMinNumeric_ValueChanged(object sender, EventArgs e) { ratingMaxNumeric.Minimum = ratingMinNumeric.Value; }
        private void ratingMaxNumeric_ValueChanged(object sender, EventArgs e) { ratingMinNumeric.Maximum = ratingMaxNumeric.Value; }
    }
}