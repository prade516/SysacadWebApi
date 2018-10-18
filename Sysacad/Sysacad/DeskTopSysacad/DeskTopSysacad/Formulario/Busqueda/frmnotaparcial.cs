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

namespace DeskTopSysacad.Formulario.Busqueda
{
	public partial class frmnotaparcial : Form
	{
		List<Alumnos_InscripcionDTO> datos;
		public frmnotaparcial(List<Alumnos_InscripcionDTO> lista)
		{
			InitializeComponent();
			datos = lista;
		}
		private void LoadForm()
		{
			List<Alumnos_InscripcionDTO> lista;
			List<String> listado = new List<String>();
			foreach (var item in datos)
			{
				lista = new List<Alumnos_InscripcionDTO>();
				item.Id = new CursoProxy().Get(item.id_curso).id_materia;
			}
			var list = (from curso in datos
						select new
						{
							Codigo = curso.id_inscripcion,
							Materia = new MateriaProxy().Get(curso.Id).desc_materia,
							Nota = curso.nota,
						}).ToList();			

			DGVGrilla.DataSource = list;

		}

		private void frmnotaparcial_Load(object sender, EventArgs e)
		{
			LoadForm();
		}
	}
}
