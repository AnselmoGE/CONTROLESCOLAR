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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alumnos newMDIChild = new Alumnos();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void cargaAcademicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generar_Cargas newMDIChild = new Generar_Cargas();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void carrerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Carrera newMDIChild = new Carrera();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void docentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Docente newMDIChild = new Docente();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grupos newMDIChild = new Grupos();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias newMDIChild = new Materias();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
