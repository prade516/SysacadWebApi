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
	public partial class frmlistmateria : Form
	{
		public frmlistmateria()
		{
			InitializeComponent();
			this.Text = "Selectionar una Materia";
		}

		public Int32 codigo = 0;
		public String materia = "";

		private void LoadForm()
		{
			int state = 1;
			int top = 100;
			string orderby = "id_materia";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<MateriaDTO> resultado = new MateriaProxy().GetAll(filters);
			var list = (from materia in resultado
						select new
						{
							Codigo = materia.id_materia,
							Materia = materia.desc_materia,
							HoraSemanales = materia.hs_semanales,
							HoraTotala = materia.hs_totales
						}).ToList();

			DGVGrilla.DataSource = list;
		}

		private void frmlistmateria_Load(object sender, EventArgs e)
		{
			LoadForm();
		}

		private void DGVGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			var habilitar = DGVGrilla.Rows.Count;
			if (habilitar != 0)
			{
				codigo = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
				materia = Convert.ToString(DGVGrilla[1, DGVGrilla.CurrentRow.Index].Value);
				this.Close();
			}
			else
			{
				MessageBox.Show("No tiene materia cargada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.Close();
			}
		}
	}
}
