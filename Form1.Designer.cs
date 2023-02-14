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
            this.components = new System.ComponentModel.Container();
            this.panelTenantInfo = new System.Windows.Forms.Panel();
            this.SignIn = new System.Windows.Forms.Button();
            this.lblTenantID = new System.Windows.Forms.Label();
            this.lblTenantInfo = new System.Windows.Forms.Label();
            this.lblSignedInUser = new System.Windows.Forms.Label();
            this.testBtn = new System.Windows.Forms.Button();
            this.dtgDisplayAppRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.assignmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clbAppAssignments = new System.Windows.Forms.CheckedListBox();
            this.cmsRemoveItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSearchApp = new System.Windows.Forms.Panel();
            this.dtgDisplayApp = new System.Windows.Forms.DataGridView();
            this.AppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Platform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtboxSearchApp = new System.Windows.Forms.TextBox();
            this.btnSearchApp = new System.Windows.Forms.Button();
            this.btnAllGroups = new System.Windows.Forms.Button();
            this.pnlSelectApps = new System.Windows.Forms.Panel();
            this.pnlSearchGroup = new System.Windows.Forms.Panel();
            this.dtgDisplayGroup = new System.Windows.Forms.DataGridView();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearchGroup = new System.Windows.Forms.Button();
            this.txtboxSearchGroup = new System.Windows.Forms.TextBox();
            this.btnListAllGroups = new System.Windows.Forms.Button();
            this.pnlSelectGroup = new System.Windows.Forms.Panel();
            this.clbGroupAssignment = new System.Windows.Forms.CheckedListBox();
            this.cmsRemoveApps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTenantInfo.SuspendLayout();
            this.dtgDisplayAppRightClick.SuspendLayout();
            this.cmsRemoveItems.SuspendLayout();
            this.pnlSearchApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDisplayApp)).BeginInit();
            this.pnlSelectApps.SuspendLayout();
            this.pnlSearchGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDisplayGroup)).BeginInit();
            this.pnlSelectGroup.SuspendLayout();
            this.cmsRemoveApps.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTenantInfo
            // 
            this.panelTenantInfo.Controls.Add(this.SignIn);
            this.panelTenantInfo.Controls.Add(this.lblTenantID);
            this.panelTenantInfo.Controls.Add(this.lblTenantInfo);
            this.panelTenantInfo.Controls.Add(this.lblSignedInUser);
            this.panelTenantInfo.Location = new System.Drawing.Point(788, 12);
            this.panelTenantInfo.Name = "panelTenantInfo";
            this.panelTenantInfo.Size = new System.Drawing.Size(309, 183);
            this.panelTenantInfo.TabIndex = 0;
            // 
            // SignIn
            // 
            this.SignIn.Location = new System.Drawing.Point(180, 139);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(126, 41);
            this.SignIn.TabIndex = 1;
            this.SignIn.Text = "Sign in";
            this.SignIn.UseVisualStyleBackColor = true;
            this.SignIn.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTenantID
            // 
            this.lblTenantID.AutoSize = true;
            this.lblTenantID.ForeColor = System.Drawing.Color.Salmon;
            this.lblTenantID.Location = new System.Drawing.Point(12, 74);
            this.lblTenantID.Name = "lblTenantID";
            this.lblTenantID.Size = new System.Drawing.Size(62, 15);
            this.lblTenantID.TabIndex = 3;
            this.lblTenantID.Text = "TENANTID";
            // 
            // lblTenantInfo
            // 
            this.lblTenantInfo.AutoSize = true;
            this.lblTenantInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTenantInfo.ForeColor = System.Drawing.Color.Salmon;
            this.lblTenantInfo.Location = new System.Drawing.Point(12, 13);
            this.lblTenantInfo.Name = "lblTenantInfo";
            this.lblTenantInfo.Size = new System.Drawing.Size(113, 25);
            this.lblTenantInfo.TabIndex = 2;
            this.lblTenantInfo.Text = "Tenant info";
            // 
            // lblSignedInUser
            // 
            this.lblSignedInUser.AutoSize = true;
            this.lblSignedInUser.ForeColor = System.Drawing.Color.Salmon;
            this.lblSignedInUser.Location = new System.Drawing.Point(12, 48);
            this.lblSignedInUser.Name = "lblSignedInUser";
            this.lblSignedInUser.Size = new System.Drawing.Size(92, 15);
            this.lblSignedInUser.TabIndex = 1;
            this.lblSignedInUser.Text = "SIGNED IN USER";
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(964, 744);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(126, 49);
            this.testBtn.TabIndex = 2;
            this.testBtn.Text = "Test Button";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // dtgDisplayAppRightClick
            // 
            this.dtgDisplayAppRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assignmentsToolStripMenuItem});
            this.dtgDisplayAppRightClick.Name = "dtgDisplayAppRightClick";
            this.dtgDisplayAppRightClick.Size = new System.Drawing.Size(143, 26);
            // 
            // assignmentsToolStripMenuItem
            // 
            this.assignmentsToolStripMenuItem.Name = "assignmentsToolStripMenuItem";
            this.assignmentsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.assignmentsToolStripMenuItem.Text = "Assignments";
            // 
            // clbAppAssignments
            // 
            this.clbAppAssignments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbAppAssignments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.clbAppAssignments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbAppAssignments.CheckOnClick = true;
            this.clbAppAssignments.ContextMenuStrip = this.cmsRemoveApps;
            this.clbAppAssignments.ForeColor = System.Drawing.Color.Salmon;
            this.clbAppAssignments.FormattingEnabled = true;
            this.clbAppAssignments.Items.AddRange(new object[] {
            "App 1",
            "App 2",
            "App 3"});
            this.clbAppAssignments.Location = new System.Drawing.Point(12, 13);
            this.clbAppAssignments.Name = "clbAppAssignments";
            this.clbAppAssignments.Size = new System.Drawing.Size(253, 234);
            this.clbAppAssignments.TabIndex = 0;
            this.clbAppAssignments.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbAppAssignments_MouseClick);
            // 
            // cmsRemoveItems
            // 
            this.cmsRemoveItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.removeAllToolStripMenuItem});
            this.cmsRemoveItems.Name = "contextMenuStrip1";
            this.cmsRemoveItems.Size = new System.Drawing.Size(164, 48);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.removeToolStripMenuItem.Text = "Remove selected";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.removeAllToolStripMenuItem.Text = "Remove all";
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.removeAllToolStripMenuItem_Click);
            // 
            // pnlSearchApp
            // 
            this.pnlSearchApp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSearchApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchApp.Controls.Add(this.dtgDisplayApp);
            this.pnlSearchApp.Controls.Add(this.txtboxSearchApp);
            this.pnlSearchApp.Controls.Add(this.btnSearchApp);
            this.pnlSearchApp.Controls.Add(this.btnAllGroups);
            this.pnlSearchApp.Location = new System.Drawing.Point(12, 12);
            this.pnlSearchApp.Name = "pnlSearchApp";
            this.pnlSearchApp.Size = new System.Drawing.Size(470, 287);
            this.pnlSearchApp.TabIndex = 9;
            // 
            // dtgDisplayApp
            // 
            this.dtgDisplayApp.AllowUserToAddRows = false;
            this.dtgDisplayApp.AllowUserToDeleteRows = false;
            this.dtgDisplayApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDisplayApp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AppName,
            this.Platform,
            this.AppID});
            this.dtgDisplayApp.ContextMenuStrip = this.dtgDisplayAppRightClick;
            this.dtgDisplayApp.Location = new System.Drawing.Point(19, 42);
            this.dtgDisplayApp.Name = "dtgDisplayApp";
            this.dtgDisplayApp.RowTemplate.Height = 25;
            this.dtgDisplayApp.Size = new System.Drawing.Size(446, 234);
            this.dtgDisplayApp.TabIndex = 10;
            this.dtgDisplayApp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDisplayApp_CellDoubleClick);
            // 
            // AppName
            // 
            this.AppName.HeaderText = "App name";
            this.AppName.Name = "AppName";
            this.AppName.Width = 200;
            // 
            // Platform
            // 
            this.Platform.HeaderText = "Platform";
            this.Platform.Name = "Platform";
            // 
            // AppID
            // 
            this.AppID.HeaderText = "ID";
            this.AppID.Name = "AppID";
            // 
            // txtboxSearchApp
            // 
            this.txtboxSearchApp.Location = new System.Drawing.Point(19, 13);
            this.txtboxSearchApp.Name = "txtboxSearchApp";
            this.txtboxSearchApp.Size = new System.Drawing.Size(142, 23);
            this.txtboxSearchApp.TabIndex = 11;
            // 
            // btnSearchApp
            // 
            this.btnSearchApp.Location = new System.Drawing.Point(167, 6);
            this.btnSearchApp.Name = "btnSearchApp";
            this.btnSearchApp.Size = new System.Drawing.Size(119, 30);
            this.btnSearchApp.TabIndex = 12;
            this.btnSearchApp.Text = "Search";
            this.btnSearchApp.UseVisualStyleBackColor = true;
            // 
            // btnAllGroups
            // 
            this.btnAllGroups.Location = new System.Drawing.Point(292, 6);
            this.btnAllGroups.Name = "btnAllGroups";
            this.btnAllGroups.Size = new System.Drawing.Size(124, 30);
            this.btnAllGroups.TabIndex = 9;
            this.btnAllGroups.Text = "List all apps";
            this.btnAllGroups.UseVisualStyleBackColor = true;
            this.btnAllGroups.Click += new System.EventHandler(this.btnAllGroups_Click);
            // 
            // pnlSelectApps
            // 
            this.pnlSelectApps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectApps.Controls.Add(this.clbAppAssignments);
            this.pnlSelectApps.Location = new System.Drawing.Point(488, 12);
            this.pnlSelectApps.Name = "pnlSelectApps";
            this.pnlSelectApps.Size = new System.Drawing.Size(281, 287);
            this.pnlSelectApps.TabIndex = 10;
            // 
            // pnlSearchGroup
            // 
            this.pnlSearchGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchGroup.Controls.Add(this.dtgDisplayGroup);
            this.pnlSearchGroup.Controls.Add(this.btnSearchGroup);
            this.pnlSearchGroup.Controls.Add(this.txtboxSearchGroup);
            this.pnlSearchGroup.Controls.Add(this.btnListAllGroups);
            this.pnlSearchGroup.Location = new System.Drawing.Point(12, 305);
            this.pnlSearchGroup.Name = "pnlSearchGroup";
            this.pnlSearchGroup.Size = new System.Drawing.Size(470, 287);
            this.pnlSearchGroup.TabIndex = 11;
            // 
            // dtgDisplayGroup
            // 
            this.dtgDisplayGroup.AllowUserToAddRows = false;
            this.dtgDisplayGroup.AllowUserToDeleteRows = false;
            this.dtgDisplayGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDisplayGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName,
            this.GroupID});
            this.dtgDisplayGroup.ContextMenuStrip = this.dtgDisplayAppRightClick;
            this.dtgDisplayGroup.Location = new System.Drawing.Point(19, 41);
            this.dtgDisplayGroup.Name = "dtgDisplayGroup";
            this.dtgDisplayGroup.RowTemplate.Height = 25;
            this.dtgDisplayGroup.Size = new System.Drawing.Size(446, 234);
            this.dtgDisplayGroup.TabIndex = 14;
            // 
            // GroupName
            // 
            this.GroupName.HeaderText = "Group name";
            this.GroupName.Name = "GroupName";
            this.GroupName.Width = 200;
            // 
            // GroupID
            // 
            this.GroupID.HeaderText = "ID";
            this.GroupID.Name = "GroupID";
            this.GroupID.Width = 200;
            // 
            // btnSearchGroup
            // 
            this.btnSearchGroup.Location = new System.Drawing.Point(167, 5);
            this.btnSearchGroup.Name = "btnSearchGroup";
            this.btnSearchGroup.Size = new System.Drawing.Size(119, 30);
            this.btnSearchGroup.TabIndex = 15;
            this.btnSearchGroup.Text = "Search";
            this.btnSearchGroup.UseVisualStyleBackColor = true;
            this.btnSearchGroup.Click += new System.EventHandler(this.btnSearchGroup_Click);
            // 
            // txtboxSearchGroup
            // 
            this.txtboxSearchGroup.Location = new System.Drawing.Point(19, 12);
            this.txtboxSearchGroup.Name = "txtboxSearchGroup";
            this.txtboxSearchGroup.Size = new System.Drawing.Size(142, 23);
            this.txtboxSearchGroup.TabIndex = 13;
            // 
            // btnListAllGroups
            // 
            this.btnListAllGroups.Location = new System.Drawing.Point(292, 5);
            this.btnListAllGroups.Name = "btnListAllGroups";
            this.btnListAllGroups.Size = new System.Drawing.Size(124, 30);
            this.btnListAllGroups.TabIndex = 13;
            this.btnListAllGroups.Text = "List all groups";
            this.btnListAllGroups.UseVisualStyleBackColor = true;
            this.btnListAllGroups.Click += new System.EventHandler(this.btnListAllGroups_Click);
            // 
            // pnlSelectGroup
            // 
            this.pnlSelectGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectGroup.Controls.Add(this.clbGroupAssignment);
            this.pnlSelectGroup.Location = new System.Drawing.Point(488, 305);
            this.pnlSelectGroup.Name = "pnlSelectGroup";
            this.pnlSelectGroup.Size = new System.Drawing.Size(281, 287);
            this.pnlSelectGroup.TabIndex = 11;
            // 
            // clbGroupAssignment
            // 
            this.clbGroupAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbGroupAssignment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.clbGroupAssignment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbGroupAssignment.CheckOnClick = true;
            this.clbGroupAssignment.ContextMenuStrip = this.cmsRemoveItems;
            this.clbGroupAssignment.ForeColor = System.Drawing.Color.Salmon;
            this.clbGroupAssignment.FormattingEnabled = true;
            this.clbGroupAssignment.Items.AddRange(new object[] {
            "Group 1",
            "Group 2",
            "Group 3",
            "Group 4",
            "Group 5"});
            this.clbGroupAssignment.Location = new System.Drawing.Point(12, 13);
            this.clbGroupAssignment.Name = "clbGroupAssignment";
            this.clbGroupAssignment.Size = new System.Drawing.Size(253, 216);
            this.clbGroupAssignment.TabIndex = 0;
            this.clbGroupAssignment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbGroupAssignment_MouseClick);
            // 
            // cmsRemoveApps
            // 
            this.cmsRemoveApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedToolStripMenuItem,
            this.removeAllToolStripMenuItem1});
            this.cmsRemoveApps.Name = "cmsRemoveApps";
            this.cmsRemoveApps.Size = new System.Drawing.Size(164, 48);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove selected";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
            // 
            // removeAllToolStripMenuItem1
            // 
            this.removeAllToolStripMenuItem1.Name = "removeAllToolStripMenuItem1";
            this.removeAllToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.removeAllToolStripMenuItem1.Text = "Remove all";
            this.removeAllToolStripMenuItem1.Click += new System.EventHandler(this.removeAllToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1109, 893);
            this.Controls.Add(this.pnlSelectGroup);
            this.Controls.Add(this.pnlSearchGroup);
            this.Controls.Add(this.pnlSelectApps);
            this.Controls.Add(this.pnlSearchApp);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.panelTenantInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTenantInfo.ResumeLayout(false);
            this.panelTenantInfo.PerformLayout();
            this.dtgDisplayAppRightClick.ResumeLayout(false);
            this.cmsRemoveItems.ResumeLayout(false);
            this.pnlSearchApp.ResumeLayout(false);
            this.pnlSearchApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDisplayApp)).EndInit();
            this.pnlSelectApps.ResumeLayout(false);
            this.pnlSearchGroup.ResumeLayout(false);
            this.pnlSearchGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDisplayGroup)).EndInit();
            this.pnlSelectGroup.ResumeLayout(false);
            this.cmsRemoveApps.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}