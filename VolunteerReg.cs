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
    public partial class VolunteerReg : Form
    {
        public VolunteerReg()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-PJCPBFS6;Initial Catalog=MadatCovid;Integrated Security=True");
        public int SrNo;

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void VolunteerReg_Load(object sender, EventArgs e)
        {
            GetVolunteerView();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            FormHealth health = new FormHealth();
            health.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            SrNo = 0;
            nameTB.Clear();
            genderTB.Clear();
            serviceTB.Clear();
            locationTB.Clear();
            phonenoTB.Clear();
            emailTB.Clear();
            vehicleTB.Clear();

        }

        private void materialButton6_Click(object sender, EventArgs e)//insert button
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO VolunteerReg VALUES(@name,@gender,@service,@location,@phoneno,@email,@vehicletype)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", nameTB.Text);
            cmd.Parameters.AddWithValue("@gender", genderTB.Text);
            cmd.Parameters.AddWithValue("@service", serviceTB.Text);
            cmd.Parameters.AddWithValue("@location", locationTB.Text);
            cmd.Parameters.AddWithValue("@phoneno", phonenoTB.Text);
            cmd.Parameters.AddWithValue("@email", emailTB.Text);
            cmd.Parameters.AddWithValue("@vehicletype", vehicleTB.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Record Created", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            GetVolunteerView();
            Reset();
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
            VolunteerDataGrid.DataSource = dt;
        }


        private void materialButton2_Click(object sender, EventArgs e)//delete
        {
            
                if (SrNo > 0)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM VolunteerReg WHERE SrNo=@ID", con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", this.SrNo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();


                    MessageBox.Show(" Deleted Entry", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetVolunteerView();
                    Reset();
                }

                else
                {
                    MessageBox.Show("Please Select From the Form", "Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void materialButton3_Click(object sender, EventArgs e)//update
        {
            if (SrNo > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE VolunteerReg SET Name=@name,Gender=@gender,Service=@service,Location=@location,PhoneNo=@phoneno,EmailID=@email,VehicleType=@vehicletype WHERE SrNo=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", nameTB.Text);
                cmd.Parameters.AddWithValue("@gender", genderTB.Text);
                cmd.Parameters.AddWithValue("@service", serviceTB.Text);
                cmd.Parameters.AddWithValue("@location", locationTB.Text);
                cmd.Parameters.AddWithValue("@phoneno", phonenoTB.Text);
                cmd.Parameters.AddWithValue("@email", emailTB.Text);
                cmd.Parameters.AddWithValue("@vehicletype", vehicleTB.Text);
                cmd.Parameters.AddWithValue("@ID", this.SrNo);

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Information Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetVolunteerView();
                Reset();
            }

            else
            {
                MessageBox.Show("Please Select From the Form", "Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VolunteerDataGrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SrNo = Convert.ToInt32(VolunteerDataGrid.SelectedRows[0].Cells[0].Value);
            nameTB.Text = VolunteerDataGrid.SelectedRows[0].Cells[1].Value.ToString();
            genderTB.Text = VolunteerDataGrid.SelectedRows[0].Cells[2].Value.ToString();
            serviceTB.Text = VolunteerDataGrid.SelectedRows[0].Cells[3].Value.ToString();
            locationTB.Text = VolunteerDataGrid.SelectedRows[0].Cells[4].Value.ToString();
            phonenoTB.Text = VolunteerDataGrid.SelectedRows[0].Cells[5].Value.ToString();
            emailTB.Text = VolunteerDataGrid.SelectedRows[0].Cells[6].Value.ToString();
            vehicleTB.Text = VolunteerDataGrid.SelectedRows[0].Cells[7].Value.ToString();
        }
    }   
}

