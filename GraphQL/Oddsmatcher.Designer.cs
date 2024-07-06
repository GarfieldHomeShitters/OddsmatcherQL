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
            this.tblMatchedResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tblMatchedResults)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMatchedResults
            // 
            this.tblMatchedResults.AllowUserToAddRows = false;
            this.tblMatchedResults.AllowUserToDeleteRows = false;
            this.tblMatchedResults.AllowUserToOrderColumns = true;
            this.tblMatchedResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblMatchedResults.Location = new System.Drawing.Point(12, 68);
            this.tblMatchedResults.Name = "tblMatchedResults";
            this.tblMatchedResults.Size = new System.Drawing.Size(762, 370);
            this.tblMatchedResults.TabIndex = 0;
            // 
            // Oddsmatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblMatchedResults);
            this.Name = "Oddsmatcher";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tblMatchedResults)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView tblMatchedResults;

        #endregion
    }
}