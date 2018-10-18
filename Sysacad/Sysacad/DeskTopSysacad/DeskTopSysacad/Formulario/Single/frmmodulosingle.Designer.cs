namespace DeskTopSysacad.Formulario.Single
{
	partial class frmmodulosingle
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
			this.txtidmodulo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.txtmodulo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtejecuta = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtidmodulo
			// 
			this.txtidmodulo.Location = new System.Drawing.Point(90, 7);
			this.txtidmodulo.Name = "txtidmodulo";
			this.txtidmodulo.ReadOnly = true;
			this.txtidmodulo.Size = new System.Drawing.Size(143, 20);
			this.txtidmodulo.TabIndex = 27;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 26;
			this.label2.Text = "Codigo:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(149, 86);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(86, 23);
			this.button1.TabIndex = 25;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtmodulo
			// 
			this.txtmodulo.Location = new System.Drawing.Point(90, 33);
			this.txtmodulo.Name = "txtmodulo";
			this.txtmodulo.Size = new System.Drawing.Size(239, 20);
			this.txtmodulo.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Modulo";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 28;
			this.label3.Text = "Ejecuta";
			// 
			// txtejecuta
			// 
			this.txtejecuta.Location = new System.Drawing.Point(90, 60);
			this.txtejecuta.Name = "txtejecuta";
			this.txtejecuta.Size = new System.Drawing.Size(239, 20);
			this.txtejecuta.TabIndex = 29;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(241, 86);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(86, 23);
			this.button2.TabIndex = 30;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// frmmodulosingle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(333, 113);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtejecuta);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtidmodulo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtmodulo);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmmodulosingle";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmmodulosingle";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtidmodulo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtmodulo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtejecuta;
		private System.Windows.Forms.Button button2;
	}
}