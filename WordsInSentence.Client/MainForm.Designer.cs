namespace WordsInSentence.Client
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.sentenceBox = new System.Windows.Forms.RichTextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.labelResults = new System.Windows.Forms.Label();
            this.analyzerProgressBar = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanelMainForm = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.tableLayoutPanelMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // sentenceBox
            // 
            this.sentenceBox.Location = new System.Drawing.Point(5, 5);
            this.sentenceBox.Name = "sentenceBox";
            this.sentenceBox.Size = new System.Drawing.Size(1139, 152);
            this.sentenceBox.TabIndex = 0;
            this.sentenceBox.Text = "";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnalyze.Location = new System.Drawing.Point(1150, 122);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(104, 35);
            this.btnAnalyze.TabIndex = 1;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Location = new System.Drawing.Point(12, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(154, 17);
            this.labelHeader.TabIndex = 2;
            this.labelHeader.Text = "Please enter text below";
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Location = new System.Drawing.Point(5, 241);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.RowTemplate.Height = 24;
            this.dataGridViewResult.Size = new System.Drawing.Size(537, 150);
            this.dataGridViewResult.TabIndex = 3;
            // 
            // labelResults
            // 
            this.labelResults.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelResults.AutoSize = true;
            this.labelResults.Location = new System.Drawing.Point(5, 210);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(55, 17);
            this.labelResults.TabIndex = 4;
            this.labelResults.Text = "Results";
            // 
            // analyzerProgressBar
            // 
            this.analyzerProgressBar.Location = new System.Drawing.Point(5, 163);
            this.analyzerProgressBar.Name = "analyzerProgressBar";
            this.analyzerProgressBar.Size = new System.Drawing.Size(1139, 32);
            this.analyzerProgressBar.TabIndex = 5;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(1150, 163);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(3);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Padding = new System.Windows.Forms.Padding(2);
            this.labelStatus.Size = new System.Drawing.Size(84, 21);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "Status : OK";
            this.labelStatus.Click += new System.EventHandler(this.labelStatus_Click);
            // 
            // tableLayoutPanelMainForm
            // 
            this.tableLayoutPanelMainForm.ColumnCount = 2;
            this.tableLayoutPanelMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMainForm.Controls.Add(this.sentenceBox, 0, 0);
            this.tableLayoutPanelMainForm.Controls.Add(this.dataGridViewResult, 0, 3);
            this.tableLayoutPanelMainForm.Controls.Add(this.analyzerProgressBar, 0, 1);
            this.tableLayoutPanelMainForm.Controls.Add(this.labelResults, 0, 2);
            this.tableLayoutPanelMainForm.Controls.Add(this.btnAnalyze, 1, 0);
            this.tableLayoutPanelMainForm.Controls.Add(this.labelStatus, 1, 1);
            this.tableLayoutPanelMainForm.Location = new System.Drawing.Point(15, 39);
            this.tableLayoutPanelMainForm.Name = "tableLayoutPanelMainForm";
            this.tableLayoutPanelMainForm.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelMainForm.RowCount = 4;
            this.tableLayoutPanelMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMainForm.Size = new System.Drawing.Size(1531, 399);
            this.tableLayoutPanelMainForm.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 465);
            this.Controls.Add(this.tableLayoutPanelMainForm);
            this.Controls.Add(this.labelHeader);
            this.MaximumSize = new System.Drawing.Size(1580, 512);
            this.Name = "MainForm";
            this.Text = "Word in sentence";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.tableLayoutPanelMainForm.ResumeLayout(false);
            this.tableLayoutPanelMainForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox sentenceBox;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.Label labelResults;
        private System.Windows.Forms.ProgressBar analyzerProgressBar;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainForm;
    }
}

