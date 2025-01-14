using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BMIS
{
    public partial class FrmIssue : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;

        public delegate void UpdateBlotterCountHandler();

        // Declare the event.
        public event UpdateBlotterCountHandler UpdateBlotterCount;
        public FrmIssue()
        {
            cn = new SqlConnection(dbconstring.connection);
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

        }

        public void LoadRecordsIssue()
        {
            try
            {
                dataGridView2.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblBlotter where barangay like '%" + txtNewSearch.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add(dr["id"].ToString(), dr["fileno"].ToString(), dr["barangay"].ToString(), dr["purok"].ToString(), dr["incident"].ToString(), dr["place"].ToString(), DateTime.Parse(dr["idate"].ToString()).ToShortDateString(), dr["itime"].ToString(), dr["complainant"].ToString(), dr["witness1"].ToString(), dr["witness2"].ToString(), dr["narrative"].ToString(), dr["status"].ToString());
                }
                cn.Close();
                if (dataGridView2.Columns["colPrint"] == null)
                {
                    DataGridViewButtonColumn btnPrint = new DataGridViewButtonColumn();
                    btnPrint.HeaderText = "Print";
                    btnPrint.Name = "btnPrint";
                    btnPrint.Text = "Print";
                    btnPrint.UseColumnTextForButtonValue = true;
                    dataGridView2.Columns.Add(btnPrint);
                }
                dataGridView2.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PrintPreview(string fileno, string barangay, string incident, string place, string narrative, string complainant, string witness1, string witness2)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (sender, e) =>
            {
                // Setting up fonts
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font contentFont = new Font("Arial", 12);

                // Draw title and date
                e.Graphics.DrawString("Barangay Cupal", titleFont, Brushes.Black, new PointF(100, 50));
                e.Graphics.DrawString(DateTime.Now.ToString("MMMM dd, yyyy"), contentFont, Brushes.Black, new PointF(400, 50));
                e.Graphics.DrawString("Aklan, Philippines", contentFont, Brushes.Black, new PointF(100, 80));

                // Draw file no and date
                e.Graphics.DrawString("File No: " + fileno, contentFont, Brushes.Black, new PointF(100, 120));
                e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString(), contentFont, Brushes.Black, new PointF(400, 120));

                // Draw incident and place
                e.Graphics.DrawString("Incident: " + incident, contentFont, Brushes.Black, new PointF(100, 150));
                e.Graphics.DrawString("Place of Incident: " + place, contentFont, Brushes.Black, new PointF(400, 150));

                // Draw narrative
                e.Graphics.DrawString("Narrative:", headerFont, Brushes.Black, new PointF(100, 180));
                e.Graphics.DrawString(narrative, contentFont, Brushes.Black, new RectangleF(100, 210, e.MarginBounds.Width - 200, 100)); // Adjust width and height as necessary

                // Draw complainant and witnesses
                e.Graphics.DrawString("Complainant: " + complainant, contentFont, Brushes.Black, new PointF(100, 320));
                e.Graphics.DrawString("Witness 1: " + witness1, contentFont, Brushes.Black, new PointF(300, 320));
                e.Graphics.DrawString("Witness 2: " + witness2, contentFont, Brushes.Black, new PointF(500, 320));
            };

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDoc
            };
            printPreviewDialog.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colname = dataGridView2.Columns[e.ColumnIndex].Name;
                if (colname == "btnEdit")
                {
                    FrmBlotter f = new FrmBlotter(this);
                    f._id = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
                    f.lblfile.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                    f.txtBarangay.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn3"].Value.ToString();
                    f.txtPurok.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn4"].Value.ToString();
                    f.txtIncident.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn5"].Value.ToString();
                    f.txtPlace.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn6"].Value.ToString();
                    f.dpDate.Value = DateTime.Parse(dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn7"].Value.ToString());
                    f.txtTime.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
                    f.txtComplainant.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn9"].Value.ToString();
                    f.txtWitness1.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn10"].Value.ToString();
                    f.txtWitness2.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn11"].Value.ToString();
                    f.txtNarrative.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn12"].Value.ToString();
                    f.btnSave.Enabled = false;
                    f.ShowDialog();
                }
                else if (colname == "btnDelete")
                {
                    if (MessageBox.Show("Do you want to delete this blotter?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblBlotter where id like '" + dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been succesfully deleted!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRecordsIssue();

                        UpdateBlotterCount?.Invoke();
                    }
                }
                else if (colname == "colPrint")
                {
                    // Fetch the data from the selected row to print
                    string fileno = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string barangay = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string incident = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string place = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string narrative = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString();
                    string complainant = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                    string witness1 = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
                    string witness2 = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();

                    // Call the PrintPreview method
                    PrintPreview(fileno, barangay, incident, place, narrative, complainant, witness1, witness2);
                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewAddNew_Click(object sender, EventArgs e)
        {
            FrmBlotter f = new FrmBlotter(this);
            f.lblfile.Text = f.GetFileNo();
            f.btnUpdate.Enabled = false;
            f.ShowDialog();

            // Trigger the event after adding a new record
            UpdateBlotterCount?.Invoke();
        }

        private void txtNewSearch_TextChanged(object sender, EventArgs e)
        {
            LoadRecordsIssue();
        }
    }
}
