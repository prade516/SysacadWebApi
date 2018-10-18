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
	public partial class frmbuscardocente : Form
	{
		public int iddocente=0;

		public frmbuscardocente()
		{
			InitializeComponent();
			this.Text = "Buscar Docente Con su Legajo";
		}
		private void SaerchLegajo()
		{
			if (txtbuscar.Text==String.Empty)
			{
				MessageBox.Show("Debe ingresar el legajo para ese profesor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtbuscar.Text = String.Empty;
				txtbuscar.Focus();
			}
			else
			{
				var list = new PersonaProxy().GetAll("?state=1"+"&top=10000").Where(x=>x.legajo==Convert.ToInt32(txtbuscar.Text));
				if (list.Count()> 0)
				{
					 iddocente = list.FirstOrDefault().id_persona;
					this.Close();
				}
				else
				{
					MessageBox.Show("No existe el legajo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtbuscar.Text = String.Empty;
					txtbuscar.Focus();
				}
			}
		}

		private void btnbuscar_Click(object sender, EventArgs e)
		{
			SaerchLegajo();
		}
	}
}
