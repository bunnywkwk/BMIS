namespace BMIS
{
    partial class frmPrintBarangayClearance
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            cboRef = new Guna.UI2.WinForms.Guna2ComboBox();
            txtName = new Guna.UI2.WinForms.Guna2TextBox();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Silver;
            guna2Panel1.Controls.Add(guna2Button1);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(691, 60);
            guna2Panel1.TabIndex = 4;
            // 
            // guna2Button1
            // 
            guna2Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2Button1.BackColor = Color.Transparent;
            guna2Button1.BorderRadius = 10;
            guna2Button1.Cursor = Cursors.Hand;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(30, 30, 30);
            guna2Button1.Font = new Font("Gadugi", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.HoverState.FillColor = Color.Red;
            guna2Button1.Location = new Point(625, 12);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.PressedColor = Color.Red;
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(54, 38);
            guna2Button1.TabIndex = 1;
            guna2Button1.Text = "X";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Gadugi", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(239, 24);
            label1.TabIndex = 0;
            label1.Text = "BARANGAY CLEARANCE";
            // 
            // cboRef
            // 
            cboRef.BackColor = Color.Transparent;
            cboRef.BorderRadius = 15;
            cboRef.CustomizableEdges = customizableEdges5;
            cboRef.DrawMode = DrawMode.OwnerDrawFixed;
            cboRef.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRef.FocusedColor = Color.FromArgb(94, 148, 255);
            cboRef.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboRef.Font = new Font("Segoe UI", 10F);
            cboRef.ForeColor = Color.FromArgb(68, 88, 112);
            cboRef.ItemHeight = 30;
            cboRef.Items.AddRange(new object[] { "YES ", "NO" });
            cboRef.Location = new Point(76, 108);
            cboRef.Name = "cboRef";
            cboRef.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cboRef.Size = new Size(535, 36);
            cboRef.TabIndex = 23;
            cboRef.SelectedIndexChanged += cboRef_SelectedIndexChanged;
            // 
            // txtName
            // 
            txtName.BorderRadius = 15;
            txtName.CharacterCasing = CharacterCasing.Upper;
            txtName.CustomizableEdges = customizableEdges7;
            txtName.DefaultText = "";
            txtName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Font = new Font("Segoe UI", 9F);
            txtName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Location = new Point(76, 180);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.PasswordChar = '\0';
            txtName.PlaceholderText = "";
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtName.Size = new Size(535, 34);
            txtName.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(76, 85);
            label3.Name = "label3";
            label3.Size = new Size(131, 20);
            label3.TabIndex = 20;
            label3.Text = "REFERENCE NO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 156);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 21;
            label2.Text = "NAME";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(76, 228);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 21;
            label4.Text = "ADDRESS";
            // 
            // txtAddress
            // 
            txtAddress.BorderRadius = 15;
            txtAddress.CharacterCasing = CharacterCasing.Upper;
            txtAddress.CustomizableEdges = customizableEdges9;
            txtAddress.DefaultText = "";
            txtAddress.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtAddress.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtAddress.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtAddress.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtAddress.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAddress.Font = new Font("Segoe UI", 9F);
            txtAddress.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAddress.Location = new Point(76, 252);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.PasswordChar = '\0';
            txtAddress.PlaceholderText = "";
            txtAddress.SelectedText = "";
            txtAddress.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtAddress.Size = new Size(535, 34);
            txtAddress.TabIndex = 22;
            // 
            // btnSave
            // 
            btnSave.CustomizableEdges = customizableEdges11;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.FromArgb(30, 30, 30);
            btnSave.Font = new Font("Segoe UI", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.HoverState.FillColor = Color.Silver;
            btnSave.Location = new Point(497, 308);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnSave.Size = new Size(114, 41);
            btnSave.TabIndex = 37;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // frmPrintBarangayClearance
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(691, 372);
            ControlBox = false;
            Controls.Add(btnSave);
            Controls.Add(cboRef);
            Controls.Add(txtAddress);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(guna2Panel1);
            Font = new Font("Gadugi", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmPrintBarangayClearance";
            StartPosition = FormStartPosition.CenterScreen;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Label label1;
        public Guna.UI2.WinForms.Guna2ComboBox cboRef;
        public Guna.UI2.WinForms.Guna2TextBox txtName;
        private Label label3;
        private Label label2;
        private Label label4;
        public Guna.UI2.WinForms.Guna2TextBox txtAddress;
        public Guna.UI2.WinForms.Guna2Button btnSave;
    }
}