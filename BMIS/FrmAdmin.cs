using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMIS
{
    public partial class FrmAdmin : Form
    {
        private string connectionString = dbconstring.connection;
        public FrmAdmin()
        {
            InitializeComponent();
            roundFrm.SetFormRoundedCorners(this, 30);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Get the username and password from the textboxes
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Authenticate user
            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Login successful!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();

                LoggedInUser.Username = username;
                // Open the FrmHome form
                FrmHome homeForm = new FrmHome();
                homeForm.Show();

                // Optionally, close the FrmAdmin form
                this.Hide();
                // or use `this.Close();` to completely close the form
                // this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // SQL query to get the username and position if credentials are valid
            string query = "SELECT username, position FROM tblRegistered WHERE username = @Username AND password = @Password";

            // Use SqlConnection and SqlCommand to execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the SQL query
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        // Open the connection
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Set the logged-in user's information
                                LoggedInUser.Username = reader["username"].ToString();
                                LoggedInUser.Position = reader["position"].ToString();
                                return true;
                            }
                            else
                            {
                                // No matching records found
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        MessageBox.Show($"Error: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            FrmLogin mainForm = FrmLogin.GetInstance();
            mainForm.Show();
            this.Close();
        }

        public void Clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FrmRegister frmRegister = new FrmRegister();
            frmRegister.Show();
            this.Hide();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the UseSystemPasswordChar property based on the checkbox state
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';  // No character masking, password visible
            }
            else
            {
                txtPassword.PasswordChar = '●';   // Bullet character for masking the password
            }
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '●';  // Bullet character for masking

            // Attach the CheckedChanged event for the Guna2CheckBox
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
