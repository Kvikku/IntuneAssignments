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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelTenantInfo = new Panel();
            SignIn = new Button();
            lblTenantID = new Label();
            lblTenantInfo = new Label();
            lblSignedInUser = new Label();
            pbView = new PictureBox();
            pictureBox1 = new PictureBox();
            clbAppAssignments = new CheckedListBox();
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
            GroupMemberCount = new DataGridViewTextBoxColumn();
            GroupType = new DataGridViewTextBoxColumn();
            GroupID = new DataGridViewTextBoxColumn();
            btnSearchGroup = new Button();
            txtboxSearchGroup = new TextBox();
            btnListAllGroups = new Button();
            pnlSelectGroup = new Panel();
            clbGroupAssignment = new CheckedListBox();
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
            pnlSearchApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayApp).BeginInit();
            pnlSelectApps.SuspendLayout();
            pnlSearchGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).BeginInit();
            pnlSelectGroup.SuspendLayout();
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
            panelTenantInfo.Location = new Point(136, 27);
            panelTenantInfo.Margin = new Padding(3, 4, 3, 4);
            panelTenantInfo.Name = "panelTenantInfo";
            panelTenantInfo.Size = new Size(329, 220);
            panelTenantInfo.TabIndex = 0;
            // 
            // SignIn
            // 
            SignIn.BackColor = Color.Salmon;
            SignIn.FlatStyle = FlatStyle.Popup;
            SignIn.Font = new Font("Consolas", 12F);
            SignIn.Location = new Point(14, 137);
            SignIn.Margin = new Padding(3, 4, 3, 4);
            SignIn.Name = "SignIn";
            SignIn.Size = new Size(144, 55);
            SignIn.TabIndex = 1;
            SignIn.Text = "Sign in";
            SignIn.UseVisualStyleBackColor = false;
            SignIn.Click += button2_Click;
            // 
            // lblTenantID
            // 
            lblTenantID.AutoSize = true;
            lblTenantID.ForeColor = Color.Salmon;
            lblTenantID.Location = new Point(14, 99);
            lblTenantID.Name = "lblTenantID";
            lblTenantID.Size = new Size(80, 20);
            lblTenantID.TabIndex = 3;
            lblTenantID.Text = "TENANTID";
            // 
            // lblTenantInfo
            // 
            lblTenantInfo.AutoSize = true;
            lblTenantInfo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblTenantInfo.ForeColor = Color.Salmon;
            lblTenantInfo.Location = new Point(14, 17);
            lblTenantInfo.Name = "lblTenantInfo";
            lblTenantInfo.Size = new Size(144, 32);
            lblTenantInfo.TabIndex = 2;
            lblTenantInfo.Text = "Tenant info";
            // 
            // lblSignedInUser
            // 
            lblSignedInUser.AutoSize = true;
            lblSignedInUser.ForeColor = Color.Salmon;
            lblSignedInUser.Location = new Point(14, 64);
            lblSignedInUser.Name = "lblSignedInUser";
            lblSignedInUser.Size = new Size(119, 20);
            lblSignedInUser.TabIndex = 1;
            lblSignedInUser.Text = "SIGNED IN USER";
            // 
            // pbView
            // 
            pbView.Image = Properties.Resources._3271932871579761116_48;
            pbView.Location = new Point(13, 112);
            pbView.Margin = new Padding(3, 4, 3, 4);
            pbView.Name = "pbView";
            pbView.Size = new Size(73, 85);
            pbView.SizeMode = PictureBoxSizeMode.StretchImage;
            pbView.TabIndex = 17;
            pbView.TabStop = false;
            mainFormToolTip.SetToolTip(pbView, "View app assignments");
            pbView.Click += pbView_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._15536420761558096328_48;
            pictureBox1.Location = new Point(13, 19);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(73, 85);
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
            clbAppAssignments.Font = new Font("Consolas", 9F);
            clbAppAssignments.ForeColor = Color.Salmon;
            clbAppAssignments.FormattingEnabled = true;
            clbAppAssignments.Location = new Point(14, 17);
            clbAppAssignments.Margin = new Padding(3, 4, 3, 4);
            clbAppAssignments.Name = "clbAppAssignments";
            clbAppAssignments.Size = new Size(215, 360);
            clbAppAssignments.TabIndex = 0;
            mainFormToolTip.SetToolTip(clbAppAssignments, "All apps that you want to deploy");
            clbAppAssignments.MouseClick += clbAppAssignments_MouseClick;
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
            pnlSearchApp.Location = new Point(123, 61);
            pnlSearchApp.Margin = new Padding(3, 4, 3, 4);
            pnlSearchApp.Name = "pnlSearchApp";
            pnlSearchApp.Size = new Size(861, 553);
            pnlSearchApp.TabIndex = 9;
            // 
            // lblSelectAppType
            // 
            lblSelectAppType.AutoSize = true;
            lblSelectAppType.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSelectAppType.ForeColor = Color.Salmon;
            lblSelectAppType.Location = new Point(3, 20);
            lblSelectAppType.Name = "lblSelectAppType";
            lblSelectAppType.Size = new Size(194, 32);
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
            cBAppType.Location = new Point(3, 101);
            cBAppType.Margin = new Padding(3, 4, 3, 4);
            cBAppType.Name = "cBAppType";
            cBAppType.Size = new Size(211, 28);
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
            dtgDisplayApp.Location = new Point(3, 180);
            dtgDisplayApp.Margin = new Padding(3, 4, 3, 4);
            dtgDisplayApp.Name = "dtgDisplayApp";
            dtgDisplayApp.ReadOnly = true;
            dtgDisplayApp.RowHeadersVisible = false;
            dtgDisplayApp.RowHeadersWidth = 51;
            dtgDisplayApp.Size = new Size(591, 432);
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
            // txtboxSearchApp
            // 
            txtboxSearchApp.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchApp.BorderStyle = BorderStyle.FixedSingle;
            txtboxSearchApp.Font = new Font("Consolas", 12F);
            txtboxSearchApp.ForeColor = Color.Salmon;
            txtboxSearchApp.Location = new Point(222, 99);
            txtboxSearchApp.Margin = new Padding(3, 4, 3, 4);
            txtboxSearchApp.Name = "txtboxSearchApp";
            txtboxSearchApp.Size = new Size(218, 31);
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
            btnSearchApp.Location = new Point(453, 91);
            btnSearchApp.Margin = new Padding(3, 4, 3, 4);
            btnSearchApp.Name = "btnSearchApp";
            btnSearchApp.Size = new Size(142, 40);
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
            pnlSelectApps.Location = new Point(601, 180);
            pnlSelectApps.Margin = new Padding(3, 4, 3, 4);
            pnlSelectApps.Name = "pnlSelectApps";
            pnlSelectApps.Size = new Size(247, 539);
            pnlSelectApps.TabIndex = 10;
            // 
            // btnAllGroups
            // 
            btnAllGroups.BackColor = Color.Salmon;
            btnAllGroups.FlatStyle = FlatStyle.Popup;
            btnAllGroups.Font = new Font("Consolas", 12F);
            btnAllGroups.Location = new Point(601, 91);
            btnAllGroups.Margin = new Padding(3, 4, 3, 4);
            btnAllGroups.Name = "btnAllGroups";
            btnAllGroups.Size = new Size(142, 40);
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
            pnlSearchGroup.Location = new Point(992, 61);
            pnlSearchGroup.Margin = new Padding(3, 4, 3, 4);
            pnlSearchGroup.Name = "pnlSearchGroup";
            pnlSearchGroup.Size = new Size(771, 551);
            pnlSearchGroup.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            label1.ForeColor = Color.Salmon;
            label1.Location = new Point(9, 12);
            label1.Name = "label1";
            label1.Size = new Size(104, 32);
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = Color.Salmon;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dtgDisplayGroup.DefaultCellStyle = dataGridViewCellStyle4;
            dtgDisplayGroup.EnableHeadersVisualStyles = false;
            dtgDisplayGroup.Location = new Point(3, 180);
            dtgDisplayGroup.Margin = new Padding(3, 4, 3, 4);
            dtgDisplayGroup.Name = "dtgDisplayGroup";
            dtgDisplayGroup.ReadOnly = true;
            dtgDisplayGroup.RowHeadersVisible = false;
            dtgDisplayGroup.RowHeadersWidth = 51;
            dtgDisplayGroup.Size = new Size(469, 408);
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
            // btnSearchGroup
            // 
            btnSearchGroup.BackColor = Color.Salmon;
            btnSearchGroup.FlatStyle = FlatStyle.Popup;
            btnSearchGroup.Font = new Font("Consolas", 12F);
            btnSearchGroup.Location = new Point(234, 92);
            btnSearchGroup.Margin = new Padding(3, 4, 3, 4);
            btnSearchGroup.Name = "btnSearchGroup";
            btnSearchGroup.Size = new Size(142, 40);
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
            txtboxSearchGroup.Location = new Point(9, 97);
            txtboxSearchGroup.Margin = new Padding(3, 4, 3, 4);
            txtboxSearchGroup.Name = "txtboxSearchGroup";
            txtboxSearchGroup.Size = new Size(218, 31);
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
            btnListAllGroups.Location = new Point(383, 91);
            btnListAllGroups.Margin = new Padding(3, 4, 3, 4);
            btnListAllGroups.Name = "btnListAllGroups";
            btnListAllGroups.Size = new Size(142, 43);
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
            pnlSelectGroup.Location = new Point(479, 180);
            pnlSelectGroup.Margin = new Padding(3, 4, 3, 4);
            pnlSelectGroup.Name = "pnlSelectGroup";
            pnlSelectGroup.Size = new Size(281, 415);
            pnlSelectGroup.TabIndex = 11;
            // 
            // clbGroupAssignment
            // 
            clbGroupAssignment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clbGroupAssignment.BackColor = Color.FromArgb(46, 51, 73);
            clbGroupAssignment.BorderStyle = BorderStyle.None;
            clbGroupAssignment.CheckOnClick = true;
            clbGroupAssignment.Font = new Font("Consolas", 9F);
            clbGroupAssignment.ForeColor = Color.Salmon;
            clbGroupAssignment.FormattingEnabled = true;
            clbGroupAssignment.Location = new Point(3, 17);
            clbGroupAssignment.Margin = new Padding(3, 4, 3, 4);
            clbGroupAssignment.Name = "clbGroupAssignment";
            clbGroupAssignment.Size = new Size(259, 260);
            clbGroupAssignment.TabIndex = 0;
            mainFormToolTip.SetToolTip(clbGroupAssignment, "All groups that you want to deploy to");
            clbGroupAssignment.MouseClick += clbGroupAssignment_MouseClick;
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
            pnlIntent.Location = new Point(1770, 63);
            pnlIntent.Margin = new Padding(3, 4, 3, 4);
            pnlIntent.Name = "pnlIntent";
            pnlIntent.Size = new Size(362, 551);
            pnlIntent.TabIndex = 12;
            // 
            // txtboxAppDescription
            // 
            txtboxAppDescription.BackColor = Color.FromArgb(46, 51, 73);
            txtboxAppDescription.BorderStyle = BorderStyle.FixedSingle;
            txtboxAppDescription.ForeColor = Color.Salmon;
            txtboxAppDescription.Location = new Point(16, 307);
            txtboxAppDescription.Margin = new Padding(3, 4, 3, 4);
            txtboxAppDescription.Multiline = true;
            txtboxAppDescription.Name = "txtboxAppDescription";
            txtboxAppDescription.Size = new Size(321, 215);
            txtboxAppDescription.TabIndex = 5;
            mainFormToolTip.SetToolTip(txtboxAppDescription, "Enter a desired description. Leave blank to not add or change the description field. Existing description will be overwritten");
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblDescription.ForeColor = Color.Salmon;
            lblDescription.Location = new Point(16, 271);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(179, 32);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description";
            mainFormToolTip.SetToolTip(lblDescription, "Enter a desired description. Leave blank to not add or change the description field. Existing description will be overwritten");
            // 
            // lblIntentChoice
            // 
            lblIntentChoice.AutoSize = true;
            lblIntentChoice.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblIntentChoice.ForeColor = Color.Salmon;
            lblIntentChoice.Location = new Point(16, 20);
            lblIntentChoice.Name = "lblIntentChoice";
            lblIntentChoice.Size = new Size(104, 32);
            lblIntentChoice.TabIndex = 3;
            lblIntentChoice.Text = "Intent";
            mainFormToolTip.SetToolTip(lblIntentChoice, "Intent");
            // 
            // rbtnUninstall
            // 
            rbtnUninstall.AutoSize = true;
            rbtnUninstall.Font = new Font("Consolas", 12F);
            rbtnUninstall.ForeColor = Color.Salmon;
            rbtnUninstall.Location = new Point(16, 139);
            rbtnUninstall.Margin = new Padding(3, 4, 3, 4);
            rbtnUninstall.Name = "rbtnUninstall";
            rbtnUninstall.Size = new Size(130, 27);
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
            rbtnRequired.Location = new Point(16, 100);
            rbtnRequired.Margin = new Padding(3, 4, 3, 4);
            rbtnRequired.Name = "rbtnRequired";
            rbtnRequired.Size = new Size(119, 27);
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
            rbtnAvailable.Location = new Point(16, 61);
            rbtnAvailable.Margin = new Padding(3, 4, 3, 4);
            rbtnAvailable.Name = "rbtnAvailable";
            rbtnAvailable.Size = new Size(130, 27);
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
            btnSummarize.Location = new Point(14, 73);
            btnSummarize.Margin = new Padding(3, 4, 3, 4);
            btnSummarize.Name = "btnSummarize";
            btnSummarize.Size = new Size(246, 51);
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
            btnReset.Location = new Point(266, 73);
            btnReset.Margin = new Padding(3, 4, 3, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(150, 51);
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
            panelSummary.Location = new Point(123, 623);
            panelSummary.Margin = new Padding(3, 4, 3, 4);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(1987, 567);
            panelSummary.TabIndex = 16;
            // 
            // btn_ClearProgressBar
            // 
            btn_ClearProgressBar.BackColor = Color.Salmon;
            btn_ClearProgressBar.FlatAppearance.BorderSize = 0;
            btn_ClearProgressBar.FlatStyle = FlatStyle.Popup;
            btn_ClearProgressBar.Font = new Font("Consolas", 12F);
            btn_ClearProgressBar.ForeColor = SystemColors.ControlText;
            btn_ClearProgressBar.Location = new Point(1439, 89);
            btn_ClearProgressBar.Margin = new Padding(3, 4, 3, 4);
            btn_ClearProgressBar.Name = "btn_ClearProgressBar";
            btn_ClearProgressBar.Size = new Size(178, 37);
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
            btnDeployDescription.Location = new Point(1439, 29);
            btnDeployDescription.Margin = new Padding(3, 4, 3, 4);
            btnDeployDescription.Name = "btnDeployDescription";
            btnDeployDescription.Size = new Size(178, 52);
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
            lblSummary.Location = new Point(14, 13);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(119, 32);
            lblSummary.TabIndex = 20;
            lblSummary.Text = "Summary";
            // 
            // rtbDeploymentSummary
            // 
            rtbDeploymentSummary.BackColor = Color.FromArgb(46, 51, 73);
            rtbDeploymentSummary.BorderStyle = BorderStyle.None;
            rtbDeploymentSummary.ForeColor = Color.Salmon;
            rtbDeploymentSummary.Location = new Point(1098, 141);
            rtbDeploymentSummary.Margin = new Padding(3, 4, 3, 4);
            rtbDeploymentSummary.Name = "rtbDeploymentSummary";
            rtbDeploymentSummary.Size = new Size(910, 392);
            rtbDeploymentSummary.TabIndex = 20;
            rtbDeploymentSummary.Text = "";
            mainFormToolTip.SetToolTip(rtbDeploymentSummary, "Output from the deployment process");
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(1098, 89);
            progressBar1.Margin = new Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(334, 37);
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
            btnDeployAssignments.Location = new Point(1098, 29);
            btnDeployAssignments.Margin = new Padding(3, 4, 3, 4);
            btnDeployAssignments.Name = "btnDeployAssignments";
            btnDeployAssignments.Size = new Size(334, 52);
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
            rtbSummarizeIntent.Location = new Point(913, 191);
            rtbSummarizeIntent.Margin = new Padding(3, 4, 3, 4);
            rtbSummarizeIntent.Name = "rtbSummarizeIntent";
            rtbSummarizeIntent.Size = new Size(178, 35);
            rtbSummarizeIntent.TabIndex = 19;
            rtbSummarizeIntent.Text = "";
            mainFormToolTip.SetToolTip(rtbSummarizeIntent, "The chosen intent");
            // 
            // rtbSummarizeGroups
            // 
            rtbSummarizeGroups.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummarizeGroups.BorderStyle = BorderStyle.None;
            rtbSummarizeGroups.ForeColor = Color.Salmon;
            rtbSummarizeGroups.Location = new Point(510, 191);
            rtbSummarizeGroups.Margin = new Padding(3, 4, 3, 4);
            rtbSummarizeGroups.Name = "rtbSummarizeGroups";
            rtbSummarizeGroups.Size = new Size(398, 369);
            rtbSummarizeGroups.TabIndex = 18;
            rtbSummarizeGroups.Text = "";
            mainFormToolTip.SetToolTip(rtbSummarizeGroups, "All selected groups");
            // 
            // rtbSummarizeApps
            // 
            rtbSummarizeApps.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummarizeApps.BorderStyle = BorderStyle.None;
            rtbSummarizeApps.ForeColor = Color.Salmon;
            rtbSummarizeApps.Location = new Point(14, 191);
            rtbSummarizeApps.Margin = new Padding(3, 4, 3, 4);
            rtbSummarizeApps.Name = "rtbSummarizeApps";
            rtbSummarizeApps.Size = new Size(486, 369);
            rtbSummarizeApps.TabIndex = 17;
            rtbSummarizeApps.Text = "";
            mainFormToolTip.SetToolTip(rtbSummarizeApps, "All selected applications");
            // 
            // lblSummarizeIntent
            // 
            lblSummarizeIntent.AutoSize = true;
            lblSummarizeIntent.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblSummarizeIntent.ForeColor = Color.Salmon;
            lblSummarizeIntent.Location = new Point(913, 141);
            lblSummarizeIntent.Name = "lblSummarizeIntent";
            lblSummarizeIntent.Size = new Size(76, 23);
            lblSummarizeIntent.TabIndex = 2;
            lblSummarizeIntent.Text = "Intent";
            mainFormToolTip.SetToolTip(lblSummarizeIntent, "Intent");
            // 
            // lblSummarizeGroups
            // 
            lblSummarizeGroups.AutoSize = true;
            lblSummarizeGroups.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblSummarizeGroups.ForeColor = Color.Salmon;
            lblSummarizeGroups.Location = new Point(510, 141);
            lblSummarizeGroups.Name = "lblSummarizeGroups";
            lblSummarizeGroups.Size = new Size(175, 23);
            lblSummarizeGroups.TabIndex = 1;
            lblSummarizeGroups.Text = "Selected groups";
            mainFormToolTip.SetToolTip(lblSummarizeGroups, "Selected groups");
            // 
            // lblSummarizeApps
            // 
            lblSummarizeApps.AutoSize = true;
            lblSummarizeApps.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblSummarizeApps.ForeColor = Color.Salmon;
            lblSummarizeApps.Location = new Point(14, 141);
            lblSummarizeApps.Name = "lblSummarizeApps";
            lblSummarizeApps.Size = new Size(241, 23);
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
            menuPanel.Margin = new Padding(3, 4, 3, 4);
            menuPanel.MaximumSize = new Size(457, 1190);
            menuPanel.MinimumSize = new Size(116, 1190);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(116, 1190);
            menuPanel.TabIndex = 18;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources._121047815016345278514481_48;
            pictureBox3.Location = new Point(13, 205);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(73, 85);
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
            lblHeaderAppForm.Location = new Point(123, 12);
            lblHeaderAppForm.Name = "lblHeaderAppForm";
            lblHeaderAppForm.Size = new Size(319, 36);
            lblHeaderAppForm.TabIndex = 20;
            lblHeaderAppForm.Text = "Deploy applications";
            mainFormToolTip.SetToolTip(lblHeaderAppForm, "Applications");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1924, 1055);
            Controls.Add(lblHeaderAppForm);
            Controls.Add(panelSummary);
            Controls.Add(menuPanel);
            Controls.Add(pnlIntent);
            Controls.Add(pnlSearchGroup);
            Controls.Add(pnlSearchApp);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load;
            panelTenantInfo.ResumeLayout(false);
            panelTenantInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
    }
}