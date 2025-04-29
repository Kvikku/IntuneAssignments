namespace IntuneAssignments.Presentation.Bulk_operations
{
    partial class Maintenance
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pBHome = new PictureBox();
            panel1 = new Panel();
            pbDestinationTenantCheck = new PictureBox();
            lblTenant = new Label();
            pbDestinationTenant = new PictureBox();
            btnClearSelectedPoliciesFromDTG = new Button();
            dtgDeleteContent = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colPlatform = new DataGridViewTextBoxColumn();
            colID = new DataGridViewTextBoxColumn();
            lblHeader = new Label();
            tbSearch = new TextBox();
            btnSearch = new Button();
            btnClearContentDTG = new Button();
            btnListAll = new Button();
            pBarLoading = new ProgressBar();
            tabControlMaintenance = new TabControl();
            tbBulkDelete = new TabPage();
            clbContentTypes = new CheckedListBox();
            btnBulkDelete = new Button();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)pBHome).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDestinationTenantCheck).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDestinationTenant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgDeleteContent).BeginInit();
            tabControlMaintenance.SuspendLayout();
            tbBulkDelete.SuspendLayout();
            SuspendLayout();
            // 
            // pBHome
            // 
            pBHome.Image = Properties.Resources._15536420761558096328_48;
            pBHome.Location = new Point(12, 12);
            pBHome.Name = "pBHome";
            pBHome.Size = new Size(64, 64);
            pBHome.SizeMode = PictureBoxSizeMode.StretchImage;
            pBHome.TabIndex = 15;
            pBHome.TabStop = false;
            pBHome.Click += pBHome_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pbDestinationTenantCheck);
            panel1.Controls.Add(pBHome);
            panel1.Controls.Add(lblTenant);
            panel1.Controls.Add(pbDestinationTenant);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(98, 768);
            panel1.TabIndex = 16;
            // 
            // pbDestinationTenantCheck
            // 
            pbDestinationTenantCheck.Image = Properties.Resources.cancel;
            pbDestinationTenantCheck.Location = new Point(12, 167);
            pbDestinationTenantCheck.Name = "pbDestinationTenantCheck";
            pbDestinationTenantCheck.Size = new Size(38, 35);
            pbDestinationTenantCheck.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDestinationTenantCheck.TabIndex = 22;
            pbDestinationTenantCheck.TabStop = false;
            // 
            // lblTenant
            // 
            lblTenant.AutoSize = true;
            lblTenant.Font = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenant.ForeColor = Color.Salmon;
            lblTenant.Location = new Point(12, 149);
            lblTenant.Name = "lblTenant";
            lblTenant.Size = new Size(49, 15);
            lblTenant.TabIndex = 21;
            lblTenant.Text = "Tenant";
            // 
            // pbDestinationTenant
            // 
            pbDestinationTenant.Image = Properties.Resources.azure;
            pbDestinationTenant.Location = new Point(12, 82);
            pbDestinationTenant.Name = "pbDestinationTenant";
            pbDestinationTenant.Size = new Size(64, 64);
            pbDestinationTenant.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDestinationTenant.TabIndex = 20;
            pbDestinationTenant.TabStop = false;
            pbDestinationTenant.Click += pbDestinationTenant_Click;
            // 
            // btnClearSelectedPoliciesFromDTG
            // 
            btnClearSelectedPoliciesFromDTG.BackColor = Color.Salmon;
            btnClearSelectedPoliciesFromDTG.FlatStyle = FlatStyle.Flat;
            btnClearSelectedPoliciesFromDTG.ForeColor = Color.FromArgb(46, 51, 73);
            btnClearSelectedPoliciesFromDTG.Location = new Point(312, 75);
            btnClearSelectedPoliciesFromDTG.Name = "btnClearSelectedPoliciesFromDTG";
            btnClearSelectedPoliciesFromDTG.Size = new Size(96, 28);
            btnClearSelectedPoliciesFromDTG.TabIndex = 29;
            btnClearSelectedPoliciesFromDTG.Text = "Clear selected";
            btnClearSelectedPoliciesFromDTG.UseVisualStyleBackColor = false;
            // 
            // dtgDeleteContent
            // 
            dtgDeleteContent.AllowUserToAddRows = false;
            dtgDeleteContent.AllowUserToDeleteRows = false;
            dtgDeleteContent.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgDeleteContent.BorderStyle = BorderStyle.None;
            dtgDeleteContent.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtgDeleteContent.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Salmon;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgDeleteContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgDeleteContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDeleteContent.Columns.AddRange(new DataGridViewColumn[] { colName, colType, colPlatform, colID });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Salmon;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgDeleteContent.DefaultCellStyle = dataGridViewCellStyle2;
            dtgDeleteContent.EnableHeadersVisualStyles = false;
            dtgDeleteContent.GridColor = Color.Salmon;
            dtgDeleteContent.Location = new Point(2, 143);
            dtgDeleteContent.Name = "dtgDeleteContent";
            dtgDeleteContent.ReadOnly = true;
            dtgDeleteContent.RowHeadersVisible = false;
            dtgDeleteContent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDeleteContent.Size = new Size(679, 567);
            dtgDeleteContent.TabIndex = 22;
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 250;
            // 
            // colType
            // 
            colType.HeaderText = "Type";
            colType.Name = "colType";
            colType.ReadOnly = true;
            // 
            // colPlatform
            // 
            colPlatform.HeaderText = "Platform";
            colPlatform.Name = "colPlatform";
            colPlatform.ReadOnly = true;
            // 
            // colID
            // 
            colID.HeaderText = "ID";
            colID.Name = "colID";
            colID.ReadOnly = true;
            colID.Width = 220;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.Salmon;
            lblHeader.Location = new Point(6, 10);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(150, 30);
            lblHeader.TabIndex = 28;
            lblHeader.Text = "Delete content";
            // 
            // tbSearch
            // 
            tbSearch.BackColor = Color.FromArgb(46, 51, 73);
            tbSearch.BorderStyle = BorderStyle.None;
            tbSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearch.ForeColor = Color.Salmon;
            tbSearch.Location = new Point(6, 43);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(150, 22);
            tbSearch.TabIndex = 23;
            tbSearch.Text = "Enter search here";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Salmon;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.FromArgb(46, 51, 73);
            btnSearch.Location = new Point(6, 75);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(96, 28);
            btnSearch.TabIndex = 24;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnClearContentDTG
            // 
            btnClearContentDTG.BackColor = Color.Salmon;
            btnClearContentDTG.FlatStyle = FlatStyle.Flat;
            btnClearContentDTG.ForeColor = Color.FromArgb(46, 51, 73);
            btnClearContentDTG.Location = new Point(210, 75);
            btnClearContentDTG.Name = "btnClearContentDTG";
            btnClearContentDTG.Size = new Size(96, 28);
            btnClearContentDTG.TabIndex = 27;
            btnClearContentDTG.Text = "Clear all";
            btnClearContentDTG.UseVisualStyleBackColor = false;
            // 
            // btnListAll
            // 
            btnListAll.BackColor = Color.Salmon;
            btnListAll.FlatStyle = FlatStyle.Flat;
            btnListAll.ForeColor = Color.FromArgb(46, 51, 73);
            btnListAll.Location = new Point(108, 75);
            btnListAll.Name = "btnListAll";
            btnListAll.Size = new Size(96, 28);
            btnListAll.TabIndex = 25;
            btnListAll.Text = "List all";
            btnListAll.UseVisualStyleBackColor = false;
            btnListAll.Click += btnListAll_Click;
            // 
            // pBarLoading
            // 
            pBarLoading.Location = new Point(6, 106);
            pBarLoading.Name = "pBarLoading";
            pBarLoading.Size = new Size(402, 23);
            pBarLoading.Style = ProgressBarStyle.Marquee;
            pBarLoading.TabIndex = 26;
            // 
            // tabControlMaintenance
            // 
            tabControlMaintenance.Controls.Add(tbBulkDelete);
            tabControlMaintenance.Controls.Add(tabPage2);
            tabControlMaintenance.Location = new Point(104, 12);
            tabControlMaintenance.Name = "tabControlMaintenance";
            tabControlMaintenance.SelectedIndex = 0;
            tabControlMaintenance.Size = new Size(949, 744);
            tabControlMaintenance.TabIndex = 30;
            // 
            // tbBulkDelete
            // 
            tbBulkDelete.BackColor = Color.FromArgb(46, 51, 73);
            tbBulkDelete.Controls.Add(clbContentTypes);
            tbBulkDelete.Controls.Add(btnBulkDelete);
            tbBulkDelete.Controls.Add(lblHeader);
            tbBulkDelete.Controls.Add(btnClearSelectedPoliciesFromDTG);
            tbBulkDelete.Controls.Add(pBarLoading);
            tbBulkDelete.Controls.Add(dtgDeleteContent);
            tbBulkDelete.Controls.Add(btnListAll);
            tbBulkDelete.Controls.Add(btnClearContentDTG);
            tbBulkDelete.Controls.Add(tbSearch);
            tbBulkDelete.Controls.Add(btnSearch);
            tbBulkDelete.Location = new Point(4, 24);
            tbBulkDelete.Name = "tbBulkDelete";
            tbBulkDelete.Padding = new Padding(3);
            tbBulkDelete.Size = new Size(941, 716);
            tbBulkDelete.TabIndex = 0;
            tbBulkDelete.Text = "Bulk delete";
            // 
            // clbContentTypes
            // 
            clbContentTypes.BackColor = Color.FromArgb(46, 51, 73);
            clbContentTypes.BorderStyle = BorderStyle.None;
            clbContentTypes.ForeColor = Color.Salmon;
            clbContentTypes.FormattingEnabled = true;
            clbContentTypes.Items.AddRange(new object[] { "Groups", "Assignment Filters", "Settings Catalog", "Device Compliance", "Device Configuration", "PowerShell script", "Proactive Remediations", "Windows Autopilot", "Windows Feature Update Profiles", "Windows Quality Update Policies", "Windows Expedite Policies", "Apple BYOD Enrollment Profiles", "macOS script", "Application", "Group Policy Configuration" });
            clbContentTypes.Location = new Point(414, 3);
            clbContentTypes.Name = "clbContentTypes";
            clbContentTypes.ScrollAlwaysVisible = true;
            clbContentTypes.Size = new Size(215, 126);
            clbContentTypes.TabIndex = 31;
            // 
            // btnBulkDelete
            // 
            btnBulkDelete.BackColor = Color.Salmon;
            btnBulkDelete.FlatStyle = FlatStyle.Flat;
            btnBulkDelete.ForeColor = Color.FromArgb(46, 51, 73);
            btnBulkDelete.Location = new Point(663, 100);
            btnBulkDelete.Name = "btnBulkDelete";
            btnBulkDelete.Size = new Size(96, 28);
            btnBulkDelete.TabIndex = 30;
            btnBulkDelete.Text = "Delete";
            btnBulkDelete.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(941, 716);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Bulk rename";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Maintenance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1065, 768);
            Controls.Add(tabControlMaintenance);
            Controls.Add(panel1);
            Name = "Maintenance";
            Text = "Maintenance";
            Load += Maintenance_Load;
            ((System.ComponentModel.ISupportInitialize)pBHome).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbDestinationTenantCheck).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDestinationTenant).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgDeleteContent).EndInit();
            tabControlMaintenance.ResumeLayout(false);
            tbBulkDelete.ResumeLayout(false);
            tbBulkDelete.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pBHome;
        private Panel panel1;
        private PictureBox pbDestinationTenantCheck;
        private Label lblTenant;
        private PictureBox pbDestinationTenant;
        private Button btnClearSelectedPoliciesFromDTG;
        private DataGridView dtgDeleteContent;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colPlatform;
        private DataGridViewTextBoxColumn colID;
        private Label lblHeader;
        private TextBox tbSearch;
        private Button btnSearch;
        private Button btnClearContentDTG;
        private Button btnListAll;
        private ProgressBar pBarLoading;
        private TabControl tabControlMaintenance;
        private TabPage tbBulkDelete;
        private TabPage tabPage2;
        private Button btnBulkDelete;
        private CheckedListBox clbContentTypes;
    }
}