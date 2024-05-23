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
    public partial class viewAdvisor : UserControl
    {
        public viewAdvisor()
        {
            InitializeComponent();
            loadData();
            
        }
        void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Person.Id,FirstName,LastName,Contact,Email,Gender,Salary,Designation from Advisor inner Join Person on Advisor.Id = Person.ID WHERE (SUBSTRING(FirstName, 1, 2)) <> '#@'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void viewAdvisor_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                loadData();
            }
        }
    }
}
