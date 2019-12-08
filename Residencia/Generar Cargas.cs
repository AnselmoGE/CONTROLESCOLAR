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
using MODELS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace Residencia
{
    public partial class Generar_Cargas : Form
    {
        AlumnosBLL alumnosBLL;
        DataTable dt ;
        public Generar_Cargas()
        {
            InitializeComponent();
            alumnosBLL = new AlumnosBLL(Extensions.GetConnectionStringBD());
            dt = new DataTable();
            recargaGRID();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    
                    DataGridViewRow row = this.tabla_alumnos.Rows[e.RowIndex];
                    int idAlumno = Convert.ToInt32(row.Cells["IdAlumno"].Value.ToString());

                    Horario newMDIChild = new Horario(idAlumno);
                     newMDIChild.MdiParent = this.ParentForm ;
                    newMDIChild.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
          
        }

        private void recargaGRID()
        {
            try
            {
                BaseResponse<List<Alumnos>> alumno = alumnosBLL.GetAlumno();

                dt.Columns.Add("IdAlumno", typeof(string));
                dt.Columns.Add("NombreCompleto", typeof(string));
                dt.Columns.Add("telefono", typeof(string));
                dt.Columns.Add("IdCarrera", typeof(string));
                dt.Columns.Add("IdGrupo", typeof(string));
                dt.Columns.Add("NombreCarrera", typeof(string));
                dt.Columns.Add("NombreGrupo", typeof(string));

                foreach (var item in alumno.Results)
                {
                    var row = dt.NewRow();

                    row["IdAlumno"] = item.IdAlumno.ToString();
                    row["NombreCompleto"] = item.NombreCompleto;
                    row["telefono"] = item.telefono;
                    row["IdCarrera"] = item.IdCarrera.ToString();
                    row["IdGrupo"] = item.IdGrupo.ToString();
                    row["NombreCarrera"] = item.NombreCarrera;
                    row["NombreGrupo"] = item.NombreGrupo;
                    dt.Rows.Add(row);
                }


                tabla_alumnos.DataSource = dt;// alumno.Results;
                this.tabla_alumnos.Columns["IdAlumno"].Visible = false;
                this.tabla_alumnos.Columns["IdCarrera"].Visible = false;
                this.tabla_alumnos.Columns["IdGrupo"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"NombreCompleto LIKE '{txtNombre.Text}%'";
        }

        private void createPDF()
        {
            //This is the absolute path to the PDF that we will create
            string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Sample.pdf");

            //Create a standard .Net FileStream for the file, setting various flags
            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //Create a new PDF document setting the size to A4
                using (Document doc = new Document(PageSize.A4))
                {
                    //Bind the PDF document to the FileStream using an iTextSharp PdfWriter
                    using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
                    {
                        //Open the document for writing
                        doc.Open();

                        //Create a table with two columns
                        PdfPTable t = new PdfPTable(2);

                        //Borders are drawn by the individual cells, not the table itself.
                        //Tell the default cell that we do not want a border drawn
                        t.DefaultCell.Border = 0;

                        //Add four cells. Cells are added starting at the top left of the table working left to right first, then down
                        t.AddCell("R1C1");
                        t.AddCell("R1C2");
                        t.AddCell("R2C1");
                        t.AddCell("R2C2");

                        //Add the table to our document
                        doc.Add(t);

                        //Close our document
                        doc.Close();
                    }
                }
            }
        }
        
    }
}
