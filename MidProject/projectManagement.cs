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
    public partial class projectManagement : Form
    {
        Projects.addProject addPro = new Projects.addProject();
        Projects.viewProject   viewPro = new Projects.viewProject();
        Projects.updateProject updatePro = new Projects.updateProject();
        Projects.deleteProject deletePro = new Projects.deleteProject();
        Projects.assignProject assignPro = new Projects.assignProject();
        Projects.viewGroupProject viewAssignPro = new Projects.viewGroupProject();
        Projects.deleteGroupProject deleteGroupPro = new Projects.deleteGroupProject();
        public projectManagement()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(viewPro);
            viewPro.Dock = DockStyle.Fill;
        }

        private void ProjectManagement_Load(object sender, EventArgs e)
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
            mainPanel.Controls.Add(addPro);
            addPro.Dock = DockStyle.Fill;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(deletePro);
            deletePro.Dock = DockStyle.Fill;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(updatePro);
            updatePro.Dock = DockStyle.Fill;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainForm obj = new mainForm();
            this.Close();
            obj.Show();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(assignPro);
            assignPro.Dock = DockStyle.Fill;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(viewAssignPro);
            viewAssignPro.Dock = DockStyle.Fill;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(deleteGroupPro);
            deleteGroupPro.Dock = DockStyle.Fill;
        }
    }
}
