namespace DeskTopSysacad.Formulario.List
{
	partial class frmmodulo
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
			this.btnfiltrar = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
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
			this.groupBox1.Location = new System.Drawing.Point(2, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(671, 247);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Lista Modulo";
			// 
			// DGVGrilla
			// 
			this.DGVGrilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.DGVGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DGVGrilla.GridColor = System.Drawing.Color.Gray;
			this.DGVGrilla.Location = new System.Drawing.Point(5, 53);
			this.DGVGrilla.Name = "DGVGrilla";
			this.DGVGrilla.ReadOnly = true;
			this.DGVGrilla.Size = new System.Drawing.Size(666, 189);
			this.DGVGrilla.TabIndex = 0;
			// 
			// btneliminar
			// 
			this.btneliminar.ForeColor = System.Drawing.Color.Black;
			this.btneliminar.Location = new System.Drawing.Point(596, 265);
			this.btneliminar.Name = "btneliminar";
			this.btneliminar.Size = new System.Drawing.Size(75, 23);
			this.btneliminar.TabIndex = 8;
			this.btneliminar.Text = "Eliminar";
			this.btneliminar.UseVisualStyleBackColor = true;
			this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
			// 
			// btnmodificar
			// 
			this.btnmodificar.ForeColor = System.Drawing.Color.Black;
			this.btnmodificar.Location = new System.Drawing.Point(515, 265);
			this.btnmodificar.Name = "btnmodificar";
			this.btnmodificar.Size = new System.Drawing.Size(75, 23);
			this.btnmodificar.TabIndex = 7;
			this.btnmodificar.Text = "Modificar";
			this.btnmodificar.UseVisualStyleBackColor = true;
			this.btnmodificar.Click += new System.EventHandler(this.btnmodificar_Click);
			// 
			// btnagregar
			// 
			this.btnagregar.ForeColor = System.Drawing.Color.Black;
			this.btnagregar.Location = new System.Drawing.Point(434, 265);
			this.btnagregar.Name = "btnagregar";
			this.btnagregar.Size = new System.Drawing.Size(75, 23);
			this.btnagregar.TabIndex = 6;
			this.btnagregar.Text = "Agregar";
			this.btnagregar.UseVisualStyleBackColor = true;
			this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
			// 
			// btnfiltrar
			// 
			this.btnfiltrar.BackColor = System.Drawing.Color.DarkGray;
			this.btnfiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnfiltrar.ForeColor = System.Drawing.Color.Black;
			this.btnfiltrar.Location = new System.Drawing.Point(554, 21);
			this.btnfiltrar.Name = "btnfiltrar";
			this.btnfiltrar.Size = new System.Drawing.Size(106, 26);
			this.btnfiltrar.TabIndex = 23;
			this.btnfiltrar.Text = "Filtrar";
			this.btnfiltrar.UseVisualStyleBackColor = false;
			this.btnfiltrar.Click += new System.EventHandler(this.btnfiltrar_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(77, 21);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(468, 26);
			this.textBox1.TabIndex = 22;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(10, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 20);
			this.label1.TabIndex = 21;
			this.label1.Text = "Modulo";
			// 
			// frmmodulo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.ClientSize = new System.Drawing.Size(677, 294);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btneliminar);
			this.Controls.Add(this.btnmodificar);
			this.Controls.Add(this.btnagregar);
			this.ForeColor = System.Drawing.Color.Gainsboro;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmmodulo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.frmmodulo_Load);
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