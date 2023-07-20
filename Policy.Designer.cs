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
            btnListAllPolicy = new Button();
            btnSearchPolicy = new Button();
            txtboxSearchPolicy = new TextBox();
            cbPolicyType = new ComboBox();
            dtgDisplayGroup = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            btnListAllGroups = new Button();
            btnSearchGroup = new Button();
            txtboxSearchGroup = new TextBox();
            rtbAssignmentPreview = new RichTextBox();
            pnlAssignedTo = new Panel();
            lblAssignmentPreview = new Label();
            panel2 = new Panel();
            rtbDeploymentSummary = new RichTextBox();
            pBarDeployProgress = new ProgressBar();
            rtbSelectedGroups = new RichTextBox();
            rtbSelectedPolicies = new RichTextBox();
            lblSelectedGroups = new Label();
            btnDeployPolicyAssignment = new Button();
            btnResetDeployment = new Button();
            lblSelectedPolicies = new Label();
            btnPrepareDeployment = new Button();
            cbLookUpAssignment = new CheckBox();
            pnlSearchGroup = new Panel();
            lblSelectGroups = new Label();
            toolTipPolicy = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pbHome).BeginInit();
            pnlSearchPolicy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayPolicy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).BeginInit();
            pnlAssignedTo.SuspendLayout();
            panel2.SuspendLayout();
            pnlSearchGroup.SuspendLayout();
            SuspendLayout();
            // 
            // pbHome
            // 
            pbHome.Image = Properties.Resources._15536420761558096328_48;
            pbHome.Location = new Point(12, 12);
            pbHome.Name = "pbHome";
            pbHome.Size = new Size(49, 51);
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
            pnlSearchPolicy.Location = new Point(97, 12);
            pnlSearchPolicy.Name = "pnlSearchPolicy";
            pnlSearchPolicy.Size = new Size(795, 468);
            pnlSearchPolicy.TabIndex = 1;
            // 
            // lblSelectApps
            // 
            lblSelectApps.AutoSize = true;
            lblSelectApps.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
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
            dataGridViewCellStyle1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgDisplayPolicy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgDisplayPolicy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayPolicy.Columns.AddRange(new DataGridViewColumn[] { PolicyName, Type, Platform, ID });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
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
            dtgDisplayPolicy.RowTemplate.Height = 25;
            dtgDisplayPolicy.Size = new Size(781, 404);
            dtgDisplayPolicy.TabIndex = 4;
            dtgDisplayPolicy.CellClick += dtgDisplayPolicy_CellClick;
            // 
            // PolicyName
            // 
            PolicyName.HeaderText = "Name";
            PolicyName.Name = "PolicyName";
            PolicyName.ReadOnly = true;
            PolicyName.Width = 400;
            // 
            // Type
            // 
            Type.HeaderText = "Type";
            Type.Name = "Type";
            Type.ReadOnly = true;
            Type.Width = 200;
            // 
            // Platform
            // 
            Platform.HeaderText = "Platform";
            Platform.Name = "Platform";
            Platform.ReadOnly = true;
            Platform.Width = 200;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // btnListAllPolicy
            // 
            btnListAllPolicy.BackColor = Color.Salmon;
            btnListAllPolicy.FlatStyle = FlatStyle.Flat;
            btnListAllPolicy.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
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
            btnSearchPolicy.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchPolicy.Location = new Point(528, 42);
            btnSearchPolicy.Name = "btnSearchPolicy";
            btnSearchPolicy.Size = new Size(128, 41);
            btnSearchPolicy.TabIndex = 2;
            btnSearchPolicy.Text = "Search";
            toolTipPolicy.SetToolTip(btnSearchPolicy, "Search for applications");
            btnSearchPolicy.UseVisualStyleBackColor = false;

            // 
            // txtboxSearchPolicy
            // 
            txtboxSearchPolicy.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchPolicy.BorderStyle = BorderStyle.FixedSingle;
            txtboxSearchPolicy.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxSearchPolicy.ForeColor = Color.Salmon;
            txtboxSearchPolicy.Location = new Point(188, 49);
            txtboxSearchPolicy.Name = "txtboxSearchPolicy";
            txtboxSearchPolicy.Size = new Size(186, 26);
            txtboxSearchPolicy.TabIndex = 1;
            txtboxSearchPolicy.Text = "Enter search here";
            toolTipPolicy.SetToolTip(txtboxSearchPolicy, "Enter search query here");
            // 
            // cbPolicyType
            // 
            cbPolicyType.BackColor = Color.FromArgb(46, 51, 73);
            cbPolicyType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPolicyType.FlatStyle = FlatStyle.Popup;
            cbPolicyType.FormattingEnabled = true;
            cbPolicyType.Items.AddRange(new object[] { "All types", "Compliance policy", "Administrative templates", "Settings catalog" });
            cbPolicyType.Location = new Point(9, 51);
            cbPolicyType.Name = "cbPolicyType";
            cbPolicyType.Size = new Size(163, 23);
            cbPolicyType.TabIndex = 0;
            toolTipPolicy.SetToolTip(cbPolicyType, "Filter on type");
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
            dtgDisplayGroup.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
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
            dtgDisplayGroup.RowTemplate.Height = 25;
            dtgDisplayGroup.Size = new Size(628, 401);
            dtgDisplayGroup.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Group name";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 420;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Group ID";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 300;
            // 
            // btnListAllGroups
            // 
            btnListAllGroups.BackColor = Color.Salmon;
            btnListAllGroups.FlatStyle = FlatStyle.Flat;
            btnListAllGroups.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
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
            btnSearchGroup.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchGroup.Location = new Point(369, 42);
            btnSearchGroup.Name = "btnSearchGroup";
            btnSearchGroup.Size = new Size(128, 41);
            btnSearchGroup.TabIndex = 7;
            btnSearchGroup.Text = "Search";
            toolTipPolicy.SetToolTip(btnSearchGroup, "Search for groups");
            btnSearchGroup.UseVisualStyleBackColor = false;

            // 
            // txtboxSearchGroup
            // 
            txtboxSearchGroup.BackColor = Color.FromArgb(46, 51, 73);
            txtboxSearchGroup.BorderStyle = BorderStyle.FixedSingle;
            txtboxSearchGroup.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxSearchGroup.ForeColor = Color.Salmon;
            txtboxSearchGroup.Location = new Point(3, 57);
            txtboxSearchGroup.Name = "txtboxSearchGroup";
            txtboxSearchGroup.Size = new Size(162, 26);
            txtboxSearchGroup.TabIndex = 6;
            txtboxSearchGroup.Text = "Enter search here";
            toolTipPolicy.SetToolTip(txtboxSearchGroup, "Enter search query here");
            // 
            // rtbAssignmentPreview
            // 
            rtbAssignmentPreview.BackColor = Color.FromArgb(46, 51, 73);
            rtbAssignmentPreview.BorderStyle = BorderStyle.None;
            rtbAssignmentPreview.ForeColor = Color.Salmon;
            rtbAssignmentPreview.Location = new Point(3, 38);
            rtbAssignmentPreview.Name = "rtbAssignmentPreview";
            rtbAssignmentPreview.Size = new Size(234, 159);
            rtbAssignmentPreview.TabIndex = 2;
            rtbAssignmentPreview.Text = "";
            // 
            // pnlAssignedTo
            // 
            pnlAssignedTo.Controls.Add(lblAssignmentPreview);
            pnlAssignedTo.Controls.Add(rtbAssignmentPreview);
            pnlAssignedTo.Location = new Point(1547, 45);
            pnlAssignedTo.Name = "pnlAssignedTo";
            pnlAssignedTo.Size = new Size(357, 217);
            pnlAssignedTo.TabIndex = 3;
            // 
            // lblAssignmentPreview
            // 
            lblAssignmentPreview.AutoSize = true;
            lblAssignmentPreview.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblAssignmentPreview.ForeColor = Color.Salmon;
            lblAssignmentPreview.Location = new Point(3, 14);
            lblAssignmentPreview.Name = "lblAssignmentPreview";
            lblAssignmentPreview.Size = new Size(103, 21);
            lblAssignmentPreview.TabIndex = 3;
            lblAssignmentPreview.Text = "Assigned to:";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(rtbDeploymentSummary);
            panel2.Controls.Add(pBarDeployProgress);
            panel2.Controls.Add(rtbSelectedGroups);
            panel2.Controls.Add(rtbSelectedPolicies);
            panel2.Controls.Add(lblSelectedGroups);
            panel2.Controls.Add(btnDeployPolicyAssignment);
            panel2.Controls.Add(btnResetDeployment);
            panel2.Controls.Add(lblSelectedPolicies);
            panel2.Controls.Add(btnPrepareDeployment);
            panel2.Location = new Point(97, 500);
            panel2.Name = "panel2";
            panel2.Size = new Size(1444, 384);
            panel2.TabIndex = 4;
            // 
            // rtbDeploymentSummary
            // 
            rtbDeploymentSummary.BackColor = Color.FromArgb(46, 51, 73);
            rtbDeploymentSummary.BorderStyle = BorderStyle.None;
            rtbDeploymentSummary.ForeColor = Color.Salmon;
            rtbDeploymentSummary.Location = new Point(893, 148);
            rtbDeploymentSummary.Name = "rtbDeploymentSummary";
            rtbDeploymentSummary.Size = new Size(539, 224);
            rtbDeploymentSummary.TabIndex = 9;
            rtbDeploymentSummary.Text = "";
            toolTipPolicy.SetToolTip(rtbDeploymentSummary, "Output from the deployment process");
            rtbDeploymentSummary.WordWrap = false;
            // 
            // pBarDeployProgress
            // 
            pBarDeployProgress.Location = new Point(893, 67);
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
            rtbSelectedGroups.Location = new Point(514, 139);
            rtbSelectedGroups.Name = "rtbSelectedGroups";
            rtbSelectedGroups.Size = new Size(373, 224);
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
            rtbSelectedPolicies.Size = new Size(450, 224);
            rtbSelectedPolicies.TabIndex = 5;
            rtbSelectedPolicies.Text = "";
            toolTipPolicy.SetToolTip(rtbSelectedPolicies, "The applications that will be used for deployment");
            rtbSelectedPolicies.WordWrap = false;
            // 
            // lblSelectedGroups
            // 
            lblSelectedGroups.AutoSize = true;
            lblSelectedGroups.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelectedGroups.ForeColor = Color.Salmon;
            lblSelectedGroups.Location = new Point(514, 92);
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
            btnDeployPolicyAssignment.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeployPolicyAssignment.Location = new Point(893, 3);
            btnDeployPolicyAssignment.Name = "btnDeployPolicyAssignment";
            btnDeployPolicyAssignment.Size = new Size(292, 58);
            btnDeployPolicyAssignment.TabIndex = 5;
            btnDeployPolicyAssignment.Text = "Deploy";
            toolTipPolicy.SetToolTip(btnDeployPolicyAssignment, "Initiate deployment");
            btnDeployPolicyAssignment.UseVisualStyleBackColor = false;
            btnDeployPolicyAssignment.Click += btnDeployPolicyAssignment_Click;
            // 
            // btnResetDeployment
            // 
            btnResetDeployment.BackColor = Color.Salmon;
            btnResetDeployment.FlatStyle = FlatStyle.Flat;
            btnResetDeployment.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnResetDeployment.Location = new Point(235, 3);
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
            lblSelectedPolicies.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnPrepareDeployment.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrepareDeployment.Location = new Point(9, 3);
            btnPrepareDeployment.Name = "btnPrepareDeployment";
            btnPrepareDeployment.Size = new Size(220, 58);
            btnPrepareDeployment.TabIndex = 6;
            btnPrepareDeployment.Text = "Prepare deployment";
            toolTipPolicy.SetToolTip(btnPrepareDeployment, "Click to prepare selected applications and groups for deployment");
            btnPrepareDeployment.UseVisualStyleBackColor = false;
            btnPrepareDeployment.Click += btnPrepareDeployment_Click;
            // 
            // cbLookUpAssignment
            // 
            cbLookUpAssignment.AutoSize = true;
            cbLookUpAssignment.ForeColor = Color.Salmon;
            cbLookUpAssignment.Location = new Point(1550, 12);
            cbLookUpAssignment.Name = "cbLookUpAssignment";
            cbLookUpAssignment.Size = new Size(212, 19);
            cbLookUpAssignment.TabIndex = 8;
            cbLookUpAssignment.Text = "Look up policy assignment on click";
            toolTipPolicy.SetToolTip(cbLookUpAssignment, "Enable to look up existing assignments for policies when clicking them");
            cbLookUpAssignment.UseVisualStyleBackColor = true;

            // 
            // pnlSearchGroup
            // 
            pnlSearchGroup.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchGroup.Controls.Add(lblSelectGroups);
            pnlSearchGroup.Controls.Add(dtgDisplayGroup);
            pnlSearchGroup.Controls.Add(txtboxSearchGroup);
            pnlSearchGroup.Controls.Add(btnListAllGroups);
            pnlSearchGroup.Controls.Add(btnSearchGroup);
            pnlSearchGroup.Location = new Point(898, 12);
            pnlSearchGroup.Name = "pnlSearchGroup";
            pnlSearchGroup.Size = new Size(643, 468);
            pnlSearchGroup.TabIndex = 9;
            // 
            // lblSelectGroups
            // 
            lblSelectGroups.AutoSize = true;
            lblSelectGroups.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelectGroups.ForeColor = Color.Salmon;
            lblSelectGroups.Location = new Point(3, 10);
            lblSelectGroups.Name = "lblSelectGroups";
            lblSelectGroups.Size = new Size(82, 24);
            lblSelectGroups.TabIndex = 11;
            lblSelectGroups.Text = "Groups";
            toolTipPolicy.SetToolTip(lblSelectGroups, "Selected policies");
            // 
            // Policy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1912, 901);
            Controls.Add(pnlSearchGroup);
            Controls.Add(cbLookUpAssignment);
            Controls.Add(panel2);
            Controls.Add(pnlAssignedTo);
            Controls.Add(pnlSearchPolicy);
            Controls.Add(pbHome);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Policy";
            Load += Policy_Load;
            ((System.ComponentModel.ISupportInitialize)pbHome).EndInit();
            pnlSearchPolicy.ResumeLayout(false);
            pnlSearchPolicy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayPolicy).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).EndInit();
            pnlAssignedTo.ResumeLayout(false);
            pnlAssignedTo.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlSearchGroup.ResumeLayout(false);
            pnlSearchGroup.PerformLayout();
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
        private Panel panel2;
        private Label lblSelectedGroups;
        private Label lblSelectedPolicies;
        private RichTextBox rtbSelectedGroups;
        private RichTextBox rtbSelectedPolicies;
        private Button btnDeployPolicyAssignment;
        private Button btnPrepareDeployment;
        private Button btnResetDeployment;
        private CheckBox cbLookUpAssignment;
        private Panel pnlSearchGroup;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private ProgressBar pBarDeployProgress;
        private RichTextBox rtbDeploymentSummary;
        private DataGridViewTextBoxColumn PolicyName;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Platform;
        private DataGridViewTextBoxColumn ID;
        private ToolTip toolTipPolicy;
        private Label lblSelectApps;
        private Label lblSelectGroups;
    }
}