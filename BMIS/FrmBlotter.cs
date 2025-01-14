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
using Microsoft.Data.SqlClient.Server;
using Microsoft.VisualBasic;

namespace BMIS
{
    public partial class FrmBlotter : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        FrmIssue f;
        public string _id;
        public FrmBlotter(FrmIssue f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring.connection);
            this.f = f;
        }
        public string GetFileNo()
        {
            string fileno = "CASE#";
            Random rnd = new Random();
            for (int x = 0; x < 7; x++)
            {
                fileno += rnd.Next(1, 9).ToString();
            }
            try
            {
                cn.Open();
                cm = new SqlCommand("select top 1fileno from tblBlotter where fileno like '" + fileno + "%' order by id desc", cn);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    lblfile.Text = GetFileNo();
                    dr.Close();
                    cn.Close();
                }
                else
                {
                    dr.Close();
                    cn.Close();
                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return fileno;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save this blotter?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblBlotter (fileno,barangay, purok, incident, place, idate, itime, complainant, witness1, witness2, narrative) values (@fileno, @barangay, @purok, @incident, @place, @idate, @itime, @complainant, @witness1, @witness2, @narrative)", cn);
                    cm.Parameters.AddWithValue("@fileno", lblfile.Text);
                    cm.Parameters.AddWithValue("@barangay", txtBarangay.Text);
                    cm.Parameters.AddWithValue("@purok", txtPurok.Text);
                    cm.Parameters.AddWithValue("@incident", txtIncident.Text);
                    cm.Parameters.AddWithValue("@place", txtPlace.Text);
                    cm.Parameters.AddWithValue("@idate", DateTime.Parse(dpDate.Value.ToShortDateString()));
                    cm.Parameters.AddWithValue("@itime", txtTime.Text);
                    cm.Parameters.AddWithValue("@complainant", txtComplainant.Text);
                    cm.Parameters.AddWithValue("@witness1", txtWitness1.Text);
                    cm.Parameters.AddWithValue("@witness2", txtWitness2.Text);
                    cm.Parameters.AddWithValue("@narrative", txtNarrative.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("The blotter has been succesfully saved!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadRecordsIssue();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Clear()
        {
            txtBarangay.Clear();
            txtIncident.Clear();
            txtPlace.Clear();
            txtTime.Clear();
            txtComplainant.Clear();
            txtWitness1.Clear();
            txtWitness2.Clear();
            txtNarrative.Clear();
            txtPurok.Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            dpDate.Value = DateTime.Now;
            txtBarangay.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtNarrative_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to update this blotter?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblBlotter set barangay=@barangay, purok=@purok, incident=@incident, place=@place, idate=@idate, itime=@itime, complainant=@complainant, witness1=@witness1, witness2=@witness2, narrative=@narrative where id=@id", cn);
                    
                    cm.Parameters.AddWithValue("@barangay", txtBarangay.Text);
                    cm.Parameters.AddWithValue("@purok", txtPurok.Text);
                    cm.Parameters.AddWithValue("@incident", txtIncident.Text);
                    cm.Parameters.AddWithValue("@place", txtPlace.Text);
                    cm.Parameters.AddWithValue("@idate", DateTime.Parse(dpDate.Value.ToShortDateString()));
                    cm.Parameters.AddWithValue("@itime", txtTime.Text);
                    cm.Parameters.AddWithValue("@complainant", txtComplainant.Text);
                    cm.Parameters.AddWithValue("@witness1", txtWitness1.Text);
                    cm.Parameters.AddWithValue("@witness2", txtWitness2.Text);
                    cm.Parameters.AddWithValue("@narrative", txtNarrative.Text);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("The blotter has been succesfully updated!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadRecordsIssue();
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
