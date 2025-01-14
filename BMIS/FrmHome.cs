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
    public partial class FrmHome : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public FrmHome()

        {
            cn = new SqlConnection(dbconstring.connection);
            InitializeComponent();
            roundFrm.SetFormRoundedCorners(this, 30);
        }

        public void LoadPaymentSummary()
        {
            try
            {
                double totalAmount = 0;
                int transactionCount = 0;

                cn.Open();
                cm = new SqlCommand("select COUNT(refno) as transactionCount, SUM(amount) as totalAmount from tblPayment", cn);
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    transactionCount = Convert.ToInt32(dr["transactionCount"]);
                    totalAmount = Convert.ToDouble(dr["totalAmount"]);
                }
                dr.Close();
                cn.Close();

                // Set the label text in FrmHome
                lblPaymentCount.Text = transactionCount.ToString();
                lblAmount.Text = totalAmount.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public string CountRecords(string sql)
        {
            cn.Open();
            cm = new SqlCommand(sql, cn);
            string _count = cm.ExecuteScalar().ToString();
            cn.Close();
            return _count;
        }
        private void UpdateBlotterCount()
        {
            // Directly count the blotter records in the FrmHome itself
            lblBlotter.Text = CountRecords("SELECT COUNT(*) FROM tblBlotter");
        }

        public void LoadDashboard()
        {
            try
            {
                lblCount.Text = CountRecords("select count(*) from tblResident ");
                lblHousehold.Text = CountRecords("select count(*) from tblResident where category like 'HEAD OF THE FAMILY'");
                lblMember.Text = CountRecords("select count(*) from tblResident where category like 'MEMBER'");
                lblVoters.Text = CountRecords("select count(*) from tblResident where voters like 'YES '");
                lblMale.Text = CountRecords("select count(*) from tblResident where gender like 'MALE'");
                lblFemale.Text = CountRecords("select count(*) from tblResident where gender like 'FEMALE'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void UpdateDashboard()
        {
            lblCount.Text = CountRecords("select count(*) from tblResident");
            lblHousehold.Text = CountRecords("select count(*) from tblResident where category like 'HEAD OF THE FAMILY'");
            lblMember.Text = CountRecords("select count(*) from tblResident where category like 'MEMBER'");
            lblVoters.Text = CountRecords("select count(*) from tblResident where voters like 'YES'");
            lblMale.Text = CountRecords("select count(*) from tblResident where gender like 'MALE'");
            lblFemale.Text = CountRecords("select count(*) from tblResident where gender like 'FEMALE'");
        }
        private void FrmHome_Load(object sender, EventArgs e)
        {
            LoadDashboard();
            UpdateBlotterCount();
            LoadPaymentSummary();
            lblUsername.Text = LoggedInUser.Username;
            lblPosition.Text = LoggedInUser.Position;
        }

        private void FrmHome_Resize(object sender, EventArgs e)
        {

        }

        private void btnResident_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDocuments_Click_1(object sender, EventArgs e)
        {
            FrmDocuments f = new FrmDocuments();
            f.TopLevel = false;
            guna2Panel3.Controls.Add(f);
            f.BringToFront();
            f.Show();
            f.loadDocuments();
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            // Clear any existing controls

            FrmResidentsList f = new FrmResidentsList(this); // Pass the current instance of FrmHome
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;

            guna2Panel3.Controls.Add(f);
            f.BringToFront();
            f.LoadHead();
            f.Loadrecords();

            f.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            FrmPaymentList f = new FrmPaymentList();
            f.TopLevel = false;
            guna2Panel3.Controls.Add(f);
            f.BringToFront();
            f.LoadPayment();
            f.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FrmIssue f = new FrmIssue();
            f.TopLevel = false;

            // Subscribe to the UpdateBlotterCount event
            f.UpdateBlotterCount += UpdateBlotterCount;

            guna2Panel3.Controls.Add(f);
            f.BringToFront();
            f.LoadRecordsIssue();
            f.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FrmMaintenance f = new FrmMaintenance();
            f.TopLevel = false;
            guna2Panel3.Controls.Add(f);
            f.LoadRecord();
            f.LoadPurok();
            f.BringToFront();
            f.Show();
        }

        private void lblCount_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
