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
    public partial class FrmPayment : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        Random rnd;
        FrmPaymentList f;
        public FrmPayment(FrmPaymentList f)
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
            GetRferenceNo();
            txtAmount.Clear();
            txtName.Clear();
            cboType.Text = "";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save this payment?",title._title,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblPayment (refno, name, type, amount, sdate,suser) values (@refno, @name, @type, @amount, @sdate, @suser)",cn);
                    cm.Parameters.AddWithValue("@refno",lblREfno.Text);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@type", cboType.Text);
                    cm.Parameters.AddWithValue("@amount", double.Parse(txtAmount.Text));
                    cm.Parameters.AddWithValue("@sdate", DateTime.Now);
                    cm.Parameters.AddWithValue("@suser", LoggedInUser.Username);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been succesfully saved!",title._title,MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadPayment();
                    Clear();

                    FrmHome home = (FrmHome)Application.OpenForms["FrmHome"];
                    if (home != null)
                    {
                        home.LoadPaymentSummary();
                    }
                }
            }catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message,title._title,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                GetRferenceNo();
            }
        }

        public void GetRferenceNo()
        {
            rnd = new Random();
            lblREfno.Text = DateTime.Now.ToString("yyyyMMdd-") + rnd.Next(11111, 99999);
        }
    }
}
