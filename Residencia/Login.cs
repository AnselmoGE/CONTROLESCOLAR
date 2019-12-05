using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (txb_contra.Text == "1234")
            {
                Menu f = new Menu();
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
