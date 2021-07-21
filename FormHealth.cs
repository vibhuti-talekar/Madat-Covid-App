using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadatCovid
{
    public partial class FormHealth : Form
    {
        public FormHealth()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            MadatApp home = new MadatApp();
            home.Show();
            this.Hide();
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            VolunteerReg vol = new VolunteerReg();
            vol.Show();
            this.Hide();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            VolunteerFind volfind = new VolunteerFind();
            volfind.Show();
            this.Hide();
        }
    }
}
