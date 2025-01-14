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
using System.IO;
namespace BMIS
{
    public partial class FrmResidentsList : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        private FrmHome homeForm;

        public FrmResidentsList(FrmHome home)
        {
            cn = new SqlConnection(dbconstring.connection);
            InitializeComponent();
            homeForm = home;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmResident f = new FrmResident(this);
            f.btnUpdate.Enabled = false;
            f.RecordSaved += OnRecordSaved;
            f.Clear();
            f.ShowDialog();
        }

        private void OnRecordSaved()
        {
            Loadrecords(); // Reload the records in the DataGridView
            homeForm.UpdateDashboard();
        }

        public void Loadrecords()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblResident where lname like '%" + txtsearch.Text + "%' or fname like '%" + txtsearch.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["nid"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["alias"].ToString(), dr["address"].ToString(), dr["house"].ToString(), dr["category"].ToString(), DateTime.Parse(dr["bdate"].ToString()).ToShortDateString(), dr["age"].ToString(), dr["gender"].ToString(), dr["civilstatus"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView1.ClearSelection();                
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadHead()
        {
            try
            {
                dataGridView2.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblResident where (lname like '%" + txtsearch1.Text + "%' or fname like '%" + txtsearch1.Text + "%') and category like 'HEAD OF THE FAMILY'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add(dr["id"].ToString(), dr["nid"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["alias"].ToString(), dr["address"].ToString(), dr["house"].ToString(), dr["category"].ToString(), DateTime.Parse(dr["bdate"].ToString()).ToShortDateString(), dr["age"].ToString(), dr["gender"].ToString(), dr["civilstatus"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView2.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colname = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colname == "btnEdit3")
                {
                    FrmResident f = new FrmResident(this);
                    f.LoadPurok();
                    cn.Open();
                    cm = new SqlCommand("select pic as picture, * from tblResident where id like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        long len = dr.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                        dr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        f._id = dr["id"].ToString();
                        f.txtID.Text = dr["nid"].ToString();
                        f.txtLname.Text = dr["lname"].ToString();
                        f.txtFname.Text = dr["fname"].ToString();
                        f.txtMname.Text = dr["mname"].ToString();
                        f.txtAddress.Text = dr["address"].ToString();
                        f.txtAge.Text = dr["age"].ToString();
                        f.txtAlias.Text = dr["alias"].ToString();
                        f.txtContact.Text = dr["contact"].ToString();
                        f.txtEducation.Text = dr["educational"].ToString();
                        f.txtEmail.Text = dr["email"].ToString();
                        f.txtHead.Text = dr["head"].ToString();
                        f.txtHouse.Text = dr["house"].ToString();
                        f.txtOccupation.Text = dr["occupation"].ToString();
                        f.txtBirthPlace.Text = dr["bplace"].ToString();
                        f.txtPrecint.Text = dr["precint"].ToString();
                        f.txtReligion.Text = dr["religion"].ToString();
                        f.cboCategory.Text = dr["category"].ToString();
                        f.cboCivilStatus.Text = dr["civilstatus"].ToString();
                        f.cboGender.Text = dr["gender"].ToString();
                        f.cboPurok.Text = dr["purok"].ToString();
                        f.cboVoterStatus.Text = dr["voters"].ToString();
                        f.dpBirthDate.Value = DateTime.Parse(dr["bdate"].ToString());
                        f.btnSave.Enabled = false;

                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmap = new Bitmap(ms);
                        f.picImage.BackgroundImage = bitmap;
                        f.btnSave.Enabled = false;
                    }
                    dr.Close();
                    cn.Close();
                    f.ShowDialog();
                }
                else if (colname == "btnDelete3")
                {
                    if (MessageBox.Show("DO you want to delete this record?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblResident where id like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been deleted!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loadrecords();
                        homeForm.UpdateDashboard();
                    }

                }



            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            Loadrecords();
        }

        private void guna2Panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtsearch1_TextChanged(object sender, EventArgs e)
        {
            LoadHead();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  
            try
            {
                string colname = dataGridView2.Columns[e.ColumnIndex].Name;
                if(colname == "btnView")
                {
                    string _id = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    FrmViewHousehold f = new FrmViewHousehold(this);
                    cn.Open(); ;
                    cm = new SqlCommand("select (lname + ', ' + fname + ' ' +mname) as FullName, house from tblResident where id=@id", cn);
                    cm.Parameters.AddWithValue("@id", _id);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        f.lblHouseHoldNo.Text = dr["house"].ToString();
                        f.lblHeadofFam.Text = dr["FullName"].ToString();
                    }
                    dr.Close();
                    cn.Close();
                    f.LoadRecord();                    
                    f.ShowDialog();
                }
            }catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
