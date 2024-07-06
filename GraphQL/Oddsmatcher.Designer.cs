namespace GraphQL
{
    partial class Oddsmatcher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Oddsmatcher));
            this.tblMatchedResults = new System.Windows.Forms.DataGridView();
            this.ConfigSelection = new System.Windows.Forms.ComboBox();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.multiBookmaker = new Syncfusion.Windows.Forms.Tools.MultiSelectionComboBox();
            this.bookmakerDeselectButton = new System.Windows.Forms.Button();
            this.minOddsNumeric = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ratingMaxNumeric = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.ratingMinNumeric = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.label1 = new System.Windows.Forms.Label();
            this.maxOddsNumeric = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.quickCheckBoxReflectable1 = new Syncfusion.Windows.Forms.Tools.QuickCheckBoxReflectable();
            this.snrCheck = new System.Windows.Forms.CheckBox();
            this.sportSelection = new Syncfusion.Windows.Forms.Tools.MultiSelectionComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblMatchedResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiBookmaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minOddsNumeric)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratingMaxNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingMinNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxOddsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sportSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMatchedResults
            // 
            this.tblMatchedResults.AllowUserToAddRows = false;
            this.tblMatchedResults.AllowUserToDeleteRows = false;
            this.tblMatchedResults.AllowUserToOrderColumns = true;
            this.tblMatchedResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblMatchedResults.Location = new System.Drawing.Point(12, 167);
            this.tblMatchedResults.Name = "tblMatchedResults";
            this.tblMatchedResults.Size = new System.Drawing.Size(936, 521);
            this.tblMatchedResults.TabIndex = 0;
            // 
            // ConfigSelection
            // 
            this.ConfigSelection.FormattingEnabled = true;
            this.ConfigSelection.Items.AddRange(new object[] { "--No Config--" });
            this.ConfigSelection.Location = new System.Drawing.Point(12, 140);
            this.ConfigSelection.Name = "ConfigSelection";
            this.ConfigSelection.Size = new System.Drawing.Size(121, 21);
            this.ConfigSelection.TabIndex = 1;
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Location = new System.Drawing.Point(139, 138);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(75, 23);
            this.btnLoadConfig.TabIndex = 2;
            this.btnLoadConfig.Text = "Load Config";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // multiBookmaker
            // 
            this.multiBookmaker.AutoSizeMode = Syncfusion.Windows.Forms.Tools.AutoSizeModes.None;
            this.multiBookmaker.BackColor = System.Drawing.Color.White;
            this.multiBookmaker.BeforeTouchSize = new System.Drawing.Size(300, 30);
            this.multiBookmaker.ButtonStyle = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.multiBookmaker.DelimiterChar = ", ";
            this.multiBookmaker.DisplayMode = Syncfusion.Windows.Forms.Tools.DisplayMode.DelimiterMode;
            this.multiBookmaker.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.multiBookmaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.multiBookmaker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiBookmaker.Location = new System.Drawing.Point(12, 18);
            this.multiBookmaker.Name = "multiBookmaker";
            this.multiBookmaker.ShowCheckBox = true;
            this.multiBookmaker.Size = new System.Drawing.Size(300, 30);
            this.multiBookmaker.TabIndex = 4;
            this.multiBookmaker.ThemeName = "Metro";
            this.multiBookmaker.ThemeStyle.FocusedBorderColor = System.Drawing.Color.Silver;
            this.multiBookmaker.ThemeStyle.HoverBorderColor = System.Drawing.Color.Gray;
            this.multiBookmaker.ThemeStyle.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.multiBookmaker.UseVisualStyle = true;
            // 
            // bookmakerDeselectButton
            // 
            this.bookmakerDeselectButton.Location = new System.Drawing.Point(12, 54);
            this.bookmakerDeselectButton.Name = "bookmakerDeselectButton";
            this.bookmakerDeselectButton.Size = new System.Drawing.Size(121, 23);
            this.bookmakerDeselectButton.TabIndex = 5;
            this.bookmakerDeselectButton.Text = "Deselect All";
            this.bookmakerDeselectButton.UseVisualStyleBackColor = true;
            this.bookmakerDeselectButton.Click += new System.EventHandler(this.bookmakerDeselectButton_Click);
            // 
            // minOddsNumeric
            // 
            this.minOddsNumeric.BackColor = System.Drawing.Color.White;
            this.minOddsNumeric.BeforeTouchSize = new System.Drawing.Size(66, 24);
            this.minOddsNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.minOddsNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minOddsNumeric.DecimalPlaces = 2;
            this.minOddsNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.minOddsNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.minOddsNumeric.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.minOddsNumeric.Location = new System.Drawing.Point(567, 24);
            this.minOddsNumeric.Maximum = new decimal(new int[] { 35, 0, 0, 65536 });
            this.minOddsNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.minOddsNumeric.Name = "minOddsNumeric";
            this.minOddsNumeric.Size = new System.Drawing.Size(66, 24);
            this.minOddsNumeric.TabIndex = 6;
            this.minOddsNumeric.ThemeName = "Metro";
            this.minOddsNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.minOddsNumeric.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.minOddsNumeric.ValueChanged += new System.EventHandler(this.minOddsNumeric_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.sportSelection);
            this.panel1.Controls.Add(this.snrCheck);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ratingMaxNumeric);
            this.panel1.Controls.Add(this.ratingMinNumeric);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.maxOddsNumeric);
            this.panel1.Controls.Add(this.bookmakerDeselectButton);
            this.panel1.Controls.Add(this.minOddsNumeric);
            this.panel1.Controls.Add(this.multiBookmaker);
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 121);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(708, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Min Rating:    Max Rating:";
            // 
            // ratingMaxNumeric
            // 
            this.ratingMaxNumeric.BackColor = System.Drawing.Color.White;
            this.ratingMaxNumeric.BeforeTouchSize = new System.Drawing.Size(66, 24);
            this.ratingMaxNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.ratingMaxNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ratingMaxNumeric.DecimalPlaces = 2;
            this.ratingMaxNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ratingMaxNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ratingMaxNumeric.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.ratingMaxNumeric.Location = new System.Drawing.Point(780, 24);
            this.ratingMaxNumeric.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            this.ratingMaxNumeric.Name = "ratingMaxNumeric";
            this.ratingMaxNumeric.Size = new System.Drawing.Size(66, 24);
            this.ratingMaxNumeric.TabIndex = 10;
            this.ratingMaxNumeric.ThemeName = "Metro";
            this.ratingMaxNumeric.Value = new decimal(new int[] { 99, 0, 0, 0 });
            this.ratingMaxNumeric.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.ratingMaxNumeric.ValueChanged += new System.EventHandler(this.ratingMaxNumeric_ValueChanged);
            // 
            // ratingMinNumeric
            // 
            this.ratingMinNumeric.BackColor = System.Drawing.Color.White;
            this.ratingMinNumeric.BeforeTouchSize = new System.Drawing.Size(66, 24);
            this.ratingMinNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.ratingMinNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ratingMinNumeric.DecimalPlaces = 2;
            this.ratingMinNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ratingMinNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ratingMinNumeric.Location = new System.Drawing.Point(708, 24);
            this.ratingMinNumeric.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            this.ratingMinNumeric.Name = "ratingMinNumeric";
            this.ratingMinNumeric.Size = new System.Drawing.Size(66, 24);
            this.ratingMinNumeric.TabIndex = 9;
            this.ratingMinNumeric.ThemeName = "Metro";
            this.ratingMinNumeric.Value = new decimal(new int[] { 50, 0, 0, 0 });
            this.ratingMinNumeric.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.ratingMinNumeric.ValueChanged += new System.EventHandler(this.ratingMinNumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(567, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Min Odds:      Max Odds:";
            // 
            // maxOddsNumeric
            // 
            this.maxOddsNumeric.BackColor = System.Drawing.Color.White;
            this.maxOddsNumeric.BeforeTouchSize = new System.Drawing.Size(66, 24);
            this.maxOddsNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.maxOddsNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxOddsNumeric.DecimalPlaces = 2;
            this.maxOddsNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.maxOddsNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.maxOddsNumeric.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.maxOddsNumeric.Location = new System.Drawing.Point(636, 24);
            this.maxOddsNumeric.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.maxOddsNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.maxOddsNumeric.Name = "maxOddsNumeric";
            this.maxOddsNumeric.Size = new System.Drawing.Size(66, 24);
            this.maxOddsNumeric.TabIndex = 7;
            this.maxOddsNumeric.ThemeName = "Metro";
            this.maxOddsNumeric.Value = new decimal(new int[] { 35, 0, 0, 65536 });
            this.maxOddsNumeric.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.maxOddsNumeric.ValueChanged += new System.EventHandler(this.maxOddsNumeric_ValueChanged);
            // 
            // quickCheckBoxReflectable1
            // 
            this.quickCheckBoxReflectable1.Name = "quickCheckBoxReflectable1";
            this.quickCheckBoxReflectable1.ReflectedCheckBox = null;
            this.quickCheckBoxReflectable1.Size = new System.Drawing.Size(23, 23);
            this.quickCheckBoxReflectable1.Text = "quickCheckBoxReflectable1";
            // 
            // snrCheck
            // 
            this.snrCheck.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.snrCheck.Location = new System.Drawing.Point(852, 24);
            this.snrCheck.Name = "snrCheck";
            this.snrCheck.Size = new System.Drawing.Size(53, 24);
            this.snrCheck.TabIndex = 12;
            this.snrCheck.Text = "SnR";
            this.snrCheck.UseVisualStyleBackColor = true;
            // 
            // sportSelection
            // 
            this.sportSelection.AutoSizeMode = Syncfusion.Windows.Forms.Tools.AutoSizeModes.None;
            this.sportSelection.BackColor = System.Drawing.Color.White;
            this.sportSelection.BeforeTouchSize = new System.Drawing.Size(243, 30);
            this.sportSelection.ButtonStyle = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.sportSelection.DelimiterChar = ", ";
            this.sportSelection.DisplayMode = Syncfusion.Windows.Forms.Tools.DisplayMode.DelimiterMode;
            this.sportSelection.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.sportSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sportSelection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sportSelection.Location = new System.Drawing.Point(318, 18);
            this.sportSelection.Name = "sportSelection";
            this.sportSelection.ShowCheckBox = true;
            this.sportSelection.Size = new System.Drawing.Size(243, 30);
            this.sportSelection.TabIndex = 13;
            this.sportSelection.ThemeName = "Metro";
            this.sportSelection.ThemeStyle.FocusedBorderColor = System.Drawing.Color.Silver;
            this.sportSelection.ThemeStyle.HoverBorderColor = System.Drawing.Color.Gray;
            this.sportSelection.ThemeStyle.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // Oddsmatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(960, 700);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLoadConfig);
            this.Controls.Add(this.ConfigSelection);
            this.Controls.Add(this.tblMatchedResults);
            this.Name = "Oddsmatcher";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Oddsmatcher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblMatchedResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiBookmaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minOddsNumeric)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ratingMaxNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingMinNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxOddsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sportSelection)).EndInit();
            this.ResumeLayout(false);
        }

        private Syncfusion.Windows.Forms.Tools.MultiSelectionComboBox sportSelection;

        private System.Windows.Forms.CheckBox snrCheck;

        private Syncfusion.Windows.Forms.Tools.QuickCheckBoxReflectable quickCheckBoxReflectable1;

        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt ratingMinNumeric;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt ratingMaxNumeric;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt maxOddsNumeric;

        private System.Windows.Forms.Panel panel1;

        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt minOddsNumeric;

        private System.Windows.Forms.Button bookmakerDeselectButton;

        private Syncfusion.Windows.Forms.Tools.MultiSelectionComboBox multiBookmaker;

        private System.Windows.Forms.Button btnLoadConfig;

        private System.Windows.Forms.ComboBox ConfigSelection;

        private System.Windows.Forms.DataGridView tblMatchedResults;

        #endregion
    }
}