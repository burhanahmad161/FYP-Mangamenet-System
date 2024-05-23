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

namespace MidProject.Advisor
{
    public partial class assignAdvisor : UserControl
    {
        public assignAdvisor()
        {
            InitializeComponent();
            //.........View Assigned Advisors
            var con = Configuration.getInstance().getConnection();
            //.........Add items to comboBox3
            comboBox3.Items.Add("Co-Advisor");
            comboBox3.Items.Add("Main Advisor");
            comboBox3.Items.Add("Industrial Advisor");
            //.........Add items to combobox1
            SqlCommand cmd = new SqlCommand("Select * from [Project]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string columnName = "Id";
            foreach (DataRow row in dt.Rows)
            {
                // Make sure the column exists in the DataTable
                if (dt.Columns.Contains(columnName))
                {
                    object value = row[columnName];
                    comboBox1.Items.Add(value);
                }
            }
            //.........Add items to comboBox2
            SqlCommand cmd2 = new SqlCommand("Select * from [Advisor]", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            string columnName2 = "Id";
            foreach (DataRow row in dt2.Rows)
            {
                // Make sure the column exists in the DataTable
                if (dt2.Columns.Contains(columnName2))
                {
                    object value = row[columnName2];
                    comboBox2.Items.Add(value);
                }
            }
            loadData();
        }
        void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select * from ProjectAdvisor", con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int advisor = 11;
            if (comboBox3.Text == "Co-Advisor")
                advisor = 12;
            else if (comboBox3.Text == "Industrial Advisor")
                advisor = 14;
            ////////// Add Data in ProjectAdvisor Table
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into ProjectAdvisor(AdvisorId,ProjectId,AdvisorRole,AssignmentDate) values (@AdvisorId,@ProjectId,@AdvisorRole,@AssignmentDate)", con);
            cmd.Parameters.AddWithValue("@AdvisorId", comboBox2.Text);
            cmd.Parameters.AddWithValue("@ProjectId", comboBox1.Text);
            cmd.Parameters.AddWithValue("@AdvisorRole", advisor);
            cmd.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Adviosr Assigned!");
            loadData();
        }
    }
}
