namespace Residencia
{
    partial class Horario
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
            this.tabla_Horario = new System.Windows.Forms.DataGridView();
            this.tabla_docentes = new System.Windows.Forms.DataGridView();
            this.tabla_alumnoActual = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargaAcademicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Horario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_docentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_alumnoActual)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabla_Horario
            // 
            this.tabla_Horario.AllowUserToAddRows = false;
            this.tabla_Horario.AllowUserToDeleteRows = false;
            this.tabla_Horario.AllowUserToOrderColumns = true;
            this.tabla_Horario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_Horario.Location = new System.Drawing.Point(50, 241);
            this.tabla_Horario.Name = "tabla_Horario";
            this.tabla_Horario.ReadOnly = true;
            this.tabla_Horario.Size = new System.Drawing.Size(700, 210);
            this.tabla_Horario.TabIndex = 42;
            // 
            // tabla_docentes
            // 
            this.tabla_docentes.AllowUserToAddRows = false;
            this.tabla_docentes.AllowUserToDeleteRows = false;
            this.tabla_docentes.AllowUserToOrderColumns = true;
            this.tabla_docentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_docentes.Location = new System.Drawing.Point(50, 95);
            this.tabla_docentes.Name = "tabla_docentes";
            this.tabla_docentes.ReadOnly = true;
            this.tabla_docentes.Size = new System.Drawing.Size(700, 140);
            this.tabla_docentes.TabIndex = 43;
            // 
            // tabla_alumnoActual
            // 
            this.tabla_alumnoActual.AllowUserToAddRows = false;
            this.tabla_alumnoActual.AllowUserToDeleteRows = false;
            this.tabla_alumnoActual.AllowUserToOrderColumns = true;
            this.tabla_alumnoActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_alumnoActual.Location = new System.Drawing.Point(50, 37);
            this.tabla_alumnoActual.Name = "tabla_alumnoActual";
            this.tabla_alumnoActual.ReadOnly = true;
            this.tabla_alumnoActual.Size = new System.Drawing.Size(700, 52);
            this.tabla_alumnoActual.TabIndex = 44;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(823, 24);
            this.menuStrip1.TabIndex = 45;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargaAcademicaToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // cargaAcademicaToolStripMenuItem
            // 
            this.cargaAcademicaToolStripMenuItem.Name = "cargaAcademicaToolStripMenuItem";
            this.cargaAcademicaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.cargaAcademicaToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.cargaAcademicaToolStripMenuItem.Text = "Imprimir Carga Academica";
            this.cargaAcademicaToolStripMenuItem.Click += new System.EventHandler(this.cargaAcademicaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(250, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(250, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // Horario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(823, 476);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabla_alumnoActual);
            this.Controls.Add(this.tabla_docentes);
            this.Controls.Add(this.tabla_Horario);
            this.Name = "Horario";
            this.Text = "Horario";
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Horario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_docentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_alumnoActual)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tabla_Horario;
        private System.Windows.Forms.DataGridView tabla_docentes;
        private System.Windows.Forms.DataGridView tabla_alumnoActual;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargaAcademicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}