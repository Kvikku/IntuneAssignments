﻿namespace IntuneAssignments
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
            btnOpenFolder = new Button();
            button1 = new Button();
            tBTenantID = new TextBox();
            tBClientID = new TextBox();
            toolTip1 = new ToolTip(components);
            cBSaveSettings = new CheckBox();
            cBOverride = new CheckBox();
            pbGood = new PictureBox();
            pbMissing = new PictureBox();
            pbWrong = new PictureBox();
            cBTenant = new ComboBox();
            lblSelectedTenant = new Label();
            richTextBox1 = new RichTextBox();
            lblTenantFriendlyName = new Label();
            tBTenantName = new TextBox();
            rtbGood = new RichTextBox();
            rtbMissing = new RichTextBox();
            rtbWrong = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)pbGood).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMissing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWrong).BeginInit();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.Salmon;
            btnOK.FlatStyle = FlatStyle.Popup;
            btnOK.Font = new Font("Consolas", 12F);
            btnOK.ForeColor = Color.FromArgb(46, 51, 73);
            btnOK.Location = new Point(323, 244);
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
            lblTenantID.Location = new Point(11, 144);
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
            lblClientID.Location = new Point(11, 173);
            lblClientID.Name = "lblClientID";
            lblClientID.Size = new Size(70, 15);
            lblClientID.TabIndex = 3;
            lblClientID.Text = "Client ID";
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.BackColor = Color.Salmon;
            btnOpenFolder.FlatStyle = FlatStyle.Popup;
            btnOpenFolder.Font = new Font("Consolas", 12F);
            btnOpenFolder.ForeColor = Color.FromArgb(46, 51, 73);
            btnOpenFolder.Location = new Point(190, 244);
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
            button1.Location = new Point(11, 244);
            button1.Name = "button1";
            button1.Size = new Size(172, 32);
            button1.TabIndex = 10;
            button1.Text = "Check permissions";
            toolTip1.SetToolTip(button1, "Checks the permissions of the Entra app registration");
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tBTenantID
            // 
            tBTenantID.BackColor = Color.FromArgb(46, 51, 73);
            tBTenantID.BorderStyle = BorderStyle.FixedSingle;
            tBTenantID.Font = new Font("Consolas", 9.75F);
            tBTenantID.ForeColor = Color.Salmon;
            tBTenantID.Location = new Point(139, 136);
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
            tBClientID.Location = new Point(139, 165);
            tBClientID.Name = "tBClientID";
            tBClientID.Size = new Size(297, 23);
            tBClientID.TabIndex = 12;
            // 
            // cBSaveSettings
            // 
            cBSaveSettings.AutoSize = true;
            cBSaveSettings.Font = new Font("Consolas", 9.75F);
            cBSaveSettings.ForeColor = Color.Salmon;
            cBSaveSettings.Location = new Point(323, 194);
            cBSaveSettings.Name = "cBSaveSettings";
            cBSaveSettings.Size = new Size(117, 19);
            cBSaveSettings.TabIndex = 14;
            cBSaveSettings.Text = "Save settings";
            toolTip1.SetToolTip(cBSaveSettings, "Save the current settings to a config file when logging in");
            cBSaveSettings.UseVisualStyleBackColor = true;
            cBSaveSettings.Click += cBSaveSettings_Click;
            // 
            // cBOverride
            // 
            cBOverride.AutoSize = true;
            cBOverride.Font = new Font("Consolas", 9.75F);
            cBOverride.ForeColor = Color.Salmon;
            cBOverride.Location = new Point(323, 219);
            cBOverride.Name = "cBOverride";
            cBOverride.Size = new Size(145, 19);
            cBOverride.TabIndex = 20;
            cBOverride.Text = "Override settings";
            toolTip1.SetToolTip(cBOverride, "Override the current info in the config file. Leave unchecked if you want to create a new entry");
            cBOverride.UseVisualStyleBackColor = true;
            // 
            // pbGood
            // 
            pbGood.Image = Properties.Resources.check__1_;
            pbGood.Location = new Point(11, 282);
            pbGood.Name = "pbGood";
            pbGood.Size = new Size(64, 67);
            pbGood.TabIndex = 22;
            pbGood.TabStop = false;
            toolTip1.SetToolTip(pbGood, "Correct permissions");
            // 
            // pbMissing
            // 
            pbMissing.Image = Properties.Resources.unlike;
            pbMissing.Location = new Point(190, 283);
            pbMissing.Name = "pbMissing";
            pbMissing.Size = new Size(64, 66);
            pbMissing.TabIndex = 23;
            pbMissing.TabStop = false;
            toolTip1.SetToolTip(pbMissing, "Missing permissions");
            // 
            // pbWrong
            // 
            pbWrong.Image = Properties.Resources.complain;
            pbWrong.Location = new Point(357, 283);
            pbWrong.Name = "pbWrong";
            pbWrong.Size = new Size(64, 67);
            pbWrong.TabIndex = 24;
            pbWrong.TabStop = false;
            toolTip1.SetToolTip(pbWrong, "Wrong permissions. Please remove");
            // 
            // cBTenant
            // 
            cBTenant.BackColor = Color.FromArgb(46, 51, 73);
            cBTenant.DropDownStyle = ComboBoxStyle.DropDownList;
            cBTenant.FlatStyle = FlatStyle.Flat;
            cBTenant.ForeColor = Color.Salmon;
            cBTenant.FormattingEnabled = true;
            cBTenant.Location = new Point(139, 79);
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
            lblSelectedTenant.Location = new Point(11, 82);
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
            richTextBox1.Location = new Point(11, 41);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(429, 38);
            richTextBox1.TabIndex = 17;
            richTextBox1.Text = "Values are retrieved from the JSON file. Please check the Github Wiki if you need help";
            // 
            // lblTenantFriendlyName
            // 
            lblTenantFriendlyName.AutoSize = true;
            lblTenantFriendlyName.Font = new Font("Consolas", 9.75F);
            lblTenantFriendlyName.ForeColor = Color.Salmon;
            lblTenantFriendlyName.Location = new Point(11, 118);
            lblTenantFriendlyName.Name = "lblTenantFriendlyName";
            lblTenantFriendlyName.Size = new Size(84, 15);
            lblTenantFriendlyName.TabIndex = 18;
            lblTenantFriendlyName.Text = "Tenant name";
            // 
            // tBTenantName
            // 
            tBTenantName.BackColor = Color.FromArgb(46, 51, 73);
            tBTenantName.BorderStyle = BorderStyle.FixedSingle;
            tBTenantName.Font = new Font("Consolas", 9.75F);
            tBTenantName.ForeColor = Color.Salmon;
            tBTenantName.Location = new Point(139, 110);
            tBTenantName.Name = "tBTenantName";
            tBTenantName.Size = new Size(297, 23);
            tBTenantName.TabIndex = 19;
            // 
            // rtbGood
            // 
            rtbGood.BackColor = Color.FromArgb(46, 51, 73);
            rtbGood.BorderStyle = BorderStyle.None;
            rtbGood.ForeColor = Color.Salmon;
            rtbGood.Location = new Point(11, 365);
            rtbGood.Name = "rtbGood";
            rtbGood.ReadOnly = true;
            rtbGood.Size = new Size(164, 187);
            rtbGood.TabIndex = 21;
            rtbGood.Text = "";
            // 
            // rtbMissing
            // 
            rtbMissing.BackColor = Color.FromArgb(46, 51, 73);
            rtbMissing.BorderStyle = BorderStyle.None;
            rtbMissing.ForeColor = Color.Salmon;
            rtbMissing.Location = new Point(190, 355);
            rtbMissing.Name = "rtbMissing";
            rtbMissing.ReadOnly = true;
            rtbMissing.Size = new Size(145, 197);
            rtbMissing.TabIndex = 25;
            rtbMissing.Text = "";
            // 
            // rtbWrong
            // 
            rtbWrong.BackColor = Color.FromArgb(46, 51, 73);
            rtbWrong.BorderStyle = BorderStyle.None;
            rtbWrong.ForeColor = Color.Salmon;
            rtbWrong.Location = new Point(357, 356);
            rtbWrong.Name = "rtbWrong";
            rtbWrong.ReadOnly = true;
            rtbWrong.Size = new Size(129, 196);
            rtbWrong.TabIndex = 26;
            rtbWrong.Text = "";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(488, 564);
            Controls.Add(rtbWrong);
            Controls.Add(rtbMissing);
            Controls.Add(pbWrong);
            Controls.Add(pbMissing);
            Controls.Add(pbGood);
            Controls.Add(rtbGood);
            Controls.Add(cBOverride);
            Controls.Add(tBTenantName);
            Controls.Add(lblTenantFriendlyName);
            Controls.Add(richTextBox1);
            Controls.Add(lblSelectedTenant);
            Controls.Add(cBTenant);
            Controls.Add(cBSaveSettings);
            Controls.Add(tBClientID);
            Controls.Add(tBTenantID);
            Controls.Add(button1);
            Controls.Add(btnOpenFolder);
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
            ((System.ComponentModel.ISupportInitialize)pbGood).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMissing).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWrong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOK;
        private Label lblHeader;
        private Label lblTenantID;
        private Label lblClientID;
        private Button btnOpenFolder;
        private Button button1;
        private TextBox tBTenantID;
        private TextBox tBClientID;
        private ToolTip toolTip1;
        private CheckBox cBSaveSettings;
        private ComboBox cBTenant;
        private Label lblSelectedTenant;
        private RichTextBox richTextBox1;
        private Label lblTenantFriendlyName;
        private TextBox tBTenantName;
        private CheckBox cBOverride;
        private RichTextBox rtbGood;
        private PictureBox pbGood;
        private PictureBox pbMissing;
        private PictureBox pbWrong;
        private RichTextBox rtbMissing;
        private RichTextBox rtbWrong;
    }
}