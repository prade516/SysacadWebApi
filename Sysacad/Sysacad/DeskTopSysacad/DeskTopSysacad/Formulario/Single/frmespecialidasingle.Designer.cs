namespace DeskTopSysacad.Formulario.Single
{
	partial class frmespecialidasingle
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
			this.txtespecialidad = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtIdespecialidad = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Especialidad";
			// 
			// txtespecialidad
			// 
			this.txtespecialidad.Location = new System.Drawing.Point(86, 38);
			this.txtespecialidad.Name = "txtespecialidad";
			this.txtespecialidad.Size = new System.Drawing.Size(239, 20);
			this.txtespecialidad.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(239, 65);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(86, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtIdespecialidad
			// 
			this.txtIdespecialidad.Location = new System.Drawing.Point(86, 12);
			this.txtIdespecialidad.Name = "txtIdespecialidad";
			this.txtIdespecialidad.ReadOnly = true;
			this.txtIdespecialidad.Size = new System.Drawing.Size(143, 20);
			this.txtIdespecialidad.TabIndex = 22;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 21;
			this.label2.Text = "Codigo:";
			// 
			// frmespecialidasingle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(334, 96);
			this.Controls.Add(this.txtIdespecialidad);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtespecialidad);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmespecialidasingle";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmespecialidasingle";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtespecialidad;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtIdespecialidad;
		private System.Windows.Forms.Label label2;
	}
}