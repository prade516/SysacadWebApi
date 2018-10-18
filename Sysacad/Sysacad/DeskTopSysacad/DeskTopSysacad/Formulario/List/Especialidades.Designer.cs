namespace DeskTopSysacad
{
	partial class frmespecialidad
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.DGVGrilla = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnagregar = new System.Windows.Forms.Button();
			this.btnmodificar = new System.Windows.Forms.Button();
			this.btneliminar = new System.Windows.Forms.Button();
			this.btnfiltrar = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DGVGrilla)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DGVGrilla
			// 
			this.DGVGrilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.DGVGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DGVGrilla.Location = new System.Drawing.Point(5, 54);
			this.DGVGrilla.Name = "DGVGrilla";
			this.DGVGrilla.ReadOnly = true;
			this.DGVGrilla.Size = new System.Drawing.Size(666, 179);
			this.DGVGrilla.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnfiltrar);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.DGVGrilla);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(1, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(671, 235);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Lista Especialidad";
			// 
			// btnagregar
			// 
			this.btnagregar.Location = new System.Drawing.Point(433, 244);
			this.btnagregar.Name = "btnagregar";
			this.btnagregar.Size = new System.Drawing.Size(75, 23);
			this.btnagregar.TabIndex = 2;
			this.btnagregar.Text = "Agregar";
			this.btnagregar.UseVisualStyleBackColor = true;
			this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
			// 
			// btnmodificar
			// 
			this.btnmodificar.Location = new System.Drawing.Point(514, 244);
			this.btnmodificar.Name = "btnmodificar";
			this.btnmodificar.Size = new System.Drawing.Size(75, 23);
			this.btnmodificar.TabIndex = 3;
			this.btnmodificar.Text = "Modificar";
			this.btnmodificar.UseVisualStyleBackColor = true;
			this.btnmodificar.Click += new System.EventHandler(this.btnmodificar_Click);
			// 
			// btneliminar
			// 
			this.btneliminar.Location = new System.Drawing.Point(595, 244);
			this.btneliminar.Name = "btneliminar";
			this.btneliminar.Size = new System.Drawing.Size(75, 23);
			this.btneliminar.TabIndex = 4;
			this.btneliminar.Text = "Eliminar";
			this.btneliminar.UseVisualStyleBackColor = true;
			this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
			// 
			// btnfiltrar
			// 
			this.btnfiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnfiltrar.Location = new System.Drawing.Point(550, 21);
			this.btnfiltrar.Name = "btnfiltrar";
			this.btnfiltrar.Size = new System.Drawing.Size(106, 26);
			this.btnfiltrar.TabIndex = 23;
			this.btnfiltrar.Text = "Filtrar";
			this.btnfiltrar.UseVisualStyleBackColor = true;
			this.btnfiltrar.Click += new System.EventHandler(this.btnfiltrar_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(128, 22);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(419, 26);
			this.textBox1.TabIndex = 22;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 20);
			this.label1.TabIndex = 21;
			this.label1.Text = "Especialidad";
			// 
			// frmespecialidad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(676, 273);
			this.Controls.Add(this.btneliminar);
			this.Controls.Add(this.btnmodificar);
			this.Controls.Add(this.btnagregar);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmespecialidad";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.frmespecialidad_Load);
			((System.ComponentModel.ISupportInitialize)(this.DGVGrilla)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView DGVGrilla;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnagregar;
		private System.Windows.Forms.Button btnmodificar;
		private System.Windows.Forms.Button btneliminar;
		private System.Windows.Forms.Button btnfiltrar;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
	}
}

