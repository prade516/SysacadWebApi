namespace DeskTopSysacad.Formulario.Single
{
	partial class frmcomisionsingle
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
            this.cbplan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdcomision = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtdesccomision = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtanioespecialidad = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 38;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbplan
            // 
            this.cbplan.FormattingEnabled = true;
            this.cbplan.Location = new System.Drawing.Point(124, 90);
            this.cbplan.Name = "cbplan";
            this.cbplan.Size = new System.Drawing.Size(300, 21);
            this.cbplan.TabIndex = 37;
            this.cbplan.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbplan_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Comision";
            // 
            // txtIdcomision
            // 
            this.txtIdcomision.Location = new System.Drawing.Point(124, 8);
            this.txtIdcomision.Name = "txtIdcomision";
            this.txtIdcomision.ReadOnly = true;
            this.txtIdcomision.Size = new System.Drawing.Size(97, 20);
            this.txtIdcomision.TabIndex = 35;
            this.txtIdcomision.TabStop = false;
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
            this.button1.Location = new System.Drawing.Point(247, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtdesccomision
            // 
            this.txtdesccomision.Location = new System.Drawing.Point(124, 34);
            this.txtdesccomision.Name = "txtdesccomision";
            this.txtdesccomision.Size = new System.Drawing.Size(172, 20);
            this.txtdesccomision.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Plan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Año Especialidad";
            // 
            // txtanioespecialidad
            // 
            this.txtanioespecialidad.Location = new System.Drawing.Point(124, 61);
            this.txtanioespecialidad.Name = "txtanioespecialidad";
            this.txtanioespecialidad.Size = new System.Drawing.Size(172, 20);
            this.txtanioespecialidad.TabIndex = 39;
            // 
            // frmcomisionsingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 146);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtanioespecialidad);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbplan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdcomision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtdesccomision);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmcomisionsingle";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmcomisionsingle";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox cbplan;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtIdcomision;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtdesccomision;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtanioespecialidad;
	}
}