using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace KhayelitshaLibrary
{
    public partial class LoanForm : Form
    {
        public LoanForm()
        {
            InitializeComponent();

            dtpLoanDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddDays(14);

            LoadMembers();
            LoadAvailableBookCopies();
            LoadAvailableBooks();
            LoadStaff();
            LoadCurrentLoans();
        }

        private void LoanForm_Load(object sender, EventArgs e)
        {

        }

        
        // LOAD MEMBERS
        

        private void LoadMembers()
        {
            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            MemberID,
                            FullName
                        FROM Member
                        ORDER BY FullName";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        cmbMember.DataSource = table;
                        cmbMember.DisplayMember = "FullName";
                        cmbMember.ValueMember = "MemberID";
                        cmbMember.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load members.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // LOAD AVAILABLE BOOK COPIES INTO COMBOBOX
        

        private void LoadAvailableBookCopies()
        {
            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            BC.CopyID,
                            BC.BookTitleID,
                            BT.Title,
                            BC.Status,
                            'Copy ' +
                            CAST(BC.CopyID AS NVARCHAR(10)) +
                            ' - ' +
                            BT.Title +
                            ' (' +
                            BC.Status +
                            ')' AS CopyDescription
                        FROM BookCopy BC
                        INNER JOIN BookTitle BT
                            ON BC.BookTitleID = BT.BookTitleID
                        WHERE BC.Status = 'Available'
                        ORDER BY BT.Title, BC.CopyID";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        cmbBookCopy.DataSource = table;

                        cmbBookCopy.DisplayMember =
                            "CopyDescription";

                        cmbBookCopy.ValueMember =
                            "CopyID";

                        cmbBookCopy.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load available book copies.\n\n"
                    + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // LOAD AVAILABLE BOOKS TABLE
        

        private void LoadAvailableBooks()
        {
            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            BC.CopyID,
                            BT.Title,
                            BT.Author,
                            BC.Status
                        FROM BookCopy BC
                        INNER JOIN BookTitle BT
                            ON BC.BookTitleID = BT.BookTitleID
                        WHERE BC.Status = 'Available'
                        ORDER BY BT.Title, BC.CopyID";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvAvailableBooks.DataSource = table;

                        if (dgvAvailableBooks.Columns["CopyID"] != null)
                            dgvAvailableBooks.Columns["CopyID"].HeaderText =
                                "Copy ID";

                        if (dgvAvailableBooks.Columns["Title"] != null)
                            dgvAvailableBooks.Columns["Title"].HeaderText =
                                "Book Title";

                        if (dgvAvailableBooks.Columns["Author"] != null)
                            dgvAvailableBooks.Columns["Author"].HeaderText =
                                "Author";

                        if (dgvAvailableBooks.Columns["Status"] != null)
                            dgvAvailableBooks.Columns["Status"].HeaderText =
                                "Status";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load available books.\n\n"
                    + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // LOAD STAFF
        

        private void LoadStaff()
        {
            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            StaffID,
                            FullName
                        FROM Staff
                        ORDER BY FullName";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        cmbStaff.DataSource = table;
                        cmbStaff.DisplayMember = "FullName";
                        cmbStaff.ValueMember = "StaffID";
                        cmbStaff.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load staff members.\n\n"
                    + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // LOAD CURRENT LOANS TABLE
        

        private void LoadCurrentLoans()
        {
            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            L.LoanID,
                            L.MemberID,
                            M.FullName AS MemberName,
                            L.CopyID,
                            BT.Title AS BookTitle,
                            L.LoanDate,
                            L.DueDate
                        FROM Loan L
                        INNER JOIN Member M
                            ON L.MemberID = M.MemberID
                        INNER JOIN BookCopy BC
                            ON L.CopyID = BC.CopyID
                        INNER JOIN BookTitle BT
                            ON BC.BookTitleID = BT.BookTitleID
                        WHERE L.ReturnDate IS NULL
                        ORDER BY L.DueDate";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvCurrentLoans.DataSource = table;

                        if (dgvCurrentLoans.Columns["LoanID"] != null)
                            dgvCurrentLoans.Columns["LoanID"].HeaderText =
                                "Loan ID";

                        if (dgvCurrentLoans.Columns["MemberName"] != null)
                            dgvCurrentLoans.Columns["MemberName"].HeaderText =
                                "Member";

                        if (dgvCurrentLoans.Columns["CopyID"] != null)
                            dgvCurrentLoans.Columns["CopyID"].HeaderText =
                                "Copy ID";

                        if (dgvCurrentLoans.Columns["BookTitle"] != null)
                            dgvCurrentLoans.Columns["BookTitle"].HeaderText =
                                "Book";

                        if (dgvCurrentLoans.Columns["LoanDate"] != null)
                            dgvCurrentLoans.Columns["LoanDate"].HeaderText =
                                "Loan Date";

                        if (dgvCurrentLoans.Columns["DueDate"] != null)
                            dgvCurrentLoans.Columns["DueDate"].HeaderText =
                                "Due Date";

                        // MemberID is only needed by the program.
                        if (dgvCurrentLoans.Columns["MemberID"] != null)
                        {
                            dgvCurrentLoans.Columns["MemberID"].Visible =
                                false;
                        }

                        if (dgvCurrentLoans.Columns["LoanID"] != null)
                        {
                            dgvCurrentLoans.Columns["LoanID"].Visible =
                                true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load current loans.\n\n"
                    + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // ISSUE BOOK
        

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (cmbMember.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a member.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbMember.Focus();
                return;
            }

            if (cmbBookCopy.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select an available book copy.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbBookCopy.Focus();
                return;
            }

            if (cmbStaff.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a staff member.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbStaff.Focus();
                return;
            }

            if (dtpDueDate.Value.Date < dtpLoanDate.Value.Date)
            {
                MessageBox.Show(
                    "The due date cannot be before the loan date.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpDueDate.Focus();
                return;
            }

            int memberID =
                Convert.ToInt32(cmbMember.SelectedValue);

            int copyID =
                Convert.ToInt32(cmbBookCopy.SelectedValue);

            int staffID =
                Convert.ToInt32(cmbStaff.SelectedValue);

            DateTime loanDate =
                dtpLoanDate.Value.Date;

            DateTime dueDate =
                dtpDueDate.Value.Date;

            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    using (SqlTransaction transaction =
                           connection.BeginTransaction())
                    {
                        try
                        {
                            // -------------------------------------------------
                            // Verify copy still exists and is Available
                            // -------------------------------------------------

                            string statusQuery = @"
                                SELECT Status
                                FROM BookCopy
                                WHERE CopyID = @CopyID";

                            string currentStatus;

                            using (SqlCommand command =
                                   new SqlCommand(
                                       statusQuery,
                                       connection,
                                       transaction))
                            {
                                command.Parameters.Add(
                                    "@CopyID",
                                    SqlDbType.Int).Value = copyID;

                                object result =
                                    command.ExecuteScalar();

                                if (result == null)
                                {
                                    transaction.Rollback();

                                    MessageBox.Show(
                                        "The selected book copy "
                                        + "could not be found.",
                                        "Issue Book",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                    return;
                                }

                                currentStatus =
                                    result.ToString();
                            }

                            if (currentStatus != "Available")
                            {
                                transaction.Rollback();

                                MessageBox.Show(
                                    "This book copy is no longer available.",
                                    "Issue Book",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                LoadAvailableBookCopies();
                                LoadAvailableBooks();

                                return;
                            }

                            // -------------------------------------------------
                            // Prevent duplicate active loan
                            // -------------------------------------------------

                            string duplicateQuery = @"
                                SELECT COUNT(*)
                                FROM Loan
                                WHERE CopyID = @CopyID
                                AND ReturnDate IS NULL";

                            using (SqlCommand command =
                                   new SqlCommand(
                                       duplicateQuery,
                                       connection,
                                       transaction))
                            {
                                command.Parameters.Add(
                                    "@CopyID",
                                    SqlDbType.Int).Value = copyID;

                                int activeLoans =
                                    Convert.ToInt32(
                                        command.ExecuteScalar());

                                if (activeLoans > 0)
                                {
                                    transaction.Rollback();

                                    MessageBox.Show(
                                        "This book copy already has "
                                        + "an active loan.",
                                        "Issue Book",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                    LoadAvailableBookCopies();
                                    LoadAvailableBooks();

                                    return;
                                }
                            }

                            // -------------------------------------------------
                            // Insert loan
                            // -------------------------------------------------

                            string insertQuery = @"
                                INSERT INTO Loan
                                (
                                    MemberID,
                                    CopyID,
                                    StaffID,
                                    LoanDate,
                                    DueDate,
                                    ReturnDate
                                )
                                VALUES
                                (
                                    @MemberID,
                                    @CopyID,
                                    @StaffID,
                                    @LoanDate,
                                    @DueDate,
                                    NULL
                                )";

                            using (SqlCommand command =
                                   new SqlCommand(
                                       insertQuery,
                                       connection,
                                       transaction))
                            {
                                command.Parameters.Add(
                                    "@MemberID",
                                    SqlDbType.Int).Value = memberID;

                                command.Parameters.Add(
                                    "@CopyID",
                                    SqlDbType.Int).Value = copyID;

                                command.Parameters.Add(
                                    "@StaffID",
                                    SqlDbType.Int).Value = staffID;

                                command.Parameters.Add(
                                    "@LoanDate",
                                    SqlDbType.Date).Value = loanDate;

                                command.Parameters.Add(
                                    "@DueDate",
                                    SqlDbType.Date).Value = dueDate;

                                command.ExecuteNonQuery();
                            }

                            // -------------------------------------------------
                            // Change copy status
                            // -------------------------------------------------

                            string updateCopyQuery = @"
                                UPDATE BookCopy
                                SET Status = 'On Loan'
                                WHERE CopyID = @CopyID";

                            using (SqlCommand command =
                                   new SqlCommand(
                                       updateCopyQuery,
                                       connection,
                                       transaction))
                            {
                                command.Parameters.Add(
                                    "@CopyID",
                                    SqlDbType.Int).Value = copyID;

                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    "Book issued successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();

                LoadAvailableBookCopies();
                LoadAvailableBooks();
                LoadCurrentLoans();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to issue the book.\n\n"
                    + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // RETURN BOOK
        

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvCurrentLoans.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a book from the "
                    + "'Books Currently on Loan' table.",
                    "Return Book",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow row =
                dgvCurrentLoans.CurrentRow;

            if (!int.TryParse(
                row.Cells["LoanID"].Value?.ToString(),
                out int loanID))
            {
                MessageBox.Show(
                    "The selected loan is invalid.",
                    "Return Book",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(
                row.Cells["CopyID"].Value?.ToString(),
                out int copyID))
            {
                MessageBox.Show(
                    "The selected book copy is invalid.",
                    "Return Book",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string memberName =
                row.Cells["MemberName"].Value?.ToString()
                ?? "Unknown member";

            string bookTitle =
                row.Cells["BookTitle"].Value?.ToString()
                ?? "Unknown book";

            DialogResult result =
                MessageBox.Show(
                    "Return this book?\n\n"
                    + "Member: " + memberName + "\n"
                    + "Book: " + bookTitle + "\n"
                    + "Copy ID: " + copyID,
                    "Confirm Book Return",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    using (SqlTransaction transaction =
                           connection.BeginTransaction())
                    {
                        try
                        {
                            // -------------------------------------------------
                            // Mark loan as returned
                            // -------------------------------------------------

                            string returnQuery = @"
                                UPDATE Loan
                                SET ReturnDate = @ReturnDate
                                WHERE LoanID = @LoanID
                                AND ReturnDate IS NULL";

                            using (SqlCommand command =
                                   new SqlCommand(
                                       returnQuery,
                                       connection,
                                       transaction))
                            {
                                command.Parameters.Add(
                                    "@ReturnDate",
                                    SqlDbType.Date).Value =
                                    DateTime.Today;

                                command.Parameters.Add(
                                    "@LoanID",
                                    SqlDbType.Int).Value =
                                    loanID;

                                int rowsAffected =
                                    command.ExecuteNonQuery();

                                if (rowsAffected != 1)
                                {
                                    transaction.Rollback();

                                    MessageBox.Show(
                                        "The loan could not be returned. "
                                        + "It may already have been returned.",
                                        "Return Book",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                    LoadCurrentLoans();
                                    return;
                                }
                            }

                            // -------------------------------------------------
                            // Change copy back to Available
                            // -------------------------------------------------

                            string copyQuery = @"
                                UPDATE BookCopy
                                SET Status = 'Available'
                                WHERE CopyID = @CopyID";

                            using (SqlCommand command =
                                   new SqlCommand(
                                       copyQuery,
                                       connection,
                                       transaction))
                            {
                                command.Parameters.Add(
                                    "@CopyID",
                                    SqlDbType.Int).Value =
                                    copyID;

                                int rowsAffected =
                                    command.ExecuteNonQuery();

                                if (rowsAffected != 1)
                                {
                                    throw new Exception(
                                        "The book copy status "
                                        + "could not be updated.");
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    "Book returned successfully.\n\n"
                    + "The book is now Available.",
                    "Return Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();

                // IMPORTANT:
                // Refresh both tables immediately.
                LoadAvailableBookCopies();
                LoadAvailableBooks();
                LoadCurrentLoans();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to return the book.\n\n"
                    + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // CLICK AVAILABLE BOOK
        

        private void dgvAvailableBooks_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvAvailableBooks.Rows[e.RowIndex];

            if (row.Cells["CopyID"].Value == null)
                return;

            int copyID =
                Convert.ToInt32(
                    row.Cells["CopyID"].Value);

            for (int i = 0;
                 i < cmbBookCopy.Items.Count;
                 i++)
            {
                DataRowView item =
                    cmbBookCopy.Items[i] as DataRowView;

                if (item != null &&
                    Convert.ToInt32(item["CopyID"]) == copyID)
                {
                    cmbBookCopy.SelectedIndex = i;
                    break;
                }
            }
        }

        
        // CLICK CURRENT LOAN
        

        private void dgvCurrentLoans_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvCurrentLoans.Rows[e.RowIndex];

            // Select member
            if (row.Cells["MemberID"].Value != null)
            {
                int memberID =
                    Convert.ToInt32(
                        row.Cells["MemberID"].Value);

                cmbMember.SelectedValue =
                    memberID;
            }

            // Set loan date
            if (row.Cells["LoanDate"].Value != null &&
                row.Cells["LoanDate"].Value != DBNull.Value)
            {
                dtpLoanDate.Value =
                    Convert.ToDateTime(
                        row.Cells["LoanDate"].Value);
            }

            // Set due date
            if (row.Cells["DueDate"].Value != null &&
                row.Cells["DueDate"].Value != DBNull.Value)
            {
                dtpDueDate.Value =
                    Convert.ToDateTime(
                        row.Cells["DueDate"].Value);
            }
        }

        
        // CLEAR
        

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            cmbMember.SelectedIndex = -1;
            cmbBookCopy.SelectedIndex = -1;
            cmbStaff.SelectedIndex = -1;

            dtpLoanDate.Value =
                DateTime.Today;

            dtpDueDate.Value =
                DateTime.Today.AddDays(14);

            dgvAvailableBooks.ClearSelection();
            dgvCurrentLoans.ClearSelection();
        }
    }
}