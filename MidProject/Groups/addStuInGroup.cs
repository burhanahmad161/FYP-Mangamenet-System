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

namespace MidProject.Groups
{
    public partial class addStuInGroup : UserControl
    {
        public addStuInGroup()
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
            //..............For Student Id ComboBox
            var con1 = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("Select * from [Student]", con);
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
            //.............For Status
            comboBox3.Items.Add("Active");
            comboBox3.Items.Add("InActive");

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int status = 4;
            if (comboBox3.Text == "Active")
                status = 3;
            ////////// Add Data in Person Table
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into GroupStudent(GroupId, StudentId,AssignmentDate,Status) values (@GroupId, @StudentId,@AssignmentDate,@Status)", con);
                cmd.Parameters.AddWithValue("@GroupId", comboBox1.Text);
                cmd.Parameters.AddWithValue("@StudentId", comboBox2.Text);
                cmd.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Added in Group!");
            }
            catch
            {
                MessageBox.Show("Already Exists in this Group");
            }
        }
    }
}
