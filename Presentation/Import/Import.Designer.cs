namespace IntuneAssignments.Presentation.Import
{
    partial class Import
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
            panel1 = new Panel();
            lblDestination = new Label();
            lblSourceTenant = new Label();
            pbDestinationTenant = new PictureBox();
            pbSourceTenant = new PictureBox();
            pBHome = new PictureBox();
            pbSourceConnectionCheck = new PictureBox();
            pbDestinationChecker = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDestinationTenant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSourceTenant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBHome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSourceConnectionCheck).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDestinationChecker).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pbDestinationChecker);
            panel1.Controls.Add(pbSourceConnectionCheck);
            panel1.Controls.Add(lblDestination);
            panel1.Controls.Add(lblSourceTenant);
            panel1.Controls.Add(pbDestinationTenant);
            panel1.Controls.Add(pbSourceTenant);
            panel1.Controls.Add(pBHome);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(102, 915);
            panel1.TabIndex = 0;
            // 
            // lblDestination
            // 
            lblDestination.AutoSize = true;
            lblDestination.Font = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDestination.ForeColor = Color.Salmon;
            lblDestination.Location = new Point(11, 294);
            lblDestination.Name = "lblDestination";
            lblDestination.Size = new Size(84, 15);
            lblDestination.TabIndex = 18;
            lblDestination.Text = "Destination";
            lblDestination.Click += lblDestination_Click;
            // 
            // lblSourceTenant
            // 
            lblSourceTenant.AutoSize = true;
            lblSourceTenant.Font = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSourceTenant.ForeColor = Color.Salmon;
            lblSourceTenant.Location = new Point(11, 148);
            lblSourceTenant.Name = "lblSourceTenant";
            lblSourceTenant.Size = new Size(49, 15);
            lblSourceTenant.TabIndex = 17;
            lblSourceTenant.Text = "Source";
            lblSourceTenant.Click += lblSourceTenant_Click;
            // 
            // pbDestinationTenant
            // 
            pbDestinationTenant.Image = Properties.Resources.azure;
            pbDestinationTenant.Location = new Point(11, 227);
            pbDestinationTenant.Name = "pbDestinationTenant";
            pbDestinationTenant.Size = new Size(64, 64);
            pbDestinationTenant.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDestinationTenant.TabIndex = 16;
            pbDestinationTenant.TabStop = false;
            pbDestinationTenant.Click += pbDestinationTenant_Click;
            // 
            // pbSourceTenant
            // 
            pbSourceTenant.Image = Properties.Resources.azure;
            pbSourceTenant.Location = new Point(11, 81);
            pbSourceTenant.Name = "pbSourceTenant";
            pbSourceTenant.Size = new Size(64, 64);
            pbSourceTenant.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSourceTenant.TabIndex = 15;
            pbSourceTenant.TabStop = false;
            pbSourceTenant.Click += pbSourceTenant_Click;
            // 
            // pBHome
            // 
            pBHome.Image = Properties.Resources._15536420761558096328_48;
            pBHome.Location = new Point(11, 11);
            pBHome.Name = "pBHome";
            pBHome.Size = new Size(64, 64);
            pBHome.SizeMode = PictureBoxSizeMode.StretchImage;
            pBHome.TabIndex = 14;
            pBHome.TabStop = false;
            pBHome.Click += pBHome_Click;
            // 
            // pbSourceConnectionCheck
            // 
            pbSourceConnectionCheck.Image = Properties.Resources.cancel;
            pbSourceConnectionCheck.Location = new Point(11, 166);
            pbSourceConnectionCheck.Name = "pbSourceConnectionCheck";
            pbSourceConnectionCheck.Size = new Size(38, 35);
            pbSourceConnectionCheck.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSourceConnectionCheck.TabIndex = 19;
            pbSourceConnectionCheck.TabStop = false;
            // 
            // pbDestinationChecker
            // 
            pbDestinationChecker.Image = Properties.Resources.cancel;
            pbDestinationChecker.Location = new Point(11, 312);
            pbDestinationChecker.Name = "pbDestinationChecker";
            pbDestinationChecker.Size = new Size(38, 35);
            pbDestinationChecker.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDestinationChecker.TabIndex = 20;
            pbDestinationChecker.TabStop = false;
            // 
            // Import
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1882, 915);
            Controls.Add(panel1);
            Name = "Import";
            Text = "Import";
            Load += Import_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbDestinationTenant).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSourceTenant).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBHome).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSourceConnectionCheck).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDestinationChecker).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pBHome;
        private PictureBox pbDestinationTenant;
        private PictureBox pbSourceTenant;
        private Label lblDestination;
        private Label lblSourceTenant;
        private PictureBox pbDestinationChecker;
        private PictureBox pbSourceConnectionCheck;
    }
}