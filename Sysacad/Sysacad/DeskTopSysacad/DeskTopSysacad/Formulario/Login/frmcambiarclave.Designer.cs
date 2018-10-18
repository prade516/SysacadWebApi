namespace DeskTopSysacad.Formulario.Login
{
	partial class frmcambiarclave
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
			this.label3 = new System.Windows.Forms.Label();
			this.txtconfirmarclave = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtclavenueva = new System.Windows.Forms.TextBox();
			this.txtclaveactual = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtconfirmarclave);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtclavenueva);
			this.groupBox1.Controls.Add(this.txtclaveactual);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(389, 139);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cambiar Clave por primera vez";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Confirmar Clave";
			// 
			// txtconfirmarclave
			// 
			this.txtconfirmarclave.Location = new System.Drawing.Point(132, 80);
			this.txtconfirmarclave.Name = "txtconfirmarclave";
			this.txtconfirmarclave.PasswordChar = '*';
			this.txtconfirmarclave.Size = new System.Drawing.Size(250, 20);
			this.txtconfirmarclave.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Clave Nueva";
			// 
			// txtclavenueva
			// 
			this.txtclavenueva.Location = new System.Drawing.Point(130, 52);
			this.txtclavenueva.Name = "txtclavenueva";
			this.txtclavenueva.PasswordChar = '*';
			this.txtclavenueva.Size = new System.Drawing.Size(250, 20);
			this.txtclavenueva.TabIndex = 4;
			// 
			// txtclaveactual
			// 
			this.txtclaveactual.Location = new System.Drawing.Point(130, 24);
			this.txtclaveactual.Name = "txtclaveactual";
			this.txtclaveactual.PasswordChar = '*';
			this.txtclaveactual.Size = new System.Drawing.Size(250, 20);
			this.txtclaveactual.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Clave Actual";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(307, 106);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(226, 106);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmcambiarclave
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(409, 157);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmcambiarclave";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmcambiarclave";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtconfirmarclave;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtclavenueva;
		private System.Windows.Forms.TextBox txtclaveactual;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
	}
}