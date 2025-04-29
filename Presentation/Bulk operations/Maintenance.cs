using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntuneAssignments.Presentation.Bulk_operations
{
    public partial class Maintenance : Form
    {
        private const int ExpandedHeight = 200; // Adjust as needed
        private const int CollapsedHeight = 100; // Adjust as needed
        public Maintenance()
        {
            InitializeComponent();

            // change the application icon and use the ico file in resources folder
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent
        }

        private void pBHome_Click(object sender, EventArgs e)
        {
            // Go back to the main menu
            this.Hide();
            HomePage mainMenu = new HomePage();
            mainMenu.ShowDialog();
        }
    }
}
