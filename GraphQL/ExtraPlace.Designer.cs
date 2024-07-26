using System.ComponentModel;

namespace GraphQL
{
    partial class ExtraPlace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.epRaceCombo = new Syncfusion.WinForms.ListView.SfComboBox();
            this.loadRacesButton = new System.Windows.Forms.Button();
            this.epDatagrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.loadDataBtn = new System.Windows.Forms.Button();
            this.stakeNumeric = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.label1 = new System.Windows.Forms.Label();
            this.bookmakerCombo = new Syncfusion.WinForms.ListView.SfComboBox();
            this.smarketBtn = new System.Windows.Forms.Button();
            this.placesCombobox = new Syncfusion.WinForms.ListView.SfComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.epRaceCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDatagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stakeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.placesCombobox)).BeginInit();
            this.SuspendLayout();
            // 
            // epRaceCombo
            // 
            this.epRaceCombo.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.epRaceCombo.Location = new System.Drawing.Point(12, 12);
            this.epRaceCombo.MaxDropDownItems = 12;
            this.epRaceCombo.Name = "epRaceCombo";
            this.epRaceCombo.Size = new System.Drawing.Size(243, 23);
            this.epRaceCombo.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.epRaceCombo.TabIndex = 0;
            this.epRaceCombo.TabStop = false;
            this.epRaceCombo.SelectedIndexChanged += new System.EventHandler(this.epRaceCombo_SelectedIndexChanged);
            // 
            // loadRacesButton
            // 
            this.loadRacesButton.Location = new System.Drawing.Point(440, 12);
            this.loadRacesButton.Name = "loadRacesButton";
            this.loadRacesButton.Size = new System.Drawing.Size(105, 23);
            this.loadRacesButton.TabIndex = 1;
            this.loadRacesButton.Text = "Load Races";
            this.loadRacesButton.UseVisualStyleBackColor = true;
            this.loadRacesButton.Click += new System.EventHandler(this.loadRacesButton_Click);
            // 
            // epDatagrid
            // 
            this.epDatagrid.AccessibleName = "Table";
            this.epDatagrid.AllowEditing = false;
            this.epDatagrid.CopyOption = Syncfusion.WinForms.DataGrid.Enums.CopyOptions.IncludeFormat;
            this.epDatagrid.Location = new System.Drawing.Point(12, 93);
            this.epDatagrid.Name = "epDatagrid";
            this.epDatagrid.PasteOption = Syncfusion.WinForms.DataGrid.Enums.PasteOptions.None;
            this.epDatagrid.Size = new System.Drawing.Size(1098, 521);
            this.epDatagrid.TabIndex = 2;
            // 
            // loadDataBtn
            // 
            this.loadDataBtn.Location = new System.Drawing.Point(440, 54);
            this.loadDataBtn.Name = "loadDataBtn";
            this.loadDataBtn.Size = new System.Drawing.Size(105, 23);
            this.loadDataBtn.TabIndex = 3;
            this.loadDataBtn.Text = "Load Race Data";
            this.loadDataBtn.UseVisualStyleBackColor = true;
            this.loadDataBtn.Click += new System.EventHandler(this.loadDataBtn_Click);
            // 
            // stakeNumeric
            // 
            this.stakeNumeric.BeforeTouchSize = new System.Drawing.Size(243, 20);
            this.stakeNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.stakeNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stakeNumeric.DecimalPlaces = 2;
            this.stakeNumeric.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            this.stakeNumeric.Location = new System.Drawing.Point(12, 57);
            this.stakeNumeric.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.stakeNumeric.Name = "stakeNumeric";
            this.stakeNumeric.Size = new System.Drawing.Size(243, 20);
            this.stakeNumeric.TabIndex = 4;
            this.stakeNumeric.ThemeName = "Metro";
            this.stakeNumeric.Value = new decimal(new int[] { 250, 0, 0, 131072 });
            this.stakeNumeric.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Stake:";
            // 
            // bookmakerCombo
            // 
            this.bookmakerCombo.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.bookmakerCombo.Location = new System.Drawing.Point(261, 12);
            this.bookmakerCombo.Name = "bookmakerCombo";
            this.bookmakerCombo.Size = new System.Drawing.Size(173, 23);
            this.bookmakerCombo.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bookmakerCombo.TabIndex = 6;
            this.bookmakerCombo.TabStop = false;
            // 
            // smarketBtn
            // 
            this.smarketBtn.Location = new System.Drawing.Point(551, 54);
            this.smarketBtn.Name = "smarketBtn";
            this.smarketBtn.Size = new System.Drawing.Size(96, 23);
            this.smarketBtn.TabIndex = 7;
            this.smarketBtn.Text = "Load Smarkets Page";
            this.smarketBtn.UseVisualStyleBackColor = true;
            this.smarketBtn.Click += new System.EventHandler(this.smarketBtn_Click);
            // 
            // placesCombobox
            // 
            this.placesCombobox.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.placesCombobox.Location = new System.Drawing.Point(261, 54);
            this.placesCombobox.Name = "placesCombobox";
            this.placesCombobox.Size = new System.Drawing.Size(173, 23);
            this.placesCombobox.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.placesCombobox.TabIndex = 8;
            this.placesCombobox.TabStop = false;
            this.placesCombobox.ThemeName = "Metro";
            // 
            // ExtraPlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1122, 626);
            this.Controls.Add(this.placesCombobox);
            this.Controls.Add(this.smarketBtn);
            this.Controls.Add(this.bookmakerCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stakeNumeric);
            this.Controls.Add(this.loadDataBtn);
            this.Controls.Add(this.epDatagrid);
            this.Controls.Add(this.loadRacesButton);
            this.Controls.Add(this.epRaceCombo);
            this.Name = "ExtraPlace";
            this.Text = "ExtraPlace";
            this.Load += new System.EventHandler(this.ExtraPlace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epRaceCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDatagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stakeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.placesCombobox)).EndInit();
            this.ResumeLayout(false);
        }

        private Syncfusion.WinForms.ListView.SfComboBox placesCombobox;

        private System.Windows.Forms.Button smarketBtn;

        private Syncfusion.WinForms.ListView.SfComboBox bookmakerCombo;


        private System.Windows.Forms.Label label1;

        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt stakeNumeric;

        private System.Windows.Forms.Button loadRacesButton;
        private Syncfusion.WinForms.DataGrid.SfDataGrid epDatagrid;
        private System.Windows.Forms.Button loadDataBtn;

        private Syncfusion.WinForms.ListView.SfComboBox epRaceCombo;

        #endregion
    }
}