namespace exam
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtMask = new TextBox();
            cmbDrives = new ComboBox();
            lstResults = new ListBox();
            progressBar = new ProgressBar();
            btnSearch = new Button();
            SuspendLayout();
            // 
            // txtMask
            // 
            txtMask.Location = new Point(12, 81);
            txtMask.Name = "txtMask";
            txtMask.Size = new Size(246, 23);
            txtMask.TabIndex = 0;

            // 
            // cmbDrives
            // 
            cmbDrives.FormattingEnabled = true;
            cmbDrives.Location = new Point(12, 110);
            cmbDrives.Name = "cmbDrives";
            cmbDrives.Size = new Size(114, 23);
            cmbDrives.TabIndex = 1;

            // 
            // lstResults
            // 
            lstResults.FormattingEnabled = true;
            lstResults.ItemHeight = 15;
            lstResults.Location = new Point(264, 81);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(698, 199);
            lstResults.TabIndex = 2;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 139);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(246, 24);
            progressBar.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(183, 169);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "button1";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 650);
            Controls.Add(btnSearch);
            Controls.Add(progressBar);
            Controls.Add(lstResults);
            Controls.Add(cmbDrives);
            Controls.Add(txtMask);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMask;
        private ComboBox cmbDrives;
        private ListBox lstResults;
        private ProgressBar progressBar;
        private Button btnSearch;
    }
}
