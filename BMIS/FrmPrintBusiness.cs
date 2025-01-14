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
    public partial class FrmPrintBusiness : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        FrmDocuments f;

        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private string printData;

        public FrmPrintBusiness(FrmDocuments f)
        {
            InitializeComponent();
            this.f = f;
            cn = new SqlConnection(dbconstring.connection);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                try
                {
                    if(MessageBox.Show("Do you want to save this record?",title._title,MessageBoxButtons.YesNo,MessageBoxIcon.Question) ==DialogResult.Yes)
                    {
                    cn.Open();
                    cm = new SqlCommand("update tblPayment set status = 'Completed' where refno like '" + cboRef.Text + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();


                        cn.Open();
                        cm = new SqlCommand("insert into tblDocument (refno, type,details1, details2, gdate, duser) values (@refno,@type ,@details1, @details2, @gdate, @duser)", cn);
                        cm.Parameters.AddWithValue("@refno", cboRef.Text);
                        cm.Parameters.AddWithValue("@type", "BARANGAY BUSINESS CLEARANCE");
                        cm.Parameters.AddWithValue("@details1", txtEstablishment.Text);
                        cm.Parameters.AddWithValue("@details2", txtOwner.Text);
                        cm.Parameters.AddWithValue("@gdate", dpDate.Value);
                        cm.Parameters.AddWithValue("@duser", LoggedInUser.Username);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        f._refno = cboRef.Text;  
                        f.loadDocuments();
                        MessageBox.Show("Record has been succesfully saved!", title._title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                         PrintPreview(
                                    cboRef.Text,                  
                                    "BARANGAY BUSINESS CLEARANCE", 
                                    txtEstablishment.Text,        
                                    txtOwner.Text,                
                                    dpDate.Value,                 
                                    LoggedInUser.Username         
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

        private void PrintPreview(string refno, string type, string details1, string details2, DateTime gdate, string user)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = false; // Set to portrait orientation
            printDoc.PrintPage += (sender, e) =>
            {
                // Set up fonts
                Font titleFont = new Font("Arial", 20, FontStyle.Bold);
                Font headerFont = new Font("Arial", 14, FontStyle.Bold);
                Font contentFont = new Font("Arial", 12);
                float y = 50; // Starting y-coordinate for printing

                // Draw the header (Barangay Details)
                e.Graphics.DrawString("BARANGAY MANAGEMENT INFORMATION SYSTEM", titleFont, Brushes.Black, new PointF(100, y));
                y += 40;
                e.Graphics.DrawString("Barangay Cupal, Aklan, Philippines", headerFont, Brushes.Black, new PointF(100, y));
                y += 40;
                e.Graphics.DrawString("_________________________________________________________________", contentFont, Brushes.Black, new PointF(50, y));
                y += 40;

                // Document details (Reference, Type)
                e.Graphics.DrawString($"Reference No: {refno}", contentFont, Brushes.Black, new PointF(100, y));
                y += 25;
                e.Graphics.DrawString($"Type: {type}", contentFont, Brushes.Black, new PointF(100, y));
                y += 40;

                // Establishment and owner details
                e.Graphics.DrawString("Details:", headerFont, Brushes.Black, new PointF(100, y));
                y += 30;
                e.Graphics.DrawString($"   Establishment Name: {details1}", contentFont, Brushes.Black, new PointF(120, y));
                y += 25;
                e.Graphics.DrawString($"   Owner's Name: {details2}", contentFont, Brushes.Black, new PointF(120, y));
                y += 40;

                // Date issued and user
                e.Graphics.DrawString("Issued Information:", headerFont, Brushes.Black, new PointF(100, y));
                y += 30;
                e.Graphics.DrawString($"   Date Issued: {gdate.ToString("MMMM dd, yyyy")}", contentFont, Brushes.Black, new PointF(120, y));
                y += 25;
                e.Graphics.DrawString($"   Issued By: {user}", contentFont, Brushes.Black, new PointF(120, y));
                y += 40;

                // Footer or additional notes
                e.Graphics.DrawString("Thank you for using Barangay Management Information System!", contentFont, Brushes.Black, new PointF(100, y));
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

        public void LoadRefNo()
        {
            try
            {
                cboRef.Items.Clear();
                cn.Open();
                cm = new SqlCommand("select refno from tblPayment where type like 'BARANGAY BUSINESS CLEARANCE' and status like 'Pending' order by id desc", cn);
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
                cm = new SqlCommand("select * from tblPayment where refno = @refno", cn);
                cm.Parameters.AddWithValue("@refno",cboRef.Text);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtOwner.Text = dr["name"].ToString();
                    dpDate.Value = DateTime.Parse(dr["sdate"].ToString());
                }
                dr.Close();
                cn.Close();

            }catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
