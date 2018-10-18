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
	public partial class fmbuscarnotaparcial : Form
	{
		public fmbuscarnotaparcial()
		{
			InitializeComponent();
		}

		private void btnbuscar_Click(object sender, EventArgs e)
		{
			int state = 1;
			int top = 100;
			string orderby = "id_persona";
			string ascending = "asc";
			Int32 tipo = 0;
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page + "&tipo_persona=" + tipo;

			if (txtbuscar.Text == String.Empty)
			{
				MessageBox.Show("Debe Ingresar el legajo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtbuscar.Text = String.Empty;
				txtbuscar.Focus();
			}
			else
			{
				List<PersonaDTO> datosdevuelto = new PersonaProxy().GetAll(filters).Where(x => x.legajo == Convert.ToInt32(txtbuscar.Text)).ToList();
				if (datosdevuelto.Count() > 0)
				{
					List<Alumnos_InscripcionDTO> alum = new Alumnos_InscripcionProxy().GetAll("?state=1" + "&top=1000").Where(x => x.id_alumno == datosdevuelto.First().id_persona).ToList();
					frmnotaparcial frm = new frmnotaparcial(alum);
					frm.Show();
					this.Close();
				}
				else
				{
					MessageBox.Show("No hay curso disponible para ese alumno", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}


			}
		}
	}
}
