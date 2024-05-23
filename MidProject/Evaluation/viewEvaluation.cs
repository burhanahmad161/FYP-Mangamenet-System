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
    public partial class viewEvaluation : UserControl
    {
        public viewEvaluation()
        {
            InitializeComponent();
            loadData();
        }
        void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Evaluation] WHERE (SUBSTRING(Name, 1, 2)) <> '#@'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void viewEvaluation_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible)
            {
            loadData();
            }
        }
    }
}
