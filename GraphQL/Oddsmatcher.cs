using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GraphQL.API;
using GraphQL.Datatypes;
using Syncfusion.DataSource.Extensions;
using Syncfusion.Windows.Forms.Tools;

namespace GraphQL
{
    public partial class Oddsmatcher : Form
    {
        private readonly FileInfo[] configs;
        private readonly string[] Bookmakers;
        private readonly string[] Sports;
        private string[] selectedBookmakers;
        private string[] selectedSports;
        private APIService ApiService;
        private List<MatchedEvent> unfilteredMatchedEvents;
        private List<MatchedEvent> filteredMatchedEvents;
        private bool shouldApplyFilters;

        public Oddsmatcher()
        {
            // TODO: Make paths relative?? Not releasing so who really cared but for best practise.
            ApiService = new APIService();
            configs = new DirectoryInfo("X:\\Projects\\MatchedBetting\\GraphQL\\GraphQL\\Configs").GetFiles("*.json");
            Bookmakers = File.ReadAllLines("X:\\Projects\\MatchedBetting\\GraphQL\\GraphQL\\Default\\availableBookmakers.txt");
            Sports = File.ReadAllLines("X:\\Projects\\MatchedBetting\\GraphQL\\GraphQL\\Default\\availableSports.txt");

            InitializeComponent();
        }

        private void Oddsmatcher_Load(object sender, EventArgs e)
        {
            foreach (var bookmaker in Bookmakers) multiBookmaker.Items.Add(bookmaker);
            foreach (var sport in Sports) multiSport.Items.Add(sport);
            configSelection.DataSource = configs;
            configSelection.DisplayMember = "Name";
        }

        private void bookmakerDeselectButton_Click(object sender, EventArgs e)
        {
            multiBookmaker.UnSelectAll();
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            // TODO Parse configSelection.SelectedItem -> will return FileInfo for File
        }

        private void minOddsNumeric_ValueChanged(object sender, EventArgs e)
        {
            maxOddsNumeric.Minimum = minOddsNumeric.Value;
        }

        private void maxOddsNumeric_ValueChanged(object sender, EventArgs e)
        {
            minOddsNumeric.Maximum = maxOddsNumeric.Value;
        }

        private void ratingMinNumeric_ValueChanged(object sender, EventArgs e)
        {
            maxRatingNumeric.Minimum = minRatingNumeric.Value;
        }

        private void ratingMaxNumeric_ValueChanged(object sender, EventArgs e)
        {
            minRatingNumeric.Maximum = maxRatingNumeric.Value;
        }

        private async void loadDataBtn_Click(object sender, EventArgs e)
        {
            // Clear Previous response data.
            updateSelections();

            // Get Unfiltered Results
            GetBestMatch[] apiResponse = await ApiService.FetchAPIData(selectedBookmakers, selectedSports, minOddsNumeric.Value, maxOddsNumeric.Value, minRatingNumeric.Value, maxRatingNumeric.Value, snrCheck.Checked);
            unfilteredMatchedEvents = new List<MatchedEvent>();
            foreach (GetBestMatch bestMatch in apiResponse)
            {
                MatchedEvent @event = new MatchedEvent(bestMatch, snrCheck.Checked, stakeNumeric.Value);
                unfilteredMatchedEvents.Add(@event);
            }

            // Update filtered results if need be.
            if (shouldApplyFilters) {
                applyFilters();
            }
            else {
                filteredMatchedEvents = unfilteredMatchedEvents.ToList();
            }

            tblMatchedResults.DataSource = filteredMatchedEvents;
        }

        private void updateSelections()
        {
            selectedBookmakers = multiBookmaker.SelectedItems.Count != 0 ? convertItemsToStringArray(multiBookmaker.SelectedItems, Bookmakers) : new string[] { };
            selectedSports = multiSport.SelectedItems.Count != 0 ? convertItemsToStringArray(multiSport.SelectedItems, Sports) : new string[] { };
        }

        private string[] convertItemsToStringArray(MultiSelectionComboBox.SelectedObjectCollection selectedObjects, string[] RefNames)
        {
            List<string> selectedItemStrings = new List<string>();
            foreach (DataRowView Object in selectedObjects)
            {
                selectedItemStrings.Add(Object.Row.ItemArray.First().ToString());
            }

            return selectedItemStrings.ToArray();
        }

        private void applyFilters()
        {
            foreach (var Event in unfilteredMatchedEvents)
            {
                Event.calculateValues(snrCheck.Checked, stakeNumeric.Value);
            }

            filteredMatchedEvents = unfilteredMatchedEvents
                .Where(x => x.liability <= maxLiabilityNumeric.Value)
                .Where(y => y.profitLoss >= -maxLossNumeric.Value)
                .ToList();
            //tblMatchedResults.Refresh();
            tblMatchedResults.DataSource = filteredMatchedEvents;
        }

        private void applyFilterBtn_Click(object sender, EventArgs e)
        {
            tblMatchedResults.DataSource = null;
            tblMatchedResults.Refresh();
            
            if (!shouldApplyFilters)
            {
                setUnfilteredData();
                tblMatchedResults.DataSource = filteredMatchedEvents;
                tblMatchedResults.Refresh();
                return;
            }

            if (unfilteredMatchedEvents.Count != 0) applyFilters();
        }

        private void setUnfilteredData()
        {
            
            foreach (var Event in unfilteredMatchedEvents)
            {
                Event.calculateValues(snrCheck.Checked, stakeNumeric.Value);
            }
            filteredMatchedEvents = unfilteredMatchedEvents.ToList();
        }

        private void filterCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            shouldApplyFilters = filterCheckbox.Checked;
        }

        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            multiBookmaker.SelectAll();
        }
    }
}