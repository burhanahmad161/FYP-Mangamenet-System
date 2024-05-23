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
    public partial class addStudent : UserControl
    {
        public addStudent()
        {
            InitializeComponent();
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int gen = 2;
            if (comboBox1.Text == "Male")
                gen = 1;
            else
                gen = 2;
            ////////// Add Data in Person Table
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Person(FirstName, LastName,Contact,Email,DateOfBirth,Gender) values (@FirstName, @LastName,@Contact,@Email,@DateOfBirth,@Gender)", con);
            cmd.Parameters.AddWithValue("@FirstName", textBox2.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox3.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox5.Text);
            cmd.Parameters.AddWithValue("@Email", textBox6.Text);
            cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Gender", gen);
            cmd.ExecuteNonQuery();
            ////////// Fetching Id from Person Table
            var cmd3 = new SqlCommand("Select Id from Person where FirstName = @FirstName and LastName = @LastName and Email = @Email and Contact = @Contact", con);
            cmd3.Parameters.AddWithValue("@FirstName", textBox2.Text);
            cmd3.Parameters.AddWithValue("@LastName", textBox3.Text);
            cmd3.Parameters.AddWithValue("@Contact", textBox5.Text);
            cmd3.Parameters.AddWithValue("@Email", textBox6.Text);
            int personId = (int)cmd3.ExecuteScalar();
            ////////// Add Data in Student Table
            SqlCommand cmd2 = new SqlCommand("Insert into Student values (@personId,@RegistrationNo)", con);
            cmd2.Parameters.AddWithValue("@personId", personId);
            cmd2.Parameters.AddWithValue("@RegistrationNo", textBox4.Text);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Student Added!");
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
    }
}
