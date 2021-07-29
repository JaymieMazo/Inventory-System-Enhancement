namespace BOI_Inventory_System
{
    partial class frmPullOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPullOut));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.btnFindItem = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboReason = new System.Windows.Forms.ComboBox();
            this.txtNotedBy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFindOIC = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPullout = new System.Windows.Forms.Button();
            this.dtReceived = new System.Windows.Forms.DateTimePicker();
            this.txtReceivingEmployee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPullOut = new System.Windows.Forms.DateTimePicker();
            this.txtEndUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pk_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Property_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 462);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(351, 47);
            this.groupBox5.TabIndex = 66;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Note:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Teal;
            this.label27.Location = new System.Drawing.Point(32, 19);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(106, 16);
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
            // btnFindItem
            // 
            this.btnFindItem.BackColor = System.Drawing.Color.Azure;
            this.btnFindItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindItem.Location = new System.Drawing.Point(763, 20);
            this.btnFindItem.Name = "btnFindItem";
            this.btnFindItem.Size = new System.Drawing.Size(109, 28);
            this.btnFindItem.TabIndex = 2;
            this.btnFindItem.Text = "Select Item";
            this.btnFindItem.UseVisualStyleBackColor = false;
            this.btnFindItem.Click += new System.EventHandler(this.btnFindItem_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pk_Id,
            this.Description,
            this.Property_No,
            this.SerialNo,
            this.Remarks,
            this.ReceivedBy});
            this.dgvItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvItems.Location = new System.Drawing.Point(8, 63);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(864, 246);
            this.dgvItems.StandardTab = true;
            this.dgvItems.TabIndex = 24;
            this.dgvItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboReason);
            this.groupBox1.Controls.Add(this.txtNotedBy);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnFindOIC);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnPullout);
            this.groupBox1.Controls.Add(this.dtReceived);
            this.groupBox1.Controls.Add(this.txtReceivingEmployee);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtPullOut);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(8, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 125);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(395, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 15);
            this.label18.TabIndex = 51;
            this.label18.Text = "*";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(6, 95);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 15);
            this.label17.TabIndex = 50;
            this.label17.Text = "*";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(9, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 15);
            this.label16.TabIndex = 49;
            this.label16.Text = "*";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(8, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 15);
            this.label15.TabIndex = 48;
            this.label15.Text = "*";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 14);
            this.label6.TabIndex = 26;
            this.label6.Text = "Reason for Pull Out :";
            // 
            // cboReason
            // 
            this.cboReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReason.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReason.FormattingEnabled = true;
            this.cboReason.Items.AddRange(new object[] {
            "FOR REPAIR",
            "FOR TRANSFER",
            "FOR DISPOSAL",
            "FOR RETURN TO SUPPLIER"});
            this.cboReason.Location = new System.Drawing.Point(169, 56);
            this.cboReason.Name = "cboReason";
            this.cboReason.Size = new System.Drawing.Size(211, 20);
            this.cboReason.TabIndex = 7;
            this.cboReason.SelectedIndexChanged += new System.EventHandler(this.cboReason_SelectedIndexChanged);
            // 
            // txtNotedBy
            // 
            this.txtNotedBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNotedBy.Location = new System.Drawing.Point(518, 52);
            this.txtNotedBy.Name = "txtNotedBy";
            this.txtNotedBy.Size = new System.Drawing.Size(193, 22);
            this.txtNotedBy.TabIndex = 10;
            this.txtNotedBy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNotedBy_MouseClick);
            this.txtNotedBy.Leave += new System.EventHandler(this.txtNotedBy_Leave);
            this.txtNotedBy.MouseLeave += new System.EventHandler(this.txtNotedBy_MouseLeave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(437, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 14);
            this.label7.TabIndex = 29;
            this.label7.Text = "Noted By :";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Azure;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(743, 68);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(103, 36);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFindOIC
            // 
            this.btnFindOIC.BackColor = System.Drawing.Color.Azure;
            this.btnFindOIC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindOIC.BackgroundImage")));
            this.btnFindOIC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindOIC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindOIC.Location = new System.Drawing.Point(352, 92);
            this.btnFindOIC.Name = "btnFindOIC";
            this.btnFindOIC.Size = new System.Drawing.Size(28, 20);
            this.btnFindOIC.TabIndex = 8;
            this.btnFindOIC.UseVisualStyleBackColor = false;
            this.btnFindOIC.Click += new System.EventHandler(this.btnFindOIC_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Receiving Employee :";
            // 
            // btnPullout
            // 
            this.btnPullout.BackColor = System.Drawing.Color.Azure;
            this.btnPullout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPullout.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullout.Location = new System.Drawing.Point(743, 25);
            this.btnPullout.Name = "btnPullout";
            this.btnPullout.Size = new System.Drawing.Size(103, 36);
            this.btnPullout.TabIndex = 11;
            this.btnPullout.Text = "Pull-Out";
            this.btnPullout.UseVisualStyleBackColor = false;
            this.btnPullout.Click += new System.EventHandler(this.btnPullout_Click);
            // 
            // dtReceived
            // 
            this.dtReceived.CustomFormat = "MM/dd/yyyy";
            this.dtReceived.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtReceived.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceived.Location = new System.Drawing.Point(522, 16);
            this.dtReceived.Name = "dtReceived";
            this.dtReceived.Size = new System.Drawing.Size(189, 20);
            this.dtReceived.TabIndex = 9;
            this.dtReceived.Value = new System.DateTime(2017, 10, 13, 0, 0, 0, 0);
            // 
            // txtReceivingEmployee
            // 
            this.txtReceivingEmployee.Enabled = false;
            this.txtReceivingEmployee.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceivingEmployee.Location = new System.Drawing.Point(167, 92);
            this.txtReceivingEmployee.Multiline = true;
            this.txtReceivingEmployee.Name = "txtReceivingEmployee";
            this.txtReceivingEmployee.Size = new System.Drawing.Size(179, 20);
            this.txtReceivingEmployee.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(411, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date Received :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date Pulled-Out :";
            // 
            // dtPullOut
            // 
            this.dtPullOut.CustomFormat = "MM/dd/yyyy";
            this.dtPullOut.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPullOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPullOut.Location = new System.Drawing.Point(167, 20);
            this.dtPullOut.Name = "dtPullOut";
            this.dtPullOut.Size = new System.Drawing.Size(213, 20);
            this.dtPullOut.TabIndex = 6;
            this.dtPullOut.Value = new System.DateTime(2017, 10, 13, 0, 0, 0, 0);
            // 
            // txtEndUser
            // 
            this.txtEndUser.Enabled = false;
            this.txtEndUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndUser.Location = new System.Drawing.Point(463, 22);
            this.txtEndUser.Name = "txtEndUser";
            this.txtEndUser.ReadOnly = true;
            this.txtEndUser.Size = new System.Drawing.Size(220, 23);
            this.txtEndUser.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(357, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "Pull-Out from :";
            // 
            // btnFindUser
            // 
            this.btnFindUser.BackColor = System.Drawing.Color.Azure;
            this.btnFindUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindUser.BackgroundImage")));
            this.btnFindUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindUser.Location = new System.Drawing.Point(691, 21);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Size = new System.Drawing.Size(28, 25);
            this.btnFindUser.TabIndex = 1;
            this.btnFindUser.UseVisualStyleBackColor = false;
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(346, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "*";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "End-User",
            "License"});
            this.cboCategory.Location = new System.Drawing.Point(98, 19);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(176, 24);
            this.cboCategory.TabIndex = 50;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(19, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 16);
            this.label19.TabIndex = 51;
            this.label19.Text = "Category:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label20.Location = new System.Drawing.Point(6, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(13, 13);
            this.label20.TabIndex = 52;
            this.label20.Text = "*";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.cboCategory);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnFindUser);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtEndUser);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.dgvItems);
            this.groupBox2.Controls.Add(this.btnFindItem);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(878, 444);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // pk_Id
            // 
            this.pk_Id.HeaderText = "pk_Id";
            this.pk_Id.Name = "pk_Id";
            this.pk_Id.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Item Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 200;
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
            this.SerialNo.Width = 150;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // ReceivedBy
            // 
            this.ReceivedBy.HeaderText = "Received By";
            this.ReceivedBy.Name = "ReceivedBy";
            this.ReceivedBy.ReadOnly = true;
            this.ReceivedBy.Width = 150;
            // 
            // frmPullOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(902, 513);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPullOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pull-Out Equipment";
            this.Load += new System.EventHandler(this.frmPullOut_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnFindItem;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboReason;
        private System.Windows.Forms.TextBox txtNotedBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFindOIC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPullout;
        private System.Windows.Forms.DateTimePicker dtReceived;
        private System.Windows.Forms.TextBox txtReceivingEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPullOut;
        private System.Windows.Forms.TextBox txtEndUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFindUser;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pk_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedBy;
    }
}