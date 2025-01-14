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
    public partial class FrmMaintenance : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;

        public FrmMaintenance()
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring.connection);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit1")
                {
                    FrmOfficials f = new FrmOfficials(this);
                    f.btnSave.Enabled = false;
                    f._id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f.txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    f.cboChairmanship.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    f.cboPosition.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    f.dtStart.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    f.dtEnd.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    f.cboStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    f.ShowDialog();
                }
                else if (colName == "btnDelete1")
                {
                    if (MessageBox.Show("Do you want to delete this record?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblOfficial where id like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been succesfully deleted!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmOfficials f = new FrmOfficials(this);
            f.btnUpdate.Enabled = false;
            f.ShowDialog();
        }

        public void LoadRecord()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblOfficial", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["name"].ToString(), dr["chairmanship"].ToString(), dr["position"].ToString(), DateTime.Parse(dr["termstart"].ToString()).ToShortDateString(), DateTime.Parse(dr["termend"].ToString()).ToShortDateString(), dr["status"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadPurok()
        {
            try
            {
                dataGridView2.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblPurok", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add(dr["purok"].ToString(), dr["chairman"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView2.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView2.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit2")
                {
                    FrmPurok f = new FrmPurok(this);
                    f.btnSave.Enabled = false;
                    f._purok = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f.txtPurok.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f.txtChairman.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    f.ShowDialog();
                }
                else if (colName == "btnDelete2")
                {
                    if (MessageBox.Show("Do you want to delete this record?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblPurok where purok like '" + dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been succesfully deleted!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPurok();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddNew2_Click_1(object sender, EventArgs e)
        {
            FrmPurok f = new FrmPurok(this);
            f.btnUpdate.Enabled = false;
            f.ShowDialog();
        }
    }
}
