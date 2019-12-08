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
    public partial class Grupo : Form
    {
        bool esNuevo;
        bool esEditar;
        CarrerasBLL carreraBLL;
        MateriasBLL materiasBLL;
        GruposBLL gruposBLL;
        bool isMateriaGrupo;
        public Grupo()
        {
            InitializeComponent();
            esNuevo = false;
            esEditar = false;
            materiasBLL = new MateriasBLL(Extensions.GetConnectionStringBD());
            carreraBLL = new CarrerasBLL(Extensions.GetConnectionStringBD());
            gruposBLL = new GruposBLL(Extensions.GetConnectionStringBD());
            recargaGRID();
            fillCombo();
            isMateriaGrupo = false;
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
                if (!isMateriaGrupo)
                {
                    if (string.IsNullOrWhiteSpace(txtID.Text))
                    {
                        MessageBox.Show("Seleccione un registro");
                    }
                    else
                    {
                        esEditar = false;
                        esNuevo = false;

                        int idGrupo = Convert.ToInt32(txtID.Text);

                        BaseResponse<int> carreras = gruposBLL.DeleteGrupo(idGrupo);
                        HabilitaDesHabilitaLimpia(false);
                        recargaGRID();
                    }
                }
                else if(isMateriaGrupo)
                {
                    if (string.IsNullOrWhiteSpace(txtGMID.Text))
                    {
                        MessageBox.Show("Seleccione un registro");
                    }
                    else
                    {
                        esEditar = false;
                        esNuevo = false;

                        int idGrupo = Convert.ToInt32(txtGMID.Text);

                        BaseResponse<int> carreras = gruposBLL.DeleteGrupoMateria(idGrupo);
                        HabilitaDesHabilitaLimpia(false);
                        int IdGrupo = Convert.ToInt32(cmbGrupo.SelectedValue);
                        recargaGRID(IdGrupo);
                    }
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
                if (!isMateriaGrupo)
                {
                    if (esNuevo)
                    {
                        if (string.IsNullOrWhiteSpace(txtGrupo.Text))
                        {
                            txtGrupo.Focus();
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(cmbCarrera.Text))
                        {
                            cmbCarrera.Focus();
                            return;
                        }

                        Grupos currentGrupo = new Grupos();
                        currentGrupo.Nombre = txtGrupo.Text;
                        currentGrupo.IdCarrera = Convert.ToInt32(cmbCarrera.SelectedValue);

                        BaseResponse<int> gruposResult = gruposBLL.InsertGrupo(currentGrupo);

                        if (gruposResult.CodeError > 0)
                        {
                            MessageBox.Show(gruposResult.MessageError);
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
                        if (string.IsNullOrWhiteSpace(txtGrupo.Text))
                        {
                            txtGrupo.Focus();
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(cmbCarrera.Text))
                        {
                            cmbCarrera.Focus();
                            return;
                        }

                        Grupos currentGrupo = new Grupos();
                        currentGrupo.IdGrupo = Convert.ToInt32(txtID.Text);
                        currentGrupo.Nombre = txtGrupo.Text;
                        currentGrupo.IdCarrera = Convert.ToInt32(cmbCarrera.SelectedValue);

                        BaseResponse<int> grupoResult = gruposBLL.UpdateGrupo(currentGrupo);

                        if (grupoResult.CodeError > 0)
                        {
                            MessageBox.Show(grupoResult.MessageError);
                            return;
                        }

                        esEditar = false;
                        HabilitaDesHabilitaLimpia(false);
                        recargaGRID();
                    }
                }
                else if(isMateriaGrupo)
                {
                    if (esNuevo)
                    {
                        if (string.IsNullOrWhiteSpace(cmbGrupo.Text))
                        {
                            cmbGrupo.Focus();
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(cmbMateria.Text))
                        {
                            cmbMateria.Focus();
                            return;
                        }

                        GruposMaterias currentGrupo = new GruposMaterias();
                        currentGrupo.IdGrupo = Convert.ToInt32(cmbGrupo.SelectedValue);
                        currentGrupo.IdMateria = Convert.ToInt32(cmbMateria.SelectedValue);

                        BaseResponse<int> gruposResult = gruposBLL.InsertGrupoMateria(currentGrupo);

                        if (gruposResult.CodeError > 0)
                        {
                            MessageBox.Show(gruposResult.MessageError);
                            return;
                        }

                        esNuevo = false;
                        HabilitaDesHabilitaLimpia(false);
                        recargaGRID(currentGrupo.IdGrupo);

                    }
                    else if (esEditar)
                    {
                        if (string.IsNullOrWhiteSpace(txtGMID.Text))
                        {
                            txtGMID.Focus();
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(cmbGrupo.Text))
                        {
                            txtGrupo.Focus();
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(cmbMateria.Text))
                        {
                            cmbCarrera.Focus();
                            return;
                        }

                        GruposMaterias currentGrupo = new GruposMaterias();
                        currentGrupo.IdGrupoMateria = Convert.ToInt32(txtGMID.Text);
                        currentGrupo.IdGrupo = Convert.ToInt32(cmbGrupo.SelectedValue);
                        currentGrupo.IdMateria = Convert.ToInt32(cmbMateria.SelectedValue);

                        BaseResponse<int> grupoResult = gruposBLL.UpdateGrupoMateria(currentGrupo);

                        if (grupoResult.CodeError > 0)
                        {
                            MessageBox.Show(grupoResult.MessageError);
                            return;
                        }

                        esEditar = false;
                        HabilitaDesHabilitaLimpia(false);
                        recargaGRID(currentGrupo.IdGrupo);
                    }
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

        private void tabla_grupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    esEditar = false;
                    esNuevo = false;
                    DataGridViewRow row = this.tabla_grupos.Rows[e.RowIndex];
                    txtID.Text = row.Cells["IdGrupo"].Value.ToString();
                    txtGrupo.Text = row.Cells["Nombre"].Value.ToString();
                    cmbCarrera.SelectedValue = Convert.ToInt32(row.Cells["IdCarrera"].Value.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }

        private void tabla_materiasgrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             try
             {
                 if (e.RowIndex >= 0)
                 {
                     esEditar = false;
                     esNuevo = false;
                     DataGridViewRow row = this.tabla_materiasgrupo.Rows[e.RowIndex];
                     txtGMID.Text = row.Cells["IdGrupoMateria"].Value.ToString();
                     cmbGrupo.SelectedValue = Convert.ToInt32(row.Cells["IdGrupo"].Value.ToString());
                     cmbMateria.SelectedValue = Convert.ToInt32(row.Cells["IdMateria"].Value.ToString());

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
            if (!isMateriaGrupo)
            {
                if (esNuevo)
                {
                    txtGrupo.Text = "";
                    cmbCarrera.Text = "";
                    txtID.Text = "";
                    txtGrupo.Enabled = accion;
                    cmbCarrera.Enabled = accion;
                    txtGrupo.Focus();
                }
                else if (esEditar)
                {
                    if (string.IsNullOrWhiteSpace(txtID.Text))
                    {
                        MessageBox.Show("Seleccione un registro");
                    }
                    else
                    {
                        txtGrupo.Enabled = accion;
                        cmbCarrera.Enabled = accion;
                        txtGrupo.Focus();
                    }
                }
                else
                {
                    txtGrupo.Text = "";
                    cmbCarrera.Text = "";
                    txtID.Text = "";
                    txtGrupo.Enabled = accion;
                    cmbCarrera.Enabled = accion;
                    txtGrupo.Focus();
                }
            }
            if (isMateriaGrupo)
            {
                if (esNuevo)
                {
                    txtGMID.Text = "";
                    cmbMateria.Text = "";
                    cmbMateria.Enabled = accion;
                    cmbMateria.Focus();
                }
                else if (esEditar)
                {
                    if (string.IsNullOrWhiteSpace(txtGMID.Text))
                    {
                        MessageBox.Show("Seleccione un registro");
                    }
                    else
                    {
                        cmbMateria.Enabled = accion;
                        cmbMateria.Focus();
                    }
                }
                else
                {
                    txtGMID.Text = "";
                    cmbMateria.Text = "";
                    cmbMateria.Enabled = accion;
                    cmbGrupo.Focus();
                }
            }
        }

        private void recargaGRID()
        {
            try
            {
                BaseResponse<List<Grupos>> grupos = gruposBLL.GetGrupos();
                tabla_grupos.DataSource = grupos.Results;
                this.tabla_grupos.Columns["IdGrupo"].Visible = false;
                this.tabla_grupos.Columns["IdCarrera"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }

        private void recargaGRID(int IdGrupo)
        {
            try
            {
                BaseResponse<List<GruposMaterias>> gruposMaterias = gruposBLL.GetGruposMaterias(IdGrupo);
                tabla_materiasgrupo.DataSource = gruposMaterias.Results;
                this.tabla_materiasgrupo.Columns["IdGrupoMateria"].Visible = false;
                this.tabla_materiasgrupo.Columns["IdGrupo"].Visible = false;
                this.tabla_materiasgrupo.Columns["NombreGrupo"].Visible = false;
                this.tabla_materiasgrupo.Columns["IdMateria"].Visible = false;
                this.tabla_materiasgrupo.Columns["IdDocente"].Visible = false;

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

                BaseResponse<List<Materias>> materias = materiasBLL.GetMaterias();
                cmbMateria.DataSource = materias.Results;
                cmbMateria.ValueMember = "IdMateria";
                cmbMateria.DisplayMember = "NombreMateriaCustom";
                cmbMateria.SelectedValue = "valuemember value";

                fillComboGrupos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " TRACE : " + ex.StackTrace);
            }
        }


        private void fillComboGrupos()
        {
            try
            {

                BaseResponse<List<Grupos>> grupos = gruposBLL.GetGrupos();
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

        private void cmbGrupo_SelectedValueChanged(object sender, EventArgs e)
        {
            bool isGrupo = cmbGrupo.SelectedValue is Grupos;
            if (!isGrupo && cmbGrupo.SelectedValue != null)
            {
                int IdGrupo = Convert.ToInt32(cmbGrupo.SelectedValue);
                recargaGRID(IdGrupo);
            }
            else
            {
                tabla_materiasgrupo.DataSource = null;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tbpGrupoMateria"])
            {
                HabilitaDesHabilitaLimpia(false);
                isMateriaGrupo = true;
                fillComboGrupos();
            }
            else
            {
                HabilitaDesHabilitaLimpia(false);
                isMateriaGrupo = false;
            }
        }
    }
}
