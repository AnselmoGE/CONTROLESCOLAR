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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_regAlumno_Click(object sender, EventArgs e)
        {
            Alumnos f = new Alumnos();
            f.Show();
            Visible = false;
        }

        private void btn_nomCarrera_Click(object sender, EventArgs e)
        {
            Carreras f = new Carreras();
            f.Show();
            Visible = false;
        }

        private void btn_regDocentes_Click(object sender, EventArgs e)
        {
            Docente f = new Docente();
            f.Show();
            Visible = false;
        }

        private void btn_regGrupos_Click(object sender, EventArgs e)
        {
            Grupos f = new Grupos();
            f.Show();
            Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_genCargas_Click(object sender, EventArgs e)
        {
            Generar_Cargas f = new Generar_Cargas();
            f.Show();
            Visible = false;
        }
    }
}
