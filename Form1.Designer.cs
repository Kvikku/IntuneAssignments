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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelTenantInfo = new Panel();
            SignIn = new Button();
            lblTenantID = new Label();
            lblTenantInfo = new Label();
            lblSignedInUser = new Label();
            pbView = new PictureBox();
            pictureBox1 = new PictureBox();
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
            lblSelectAppType = new Label();
            cBAppType = new ComboBox();
            dtgDisplayApp = new DataGridView();
            AppName = new DataGridViewTextBoxColumn();
            Platform = new DataGridViewTextBoxColumn();
            AppID = new DataGridViewTextBoxColumn();
            txtboxSearchApp = new TextBox();
            btnSearchApp = new Button();
            pnlSelectApps = new Panel();
            btnAllGroups = new Button();
            pnlSearchGroup = new Panel();
            label1 = new Label();
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
            pBPointToLoginButton = new PictureBox();
            pictureBox2 = new PictureBox();
            mainFormToolTip = new ToolTip(components);
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
            ((System.ComponentModel.ISupportInitialize)pBPointToLoginButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            SignIn.BackColor = Color.Salmon;
            SignIn.FlatStyle = FlatStyle.Popup;
            SignIn.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
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
            pbView.Location = new Point(11, 74);
            pbView.Name = "pbView";
            pbView.Size = new Size(48, 53);
            pbView.TabIndex = 17;
            pbView.TabStop = false;
            mainFormToolTip.SetToolTip(pbView, "Search");
            pbView.Click += pbView_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources._15536420761558096328_48;
            pictureBox1.Location = new Point(11, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 54);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            mainFormToolTip.SetToolTip(pictureBox1, "Home");
            pictureBox1.Click += pictureBox1_Click;
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
            clbAppAssignments.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            clbAppAssignments.ForeColor = Color.Salmon;
            clbAppAssignments.FormattingEnabled = true;
            clbAppAssignments.Items.AddRange(new object[] { "App 1", "App 2", "App 3" });
            clbAppAssignments.Location = new Point(12, 13);
            clbAppAssignments.Name = "clbAppAssignments";
            clbAppAssignments.Size = new Size(188, 272);
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
            pnlSearchApp.Controls.Add(lblSelectAppType);
            pnlSearchApp.Controls.Add(cBAppType);
            pnlSearchApp.Controls.Add(dtgDisplayApp);
            pnlSearchApp.Controls.Add(txtboxSearchApp);
            pnlSearchApp.Controls.Add(btnSearchApp);
            pnlSearchApp.Controls.Add(pnlSelectApps);
            pnlSearchApp.Controls.Add(btnAllGroups);
            pnlSearchApp.Location = new Point(108, 11);
            pnlSearchApp.Name = "pnlSearchApp";
            pnlSearchApp.Size = new Size(754, 437);
            pnlSearchApp.TabIndex = 9;
            // 
            // lblSelectAppType
            // 
            lblSelectAppType.AutoSize = true;
            lblSelectAppType.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelectAppType.ForeColor = Color.Salmon;
            lblSelectAppType.Location = new Point(3, 15);
            lblSelectAppType.Name = "lblSelectAppType";
            lblSelectAppType.Size = new Size(106, 24);
            lblSelectAppType.TabIndex = 19;
            lblSelectAppType.Text = "Platform";
            // 
            // cBAppType
            // 
            cBAppType.BackColor = Color.FromArgb(46, 51, 73);
            cBAppType.DropDownStyle = ComboBoxStyle.DropDownList;
            cBAppType.ForeColor = Color.Salmon;
            cBAppType.FormattingEnabled = true;
            cBAppType.Items.AddRange(new object[] { "Windows", "Android", "iOS", "macOS", "All types (BETA)" });
            cBAppType.Location = new Point(3, 76);
            cBAppType.Name = "cBAppType";
            cBAppType.Size = new Size(185, 23);
            cBAppType.TabIndex = 19;
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
            dataGridViewCellStyle1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgDisplayApp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgDisplayApp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayApp.Columns.AddRange(new DataGridViewColumn[] { AppName, Platform, AppID });
            dtgDisplayApp.ContextMenuStrip = dtgDisplayAppRightClick;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
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
            dtgDisplayApp.RowTemplate.Height = 25;
            dtgDisplayApp.Size = new Size(517, 324);
            dtgDisplayApp.TabIndex = 10;
            dtgDisplayApp.CellDoubleClick += dtgDisplayApp_CellDoubleClick;
            // 
            // AppName
            // 
            AppName.HeaderText = "App name";
            AppName.Name = "AppName";
            AppName.ReadOnly = true;
            AppName.Width = 350;
            // 
            // Platform
            // 
            Platform.HeaderText = "Platform";
            Platform.Name = "Platform";
            Platform.ReadOnly = true;
            Platform.Width = 200;
            // 
            // AppID
            // 
            AppID.HeaderText = "ID";
            AppID.Name = "AppID";
            AppID.ReadOnly = true;
            AppID.Width = 112;
            // 
            // txtboxSearchApp
            // 
            txtboxSearchApp.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchApp.BorderStyle = BorderStyle.FixedSingle;
            txtboxSearchApp.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxSearchApp.ForeColor = Color.Salmon;
            txtboxSearchApp.Location = new Point(194, 74);
            txtboxSearchApp.Name = "txtboxSearchApp";
            txtboxSearchApp.Size = new Size(191, 26);
            txtboxSearchApp.TabIndex = 11;
            txtboxSearchApp.Text = "Enter search here";
            txtboxSearchApp.Click += txtboxSearchApp_Click;
            // 
            // btnSearchApp
            // 
            btnSearchApp.BackColor = Color.Salmon;
            btnSearchApp.FlatStyle = FlatStyle.Popup;
            btnSearchApp.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchApp.Location = new Point(396, 68);
            btnSearchApp.Name = "btnSearchApp";
            btnSearchApp.Size = new Size(124, 30);
            btnSearchApp.TabIndex = 12;
            btnSearchApp.Text = "Search";
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
            btnAllGroups.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAllGroups.Location = new Point(526, 68);
            btnAllGroups.Name = "btnAllGroups";
            btnAllGroups.Size = new Size(124, 30);
            btnAllGroups.TabIndex = 9;
            btnAllGroups.Text = "List all apps";
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
            pnlSearchGroup.Location = new Point(868, 11);
            pnlSearchGroup.Name = "pnlSearchGroup";
            pnlSearchGroup.Size = new Size(675, 437);
            pnlSearchGroup.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Salmon;
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 20;
            label1.Text = "Target";
            // 
            // dtgDisplayGroup
            // 
            dtgDisplayGroup.AllowUserToAddRows = false;
            dtgDisplayGroup.AllowUserToDeleteRows = false;
            dtgDisplayGroup.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgDisplayGroup.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Salmon;
            dataGridViewCellStyle3.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtgDisplayGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dtgDisplayGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayGroup.Columns.AddRange(new DataGridViewColumn[] { GroupName, GroupID });
            dtgDisplayGroup.ContextMenuStrip = dtgDisplayAppRightClick;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
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
            dtgDisplayGroup.RowTemplate.Height = 25;
            dtgDisplayGroup.Size = new Size(370, 324);
            dtgDisplayGroup.TabIndex = 14;
            dtgDisplayGroup.CellDoubleClick += dtgDisplayGroup_CellDoubleClick;
            // 
            // GroupName
            // 
            GroupName.HeaderText = "Group name";
            GroupName.Name = "GroupName";
            GroupName.ReadOnly = true;
            GroupName.Width = 370;
            // 
            // GroupID
            // 
            GroupID.HeaderText = "ID";
            GroupID.Name = "GroupID";
            GroupID.ReadOnly = true;
            GroupID.Width = 200;
            // 
            // btnSearchGroup
            // 
            btnSearchGroup.BackColor = Color.Salmon;
            btnSearchGroup.FlatStyle = FlatStyle.Popup;
            btnSearchGroup.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchGroup.Location = new Point(205, 69);
            btnSearchGroup.Name = "btnSearchGroup";
            btnSearchGroup.Size = new Size(124, 30);
            btnSearchGroup.TabIndex = 15;
            btnSearchGroup.Text = "Search";
            btnSearchGroup.UseVisualStyleBackColor = false;
            btnSearchGroup.Click += btnSearchGroup_Click;
            // 
            // txtboxSearchGroup
            // 
            txtboxSearchGroup.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchGroup.BorderStyle = BorderStyle.FixedSingle;
            txtboxSearchGroup.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxSearchGroup.ForeColor = Color.Salmon;
            txtboxSearchGroup.Location = new Point(8, 73);
            txtboxSearchGroup.Name = "txtboxSearchGroup";
            txtboxSearchGroup.Size = new Size(191, 26);
            txtboxSearchGroup.TabIndex = 13;
            txtboxSearchGroup.Text = "Enter search here";
            txtboxSearchGroup.Click += txtboxSearchGroup_Click;
            // 
            // btnListAllGroups
            // 
            btnListAllGroups.BackColor = Color.Salmon;
            btnListAllGroups.FlatStyle = FlatStyle.Popup;
            btnListAllGroups.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnListAllGroups.Location = new Point(335, 68);
            btnListAllGroups.Name = "btnListAllGroups";
            btnListAllGroups.Size = new Size(124, 32);
            btnListAllGroups.TabIndex = 13;
            btnListAllGroups.Text = "List all groups";
            btnListAllGroups.UseVisualStyleBackColor = false;
            btnListAllGroups.Click += btnListAllGroups_Click;
            // 
            // pnlSelectGroup
            // 
            pnlSelectGroup.BorderStyle = BorderStyle.FixedSingle;
            pnlSelectGroup.Controls.Add(clbGroupAssignment);
            pnlSelectGroup.Location = new Point(379, 135);
            pnlSelectGroup.Name = "pnlSelectGroup";
            pnlSelectGroup.Size = new Size(286, 312);
            pnlSelectGroup.TabIndex = 11;
            // 
            // clbGroupAssignment
            // 
            clbGroupAssignment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clbGroupAssignment.BackColor = Color.FromArgb(46, 51, 73);
            clbGroupAssignment.BorderStyle = BorderStyle.None;
            clbGroupAssignment.CheckOnClick = true;
            clbGroupAssignment.ContextMenuStrip = cmsRemoveItems;
            clbGroupAssignment.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            clbGroupAssignment.ForeColor = Color.Salmon;
            clbGroupAssignment.FormattingEnabled = true;
            clbGroupAssignment.Items.AddRange(new object[] { "Group 1", "Group 2", "Group 3", "Group 4", "Group 5" });
            clbGroupAssignment.Location = new Point(12, 13);
            clbGroupAssignment.Name = "clbGroupAssignment";
            clbGroupAssignment.Size = new Size(258, 204);
            clbGroupAssignment.TabIndex = 0;
            clbGroupAssignment.MouseClick += clbGroupAssignment_MouseClick;
            // 
            // pnlIntent
            // 
            pnlIntent.Controls.Add(lblIntentChoice);
            pnlIntent.Controls.Add(rbtnUninstall);
            pnlIntent.Controls.Add(rbtnRequired);
            pnlIntent.Controls.Add(rbtnAvailable);
            pnlIntent.Location = new Point(1549, 11);
            pnlIntent.Name = "pnlIntent";
            pnlIntent.Size = new Size(117, 437);
            pnlIntent.TabIndex = 12;
            // 
            // lblIntentChoice
            // 
            lblIntentChoice.AutoSize = true;
            lblIntentChoice.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblIntentChoice.ForeColor = Color.Salmon;
            lblIntentChoice.Location = new Point(3, 9);
            lblIntentChoice.Name = "lblIntentChoice";
            lblIntentChoice.Size = new Size(82, 24);
            lblIntentChoice.TabIndex = 3;
            lblIntentChoice.Text = "Intent";
            // 
            // rbtnUninstall
            // 
            rbtnUninstall.AutoSize = true;
            rbtnUninstall.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnUninstall.ForeColor = Color.Salmon;
            rbtnUninstall.Location = new Point(3, 194);
            rbtnUninstall.Name = "rbtnUninstall";
            rbtnUninstall.Size = new Size(108, 23);
            rbtnUninstall.TabIndex = 2;
            rbtnUninstall.TabStop = true;
            rbtnUninstall.Text = "Uninstall";
            rbtnUninstall.UseVisualStyleBackColor = true;
            rbtnUninstall.Click += rbtnUninstall_Click;
            // 
            // rbtnRequired
            // 
            rbtnRequired.AutoSize = true;
            rbtnRequired.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnRequired.ForeColor = Color.Salmon;
            rbtnRequired.Location = new Point(3, 165);
            rbtnRequired.Name = "rbtnRequired";
            rbtnRequired.Size = new Size(99, 23);
            rbtnRequired.TabIndex = 1;
            rbtnRequired.TabStop = true;
            rbtnRequired.Text = "Required";
            rbtnRequired.UseVisualStyleBackColor = true;
            rbtnRequired.Click += rbtnRequired_Click;
            // 
            // rbtnAvailable
            // 
            rbtnAvailable.AutoSize = true;
            rbtnAvailable.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rbtnAvailable.ForeColor = Color.Salmon;
            rbtnAvailable.Location = new Point(3, 136);
            rbtnAvailable.Name = "rbtnAvailable";
            rbtnAvailable.Size = new Size(108, 23);
            rbtnAvailable.TabIndex = 0;
            rbtnAvailable.TabStop = true;
            rbtnAvailable.Text = "Available";
            rbtnAvailable.UseVisualStyleBackColor = true;
            rbtnAvailable.Click += rbtnAvailable_Click;
            // 
            // btnSummarize
            // 
            btnSummarize.BackColor = Color.Salmon;
            btnSummarize.FlatAppearance.BorderColor = Color.White;
            btnSummarize.FlatStyle = FlatStyle.Popup;
            btnSummarize.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSummarize.Location = new Point(15, 10);
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
            btnReset.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.Location = new Point(252, 10);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(79, 38);
            btnReset.TabIndex = 15;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
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
            panelSummary.Location = new Point(112, 490);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(1554, 401);
            panelSummary.TabIndex = 16;
            // 
            // rtbDeploymentSummary
            // 
            rtbDeploymentSummary.BackColor = Color.FromArgb(46, 51, 73);
            rtbDeploymentSummary.BorderStyle = BorderStyle.None;
            rtbDeploymentSummary.ForeColor = Color.Salmon;
            rtbDeploymentSummary.Location = new Point(1123, 92);
            rtbDeploymentSummary.Name = "rtbDeploymentSummary";
            rtbDeploymentSummary.Size = new Size(359, 294);
            rtbDeploymentSummary.TabIndex = 20;
            rtbDeploymentSummary.Text = "";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(1123, 58);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(292, 28);
            progressBar1.TabIndex = 17;
            // 
            // btnDeployAssignments
            // 
            btnDeployAssignments.BackColor = Color.Salmon;
            btnDeployAssignments.FlatAppearance.BorderSize = 0;
            btnDeployAssignments.FlatStyle = FlatStyle.Popup;
            btnDeployAssignments.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeployAssignments.ForeColor = SystemColors.ControlText;
            btnDeployAssignments.Location = new Point(1123, 13);
            btnDeployAssignments.Name = "btnDeployAssignments";
            btnDeployAssignments.Size = new Size(292, 39);
            btnDeployAssignments.TabIndex = 17;
            btnDeployAssignments.Text = "Deploy";
            btnDeployAssignments.UseVisualStyleBackColor = false;
            btnDeployAssignments.Click += btnDeployAssignments_Click;
            // 
            // rtbSummarizeIntent
            // 
            rtbSummarizeIntent.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummarizeIntent.BorderStyle = BorderStyle.None;
            rtbSummarizeIntent.ForeColor = Color.Salmon;
            rtbSummarizeIntent.Location = new Point(713, 109);
            rtbSummarizeIntent.Name = "rtbSummarizeIntent";
            rtbSummarizeIntent.Size = new Size(359, 26);
            rtbSummarizeIntent.TabIndex = 19;
            rtbSummarizeIntent.Text = "";
            // 
            // rtbSummarizeGroups
            // 
            rtbSummarizeGroups.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummarizeGroups.BorderStyle = BorderStyle.None;
            rtbSummarizeGroups.ForeColor = Color.Salmon;
            rtbSummarizeGroups.Location = new Point(320, 109);
            rtbSummarizeGroups.Name = "rtbSummarizeGroups";
            rtbSummarizeGroups.Size = new Size(356, 277);
            rtbSummarizeGroups.TabIndex = 18;
            rtbSummarizeGroups.Text = "";
            // 
            // rtbSummarizeApps
            // 
            rtbSummarizeApps.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummarizeApps.BorderStyle = BorderStyle.None;
            rtbSummarizeApps.ForeColor = Color.Salmon;
            rtbSummarizeApps.Location = new Point(15, 109);
            rtbSummarizeApps.Name = "rtbSummarizeApps";
            rtbSummarizeApps.Size = new Size(283, 277);
            rtbSummarizeApps.TabIndex = 17;
            rtbSummarizeApps.Text = "";
            // 
            // lblSummarizeIntent
            // 
            lblSummarizeIntent.AutoSize = true;
            lblSummarizeIntent.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSummarizeIntent.ForeColor = Color.Salmon;
            lblSummarizeIntent.Location = new Point(712, 67);
            lblSummarizeIntent.Name = "lblSummarizeIntent";
            lblSummarizeIntent.Size = new Size(27, 19);
            lblSummarizeIntent.TabIndex = 2;
            lblSummarizeIntent.Text = "as";
            // 
            // lblSummarizeGroups
            // 
            lblSummarizeGroups.AutoSize = true;
            lblSummarizeGroups.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSummarizeGroups.ForeColor = Color.Salmon;
            lblSummarizeGroups.Location = new Point(320, 67);
            lblSummarizeGroups.Name = "lblSummarizeGroups";
            lblSummarizeGroups.Size = new Size(369, 19);
            lblSummarizeGroups.TabIndex = 1;
            lblSummarizeGroups.Text = "will be assigned to the following groups";
            // 
            // lblSummarizeApps
            // 
            lblSummarizeApps.AutoSize = true;
            lblSummarizeApps.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSummarizeApps.ForeColor = Color.Salmon;
            lblSummarizeApps.Location = new Point(7, 67);
            lblSummarizeApps.Name = "lblSummarizeApps";
            lblSummarizeApps.Size = new Size(171, 19);
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
            menuPanel.Controls.Add(pBPointToLoginButton);
            menuPanel.Controls.Add(pictureBox2);
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
            // pBPointToLoginButton
            // 
            pBPointToLoginButton.Image = Properties.Resources._5410058521582634780_128;
            pBPointToLoginButton.Location = new Point(127, 204);
            pBPointToLoginButton.Name = "pBPointToLoginButton";
            pBPointToLoginButton.Size = new Size(129, 136);
            pBPointToLoginButton.TabIndex = 19;
            pBPointToLoginButton.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._46291024716276567993766_48;
            pictureBox2.Location = new Point(11, 133);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 53);
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            mainFormToolTip.SetToolTip(pictureBox2, "Device policy");
            pictureBox2.Click += pictureBox2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1878, 897);
            Controls.Add(panelSummary);
            Controls.Add(menuPanel);
            Controls.Add(pnlIntent);
            Controls.Add(pnlSearchGroup);
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
            ((System.ComponentModel.ISupportInitialize)pBPointToLoginButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
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
        private PictureBox pictureBox2;
        private ToolTip mainFormToolTip;
        private DataGridViewTextBoxColumn AppName;
        private DataGridViewTextBoxColumn Platform;
        private DataGridViewTextBoxColumn AppID;
        private PictureBox pBPointToLoginButton;
        private DataGridViewTextBoxColumn GroupName;
        private DataGridViewTextBoxColumn GroupID;
    }
}