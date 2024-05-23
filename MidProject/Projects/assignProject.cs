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
    public partial class assignProject : UserControl
    {
        public assignProject()
        {
            InitializeComponent();
            //..............For Group Id ComboBox
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from [Group]", con);
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
            //..............For Project Id ComboBox
            var con1 = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("Select * from Project", con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            string columnName1 = "Id";
            foreach (DataRow row in dt1.Rows)
            {
                // Make sure the column exists in the DataTable
                if (dt1.Columns.Contains(columnName1))
                {
                    object value = row[columnName1];
                    comboBox2.Items.Add(value);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ////////// Add Data in GroupProject Table
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into GroupProject(GroupId, ProjectId,AssignmentDate) values (@GroupId, @ProjectId,@AssignmentDate)", con);
            cmd.Parameters.AddWithValue("@GroupId", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ProjectId", comboBox2.Text);
            cmd.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Project Assigned to Group!");

        }
    }
}
