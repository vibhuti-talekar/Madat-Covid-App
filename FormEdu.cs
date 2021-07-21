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
    public partial class FormEdu : Form
    {
        public FormEdu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
           StudentView stdView = new StudentView();
            stdView.Show();
            this.Hide();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            MadatApp home = new MadatApp();
            home.Show();
            this.Hide();
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            TrRegistration tr = new TrRegistration();
            tr.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            Notes not = new Notes();
            not.Show();
            this.Hide();
        }
    }
}
