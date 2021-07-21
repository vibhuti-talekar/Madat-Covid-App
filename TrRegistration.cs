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
    public partial class TrRegistration : Form
    {
        public TrRegistration()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-PJCPBFS6;Initial Catalog=MadatCovid;Integrated Security=True");
        public int SrNo;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void materialMultiLineTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TrRegistration_Load(object sender, EventArgs e)
        { 
            GetStudentView();
        }

        private void GetStudentView()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-PJCPBFS6;Initial Catalog=MadatCovid;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from TeacherReg", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            StudentDataGrid.DataSource = dt;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
           FormEdu educ = new FormEdu();
           educ.Show();
           this.Hide();
        }

        private void materialButton6_Click(object sender, EventArgs e)//insert button
        {
            if(IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TeacherReg VALUES(@name,@gender,@subject,@leveltaught,@medium,@email,@phoneno)",con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", teachname.Text);
                cmd.Parameters.AddWithValue("@gender",genderTB.Text);
                cmd.Parameters.AddWithValue("@subject", subjnameTB.Text);
                cmd.Parameters.AddWithValue("@leveltaught", levelTB.Text);
                cmd.Parameters.AddWithValue("@medium", mediumTB.Text);
                cmd.Parameters.AddWithValue("@email", emailTB.Text); 
                cmd.Parameters.AddWithValue("@phoneno", phoneTB.Text);

                con.Open();
                
                cmd.ExecuteNonQuery();
                con.Close();

           
                MessageBox.Show("Record Created", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                GetStudentView();
            }

        }

        private bool IsValid()
        {
            if(teachname.Text==string.Empty)
            {
                MessageBox.Show("Name is Required","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void materialButton2_Click(object sender, EventArgs e)//update buuton
        {
            if(SrNo>0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE TeacherReg SET Name=@name,Gender=@gender,Subject=@subject,LevelTaught=@leveltaught,Medium=@medium,Email=@email,PhoneNo=@phoneno WHERE SrNo=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", teachname.Text);
                cmd.Parameters.AddWithValue("@gender", genderTB.Text);
                cmd.Parameters.AddWithValue("@subject", subjnameTB.Text);
                cmd.Parameters.AddWithValue("@leveltaught", levelTB.Text);
                cmd.Parameters.AddWithValue("@medium", mediumTB.Text);
                cmd.Parameters.AddWithValue("@email", emailTB.Text);
                cmd.Parameters.AddWithValue("@phoneno", phoneTB.Text);
                cmd.Parameters.AddWithValue("@ID", this.SrNo);

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Information Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentView();
                Reset();
            }

            else
            {
                MessageBox.Show("Please Select From the Form", "Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)//reset button
        {
            Reset();

        }

        private void Reset()
        {
            SrNo = 0;
            teachname.Clear();
            genderTB.Clear();
            subjnameTB.Clear();
            levelTB.Clear();
            mediumTB.Clear();
            emailTB.Clear();
            phoneTB.Clear();

        }

        private void StudentDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SrNo=Convert.ToInt32(StudentDataGrid.SelectedRows[0].Cells[0].Value);
            teachname.Text = StudentDataGrid.SelectedRows[0].Cells[1].Value.ToString();
            genderTB.Text= StudentDataGrid.SelectedRows[0].Cells[2].Value.ToString();
            subjnameTB.Text= StudentDataGrid.SelectedRows[0].Cells[3].Value.ToString();
            levelTB.Text= StudentDataGrid.SelectedRows[0].Cells[4].Value.ToString();
            mediumTB.Text= StudentDataGrid.SelectedRows[0].Cells[5].Value.ToString();
            emailTB.Text = StudentDataGrid.SelectedRows[0].Cells[6].Value.ToString();
            phoneTB.Text= StudentDataGrid.SelectedRows[0].Cells[7].Value.ToString();


        }

        private void materialButton3_Click(object sender, EventArgs e)//delete
        {
            if (SrNo > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM TeacherReg WHERE SrNo=@ID", con);
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("@ID", this.SrNo);

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show(" Deleted Entry", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentView();
                Reset();
            }

            else
            {
                MessageBox.Show("Please Select From the Form", "Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
