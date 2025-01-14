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
    public partial class FrmResident : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        FrmResidentsList f;
        public string _id;
        public event Action RecordSaved;

        public FrmResident(FrmResidentsList f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring.connection);
            this.f = f;
            LoadPurok();
        }

        public void LoadPurok()
        {
            try
            {
                cboPurok.Items.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblPurok", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    cboPurok.Items.Add(dr["purok"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmResident_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {
            lblName.Text = txtFname.Text + " " + txtMname.Text + " " + txtLname.Text;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Image Files (*.png)|*.png|(*.jpg)|*.jpg|(*.gif)|*.gif";
                openFileDialog1.ShowDialog();
                picImage.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save this record?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MemoryStream ms = new MemoryStream();
                    picImage.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = ms.GetBuffer();
                    cn.Open();
                    cm = new SqlCommand("insert into tblResident (nid,lname,fname,mname,alias,bdate,bplace,age,civilstatus,gender,religion,email,contact,voters,precint,purok,educational,occupation,address,category,house,head,pic) VALUES (@nid,@lname,@fname,@mname,@alias,@bdate,@bplace,@age,@civilstatus,@gender,@religion,@email,@contact,@voters,@precint,@purok,@educational,@occupation,@address,@category,@house,@head,@pic)", cn);
                    cm.Parameters.AddWithValue("@nid", txtID.Text);
                    cm.Parameters.AddWithValue("@lname", txtLname.Text);
                    cm.Parameters.AddWithValue("@fname", txtFname.Text);
                    cm.Parameters.AddWithValue("@mname", txtMname.Text);
                    cm.Parameters.AddWithValue("@alias", txtAlias.Text);
                    cm.Parameters.AddWithValue("@bdate", dpBirthDate.Value);
                    cm.Parameters.AddWithValue("@bplace", txtBirthPlace.Text);
                    cm.Parameters.AddWithValue("@age", txtAge.Text);
                    cm.Parameters.AddWithValue("@civilstatus", cboCivilStatus.Text);
                    cm.Parameters.AddWithValue("@gender", cboGender.Text);
                    cm.Parameters.AddWithValue("@religion", txtReligion.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@contact", txtContact.Text);
                    cm.Parameters.AddWithValue("@voters", cboVoterStatus.Text);
                    cm.Parameters.AddWithValue("@precint", txtPrecint.Text);
                    cm.Parameters.AddWithValue("@purok", cboPurok.Text);
                    cm.Parameters.AddWithValue("@educational", txtEducation.Text);
                    cm.Parameters.AddWithValue("@occupation", txtOccupation.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@category", cboCategory.Text);
                    cm.Parameters.AddWithValue("@house", txtHouse.Text);
                    cm.Parameters.AddWithValue("@head", txtHead.Text);
                    cm.Parameters.AddWithValue("@pic", arrImage);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been succesfully saved!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.Loadrecords();
                    RecordSaved?.Invoke();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.Text == "HEAD OF THE FAMILY")
            {
                txtHouse.Enabled = true;
                btnBrowse.Visible = false;
            }
            else
            {
                txtHouse.Enabled = false;
                btnBrowse.Visible = true;
            }
        }

        private void cboVoterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVoterStatus.Text == "YES ")
            {
                txtPrecint.Enabled = true;
            }
            else
            {
                txtPrecint.Enabled = false;
                txtPrecint.Clear();
            }

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to update this record?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MemoryStream ms = new MemoryStream();
                    picImage.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = ms.GetBuffer();
                    cn.Open();
                    cm = new SqlCommand("update tblResident set nid=@nid,lname=@lname,fname=@fname,mname=@mname,alias=@alias,bdate=@bdate,bplace=@bplace,age=@age,civilstatus=@civilstatus,gender=@gender,religion=@religion,email=@email,contact=@contact,voters=@voters,precint=@precint,purok=@purok,educational=@educational,occupation=@occupation,address=@address,category=@category,house=@house,head=@head,pic=@pic where id=@id", cn);
                    cm.Parameters.AddWithValue("@nid", txtID.Text);
                    cm.Parameters.AddWithValue("@lname", txtLname.Text);
                    cm.Parameters.AddWithValue("@fname", txtFname.Text);
                    cm.Parameters.AddWithValue("@mname", txtMname.Text);
                    cm.Parameters.AddWithValue("@alias", txtAlias.Text);
                    cm.Parameters.AddWithValue("@bdate", dpBirthDate.Value);
                    cm.Parameters.AddWithValue("@bplace", txtBirthPlace.Text);
                    cm.Parameters.AddWithValue("@age", txtAge.Text);
                    cm.Parameters.AddWithValue("@civilstatus", cboCivilStatus.Text);
                    cm.Parameters.AddWithValue("@gender", cboGender.Text);
                    cm.Parameters.AddWithValue("@religion", txtReligion.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@contact", txtContact.Text);
                    cm.Parameters.AddWithValue("@voters", cboVoterStatus.Text);
                    cm.Parameters.AddWithValue("@precint", txtPrecint.Text);
                    cm.Parameters.AddWithValue("@purok", cboPurok.Text);
                    cm.Parameters.AddWithValue("@educational", txtEducation.Text);
                    cm.Parameters.AddWithValue("@occupation", txtOccupation.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@category", cboCategory.Text);
                    cm.Parameters.AddWithValue("@house", txtHouse.Text);
                    cm.Parameters.AddWithValue("@head", txtHead.Text);
                    cm.Parameters.AddWithValue("@pic", arrImage);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been succesfully updated!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.Loadrecords();
                    this.Dispose();
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
            string imagePath = Application.StartupPath + @"\Images\jake.jpg";
            picImage.BackgroundImage = Image.FromFile(imagePath);
            txtAddress.Clear();
            txtHouse.Clear();
            txtHead.Clear();
            txtAge.Clear();
            txtAlias.Clear();
            txtContact.Clear();
            txtEducation.Clear();
            txtBirthPlace.Clear();
            txtOccupation.Clear();
            txtFname.Clear();
            txtMname.Clear();
            txtLname.Clear();
            txtPrecint.Clear();
            txtReligion.Clear();
            txtID.Clear();
            txtEmail.Clear();
            cboCategory.Text = "";
            cboCivilStatus.Text = "";
            cboGender.Text = "";
            cboPurok.Text = "";
            cboVoterStatus.Text = "";
            dpBirthDate.Value = DateTime.Now;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtID.Focus();


        }

        private void dpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dpBirthDate.Value.Year;
            txtAge.Text = age.ToString();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FrmHouseHold f = new FrmHouseHold(this);
            f.LoadRecords();
            f.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
