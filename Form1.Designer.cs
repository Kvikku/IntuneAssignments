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
            this.tenantInfoPanel = new System.Windows.Forms.Panel();
            this.signIn = new System.Windows.Forms.Button();
            this.lblTenantID = new System.Windows.Forms.Label();
            this.lblTenantInfo = new System.Windows.Forms.Label();
            this.lblSignedInUser = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.tenantInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tenantInfoPanel
            // 
            this.tenantInfoPanel.Controls.Add(this.signIn);
            this.tenantInfoPanel.Controls.Add(this.lblTenantID);
            this.tenantInfoPanel.Controls.Add(this.lblTenantInfo);
            this.tenantInfoPanel.Controls.Add(this.lblSignedInUser);
            this.tenantInfoPanel.Location = new System.Drawing.Point(762, 12);
            this.tenantInfoPanel.Name = "tenantInfoPanel";
            this.tenantInfoPanel.Size = new System.Drawing.Size(309, 183);
            this.tenantInfoPanel.TabIndex = 0;
            // 
            // signIn
            // 
            this.signIn.Location = new System.Drawing.Point(180, 139);
            this.signIn.Name = "signIn";
            this.signIn.Size = new System.Drawing.Size(126, 41);
            this.signIn.TabIndex = 1;
            this.signIn.Text = "Sign in";
            this.signIn.UseVisualStyleBackColor = true;
            this.signIn.Click += new System.EventHandler(this.button2_Click);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(828, 512);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(617, 490);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(108, 49);
            this.testBtn.TabIndex = 2;
            this.testBtn.Text = "button2";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1083, 794);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tenantInfoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tenantInfoPanel.ResumeLayout(false);
            this.tenantInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel tenantInfoPanel;
        private Button signIn;
        private Label lblSignedInUser;
        private Label lblTenantInfo;
        private Label lblTenantID;
        private Button button1;
        private Button testBtn;
    }
}