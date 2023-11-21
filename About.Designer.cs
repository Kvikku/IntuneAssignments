﻿namespace IntuneAssignments
{
    partial class About
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
            btnOk = new Button();
            lnklblGithubURL = new LinkLabel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            linkLabel1 = new LinkLabel();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.Salmon;
            btnOk.FlatStyle = FlatStyle.Popup;
            btnOk.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnOk.ForeColor = Color.FromArgb(46, 51, 73);
            btnOk.Location = new Point(382, 351);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(90, 32);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // lnklblGithubURL
            // 
            lnklblGithubURL.AutoSize = true;
            lnklblGithubURL.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lnklblGithubURL.LinkColor = Color.Salmon;
            lnklblGithubURL.Location = new Point(48, 341);
            lnklblGithubURL.Name = "lnklblGithubURL";
            lnklblGithubURL.Size = new Size(77, 14);
            lnklblGithubURL.TabIndex = 1;
            lnklblGithubURL.TabStop = true;
            lnklblGithubURL.Text = "GitHub URL";
            lnklblGithubURL.LinkClicked += lnklblGithubURL_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Salmon;
            label1.Location = new Point(48, 30);
            label1.Name = "label1";
            label1.Size = new Size(54, 19);
            label1.TabIndex = 2;
            label1.Text = "About";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Salmon;
            label2.Location = new Point(48, 318);
            label2.Name = "label2";
            label2.Size = new Size(161, 14);
            label2.TabIndex = 3;
            label2.Text = "© 2023 - Jørgen Sundet";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Salmon;
            label3.Location = new Point(48, 71);
            label3.Name = "label3";
            label3.Size = new Size(322, 14);
            label3.TabIndex = 4;
            label3.Text = "This application can bulk assign applications";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Salmon;
            label4.Location = new Point(48, 85);
            label4.Name = "label4";
            label4.Size = new Size(336, 14);
            label4.TabIndex = 5;
            label4.Text = "and device policies to multiple security groups";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Salmon;
            label5.Location = new Point(48, 99);
            label5.Name = "label5";
            label5.Size = new Size(189, 14);
            label5.TabIndex = 6;
            label5.Text = "with just a few easy steps";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Salmon;
            label6.Location = new Point(48, 292);
            label6.Name = "label6";
            label6.Size = new Size(63, 19);
            label6.TabIndex = 7;
            label6.Text = "Author";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.LinkColor = Color.Salmon;
            linkLabel1.Location = new Point(48, 365);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(84, 14);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "MIT License";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Salmon;
            label7.Location = new Point(48, 202);
            label7.Name = "label7";
            label7.Size = new Size(210, 14);
            label7.TabIndex = 9;
            label7.Text = "You are running version 0.2.0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Salmon;
            label8.Location = new Point(48, 173);
            label8.Name = "label8";
            label8.Size = new Size(72, 19);
            label8.TabIndex = 10;
            label8.Text = "Version";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.Salmon;
            label9.Location = new Point(48, 225);
            label9.Name = "label9";
            label9.Size = new Size(322, 14);
            label9.TabIndex = 11;
            label9.Text = "Please check the GitHub URL below for updates";
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(484, 395);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(linkLabel1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lnklblGithubURL);
            Controls.Add(btnOk);
            Name = "About";
            Text = "About";
            Load += About_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOk;
        private LinkLabel lnklblGithubURL;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private LinkLabel linkLabel1;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}