using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using MODELS;

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
    }
}
