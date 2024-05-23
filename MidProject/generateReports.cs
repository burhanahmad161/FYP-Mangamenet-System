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
    public partial class generateReports : Form
    {
        Reports.advisorReport advReport = new Reports.advisorReport();
        Reports.evaluationReport evalReport = new Reports.evaluationReport();
        Reports.groupReport groupReport = new Reports.groupReport();
        Reports.studentReport studentReport = new Reports.studentReport();
        Reports.projectReport projectReport = new Reports.projectReport();
        public generateReports()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(studentReport);
            studentReport.Dock = DockStyle.Fill;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(advReport);
            advReport.Dock = DockStyle.Fill;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(projectReport);
            projectReport.Dock = DockStyle.Fill;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(evalReport);
            evalReport.Dock = DockStyle.Fill;
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
            mainPanel.Controls.Add(groupReport);
            groupReport.Dock = DockStyle.Fill;
        }
    }
}
