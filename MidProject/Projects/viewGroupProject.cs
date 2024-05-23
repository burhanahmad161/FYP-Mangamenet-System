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
    public partial class viewGroupProject : UserControl
    {
        public viewGroupProject()
        {
            InitializeComponent();
            //.............Display Group Projects
            loadData();
        }
        void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from GroupProject", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void viewGroupProject_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                loadData();
            }
        }
    }
}
