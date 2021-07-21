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
    public partial class VolunteerFind : Form
    {
        public VolunteerFind()
        {
            InitializeComponent();
        }

        private void StudentDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VolunteerFind_Load(object sender, EventArgs e)
        {
            GetVolunteerView();
        }

        private void GetVolunteerView()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-PJCPBFS6;Initial Catalog=MadatCovid;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from VolunteerReg", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            StudentDataGrid.DataSource = dt;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            FormHealth health = new FormHealth();
            health.Show();
            this.Hide();
        }
    }
}
