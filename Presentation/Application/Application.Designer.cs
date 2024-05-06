namespace IntuneAssignments
{
    partial class Application
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Application));
            panelTenantInfo = new Panel();
            SignIn = new Button();
            lblTenantID = new Label();
            lblTenantInfo = new Label();
            lblSignedInUser = new Label();
            pbView = new PictureBox();
            pictureBox1 = new PictureBox();
            clbAppAssignments = new CheckedListBox();
            cmbRightClickAppAssignment = new ContextMenuStrip(components);
            cmsRemoveSelectedAppAssignments = new ToolStripMenuItem();
            cmsRemoveAllAppAssignments = new ToolStripMenuItem();
            pnlSearchApp = new Panel();
            lblSelectAppType = new Label();
            cBAppType = new ComboBox();
            dtgDisplayApp = new DataGridView();
            AppName = new DataGridViewTextBoxColumn();
            Platform = new DataGridViewTextBoxColumn();
            AppID = new DataGridViewTextBoxColumn();
            cmsRightClickAppList = new ContextMenuStrip(components);
            addSelectedToolStripMenuItem = new ToolStripMenuItem();
            AddAllToolStripMenuItem = new ToolStripMenuItem();
            txtboxSearchApp = new TextBox();
            btnSearchApp = new Button();
            pnlSelectApps = new Panel();
            btnAllGroups = new Button();
            pnlSearchGroup = new Panel();
            label1 = new Label();
            dtgDisplayGroup = new DataGridView();
            GroupName = new DataGridViewTextBoxColumn();
            GroupMemberCount = new DataGridViewTextBoxColumn();
            GroupType = new DataGridViewTextBoxColumn();
            GroupID = new DataGridViewTextBoxColumn();
            cmsRightClickGroupList = new ContextMenuStrip(components);
            addSelectedGroupsToolStripMenuItem1 = new ToolStripMenuItem();
            addAllGroupsToolStripMenuItem1 = new ToolStripMenuItem();
            btnSearchGroup = new Button();
            txtboxSearchGroup = new TextBox();
            btnListAllGroups = new Button();
            pnlSelectGroup = new Panel();
            clbGroupAssignment = new CheckedListBox();
            cmsRightClickGroupAssignment = new ContextMenuStrip(components);
            cmsRemoveSelectedGroupAssignments = new ToolStripMenuItem();
            cmsRemoveAllGroupAssignments = new ToolStripMenuItem();
            pnlIntent = new Panel();
            txtboxAppDescription = new TextBox();
            lblDescription = new Label();
            lblIntentChoice = new Label();
            rbtnUninstall = new RadioButton();
            rbtnRequired = new RadioButton();
            rbtnAvailable = new RadioButton();
            btnSummarize = new Button();
            btnReset = new Button();
            panelSummary = new Panel();
            btn_ClearProgressBar = new Button();
            btnDeployDescription = new Button();
            lblSummary = new Label();
            rtbDeploymentSummary = new RichTextBox();
            progressBar1 = new ProgressBar();
            btnDeployAssignments = new Button();
            rtbSummarizeIntent = new RichTextBox();
            rtbSummarizeGroups = new RichTextBox();
            rtbSummarizeApps = new RichTextBox();
            lblSummarizeIntent = new Label();
            lblSummarizeGroups = new Label();
            lblSummarizeApps = new Label();
            sideBarTimer = new System.Windows.Forms.Timer(components);
            menuPanel = new Panel();
            pictureBox3 = new PictureBox();
            mainFormToolTip = new ToolTip(components);
            lblHeaderAppForm = new Label();
            panelTenantInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            cmbRightClickAppAssignment.SuspendLayout();
            pnlSearchApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayApp).BeginInit();
            cmsRightClickAppList.SuspendLayout();
            pnlSelectApps.SuspendLayout();
            pnlSearchGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).BeginInit();
            cmsRightClickGroupList.SuspendLayout();
            pnlSelectGroup.SuspendLayout();
            cmsRightClickGroupAssignment.SuspendLayout();
            pnlIntent.SuspendLayout();
            panelSummary.SuspendLayout();
            menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // panelTenantInfo
            // 
            panelTenantInfo.Controls.Add(SignIn);
            panelTenantInfo.Controls.Add(lblTenantID);
            panelTenantInfo.Controls.Add(lblTenantInfo);
            panelTenantInfo.Controls.Add(lblSignedInUser);
            panelTenantInfo.Location = new Point(119, 20);
            panelTenantInfo.Name = "panelTenantInfo";
            panelTenantInfo.Size = new Size(288, 165);
            panelTenantInfo.TabIndex = 0;
            // 
            // SignIn
            // 
            SignIn.BackColor = Color.Salmon;
            SignIn.FlatStyle = FlatStyle.Popup;
            SignIn.Font = new Font("Consolas", 12F);
            SignIn.Location = new Point(12, 103);
            SignIn.Name = "SignIn";
            SignIn.Size = new Size(126, 41);
            SignIn.TabIndex = 1;
            SignIn.Text = "Sign in";
            SignIn.UseVisualStyleBackColor = false;
            SignIn.Click += button2_Click;
            // 
            // lblTenantID
            // 
            lblTenantID.AutoSize = true;
            lblTenantID.ForeColor = Color.Salmon;
            lblTenantID.Location = new Point(12, 74);
            lblTenantID.Name = "lblTenantID";
            lblTenantID.Size = new Size(62, 15);
            lblTenantID.TabIndex = 3;
            lblTenantID.Text = "TENANTID";
            // 
            // lblTenantInfo
            // 
            lblTenantInfo.AutoSize = true;
            lblTenantInfo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblTenantInfo.ForeColor = Color.Salmon;
            lblTenantInfo.Location = new Point(12, 13);
            lblTenantInfo.Name = "lblTenantInfo";
            lblTenantInfo.Size = new Size(113, 25);
            lblTenantInfo.TabIndex = 2;
            lblTenantInfo.Text = "Tenant info";
            // 
            // lblSignedInUser
            // 
            lblSignedInUser.AutoSize = true;
            lblSignedInUser.ForeColor = Color.Salmon;
            lblSignedInUser.Location = new Point(12, 48);
            lblSignedInUser.Name = "lblSignedInUser";
            lblSignedInUser.Size = new Size(92, 15);
            lblSignedInUser.TabIndex = 1;
            lblSignedInUser.Text = "SIGNED IN USER";
            // 
            // pbView
            // 
            pbView.Image = Properties.Resources._3271932871579761116_48;
            pbView.Location = new Point(11, 84);
            pbView.Name = "pbView";
            pbView.Size = new Size(64, 64);
            pbView.SizeMode = PictureBoxSizeMode.StretchImage;
            pbView.TabIndex = 17;
            pbView.TabStop = false;
            mainFormToolTip.SetToolTip(pbView, "View app assignments");
            pbView.Click += pbView_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._15536420761558096328_48;
            pictureBox1.Location = new Point(11, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            mainFormToolTip.SetToolTip(pictureBox1, "Home");
            pictureBox1.Click += pictureBox1_Click;
            // 
            // clbAppAssignments
            // 
            clbAppAssignments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clbAppAssignments.BackColor = Color.FromArgb(46, 51, 73);
            clbAppAssignments.BorderStyle = BorderStyle.None;
            clbAppAssignments.CheckOnClick = true;
            clbAppAssignments.ContextMenuStrip = cmbRightClickAppAssignment;
            clbAppAssignments.Font = new Font("Consolas", 9F);
            clbAppAssignments.ForeColor = Color.Salmon;
            clbAppAssignments.FormattingEnabled = true;
            clbAppAssignments.Location = new Point(12, 13);
            clbAppAssignments.Name = "clbAppAssignments";
            clbAppAssignments.Size = new Size(188, 255);
            clbAppAssignments.TabIndex = 0;
            mainFormToolTip.SetToolTip(clbAppAssignments, "All apps that you want to deploy");
            clbAppAssignments.MouseClick += clbAppAssignments_MouseClick;
            // 
            // cmbRightClickAppAssignment
            // 
            cmbRightClickAppAssignment.Items.AddRange(new ToolStripItem[] { cmsRemoveSelectedAppAssignments, cmsRemoveAllAppAssignments });
            cmbRightClickAppAssignment.Name = "cmbRightClickApp";
            cmbRightClickAppAssignment.Size = new Size(164, 48);
            // 
            // cmsRemoveSelectedAppAssignments
            // 
            cmsRemoveSelectedAppAssignments.Name = "cmsRemoveSelectedAppAssignments";
            cmsRemoveSelectedAppAssignments.Size = new Size(163, 22);
            cmsRemoveSelectedAppAssignments.Text = "Remove selected";
            cmsRemoveSelectedAppAssignments.Click += cmsRemoveSelectedAppAssignments_Click;
            // 
            // cmsRemoveAllAppAssignments
            // 
            cmsRemoveAllAppAssignments.Name = "cmsRemoveAllAppAssignments";
            cmsRemoveAllAppAssignments.Size = new Size(163, 22);
            cmsRemoveAllAppAssignments.Text = "Remove all";
            cmsRemoveAllAppAssignments.Click += cmsRemoveAllAppAssignments_Click;
            // 
            // pnlSearchApp
            // 
            pnlSearchApp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlSearchApp.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchApp.Controls.Add(lblSelectAppType);
            pnlSearchApp.Controls.Add(cBAppType);
            pnlSearchApp.Controls.Add(dtgDisplayApp);
            pnlSearchApp.Controls.Add(txtboxSearchApp);
            pnlSearchApp.Controls.Add(btnSearchApp);
            pnlSearchApp.Controls.Add(pnlSelectApps);
            pnlSearchApp.Controls.Add(btnAllGroups);
            pnlSearchApp.Location = new Point(108, 46);
            pnlSearchApp.Name = "pnlSearchApp";
            pnlSearchApp.Size = new Size(754, 535);
            pnlSearchApp.TabIndex = 9;
            // 
            // lblSelectAppType
            // 
            lblSelectAppType.AutoSize = true;
            lblSelectAppType.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSelectAppType.ForeColor = Color.Salmon;
            lblSelectAppType.Location = new Point(3, 15);
            lblSelectAppType.Name = "lblSelectAppType";
            lblSelectAppType.Size = new Size(154, 24);
            lblSelectAppType.TabIndex = 19;
            lblSelectAppType.Text = "Applications";
            mainFormToolTip.SetToolTip(lblSelectAppType, "Platform");
            // 
            // cBAppType
            // 
            cBAppType.BackColor = Color.FromArgb(46, 51, 73);
            cBAppType.DropDownStyle = ComboBoxStyle.DropDownList;
            cBAppType.FlatStyle = FlatStyle.Popup;
            cBAppType.ForeColor = Color.Salmon;
            cBAppType.FormattingEnabled = true;
            cBAppType.Items.AddRange(new object[] { "Windows", "Android", "iOS", "macOS", "All platforms" });
            cBAppType.Location = new Point(3, 76);
            cBAppType.Name = "cBAppType";
            cBAppType.Size = new Size(185, 23);
            cBAppType.TabIndex = 19;
            mainFormToolTip.SetToolTip(cBAppType, "Filter based on platform");
            // 
            // dtgDisplayApp
            // 
            dtgDisplayApp.AllowUserToAddRows = false;
            dtgDisplayApp.AllowUserToDeleteRows = false;
            dtgDisplayApp.AllowUserToResizeRows = false;
            dtgDisplayApp.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgDisplayApp.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtgDisplayApp.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Salmon;
            dataGridViewCellStyle1.Font = new Font("Consolas", 12F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgDisplayApp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgDisplayApp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayApp.Columns.AddRange(new DataGridViewColumn[] { AppName, Platform, AppID });
            dtgDisplayApp.ContextMenuStrip = cmsRightClickAppList;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.Salmon;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgDisplayApp.DefaultCellStyle = dataGridViewCellStyle2;
            dtgDisplayApp.EnableHeadersVisualStyles = false;
            dtgDisplayApp.GridColor = Color.Salmon;
            dtgDisplayApp.Location = new Point(3, 135);
            dtgDisplayApp.Name = "dtgDisplayApp";
            dtgDisplayApp.ReadOnly = true;
            dtgDisplayApp.RowHeadersVisible = false;
            dtgDisplayApp.RowHeadersWidth = 51;
            dtgDisplayApp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDisplayApp.Size = new Size(517, 324);
            dtgDisplayApp.TabIndex = 10;
            mainFormToolTip.SetToolTip(dtgDisplayApp, "Double click an app to prepare it for deployment");
            dtgDisplayApp.CellDoubleClick += dtgDisplayApp_CellDoubleClick;
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
            // cmsRightClickAppList
            // 
            cmsRightClickAppList.Items.AddRange(new ToolStripItem[] { addSelectedToolStripMenuItem, AddAllToolStripMenuItem });
            cmsRightClickAppList.Name = "contextMenuStrip1";
            cmsRightClickAppList.Size = new Size(143, 48);
            // 
            // addSelectedToolStripMenuItem
            // 
            addSelectedToolStripMenuItem.Name = "addSelectedToolStripMenuItem";
            addSelectedToolStripMenuItem.Size = new Size(142, 22);
            addSelectedToolStripMenuItem.Text = "Add selected";
            addSelectedToolStripMenuItem.Click += addSelectedToolStripMenuItem_Click;
            // 
            // AddAllToolStripMenuItem
            // 
            AddAllToolStripMenuItem.Name = "AddAllToolStripMenuItem";
            AddAllToolStripMenuItem.Size = new Size(142, 22);
            AddAllToolStripMenuItem.Text = "Add all";
            AddAllToolStripMenuItem.Click += AddAllToolStripMenuItem_Click;
            // 
            // txtboxSearchApp
            // 
            txtboxSearchApp.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchApp.BorderStyle = BorderStyle.FixedSingle;
            txtboxSearchApp.Font = new Font("Consolas", 12F);
            txtboxSearchApp.ForeColor = Color.Salmon;
            txtboxSearchApp.Location = new Point(194, 74);
            txtboxSearchApp.Name = "txtboxSearchApp";
            txtboxSearchApp.Size = new Size(191, 26);
            txtboxSearchApp.TabIndex = 11;
            txtboxSearchApp.Text = "Enter search here";
            mainFormToolTip.SetToolTip(txtboxSearchApp, "Enter search query here");
            txtboxSearchApp.Click += txtboxSearchApp_Click;
            // 
            // btnSearchApp
            // 
            btnSearchApp.BackColor = Color.Salmon;
            btnSearchApp.FlatStyle = FlatStyle.Popup;
            btnSearchApp.Font = new Font("Consolas", 12F);
            btnSearchApp.Location = new Point(396, 68);
            btnSearchApp.Name = "btnSearchApp";
            btnSearchApp.Size = new Size(124, 30);
            btnSearchApp.TabIndex = 12;
            btnSearchApp.Text = "Search";
            mainFormToolTip.SetToolTip(btnSearchApp, "Search for applications");
            btnSearchApp.UseVisualStyleBackColor = false;
            btnSearchApp.Click += btnSearchApp_Click_1;
            // 
            // pnlSelectApps
            // 
            pnlSelectApps.BorderStyle = BorderStyle.FixedSingle;
            pnlSelectApps.Controls.Add(clbAppAssignments);
            pnlSelectApps.Location = new Point(526, 135);
            pnlSelectApps.Name = "pnlSelectApps";
            pnlSelectApps.Size = new Size(216, 405);
            pnlSelectApps.TabIndex = 10;
            // 
            // btnAllGroups
            // 
            btnAllGroups.BackColor = Color.Salmon;
            btnAllGroups.FlatStyle = FlatStyle.Popup;
            btnAllGroups.Font = new Font("Consolas", 12F);
            btnAllGroups.Location = new Point(526, 68);
            btnAllGroups.Name = "btnAllGroups";
            btnAllGroups.Size = new Size(124, 30);
            btnAllGroups.TabIndex = 9;
            btnAllGroups.Text = "List all apps";
            mainFormToolTip.SetToolTip(btnAllGroups, "List all applications in the tenant");
            btnAllGroups.UseVisualStyleBackColor = false;
            btnAllGroups.Click += btnAllGroups_Click;
            // 
            // pnlSearchGroup
            // 
            pnlSearchGroup.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchGroup.Controls.Add(label1);
            pnlSearchGroup.Controls.Add(dtgDisplayGroup);
            pnlSearchGroup.Controls.Add(btnSearchGroup);
            pnlSearchGroup.Controls.Add(txtboxSearchGroup);
            pnlSearchGroup.Controls.Add(btnListAllGroups);
            pnlSearchGroup.Controls.Add(pnlSelectGroup);
            pnlSearchGroup.Location = new Point(868, 46);
            pnlSearchGroup.Name = "pnlSearchGroup";
            pnlSearchGroup.Size = new Size(675, 414);
            pnlSearchGroup.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            label1.ForeColor = Color.Salmon;
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 20;
            label1.Text = "Groups";
            mainFormToolTip.SetToolTip(label1, "Target");
            // 
            // dtgDisplayGroup
            // 
            dtgDisplayGroup.AllowUserToAddRows = false;
            dtgDisplayGroup.AllowUserToDeleteRows = false;
            dtgDisplayGroup.AllowUserToResizeRows = false;
            dtgDisplayGroup.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgDisplayGroup.CellBorderStyle = DataGridViewCellBorderStyle.None;
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
            dtgDisplayGroup.Columns.AddRange(new DataGridViewColumn[] { GroupName, GroupMemberCount, GroupType, GroupID });
            dtgDisplayGroup.ContextMenuStrip = cmsRightClickGroupList;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = Color.Salmon;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dtgDisplayGroup.DefaultCellStyle = dataGridViewCellStyle4;
            dtgDisplayGroup.EnableHeadersVisualStyles = false;
            dtgDisplayGroup.Location = new Point(3, 135);
            dtgDisplayGroup.Name = "dtgDisplayGroup";
            dtgDisplayGroup.ReadOnly = true;
            dtgDisplayGroup.RowHeadersVisible = false;
            dtgDisplayGroup.RowHeadersWidth = 51;
            dtgDisplayGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDisplayGroup.Size = new Size(410, 306);
            dtgDisplayGroup.TabIndex = 14;
            mainFormToolTip.SetToolTip(dtgDisplayGroup, "Double click a group to prepare it for deployment");
            dtgDisplayGroup.CellDoubleClick += dtgDisplayGroup_CellDoubleClick;
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
            // cmsRightClickGroupList
            // 
            cmsRightClickGroupList.Items.AddRange(new ToolStripItem[] { addSelectedGroupsToolStripMenuItem1, addAllGroupsToolStripMenuItem1 });
            cmsRightClickGroupList.Name = "cmsRightClickGroupList";
            cmsRightClickGroupList.Size = new Size(143, 48);
            // 
            // addSelectedGroupsToolStripMenuItem1
            // 
            addSelectedGroupsToolStripMenuItem1.Name = "addSelectedGroupsToolStripMenuItem1";
            addSelectedGroupsToolStripMenuItem1.Size = new Size(142, 22);
            addSelectedGroupsToolStripMenuItem1.Text = "Add selected";
            addSelectedGroupsToolStripMenuItem1.Click += addSelectedGroupsToolStripMenuItem1_Click;
            // 
            // addAllGroupsToolStripMenuItem1
            // 
            addAllGroupsToolStripMenuItem1.Name = "addAllGroupsToolStripMenuItem1";
            addAllGroupsToolStripMenuItem1.Size = new Size(142, 22);
            addAllGroupsToolStripMenuItem1.Text = "Add all";
            addAllGroupsToolStripMenuItem1.Click += addAllGroupsToolStripMenuItem1_Click;
            // 
            // btnSearchGroup
            // 
            btnSearchGroup.BackColor = Color.Salmon;
            btnSearchGroup.FlatStyle = FlatStyle.Popup;
            btnSearchGroup.Font = new Font("Consolas", 12F);
            btnSearchGroup.Location = new Point(205, 69);
            btnSearchGroup.Name = "btnSearchGroup";
            btnSearchGroup.Size = new Size(124, 30);
            btnSearchGroup.TabIndex = 15;
            btnSearchGroup.Text = "Search";
            mainFormToolTip.SetToolTip(btnSearchGroup, "Search for groups");
            btnSearchGroup.UseVisualStyleBackColor = false;
            btnSearchGroup.Click += btnSearchGroup_Click;
            // 
            // txtboxSearchGroup
            // 
            txtboxSearchGroup.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchGroup.BorderStyle = BorderStyle.FixedSingle;
            txtboxSearchGroup.Font = new Font("Consolas", 12F);
            txtboxSearchGroup.ForeColor = Color.Salmon;
            txtboxSearchGroup.Location = new Point(8, 73);
            txtboxSearchGroup.Name = "txtboxSearchGroup";
            txtboxSearchGroup.Size = new Size(191, 26);
            txtboxSearchGroup.TabIndex = 13;
            txtboxSearchGroup.Text = "Enter search here";
            mainFormToolTip.SetToolTip(txtboxSearchGroup, "Enter search query here");
            txtboxSearchGroup.Click += txtboxSearchGroup_Click;
            // 
            // btnListAllGroups
            // 
            btnListAllGroups.BackColor = Color.Salmon;
            btnListAllGroups.FlatStyle = FlatStyle.Popup;
            btnListAllGroups.Font = new Font("Consolas", 12F);
            btnListAllGroups.Location = new Point(335, 68);
            btnListAllGroups.Name = "btnListAllGroups";
            btnListAllGroups.Size = new Size(124, 32);
            btnListAllGroups.TabIndex = 13;
            btnListAllGroups.Text = "List all groups";
            mainFormToolTip.SetToolTip(btnListAllGroups, "List all groups");
            btnListAllGroups.UseVisualStyleBackColor = false;
            btnListAllGroups.Click += btnListAllGroups_Click;
            // 
            // pnlSelectGroup
            // 
            pnlSelectGroup.BorderStyle = BorderStyle.FixedSingle;
            pnlSelectGroup.Controls.Add(clbGroupAssignment);
            pnlSelectGroup.Location = new Point(419, 135);
            pnlSelectGroup.Name = "pnlSelectGroup";
            pnlSelectGroup.Size = new Size(246, 312);
            pnlSelectGroup.TabIndex = 11;
            // 
            // clbGroupAssignment
            // 
            clbGroupAssignment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clbGroupAssignment.BackColor = Color.FromArgb(46, 51, 73);
            clbGroupAssignment.BorderStyle = BorderStyle.None;
            clbGroupAssignment.CheckOnClick = true;
            clbGroupAssignment.ContextMenuStrip = cmsRightClickGroupAssignment;
            clbGroupAssignment.Font = new Font("Consolas", 9F);
            clbGroupAssignment.ForeColor = Color.Salmon;
            clbGroupAssignment.FormattingEnabled = true;
            clbGroupAssignment.Location = new Point(3, 13);
            clbGroupAssignment.Name = "clbGroupAssignment";
            clbGroupAssignment.Size = new Size(227, 187);
            clbGroupAssignment.TabIndex = 0;
            mainFormToolTip.SetToolTip(clbGroupAssignment, "All groups that you want to deploy to");
            clbGroupAssignment.MouseClick += clbGroupAssignment_MouseClick;
            // 
            // cmsRightClickGroupAssignment
            // 
            cmsRightClickGroupAssignment.Items.AddRange(new ToolStripItem[] { cmsRemoveSelectedGroupAssignments, cmsRemoveAllGroupAssignments });
            cmsRightClickGroupAssignment.Name = "cmsRemove";
            cmsRightClickGroupAssignment.Size = new Size(164, 48);
            // 
            // cmsRemoveSelectedGroupAssignments
            // 
            cmsRemoveSelectedGroupAssignments.Name = "cmsRemoveSelectedGroupAssignments";
            cmsRemoveSelectedGroupAssignments.Size = new Size(163, 22);
            cmsRemoveSelectedGroupAssignments.Text = "Remove selected";
            cmsRemoveSelectedGroupAssignments.Click += cmsRemoveSelectedGroupAssignments_Click;
            // 
            // cmsRemoveAllGroupAssignments
            // 
            cmsRemoveAllGroupAssignments.Name = "cmsRemoveAllGroupAssignments";
            cmsRemoveAllGroupAssignments.Size = new Size(163, 22);
            cmsRemoveAllGroupAssignments.Text = "Remove all";
            cmsRemoveAllGroupAssignments.Click += cmsRemoveAllGroupAssignments_Click;
            // 
            // pnlIntent
            // 
            pnlIntent.BorderStyle = BorderStyle.FixedSingle;
            pnlIntent.Controls.Add(txtboxAppDescription);
            pnlIntent.Controls.Add(lblDescription);
            pnlIntent.Controls.Add(lblIntentChoice);
            pnlIntent.Controls.Add(rbtnUninstall);
            pnlIntent.Controls.Add(rbtnRequired);
            pnlIntent.Controls.Add(rbtnAvailable);
            pnlIntent.Location = new Point(1549, 47);
            pnlIntent.Name = "pnlIntent";
            pnlIntent.Size = new Size(317, 414);
            pnlIntent.TabIndex = 12;
            // 
            // txtboxAppDescription
            // 
            txtboxAppDescription.BackColor = Color.FromArgb(46, 51, 73);
            txtboxAppDescription.BorderStyle = BorderStyle.FixedSingle;
            txtboxAppDescription.ForeColor = Color.Salmon;
            txtboxAppDescription.Location = new Point(14, 230);
            txtboxAppDescription.Multiline = true;
            txtboxAppDescription.Name = "txtboxAppDescription";
            txtboxAppDescription.Size = new Size(281, 162);
            txtboxAppDescription.TabIndex = 5;
            mainFormToolTip.SetToolTip(txtboxAppDescription, "Enter a desired description. Leave blank to not add or change the description field. Existing description will be overwritten");
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblDescription.ForeColor = Color.Salmon;
            lblDescription.Location = new Point(14, 203);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(142, 24);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description";
            mainFormToolTip.SetToolTip(lblDescription, "Enter a desired description. Leave blank to not add or change the description field. Existing description will be overwritten");
            // 
            // lblIntentChoice
            // 
            lblIntentChoice.AutoSize = true;
            lblIntentChoice.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblIntentChoice.ForeColor = Color.Salmon;
            lblIntentChoice.Location = new Point(14, 15);
            lblIntentChoice.Name = "lblIntentChoice";
            lblIntentChoice.Size = new Size(82, 24);
            lblIntentChoice.TabIndex = 3;
            lblIntentChoice.Text = "Intent";
            mainFormToolTip.SetToolTip(lblIntentChoice, "Intent");
            // 
            // rbtnUninstall
            // 
            rbtnUninstall.AutoSize = true;
            rbtnUninstall.Font = new Font("Consolas", 12F);
            rbtnUninstall.ForeColor = Color.Salmon;
            rbtnUninstall.Location = new Point(14, 104);
            rbtnUninstall.Name = "rbtnUninstall";
            rbtnUninstall.Size = new Size(108, 23);
            rbtnUninstall.TabIndex = 2;
            rbtnUninstall.TabStop = true;
            rbtnUninstall.Text = "Uninstall";
            mainFormToolTip.SetToolTip(rbtnUninstall, "Choose an intent for the assignment");
            rbtnUninstall.UseVisualStyleBackColor = true;
            rbtnUninstall.Click += rbtnUninstall_Click;
            // 
            // rbtnRequired
            // 
            rbtnRequired.AutoSize = true;
            rbtnRequired.Font = new Font("Consolas", 12F);
            rbtnRequired.ForeColor = Color.Salmon;
            rbtnRequired.Location = new Point(14, 75);
            rbtnRequired.Name = "rbtnRequired";
            rbtnRequired.Size = new Size(99, 23);
            rbtnRequired.TabIndex = 1;
            rbtnRequired.TabStop = true;
            rbtnRequired.Text = "Required";
            mainFormToolTip.SetToolTip(rbtnRequired, "Choose an intent for the assignment");
            rbtnRequired.UseVisualStyleBackColor = true;
            rbtnRequired.Click += rbtnRequired_Click;
            // 
            // rbtnAvailable
            // 
            rbtnAvailable.AutoSize = true;
            rbtnAvailable.Font = new Font("Consolas", 12F);
            rbtnAvailable.ForeColor = Color.Salmon;
            rbtnAvailable.Location = new Point(14, 46);
            rbtnAvailable.Name = "rbtnAvailable";
            rbtnAvailable.Size = new Size(108, 23);
            rbtnAvailable.TabIndex = 0;
            rbtnAvailable.TabStop = true;
            rbtnAvailable.Text = "Available";
            mainFormToolTip.SetToolTip(rbtnAvailable, "Choose an intent for the assignment");
            rbtnAvailable.UseVisualStyleBackColor = true;
            rbtnAvailable.Click += rbtnAvailable_Click;
            // 
            // btnSummarize
            // 
            btnSummarize.BackColor = Color.Salmon;
            btnSummarize.FlatAppearance.BorderColor = Color.White;
            btnSummarize.FlatStyle = FlatStyle.Popup;
            btnSummarize.Font = new Font("Consolas", 12F);
            btnSummarize.Location = new Point(12, 55);
            btnSummarize.Name = "btnSummarize";
            btnSummarize.Size = new Size(215, 38);
            btnSummarize.TabIndex = 14;
            btnSummarize.Text = "Prepare deployment";
            btnSummarize.UseVisualStyleBackColor = false;
            btnSummarize.Click += btnSummarize_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Salmon;
            btnReset.FlatStyle = FlatStyle.Popup;
            btnReset.Font = new Font("Consolas", 12F);
            btnReset.Location = new Point(233, 55);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(131, 38);
            btnReset.TabIndex = 15;
            btnReset.Text = "Reset";
            mainFormToolTip.SetToolTip(btnReset, "Clear all selected apps, groups and intent");
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // panelSummary
            // 
            panelSummary.BorderStyle = BorderStyle.FixedSingle;
            panelSummary.Controls.Add(btn_ClearProgressBar);
            panelSummary.Controls.Add(btnDeployDescription);
            panelSummary.Controls.Add(lblSummary);
            panelSummary.Controls.Add(rtbDeploymentSummary);
            panelSummary.Controls.Add(progressBar1);
            panelSummary.Controls.Add(btnDeployAssignments);
            panelSummary.Controls.Add(rtbSummarizeIntent);
            panelSummary.Controls.Add(rtbSummarizeGroups);
            panelSummary.Controls.Add(btnReset);
            panelSummary.Controls.Add(rtbSummarizeApps);
            panelSummary.Controls.Add(btnSummarize);
            panelSummary.Controls.Add(lblSummarizeIntent);
            panelSummary.Controls.Add(lblSummarizeGroups);
            panelSummary.Controls.Add(lblSummarizeApps);
            panelSummary.Location = new Point(108, 467);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(1739, 426);
            panelSummary.TabIndex = 16;
            // 
            // btn_ClearProgressBar
            // 
            btn_ClearProgressBar.BackColor = Color.Salmon;
            btn_ClearProgressBar.FlatAppearance.BorderSize = 0;
            btn_ClearProgressBar.FlatStyle = FlatStyle.Popup;
            btn_ClearProgressBar.Font = new Font("Consolas", 12F);
            btn_ClearProgressBar.ForeColor = SystemColors.ControlText;
            btn_ClearProgressBar.Location = new Point(1259, 67);
            btn_ClearProgressBar.Name = "btn_ClearProgressBar";
            btn_ClearProgressBar.Size = new Size(156, 28);
            btn_ClearProgressBar.TabIndex = 22;
            btn_ClearProgressBar.Text = "Clear output";
            mainFormToolTip.SetToolTip(btn_ClearProgressBar, "Reset the progress bar in case of errors");
            btn_ClearProgressBar.UseVisualStyleBackColor = false;
            btn_ClearProgressBar.Click += btn_ClearProgressBar_Click;
            // 
            // btnDeployDescription
            // 
            btnDeployDescription.BackColor = Color.Salmon;
            btnDeployDescription.FlatAppearance.BorderSize = 0;
            btnDeployDescription.FlatStyle = FlatStyle.Popup;
            btnDeployDescription.Font = new Font("Consolas", 12F);
            btnDeployDescription.ForeColor = SystemColors.ControlText;
            btnDeployDescription.Location = new Point(1259, 22);
            btnDeployDescription.Name = "btnDeployDescription";
            btnDeployDescription.Size = new Size(156, 39);
            btnDeployDescription.TabIndex = 21;
            btnDeployDescription.Text = "Add description";
            mainFormToolTip.SetToolTip(btnDeployDescription, "Overwrite each apps description with your own");
            btnDeployDescription.UseVisualStyleBackColor = false;
            btnDeployDescription.Click += btnDeployDescription_Click;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSummary.ForeColor = Color.Salmon;
            lblSummary.Location = new Point(12, 10);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(94, 24);
            lblSummary.TabIndex = 20;
            lblSummary.Text = "Summary";
            // 
            // rtbDeploymentSummary
            // 
            rtbDeploymentSummary.BackColor = Color.FromArgb(46, 51, 73);
            rtbDeploymentSummary.BorderStyle = BorderStyle.None;
            rtbDeploymentSummary.ForeColor = Color.Salmon;
            rtbDeploymentSummary.Location = new Point(961, 106);
            rtbDeploymentSummary.Name = "rtbDeploymentSummary";
            rtbDeploymentSummary.Size = new Size(796, 294);
            rtbDeploymentSummary.TabIndex = 20;
            rtbDeploymentSummary.Text = "";
            mainFormToolTip.SetToolTip(rtbDeploymentSummary, "Output from the deployment process");
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(961, 67);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(292, 28);
            progressBar1.TabIndex = 17;
            mainFormToolTip.SetToolTip(progressBar1, "Because you gotta have a progress bar");
            // 
            // btnDeployAssignments
            // 
            btnDeployAssignments.BackColor = Color.Salmon;
            btnDeployAssignments.FlatAppearance.BorderSize = 0;
            btnDeployAssignments.FlatStyle = FlatStyle.Popup;
            btnDeployAssignments.Font = new Font("Consolas", 12F);
            btnDeployAssignments.ForeColor = SystemColors.ControlText;
            btnDeployAssignments.Location = new Point(961, 22);
            btnDeployAssignments.Name = "btnDeployAssignments";
            btnDeployAssignments.Size = new Size(292, 39);
            btnDeployAssignments.TabIndex = 17;
            btnDeployAssignments.Text = "Add assignments";
            mainFormToolTip.SetToolTip(btnDeployAssignments, "Add the selected assignments to the selected apps");
            btnDeployAssignments.UseVisualStyleBackColor = false;
            btnDeployAssignments.Click += btnDeployAssignments_Click;
            // 
            // rtbSummarizeIntent
            // 
            rtbSummarizeIntent.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummarizeIntent.BorderStyle = BorderStyle.None;
            rtbSummarizeIntent.ForeColor = Color.Salmon;
            rtbSummarizeIntent.Location = new Point(799, 143);
            rtbSummarizeIntent.Name = "rtbSummarizeIntent";
            rtbSummarizeIntent.Size = new Size(156, 26);
            rtbSummarizeIntent.TabIndex = 19;
            rtbSummarizeIntent.Text = "";
            mainFormToolTip.SetToolTip(rtbSummarizeIntent, "The chosen intent");
            // 
            // rtbSummarizeGroups
            // 
            rtbSummarizeGroups.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummarizeGroups.BorderStyle = BorderStyle.None;
            rtbSummarizeGroups.ForeColor = Color.Salmon;
            rtbSummarizeGroups.Location = new Point(446, 143);
            rtbSummarizeGroups.Name = "rtbSummarizeGroups";
            rtbSummarizeGroups.Size = new Size(348, 277);
            rtbSummarizeGroups.TabIndex = 18;
            rtbSummarizeGroups.Text = "";
            mainFormToolTip.SetToolTip(rtbSummarizeGroups, "All selected groups");
            // 
            // rtbSummarizeApps
            // 
            rtbSummarizeApps.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummarizeApps.BorderStyle = BorderStyle.None;
            rtbSummarizeApps.ForeColor = Color.Salmon;
            rtbSummarizeApps.Location = new Point(12, 143);
            rtbSummarizeApps.Name = "rtbSummarizeApps";
            rtbSummarizeApps.Size = new Size(425, 277);
            rtbSummarizeApps.TabIndex = 17;
            rtbSummarizeApps.Text = "";
            mainFormToolTip.SetToolTip(rtbSummarizeApps, "All selected applications");
            // 
            // lblSummarizeIntent
            // 
            lblSummarizeIntent.AutoSize = true;
            lblSummarizeIntent.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblSummarizeIntent.ForeColor = Color.Salmon;
            lblSummarizeIntent.Location = new Point(799, 106);
            lblSummarizeIntent.Name = "lblSummarizeIntent";
            lblSummarizeIntent.Size = new Size(63, 19);
            lblSummarizeIntent.TabIndex = 2;
            lblSummarizeIntent.Text = "Intent";
            mainFormToolTip.SetToolTip(lblSummarizeIntent, "Intent");
            // 
            // lblSummarizeGroups
            // 
            lblSummarizeGroups.AutoSize = true;
            lblSummarizeGroups.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblSummarizeGroups.ForeColor = Color.Salmon;
            lblSummarizeGroups.Location = new Point(446, 106);
            lblSummarizeGroups.Name = "lblSummarizeGroups";
            lblSummarizeGroups.Size = new Size(144, 19);
            lblSummarizeGroups.TabIndex = 1;
            lblSummarizeGroups.Text = "Selected groups";
            mainFormToolTip.SetToolTip(lblSummarizeGroups, "Selected groups");
            // 
            // lblSummarizeApps
            // 
            lblSummarizeApps.AutoSize = true;
            lblSummarizeApps.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblSummarizeApps.ForeColor = Color.Salmon;
            lblSummarizeApps.Location = new Point(12, 106);
            lblSummarizeApps.Name = "lblSummarizeApps";
            lblSummarizeApps.Size = new Size(198, 19);
            lblSummarizeApps.TabIndex = 0;
            lblSummarizeApps.Text = "Selected applications";
            mainFormToolTip.SetToolTip(lblSummarizeApps, "Selected applications");
            // 
            // sideBarTimer
            // 
            sideBarTimer.Interval = 10;
            sideBarTimer.Tick += sideBarTimer_Tick;
            // 
            // menuPanel
            // 
            menuPanel.BorderStyle = BorderStyle.FixedSingle;
            menuPanel.Controls.Add(pictureBox3);
            menuPanel.Controls.Add(pictureBox1);
            menuPanel.Controls.Add(pbView);
            menuPanel.Controls.Add(panelTenantInfo);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Location = new Point(0, 0);
            menuPanel.MaximumSize = new Size(400, 893);
            menuPanel.MinimumSize = new Size(102, 893);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(102, 893);
            menuPanel.TabIndex = 18;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources._121047815016345278514481_48;
            pictureBox3.Location = new Point(11, 154);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(64, 64);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            mainFormToolTip.SetToolTip(pictureBox3, "Help");
            pictureBox3.Click += pictureBox3_Click;
            // 
            // lblHeaderAppForm
            // 
            lblHeaderAppForm.AutoSize = true;
            lblHeaderAppForm.Font = new Font("Consolas", 18F, FontStyle.Bold);
            lblHeaderAppForm.ForeColor = Color.Salmon;
            lblHeaderAppForm.Location = new Point(108, 9);
            lblHeaderAppForm.Name = "lblHeaderAppForm";
            lblHeaderAppForm.Size = new Size(259, 28);
            lblHeaderAppForm.TabIndex = 20;
            lblHeaderAppForm.Text = "Deploy applications";
            mainFormToolTip.SetToolTip(lblHeaderAppForm, "Applications");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1878, 911);
            Controls.Add(lblHeaderAppForm);
            Controls.Add(panelSummary);
            Controls.Add(menuPanel);
            Controls.Add(pnlIntent);
            Controls.Add(pnlSearchGroup);
            Controls.Add(pnlSearchApp);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load;
            panelTenantInfo.ResumeLayout(false);
            panelTenantInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            cmbRightClickAppAssignment.ResumeLayout(false);
            pnlSearchApp.ResumeLayout(false);
            pnlSearchApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayApp).EndInit();
            cmsRightClickAppList.ResumeLayout(false);
            pnlSelectApps.ResumeLayout(false);
            pnlSearchGroup.ResumeLayout(false);
            pnlSearchGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).EndInit();
            cmsRightClickGroupList.ResumeLayout(false);
            pnlSelectGroup.ResumeLayout(false);
            cmsRightClickGroupAssignment.ResumeLayout(false);
            pnlIntent.ResumeLayout(false);
            pnlIntent.PerformLayout();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTenantInfo;
        private Button SignIn;
        private Label lblSignedInUser;
        private Label lblTenantInfo;
        private Label lblTenantID;
        private ContextMenuStrip dtgDisplayAppRightClick;
        private ToolStripMenuItem assignmentsToolStripMenuItem;
        private Panel pnlSearchApp;
        private CheckedListBox clbAppAssignments;
        private DataGridView dtgDisplayApp;
        private TextBox txtboxSearchApp;
        private Button btnSearchApp;
        private Button btnAllGroups;
        private Panel pnlSelectApps;
        private Panel pnlSearchGroup;
        private DataGridView dtgDisplayGroup;
        private Button btnSearchGroup;
        private TextBox txtboxSearchGroup;
        private Button btnListAllGroups;
        private Panel pnlSelectGroup;
        private CheckedListBox clbGroupAssignment;
        private ContextMenuStrip cmsRemoveItems;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem removeAllToolStripMenuItem;
        private ContextMenuStrip cmsRemoveApps;
        private ToolStripMenuItem removeSelectedToolStripMenuItem;
        private ToolStripMenuItem removeAllToolStripMenuItem1;
        private Panel pnlIntent;
        private RadioButton rbtnUninstall;
        private RadioButton rbtnRequired;
        private RadioButton rbtnAvailable;
        private Label lblIntentChoice;
        private PictureBox pictureBox1;
        private Button btnSummarize;
        private Button btnReset;
        private Panel panelSummary;
        private Label lblSummarizeIntent;
        private Label lblSummarizeGroups;
        private Label lblSummarizeApps;
        private RichTextBox rtbSummarizeApps;
        private RichTextBox rtbSummarizeIntent;
        private RichTextBox rtbSummarizeGroups;
        private Button btnDeployAssignments;
        private ProgressBar progressBar1;
        private RichTextBox rtbDeploymentSummary;
        private PictureBox pbView;
        private System.Windows.Forms.Timer sideBarTimer;
        private Panel menuPanel;
        private ComboBox cBAppType;
        private Label lblSelectAppType;
        private Label label1;
        private ToolTip mainFormToolTip;
        private DataGridViewTextBoxColumn AppName;
        private DataGridViewTextBoxColumn Platform;
        private DataGridViewTextBoxColumn AppID;
        private PictureBox pictureBox3;
        private Label lblSummary;
        private Label lblDescription;
        private TextBox txtboxAppDescription;
        private Button btnDeployDescription;
        private Label lblHeaderAppForm;
        private DataGridViewTextBoxColumn GroupName;
        private DataGridViewTextBoxColumn GroupMemberCount;
        private DataGridViewTextBoxColumn GroupType;
        private DataGridViewTextBoxColumn GroupID;
        private Button btn_ClearProgressBar;
        private ToolStripMenuItem addAllSelectedToolStripMenuItem;
        private ContextMenuStrip dtgDisplayGroupRightClick;
        private ToolStripMenuItem addAllToolStripMenuItem;
        private ContextMenuStrip cmsRightClickAppList;
        private ToolStripMenuItem addSelectedToolStripMenuItem;
        private ToolStripMenuItem AddAllToolStripMenuItem;
        private ContextMenuStrip cmsRightClickGroupList;
        private ToolStripMenuItem addSelectedGroupsToolStripMenuItem1;
        private ToolStripMenuItem addAllGroupsToolStripMenuItem1;
        private ContextMenuStrip cmbRightClickAppAssignment;
        private ToolStripMenuItem cmsRemoveSelectedAppAssignments;
        private ToolStripMenuItem cmsRemoveAllAppAssignments;
        private ContextMenuStrip cmsRightClickGroupAssignment;
        private ToolStripMenuItem cmsRemoveSelectedGroupAssignments;
        private ToolStripMenuItem cmsRemoveAllGroupAssignments;
    }
}