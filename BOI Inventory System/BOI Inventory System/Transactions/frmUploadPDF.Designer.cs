
namespace BOI_Inventory_System
{
    partial class frmUploadPDF
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.uploadPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtg_PDF = new System.Windows.Forms.DataGridView();
            this.btnOpen = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_PDF)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadPDFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(618, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // uploadPDFToolStripMenuItem
            // 
            this.uploadPDFToolStripMenuItem.Name = "uploadPDFToolStripMenuItem";
            this.uploadPDFToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.uploadPDFToolStripMenuItem.Text = "Upload PDF";
            this.uploadPDFToolStripMenuItem.Click += new System.EventHandler(this.uploadPDFToolStripMenuItem_Click);
            // 
            // dtg_PDF
            // 
            this.dtg_PDF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_PDF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnOpen});
            this.dtg_PDF.Location = new System.Drawing.Point(7, 30);
            this.dtg_PDF.Name = "dtg_PDF";
            this.dtg_PDF.Size = new System.Drawing.Size(599, 349);
            this.dtg_PDF.TabIndex = 1;
            this.dtg_PDF.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_PDF_CellClick);
            this.dtg_PDF.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_PDF_CellContentClick);
            // 
            // btnOpen
            // 
            this.btnOpen.HeaderText = "Download";
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnOpen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnOpen.Text = "Download PDF";
            this.btnOpen.UseColumnTextForButtonValue = true;
            // 
            // frmUploadPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 391);
            this.Controls.Add(this.dtg_PDF);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmUploadPDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uploading / Viewing PDF ";
            this.Load += new System.EventHandler(this.frmUploadPDF_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_PDF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uploadPDFToolStripMenuItem;
        private System.Windows.Forms.DataGridView dtg_PDF;
        private System.Windows.Forms.DataGridViewButtonColumn btnOpen;
    }
}