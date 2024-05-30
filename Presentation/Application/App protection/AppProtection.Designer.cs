namespace IntuneAssignments.Presentation.Application.App_protection
{
    partial class AppProtection
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
            pbHome = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbHome).BeginInit();
            SuspendLayout();
            // 
            // pbHome
            // 
            pbHome.Image = Properties.Resources.application;
            pbHome.Location = new Point(12, 12);
            pbHome.Name = "pbHome";
            pbHome.Size = new Size(64, 64);
            pbHome.SizeMode = PictureBoxSizeMode.StretchImage;
            pbHome.TabIndex = 19;
            pbHome.TabStop = false;
            pbHome.Click += pbHome_Click;
            // 
            // AppProtection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1118, 795);
            Controls.Add(pbHome);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "AppProtection";
            Text = "AppProtection";
            //Load += AppProtection_Load;
            ((System.ComponentModel.ISupportInitialize)pbHome).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbHome;
    }
}