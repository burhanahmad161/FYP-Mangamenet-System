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
    public partial class updateEvaluation : UserControl
    {
        public updateEvaluation()
        {
            InitializeComponent();
            loadData();
        }
    private void textBox3_Enter(object sender, EventArgs e)
    {
        if (textBox3.Text == "Enter Total Marks")
        {
            textBox3.Text = "";
            textBox3.ForeColor = Color.DimGray;
        }
    }
        void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Evaluation WHERE (SUBSTRING(Name, 1, 2)) <> '#@'", con);
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
    private void textBox3_Leave(object sender, EventArgs e)
    {
        if (textBox3.Text == "")
        {
            textBox3.Text = "Enter Total Marks";
            textBox3.ForeColor = Color.DimGray;
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Evaluation SET Name = @Name,TotalMarks=@TotalMarks, TotalWeightage = @TotalWeightage WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@TotalMarks", textBox3.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", textBox4.Text);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@ID",comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Evaluation Updated!");
            comboBox1.Items.Clear();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            button1.Hide();
            loadData();
        }
        private void updateEvaluation_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Show();
            textBox3.Show();
            textBox4.Show();
            button1.Show();
            // Fetch Data Based on selected ID
            int id = int.Parse(comboBox1.Text);
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Name, TotalMarks, TotalWeightage FROM Evaluation WHERE (SUBSTRING(Name, 1, 2)) <> '#@'", con);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Retrieve values from the SqlDataReader and store in strings
                textBox2.Text = reader["Name"].ToString();
                textBox3.Text = reader["TotalMarks"].ToString();
                textBox4.Text = reader["TotalWeightage"].ToString();
            }
            reader.Close();
        }
    }
}
