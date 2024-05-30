using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IntuneAssignments.Application;


namespace IntuneAssignments.Presentation.Application.App_protection
{
    public partial class AppProtection : Form
    {
        // Global variables
        private readonly IntuneAssignments.Application _application;


        // Load and startup mechanics
        public AppProtection(IntuneAssignments.Application application)
        {
            InitializeComponent();
            _application = application;
            
        }

        protected override void OnLoad(EventArgs e)
        {
            // Necessary to copy the location of Form1
            base.OnLoad(e);

            // Set the location of the form to the position of Form1
            if (_application != null)
            {
                Location = new Point(
                    _application.Location.X + (_application.Width - Width) / 2,
                    _application.Location.Y + (_application.Height - Height) / 2);
            }
        }





        // Navigation mechanics
        private void goHome()
        {
            this.Hide();
            IntuneAssignments.Application application = new IntuneAssignments.Application();
            application.Show();
        }




        // Event handlers for the navigation buttons
        private void pbHome_Click(object sender, EventArgs e)
        {
            goHome();
        }


    }
}
