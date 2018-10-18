namespace DeskTopSysacad.Formulario.Single
{
	partial class frmsinglenota
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
			this.button2 = new System.Windows.Forms.Button();
			this.txtmateria = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtidinscripcion = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.txtalumno = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtnota = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(246, 113);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(86, 23);
			this.button2.TabIndex = 38;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtmateria
			// 
			this.txtmateria.Location = new System.Drawing.Point(93, 61);
			this.txtmateria.Name = "txtmateria";
			this.txtmateria.Size = new System.Drawing.Size(239, 20);
			this.txtmateria.TabIndex = 37;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 36;
			this.label3.Text = "Materia";
			// 
			// txtidinscripcion
			// 
			this.txtidinscripcion.Location = new System.Drawing.Point(93, 8);
			this.txtidinscripcion.Name = "txtidinscripcion";
			this.txtidinscripcion.ReadOnly = true;
			this.txtidinscripcion.Size = new System.Drawing.Size(143, 20);
			this.txtidinscripcion.TabIndex = 35;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 34;
			this.label2.Text = "Codigo:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(154, 113);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(86, 23);
			this.button1.TabIndex = 33;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtalumno
			// 
			this.txtalumno.Location = new System.Drawing.Point(93, 34);
			this.txtalumno.Name = "txtalumno";
			this.txtalumno.Size = new System.Drawing.Size(239, 20);
			this.txtalumno.TabIndex = 32;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 31;
			this.label1.Text = "Alumno";
			// 
			// txtnota
			// 
			this.txtnota.Location = new System.Drawing.Point(93, 87);
			this.txtnota.Name = "txtnota";
			this.txtnota.Size = new System.Drawing.Size(239, 20);
			this.txtnota.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 39;
			this.label4.Text = "Nota";
			// 
			// frmsinglenota
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(336, 142);
			this.Controls.Add(this.txtnota);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtmateria);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtidinscripcion);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtalumno);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "frmsinglenota";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmsinglenota";
			this.Load += new System.EventHandler(this.frmsinglenota_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtmateria;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtidinscripcion;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtalumno;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtnota;
		private System.Windows.Forms.Label label4;
	}
}