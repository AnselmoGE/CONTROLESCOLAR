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
    public partial class Carreras : Form
    {
        public Carreras()
        {
            InitializeComponent();
        }

        private void tabla_carreras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu f = new Menu();
            f.Show();
            Visible = false;
        }
    }
}
