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
using Microsoft.Data.SqlClient;

namespace BMIS
{
    public partial class FrmViewHousehold : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        FrmResidentsList f;
        public FrmViewHousehold(FrmResidentsList f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring.connection);
            this.f = f;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadRecord()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select id, address, (lname + ', ' + fname + ' ' +mname) as FullName from tblResident where house like '111222' and category like 'MEMBER'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["FullName"].ToString(), dr["address"].ToString());
                }
                dr.Close();
                cn.Close();
            }catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
