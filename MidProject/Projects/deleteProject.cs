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
    public partial class deleteProject : UserControl
    {
        public deleteProject()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Project WHERE (SUBSTRING(Description, 1, 2)) <> '#@'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //........Fetch ComboBox Data
            string columnName = "Title";
            string columnName2 = "Description";
            foreach (DataRow row in dt.Rows)
            {
                // Make sure the column exists in the DataTable
                if (dt.Columns.Contains(columnName))
                {
                    object value = row[columnName];
                    object value2 = row[columnName2];
                    comboBox1.Items.Add(value);
                    comboBox2.Items.Add(value2);
                }
            }
        }
        private void deleteProject_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                loadData();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string name = "#@" + comboBox2.Text;

            // Query to Update
            SqlCommand cmd = new SqlCommand("UPDATE Project SET Description = @Description WHERE Title = @title and Description = @desc", con);
            cmd.Parameters.AddWithValue("@Description", name);
            cmd.Parameters.AddWithValue("@title", comboBox1.Text);
            cmd.Parameters.AddWithValue("@desc", comboBox2.Text);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Successfully Deleted");
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                loadData();
            }
            else
            {
                MessageBox.Show("No matching record found for the provided Title and Description.");
            }
        }
    }
}
