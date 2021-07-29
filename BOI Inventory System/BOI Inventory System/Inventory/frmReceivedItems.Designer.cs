namespace BOI_Inventory_System
{
    partial class frmReceivedItems
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkIsSubscribed = new System.Windows.Forms.CheckBox();
            this.label53 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dtDateAcquired = new System.Windows.Forms.DateTimePicker();
            this.txtSubcat = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.cboEUL = new System.Windows.Forms.ComboBox();
            this.txtWarrantyVaildity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnitCost = new System.Windows.Forms.TextBox();
            this.txtPropertyNo = new System.Windows.Forms.TextBox();
            this.txtUOM = new System.Windows.Forms.TextBox();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkIsSubscribed);
            this.groupBox2.Controls.Add(this.label53);
            this.groupBox2.Controls.Add(this.txtSerialNo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtRemarks);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.cboLocation);
            this.groupBox2.Controls.Add(this.txtSupplier);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtReset);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.dtDateAcquired);
            this.groupBox2.Controls.Add(this.txtSubcat);
            this.groupBox2.Controls.Add(this.txtCategory);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtArticle);
            this.groupBox2.Controls.Add(this.cboEUL);
            this.groupBox2.Controls.Add(this.txtWarrantyVaildity);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtUnitCost);
            this.groupBox2.Controls.Add(this.txtPropertyNo);
            this.groupBox2.Controls.Add(this.txtUOM);
            this.groupBox2.Controls.Add(this.txtItemDesc);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 611);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Received Item Details:";
            // 
            // chkIsSubscribed
            // 
            this.chkIsSubscribed.AutoSize = true;
            this.chkIsSubscribed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsSubscribed.Location = new System.Drawing.Point(179, 307);
            this.chkIsSubscribed.Name = "chkIsSubscribed";
            this.chkIsSubscribed.Size = new System.Drawing.Size(12, 11);
            this.chkIsSubscribed.TabIndex = 86;
            this.chkIsSubscribed.UseVisualStyleBackColor = true;
            this.chkIsSubscribed.CheckedChanged += new System.EventHandler(this.chkIsSubscribed_CheckedChanged);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(194, 305);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(188, 14);
            this.label53.TabIndex = 85;
            this.label53.Text = "Subscription? (for Software only)";
            this.label53.Click += new System.EventHandler(this.label53_Click);
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerialNo.Location = new System.Drawing.Point(196, 181);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(236, 22);
            this.txtSerialNo.TabIndex = 2;
            this.txtSerialNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSerialNo_MouseClick);
            this.txtSerialNo.TextChanged += new System.EventHandler(this.txtSerialNo_TextChanged);
            this.txtSerialNo.Leave += new System.EventHandler(this.txtSerialNo_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(112, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 14);
            this.label7.TabIndex = 80;
            this.label7.Text = "Serial No. :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemarks.Location = new System.Drawing.Point(193, 522);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(235, 34);
            this.txtRemarks.TabIndex = 77;
            this.txtRemarks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRemarks_MouseClick);
            this.txtRemarks.Leave += new System.EventHandler(this.txtRemarks_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 522);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 14);
            this.label8.TabIndex = 78;
            this.label8.Text = "Remarks :";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Azure;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(353, 572);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 28);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cboLocation
            // 
            this.cboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(196, 484);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(235, 22);
            this.cboLocation.TabIndex = 9;
            this.cboLocation.SelectedIndexChanged += new System.EventHandler(this.cboLocation_SelectedIndexChanged);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Enabled = false;
            this.txtSupplier.Location = new System.Drawing.Point(196, 247);
            this.txtSupplier.Multiline = true;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(236, 41);
            this.txtSupplier.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 14);
            this.label6.TabIndex = 73;
            this.label6.Text = "Supplier :";
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
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Azure;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(195, 572);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 28);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Azure;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(274, 572);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 28);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dtDateAcquired
            // 
            this.dtDateAcquired.CustomFormat = "MM/dd/yyyy";
            this.dtDateAcquired.Enabled = false;
            this.dtDateAcquired.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateAcquired.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateAcquired.Location = new System.Drawing.Point(196, 371);
            this.dtDateAcquired.Name = "dtDateAcquired";
            this.dtDateAcquired.Size = new System.Drawing.Size(236, 20);
            this.dtDateAcquired.TabIndex = 6;
            this.dtDateAcquired.Value = new System.DateTime(2017, 12, 14, 0, 0, 0, 0);
            // 
            // txtSubcat
            // 
            this.txtSubcat.Enabled = false;
            this.txtSubcat.Location = new System.Drawing.Point(197, 78);
            this.txtSubcat.Name = "txtSubcat";
            this.txtSubcat.Size = new System.Drawing.Size(235, 22);
            this.txtSubcat.TabIndex = 45;
            // 
            // txtCategory
            // 
            this.txtCategory.Enabled = false;
            this.txtCategory.Location = new System.Drawing.Point(197, 51);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(235, 22);
            this.txtCategory.TabIndex = 48;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(118, 484);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 14);
            this.label18.TabIndex = 56;
            this.label18.Text = "Location :";
            // 
            // txtArticle
            // 
            this.txtArticle.Enabled = false;
            this.txtArticle.Location = new System.Drawing.Point(197, 23);
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(235, 22);
            this.txtArticle.TabIndex = 49;
            // 
            // cboEUL
            // 
            this.cboEUL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEUL.FormattingEnabled = true;
            this.cboEUL.Location = new System.Drawing.Point(196, 332);
            this.cboEUL.Name = "cboEUL";
            this.cboEUL.Size = new System.Drawing.Size(236, 22);
            this.cboEUL.TabIndex = 3;
            this.cboEUL.SelectedIndexChanged += new System.EventHandler(this.cboEUL_SelectedIndexChanged);
            // 
            // txtWarrantyVaildity
            // 
            this.txtWarrantyVaildity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWarrantyVaildity.Enabled = false;
            this.txtWarrantyVaildity.Location = new System.Drawing.Point(196, 409);
            this.txtWarrantyVaildity.Name = "txtWarrantyVaildity";
            this.txtWarrantyVaildity.Size = new System.Drawing.Size(236, 22);
            this.txtWarrantyVaildity.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 14);
            this.label4.TabIndex = 43;
            this.label4.Text = "Category :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "Subcategory :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 40;
            this.label1.Text = "Article :";
            // 
            // txtUnitCost
            // 
            this.txtUnitCost.Location = new System.Drawing.Point(196, 213);
            this.txtUnitCost.Name = "txtUnitCost";
            this.txtUnitCost.Size = new System.Drawing.Size(236, 22);
            this.txtUnitCost.TabIndex = 4;
            // 
            // txtPropertyNo
            // 
            this.txtPropertyNo.Enabled = false;
            this.txtPropertyNo.Location = new System.Drawing.Point(196, 448);
            this.txtPropertyNo.Name = "txtPropertyNo";
            this.txtPropertyNo.Size = new System.Drawing.Size(236, 22);
            this.txtPropertyNo.TabIndex = 8;
            // 
            // txtUOM
            // 
            this.txtUOM.Enabled = false;
            this.txtUOM.Location = new System.Drawing.Point(197, 150);
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.Size = new System.Drawing.Size(235, 22);
            this.txtUOM.TabIndex = 17;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.Enabled = false;
            this.txtItemDesc.Location = new System.Drawing.Point(197, 104);
            this.txtItemDesc.Multiline = true;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(235, 41);
            this.txtItemDesc.TabIndex = 59;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(73, 412);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 14);
            this.label13.TabIndex = 57;
            this.label13.Text = "Warranty Validity :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(82, 371);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 14);
            this.label15.TabIndex = 54;
            this.label15.Text = "Date Acquired  :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(50, 335);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 14);
            this.label14.TabIndex = 53;
            this.label14.Text = "Estimated Useful Life :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(77, 150);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(101, 14);
            this.label21.TabIndex = 58;
            this.label21.Text = "Unit of Measure :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(70, 448);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(109, 14);
            this.label20.TabIndex = 58;
            this.label20.Text = "Property Number :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 14);
            this.label5.TabIndex = 58;
            this.label5.Text = "Unit Cost (in Php) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 51;
            this.label3.Text = "Item Description :";
            // 
            // frmReceivedItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(481, 624);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReceivedItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Received Items";
            this.Load += new System.EventHandler(this.frmReceivedItems_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button txtReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DateTimePicker dtDateAcquired;
        private System.Windows.Forms.TextBox txtSubcat;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.ComboBox cboEUL;
        private System.Windows.Forms.TextBox txtWarrantyVaildity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnitCost;
        private System.Windows.Forms.TextBox txtPropertyNo;
        private System.Windows.Forms.TextBox txtUOM;
        private System.Windows.Forms.TextBox txtItemDesc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIsSubscribed;
        private System.Windows.Forms.Label label53;
    }
}