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

namespace DeskTopSysacad
{
	public partial class frmespecialidad :Form
	{
		public  BaseSysacadProxy<EspecialidadDTO> Myproxy()
		{
			return new EspecialidadProxy();
		}
		public frmespecialidad()
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
			string orderby = "id_especialidad";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<EspecialidadDTO> resultado = Myproxy().GetAll(filters);
			var list = (from especialidad in resultado
						select new
						{
							Codigo = especialidad.id_especialidad,
							Especialidad=especialidad.desc_especialidad
						}).ToList();

			DGVGrilla.DataSource = list;
		}

		private void frmespecialidad_Load(object sender, EventArgs e)
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
			frmespecialidasingle frm = new frmespecialidasingle(new EspecialidadDTO(), "A");
			frm.ShowDialog();
			LoadForm();
		}

		private void btnmodificar_Click(object sender, EventArgs e)
		{
			Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
			EspecialidadDTO getespecialidad = Myproxy().Get(id,"");
			frmespecialidasingle frm = new frmespecialidasingle(getespecialidad, "M");
			frm.ShowDialog();
			LoadForm();
		}

		private void btneliminar_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Estas seguro de eliminar este registro ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
				EspecialidadDTO getespecialidad = Myproxy().Get(id, "");
				frmespecialidasingle frm = new frmespecialidasingle(getespecialidad, "D");
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
			string orderby = "id_especialidad";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<EspecialidadDTO> resultado = Myproxy().GetAll(filters);

			var list = (from curso in resultado.Where(x => x.desc_especialidad.Contains(textBox1.Text) || textBox1.Text == String.Empty)
						select new
						{
							Codigo = curso.id_especialidad,
							Especialidad = curso.desc_especialidad,
						}).ToList();
			DGVGrilla.DataSource = list;


		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			//Search();
		}
	}
}
