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
    public partial class Docente : Form
    {
        bool esNuevo;
        bool esEditar;
        DocentesBLL docenteBLL;

        public Docente()
        {
            InitializeComponent();
            esNuevo = false;
            esEditar = false; 
            docenteBLL = new DocentesBLL(Extensions.GetConnectionStringBD());
            recargaGRID();
        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            esEditar = false;
            HabilitaDesHabilitaLimpia(true);
           
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
                    if (string.IsNullOrWhiteSpace(txtDocente.Text))
                    {
                        txtDocente.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        txtTelefono.Focus();
                        return;
                    }

                    Docentes currentDocente = new Docentes();
                    currentDocente.Nombre = txtDocente.Text;
                    currentDocente.telefono = txtTelefono.Text;

                    BaseResponse<int> usuarios = docenteBLL.InsertDocente(currentDocente);
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
                    if (string.IsNullOrWhiteSpace(txtDocente.Text))
                    {
                        txtDocente.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        txtTelefono.Focus();
                        return;
                    }


                    Docentes currentDocente = new Docentes();
                    currentDocente.IdDocente = Convert.ToInt32(txtID.Text);
                    currentDocente.Nombre = txtDocente.Text;
                    currentDocente.telefono = txtTelefono.Text;

                    BaseResponse<int> usuarios = docenteBLL.UpdateDocente(currentDocente);
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

                    int IdCarrera = Convert.ToInt32(txtID.Text);

                    BaseResponse<int> carreras = docenteBLL.DeleteDocente(IdCarrera);
                    HabilitaDesHabilitaLimpia(false);
                    recargaGRID();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                    MessageBox.Show("El registro se encuentra asignado y no se puede eliminar");
                else
                    MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }

        
        private void tabla_docente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            if (e.RowIndex >= 0)
            {
                    esEditar = true;
                    esNuevo = false;
                    DataGridViewRow row = this.tabla_docente.Rows[e.RowIndex];
                txtID.Text = row.Cells["IdDocente"].Value.ToString();
                txtDocente.Text = row.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = row.Cells["telefono"].Value.ToString();

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
                txtDocente.Text = "";
                txtTelefono.Text = "";
                txtID.Text = "";
                txtDocente.Enabled = accion;
                txtTelefono.Enabled = accion;
                txtDocente.Focus();
            }
            else if (esEditar)
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Seleccione un registro");
                }
                else
                {
                    txtDocente.Enabled = accion;
                    txtTelefono.Enabled = accion;
                    txtDocente.Focus();
                }
            }
            else
            {
                txtDocente.Text = "";
                txtTelefono.Text = "";
                txtID.Text = "";
                txtDocente.Enabled = accion;
                txtTelefono.Enabled = accion;
                txtDocente.Focus();
            }

        }

        private void recargaGRID()
        {
            try { 
            BaseResponse<List<Docentes>> docentes = docenteBLL.GetDocente();
            tabla_docente.DataSource = docentes.Results;
            this.tabla_docente.Columns["IdDocente"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }

    }
}
