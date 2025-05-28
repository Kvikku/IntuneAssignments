namespace IntuneAssignments
{
    partial class WhatsNew
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
            rtbWhatsNew = new RichTextBox();
            lblWhatsNew = new Label();
            linklblGithubURL = new LinkLabel();
            lblNewestVersion = new Label();
            btnOk = new Button();
            SuspendLayout();
            // 
            // rtbWhatsNew
            // 
            rtbWhatsNew.BackColor = Color.FromArgb(46, 51, 73);
            rtbWhatsNew.BorderStyle = BorderStyle.None;
            rtbWhatsNew.Font = new Font("Consolas", 9F);
            rtbWhatsNew.ForeColor = Color.Salmon;
            rtbWhatsNew.Location = new Point(12, 137);
            rtbWhatsNew.Name = "rtbWhatsNew";
            rtbWhatsNew.ReadOnly = true;
            rtbWhatsNew.Size = new Size(464, 165);
            rtbWhatsNew.TabIndex = 13;
            rtbWhatsNew.Text = "New major feature - Tenant to Tenant migration! Read more on GitHub";
            // 
            // lblWhatsNew
            // 
            lblWhatsNew.AutoSize = true;
            lblWhatsNew.Font = new Font("Consolas", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWhatsNew.ForeColor = Color.Salmon;
            lblWhatsNew.Location = new Point(18, 24);
            lblWhatsNew.Name = "lblWhatsNew";
            lblWhatsNew.Size = new Size(164, 32);
            lblWhatsNew.TabIndex = 14;
            lblWhatsNew.Text = "What's new";
            // 
            // linklblGithubURL
            // 
            linklblGithubURL.AutoSize = true;
            linklblGithubURL.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linklblGithubURL.LinkColor = Color.Salmon;
            linklblGithubURL.Location = new Point(18, 329);
            linklblGithubURL.Name = "linklblGithubURL";
            linklblGithubURL.Size = new Size(159, 20);
            linklblGithubURL.TabIndex = 15;
            linklblGithubURL.TabStop = true;
            linklblGithubURL.Text = "Link to full patch notes";
            linklblGithubURL.LinkClicked += linklblGithubURL_LinkClicked;
            // 
            // lblNewestVersion
            // 
            lblNewestVersion.AutoSize = true;
            lblNewestVersion.Font = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNewestVersion.ForeColor = Color.Salmon;
            lblNewestVersion.Location = new Point(18, 92);
            lblNewestVersion.Name = "lblNewestVersion";
            lblNewestVersion.Size = new Size(133, 15);
            lblNewestVersion.TabIndex = 16;
            lblNewestVersion.Text = "Version 0.2.8-beta";
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.Salmon;
            btnOk.FlatStyle = FlatStyle.Popup;
            btnOk.Font = new Font("Consolas", 12F);
            btnOk.ForeColor = Color.FromArgb(46, 51, 73);
            btnOk.Location = new Point(386, 355);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(90, 32);
            btnOk.TabIndex = 17;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // WhatsNew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(488, 399);
            Controls.Add(btnOk);
            Controls.Add(lblNewestVersion);
            Controls.Add(linklblGithubURL);
            Controls.Add(lblWhatsNew);
            Controls.Add(rtbWhatsNew);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "WhatsNew";
            Text = "WhatsNew";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbWhatsNew;
        private Label lblWhatsNew;
        private LinkLabel linklblGithubURL;
        private Label lblNewestVersion;
        private Button btnOk;
    }
}