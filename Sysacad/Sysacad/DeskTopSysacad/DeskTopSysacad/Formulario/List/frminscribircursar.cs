using DeskTopSysacad.DTO;
using DeskTopSysacad.EnumeradorPublic;
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
	public partial class frminscribircursar : Form
	{
		private Int32 Role;
		private Int32 IdConectado;

		public frminscribircursar(Int32 Tipo,Int32 idconectado)
		{
			InitializeComponent();
			Role = Tipo;
			IdConectado = idconectado;
			this.Text = ("Inscribir a Cursar");
		}

		private void frminscribircursar_Load(object sender, EventArgs e)
		{
			LoadForm();
		}
		private void LoadForm()
		{
			if (Role==(Int32)EnumeradorPublic.Role.Administrador)
			{
				Administrador();
			}
			else if (Role == (Int32)EnumeradorPublic.Role.Alumno)
			{
				Alumno();
			}
			
		}

		private void DGVGrilla_Click(object sender, EventArgs e)
		{
			var idcurso = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
			var accion = Convert.ToString(DGVGrilla[2, DGVGrilla.CurrentRow.Index].Value);
			var materia = Convert.ToString(DGVGrilla[1, DGVGrilla.CurrentRow.Index].Value);

			List<CursoDTO> resultado = new CursoProxy().GetAll("?state=1"+"&top=1000");

			if (Role==(Int32)EnumeradorPublic.Role.Alumno)
			{
				if (accion=="Eliminar")
				{
					if (MessageBox.Show("Estas seguro de eliminar esa materia ?", "Eliminar Materia "+ materia + "", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						var inscripto = new Alumnos_InscripcionProxy().GetAll("?idalumno=" + IdConectado + "&id_curso=" + idcurso);
						if (inscripto.Count() > 0)
						{
							Alumnos_InscripcionDTO dtoeliminar = new Alumnos_InscripcionDTO()
							{
								Id = inscripto.First().id_inscripcion
							};
							new Alumnos_InscripcionProxy().Delete(dtoeliminar);
						}
						else
						{
							MessageBox.Show("No se pudo dar de baja a ese inscripcion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}
				else
				{
					frmelegircomision frmelcom = new frmelegircomision(materia);
					frmelcom.ShowDialog();
					var idcursocomision = frmelcom.idcursocomision;
					var verificar = new Alumnos_InscripcionProxy().GetAll("?idalumno=" + IdConectado + "&id_curso=" + idcurso);
					if (verificar.Count == 0)
					{
						Alumnos_InscripcionDTO dtoinsert = new Alumnos_InscripcionDTO()
						{
							id_alumno = IdConectado,
							id_curso = idcurso,
							condicion = "Inscripto",
							nota = 0,
							estado = (Int32)EstadoPersona.Alta
						};
						new Alumnos_InscripcionProxy().Create(dtoinsert);
						MessageBox.Show("La Inscripcion se realizo corectamente, materia : " + materia + " con Codigo de inscripcion :" + new Alumnos_InscripcionProxy().GetAll("?top=10000000").Last().id_inscripcion + "", "Exitos", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{

					}
						
				}
				
				LoadForm();
			}
			else
			{
				var inscripto = new Alumnos_InscripcionProxy().GetAll("?state=1" + "&top=100");
				
				if (inscripto.Where(x=>x.Id==idcurso).Count()<=30)
				{
					frmbuscaralumno frm = new frmbuscaralumno();
					frm.ShowDialog();

					if (frm.codigo != 0)
					{
						var verificar = inscripto.Where(x => x.id_curso == idcurso && x.id_alumno == frm.codigo).Count();
						var existe = inscripto.Where(x =>x.id_alumno == frm.codigo);
						if (verificar==0)
						{
							
							frmelegircomision frmelcom = new frmelegircomision(materia);
							frmelcom.ShowDialog();
							if (frmelcom.idcursocomision != 0)
							{
								Alumnos_InscripcionDTO dtoinsert = new Alumnos_InscripcionDTO()
								{
									id_alumno = frm.codigo,
									id_curso = frmelcom.idcursocomision,
									condicion = "Inscripto",
									nota = 0,
									estado = (Int32)EstadoPersona.Alta
								};
								new Alumnos_InscripcionProxy().Create(dtoinsert);
								MessageBox.Show("La Inscripcion se realizo corectamente, materia : " + materia + " con Codigo de inscripcion :"+ new Alumnos_InscripcionProxy().GetAll("?top=10000000").Last().id_inscripcion + "", "Exitos", MessageBoxButtons.OK, MessageBoxIcon.Information);
								LoadForm();
							}
							else
							{
								MessageBox.Show("No se pudo completar la inscripcion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
						}
						else
						{
							MessageBox.Show("Ya esta Inscripto en : "+ materia + " con Codigo de inscripcion :"+ inscripto.First().id_inscripcion+"", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}


					}
					else
					{
						MessageBox.Show("No se pudo completar la inscripcion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				else
				{
					MessageBox.Show("No hay mas cupo para esa materia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					//this.Close();
				}


			}
		}
		#region Private Method
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
			string filtersmateria = "?state=" + state + "&top=" + top + "&orderby=id_materia"+ "&ascending=" + ascending + "&page=" + page;
			List<MateriaDTO> lista = new MateriaProxy().GetAll(filtersmateria);
			var Listcursos = resultado.GroupBy(a => a.id_materia).Select(grp => grp.First());

			foreach (var item in Listcursos)
			{					
				item.accion = "Inscribir";
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
					var resul = inscripto.Where(t => t.condicion == "Inscripto" && t.id_curso == item.id_curso && t.id_alumno == IdConectado).Count();
					if (resul > 0)
					{
						item.accion = "Eliminar";
						list.Add(item);
					}
					else
					{
						item.accion = "Inscribir";
						list.Add(item);
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
	}
}
