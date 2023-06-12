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
            dtgDisplayPolicy = new DataGridView();
            PolicyName = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            Platform = new DataGridViewTextBoxColumn();
            btnListAllPolicy = new Button();
            btnSearchPolicy = new Button();
            txtboxSearchPolicy = new TextBox();
            cbPolicyType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pbHome).BeginInit();
            pnlSearchPolicy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayPolicy).BeginInit();
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
            pnlSearchPolicy.Controls.Add(dtgDisplayPolicy);
            pnlSearchPolicy.Controls.Add(btnListAllPolicy);
            pnlSearchPolicy.Controls.Add(btnSearchPolicy);
            pnlSearchPolicy.Controls.Add(txtboxSearchPolicy);
            pnlSearchPolicy.Controls.Add(cbPolicyType);
            pnlSearchPolicy.Location = new Point(97, 12);
            pnlSearchPolicy.Name = "pnlSearchPolicy";
            pnlSearchPolicy.Size = new Size(643, 879);
            pnlSearchPolicy.TabIndex = 1;
            // 
            // dtgDisplayPolicy
            // 
            dtgDisplayPolicy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayPolicy.Columns.AddRange(new DataGridViewColumn[] { PolicyName, Type, Platform });
            dtgDisplayPolicy.Location = new Point(3, 98);
            dtgDisplayPolicy.Name = "dtgDisplayPolicy";
            dtgDisplayPolicy.RowTemplate.Height = 25;
            dtgDisplayPolicy.Size = new Size(637, 513);
            dtgDisplayPolicy.TabIndex = 4;
            // 
            // PolicyName
            // 
            PolicyName.HeaderText = "Name";
            PolicyName.Name = "PolicyName";
            PolicyName.Width = 200;
            // 
            // Type
            // 
            Type.HeaderText = "Type";
            Type.Name = "Type";
            Type.Width = 200;
            // 
            // Platform
            // 
            Platform.HeaderText = "Platform";
            Platform.Name = "Platform";
            Platform.Width = 200;
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
            // Policy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1578, 903);
            Controls.Add(pnlSearchPolicy);
            Controls.Add(pbHome);
            Name = "Policy";
            Text = "Policy";
            ((System.ComponentModel.ISupportInitialize)pbHome).EndInit();
            pnlSearchPolicy.ResumeLayout(false);
            pnlSearchPolicy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayPolicy).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbHome;
        private Panel pnlSearchPolicy;
        private ComboBox cbPolicyType;
        private TextBox txtboxSearchPolicy;
        private Button btnListAllPolicy;
        private Button btnSearchPolicy;
        private DataGridView dtgDisplayPolicy;
        private DataGridViewTextBoxColumn PolicyName;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Platform;
    }
}