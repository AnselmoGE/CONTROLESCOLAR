using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using MODELS;

namespace Residencia
{
    public partial class Horario : Form
    {
        int IdAlumno;
        AlumnosBLL alumnosBLL;
        Alumnos currentAlumno;
        public Horario()
        {
            InitializeComponent();
        }

        public Horario(int IdAlumno)
        {
            InitializeComponent();
            this.IdAlumno = IdAlumno;
            alumnosBLL = new AlumnosBLL(Extensions.GetConnectionStringBD());
            currentAlumno = new Alumnos();
            recargaGRIDHorario(IdAlumno);
        }

        private void cargaAcademicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createPDF2();
        }

        private void recargaGRIDHorario(int IdAlumno)
        {
            try
            {

                BaseResponse<Alumnos> alumnoC = alumnosBLL.GetAlumno(IdAlumno);
                currentAlumno = alumnoC.Results;

                BaseResponse<List<Horarios>> Horarios = alumnosBLL.GetAlumnoHorario(IdAlumno);
                tabla_Horario.DataSource = Horarios.Results;

                BaseResponse<List<AlumnosEncabezado>> alumno = alumnosBLL.GetAlumnoEncabezado(IdAlumno);
                tabla_alumnoActual.DataSource = alumno.Results;

                BaseResponse<List<DocentesHorario>> docentes = alumnosBLL.GetMateriasDocenteEncabezado(IdAlumno);
                tabla_docentes.DataSource = docentes.Results;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }


        private void createPDF2()
        {
            try
            {
                string html = "";
                //Tabla ENCABEZADO
                if (tabla_alumnoActual.Rows.Count > 0)
                {
                    html += "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 12pt'>";
                    html += "<tr>";
                    foreach (DataGridViewColumn column in tabla_alumnoActual.Columns)
                    {
                        html += "<th style='background-color: #5292DF;border: 1px solid #ccc'>" + column.HeaderText + "</th>";
                    }
                    html += "</tr>";

                    foreach (DataGridViewRow row in tabla_alumnoActual.Rows)
                    {
                        html += "<tr>";
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            html += "<td style='width:200px;border: 1px solid #ccc'>" + cell.Value.ToString() + "</td>";
                        }
                        html += "</tr>";
                    }
                    html += "</table> <br/>";
                }

                //Tabla DOCENTES.
                if (tabla_docentes.Rows.Count > 0)
                {
                    html += "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 12pt'>";
                    html += "<tr>";
                    foreach (DataGridViewColumn column in tabla_docentes.Columns)
                    {
                        html += "<th style='background-color: #FCFDFD;border: 1px solid #ccc'>" + column.HeaderText + "</th>";
                    }
                    html += "</tr>";
                    foreach (DataGridViewRow row in tabla_docentes.Rows)
                    {
                        html += "<tr>";
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            html += "<td style='width:180px;border: 1px solid #ccc'>" + cell.Value.ToString() + "</td>";
                        }
                        html += "</tr>";
                    }
                    html += "</table>";
                }


                //Table HORARIO
                if (tabla_Horario.Rows.Count > 0)
                {
                    html += "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 12pt'>";
                    html += "<tr>";
                    foreach (DataGridViewColumn column in tabla_Horario.Columns)
                    {
                        html += "<th style='background-color: #5292DF;border: 1px solid #ccc'>" + column.HeaderText + "</th>";
                    }
                    html += "</tr>";
                    foreach (DataGridViewRow row in tabla_Horario.Rows)
                    {
                        html += "<tr>";
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            html += "<td style='width:100px;border: 1px solid #ccc'>" + cell.Value.ToString() + "</td>";
                        }
                        html += "</tr>";
                    }
                    html += "</table>";
                }

                //Creating Folder for saving PDF.
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "HORARIOS"); ;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                //Exporting HTML to PDF file.
                using (FileStream stream = new FileStream(folderPath + currentAlumno.NombreCompleto + ".pdf", FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.LETTER);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    StringReader sr = new StringReader(html);
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    stream.Close();

                    System.Diagnostics.Process.Start(folderPath + currentAlumno.NombreCompleto + ".pdf");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }

    }
}
