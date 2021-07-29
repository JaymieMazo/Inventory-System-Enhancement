namespace BOI_Inventory_System.File_Maintenance
{
    partial class frmReceivingItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceivingItem));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.dtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.cboStatusOfDel = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.txtReqOffice = new System.Windows.Forms.TextBox();
            this.cboMOA = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cboUnits = new System.Windows.Forms.ComboBox();
            this.btnFindOIC = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnFindSupplier = new System.Windows.Forms.Button();
            this.txtAPRNo = new System.Windows.Forms.TextBox();
            this.txtSINo = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtInspectionDate = new System.Windows.Forms.DateTimePicker();
            this.dtReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.txtDRNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInspector = new System.Windows.Forms.TextBox();
            this.txtRemarksHead = new System.Windows.Forms.TextBox();
            this.txtAcceptedBy = new System.Windows.Forms.TextBox();
            this.txtCenterCode = new System.Windows.Forms.TextBox();
            this.txtReceivedBy = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newReceivingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receivedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvItems2 = new System.Windows.Forms.DataGridView();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.RecordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArticleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EULId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subcategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Article = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EUL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateAcquired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarrantyValidity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSubscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtxtUnitCost = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkIsSubscribed = new System.Windows.Forms.CheckBox();
            this.txtStockNo = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btnAddtoGrid = new System.Windows.Forms.Button();
            this.txtReset = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnFindArticle = new System.Windows.Forms.Button();
            this.dtDateAcquired = new System.Windows.Forms.DateTimePicker();
            this.txtSubcat = new System.Windows.Forms.TextBox();
            this.btnFindItemDesc = new System.Windows.Forms.Button();
            this.txtPRNo = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.cboEUL = new System.Windows.Forms.ComboBox();
            this.txtWarrantyVaildity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnitCost = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtUOM = new System.Windows.Forms.TextBox();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label51);
            this.groupBox1.Controls.Add(this.label52);
            this.groupBox1.Controls.Add(this.dtInvoiceDate);
            this.groupBox1.Controls.Add(this.cboStatusOfDel);
            this.groupBox1.Controls.Add(this.label49);
            this.groupBox1.Controls.Add(this.label50);
            this.groupBox1.Controls.Add(this.txtReqOffice);
            this.groupBox1.Controls.Add(this.cboMOA);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.cboUnits);
            this.groupBox1.Controls.Add(this.btnFindOIC);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnFindSupplier);
            this.groupBox1.Controls.Add(this.txtAPRNo);
            this.groupBox1.Controls.Add(this.txtSINo);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dtInspectionDate);
            this.groupBox1.Controls.Add(this.dtReceivedDate);
            this.groupBox1.Controls.Add(this.txtDRNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSupplier);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtInspector);
            this.groupBox1.Controls.Add(this.txtRemarksHead);
            this.groupBox1.Controls.Add(this.txtAcceptedBy);
            this.groupBox1.Controls.Add(this.txtCenterCode);
            this.groupBox1.Controls.Add(this.txtReceivedBy);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(15, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1123, 497);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label51.Location = new System.Drawing.Point(611, 129);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(12, 11);
            this.label51.TabIndex = 62;
            this.label51.Text = "*";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(624, 125);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(84, 14);
            this.label52.TabIndex = 61;
            this.label52.Text = "Invoice Date :";
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.CustomFormat = "MM/dd/yyyy";
            this.dtInvoiceDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInvoiceDate.Location = new System.Drawing.Point(754, 119);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Size = new System.Drawing.Size(209, 21);
            this.dtInvoiceDate.TabIndex = 60;
            this.dtInvoiceDate.Value = new System.DateTime(2018, 5, 8, 0, 0, 0, 0);
            // 
            // cboStatusOfDel
            // 
            this.cboStatusOfDel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusOfDel.FormattingEnabled = true;
            this.cboStatusOfDel.Items.AddRange(new object[] {
            "Partial Delivery",
            "Complete Delivery"});
            this.cboStatusOfDel.Location = new System.Drawing.Point(378, 356);
            this.cboStatusOfDel.Name = "cboStatusOfDel";
            this.cboStatusOfDel.Size = new System.Drawing.Size(195, 19);
            this.cboStatusOfDel.TabIndex = 7;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label49.Location = new System.Drawing.Point(217, 359);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(12, 11);
            this.label49.TabIndex = 59;
            this.label49.Text = "*";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(234, 357);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(113, 14);
            this.label50.TabIndex = 58;
            this.label50.Text = "Status Of Delivery :";
            // 
            // txtReqOffice
            // 
            this.txtReqOffice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReqOffice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReqOffice.Location = new System.Drawing.Point(378, 198);
            this.txtReqOffice.Name = "txtReqOffice";
            this.txtReqOffice.Size = new System.Drawing.Size(195, 21);
            this.txtReqOffice.TabIndex = 4;
            this.txtReqOffice.TabStop = false;
            this.txtReqOffice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtReqOffice_MouseClick);
            this.txtReqOffice.Leave += new System.EventHandler(this.txtReqOffice_Leave);
            // 
            // cboMOA
            // 
            this.cboMOA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMOA.FormattingEnabled = true;
            this.cboMOA.Location = new System.Drawing.Point(378, 326);
            this.cboMOA.Name = "cboMOA";
            this.cboMOA.Size = new System.Drawing.Size(195, 19);
            this.cboMOA.TabIndex = 6;
            this.cboMOA.Click += new System.EventHandler(this.cboMOA_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label36.Location = new System.Drawing.Point(612, 276);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(12, 11);
            this.label36.TabIndex = 56;
            this.label36.Text = "*";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label35.Location = new System.Drawing.Point(611, 168);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(12, 11);
            this.label35.TabIndex = 55;
            this.label35.Text = "*";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label34.Location = new System.Drawing.Point(613, 91);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(12, 11);
            this.label34.TabIndex = 54;
            this.label34.Text = "*";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label33.Location = new System.Drawing.Point(204, 329);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(12, 11);
            this.label33.TabIndex = 53;
            this.label33.Text = "*";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label32.Location = new System.Drawing.Point(271, 276);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(12, 11);
            this.label32.TabIndex = 52;
            this.label32.Text = "*";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label31.Location = new System.Drawing.Point(166, 203);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(12, 11);
            this.label31.TabIndex = 51;
            this.label31.Text = "*";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label30.Location = new System.Drawing.Point(252, 168);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(12, 11);
            this.label30.TabIndex = 50;
            this.label30.Text = "*";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label29.Location = new System.Drawing.Point(222, 129);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(12, 11);
            this.label29.TabIndex = 49;
            this.label29.Text = "*";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label28.Location = new System.Drawing.Point(204, 90);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(12, 11);
            this.label28.TabIndex = 48;
            this.label28.Text = "*";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboUnits
            // 
            this.cboUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnits.Enabled = false;
            this.cboUnits.FormattingEnabled = true;
            this.cboUnits.Location = new System.Drawing.Point(6, 450);
            this.cboUnits.Name = "cboUnits";
            this.cboUnits.Size = new System.Drawing.Size(195, 19);
            this.cboUnits.TabIndex = 4;
            this.cboUnits.TabStop = false;
            this.cboUnits.Visible = false;
            this.cboUnits.SelectedIndexChanged += new System.EventHandler(this.cboUnits_SelectedIndexChanged);
            this.cboUnits.Click += new System.EventHandler(this.cboUnits_Click);
            // 
            // btnFindOIC
            // 
            this.btnFindOIC.BackgroundImage = global::BOI_Inventory_System.Properties.Resources.search11;
            this.btnFindOIC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFindOIC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindOIC.Location = new System.Drawing.Point(939, 269);
            this.btnFindOIC.Name = "btnFindOIC";
            this.btnFindOIC.Size = new System.Drawing.Size(24, 24);
            this.btnFindOIC.TabIndex = 12;
            this.btnFindOIC.UseVisualStyleBackColor = true;
            this.btnFindOIC.Click += new System.EventHandler(this.btnFindOIC_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Azure;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(806, 421);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(77, 27);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Azure;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(889, 421);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(74, 27);
            this.btnNext.TabIndex = 14;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(221, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 14);
            this.label9.TabIndex = 20;
            this.label9.Text = "Mode of  Acquisition :";
            // 
            // btnFindSupplier
            // 
            this.btnFindSupplier.BackColor = System.Drawing.Color.Teal;
            this.btnFindSupplier.BackgroundImage = global::BOI_Inventory_System.Properties.Resources.search11;
            this.btnFindSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFindSupplier.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindSupplier.Location = new System.Drawing.Point(549, 268);
            this.btnFindSupplier.Name = "btnFindSupplier";
            this.btnFindSupplier.Size = new System.Drawing.Size(24, 24);
            this.btnFindSupplier.TabIndex = 5;
            this.btnFindSupplier.UseVisualStyleBackColor = false;
            this.btnFindSupplier.Click += new System.EventHandler(this.btnFindSupplier_Click);
            // 
            // txtAPRNo
            // 
            this.txtAPRNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAPRNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPRNo.Location = new System.Drawing.Point(378, 163);
            this.txtAPRNo.Name = "txtAPRNo";
            this.txtAPRNo.Size = new System.Drawing.Size(195, 21);
            this.txtAPRNo.TabIndex = 3;
            this.txtAPRNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAPRNo_MouseClick);
            this.txtAPRNo.TabStopChanged += new System.EventHandler(this.txtAPRNo_TabStopChanged);
            this.txtAPRNo.Leave += new System.EventHandler(this.txtAPRNo_Leave);
            // 
            // txtSINo
            // 
            this.txtSINo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSINo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSINo.Location = new System.Drawing.Point(378, 124);
            this.txtSINo.Name = "txtSINo";
            this.txtSINo.Size = new System.Drawing.Size(195, 21);
            this.txtSINo.TabIndex = 2;
            this.txtSINo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSINo_MouseClick);
            this.txtSINo.TextChanged += new System.EventHandler(this.txtSINo_TextChanged);
            this.txtSINo.Leave += new System.EventHandler(this.txtSINo_Leave);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(649, 313);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 14);
            this.label25.TabIndex = 16;
            this.label25.Text = "Remarks :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(625, 274);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(85, 14);
            this.label24.TabIndex = 16;
            this.label24.Text = "Accepted By :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(609, 238);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(102, 14);
            this.label23.TabIndex = 16;
            this.label23.Text = "Inspection Date :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(624, 164);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 14);
            this.label17.TabIndex = 16;
            this.label17.Text = "Receive Date :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(624, 201);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(87, 14);
            this.label22.TabIndex = 19;
            this.label22.Text = "Inspected By :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(631, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 14);
            this.label16.TabIndex = 19;
            this.label16.Text = "Received By :";
            // 
            // dtInspectionDate
            // 
            this.dtInspectionDate.CustomFormat = "MM/dd/yyyy";
            this.dtInspectionDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInspectionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInspectionDate.Location = new System.Drawing.Point(754, 234);
            this.dtInspectionDate.Name = "dtInspectionDate";
            this.dtInspectionDate.Size = new System.Drawing.Size(209, 21);
            this.dtInspectionDate.TabIndex = 11;
            this.dtInspectionDate.Value = new System.DateTime(2017, 12, 8, 0, 0, 0, 0);
            this.dtInspectionDate.DropDown += new System.EventHandler(this.dtInspectionDate_DropDown);
            this.dtInspectionDate.Leave += new System.EventHandler(this.dtInspectionDate_Leave);
            // 
            // dtReceivedDate
            // 
            this.dtReceivedDate.CustomFormat = "MM/dd/yyyy";
            this.dtReceivedDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceivedDate.Location = new System.Drawing.Point(754, 158);
            this.dtReceivedDate.Name = "dtReceivedDate";
            this.dtReceivedDate.Size = new System.Drawing.Size(209, 21);
            this.dtReceivedDate.TabIndex = 9;
            this.dtReceivedDate.Value = new System.DateTime(2017, 12, 8, 0, 0, 0, 0);
            this.dtReceivedDate.ValueChanged += new System.EventHandler(this.dtReceivedDate_ValueChanged);
            this.dtReceivedDate.DropDown += new System.EventHandler(this.dtReceivedDate_DropDown);
            this.dtReceivedDate.Leave += new System.EventHandler(this.dtReceivedDate_Leave);
            // 
            // txtDRNo
            // 
            this.txtDRNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDRNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRNo.Location = new System.Drawing.Point(378, 86);
            this.txtDRNo.Name = "txtDRNo";
            this.txtDRNo.Size = new System.Drawing.Size(195, 21);
            this.txtDRNo.TabIndex = 1;
            this.txtDRNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDRNo_MouseClick);
            this.txtDRNo.TabStopChanged += new System.EventHandler(this.txtDRNo_TabStopChanged);
            this.txtDRNo.TextChanged += new System.EventHandler(this.txtDRNo_TextChanged);
            this.txtDRNo.Leave += new System.EventHandler(this.txtDRNo_Leave);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(184, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Requisitioning Office/Dept. :";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Enabled = false;
            this.txtSupplier.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(378, 269);
            this.txtSupplier.Multiline = true;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(167, 47);
            this.txtSupplier.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(222, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "Delivery Receipt No. :";
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(186, 240);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(172, 23);
            this.label26.TabIndex = 0;
            this.label26.Text = "Responsibility Center Code :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(271, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "APR/ P.O No :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(238, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "Sales Invoice No. :";
            // 
            // txtInspector
            // 
            this.txtInspector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInspector.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInspector.Location = new System.Drawing.Point(754, 196);
            this.txtInspector.Name = "txtInspector";
            this.txtInspector.Size = new System.Drawing.Size(209, 21);
            this.txtInspector.TabIndex = 10;
            this.txtInspector.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtInspector_MouseClick);
            this.txtInspector.TextChanged += new System.EventHandler(this.txtInspector_TextChanged);
            this.txtInspector.Leave += new System.EventHandler(this.txtInspector_Leave);
            // 
            // txtRemarksHead
            // 
            this.txtRemarksHead.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemarksHead.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarksHead.Location = new System.Drawing.Point(754, 309);
            this.txtRemarksHead.Multiline = true;
            this.txtRemarksHead.Name = "txtRemarksHead";
            this.txtRemarksHead.Size = new System.Drawing.Size(209, 66);
            this.txtRemarksHead.TabIndex = 13;
            this.txtRemarksHead.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRemarksHead_MouseClick);
            this.txtRemarksHead.Leave += new System.EventHandler(this.txtRemarksHead_Leave);
            // 
            // txtAcceptedBy
            // 
            this.txtAcceptedBy.Enabled = false;
            this.txtAcceptedBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcceptedBy.Location = new System.Drawing.Point(754, 271);
            this.txtAcceptedBy.Name = "txtAcceptedBy";
            this.txtAcceptedBy.Size = new System.Drawing.Size(179, 21);
            this.txtAcceptedBy.TabIndex = 12;
            this.txtAcceptedBy.TabStop = false;
            this.txtAcceptedBy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAcceptedBy_MouseClick);
            this.txtAcceptedBy.Leave += new System.EventHandler(this.txtAcceptedBy_Leave);
            // 
            // txtCenterCode
            // 
            this.txtCenterCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCenterCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCenterCode.Location = new System.Drawing.Point(378, 238);
            this.txtCenterCode.Name = "txtCenterCode";
            this.txtCenterCode.Size = new System.Drawing.Size(195, 21);
            this.txtCenterCode.TabIndex = 5;
            this.txtCenterCode.TabStop = false;
            this.txtCenterCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCenterCode_MouseClick);
            this.txtCenterCode.Leave += new System.EventHandler(this.txtCenterCode_Leave);
            // 
            // txtReceivedBy
            // 
            this.txtReceivedBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceivedBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceivedBy.Location = new System.Drawing.Point(754, 85);
            this.txtReceivedBy.Name = "txtReceivedBy";
            this.txtReceivedBy.Size = new System.Drawing.Size(209, 21);
            this.txtReceivedBy.TabIndex = 8;
            this.txtReceivedBy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtReceivedBy_MouseClick);
            this.txtReceivedBy.Leave += new System.EventHandler(this.txtReceivedBy_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(287, 274);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "Supplier :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1199, 24);
            this.menuStrip1.TabIndex = 42;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newReceivingReportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newReceivingReportToolStripMenuItem
            // 
            this.newReceivingReportToolStripMenuItem.Name = "newReceivingReportToolStripMenuItem";
            this.newReceivingReportToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.newReceivingReportToolStripMenuItem.Text = "New Receiving Report";
            this.newReceivingReportToolStripMenuItem.Click += new System.EventHandler(this.newReceivingReportToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receiviToolStripMenuItem,
            this.receivedItemsToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // receiviToolStripMenuItem
            // 
            this.receiviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postToolStripMenuItem});
            this.receiviToolStripMenuItem.Name = "receiviToolStripMenuItem";
            this.receiviToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.receiviToolStripMenuItem.Text = "Receiving Report";
            this.receiviToolStripMenuItem.Click += new System.EventHandler(this.receiviToolStripMenuItem_Click);
            // 
            // postToolStripMenuItem
            // 
            this.postToolStripMenuItem.Name = "postToolStripMenuItem";
            this.postToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.postToolStripMenuItem.Text = "Post";
            this.postToolStripMenuItem.Click += new System.EventHandler(this.postToolStripMenuItem_Click);
            // 
            // receivedItemsToolStripMenuItem
            // 
            this.receivedItemsToolStripMenuItem.Name = "receivedItemsToolStripMenuItem";
            this.receivedItemsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.receivedItemsToolStripMenuItem.Text = "Received Items";
            this.receivedItemsToolStripMenuItem.Click += new System.EventHandler(this.receivedItemsToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1172, 604);
            this.tabControl1.TabIndex = 43;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1164, 577);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Receiving Items Head";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label44);
            this.groupBox5.Controls.Add(this.label45);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(15, 524);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(351, 47);
            this.groupBox5.TabIndex = 66;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Note:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Teal;
            this.label44.Location = new System.Drawing.Point(32, 19);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(89, 13);
            this.label44.TabIndex = 24;
            this.label44.Text = "- Required fields.";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.Red;
            this.label45.Location = new System.Drawing.Point(15, 19);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(15, 20);
            this.label45.TabIndex = 23;
            this.label45.Text = "*";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1164, 577);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Receiving Items Details";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.dgvItems2);
            this.groupBox3.Controls.Add(this.dgvItems);
            this.groupBox3.Controls.Add(this.mtxtUnitCost);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Teal;
            this.groupBox3.Location = new System.Drawing.Point(465, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(684, 553);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Received Items List :";
            this.groupBox3.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label46);
            this.groupBox4.Controls.Add(this.btnPrev);
            this.groupBox4.Controls.Add(this.label47);
            this.groupBox4.Controls.Add(this.btnSaveUpdate);
            this.groupBox4.Controls.Add(this.btnClear);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(20, 464);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(651, 57);
            this.groupBox4.TabIndex = 81;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Note:";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(32, 23);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(89, 13);
            this.label46.TabIndex = 24;
            this.label46.Text = "- Required fields.";
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Azure;
            this.btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(404, 19);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(78, 27);
            this.btnPrev.TabIndex = 15;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.Red;
            this.label47.Location = new System.Drawing.Point(15, 23);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(15, 20);
            this.label47.TabIndex = 23;
            this.label47.Text = "*";
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.BackColor = System.Drawing.Color.Azure;
            this.btnSaveUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveUpdate.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUpdate.ForeColor = System.Drawing.Color.Teal;
            this.btnSaveUpdate.Location = new System.Drawing.Point(570, 19);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(75, 27);
            this.btnSaveUpdate.TabIndex = 14;
            this.btnSaveUpdate.Text = "Save";
            this.btnSaveUpdate.UseVisualStyleBackColor = false;
            this.btnSaveUpdate.Visible = false;
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Azure;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Teal;
            this.btnClear.Location = new System.Drawing.Point(488, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 27);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvItems2
            // 
            this.dgvItems2.AllowUserToAddRows = false;
            this.dgvItems2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItems2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems2.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems2.Location = new System.Drawing.Point(20, 36);
            this.dgvItems2.Name = "dgvItems2";
            this.dgvItems2.ReadOnly = true;
            this.dgvItems2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems2.Size = new System.Drawing.Size(651, 414);
            this.dgvItems2.TabIndex = 33;
            this.dgvItems2.Visible = false;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecordId,
            this.ArticleId,
            this.ItemCode,
            this.SupplierId,
            this.EULId,
            this.PRNo,
            this.CategoryName,
            this.Subcategory,
            this.Article,
            this.ItemDescription,
            this.UOM,
            this.Serial_No,
            this.Quantity,
            this.UnitCost,
            this.TotalCost,
            this.EUL,
            this.DateAcquired,
            this.WarrantyValidity,
            this.Remarks,
            this.StockNo,
            this.IsSubscription,
            this.EOS});
            this.dgvItems.Location = new System.Drawing.Point(20, 36);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(651, 396);
            this.dgvItems.TabIndex = 26;
            // 
            // RecordId
            // 
            this.RecordId.HeaderText = "RecordId";
            this.RecordId.Name = "RecordId";
            this.RecordId.ReadOnly = true;
            this.RecordId.Visible = false;
            // 
            // ArticleId
            // 
            this.ArticleId.HeaderText = "ArticleId";
            this.ArticleId.Name = "ArticleId";
            this.ArticleId.ReadOnly = true;
            this.ArticleId.Visible = false;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "ItemCode";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            this.ItemCode.Visible = false;
            // 
            // SupplierId
            // 
            this.SupplierId.HeaderText = "SupplierId";
            this.SupplierId.Name = "SupplierId";
            this.SupplierId.ReadOnly = true;
            this.SupplierId.Visible = false;
            // 
            // EULId
            // 
            this.EULId.HeaderText = "EULId";
            this.EULId.Name = "EULId";
            this.EULId.ReadOnly = true;
            this.EULId.Visible = false;
            // 
            // PRNo
            // 
            this.PRNo.HeaderText = "PR No.";
            this.PRNo.Name = "PRNo";
            this.PRNo.ReadOnly = true;
            // 
            // CategoryName
            // 
            this.CategoryName.HeaderText = "Category Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            // 
            // Subcategory
            // 
            this.Subcategory.HeaderText = "Subcategory";
            this.Subcategory.Name = "Subcategory";
            this.Subcategory.ReadOnly = true;
            // 
            // Article
            // 
            this.Article.HeaderText = "Article";
            this.Article.Name = "Article";
            this.Article.ReadOnly = true;
            // 
            // ItemDescription
            // 
            this.ItemDescription.HeaderText = "Item Description";
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.ReadOnly = true;
            // 
            // UOM
            // 
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            this.UOM.ReadOnly = true;
            // 
            // Serial_No
            // 
            this.Serial_No.HeaderText = "Serial_No";
            this.Serial_No.Name = "Serial_No";
            this.Serial_No.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // UnitCost
            // 
            this.UnitCost.HeaderText = "Unit Cost";
            this.UnitCost.Name = "UnitCost";
            this.UnitCost.ReadOnly = true;
            // 
            // TotalCost
            // 
            this.TotalCost.HeaderText = "Total Cost";
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            // 
            // EUL
            // 
            this.EUL.HeaderText = "Estimated Useful Life";
            this.EUL.Name = "EUL";
            this.EUL.ReadOnly = true;
            // 
            // DateAcquired
            // 
            this.DateAcquired.HeaderText = "Date Acquired";
            this.DateAcquired.Name = "DateAcquired";
            this.DateAcquired.ReadOnly = true;
            // 
            // WarrantyValidity
            // 
            this.WarrantyValidity.HeaderText = "Warranty Validity";
            this.WarrantyValidity.Name = "WarrantyValidity";
            this.WarrantyValidity.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // StockNo
            // 
            this.StockNo.HeaderText = "Stock No.";
            this.StockNo.Name = "StockNo";
            this.StockNo.ReadOnly = true;
            // 
            // IsSubscription
            // 
            this.IsSubscription.HeaderText = "IsSubscription?";
            this.IsSubscription.Name = "IsSubscription";
            this.IsSubscription.ReadOnly = true;
            // 
            // EOS
            // 
            this.EOS.HeaderText = "EndOfService";
            this.EOS.Name = "EOS";
            this.EOS.ReadOnly = true;
            // 
            // mtxtUnitCost
            // 
            this.mtxtUnitCost.Enabled = false;
            this.mtxtUnitCost.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtUnitCost.Location = new System.Drawing.Point(331, 527);
            this.mtxtUnitCost.Mask = "\"Php 00000000000000.00\"";
            this.mtxtUnitCost.Name = "mtxtUnitCost";
            this.mtxtUnitCost.Size = new System.Drawing.Size(171, 20);
            this.mtxtUnitCost.TabIndex = 69;
            this.mtxtUnitCost.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtUnitCost.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkIsSubscribed);
            this.groupBox2.Controls.Add(this.txtStockNo);
            this.groupBox2.Controls.Add(this.label53);
            this.groupBox2.Controls.Add(this.label48);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.label40);
            this.groupBox2.Controls.Add(this.label39);
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Controls.Add(this.txtSerialNo);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.btnAddtoGrid);
            this.groupBox2.Controls.Add(this.txtReset);
            this.groupBox2.Controls.Add(this.btnAddItem);
            this.groupBox2.Controls.Add(this.btnFindArticle);
            this.groupBox2.Controls.Add(this.dtDateAcquired);
            this.groupBox2.Controls.Add(this.txtSubcat);
            this.groupBox2.Controls.Add(this.btnFindItemDesc);
            this.groupBox2.Controls.Add(this.txtPRNo);
            this.groupBox2.Controls.Add(this.txtCategory);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtArticle);
            this.groupBox2.Controls.Add(this.cboEUL);
            this.groupBox2.Controls.Add(this.txtWarrantyVaildity);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtRemarks);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtTotalCost);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtUnitCost);
            this.groupBox2.Controls.Add(this.txtQuantity);
            this.groupBox2.Controls.Add(this.txtUOM);
            this.groupBox2.Controls.Add(this.txtItemDesc);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 553);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // chkIsSubscribed
            // 
            this.chkIsSubscribed.AutoSize = true;
            this.chkIsSubscribed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsSubscribed.Location = new System.Drawing.Point(183, 249);
            this.chkIsSubscribed.Name = "chkIsSubscribed";
            this.chkIsSubscribed.Size = new System.Drawing.Size(12, 11);
            this.chkIsSubscribed.TabIndex = 84;
            this.chkIsSubscribed.UseVisualStyleBackColor = true;
            this.chkIsSubscribed.CheckedChanged += new System.EventHandler(this.chkIsSubscribed_CheckedChanged);
            // 
            // txtStockNo
            // 
            this.txtStockNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStockNo.Location = new System.Drawing.Point(181, 480);
            this.txtStockNo.Name = "txtStockNo";
            this.txtStockNo.Size = new System.Drawing.Size(160, 21);
            this.txtStockNo.TabIndex = 11;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(198, 247);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(188, 14);
            this.label53.TabIndex = 82;
            this.label53.Text = "Subscription? (for Software only)";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(93, 482);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(69, 14);
            this.label48.TabIndex = 81;
            this.label48.Text = "Stock No. :";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label43.Location = new System.Drawing.Point(55, 408);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(13, 13);
            this.label43.TabIndex = 80;
            this.label43.Text = "*";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label42.Location = new System.Drawing.Point(24, 377);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(13, 13);
            this.label42.TabIndex = 79;
            this.label42.Text = "*";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label41.Location = new System.Drawing.Point(34, 311);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(13, 13);
            this.label41.TabIndex = 78;
            this.label41.Text = "*";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label40.Location = new System.Drawing.Point(78, 280);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(13, 13);
            this.label40.TabIndex = 77;
            this.label40.Text = "*";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label39.Location = new System.Drawing.Point(43, 133);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(13, 13);
            this.label39.TabIndex = 76;
            this.label39.Text = "*";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label38.Location = new System.Drawing.Point(97, 49);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(13, 13);
            this.label38.TabIndex = 75;
            this.label38.Text = "*";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label37.Location = new System.Drawing.Point(17, 21);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(13, 13);
            this.label37.TabIndex = 74;
            this.label37.Text = "*";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerialNo.Location = new System.Drawing.Point(182, 207);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(235, 21);
            this.txtSerialNo.TabIndex = 4;
            this.txtSerialNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSerialNo_MouseClick);
            this.txtSerialNo.TextChanged += new System.EventHandler(this.txtSerialNo_TextChanged);
            this.txtSerialNo.Leave += new System.EventHandler(this.txtSerialNo_Leave);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(94, 209);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(66, 14);
            this.label27.TabIndex = 73;
            this.label27.Text = "Serial No. :";
            // 
            // btnAddtoGrid
            // 
            this.btnAddtoGrid.BackColor = System.Drawing.Color.Azure;
            this.btnAddtoGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddtoGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddtoGrid.Location = new System.Drawing.Point(347, 518);
            this.btnAddtoGrid.Name = "btnAddtoGrid";
            this.btnAddtoGrid.Size = new System.Drawing.Size(85, 28);
            this.btnAddtoGrid.TabIndex = 13;
            this.btnAddtoGrid.Text = "Add Item";
            this.btnAddtoGrid.UseVisualStyleBackColor = false;
            this.btnAddtoGrid.Click += new System.EventHandler(this.btnAddtoGrid_Click);
            // 
            // txtReset
            // 
            this.txtReset.Location = new System.Drawing.Point(1135, 222);
            this.txtReset.Name = "txtReset";
            this.txtReset.Size = new System.Drawing.Size(58, 26);
            this.txtReset.TabIndex = 71;
            this.txtReset.Text = "Clear";
            this.txtReset.UseVisualStyleBackColor = true;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(1067, 222);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(62, 26);
            this.btnAddItem.TabIndex = 70;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            // 
            // btnFindArticle
            // 
            this.btnFindArticle.BackColor = System.Drawing.Color.Azure;
            this.btnFindArticle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindArticle.BackgroundImage")));
            this.btnFindArticle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindArticle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindArticle.Location = new System.Drawing.Point(390, 44);
            this.btnFindArticle.Name = "btnFindArticle";
            this.btnFindArticle.Size = new System.Drawing.Size(26, 23);
            this.btnFindArticle.TabIndex = 2;
            this.btnFindArticle.UseVisualStyleBackColor = false;
            this.btnFindArticle.Click += new System.EventHandler(this.btnFindArticle_Click);
            // 
            // dtDateAcquired
            // 
            this.dtDateAcquired.CustomFormat = "MM/dd/yyyy";
            this.dtDateAcquired.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateAcquired.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateAcquired.Location = new System.Drawing.Point(182, 407);
            this.dtDateAcquired.Name = "dtDateAcquired";
            this.dtDateAcquired.Size = new System.Drawing.Size(158, 20);
            this.dtDateAcquired.TabIndex = 9;
            this.dtDateAcquired.Value = new System.DateTime(2018, 9, 12, 0, 0, 0, 0);
            // 
            // txtSubcat
            // 
            this.txtSubcat.Enabled = false;
            this.txtSubcat.Location = new System.Drawing.Point(183, 100);
            this.txtSubcat.Name = "txtSubcat";
            this.txtSubcat.Size = new System.Drawing.Size(234, 21);
            this.txtSubcat.TabIndex = 45;
            // 
            // btnFindItemDesc
            // 
            this.btnFindItemDesc.BackColor = System.Drawing.Color.Azure;
            this.btnFindItemDesc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindItemDesc.BackgroundImage")));
            this.btnFindItemDesc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindItemDesc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindItemDesc.Location = new System.Drawing.Point(390, 127);
            this.btnFindItemDesc.Name = "btnFindItemDesc";
            this.btnFindItemDesc.Size = new System.Drawing.Size(26, 23);
            this.btnFindItemDesc.TabIndex = 3;
            this.btnFindItemDesc.UseVisualStyleBackColor = false;
            this.btnFindItemDesc.Click += new System.EventHandler(this.btnFindItemDesc_Click);
            // 
            // txtPRNo
            // 
            this.txtPRNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPRNo.Location = new System.Drawing.Point(182, 16);
            this.txtPRNo.Name = "txtPRNo";
            this.txtPRNo.Size = new System.Drawing.Size(233, 21);
            this.txtPRNo.TabIndex = 1;
            // 
            // txtCategory
            // 
            this.txtCategory.Enabled = false;
            this.txtCategory.Location = new System.Drawing.Point(183, 74);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(234, 21);
            this.txtCategory.TabIndex = 48;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(100, 513);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 14);
            this.label18.TabIndex = 56;
            this.label18.Text = "Remarks :";
            // 
            // txtArticle
            // 
            this.txtArticle.Enabled = false;
            this.txtArticle.Location = new System.Drawing.Point(183, 46);
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(202, 21);
            this.txtArticle.TabIndex = 49;
            // 
            // cboEUL
            // 
            this.cboEUL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEUL.FormattingEnabled = true;
            this.cboEUL.Location = new System.Drawing.Point(182, 374);
            this.cboEUL.Name = "cboEUL";
            this.cboEUL.Size = new System.Drawing.Size(158, 21);
            this.cboEUL.TabIndex = 7;
            this.cboEUL.SelectedIndexChanged += new System.EventHandler(this.cboEUL_SelectedIndexChanged);
            this.cboEUL.Click += new System.EventHandler(this.cboEUL_Click);
            // 
            // txtWarrantyVaildity
            // 
            this.txtWarrantyVaildity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWarrantyVaildity.Location = new System.Drawing.Point(182, 443);
            this.txtWarrantyVaildity.Name = "txtWarrantyVaildity";
            this.txtWarrantyVaildity.Size = new System.Drawing.Size(160, 21);
            this.txtWarrantyVaildity.TabIndex = 10;
            this.txtWarrantyVaildity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtWarrantyVaildity_MouseClick_1);
            this.txtWarrantyVaildity.Leave += new System.EventHandler(this.txtWarrantyVaildity_Leave_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 14);
            this.label8.TabIndex = 44;
            this.label8.Text = "Purchase Request No. :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemarks.Location = new System.Drawing.Point(181, 513);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(160, 33);
            this.txtRemarks.TabIndex = 12;
            this.txtRemarks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRemarks_MouseClick_1);
            this.txtRemarks.Leave += new System.EventHandler(this.txtRemarks_Leave_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(97, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 14);
            this.label4.TabIndex = 43;
            this.label4.Text = "Category :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "Subcategory :";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Enabled = false;
            this.txtTotalCost.Location = new System.Drawing.Point(182, 343);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Size = new System.Drawing.Size(158, 21);
            this.txtTotalCost.TabIndex = 21;
            this.txtTotalCost.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 40;
            this.label1.Text = "Article :";
            // 
            // txtUnitCost
            // 
            this.txtUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnitCost.Location = new System.Drawing.Point(182, 308);
            this.txtUnitCost.Name = "txtUnitCost";
            this.txtUnitCost.Size = new System.Drawing.Size(159, 21);
            this.txtUnitCost.TabIndex = 6;
            this.txtUnitCost.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtUnitCost_MouseClick_1);
            this.txtUnitCost.TextChanged += new System.EventHandler(this.txtUnitCost_TextChanged);
            this.txtUnitCost.Leave += new System.EventHandler(this.txtUnitCost_Leave_1);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(181, 280);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(159, 21);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtQuantity_MouseClick_1);
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.Leave += new System.EventHandler(this.txtQuantity_Leave_1);
            // 
            // txtUOM
            // 
            this.txtUOM.Enabled = false;
            this.txtUOM.Location = new System.Drawing.Point(183, 175);
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.Size = new System.Drawing.Size(233, 21);
            this.txtUOM.TabIndex = 17;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.Enabled = false;
            this.txtItemDesc.Location = new System.Drawing.Point(183, 127);
            this.txtItemDesc.Multiline = true;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(203, 41);
            this.txtItemDesc.TabIndex = 59;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(55, 446);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 14);
            this.label13.TabIndex = 57;
            this.label13.Text = "Warranty Validity :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(66, 407);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 14);
            this.label15.TabIndex = 54;
            this.label15.Text = "Date Acquired  :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(34, 376);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 14);
            this.label14.TabIndex = 53;
            this.label14.Text = "Estimated Useful Life :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(44, 345);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(119, 14);
            this.label19.TabIndex = 58;
            this.label19.Text = "Total Cost (in Php) :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(60, 177);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(101, 14);
            this.label21.TabIndex = 58;
            this.label21.Text = "Unit of Measure :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(97, 280);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 14);
            this.label20.TabIndex = 58;
            this.label20.Text = "Quantity :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 14);
            this.label5.TabIndex = 58;
            this.label5.Text = "Unit Cost (in Php) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 51;
            this.label3.Text = "Item Description :";
            // 
            // frmReceivingItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1199, 646);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmReceivingItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receiving Item";
            this.Load += new System.EventHandler(this.frmReceivingItem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSINo;
        private System.Windows.Forms.TextBox txtDRNo;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Button btnFindSupplier;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtReceivedDate;
        private System.Windows.Forms.TextBox txtReceivedBy;
        private System.Windows.Forms.TextBox txtAPRNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtInspectionDate;
        private System.Windows.Forms.TextBox txtInspector;
        private System.Windows.Forms.TextBox txtAcceptedBy;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtRemarksHead;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtCenterCode;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddtoGrid;
        private System.Windows.Forms.MaskedTextBox mtxtUnitCost;
        private System.Windows.Forms.Button txtReset;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnFindArticle;
        private System.Windows.Forms.DateTimePicker dtDateAcquired;
        private System.Windows.Forms.TextBox txtSubcat;
        private System.Windows.Forms.Button btnFindItemDesc;
        private System.Windows.Forms.TextBox txtPRNo;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.ComboBox cboEUL;
        private System.Windows.Forms.TextBox txtWarrantyVaildity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnitCost;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtUOM;
        private System.Windows.Forms.TextBox txtItemDesc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DataGridView dgvItems2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem newReceivingReportToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnFindOIC;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.ComboBox cboUnits;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ComboBox cboMOA;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receivedItemsToolStripMenuItem;
        private System.Windows.Forms.TextBox txtStockNo;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtReqOffice;
        private System.Windows.Forms.ComboBox cboStatusOfDel;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.DateTimePicker dtInvoiceDate;
        private System.Windows.Forms.ToolStripMenuItem postToolStripMenuItem;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.CheckBox chkIsSubscribed;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EULId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subcategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Article;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn EUL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateAcquired;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarrantyValidity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSubscription;
        private System.Windows.Forms.DataGridViewTextBoxColumn EOS;
    }
}