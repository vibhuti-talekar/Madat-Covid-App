using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MadatCovid
{
    public partial class JobView : Form
    {
        public JobView()
        {
            InitializeComponent();
        }

        private void JobDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void JobView_Load(object sender, EventArgs e)
        {
            GetJobView();

        }

        private void GetJobView()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-PJCPBFS6;Initial Catalog=MadatCovid;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from Jobreg", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            JobDataGrid.DataSource = dt;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            FormJob job = new FormJob();
            job.Show();
            this.Hide();
        }
    }
}
