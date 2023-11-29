using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Policy;
using Windows.Graphics.Printing.PrintSupport;
using Microsoft.Graph.Beta.Models.Networkaccess;
using static System.Net.WebRequestMethods;
using static IntuneAssignments.FormUtilities;

namespace IntuneAssignments
{
    public partial class About : Form
    {
        public About()
        {

            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent

            InitializeComponent();
        }


        private void About_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            WriteToLog("Closing the About page");
            WriteToLog("Opening the Main Menu page");
            this.Close();
        }

        private void lnklblGithubURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            // Opens the URL in the default browser

            const string URL = "https://github.com/Kvikku/IntuneAssignments";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = URL,
                UseShellExecute = true
            };
            Process.Start(psi);

            WriteToLog("Opened the GitHub URL in the default browser");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            // Opens the URL in the default browser

            const string URL = "https://choosealicense.com/licenses/mit/";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = URL,
                UseShellExecute = true
            };
            Process.Start(psi);

            WriteToLog("Opened the MIT License URL in the default browser");

        }

    }
}
