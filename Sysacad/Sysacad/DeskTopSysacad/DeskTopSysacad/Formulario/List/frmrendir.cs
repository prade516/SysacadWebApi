using DeskTopSysacad.DTO;
using DeskTopSysacad.Formulario.Presenciar;
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
	public partial class frmrendir : Form
	{
		public int idconectado;
		public int cargo;

		public frmrendir()
		{
			InitializeComponent();
		}
		#region Private Method
		private void LoadForm()
		{
			if (cargo == (Int32)EnumeradorPublic.Role.Administrador)
			{
				frmbuscaralumno frm = new frmbuscaralumno();
				frm.ShowDialog();
				var idalumno = frm.codigo;
				if (idalumno != 0)
				{
					InscribirAdmi(idalumno);
				}
				else
				{
					this.Close();
				}
			}
			else if (cargo == (Int32)EnumeradorPublic.Role.Alumno)
			{
				Alumno();
			}

		}

		private void Alumno()
		{
			int state = 1;
			int top = 100;
			string orderby = "id_curso";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			List<CursoDTO> list = new List<CursoDTO>();
			List<MateriaDTO> materia = new List<MateriaDTO>();
			List<CursoDTO> resultado = new CursoProxy().GetAll(filters);
			string filtersmateria = "?state=" + state + "&top=" + top + "&orderby=id_materia" + "&ascending=" + ascending + "&page=" + page;
			List<MateriaDTO> lista = new MateriaProxy().GetAll(filtersmateria);
			var Listcursos = resultado.GroupBy(a => a.id_materia).Select(grp => grp.First());

			List<Alumnos_InscripcionDTO> inscripto = new Alumnos_InscripcionProxy().GetAll("?state=1" + "&top=100");

			foreach (var item in Listcursos)
			{
				if (inscripto.Where(x => x.id_curso == item.id_curso).Count() <= 30)
				{
					var resul = inscripto.Where(t => t.condicion == "Examen" && t.id_curso == item.id_curso && t.id_alumno == idconectado).Count();
					if (resul > 0)
					{
						item.accion = "Eliminar";
						list.Add(item);
					}
					else
					{
						var esta = inscripto.Where(t => t.condicion == "Inscripto" && t.id_curso == item.id_curso && t.id_alumno == idconectado).Count();
						if (esta > 0)
						{
							item.accion = "Inscribir";
							list.Add(item);
						}						
					}

				}
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

		private void InscribirAdmi(Int32 idalumno)
		{
			int state = 1;
			int top = 100;
			string orderby = "id_curso";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			List<CursoDTO> list = new List<CursoDTO>();
			List<MateriaDTO> materia = new List<MateriaDTO>();
			List<CursoDTO> resultado = new CursoProxy().GetAll(filters);
			string filtersmateria = "?state=" + state + "&top=" + top + "&orderby=id_materia" + "&ascending=" + ascending + "&page=" + page;
			List<MateriaDTO> lista = new MateriaProxy().GetAll(filtersmateria);
			var Listcursos = resultado.GroupBy(a => a.id_materia).Select(grp => grp.First());

			List<Alumnos_InscripcionDTO> inscripto = new Alumnos_InscripcionProxy().GetAll("?state=1" + "&top=100");

			foreach (var item in Listcursos)
			{
				if (inscripto.Where(x => x.id_curso == item.id_curso).Count() <= 30)
				{
					var resul = inscripto.Where(t => t.condicion == "Examen" && t.id_curso == item.id_curso && t.id_alumno == idalumno).Count();
					if (resul > 0)
					{
						item.accion = "Eliminar";
						list.Add(item);
					}
					else
					{
						var esta = inscripto.Where(t => t.condicion == "Inscripto" && t.id_curso == item.id_curso && t.id_alumno == idalumno).Count();
						if (esta > 0)
						{
							item.accion = "Inscribir";
							list.Add(item);
						}
					}

				}
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
		#endregion

		private void frmrendir_Load(object sender, EventArgs e)
		{
			LoadForm();
		}
	}
}
