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

        public Carrera()
        {
            InitializeComponent();
            esNuevo = false;
            esEditar = false;
            recargaGRID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu f = new Menu();
            f.Show();
            Visible = false;
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
                CarrerasBLL carreraBLL = new CarrerasBLL(Extensions.GetConnectionStringBD());

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

                    Usuarios usuario = new Usuarios();
                    usuario.IdUsuario = Convert.ToInt32(txtID.Text);
                    usuario.Usario = txtCarrera.Text;
                    usuario.Password = txtAbreviatura.Text;

                    BaseResponse<int> usuarios = carreraBLL.UpdateCarrera(currentCarrera);
                    HabilitaDesHabilitaLimpia(false);
                    recargaGRID();
                }
            }
            catch(Exception ex)
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
            }
            else if(esEditar)
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Seleccione un registro");
                }
                else
                {
                    txtCarrera.Enabled = accion;
                    txtAbreviatura.Enabled = accion;
                }
            }

        }

        private void recargaGRID()
        {
            CarrerasBLL carreraBLL = new CarrerasBLL(Extensions.GetConnectionStringBD());

            BaseResponse<List<Carreras>> carreras = carreraBLL.GetCarrera();

            tabla_carreras.DataSource = carreras.Results;
        }

        private void tabla_carreras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tabla_carreras.Rows[e.RowIndex];
                txtID.Text = row.Cells["IdCarrera"].Value.ToString();
                txtCarrera.Text = row.Cells["Nombre"].Value.ToString();
                txtAbreviatura.Text = row.Cells["Abreviatura"].Value.ToString();

            }
        }
    }
}
