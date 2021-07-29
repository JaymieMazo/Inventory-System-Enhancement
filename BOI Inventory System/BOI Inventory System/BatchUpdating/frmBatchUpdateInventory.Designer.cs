namespace BOI_Inventory_System.BatchUpdating
{
    partial class frmBatchUpdateInventory
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkIsSubscribed = new System.Windows.Forms.CheckBox();
            this.label53 = new System.Windows.Forms.Label();
            this.lblcount = new System.Windows.Forms.Label();
            this.lblRowCountCap = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bIS_DBENGInventoryDataSet = new BOI_Inventory_System.BIS_DBENGInventoryDataSet();
            this.viewInventoryDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_Inventory_DetailsTableAdapter = new BOI_Inventory_System.BIS_DBENGInventoryDataSetTableAdapters.view_Inventory_DetailsTableAdapter();
            this.categoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subcategoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eULNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAcquiredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warrantyValidityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldPropertyNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeofAcquisitionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateIssuedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateReceivedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkAccountableEmployeeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountableOfficerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDesignationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.divisionCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endUserUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oICDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signatoryDesignationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oICUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depreciatedCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isSubscribedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newPropertyNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.officeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subcategoryCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articleCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bIS_DBENGInventoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewInventoryDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkIsSubscribed);
            this.groupBox2.Controls.Add(this.label53);
            this.groupBox2.Controls.Add(this.lblcount);
            this.groupBox2.Controls.Add(this.lblRowCountCap);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(12, 475);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(973, 50);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // chkIsSubscribed
            // 
            this.chkIsSubscribed.AutoSize = true;
            this.chkIsSubscribed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsSubscribed.Location = new System.Drawing.Point(41, 26);
            this.chkIsSubscribed.Name = "chkIsSubscribed";
            this.chkIsSubscribed.Size = new System.Drawing.Size(12, 11);
            this.chkIsSubscribed.TabIndex = 94;
            this.chkIsSubscribed.UseVisualStyleBackColor = true;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(56, 24);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(196, 14);
            this.label53.TabIndex = 93;
            this.label53.Text = "Subscription? (check if subscribed)";
            // 
            // lblcount
            // 
            this.lblcount.AutoSize = true;
            this.lblcount.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblcount.Location = new System.Drawing.Point(930, 18);
            this.lblcount.Name = "lblcount";
            this.lblcount.Size = new System.Drawing.Size(0, 12);
            this.lblcount.TabIndex = 32;
            // 
            // lblRowCountCap
            // 
            this.lblRowCountCap.AutoSize = true;
            this.lblRowCountCap.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCountCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRowCountCap.Location = new System.Drawing.Point(763, 18);
            this.lblRowCountCap.Name = "lblRowCountCap";
            this.lblRowCountCap.Size = new System.Drawing.Size(159, 12);
            this.lblRowCountCap.TabIndex = 31;
            this.lblRowCountCap.Text = "Total No. of Records :";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Azure;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Teal;
            this.btnUpdate.Location = new System.Drawing.Point(258, 21);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(78, 24);
            this.btnUpdate.TabIndex = 30;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(20, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 14);
            this.label4.TabIndex = 26;
            this.label4.Text = "*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryNameDataGridViewTextBoxColumn,
            this.subcategoryNameDataGridViewTextBoxColumn,
            this.articleNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.uOMDataGridViewTextBoxColumn,
            this.serialNoDataGridViewTextBoxColumn,
            this.unitCostDataGridViewTextBoxColumn,
            this.eULNameDataGridViewTextBoxColumn,
            this.dateAcquiredDataGridViewTextBoxColumn,
            this.warrantyValidityDataGridViewTextBoxColumn,
            this.oldPropertyNoDataGridViewTextBoxColumn,
            this.locationNameDataGridViewTextBoxColumn,
            this.modeofAcquisitionDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.documentNoDataGridViewTextBoxColumn,
            this.dateIssuedDataGridViewTextBoxColumn,
            this.dateReceivedDataGridViewTextBoxColumn,
            this.fkAccountableEmployeeIdDataGridViewTextBoxColumn,
            this.accountableOfficerDataGridViewTextBoxColumn,
            this.designationDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.endUserDataGridViewTextBoxColumn,
            this.userDesignationDataGridViewTextBoxColumn,
            this.serviceCodeDataGridViewTextBoxColumn,
            this.divisionCodeDataGridViewTextBoxColumn,
            this.endUserUnitDataGridViewTextBoxColumn,
            this.oICDataGridViewTextBoxColumn,
            this.signatoryDesignationDataGridViewTextBoxColumn,
            this.oICUnitDataGridViewTextBoxColumn,
            this.inventoryDateDataGridViewTextBoxColumn,
            this.remarksDataGridViewTextBoxColumn,
            this.tagDataGridViewTextBoxColumn,
            this.tagSizeDataGridViewTextBoxColumn,
            this.depreciatedCostDataGridViewTextBoxColumn,
            this.bookValueDataGridViewTextBoxColumn,
            this.isSubscribedDataGridViewTextBoxColumn,
            this.eOSDataGridViewTextBoxColumn,
            this.newPropertyNoDataGridViewTextBoxColumn,
            this.officeDataGridViewTextBoxColumn,
            this.subcategoryCodeDataGridViewTextBoxColumn,
            this.articleCodeDataGridViewTextBoxColumn});
            this.dgvItems.DataSource = this.viewInventoryDetailsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItems.Location = new System.Drawing.Point(12, 76);
            this.dgvItems.Name = "dgvItems";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(973, 393);
            this.dgvItems.StandardTab = true;
            this.dgvItems.TabIndex = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(973, 58);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Item :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(130, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(417, 22);
            this.txtSearch.TabIndex = 32;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Azure;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Teal;
            this.btnClear.Location = new System.Drawing.Point(553, 23);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 24);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(29, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 14);
            this.label5.TabIndex = 29;
            this.label5.Text = "*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 28;
            this.label1.Text = "Description : ";
            // 
            // bIS_DBENGInventoryDataSet
            // 
            this.bIS_DBENGInventoryDataSet.DataSetName = "BIS_DBENGInventoryDataSet";
            this.bIS_DBENGInventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewInventoryDetailsBindingSource
            // 
            this.viewInventoryDetailsBindingSource.DataMember = "view_Inventory_Details";
            this.viewInventoryDetailsBindingSource.DataSource = this.bIS_DBENGInventoryDataSet;
            // 
            // view_Inventory_DetailsTableAdapter
            // 
            this.view_Inventory_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // categoryNameDataGridViewTextBoxColumn
            // 
            this.categoryNameDataGridViewTextBoxColumn.DataPropertyName = "Category_Name";
            this.categoryNameDataGridViewTextBoxColumn.HeaderText = "Category_Name";
            this.categoryNameDataGridViewTextBoxColumn.Name = "categoryNameDataGridViewTextBoxColumn";
            // 
            // subcategoryNameDataGridViewTextBoxColumn
            // 
            this.subcategoryNameDataGridViewTextBoxColumn.DataPropertyName = "Subcategory_Name";
            this.subcategoryNameDataGridViewTextBoxColumn.HeaderText = "Subcategory_Name";
            this.subcategoryNameDataGridViewTextBoxColumn.Name = "subcategoryNameDataGridViewTextBoxColumn";
            // 
            // articleNameDataGridViewTextBoxColumn
            // 
            this.articleNameDataGridViewTextBoxColumn.DataPropertyName = "Article_Name";
            this.articleNameDataGridViewTextBoxColumn.HeaderText = "Article_Name";
            this.articleNameDataGridViewTextBoxColumn.Name = "articleNameDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // uOMDataGridViewTextBoxColumn
            // 
            this.uOMDataGridViewTextBoxColumn.DataPropertyName = "UOM";
            this.uOMDataGridViewTextBoxColumn.HeaderText = "UOM";
            this.uOMDataGridViewTextBoxColumn.Name = "uOMDataGridViewTextBoxColumn";
            // 
            // serialNoDataGridViewTextBoxColumn
            // 
            this.serialNoDataGridViewTextBoxColumn.DataPropertyName = "Serial_No";
            this.serialNoDataGridViewTextBoxColumn.HeaderText = "Serial_No";
            this.serialNoDataGridViewTextBoxColumn.Name = "serialNoDataGridViewTextBoxColumn";
            // 
            // unitCostDataGridViewTextBoxColumn
            // 
            this.unitCostDataGridViewTextBoxColumn.DataPropertyName = "Unit_Cost";
            this.unitCostDataGridViewTextBoxColumn.HeaderText = "Unit_Cost";
            this.unitCostDataGridViewTextBoxColumn.Name = "unitCostDataGridViewTextBoxColumn";
            // 
            // eULNameDataGridViewTextBoxColumn
            // 
            this.eULNameDataGridViewTextBoxColumn.DataPropertyName = "EUL_Name";
            this.eULNameDataGridViewTextBoxColumn.HeaderText = "EUL_Name";
            this.eULNameDataGridViewTextBoxColumn.Name = "eULNameDataGridViewTextBoxColumn";
            // 
            // dateAcquiredDataGridViewTextBoxColumn
            // 
            this.dateAcquiredDataGridViewTextBoxColumn.DataPropertyName = "Date_Acquired";
            this.dateAcquiredDataGridViewTextBoxColumn.HeaderText = "Date_Acquired";
            this.dateAcquiredDataGridViewTextBoxColumn.Name = "dateAcquiredDataGridViewTextBoxColumn";
            // 
            // warrantyValidityDataGridViewTextBoxColumn
            // 
            this.warrantyValidityDataGridViewTextBoxColumn.DataPropertyName = "Warranty_Validity";
            this.warrantyValidityDataGridViewTextBoxColumn.HeaderText = "Warranty_Validity";
            this.warrantyValidityDataGridViewTextBoxColumn.Name = "warrantyValidityDataGridViewTextBoxColumn";
            // 
            // oldPropertyNoDataGridViewTextBoxColumn
            // 
            this.oldPropertyNoDataGridViewTextBoxColumn.DataPropertyName = "Old_Property_No";
            this.oldPropertyNoDataGridViewTextBoxColumn.HeaderText = "Old_Property_No";
            this.oldPropertyNoDataGridViewTextBoxColumn.Name = "oldPropertyNoDataGridViewTextBoxColumn";
            // 
            // locationNameDataGridViewTextBoxColumn
            // 
            this.locationNameDataGridViewTextBoxColumn.DataPropertyName = "Location_Name";
            this.locationNameDataGridViewTextBoxColumn.HeaderText = "Location_Name";
            this.locationNameDataGridViewTextBoxColumn.Name = "locationNameDataGridViewTextBoxColumn";
            // 
            // modeofAcquisitionDataGridViewTextBoxColumn
            // 
            this.modeofAcquisitionDataGridViewTextBoxColumn.DataPropertyName = "Mode_of_Acquisition";
            this.modeofAcquisitionDataGridViewTextBoxColumn.HeaderText = "Mode_of_Acquisition";
            this.modeofAcquisitionDataGridViewTextBoxColumn.Name = "modeofAcquisitionDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // documentNoDataGridViewTextBoxColumn
            // 
            this.documentNoDataGridViewTextBoxColumn.DataPropertyName = "Document_No";
            this.documentNoDataGridViewTextBoxColumn.HeaderText = "Document_No";
            this.documentNoDataGridViewTextBoxColumn.Name = "documentNoDataGridViewTextBoxColumn";
            // 
            // dateIssuedDataGridViewTextBoxColumn
            // 
            this.dateIssuedDataGridViewTextBoxColumn.DataPropertyName = "Date_Issued";
            this.dateIssuedDataGridViewTextBoxColumn.HeaderText = "Date_Issued";
            this.dateIssuedDataGridViewTextBoxColumn.Name = "dateIssuedDataGridViewTextBoxColumn";
            // 
            // dateReceivedDataGridViewTextBoxColumn
            // 
            this.dateReceivedDataGridViewTextBoxColumn.DataPropertyName = "Date_Received";
            this.dateReceivedDataGridViewTextBoxColumn.HeaderText = "Date_Received";
            this.dateReceivedDataGridViewTextBoxColumn.Name = "dateReceivedDataGridViewTextBoxColumn";
            // 
            // fkAccountableEmployeeIdDataGridViewTextBoxColumn
            // 
            this.fkAccountableEmployeeIdDataGridViewTextBoxColumn.DataPropertyName = "fk_Accountable_Employee_Id";
            this.fkAccountableEmployeeIdDataGridViewTextBoxColumn.HeaderText = "fk_Accountable_Employee_Id";
            this.fkAccountableEmployeeIdDataGridViewTextBoxColumn.Name = "fkAccountableEmployeeIdDataGridViewTextBoxColumn";
            // 
            // accountableOfficerDataGridViewTextBoxColumn
            // 
            this.accountableOfficerDataGridViewTextBoxColumn.DataPropertyName = "Accountable Officer";
            this.accountableOfficerDataGridViewTextBoxColumn.HeaderText = "Accountable Officer";
            this.accountableOfficerDataGridViewTextBoxColumn.Name = "accountableOfficerDataGridViewTextBoxColumn";
            // 
            // designationDataGridViewTextBoxColumn
            // 
            this.designationDataGridViewTextBoxColumn.DataPropertyName = "Designation";
            this.designationDataGridViewTextBoxColumn.HeaderText = "Designation";
            this.designationDataGridViewTextBoxColumn.Name = "designationDataGridViewTextBoxColumn";
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn.HeaderText = "Unit";
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            // 
            // endUserDataGridViewTextBoxColumn
            // 
            this.endUserDataGridViewTextBoxColumn.DataPropertyName = "End User";
            this.endUserDataGridViewTextBoxColumn.HeaderText = "End User";
            this.endUserDataGridViewTextBoxColumn.Name = "endUserDataGridViewTextBoxColumn";
            // 
            // userDesignationDataGridViewTextBoxColumn
            // 
            this.userDesignationDataGridViewTextBoxColumn.DataPropertyName = "User_Designation";
            this.userDesignationDataGridViewTextBoxColumn.HeaderText = "User_Designation";
            this.userDesignationDataGridViewTextBoxColumn.Name = "userDesignationDataGridViewTextBoxColumn";
            // 
            // serviceCodeDataGridViewTextBoxColumn
            // 
            this.serviceCodeDataGridViewTextBoxColumn.DataPropertyName = "Service_Code";
            this.serviceCodeDataGridViewTextBoxColumn.HeaderText = "Service_Code";
            this.serviceCodeDataGridViewTextBoxColumn.Name = "serviceCodeDataGridViewTextBoxColumn";
            // 
            // divisionCodeDataGridViewTextBoxColumn
            // 
            this.divisionCodeDataGridViewTextBoxColumn.DataPropertyName = "Division_Code";
            this.divisionCodeDataGridViewTextBoxColumn.HeaderText = "Division_Code";
            this.divisionCodeDataGridViewTextBoxColumn.Name = "divisionCodeDataGridViewTextBoxColumn";
            // 
            // endUserUnitDataGridViewTextBoxColumn
            // 
            this.endUserUnitDataGridViewTextBoxColumn.DataPropertyName = "End User Unit";
            this.endUserUnitDataGridViewTextBoxColumn.HeaderText = "End User Unit";
            this.endUserUnitDataGridViewTextBoxColumn.Name = "endUserUnitDataGridViewTextBoxColumn";
            // 
            // oICDataGridViewTextBoxColumn
            // 
            this.oICDataGridViewTextBoxColumn.DataPropertyName = "OIC";
            this.oICDataGridViewTextBoxColumn.HeaderText = "OIC";
            this.oICDataGridViewTextBoxColumn.Name = "oICDataGridViewTextBoxColumn";
            // 
            // signatoryDesignationDataGridViewTextBoxColumn
            // 
            this.signatoryDesignationDataGridViewTextBoxColumn.DataPropertyName = "Signatory_Designation";
            this.signatoryDesignationDataGridViewTextBoxColumn.HeaderText = "Signatory_Designation";
            this.signatoryDesignationDataGridViewTextBoxColumn.Name = "signatoryDesignationDataGridViewTextBoxColumn";
            // 
            // oICUnitDataGridViewTextBoxColumn
            // 
            this.oICUnitDataGridViewTextBoxColumn.DataPropertyName = "OIC Unit";
            this.oICUnitDataGridViewTextBoxColumn.HeaderText = "OIC Unit";
            this.oICUnitDataGridViewTextBoxColumn.Name = "oICUnitDataGridViewTextBoxColumn";
            // 
            // inventoryDateDataGridViewTextBoxColumn
            // 
            this.inventoryDateDataGridViewTextBoxColumn.DataPropertyName = "Inventory_Date";
            this.inventoryDateDataGridViewTextBoxColumn.HeaderText = "Inventory_Date";
            this.inventoryDateDataGridViewTextBoxColumn.Name = "inventoryDateDataGridViewTextBoxColumn";
            // 
            // remarksDataGridViewTextBoxColumn
            // 
            this.remarksDataGridViewTextBoxColumn.DataPropertyName = "Remarks";
            this.remarksDataGridViewTextBoxColumn.HeaderText = "Remarks";
            this.remarksDataGridViewTextBoxColumn.Name = "remarksDataGridViewTextBoxColumn";
            // 
            // tagDataGridViewTextBoxColumn
            // 
            this.tagDataGridViewTextBoxColumn.DataPropertyName = "Tag";
            this.tagDataGridViewTextBoxColumn.HeaderText = "Tag";
            this.tagDataGridViewTextBoxColumn.Name = "tagDataGridViewTextBoxColumn";
            // 
            // tagSizeDataGridViewTextBoxColumn
            // 
            this.tagSizeDataGridViewTextBoxColumn.DataPropertyName = "Tag_Size";
            this.tagSizeDataGridViewTextBoxColumn.HeaderText = "Tag_Size";
            this.tagSizeDataGridViewTextBoxColumn.Name = "tagSizeDataGridViewTextBoxColumn";
            // 
            // depreciatedCostDataGridViewTextBoxColumn
            // 
            this.depreciatedCostDataGridViewTextBoxColumn.DataPropertyName = "Depreciated_Cost";
            this.depreciatedCostDataGridViewTextBoxColumn.HeaderText = "Depreciated_Cost";
            this.depreciatedCostDataGridViewTextBoxColumn.Name = "depreciatedCostDataGridViewTextBoxColumn";
            // 
            // bookValueDataGridViewTextBoxColumn
            // 
            this.bookValueDataGridViewTextBoxColumn.DataPropertyName = "Book_Value";
            this.bookValueDataGridViewTextBoxColumn.HeaderText = "Book_Value";
            this.bookValueDataGridViewTextBoxColumn.Name = "bookValueDataGridViewTextBoxColumn";
            // 
            // isSubscribedDataGridViewTextBoxColumn
            // 
            this.isSubscribedDataGridViewTextBoxColumn.DataPropertyName = "IsSubscribed";
            this.isSubscribedDataGridViewTextBoxColumn.HeaderText = "IsSubscribed";
            this.isSubscribedDataGridViewTextBoxColumn.Name = "isSubscribedDataGridViewTextBoxColumn";
            // 
            // eOSDataGridViewTextBoxColumn
            // 
            this.eOSDataGridViewTextBoxColumn.DataPropertyName = "EOS";
            this.eOSDataGridViewTextBoxColumn.HeaderText = "EOS";
            this.eOSDataGridViewTextBoxColumn.Name = "eOSDataGridViewTextBoxColumn";
            // 
            // newPropertyNoDataGridViewTextBoxColumn
            // 
            this.newPropertyNoDataGridViewTextBoxColumn.DataPropertyName = "New_Property_No";
            this.newPropertyNoDataGridViewTextBoxColumn.HeaderText = "New_Property_No";
            this.newPropertyNoDataGridViewTextBoxColumn.Name = "newPropertyNoDataGridViewTextBoxColumn";
            // 
            // officeDataGridViewTextBoxColumn
            // 
            this.officeDataGridViewTextBoxColumn.DataPropertyName = "Office";
            this.officeDataGridViewTextBoxColumn.HeaderText = "Office";
            this.officeDataGridViewTextBoxColumn.Name = "officeDataGridViewTextBoxColumn";
            // 
            // subcategoryCodeDataGridViewTextBoxColumn
            // 
            this.subcategoryCodeDataGridViewTextBoxColumn.DataPropertyName = "Subcategory_Code";
            this.subcategoryCodeDataGridViewTextBoxColumn.HeaderText = "Subcategory_Code";
            this.subcategoryCodeDataGridViewTextBoxColumn.Name = "subcategoryCodeDataGridViewTextBoxColumn";
            // 
            // articleCodeDataGridViewTextBoxColumn
            // 
            this.articleCodeDataGridViewTextBoxColumn.DataPropertyName = "Article_Code";
            this.articleCodeDataGridViewTextBoxColumn.HeaderText = "Article_Code";
            this.articleCodeDataGridViewTextBoxColumn.Name = "articleCodeDataGridViewTextBoxColumn";
            // 
            // frmBatchUpdateInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(994, 538);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBatchUpdateInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Inventory";
            this.Load += new System.EventHandler(this.frmBatchUpdateInventory_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bIS_DBENGInventoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewInventoryDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkIsSubscribed;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label lblcount;
        private System.Windows.Forms.Label lblRowCountCap;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private BIS_DBENGInventoryDataSet bIS_DBENGInventoryDataSet;
        private System.Windows.Forms.BindingSource viewInventoryDetailsBindingSource;
        private BIS_DBENGInventoryDataSetTableAdapters.view_Inventory_DetailsTableAdapter view_Inventory_DetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subcategoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn articleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eULNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAcquiredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warrantyValidityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldPropertyNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeofAcquisitionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateIssuedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateReceivedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkAccountableEmployeeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountableOfficerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn designationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDesignationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn divisionCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endUserUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oICDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn signatoryDesignationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oICUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventoryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depreciatedCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isSubscribedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eOSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newPropertyNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn officeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subcategoryCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn articleCodeDataGridViewTextBoxColumn;
    }
}