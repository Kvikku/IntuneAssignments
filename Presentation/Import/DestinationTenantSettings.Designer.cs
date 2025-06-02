namespace IntuneAssignments.Presentation.Import
{
    partial class DestinationTenantSettings
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
            tBTenantName = new TextBox();
            lblTenantFriendlyName = new Label();
            tBClientID = new TextBox();
            tBTenantID = new TextBox();
            lblClientID = new Label();
            lblTenantID = new Label();
            btnCheckPermissions = new Button();
            btnOpenFolder = new Button();
            btnLogin = new Button();
            lblHeader = new Label();
            lblSelectedTenant = new Label();
            cBTenant = new ComboBox();
            SuspendLayout();
            // 
            // tBTenantName
            // 
            tBTenantName.BackColor = Color.FromArgb(46, 51, 73);
            tBTenantName.BorderStyle = BorderStyle.FixedSingle;
            tBTenantName.Font = new Font("Consolas", 9.75F);
            tBTenantName.ForeColor = Color.Salmon;
            tBTenantName.Location = new Point(112, 124);
            tBTenantName.Name = "tBTenantName";
            tBTenantName.Size = new Size(297, 23);
            tBTenantName.TabIndex = 25;
            // 
            // lblTenantFriendlyName
            // 
            lblTenantFriendlyName.AutoSize = true;
            lblTenantFriendlyName.Font = new Font("Consolas", 9.75F);
            lblTenantFriendlyName.ForeColor = Color.Salmon;
            lblTenantFriendlyName.Location = new Point(22, 124);
            lblTenantFriendlyName.Name = "lblTenantFriendlyName";
            lblTenantFriendlyName.Size = new Size(84, 15);
            lblTenantFriendlyName.TabIndex = 24;
            lblTenantFriendlyName.Text = "Tenant name";
            // 
            // tBClientID
            // 
            tBClientID.BackColor = Color.FromArgb(46, 51, 73);
            tBClientID.BorderStyle = BorderStyle.FixedSingle;
            tBClientID.Font = new Font("Consolas", 9.75F);
            tBClientID.ForeColor = Color.Salmon;
            tBClientID.Location = new Point(112, 179);
            tBClientID.Name = "tBClientID";
            tBClientID.Size = new Size(297, 23);
            tBClientID.TabIndex = 23;
            // 
            // tBTenantID
            // 
            tBTenantID.BackColor = Color.FromArgb(46, 51, 73);
            tBTenantID.BorderStyle = BorderStyle.FixedSingle;
            tBTenantID.Font = new Font("Consolas", 9.75F);
            tBTenantID.ForeColor = Color.Salmon;
            tBTenantID.Location = new Point(112, 150);
            tBTenantID.Name = "tBTenantID";
            tBTenantID.Size = new Size(297, 23);
            tBTenantID.TabIndex = 22;
            // 
            // lblClientID
            // 
            lblClientID.AutoSize = true;
            lblClientID.Font = new Font("Consolas", 9.75F);
            lblClientID.ForeColor = Color.Salmon;
            lblClientID.Location = new Point(22, 179);
            lblClientID.Name = "lblClientID";
            lblClientID.Size = new Size(70, 15);
            lblClientID.TabIndex = 21;
            lblClientID.Text = "Client ID";
            // 
            // lblTenantID
            // 
            lblTenantID.AutoSize = true;
            lblTenantID.Font = new Font("Consolas", 9.75F);
            lblTenantID.ForeColor = Color.Salmon;
            lblTenantID.Location = new Point(22, 150);
            lblTenantID.Name = "lblTenantID";
            lblTenantID.Size = new Size(70, 15);
            lblTenantID.TabIndex = 20;
            lblTenantID.Text = "Tenant ID";
            // 
            // btnCheckPermissions
            // 
            btnCheckPermissions.BackColor = Color.Salmon;
            btnCheckPermissions.FlatStyle = FlatStyle.Popup;
            btnCheckPermissions.Font = new Font("Consolas", 12F);
            btnCheckPermissions.ForeColor = Color.FromArgb(46, 51, 73);
            btnCheckPermissions.Location = new Point(12, 208);
            btnCheckPermissions.Name = "btnCheckPermissions";
            btnCheckPermissions.Size = new Size(172, 32);
            btnCheckPermissions.TabIndex = 28;
            btnCheckPermissions.Text = "Check permissions";
            btnCheckPermissions.UseVisualStyleBackColor = false;
            btnCheckPermissions.Click += btnCheckPermissions_Click;
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.BackColor = Color.Salmon;
            btnOpenFolder.FlatStyle = FlatStyle.Popup;
            btnOpenFolder.Font = new Font("Consolas", 12F);
            btnOpenFolder.ForeColor = Color.FromArgb(46, 51, 73);
            btnOpenFolder.Location = new Point(191, 208);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new Size(127, 32);
            btnOpenFolder.TabIndex = 27;
            btnOpenFolder.Text = "Open folder";
            btnOpenFolder.UseVisualStyleBackColor = false;
            btnOpenFolder.Click += btnOpenFolder_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Salmon;
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Consolas", 12F);
            btnLogin.ForeColor = Color.FromArgb(46, 51, 73);
            btnLogin.Location = new Point(324, 208);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(149, 32);
            btnLogin.TabIndex = 26;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Salmon;
            lblHeader.Location = new Point(22, 28);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(252, 19);
            lblHeader.TabIndex = 29;
            lblHeader.Text = "Destination tenant settings";
            // 
            // lblSelectedTenant
            // 
            lblSelectedTenant.AutoSize = true;
            lblSelectedTenant.Font = new Font("Consolas", 9.75F);
            lblSelectedTenant.ForeColor = Color.Salmon;
            lblSelectedTenant.Location = new Point(22, 78);
            lblSelectedTenant.Name = "lblSelectedTenant";
            lblSelectedTenant.Size = new Size(98, 15);
            lblSelectedTenant.TabIndex = 31;
            lblSelectedTenant.Text = "Select tenant";
            // 
            // cBTenant
            // 
            cBTenant.BackColor = Color.FromArgb(46, 51, 73);
            cBTenant.DropDownStyle = ComboBoxStyle.DropDownList;
            cBTenant.FlatStyle = FlatStyle.Flat;
            cBTenant.ForeColor = Color.Salmon;
            cBTenant.FormattingEnabled = true;
            cBTenant.Location = new Point(126, 75);
            cBTenant.Name = "cBTenant";
            cBTenant.Size = new Size(121, 23);
            cBTenant.TabIndex = 30;
            cBTenant.SelectedIndexChanged += cBTenant_SelectedIndexChanged;
            // 
            // DestinationTenantSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(492, 399);
            Controls.Add(lblSelectedTenant);
            Controls.Add(cBTenant);
            Controls.Add(lblHeader);
            Controls.Add(btnCheckPermissions);
            Controls.Add(btnOpenFolder);
            Controls.Add(btnLogin);
            Controls.Add(tBTenantName);
            Controls.Add(lblTenantFriendlyName);
            Controls.Add(tBClientID);
            Controls.Add(tBTenantID);
            Controls.Add(lblClientID);
            Controls.Add(lblTenantID);
            Name = "DestinationTenantSettings";
            Text = "DestinationTenantSettings";
            Load += DestinationTenantSettings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tBTenantName;
        private Label lblTenantFriendlyName;
        private TextBox tBClientID;
        private TextBox tBTenantID;
        private Label lblClientID;
        private Label lblTenantID;
        private Button btnCheckPermissions;
        private Button btnOpenFolder;
        private Button btnLogin;
        private Label lblHeader;
        private Label lblSelectedTenant;
        private ComboBox cBTenant;
    }
}