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

namespace DeskTopSysacad.Formulario.Presenciar
{
	public partial class frmbuscaralumno : Form
	{
		public Int32 codigo = 0;
		public frmbuscaralumno()
		{
			InitializeComponent();
			this.Text = "Buscar Alumno con su legajo";
		}

		private void btnbuscar_Click(object sender, EventArgs e)
		{
			if (txtbuscar.Text!=String.Empty)
			{
				var alumno = new PersonaProxy().GetAll("?state=1" + "&top=100000000").Where(x => x.legajo == Convert.ToInt32(txtbuscar.Text));
				if (alumno.Count() != 0)
				{
					if (alumno.First().tipo_persona == (Int32)EnumeradorPublic.Role.Alumno)
					{
						codigo = alumno.First().id_persona;
						Close();
					}
					else
					{
						MessageBox.Show("Este legajo no pertenece a un alumno", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtbuscar.Text = String.Empty;
						txtbuscar.Focus();
					}
				}
				else
				{
					MessageBox.Show("No existe es legajo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtbuscar.Text = String.Empty;
					txtbuscar.Focus();
				}
			}
			else
			{
				MessageBox.Show("Debe Ingresar el legajo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtbuscar.Text = String.Empty;
				txtbuscar.Focus();
			}

		}
	}
}
