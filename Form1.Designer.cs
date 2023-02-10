namespace IntuneAssignments
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTenantID = new System.Windows.Forms.Label();
            this.lblTenantInfo = new System.Windows.Forms.Label();
            this.lblSignedInUser = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTenantID);
            this.panel1.Controls.Add(this.lblTenantInfo);
            this.panel1.Controls.Add(this.lblSignedInUser);
            this.panel1.Location = new System.Drawing.Point(762, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 183);
            this.panel1.TabIndex = 0;
            // 
            // lblTenantID
            // 
            this.lblTenantID.AutoSize = true;
            this.lblTenantID.ForeColor = System.Drawing.Color.Salmon;
            this.lblTenantID.Location = new System.Drawing.Point(12, 74);
            this.lblTenantID.Name = "lblTenantID";
            this.lblTenantID.Size = new System.Drawing.Size(62, 15);
            this.lblTenantID.TabIndex = 3;
            this.lblTenantID.Text = "TENANTID";
            // 
            // lblTenantInfo
            // 
            this.lblTenantInfo.AutoSize = true;
            this.lblTenantInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTenantInfo.ForeColor = System.Drawing.Color.Salmon;
            this.lblTenantInfo.Location = new System.Drawing.Point(12, 13);
            this.lblTenantInfo.Name = "lblTenantInfo";
            this.lblTenantInfo.Size = new System.Drawing.Size(113, 25);
            this.lblTenantInfo.TabIndex = 2;
            this.lblTenantInfo.Text = "Tenant info";
            // 
            // lblSignedInUser
            // 
            this.lblSignedInUser.AutoSize = true;
            this.lblSignedInUser.ForeColor = System.Drawing.Color.Salmon;
            this.lblSignedInUser.Location = new System.Drawing.Point(12, 48);
            this.lblSignedInUser.Name = "lblSignedInUser";
            this.lblSignedInUser.Size = new System.Drawing.Size(92, 15);
            this.lblSignedInUser.TabIndex = 1;
            this.lblSignedInUser.Text = "SIGNED IN USER";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(387, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(951, 741);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "WIP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1083, 794);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button button2;
        private Label lblSignedInUser;
        private Label lblTenantInfo;
        private Label lblTenantID;
    }
}