using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidProject
{
    public partial class studentManagement : Form
    {
        addStudent addStu = new addStudent();
        viewStudent viewStu = new viewStudent();
        updateStudent updateStu = new updateStudent();
        deleteStudent deleteStu = new deleteStudent();
        public studentManagement()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(viewStu);
            viewStu.Dock = DockStyle.Fill;
        }

        private void studentManagement_Load(object sender, EventArgs e)
        {
            // Add the Delete button column only once during form load
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.FlatStyle = FlatStyle.Popup;
            deleteButton.HeaderText = "";
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.Text = "Delete";
            deleteButton.Width = 60;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(addStu);
            addStu.Dock = DockStyle.Fill;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(deleteStu);
            deleteStu.Dock = DockStyle.Fill;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(updateStu);
            updateStu.Dock = DockStyle.Fill;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainForm obj = new mainForm();
            this.Close();
            obj.Show();
        }
    }
}
