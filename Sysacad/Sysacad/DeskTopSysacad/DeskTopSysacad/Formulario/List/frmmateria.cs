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
	public partial class frmmateria : Form
	{
		public BaseSysacadProxy<MateriaDTO> Myproxy()
		{
			return new MateriaProxy();
		}
		public frmmateria()
		{
			InitializeComponent();
			this.Text = ("Lista De Materias").ToString().ToUpper();
			
		}
		private void LoadForm()
		{
			int state = 1;
			int top = 100;
			string orderby = "id_materia";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<MateriaDTO> resultado = Myproxy().GetAll(filters);
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

		private void frmmateria_Load(object sender, EventArgs e)
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
			frmmateriasingle frm = new frmmateriasingle(new MateriaDTO(), "A");
			frm.ShowDialog();
			LoadForm();
		}

		private void btnmodificar_Click(object sender, EventArgs e)
		{
			Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
			MateriaDTO getmateria = Myproxy().Get(id, "");
			frmmateriasingle frm = new frmmateriasingle(getmateria, "M");
			frm.ShowDialog();
			LoadForm();
		}

		private void btneliminar_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Estas seguro de eliminar este registro ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
				MateriaDTO getmateria = Myproxy().Get(id, "");
				frmmateriasingle frm = new frmmateriasingle(getmateria, "D");
				frm.ShowDialog();
				LoadForm();
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
			string orderby = "id_materia";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<MateriaDTO> resultado = Myproxy().GetAll(filters);
			var list = (from materia in resultado.Where(x => x.desc_materia.Contains(textBox1.Text) || textBox1.Text == String.Empty)
						select new
						{
							Codigo = materia.id_materia,
							Modulo = materia.desc_materia,
							HorasSemanales=materia.hs_semanales,
							HorasTotales=materia.hs_semanales
						}).ToList();
			DGVGrilla.DataSource = list;

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Search();
		}
	}
}
