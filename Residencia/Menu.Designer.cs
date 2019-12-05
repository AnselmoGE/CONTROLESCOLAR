namespace Residencia
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btn_regAlumno = new System.Windows.Forms.Button();
            this.btn_regDocentes = new System.Windows.Forms.Button();
            this.btn_nomCarrera = new System.Windows.Forms.Button();
            this.btn_regGrupos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_genCargas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_regAlumno
            // 
            this.btn_regAlumno.Location = new System.Drawing.Point(12, 57);
            this.btn_regAlumno.Name = "btn_regAlumno";
            this.btn_regAlumno.Size = new System.Drawing.Size(97, 57);
            this.btn_regAlumno.TabIndex = 0;
            this.btn_regAlumno.Text = "Registro de Alumnos";
            this.btn_regAlumno.UseVisualStyleBackColor = true;
            this.btn_regAlumno.Click += new System.EventHandler(this.btn_regAlumno_Click);
            // 
            // btn_regDocentes
            // 
            this.btn_regDocentes.Location = new System.Drawing.Point(12, 133);
            this.btn_regDocentes.Name = "btn_regDocentes";
            this.btn_regDocentes.Size = new System.Drawing.Size(97, 57);
            this.btn_regDocentes.TabIndex = 1;
            this.btn_regDocentes.Text = "Registro Docentes";
            this.btn_regDocentes.UseVisualStyleBackColor = true;
            this.btn_regDocentes.Click += new System.EventHandler(this.btn_regDocentes_Click);
            // 
            // btn_nomCarrera
            // 
            this.btn_nomCarrera.Location = new System.Drawing.Point(12, 214);
            this.btn_nomCarrera.Name = "btn_nomCarrera";
            this.btn_nomCarrera.Size = new System.Drawing.Size(97, 57);
            this.btn_nomCarrera.TabIndex = 2;
            this.btn_nomCarrera.Text = "Registro de Carreras ";
            this.btn_nomCarrera.UseVisualStyleBackColor = true;
            this.btn_nomCarrera.Click += new System.EventHandler(this.btn_nomCarrera_Click);
            // 
            // btn_regGrupos
            // 
            this.btn_regGrupos.Location = new System.Drawing.Point(12, 296);
            this.btn_regGrupos.Name = "btn_regGrupos";
            this.btn_regGrupos.Size = new System.Drawing.Size(97, 57);
            this.btn_regGrupos.TabIndex = 3;
            this.btn_regGrupos.Text = "Registro de Grupos";
            this.btn_regGrupos.UseVisualStyleBackColor = true;
            this.btn_regGrupos.Click += new System.EventHandler(this.btn_regGrupos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(125, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(631, 483);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox2.Location = new System.Drawing.Point(-3, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 483);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btn_genCargas
            // 
            this.btn_genCargas.Location = new System.Drawing.Point(12, 373);
            this.btn_genCargas.Name = "btn_genCargas";
            this.btn_genCargas.Size = new System.Drawing.Size(97, 57);
            this.btn_genCargas.TabIndex = 6;
            this.btn_genCargas.Text = "Generar Carga";
            this.btn_genCargas.UseVisualStyleBackColor = true;
            this.btn_genCargas.Click += new System.EventHandler(this.btn_genCargas_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(745, 481);
            this.Controls.Add(this.btn_genCargas);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_regGrupos);
            this.Controls.Add(this.btn_nomCarrera);
            this.Controls.Add(this.btn_regDocentes);
            this.Controls.Add(this.btn_regAlumno);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_regAlumno;
        private System.Windows.Forms.Button btn_regDocentes;
        private System.Windows.Forms.Button btn_nomCarrera;
        private System.Windows.Forms.Button btn_regGrupos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_genCargas;
    }
}