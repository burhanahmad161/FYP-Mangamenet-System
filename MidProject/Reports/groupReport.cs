using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Layout.Properties;
using iText.Kernel.Colors;

namespace MidProject.Reports
{
    public partial class groupReport : UserControl
    {
        public groupReport()
        {
            InitializeComponent();
            loadData();
        }
        void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT G.Id AS GroupId, G.Created_On AS GroupCreationDate, GP.ProjectId AS ProjectId, P.Title AS ProjectTitle, GS.StudentId AS StudentId, CONCAT(PeStudent.FirstName, ' ', PeStudent.LastName) AS StudentName, GE.EvaluationId AS EvaluationId, E.Name AS EvaluationName, GE.ObtainedMarks AS ObtainedMarks FROM [Group] G LEFT JOIN GroupProject GP ON G.Id = GP.GroupId LEFT JOIN Project P ON GP.ProjectId = P.Id LEFT JOIN GroupStudent GS ON G.Id = GS.GroupId LEFT JOIN Student S ON GS.StudentId = S.Id LEFT JOIN Person PeStudent ON S.Id = PeStudent.Id LEFT JOIN GroupEvaluation GE ON G.Id = GE.GroupId LEFT JOIN Evaluation E ON GE.EvaluationId = E.Id ORDER BY G.Id, GP.ProjectId, GS.StudentId, GE.EvaluationId;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void advisorReport_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (.pdf)|.pdf";
            saveFileDialog.Title = "Export to PDF";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));

                document.Open();

                // Add a header table
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.DefaultCell.Border = 0;
                headerTable.WidthPercentage = 100;

                // Header cell styles
                PdfPCell headerCell1 = new PdfPCell(new Phrase("FYP Management System"));
                headerCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                headerCell1.PaddingBottom = 10f; // Add padding to the bottom
                headerCell1.BackgroundColor = new BaseColor(200, 200, 200); // Set background color
                headerTable.AddCell(headerCell1);

                PdfPCell headerCell2 = new PdfPCell(new Phrase("Groups Report"));
                headerCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                headerCell2.PaddingBottom = 10f;
                headerCell2.BackgroundColor = new BaseColor(200, 200, 200);
                headerTable.AddCell(headerCell2);

                PdfPCell headerCell3 = new PdfPCell(new Phrase("Submitted by: Burhan Ahmad 2022-CS-191"));
                headerCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                headerCell3.PaddingBottom = 10f;
                headerCell3.BackgroundColor = new BaseColor(200, 200, 200);
                headerTable.AddCell(headerCell3);

                PdfPCell headerCell4 = new PdfPCell(new Phrase("Submitted To: Mr. Nazeef Ul Haq"));
                headerCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                headerCell4.PaddingBottom = 10f;
                headerCell4.BackgroundColor = new BaseColor(200, 200, 200);
                headerTable.AddCell(headerCell4);

                document.Add(headerTable);

                // Add a spacer line between header and data table
                document.Add(new Paragraph(" "));

                // Add the data table
                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                // Data cell styles
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new BaseColor(150, 150, 150); // Set background color
                    cell.Padding = 5f; // Add padding
                    pdfTable.AddCell(cell);
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Check for null before accessing the Value property
                        object cellValue = cell.Value;
                        string cellText = cellValue != null ? cellValue.ToString() : "";

                        PdfPCell dataCell = new PdfPCell(new Phrase(cellText));
                        dataCell.Padding = 5f;
                        pdfTable.AddCell(dataCell);
                    }
                }

                document.Add(pdfTable);
                document.Close();

                MessageBox.Show("PDF file has been created!");
            }
        }



    }
}
