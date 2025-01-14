using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DirectX.Common.Direct2D;
using DevExpress.DocumentServices.ServiceModel.DataContracts;
using Microsoft.Data.SqlClient;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;

namespace BMIS
{
    public partial class FrmDocuments : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public string _refno;
        string _captain;
        public FrmDocuments()
        {
            cn = new SqlConnection(dbconstring.connection);
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FrmPrintBusiness f = new FrmPrintBusiness(this);
            f.LoadRefNo();
            f.ShowDialog();
        }


        private void btnClearance_Click(object sender, EventArgs e)
        {
            frmPrintBarangayClearance f = new frmPrintBarangayClearance(this);
            f.LoadRefNo();
            f.ShowDialog();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void loadDocuments()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblDocument", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["refno"].ToString(), dr["type"].ToString(), dr["details1"].ToString(), dr["details2"].ToString(), DateTime.Parse(dr["gdate"].ToString()), dr["duser"].ToString());
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

        private void FrmDocuments_Load(object sender, EventArgs e)
        {
            
        }
    }
}
