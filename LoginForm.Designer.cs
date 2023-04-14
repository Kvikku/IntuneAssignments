namespace IntuneAssignments
{
    partial class LoginForm
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
            btnLogin = new Button();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(126, 107);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(96, 33);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login to Azure";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(370, 286);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnLogin;
    }
}