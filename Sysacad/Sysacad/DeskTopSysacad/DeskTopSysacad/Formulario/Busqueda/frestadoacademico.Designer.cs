namespace DeskTopSysacad.Formulario.Busqueda
{
	partial class frestadoacademico
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
			this.DGVGrilla = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.DGVGrilla)).BeginInit();
			this.SuspendLayout();
			// 
			// DGVGrilla
			// 
			this.DGVGrilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.DGVGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DGVGrilla.Location = new System.Drawing.Point(5, 3);
			this.DGVGrilla.Name = "DGVGrilla";
			this.DGVGrilla.ReadOnly = true;
			this.DGVGrilla.Size = new System.Drawing.Size(926, 463);
			this.DGVGrilla.TabIndex = 3;
			// 
			// frestadoacademico
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(964, 481);
			this.Controls.Add(this.DGVGrilla);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frestadoacademico";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frestadoacademico";
			this.Load += new System.EventHandler(this.frestadoacademico_Load);
			((System.ComponentModel.ISupportInitialize)(this.DGVGrilla)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView DGVGrilla;
	}
}