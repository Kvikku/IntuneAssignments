namespace IntuneAssignments
{
    partial class ManagePolicyAssignments
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagePolicyAssignments));
            pbViewAssignments = new PictureBox();
            pnlPolicies = new Panel();
            btnDeleteAssignmentForSelectedPolicies = new Button();
            dtgDisplayPolicy = new DataGridView();
            PolicyName = new DataGridViewTextBoxColumn();
            Platform = new DataGridViewTextBoxColumn();
            PolicyPlatform = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            pbClearDtgDisplayPolicy = new PictureBox();
            txtboxSearchPolicy = new TextBox();
            lblSelectPolicies = new Label();
            btnListAllPolices = new Button();
            btnSearchPolicy = new Button();
            pnlAssignments = new Panel();
            lblPolicyType = new Label();
            lblViewAssignmentHeadline = new Label();
            btnDeleteAllAssignments = new Button();
            btnDeleteSelectedAssignment = new Button();
            lblPolicyID = new Label();
            pbpbClearDtgGroupAssignment = new PictureBox();
            lblPolicyName = new Label();
            dtgGroupAssignment = new DataGridView();
            GroupName = new DataGridViewTextBoxColumn();
            GroupID = new DataGridViewTextBoxColumn();
            lblWIP = new Label();
            pnlStatus = new Panel();
            rtbSummary = new RichTextBox();
            pBCalculate = new ProgressBar();
            lblNumberOfAssignmentsDeleted = new Label();
            lblDeleteStatusText = new Label();
            lblProgress = new Label();
            btnClearSummary = new Button();
            ((System.ComponentModel.ISupportInitialize)pbViewAssignments).BeginInit();
            pnlPolicies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayPolicy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbClearDtgDisplayPolicy).BeginInit();
            pnlAssignments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbpbClearDtgGroupAssignment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgGroupAssignment).BeginInit();
            pnlStatus.SuspendLayout();
            SuspendLayout();
            // 
            // pbViewAssignments
            // 
            pbViewAssignments.Image = Properties.Resources._46291024716276567993766_48;
            pbViewAssignments.InitialImage = Properties.Resources._121047815016345278514481_48;
            pbViewAssignments.Location = new Point(12, 12);
            pbViewAssignments.Name = "pbViewAssignments";
            pbViewAssignments.Size = new Size(64, 64);
            pbViewAssignments.SizeMode = PictureBoxSizeMode.StretchImage;
            pbViewAssignments.TabIndex = 12;
            pbViewAssignments.TabStop = false;
            pbViewAssignments.Click += pbViewAssignments_Click;
            // 
            // pnlPolicies
            // 
            pnlPolicies.BorderStyle = BorderStyle.FixedSingle;
            pnlPolicies.Controls.Add(btnDeleteAssignmentForSelectedPolicies);
            pnlPolicies.Controls.Add(dtgDisplayPolicy);
            pnlPolicies.Controls.Add(pbClearDtgDisplayPolicy);
            pnlPolicies.Controls.Add(txtboxSearchPolicy);
            pnlPolicies.Controls.Add(lblSelectPolicies);
            pnlPolicies.Controls.Add(btnListAllPolices);
            pnlPolicies.Controls.Add(btnSearchPolicy);
            pnlPolicies.Location = new Point(82, 12);
            pnlPolicies.Name = "pnlPolicies";
            pnlPolicies.Size = new Size(544, 724);
            pnlPolicies.TabIndex = 13;
            // 
            // btnDeleteAssignmentForSelectedPolicies
            // 
            btnDeleteAssignmentForSelectedPolicies.BackColor = Color.Salmon;
            btnDeleteAssignmentForSelectedPolicies.FlatStyle = FlatStyle.Popup;
            btnDeleteAssignmentForSelectedPolicies.Font = new Font("Consolas", 12F);
            btnDeleteAssignmentForSelectedPolicies.Location = new Point(251, 151);
            btnDeleteAssignmentForSelectedPolicies.Name = "btnDeleteAssignmentForSelectedPolicies";
            btnDeleteAssignmentForSelectedPolicies.Size = new Size(249, 30);
            btnDeleteAssignmentForSelectedPolicies.TabIndex = 22;
            btnDeleteAssignmentForSelectedPolicies.Text = "Delete assignments";
            btnDeleteAssignmentForSelectedPolicies.UseVisualStyleBackColor = false;
            btnDeleteAssignmentForSelectedPolicies.Click += btnDeleteAssignmentForSelectedPolicies_Click;
            // 
            // dtgDisplayPolicy
            // 
            dtgDisplayPolicy.AllowUserToAddRows = false;
            dtgDisplayPolicy.AllowUserToDeleteRows = false;
            dtgDisplayPolicy.AllowUserToResizeRows = false;
            dtgDisplayPolicy.BackgroundColor = Color.FromArgb(46, 51, 73);
            dtgDisplayPolicy.CellBorderStyle = DataGridViewCellBorderStyle.None;
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
            dtgDisplayPolicy.Columns.AddRange(new DataGridViewColumn[] { PolicyName, Platform, PolicyPlatform, ID });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Salmon;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgDisplayPolicy.DefaultCellStyle = dataGridViewCellStyle2;
            dtgDisplayPolicy.EnableHeadersVisualStyles = false;
            dtgDisplayPolicy.Location = new Point(12, 190);
            dtgDisplayPolicy.Name = "dtgDisplayPolicy";
            dtgDisplayPolicy.ReadOnly = true;
            dtgDisplayPolicy.RowHeadersVisible = false;
            dtgDisplayPolicy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDisplayPolicy.Size = new Size(574, 559);
            dtgDisplayPolicy.TabIndex = 21;
            dtgDisplayPolicy.CellDoubleClick += dtgDisplayPolicy_CellDoubleClick;
            // 
            // PolicyName
            // 
            PolicyName.HeaderText = "Policy Name";
            PolicyName.Name = "PolicyName";
            PolicyName.ReadOnly = true;
            PolicyName.Width = 350;
            // 
            // Platform
            // 
            Platform.HeaderText = "Platform";
            Platform.Name = "Platform";
            Platform.ReadOnly = true;
            Platform.Width = 190;
            // 
            // PolicyPlatform
            // 
            PolicyPlatform.HeaderText = "Policy Platform";
            PolicyPlatform.Name = "PolicyPlatform";
            PolicyPlatform.ReadOnly = true;
            // 
            // ID
            // 
            ID.HeaderText = "Policy ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // pbClearDtgDisplayPolicy
            // 
            pbClearDtgDisplayPolicy.Image = Properties.Resources._5358270771574330938_32;
            pbClearDtgDisplayPolicy.Location = new Point(506, 135);
            pbClearDtgDisplayPolicy.Name = "pbClearDtgDisplayPolicy";
            pbClearDtgDisplayPolicy.Size = new Size(36, 38);
            pbClearDtgDisplayPolicy.TabIndex = 20;
            pbClearDtgDisplayPolicy.TabStop = false;
            // 
            // txtboxSearchPolicy
            // 
            txtboxSearchPolicy.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchPolicy.Font = new Font("Consolas", 12F);
            txtboxSearchPolicy.ForeColor = Color.Salmon;
            txtboxSearchPolicy.Location = new Point(20, 119);
            txtboxSearchPolicy.Name = "txtboxSearchPolicy";
            txtboxSearchPolicy.Size = new Size(225, 26);
            txtboxSearchPolicy.TabIndex = 19;
            txtboxSearchPolicy.Text = "Enter search here";
            // 
            // lblSelectPolicies
            // 
            lblSelectPolicies.AutoSize = true;
            lblSelectPolicies.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSelectPolicies.ForeColor = Color.Salmon;
            lblSelectPolicies.Location = new Point(12, 11);
            lblSelectPolicies.Name = "lblSelectPolicies";
            lblSelectPolicies.Size = new Size(190, 24);
            lblSelectPolicies.TabIndex = 18;
            lblSelectPolicies.Text = "Select policies";
            // 
            // btnListAllPolices
            // 
            btnListAllPolices.BackColor = Color.Salmon;
            btnListAllPolices.FlatStyle = FlatStyle.Popup;
            btnListAllPolices.Font = new Font("Consolas", 12F);
            btnListAllPolices.Location = new Point(376, 115);
            btnListAllPolices.Name = "btnListAllPolices";
            btnListAllPolices.Size = new Size(124, 30);
            btnListAllPolices.TabIndex = 17;
            btnListAllPolices.Text = "List all";
            btnListAllPolices.UseVisualStyleBackColor = false;
            btnListAllPolices.Click += btnListAllPolices_Click;
            // 
            // btnSearchPolicy
            // 
            btnSearchPolicy.BackColor = Color.Salmon;
            btnSearchPolicy.FlatStyle = FlatStyle.Popup;
            btnSearchPolicy.Font = new Font("Consolas", 12F);
            btnSearchPolicy.Location = new Point(251, 115);
            btnSearchPolicy.Name = "btnSearchPolicy";
            btnSearchPolicy.Size = new Size(119, 30);
            btnSearchPolicy.TabIndex = 16;
            btnSearchPolicy.Text = "Search";
            btnSearchPolicy.UseVisualStyleBackColor = false;
            btnSearchPolicy.Click += btnSearchPolicy_Click;
            // 
            // pnlAssignments
            // 
            pnlAssignments.BorderStyle = BorderStyle.FixedSingle;
            pnlAssignments.Controls.Add(lblPolicyType);
            pnlAssignments.Controls.Add(lblViewAssignmentHeadline);
            pnlAssignments.Controls.Add(btnDeleteAllAssignments);
            pnlAssignments.Controls.Add(btnDeleteSelectedAssignment);
            pnlAssignments.Controls.Add(lblPolicyID);
            pnlAssignments.Controls.Add(pbpbClearDtgGroupAssignment);
            pnlAssignments.Controls.Add(lblPolicyName);
            pnlAssignments.Controls.Add(dtgGroupAssignment);
            pnlAssignments.Location = new Point(632, 12);
            pnlAssignments.Name = "pnlAssignments";
            pnlAssignments.Size = new Size(470, 404);
            pnlAssignments.TabIndex = 14;
            // 
            // lblPolicyType
            // 
            lblPolicyType.AutoSize = true;
            lblPolicyType.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblPolicyType.ForeColor = Color.Salmon;
            lblPolicyType.Location = new Point(7, 90);
            lblPolicyType.Name = "lblPolicyType";
            lblPolicyType.Size = new Size(126, 19);
            lblPolicyType.TabIndex = 29;
            lblPolicyType.Text = "{Policy Type}";
            // 
            // lblViewAssignmentHeadline
            // 
            lblViewAssignmentHeadline.AutoSize = true;
            lblViewAssignmentHeadline.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblViewAssignmentHeadline.ForeColor = Color.Salmon;
            lblViewAssignmentHeadline.Location = new Point(7, 11);
            lblViewAssignmentHeadline.Name = "lblViewAssignmentHeadline";
            lblViewAssignmentHeadline.Size = new Size(358, 24);
            lblViewAssignmentHeadline.TabIndex = 23;
            lblViewAssignmentHeadline.Text = "View and delete assignment(s)";
            // 
            // btnDeleteAllAssignments
            // 
            btnDeleteAllAssignments.BackColor = Color.Salmon;
            btnDeleteAllAssignments.FlatStyle = FlatStyle.Popup;
            btnDeleteAllAssignments.Font = new Font("Consolas", 12F);
            btnDeleteAllAssignments.Location = new Point(264, 119);
            btnDeleteAllAssignments.Name = "btnDeleteAllAssignments";
            btnDeleteAllAssignments.Size = new Size(152, 30);
            btnDeleteAllAssignments.TabIndex = 24;
            btnDeleteAllAssignments.Text = "Delete all";
            btnDeleteAllAssignments.UseVisualStyleBackColor = false;
            btnDeleteAllAssignments.Click += btnDeleteAllAssignments_Click;
            // 
            // btnDeleteSelectedAssignment
            // 
            btnDeleteSelectedAssignment.BackColor = Color.Salmon;
            btnDeleteSelectedAssignment.FlatStyle = FlatStyle.Popup;
            btnDeleteSelectedAssignment.Font = new Font("Consolas", 12F);
            btnDeleteSelectedAssignment.Location = new Point(106, 119);
            btnDeleteSelectedAssignment.Name = "btnDeleteSelectedAssignment";
            btnDeleteSelectedAssignment.Size = new Size(152, 30);
            btnDeleteSelectedAssignment.TabIndex = 26;
            btnDeleteSelectedAssignment.Text = "Delete selected";
            btnDeleteSelectedAssignment.UseVisualStyleBackColor = false;
            btnDeleteSelectedAssignment.Click += btnDeleteSelectedAssignment_Click;
            // 
            // lblPolicyID
            // 
            lblPolicyID.AutoSize = true;
            lblPolicyID.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblPolicyID.ForeColor = Color.Salmon;
            lblPolicyID.Location = new Point(7, 71);
            lblPolicyID.Name = "lblPolicyID";
            lblPolicyID.Size = new Size(108, 19);
            lblPolicyID.TabIndex = 28;
            lblPolicyID.Text = "{Policy ID}";
            // 
            // pbpbClearDtgGroupAssignment
            // 
            pbpbClearDtgGroupAssignment.Image = Properties.Resources._5358270771574330938_32;
            pbpbClearDtgGroupAssignment.Location = new Point(422, 110);
            pbpbClearDtgGroupAssignment.Name = "pbpbClearDtgGroupAssignment";
            pbpbClearDtgGroupAssignment.Size = new Size(36, 38);
            pbpbClearDtgGroupAssignment.TabIndex = 25;
            pbpbClearDtgGroupAssignment.TabStop = false;
            // 
            // lblPolicyName
            // 
            lblPolicyName.AutoSize = true;
            lblPolicyName.Font = new Font("Consolas", 14.25F, FontStyle.Bold);
            lblPolicyName.ForeColor = Color.Salmon;
            lblPolicyName.Location = new Point(7, 49);
            lblPolicyName.Name = "lblPolicyName";
            lblPolicyName.Size = new Size(140, 22);
            lblPolicyName.TabIndex = 27;
            lblPolicyName.Text = "{Policy NAME}";
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
            dtgGroupAssignment.Columns.AddRange(new DataGridViewColumn[] { GroupName, GroupID });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = Color.Salmon;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dtgGroupAssignment.DefaultCellStyle = dataGridViewCellStyle4;
            dtgGroupAssignment.EnableHeadersVisualStyles = false;
            dtgGroupAssignment.Location = new Point(7, 155);
            dtgGroupAssignment.Name = "dtgGroupAssignment";
            dtgGroupAssignment.ReadOnly = true;
            dtgGroupAssignment.RowHeadersVisible = false;
            dtgGroupAssignment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgGroupAssignment.Size = new Size(455, 272);
            dtgGroupAssignment.TabIndex = 22;
            // 
            // GroupName
            // 
            GroupName.HeaderText = "Group name";
            GroupName.Name = "GroupName";
            GroupName.ReadOnly = true;
            GroupName.Width = 300;
            // 
            // GroupID
            // 
            GroupID.HeaderText = "Group ID";
            GroupID.Name = "GroupID";
            GroupID.ReadOnly = true;
            GroupID.Width = 300;
            // 
            // lblWIP
            // 
            lblWIP.AutoSize = true;
            lblWIP.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWIP.ForeColor = Color.Yellow;
            lblWIP.Location = new Point(361, 765);
            lblWIP.Name = "lblWIP";
            lblWIP.Size = new Size(430, 32);
            lblWIP.TabIndex = 15;
            lblWIP.Text = "THIS PAGE IS A WORK IN PROGRESS";
            // 
            // pnlStatus
            // 
            pnlStatus.BorderStyle = BorderStyle.FixedSingle;
            pnlStatus.Controls.Add(rtbSummary);
            pnlStatus.Controls.Add(pBCalculate);
            pnlStatus.Controls.Add(lblNumberOfAssignmentsDeleted);
            pnlStatus.Controls.Add(lblDeleteStatusText);
            pnlStatus.Controls.Add(lblProgress);
            pnlStatus.Controls.Add(btnClearSummary);
            pnlStatus.Location = new Point(632, 422);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(470, 314);
            pnlStatus.TabIndex = 16;
            // 
            // rtbSummary
            // 
            rtbSummary.BackColor = Color.FromArgb(46, 51, 73);
            rtbSummary.BorderStyle = BorderStyle.None;
            rtbSummary.ForeColor = Color.Salmon;
            rtbSummary.Location = new Point(8, 113);
            rtbSummary.Name = "rtbSummary";
            rtbSummary.ReadOnly = true;
            rtbSummary.Size = new Size(451, 189);
            rtbSummary.TabIndex = 34;
            rtbSummary.Text = "";
            // 
            // pBCalculate
            // 
            pBCalculate.Location = new Point(8, 33);
            pBCalculate.Name = "pBCalculate";
            pBCalculate.Size = new Size(283, 23);
            pBCalculate.TabIndex = 33;
            // 
            // lblNumberOfAssignmentsDeleted
            // 
            lblNumberOfAssignmentsDeleted.AutoSize = true;
            lblNumberOfAssignmentsDeleted.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblNumberOfAssignmentsDeleted.ForeColor = Color.Salmon;
            lblNumberOfAssignmentsDeleted.Location = new Point(3, 78);
            lblNumberOfAssignmentsDeleted.Name = "lblNumberOfAssignmentsDeleted";
            lblNumberOfAssignmentsDeleted.Size = new Size(288, 19);
            lblNumberOfAssignmentsDeleted.TabIndex = 32;
            lblNumberOfAssignmentsDeleted.Text = "{NUMBER OF DELETED ASSIGNMENTS}";
            // 
            // lblDeleteStatusText
            // 
            lblDeleteStatusText.AutoSize = true;
            lblDeleteStatusText.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblDeleteStatusText.ForeColor = Color.Salmon;
            lblDeleteStatusText.Location = new Point(3, 59);
            lblDeleteStatusText.Name = "lblDeleteStatusText";
            lblDeleteStatusText.Size = new Size(189, 19);
            lblDeleteStatusText.TabIndex = 31;
            lblDeleteStatusText.Text = "Assignments deleted:";
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblProgress.ForeColor = Color.Salmon;
            lblProgress.Location = new Point(8, 12);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(81, 19);
            lblProgress.TabIndex = 30;
            lblProgress.Text = "Progress";
            // 
            // btnClearSummary
            // 
            btnClearSummary.BackColor = Color.Salmon;
            btnClearSummary.FlatStyle = FlatStyle.Popup;
            btnClearSummary.Font = new Font("Consolas", 12F);
            btnClearSummary.Location = new Point(307, 53);
            btnClearSummary.Name = "btnClearSummary";
            btnClearSummary.Size = new Size(152, 30);
            btnClearSummary.TabIndex = 30;
            btnClearSummary.Text = "Clear summary";
            btnClearSummary.UseVisualStyleBackColor = false;
            btnClearSummary.Click += btnClearSummary_Click;
            // 
            // ManagePolicyAssignments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1114, 836);
            Controls.Add(pnlStatus);
            Controls.Add(lblWIP);
            Controls.Add(pnlAssignments);
            Controls.Add(pnlPolicies);
            Controls.Add(pbViewAssignments);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ManagePolicyAssignments";
            Text = "ManagePolicyAssignments";
            ((System.ComponentModel.ISupportInitialize)pbViewAssignments).EndInit();
            pnlPolicies.ResumeLayout(false);
            pnlPolicies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayPolicy).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbClearDtgDisplayPolicy).EndInit();
            pnlAssignments.ResumeLayout(false);
            pnlAssignments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbpbClearDtgGroupAssignment).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgGroupAssignment).EndInit();
            pnlStatus.ResumeLayout(false);
            pnlStatus.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbViewAssignments;
        private Panel pnlPolicies;
        private Panel pnlAssignments;
        private Button btnSearchPolicy;
        private Button btnListAllPolices;
        private Label lblSelectPolicies;
        private TextBox txtboxSearchPolicy;
        private PictureBox pbClearDtgDisplayPolicy;
        private DataGridView dtgDisplayPolicy;
        private Label lblViewAssignmentHeadline;
        private Button btnDeleteAllAssignments;
        private Button btnDeleteSelectedAssignment;
        private Label lblPolicyID;
        private PictureBox pbpbClearDtgGroupAssignment;
        private Label lblPolicyName;
        private DataGridView dtgGroupAssignment;
        private DataGridViewTextBoxColumn PolicyName;
        private DataGridViewTextBoxColumn Platform;
        private DataGridViewTextBoxColumn PolicyPlatform;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn GroupName;
        private DataGridViewTextBoxColumn GroupID;
        private Label lblPolicyType;
        private Label lblWIP;
        private Panel pnlStatus;
        private Label lblProgress;
        private Button btnClearSummary;
        private Label lblNumberOfAssignmentsDeleted;
        private Label lblDeleteStatusText;
        private ProgressBar pBCalculate;
        private RichTextBox rtbSummary;
        private Button btnDeleteAssignmentForSelectedPolicies;
    }
}