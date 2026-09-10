using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace KhayelitshaLibrary
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();

            LoadMembers();
            LoadBooks();
            LoadLoans();
            LoadOverdueLoans();
            LoadLoanSummary();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {

        }

        
        // MEMBERS
        

        private void LoadMembers(string searchText = "")
        {
            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            MemberID,
                            FullName,
                            Address,
                            Phone,
                            JoinDate
                        FROM Member
                        WHERE
                            FullName LIKE @Search
                            OR CAST(MemberID AS NVARCHAR(20))
                               LIKE @Search
                        ORDER BY FullName";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.Add(
                            "@Search",
                            SqlDbType.NVarChar).Value =
                            "%" + searchText.Trim() + "%";

                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvMembers.DataSource = table;
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

        private void btnSearchMembers_Click(
            object sender,
            EventArgs e)
        {
            LoadMembers(txtMemberSearch.Text);
        }

        private void btnClearMemberSearch_Click(
            object sender,
            EventArgs e)
        {
            txtMemberSearch.Clear();
            LoadMembers();
        }

        
        // BOOKS
        

        private void LoadBooks(string searchText = "")
        {
            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            BookTitleID,
                            Title,
                            Author,
                            ISBN,
                            PublishedYear
                        FROM BookTitle
                        WHERE
                            Title LIKE @Search
                            OR Author LIKE @Search
                        ORDER BY Title";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.Add(
                            "@Search",
                            SqlDbType.NVarChar).Value =
                            "%" + searchText.Trim() + "%";

                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvBooks.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load books.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSearchBooks_Click(
            object sender,
            EventArgs e)
        {
            LoadBooks(txtBookSearch.Text);
        }

        private void btnClearBookSearch_Click(
            object sender,
            EventArgs e)
        {
            txtBookSearch.Clear();
            LoadBooks();
        }

        
        // LOAN FILTER
        

        private void LoadLoans()
        {
            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            L.LoanID,
                            M.FullName AS Member,
                            BT.Title AS Book,
                            L.CopyID,
                            L.LoanDate,
                            L.DueDate,
                            L.ReturnDate,
                            CASE
                                WHEN L.ReturnDate IS NOT NULL
                                    THEN 'Returned'
                                WHEN L.DueDate < CAST(GETDATE() AS DATE)
                                    THEN 'Overdue'
                                ELSE 'Active'
                            END AS LoanStatus
                        FROM Loan L
                        INNER JOIN Member M
                            ON L.MemberID = M.MemberID
                        INNER JOIN BookCopy BC
                            ON L.CopyID = BC.CopyID
                        INNER JOIN BookTitle BT
                            ON BC.BookTitleID = BT.BookTitleID
                        ORDER BY L.DueDate";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvLoans.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load loans.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FilterLoans()
        {
            string selectedFilter =
                cmbLoanFilter.SelectedItem?.ToString()
                ?? "All";

            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            L.LoanID,
                            M.FullName AS Member,
                            BT.Title AS Book,
                            L.CopyID,
                            L.LoanDate,
                            L.DueDate,
                            L.ReturnDate,
                            CASE
                                WHEN L.ReturnDate IS NOT NULL
                                    THEN 'Returned'
                                WHEN L.DueDate <
                                     CAST(GETDATE() AS DATE)
                                    THEN 'Overdue'
                                ELSE 'Active'
                            END AS LoanStatus
                        FROM Loan L
                        INNER JOIN Member M
                            ON L.MemberID = M.MemberID
                        INNER JOIN BookCopy BC
                            ON L.CopyID = BC.CopyID
                        INNER JOIN BookTitle BT
                            ON BC.BookTitleID = BT.BookTitleID
                        WHERE
                            (
                                @Filter = 'All'
                                OR
                                (
                                    @Filter = 'Active'
                                    AND L.ReturnDate IS NULL
                                    AND L.DueDate >=
                                        CAST(GETDATE() AS DATE)
                                )
                                OR
                                (
                                    @Filter = 'Returned'
                                    AND L.ReturnDate IS NOT NULL
                                )
                                OR
                                (
                                    @Filter = 'Overdue'
                                    AND L.ReturnDate IS NULL
                                    AND L.DueDate <
                                        CAST(GETDATE() AS DATE)
                                )
                            )
                        ORDER BY L.DueDate";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.Add(
                            "@Filter",
                            SqlDbType.NVarChar).Value =
                            selectedFilter;

                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvLoans.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to filter loans.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cmbLoanFilter_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            FilterLoans();
        }

        
        // OVERDUE REPORT
        

        private void LoadOverdueLoans()
        {
            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            M.FullName AS Member,
                            BT.Title AS Book,
                            L.CopyID,
                            L.DueDate,
                            DATEDIFF(
                                DAY,
                                L.DueDate,
                                CAST(GETDATE() AS DATE)
                            ) AS DaysOverdue
                        FROM Loan L
                        INNER JOIN Member M
                            ON L.MemberID = M.MemberID
                        INNER JOIN BookCopy BC
                            ON L.CopyID = BC.CopyID
                        INNER JOIN BookTitle BT
                            ON BC.BookTitleID = BT.BookTitleID
                        WHERE
                            L.ReturnDate IS NULL
                            AND L.DueDate <
                                CAST(GETDATE() AS DATE)
                        ORDER BY L.DueDate";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvOverdue.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load overdue loans.\n\n"
                    + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // LOAN SUMMARY
        

        private void LoadLoanSummary()
        {
            try
            {
                using (SqlConnection connection =
                       DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            M.FullName AS Member,
                            COUNT(L.LoanID) AS TotalLoans,
                            SUM(
                                CASE
                                    WHEN L.ReturnDate IS NULL
                                        THEN 1
                                    ELSE 0
                                END
                            ) AS ActiveLoans,
                            SUM(
                                CASE
                                    WHEN L.ReturnDate IS NOT NULL
                                        THEN 1
                                    ELSE 0
                                END
                            ) AS ReturnedLoans
                        FROM Member M
                        LEFT JOIN Loan L
                            ON M.MemberID = L.MemberID
                        GROUP BY
                            M.MemberID,
                            M.FullName
                        ORDER BY
                            TotalLoans DESC,
                            M.FullName";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvSummary.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load the loan summary.\n\n"
                    + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // REFRESH EVERYTHING
        

        private void btnRefresh_Click(
            object sender,
            EventArgs e)
        {
            LoadMembers(txtMemberSearch.Text);
            LoadBooks(txtBookSearch.Text);
            FilterLoans();
            LoadOverdueLoans();
            LoadLoanSummary();
        }
    }
}