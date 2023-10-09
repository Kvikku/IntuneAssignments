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
            btnOK = new Button();
            lblHeader = new Label();
            lblTenantID = new Label();
            lblClientID = new Label();
            lblClientSecret = new Label();
            lblInfo = new Label();
            btnOpenFolder = new Button();
            button1 = new Button();
            tBTenantID = new TextBox();
            tBClientID = new TextBox();
            tBClientSecret = new TextBox();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.Salmon;
            btnOK.FlatStyle = FlatStyle.Popup;
            btnOK.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnOK.ForeColor = Color.FromArgb(46, 51, 73);
            btnOK.Location = new Point(382, 351);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(90, 32);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.Salmon;
            lblHeader.Location = new Point(12, 46);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(189, 19);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Application settings";
            // 
            // lblTenantID
            // 
            lblTenantID.AutoSize = true;
            lblTenantID.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblTenantID.ForeColor = Color.Salmon;
            lblTenantID.Location = new Point(12, 215);
            lblTenantID.Name = "lblTenantID";
            lblTenantID.Size = new Size(70, 15);
            lblTenantID.TabIndex = 2;
            lblTenantID.Text = "Tenant ID";
            // 
            // lblClientID
            // 
            lblClientID.AutoSize = true;
            lblClientID.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblClientID.ForeColor = Color.Salmon;
            lblClientID.Location = new Point(12, 261);
            lblClientID.Name = "lblClientID";
            lblClientID.Size = new Size(70, 15);
            lblClientID.TabIndex = 3;
            lblClientID.Text = "Client ID";
            // 
            // lblClientSecret
            // 
            lblClientSecret.AutoSize = true;
            lblClientSecret.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblClientSecret.ForeColor = Color.Salmon;
            lblClientSecret.Location = new Point(12, 305);
            lblClientSecret.Name = "lblClientSecret";
            lblClientSecret.Size = new Size(98, 15);
            lblClientSecret.TabIndex = 4;
            lblClientSecret.Text = "Client secret";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblInfo.ForeColor = Color.Salmon;
            lblInfo.Location = new Point(12, 95);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(294, 15);
            lblInfo.TabIndex = 5;
            lblInfo.Text = "Please make sure these values are correct";
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.BackColor = Color.Salmon;
            btnOpenFolder.FlatStyle = FlatStyle.Popup;
            btnOpenFolder.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpenFolder.ForeColor = Color.FromArgb(46, 51, 73);
            btnOpenFolder.Location = new Point(228, 351);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new Size(127, 32);
            btnOpenFolder.TabIndex = 9;
            btnOpenFolder.Text = "Open folder";
            btnOpenFolder.UseVisualStyleBackColor = false;
            btnOpenFolder.Click += btnOpenFolder_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Salmon;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(46, 51, 73);
            button1.Location = new Point(12, 351);
            button1.Name = "button1";
            button1.Size = new Size(185, 32);
            button1.TabIndex = 10;
            button1.Text = "Check permissions";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tBTenantID
            // 
            tBTenantID.BackColor = Color.FromArgb(46, 51, 73);
            tBTenantID.BorderStyle = BorderStyle.FixedSingle;
            tBTenantID.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tBTenantID.ForeColor = Color.Salmon;
            tBTenantID.Location = new Point(140, 207);
            tBTenantID.Name = "tBTenantID";
            tBTenantID.Size = new Size(297, 23);
            tBTenantID.TabIndex = 11;
            // 
            // tBClientID
            // 
            tBClientID.BackColor = Color.FromArgb(46, 51, 73);
            tBClientID.BorderStyle = BorderStyle.FixedSingle;
            tBClientID.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tBClientID.ForeColor = Color.Salmon;
            tBClientID.Location = new Point(140, 253);
            tBClientID.Name = "tBClientID";
            tBClientID.Size = new Size(297, 23);
            tBClientID.TabIndex = 12;
            // 
            // tBClientSecret
            // 
            tBClientSecret.BackColor = Color.FromArgb(46, 51, 73);
            tBClientSecret.BorderStyle = BorderStyle.FixedSingle;
            tBClientSecret.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tBClientSecret.ForeColor = Color.Salmon;
            tBClientSecret.Location = new Point(140, 297);
            tBClientSecret.Name = "tBClientSecret";
            tBClientSecret.Size = new Size(297, 23);
            tBClientSecret.TabIndex = 13;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(484, 395);
            Controls.Add(tBClientSecret);
            Controls.Add(tBClientID);
            Controls.Add(tBTenantID);
            Controls.Add(button1);
            Controls.Add(btnOpenFolder);
            Controls.Add(lblInfo);
            Controls.Add(lblClientSecret);
            Controls.Add(lblClientID);
            Controls.Add(lblTenantID);
            Controls.Add(lblHeader);
            Controls.Add(btnOK);
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
        private Label lblInfo;
        private Button btnOpenFolder;
        private Button button1;
        private TextBox tBTenantID;
        private TextBox tBClientID;
        private TextBox tBClientSecret;
    }
}