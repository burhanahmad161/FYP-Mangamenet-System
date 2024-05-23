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

namespace MidProject
{
    public partial class viewStudent : UserControl
    {
        public viewStudent()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Person.Id,FirstName,LastName,Contact,Email,Gender,RegistrationNo from Student inner Join Person on Student.Id = Person.ID WHERE (SUBSTRING(FirstName, 1, 2)) <> '#@'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewStudent_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void viewStudent_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                loadData();
            }
        }
    }
}
