namespace BMIS
{
    partial class FrmPaymentList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPaymentList));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            txtsearch = new Guna.UI2.WinForms.Guna2TextBox();
            btnAddNew = new Guna.UI2.WinForms.Guna2Button();
            btnDelete3 = new DataGridViewImageColumn();
            btnEdit3 = new DataGridViewImageColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            dataGridView1 = new DataGridView();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(btnClose);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.ForeColor = Color.Black;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(1326, 50);
            guna2Panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BorderColor = Color.Transparent;
            btnClose.BorderRadius = 10;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges1;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.FillColor = Color.FromArgb(30, 30, 30);
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.HoverState.FillColor = Color.Red;
            btnClose.Location = new Point(1225, 7);
            btnClose.Margin = new Padding(0);
            btnClose.Name = "btnClose";
            btnClose.PressedColor = Color.Red;
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnClose.Size = new Size(91, 33);
            btnClose.TabIndex = 3;
            btnClose.Text = "{ Close }";
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gadugi", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(212, 34);
            label1.TabIndex = 0;
            label1.Text = "PAYMENT LIST";
            // 
            // guna2Panel2
            // 
            guna2Panel2.Controls.Add(txtsearch);
            guna2Panel2.Controls.Add(btnAddNew);
            guna2Panel2.CustomizableEdges = customizableEdges9;
            guna2Panel2.Dock = DockStyle.Top;
            guna2Panel2.Location = new Point(0, 50);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel2.Size = new Size(1326, 78);
            guna2Panel2.TabIndex = 3;
            // 
            // txtsearch
            // 
            txtsearch.BackColor = Color.Transparent;
            txtsearch.BorderRadius = 15;
            txtsearch.CharacterCasing = CharacterCasing.Upper;
            txtsearch.CustomizableEdges = customizableEdges5;
            txtsearch.DefaultText = "";
            txtsearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtsearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtsearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtsearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtsearch.FillColor = Color.Gainsboro;
            txtsearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtsearch.Font = new Font("Gadugi", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtsearch.ForeColor = Color.Black;
            txtsearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtsearch.IconRight = (Image)resources.GetObject("txtsearch.IconRight");
            txtsearch.IconRightCursor = Cursors.Hand;
            txtsearch.IconRightOffset = new Point(10, 0);
            txtsearch.Location = new Point(130, 19);
            txtsearch.Margin = new Padding(3, 4, 3, 4);
            txtsearch.Name = "txtsearch";
            txtsearch.PasswordChar = '\0';
            txtsearch.PlaceholderForeColor = Color.DimGray;
            txtsearch.PlaceholderText = "Search";
            txtsearch.SelectedText = "";
            txtsearch.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtsearch.Size = new Size(412, 43);
            txtsearch.TabIndex = 7;
            txtsearch.TextChanged += txtsearch_TextChanged;
            // 
            // btnAddNew
            // 
            btnAddNew.BorderColor = Color.Transparent;
            btnAddNew.BorderRadius = 10;
            btnAddNew.CustomizableEdges = customizableEdges7;
            btnAddNew.DisabledState.BorderColor = Color.DarkGray;
            btnAddNew.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddNew.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddNew.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddNew.FillColor = Color.FromArgb(30, 30, 30);
            btnAddNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.HoverState.FillColor = Color.Silver;
            btnAddNew.Location = new Point(7, 14);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnAddNew.Size = new Size(104, 52);
            btnAddNew.TabIndex = 0;
            btnAddNew.Text = "Add New";
            btnAddNew.Click += btnAddNew_Click;
            // 
            // btnDelete3
            // 
            btnDelete3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            btnDelete3.HeaderText = "";
            btnDelete3.Image = (Image)resources.GetObject("btnDelete3.Image");
            btnDelete3.MinimumWidth = 6;
            btnDelete3.Name = "btnDelete3";
            btnDelete3.Width = 6;
            // 
            // btnEdit3
            // 
            btnEdit3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            btnEdit3.HeaderText = "";
            btnEdit3.Image = (Image)resources.GetObject("btnEdit3.Image");
            btnEdit3.MinimumWidth = 6;
            btnEdit3.Name = "btnEdit3";
            btnEdit3.Visible = false;
            btnEdit3.Width = 125;
            // 
            // Column7
            // 
            Column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Column7.HeaderText = "USER";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.Width = 78;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Column4.HeaderText = "DATE";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 80;
            // 
            // Column6
            // 
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Column6.HeaderText = "AMOUNT";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 112;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Column5.HeaderText = "TYPE";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 75;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "NAME";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Column2.HeaderText = "REFNO";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 91;
            // 
            // Column1
            // 
            Column1.HeaderText = "ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Visible = false;
            Column1.Width = 125;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Gadugi", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle1.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column5, Column6, Column4, Column7, btnEdit3, btnDelete3 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Gadugi", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = SystemColors.Control;
            dataGridView1.Location = new Point(0, 128);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1326, 592);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // FrmPaymentList
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1326, 720);
            ControlBox = false;
            Controls.Add(dataGridView1);
            Controls.Add(guna2Panel2);
            Controls.Add(guna2Panel1);
            Font = new Font("Gadugi", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmPaymentList";
            WindowState = FormWindowState.Maximized;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnAddNew;
        private Guna.UI2.WinForms.Guna2TextBox txtsearch;
        private DataGridViewImageColumn btnDelete3;
        private DataGridViewImageColumn btnEdit3;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridView dataGridView1;
    }
}