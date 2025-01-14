namespace BMIS
{
    public partial class FrmLogin : Form
    {
        private static FrmLogin instance;
        public FrmLogin()
        {
            InitializeComponent();
            roundFrm.SetFormRoundedCorners(this, 30);
        }
        public static FrmLogin GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmLogin();
            }
            return instance;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            FrmAdmin f = new FrmAdmin();
            f.Show();
            this.Hide();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {

        }
    }
}
