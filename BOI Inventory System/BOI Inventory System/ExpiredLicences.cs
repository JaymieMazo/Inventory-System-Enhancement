using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BOI_Inventory_System
{
    public partial class ExpiredLicences : Form
    {
        public ExpiredLicences()
        {
            InitializeComponent();
        }

        private void ExpiredLicences_Load(object sender, EventArgs e)
        {
            loadLicense();
        }

        void loadLicense()
        {
            SysCon.CloseConnection();
            SysCon.OpenConnection();
            string strLicense = "Select * from ExpiredLicensesToday";
            SqlDataAdapter ReadExpired = new SqlDataAdapter(strLicense, SysCon.SystemConnect);
            DataTable dtLicense = new DataTable();
            ReadExpired.Fill(dtLicense);
            dgvExpiredLicense.DataSource = dtLicense;
            SysCon.CloseConnection();
        }
    }
}
