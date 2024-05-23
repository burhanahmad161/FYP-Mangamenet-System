using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidProject
{
    public partial class updateStudent : UserControl
    {
        public updateStudent()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Person.Id, FirstName, LastName, Contact, Email, Gender, RegistrationNo from Student Inner Join Person on Student.Id = Person.ID WHERE (SUBSTRING(FirstName, 1, 2)) <> '#@'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            string columnName1 = "Id";
            foreach (DataRow row in dt.Rows)
            {
                // Make sure the column exists in the DataTable
                if (dt.Columns.Contains(columnName1))
                {
                    object value = row[columnName1];
                    comboBox1.Items.Add(value);
                }
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter First Name")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.DimGray;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter First Name";
                textBox2.ForeColor = Color.DimGray;
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter Last Name")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.DimGray;
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter Last Name";
                textBox3.ForeColor = Color.DimGray;
            }
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Enter Registration Number")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.DimGray;
            }
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Enter Registration Number";
                textBox4.ForeColor = Color.DimGray;
            }
        }
        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Enter Contact Number")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.DimGray;
            }
        }
        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Enter Contact Number";
                textBox5.ForeColor = Color.DimGray;
            }
        }
        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Enter Email Address")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.DimGray;
            }
        }
        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Enter Email Address";
                textBox6.ForeColor = Color.DimGray;
            }
        }
        private void updateStudent_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible)
            {
                loadData();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Update data in Person Table
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Person SET FirstName = @FirstName, LastName = @LastName, Contact = @Contact, Email = @Email, DateOfBirth = @DateOfBirth WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@FirstName", textBox2.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox3.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox5.Text);
            cmd.Parameters.AddWithValue("@Email", textBox6.Text);
            cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Id", comboBox1.Text);
            cmd.ExecuteNonQuery();
            // Update Data in Advisor Table
            SqlCommand cmd2 = new SqlCommand("UPDATE Student SET RegistrationNo = @RegistrationNo WHERE Id = @Id", con);
            cmd2.Parameters.AddWithValue("@RegistrationNo", textBox4.Text);
            cmd2.Parameters.AddWithValue("@Id", comboBox1.Text);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Advisor Updated!");
            comboBox1.Items.Clear();
            loadData();
            textBox3.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dateTimePicker1.Refresh();
            textBox3.Hide();
            textBox2.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            dateTimePicker1.Hide();
            button1.Hide();
            dataGridView1.Refresh();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Show();
            textBox3.Show();
            textBox2.Show();
            textBox4.Show();
            textBox5.Show();
            textBox6.Show();
            dateTimePicker1.Show();
            button1.Show();
            // Fetch Data Based on selected ID
            int id = int.Parse(comboBox1.Text);
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT FirstName, LastName, Contact, Email, Gender, RegistrationNo FROM Student INNER JOIN Person ON Student.Id = Person.ID WHERE Person.Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Retrieve values from the SqlDataReader and store in strings
                textBox2.Text = reader["FirstName"].ToString();
                textBox3.Text = reader["LastName"].ToString();
                textBox5.Text = reader["Contact"].ToString();
                textBox6.Text = reader["Email"].ToString();
                textBox4.Text = reader["RegistrationNo"].ToString();
            }
            reader.Close();
        }
    }
}
