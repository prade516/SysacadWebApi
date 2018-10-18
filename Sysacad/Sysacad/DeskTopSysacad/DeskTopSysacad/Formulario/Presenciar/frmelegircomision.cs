using DeskTopSysacad.DTO;
using DeskTopSysacad.Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskTopSysacad.Formulario.Presenciar
{
	public partial class frmelegircomision : Form
	{
		private String Nombre;
		public Int32 idcursocomision=0;
		public frmelegircomision(String nombre)
		{
			InitializeComponent();
			Nombre = nombre;
			this.Text = "Elegir la comision";
		}

		private void DGVGrilla_Click(object sender, EventArgs e)
		{
			idcursocomision = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
			this.Close();
		}
		private void LoadForm()
		{
			int state = 1;
			int top = 100;
			string orderby = "id_curso";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<CursoDTO> resultado = new CursoProxy().GetAll(filters);			
			
			var listfinal = (from curso in resultado
							 select new
							 {
								 Codigo = curso.id_curso,
								 Comision = new ComisionProxy().Get(curso.id_comision).desc_comision,
								 Materia = new MateriaProxy().Get(curso.id_materia).desc_materia								
							 }).Where(x=>x.Materia==Nombre).ToList();

			DGVGrilla.DataSource = listfinal;
		}

		private void frmelegircomision_Load(object sender, EventArgs e)
		{
			LoadForm();
			this.DGVGrilla.Columns[2].Visible = false;
		}
	}
}
