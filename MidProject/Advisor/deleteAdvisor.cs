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
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace MidProject.Advisor
{
    public partial class deleteAdvisor : UserControl
    {
        public deleteAdvisor()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Person.Id, FirstName, LastName, Contact, Email, Gender, Designation,Salary from Advisor Inner Join Person on Advisor.Id = Person.ID WHERE (SUBSTRING(FirstName, 1, 2)) <> '#@'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //........
            string columnName = "FirstName";
            string columnName2 = "LastName";
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
        private void deleteAdvisor_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                loadData();
                dataGridView1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string name = "#@" + comboBox1.Text;

            // Query to Update
            SqlCommand cmd = new SqlCommand("UPDATE Person SET FirstName = @FirstName WHERE FirstName = @first and LastName = @last", con);
            cmd.Parameters.AddWithValue("@FirstName", name);
            cmd.Parameters.AddWithValue("@first", comboBox1.Text);
            cmd.Parameters.AddWithValue("@last", comboBox2.Text);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Successfully Deleted");
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox1.Text = "Select First Name";
                comboBox2.Text = "Select Last Name";
                loadData();
            }
            else
            {
                MessageBox.Show("No matching record found for the provided First and Last Names.");
            }
        }

    }
}
