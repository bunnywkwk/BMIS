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
    public partial class FrmOfficials : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        FrmMaintenance f;
        public string _id;
        public FrmOfficials(FrmMaintenance f)
        {
            cn = new SqlConnection(dbconstring.connection);
            InitializeComponent();
            this.f = f;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save this record?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblOfficial (name, chairmanship, position, termstart, termend, status) values (@name, @chairmanship, @position, @termstart, @termend, @status)", cn);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@chairmanship", cboChairmanship.Text);
                    cm.Parameters.AddWithValue("@position", cboPosition.Text);
                    cm.Parameters.AddWithValue("@termstart", dtStart.Value);
                    cm.Parameters.AddWithValue("@termend", dtEnd.Value);
                    cm.Parameters.AddWithValue("@status", cboStatus.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadRecord();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            txtName.Clear();
            cboChairmanship.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;
            dtStart.Value = DateTime.Today;
            dtEnd.Value = DateTime.Today;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtName.Focus();
        }

        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to update this record?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblOfficial set name=@name, chairmanship=@chairmanship, position=@position, termstart=@termstart, termend=@termend, status=@status where id=@id", cn);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@chairmanship", cboChairmanship.Text);
                    cm.Parameters.AddWithValue("@position", cboPosition.Text);
                    cm.Parameters.AddWithValue("@termstart", dtStart.Value);
                    cm.Parameters.AddWithValue("@termend", dtEnd.Value);
                    cm.Parameters.AddWithValue("@status", cboStatus.Text);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully updated!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadRecord();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboChairmanship_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
