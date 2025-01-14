namespace BMIS
{
    partial class FrmPayment
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
            label2 = new Label();
            lblREfno = new Label();
            label4 = new Label();
            cboType = new Guna.UI2.WinForms.Guna2ComboBox();
            txtName = new Guna.UI2.WinForms.Guna2TextBox();
            label3 = new Label();
            label5 = new Label();
            txtAmount = new Guna.UI2.WinForms.Guna2TextBox();
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
            guna2Panel1.Size = new Size(687, 60);
            guna2Panel1.TabIndex = 3;
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
            guna2Button1.Location = new Point(621, 12);
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
            label1.Size = new Size(191, 24);
            label1.TabIndex = 0;
            label1.Text = "PAYMENT DETAILS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gadugi", 19.8000011F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(22, 88);
            label2.Name = "label2";
            label2.Size = new Size(137, 40);
            label2.TabIndex = 4;
            label2.Text = "REF NO";
            // 
            // lblREfno
            // 
            lblREfno.AutoSize = true;
            lblREfno.Font = new Font("Gadugi", 19.8000011F, FontStyle.Bold);
            lblREfno.ForeColor = Color.Red;
            lblREfno.Location = new Point(172, 88);
            lblREfno.Name = "lblREfno";
            lblREfno.Size = new Size(271, 40);
            lblREfno.TabIndex = 4;
            lblREfno.Text = "0000000-00000";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Gadugi", 16.2F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(22, 158);
            label4.Name = "label4";
            label4.Size = new Size(80, 34);
            label4.TabIndex = 4;
            label4.Text = "TYPE";
            // 
            // cboType
            // 
            cboType.BackColor = Color.Transparent;
            cboType.BorderRadius = 15;
            cboType.CustomizableEdges = customizableEdges5;
            cboType.DrawMode = DrawMode.OwnerDrawFixed;
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboType.FocusedColor = Color.FromArgb(94, 148, 255);
            cboType.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboType.Font = new Font("Segoe UI", 10F);
            cboType.ForeColor = Color.FromArgb(68, 88, 112);
            cboType.ItemHeight = 30;
            cboType.Items.AddRange(new object[] { "BARANGAY BUSINESS CLEARANCE", "BARANGAY CLEARANCE", "OTHERS" });
            cboType.Location = new Point(181, 158);
            cboType.Name = "cboType";
            cboType.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cboType.Size = new Size(449, 36);
            cboType.TabIndex = 19;
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
            txtName.Location = new Point(181, 218);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.PasswordChar = '\0';
            txtName.PlaceholderText = "";
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtName.Size = new Size(449, 34);
            txtName.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Gadugi", 16.2F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(22, 218);
            label3.Name = "label3";
            label3.Size = new Size(99, 34);
            label3.TabIndex = 4;
            label3.Text = "NAME";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Gadugi", 16.2F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Location = new Point(22, 278);
            label5.Name = "label5";
            label5.Size = new Size(141, 34);
            label5.TabIndex = 4;
            label5.Text = "AMOUNT";
            // 
            // txtAmount
            // 
            txtAmount.BorderRadius = 15;
            txtAmount.CharacterCasing = CharacterCasing.Upper;
            txtAmount.CustomizableEdges = customizableEdges9;
            txtAmount.DefaultText = "";
            txtAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAmount.Font = new Font("Segoe UI", 9F);
            txtAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAmount.Location = new Point(181, 278);
            txtAmount.Margin = new Padding(3, 4, 3, 4);
            txtAmount.Name = "txtAmount";
            txtAmount.PasswordChar = '\0';
            txtAmount.PlaceholderText = "";
            txtAmount.SelectedText = "";
            txtAmount.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtAmount.Size = new Size(449, 34);
            txtAmount.TabIndex = 20;
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
            btnSave.Location = new Point(516, 333);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnSave.Size = new Size(114, 41);
            btnSave.TabIndex = 32;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // FrmPayment
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(687, 395);
            ControlBox = false;
            Controls.Add(btnSave);
            Controls.Add(txtAmount);
            Controls.Add(txtName);
            Controls.Add(cboType);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(lblREfno);
            Controls.Add(label2);
            Controls.Add(guna2Panel1);
            Font = new Font("Gadugi", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmPayment";
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
        private Label label2;
        private Label lblREfno;
        private Label label4;
        public Guna.UI2.WinForms.Guna2ComboBox cboType;
        public Guna.UI2.WinForms.Guna2TextBox txtName;
        private Label label3;
        private Label label5;
        public Guna.UI2.WinForms.Guna2TextBox txtAmount;
        public Guna.UI2.WinForms.Guna2Button btnSave;
    }
}