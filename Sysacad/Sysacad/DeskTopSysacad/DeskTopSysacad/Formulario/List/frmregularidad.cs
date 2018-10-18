using DeskTopSysacad.DTO;
using DeskTopSysacad.Formulario.Presenciar;
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
	public partial class frmregularidad : Form
	{
		public Int32 iddocente = 0;
		public Int32 cargo = 0;

		public frmregularidad()
		{
			InitializeComponent();
			this.Text = "Agregar Nota";			
		}

		private void LoadForm()
		{
			if (cargo == (Int32)EnumeradorPublic.Role.Administrador)
			{
				frmbuscardocente frm = new frmbuscardocente();
				frm.ShowDialog();
				var iddocente = frm.iddocente;
				if (iddocente != 0)
				{
					RegularizarAdmi(iddocente);
				}
				else
				{
					this.Close();
				}
			}
			else if (cargo == (Int32)EnumeradorPublic.Role.Docente)
			{
				Docente();
			}

		}
		private void frmregularidad_Load(object sender, EventArgs e)
		{
			LoadForm();
		}

		private void DGVGrilla_Click(object sender, EventArgs e)
		{
			var idinscripto = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
			
			var alumno = new Alumnos_InscripcionProxy().Get(idinscripto);
			frmsinglenota frm = new frmsinglenota(alumno);
			frm.ShowDialog();						
			
		}

		#region Method Private
		private void Administrador()
		{

			int state = 1;
			int top = 1000000;
			string orderby = "id_curso";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<CursoDTO> list = new List<CursoDTO>();
			List<MateriaDTO> materia = new List<MateriaDTO>();
			List<CursoDTO> resultado = new CursoProxy().GetAll(filters);
			string filtersmateria = "?state=" + state + "&top=" + top + "&orderby=id_materia" + "&ascending=" + ascending + "&page=" + page;
			List<MateriaDTO> lista = new MateriaProxy().GetAll(filtersmateria);
			var Listcursos = resultado.GroupBy(a => a.id_materia).Select(grp => grp.First());

			foreach (var item in Listcursos)
			{
				item.accion = "Agregar Nota";
				list.Add(item);
			}
			var listfinal = (from curso in list
							 select new
							 {
								 Codigo = curso.id_curso,
								 Materia = new MateriaProxy().Get(curso.id_materia).desc_materia,
								 Acccion = curso.accion
							 }).ToList();
			DGVGrilla.DataSource = listfinal;
		}
		private void Docente()
		{
			int state = 1;
			int top = 100;
			string orderby = "id_curso";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			List<Alumnos_InscripcionDTO> list = new List<Alumnos_InscripcionDTO>();
			List<MateriaDTO> materia = new List<MateriaDTO>();
			List<CursoDTO> resultado = new CursoProxy().GetAll(filters);
			string filtersmateria = "?state=" + state + "&top=" + top + "&orderby=id_materia" + "&ascending=" + ascending + "&page=" + page;
			List<MateriaDTO> lista = new MateriaProxy().GetAll(filtersmateria);


			List<Alumnos_InscripcionDTO> inscripto = new Alumnos_InscripcionProxy().GetAll("?state=1" + "&top=100");
			var docente = resultado.Where(t => t.Docente_curso.Any(xt => xt.id_docente == iddocente));
			foreach (var item in resultado)
			{
				foreach (var item2 in item.Docente_curso)
				{
					var resul = inscripto.Where(t => t.condicion == "Inscripto" && t.id_curso == item2.id_cursos);
					if (resul.Count() > 0)
					{
						foreach (var inscrip in resul)
						{
							list.Add(inscrip);
						}

					}
				}
			}

			var Listcursos = list.GroupBy(a => a.id_inscripcion).Select(grp => grp.First());
			var listfinal = (from curso in Listcursos
							 select new
							 {
								 Codigo = curso.id_inscripcion,
								 Nombre = new PersonaProxy().Get(curso.id_alumno).nombre + " " + new PersonaProxy().Get(curso.id_alumno).nombre,
								 Materia = new MateriaProxy().Get(new CursoProxy().Get(curso.id_curso).id_materia).desc_materia,
								 Acccion = "Agregar Nota"
							 }).ToList();

			DGVGrilla.DataSource = listfinal;
		}
		private void RegularizarAdmi(Int32 iddocente)
		{
			int state = 1;
			int top = 100;
			string orderby = "id_curso";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			List<Alumnos_InscripcionDTO> list = new List<Alumnos_InscripcionDTO>();
			List<MateriaDTO> materia = new List<MateriaDTO>();
			List<CursoDTO> resultado = new CursoProxy().GetAll(filters);
			string filtersmateria = "?state=" + state + "&top=" + top + "&orderby=id_materia" + "&ascending=" + ascending + "&page=" + page;
			List<MateriaDTO> lista = new MateriaProxy().GetAll(filtersmateria);


			List<Alumnos_InscripcionDTO> inscripto = new Alumnos_InscripcionProxy().GetAll("?state=1" + "&top=100");
			var docente = resultado.Where(t => t.Docente_curso.Any(xt => xt.id_docente == iddocente));
			foreach (var item in resultado)
			{
				foreach (var item2 in item.Docente_curso)
				{
					var resul = inscripto.Where(t => t.condicion == "Inscripto" && t.id_curso == item2.id_cursos);
					if (resul.Count() > 0)
					{
						foreach (var inscrip in resul)
						{
							list.Add(inscrip);
						}

					}
				}
			}

			var Listcursos = list.GroupBy(a => a.id_inscripcion).Select(grp => grp.First());
			var listfinal = (from curso in Listcursos
							 select new
							 {
								 Codigo = curso.id_inscripcion,
								 Nombre = new PersonaProxy().Get(curso.id_alumno).nombre + " " + new PersonaProxy().Get(curso.id_alumno).nombre,
								 Materia = new MateriaProxy().Get(new CursoProxy().Get(curso.id_curso).id_materia).desc_materia,
								 Acccion = "Agregar Nota"
							 }).ToList();

			DGVGrilla.DataSource = listfinal;
		}
		#endregion
	}
}
