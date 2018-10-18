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
	public partial class frmshowdocente : Form
	{
		public Int32 codigo = 0;
		public String docente = "";

		public Int32 codigojtp = 0;
		public String ayudante = "";

		public String role = "";
		public frmshowdocente()
		{
			InitializeComponent();
			this.Text = "Selectionar un Docente";
		}

		private void LoadForm()
		{
			int state = 1;
			int top = 100;
			string orderby = "id_persona";
			string ascending = "asc";
			Int32 tipo = Convert.ToInt32(EnumeradorPublic.Role.Docente);
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page + "&tipo_persona=" + tipo;

			DGVGrilla.DataSource = null;
			List<PersonaDTO> resultado = new PersonaProxy().GetAll(filters);
			List<PersonaDTO> listplan = new List<PersonaDTO>();
			var list = (from persona in resultado
						select new
						{
							Codigo = persona.id_persona,
							Apellido = persona.apellido,
							Nombre = persona.nombre,
							Legajo = persona.legajo,
							Telefono = persona.telefono
						}).ToList();

			DGVGrilla.DataSource = list;
		}

		private void frmshowdocente_Load(object sender, EventArgs e)
		{
			LoadForm();
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
			List<PersonaDTO> resultado = new PersonaProxy().GetAll(filters);

			var list = (from curso in resultado.Where((x => (x.nombre.Contains(txtnombre.Text) || txtnombre.Text == String.Empty) && (x.apellido.Contains(txtapellido.Text) || txtapellido.Text == String.Empty)))
						select new
						{
							Codigo = curso.id_persona,
							Nombre = curso.nombre,
							Apellido = curso.apellido,
							Legajo = curso.legajo
						}).ToList();
			DGVGrilla.DataSource = list;
		}

		private void DGVGrilla_Click(object sender, EventArgs e)
		{
			var habilitar = DGVGrilla.Rows.Count;
			if (habilitar != 0)
			{
				if (role=="Docente")
				{
					codigo = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
					docente = Convert.ToString(DGVGrilla[1, DGVGrilla.CurrentRow.Index].Value)+" "+ Convert.ToString(DGVGrilla[2, DGVGrilla.CurrentRow.Index].Value);
					this.Close();
				}
				else if (role=="Ayudante")
				{
					codigojtp = Convert.ToInt32(DGVGrilla[0, DGVGrilla.CurrentRow.Index].Value);
					ayudante = Convert.ToString(DGVGrilla[1, DGVGrilla.CurrentRow.Index].Value) + " " + Convert.ToString(DGVGrilla[2, DGVGrilla.CurrentRow.Index].Value);
					this.Close();
				}
				
			}
			else
			{
				MessageBox.Show("No tiene comision cargada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.Close();
			}
		}
	}
}
