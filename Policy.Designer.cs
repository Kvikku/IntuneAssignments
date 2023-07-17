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
            pbHome = new PictureBox();
            pnlSearchPolicy = new Panel();
            dtgDisplayGroup = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            btnListAllGroups = new Button();
            btnSearchGroup = new Button();
            txtboxSearchGroup = new TextBox();
            dtgDisplayPolicy = new DataGridView();
            PolicyName = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            Platform = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            btnListAllPolicy = new Button();
            btnSearchPolicy = new Button();
            txtboxSearchPolicy = new TextBox();
            cbPolicyType = new ComboBox();
            rtbAssignmentPreview = new RichTextBox();
            panel1 = new Panel();
            lblAssignmentPreview = new Label();
            panel2 = new Panel();
            rtbSelectedGroups = new RichTextBox();
            rtbSelectedPolicies = new RichTextBox();
            lblSelectedGroups = new Label();
            lblSelectedPolicies = new Label();
            btnDeployPolicyAssignment = new Button();
            btnPrepareDeployment = new Button();
            btnResetDeployment = new Button();
            cbLookUpAssignment = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pbHome).BeginInit();
            pnlSearchPolicy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayPolicy).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            pbHome.Click += pbHome_Click;
            // 
            // pnlSearchPolicy
            // 
            pnlSearchPolicy.Controls.Add(dtgDisplayGroup);
            pnlSearchPolicy.Controls.Add(btnListAllGroups);
            pnlSearchPolicy.Controls.Add(btnSearchGroup);
            pnlSearchPolicy.Controls.Add(txtboxSearchGroup);
            pnlSearchPolicy.Controls.Add(dtgDisplayPolicy);
            pnlSearchPolicy.Controls.Add(btnListAllPolicy);
            pnlSearchPolicy.Controls.Add(btnSearchPolicy);
            pnlSearchPolicy.Controls.Add(txtboxSearchPolicy);
            pnlSearchPolicy.Controls.Add(cbPolicyType);
            pnlSearchPolicy.Location = new Point(97, 12);
            pnlSearchPolicy.Name = "pnlSearchPolicy";
            pnlSearchPolicy.Size = new Size(613, 879);
            pnlSearchPolicy.TabIndex = 1;
            // 
            // dtgDisplayGroup
            // 
            dtgDisplayGroup.AllowUserToAddRows = false;
            dtgDisplayGroup.AllowUserToDeleteRows = false;
            dtgDisplayGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayGroup.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dtgDisplayGroup.Location = new Point(3, 526);
            dtgDisplayGroup.Name = "dtgDisplayGroup";
            dtgDisplayGroup.ReadOnly = true;
            dtgDisplayGroup.RowHeadersVisible = false;
            dtgDisplayGroup.RowTemplate.Height = 25;
            dtgDisplayGroup.Size = new Size(604, 350);
            dtgDisplayGroup.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Group name";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 300;
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
            btnListAllGroups.Location = new Point(432, 479);
            btnListAllGroups.Name = "btnListAllGroups";
            btnListAllGroups.Size = new Size(128, 41);
            btnListAllGroups.TabIndex = 8;
            btnListAllGroups.Text = "List all";
            btnListAllGroups.UseVisualStyleBackColor = true;
            btnListAllGroups.Click += btnListAllGroups_Click;
            // 
            // btnSearchGroup
            // 
            btnSearchGroup.Location = new Point(298, 479);
            btnSearchGroup.Name = "btnSearchGroup";
            btnSearchGroup.Size = new Size(128, 41);
            btnSearchGroup.TabIndex = 7;
            btnSearchGroup.Text = "Search";
            btnSearchGroup.UseVisualStyleBackColor = true;
            // 
            // txtboxSearchGroup
            // 
            txtboxSearchGroup.Location = new Point(3, 497);
            txtboxSearchGroup.Name = "txtboxSearchGroup";
            txtboxSearchGroup.Size = new Size(162, 23);
            txtboxSearchGroup.TabIndex = 6;
            txtboxSearchGroup.Text = "Enter search query here";
            // 
            // dtgDisplayPolicy
            // 
            dtgDisplayPolicy.AllowUserToAddRows = false;
            dtgDisplayPolicy.AllowUserToDeleteRows = false;
            dtgDisplayPolicy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayPolicy.Columns.AddRange(new DataGridViewColumn[] { PolicyName, Type, Platform, ID });
            dtgDisplayPolicy.Location = new Point(3, 98);
            dtgDisplayPolicy.Name = "dtgDisplayPolicy";
            dtgDisplayPolicy.ReadOnly = true;
            dtgDisplayPolicy.RowHeadersVisible = false;
            dtgDisplayPolicy.RowTemplate.Height = 25;
            dtgDisplayPolicy.Size = new Size(604, 350);
            dtgDisplayPolicy.TabIndex = 4;
            dtgDisplayPolicy.CellClick += dtgDisplayPolicy_CellClick;
            // 
            // PolicyName
            // 
            PolicyName.HeaderText = "Name";
            PolicyName.Name = "PolicyName";
            PolicyName.ReadOnly = true;
            PolicyName.Width = 200;
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
            btnListAllPolicy.Location = new Point(432, 33);
            btnListAllPolicy.Name = "btnListAllPolicy";
            btnListAllPolicy.Size = new Size(128, 41);
            btnListAllPolicy.TabIndex = 3;
            btnListAllPolicy.Text = "List all";
            btnListAllPolicy.UseVisualStyleBackColor = true;
            btnListAllPolicy.Click += btnListAllPolicy_Click;
            // 
            // btnSearchPolicy
            // 
            btnSearchPolicy.Location = new Point(298, 33);
            btnSearchPolicy.Name = "btnSearchPolicy";
            btnSearchPolicy.Size = new Size(128, 41);
            btnSearchPolicy.TabIndex = 2;
            btnSearchPolicy.Text = "Search";
            btnSearchPolicy.UseVisualStyleBackColor = true;
            // 
            // txtboxSearchPolicy
            // 
            txtboxSearchPolicy.Location = new Point(130, 51);
            txtboxSearchPolicy.Name = "txtboxSearchPolicy";
            txtboxSearchPolicy.Size = new Size(162, 23);
            txtboxSearchPolicy.TabIndex = 1;
            txtboxSearchPolicy.Text = "Enter search query here";
            // 
            // cbPolicyType
            // 
            cbPolicyType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPolicyType.FormattingEnabled = true;
            cbPolicyType.Items.AddRange(new object[] { "All", "Compliance", "Option 1", "Option 2" });
            cbPolicyType.Location = new Point(3, 51);
            cbPolicyType.Name = "cbPolicyType";
            cbPolicyType.Size = new Size(121, 23);
            cbPolicyType.TabIndex = 0;
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
            // panel1
            // 
            panel1.Controls.Add(lblAssignmentPreview);
            panel1.Controls.Add(rtbAssignmentPreview);
            panel1.Location = new Point(725, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(382, 307);
            panel1.TabIndex = 3;
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
            panel2.Controls.Add(rtbSelectedGroups);
            panel2.Controls.Add(rtbSelectedPolicies);
            panel2.Controls.Add(lblSelectedGroups);
            panel2.Controls.Add(lblSelectedPolicies);
            panel2.Location = new Point(725, 356);
            panel2.Name = "panel2";
            panel2.Size = new Size(382, 532);
            panel2.TabIndex = 4;
            // 
            // rtbSelectedGroups
            // 
            rtbSelectedGroups.BackColor = Color.FromArgb(46, 51, 73);
            rtbSelectedGroups.BorderStyle = BorderStyle.None;
            rtbSelectedGroups.Location = new Point(6, 341);
            rtbSelectedGroups.Name = "rtbSelectedGroups";
            rtbSelectedGroups.Size = new Size(357, 163);
            rtbSelectedGroups.TabIndex = 6;
            rtbSelectedGroups.Text = "";
            // 
            // rtbSelectedPolicies
            // 
            rtbSelectedPolicies.BackColor = Color.FromArgb(46, 51, 73);
            rtbSelectedPolicies.BorderStyle = BorderStyle.None;
            rtbSelectedPolicies.Location = new Point(3, 104);
            rtbSelectedPolicies.Name = "rtbSelectedPolicies";
            rtbSelectedPolicies.Size = new Size(357, 163);
            rtbSelectedPolicies.TabIndex = 5;
            rtbSelectedPolicies.Text = "";
            // 
            // lblSelectedGroups
            // 
            lblSelectedGroups.AutoSize = true;
            lblSelectedGroups.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelectedGroups.ForeColor = Color.Salmon;
            lblSelectedGroups.Location = new Point(6, 286);
            lblSelectedGroups.Name = "lblSelectedGroups";
            lblSelectedGroups.Size = new Size(133, 21);
            lblSelectedGroups.TabIndex = 5;
            lblSelectedGroups.Text = "Selected Groups";
            // 
            // lblSelectedPolicies
            // 
            lblSelectedPolicies.AutoSize = true;
            lblSelectedPolicies.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelectedPolicies.ForeColor = Color.Salmon;
            lblSelectedPolicies.Location = new Point(6, 50);
            lblSelectedPolicies.Name = "lblSelectedPolicies";
            lblSelectedPolicies.Size = new Size(138, 21);
            lblSelectedPolicies.TabIndex = 4;
            lblSelectedPolicies.Text = "Selected policies";
            // 
            // btnDeployPolicyAssignment
            // 
            btnDeployPolicyAssignment.Location = new Point(1134, 474);
            btnDeployPolicyAssignment.Name = "btnDeployPolicyAssignment";
            btnDeployPolicyAssignment.Size = new Size(167, 58);
            btnDeployPolicyAssignment.TabIndex = 5;
            btnDeployPolicyAssignment.Text = "Deploy";
            btnDeployPolicyAssignment.UseVisualStyleBackColor = true;
            btnDeployPolicyAssignment.Click += btnDeployPolicyAssignment_Click;
            // 
            // btnPrepareDeployment
            // 
            btnPrepareDeployment.Location = new Point(1134, 356);
            btnPrepareDeployment.Name = "btnPrepareDeployment";
            btnPrepareDeployment.Size = new Size(167, 58);
            btnPrepareDeployment.TabIndex = 6;
            btnPrepareDeployment.Text = "Prepare deployment";
            btnPrepareDeployment.UseVisualStyleBackColor = true;
            btnPrepareDeployment.Click += btnPrepareDeployment_Click;
            // 
            // btnResetDeployment
            // 
            btnResetDeployment.Location = new Point(1134, 266);
            btnResetDeployment.Name = "btnResetDeployment";
            btnResetDeployment.Size = new Size(167, 53);
            btnResetDeployment.TabIndex = 7;
            btnResetDeployment.Text = "Reset";
            btnResetDeployment.UseVisualStyleBackColor = true;
            btnResetDeployment.Click += btnResetDeployment_Click;
            // 
            // cbLookUpAssignment
            // 
            cbLookUpAssignment.AutoSize = true;
            cbLookUpAssignment.ForeColor = Color.Salmon;
            cbLookUpAssignment.Location = new Point(1156, 31);
            cbLookUpAssignment.Name = "cbLookUpAssignment";
            cbLookUpAssignment.Size = new Size(212, 19);
            cbLookUpAssignment.TabIndex = 8;
            cbLookUpAssignment.Text = "Look up policy assignment on click";
            cbLookUpAssignment.UseVisualStyleBackColor = true;
            // 
            // Policy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1578, 903);
            Controls.Add(cbLookUpAssignment);
            Controls.Add(btnResetDeployment);
            Controls.Add(btnPrepareDeployment);
            Controls.Add(btnDeployPolicyAssignment);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pnlSearchPolicy);
            Controls.Add(pbHome);
            Name = "Policy";
            Text = "Policy";
            ((System.ComponentModel.ISupportInitialize)pbHome).EndInit();
            pnlSearchPolicy.ResumeLayout(false);
            pnlSearchPolicy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayPolicy).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn PolicyName;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Platform;
        private DataGridViewTextBoxColumn ID;
        private RichTextBox rtbAssignmentPreview;
        private Panel panel1;
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
    }
}