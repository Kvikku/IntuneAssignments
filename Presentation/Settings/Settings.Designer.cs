namespace IntuneAssignments
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            btnOK = new Button();
            lblHeader = new Label();
            lblTenantID = new Label();
            lblClientID = new Label();
            lblClientSecret = new Label();
            btnOpenFolder = new Button();
            button1 = new Button();
            tBTenantID = new TextBox();
            tBClientID = new TextBox();
            tBClientSecret = new TextBox();
            toolTip1 = new ToolTip(components);
            cBSaveSettings = new CheckBox();
            cBTenant = new ComboBox();
            lblSelectedTenant = new Label();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.Salmon;
            btnOK.FlatStyle = FlatStyle.Popup;
            btnOK.Font = new Font("Consolas", 12F);
            btnOK.ForeColor = Color.FromArgb(46, 51, 73);
            btnOK.Location = new Point(323, 337);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(149, 32);
            btnOK.TabIndex = 0;
            btnOK.Text = "Login";
            toolTip1.SetToolTip(btnOK, "Login to Microsoft Entra");
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Salmon;
            lblHeader.Location = new Point(11, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(189, 19);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Application settings";
            // 
            // lblTenantID
            // 
            lblTenantID.AutoSize = true;
            lblTenantID.Font = new Font("Consolas", 9.75F);
            lblTenantID.ForeColor = Color.Salmon;
            lblTenantID.Location = new Point(11, 159);
            lblTenantID.Name = "lblTenantID";
            lblTenantID.Size = new Size(70, 15);
            lblTenantID.TabIndex = 2;
            lblTenantID.Text = "Tenant ID";
            // 
            // lblClientID
            // 
            lblClientID.AutoSize = true;
            lblClientID.Font = new Font("Consolas", 9.75F);
            lblClientID.ForeColor = Color.Salmon;
            lblClientID.Location = new Point(11, 205);
            lblClientID.Name = "lblClientID";
            lblClientID.Size = new Size(70, 15);
            lblClientID.TabIndex = 3;
            lblClientID.Text = "Client ID";
            // 
            // lblClientSecret
            // 
            lblClientSecret.AutoSize = true;
            lblClientSecret.Font = new Font("Consolas", 9.75F);
            lblClientSecret.ForeColor = Color.Salmon;
            lblClientSecret.Location = new Point(11, 249);
            lblClientSecret.Name = "lblClientSecret";
            lblClientSecret.Size = new Size(98, 15);
            lblClientSecret.TabIndex = 4;
            lblClientSecret.Text = "Client secret";
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.BackColor = Color.Salmon;
            btnOpenFolder.FlatStyle = FlatStyle.Popup;
            btnOpenFolder.Font = new Font("Consolas", 12F);
            btnOpenFolder.ForeColor = Color.FromArgb(46, 51, 73);
            btnOpenFolder.Location = new Point(190, 337);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new Size(127, 32);
            btnOpenFolder.TabIndex = 9;
            btnOpenFolder.Text = "Open folder";
            toolTip1.SetToolTip(btnOpenFolder, "Open the folder for logs and configuration");
            btnOpenFolder.UseVisualStyleBackColor = false;
            btnOpenFolder.Click += btnOpenFolder_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Salmon;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Consolas", 12F);
            button1.ForeColor = Color.FromArgb(46, 51, 73);
            button1.Location = new Point(11, 337);
            button1.Name = "button1";
            button1.Size = new Size(172, 32);
            button1.TabIndex = 10;
            button1.Text = "Check permissions";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tBTenantID
            // 
            tBTenantID.BackColor = Color.FromArgb(46, 51, 73);
            tBTenantID.BorderStyle = BorderStyle.FixedSingle;
            tBTenantID.Font = new Font("Consolas", 9.75F);
            tBTenantID.ForeColor = Color.Salmon;
            tBTenantID.Location = new Point(139, 151);
            tBTenantID.Name = "tBTenantID";
            tBTenantID.Size = new Size(297, 23);
            tBTenantID.TabIndex = 11;
            // 
            // tBClientID
            // 
            tBClientID.BackColor = Color.FromArgb(46, 51, 73);
            tBClientID.BorderStyle = BorderStyle.FixedSingle;
            tBClientID.Font = new Font("Consolas", 9.75F);
            tBClientID.ForeColor = Color.Salmon;
            tBClientID.Location = new Point(139, 197);
            tBClientID.Name = "tBClientID";
            tBClientID.Size = new Size(297, 23);
            tBClientID.TabIndex = 12;
            // 
            // tBClientSecret
            // 
            tBClientSecret.BackColor = Color.FromArgb(46, 51, 73);
            tBClientSecret.BorderStyle = BorderStyle.FixedSingle;
            tBClientSecret.Font = new Font("Consolas", 9.75F);
            tBClientSecret.ForeColor = Color.Salmon;
            tBClientSecret.Location = new Point(139, 241);
            tBClientSecret.Name = "tBClientSecret";
            tBClientSecret.Size = new Size(297, 23);
            tBClientSecret.TabIndex = 13;
            // 
            // cBSaveSettings
            // 
            cBSaveSettings.AutoSize = true;
            cBSaveSettings.Font = new Font("Consolas", 9.75F);
            cBSaveSettings.ForeColor = Color.Salmon;
            cBSaveSettings.Location = new Point(323, 375);
            cBSaveSettings.Name = "cBSaveSettings";
            cBSaveSettings.Size = new Size(117, 19);
            cBSaveSettings.TabIndex = 14;
            cBSaveSettings.Text = "Save settings";
            toolTip1.SetToolTip(cBSaveSettings, "Save the current settings to a config file when logging in");
            cBSaveSettings.UseVisualStyleBackColor = true;
            // 
            // cBTenant
            // 
            cBTenant.BackColor = Color.FromArgb(46, 51, 73);
            cBTenant.DropDownStyle = ComboBoxStyle.DropDownList;
            cBTenant.FlatStyle = FlatStyle.Flat;
            cBTenant.ForeColor = Color.Salmon;
            cBTenant.FormattingEnabled = true;
            cBTenant.Location = new Point(139, 110);
            cBTenant.Name = "cBTenant";
            cBTenant.Size = new Size(121, 23);
            cBTenant.TabIndex = 15;
            cBTenant.SelectedIndexChanged += cBTenant_SelectedIndexChanged;
            // 
            // lblSelectedTenant
            // 
            lblSelectedTenant.AutoSize = true;
            lblSelectedTenant.Font = new Font("Consolas", 9.75F);
            lblSelectedTenant.ForeColor = Color.Salmon;
            lblSelectedTenant.Location = new Point(12, 118);
            lblSelectedTenant.Name = "lblSelectedTenant";
            lblSelectedTenant.Size = new Size(98, 15);
            lblSelectedTenant.TabIndex = 16;
            lblSelectedTenant.Text = "Select tenant";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(46, 51, 73);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Consolas", 9F);
            richTextBox1.ForeColor = Color.Salmon;
            richTextBox1.Location = new Point(11, 53);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(429, 38);
            richTextBox1.TabIndex = 17;
            richTextBox1.Text = "Values are retrieved from the JSON file. Please check the Github Wiki if you need help";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(484, 395);
            Controls.Add(richTextBox1);
            Controls.Add(lblSelectedTenant);
            Controls.Add(cBTenant);
            Controls.Add(cBSaveSettings);
            Controls.Add(tBClientSecret);
            Controls.Add(tBClientID);
            Controls.Add(tBTenantID);
            Controls.Add(button1);
            Controls.Add(btnOpenFolder);
            Controls.Add(lblClientSecret);
            Controls.Add(lblClientID);
            Controls.Add(lblTenantID);
            Controls.Add(lblHeader);
            Controls.Add(btnOK);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Settings";
            Text = "Settings";
            Load += Settings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOK;
        private Label lblHeader;
        private Label lblTenantID;
        private Label lblClientID;
        private Label lblClientSecret;
        private Button btnOpenFolder;
        private Button button1;
        private TextBox tBTenantID;
        private TextBox tBClientID;
        private TextBox tBClientSecret;
        private ToolTip toolTip1;
        private CheckBox cBSaveSettings;
        private ComboBox cBTenant;
        private Label lblSelectedTenant;
        private RichTextBox richTextBox1;
    }
}