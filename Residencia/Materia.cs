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
    public partial class Materia : Form
    {
        bool esNuevo;
        bool esEditar;
        MateriasBLL materiasBLL;
        DocentesBLL docenteBLL;

        public Materia()
        {
            InitializeComponent();
            esNuevo = false;
            esEditar = false;
            materiasBLL = new MateriasBLL(Extensions.GetConnectionStringBD());
            docenteBLL = new DocentesBLL(Extensions.GetConnectionStringBD());
            recargaGRID();
            fillCombo();
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

                    int idMateria = Convert.ToInt32(txtID.Text);

                    BaseResponse<int> carreras = materiasBLL.DeleteMateria(idMateria);
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
                    if (string.IsNullOrWhiteSpace(txtMateria.Text))
                    {
                        txtMateria.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbDocente.Text))
                    {
                        cmbDocente.Focus();
                        return;
                    }

                    Materias currentMateria = new Materias();
                    currentMateria.Nombre = txtMateria.Text;
                    currentMateria.IdDocente = Convert.ToInt32(cmbDocente.SelectedValue);
                    currentMateria.HoraEntrada = dtpEntrada.Value.TimeOfDay;
                    currentMateria.HoraSalida = dtpSalida.Value.TimeOfDay;

                    BaseResponse<int> usuarios = materiasBLL.InsertMateria(currentMateria);

                    if(usuarios.CodeError>0)
                    {
                        MessageBox.Show(usuarios.MessageError);
                        return;
                    }

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
                    if (string.IsNullOrWhiteSpace(txtMateria.Text))
                    {
                        txtMateria.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbDocente.Text))
                    {
                        cmbDocente.Focus();
                        return;
                    }

                    Materias currentMateria = new Materias();
                    currentMateria.IdMateria = Convert.ToInt32(txtID.Text);
                    currentMateria.Nombre = txtMateria.Text;
                    currentMateria.IdDocente = Convert.ToInt32(cmbDocente.SelectedValue);
                    currentMateria.HoraEntrada = dtpEntrada.Value.TimeOfDay;
                    currentMateria.HoraSalida = dtpSalida.Value.TimeOfDay;

                     BaseResponse<int> usuarios = materiasBLL.UpdateMateria(currentMateria);

                    if (usuarios.CodeError > 0)
                    {
                        MessageBox.Show(usuarios.MessageError);
                        return;
                    }

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


        private void tabla_materias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    esEditar = true;
                    esNuevo = false;
                    DataGridViewRow row = this.tabla_materias.Rows[e.RowIndex];
                    txtID.Text = row.Cells["IdMateria"].Value.ToString();
                    txtMateria.Text = row.Cells["Nombre"].Value.ToString();
                    cmbDocente.SelectedValue = Convert.ToInt32(row.Cells["IdDocente"].Value.ToString());
                    dtpEntrada.Text = row.Cells["HoraEntrada"].Value.ToString();
                    dtpSalida.Text = row.Cells["HoraSalida"].Value.ToString();

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
                txtMateria.Text = "";
                cmbDocente.Text = "";
                txtID.Text = "";
                dtpEntrada.Value = DateTime.Today;
                dtpSalida.Value = DateTime.Today;
                txtMateria.Enabled = accion;
                cmbDocente.Enabled = accion;
                dtpEntrada.Enabled = accion;
                dtpSalida.Enabled = accion;
                txtMateria.Focus();
            }
            else if (esEditar)
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Seleccione un registro");
                }
                else
                {
                    txtMateria.Enabled = accion;
                    cmbDocente.Enabled = accion;
                    dtpEntrada.Enabled = accion;
                    dtpSalida.Enabled = accion;
                    txtMateria.Focus();
                }
            }
            else
            {
                txtMateria.Text = "";
                cmbDocente.Text = "";
                txtID.Text = "";
                dtpEntrada.Value = DateTime.Today;
                dtpSalida.Value = DateTime.Today;
                txtMateria.Enabled = accion;
                cmbDocente.Enabled = accion;
                dtpEntrada.Enabled = accion;
                dtpSalida.Enabled = accion;
                txtMateria.Focus();
            }

        }

        private void recargaGRID()
        {
            try
            {
                BaseResponse<List<Materias>> docentes = materiasBLL.GetMaterias();
                tabla_materias.DataSource = docentes.Results;
                this.tabla_materias.Columns["IdDocente"].Visible = false; 
                this.tabla_materias.Columns["IdMateria"].Visible = false;
                this.tabla_materias.Columns["NombreMateriaCustom"].Visible = false;
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
                BaseResponse<List<Docentes>> docentes = docenteBLL.GetDocente();
                cmbDocente.DataSource = docentes.Results;

                cmbDocente.ValueMember = "IdDocente";
                cmbDocente.DisplayMember = "Nombre";

                cmbDocente.SelectedValue = "valuemember value";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }
    }
}
