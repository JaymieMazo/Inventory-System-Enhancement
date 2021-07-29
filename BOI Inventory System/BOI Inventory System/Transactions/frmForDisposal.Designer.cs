namespace BOI_Inventory_System
{
    partial class frmForDisposal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForDisposal));
            this.btnReset = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCondition = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtStation = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.dtTransferred = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.txtReceiving = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboModeofDisposal = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtApproved = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtChairman = new System.Windows.Forms.TextBox();
            this.btnFindChairman = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtInpector = new System.Windows.Forms.TextBox();
            this.btnFindInspector = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFindA = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIssued = new System.Windows.Forms.TextBox();
            this.btnFindR = new System.Windows.Forms.Button();
            this.txtApproved = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtAccDep = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtAccImpLosses = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtUnitCost = new System.Windows.Forms.TextBox();
            this.txtAppraiseVal = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEUL = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDateAcq = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPropertyNo = new System.Windows.Forms.TextBox();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.lblcount2 = new System.Windows.Forms.Label();
            this.dgvItems2 = new System.Windows.Forms.DataGridView();
            this.pk_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Property_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateAcquired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsefulLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepreciationAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppraisedValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImpairmentLosses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Azure;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Teal;
            this.btnReset.Location = new System.Drawing.Point(931, 503);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 34);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtReason
            // 
            this.txtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReason.Location = new System.Drawing.Point(167, 92);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(257, 39);
            this.txtReason.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(15, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 14);
            this.label2.TabIndex = 43;
            this.label2.Text = "Reason For Disposal :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Azure;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Teal;
            this.btnSave.Location = new System.Drawing.Point(732, 503);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 34);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(33, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 14);
            this.label3.TabIndex = 46;
            this.label3.Text = "Condition of PPE :";
            // 
            // cboCondition
            // 
            this.cboCondition.BackColor = System.Drawing.Color.White;
            this.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondition.FormattingEnabled = true;
            this.cboCondition.Items.AddRange(new object[] {
            "Serviceable",
            "Unserviceable"});
            this.cboCondition.Location = new System.Drawing.Point(167, 22);
            this.cboCondition.Name = "cboCondition";
            this.cboCondition.Size = new System.Drawing.Size(257, 22);
            this.cboCondition.TabIndex = 1;
            this.cboCondition.SelectedIndexChanged += new System.EventHandler(this.cboCondition_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.txtStation);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtRecipient);
            this.groupBox2.Controls.Add(this.dtTransferred);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtDesignation);
            this.groupBox2.Controls.Add(this.txtReceiving);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboModeofDisposal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboCondition);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtReason);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(39, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(967, 192);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Disposal Details";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Teal;
            this.label24.Location = new System.Drawing.Point(525, 147);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 14);
            this.label24.TabIndex = 64;
            this.label24.Text = "Station :";
            // 
            // txtStation
            // 
            this.txtStation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStation.Location = new System.Drawing.Point(600, 142);
            this.txtStation.Name = "txtStation";
            this.txtStation.Size = new System.Drawing.Size(227, 22);
            this.txtStation.TabIndex = 63;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Teal;
            this.label10.Location = new System.Drawing.Point(514, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 14);
            this.label10.TabIndex = 62;
            this.label10.Text = "Recipient :";
            // 
            // txtRecipient
            // 
            this.txtRecipient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRecipient.Location = new System.Drawing.Point(600, 21);
            this.txtRecipient.Multiline = true;
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(227, 41);
            this.txtRecipient.TabIndex = 5;
            // 
            // dtTransferred
            // 
            this.dtTransferred.CustomFormat = "MM/dd/yyyy";
            this.dtTransferred.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTransferred.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransferred.Location = new System.Drawing.Point(167, 143);
            this.dtTransferred.Name = "dtTransferred";
            this.dtTransferred.Size = new System.Drawing.Size(257, 20);
            this.dtTransferred.TabIndex = 4;
            this.dtTransferred.Value = new System.DateTime(2017, 12, 5, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Teal;
            this.label9.Location = new System.Drawing.Point(33, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 14);
            this.label9.TabIndex = 59;
            this.label9.Text = "Date of Transfer :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Teal;
            this.label8.Location = new System.Drawing.Point(501, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 14);
            this.label8.TabIndex = 57;
            this.label8.Text = "Designation :";
            // 
            // txtDesignation
            // 
            this.txtDesignation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesignation.Location = new System.Drawing.Point(600, 109);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(227, 22);
            this.txtDesignation.TabIndex = 7;
            // 
            // txtReceiving
            // 
            this.txtReceiving.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceiving.Location = new System.Drawing.Point(600, 75);
            this.txtReceiving.Name = "txtReceiving";
            this.txtReceiving.Size = new System.Drawing.Size(227, 22);
            this.txtReceiving.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Location = new System.Drawing.Point(498, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 14);
            this.label7.TabIndex = 51;
            this.label7.Text = "Received By :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(30, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 14);
            this.label4.TabIndex = 48;
            this.label4.Text = "Mode of Disposal :";
            // 
            // cboModeofDisposal
            // 
            this.cboModeofDisposal.BackColor = System.Drawing.Color.White;
            this.cboModeofDisposal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeofDisposal.FormattingEnabled = true;
            this.cboModeofDisposal.Items.AddRange(new object[] {
            "Donation",
            "Reassignment",
            "Relocate",
            "Sold",
            "Waste Material"});
            this.cboModeofDisposal.Location = new System.Drawing.Point(167, 57);
            this.cboModeofDisposal.Name = "cboModeofDisposal";
            this.cboModeofDisposal.Size = new System.Drawing.Size(257, 22);
            this.cboModeofDisposal.TabIndex = 2;
            this.cboModeofDisposal.SelectedIndexChanged += new System.EventHandler(this.cboModeofDisposal_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtApproved);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtChairman);
            this.groupBox3.Controls.Add(this.btnFindChairman);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtInpector);
            this.groupBox3.Controls.Add(this.btnFindInspector);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnFindA);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtIssued);
            this.groupBox3.Controls.Add(this.btnFindR);
            this.groupBox3.Controls.Add(this.txtApproved);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Teal;
            this.groupBox3.Location = new System.Drawing.Point(39, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(967, 207);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Approving Authorities ";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // dtApproved
            // 
            this.dtApproved.CustomFormat = "MM/dd/yyyy";
            this.dtApproved.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtApproved.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtApproved.Location = new System.Drawing.Point(610, 79);
            this.dtApproved.Name = "dtApproved";
            this.dtApproved.Size = new System.Drawing.Size(217, 20);
            this.dtApproved.TabIndex = 12;
            this.dtApproved.Value = new System.DateTime(2017, 12, 5, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Teal;
            this.label12.Location = new System.Drawing.Point(454, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(145, 32);
            this.label12.TabIndex = 59;
            this.label12.Text = "Chairman/ Disposal Committee:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Teal;
            this.label13.Location = new System.Drawing.Point(490, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 14);
            this.label13.TabIndex = 64;
            this.label13.Text = "Date of Approved:";
            // 
            // txtChairman
            // 
            this.txtChairman.Enabled = false;
            this.txtChairman.Location = new System.Drawing.Point(610, 36);
            this.txtChairman.Name = "txtChairman";
            this.txtChairman.Size = new System.Drawing.Size(178, 22);
            this.txtChairman.TabIndex = 60;
            // 
            // btnFindChairman
            // 
            this.btnFindChairman.BackColor = System.Drawing.Color.Azure;
            this.btnFindChairman.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindChairman.BackgroundImage")));
            this.btnFindChairman.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindChairman.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindChairman.Location = new System.Drawing.Point(794, 36);
            this.btnFindChairman.Name = "btnFindChairman";
            this.btnFindChairman.Size = new System.Drawing.Size(33, 23);
            this.btnFindChairman.TabIndex = 11;
            this.btnFindChairman.UseVisualStyleBackColor = false;
            this.btnFindChairman.Click += new System.EventHandler(this.btnFindChairman_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Teal;
            this.label11.Location = new System.Drawing.Point(48, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 14);
            this.label11.TabIndex = 56;
            this.label11.Text = "Inspected by :";
            // 
            // txtInpector
            // 
            this.txtInpector.Enabled = false;
            this.txtInpector.Location = new System.Drawing.Point(167, 123);
            this.txtInpector.Name = "txtInpector";
            this.txtInpector.Size = new System.Drawing.Size(217, 22);
            this.txtInpector.TabIndex = 57;
            // 
            // btnFindInspector
            // 
            this.btnFindInspector.BackColor = System.Drawing.Color.Azure;
            this.btnFindInspector.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindInspector.BackgroundImage")));
            this.btnFindInspector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindInspector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindInspector.Location = new System.Drawing.Point(390, 123);
            this.btnFindInspector.Name = "btnFindInspector";
            this.btnFindInspector.Size = new System.Drawing.Size(33, 23);
            this.btnFindInspector.TabIndex = 10;
            this.btnFindInspector.UseVisualStyleBackColor = false;
            this.btnFindInspector.Click += new System.EventHandler(this.btnFindInspector_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Teal;
            this.label6.Location = new System.Drawing.Point(51, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 14);
            this.label6.TabIndex = 49;
            this.label6.Text = "Approved By :";
            // 
            // btnFindA
            // 
            this.btnFindA.BackColor = System.Drawing.Color.Azure;
            this.btnFindA.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindA.BackgroundImage")));
            this.btnFindA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindA.Location = new System.Drawing.Point(391, 39);
            this.btnFindA.Name = "btnFindA";
            this.btnFindA.Size = new System.Drawing.Size(33, 23);
            this.btnFindA.TabIndex = 8;
            this.btnFindA.UseVisualStyleBackColor = false;
            this.btnFindA.Click += new System.EventHandler(this.btnFindA_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(16, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 14);
            this.label5.TabIndex = 50;
            this.label5.Text = "Released/Issued By :";
            // 
            // txtIssued
            // 
            this.txtIssued.Enabled = false;
            this.txtIssued.Location = new System.Drawing.Point(168, 80);
            this.txtIssued.Name = "txtIssued";
            this.txtIssued.Size = new System.Drawing.Size(217, 22);
            this.txtIssued.TabIndex = 53;
            // 
            // btnFindR
            // 
            this.btnFindR.BackColor = System.Drawing.Color.Azure;
            this.btnFindR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindR.BackgroundImage")));
            this.btnFindR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindR.Location = new System.Drawing.Point(391, 80);
            this.btnFindR.Name = "btnFindR";
            this.btnFindR.Size = new System.Drawing.Size(33, 23);
            this.btnFindR.TabIndex = 9;
            this.btnFindR.UseVisualStyleBackColor = false;
            this.btnFindR.Click += new System.EventHandler(this.btnFindR_Click);
            // 
            // txtApproved
            // 
            this.txtApproved.Enabled = false;
            this.txtApproved.Location = new System.Drawing.Point(169, 39);
            this.txtApproved.Name = "txtApproved";
            this.txtApproved.Size = new System.Drawing.Size(217, 22);
            this.txtApproved.TabIndex = 52;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Azure;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Location = new System.Drawing.Point(922, 496);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(84, 29);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.Azure;
            this.btnReport.Enabled = false;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.Teal;
            this.btnReport.Location = new System.Drawing.Point(835, 503);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(90, 34);
            this.btnReport.TabIndex = 19;
            this.btnReport.Text = "Generate Reports";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1044, 572);
            this.tabControl1.TabIndex = 48;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1036, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Disposal Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(39, 464);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(351, 61);
            this.groupBox5.TabIndex = 64;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Note:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(32, 26);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(190, 14);
            this.label27.TabIndex = 24;
            this.label27.Text = "- All fields in this tab are required.";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(18, 26);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(15, 20);
            this.label28.TabIndex = 23;
            this.label28.Text = "*";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.btnReset);
            this.tabPage2.Controls.Add(this.btnAddItem);
            this.tabPage2.Controls.Add(this.btnReport);
            this.tabPage2.Controls.Add(this.lblcount2);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.dgvItems2);
            this.tabPage2.Controls.Add(this.lblRowCount);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1036, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items for Disposal";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.txtAccDep);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.txtAccImpLosses);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.txtUnitCost);
            this.groupBox4.Controls.Add(this.txtAppraiseVal);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.txtEUL);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtDateAcq);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtSerialNo);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtPropertyNo);
            this.groupBox4.Controls.Add(this.txtItemDesc);
            this.groupBox4.Controls.Add(this.btnFind);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Teal;
            this.groupBox4.Location = new System.Drawing.Point(6, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1021, 113);
            this.groupBox4.TabIndex = 59;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select an item :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label23.Location = new System.Drawing.Point(700, 49);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(13, 13);
            this.label23.TabIndex = 77;
            this.label23.Text = "*";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAccDep
            // 
            this.txtAccDep.Location = new System.Drawing.Point(855, 18);
            this.txtAccDep.Name = "txtAccDep";
            this.txtAccDep.Size = new System.Drawing.Size(158, 21);
            this.txtAccDep.TabIndex = 76;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Teal;
            this.label20.Location = new System.Drawing.Point(715, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(138, 13);
            this.label20.TabIndex = 75;
            this.label20.Text = "Accumulated Depreciation :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Teal;
            this.label21.Location = new System.Drawing.Point(714, 78);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(170, 13);
            this.label21.TabIndex = 74;
            this.label21.Text = "Accumulated Impairment Losses  :";
            // 
            // txtAccImpLosses
            // 
            this.txtAccImpLosses.Location = new System.Drawing.Point(890, 77);
            this.txtAccImpLosses.Name = "txtAccImpLosses";
            this.txtAccImpLosses.Size = new System.Drawing.Size(123, 21);
            this.txtAccImpLosses.TabIndex = 16;
            this.txtAccImpLosses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAccImpLosses_MouseClick);
            this.txtAccImpLosses.Leave += new System.EventHandler(this.txtAccImpLosses_Leave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Teal;
            this.label22.Location = new System.Drawing.Point(715, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(98, 13);
            this.label22.TabIndex = 72;
            this.label22.Text = "Appraised Value.  :";
            // 
            // txtUnitCost
            // 
            this.txtUnitCost.Enabled = false;
            this.txtUnitCost.Location = new System.Drawing.Point(467, 48);
            this.txtUnitCost.Name = "txtUnitCost";
            this.txtUnitCost.Size = new System.Drawing.Size(222, 21);
            this.txtUnitCost.TabIndex = 70;
            // 
            // txtAppraiseVal
            // 
            this.txtAppraiseVal.Location = new System.Drawing.Point(819, 47);
            this.txtAppraiseVal.Name = "txtAppraiseVal";
            this.txtAppraiseVal.Size = new System.Drawing.Size(194, 21);
            this.txtAppraiseVal.TabIndex = 15;
            this.txtAppraiseVal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAppraiseVal_MouseClick);
            this.txtAppraiseVal.TextChanged += new System.EventHandler(this.txtAppraiseVal_TextChanged);
            this.txtAppraiseVal.Leave += new System.EventHandler(this.txtAppraiseVal_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Teal;
            this.label19.Location = new System.Drawing.Point(382, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 13);
            this.label19.TabIndex = 69;
            this.label19.Text = "DateAcquired :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Teal;
            this.label18.Location = new System.Drawing.Point(395, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 13);
            this.label18.TabIndex = 68;
            this.label18.Text = "Useful Life  :";
            // 
            // txtEUL
            // 
            this.txtEUL.Enabled = false;
            this.txtEUL.Location = new System.Drawing.Point(468, 74);
            this.txtEUL.Name = "txtEUL";
            this.txtEUL.Size = new System.Drawing.Size(222, 21);
            this.txtEUL.TabIndex = 67;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Teal;
            this.label17.Location = new System.Drawing.Point(403, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 66;
            this.label17.Text = "Unit Cost :";
            // 
            // txtDateAcq
            // 
            this.txtDateAcq.Enabled = false;
            this.txtDateAcq.Location = new System.Drawing.Point(467, 18);
            this.txtDateAcq.Name = "txtDateAcq";
            this.txtDateAcq.Size = new System.Drawing.Size(222, 21);
            this.txtDateAcq.TabIndex = 65;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Teal;
            this.label16.Location = new System.Drawing.Point(19, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 64;
            this.label16.Text = "Serial No.  :";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Enabled = false;
            this.txtSerialNo.Location = new System.Drawing.Point(104, 77);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(222, 21);
            this.txtSerialNo.TabIndex = 63;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Teal;
            this.label15.Location = new System.Drawing.Point(19, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 13);
            this.label15.TabIndex = 62;
            this.label15.Text = "Property No.  :";
            // 
            // txtPropertyNo
            // 
            this.txtPropertyNo.Enabled = false;
            this.txtPropertyNo.Location = new System.Drawing.Point(104, 49);
            this.txtPropertyNo.Name = "txtPropertyNo";
            this.txtPropertyNo.Size = new System.Drawing.Size(222, 21);
            this.txtPropertyNo.TabIndex = 61;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.Enabled = false;
            this.txtItemDesc.Location = new System.Drawing.Point(104, 21);
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(222, 21);
            this.txtItemDesc.TabIndex = 0;
            this.txtItemDesc.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.Azure;
            this.btnFind.BackgroundImage = global::BOI_Inventory_System.Properties.Resources.search11;
            this.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Location = new System.Drawing.Point(332, 21);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(26, 23);
            this.btnFind.TabIndex = 14;
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Teal;
            this.label14.Location = new System.Drawing.Point(10, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 60;
            this.label14.Text = "Item Description :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(1, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.Azure;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(936, 134);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(82, 27);
            this.btnAddItem.TabIndex = 17;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lblcount2
            // 
            this.lblcount2.AutoSize = true;
            this.lblcount2.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcount2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblcount2.Location = new System.Drawing.Point(200, 506);
            this.lblcount2.Name = "lblcount2";
            this.lblcount2.Size = new System.Drawing.Size(0, 12);
            this.lblcount2.TabIndex = 51;
            // 
            // dgvItems2
            // 
            this.dgvItems2.AllowUserToAddRows = false;
            this.dgvItems2.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvItems2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pk_Id,
            this.Description,
            this.Property_No,
            this.SerialNo,
            this.DateAcquired,
            this.UnitCost,
            this.UsefulLife,
            this.DepreciationAmount,
            this.AppraisedValue,
            this.ImpairmentLosses});
            this.dgvItems2.Location = new System.Drawing.Point(16, 167);
            this.dgvItems2.Name = "dgvItems2";
            this.dgvItems2.ReadOnly = true;
            this.dgvItems2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems2.Size = new System.Drawing.Size(1002, 323);
            this.dgvItems2.StandardTab = true;
            this.dgvItems2.TabIndex = 45;
            // 
            // pk_Id
            // 
            this.pk_Id.HeaderText = "pk_Id";
            this.pk_Id.Name = "pk_Id";
            this.pk_Id.ReadOnly = true;
            this.pk_Id.Visible = false;
            // 
            // Description
            // 
            this.Description.HeaderText = "Item Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Property_No
            // 
            this.Property_No.HeaderText = "Property Number";
            this.Property_No.Name = "Property_No";
            this.Property_No.ReadOnly = true;
            // 
            // SerialNo
            // 
            this.SerialNo.HeaderText = "Serial No.";
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.ReadOnly = true;
            // 
            // DateAcquired
            // 
            this.DateAcquired.HeaderText = "Date Acquired";
            this.DateAcquired.Name = "DateAcquired";
            this.DateAcquired.ReadOnly = true;
            // 
            // UnitCost
            // 
            this.UnitCost.HeaderText = "Unit Cost";
            this.UnitCost.Name = "UnitCost";
            this.UnitCost.ReadOnly = true;
            // 
            // UsefulLife
            // 
            this.UsefulLife.HeaderText = "EUL";
            this.UsefulLife.Name = "UsefulLife";
            this.UsefulLife.ReadOnly = true;
            // 
            // DepreciationAmount
            // 
            this.DepreciationAmount.HeaderText = "Accumulated Depreciation ";
            this.DepreciationAmount.Name = "DepreciationAmount";
            this.DepreciationAmount.ReadOnly = true;
            // 
            // AppraisedValue
            // 
            this.AppraisedValue.HeaderText = "Appraised Value";
            this.AppraisedValue.Name = "AppraisedValue";
            this.AppraisedValue.ReadOnly = true;
            // 
            // ImpairmentLosses
            // 
            this.ImpairmentLosses.HeaderText = "Accumulated Impairment Losses";
            this.ImpairmentLosses.Name = "ImpairmentLosses";
            this.ImpairmentLosses.ReadOnly = true;
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRowCount.Location = new System.Drawing.Point(19, 506);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(173, 12);
            this.lblRowCount.TabIndex = 50;
            this.lblRowCount.Text = "No. of Records Selected:";
            // 
            // frmForDisposal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1061, 590);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.Teal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmForDisposal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Items For Disposal";
            this.Load += new System.EventHandler(this.frmForDisposal_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCondition;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboModeofDisposal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReceiving;
        private System.Windows.Forms.TextBox txtIssued;
        private System.Windows.Forms.TextBox txtApproved;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Button btnFindR;
        private System.Windows.Forms.Button btnFindA;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtTransferred;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtItemDesc;
        private System.Windows.Forms.Label lblcount2;
        private System.Windows.Forms.DataGridView dgvItems2;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRecipient;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtChairman;
        private System.Windows.Forms.Button btnFindChairman;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtInpector;
        private System.Windows.Forms.Button btnFindInspector;
        private System.Windows.Forms.DateTimePicker dtApproved;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPropertyNo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDateAcq;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEUL;
        private System.Windows.Forms.TextBox txtUnitCost;
        private System.Windows.Forms.TextBox txtAccDep;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtAccImpLosses;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtAppraiseVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn pk_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateAcquired;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsefulLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepreciationAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppraisedValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImpairmentLosses;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtStation;
    }
}