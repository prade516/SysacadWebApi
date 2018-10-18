namespace DeskTopSysacad.Formulario.Single
{
	partial class frmplansingle
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
			this.txtIdplan = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.txtdescplan = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbBespecialidad = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtIdplan
			// 
			this.txtIdplan.Location = new System.Drawing.Point(87, 8);
			this.txtIdplan.Name = "txtIdplan";
			this.txtIdplan.ReadOnly = true;
			this.txtIdplan.Size = new System.Drawing.Size(97, 20);
			this.txtIdplan.TabIndex = 27;
			this.txtIdplan.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 26;
			this.label2.Text = "Codigo:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(209, 88);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(86, 23);
			this.button1.TabIndex = 25;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtdescplan
			// 
			this.txtdescplan.Location = new System.Drawing.Point(87, 34);
			this.txtdescplan.Name = "txtdescplan";
			this.txtdescplan.Size = new System.Drawing.Size(172, 20);
			this.txtdescplan.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Especialidad";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 28;
			this.label3.Text = "Plan";
			// 
			// cbBespecialidad
			// 
			this.cbBespecialidad.FormattingEnabled = true;
			this.cbBespecialidad.Location = new System.Drawing.Point(87, 61);
			this.cbBespecialidad.Name = "cbBespecialidad";
			this.cbBespecialidad.Size = new System.Drawing.Size(300, 21);
			this.cbBespecialidad.TabIndex = 29;
			this.cbBespecialidad.SelectedIndexChanged += new System.EventHandler(this.cbBespecialidad_SelectedIndexChanged);
			this.cbBespecialidad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbBespecialidad_MouseClick);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(301, 88);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(86, 23);
			this.button2.TabIndex = 30;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// frmplansingle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(392, 116);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.cbBespecialidad);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtIdplan);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtdescplan);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmplansingle";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmplansingle";
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmplansingle_MouseClick);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtIdplan;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtdescplan;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbBespecialidad;
		private System.Windows.Forms.Button button2;
	}
}