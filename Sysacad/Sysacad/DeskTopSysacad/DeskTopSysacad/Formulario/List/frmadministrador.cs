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
	public partial class frmadministrador : Form
	{
		public BaseSysacadProxy<PersonaDTO> Myproxy()
		{
			return new PersonaProxy();
		}
		public frmadministrador()
		{
			InitializeComponent();
			this.Text = "Lista Administrador";			
		}
		private void LoadForm()
		{
			int state = 1;
			int top = 100;
			string orderby = "id_persona";
			string ascending = "asc";
			Int32 tipo = Convert.ToInt32(EnumeradorPublic.Role.Administrador);
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page+ "&tipo_persona="+tipo;

			DGVGrilla.DataSource = null;
			List<PersonaDTO> resultado = Myproxy().GetAll(filters);
			List<PersonaDTO> listplan = new List<PersonaDTO>();
			var list = (from persona in resultado
						select new
						{
							Codigo = persona.id_persona,
							Apellido = persona.apellido,
							Nombre=persona.nombre,
							Legajo=persona.legajo,
							Telefono=persona.telefono
						}).ToList();

			DGVGrilla.DataSource = list;
		}

		private void frmpersona_Load(object sender, EventArgs e)
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
			frmpersonasingle frm = new frmpersonasingle(new PersonaDTO(), "A", "Administrador","Alta Administrador");
			frm.ShowDialog();
			LoadForm();
			
		}

		private void btnmodificar_Click(object sender, EventArgs e)
		{
			Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
			PersonaDTO getpersona = Myproxy().Get(id, "");
			frmpersonasingle frm = new frmpersonasingle(getpersona, "M", "Administrador", "Modificar Administrador");
			frm.ShowDialog();
			LoadForm();
		}

		private void btneliminar_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Estas seguro de eliminar este registro ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Int32 id = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
				PersonaDTO getpersona = Myproxy().Get(id, "");
				frmpersonasingle frm = new frmpersonasingle(getpersona, "D", "Administrador", "Eliminar Adminstrador");
				frm.ShowDialog();
				LoadForm();
			}
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void btnfiltrar_Click(object sender, EventArgs e)
		{
			Search();
		}
		private void Search()
		{
			int state = 1;
			int top = 100;
			string orderby = "id_persona";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			DGVGrilla.DataSource = null;
			List<PersonaDTO> resultado = Myproxy().GetAll(filters);

			var list = (from curso in resultado.Where((x => (x.nombre.Contains(txtnombre.Text) || txtnombre.Text == String.Empty) &&(x.apellido.Contains(txtapellido.Text) || txtapellido.Text == String.Empty)))
						select new
						{
							Codigo = curso.id_persona,
							Nombre = curso.nombre,
							Apellido=curso.apellido,
							Legajo=curso.legajo
						}).ToList();
			DGVGrilla.DataSource = list;


		}
	}
}
