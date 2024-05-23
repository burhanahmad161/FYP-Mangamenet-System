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
    public partial class deleteGroupProject : UserControl
    {
        public deleteGroupProject()
        {
            InitializeComponent();
            loadData();
        }

        private void deleteGroupProject_Load(object sender, EventArgs e)
        {
            // Delete Button
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.FlatStyle = FlatStyle.Popup;
            deleteButton.HeaderText = "";
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.Text = "Delete";
            deleteButton.Width = 60;
            dataGridView1.Columns.Add(deleteButton);
        }

        private void deleteGroupProject_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible)
                loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                object id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Delete from GroupProject WHERE ProjectId = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted");
                loadData();
            }
        }
        public void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from GroupProject", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
