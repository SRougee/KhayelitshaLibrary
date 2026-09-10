namespace KhayelitshaLibrary
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblMemberSection;
        private System.Windows.Forms.TextBox txtMemberSearch;
        private System.Windows.Forms.Button btnSearchMembers;
        private System.Windows.Forms.Button btnClearMemberSearch;
        private System.Windows.Forms.DataGridView dgvMembers;

        private System.Windows.Forms.Label lblBookSection;
        private System.Windows.Forms.TextBox txtBookSearch;
        private System.Windows.Forms.Button btnSearchBooks;
        private System.Windows.Forms.Button btnClearBookSearch;
        private System.Windows.Forms.DataGridView dgvBooks;

        private System.Windows.Forms.Label lblLoanSection;
        private System.Windows.Forms.Label lblLoanFilter;
        private System.Windows.Forms.ComboBox cmbLoanFilter;
        private System.Windows.Forms.DataGridView dgvLoans;

        private System.Windows.Forms.Label lblOverdueSection;
        private System.Windows.Forms.DataGridView dgvOverdue;

        private System.Windows.Forms.Label lblSummarySection;
        private System.Windows.Forms.DataGridView dgvSummary;

        private System.Windows.Forms.Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMemberSection = new System.Windows.Forms.Label();
            this.txtMemberSearch = new System.Windows.Forms.TextBox();
            this.btnSearchMembers = new System.Windows.Forms.Button();
            this.btnClearMemberSearch = new System.Windows.Forms.Button();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.lblBookSection = new System.Windows.Forms.Label();
            this.txtBookSearch = new System.Windows.Forms.TextBox();
            this.btnSearchBooks = new System.Windows.Forms.Button();
            this.btnClearBookSearch = new System.Windows.Forms.Button();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.lblLoanSection = new System.Windows.Forms.Label();
            this.lblLoanFilter = new System.Windows.Forms.Label();
            this.cmbLoanFilter = new System.Windows.Forms.ComboBox();
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            this.lblOverdueSection = new System.Windows.Forms.Label();
            this.dgvOverdue = new System.Windows.Forms.DataGridView();
            this.lblSummarySection = new System.Windows.Forms.Label();
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(42, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(406, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Library Reports and Search";
            // 
            // lblMemberSection
            // 
            this.lblMemberSection.AutoSize = true;
            this.lblMemberSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblMemberSection.Location = new System.Drawing.Point(42, 67);
            this.lblMemberSection.Name = "lblMemberSection";
            this.lblMemberSection.Size = new System.Drawing.Size(165, 25);
            this.lblMemberSection.TabIndex = 2;
            this.lblMemberSection.Text = "Member Search";
            // 
            // txtMemberSearch
            // 
            this.txtMemberSearch.Location = new System.Drawing.Point(42, 102);
            this.txtMemberSearch.Name = "txtMemberSearch";
            this.txtMemberSearch.Size = new System.Drawing.Size(220, 22);
            this.txtMemberSearch.TabIndex = 3;
            // 
            // btnSearchMembers
            // 
            this.btnSearchMembers.Location = new System.Drawing.Point(272, 100);
            this.btnSearchMembers.Name = "btnSearchMembers";
            this.btnSearchMembers.Size = new System.Drawing.Size(90, 28);
            this.btnSearchMembers.TabIndex = 4;
            this.btnSearchMembers.Text = "Search";
            this.btnSearchMembers.UseVisualStyleBackColor = true;
            this.btnSearchMembers.Click += new System.EventHandler(this.btnSearchMembers_Click);
            // 
            // btnClearMemberSearch
            // 
            this.btnClearMemberSearch.Location = new System.Drawing.Point(367, 100);
            this.btnClearMemberSearch.Name = "btnClearMemberSearch";
            this.btnClearMemberSearch.Size = new System.Drawing.Size(90, 28);
            this.btnClearMemberSearch.TabIndex = 5;
            this.btnClearMemberSearch.Text = "Clear";
            this.btnClearMemberSearch.UseVisualStyleBackColor = true;
            this.btnClearMemberSearch.Click += new System.EventHandler(this.btnClearMemberSearch_Click);
            // 
            // dgvMembers
            // 
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMembers.ColumnHeadersHeight = 29;
            this.dgvMembers.Location = new System.Drawing.Point(42, 137);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.RowHeadersWidth = 51;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new System.Drawing.Size(559, 136);
            this.dgvMembers.TabIndex = 6;
            // 
            // lblBookSection
            // 
            this.lblBookSection.AutoSize = true;
            this.lblBookSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblBookSection.Location = new System.Drawing.Point(630, 67);
            this.lblBookSection.Name = "lblBookSection";
            this.lblBookSection.Size = new System.Drawing.Size(136, 25);
            this.lblBookSection.TabIndex = 7;
            this.lblBookSection.Text = "Book Search";
            // 
            // txtBookSearch
            // 
            this.txtBookSearch.Location = new System.Drawing.Point(630, 102);
            this.txtBookSearch.Name = "txtBookSearch";
            this.txtBookSearch.Size = new System.Drawing.Size(220, 22);
            this.txtBookSearch.TabIndex = 8;
            // 
            // btnSearchBooks
            // 
            this.btnSearchBooks.Location = new System.Drawing.Point(860, 100);
            this.btnSearchBooks.Name = "btnSearchBooks";
            this.btnSearchBooks.Size = new System.Drawing.Size(90, 28);
            this.btnSearchBooks.TabIndex = 9;
            this.btnSearchBooks.Text = "Search";
            this.btnSearchBooks.UseVisualStyleBackColor = true;
            this.btnSearchBooks.Click += new System.EventHandler(this.btnSearchBooks_Click);
            // 
            // btnClearBookSearch
            // 
            this.btnClearBookSearch.Location = new System.Drawing.Point(955, 100);
            this.btnClearBookSearch.Name = "btnClearBookSearch";
            this.btnClearBookSearch.Size = new System.Drawing.Size(90, 28);
            this.btnClearBookSearch.TabIndex = 10;
            this.btnClearBookSearch.Text = "Clear";
            this.btnClearBookSearch.UseVisualStyleBackColor = true;
            this.btnClearBookSearch.Click += new System.EventHandler(this.btnClearBookSearch_Click);
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBooks.ColumnHeadersHeight = 29;
            this.dgvBooks.Location = new System.Drawing.Point(630, 137);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersWidth = 51;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(600, 136);
            this.dgvBooks.TabIndex = 11;
            // 
            // lblLoanSection
            // 
            this.lblLoanSection.AutoSize = true;
            this.lblLoanSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoanSection.Location = new System.Drawing.Point(37, 294);
            this.lblLoanSection.Name = "lblLoanSection";
            this.lblLoanSection.Size = new System.Drawing.Size(129, 25);
            this.lblLoanSection.TabIndex = 12;
            this.lblLoanSection.Text = "Loan Report";
            // 
            // lblLoanFilter
            // 
            this.lblLoanFilter.AutoSize = true;
            this.lblLoanFilter.Location = new System.Drawing.Point(37, 329);
            this.lblLoanFilter.Name = "lblLoanFilter";
            this.lblLoanFilter.Size = new System.Drawing.Size(39, 16);
            this.lblLoanFilter.TabIndex = 13;
            this.lblLoanFilter.Text = "Filter:";
            // 
            // cmbLoanFilter
            // 
            this.cmbLoanFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoanFilter.FormattingEnabled = true;
            this.cmbLoanFilter.Items.AddRange(new object[] {
            "All",
            "Active",
            "Returned",
            "Overdue"});
            this.cmbLoanFilter.Location = new System.Drawing.Point(87, 326);
            this.cmbLoanFilter.Name = "cmbLoanFilter";
            this.cmbLoanFilter.Size = new System.Drawing.Size(150, 24);
            this.cmbLoanFilter.TabIndex = 14;
            this.cmbLoanFilter.SelectedIndexChanged += new System.EventHandler(this.cmbLoanFilter_SelectedIndexChanged);
            // 
            // dgvLoans
            // 
            this.dgvLoans.AllowUserToAddRows = false;
            this.dgvLoans.AllowUserToDeleteRows = false;
            this.dgvLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoans.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLoans.ColumnHeadersHeight = 29;
            this.dgvLoans.Location = new System.Drawing.Point(37, 364);
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.ReadOnly = true;
            this.dgvLoans.RowHeadersWidth = 51;
            this.dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoans.Size = new System.Drawing.Size(1193, 145);
            this.dgvLoans.TabIndex = 15;
            // 
            // lblOverdueSection
            // 
            this.lblOverdueSection.AutoSize = true;
            this.lblOverdueSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblOverdueSection.Location = new System.Drawing.Point(37, 554);
            this.lblOverdueSection.Name = "lblOverdueSection";
            this.lblOverdueSection.Size = new System.Drawing.Size(161, 25);
            this.lblOverdueSection.TabIndex = 16;
            this.lblOverdueSection.Text = "Overdue Books";
            // 
            // dgvOverdue
            // 
            this.dgvOverdue.AllowUserToAddRows = false;
            this.dgvOverdue.AllowUserToDeleteRows = false;
            this.dgvOverdue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOverdue.ColumnHeadersHeight = 29;
            this.dgvOverdue.Location = new System.Drawing.Point(37, 589);
            this.dgvOverdue.Name = "dgvOverdue";
            this.dgvOverdue.ReadOnly = true;
            this.dgvOverdue.RowHeadersWidth = 51;
            this.dgvOverdue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOverdue.Size = new System.Drawing.Size(564, 130);
            this.dgvOverdue.TabIndex = 17;
            // 
            // lblSummarySection
            // 
            this.lblSummarySection.AutoSize = true;
            this.lblSummarySection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblSummarySection.Location = new System.Drawing.Point(630, 559);
            this.lblSummarySection.Name = "lblSummarySection";
            this.lblSummarySection.Size = new System.Drawing.Size(192, 25);
            this.lblSummarySection.TabIndex = 18;
            this.lblSummarySection.Text = "Loans per Member";
            // 
            // dgvSummary
            // 
            this.dgvSummary.AllowUserToAddRows = false;
            this.dgvSummary.AllowUserToDeleteRows = false;
            this.dgvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSummary.ColumnHeadersHeight = 29;
            this.dgvSummary.Location = new System.Drawing.Point(630, 594);
            this.dgvSummary.Name = "dgvSummary";
            this.dgvSummary.ReadOnly = true;
            this.dgvSummary.RowHeadersWidth = 51;
            this.dgvSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSummary.Size = new System.Drawing.Size(600, 130);
            this.dgvSummary.TabIndex = 19;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1100, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ReportsForm
            // 
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblMemberSection);
            this.Controls.Add(this.txtMemberSearch);
            this.Controls.Add(this.btnSearchMembers);
            this.Controls.Add(this.btnClearMemberSearch);
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.lblBookSection);
            this.Controls.Add(this.txtBookSearch);
            this.Controls.Add(this.btnSearchBooks);
            this.Controls.Add(this.btnClearBookSearch);
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.lblLoanSection);
            this.Controls.Add(this.lblLoanFilter);
            this.Controls.Add(this.cmbLoanFilter);
            this.Controls.Add(this.dgvLoans);
            this.Controls.Add(this.lblOverdueSection);
            this.Controls.Add(this.dgvOverdue);
            this.Controls.Add(this.lblSummarySection);
            this.Controls.Add(this.dgvSummary);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Reports and Search";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}