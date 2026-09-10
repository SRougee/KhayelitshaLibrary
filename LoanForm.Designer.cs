namespace KhayelitshaLibrary
{
    partial class LoanForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblLoanTitle;

        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.ComboBox cmbMember;

        private System.Windows.Forms.Label lblBookCopy;
        private System.Windows.Forms.ComboBox cmbBookCopy;

        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.ComboBox cmbStaff;

        private System.Windows.Forms.Label lblLoanDate;
        private System.Windows.Forms.DateTimePicker dtpLoanDate;

        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;

        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.Label lblBooks;
        private System.Windows.Forms.DataGridView dgvAvailableBooks;

        private System.Windows.Forms.Label lblCurrentLoans;
        private System.Windows.Forms.DataGridView dgvCurrentLoans;

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
            this.lblLoanTitle = new System.Windows.Forms.Label();
            this.lblMember = new System.Windows.Forms.Label();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.lblBookCopy = new System.Windows.Forms.Label();
            this.cmbBookCopy = new System.Windows.Forms.ComboBox();
            this.lblStaff = new System.Windows.Forms.Label();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.lblLoanDate = new System.Windows.Forms.Label();
            this.dtpLoanDate = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblBooks = new System.Windows.Forms.Label();
            this.dgvAvailableBooks = new System.Windows.Forms.DataGridView();
            this.lblCurrentLoans = new System.Windows.Forms.Label();
            this.dgvCurrentLoans = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentLoans)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLoanTitle
            // 
            this.lblLoanTitle.AutoSize = true;
            this.lblLoanTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblLoanTitle.Location = new System.Drawing.Point(51, 19);
            this.lblLoanTitle.Name = "lblLoanTitle";
            this.lblLoanTitle.Size = new System.Drawing.Size(443, 36);
            this.lblLoanTitle.TabIndex = 0;
            this.lblLoanTitle.Text = "Loan and Return Management";
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Location = new System.Drawing.Point(54, 139);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(60, 16);
            this.lblMember.TabIndex = 1;
            this.lblMember.Text = "Member:";
            // 
            // cmbMember
            // 
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMember.FormattingEnabled = true;
            this.cmbMember.Location = new System.Drawing.Point(194, 139);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(300, 24);
            this.cmbMember.TabIndex = 2;
            // 
            // lblBookCopy
            // 
            this.lblBookCopy.AutoSize = true;
            this.lblBookCopy.Location = new System.Drawing.Point(54, 184);
            this.lblBookCopy.Name = "lblBookCopy";
            this.lblBookCopy.Size = new System.Drawing.Size(102, 16);
            this.lblBookCopy.TabIndex = 3;
            this.lblBookCopy.Text = "Available Book:";
            // 
            // cmbBookCopy
            // 
            this.cmbBookCopy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBookCopy.FormattingEnabled = true;
            this.cmbBookCopy.Location = new System.Drawing.Point(194, 184);
            this.cmbBookCopy.Name = "cmbBookCopy";
            this.cmbBookCopy.Size = new System.Drawing.Size(300, 24);
            this.cmbBookCopy.TabIndex = 4;
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(54, 229);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(36, 16);
            this.lblStaff.TabIndex = 5;
            this.lblStaff.Text = "Staff:";
            // 
            // cmbStaff
            // 
            this.cmbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(194, 229);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(300, 24);
            this.cmbStaff.TabIndex = 6;
            // 
            // lblLoanDate
            // 
            this.lblLoanDate.AutoSize = true;
            this.lblLoanDate.Location = new System.Drawing.Point(54, 274);
            this.lblLoanDate.Name = "lblLoanDate";
            this.lblLoanDate.Size = new System.Drawing.Size(72, 16);
            this.lblLoanDate.TabIndex = 7;
            this.lblLoanDate.Text = "Loan Date:";
            // 
            // dtpLoanDate
            // 
            this.dtpLoanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLoanDate.Location = new System.Drawing.Point(194, 274);
            this.dtpLoanDate.Name = "dtpLoanDate";
            this.dtpLoanDate.Size = new System.Drawing.Size(150, 22);
            this.dtpLoanDate.TabIndex = 8;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(54, 319);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(67, 16);
            this.lblDueDate.TabIndex = 9;
            this.lblDueDate.Text = "Due Date:";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(194, 319);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(150, 22);
            this.dtpDueDate.TabIndex = 10;
            // 
            // btnIssue
            // 
            this.btnIssue.Location = new System.Drawing.Point(90, 371);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(110, 40);
            this.btnIssue.TabIndex = 11;
            this.btnIssue.Text = "Issue Book";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(210, 371);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(110, 40);
            this.btnReturn.TabIndex = 12;
            this.btnReturn.Text = "Return Book";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(330, 371);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 40);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblBooks
            // 
            this.lblBooks.AutoSize = true;
            this.lblBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblBooks.Location = new System.Drawing.Point(521, 19);
            this.lblBooks.Name = "lblBooks";
            this.lblBooks.Size = new System.Drawing.Size(167, 25);
            this.lblBooks.TabIndex = 14;
            this.lblBooks.Text = "Available Books";
            // 
            // dgvAvailableBooks
            // 
            this.dgvAvailableBooks.AllowUserToAddRows = false;
            this.dgvAvailableBooks.AllowUserToDeleteRows = false;
            this.dgvAvailableBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailableBooks.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAvailableBooks.ColumnHeadersHeight = 29;
            this.dgvAvailableBooks.Location = new System.Drawing.Point(521, 54);
            this.dgvAvailableBooks.MultiSelect = false;
            this.dgvAvailableBooks.Name = "dgvAvailableBooks";
            this.dgvAvailableBooks.ReadOnly = true;
            this.dgvAvailableBooks.RowHeadersWidth = 51;
            this.dgvAvailableBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableBooks.Size = new System.Drawing.Size(700, 270);
            this.dgvAvailableBooks.TabIndex = 15;
            this.dgvAvailableBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAvailableBooks_CellClick);
            // 
            // lblCurrentLoans
            // 
            this.lblCurrentLoans.AutoSize = true;
            this.lblCurrentLoans.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblCurrentLoans.Location = new System.Drawing.Point(521, 349);
            this.lblCurrentLoans.Name = "lblCurrentLoans";
            this.lblCurrentLoans.Size = new System.Drawing.Size(250, 25);
            this.lblCurrentLoans.TabIndex = 16;
            this.lblCurrentLoans.Text = "Books Currently on Loan";
            // 
            // dgvCurrentLoans
            // 
            this.dgvCurrentLoans.AllowUserToAddRows = false;
            this.dgvCurrentLoans.AllowUserToDeleteRows = false;
            this.dgvCurrentLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentLoans.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCurrentLoans.ColumnHeadersHeight = 29;
            this.dgvCurrentLoans.Location = new System.Drawing.Point(521, 384);
            this.dgvCurrentLoans.MultiSelect = false;
            this.dgvCurrentLoans.Name = "dgvCurrentLoans";
            this.dgvCurrentLoans.ReadOnly = true;
            this.dgvCurrentLoans.RowHeadersWidth = 51;
            this.dgvCurrentLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentLoans.Size = new System.Drawing.Size(700, 300);
            this.dgvCurrentLoans.TabIndex = 17;
            this.dgvCurrentLoans.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCurrentLoans_CellClick);
            // 
            // LoanForm
            // 
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.lblLoanTitle);
            this.Controls.Add(this.lblMember);
            this.Controls.Add(this.cmbMember);
            this.Controls.Add(this.lblBookCopy);
            this.Controls.Add(this.cmbBookCopy);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.lblLoanDate);
            this.Controls.Add(this.dtpLoanDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblBooks);
            this.Controls.Add(this.dgvAvailableBooks);
            this.Controls.Add(this.lblCurrentLoans);
            this.Controls.Add(this.dgvCurrentLoans);
            this.Name = "LoanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan and Return Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentLoans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}