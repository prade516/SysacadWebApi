namespace DeskTopSysacad.Formulario.List
{
	partial class frmcurso
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.DGVGrilla = new System.Windows.Forms.DataGridView();
			this.btneliminar = new System.Windows.Forms.Button();
			this.btnmodificar = new System.Windows.Forms.Button();
			this.btnagregar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnfiltrar = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DGVGrilla)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnfiltrar);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.DGVGrilla);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(5, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(706, 440);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Lista Curso";
			// 
			// DGVGrilla
			// 
			this.DGVGrilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.DGVGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DGVGrilla.Location = new System.Drawing.Point(5, 69);
			this.DGVGrilla.Name = "DGVGrilla";
			this.DGVGrilla.ReadOnly = true;
			this.DGVGrilla.Size = new System.Drawing.Size(695, 365);
			this.DGVGrilla.TabIndex = 0;
			// 
			// btneliminar
			// 
			this.btneliminar.Location = new System.Drawing.Point(636, 450);
			this.btneliminar.Name = "btneliminar";
			this.btneliminar.Size = new System.Drawing.Size(75, 23);
			this.btneliminar.TabIndex = 16;
			this.btneliminar.Text = "Eliminar";
			this.btneliminar.UseVisualStyleBackColor = true;
			this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
			// 
			// btnmodificar
			// 
			this.btnmodificar.Location = new System.Drawing.Point(555, 450);
			this.btnmodificar.Name = "btnmodificar";
			this.btnmodificar.Size = new System.Drawing.Size(75, 23);
			this.btnmodificar.TabIndex = 15;
			this.btnmodificar.Text = "Modificar";
			this.btnmodificar.UseVisualStyleBackColor = true;
			this.btnmodificar.Click += new System.EventHandler(this.btnmodificar_Click);
			// 
			// btnagregar
			// 
			this.btnagregar.Location = new System.Drawing.Point(474, 450);
			this.btnagregar.Name = "btnagregar";
			this.btnagregar.Size = new System.Drawing.Size(75, 23);
			this.btnagregar.TabIndex = 14;
			this.btnagregar.Text = "Agregar";
			this.btnagregar.UseVisualStyleBackColor = true;
			this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(118, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Año Calendario";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(155, 25);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(431, 26);
			this.textBox1.TabIndex = 2;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// btnfiltrar
			// 
			this.btnfiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnfiltrar.Location = new System.Drawing.Point(592, 25);
			this.btnfiltrar.Name = "btnfiltrar";
			this.btnfiltrar.Size = new System.Drawing.Size(106, 26);
			this.btnfiltrar.TabIndex = 17;
			this.btnfiltrar.Text = "Filtrar";
			this.btnfiltrar.UseVisualStyleBackColor = true;
			this.btnfiltrar.Click += new System.EventHandler(this.btnfiltrar_Click);
			// 
			// frmcurso
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 480);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btneliminar);
			this.Controls.Add(this.btnmodificar);
			this.Controls.Add(this.btnagregar);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmcurso";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmcurso";
			this.Load += new System.EventHandler(this.frmcurso_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DGVGrilla)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView DGVGrilla;
		private System.Windows.Forms.Button btneliminar;
		private System.Windows.Forms.Button btnmodificar;
		private System.Windows.Forms.Button btnagregar;
		private System.Windows.Forms.Button btnfiltrar;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
	}
}