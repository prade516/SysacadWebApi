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
	public partial class frestadoacademico : Form
	{
		List<MateriaDTO> listamateria = new List<MateriaDTO>();
		public frestadoacademico(List<MateriaDTO> materia)
		{
			InitializeComponent();
			listamateria = materia;
		}
		private void LoadForm()
		{
			List<String> listado = new List<String>();
			
			var list = (from curso in listamateria
						select new
						{
							Codigo = curso.id_materia,
							Materia = curso.desc_materia,
							//Cursado = new ComisionProxy().Get(curso.Id).desc_comision,
						}).ToList();

			DGVGrilla.DataSource = list.ToList();
		}

		private void frestadoacademico_Load(object sender, EventArgs e)
		{
			LoadForm();
		}
	}
}
