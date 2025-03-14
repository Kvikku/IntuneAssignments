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
            pBHome = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pBHome).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pBHome);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(102, 915);
            panel1.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)pBHome).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pBHome;
    }
}