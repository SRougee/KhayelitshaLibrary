namespace KhayelitshaLibrary
{
    partial class BookForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Label lblBookTitleSection;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;

        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;

        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox txtISBN;

        private System.Windows.Forms.Label lblPublishedYear;
        private System.Windows.Forms.NumericUpDown nudPublishedYear;

        private System.Windows.Forms.Button btnAddTitle;
        private System.Windows.Forms.Button btnUpdateTitle;
        private System.Windows.Forms.Button btnDeleteTitle;
        private System.Windows.Forms.Button btnClearTitle;

        private System.Windows.Forms.DataGridView dgvBookTitles;

        private System.Windows.Forms.Label lblCopySection;
        private System.Windows.Forms.Label lblCopyID;
        private System.Windows.Forms.TextBox txtCopyID;

        private System.Windows.Forms.Label lblCopyBookTitle;
        private System.Windows.Forms.ComboBox cmbBookTitle;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;

        private System.Windows.Forms.Button btnAddCopy;
        private System.Windows.Forms.Button btnUpdateCopy;
        private System.Windows.Forms.Button btnDeleteCopy;

        private System.Windows.Forms.DataGridView dgvBookCopies;

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
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.lblBookTitleSection = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblISBN = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.lblPublishedYear = new System.Windows.Forms.Label();
            this.nudPublishedYear = new System.Windows.Forms.NumericUpDown();
            this.btnAddTitle = new System.Windows.Forms.Button();
            this.btnUpdateTitle = new System.Windows.Forms.Button();
            this.btnDeleteTitle = new System.Windows.Forms.Button();
            this.btnClearTitle = new System.Windows.Forms.Button();
            this.dgvBookTitles = new System.Windows.Forms.DataGridView();
            this.lblCopySection = new System.Windows.Forms.Label();
            this.lblCopyID = new System.Windows.Forms.Label();
            this.txtCopyID = new System.Windows.Forms.TextBox();
            this.lblCopyBookTitle = new System.Windows.Forms.Label();
            this.cmbBookTitle = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnAddCopy = new System.Windows.Forms.Button();
            this.btnUpdateCopy = new System.Windows.Forms.Button();
            this.btnDeleteCopy = new System.Windows.Forms.Button();
            this.dgvBookCopies = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudPublishedYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookTitles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblBookTitle.Location = new System.Drawing.Point(80, 40);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(278, 36);
            this.lblBookTitle.TabIndex = 0;
            this.lblBookTitle.Text = "Book Management";
            // 
            // lblBookTitleSection
            // 
            this.lblBookTitleSection.AutoSize = true;
            this.lblBookTitleSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblBookTitleSection.Location = new System.Drawing.Point(79, 128);
            this.lblBookTitleSection.Name = "lblBookTitleSection";
            this.lblBookTitleSection.Size = new System.Drawing.Size(222, 25);
            this.lblBookTitleSection.TabIndex = 1;
            this.lblBookTitleSection.Text = "Book Title Information";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(79, 168);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(36, 16);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(199, 165);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(280, 22);
            this.txtTitle.TabIndex = 3;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(79, 203);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(48, 16);
            this.lblAuthor.TabIndex = 4;
            this.lblAuthor.Text = "Author:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(199, 200);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(280, 22);
            this.txtAuthor.TabIndex = 5;
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(79, 238);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(41, 16);
            this.lblISBN.TabIndex = 6;
            this.lblISBN.Text = "ISBN:";
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(199, 235);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(280, 22);
            this.txtISBN.TabIndex = 7;
            // 
            // lblPublishedYear
            // 
            this.lblPublishedYear.AutoSize = true;
            this.lblPublishedYear.Location = new System.Drawing.Point(79, 273);
            this.lblPublishedYear.Name = "lblPublishedYear";
            this.lblPublishedYear.Size = new System.Drawing.Size(108, 16);
            this.lblPublishedYear.TabIndex = 8;
            this.lblPublishedYear.Text = "Publication Year:";
            // 
            // nudPublishedYear
            // 
            this.nudPublishedYear.Location = new System.Drawing.Point(199, 270);
            this.nudPublishedYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nudPublishedYear.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPublishedYear.Name = "nudPublishedYear";
            this.nudPublishedYear.Size = new System.Drawing.Size(120, 22);
            this.nudPublishedYear.TabIndex = 9;
            this.nudPublishedYear.Value = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            // 
            // btnAddTitle
            // 
            this.btnAddTitle.Location = new System.Drawing.Point(79, 313);
            this.btnAddTitle.Name = "btnAddTitle";
            this.btnAddTitle.Size = new System.Drawing.Size(90, 35);
            this.btnAddTitle.TabIndex = 10;
            this.btnAddTitle.Text = "Add";
            this.btnAddTitle.UseVisualStyleBackColor = true;
            this.btnAddTitle.Click += new System.EventHandler(this.btnAddTitle_Click);
            // 
            // btnUpdateTitle
            // 
            this.btnUpdateTitle.Location = new System.Drawing.Point(179, 313);
            this.btnUpdateTitle.Name = "btnUpdateTitle";
            this.btnUpdateTitle.Size = new System.Drawing.Size(90, 35);
            this.btnUpdateTitle.TabIndex = 11;
            this.btnUpdateTitle.Text = "Update";
            this.btnUpdateTitle.UseVisualStyleBackColor = true;
            this.btnUpdateTitle.Click += new System.EventHandler(this.btnUpdateTitle_Click);
            // 
            // btnDeleteTitle
            // 
            this.btnDeleteTitle.Location = new System.Drawing.Point(279, 313);
            this.btnDeleteTitle.Name = "btnDeleteTitle";
            this.btnDeleteTitle.Size = new System.Drawing.Size(90, 35);
            this.btnDeleteTitle.TabIndex = 12;
            this.btnDeleteTitle.Text = "Delete";
            this.btnDeleteTitle.UseVisualStyleBackColor = true;
            this.btnDeleteTitle.Click += new System.EventHandler(this.btnDeleteTitle_Click);
            // 
            // btnClearTitle
            // 
            this.btnClearTitle.Location = new System.Drawing.Point(379, 313);
            this.btnClearTitle.Name = "btnClearTitle";
            this.btnClearTitle.Size = new System.Drawing.Size(90, 35);
            this.btnClearTitle.TabIndex = 13;
            this.btnClearTitle.Text = "Clear";
            this.btnClearTitle.UseVisualStyleBackColor = true;
            this.btnClearTitle.Click += new System.EventHandler(this.btnClearTitle_Click);
            // 
            // dgvBookTitles
            // 
            this.dgvBookTitles.AllowUserToAddRows = false;
            this.dgvBookTitles.AllowUserToDeleteRows = false;
            this.dgvBookTitles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookTitles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBookTitles.ColumnHeadersHeight = 29;
            this.dgvBookTitles.Location = new System.Drawing.Point(519, 128);
            this.dgvBookTitles.MultiSelect = false;
            this.dgvBookTitles.Name = "dgvBookTitles";
            this.dgvBookTitles.ReadOnly = true;
            this.dgvBookTitles.RowHeadersWidth = 51;
            this.dgvBookTitles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookTitles.Size = new System.Drawing.Size(690, 220);
            this.dgvBookTitles.TabIndex = 14;
            this.dgvBookTitles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookTitles_CellClick);
            // 
            // lblCopySection
            // 
            this.lblCopySection.AutoSize = true;
            this.lblCopySection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblCopySection.Location = new System.Drawing.Point(79, 393);
            this.lblCopySection.Name = "lblCopySection";
            this.lblCopySection.Size = new System.Drawing.Size(336, 25);
            this.lblCopySection.TabIndex = 15;
            this.lblCopySection.Text = "Physical Book Copy Management";
            // 
            // lblCopyID
            // 
            this.lblCopyID.AutoSize = true;
            this.lblCopyID.Location = new System.Drawing.Point(79, 438);
            this.lblCopyID.Name = "lblCopyID";
            this.lblCopyID.Size = new System.Drawing.Size(58, 16);
            this.lblCopyID.TabIndex = 16;
            this.lblCopyID.Text = "Copy ID:";
            // 
            // txtCopyID
            // 
            this.txtCopyID.Location = new System.Drawing.Point(199, 435);
            this.txtCopyID.Name = "txtCopyID";
            this.txtCopyID.ReadOnly = true;
            this.txtCopyID.Size = new System.Drawing.Size(120, 22);
            this.txtCopyID.TabIndex = 17;
            // 
            // lblCopyBookTitle
            // 
            this.lblCopyBookTitle.AutoSize = true;
            this.lblCopyBookTitle.Location = new System.Drawing.Point(79, 478);
            this.lblCopyBookTitle.Name = "lblCopyBookTitle";
            this.lblCopyBookTitle.Size = new System.Drawing.Size(71, 16);
            this.lblCopyBookTitle.TabIndex = 18;
            this.lblCopyBookTitle.Text = "Book Title:";
            // 
            // cmbBookTitle
            // 
            this.cmbBookTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBookTitle.FormattingEnabled = true;
            this.cmbBookTitle.Location = new System.Drawing.Point(199, 475);
            this.cmbBookTitle.Name = "cmbBookTitle";
            this.cmbBookTitle.Size = new System.Drawing.Size(280, 24);
            this.cmbBookTitle.TabIndex = 19;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(79, 518);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 16);
            this.lblStatus.TabIndex = 20;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(199, 515);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 24);
            this.cmbStatus.TabIndex = 21;
            // 
            // btnAddCopy
            // 
            this.btnAddCopy.Location = new System.Drawing.Point(79, 558);
            this.btnAddCopy.Name = "btnAddCopy";
            this.btnAddCopy.Size = new System.Drawing.Size(100, 35);
            this.btnAddCopy.TabIndex = 22;
            this.btnAddCopy.Text = "Add Copy";
            this.btnAddCopy.UseVisualStyleBackColor = true;
            this.btnAddCopy.Click += new System.EventHandler(this.btnAddCopy_Click);
            // 
            // btnUpdateCopy
            // 
            this.btnUpdateCopy.Location = new System.Drawing.Point(189, 558);
            this.btnUpdateCopy.Name = "btnUpdateCopy";
            this.btnUpdateCopy.Size = new System.Drawing.Size(100, 35);
            this.btnUpdateCopy.TabIndex = 23;
            this.btnUpdateCopy.Text = "Update";
            this.btnUpdateCopy.UseVisualStyleBackColor = true;
            this.btnUpdateCopy.Click += new System.EventHandler(this.btnUpdateCopy_Click);
            // 
            // btnDeleteCopy
            // 
            this.btnDeleteCopy.Location = new System.Drawing.Point(299, 558);
            this.btnDeleteCopy.Name = "btnDeleteCopy";
            this.btnDeleteCopy.Size = new System.Drawing.Size(100, 35);
            this.btnDeleteCopy.TabIndex = 24;
            this.btnDeleteCopy.Text = "Delete";
            this.btnDeleteCopy.UseVisualStyleBackColor = true;
            this.btnDeleteCopy.Click += new System.EventHandler(this.btnDeleteCopy_Click);
            // 
            // dgvBookCopies
            // 
            this.dgvBookCopies.AllowUserToAddRows = false;
            this.dgvBookCopies.AllowUserToDeleteRows = false;
            this.dgvBookCopies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookCopies.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBookCopies.ColumnHeadersHeight = 29;
            this.dgvBookCopies.Location = new System.Drawing.Point(519, 393);
            this.dgvBookCopies.MultiSelect = false;
            this.dgvBookCopies.Name = "dgvBookCopies";
            this.dgvBookCopies.ReadOnly = true;
            this.dgvBookCopies.RowHeadersWidth = 51;
            this.dgvBookCopies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookCopies.Size = new System.Drawing.Size(690, 250);
            this.dgvBookCopies.TabIndex = 25;
            this.dgvBookCopies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookCopies_CellClick);
            // 
            // BookForm
            // 
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.lblBookTitle);
            this.Controls.Add(this.lblBookTitleSection);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.lblPublishedYear);
            this.Controls.Add(this.nudPublishedYear);
            this.Controls.Add(this.btnAddTitle);
            this.Controls.Add(this.btnUpdateTitle);
            this.Controls.Add(this.btnDeleteTitle);
            this.Controls.Add(this.btnClearTitle);
            this.Controls.Add(this.dgvBookTitles);
            this.Controls.Add(this.lblCopySection);
            this.Controls.Add(this.lblCopyID);
            this.Controls.Add(this.txtCopyID);
            this.Controls.Add(this.lblCopyBookTitle);
            this.Controls.Add(this.cmbBookTitle);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnAddCopy);
            this.Controls.Add(this.btnUpdateCopy);
            this.Controls.Add(this.btnDeleteCopy);
            this.Controls.Add(this.dgvBookCopies);
            this.Name = "BookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Management";
            ((System.ComponentModel.ISupportInitialize)(this.nudPublishedYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookTitles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}