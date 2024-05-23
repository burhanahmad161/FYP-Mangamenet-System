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
    public partial class groupManagement : Form
    {
        Groups.addGroup addgroup = new Groups.addGroup();
        Groups.viewGroup viewgroup = new Groups.viewGroup();
        Groups.viewStudentGroup deletegroup = new Groups.viewStudentGroup();
        Groups.addStuInGroup addInGroup = new Groups.addStuInGroup();
        Groups.removeStuFromGroup removeFrom = new Groups.removeStuFromGroup();

        public groupManagement()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(viewgroup);
            viewgroup.Dock = DockStyle.Fill;
        }

        private void GroupManagement_Load(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(addgroup);
            addgroup.Dock = DockStyle.Fill;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(deletegroup);
            deletegroup.Dock = DockStyle.Fill;
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
            mainPanel.Controls.Add(addInGroup);
            addInGroup.Dock = DockStyle.Fill;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(removeFrom);
            removeFrom.Dock = DockStyle.Fill;
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
