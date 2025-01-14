using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BMIS
{
    public partial class FrmRegister : Form
    {
        private string connectionString = dbconstring.connection;
        public FrmRegister()
        {
            InitializeComponent();
            roundFrm.SetFormRoundedCorners(this, 30);
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Collect data from textboxes
            string position = txtregPosition.Text;
            string username = txtregUser.Text;
            string password = txtregPass.Text;

            // Validate input (optional but recommended)
            if (string.IsNullOrWhiteSpace(position) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            // Insert data into the database
            InsertData(position, username, password);
            txtregPass.Clear();
            txtregPosition.Clear();
            txtregUser.Clear();
        }

        private void InsertData(string position, string username, string password)
        {
            // SQL query to insert data
            string query = "INSERT INTO tblRegistered (position, username, password) VALUES (@Position, @Username, @Password)";

            // Use SqlConnection and SqlCommand to execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the SQL query
                    command.Parameters.AddWithValue("@Position", position);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        // Open the connection
                        connection.Open();
                        // Execute the query
                        command.ExecuteNonQuery();
                        // Notify the user
                        MessageBox.Show("Registration successful.");
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            FrmAdmin mainForm = new FrmAdmin();
            mainForm.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
