namespace Residencia
{
    partial class Materias
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_nomMateria = new System.Windows.Forms.Label();
            this.txb_nomMateria = new System.Windows.Forms.TextBox();
            this.lbl_maestro = new System.Windows.Forms.Label();
            this.cmb_nomMaestro = new System.Windows.Forms.ComboBox();
            this.lbl_entrada = new System.Windows.Forms.Label();
            this.ll_salida = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro De Materias";
            // 
            // lbl_nomMateria
            // 
            this.lbl_nomMateria.AutoSize = true;
            this.lbl_nomMateria.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nomMateria.Location = new System.Drawing.Point(12, 79);
            this.lbl_nomMateria.Name = "lbl_nomMateria";
            this.lbl_nomMateria.Size = new System.Drawing.Size(134, 18);
            this.lbl_nomMateria.TabIndex = 1;
            this.lbl_nomMateria.Text = "Nombre de materia:";
            // 
            // txb_nomMateria
            // 
            this.txb_nomMateria.Location = new System.Drawing.Point(15, 113);
            this.txb_nomMateria.Name = "txb_nomMateria";
            this.txb_nomMateria.Size = new System.Drawing.Size(186, 20);
            this.txb_nomMateria.TabIndex = 2;
            // 
            // lbl_maestro
            // 
            this.lbl_maestro.AutoSize = true;
            this.lbl_maestro.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_maestro.Location = new System.Drawing.Point(15, 161);
            this.lbl_maestro.Name = "lbl_maestro";
            this.lbl_maestro.Size = new System.Drawing.Size(140, 18);
            this.lbl_maestro.TabIndex = 3;
            this.lbl_maestro.Text = "Nombre del maestro:";
            // 
            // cmb_nomMaestro
            // 
            this.cmb_nomMaestro.FormattingEnabled = true;
            this.cmb_nomMaestro.Location = new System.Drawing.Point(18, 192);
            this.cmb_nomMaestro.Name = "cmb_nomMaestro";
            this.cmb_nomMaestro.Size = new System.Drawing.Size(186, 21);
            this.cmb_nomMaestro.TabIndex = 4;
            // 
            // lbl_entrada
            // 
            this.lbl_entrada.AutoSize = true;
            this.lbl_entrada.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_entrada.Location = new System.Drawing.Point(15, 242);
            this.lbl_entrada.Name = "lbl_entrada";
            this.lbl_entrada.Size = new System.Drawing.Size(117, 18);
            this.lbl_entrada.TabIndex = 5;
            this.lbl_entrada.Text = "Hora de entrada:";
            // 
            // ll_salida
            // 
            this.ll_salida.AutoSize = true;
            this.ll_salida.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll_salida.Location = new System.Drawing.Point(15, 322);
            this.ll_salida.Name = "ll_salida";
            this.ll_salida.Size = new System.Drawing.Size(107, 18);
            this.ll_salida.TabIndex = 6;
            this.ll_salida.Text = "Hora de salida:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dataGridView1.Location = new System.Drawing.Point(272, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(414, 300);
            this.dataGridView1.TabIndex = 7;
            // 
            // btn_guardar
            // 
            this.btn_guardar.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar.Location = new System.Drawing.Point(104, 408);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 8;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(18, 278);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(18, 355);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar Materia";
            this.Eliminar.Name = "Eliminar";
            // 
            // Materias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(724, 457);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ll_salida);
            this.Controls.Add(this.lbl_entrada);
            this.Controls.Add(this.cmb_nomMaestro);
            this.Controls.Add(this.lbl_maestro);
            this.Controls.Add(this.txb_nomMateria);
            this.Controls.Add(this.lbl_nomMateria);
            this.Controls.Add(this.label1);
            this.Name = "Materias";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_nomMateria;
        private System.Windows.Forms.TextBox txb_nomMateria;
        private System.Windows.Forms.Label lbl_maestro;
        private System.Windows.Forms.ComboBox cmb_nomMaestro;
        private System.Windows.Forms.Label lbl_entrada;
        private System.Windows.Forms.Label ll_salida;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}