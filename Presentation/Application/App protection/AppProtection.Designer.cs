namespace IntuneAssignments.Presentation.Application.App_protection
{
    partial class AppProtection
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
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            pbHome = new PictureBox();
            pnlAppProtectionPolicies = new Panel();
            dtgDisplayAppProtectionPolicies = new DataGridView();
            AppName = new DataGridViewTextBoxColumn();
            Platform = new DataGridViewTextBoxColumn();
            AppID = new DataGridViewTextBoxColumn();
            lblAppProtetion = new Label();
            cBAppType = new ComboBox();
            txtboxSearchApp = new TextBox();
            btnSearchPolicy = new Button();
            btnListAllPolicies = new Button();
            lblHeaderAppProtectionForm = new Label();
            pnlSearchGroup = new Panel();
            lblGroups = new Label();
            dtgDisplayGroup = new DataGridView();
            GroupName = new DataGridViewTextBoxColumn();
            GroupMemberCount = new DataGridViewTextBoxColumn();
            GroupType = new DataGridViewTextBoxColumn();
            GroupID = new DataGridViewTextBoxColumn();
            btnSearchGroup = new Button();
            txtboxSearchGroup = new TextBox();
            btnListAllGroups = new Button();
            pnlSummary = new Panel();
            btn_ResetProgressBar = new Button();
            btnDeployDescription = new Button();
            rtbDeploymentSummary = new RichTextBox();
            cbLookUpAssignment = new CheckBox();
            pBarDeployProgress = new ProgressBar();
            rtbSelectedGroups = new RichTextBox();
            rtbSelectedPolicies = new RichTextBox();
            pnlAssignedTo = new Panel();
            lblAssignedTo = new Label();
            lblAssignmentPreview = new Label();
            rtbAssignmentPreview = new RichTextBox();
            lblSelectedGroups = new Label();
            btnDeployPolicyAssignment = new Button();
            btnResetDeployment = new Button();
            lblSelectedPolicies = new Label();
            btnPrepareDeployment = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pbHome).BeginInit();
            pnlAppProtectionPolicies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayAppProtectionPolicies).BeginInit();
            pnlSearchGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).BeginInit();
            pnlSummary.SuspendLayout();
            pnlAssignedTo.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pbHome
            // 
            pbHome.Image = Properties.Resources.application;
            pbHome.Location = new Point(12, 12);
            pbHome.Name = "pbHome";
            pbHome.Size = new Size(64, 64);
            pbHome.SizeMode = PictureBoxSizeMode.StretchImage;
            pbHome.TabIndex = 19;
            pbHome.TabStop = false;
            pbHome.Click += pbHome_Click;
            // 
            // pnlAppProtectionPolicies
            // 
            pnlAppProtectionPolicies.BorderStyle = BorderStyle.FixedSingle;
            pnlAppProtectionPolicies.Controls.Add(dtgDisplayAppProtectionPolicies);
            pnlAppProtectionPolicies.Controls.Add(lblAppProtetion);
            pnlAppProtectionPolicies.Controls.Add(cBAppType);
            pnlAppProtectionPolicies.Controls.Add(txtboxSearchApp);
            pnlAppProtectionPolicies.Controls.Add(btnSearchPolicy);
            pnlAppProtectionPolicies.Controls.Add(btnListAllPolicies);
            pnlAppProtectionPolicies.Location = new Point(97, 59);
            pnlAppProtectionPolicies.Name = "pnlAppProtectionPolicies";
            pnlAppProtectionPolicies.Size = new Size(621, 401);
            pnlAppProtectionPolicies.TabIndex = 20;
            // 
            // dtgDisplayAppProtectionPolicies
            // 
            dtgDisplayAppProtectionPolicies.AllowUserToAddRows = false;
            dtgDisplayAppProtectionPolicies.AllowUserToDeleteRows = false;
            dtgDisplayAppProtectionPolicies.AllowUserToResizeRows = false;
            dtgDisplayAppProtectionPolicies.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgDisplayAppProtectionPolicies.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtgDisplayAppProtectionPolicies.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.Salmon;
            dataGridViewCellStyle13.Font = new Font("Consolas", 12F);
            dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dtgDisplayAppProtectionPolicies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dtgDisplayAppProtectionPolicies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayAppProtectionPolicies.Columns.AddRange(new DataGridViewColumn[] { AppName, Platform, AppID });
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle14.ForeColor = Color.Salmon;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            dtgDisplayAppProtectionPolicies.DefaultCellStyle = dataGridViewCellStyle14;
            dtgDisplayAppProtectionPolicies.EnableHeadersVisualStyles = false;
            dtgDisplayAppProtectionPolicies.GridColor = Color.Salmon;
            dtgDisplayAppProtectionPolicies.Location = new Point(20, 136);
            dtgDisplayAppProtectionPolicies.Name = "dtgDisplayAppProtectionPolicies";
            dtgDisplayAppProtectionPolicies.ReadOnly = true;
            dtgDisplayAppProtectionPolicies.RowHeadersVisible = false;
            dtgDisplayAppProtectionPolicies.RowHeadersWidth = 51;
            dtgDisplayAppProtectionPolicies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDisplayAppProtectionPolicies.Size = new Size(556, 324);
            dtgDisplayAppProtectionPolicies.TabIndex = 25;
            // 
            // AppName
            // 
            AppName.HeaderText = "App name";
            AppName.MinimumWidth = 6;
            AppName.Name = "AppName";
            AppName.ReadOnly = true;
            AppName.Width = 350;
            // 
            // Platform
            // 
            Platform.HeaderText = "Platform";
            Platform.MinimumWidth = 6;
            Platform.Name = "Platform";
            Platform.ReadOnly = true;
            Platform.Width = 200;
            // 
            // AppID
            // 
            AppID.HeaderText = "ID";
            AppID.MinimumWidth = 6;
            AppID.Name = "AppID";
            AppID.ReadOnly = true;
            AppID.Width = 112;
            // 
            // lblAppProtetion
            // 
            lblAppProtetion.AutoSize = true;
            lblAppProtetion.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblAppProtetion.ForeColor = Color.Salmon;
            lblAppProtetion.Location = new Point(3, 10);
            lblAppProtetion.Name = "lblAppProtetion";
            lblAppProtetion.Size = new Size(286, 24);
            lblAppProtetion.TabIndex = 24;
            lblAppProtetion.Text = "App Protection Policies";
            // 
            // cBAppType
            // 
            cBAppType.BackColor = Color.FromArgb(46, 51, 73);
            cBAppType.DropDownStyle = ComboBoxStyle.DropDownList;
            cBAppType.FlatStyle = FlatStyle.Popup;
            cBAppType.ForeColor = Color.Salmon;
            cBAppType.FormattingEnabled = true;
            cBAppType.Items.AddRange(new object[] { "iOS", "Android", "Windows", "All platforms" });
            cBAppType.Location = new Point(20, 69);
            cBAppType.Name = "cBAppType";
            cBAppType.Size = new Size(138, 23);
            cBAppType.TabIndex = 23;
            // 
            // txtboxSearchApp
            // 
            txtboxSearchApp.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchApp.BorderStyle = BorderStyle.FixedSingle;
            txtboxSearchApp.Font = new Font("Consolas", 12F);
            txtboxSearchApp.ForeColor = Color.Salmon;
            txtboxSearchApp.Location = new Point(164, 66);
            txtboxSearchApp.Name = "txtboxSearchApp";
            txtboxSearchApp.Size = new Size(191, 26);
            txtboxSearchApp.TabIndex = 21;
            txtboxSearchApp.Text = "Enter search here";
            // 
            // btnSearchPolicy
            // 
            btnSearchPolicy.BackColor = Color.Salmon;
            btnSearchPolicy.FlatStyle = FlatStyle.Popup;
            btnSearchPolicy.Font = new Font("Consolas", 12F);
            btnSearchPolicy.Location = new Point(20, 98);
            btnSearchPolicy.Name = "btnSearchPolicy";
            btnSearchPolicy.Size = new Size(138, 32);
            btnSearchPolicy.TabIndex = 22;
            btnSearchPolicy.Text = "Search";
            btnSearchPolicy.UseVisualStyleBackColor = false;
            // 
            // btnListAllPolicies
            // 
            btnListAllPolicies.BackColor = Color.Salmon;
            btnListAllPolicies.FlatStyle = FlatStyle.Popup;
            btnListAllPolicies.Font = new Font("Consolas", 12F);
            btnListAllPolicies.Location = new Point(164, 98);
            btnListAllPolicies.Name = "btnListAllPolicies";
            btnListAllPolicies.Size = new Size(191, 32);
            btnListAllPolicies.TabIndex = 20;
            btnListAllPolicies.Text = "List all apps";
            btnListAllPolicies.UseVisualStyleBackColor = false;
            // 
            // lblHeaderAppProtectionForm
            // 
            lblHeaderAppProtectionForm.AutoSize = true;
            lblHeaderAppProtectionForm.Font = new Font("Consolas", 18F, FontStyle.Bold);
            lblHeaderAppProtectionForm.ForeColor = Color.Salmon;
            lblHeaderAppProtectionForm.Location = new Point(97, 12);
            lblHeaderAppProtectionForm.Name = "lblHeaderAppProtectionForm";
            lblHeaderAppProtectionForm.Size = new Size(402, 28);
            lblHeaderAppProtectionForm.TabIndex = 21;
            lblHeaderAppProtectionForm.Text = "Deploy App Protection policies";
            // 
            // pnlSearchGroup
            // 
            pnlSearchGroup.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchGroup.Controls.Add(lblGroups);
            pnlSearchGroup.Controls.Add(dtgDisplayGroup);
            pnlSearchGroup.Controls.Add(btnSearchGroup);
            pnlSearchGroup.Controls.Add(txtboxSearchGroup);
            pnlSearchGroup.Controls.Add(btnListAllGroups);
            pnlSearchGroup.Location = new Point(724, 59);
            pnlSearchGroup.Name = "pnlSearchGroup";
            pnlSearchGroup.Size = new Size(487, 401);
            pnlSearchGroup.TabIndex = 22;
            // 
            // lblGroups
            // 
            lblGroups.AutoSize = true;
            lblGroups.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblGroups.ForeColor = Color.Salmon;
            lblGroups.Location = new Point(8, 9);
            lblGroups.Name = "lblGroups";
            lblGroups.Size = new Size(82, 24);
            lblGroups.TabIndex = 20;
            lblGroups.Text = "Groups";
            // 
            // dtgDisplayGroup
            // 
            dtgDisplayGroup.AllowUserToAddRows = false;
            dtgDisplayGroup.AllowUserToDeleteRows = false;
            dtgDisplayGroup.AllowUserToResizeRows = false;
            dtgDisplayGroup.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgDisplayGroup.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtgDisplayGroup.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = Color.Salmon;
            dataGridViewCellStyle15.Font = new Font("Consolas", 12F);
            dataGridViewCellStyle15.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            dtgDisplayGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dtgDisplayGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayGroup.Columns.AddRange(new DataGridViewColumn[] { GroupName, GroupMemberCount, GroupType, GroupID });
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle16.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle16.ForeColor = Color.Salmon;
            dataGridViewCellStyle16.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.False;
            dtgDisplayGroup.DefaultCellStyle = dataGridViewCellStyle16;
            dtgDisplayGroup.EnableHeadersVisualStyles = false;
            dtgDisplayGroup.Location = new Point(8, 135);
            dtgDisplayGroup.Name = "dtgDisplayGroup";
            dtgDisplayGroup.ReadOnly = true;
            dtgDisplayGroup.RowHeadersVisible = false;
            dtgDisplayGroup.RowHeadersWidth = 51;
            dtgDisplayGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDisplayGroup.Size = new Size(446, 306);
            dtgDisplayGroup.TabIndex = 14;
            // 
            // GroupName
            // 
            GroupName.HeaderText = "Group name";
            GroupName.MinimumWidth = 6;
            GroupName.Name = "GroupName";
            GroupName.ReadOnly = true;
            GroupName.Width = 200;
            // 
            // GroupMemberCount
            // 
            GroupMemberCount.HeaderText = "Members";
            GroupMemberCount.MinimumWidth = 6;
            GroupMemberCount.Name = "GroupMemberCount";
            GroupMemberCount.ReadOnly = true;
            GroupMemberCount.Width = 125;
            // 
            // GroupType
            // 
            GroupType.HeaderText = "Type";
            GroupType.MinimumWidth = 6;
            GroupType.Name = "GroupType";
            GroupType.ReadOnly = true;
            GroupType.Width = 125;
            // 
            // GroupID
            // 
            GroupID.HeaderText = "ID";
            GroupID.MinimumWidth = 6;
            GroupID.Name = "GroupID";
            GroupID.ReadOnly = true;
            GroupID.Width = 200;
            // 
            // btnSearchGroup
            // 
            btnSearchGroup.BackColor = Color.Salmon;
            btnSearchGroup.FlatStyle = FlatStyle.Popup;
            btnSearchGroup.Font = new Font("Consolas", 12F);
            btnSearchGroup.Location = new Point(8, 99);
            btnSearchGroup.Name = "btnSearchGroup";
            btnSearchGroup.Size = new Size(124, 32);
            btnSearchGroup.TabIndex = 15;
            btnSearchGroup.Text = "Search";
            btnSearchGroup.UseVisualStyleBackColor = false;
            // 
            // txtboxSearchGroup
            // 
            txtboxSearchGroup.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchGroup.BorderStyle = BorderStyle.FixedSingle;
            txtboxSearchGroup.Font = new Font("Consolas", 12F);
            txtboxSearchGroup.ForeColor = Color.Salmon;
            txtboxSearchGroup.Location = new Point(8, 68);
            txtboxSearchGroup.Name = "txtboxSearchGroup";
            txtboxSearchGroup.Size = new Size(254, 26);
            txtboxSearchGroup.TabIndex = 13;
            txtboxSearchGroup.Text = "Enter search here";
            // 
            // btnListAllGroups
            // 
            btnListAllGroups.BackColor = Color.Salmon;
            btnListAllGroups.FlatStyle = FlatStyle.Popup;
            btnListAllGroups.Font = new Font("Consolas", 12F);
            btnListAllGroups.Location = new Point(138, 100);
            btnListAllGroups.Name = "btnListAllGroups";
            btnListAllGroups.Size = new Size(124, 32);
            btnListAllGroups.TabIndex = 13;
            btnListAllGroups.Text = "List all groups";
            btnListAllGroups.UseVisualStyleBackColor = false;
            // 
            // pnlSummary
            // 
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.Controls.Add(panel3);
            pnlSummary.Controls.Add(panel2);
            pnlSummary.Controls.Add(panel1);
            pnlSummary.Controls.Add(btn_ResetProgressBar);
            pnlSummary.Controls.Add(btnDeployDescription);
            pnlSummary.Controls.Add(pBarDeployProgress);
            pnlSummary.Controls.Add(lblSelectedGroups);
            pnlSummary.Controls.Add(btnDeployPolicyAssignment);
            pnlSummary.Controls.Add(btnResetDeployment);
            pnlSummary.Controls.Add(lblSelectedPolicies);
            pnlSummary.Controls.Add(btnPrepareDeployment);
            pnlSummary.Location = new Point(97, 491);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(902, 384);
            pnlSummary.TabIndex = 23;
            // 
            // btn_ResetProgressBar
            // 
            btn_ResetProgressBar.BackColor = Color.Salmon;
            btn_ResetProgressBar.FlatStyle = FlatStyle.Flat;
            btn_ResetProgressBar.Font = new Font("Consolas", 12F);
            btn_ResetProgressBar.Location = new Point(723, 50);
            btn_ResetProgressBar.Name = "btn_ResetProgressBar";
            btn_ResetProgressBar.Size = new Size(166, 39);
            btn_ResetProgressBar.TabIndex = 11;
            btn_ResetProgressBar.Text = "Clear output";
            btn_ResetProgressBar.UseVisualStyleBackColor = false;
            // 
            // btnDeployDescription
            // 
            btnDeployDescription.BackColor = Color.Salmon;
            btnDeployDescription.FlatStyle = FlatStyle.Flat;
            btnDeployDescription.Font = new Font("Consolas", 12F);
            btnDeployDescription.Location = new Point(723, 3);
            btnDeployDescription.Name = "btnDeployDescription";
            btnDeployDescription.Size = new Size(166, 41);
            btnDeployDescription.TabIndex = 10;
            btnDeployDescription.Text = "Add description";
            btnDeployDescription.UseVisualStyleBackColor = false;
            // 
            // rtbDeploymentSummary
            // 
            rtbDeploymentSummary.BackColor = Color.FromArgb(46, 51, 73);
            rtbDeploymentSummary.BorderStyle = BorderStyle.None;
            rtbDeploymentSummary.ForeColor = Color.Salmon;
            rtbDeploymentSummary.Location = new Point(3, 3);
            rtbDeploymentSummary.Name = "rtbDeploymentSummary";
            rtbDeploymentSummary.Size = new Size(376, 243);
            rtbDeploymentSummary.TabIndex = 9;
            rtbDeploymentSummary.Text = "";
            rtbDeploymentSummary.WordWrap = false;
            // 
            // cbLookUpAssignment
            // 
            cbLookUpAssignment.AutoSize = true;
            cbLookUpAssignment.ForeColor = Color.Salmon;
            cbLookUpAssignment.Location = new Point(1005, 491);
            cbLookUpAssignment.Name = "cbLookUpAssignment";
            cbLookUpAssignment.Size = new Size(212, 19);
            cbLookUpAssignment.TabIndex = 8;
            cbLookUpAssignment.Text = "Look up policy assignment on click";
            cbLookUpAssignment.UseVisualStyleBackColor = true;
            // 
            // pBarDeployProgress
            // 
            pBarDeployProgress.Location = new Point(505, 50);
            pBarDeployProgress.Name = "pBarDeployProgress";
            pBarDeployProgress.Size = new Size(212, 39);
            pBarDeployProgress.TabIndex = 8;
            // 
            // rtbSelectedGroups
            // 
            rtbSelectedGroups.BackColor = Color.FromArgb(46, 51, 73);
            rtbSelectedGroups.BorderStyle = BorderStyle.None;
            rtbSelectedGroups.ForeColor = Color.Salmon;
            rtbSelectedGroups.Location = new Point(3, 3);
            rtbSelectedGroups.Name = "rtbSelectedGroups";
            rtbSelectedGroups.Size = new Size(182, 232);
            rtbSelectedGroups.TabIndex = 6;
            rtbSelectedGroups.Text = "";
            rtbSelectedGroups.WordWrap = false;
            // 
            // rtbSelectedPolicies
            // 
            rtbSelectedPolicies.BackColor = Color.FromArgb(46, 51, 73);
            rtbSelectedPolicies.BorderStyle = BorderStyle.None;
            rtbSelectedPolicies.ForeColor = Color.Salmon;
            rtbSelectedPolicies.Location = new Point(3, 3);
            rtbSelectedPolicies.Name = "rtbSelectedPolicies";
            rtbSelectedPolicies.Size = new Size(251, 247);
            rtbSelectedPolicies.TabIndex = 5;
            rtbSelectedPolicies.Text = "";
            rtbSelectedPolicies.WordWrap = false;
            // 
            // pnlAssignedTo
            // 
            pnlAssignedTo.BorderStyle = BorderStyle.FixedSingle;
            pnlAssignedTo.Controls.Add(lblAssignedTo);
            pnlAssignedTo.Controls.Add(lblAssignmentPreview);
            pnlAssignedTo.Controls.Add(rtbAssignmentPreview);
            pnlAssignedTo.Location = new Point(1005, 516);
            pnlAssignedTo.Name = "pnlAssignedTo";
            pnlAssignedTo.Size = new Size(258, 359);
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
            // rtbAssignmentPreview
            // 
            rtbAssignmentPreview.BackColor = Color.FromArgb(46, 51, 73);
            rtbAssignmentPreview.BorderStyle = BorderStyle.None;
            rtbAssignmentPreview.ForeColor = Color.Salmon;
            rtbAssignmentPreview.Location = new Point(10, 78);
            rtbAssignmentPreview.Name = "rtbAssignmentPreview";
            rtbAssignmentPreview.Size = new Size(228, 256);
            rtbAssignmentPreview.TabIndex = 2;
            rtbAssignmentPreview.Text = "";
            // 
            // lblSelectedGroups
            // 
            lblSelectedGroups.AutoSize = true;
            lblSelectedGroups.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSelectedGroups.ForeColor = Color.Salmon;
            lblSelectedGroups.Location = new Point(281, 92);
            lblSelectedGroups.Name = "lblSelectedGroups";
            lblSelectedGroups.Size = new Size(190, 24);
            lblSelectedGroups.TabIndex = 5;
            lblSelectedGroups.Text = "Selected Groups";
            // 
            // btnDeployPolicyAssignment
            // 
            btnDeployPolicyAssignment.BackColor = Color.Salmon;
            btnDeployPolicyAssignment.FlatStyle = FlatStyle.Flat;
            btnDeployPolicyAssignment.Font = new Font("Consolas", 12F);
            btnDeployPolicyAssignment.Location = new Point(505, 3);
            btnDeployPolicyAssignment.Name = "btnDeployPolicyAssignment";
            btnDeployPolicyAssignment.Size = new Size(212, 41);
            btnDeployPolicyAssignment.TabIndex = 5;
            btnDeployPolicyAssignment.Text = "Add assignment";
            btnDeployPolicyAssignment.UseVisualStyleBackColor = false;
            // 
            // btnResetDeployment
            // 
            btnResetDeployment.BackColor = Color.Salmon;
            btnResetDeployment.FlatStyle = FlatStyle.Flat;
            btnResetDeployment.Font = new Font("Consolas", 12F);
            btnResetDeployment.Location = new Point(235, 3);
            btnResetDeployment.Name = "btnResetDeployment";
            btnResetDeployment.Size = new Size(96, 58);
            btnResetDeployment.TabIndex = 7;
            btnResetDeployment.Text = "Reset";
            btnResetDeployment.UseVisualStyleBackColor = false;
            // 
            // lblSelectedPolicies
            // 
            lblSelectedPolicies.AutoSize = true;
            lblSelectedPolicies.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSelectedPolicies.ForeColor = Color.Salmon;
            lblSelectedPolicies.Location = new Point(13, 92);
            lblSelectedPolicies.Name = "lblSelectedPolicies";
            lblSelectedPolicies.Size = new Size(214, 24);
            lblSelectedPolicies.TabIndex = 4;
            lblSelectedPolicies.Text = "Selected policies";
            // 
            // btnPrepareDeployment
            // 
            btnPrepareDeployment.BackColor = Color.Salmon;
            btnPrepareDeployment.FlatStyle = FlatStyle.Flat;
            btnPrepareDeployment.Font = new Font("Consolas", 12F);
            btnPrepareDeployment.Location = new Point(9, 3);
            btnPrepareDeployment.Name = "btnPrepareDeployment";
            btnPrepareDeployment.Size = new Size(220, 58);
            btnPrepareDeployment.TabIndex = 6;
            btnPrepareDeployment.Text = "Prepare deployment";
            btnPrepareDeployment.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(rtbSelectedPolicies);
            panel1.Location = new Point(9, 124);
            panel1.Name = "panel1";
            panel1.Size = new Size(266, 255);
            panel1.TabIndex = 24;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(rtbSelectedGroups);
            panel2.Location = new Point(281, 124);
            panel2.Name = "panel2";
            panel2.Size = new Size(190, 255);
            panel2.TabIndex = 24;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(rtbDeploymentSummary);
            panel3.Location = new Point(505, 124);
            panel3.Name = "panel3";
            panel3.Size = new Size(384, 255);
            panel3.TabIndex = 24;
            // 
            // AppProtection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1288, 892);
            Controls.Add(pnlSummary);
            Controls.Add(pnlSearchGroup);
            Controls.Add(lblHeaderAppProtectionForm);
            Controls.Add(cbLookUpAssignment);
            Controls.Add(pnlAppProtectionPolicies);
            Controls.Add(pbHome);
            Controls.Add(pnlAssignedTo);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "AppProtection";
            Text = "AppProtection";
            ((System.ComponentModel.ISupportInitialize)pbHome).EndInit();
            pnlAppProtectionPolicies.ResumeLayout(false);
            pnlAppProtectionPolicies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayAppProtectionPolicies).EndInit();
            pnlSearchGroup.ResumeLayout(false);
            pnlSearchGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).EndInit();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlAssignedTo.ResumeLayout(false);
            pnlAssignedTo.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbHome;
        private Panel pnlAppProtectionPolicies;
        private Label lblHeaderAppProtectionForm;
        private ComboBox cBAppType;
        private TextBox txtboxSearchApp;
        private Button btnSearchPolicy;
        private Button btnListAllPolicies;
        private Label lblAppProtetion;
        private DataGridView dtgDisplayAppProtectionPolicies;
        private DataGridViewTextBoxColumn AppName;
        private DataGridViewTextBoxColumn Platform;
        private DataGridViewTextBoxColumn AppID;
        private Panel pnlSearchGroup;
        private Label lblGroups;
        private DataGridView dtgDisplayGroup;
        private DataGridViewTextBoxColumn GroupName;
        private DataGridViewTextBoxColumn GroupMemberCount;
        private DataGridViewTextBoxColumn GroupType;
        private DataGridViewTextBoxColumn GroupID;
        private Button btnSearchGroup;
        private TextBox txtboxSearchGroup;
        private Button btnListAllGroups;
        private Panel pnlSummary;
        private Button btn_ResetProgressBar;
        private Button btnDeployDescription;
        private RichTextBox rtbDeploymentSummary;
        private ProgressBar pBarDeployProgress;
        private RichTextBox rtbSelectedGroups;
        private RichTextBox rtbSelectedPolicies;
        private Label lblSelectedGroups;
        private Button btnDeployPolicyAssignment;
        private Button btnResetDeployment;
        private Label lblSelectedPolicies;
        private Button btnPrepareDeployment;
        private CheckBox cbLookUpAssignment;
        private Panel pnlAssignedTo;
        private Label lblAssignedTo;
        private Label lblAssignmentPreview;
        private RichTextBox rtbAssignmentPreview;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
    }
}