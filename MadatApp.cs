using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace MadatCovid
{
    public partial class MadatApp : Form
    {
        public MadatApp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void materialButton3_Click(object sender, EventArgs e)//to open job app
        {
            FormJob job = new FormJob();
            job.Show();
            
            this.Hide();
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            

        }

        private void materialButton7_Click(object sender, EventArgs e)
        {

        }

        private void materialButton6_Click(object sender, EventArgs e)//to open Health app
        {
            FormHealth health = new FormHealth();
            health.Show();
            this.Hide();
        }

        private void materialButton1_Click(object sender, EventArgs e)//to open education app
        {
            FormEdu edu = new FormEdu();
            edu.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random randomValue = new Random();
            int A = randomValue.Next(0, 255);
            int B = randomValue.Next(0, 255);
            int C = randomValue.Next(0, 255);
            label8.ForeColor = System.Drawing.Color.FromArgb(A, B, C);
        }
    }
}
