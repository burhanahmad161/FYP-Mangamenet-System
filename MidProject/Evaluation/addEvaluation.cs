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

namespace MidProject.Evaluation
{
    public partial class addEvaluation : UserControl
    {
        public addEvaluation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////////// Add Data in Evaluation Table
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Evaluation(Name,TotalMarks,TotalWeightage) values (@Name, @TotalMarks,@TotalWeightage)", con);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@TotalMarks", textBox3.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Evaluation Added!");

        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Evaluation Name")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.DimGray;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Evaluation Name";
                textBox2.ForeColor = Color.DimGray;
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter Total Marks")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.DimGray;
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter Total Marks";
                textBox3.ForeColor = Color.DimGray;
            }
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Enter Total Weightage")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.DimGray;
            }
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Enter Total Weightage";
                textBox4.ForeColor = Color.DimGray;
            }
        }
    }
}
