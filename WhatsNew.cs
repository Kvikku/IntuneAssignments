using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IntuneAssignments.FormUtilities;

namespace IntuneAssignments
{
    public partial class WhatsNew : Form
    {
        public WhatsNew()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent

            InitializeComponent();
        }

        private void linklblGithubURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Opens the URL in the default browser

            const string URL = "https://github.com/Kvikku/IntuneAssignments/releases";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = URL,
                UseShellExecute = true
            };
            Process.Start(psi);

            WriteToLog("Opened the GitHub URL in the default browser");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            WriteToLog("Closing the About page");
            WriteToLog("Opening the Main Menu page");
            this.Close();
        }
    }
}
