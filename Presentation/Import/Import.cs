using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Usb;
using static IntuneAssignments.Backend.FormUtilities;
using static IntuneAssignments.Backend.GlobalVariables;
using static IntuneAssignments.Backend.GraphServiceClientCreator;

namespace IntuneAssignments.Presentation.Import
{
    public partial class Import : Form
    {
        public Import()
        {
            InitializeComponent();

            // change the application icon and use the ico file in resources folder
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent

        }



        private void Import_Load(object sender, EventArgs e)
        {

        }










        // Click events

        private async void pbSourceTenant_Click(object sender, EventArgs e)
        {
            // Open the source tenant settings form
            SourceTenantSettings sourceTenantSettings = new SourceTenantSettings();
            sourceTenantSettings.ShowDialog();
        }

        private void pbDestinationTenant_Click(object sender, EventArgs e)
        {
            // Open the destination tenant settings form

            DestinationTenantSettings destinationTenantSettings = new DestinationTenantSettings();
            destinationTenantSettings.ShowDialog();

        }

        private void lblDestination_Click(object sender, EventArgs e)
        {
            // Open the destination tenant settings form

            DestinationTenantSettings destinationTenantSettings = new DestinationTenantSettings();
            destinationTenantSettings.ShowDialog();

        }

        private void pBHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        private void lblSourceTenant_Click(object sender, EventArgs e)
        {
            // Open the source tenant settings form
            SourceTenantSettings sourceTenantSettings = new SourceTenantSettings();
            sourceTenantSettings.ShowDialog();
        }
    }
}
