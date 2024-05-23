using Guna.UI2.WinForms.Suite;
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

namespace MidProject.Projects
{
    public partial class addProject : UserControl
    {
        public addProject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////////// Add Data in Project Table
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Project(Title,Description) values (@Title, @Description)", con);
            cmd.Parameters.AddWithValue("@Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@Description", textBox3.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Project Added!");
            textBox2.Text = "Enter Project Title";
            textBox3.Text = "Enter Project Description";
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Project Title")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.DimGray;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Project Title";
                textBox2.ForeColor = Color.DimGray;
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter Project Description")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.DimGray;
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter Project Description";
                textBox3.ForeColor = Color.DimGray;
            }
        }
    }
}
