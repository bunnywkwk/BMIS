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
    public partial class frmPrintBarangayClearance : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        FrmDocuments f;
        public frmPrintBarangayClearance(FrmDocuments f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring.connection);
            this.f = f;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadRefNo()
        {
            try
            {
                cboRef.Items.Clear();
                cn.Open();
                cm = new SqlCommand("select refno from tblPayment where type like 'BARANGAY CLEARANCE' and status like 'Pending' order by id desc", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    cboRef.Items.Add(dr[0].ToString());
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

        private void cboRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from tblPayment where refno like '" + cboRef.Text + "'", cn);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtName.Text = dr["name"].ToString();
                }
                cn.Close();

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save this record?", title._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblPayment set status = 'Completed' where refno like '" + cboRef.Text + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();


                    cn.Open();
                    cm = new SqlCommand("insert into tblDocument (refno, type,details1, details2, gdate, duser) values (@refno,@type ,@details1, @details2, @gdate, @duser)", cn);
                    cm.Parameters.AddWithValue("@refno", cboRef.Text);
                    cm.Parameters.AddWithValue("@type", "BARANGAY CLEARANCE");
                    cm.Parameters.AddWithValue("@details1", txtAddress.Text);
                    cm.Parameters.AddWithValue("@details2", txtName.Text);
                    cm.Parameters.AddWithValue("@gdate", DateTime.Now);
                    cm.Parameters.AddWithValue("@duser", LoggedInUser.Username);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    f._refno = cboRef.Text;
                    f.loadDocuments();
                    MessageBox.Show("Record has been succesfully saved!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PrintPreview(
    cboRef.Text,              // Reference No
    "BARANGAY CLEARANCE",     // Document Type
    txtAddress.Text,          // Address
    txtName.Text,             // Name
    DateTime.Now,             // Date Issued
    LoggedInUser.Username,    // Issued By
    "Aeron C. Solano"   // Barangay Captain Name
);



                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PrintPreview(string refno, string type, string address, string name, DateTime issueDate, string user, string captain)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = false; // Portrait layout
            printDoc.PrintPage += (sender, e) =>
            {
                // Set up fonts
                Font titleFont = new Font("Arial", 18, FontStyle.Bold);
                Font headerFont = new Font("Arial", 14, FontStyle.Bold);
                Font contentFont = new Font("Arial", 12);
                Font boldContentFont = new Font("Arial", 12, FontStyle.Bold);
                Font footerFont = new Font("Arial", 12, FontStyle.Italic);
                float y = 50; // Starting y-coordinate for printing

                // Title
                e.Graphics.DrawString("BARANGAY CLEARANCE", titleFont, Brushes.Black, new PointF(200, y));
                y += 50;

                // Addressed to
                e.Graphics.DrawString("TO WHOM IT MAY CONCERN:", headerFont, Brushes.Black, new PointF(100, y));
                y += 30;

                // Certification details
                string clearanceText = "THIS IS TO CERTIFY that ";
                e.Graphics.DrawString(clearanceText, contentFont, Brushes.Black, new PointF(100, y));
                e.Graphics.DrawString(name.ToUpper(), boldContentFont, Brushes.Black, new PointF(100 + e.Graphics.MeasureString(clearanceText, contentFont).Width, y));
                y += 20;

                string continuationText = "is cleared from all the obligations of this barangay, and that he/she has fully satisfied/paid whatever liabilities he/she may have incurred as a resident of this barangay in coordination with the purok he/she belongs.";
                RectangleF continuationRect = new RectangleF(100, y, 600, 100); // Rectangle for text wrapping
                e.Graphics.DrawString(continuationText, contentFont, Brushes.Black, continuationRect);
                y += 80;

                // Purpose of the certification
                string purposeText = "This certification is being issued upon the request of the \nabovementioned person for whatever purpose this may serve.";
                e.Graphics.DrawString(purposeText, contentFont, Brushes.Black, new PointF(100, y));
                y += 50;

                // Date issued and address
                e.Graphics.DrawString($"Issued this {issueDate.Day} day of {issueDate.ToString("MMMM")}, {issueDate.Year} at ", contentFont, Brushes.Black, new PointF(100, y));
                float addressX = 100 + e.Graphics.MeasureString($"Issued this {issueDate.Day} day of {issueDate.ToString("MMMM")}, {issueDate.Year} at ", contentFont).Width;
                e.Graphics.DrawString(address, boldContentFont, Brushes.Black, new PointF(addressX, y));
                y += 20;
                e.Graphics.DrawString("Barangay Cupal.", contentFont, Brushes.Black, new PointF(100, y));
                y += 50;

                // Signature area
                e.Graphics.DrawString($"_________________________", contentFont, Brushes.Black, new PointF(400, y));
                y += 20;
                e.Graphics.DrawString(captain.ToUpper(), boldContentFont, Brushes.Black, new PointF(400, y));
                y += 20;
                e.Graphics.DrawString("Punong Barangay", footerFont, Brushes.Black, new PointF(400, y));
                y += 50;

                // Payment details
                e.Graphics.DrawString("Paid per OR No.:", contentFont, Brushes.Black, new PointF(100, y));
                float orNoX = 100 + e.Graphics.MeasureString("Paid per OR No.:", contentFont).Width;
                e.Graphics.DrawString(refno, boldContentFont, Brushes.Black, new PointF(orNoX, y));
                y += 30;

                e.Graphics.DrawString("Dated Issued:", contentFont, Brushes.Black, new PointF(100, y));
                float dateX = 100 + e.Graphics.MeasureString("Dated Issued:", contentFont).Width;
                e.Graphics.DrawString(issueDate.ToString("MMMM dd, yyyy"), boldContentFont, Brushes.Black, new PointF(dateX, y));
            };

            // Display the print preview dialog
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 1000,
                Height = 700
            };
            printPreviewDialog.ShowDialog();
        }


    }
}
