using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;



namespace IntuneAssignments
{
    public partial class Settings : Form
    {

        private readonly Form1 _form1;
        public Settings()
        {

            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent


            


            InitializeComponent();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            // Retrieve data from appsettings.json and populate labels

            string path = @"C:\ProgramData\IntuneAssignments" + @"\AppSettings.json";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(path)
                .Build();

            string tenantID = configuration.GetSection("Entra:TenantId").Value;
            string clientID = configuration.GetSection("Entra:ClientId").Value;
            string clientSecret = configuration.GetSection("Entra:ClientSecret").Value;


            lblTenantIDString.Text = tenantID;
            lblClientIDString.Text = clientID;
            lblClientSecretString.Text = clientSecret;



        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            // Open file explorer
            System.Diagnostics.Process.Start("explorer.exe", @"C:\ProgramData\IntuneAssignments");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Attempt to authenticate to Graph API with the current settings


            
            var graphClient = Form1.MSGraphAuthenticator.GetAuthenticatedGraphClient();

            // query for tenant name
            var tenant = graphClient.Result.Organization.GetAsync();

            MessageBox.Show(tenant.Result.ToString());

        }
    }
}
