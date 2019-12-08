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
    public partial class Alumno : Form
    {
        bool esNuevo;
        bool esEditar;
        CarrerasBLL carreraBLL;
        GruposBLL gruposBLL;
        AlumnosBLL alumnosBLL;
        public Alumno()
        {
            InitializeComponent();
            esNuevo = false;
            esEditar = false;
            carreraBLL = new CarrerasBLL(Extensions.GetConnectionStringBD());
            gruposBLL = new GruposBLL(Extensions.GetConnectionStringBD());
            alumnosBLL = new AlumnosBLL(Extensions.GetConnectionStringBD());
            fillCombo();
            recargaGRID();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            esEditar = false;
            HabilitaDesHabilitaLimpia(true);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Seleccione un registro");
                }
                else
                {
                    esEditar = false;
                    esNuevo = false;

                    int IdAlumno = Convert.ToInt32(txtID.Text);

                    BaseResponse<int> carreras = alumnosBLL.DeleteAlumno(IdAlumno);
                    HabilitaDesHabilitaLimpia(false);
                    recargaGRID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            esEditar = true;
            HabilitaDesHabilitaLimpia(true);
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (esNuevo)
                {
                    if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        txtNombre.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtApellidoPaterno.Text))
                    {
                        txtApellidoPaterno.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtApellidoMaterno.Text))
                    {
                        txtApellidoPaterno.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        txtApellidoPaterno.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbCarrera.Text))
                    {
                        txtApellidoPaterno.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbGrupo.Text))
                    {
                        txtApellidoPaterno.Focus();
                        return;
                    }

                    Alumnos currentAlumno = new Alumnos();
                    currentAlumno.Nombre = txtNombre.Text;
                    currentAlumno.ApellidoPaterno = txtApellidoPaterno.Text;
                    currentAlumno.ApellidoMaterno = txtApellidoMaterno.Text;
                    currentAlumno.telefono = txtTelefono.Text;
                    currentAlumno.IdCarrera = Convert.ToInt32(cmbCarrera.SelectedValue);
                    currentAlumno.IdGrupo = Convert.ToInt32(cmbGrupo.SelectedValue);

                    BaseResponse<int> usuarios = alumnosBLL.InsertAlumno(currentAlumno);
                    esNuevo = false;
                    HabilitaDesHabilitaLimpia(false);
                    recargaGRID();

                }
                else if (esEditar)
                {
                    if (string.IsNullOrWhiteSpace(txtID.Text))
                    {
                        txtID.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        txtNombre.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtApellidoPaterno.Text))
                    {
                        txtApellidoPaterno.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtApellidoMaterno.Text))
                    {
                        txtApellidoPaterno.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        txtApellidoPaterno.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbCarrera.Text))
                    {
                        txtApellidoPaterno.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbGrupo.Text))
                    {
                        txtApellidoPaterno.Focus();
                        return;
                    }

                    Alumnos currentAlumno = new Alumnos();
                    currentAlumno.IdAlumno = Convert.ToInt32(txtID.Text);
                    currentAlumno.Nombre = txtNombre.Text;
                    currentAlumno.ApellidoPaterno = txtApellidoPaterno.Text;
                    currentAlumno.ApellidoMaterno = txtApellidoMaterno.Text;
                    currentAlumno.telefono = txtTelefono.Text;
                    currentAlumno.IdCarrera = Convert.ToInt32(cmbCarrera.SelectedValue);
                    currentAlumno.IdGrupo = Convert.ToInt32(cmbGrupo.SelectedValue);

                    BaseResponse<int> usuarios = alumnosBLL.UpdateAlumno(currentAlumno);
                    esEditar = false;
                    HabilitaDesHabilitaLimpia(false);
                    recargaGRID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargaAcademicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabla_alumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    esEditar = true;
                    esNuevo = false;
                    DataGridViewRow row = this.tabla_alumnos.Rows[e.RowIndex];
                    txtID.Text = row.Cells["IdAlumno"].Value.ToString();
                    txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                    cmbCarrera.SelectedValue = Convert.ToInt32(row.Cells["IdCarrera"].Value.ToString());
                    txtApellidoPaterno.Text = row.Cells["ApellidoPaterno"].Value.ToString();
                    txtApellidoMaterno.Text = row.Cells["ApellidoMaterno"].Value.ToString();
                    txtTelefono.Text = row.Cells["telefono"].Value.ToString();
                    cmbGrupo.SelectedValue = Convert.ToInt32(row.Cells["IdGrupo"].Value.ToString());
                  

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }

        //FUNCIONES

        public void HabilitaDesHabilitaLimpia(bool accion)
        {

            if (esNuevo)
            {
                txtNombre.Text = "";
                txtApellidoPaterno.Text = "";
                txtApellidoMaterno.Text = "";
                txtID.Text = "";
                txtTelefono.Text = "";
                cmbCarrera.Text = "";
                cmbGrupo.Text = "";
                cmbCarrera.Enabled = accion;
                cmbGrupo.Enabled = accion;
                txtNombre.Enabled = accion;
                txtApellidoPaterno.Enabled = accion;
                txtApellidoMaterno.Enabled = accion;
                txtTelefono.Enabled = accion;
                txtNombre.Focus();
            }
            else if (esEditar)
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Seleccione un registro");
                }
                else
                {
                    txtNombre.Enabled = accion;
                    txtApellidoPaterno.Enabled = accion;
                    txtApellidoMaterno.Enabled = accion;
                    txtTelefono.Enabled = accion;
                    cmbCarrera.Enabled = accion;
                    cmbGrupo.Enabled = accion;
                    txtNombre.Focus();
                }
            }
            else
            {
                txtNombre.Text = "";
                txtApellidoPaterno.Text = "";
                txtApellidoMaterno.Text = "";
                txtID.Text = "";
                txtTelefono.Text = "";
                txtNombre.Enabled = accion;
                txtApellidoPaterno.Enabled = accion;
                txtApellidoMaterno.Enabled = accion;
                txtTelefono.Enabled = accion;
                cmbCarrera.Text = "";
                cmbGrupo.Text = "";
                cmbCarrera.Enabled = accion;
                cmbGrupo.Enabled = accion;
                txtNombre.Focus();
            }

        }

        private void recargaGRID()
        {
            try
            {
                BaseResponse<List<Alumnos>> alumno = alumnosBLL.GetAlumno();
                tabla_alumnos.DataSource = alumno.Results;
                this.tabla_alumnos.Columns["IdAlumno"].Visible = false;
                this.tabla_alumnos.Columns["IdCarrera"].Visible = false;
                this.tabla_alumnos.Columns["IdGrupo"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }

        private void fillCombo()
        {
            try
            {
                BaseResponse<List<Carreras>> carrera = carreraBLL.GetCarrera();
                cmbCarrera.DataSource = carrera.Results;
                cmbCarrera.ValueMember = "IdCarrera";
                cmbCarrera.DisplayMember = "Nombre";
                cmbCarrera.SelectedValue = "valuemember value";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }


        private void fillComboGrupos(int idCarrera)
        {
            try
            {
                BaseResponse<List<Grupos>> grupos = gruposBLL.GetGruposByCarrera(idCarrera);
                cmbGrupo.DataSource = grupos.Results;
                cmbGrupo.ValueMember = "IdGrupo";
                cmbGrupo.DisplayMember = "Nombre";
                cmbGrupo.SelectedValue = "valuemember value";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }

        private void cmbCarrera_SelectedValueChanged(object sender, EventArgs e)
        {
            bool isGrupo = cmbCarrera.SelectedValue is Carreras;
            if (!isGrupo && cmbCarrera.SelectedValue != null)
            {
                int IdGrupo = Convert.ToInt32(cmbCarrera.SelectedValue);
                fillComboGrupos(IdGrupo);
            }

        }
    }
}
