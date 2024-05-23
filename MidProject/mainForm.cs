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
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            studentManagement stud = new studentManagement();
            this.Hide();
            stud.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            projectManagement project = new projectManagement();
            this.Hide();
            project.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            groupManagement group = new groupManagement();
            this.Hide();
            group.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            evaluationManagement eval = new evaluationManagement();
            this.Hide();
            eval.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            advisorManagement advisor = new advisorManagement();
            this.Hide();
            advisor.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            generateReports generate = new generateReports();
            this.Hide();
            generate.Show();
        }
    }
}
