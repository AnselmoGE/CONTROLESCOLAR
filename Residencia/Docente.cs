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
        public Docente()
        {
            InitializeComponent();
        }

        private void Docente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu f = new Menu();
            f.Show();
            Visible = false;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            UsuariosBLL usuario = new UsuariosBLL(Extensions.GetConnectionStringBD());

            BaseResponse<List<Usuarios>> usuarios = usuario.GetStatus();

            tabla_docente.DataSource = usuarios.Results;
        }
    }
}
