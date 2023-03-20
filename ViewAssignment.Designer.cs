﻿namespace IntuneAssignments
{
    partial class ViewAssignment
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
            pnlSearchApp = new Panel();
            pbClearDtgDisplayApp = new PictureBox();
            lblSearchApp = new Label();
            dtgDisplayApp = new DataGridView();
            AppName = new DataGridViewTextBoxColumn();
            Platform = new DataGridViewTextBoxColumn();
            AppID = new DataGridViewTextBoxColumn();
            txtboxSearchApp = new TextBox();
            btnSearchApp = new Button();
            btnAllGroups = new Button();
            panel1 = new Panel();
            pbpbClearDtgGroupAssignment = new PictureBox();
            dtgGroupAssignment = new DataGridView();
            GroupName = new DataGridViewTextBoxColumn();
            Intent = new DataGridViewTextBoxColumn();
            pbHome = new PictureBox();
            tstbtn1 = new Button();
            pnlSearchApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbClearDtgDisplayApp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayApp).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbpbClearDtgGroupAssignment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgGroupAssignment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbHome).BeginInit();
            SuspendLayout();
            // 
            // pnlSearchApp
            // 
            pnlSearchApp.Controls.Add(pbClearDtgDisplayApp);
            pnlSearchApp.Controls.Add(lblSearchApp);
            pnlSearchApp.Controls.Add(dtgDisplayApp);
            pnlSearchApp.Controls.Add(txtboxSearchApp);
            pnlSearchApp.Controls.Add(btnSearchApp);
            pnlSearchApp.Controls.Add(btnAllGroups);
            pnlSearchApp.Location = new Point(12, 12);
            pnlSearchApp.Name = "pnlSearchApp";
            pnlSearchApp.Size = new Size(470, 589);
            pnlSearchApp.TabIndex = 0;
            // 
            // pbClearDtgDisplayApp
            // 
            pbClearDtgDisplayApp.Image = Properties.Resources._5358270771574330938_32;
            pbClearDtgDisplayApp.Location = new Point(415, 30);
            pbClearDtgDisplayApp.Name = "pbClearDtgDisplayApp";
            pbClearDtgDisplayApp.Size = new Size(36, 38);
            pbClearDtgDisplayApp.TabIndex = 18;
            pbClearDtgDisplayApp.TabStop = false;
            pbClearDtgDisplayApp.Click += pbClearDtgDisplayApp_Click;
            // 
            // lblSearchApp
            // 
            lblSearchApp.AutoSize = true;
            lblSearchApp.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblSearchApp.ForeColor = Color.Salmon;
            lblSearchApp.Location = new Point(12, 5);
            lblSearchApp.Name = "lblSearchApp";
            lblSearchApp.Size = new Size(259, 30);
            lblSearchApp.TabIndex = 17;
            lblSearchApp.Text = "Search for an application";
            // 
            // dtgDisplayApp
            // 
            dtgDisplayApp.AllowUserToAddRows = false;
            dtgDisplayApp.AllowUserToDeleteRows = false;
            dtgDisplayApp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDisplayApp.Columns.AddRange(new DataGridViewColumn[] { AppName, Platform, AppID });
            dtgDisplayApp.Location = new Point(12, 74);
            dtgDisplayApp.Name = "dtgDisplayApp";
            dtgDisplayApp.ReadOnly = true;
            dtgDisplayApp.RowTemplate.Height = 25;
            dtgDisplayApp.Size = new Size(455, 512);
            dtgDisplayApp.TabIndex = 16;
            dtgDisplayApp.CellMouseDoubleClick += dtgDisplayApp_CellMouseDoubleClick;
            // 
            // AppName
            // 
            AppName.HeaderText = "App name";
            AppName.Name = "AppName";
            AppName.ReadOnly = true;
            AppName.Width = 200;
            // 
            // Platform
            // 
            Platform.HeaderText = "Platform";
            Platform.Name = "Platform";
            Platform.ReadOnly = true;
            // 
            // AppID
            // 
            AppID.HeaderText = "ID";
            AppID.Name = "AppID";
            AppID.ReadOnly = true;
            // 
            // txtboxSearchApp
            // 
            txtboxSearchApp.Location = new Point(12, 45);
            txtboxSearchApp.Name = "txtboxSearchApp";
            txtboxSearchApp.Size = new Size(142, 23);
            txtboxSearchApp.TabIndex = 14;
            // 
            // btnSearchApp
            // 
            btnSearchApp.Location = new Point(160, 38);
            btnSearchApp.Name = "btnSearchApp";
            btnSearchApp.Size = new Size(119, 30);
            btnSearchApp.TabIndex = 15;
            btnSearchApp.Text = "Search";
            btnSearchApp.UseVisualStyleBackColor = true;
            btnSearchApp.Click += btnSearchApp_Click_1;
            // 
            // btnAllGroups
            // 
            btnAllGroups.Location = new Point(285, 38);
            btnAllGroups.Name = "btnAllGroups";
            btnAllGroups.Size = new Size(124, 30);
            btnAllGroups.TabIndex = 13;
            btnAllGroups.Text = "List all apps";
            btnAllGroups.UseVisualStyleBackColor = true;
            btnAllGroups.Click += btnAllGroups_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pbpbClearDtgGroupAssignment);
            panel1.Controls.Add(dtgGroupAssignment);
            panel1.Location = new Point(500, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(470, 589);
            panel1.TabIndex = 17;
            // 
            // pbpbClearDtgGroupAssignment
            // 
            pbpbClearDtgGroupAssignment.Image = Properties.Resources._5358270771574330938_32;
            pbpbClearDtgGroupAssignment.Location = new Point(431, 30);
            pbpbClearDtgGroupAssignment.Name = "pbpbClearDtgGroupAssignment";
            pbpbClearDtgGroupAssignment.Size = new Size(36, 38);
            pbpbClearDtgGroupAssignment.TabIndex = 19;
            pbpbClearDtgGroupAssignment.TabStop = false;
            pbpbClearDtgGroupAssignment.Click += pbpbClearDtgGroupAssignment_Click;
            // 
            // dtgGroupAssignment
            // 
            dtgGroupAssignment.AllowUserToAddRows = false;
            dtgGroupAssignment.AllowUserToDeleteRows = false;
            dtgGroupAssignment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgGroupAssignment.Columns.AddRange(new DataGridViewColumn[] { GroupName, Intent });
            dtgGroupAssignment.Location = new Point(12, 74);
            dtgGroupAssignment.Name = "dtgGroupAssignment";
            dtgGroupAssignment.RowTemplate.Height = 25;
            dtgGroupAssignment.Size = new Size(455, 512);
            dtgGroupAssignment.TabIndex = 16;
            // 
            // GroupName
            // 
            GroupName.HeaderText = "Group name";
            GroupName.Name = "GroupName";
            GroupName.Width = 200;
            // 
            // Intent
            // 
            Intent.HeaderText = "Intent";
            Intent.Name = "Intent";
            // 
            // pbHome
            // 
            pbHome.Image = Properties.Resources._15536420761558096328_48;
            pbHome.Location = new Point(1047, 12);
            pbHome.Name = "pbHome";
            pbHome.Size = new Size(50, 50);
            pbHome.TabIndex = 18;
            pbHome.TabStop = false;
            pbHome.Click += pbHome_Click;
            // 
            // tstbtn1
            // 
            tstbtn1.Location = new Point(234, 665);
            tstbtn1.Name = "tstbtn1";
            tstbtn1.Size = new Size(120, 45);
            tstbtn1.TabIndex = 19;
            tstbtn1.Text = "test delete";
            tstbtn1.UseVisualStyleBackColor = true;
            tstbtn1.Click += tstbtn1_Click;
            // 
            // ViewAssignment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1109, 893);
            Controls.Add(tstbtn1);
            Controls.Add(pbHome);
            Controls.Add(panel1);
            Controls.Add(pnlSearchApp);
            Name = "ViewAssignment";
            Text = "ViewAssignment";
            Load += ViewAssignment_Load;
            pnlSearchApp.ResumeLayout(false);
            pnlSearchApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbClearDtgDisplayApp).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgDisplayApp).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbpbClearDtgGroupAssignment).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgGroupAssignment).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbHome).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSearchApp;
        private TextBox txtboxSearchApp;
        private Button btnSearchApp;
        private Button btnAllGroups;
        private DataGridView dtgDisplayApp;
        private Panel panel1;
        private DataGridView dtgGroupAssignment;
        private DataGridViewTextBoxColumn GroupName;
        private DataGridViewTextBoxColumn Intent;
        private PictureBox pbHome;
        private DataGridViewTextBoxColumn AppName;
        private DataGridViewTextBoxColumn Platform;
        private DataGridViewTextBoxColumn AppID;
        private Label lblSearchApp;
        private PictureBox pbClearDtgDisplayApp;
        private PictureBox pbpbClearDtgGroupAssignment;
        private Button tstbtn1;
    }
}