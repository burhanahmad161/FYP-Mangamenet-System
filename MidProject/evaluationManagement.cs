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
    public partial class evaluationManagement : Form
    {
        Evaluation.addEvaluation addEval = new       Evaluation.addEvaluation();
        Evaluation.viewEvaluation viewEval = new     Evaluation.viewEvaluation();
        Evaluation.updateEvaluation updateEval = new Evaluation.updateEvaluation();
        Evaluation.deleteEvaluation deleteEval = new Evaluation.deleteEvaluation();
        Evaluation.markEvaluation markEval = new Evaluation.markEvaluation();
        public evaluationManagement()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(viewEval);
            viewEval.Dock = DockStyle.Fill;
        }

        private void EvaluationManagement_Load(object sender, EventArgs e)
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
            mainPanel.Controls.Add(addEval);
            addEval.Dock = DockStyle.Fill;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(deleteEval);
            deleteEval.Dock = DockStyle.Fill;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(updateEval);
            updateEval.Dock = DockStyle.Fill;
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
            mainPanel.Controls.Add(markEval);
            markEval.Dock = DockStyle.Fill;
        }
    }
}
