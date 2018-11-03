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
	public partial class frmcomision : Form
	{
		public BaseSysacadProxy<ComisionDTO> Myproxy()
		{
			return new ComisionProxy();
		}
		public frmcomision()
		{
			InitializeComponent();
			this.Text = ("Lista De Comision").ToString().ToUpper();
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
			string orderby = "id_comision";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<ComisionDTO> resultado = Myproxy().GetAll(filters);
			var list = (from comision in resultado
						select new
						{
							Codigo = comision.id_comision,
							Comision = comision.desc_comision,
							Año=comision.anio_especialidad
						}).ToList();

			DGVGrilla.DataSource = list;
			
		}

		private void frmcomision_Load(object sender, EventArgs e)
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
			frmcomisionsingle frm = new frmcomisionsingle(new ComisionDTO(), "A");
			frm.ShowDialog();
			LoadForm();
		}

		private void btnmodificar_Click(object sender, EventArgs e)
		{
			Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
			ComisionDTO getcomision = Myproxy().Get(id, "");
			frmcomisionsingle frm = new frmcomisionsingle(getcomision, "M");
			frm.ShowDialog();
			LoadForm();
		}

		private void btneliminar_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Estas seguro de eliminar este registro ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
				ComisionDTO getcomision = Myproxy().Get(id, "");
				frmcomisionsingle frm = new frmcomisionsingle(getcomision, "D");
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
			string orderby = "id_comision";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<ComisionDTO> resultado = Myproxy().GetAll(filters);
			
				var list = (from curso in resultado.Where(x => x.desc_comision.Contains(textBox1.Text)|| textBox1.Text==String.Empty)
							select new
							{
								Codigo = curso.id_comision,
								Comision =curso.desc_comision,
								Año = curso.anio_especialidad
							}).ToList();
				DGVGrilla.DataSource = list;
			

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Search();
		}

        private void btnactDGV_Click(object sender, EventArgs e)
        {
            this.LoadForm();
        }
    }
}
