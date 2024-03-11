namespace IntuneAssignments
{
    partial class ViewAssignment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAssignment));
            pnlSearchApp = new Panel();
            pbClearDtgDisplayApp = new PictureBox();
            lblSearchApp = new Label();
            btnDeleteAssignmentForSelectedApps = new Button();
            dtgDisplayApp = new DataGridView();
            AppName = new DataGridViewTextBoxColumn();
            Platform = new DataGridViewTextBoxColumn();
            AppID = new DataGridViewTextBoxColumn();
            txtboxSearchApp = new TextBox();
            btnSearchApp = new Button();
            btnAllGroups = new Button();
            pnllViewAssignments = new Panel();
            label1 = new Label();
            btnDeleteAllAssignments = new Button();
            btnDeleteSelectedAssignment = new Button();
            lblAppID = new Label();
            pbpbClearDtgGroupAssignment = new PictureBox();
            lblAppName = new Label();
            dtgGroupAssignment = new DataGridView();
            GroupName = new DataGridViewTextBoxColumn();
            Intent = new DataGridViewTextBoxColumn();
            GroupID = new DataGridViewTextBoxColumn();
            pbHome = new PictureBox();
            mainFormToolTip = new ToolTip(components);
            btnClearSummary = new Button();
            lblNumberOfAssignmentsDeleted = new Label();
            lblDeleteStatusText = new Label();
            pbHelpGuide = new PictureBox();
            rtbSummary = new RichTextBox();
            panel2 = new Panel();
            pnlSearchApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbClearDtgDisplayApp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayApp).BeginInit();
            pnllViewAssignments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbpbClearDtgGroupAssignment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgGroupAssignment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbHome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbHelpGuide).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSearchApp
            // 
            pnlSearchApp.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchApp.Controls.Add(pbClearDtgDisplayApp);
            pnlSearchApp.Controls.Add(lblSearchApp);
            pnlSearchApp.Controls.Add(btnDeleteAssignmentForSelectedApps);
            pnlSearchApp.Controls.Add(dtgDisplayApp);
            pnlSearchApp.Controls.Add(txtboxSearchApp);
            pnlSearchApp.Controls.Add(btnSearchApp);
            pnlSearchApp.Controls.Add(btnAllGroups);
            pnlSearchApp.Location = new Point(82, 12);
            pnlSearchApp.Name = "pnlSearchApp";
            pnlSearchApp.Size = new Size(539, 747);
            pnlSearchApp.TabIndex = 0;
            // 
            // pbClearDtgDisplayApp
            // 
            pbClearDtgDisplayApp.Image = Properties.Resources._5358270771574330938_32;
            pbClearDtgDisplayApp.Location = new Point(501, 115);
            pbClearDtgDisplayApp.Name = "pbClearDtgDisplayApp";
            pbClearDtgDisplayApp.Size = new Size(36, 38);
            pbClearDtgDisplayApp.TabIndex = 18;
            pbClearDtgDisplayApp.TabStop = false;
            mainFormToolTip.SetToolTip(pbClearDtgDisplayApp, "Clear the view");
            pbClearDtgDisplayApp.Click += pbClearDtgDisplayApp_Click;
            // 
            // lblSearchApp
            // 
            lblSearchApp.AutoSize = true;
            lblSearchApp.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSearchApp.ForeColor = Color.Salmon;
            lblSearchApp.Location = new Point(15, 14);
            lblSearchApp.Name = "lblSearchApp";
            lblSearchApp.Size = new Size(262, 24);
            lblSearchApp.TabIndex = 17;
            lblSearchApp.Text = "Select application(s)";
            // 
            // btnDeleteAssignmentForSelectedApps
            // 
            btnDeleteAssignmentForSelectedApps.BackColor = Color.Salmon;
            btnDeleteAssignmentForSelectedApps.FlatStyle = FlatStyle.Flat;
            btnDeleteAssignmentForSelectedApps.Font = new Font("Consolas", 12F);
            btnDeleteAssignmentForSelectedApps.Location = new Point(246, 156);
            btnDeleteAssignmentForSelectedApps.Margin = new Padding(3, 2, 3, 2);
            btnDeleteAssignmentForSelectedApps.Name = "btnDeleteAssignmentForSelectedApps";
            btnDeleteAssignmentForSelectedApps.Size = new Size(249, 28);
            btnDeleteAssignmentForSelectedApps.TabIndex = 20;
            btnDeleteAssignmentForSelectedApps.Text = "Delete assignments";
            mainFormToolTip.SetToolTip(btnDeleteAssignmentForSelectedApps, "This will delete ALL assignments from EVERY app you have selected");
            btnDeleteAssignmentForSelectedApps.UseVisualStyleBackColor = false;
            btnDeleteAssignmentForSelectedApps.Click += btnDeleteAssignmentForSelectedApps_Click;
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
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Salmon;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgDisplayApp.DefaultCellStyle = dataGridViewCellStyle2;
            dtgDisplayApp.EnableHeadersVisualStyles = false;
            dtgDisplayApp.Location = new Point(15, 187);
            dtgDisplayApp.Name = "dtgDisplayApp";
            dtgDisplayApp.ReadOnly = true;
            dtgDisplayApp.RowHeadersVisible = false;
            dtgDisplayApp.RowHeadersWidth = 51;
            dtgDisplayApp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDisplayApp.Size = new Size(538, 579);
            dtgDisplayApp.TabIndex = 16;
            dtgDisplayApp.CellClick += dtgDisplayApp_CellClick;
            dtgDisplayApp.CellMouseDoubleClick += dtgDisplayApp_CellMouseDoubleClick;
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
            Platform.Width = 180;
            // 
            // AppID
            // 
            AppID.HeaderText = "ID";
            AppID.MinimumWidth = 6;
            AppID.Name = "AppID";
            AppID.ReadOnly = true;
            AppID.Width = 125;
            // 
            // txtboxSearchApp
            // 
            txtboxSearchApp.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchApp.Font = new Font("Consolas", 12F);
            txtboxSearchApp.ForeColor = Color.Salmon;
            txtboxSearchApp.Location = new Point(15, 121);
            txtboxSearchApp.Name = "txtboxSearchApp";
            txtboxSearchApp.Size = new Size(225, 26);
            txtboxSearchApp.TabIndex = 14;
            txtboxSearchApp.Text = "Enter search here";
            mainFormToolTip.SetToolTip(txtboxSearchApp, "Enter search query here");
            // 
            // btnSearchApp
            // 
            btnSearchApp.BackColor = Color.Salmon;
            btnSearchApp.FlatStyle = FlatStyle.Popup;
            btnSearchApp.Font = new Font("Consolas", 12F);
            btnSearchApp.Location = new Point(246, 121);
            btnSearchApp.Name = "btnSearchApp";
            btnSearchApp.Size = new Size(119, 30);
            btnSearchApp.TabIndex = 15;
            btnSearchApp.Text = "Search";
            mainFormToolTip.SetToolTip(btnSearchApp, "Click to search for applications");
            btnSearchApp.UseVisualStyleBackColor = false;
            btnSearchApp.Click += btnSearchApp_Click_1;
            // 
            // btnAllGroups
            // 
            btnAllGroups.BackColor = Color.Salmon;
            btnAllGroups.FlatStyle = FlatStyle.Popup;
            btnAllGroups.Font = new Font("Consolas", 12F);
            btnAllGroups.Location = new Point(371, 121);
            btnAllGroups.Name = "btnAllGroups";
            btnAllGroups.Size = new Size(124, 30);
            btnAllGroups.TabIndex = 13;
            btnAllGroups.Text = "List all apps";
            mainFormToolTip.SetToolTip(btnAllGroups, "List all applications");
            btnAllGroups.UseVisualStyleBackColor = false;
            btnAllGroups.Click += btnAllGroups_Click;
            // 
            // pnllViewAssignments
            // 
            pnllViewAssignments.BorderStyle = BorderStyle.FixedSingle;
            pnllViewAssignments.Controls.Add(label1);
            pnllViewAssignments.Controls.Add(btnDeleteAllAssignments);
            pnllViewAssignments.Controls.Add(btnDeleteSelectedAssignment);
            pnllViewAssignments.Controls.Add(lblAppID);
            pnllViewAssignments.Controls.Add(pbpbClearDtgGroupAssignment);
            pnllViewAssignments.Controls.Add(lblAppName);
            pnllViewAssignments.Controls.Add(dtgGroupAssignment);
            pnllViewAssignments.Location = new Point(627, 12);
            pnllViewAssignments.Name = "pnllViewAssignments";
            pnllViewAssignments.Size = new Size(470, 387);
            pnllViewAssignments.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            label1.ForeColor = Color.Salmon;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(358, 24);
            label1.TabIndex = 19;
            label1.Text = "View and delete assignment(s)";
            // 
            // btnDeleteAllAssignments
            // 
            btnDeleteAllAssignments.BackColor = Color.Salmon;
            btnDeleteAllAssignments.FlatStyle = FlatStyle.Popup;
            btnDeleteAllAssignments.Font = new Font("Consolas", 12F);
            btnDeleteAllAssignments.Location = new Point(334, 155);
            btnDeleteAllAssignments.Name = "btnDeleteAllAssignments";
            btnDeleteAllAssignments.Size = new Size(130, 30);
            btnDeleteAllAssignments.TabIndex = 19;
            btnDeleteAllAssignments.Text = "Delete all";
            mainFormToolTip.SetToolTip(btnDeleteAllAssignments, "Click to delete all group assignments");
            btnDeleteAllAssignments.UseVisualStyleBackColor = false;
            btnDeleteAllAssignments.Click += tstbtn1_Click;
            // 
            // btnDeleteSelectedAssignment
            // 
            btnDeleteSelectedAssignment.BackColor = Color.Salmon;
            btnDeleteSelectedAssignment.FlatStyle = FlatStyle.Popup;
            btnDeleteSelectedAssignment.Font = new Font("Consolas", 12F);
            btnDeleteSelectedAssignment.Location = new Point(175, 155);
            btnDeleteSelectedAssignment.Name = "btnDeleteSelectedAssignment";
            btnDeleteSelectedAssignment.Size = new Size(153, 30);
            btnDeleteSelectedAssignment.TabIndex = 20;
            btnDeleteSelectedAssignment.Text = "Delete selected";
            mainFormToolTip.SetToolTip(btnDeleteSelectedAssignment, "Click to delete the selected group assignments");
            btnDeleteSelectedAssignment.UseVisualStyleBackColor = false;
            btnDeleteSelectedAssignment.Click += btnDeleteSelectedAssignment_Click;
            // 
            // lblAppID
            // 
            lblAppID.AutoSize = true;
            lblAppID.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblAppID.ForeColor = Color.Salmon;
            lblAppID.Location = new Point(8, 115);
            lblAppID.Name = "lblAppID";
            lblAppID.Size = new Size(81, 19);
            lblAppID.TabIndex = 21;
            lblAppID.Text = "{APP ID}";
            mainFormToolTip.SetToolTip(lblAppID, "The selected applications ID");
            // 
            // pbpbClearDtgGroupAssignment
            // 
            pbpbClearDtgGroupAssignment.Image = Properties.Resources._5358270771574330938_32;
            pbpbClearDtgGroupAssignment.Location = new Point(428, 96);
            pbpbClearDtgGroupAssignment.Name = "pbpbClearDtgGroupAssignment";
            pbpbClearDtgGroupAssignment.Size = new Size(36, 38);
            pbpbClearDtgGroupAssignment.TabIndex = 19;
            pbpbClearDtgGroupAssignment.TabStop = false;
            mainFormToolTip.SetToolTip(pbpbClearDtgGroupAssignment, "Clear the view");
            pbpbClearDtgGroupAssignment.Click += pbpbClearDtgGroupAssignment_Click;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Consolas", 14.25F, FontStyle.Bold);
            lblAppName.ForeColor = Color.Salmon;
            lblAppName.Location = new Point(8, 83);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(100, 22);
            lblAppName.TabIndex = 20;
            lblAppName.Text = "{APPNAME}";
            mainFormToolTip.SetToolTip(lblAppName, "The selected application");
            // 
            // dtgGroupAssignment
            // 
            dtgGroupAssignment.AllowUserToAddRows = false;
            dtgGroupAssignment.AllowUserToDeleteRows = false;
            dtgGroupAssignment.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgGroupAssignment.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtgGroupAssignment.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Salmon;
            dataGridViewCellStyle3.Font = new Font("Consolas", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtgGroupAssignment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dtgGroupAssignment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgGroupAssignment.Columns.AddRange(new DataGridViewColumn[] { GroupName, Intent, GroupID });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = Color.Salmon;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dtgGroupAssignment.DefaultCellStyle = dataGridViewCellStyle4;
            dtgGroupAssignment.EnableHeadersVisualStyles = false;
            dtgGroupAssignment.Location = new Point(12, 187);
            dtgGroupAssignment.Name = "dtgGroupAssignment";
            dtgGroupAssignment.ReadOnly = true;
            dtgGroupAssignment.RowHeadersVisible = false;
            dtgGroupAssignment.RowHeadersWidth = 51;
            dtgGroupAssignment.Size = new Size(455, 559);
            dtgGroupAssignment.TabIndex = 16;
            // 
            // GroupName
            // 
            GroupName.HeaderText = "Group name";
            GroupName.MinimumWidth = 6;
            GroupName.Name = "GroupName";
            GroupName.ReadOnly = true;
            GroupName.Width = 300;
            // 
            // Intent
            // 
            Intent.HeaderText = "Intent";
            Intent.MinimumWidth = 6;
            Intent.Name = "Intent";
            Intent.ReadOnly = true;
            Intent.Width = 150;
            // 
            // GroupID
            // 
            GroupID.HeaderText = "Group ID";
            GroupID.MinimumWidth = 6;
            GroupID.Name = "GroupID";
            GroupID.ReadOnly = true;
            GroupID.Width = 125;
            // 
            // pbHome
            // 
            pbHome.Image = Properties.Resources.application;
            pbHome.Location = new Point(12, 12);
            pbHome.Name = "pbHome";
            pbHome.Size = new Size(64, 64);
            pbHome.SizeMode = PictureBoxSizeMode.StretchImage;
            pbHome.TabIndex = 18;
            pbHome.TabStop = false;
            mainFormToolTip.SetToolTip(pbHome, "Home");
            pbHome.Click += pbHome_Click;
            // 
            // btnClearSummary
            // 
            btnClearSummary.BackColor = Color.Salmon;
            btnClearSummary.FlatStyle = FlatStyle.Popup;
            btnClearSummary.Font = new Font("Consolas", 12F);
            btnClearSummary.Location = new Point(313, 12);
            btnClearSummary.Name = "btnClearSummary";
            btnClearSummary.Size = new Size(152, 30);
            btnClearSummary.TabIndex = 22;
            btnClearSummary.Text = "Clear summary";
            mainFormToolTip.SetToolTip(btnClearSummary, "Clears the summary of the page");
            btnClearSummary.UseVisualStyleBackColor = false;
            btnClearSummary.Click += btnClearSummary_Click;
            // 
            // lblNumberOfAssignmentsDeleted
            // 
            lblNumberOfAssignmentsDeleted.AutoSize = true;
            lblNumberOfAssignmentsDeleted.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblNumberOfAssignmentsDeleted.ForeColor = Color.Salmon;
            lblNumberOfAssignmentsDeleted.Location = new Point(9, 31);
            lblNumberOfAssignmentsDeleted.Name = "lblNumberOfAssignmentsDeleted";
            lblNumberOfAssignmentsDeleted.Size = new Size(288, 19);
            lblNumberOfAssignmentsDeleted.TabIndex = 22;
            lblNumberOfAssignmentsDeleted.Text = "{NUMBER OF DELETED ASSIGNMENTS}";
            mainFormToolTip.SetToolTip(lblNumberOfAssignmentsDeleted, "The selected applications ID");
            // 
            // lblDeleteStatusText
            // 
            lblDeleteStatusText.AutoSize = true;
            lblDeleteStatusText.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblDeleteStatusText.ForeColor = Color.Salmon;
            lblDeleteStatusText.Location = new Point(9, 12);
            lblDeleteStatusText.Name = "lblDeleteStatusText";
            lblDeleteStatusText.Size = new Size(279, 19);
            lblDeleteStatusText.TabIndex = 23;
            lblDeleteStatusText.Text = "Number of assignments deleted:";
            mainFormToolTip.SetToolTip(lblDeleteStatusText, "The selected applications ID");
            // 
            // pbHelpGuide
            // 
            pbHelpGuide.Image = Properties.Resources._121047815016345278514481_48;
            pbHelpGuide.Location = new Point(12, 72);
            pbHelpGuide.Name = "pbHelpGuide";
            pbHelpGuide.Size = new Size(64, 64);
            pbHelpGuide.SizeMode = PictureBoxSizeMode.StretchImage;
            pbHelpGuide.TabIndex = 19;
            pbHelpGuide.TabStop = false;
            pbHelpGuide.Click += pbHelpGuide_Click;
            // 
            // rtbSummary
            // 
            rtbSummary.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummary.BorderStyle = BorderStyle.None;
            rtbSummary.ForeColor = Color.Salmon;
            rtbSummary.Location = new Point(3, 70);
            rtbSummary.Name = "rtbSummary";
            rtbSummary.Size = new Size(462, 281);
            rtbSummary.TabIndex = 21;
            rtbSummary.Text = "";
            // 
            // panel2
            // 
            panel2.Controls.Add(lblDeleteStatusText);
            panel2.Controls.Add(lblNumberOfAssignmentsDeleted);
            panel2.Controls.Add(btnClearSummary);
            panel2.Controls.Add(rtbSummary);
            panel2.Location = new Point(627, 405);
            panel2.Name = "panel2";
            panel2.Size = new Size(468, 354);
            panel2.TabIndex = 22;
            // 
            // ViewAssignment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1114, 791);
            Controls.Add(panel2);
            Controls.Add(pbHelpGuide);
            Controls.Add(pbHome);
            Controls.Add(pnllViewAssignments);
            Controls.Add(pnlSearchApp);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ViewAssignment";
            pnlSearchApp.ResumeLayout(false);
            pnlSearchApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbClearDtgDisplayApp).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayApp).EndInit();
            pnllViewAssignments.ResumeLayout(false);
            pnllViewAssignments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbpbClearDtgGroupAssignment).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgGroupAssignment).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbHome).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbHelpGuide).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSearchApp;
        private TextBox txtboxSearchApp;
        private Button btnSearchApp;
        private Button btnAllGroups;
        private DataGridView dtgDisplayApp;
        private Panel pnllViewAssignments;
        private DataGridView dtgGroupAssignment;
        private PictureBox pbHome;
        private Label lblSearchApp;
        private PictureBox pbClearDtgDisplayApp;
        private PictureBox pbpbClearDtgGroupAssignment;
        private Button btnDeleteAllAssignments;
        private Label lblAppID;
        private Label lblAppName;
        private Button btnDeleteSelectedAssignment;
        private DataGridViewTextBoxColumn AppName;
        private DataGridViewTextBoxColumn Platform;
        private DataGridViewTextBoxColumn AppID;
        private DataGridViewTextBoxColumn GroupName;
        private DataGridViewTextBoxColumn Intent;
        private DataGridViewTextBoxColumn GroupID;
        private ToolTip mainFormToolTip;
        private Label label1;
        private PictureBox pbHelpGuide;
        private Button btnDeleteAssignmentForSelectedApps;
        private RichTextBox rtbSummary;
        private Panel panel2;
        private Button btnClearSummary;
        private Label lblNumberOfAssignmentsDeleted;
        private Label lblDeleteStatusText;
    }
}