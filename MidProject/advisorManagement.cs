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
    public partial class advisorManagement : Form
    {
        Advisor.addAdvisor addAdvi = new Advisor.addAdvisor();
        Advisor.deleteAdvisor deleteAdvi = new Advisor.deleteAdvisor();
        Advisor.viewAdvisor viewAdvi = new Advisor.viewAdvisor();
        Advisor.updateAdvisor updateAdvi = new Advisor.updateAdvisor();
        Advisor.assignAdvisor assignAdvi = new Advisor.assignAdvisor();
        public advisorManagement()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(viewAdvi);
            viewAdvi.Dock = DockStyle.Fill;
        }

        private void AdvidentManagement_Load(object sender, EventArgs e)
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
            mainPanel.Controls.Add(addAdvi);
            addAdvi.Dock = DockStyle.Fill;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(deleteAdvi);
            deleteAdvi.Dock = DockStyle.Fill;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(updateAdvi);
            updateAdvi.Dock = DockStyle.Fill;
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
            mainPanel.Controls.Add(assignAdvi);
            assignAdvi.Dock = DockStyle.Fill;
        }
    }
}
