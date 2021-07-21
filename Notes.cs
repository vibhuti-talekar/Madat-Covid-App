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
    public partial class Notes : Form
    {
        public Notes()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-PJCPBFS6;Initial Catalog=MadatCovid;Integrated Security=True");
        public int IdNo;


        private void NotesDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdNo = Convert.ToInt32(NotesDataGrid.SelectedRows[0].Cells[0].Value);
            nameTB.Text = NotesDataGrid.SelectedRows[0].Cells[1].Value.ToString();
            standardTB.Text = NotesDataGrid.SelectedRows[0].Cells[2].Value.ToString();
            subjectTB.Text = NotesDataGrid.SelectedRows[0].Cells[3].Value.ToString();
            lessonTB.Text = NotesDataGrid.SelectedRows[0].Cells[4].Value.ToString();
            linkTB.Text = NotesDataGrid.SelectedRows[0].Cells[5].Value.ToString();
           
        }

        private void Notes_Load(object sender, EventArgs e)
        {
            GetNoteView();
        }

        private void GetNoteView()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-PJCPBFS6;Initial Catalog=MadatCovid;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from NotesA", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            NotesDataGrid.DataSource = dt;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            FormEdu educ = new FormEdu();
            educ.Show();
            this.Hide();
        }

        private void materialButton6_Click(object sender, EventArgs e)//insert
        {

            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO NotesA VALUES(@name,@standard,@subject,@lesson,@link)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", nameTB.Text);
                cmd.Parameters.AddWithValue("@standard", standardTB.Text);
                cmd.Parameters.AddWithValue("@subject", subjectTB.Text);
                cmd.Parameters.AddWithValue("@lesson", lessonTB.Text);
                cmd.Parameters.AddWithValue("@link", linkTB.Text);
                

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Record Created", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                GetNoteView();
            }

        }

        private bool IsValid()
        {
            if (nameTB.Text == string.Empty)
            {
                MessageBox.Show("Name is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void materialButton3_Click(object sender, EventArgs e)//delete
        {
            if (IdNo > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM NotesA WHERE IdNo=@ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.IdNo);

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show(" Deleted Entry", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetNoteView();
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
            IdNo = 0;
            nameTB.Clear();
            standardTB.Clear();
            subjectTB.Clear();
            lessonTB.Clear();
            linkTB.Clear();
            

        }

        private void materialButton2_Click(object sender, EventArgs e)//update button
        {
            if (IdNo > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE NotesA SET Name=@name,Standard=@standard,Subject=@subject,Lesson=@lesson,Link=@link WHERE IdNo=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", nameTB.Text);
                cmd.Parameters.AddWithValue("@standard", standardTB.Text);
                cmd.Parameters.AddWithValue("@subject", subjectTB.Text);
                cmd.Parameters.AddWithValue("@lesson", lessonTB.Text);
                cmd.Parameters.AddWithValue("@link", linkTB.Text);
                cmd.Parameters.AddWithValue("@ID", this.IdNo);

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Information Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetNoteView();
                Reset();
            }

            else
            {
                MessageBox.Show("Please Select From the Form", "Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
