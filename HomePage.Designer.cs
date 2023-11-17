namespace IntuneAssignments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            label1 = new Label();
            pbGoToApplication = new PictureBox();
            pbGoToPolicy = new PictureBox();
            GoToAbout = new PictureBox();
            GoToSettings = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbGoToApplication).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGoToPolicy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GoToAbout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GoToSettings).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(320, 200);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "TEST";
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
            pbGoToPolicy.Click += pbGoToPolicy_Click;
            // 
            // GoToAbout
            // 
            GoToAbout.Image = (Image)resources.GetObject("GoToAbout.Image");
            GoToAbout.Location = new Point(12, 153);
            GoToAbout.Name = "GoToAbout";
            GoToAbout.Size = new Size(64, 64);
            GoToAbout.SizeMode = PictureBoxSizeMode.AutoSize;
            GoToAbout.TabIndex = 3;
            GoToAbout.TabStop = false;
            GoToAbout.Click += GoToAbout_Click;
            // 
            // GoToSettings
            // 
            GoToSettings.Image = (Image)resources.GetObject("GoToSettings.Image");
            GoToSettings.Location = new Point(12, 223);
            GoToSettings.Name = "GoToSettings";
            GoToSettings.Size = new Size(64, 64);
            GoToSettings.SizeMode = PictureBoxSizeMode.AutoSize;
            GoToSettings.TabIndex = 4;
            GoToSettings.TabStop = false;
            GoToSettings.Click += GoToSettings_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(800, 450);
            Controls.Add(GoToSettings);
            Controls.Add(GoToAbout);
            Controls.Add(pbGoToPolicy);
            Controls.Add(pbGoToApplication);
            Controls.Add(label1);
            ForeColor = Color.Black;
            Name = "HomePage";
            Text = "HomePage";
            Load += HomePage_Load;
            ((System.ComponentModel.ISupportInitialize)pbGoToApplication).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGoToPolicy).EndInit();
            ((System.ComponentModel.ISupportInitialize)GoToAbout).EndInit();
            ((System.ComponentModel.ISupportInitialize)GoToSettings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pbGoToApplication;
        private PictureBox pbGoToPolicy;
        private PictureBox GoToAbout;
        private PictureBox GoToSettings;
    }
}