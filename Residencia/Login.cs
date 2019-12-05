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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_usuario.Text))
                txb_usuario.Focus();

            if (string.IsNullOrWhiteSpace(txb_contra.Text))
                txb_contra.Focus();

            string usuario = txb_usuario.Text;
            string password = txb_contra.Text;

            UsuariosBLL usuarioBLL = new UsuariosBLL(Extensions.GetConnectionStringBD());
            BaseResponse<bool> respuesta = usuarioBLL.GetUsuarioLOG(usuario, password);

            if (respuesta.Results)
            {
                Principal f = new Principal();
                f.Show();
                Visible = false;
                txb_contra.Clear();
            }
            else
            {
                DialogResult eli = MessageBox.Show("Datos Incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_contra.Clear();
                txb_contra.Focus();
            }
        }
    }
}
