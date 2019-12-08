using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODELS;
using BLL;

namespace Residencia
{
    public partial class Carrera : Form
    {
        bool esNuevo;
        bool esEditar;
        CarrerasBLL carreraBLL;
        public Carrera()
        {
            InitializeComponent();
            esNuevo = false;
            esEditar = false;
            carreraBLL = new CarrerasBLL(Extensions.GetConnectionStringBD());
            recargaGRID();
        }


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    if (string.IsNullOrWhiteSpace(txtCarrera.Text))
                    {
                        txtCarrera.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtAbreviatura.Text))
                    {
                        txtAbreviatura.Focus();
                        return;
                    }

                    Carreras currentCarrera = new Carreras();
                    currentCarrera.Nombre = txtCarrera.Text;
                    currentCarrera.Abreviatura = txtAbreviatura.Text;

                    BaseResponse<int> usuarios = carreraBLL.InsertCarrera(currentCarrera);
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
                    if (string.IsNullOrWhiteSpace(txtCarrera.Text))
                    {
                        txtCarrera.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtAbreviatura.Text))
                    {
                        txtAbreviatura.Focus();
                        return;
                    }

                    Carreras currentCarrera = new Carreras();
                    currentCarrera.IdCarrera = Convert.ToInt32(txtID.Text);
                    currentCarrera.Nombre = txtCarrera.Text;
                    currentCarrera.Abreviatura = txtAbreviatura.Text;

                    BaseResponse<int> usuarios = carreraBLL.UpdateCarrera(currentCarrera);
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

        private void tabla_carreras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            if (e.RowIndex >= 0)
            {
                    esEditar = true;
                    esNuevo = false;
                DataGridViewRow row = this.tabla_carreras.Rows[e.RowIndex];
                txtID.Text = row.Cells["IdCarrera"].Value.ToString();
                txtCarrera.Text = row.Cells["Nombre"].Value.ToString();
                txtAbreviatura.Text = row.Cells["Abreviatura"].Value.ToString();

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
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

                    BaseResponse<int> carreras = carreraBLL.DeleteCarrera(IdCarrera);
                    HabilitaDesHabilitaLimpia(false);
                    recargaGRID();
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
                txtCarrera.Text = "";
                txtAbreviatura.Text = "";
                txtID.Text = "";
                txtCarrera.Enabled = accion;
                txtAbreviatura.Enabled = accion;
                txtCarrera.Focus();
            }
            else if (esEditar)
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Seleccione un registro");
                }
                else
                {
                    txtCarrera.Enabled = accion;
                    txtAbreviatura.Enabled = accion;
                    txtCarrera.Focus();
                }
            }
            else
            {
                txtCarrera.Text = "";
                txtAbreviatura.Text = "";
                txtID.Text = "";
                txtCarrera.Enabled = accion;
                txtAbreviatura.Enabled = accion;
                txtCarrera.Focus();
            }

        }

        private void recargaGRID()
        {
            try { 
            BaseResponse<List<Carreras>> carreras = carreraBLL.GetCarrera();
            tabla_carreras.DataSource = carreras.Results;
            this.tabla_carreras.Columns["IdCarrera"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }
    }
}
