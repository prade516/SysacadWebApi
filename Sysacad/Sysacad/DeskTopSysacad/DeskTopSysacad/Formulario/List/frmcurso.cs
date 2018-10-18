using DeskTopSysacad.DTO;
using DeskTopSysacad.Formulario.Single;
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

namespace DeskTopSysacad.Formulario.List
{
	public partial class frmcurso : Form
	{
		public BaseSysacadProxy<CursoDTO> Myproxy()
		{
			return new CursoProxy();
		}
		public frmcurso()
		{
			InitializeComponent();
			this.Text = ("Lista De Cursos").ToString().ToUpper();
			var habilitar = DGVGrilla.Rows.Count;
			if (habilitar != 0)
			{
				btnmodificar.Enabled = false;
				btneliminar.Enabled = false;
			}
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
			List<CursoDTO> resultado = Myproxy().GetAll(filters);
			var list = (from curso in resultado
						select new
						{
							Codigo = curso.id_curso,
							Materia = new MateriaProxy().Get(curso.id_materia).desc_materia,
							Comision = new ComisionProxy().Get(curso.id_comision).desc_comision,
							Cupo = curso.cupo,
							Calendario = curso.anio_calendario
						}).ToList();

			DGVGrilla.DataSource = list;
		}

		private void frmcurso_Load(object sender, EventArgs e)
		{
			LoadForm();

			var habilitar = DGVGrilla.Rows.Count;
			if (habilitar == 0)
			{
				btnmodificar.Enabled = false;
				btneliminar.Enabled = false;
			}
		}

		private void btnagregar_Click(object sender, EventArgs e)
		{
			frmcursosingle frm = new frmcursosingle(new CursoDTO(), "A");
			frm.ShowDialog();
			LoadForm();

			var habilitar = DGVGrilla.Rows.Count;
			if (habilitar != 0)
			{
				btnmodificar.Enabled = true;
				btneliminar.Enabled = true;
			}
		}

		private void btnmodificar_Click(object sender, EventArgs e)
		{

			Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
			CursoDTO getcurso = Myproxy().Get(id, "");
			frmcursosingle frm = new frmcursosingle(getcurso, "M");
			frm.ShowDialog();
			LoadForm();

			var habilitar = DGVGrilla.Rows.Count;
			if (habilitar != 0)
			{
				btnmodificar.Enabled = true;
				btneliminar.Enabled = true;
			}
		}

		private void btneliminar_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Estas seguro de eliminar este registro ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
				CursoDTO getcurso = Myproxy().Get(id, "");
				frmcursosingle frm = new frmcursosingle(getcurso, "D");
				frm.ShowDialog();
				LoadForm();

				var habilitar = DGVGrilla.Rows.Count;
				if (habilitar == 0)
				{
					btnmodificar.Enabled = false;
					btneliminar.Enabled = false;
				}
			}
		}

		private void btnfiltrar_Click(object sender, EventArgs e)
		{
			Search();
		}
		private void Search()
		{
			int state = 1;
			int top = 100;
			string orderby = "id_curso";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<CursoDTO> resultado = Myproxy().GetAll(filters);
			if (textBox1.Text==String.Empty)
			{
				LoadForm();

			}
			else
			{
				var list = (from curso in resultado.Where(x => x.anio_calendario == Convert.ToInt32(textBox1.Text))
							select new
							{
								Codigo = curso.id_curso,
								Materia = new MateriaProxy().Get(curso.id_materia).desc_materia,
								Comision = new ComisionProxy().Get(curso.id_comision).desc_comision,
								Cupo = curso.cupo,
								Calendario = curso.anio_calendario
							}).ToList();
				DGVGrilla.DataSource = list;
			}
		
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Search();
		}
	}
}
