namespace BOI_Inventory_System
{
    partial class frmAssignmentPerEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssignmentPerEmployee));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cboOffice = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDocType = new System.Windows.Forms.ComboBox();
            this.chkDocNo = new System.Windows.Forms.CheckBox();
            this.btnFindIssuer = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.btnFindAcc = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.dtIssuanceDate = new System.Windows.Forms.DateTimePicker();
            this.dtReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.txtFundCluster = new System.Windows.Forms.TextBox();
            this.txtAccountable = new System.Windows.Forms.TextBox();
            this.txtIssuedBy = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtnewpn = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboTagClass = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.btnAddtoGrid = new System.Windows.Forms.Button();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.btnFindItemdesc = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.RecordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountableId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OICId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acquisition_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UACS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Article_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.New_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUnitCost = new System.Windows.Forms.TextBox();
            this.txtPropertyNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.txtEndUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.cboOffice);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboDocType);
            this.groupBox1.Controls.Add(this.chkDocNo);
            this.groupBox1.Controls.Add(this.btnFindIssuer);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.btnFindAcc);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtDocNo);
            this.groupBox1.Controls.Add(this.dtIssuanceDate);
            this.groupBox1.Controls.Add(this.dtReceivedDate);
            this.groupBox1.Controls.Add(this.txtFundCluster);
            this.groupBox1.Controls.Add(this.txtAccountable);
            this.groupBox1.Controls.Add(this.txtIssuedBy);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(866, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(439, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 14);
            this.label18.TabIndex = 23;
            this.label18.Text = "*";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboOffice
            // 
            this.cboOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOffice.FormattingEnabled = true;
            this.cboOffice.Items.AddRange(new object[] {
            "MNL",
            "CEB",
            "CDO",
            "DVO"});
            this.cboOffice.Location = new System.Drawing.Point(605, 47);
            this.cboOffice.Name = "cboOffice";
            this.cboOffice.Size = new System.Drawing.Size(234, 22);
            this.cboOffice.TabIndex = 22;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(450, 50);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(129, 14);
            this.label19.TabIndex = 21;
            this.label19.Text = "Office of Assignment :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(458, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 14);
            this.label13.TabIndex = 20;
            this.label13.Text = "*";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(68, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 19;
            this.label9.Text = "*";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(14, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboDocType
            // 
            this.cboDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocType.FormattingEnabled = true;
            this.cboDocType.Items.AddRange(new object[] {
            "PAR",
            "ICS"});
            this.cboDocType.Location = new System.Drawing.Point(605, 77);
            this.cboDocType.Name = "cboDocType";
            this.cboDocType.Size = new System.Drawing.Size(234, 22);
            this.cboDocType.TabIndex = 5;
            this.cboDocType.SelectedIndexChanged += new System.EventHandler(this.cboDocType_SelectedIndexChanged);
            // 
            // chkDocNo
            // 
            this.chkDocNo.AutoSize = true;
            this.chkDocNo.BackColor = System.Drawing.Color.White;
            this.chkDocNo.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.chkDocNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDocNo.Location = new System.Drawing.Point(468, 108);
            this.chkDocNo.Name = "chkDocNo";
            this.chkDocNo.Size = new System.Drawing.Size(111, 18);
            this.chkDocNo.TabIndex = 6;
            this.chkDocNo.Text = "Document No. :";
            this.chkDocNo.UseVisualStyleBackColor = false;
            this.chkDocNo.CheckedChanged += new System.EventHandler(this.chkDocNo_CheckedChanged);
            // 
            // btnFindIssuer
            // 
            this.btnFindIssuer.BackColor = System.Drawing.Color.Azure;
            this.btnFindIssuer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindIssuer.BackgroundImage")));
            this.btnFindIssuer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindIssuer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindIssuer.Location = new System.Drawing.Point(396, 76);
            this.btnFindIssuer.Name = "btnFindIssuer";
            this.btnFindIssuer.Size = new System.Drawing.Size(26, 23);
            this.btnFindIssuer.TabIndex = 2;
            this.btnFindIssuer.UseVisualStyleBackColor = false;
            this.btnFindIssuer.Click += new System.EventHandler(this.btnFindIssuer_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(63, 110);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(92, 14);
            this.label23.TabIndex = 16;
            this.label23.Text = "Issuance Date :";
            // 
            // btnFindAcc
            // 
            this.btnFindAcc.BackColor = System.Drawing.Color.Azure;
            this.btnFindAcc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindAcc.BackgroundImage")));
            this.btnFindAcc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindAcc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindAcc.Location = new System.Drawing.Point(396, 19);
            this.btnFindAcc.Name = "btnFindAcc";
            this.btnFindAcc.Size = new System.Drawing.Size(26, 23);
            this.btnFindAcc.TabIndex = 0;
            this.btnFindAcc.UseVisualStyleBackColor = false;
            this.btnFindAcc.Click += new System.EventHandler(this.btnFindAcc_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(68, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 14);
            this.label17.TabIndex = 16;
            this.label17.Text = "Receive Date :";
            // 
            // txtDocNo
            // 
            this.txtDocNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocNo.Enabled = false;
            this.txtDocNo.Location = new System.Drawing.Point(605, 106);
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(234, 22);
            this.txtDocNo.TabIndex = 6;
            this.txtDocNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDocNo_MouseClick);
            this.txtDocNo.Leave += new System.EventHandler(this.txtDocNo_Leave);
            // 
            // dtIssuanceDate
            // 
            this.dtIssuanceDate.CustomFormat = "MM/dd/yyyy";
            this.dtIssuanceDate.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtIssuanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIssuanceDate.Location = new System.Drawing.Point(180, 105);
            this.dtIssuanceDate.Name = "dtIssuanceDate";
            this.dtIssuanceDate.Size = new System.Drawing.Size(242, 20);
            this.dtIssuanceDate.TabIndex = 3;
            this.dtIssuanceDate.Value = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            // 
            // dtReceivedDate
            // 
            this.dtReceivedDate.CustomFormat = "MM/dd/yyyy";
            this.dtReceivedDate.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceivedDate.Location = new System.Drawing.Point(180, 50);
            this.dtReceivedDate.Name = "dtReceivedDate";
            this.dtReceivedDate.Size = new System.Drawing.Size(241, 20);
            this.dtReceivedDate.TabIndex = 1;
            this.dtReceivedDate.Value = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            // 
            // txtFundCluster
            // 
            this.txtFundCluster.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFundCluster.Enabled = false;
            this.txtFundCluster.Location = new System.Drawing.Point(606, 18);
            this.txtFundCluster.Name = "txtFundCluster";
            this.txtFundCluster.Size = new System.Drawing.Size(234, 22);
            this.txtFundCluster.TabIndex = 4;
            this.txtFundCluster.Text = "101101";
            // 
            // txtAccountable
            // 
            this.txtAccountable.Enabled = false;
            this.txtAccountable.Location = new System.Drawing.Point(180, 20);
            this.txtAccountable.Name = "txtAccountable";
            this.txtAccountable.Size = new System.Drawing.Size(212, 22);
            this.txtAccountable.TabIndex = 1;
            // 
            // txtIssuedBy
            // 
            this.txtIssuedBy.Enabled = false;
            this.txtIssuedBy.Location = new System.Drawing.Point(180, 76);
            this.txtIssuedBy.Multiline = true;
            this.txtIssuedBy.Name = "txtIssuedBy";
            this.txtIssuedBy.Size = new System.Drawing.Size(210, 23);
            this.txtIssuedBy.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "Accountable Officer  :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(85, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "Issued By :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Document Type :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(496, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "Fund Cluster :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.txtnewpn);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.cboTagClass);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtSerialNo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cboLocation);
            this.groupBox2.Controls.Add(this.btnAddtoGrid);
            this.groupBox2.Controls.Add(this.btnFindUser);
            this.groupBox2.Controls.Add(this.btnFindItemdesc);
            this.groupBox2.Controls.Add(this.dgvItems);
            this.groupBox2.Controls.Add(this.txtUnitCost);
            this.groupBox2.Controls.Add(this.txtPropertyNo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtItemDesc);
            this.groupBox2.Controls.Add(this.txtEndUser);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(12, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(866, 391);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Assign Items:";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label21.Location = new System.Drawing.Point(80, 105);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(14, 14);
            this.label21.TabIndex = 85;
            this.label21.Text = "*";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnewpn
            // 
            this.txtnewpn.Enabled = false;
            this.txtnewpn.Location = new System.Drawing.Point(603, 47);
            this.txtnewpn.Name = "txtnewpn";
            this.txtnewpn.Size = new System.Drawing.Size(236, 22);
            this.txtnewpn.TabIndex = 84;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(463, 53);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 14);
            this.label20.TabIndex = 83;
            this.label20.Text = "New Property No. :";
            // 
            // cboTagClass
            // 
            this.cboTagClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTagClass.FormattingEnabled = true;
            this.cboTagClass.Items.AddRange(new object[] {
            "SMALL TAG",
            "BIG TAG"});
            this.cboTagClass.Location = new System.Drawing.Point(180, 105);
            this.cboTagClass.Name = "cboTagClass";
            this.cboTagClass.Size = new System.Drawing.Size(242, 22);
            this.cboTagClass.TabIndex = 81;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(97, 108);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 14);
            this.label16.TabIndex = 82;
            this.label16.Text = "Tag :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(80, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 14);
            this.label15.TabIndex = 80;
            this.label15.Text = "*";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(100, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 14);
            this.label14.TabIndex = 79;
            this.label14.Text = "*";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Enabled = false;
            this.txtSerialNo.Location = new System.Drawing.Point(180, 139);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(242, 22);
            this.txtSerialNo.TabIndex = 78;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 14);
            this.label7.TabIndex = 77;
            this.label7.Text = "Serial No. :";
            // 
            // cboLocation
            // 
            this.cboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(602, 105);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(236, 22);
            this.cboLocation.TabIndex = 10;
            this.cboLocation.SelectedIndexChanged += new System.EventHandler(this.cboLocation_SelectedIndexChanged);
            this.cboLocation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cboLocation_MouseClick);
            // 
            // btnAddtoGrid
            // 
            this.btnAddtoGrid.BackColor = System.Drawing.Color.Azure;
            this.btnAddtoGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddtoGrid.Location = new System.Drawing.Point(765, 139);
            this.btnAddtoGrid.Name = "btnAddtoGrid";
            this.btnAddtoGrid.Size = new System.Drawing.Size(75, 27);
            this.btnAddtoGrid.TabIndex = 10;
            this.btnAddtoGrid.Text = "Add Item";
            this.btnAddtoGrid.UseVisualStyleBackColor = false;
            this.btnAddtoGrid.Click += new System.EventHandler(this.btnAddtoGrid_Click);
            // 
            // btnFindUser
            // 
            this.btnFindUser.BackColor = System.Drawing.Color.Azure;
            this.btnFindUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindUser.BackgroundImage")));
            this.btnFindUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindUser.Location = new System.Drawing.Point(396, 74);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Size = new System.Drawing.Size(26, 22);
            this.btnFindUser.TabIndex = 9;
            this.btnFindUser.UseVisualStyleBackColor = false;
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);
            // 
            // btnFindItemdesc
            // 
            this.btnFindItemdesc.BackColor = System.Drawing.Color.Azure;
            this.btnFindItemdesc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindItemdesc.BackgroundImage")));
            this.btnFindItemdesc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindItemdesc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindItemdesc.Location = new System.Drawing.Point(396, 15);
            this.btnFindItemdesc.Name = "btnFindItemdesc";
            this.btnFindItemdesc.Size = new System.Drawing.Size(26, 23);
            this.btnFindItemdesc.TabIndex = 7;
            this.btnFindItemdesc.UseVisualStyleBackColor = false;
            this.btnFindItemdesc.Click += new System.EventHandler(this.btnFindItemdesc_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecordId,
            this.AccountableId,
            this.OICId,
            this.EndUserId,
            this.LocationId,
            this.ItemDesc,
            this.PropertyNo,
            this.SerialNo,
            this.Cost,
            this.ItemLocation,
            this.EndUser,
            this.Item_Tag,
            this.Acquisition_Date,
            this.UACS,
            this.Article_Code,
            this.New_Code});
            this.dgvItems.Location = new System.Drawing.Point(15, 172);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(827, 201);
            this.dgvItems.TabIndex = 11;
            // 
            // RecordId
            // 
            this.RecordId.HeaderText = "RecordId";
            this.RecordId.Name = "RecordId";
            this.RecordId.ReadOnly = true;
            this.RecordId.Visible = false;
            // 
            // AccountableId
            // 
            this.AccountableId.HeaderText = "AccountableId";
            this.AccountableId.Name = "AccountableId";
            this.AccountableId.ReadOnly = true;
            this.AccountableId.Visible = false;
            // 
            // OICId
            // 
            this.OICId.HeaderText = "OICId";
            this.OICId.Name = "OICId";
            this.OICId.ReadOnly = true;
            this.OICId.Visible = false;
            // 
            // EndUserId
            // 
            this.EndUserId.HeaderText = "EndUserId";
            this.EndUserId.Name = "EndUserId";
            this.EndUserId.ReadOnly = true;
            this.EndUserId.Visible = false;
            // 
            // LocationId
            // 
            this.LocationId.HeaderText = "Location_Id";
            this.LocationId.Name = "LocationId";
            this.LocationId.ReadOnly = true;
            this.LocationId.Visible = false;
            // 
            // ItemDesc
            // 
            this.ItemDesc.HeaderText = "Item Description";
            this.ItemDesc.Name = "ItemDesc";
            this.ItemDesc.ReadOnly = true;
            // 
            // PropertyNo
            // 
            this.PropertyNo.HeaderText = "Property No.";
            this.PropertyNo.Name = "PropertyNo";
            this.PropertyNo.ReadOnly = true;
            // 
            // SerialNo
            // 
            this.SerialNo.HeaderText = "Serial No";
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.ReadOnly = true;
            // 
            // Cost
            // 
            this.Cost.HeaderText = "Unit Cost";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // ItemLocation
            // 
            this.ItemLocation.HeaderText = "Location";
            this.ItemLocation.Name = "ItemLocation";
            this.ItemLocation.ReadOnly = true;
            // 
            // EndUser
            // 
            this.EndUser.HeaderText = "End User";
            this.EndUser.Name = "EndUser";
            this.EndUser.ReadOnly = true;
            // 
            // Item_Tag
            // 
            this.Item_Tag.HeaderText = "Tag";
            this.Item_Tag.Name = "Item_Tag";
            this.Item_Tag.ReadOnly = true;
            // 
            // Acquisition_Date
            // 
            this.Acquisition_Date.HeaderText = "Acquisition Date";
            this.Acquisition_Date.Name = "Acquisition_Date";
            this.Acquisition_Date.ReadOnly = true;
            this.Acquisition_Date.Visible = false;
            // 
            // UACS
            // 
            this.UACS.HeaderText = "UACS";
            this.UACS.Name = "UACS";
            this.UACS.ReadOnly = true;
            this.UACS.Visible = false;
            // 
            // Article_Code
            // 
            this.Article_Code.HeaderText = "Article Code";
            this.Article_Code.Name = "Article_Code";
            this.Article_Code.ReadOnly = true;
            this.Article_Code.Visible = false;
            // 
            // New_Code
            // 
            this.New_Code.HeaderText = "New_Code";
            this.New_Code.Name = "New_Code";
            this.New_Code.ReadOnly = true;
            // 
            // txtUnitCost
            // 
            this.txtUnitCost.Enabled = false;
            this.txtUnitCost.Location = new System.Drawing.Point(603, 75);
            this.txtUnitCost.Name = "txtUnitCost";
            this.txtUnitCost.Size = new System.Drawing.Size(235, 22);
            this.txtUnitCost.TabIndex = 3;
            // 
            // txtPropertyNo
            // 
            this.txtPropertyNo.Enabled = false;
            this.txtPropertyNo.Location = new System.Drawing.Point(603, 18);
            this.txtPropertyNo.Name = "txtPropertyNo";
            this.txtPropertyNo.Size = new System.Drawing.Size(236, 22);
            this.txtPropertyNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "End-User :";
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.Enabled = false;
            this.txtItemDesc.Location = new System.Drawing.Point(180, 15);
            this.txtItemDesc.Multiline = true;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(212, 52);
            this.txtItemDesc.TabIndex = 1;
            // 
            // txtEndUser
            // 
            this.txtEndUser.Enabled = false;
            this.txtEndUser.Location = new System.Drawing.Point(180, 74);
            this.txtEndUser.Name = "txtEndUser";
            this.txtEndUser.Size = new System.Drawing.Size(212, 22);
            this.txtEndUser.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Item  :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(511, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Unit Cost :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(511, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Location :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Old Property No. :";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Azure;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Teal;
            this.btnClear.Location = new System.Drawing.Point(780, 556);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(74, 26);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.BackColor = System.Drawing.Color.Azure;
            this.btnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveUpdate.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUpdate.ForeColor = System.Drawing.Color.Teal;
            this.btnSaveUpdate.Location = new System.Drawing.Point(697, 556);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(77, 26);
            this.btnSaveUpdate.TabIndex = 11;
            this.btnSaveUpdate.Text = "Save";
            this.btnSaveUpdate.UseVisualStyleBackColor = false;
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 543);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(147, 47);
            this.groupBox5.TabIndex = 66;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Note:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Teal;
            this.label27.Location = new System.Drawing.Point(32, 19);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(89, 13);
            this.label27.TabIndex = 24;
            this.label27.Text = "- Required fields.";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(15, 19);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(15, 20);
            this.label28.TabIndex = 23;
            this.label28.Text = "*";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Azure;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Teal;
            this.button1.Location = new System.Drawing.Point(614, 556);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 26);
            this.button1.TabIndex = 67;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAssignmentPerEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(890, 594);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSaveUpdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAssignmentPerEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equipment Assignment";
            this.Load += new System.EventHandler(this.frmAssignmentPerEmployee_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFindItemdesc;
        private System.Windows.Forms.TextBox txtDocNo;
        private System.Windows.Forms.TextBox txtFundCluster;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtIssuanceDate;
        private System.Windows.Forms.DateTimePicker dtReceivedDate;
        private System.Windows.Forms.TextBox txtAccountable;
        private System.Windows.Forms.TextBox txtIssuedBy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnFindIssuer;
        private System.Windows.Forms.CheckBox chkDocNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFindUser;
        private System.Windows.Forms.Button btnFindAcc;
        private System.Windows.Forms.TextBox txtUnitCost;
        private System.Windows.Forms.TextBox txtPropertyNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemDesc;
        private System.Windows.Forms.TextBox txtEndUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddtoGrid;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboTagClass;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboOffice;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtnewpn;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountableId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OICId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acquisition_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn UACS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Article_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn New_Code;
        private System.Windows.Forms.Label label21;
    }
}