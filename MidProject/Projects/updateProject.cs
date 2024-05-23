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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MidProject.Projects
{
    public partial class updateProject : UserControl
    {
        public updateProject()
        {
            InitializeComponent();
            loadData();


        }
        void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Project WHERE (SUBSTRING(Description, 1, 2)) <> '#@'", con);
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
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Enter Project Description")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.DimGray;
            }
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Enter Project Description";
                textBox4.ForeColor = Color.DimGray;
            }
        }

        private void updateProject_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible)
                loadData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Update data in Project Table
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Project SET Title=@Title, Description=@Description where Id = @Id", con);
            cmd.Parameters.AddWithValue("@Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@Description", textBox4.Text);
            cmd.Parameters.AddWithValue("@Id", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Project Updated!");
            comboBox1.Items.Clear();
            loadData();
            textBox2.Hide();
            textBox4.Hide();
            button1.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Show();
            textBox4.Show();
            button1.Show();
            // Fetch Data Based on selected ID
            int id = int.Parse(comboBox1.Text);
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Title,Description FROM Project WHERE (SUBSTRING(Description, 1, 2)) <> '#@'", con);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Retrieve values from the SqlDataReader and store in strings
                textBox2.Text = reader["Title"].ToString();
                textBox4.Text = reader["Description"].ToString();
            }
            reader.Close();
        }
    }
}
