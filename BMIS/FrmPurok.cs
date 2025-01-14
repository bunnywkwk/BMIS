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
using Microsoft.VisualBasic;
namespace BMIS
{
    public partial class FrmPurok : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        FrmMaintenance f;
        public string _purok;

        public FrmPurok(FrmMaintenance f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring.connection);
            this.f = f;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txtPurok.Clear();
            txtChairman.Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtPurok.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("DO you want saved this record?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblPurok (purok, chairman) values (@purok, @chairman)", cn);
                    cm.Parameters.AddWithValue("@purok", txtPurok.Text);
                    cm.Parameters.AddWithValue("@chairman", txtChairman.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadPurok();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("DO you want update this record?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblPurok set purok=@purok, chairman=@chairman where purok = @purok1", cn);
                    cm.Parameters.AddWithValue("@purok", txtPurok.Text);
                    cm.Parameters.AddWithValue("@chairman", txtChairman.Text);
                    cm.Parameters.AddWithValue("@purok1", _purok);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully updated!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadPurok();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
