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
	public partial class frmplan : Form
	{
		public BaseSysacadProxy<PlanDTO> Myproxy()
		{
			return new PlanProxy();
		}
		public frmplan()
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
			string orderby = "id_plan";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<PlanDTO> resultado = Myproxy().GetAll(filters);
			List<PlanDTO> listplan = new List<PlanDTO>();
		    var list = (from plan in resultado
						select new
						{
							Codigo = plan.id_plan,
							Plan = plan.desc_plan
						}).ToList();

			DGVGrilla.DataSource = list;
		}

		private void frmplan_Load(object sender, EventArgs e)
		{
			this.LoadForm();
			var habilitar = DGVGrilla.Rows.Count;
			if (habilitar == 0)
			{
				btnmodificar.Enabled = false;
				btneliminar.Enabled = false;
			}
		}

		private void btnagregar_Click(object sender, EventArgs e)
		{
			frmplansingle frm = new frmplansingle(new PlanDTO(), "A");
			frm.ShowDialog();
			LoadForm();
		}

		private void btnmodificar_Click(object sender, EventArgs e)
		{
			Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
			PlanDTO getplan = Myproxy().Get(id, "");
			frmplansingle frm = new frmplansingle(getplan, "M");
			frm.ShowDialog();
			LoadForm();
		}

		private void btneliminar_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Estas seguro de eliminar este registro ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
				PlanDTO getplan = Myproxy().Get(id, "");
				frmplansingle frm = new frmplansingle(getplan, "D");
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
			string orderby = "id_plan";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<PlanDTO> resultado = Myproxy().GetAll(filters);
			if (textBox1.Text == String.Empty)
			{
				LoadForm();

			}
			else
			{
				var list = (from plan in resultado.Where(x => x.desc_plan.Contains(textBox1.Text) || textBox1.Text==String.Empty)
							select new
							{
								Codigo = plan.id_plan,
								Plan = plan.desc_plan								
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
