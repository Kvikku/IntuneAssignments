namespace IntuneAssignments.Presentation.Import
{
    partial class Import
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pbDestinationChecker = new PictureBox();
            pbSourceConnectionCheck = new PictureBox();
            lblDestination = new Label();
            lblSourceTenant = new Label();
            pbDestinationTenant = new PictureBox();
            pbSourceTenant = new PictureBox();
            pBHome = new PictureBox();
            dtgImportContent = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colPlatform = new DataGridViewTextBoxColumn();
            colID = new DataGridViewTextBoxColumn();
            pnlMainContent = new Panel();
            pnlAddFilter = new Panel();
            dtgFilters = new DataGridView();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            Rule = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            rbFilterExclude = new RadioButton();
            rbFilterInclude = new RadioButton();
            lblFilterHeader = new Label();
            cbAddFilter = new CheckBox();
            panel2 = new Panel();
            btnClearSelectedPoliciesFromDTG = new Button();
            lblHeader = new Label();
            tbSearch = new TextBox();
            btnSearch = new Button();
            btnClearContentDTG = new Button();
            btnListAll = new Button();
            clbContentTypes = new CheckedListBox();
            pBarLoading = new ProgressBar();
            pBarImportStatus = new ProgressBar();
            pnlStatusOutput = new Panel();
            lblStatus = new Label();
            rtbDeploymentSummary = new RichTextBox();
            pnlGroups = new Panel();
            btnClearSelectedFromGroupDTG = new Button();
            lblGroups = new Label();
            btnClearGroupDTG = new Button();
            pBarGroupLoading = new ProgressBar();
            dtgGroups = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            btnGroupListAll = new Button();
            btnGroupSearch = new Button();
            tBoxGroupSearch = new TextBox();
            cBoxAssignments = new CheckBox();
            btnImportContet = new Button();
            ToolTipImport = new ToolTip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDestinationChecker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSourceConnectionCheck).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDestinationTenant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSourceTenant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBHome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgImportContent).BeginInit();
            pnlMainContent.SuspendLayout();
            pnlAddFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgFilters).BeginInit();
            panel2.SuspendLayout();
            pnlStatusOutput.SuspendLayout();
            pnlGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgGroups).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pbDestinationChecker);
            panel1.Controls.Add(pbSourceConnectionCheck);
            panel1.Controls.Add(lblDestination);
            panel1.Controls.Add(lblSourceTenant);
            panel1.Controls.Add(pbDestinationTenant);
            panel1.Controls.Add(pbSourceTenant);
            panel1.Controls.Add(pBHome);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(102, 915);
            panel1.TabIndex = 0;
            // 
            // pbDestinationChecker
            // 
            pbDestinationChecker.Image = Properties.Resources.cancel;
            pbDestinationChecker.Location = new Point(11, 312);
            pbDestinationChecker.Name = "pbDestinationChecker";
            pbDestinationChecker.Size = new Size(38, 35);
            pbDestinationChecker.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDestinationChecker.TabIndex = 20;
            pbDestinationChecker.TabStop = false;
            // 
            // pbSourceConnectionCheck
            // 
            pbSourceConnectionCheck.Image = Properties.Resources.cancel;
            pbSourceConnectionCheck.Location = new Point(11, 166);
            pbSourceConnectionCheck.Name = "pbSourceConnectionCheck";
            pbSourceConnectionCheck.Size = new Size(38, 35);
            pbSourceConnectionCheck.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSourceConnectionCheck.TabIndex = 19;
            pbSourceConnectionCheck.TabStop = false;
            // 
            // lblDestination
            // 
            lblDestination.AutoSize = true;
            lblDestination.Font = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDestination.ForeColor = Color.Salmon;
            lblDestination.Location = new Point(11, 294);
            lblDestination.Name = "lblDestination";
            lblDestination.Size = new Size(84, 15);
            lblDestination.TabIndex = 18;
            lblDestination.Text = "Destination";
            lblDestination.Click += lblDestination_Click;
            // 
            // lblSourceTenant
            // 
            lblSourceTenant.AutoSize = true;
            lblSourceTenant.Font = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSourceTenant.ForeColor = Color.Salmon;
            lblSourceTenant.Location = new Point(11, 148);
            lblSourceTenant.Name = "lblSourceTenant";
            lblSourceTenant.Size = new Size(49, 15);
            lblSourceTenant.TabIndex = 17;
            lblSourceTenant.Text = "Source";
            lblSourceTenant.Click += lblSourceTenant_Click;
            // 
            // pbDestinationTenant
            // 
            pbDestinationTenant.Image = Properties.Resources.azure;
            pbDestinationTenant.Location = new Point(11, 227);
            pbDestinationTenant.Name = "pbDestinationTenant";
            pbDestinationTenant.Size = new Size(64, 64);
            pbDestinationTenant.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDestinationTenant.TabIndex = 16;
            pbDestinationTenant.TabStop = false;
            pbDestinationTenant.Click += pbDestinationTenant_Click;
            // 
            // pbSourceTenant
            // 
            pbSourceTenant.Image = Properties.Resources.azure;
            pbSourceTenant.Location = new Point(11, 81);
            pbSourceTenant.Name = "pbSourceTenant";
            pbSourceTenant.Size = new Size(64, 64);
            pbSourceTenant.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSourceTenant.TabIndex = 15;
            pbSourceTenant.TabStop = false;
            pbSourceTenant.Click += pbSourceTenant_Click;
            // 
            // pBHome
            // 
            pBHome.Image = Properties.Resources._15536420761558096328_48;
            pBHome.Location = new Point(11, 11);
            pBHome.Name = "pBHome";
            pBHome.Size = new Size(64, 64);
            pBHome.SizeMode = PictureBoxSizeMode.StretchImage;
            pBHome.TabIndex = 14;
            pBHome.TabStop = false;
            pBHome.Click += pBHome_Click;
            // 
            // dtgImportContent
            // 
            dtgImportContent.AllowUserToAddRows = false;
            dtgImportContent.AllowUserToDeleteRows = false;
            dtgImportContent.AllowUserToResizeColumns = false;
            dtgImportContent.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgImportContent.BorderStyle = BorderStyle.None;
            dtgImportContent.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtgImportContent.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Salmon;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgImportContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgImportContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgImportContent.Columns.AddRange(new DataGridViewColumn[] { colName, colType, colPlatform, colID });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Salmon;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgImportContent.DefaultCellStyle = dataGridViewCellStyle2;
            dtgImportContent.EnableHeadersVisualStyles = false;
            dtgImportContent.GridColor = Color.Salmon;
            dtgImportContent.Location = new Point(-1, 142);
            dtgImportContent.Name = "dtgImportContent";
            dtgImportContent.ReadOnly = true;
            dtgImportContent.RowHeadersVisible = false;
            dtgImportContent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgImportContent.Size = new Size(679, 459);
            dtgImportContent.TabIndex = 1;
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
            // pnlMainContent
            // 
            pnlMainContent.Controls.Add(pnlAddFilter);
            pnlMainContent.Controls.Add(cbAddFilter);
            pnlMainContent.Controls.Add(panel2);
            pnlMainContent.Controls.Add(pBarImportStatus);
            pnlMainContent.Controls.Add(pnlStatusOutput);
            pnlMainContent.Controls.Add(pnlGroups);
            pnlMainContent.Controls.Add(cBoxAssignments);
            pnlMainContent.Controls.Add(btnImportContet);
            pnlMainContent.Location = new Point(108, 12);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1762, 891);
            pnlMainContent.TabIndex = 2;
            // 
            // pnlAddFilter
            // 
            pnlAddFilter.BorderStyle = BorderStyle.FixedSingle;
            pnlAddFilter.Controls.Add(dtgFilters);
            pnlAddFilter.Controls.Add(rbFilterExclude);
            pnlAddFilter.Controls.Add(rbFilterInclude);
            pnlAddFilter.Controls.Add(lblFilterHeader);
            pnlAddFilter.Location = new Point(675, 623);
            pnlAddFilter.Name = "pnlAddFilter";
            pnlAddFilter.Size = new Size(645, 265);
            pnlAddFilter.TabIndex = 21;
            // 
            // dtgFilters
            // 
            dtgFilters.AllowUserToAddRows = false;
            dtgFilters.AllowUserToDeleteRows = false;
            dtgFilters.AllowUserToResizeColumns = false;
            dtgFilters.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgFilters.BorderStyle = BorderStyle.None;
            dtgFilters.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtgFilters.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Salmon;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtgFilters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dtgFilters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgFilters.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, Rule, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.Salmon;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dtgFilters.DefaultCellStyle = dataGridViewCellStyle4;
            dtgFilters.EnableHeadersVisualStyles = false;
            dtgFilters.GridColor = Color.Salmon;
            dtgFilters.Location = new Point(3, 51);
            dtgFilters.MultiSelect = false;
            dtgFilters.Name = "dtgFilters";
            dtgFilters.ReadOnly = true;
            dtgFilters.RowHeadersVisible = false;
            dtgFilters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgFilters.Size = new Size(658, 209);
            dtgFilters.TabIndex = 19;
            ToolTipImport.SetToolTip(dtgFilters, "Select the filter that you want to use");
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Name";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 150;
            // 
            // Rule
            // 
            Rule.HeaderText = "Rule";
            Rule.Name = "Rule";
            Rule.ReadOnly = true;
            Rule.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Platform";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "ID";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            dataGridViewTextBoxColumn8.Width = 200;
            // 
            // rbFilterExclude
            // 
            rbFilterExclude.AutoSize = true;
            rbFilterExclude.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbFilterExclude.ForeColor = Color.Salmon;
            rbFilterExclude.Location = new Point(211, 27);
            rbFilterExclude.Name = "rbFilterExclude";
            rbFilterExclude.Size = new Size(74, 18);
            rbFilterExclude.TabIndex = 31;
            rbFilterExclude.TabStop = true;
            rbFilterExclude.Text = "Exclude";
            rbFilterExclude.UseVisualStyleBackColor = true;
            rbFilterExclude.Click += rbFilterExclude_Click;
            // 
            // rbFilterInclude
            // 
            rbFilterInclude.AutoSize = true;
            rbFilterInclude.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbFilterInclude.ForeColor = Color.Salmon;
            rbFilterInclude.Location = new Point(211, 9);
            rbFilterInclude.Name = "rbFilterInclude";
            rbFilterInclude.Size = new Size(74, 18);
            rbFilterInclude.TabIndex = 30;
            rbFilterInclude.TabStop = true;
            rbFilterInclude.Text = "Include";
            rbFilterInclude.UseVisualStyleBackColor = true;
            rbFilterInclude.Click += rbFilterInclude_Click;
            // 
            // lblFilterHeader
            // 
            lblFilterHeader.AutoSize = true;
            lblFilterHeader.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFilterHeader.ForeColor = Color.Salmon;
            lblFilterHeader.Location = new Point(3, 9);
            lblFilterHeader.Name = "lblFilterHeader";
            lblFilterHeader.Size = new Size(202, 30);
            lblFilterHeader.TabIndex = 20;
            lblFilterHeader.Text = "Filter for assignment";
            // 
            // cbAddFilter
            // 
            cbAddFilter.AutoSize = true;
            cbAddFilter.ForeColor = Color.Salmon;
            cbAddFilter.Location = new Point(189, 644);
            cbAddFilter.Name = "cbAddFilter";
            cbAddFilter.Size = new Size(75, 19);
            cbAddFilter.TabIndex = 20;
            cbAddFilter.Text = "Add filter";
            cbAddFilter.UseVisualStyleBackColor = true;
            cbAddFilter.CheckedChanged += cbAddFilter_CheckedChanged;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnClearSelectedPoliciesFromDTG);
            panel2.Controls.Add(dtgImportContent);
            panel2.Controls.Add(lblHeader);
            panel2.Controls.Add(tbSearch);
            panel2.Controls.Add(btnSearch);
            panel2.Controls.Add(btnClearContentDTG);
            panel2.Controls.Add(btnListAll);
            panel2.Controls.Add(clbContentTypes);
            panel2.Controls.Add(pBarLoading);
            panel2.Location = new Point(3, 11);
            panel2.Name = "panel2";
            panel2.Size = new Size(666, 606);
            panel2.TabIndex = 19;
            // 
            // btnClearSelectedPoliciesFromDTG
            // 
            btnClearSelectedPoliciesFromDTG.BackColor = Color.Salmon;
            btnClearSelectedPoliciesFromDTG.FlatStyle = FlatStyle.Flat;
            btnClearSelectedPoliciesFromDTG.ForeColor = Color.FromArgb(46, 51, 73);
            btnClearSelectedPoliciesFromDTG.Location = new Point(309, 74);
            btnClearSelectedPoliciesFromDTG.Name = "btnClearSelectedPoliciesFromDTG";
            btnClearSelectedPoliciesFromDTG.Size = new Size(96, 28);
            btnClearSelectedPoliciesFromDTG.TabIndex = 21;
            btnClearSelectedPoliciesFromDTG.Text = "Clear selected";
            btnClearSelectedPoliciesFromDTG.UseVisualStyleBackColor = false;
            btnClearSelectedPoliciesFromDTG.Click += btnClearSelectedPoliciesFromDTG_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.Salmon;
            lblHeader.Location = new Point(3, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(152, 30);
            lblHeader.TabIndex = 18;
            lblHeader.Text = "Import content";
            // 
            // tbSearch
            // 
            tbSearch.BackColor = Color.FromArgb(46, 51, 73);
            tbSearch.BorderStyle = BorderStyle.None;
            tbSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearch.ForeColor = Color.Salmon;
            tbSearch.Location = new Point(3, 46);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(150, 22);
            tbSearch.TabIndex = 3;
            tbSearch.Text = "Enter search here";
            tbSearch.Click += tbSearch_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Salmon;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.FromArgb(46, 51, 73);
            btnSearch.Location = new Point(3, 74);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(96, 28);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClearContentDTG
            // 
            btnClearContentDTG.BackColor = Color.Salmon;
            btnClearContentDTG.FlatStyle = FlatStyle.Flat;
            btnClearContentDTG.ForeColor = Color.FromArgb(46, 51, 73);
            btnClearContentDTG.Location = new Point(207, 74);
            btnClearContentDTG.Name = "btnClearContentDTG";
            btnClearContentDTG.Size = new Size(96, 28);
            btnClearContentDTG.TabIndex = 16;
            btnClearContentDTG.Text = "Clear all";
            btnClearContentDTG.UseVisualStyleBackColor = false;
            btnClearContentDTG.Click += btnClearContentDTG_Click;
            // 
            // btnListAll
            // 
            btnListAll.BackColor = Color.Salmon;
            btnListAll.FlatStyle = FlatStyle.Flat;
            btnListAll.ForeColor = Color.FromArgb(46, 51, 73);
            btnListAll.Location = new Point(105, 74);
            btnListAll.Name = "btnListAll";
            btnListAll.Size = new Size(96, 28);
            btnListAll.TabIndex = 5;
            btnListAll.Text = "List all";
            btnListAll.UseVisualStyleBackColor = false;
            btnListAll.Click += btnListAll_Click;
            // 
            // clbContentTypes
            // 
            clbContentTypes.BackColor = Color.FromArgb(46, 51, 73);
            clbContentTypes.BorderStyle = BorderStyle.None;
            clbContentTypes.ForeColor = Color.Salmon;
            clbContentTypes.FormattingEnabled = true;
            clbContentTypes.Items.AddRange(new object[] { "Settings Catalog", "Device Compliance", "Device configuration", "ADMX Template", "Application", "Powershell script", "Remediation script", "macOS script" });
            clbContentTypes.Location = new Point(448, 4);
            clbContentTypes.Name = "clbContentTypes";
            clbContentTypes.ScrollAlwaysVisible = true;
            clbContentTypes.Size = new Size(215, 90);
            clbContentTypes.TabIndex = 2;
            clbContentTypes.MouseEnter += clbContentTypes_MouseEnter;
            clbContentTypes.MouseLeave += clbContentTypes_MouseLeave;
            // 
            // pBarLoading
            // 
            pBarLoading.Location = new Point(3, 105);
            pBarLoading.Name = "pBarLoading";
            pBarLoading.Size = new Size(402, 23);
            pBarLoading.Style = ProgressBarStyle.Marquee;
            pBarLoading.TabIndex = 6;
            // 
            // pBarImportStatus
            // 
            pBarImportStatus.Location = new Point(19, 669);
            pBarImportStatus.Name = "pBarImportStatus";
            pBarImportStatus.Size = new Size(300, 37);
            pBarImportStatus.Style = ProgressBarStyle.Marquee;
            pBarImportStatus.TabIndex = 16;
            // 
            // pnlStatusOutput
            // 
            pnlStatusOutput.BorderStyle = BorderStyle.FixedSingle;
            pnlStatusOutput.Controls.Add(lblStatus);
            pnlStatusOutput.Controls.Add(rtbDeploymentSummary);
            pnlStatusOutput.Location = new Point(1326, 11);
            pnlStatusOutput.Name = "pnlStatusOutput";
            pnlStatusOutput.Size = new Size(422, 606);
            pnlStatusOutput.TabIndex = 17;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Salmon;
            lblStatus.Location = new Point(3, 3);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(217, 30);
            lblStatus.TabIndex = 20;
            lblStatus.Text = "Deployment summary";
            // 
            // rtbDeploymentSummary
            // 
            rtbDeploymentSummary.BackColor = Color.FromArgb(46, 51, 73);
            rtbDeploymentSummary.BorderStyle = BorderStyle.None;
            rtbDeploymentSummary.ForeColor = Color.Salmon;
            rtbDeploymentSummary.Location = new Point(13, 35);
            rtbDeploymentSummary.Name = "rtbDeploymentSummary";
            rtbDeploymentSummary.Size = new Size(406, 552);
            rtbDeploymentSummary.TabIndex = 21;
            rtbDeploymentSummary.Text = "";
            // 
            // pnlGroups
            // 
            pnlGroups.BorderStyle = BorderStyle.FixedSingle;
            pnlGroups.Controls.Add(btnClearSelectedFromGroupDTG);
            pnlGroups.Controls.Add(lblGroups);
            pnlGroups.Controls.Add(btnClearGroupDTG);
            pnlGroups.Controls.Add(pBarGroupLoading);
            pnlGroups.Controls.Add(dtgGroups);
            pnlGroups.Controls.Add(btnGroupListAll);
            pnlGroups.Controls.Add(btnGroupSearch);
            pnlGroups.Controls.Add(tBoxGroupSearch);
            pnlGroups.Location = new Point(675, 11);
            pnlGroups.Name = "pnlGroups";
            pnlGroups.Size = new Size(645, 606);
            pnlGroups.TabIndex = 10;
            // 
            // btnClearSelectedFromGroupDTG
            // 
            btnClearSelectedFromGroupDTG.BackColor = Color.Salmon;
            btnClearSelectedFromGroupDTG.FlatStyle = FlatStyle.Flat;
            btnClearSelectedFromGroupDTG.ForeColor = Color.FromArgb(46, 51, 73);
            btnClearSelectedFromGroupDTG.Location = new Point(309, 75);
            btnClearSelectedFromGroupDTG.Name = "btnClearSelectedFromGroupDTG";
            btnClearSelectedFromGroupDTG.Size = new Size(96, 28);
            btnClearSelectedFromGroupDTG.TabIndex = 20;
            btnClearSelectedFromGroupDTG.Text = "Clear selected";
            btnClearSelectedFromGroupDTG.UseVisualStyleBackColor = false;
            btnClearSelectedFromGroupDTG.Click += btnClearSelectedFromGroupDTG_Click;
            // 
            // lblGroups
            // 
            lblGroups.AutoSize = true;
            lblGroups.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGroups.ForeColor = Color.Salmon;
            lblGroups.Location = new Point(3, 4);
            lblGroups.Name = "lblGroups";
            lblGroups.Size = new Size(223, 30);
            lblGroups.TabIndex = 19;
            lblGroups.Text = "Groups for assignment";
            // 
            // btnClearGroupDTG
            // 
            btnClearGroupDTG.BackColor = Color.Salmon;
            btnClearGroupDTG.FlatStyle = FlatStyle.Flat;
            btnClearGroupDTG.ForeColor = Color.FromArgb(46, 51, 73);
            btnClearGroupDTG.Location = new Point(207, 75);
            btnClearGroupDTG.Name = "btnClearGroupDTG";
            btnClearGroupDTG.Size = new Size(96, 28);
            btnClearGroupDTG.TabIndex = 15;
            btnClearGroupDTG.Text = "Clear all";
            btnClearGroupDTG.UseVisualStyleBackColor = false;
            btnClearGroupDTG.Click += btnClearGroupDTG_Click;
            // 
            // pBarGroupLoading
            // 
            pBarGroupLoading.Location = new Point(3, 105);
            pBarGroupLoading.Name = "pBarGroupLoading";
            pBarGroupLoading.Size = new Size(402, 23);
            pBarGroupLoading.Style = ProgressBarStyle.Marquee;
            pBarGroupLoading.TabIndex = 14;
            // 
            // dtgGroups
            // 
            dtgGroups.AllowUserToAddRows = false;
            dtgGroups.AllowUserToDeleteRows = false;
            dtgGroups.AllowUserToResizeColumns = false;
            dtgGroups.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgGroups.BorderStyle = BorderStyle.None;
            dtgGroups.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtgGroups.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.Salmon;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dtgGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dtgGroups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgGroups.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.Salmon;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dtgGroups.DefaultCellStyle = dataGridViewCellStyle6;
            dtgGroups.EnableHeadersVisualStyles = false;
            dtgGroups.GridColor = Color.Salmon;
            dtgGroups.Location = new Point(3, 142);
            dtgGroups.Name = "dtgGroups";
            dtgGroups.ReadOnly = true;
            dtgGroups.RowHeadersVisible = false;
            dtgGroups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgGroups.Size = new Size(658, 459);
            dtgGroups.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Name";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Group type";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Rule";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "ID";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 200;
            // 
            // btnGroupListAll
            // 
            btnGroupListAll.BackColor = Color.Salmon;
            btnGroupListAll.FlatStyle = FlatStyle.Flat;
            btnGroupListAll.ForeColor = Color.FromArgb(46, 51, 73);
            btnGroupListAll.Location = new Point(105, 75);
            btnGroupListAll.Name = "btnGroupListAll";
            btnGroupListAll.Size = new Size(96, 28);
            btnGroupListAll.TabIndex = 13;
            btnGroupListAll.Text = "List all";
            btnGroupListAll.UseVisualStyleBackColor = false;
            btnGroupListAll.Click += btnGroupListAll_Click;
            // 
            // btnGroupSearch
            // 
            btnGroupSearch.BackColor = Color.Salmon;
            btnGroupSearch.FlatStyle = FlatStyle.Flat;
            btnGroupSearch.ForeColor = Color.FromArgb(46, 51, 73);
            btnGroupSearch.Location = new Point(3, 75);
            btnGroupSearch.Name = "btnGroupSearch";
            btnGroupSearch.Size = new Size(96, 28);
            btnGroupSearch.TabIndex = 12;
            btnGroupSearch.Text = "Search";
            btnGroupSearch.UseVisualStyleBackColor = false;
            btnGroupSearch.Click += btnGroupSearch_Click;
            // 
            // tBoxGroupSearch
            // 
            tBoxGroupSearch.BackColor = Color.FromArgb(46, 51, 73);
            tBoxGroupSearch.BorderStyle = BorderStyle.None;
            tBoxGroupSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tBoxGroupSearch.ForeColor = Color.Salmon;
            tBoxGroupSearch.Location = new Point(3, 46);
            tBoxGroupSearch.Name = "tBoxGroupSearch";
            tBoxGroupSearch.Size = new Size(150, 22);
            tBoxGroupSearch.TabIndex = 11;
            tBoxGroupSearch.Text = "Enter search here";
            tBoxGroupSearch.Click += tBoxGroupSearch_Click;
            // 
            // cBoxAssignments
            // 
            cBoxAssignments.AutoSize = true;
            cBoxAssignments.ForeColor = Color.Salmon;
            cBoxAssignments.Location = new Point(189, 623);
            cBoxAssignments.Name = "cBoxAssignments";
            cBoxAssignments.Size = new Size(117, 19);
            cBoxAssignments.TabIndex = 9;
            cBoxAssignments.Text = "Add assignments";
            cBoxAssignments.UseVisualStyleBackColor = true;
            cBoxAssignments.CheckedChanged += cBoxAssignments_CheckedChanged;
            // 
            // btnImportContet
            // 
            btnImportContet.BackColor = Color.Salmon;
            btnImportContet.FlatStyle = FlatStyle.Flat;
            btnImportContet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImportContet.ForeColor = Color.FromArgb(46, 51, 73);
            btnImportContet.Location = new Point(19, 623);
            btnImportContet.Name = "btnImportContet";
            btnImportContet.Size = new Size(164, 40);
            btnImportContet.TabIndex = 7;
            btnImportContet.Text = "Import";
            btnImportContet.UseVisualStyleBackColor = false;
            btnImportContet.Click += btnImportContet_Click;
            // 
            // Import
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1882, 915);
            Controls.Add(pnlMainContent);
            Controls.Add(panel1);
            Name = "Import";
            Load += Import_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbDestinationChecker).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSourceConnectionCheck).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDestinationTenant).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSourceTenant).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBHome).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgImportContent).EndInit();
            pnlMainContent.ResumeLayout(false);
            pnlMainContent.PerformLayout();
            pnlAddFilter.ResumeLayout(false);
            pnlAddFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgFilters).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlStatusOutput.ResumeLayout(false);
            pnlStatusOutput.PerformLayout();
            pnlGroups.ResumeLayout(false);
            pnlGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgGroups).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pBHome;
        private PictureBox pbDestinationTenant;
        private PictureBox pbSourceTenant;
        private Label lblDestination;
        private Label lblSourceTenant;
        private PictureBox pbDestinationChecker;
        private PictureBox pbSourceConnectionCheck;
        private DataGridView dtgImportContent;
        private Panel pnlMainContent;
        private CheckedListBox clbContentTypes;
        private TextBox tbSearch;
        private Button btnSearch;
        private Button btnListAll;
        private ProgressBar pBarLoading;
        private Button btnImportContet;
        private CheckBox cBoxAssignments;
        private Panel pnlGroups;
        private ProgressBar pBarGroupLoading;
        private DataGridView dtgGroups;
        private Button btnGroupListAll;
        private Button btnGroupSearch;
        private TextBox tBoxGroupSearch;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Button btnClearGroupDTG;
        private Button btnClearContentDTG;
        private Panel pnlStatusOutput;
        private RichTextBox rtbDeploymentSummary;
        private ProgressBar pBarImportStatus;
        private Label lblHeader;
        private Label lblStatus;
        private Label lblGroups;
        private Panel panel2;
        private Button btnClearSelectedFromGroupDTG;
        private CheckBox cbAddFilter;
        private Panel pnlAddFilter;
        private Label lblFilterHeader;
        private RadioButton rbFilterExclude;
        private RadioButton rbFilterInclude;
        private DataGridView dtgFilters;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn Rule;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colPlatform;
        private DataGridViewTextBoxColumn colID;
        private ToolTip ToolTipImport;
        private Button btnClearSelectedPoliciesFromDTG;
    }
}