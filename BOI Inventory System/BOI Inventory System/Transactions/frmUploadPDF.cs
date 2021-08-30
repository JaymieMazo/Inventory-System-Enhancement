using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace BOI_Inventory_System
{
    public partial class frmUploadPDF : Form
    {
        public frmUploadPDF()
        {
            InitializeComponent();
        }


   
        private void frmUploadPDF_Load(object sender, EventArgs e)
        {
          
            LoadData();
        }

        void LoadData()
        {
   
            SysCon.CloseConnection();
            SysCon.OpenConnection();
            string strQry = "SELECT pk_id AS NO, filename AS FILENAME FROM tbl_FileUpload ";
            SqlCommand cmd = new SqlCommand(strQry, SysCon.SystemConnect);
            SqlDataAdapter LoadData = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            LoadData.Fill(dt);
            dtg_PDF.DataSource = null;
            dtg_PDF.DataSource = dt;
            dtg_PDF.Columns[2].Width =300;
            SysCon.CloseConnection();
       }

        private void btnOpen_Click(object sender, EventArgs e)
        {
        }

        string fileName = "";
        private void uploadPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)| *.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fileName = dlg.FileName;
                    UploadFile(fileName);
                
                    LoadData();
                }

            }
        }


        void UploadFile(string filename1)
        {
            SysCon.SystemConnect.Close();
            SysCon.SystemConnect.Open();
            FileStream flStream = File.OpenRead(filename1);
            byte[] contents = new byte[flStream.Length];
            flStream.Read(contents, 0, (int)flStream.Length);
            flStream.Close();

            string qry = "Insert into tbl_FileUpload (filename, pdf_file, updateddate , updatedby, UsersPC) " +
                         "values(@filename,  @pdf,   @updateddate,  @updatedby , @UsersPC  )";
            var fi = new FileInfo(filename1);
            SqlCommand cmd = new SqlCommand(qry, SysCon.SystemConnect);
            cmd.Parameters.AddWithValue("@filename", fi.Name);

            cmd.Parameters.AddWithValue("@pdf", contents);
            cmd.Parameters.AddWithValue("@updateddate", DateTime.Now);
            cmd.Parameters.AddWithValue("@updatedby", GlobalClass.GlobalUser);
            cmd.Parameters.AddWithValue("@UsersPC", Environment.UserName);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Upload done!");
            SysCon.SystemConnect.Close();


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
                
        }

        private void dtg_PDF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dtg_PDF.Columns[e.ColumnIndex].Name == "btnOpen")
            {
                MessageBox.Show("TEST : " + dtg_PDF.CurrentRow.Cells[1].Value.ToString());
                var id = Convert.ToInt32( dtg_PDF.CurrentRow.Cells[1].Value);
                string selectedFile= dtg_PDF.CurrentRow.Cells[2].Value.ToString();
                OpenFile(id, selectedFile);
            }
        }


     private void OpenFile( int id, string fileName)
        {
            SysCon.CloseConnection();
            SysCon.OpenConnection();

            string pdf = "Select  pdf_file from tbl_FileUpload where pk_id =" + id ;
            SqlCommand cmd = new SqlCommand(pdf, SysCon.SystemConnect);
            SqlDataReader reader1 = cmd.ExecuteReader();
            if (reader1.Read())
            {
                var pdf_file = (byte[])reader1["pdf_file"];
                string newFileName = @"C:\Users\" + Environment.UserName + @"\Desktop\" + fileName  ;
                File.WriteAllBytes(newFileName, pdf_file);
                System.Diagnostics.Process.Start(newFileName);
            }
        }



        private void dtg_PDF_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dtg_PDF.CurrentRow.Cells[2].Value.ToString());
        }
    }
}
