namespace IntuneAssignments
{
    partial class Form1
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
            panelTenantInfo = new Panel();
            SignIn = new Button();
            lblTenantID = new Label();
            lblTenantInfo = new Label();
            lblSignedInUser = new Label();
            pbView = new PictureBox();
            pictureBox1 = new PictureBox();
            testBtn = new Button();
            dtgDisplayAppRightClick = new ContextMenuStrip(components);
            assignmentsToolStripMenuItem = new ToolStripMenuItem();
            clbAppAssignments = new CheckedListBox();
            cmsRemoveApps = new ContextMenuStrip(components);
            removeSelectedToolStripMenuItem = new ToolStripMenuItem();
            removeAllToolStripMenuItem1 = new ToolStripMenuItem();
            cmsRemoveItems = new ContextMenuStrip(components);
            removeToolStripMenuItem = new ToolStripMenuItem();
            removeAllToolStripMenuItem = new ToolStripMenuItem();
            pnlSearchApp = new Panel();
            dtgDisplayApp = new DataGridView();
            AppName = new DataGridViewTextBoxColumn();
            Platform = new DataGridViewTextBoxColumn();
            AppID = new DataGridViewTextBoxColumn();
            txtboxSearchApp = new TextBox();
            btnSearchApp = new Button();
            btnAllGroups = new Button();
            pnlSelectApps = new Panel();
            pnlSearchGroup = new Panel();
            dtgDisplayGroup = new DataGridView();
            GroupName = new DataGridViewTextBoxColumn();
            GroupID = new DataGridViewTextBoxColumn();
            btnSearchGroup = new Button();
            txtboxSearchGroup = new TextBox();
            btnListAllGroups = new Button();
            pnlSelectGroup = new Panel();
            clbGroupAssignment = new CheckedListBox();
            pnlIntent = new Panel();
            lblIntentChoice = new Label();
            rbtnUninstall = new RadioButton();
            rbtnRequired = new RadioButton();
            rbtnAvailable = new RadioButton();
            btnSummarize = new Button();
            btnReset = new Button();
            panelSummary = new Panel();
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
            panelTenantInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            dtgDisplayAppRightClick.SuspendLayout();
            cmsRemoveApps.SuspendLayout();
            cmsRemoveItems.SuspendLayout();
            pnlSearchApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayApp).BeginInit();
            pnlSelectApps.SuspendLayout();
            pnlSearchGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).BeginInit();
            pnlSelectGroup.SuspendLayout();
            pnlIntent.SuspendLayout();
            panelSummary.SuspendLayout();
            menuPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelTenantInfo
            // 
            panelTenantInfo.Controls.Add(SignIn);
            panelTenantInfo.Controls.Add(lblTenantID);
            panelTenantInfo.Controls.Add(lblTenantInfo);
            panelTenantInfo.Controls.Add(lblSignedInUser);
            panelTenantInfo.Location = new Point(118, 14);
            panelTenantInfo.Name = "panelTenantInfo";
            panelTenantInfo.Size = new Size(160, 165);
            panelTenantInfo.TabIndex = 0;
            // 
            // SignIn
            // 
            SignIn.Location = new Point(12, 103);
            SignIn.Name = "SignIn";
            SignIn.Size = new Size(126, 41);
            SignIn.TabIndex = 1;
            SignIn.Text = "Sign in";
            SignIn.UseVisualStyleBackColor = true;
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
            lblTenantInfo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
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
            pbView.Location = new Point(11, 27);
            pbView.Name = "pbView";
            pbView.Size = new Size(67, 57);
            pbView.TabIndex = 17;
            pbView.TabStop = false;
            pbView.Click += pbView_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources._15536420761558096328_48;
            pictureBox1.Location = new Point(11, 104);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 54);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // testBtn
            // 
            testBtn.Location = new Point(922, 458);
            testBtn.Name = "testBtn";
            testBtn.Size = new Size(79, 41);
            testBtn.TabIndex = 2;
            testBtn.Text = "Test Button";
            testBtn.UseVisualStyleBackColor = true;
            testBtn.Click += testBtn_Click;
            // 
            // dtgDisplayAppRightClick
            // 
            dtgDisplayAppRightClick.Items.AddRange(new ToolStripItem[] { assignmentsToolStripMenuItem });
            dtgDisplayAppRightClick.Name = "dtgDisplayAppRightClick";
            dtgDisplayAppRightClick.Size = new Size(143, 26);
            // 
            // assignmentsToolStripMenuItem
            // 
            assignmentsToolStripMenuItem.Name = "assignmentsToolStripMenuItem";
            assignmentsToolStripMenuItem.Size = new Size(142, 22);
            assignmentsToolStripMenuItem.Text = "Assignments";
            // 
            // clbAppAssignments
            // 
            clbAppAssignments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clbAppAssignments.BackColor = Color.FromArgb(46, 51, 73);
            clbAppAssignments.BorderStyle = BorderStyle.None;
            clbAppAssignments.CheckOnClick = true;
            clbAppAssignments.ContextMenuStrip = cmsRemoveApps;
            clbAppAssignments.ForeColor = Color.Salmon;
            clbAppAssignments.FormattingEnabled = true;
            clbAppAssignments.Items.AddRange(new object[] { "App 1", "App 2", "App 3" });
            clbAppAssignments.Location = new Point(12, 13);
            clbAppAssignments.Name = "clbAppAssignments";
            clbAppAssignments.Size = new Size(253, 234);
            clbAppAssignments.TabIndex = 0;
            clbAppAssignments.MouseClick += clbAppAssignments_MouseClick;
            // 
            // cmsRemoveApps
            // 
            cmsRemoveApps.Items.AddRange(new ToolStripItem[] { removeSelectedToolStripMenuItem, removeAllToolStripMenuItem1 });
            cmsRemoveApps.Name = "cmsRemoveApps";
            cmsRemoveApps.Size = new Size(164, 48);
            // 
            // removeSelectedToolStripMenuItem
            // 
            removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            removeSelectedToolStripMenuItem.Size = new Size(163, 22);
            removeSelectedToolStripMenuItem.Text = "Remove selected";
            removeSelectedToolStripMenuItem.Click += removeSelectedToolStripMenuItem_Click;
            // 
            // removeAllToolStripMenuItem1
            // 
            removeAllToolStripMenuItem1.Name = "removeAllToolStripMenuItem1";
            removeAllToolStripMenuItem1.Size = new Size(163, 22);
            removeAllToolStripMenuItem1.Text = "Remove all";
            removeAllToolStripMenuItem1.Click += removeAllToolStripMenuItem1_Click;
            // 
            // cmsRemoveItems
            // 
            cmsRemoveItems.Items.AddRange(new ToolStripItem[] { removeToolStripMenuItem, removeAllToolStripMenuItem });
            cmsRemoveItems.Name = "contextMenuStrip1";
            cmsRemoveItems.Size = new Size(164, 48);
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(163, 22);
            removeToolStripMenuItem.Text = "Remove selected";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // removeAllToolStripMenuItem
            // 
            removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            removeAllToolStripMenuItem.Size = new Size(163, 22);
            removeAllToolStripMenuItem.Text = "Remove all";
            removeAllToolStripMenuItem.Click += removeAllToolStripMenuItem_Click;
            // 
            // pnlSearchApp
            // 
            pnlSearchApp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlSearchApp.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchApp.Controls.Add(dtgDisplayApp);
            pnlSearchApp.Controls.Add(txtboxSearchApp);
            pnlSearchApp.Controls.Add(btnSearchApp);
            pnlSearchApp.Controls.Add(btnAllGroups);
            pnlSearchApp.Location = new Point(108, 12);
            pnlSearchApp.Name = "pnlSearchApp";
            pnlSearchApp.Size = new Size(470, 286);
            pnlSearchApp.TabIndex = 9;
            // 
            // dtgDisplayApp
            // 
            dtgDisplayApp.AllowUserToAddRows = false;
            dtgDisplayApp.AllowUserToDeleteRows = false;
            dtgDisplayApp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayApp.Columns.AddRange(new DataGridViewColumn[] { AppName, Platform, AppID });
            dtgDisplayApp.ContextMenuStrip = dtgDisplayAppRightClick;
            dtgDisplayApp.Location = new Point(19, 42);
            dtgDisplayApp.Name = "dtgDisplayApp";
            dtgDisplayApp.RowTemplate.Height = 25;
            dtgDisplayApp.Size = new Size(446, 234);
            dtgDisplayApp.TabIndex = 10;
            dtgDisplayApp.CellDoubleClick += dtgDisplayApp_CellDoubleClick;
            // 
            // AppName
            // 
            AppName.HeaderText = "App name";
            AppName.Name = "AppName";
            AppName.Width = 200;
            // 
            // Platform
            // 
            Platform.HeaderText = "Platform";
            Platform.Name = "Platform";
            // 
            // AppID
            // 
            AppID.HeaderText = "ID";
            AppID.Name = "AppID";
            // 
            // txtboxSearchApp
            // 
            txtboxSearchApp.Location = new Point(19, 13);
            txtboxSearchApp.Name = "txtboxSearchApp";
            txtboxSearchApp.Size = new Size(142, 23);
            txtboxSearchApp.TabIndex = 11;
            // 
            // btnSearchApp
            // 
            btnSearchApp.Location = new Point(167, 6);
            btnSearchApp.Name = "btnSearchApp";
            btnSearchApp.Size = new Size(119, 30);
            btnSearchApp.TabIndex = 12;
            btnSearchApp.Text = "Search";
            btnSearchApp.UseVisualStyleBackColor = true;
            // 
            // btnAllGroups
            // 
            btnAllGroups.Location = new Point(292, 6);
            btnAllGroups.Name = "btnAllGroups";
            btnAllGroups.Size = new Size(124, 30);
            btnAllGroups.TabIndex = 9;
            btnAllGroups.Text = "List all apps";
            btnAllGroups.UseVisualStyleBackColor = true;
            btnAllGroups.Click += btnAllGroups_Click;
            // 
            // pnlSelectApps
            // 
            pnlSelectApps.BorderStyle = BorderStyle.FixedSingle;
            pnlSelectApps.Controls.Add(clbAppAssignments);
            pnlSelectApps.Location = new Point(584, 11);
            pnlSelectApps.Name = "pnlSelectApps";
            pnlSelectApps.Size = new Size(281, 287);
            pnlSelectApps.TabIndex = 10;
            // 
            // pnlSearchGroup
            // 
            pnlSearchGroup.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchGroup.Controls.Add(dtgDisplayGroup);
            pnlSearchGroup.Controls.Add(btnSearchGroup);
            pnlSearchGroup.Controls.Add(txtboxSearchGroup);
            pnlSearchGroup.Controls.Add(btnListAllGroups);
            pnlSearchGroup.Location = new Point(108, 305);
            pnlSearchGroup.Name = "pnlSearchGroup";
            pnlSearchGroup.Size = new Size(470, 287);
            pnlSearchGroup.TabIndex = 11;
            // 
            // dtgDisplayGroup
            // 
            dtgDisplayGroup.AllowUserToAddRows = false;
            dtgDisplayGroup.AllowUserToDeleteRows = false;
            dtgDisplayGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayGroup.Columns.AddRange(new DataGridViewColumn[] { GroupName, GroupID });
            dtgDisplayGroup.ContextMenuStrip = dtgDisplayAppRightClick;
            dtgDisplayGroup.Location = new Point(19, 41);
            dtgDisplayGroup.Name = "dtgDisplayGroup";
            dtgDisplayGroup.RowTemplate.Height = 25;
            dtgDisplayGroup.Size = new Size(446, 234);
            dtgDisplayGroup.TabIndex = 14;
            dtgDisplayGroup.CellDoubleClick += dtgDisplayGroup_CellDoubleClick;
            // 
            // GroupName
            // 
            GroupName.HeaderText = "Group name";
            GroupName.Name = "GroupName";
            GroupName.Width = 200;
            // 
            // GroupID
            // 
            GroupID.HeaderText = "ID";
            GroupID.Name = "GroupID";
            GroupID.Width = 200;
            // 
            // btnSearchGroup
            // 
            btnSearchGroup.Location = new Point(167, 5);
            btnSearchGroup.Name = "btnSearchGroup";
            btnSearchGroup.Size = new Size(119, 30);
            btnSearchGroup.TabIndex = 15;
            btnSearchGroup.Text = "Search";
            btnSearchGroup.UseVisualStyleBackColor = true;
            btnSearchGroup.Click += btnSearchGroup_Click;
            // 
            // txtboxSearchGroup
            // 
            txtboxSearchGroup.Location = new Point(19, 12);
            txtboxSearchGroup.Name = "txtboxSearchGroup";
            txtboxSearchGroup.Size = new Size(142, 23);
            txtboxSearchGroup.TabIndex = 13;
            // 
            // btnListAllGroups
            // 
            btnListAllGroups.Location = new Point(292, 5);
            btnListAllGroups.Name = "btnListAllGroups";
            btnListAllGroups.Size = new Size(124, 30);
            btnListAllGroups.TabIndex = 13;
            btnListAllGroups.Text = "List all groups";
            btnListAllGroups.UseVisualStyleBackColor = true;
            btnListAllGroups.Click += btnListAllGroups_Click;
            // 
            // pnlSelectGroup
            // 
            pnlSelectGroup.BorderStyle = BorderStyle.FixedSingle;
            pnlSelectGroup.Controls.Add(clbGroupAssignment);
            pnlSelectGroup.Location = new Point(580, 305);
            pnlSelectGroup.Name = "pnlSelectGroup";
            pnlSelectGroup.Size = new Size(281, 287);
            pnlSelectGroup.TabIndex = 11;
            // 
            // clbGroupAssignment
            // 
            clbGroupAssignment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clbGroupAssignment.BackColor = Color.FromArgb(46, 51, 73);
            clbGroupAssignment.BorderStyle = BorderStyle.None;
            clbGroupAssignment.CheckOnClick = true;
            clbGroupAssignment.ContextMenuStrip = cmsRemoveItems;
            clbGroupAssignment.ForeColor = Color.Salmon;
            clbGroupAssignment.FormattingEnabled = true;
            clbGroupAssignment.Items.AddRange(new object[] { "Group 1", "Group 2", "Group 3", "Group 4", "Group 5" });
            clbGroupAssignment.Location = new Point(12, 13);
            clbGroupAssignment.Name = "clbGroupAssignment";
            clbGroupAssignment.Size = new Size(253, 216);
            clbGroupAssignment.TabIndex = 0;
            clbGroupAssignment.MouseClick += clbGroupAssignment_MouseClick;
            // 
            // pnlIntent
            // 
            pnlIntent.Controls.Add(lblIntentChoice);
            pnlIntent.Controls.Add(rbtnUninstall);
            pnlIntent.Controls.Add(rbtnRequired);
            pnlIntent.Controls.Add(rbtnAvailable);
            pnlIntent.Location = new Point(108, 601);
            pnlIntent.Name = "pnlIntent";
            pnlIntent.Size = new Size(303, 125);
            pnlIntent.TabIndex = 12;
            // 
            // lblIntentChoice
            // 
            lblIntentChoice.AutoSize = true;
            lblIntentChoice.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblIntentChoice.ForeColor = Color.Salmon;
            lblIntentChoice.Location = new Point(20, 13);
            lblIntentChoice.Name = "lblIntentChoice";
            lblIntentChoice.Size = new Size(274, 30);
            lblIntentChoice.TabIndex = 3;
            lblIntentChoice.Text = "Choose deployment intent";
            // 
            // rbtnUninstall
            // 
            rbtnUninstall.AutoSize = true;
            rbtnUninstall.ForeColor = Color.Salmon;
            rbtnUninstall.Location = new Point(20, 96);
            rbtnUninstall.Name = "rbtnUninstall";
            rbtnUninstall.Size = new Size(71, 19);
            rbtnUninstall.TabIndex = 2;
            rbtnUninstall.TabStop = true;
            rbtnUninstall.Text = "Uninstall";
            rbtnUninstall.UseVisualStyleBackColor = true;
            // 
            // rbtnRequired
            // 
            rbtnRequired.AutoSize = true;
            rbtnRequired.ForeColor = Color.Salmon;
            rbtnRequired.Location = new Point(20, 71);
            rbtnRequired.Name = "rbtnRequired";
            rbtnRequired.Size = new Size(72, 19);
            rbtnRequired.TabIndex = 1;
            rbtnRequired.TabStop = true;
            rbtnRequired.Text = "Required";
            rbtnRequired.UseVisualStyleBackColor = true;
            // 
            // rbtnAvailable
            // 
            rbtnAvailable.AutoSize = true;
            rbtnAvailable.ForeColor = Color.Salmon;
            rbtnAvailable.Location = new Point(20, 46);
            rbtnAvailable.Name = "rbtnAvailable";
            rbtnAvailable.Size = new Size(73, 19);
            rbtnAvailable.TabIndex = 0;
            rbtnAvailable.TabStop = true;
            rbtnAvailable.Text = "Available";
            rbtnAvailable.UseVisualStyleBackColor = true;
            // 
            // btnSummarize
            // 
            btnSummarize.FlatAppearance.BorderColor = Color.White;
            btnSummarize.Location = new Point(158, 3);
            btnSummarize.Name = "btnSummarize";
            btnSummarize.Size = new Size(79, 38);
            btnSummarize.TabIndex = 14;
            btnSummarize.Text = "Summarize";
            btnSummarize.UseVisualStyleBackColor = true;
            btnSummarize.Click += btnSummarize_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(240, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(79, 38);
            btnReset.TabIndex = 15;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // panelSummary
            // 
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
            panelSummary.Location = new Point(580, 598);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(322, 334);
            panelSummary.TabIndex = 16;
            // 
            // rtbDeploymentSummary
            // 
            rtbDeploymentSummary.BackColor = Color.FromArgb(46, 51, 73);
            rtbDeploymentSummary.BorderStyle = BorderStyle.None;
            rtbDeploymentSummary.ForeColor = Color.Salmon;
            rtbDeploymentSummary.Location = new Point(15, 339);
            rtbDeploymentSummary.Name = "rtbDeploymentSummary";
            rtbDeploymentSummary.Size = new Size(244, 113);
            rtbDeploymentSummary.TabIndex = 20;
            rtbDeploymentSummary.Text = "";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(15, 305);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(292, 28);
            progressBar1.TabIndex = 17;
            // 
            // btnDeployAssignments
            // 
            btnDeployAssignments.Location = new Point(88, 247);
            btnDeployAssignments.Name = "btnDeployAssignments";
            btnDeployAssignments.Size = new Size(124, 39);
            btnDeployAssignments.TabIndex = 17;
            btnDeployAssignments.Text = "Deploy";
            btnDeployAssignments.UseVisualStyleBackColor = true;
            btnDeployAssignments.Click += btnDeployAssignments_Click;
            // 
            // rtbSummarizeIntent
            // 
            rtbSummarizeIntent.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummarizeIntent.BorderStyle = BorderStyle.None;
            rtbSummarizeIntent.ForeColor = Color.Salmon;
            rtbSummarizeIntent.Location = new Point(4, 204);
            rtbSummarizeIntent.Name = "rtbSummarizeIntent";
            rtbSummarizeIntent.Size = new Size(255, 26);
            rtbSummarizeIntent.TabIndex = 19;
            rtbSummarizeIntent.Text = "";
            // 
            // rtbSummarizeGroups
            // 
            rtbSummarizeGroups.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummarizeGroups.BorderStyle = BorderStyle.None;
            rtbSummarizeGroups.ForeColor = Color.Salmon;
            rtbSummarizeGroups.Location = new Point(3, 119);
            rtbSummarizeGroups.Name = "rtbSummarizeGroups";
            rtbSummarizeGroups.Size = new Size(255, 61);
            rtbSummarizeGroups.TabIndex = 18;
            rtbSummarizeGroups.Text = "";
            // 
            // rtbSummarizeApps
            // 
            rtbSummarizeApps.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummarizeApps.BorderStyle = BorderStyle.None;
            rtbSummarizeApps.ForeColor = Color.Salmon;
            rtbSummarizeApps.Location = new Point(4, 33);
            rtbSummarizeApps.Name = "rtbSummarizeApps";
            rtbSummarizeApps.Size = new Size(255, 62);
            rtbSummarizeApps.TabIndex = 17;
            rtbSummarizeApps.Text = "";
            // 
            // lblSummarizeIntent
            // 
            lblSummarizeIntent.AutoSize = true;
            lblSummarizeIntent.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummarizeIntent.ForeColor = Color.Salmon;
            lblSummarizeIntent.Location = new Point(4, 183);
            lblSummarizeIntent.Name = "lblSummarizeIntent";
            lblSummarizeIntent.Size = new Size(26, 18);
            lblSummarizeIntent.TabIndex = 2;
            lblSummarizeIntent.Text = "as";
            // 
            // lblSummarizeGroups
            // 
            lblSummarizeGroups.AutoSize = true;
            lblSummarizeGroups.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummarizeGroups.ForeColor = Color.Salmon;
            lblSummarizeGroups.Location = new Point(3, 98);
            lblSummarizeGroups.Name = "lblSummarizeGroups";
            lblSummarizeGroups.Size = new Size(304, 18);
            lblSummarizeGroups.TabIndex = 1;
            lblSummarizeGroups.Text = "will be assigned to the following groups";
            // 
            // lblSummarizeApps
            // 
            lblSummarizeApps.AutoSize = true;
            lblSummarizeApps.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummarizeApps.ForeColor = Color.Salmon;
            lblSummarizeApps.Location = new Point(3, 12);
            lblSummarizeApps.Name = "lblSummarizeApps";
            lblSummarizeApps.Size = new Size(149, 18);
            lblSummarizeApps.TabIndex = 0;
            lblSummarizeApps.Text = "The following apps";
            // 
            // sideBarTimer
            // 
            sideBarTimer.Interval = 10;
            sideBarTimer.Tick += sideBarTimer_Tick;
            // 
            // menuPanel
            // 
            menuPanel.BorderStyle = BorderStyle.FixedSingle;
            menuPanel.Controls.Add(pictureBox1);
            menuPanel.Controls.Add(pbView);
            menuPanel.Controls.Add(panelTenantInfo);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Location = new Point(0, 0);
            menuPanel.MaximumSize = new Size(287, 893);
            menuPanel.MinimumSize = new Size(102, 893);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(102, 893);
            menuPanel.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1109, 893);
            Controls.Add(panelSummary);
            Controls.Add(menuPanel);
            Controls.Add(testBtn);
            Controls.Add(pnlIntent);
            Controls.Add(pnlSelectGroup);
            Controls.Add(pnlSearchGroup);
            Controls.Add(pnlSelectApps);
            Controls.Add(pnlSearchApp);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panelTenantInfo.ResumeLayout(false);
            panelTenantInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            dtgDisplayAppRightClick.ResumeLayout(false);
            cmsRemoveApps.ResumeLayout(false);
            cmsRemoveItems.ResumeLayout(false);
            pnlSearchApp.ResumeLayout(false);
            pnlSearchApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayApp).EndInit();
            pnlSelectApps.ResumeLayout(false);
            pnlSearchGroup.ResumeLayout(false);
            pnlSearchGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).EndInit();
            pnlSelectGroup.ResumeLayout(false);
            pnlIntent.ResumeLayout(false);
            pnlIntent.PerformLayout();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            menuPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTenantInfo;
        private Button SignIn;
        private Label lblSignedInUser;
        private Label lblTenantInfo;
        private Label lblTenantID;
        private Button testBtn;
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
        private DataGridViewTextBoxColumn AppName;
        private DataGridViewTextBoxColumn Platform;
        private DataGridViewTextBoxColumn AppID;
        private Panel pnlSelectGroup;
        private CheckedListBox clbGroupAssignment;
        private DataGridViewTextBoxColumn GroupName;
        private DataGridViewTextBoxColumn GroupID;
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
    }
}