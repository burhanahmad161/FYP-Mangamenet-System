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
    public partial class markEvaluation : UserControl
    {
        public markEvaluation()
        {
            InitializeComponent();
            //..........Add items to comboBox1
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
            //.........Add items to comboBox2
            SqlCommand cmd2 = new SqlCommand("Select * from [Evaluation]", con);
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
            //........View ProjectEvaluation
            SqlCommand cmd3 = new SqlCommand("Select * from GroupEvaluation", con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            loadData();
        }
        void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select * from GroupEvaluation", con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ////////// Add Data in ProjectAdvisor Table
            try
            {
                int marks = int.Parse(textBox1.Text);
                var con = Configuration.getInstance().getConnection();
                //.........Check Marks Validation
                SqlCommand cmd2 = new SqlCommand("Select TotalMarks from Evaluation where Id = @EvalId", con);
                cmd2.Parameters.AddWithValue("@EvalId", comboBox2.Text);
                object result = cmd2.ExecuteScalar();
                int MaxMarks = Convert.ToInt32(result);
                if(marks > MaxMarks)
                {
                    MessageBox.Show("Total Marks for this evaluation are " + MaxMarks);
                    return;
                }
                //............Insert Evaluation Data
                SqlCommand cmd = new SqlCommand("Insert into GroupEvaluation(GroupId,EvaluationId,ObtainedMarks,EvaluationDate) values (@GroupId,@EvaluationId,@ObtainedMarks,@EvaluationDate)", con);
                cmd.Parameters.AddWithValue("@GroupId", comboBox1.Text);
                cmd.Parameters.AddWithValue("@EvaluationId", comboBox2.Text);
                cmd.Parameters.AddWithValue("@ObtainedMarks", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@EvaluationDate", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Group Evaluated");
                this.Refresh();
                loadData();
            }
            catch
            {
                MessageBox.Show("Please Enter Valid Obtained Marks");
            }
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "Enter Obtained Marks")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.DimGray;
            }

        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Obtained Marks";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void markEvaluation_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                loadData();
        }
    }
}
