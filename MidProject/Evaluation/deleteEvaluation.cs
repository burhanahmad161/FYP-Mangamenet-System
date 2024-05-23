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

namespace MidProject.Evaluation
{
    public partial class deleteEvaluation : UserControl
    {
        public deleteEvaluation()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Evaluation WHERE (SUBSTRING(Name, 1, 2)) <> '#@'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //........
            string columnName = "Name";
            foreach (DataRow row in dt.Rows)
            {
                // Make sure the column exists in the DataTable
                if (dt.Columns.Contains(columnName))
                {
                    object value = row[columnName];
                    comboBox1.Items.Add(value);
                }
            }
        }
        private void deleteEvaluation_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible)
            {
                loadData();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = "#@" + comboBox1.Text;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Evaluation SET Name = @NewName WHERE Name = @Name", con);
            cmd.Parameters.AddWithValue("@NewName", name);
            cmd.Parameters.AddWithValue("@Name", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
            comboBox1.Items.Clear();
            loadData();
        }
    }
}
