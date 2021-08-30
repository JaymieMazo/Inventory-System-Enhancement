
namespace BOI_Inventory_System
{
    partial class ExpiredLicences
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
            this.dgvExpiredLicense = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiredLicense)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvExpiredLicense
            // 
            this.dgvExpiredLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpiredLicense.Location = new System.Drawing.Point(12, 12);
            this.dgvExpiredLicense.Name = "dgvExpiredLicense";
            this.dgvExpiredLicense.Size = new System.Drawing.Size(776, 391);
            this.dgvExpiredLicense.TabIndex = 0;
            // 
            // ExpiredLicences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 412);
            this.Controls.Add(this.dgvExpiredLicense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ExpiredLicences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expired Licences";
            this.Load += new System.EventHandler(this.ExpiredLicences_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiredLicense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExpiredLicense;
    }
}