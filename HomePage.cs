using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntuneAssignments
{
    public partial class HomePage : Form
    {
        private readonly Form1 _form1;

        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {


            // Work on location of the form when loading

        }



        private void pbGoToApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();




        }

        private void pbGoToPolicy_Click(object sender, EventArgs e)
        {






        }

        private void GoToAbout_Click(object sender, EventArgs e)
        {





        }

        private void GoToSettings_Click(object sender, EventArgs e)
        {





        }


    }
}
