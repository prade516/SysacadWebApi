using DeskTopSysacad.DTO;
using DeskTopSysacad.Formulario.Single;
using DeskTopSysacad.Properties;
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
	public partial class frmmodulo : Form
	{
		public BaseSysacadProxy<ModuloDTO> Myproxy()
		{
			return new ModuloProxy();
		}
		public frmmodulo()
		{
			InitializeComponent();
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
			string orderby = "id_modulo";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<ModuloDTO> resultado = Myproxy().GetAll(filters);
			var list = (from modulo in resultado
						select new
						{
							Codigo = modulo.id_modulo,
							Modula = modulo.desc_modulo,
							Ejecuta=modulo.ejecuta
						}).ToList();
            this.DGVGrilla.DefaultCellStyle.ForeColor = Color.Black;
            DGVGrilla.DataSource = list;
		}

		private void frmmodulo_Load(object sender, EventArgs e)
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
			frmmodulosingle frm = new frmmodulosingle(new ModuloDTO(), "A");
			frm.ShowDialog();
			LoadForm();
		}

		private void btnmodificar_Click(object sender, EventArgs e)
		{
			Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
			ModuloDTO getmodulo = Myproxy().Get(id, "");
			frmmodulosingle frm = new frmmodulosingle(getmodulo, "M");
			frm.ShowDialog();
			LoadForm();
		}

		private void btneliminar_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Estas seguro de eliminar este registro ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
				ModuloDTO getmodulo = Myproxy().Get(id, "");
				frmmodulosingle frm = new frmmodulosingle(getmodulo, "D");
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
			string orderby = "id_modulo";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<ModuloDTO> resultado = Myproxy().GetAll(filters);			
				var list = (from mod in resultado.Where(x => x.desc_modulo.Contains(textBox1.Text) || textBox1.Text == String.Empty)
							select new
							{
								Codigo = mod.id_modulo,
								Modulo = mod.desc_modulo
							}).ToList();
				DGVGrilla.DataSource = list;

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Search();
		}
	}
}
