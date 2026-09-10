using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace KhayelitshaLibrary
{
    public partial class BookForm : Form
    {
        public BookForm()
        {
            InitializeComponent();

            LoadBookTitles();
            LoadBookTitleComboBox();
            LoadStatuses();
            LoadBookCopies();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {

        }
        
        
        // BOOK TITLE MANAGEMENT
        

        private void LoadBookTitles()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            BookTitleID,
                            Title,
                            Author,
                            ISBN,
                            PublishedYear
                        FROM BookTitle
                        ORDER BY BookTitleID";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvBookTitles.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load book titles.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadBookTitleComboBox()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            BookTitleID,
                            Title
                        FROM BookTitle
                        ORDER BY Title";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        cmbBookTitle.DataSource = table;
                        cmbBookTitle.DisplayMember = "Title";
                        cmbBookTitle.ValueMember = "BookTitleID";
                        cmbBookTitle.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load book titles into the selection list.\n\n"
                    + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("On Loan");
            cmbStatus.Items.Add("Lost");
            cmbStatus.Items.Add("Damaged");

            cmbStatus.SelectedIndex = -1;
        }

        private void LoadBookCopies()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT
                            BC.CopyID,
                            BC.BookTitleID,
                            BT.Title,
                            BC.Status
                        FROM BookCopy BC
                        INNER JOIN BookTitle BT
                            ON BC.BookTitleID = BT.BookTitleID
                        ORDER BY BC.CopyID";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvBookCopies.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load book copies.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // ADD BOOK TITLE
        

        private void btnAddTitle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show(
                    "Please enter a book title.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show(
                    "Please enter the author's name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAuthor.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show(
                    "Please enter the ISBN.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtISBN.Focus();
                return;
            }

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO BookTitle
                        (
                            Title,
                            Author,
                            ISBN,
                            PublishedYear
                        )
                        VALUES
                        (
                            @Title,
                            @Author,
                            @ISBN,
                            @PublishedYear
                        )";

                    using (SqlCommand command =
                           new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@Title",
                            txtTitle.Text.Trim());

                        command.Parameters.AddWithValue(
                            "@Author",
                            txtAuthor.Text.Trim());

                        command.Parameters.AddWithValue(
                            "@ISBN",
                            txtISBN.Text.Trim());

                        command.Parameters.AddWithValue(
                            "@PublishedYear",
                            (int)nudPublishedYear.Value);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Book title added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearTitleFields();

                LoadBookTitles();
                LoadBookTitleComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to add the book title.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // SELECT BOOK TITLE
        

        private void dgvBookTitles_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvBookTitles.Rows[e.RowIndex];

            txtTitle.Text =
                row.Cells["Title"].Value?.ToString() ?? "";

            txtAuthor.Text =
                row.Cells["Author"].Value?.ToString() ?? "";

            txtISBN.Text =
                row.Cells["ISBN"].Value?.ToString() ?? "";

            if (row.Cells["PublishedYear"].Value != null &&
                int.TryParse(
                    row.Cells["PublishedYear"].Value.ToString(),
                    out int year))
            {
                if (year >= nudPublishedYear.Minimum &&
                    year <= nudPublishedYear.Maximum)
                {
                    nudPublishedYear.Value = year;
                }
            }
        }

        
        // UPDATE BOOK TITLE
        

        private void btnUpdateTitle_Click(object sender, EventArgs e)
        {
            if (dgvBookTitles.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a book title to update.",
                    "Update Book",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show(
                    "Please enter a book title.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show(
                    "Please enter the author's name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAuthor.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show(
                    "Please enter the ISBN.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtISBN.Focus();
                return;
            }

            int bookTitleID = Convert.ToInt32(
                dgvBookTitles.CurrentRow.Cells["BookTitleID"].Value);

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        UPDATE BookTitle
                        SET
                            Title = @Title,
                            Author = @Author,
                            ISBN = @ISBN,
                            PublishedYear = @PublishedYear
                        WHERE BookTitleID = @BookTitleID";

                    using (SqlCommand command =
                           new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@Title",
                            txtTitle.Text.Trim());

                        command.Parameters.AddWithValue(
                            "@Author",
                            txtAuthor.Text.Trim());

                        command.Parameters.AddWithValue(
                            "@ISBN",
                            txtISBN.Text.Trim());

                        command.Parameters.AddWithValue(
                            "@PublishedYear",
                            (int)nudPublishedYear.Value);

                        command.Parameters.AddWithValue(
                            "@BookTitleID",
                            bookTitleID);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Book title updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearTitleFields();

                LoadBookTitles();
                LoadBookTitleComboBox();
                LoadBookCopies();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update the book title.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // DELETE BOOK TITLE
        

        private void btnDeleteTitle_Click(object sender, EventArgs e)
        {
            if (dgvBookTitles.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a book title to delete.",
                    "Delete Book",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int bookTitleID = Convert.ToInt32(
                dgvBookTitles.CurrentRow.Cells["BookTitleID"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this book title?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // Check whether physical copies exist
                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM BookCopy
                        WHERE BookTitleID = @BookTitleID";

                    using (SqlCommand checkCommand =
                           new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue(
                            "@BookTitleID",
                            bookTitleID);

                        int copyCount =
                            Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (copyCount > 0)
                        {
                            MessageBox.Show(
                                "This book title cannot be deleted because "
                                + "physical book copies are linked to it.\n\n"
                                + "Delete the related copies first.",
                                "Delete Not Allowed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    string deleteQuery = @"
                        DELETE FROM BookTitle
                        WHERE BookTitleID = @BookTitleID";

                    using (SqlCommand deleteCommand =
                           new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue(
                            "@BookTitleID",
                            bookTitleID);

                        deleteCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Book title deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearTitleFields();

                LoadBookTitles();
                LoadBookTitleComboBox();
                LoadBookCopies();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete the book title.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // CLEAR BOOK TITLE
        

        private void btnClearTitle_Click(object sender, EventArgs e)
        {
            ClearTitleFields();
        }

        private void ClearTitleFields()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtISBN.Clear();

            nudPublishedYear.Value =
                DateTime.Now.Year;

            dgvBookTitles.ClearSelection();
        }

        
        // ADD PHYSICAL BOOK COPY
        

        private void btnAddCopy_Click(object sender, EventArgs e)
        {
            if (cmbBookTitle.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a book title.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbBookTitle.Focus();
                return;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a copy status.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbStatus.Focus();
                return;
            }

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO BookCopy
                        (
                            BookTitleID,
                            Status
                        )
                        VALUES
                        (
                            @BookTitleID,
                            @Status
                        )";

                    using (SqlCommand command =
                           new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@BookTitleID",
                            Convert.ToInt32(cmbBookTitle.SelectedValue));

                        command.Parameters.AddWithValue(
                            "@Status",
                            cmbStatus.SelectedItem.ToString());

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Physical book copy added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearCopyFields();
                LoadBookCopies();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to add the book copy.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // SELECT PHYSICAL COPY
        

        private void dgvBookCopies_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvBookCopies.Rows[e.RowIndex];

            txtCopyID.Text =
                row.Cells["CopyID"].Value?.ToString() ?? "";

            if (row.Cells["BookTitleID"].Value != null)
            {
                int bookTitleID =
                    Convert.ToInt32(
                        row.Cells["BookTitleID"].Value);

                cmbBookTitle.SelectedValue =
                    bookTitleID;
            }

            if (row.Cells["Status"].Value != null)
            {
                cmbStatus.SelectedItem =
                    row.Cells["Status"].Value.ToString();
            }
        }

        
        // UPDATE PHYSICAL COPY
        

        private void btnUpdateCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCopyID.Text))
            {
                MessageBox.Show(
                    "Please select a physical book copy to update.",
                    "Update Copy",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cmbBookTitle.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a book title.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a copy status.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int copyID = Convert.ToInt32(txtCopyID.Text);

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        UPDATE BookCopy
                        SET
                            BookTitleID = @BookTitleID,
                            Status = @Status
                        WHERE CopyID = @CopyID";

                    using (SqlCommand command =
                           new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@BookTitleID",
                            Convert.ToInt32(cmbBookTitle.SelectedValue));

                        command.Parameters.AddWithValue(
                            "@Status",
                            cmbStatus.SelectedItem.ToString());

                        command.Parameters.AddWithValue(
                            "@CopyID",
                            copyID);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Physical book copy updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearCopyFields();
                LoadBookCopies();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update the book copy.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // DELETE PHYSICAL COPY
        

        private void btnDeleteCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCopyID.Text))
            {
                MessageBox.Show(
                    "Please select a physical book copy to delete.",
                    "Delete Copy",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int copyID = Convert.ToInt32(txtCopyID.Text);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this physical book copy?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // Check whether the copy has loan history
                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM Loan
                        WHERE CopyID = @CopyID";

                    using (SqlCommand checkCommand =
                           new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue(
                            "@CopyID",
                            copyID);

                        int loanCount =
                            Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (loanCount > 0)
                        {
                            MessageBox.Show(
                                "This physical copy cannot be deleted "
                                + "because it has loan history.",
                                "Delete Not Allowed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    string deleteQuery = @"
                        DELETE FROM BookCopy
                        WHERE CopyID = @CopyID";

                    using (SqlCommand deleteCommand =
                           new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue(
                            "@CopyID",
                            copyID);

                        deleteCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Physical book copy deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearCopyFields();
                LoadBookCopies();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete the book copy.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        // CLEAR COPY FIELDS
        

        private void ClearCopyFields()
        {
            txtCopyID.Clear();
            cmbBookTitle.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            dgvBookCopies.ClearSelection();
        }
    }
}