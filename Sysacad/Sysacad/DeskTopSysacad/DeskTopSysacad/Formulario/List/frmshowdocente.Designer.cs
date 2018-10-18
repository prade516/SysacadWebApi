namespace DeskTopSysacad.Formulario.List
{
	partial class frmshowdocente
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
			this.txtapellido = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtnombre = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnfiltrar = new System.Windows.Forms.Button();
			this.DGVGrilla = new System.Windows.Forms.DataGridView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DGVGrilla)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtapellido);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtnombre);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.btnfiltrar);
			this.groupBox1.Controls.Add(this.DGVGrilla);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(7, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1242, 496);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Lista Docente";
			this.groupBox1.UseWaitCursor = true;
			// 
			// txtapellido
			// 
			this.txtapellido.Location = new System.Drawing.Point(717, 29);
			this.txtapellido.Name = "txtapellido";
			this.txtapellido.Size = new System.Drawing.Size(398, 26);
			this.txtapellido.TabIndex = 30;
			this.txtapellido.UseWaitCursor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(646, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 20);
			this.label3.TabIndex = 29;
			this.label3.Text = "Apellido";
			this.label3.UseWaitCursor = true;
			// 
			// txtnombre
			// 
			this.txtnombre.Location = new System.Drawing.Point(87, 29);
			this.txtnombre.Name = "txtnombre";
			this.txtnombre.Size = new System.Drawing.Size(517, 26);
			this.txtnombre.TabIndex = 28;
			this.txtnombre.UseWaitCursor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 20);
			this.label2.TabIndex = 27;
			this.label2.Text = "Nombre";
			this.label2.UseWaitCursor = true;
			// 
			// btnfiltrar
			// 
			this.btnfiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnfiltrar.Location = new System.Drawing.Point(1130, 29);
			this.btnfiltrar.Name = "btnfiltrar";
			this.btnfiltrar.Size = new System.Drawing.Size(106, 26);
			this.btnfiltrar.TabIndex = 26;
			this.btnfiltrar.Text = "Filtrar";
			this.btnfiltrar.UseVisualStyleBackColor = true;
			this.btnfiltrar.UseWaitCursor = true;
			this.btnfiltrar.Click += new System.EventHandler(this.btnfiltrar_Click);
			// 
			// DGVGrilla
			// 
			this.DGVGrilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.DGVGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DGVGrilla.Location = new System.Drawing.Point(5, 64);
			this.DGVGrilla.Name = "DGVGrilla";
			this.DGVGrilla.ReadOnly = true;
			this.DGVGrilla.Size = new System.Drawing.Size(1231, 430);
			this.DGVGrilla.TabIndex = 0;
			this.DGVGrilla.UseWaitCursor = true;
			this.DGVGrilla.Click += new System.EventHandler(this.DGVGrilla_Click);
			// 
			// frmshowdocente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1263, 536);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmshowdocente";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmshowdocente";
			this.Load += new System.EventHandler(this.frmshowdocente_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DGVGrilla)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtapellido;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtnombre;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnfiltrar;
		private System.Windows.Forms.DataGridView DGVGrilla;
	}
}