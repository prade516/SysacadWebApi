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

namespace DeskTopSysacad.Formulario.List
{
	public partial class frmlistcomision : Form
	{
		public Int32 codigo = 0;
		public String materia="";
		public frmlistcomision()
		{
			InitializeComponent();
		}
		private void LoadForm()
		{
			int state = 1;
			int top = 100;
			string orderby = "id_comision";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<ComisionDTO> resultado = new ComisionProxy().GetAll(filters);
			var list = (from comision in resultado
						select new
						{
							Codigo = comision.id_comision,
							Comision = comision.desc_comision,
							Año = comision.anio_especialidad
						}).ToList();

			DGVGrilla.DataSource = list;
		}

		private void frmlistcomision_Load(object sender, EventArgs e)
		{
			LoadForm();
		}

		private void DGVGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			var habilitar = DGVGrilla.Rows.Count;
			if (habilitar!=0)
			{
				codigo = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
				materia = Convert.ToString(DGVGrilla[1, DGVGrilla.CurrentRow.Index].Value);
				this.Close();
			}
			else
			{
				MessageBox.Show("No tiene comision cargada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.Close();
			}
			
		//frmlistcomision fr = new frmlistcomision(codigo, materia);
		}
	}
}
