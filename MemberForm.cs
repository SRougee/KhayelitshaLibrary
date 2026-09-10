using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KhayelitshaLibrary
{
    public partial class MemberForm : Form
    {
        public MemberForm()
        {
            InitializeComponent();
            LoadMembers();
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadMembers()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"
                SELECT 
                    MemberID,
                    FullName,
                    Address,
                    Phone,
                    JoinDate
                FROM Member
                ORDER BY MemberID";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
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

        private void ClearMemberFields()
        {
            txtMemberID.Clear();
            txtFullName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();

            dtpJoinDate.Value = DateTime.Today;

            txtFullName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show(
                    "Please enter the member's full name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show(
                    "Please enter the member's address.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAddress.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show(
                    "Please enter the member's phone number.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPhone.Focus();
                return;
            }

            if (!Regex.IsMatch(txtPhone.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show(
                    "Please enter a valid 10-digit phone number.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPhone.Focus();
                return;
            }

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"
                INSERT INTO Member
                    (FullName, Address, Phone, JoinDate)
                VALUES
                    (@FullName, @Address, @Phone, @JoinDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        command.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        command.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        command.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Value.Date);

                        connection.Open();

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Member added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadMembers();
                ClearMemberFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to add member.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMembers.Rows[e.RowIndex];

                txtMemberID.Text = row.Cells["MemberID"].Value?.ToString();
                txtFullName.Text = row.Cells["FullName"].Value?.ToString();
                txtAddress.Text = row.Cells["Address"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();

                if (row.Cells["JoinDate"].Value != null)
                {
                    dtpJoinDate.Value = Convert.ToDateTime(row.Cells["JoinDate"].Value);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMemberID.Text))
            {
                MessageBox.Show(
                    "Please select a member to update.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show(
                    "Please enter the member's full name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show(
                    "Please enter the member's address.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAddress.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show(
                    "Please enter the member's phone number.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPhone.Focus();
                return;
            }
            if (!Regex.IsMatch(txtPhone.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show(
                    "Please enter a valid 10-digit phone number.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPhone.Focus();
                return;
            }

            if (!int.TryParse(txtMemberID.Text, out int memberID))
            {
                MessageBox.Show(
                    "The selected Member ID is invalid.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"
                UPDATE Member
                SET FullName = @FullName,
                    Address = @Address,
                    Phone = @Phone,
                    JoinDate = @JoinDate
                WHERE MemberID = @MemberID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@FullName",
                            txtFullName.Text.Trim());

                        command.Parameters.AddWithValue(
                            "@Address",
                            txtAddress.Text.Trim());

                        command.Parameters.AddWithValue(
                            "@Phone",
                            txtPhone.Text.Trim());

                        command.Parameters.AddWithValue(
                            "@JoinDate",
                            dtpJoinDate.Value.Date);

                        command.Parameters.AddWithValue(
                            "@MemberID",
                            memberID);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show(
                                "The member could not be found.",
                                "Update",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Member updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadMembers();
                ClearMemberFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update member.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMemberID.Text))
            {
                MessageBox.Show(
                    "Please select a member to delete.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(txtMemberID.Text, out int memberID))
            {
                MessageBox.Show(
                    "The selected Member ID is invalid.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this member?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // Check whether the member has loan records
                    string checkQuery = @"
                SELECT COUNT(*)
                FROM Loan
                WHERE MemberID = @MemberID";

                    using (SqlCommand checkCommand =
                           new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue(
                            "@MemberID", memberID);

                        int loanCount =
                            Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (loanCount > 0)
                        {
                            MessageBox.Show(
                                "This member cannot be deleted because loan " +
                                "history exists for this member.",
                                "Delete Not Allowed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    // Delete the member
                    string deleteQuery = @"
                DELETE FROM Member
                WHERE MemberID = @MemberID";

                    using (SqlCommand deleteCommand =
                           new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue(
                            "@MemberID", memberID);

                        int rowsAffected =
                            deleteCommand.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show(
                                "The member could not be found.",
                                "Delete",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Member deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadMembers();
                ClearMemberFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete member.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearMemberFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"
                SELECT
                    MemberID,
                    FullName,
                    Address,
                    Phone,
                    JoinDate
                FROM Member
                WHERE FullName LIKE @Search
                   OR CAST(MemberID AS NVARCHAR(20)) LIKE @Search
                ORDER BY MemberID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@Search",
                            "%" + txtSearch.Text.Trim() + "%");

                        using (SqlDataAdapter adapter =
                               new SqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();

                            adapter.Fill(table);

                            dgvMembers.DataSource = table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to search members.\n\n" + ex.Message,
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
