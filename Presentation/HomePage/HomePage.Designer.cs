﻿namespace IntuneAssignments
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            lblTenantName = new Label();
            pbGoToApplication = new PictureBox();
            pbGoToPolicy = new PictureBox();
            GoToAbout = new PictureBox();
            GoToSettings = new PictureBox();
            pBConnectionStatus = new PictureBox();
            lblConnectionStatus = new Label();
            toolTip1 = new ToolTip(components);
            lblAdditionalInfo = new Label();
            lblManageApplicationHeader = new Label();
            lblManageProfilesHeader = new Label();
            lblManageAppSettingsHeader = new Label();
            lblAboutHeader = new Label();
            pbWhatsNew = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbGoToApplication).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGoToPolicy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GoToAbout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GoToSettings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBConnectionStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWhatsNew).BeginInit();
            SuspendLayout();
            // 
            // lblTenantName
            // 
            lblTenantName.AutoSize = true;
            lblTenantName.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblTenantName.ForeColor = Color.Salmon;
            lblTenantName.Location = new Point(91, 338);
            lblTenantName.Name = "lblTenantName";
            lblTenantName.Size = new Size(108, 19);
            lblTenantName.TabIndex = 0;
            lblTenantName.Text = "Tenant name";
            // 
            // pbGoToApplication
            // 
            pbGoToApplication.Image = Properties.Resources.application;
            pbGoToApplication.Location = new Point(12, 12);
            pbGoToApplication.Name = "pbGoToApplication";
            pbGoToApplication.Size = new Size(64, 64);
            pbGoToApplication.SizeMode = PictureBoxSizeMode.AutoSize;
            pbGoToApplication.TabIndex = 1;
            pbGoToApplication.TabStop = false;
            toolTip1.SetToolTip(pbGoToApplication, "View and deploy applications");
            pbGoToApplication.Click += pbGoToApplication_Click;
            // 
            // pbGoToPolicy
            // 
            pbGoToPolicy.Image = (Image)resources.GetObject("pbGoToPolicy.Image");
            pbGoToPolicy.Location = new Point(12, 83);
            pbGoToPolicy.Name = "pbGoToPolicy";
            pbGoToPolicy.Size = new Size(64, 64);
            pbGoToPolicy.SizeMode = PictureBoxSizeMode.AutoSize;
            pbGoToPolicy.TabIndex = 2;
            pbGoToPolicy.TabStop = false;
            toolTip1.SetToolTip(pbGoToPolicy, "View and deploy policies");
            pbGoToPolicy.Click += pbGoToPolicy_Click;
            // 
            // GoToAbout
            // 
            GoToAbout.Image = (Image)resources.GetObject("GoToAbout.Image");
            GoToAbout.Location = new Point(12, 223);
            GoToAbout.Name = "GoToAbout";
            GoToAbout.Size = new Size(64, 64);
            GoToAbout.SizeMode = PictureBoxSizeMode.AutoSize;
            GoToAbout.TabIndex = 3;
            GoToAbout.TabStop = false;
            toolTip1.SetToolTip(GoToAbout, "About");
            GoToAbout.Click += GoToAbout_Click;
            // 
            // GoToSettings
            // 
            GoToSettings.Image = (Image)resources.GetObject("GoToSettings.Image");
            GoToSettings.Location = new Point(12, 153);
            GoToSettings.Name = "GoToSettings";
            GoToSettings.Size = new Size(64, 64);
            GoToSettings.SizeMode = PictureBoxSizeMode.AutoSize;
            GoToSettings.TabIndex = 4;
            GoToSettings.TabStop = false;
            toolTip1.SetToolTip(GoToSettings, "Configure authentication");
            GoToSettings.Click += GoToSettings_Click;
            // 
            // pBConnectionStatus
            // 
            pBConnectionStatus.Location = new Point(12, 319);
            pBConnectionStatus.Name = "pBConnectionStatus";
            pBConnectionStatus.Size = new Size(64, 64);
            pBConnectionStatus.TabIndex = 5;
            pBConnectionStatus.TabStop = false;
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.AutoSize = true;
            lblConnectionStatus.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblConnectionStatus.ForeColor = Color.Salmon;
            lblConnectionStatus.Location = new Point(91, 319);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(162, 19);
            lblConnectionStatus.TabIndex = 6;
            lblConnectionStatus.Text = "Connection status";
            // 
            // lblAdditionalInfo
            // 
            lblAdditionalInfo.AutoSize = true;
            lblAdditionalInfo.Font = new Font("Consolas", 11.25F);
            lblAdditionalInfo.ForeColor = Color.Salmon;
            lblAdditionalInfo.Location = new Point(91, 357);
            lblAdditionalInfo.Name = "lblAdditionalInfo";
            lblAdditionalInfo.Size = new Size(128, 18);
            lblAdditionalInfo.TabIndex = 7;
            lblAdditionalInfo.Text = "Additional info";
            // 
            // lblManageApplicationHeader
            // 
            lblManageApplicationHeader.AutoSize = true;
            lblManageApplicationHeader.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblManageApplicationHeader.ForeColor = Color.Salmon;
            lblManageApplicationHeader.Location = new Point(91, 29);
            lblManageApplicationHeader.Name = "lblManageApplicationHeader";
            lblManageApplicationHeader.Size = new Size(217, 32);
            lblManageApplicationHeader.TabIndex = 8;
            lblManageApplicationHeader.Text = "Intune applications";
            // 
            // lblManageProfilesHeader
            // 
            lblManageProfilesHeader.AutoSize = true;
            lblManageProfilesHeader.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblManageProfilesHeader.ForeColor = Color.Salmon;
            lblManageProfilesHeader.Location = new Point(91, 100);
            lblManageProfilesHeader.Name = "lblManageProfilesHeader";
            lblManageProfilesHeader.Size = new Size(169, 32);
            lblManageProfilesHeader.TabIndex = 9;
            lblManageProfilesHeader.Text = "Intune profiles";
            // 
            // lblManageAppSettingsHeader
            // 
            lblManageAppSettingsHeader.AutoSize = true;
            lblManageAppSettingsHeader.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblManageAppSettingsHeader.ForeColor = Color.Salmon;
            lblManageAppSettingsHeader.Location = new Point(91, 170);
            lblManageAppSettingsHeader.Name = "lblManageAppSettingsHeader";
            lblManageAppSettingsHeader.Size = new Size(147, 32);
            lblManageAppSettingsHeader.TabIndex = 10;
            lblManageAppSettingsHeader.Text = "App settings";
            // 
            // lblAboutHeader
            // 
            lblAboutHeader.AutoSize = true;
            lblAboutHeader.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAboutHeader.ForeColor = Color.Salmon;
            lblAboutHeader.Location = new Point(91, 238);
            lblAboutHeader.Name = "lblAboutHeader";
            lblAboutHeader.Size = new Size(79, 32);
            lblAboutHeader.TabIndex = 11;
            lblAboutHeader.Text = "About";
            // 
            // pbWhatsNew
            // 
            pbWhatsNew.Image = Properties.Resources.whatsnew;
            pbWhatsNew.Location = new Point(413, 6);
            pbWhatsNew.Name = "pbWhatsNew";
            pbWhatsNew.Size = new Size(71, 70);
            pbWhatsNew.TabIndex = 12;
            pbWhatsNew.TabStop = false;
            pbWhatsNew.Click += pbWhatsNew_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(484, 395);
            Controls.Add(pbWhatsNew);
            Controls.Add(lblAboutHeader);
            Controls.Add(lblManageAppSettingsHeader);
            Controls.Add(lblManageProfilesHeader);
            Controls.Add(lblManageApplicationHeader);
            Controls.Add(lblAdditionalInfo);
            Controls.Add(lblConnectionStatus);
            Controls.Add(pBConnectionStatus);
            Controls.Add(GoToSettings);
            Controls.Add(GoToAbout);
            Controls.Add(pbGoToPolicy);
            Controls.Add(pbGoToApplication);
            Controls.Add(lblTenantName);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "HomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomePage";
            Load += HomePage_Load;
            ((System.ComponentModel.ISupportInitialize)pbGoToApplication).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGoToPolicy).EndInit();
            ((System.ComponentModel.ISupportInitialize)GoToAbout).EndInit();
            ((System.ComponentModel.ISupportInitialize)GoToSettings).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBConnectionStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWhatsNew).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenantName;
        private PictureBox pbGoToApplication;
        private PictureBox pbGoToPolicy;
        private PictureBox GoToAbout;
        private PictureBox GoToSettings;
        private PictureBox pBConnectionStatus;
        private Label lblConnectionStatus;
        private ToolTip toolTip1;
        private Label lblAdditionalInfo;
        private Label lblManageApplicationHeader;
        private Label lblManageProfilesHeader;
        private Label lblManageAppSettingsHeader;
        private Label lblAboutHeader;
        private PictureBox pbWhatsNew;
    }
}