namespace IntuneAssignments
{
    partial class Policy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Policy));
            pbHome = new PictureBox();
            pnlSearchPolicy = new Panel();
            lblSelectApps = new Label();
            dtgDisplayPolicy = new DataGridView();
            PolicyName = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            Platform = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            Assigned = new DataGridViewTextBoxColumn();
            cmsDisplayPolicy = new ContextMenuStrip(components);
            copyCellContentToolStripMenuItem = new ToolStripMenuItem();
            btnListAllPolicy = new Button();
            btnSearchPolicy = new Button();
            txtboxSearchPolicy = new TextBox();
            cbPolicyType = new ComboBox();
            dtgDisplayGroup = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            MemberCount = new DataGridViewTextBoxColumn();
            groupType = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            cmsDisplayGroup = new ContextMenuStrip(components);
            copyCellContentToolStripMenuItem1 = new ToolStripMenuItem();
            btnListAllGroups = new Button();
            btnSearchGroup = new Button();
            txtboxSearchGroup = new TextBox();
            rtbAssignmentPreview = new RichTextBox();
            pnlAssignedTo = new Panel();
            lblAssignedTo = new Label();
            lblAssignmentPreview = new Label();
            pnlSummary = new Panel();
            rbFilterExclude = new RadioButton();
            rbFilterInclude = new RadioButton();
            pbFilterWarning = new PictureBox();
            lblFilter = new Label();
            cbFilter = new ComboBox();
            btn_ResetProgressBar = new Button();
            btnDeployDescription = new Button();
            rtbDeploymentSummary = new RichTextBox();
            cbLookUpAssignment = new CheckBox();
            pBarDeployProgress = new ProgressBar();
            rtbSelectedGroups = new RichTextBox();
            rtbSelectedPolicies = new RichTextBox();
            lblSelectedGroups = new Label();
            btnDeployPolicyAssignment = new Button();
            btnResetDeployment = new Button();
            lblSelectedPolicies = new Label();
            btnPrepareDeployment = new Button();
            pnlSearchGroup = new Panel();
            lblSelectGroups = new Label();
            toolTipPolicy = new ToolTip(components);
            txtboxDescription = new TextBox();
            pbHelpGuide = new PictureBox();
            pnlDescription = new Panel();
            label1 = new Label();
            pbViewAssignments = new PictureBox();
            lblHeaderAppForm = new Label();
            ((System.ComponentModel.ISupportInitialize)pbHome).BeginInit();
            pnlSearchPolicy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayPolicy).BeginInit();
            cmsDisplayPolicy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).BeginInit();
            cmsDisplayGroup.SuspendLayout();
            pnlAssignedTo.SuspendLayout();
            pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFilterWarning).BeginInit();
            pnlSearchGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbHelpGuide).BeginInit();
            pnlDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbViewAssignments).BeginInit();
            SuspendLayout();
            // 
            // pbHome
            // 
            pbHome.Image = Properties.Resources._15536420761558096328_48;
            pbHome.Location = new Point(12, 12);
            pbHome.Name = "pbHome";
            pbHome.Size = new Size(64, 64);
            pbHome.SizeMode = PictureBoxSizeMode.StretchImage;
            pbHome.TabIndex = 0;
            pbHome.TabStop = false;
            toolTipPolicy.SetToolTip(pbHome, "Home");
            pbHome.Click += pbHome_Click;
            // 
            // pnlSearchPolicy
            // 
            pnlSearchPolicy.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchPolicy.Controls.Add(lblSelectApps);
            pnlSearchPolicy.Controls.Add(dtgDisplayPolicy);
            pnlSearchPolicy.Controls.Add(btnListAllPolicy);
            pnlSearchPolicy.Controls.Add(btnSearchPolicy);
            pnlSearchPolicy.Controls.Add(txtboxSearchPolicy);
            pnlSearchPolicy.Controls.Add(cbPolicyType);
            pnlSearchPolicy.Location = new Point(97, 31);
            pnlSearchPolicy.Name = "pnlSearchPolicy";
            pnlSearchPolicy.Size = new Size(795, 468);
            pnlSearchPolicy.TabIndex = 1;
            // 
            // lblSelectApps
            // 
            lblSelectApps.AutoSize = true;
            lblSelectApps.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSelectApps.ForeColor = Color.Salmon;
            lblSelectApps.Location = new Point(9, 10);
            lblSelectApps.Name = "lblSelectApps";
            lblSelectApps.Size = new Size(106, 24);
            lblSelectApps.TabIndex = 10;
            lblSelectApps.Text = "Policies";
            toolTipPolicy.SetToolTip(lblSelectApps, "Selected policies");
            // 
            // dtgDisplayPolicy
            // 
            dtgDisplayPolicy.AllowUserToAddRows = false;
            dtgDisplayPolicy.AllowUserToDeleteRows = false;
            dtgDisplayPolicy.AllowUserToResizeRows = false;
            dtgDisplayPolicy.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgDisplayPolicy.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Salmon;
            dataGridViewCellStyle1.Font = new Font("Consolas", 12F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgDisplayPolicy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgDisplayPolicy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayPolicy.Columns.AddRange(new DataGridViewColumn[] { PolicyName, Type, Platform, ID, Assigned });
            dtgDisplayPolicy.ContextMenuStrip = cmsDisplayPolicy;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.Salmon;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgDisplayPolicy.DefaultCellStyle = dataGridViewCellStyle2;
            dtgDisplayPolicy.EnableHeadersVisualStyles = false;
            dtgDisplayPolicy.Location = new Point(9, 98);
            dtgDisplayPolicy.Name = "dtgDisplayPolicy";
            dtgDisplayPolicy.ReadOnly = true;
            dtgDisplayPolicy.RowHeadersVisible = false;
            dtgDisplayPolicy.RowHeadersWidth = 51;
            dtgDisplayPolicy.Size = new Size(781, 365);
            dtgDisplayPolicy.TabIndex = 4;
            dtgDisplayPolicy.CellClick += dtgDisplayPolicy_CellClick;
            dtgDisplayPolicy.SelectionChanged += dtgDisplayPolicy_SelectionChanged;
            // 
            // PolicyName
            // 
            PolicyName.HeaderText = "Name";
            PolicyName.MinimumWidth = 6;
            PolicyName.Name = "PolicyName";
            PolicyName.ReadOnly = true;
            PolicyName.Width = 400;
            // 
            // Type
            // 
            Type.HeaderText = "Type";
            Type.MinimumWidth = 6;
            Type.Name = "Type";
            Type.ReadOnly = true;
            Type.Width = 200;
            // 
            // Platform
            // 
            Platform.HeaderText = "Platform";
            Platform.MinimumWidth = 6;
            Platform.Name = "Platform";
            Platform.ReadOnly = true;
            Platform.Width = 200;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 125;
            // 
            // Assigned
            // 
            Assigned.HeaderText = "Assigned";
            Assigned.Name = "Assigned";
            Assigned.ReadOnly = true;
            // 
            // cmsDisplayPolicy
            // 
            cmsDisplayPolicy.Items.AddRange(new ToolStripItem[] { copyCellContentToolStripMenuItem });
            cmsDisplayPolicy.Name = "cmsDisplayPolicy";
            cmsDisplayPolicy.Size = new Size(168, 26);
            // 
            // copyCellContentToolStripMenuItem
            // 
            copyCellContentToolStripMenuItem.Name = "copyCellContentToolStripMenuItem";
            copyCellContentToolStripMenuItem.Size = new Size(167, 22);
            copyCellContentToolStripMenuItem.Text = "Copy cell content";
            copyCellContentToolStripMenuItem.Click += copyCellContentToolStripMenuItem_Click;
            // 
            // btnListAllPolicy
            // 
            btnListAllPolicy.BackColor = Color.Salmon;
            btnListAllPolicy.FlatStyle = FlatStyle.Flat;
            btnListAllPolicy.Font = new Font("Consolas", 12F);
            btnListAllPolicy.Location = new Point(662, 42);
            btnListAllPolicy.Name = "btnListAllPolicy";
            btnListAllPolicy.Size = new Size(128, 41);
            btnListAllPolicy.TabIndex = 3;
            btnListAllPolicy.Text = "List all";
            toolTipPolicy.SetToolTip(btnListAllPolicy, "List all applications");
            btnListAllPolicy.UseVisualStyleBackColor = false;
            btnListAllPolicy.Click += btnListAllPolicy_Click;
            // 
            // btnSearchPolicy
            // 
            btnSearchPolicy.BackColor = Color.Salmon;
            btnSearchPolicy.FlatStyle = FlatStyle.Flat;
            btnSearchPolicy.Font = new Font("Consolas", 12F);
            btnSearchPolicy.Location = new Point(528, 42);
            btnSearchPolicy.Name = "btnSearchPolicy";
            btnSearchPolicy.Size = new Size(128, 41);
            btnSearchPolicy.TabIndex = 2;
            btnSearchPolicy.Text = "Search";
            toolTipPolicy.SetToolTip(btnSearchPolicy, "Search for applications");
            btnSearchPolicy.UseVisualStyleBackColor = false;
            btnSearchPolicy.Click += btnSearchPolicy_Click;
            // 
            // txtboxSearchPolicy
            // 
            txtboxSearchPolicy.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchPolicy.BorderStyle = BorderStyle.FixedSingle;
            txtboxSearchPolicy.Font = new Font("Consolas", 12F);
            txtboxSearchPolicy.ForeColor = Color.Salmon;
            txtboxSearchPolicy.Location = new Point(188, 49);
            txtboxSearchPolicy.Name = "txtboxSearchPolicy";
            txtboxSearchPolicy.Size = new Size(186, 26);
            txtboxSearchPolicy.TabIndex = 1;
            txtboxSearchPolicy.Text = "Enter search here";
            toolTipPolicy.SetToolTip(txtboxSearchPolicy, "Enter search query here");
            txtboxSearchPolicy.Click += txtboxSearchPolicy_Click;
            // 
            // cbPolicyType
            // 
            cbPolicyType.BackColor = Color.FromArgb(46, 51, 73);
            cbPolicyType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPolicyType.FlatStyle = FlatStyle.Popup;
            cbPolicyType.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbPolicyType.ForeColor = Color.Salmon;
            cbPolicyType.FormattingEnabled = true;
            cbPolicyType.Items.AddRange(new object[] { "All types", "Compliance policy", "Administrative templates", "Settings catalog", "Security baseline" });
            cbPolicyType.Location = new Point(9, 51);
            cbPolicyType.Name = "cbPolicyType";
            cbPolicyType.Size = new Size(163, 22);
            cbPolicyType.TabIndex = 0;
            toolTipPolicy.SetToolTip(cbPolicyType, "Filter on type");
            // 
            // dtgDisplayGroup
            // 
            dtgDisplayGroup.AllowUserToAddRows = false;
            dtgDisplayGroup.AllowUserToDeleteRows = false;
            dtgDisplayGroup.AllowUserToResizeRows = false;
            dtgDisplayGroup.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgDisplayGroup.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Salmon;
            dataGridViewCellStyle3.Font = new Font("Consolas", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtgDisplayGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dtgDisplayGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayGroup.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, MemberCount, groupType, dataGridViewTextBoxColumn2 });
            dtgDisplayGroup.ContextMenuStrip = cmsDisplayGroup;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = Color.Salmon;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dtgDisplayGroup.DefaultCellStyle = dataGridViewCellStyle4;
            dtgDisplayGroup.EnableHeadersVisualStyles = false;
            dtgDisplayGroup.GridColor = Color.Salmon;
            dtgDisplayGroup.Location = new Point(3, 98);
            dtgDisplayGroup.Name = "dtgDisplayGroup";
            dtgDisplayGroup.ReadOnly = true;
            dtgDisplayGroup.RowHeadersVisible = false;
            dtgDisplayGroup.RowHeadersWidth = 51;
            dtgDisplayGroup.Size = new Size(679, 401);
            dtgDisplayGroup.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Group name";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 250;
            // 
            // MemberCount
            // 
            MemberCount.HeaderText = "Count";
            MemberCount.MinimumWidth = 6;
            MemberCount.Name = "MemberCount";
            MemberCount.ReadOnly = true;
            MemberCount.Width = 125;
            // 
            // groupType
            // 
            groupType.HeaderText = "Type";
            groupType.MinimumWidth = 6;
            groupType.Name = "groupType";
            groupType.ReadOnly = true;
            groupType.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Group ID";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 300;
            // 
            // cmsDisplayGroup
            // 
            cmsDisplayGroup.Items.AddRange(new ToolStripItem[] { copyCellContentToolStripMenuItem1 });
            cmsDisplayGroup.Name = "cmsDisplayGroup";
            cmsDisplayGroup.Size = new Size(168, 26);
            // 
            // copyCellContentToolStripMenuItem1
            // 
            copyCellContentToolStripMenuItem1.Name = "copyCellContentToolStripMenuItem1";
            copyCellContentToolStripMenuItem1.Size = new Size(167, 22);
            copyCellContentToolStripMenuItem1.Text = "Copy cell content";
            copyCellContentToolStripMenuItem1.Click += copyCellContentToolStripMenuItem1_Click;
            // 
            // btnListAllGroups
            // 
            btnListAllGroups.BackColor = Color.Salmon;
            btnListAllGroups.FlatStyle = FlatStyle.Flat;
            btnListAllGroups.Font = new Font("Consolas", 12F);
            btnListAllGroups.Location = new Point(503, 42);
            btnListAllGroups.Name = "btnListAllGroups";
            btnListAllGroups.Size = new Size(128, 41);
            btnListAllGroups.TabIndex = 8;
            btnListAllGroups.Text = "List all";
            toolTipPolicy.SetToolTip(btnListAllGroups, "List all groups");
            btnListAllGroups.UseVisualStyleBackColor = false;
            btnListAllGroups.Click += btnListAllGroups_Click;
            // 
            // btnSearchGroup
            // 
            btnSearchGroup.BackColor = Color.Salmon;
            btnSearchGroup.FlatStyle = FlatStyle.Flat;
            btnSearchGroup.Font = new Font("Consolas", 12F);
            btnSearchGroup.Location = new Point(369, 42);
            btnSearchGroup.Name = "btnSearchGroup";
            btnSearchGroup.Size = new Size(128, 41);
            btnSearchGroup.TabIndex = 7;
            btnSearchGroup.Text = "Search";
            toolTipPolicy.SetToolTip(btnSearchGroup, "Search for groups");
            btnSearchGroup.UseVisualStyleBackColor = false;
            btnSearchGroup.Click += btnSearchGroup_Click;
            // 
            // txtboxSearchGroup
            // 
            txtboxSearchGroup.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchGroup.BorderStyle = BorderStyle.FixedSingle;
            txtboxSearchGroup.Font = new Font("Consolas", 12F);
            txtboxSearchGroup.ForeColor = Color.Salmon;
            txtboxSearchGroup.Location = new Point(3, 57);
            txtboxSearchGroup.Name = "txtboxSearchGroup";
            txtboxSearchGroup.Size = new Size(162, 26);
            txtboxSearchGroup.TabIndex = 6;
            txtboxSearchGroup.Text = "Enter search here";
            toolTipPolicy.SetToolTip(txtboxSearchGroup, "Enter search query here");
            txtboxSearchGroup.Click += txtboxSearchGroup_Click;
            // 
            // rtbAssignmentPreview
            // 
            rtbAssignmentPreview.BackColor = Color.FromArgb(46, 51, 73);
            rtbAssignmentPreview.BorderStyle = BorderStyle.None;
            rtbAssignmentPreview.ForeColor = Color.Salmon;
            rtbAssignmentPreview.Location = new Point(10, 110);
            rtbAssignmentPreview.Name = "rtbAssignmentPreview";
            rtbAssignmentPreview.ReadOnly = true;
            rtbAssignmentPreview.Size = new Size(327, 224);
            rtbAssignmentPreview.TabIndex = 2;
            rtbAssignmentPreview.Text = "";
            // 
            // pnlAssignedTo
            // 
            pnlAssignedTo.BorderStyle = BorderStyle.FixedSingle;
            pnlAssignedTo.Controls.Add(lblAssignedTo);
            pnlAssignedTo.Controls.Add(lblAssignmentPreview);
            pnlAssignedTo.Controls.Add(rtbAssignmentPreview);
            pnlAssignedTo.Location = new Point(1327, 28);
            pnlAssignedTo.Name = "pnlAssignedTo";
            pnlAssignedTo.Size = new Size(468, 344);
            pnlAssignedTo.TabIndex = 3;
            // 
            // lblAssignedTo
            // 
            lblAssignedTo.AutoSize = true;
            lblAssignedTo.Font = new Font("Segoe UI", 11.25F);
            lblAssignedTo.ForeColor = Color.Salmon;
            lblAssignedTo.Location = new Point(5, 38);
            lblAssignedTo.Name = "lblAssignedTo";
            lblAssignedTo.Size = new Size(99, 20);
            lblAssignedTo.TabIndex = 4;
            lblAssignedTo.Text = "Is assigned to";
            // 
            // lblAssignmentPreview
            // 
            lblAssignmentPreview.AutoSize = true;
            lblAssignmentPreview.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblAssignmentPreview.ForeColor = Color.Salmon;
            lblAssignmentPreview.Location = new Point(3, 10);
            lblAssignmentPreview.Name = "lblAssignmentPreview";
            lblAssignmentPreview.Size = new Size(101, 20);
            lblAssignmentPreview.TabIndex = 3;
            lblAssignmentPreview.Text = "NAMEOFAPP";
            // 
            // pnlSummary
            // 
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.Controls.Add(rbFilterExclude);
            pnlSummary.Controls.Add(rbFilterInclude);
            pnlSummary.Controls.Add(pbFilterWarning);
            pnlSummary.Controls.Add(lblFilter);
            pnlSummary.Controls.Add(cbFilter);
            pnlSummary.Controls.Add(btn_ResetProgressBar);
            pnlSummary.Controls.Add(btnDeployDescription);
            pnlSummary.Controls.Add(rtbDeploymentSummary);
            pnlSummary.Controls.Add(cbLookUpAssignment);
            pnlSummary.Controls.Add(pBarDeployProgress);
            pnlSummary.Controls.Add(rtbSelectedGroups);
            pnlSummary.Controls.Add(rtbSelectedPolicies);
            pnlSummary.Controls.Add(pnlAssignedTo);
            pnlSummary.Controls.Add(lblSelectedGroups);
            pnlSummary.Controls.Add(btnDeployPolicyAssignment);
            pnlSummary.Controls.Add(btnResetDeployment);
            pnlSummary.Controls.Add(lblSelectedPolicies);
            pnlSummary.Controls.Add(btnPrepareDeployment);
            pnlSummary.Location = new Point(97, 505);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(1807, 384);
            pnlSummary.TabIndex = 4;
            // 
            // rbFilterExclude
            // 
            rbFilterExclude.AutoSize = true;
            rbFilterExclude.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbFilterExclude.ForeColor = Color.Salmon;
            rbFilterExclude.Location = new Point(403, 31);
            rbFilterExclude.Name = "rbFilterExclude";
            rbFilterExclude.Size = new Size(74, 18);
            rbFilterExclude.TabIndex = 15;
            rbFilterExclude.TabStop = true;
            rbFilterExclude.Text = "Exclude";
            rbFilterExclude.UseVisualStyleBackColor = true;
            // 
            // rbFilterInclude
            // 
            rbFilterInclude.AutoSize = true;
            rbFilterInclude.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbFilterInclude.ForeColor = Color.Salmon;
            rbFilterInclude.Location = new Point(403, 13);
            rbFilterInclude.Name = "rbFilterInclude";
            rbFilterInclude.Size = new Size(74, 18);
            rbFilterInclude.TabIndex = 14;
            rbFilterInclude.TabStop = true;
            rbFilterInclude.Text = "Include";
            rbFilterInclude.UseVisualStyleBackColor = true;
            rbFilterInclude.CheckedChanged += rbFilterInclude_CheckedChanged;
            // 
            // pbFilterWarning
            // 
            pbFilterWarning.Image = Properties.Resources.complain;
            pbFilterWarning.Location = new Point(483, 54);
            pbFilterWarning.Name = "pbFilterWarning";
            pbFilterWarning.Size = new Size(32, 24);
            pbFilterWarning.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFilterWarning.TabIndex = 13;
            pbFilterWarning.TabStop = false;
            toolTipPolicy.SetToolTip(pbFilterWarning, "Filters are platform specific. Assignment will fail if the filter does not match the platform for the policy");
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFilter.ForeColor = Color.Salmon;
            lblFilter.Location = new Point(337, 20);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(49, 21);
            lblFilter.TabIndex = 12;
            lblFilter.Text = "Filter";
            // 
            // cbFilter
            // 
            cbFilter.BackColor = Color.FromArgb(46, 51, 73);
            cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilter.FlatStyle = FlatStyle.Flat;
            cbFilter.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFilter.ForeColor = Color.Salmon;
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(337, 55);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(140, 22);
            cbFilter.TabIndex = 12;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
            // 
            // btn_ResetProgressBar
            // 
            btn_ResetProgressBar.BackColor = Color.Salmon;
            btn_ResetProgressBar.FlatStyle = FlatStyle.Flat;
            btn_ResetProgressBar.Font = new Font("Consolas", 12F);
            btn_ResetProgressBar.Location = new Point(1094, 67);
            btn_ResetProgressBar.Name = "btn_ResetProgressBar";
            btn_ResetProgressBar.Size = new Size(193, 39);
            btn_ResetProgressBar.TabIndex = 11;
            btn_ResetProgressBar.Text = "Clear output";
            toolTipPolicy.SetToolTip(btn_ResetProgressBar, "Reset the progress bar in case of errors");
            btn_ResetProgressBar.UseVisualStyleBackColor = false;
            btn_ResetProgressBar.Click += btn_ResetProgressBar_Click;
            // 
            // btnDeployDescription
            // 
            btnDeployDescription.BackColor = Color.Salmon;
            btnDeployDescription.FlatStyle = FlatStyle.Flat;
            btnDeployDescription.Font = new Font("Consolas", 12F);
            btnDeployDescription.Location = new Point(1094, 3);
            btnDeployDescription.Name = "btnDeployDescription";
            btnDeployDescription.Size = new Size(193, 58);
            btnDeployDescription.TabIndex = 10;
            btnDeployDescription.Text = "Add description";
            toolTipPolicy.SetToolTip(btnDeployDescription, "Overwrite each policies descrption property");
            btnDeployDescription.UseVisualStyleBackColor = false;
            btnDeployDescription.Click += btnDeployDescription_Click;
            // 
            // rtbDeploymentSummary
            // 
            rtbDeploymentSummary.BackColor = Color.FromArgb(46, 51, 73);
            rtbDeploymentSummary.BorderStyle = BorderStyle.None;
            rtbDeploymentSummary.ForeColor = Color.Salmon;
            rtbDeploymentSummary.Location = new Point(796, 139);
            rtbDeploymentSummary.Name = "rtbDeploymentSummary";
            rtbDeploymentSummary.Size = new Size(491, 224);
            rtbDeploymentSummary.TabIndex = 9;
            rtbDeploymentSummary.Text = "";
            toolTipPolicy.SetToolTip(rtbDeploymentSummary, "Output from the deployment process");
            rtbDeploymentSummary.WordWrap = false;
            // 
            // cbLookUpAssignment
            // 
            cbLookUpAssignment.AutoSize = true;
            cbLookUpAssignment.ForeColor = Color.Salmon;
            cbLookUpAssignment.Location = new Point(1327, 3);
            cbLookUpAssignment.Name = "cbLookUpAssignment";
            cbLookUpAssignment.Size = new Size(212, 19);
            cbLookUpAssignment.TabIndex = 8;
            cbLookUpAssignment.Text = "Look up policy assignment on click";
            toolTipPolicy.SetToolTip(cbLookUpAssignment, "Enable to look up existing assignments for policies when clicking them");
            cbLookUpAssignment.UseVisualStyleBackColor = true;
            // 
            // pBarDeployProgress
            // 
            pBarDeployProgress.Location = new Point(796, 67);
            pBarDeployProgress.Name = "pBarDeployProgress";
            pBarDeployProgress.Size = new Size(292, 39);
            pBarDeployProgress.TabIndex = 8;
            toolTipPolicy.SetToolTip(pBarDeployProgress, "Because you gotta have a progress bar");
            // 
            // rtbSelectedGroups
            // 
            rtbSelectedGroups.BackColor = Color.FromArgb(46, 51, 73);
            rtbSelectedGroups.BorderStyle = BorderStyle.None;
            rtbSelectedGroups.ForeColor = Color.Salmon;
            rtbSelectedGroups.Location = new Point(421, 139);
            rtbSelectedGroups.Name = "rtbSelectedGroups";
            rtbSelectedGroups.ReadOnly = true;
            rtbSelectedGroups.Size = new Size(347, 224);
            rtbSelectedGroups.TabIndex = 6;
            rtbSelectedGroups.Text = "";
            toolTipPolicy.SetToolTip(rtbSelectedGroups, "The groups that will be used for deployment");
            rtbSelectedGroups.WordWrap = false;
            // 
            // rtbSelectedPolicies
            // 
            rtbSelectedPolicies.BackColor = Color.FromArgb(46, 51, 73);
            rtbSelectedPolicies.BorderStyle = BorderStyle.None;
            rtbSelectedPolicies.ForeColor = Color.Salmon;
            rtbSelectedPolicies.Location = new Point(9, 139);
            rtbSelectedPolicies.Name = "rtbSelectedPolicies";
            rtbSelectedPolicies.ReadOnly = true;
            rtbSelectedPolicies.Size = new Size(386, 224);
            rtbSelectedPolicies.TabIndex = 5;
            rtbSelectedPolicies.Text = "";
            toolTipPolicy.SetToolTip(rtbSelectedPolicies, "The applications that will be used for deployment");
            rtbSelectedPolicies.WordWrap = false;
            // 
            // lblSelectedGroups
            // 
            lblSelectedGroups.AutoSize = true;
            lblSelectedGroups.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSelectedGroups.ForeColor = Color.Salmon;
            lblSelectedGroups.Location = new Point(418, 92);
            lblSelectedGroups.Name = "lblSelectedGroups";
            lblSelectedGroups.Size = new Size(190, 24);
            lblSelectedGroups.TabIndex = 5;
            lblSelectedGroups.Text = "Selected Groups";
            toolTipPolicy.SetToolTip(lblSelectedGroups, "Selected Groups");
            // 
            // btnDeployPolicyAssignment
            // 
            btnDeployPolicyAssignment.BackColor = Color.Salmon;
            btnDeployPolicyAssignment.FlatStyle = FlatStyle.Flat;
            btnDeployPolicyAssignment.Font = new Font("Consolas", 12F);
            btnDeployPolicyAssignment.Location = new Point(796, 3);
            btnDeployPolicyAssignment.Name = "btnDeployPolicyAssignment";
            btnDeployPolicyAssignment.Size = new Size(292, 58);
            btnDeployPolicyAssignment.TabIndex = 5;
            btnDeployPolicyAssignment.Text = "Add assignment";
            toolTipPolicy.SetToolTip(btnDeployPolicyAssignment, "Initiate deployment");
            btnDeployPolicyAssignment.UseVisualStyleBackColor = false;
            btnDeployPolicyAssignment.Click += btnDeployPolicyAssignment_Click;
            // 
            // btnResetDeployment
            // 
            btnResetDeployment.BackColor = Color.Salmon;
            btnResetDeployment.FlatStyle = FlatStyle.Flat;
            btnResetDeployment.Font = new Font("Consolas", 12F);
            btnResetDeployment.Location = new Point(235, 20);
            btnResetDeployment.Name = "btnResetDeployment";
            btnResetDeployment.Size = new Size(96, 58);
            btnResetDeployment.TabIndex = 7;
            btnResetDeployment.Text = "Reset";
            btnResetDeployment.UseVisualStyleBackColor = false;
            btnResetDeployment.Click += btnResetDeployment_Click;
            // 
            // lblSelectedPolicies
            // 
            lblSelectedPolicies.AutoSize = true;
            lblSelectedPolicies.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSelectedPolicies.ForeColor = Color.Salmon;
            lblSelectedPolicies.Location = new Point(9, 92);
            lblSelectedPolicies.Name = "lblSelectedPolicies";
            lblSelectedPolicies.Size = new Size(214, 24);
            lblSelectedPolicies.TabIndex = 4;
            lblSelectedPolicies.Text = "Selected policies";
            toolTipPolicy.SetToolTip(lblSelectedPolicies, "Selected policies");
            // 
            // btnPrepareDeployment
            // 
            btnPrepareDeployment.BackColor = Color.Salmon;
            btnPrepareDeployment.FlatStyle = FlatStyle.Flat;
            btnPrepareDeployment.Font = new Font("Consolas", 12F);
            btnPrepareDeployment.Location = new Point(9, 20);
            btnPrepareDeployment.Name = "btnPrepareDeployment";
            btnPrepareDeployment.Size = new Size(220, 58);
            btnPrepareDeployment.TabIndex = 6;
            btnPrepareDeployment.Text = "Prepare deployment";
            toolTipPolicy.SetToolTip(btnPrepareDeployment, "Click to prepare selected applications and groups for deployment");
            btnPrepareDeployment.UseVisualStyleBackColor = false;
            btnPrepareDeployment.Click += btnPrepareDeployment_Click;
            // 
            // pnlSearchGroup
            // 
            pnlSearchGroup.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchGroup.Controls.Add(lblSelectGroups);
            pnlSearchGroup.Controls.Add(dtgDisplayGroup);
            pnlSearchGroup.Controls.Add(txtboxSearchGroup);
            pnlSearchGroup.Controls.Add(btnListAllGroups);
            pnlSearchGroup.Controls.Add(btnSearchGroup);
            pnlSearchGroup.Location = new Point(898, 31);
            pnlSearchGroup.Name = "pnlSearchGroup";
            pnlSearchGroup.Size = new Size(643, 468);
            pnlSearchGroup.TabIndex = 9;
            // 
            // lblSelectGroups
            // 
            lblSelectGroups.AutoSize = true;
            lblSelectGroups.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSelectGroups.ForeColor = Color.Salmon;
            lblSelectGroups.Location = new Point(3, 10);
            lblSelectGroups.Name = "lblSelectGroups";
            lblSelectGroups.Size = new Size(82, 24);
            lblSelectGroups.TabIndex = 11;
            lblSelectGroups.Text = "Groups";
            toolTipPolicy.SetToolTip(lblSelectGroups, "Selected policies");
            // 
            // txtboxDescription
            // 
            txtboxDescription.BackColor = Color.FromArgb(46, 51, 73);
            txtboxDescription.BorderStyle = BorderStyle.FixedSingle;
            txtboxDescription.ForeColor = Color.Salmon;
            txtboxDescription.Location = new Point(6, 54);
            txtboxDescription.Multiline = true;
            txtboxDescription.Name = "txtboxDescription";
            txtboxDescription.Size = new Size(339, 218);
            txtboxDescription.TabIndex = 11;
            toolTipPolicy.SetToolTip(txtboxDescription, "Enter a desired description. Leave blank to not add or change the description field. Existing description will be overwritten");
            txtboxDescription.TextChanged += txtboxDescription_TextChanged;
            // 
            // pbHelpGuide
            // 
            pbHelpGuide.Image = Properties.Resources._121047815016345278514481_48;
            pbHelpGuide.InitialImage = Properties.Resources._121047815016345278514481_48;
            pbHelpGuide.Location = new Point(12, 159);
            pbHelpGuide.Name = "pbHelpGuide";
            pbHelpGuide.Size = new Size(64, 64);
            pbHelpGuide.SizeMode = PictureBoxSizeMode.StretchImage;
            pbHelpGuide.TabIndex = 10;
            pbHelpGuide.TabStop = false;
            pbHelpGuide.Click += pbHelpGuide_Click;
            // 
            // pnlDescription
            // 
            pnlDescription.BorderStyle = BorderStyle.FixedSingle;
            pnlDescription.Controls.Add(txtboxDescription);
            pnlDescription.Controls.Add(label1);
            pnlDescription.Location = new Point(1547, 31);
            pnlDescription.Name = "pnlDescription";
            pnlDescription.Size = new Size(357, 468);
            pnlDescription.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Salmon;
            label1.Location = new Point(3, 14);
            label1.Name = "label1";
            label1.Size = new Size(98, 21);
            label1.TabIndex = 3;
            label1.Text = "Description";
            // 
            // pbViewAssignments
            // 
            pbViewAssignments.Image = Properties.Resources._3271932871579761116_48;
            pbViewAssignments.InitialImage = Properties.Resources._121047815016345278514481_48;
            pbViewAssignments.Location = new Point(12, 89);
            pbViewAssignments.Name = "pbViewAssignments";
            pbViewAssignments.Size = new Size(64, 64);
            pbViewAssignments.SizeMode = PictureBoxSizeMode.StretchImage;
            pbViewAssignments.TabIndex = 11;
            pbViewAssignments.TabStop = false;
            pbViewAssignments.Click += pbViewAssignments_Click;
            // 
            // lblHeaderAppForm
            // 
            lblHeaderAppForm.AutoSize = true;
            lblHeaderAppForm.Font = new Font("Consolas", 18F, FontStyle.Bold);
            lblHeaderAppForm.ForeColor = Color.Salmon;
            lblHeaderAppForm.Location = new Point(97, 0);
            lblHeaderAppForm.Name = "lblHeaderAppForm";
            lblHeaderAppForm.Size = new Size(207, 28);
            lblHeaderAppForm.TabIndex = 21;
            lblHeaderAppForm.Text = "Deploy policies";
            // 
            // Policy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1919, 791);
            Controls.Add(lblHeaderAppForm);
            Controls.Add(pbViewAssignments);
            Controls.Add(pnlDescription);
            Controls.Add(pbHelpGuide);
            Controls.Add(pnlSearchGroup);
            Controls.Add(pnlSummary);
            Controls.Add(pnlSearchPolicy);
            Controls.Add(pbHome);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Policy";
            Load += Policy_Load;
            ((System.ComponentModel.ISupportInitialize)pbHome).EndInit();
            pnlSearchPolicy.ResumeLayout(false);
            pnlSearchPolicy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayPolicy).EndInit();
            cmsDisplayPolicy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).EndInit();
            cmsDisplayGroup.ResumeLayout(false);
            pnlAssignedTo.ResumeLayout(false);
            pnlAssignedTo.PerformLayout();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbFilterWarning).EndInit();
            pnlSearchGroup.ResumeLayout(false);
            pnlSearchGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbHelpGuide).EndInit();
            pnlDescription.ResumeLayout(false);
            pnlDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbViewAssignments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbHome;
        private Panel pnlSearchPolicy;
        private ComboBox cbPolicyType;
        private TextBox txtboxSearchPolicy;
        private Button btnListAllPolicy;
        private Button btnSearchPolicy;
        private DataGridView dtgDisplayPolicy;
        private DataGridView dtgDisplayGroup;
        private Button btnListAllGroups;
        private Button btnSearchGroup;
        private TextBox txtboxSearchGroup;
        private RichTextBox rtbAssignmentPreview;
        private Panel pnlAssignedTo;
        private Label lblAssignmentPreview;
        private Panel pnlSummary;
        private Label lblSelectedGroups;
        private Label lblSelectedPolicies;
        private RichTextBox rtbSelectedGroups;
        private RichTextBox rtbSelectedPolicies;
        private Button btnDeployPolicyAssignment;
        private Button btnPrepareDeployment;
        private Button btnResetDeployment;
        private CheckBox cbLookUpAssignment;
        private Panel pnlSearchGroup;
        private ProgressBar pBarDeployProgress;
        private RichTextBox rtbDeploymentSummary;
        private ToolTip toolTipPolicy;
        private Label lblSelectApps;
        private Label lblSelectGroups;
        private PictureBox pbHelpGuide;
        private Button btnDeployDescription;
        private Panel pnlDescription;
        private TextBox txtboxDescription;
        private Label label1;
        private Label lblAssignedTo;
        private PictureBox pbViewAssignments;
        private Label lblHeaderAppForm;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn MemberCount;
        private DataGridViewTextBoxColumn groupType;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Button btn_ResetProgressBar;
        private ContextMenuStrip cmsDisplayPolicy;
        private ToolStripMenuItem copyCellContentToolStripMenuItem;
        private ContextMenuStrip cmsDisplayGroup;
        private ToolStripMenuItem copyCellContentToolStripMenuItem1;
        private DataGridViewTextBoxColumn PolicyName;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Platform;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Assigned;
        private Label lblFilter;
        private ComboBox cbFilter;
        private PictureBox pbFilterWarning;
        private RadioButton rbFilterExclude;
        private RadioButton rbFilterInclude;
    }
}