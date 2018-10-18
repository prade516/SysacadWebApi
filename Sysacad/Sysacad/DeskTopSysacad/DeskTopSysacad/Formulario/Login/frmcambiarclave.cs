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

namespace DeskTopSysacad.Formulario.Login
{
	public partial class frmcambiarclave : Form
	{
		public BaseSysacadProxy<PersonaDTO> Myproxy()
		{
			return new UsuarioProxy();
		}

		PersonaDTO dtousr = new PersonaDTO();
		public frmcambiarclave( PersonaDTO dto)
		{
			InitializeComponent();
			dtousr = dto;

			this.Text = "Cambiar clave";
			button1.Text = "Confirmar";
			button2.Text = "Cancelar";
		}

		private void button2_Click(object sender, EventArgs e)
		{			
			this.Close();
		}		

		private void button1_Click(object sender, EventArgs e)
		{
			this.cambiarclave();
		}
		#region Private Method
		private void cambiarclave()
		{
			var claveactual = txtclaveactual.Text;
			var clavenueva = txtclavenueva.Text;
			var confirmarclave = txtconfirmarclave.Text;

			if (claveactual == String.Empty)
			{
				MessageBox.Show("Debe ingresar clave actual");
				txtclaveactual.Focus();
			}
			else if (clavenueva == String.Empty)
			{
				MessageBox.Show("Debe ingresar clave nueva");
				txtclavenueva.Focus();
			}
			else if (confirmarclave == String.Empty)
			{
				MessageBox.Show("La confirmacion de la clave nueva es diferente que la clave nueva");
				txtconfirmarclave.Focus();
			}
			else
			{
				var logueo = new PersonaProxy().Get(dtousr.id_persona).Usuarios.Where(x => x.clave == claveactual);

				if (logueo.Count() != 0)
				{
					if (clavenueva == confirmarclave)
					{
						if (claveactual==clavenueva)
						{
							MessageBox.Show("La clave nueva debe ser diferente que la clave actual");
							txtclavenueva.Focus();
							txtconfirmarclave.Text = String.Empty;
						}
						else
						{
							dtousr.Usuarios = new List<UsuarioDTO>()
							{
								new UsuarioDTO()
								{
									id_usuario=logueo.FirstOrDefault().id_usuario,
									id_persona=logueo.FirstOrDefault().id_persona,
									nombre_usuario=logueo.FirstOrDefault().nombre_usuario,
									clave=clavenueva,
									cambia_clave=true,
									email=logueo.FirstOrDefault().email,
									habilitado=logueo.FirstOrDefault().habilitado,
									estado=logueo.FirstOrDefault().estado
								},
							};
							Myproxy().Update(dtousr);
							MessageBox.Show("Tu clave ha cambiado con Exito");
							this.Close();
						}						
					}
					else
					{
						MessageBox.Show("La confirmacion de la clave nueva es diferente que la clave nueva");
						txtclavenueva.Focus();
						txtclavenueva.Text = String.Empty;
						txtconfirmarclave.Text = String.Empty;
					}
				}
				else
				{
					MessageBox.Show("La clave actual no es correcta");
					txtclaveactual.Focus();
					txtclavenueva.Text = String.Empty;
					txtconfirmarclave.Text = String.Empty;
				}
			}
		}
		#endregion
	}
}
