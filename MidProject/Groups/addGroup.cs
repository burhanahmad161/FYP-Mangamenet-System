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
    public partial class addGroup : UserControl
    {
        public addGroup()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into [Group] (Created_On) values (@Created_On)", con);
            cmd.Parameters.AddWithValue("@Created_On", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Group Added!");
            con.Close();
        }
    }
}
