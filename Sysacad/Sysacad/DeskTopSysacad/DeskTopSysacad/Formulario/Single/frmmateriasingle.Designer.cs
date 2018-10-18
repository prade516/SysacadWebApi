namespace DeskTopSysacad.Formulario.Single
{
	partial class frmmateriasingle
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
			this.label3 = new System.Windows.Forms.Label();
			this.txtIdmateria = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.txtdescmateria = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbplan = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txths_total = new System.Windows.Forms.TextBox();
			this.txths_semanales = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(358, 143);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(86, 23);
			this.button2.TabIndex = 38;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 36;
			this.label3.Text = "Materia";
			// 
			// txtIdmateria
			// 
			this.txtIdmateria.Location = new System.Drawing.Point(119, 8);
			this.txtIdmateria.Name = "txtIdmateria";
			this.txtIdmateria.ReadOnly = true;
			this.txtIdmateria.Size = new System.Drawing.Size(97, 20);
			this.txtIdmateria.TabIndex = 35;
			this.txtIdmateria.TabStop = false;
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
			this.button1.Location = new System.Drawing.Point(266, 143);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(86, 23);
			this.button1.TabIndex = 33;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtdescmateria
			// 
			this.txtdescmateria.Location = new System.Drawing.Point(119, 34);
			this.txtdescmateria.Name = "txtdescmateria";
			this.txtdescmateria.Size = new System.Drawing.Size(325, 20);
			this.txtdescmateria.TabIndex = 32;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 31;
			this.label1.Text = "Horas Semanales";
			// 
			// cbplan
			// 
			this.cbplan.FormattingEnabled = true;
			this.cbplan.Location = new System.Drawing.Point(119, 111);
			this.cbplan.Name = "cbplan";
			this.cbplan.Size = new System.Drawing.Size(172, 21);
			this.cbplan.TabIndex = 40;
			this.cbplan.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbplan_MouseClick);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 116);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 13);
			this.label4.TabIndex = 39;
			this.label4.Text = "Plan";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 91);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 13);
			this.label5.TabIndex = 41;
			this.label5.Text = "Horas Totales";
			// 
			// txths_total
			// 
			this.txths_total.Location = new System.Drawing.Point(119, 84);
			this.txths_total.Name = "txths_total";
			this.txths_total.ReadOnly = true;
			this.txths_total.Size = new System.Drawing.Size(97, 20);
			this.txths_total.TabIndex = 42;
			// 
			// txths_semanales
			// 
			this.txths_semanales.Location = new System.Drawing.Point(119, 60);
			this.txths_semanales.Name = "txths_semanales";
			this.txths_semanales.Size = new System.Drawing.Size(97, 20);
			this.txths_semanales.TabIndex = 43;
			this.txths_semanales.TextChanged += new System.EventHandler(this.txths_semanales_TextChanged);
			// 
			// frmmateriasingle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(455, 172);
			this.Controls.Add(this.txths_semanales);
			this.Controls.Add(this.txths_total);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cbplan);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtIdmateria);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtdescmateria);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmmateriasingle";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmmateriasingle";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtIdmateria;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtdescmateria;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbplan;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txths_total;
		private System.Windows.Forms.TextBox txths_semanales;
	}
}