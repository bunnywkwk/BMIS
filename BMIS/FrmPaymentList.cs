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
    public partial class FrmPaymentList : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public FrmPaymentList()
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring.connection);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmPayment f = new FrmPayment(this);
            f.GetRferenceNo();
            f.Show();
        }

        public void LoadPayment()
        {
            try
            {
                double _amount = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblPayment", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    _amount += double.Parse(dr["amount"].ToString());
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["refno"].ToString(), dr["name"].ToString(), dr["type"].ToString(), dr["amount"].ToString(), DateTime.Parse(dr["sdate"].ToString()).ToString("MM-dd-yyyy"), dr["suser"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView1.ClearSelection();
                /*lblAmount.Text = _amount.ToString("#,##0.00");*/
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colname == "btnDelete3")
            {
                if (MessageBox.Show("Do you want to delete this record?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from tblPayment where id=@id", cn);
                    cm.Parameters.AddWithValue("@id", dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record Deleted!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPayment();


                    FrmHome home = (FrmHome)Application.OpenForms["FrmHome"];
                    if (home != null)
                    {
                        home.LoadPaymentSummary();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
