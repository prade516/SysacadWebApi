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
	public partial class frmlogin : Form
	{
		public BaseSysacadProxy<PersonaDTO> Myproxy()
		{
			return new UsuarioProxy();
		}
		public frmlogin()
		{
			InitializeComponent();
			this.Text = "Login de Usuario";
			button1.Text = "Loguea";
			button2.Text = "Cancelar";		
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Login();
		}
		#region Private Method
		private void Login()
		{
			var usuario = txtusuario.Text;
			var clave = txtclave.Text;
			if (usuario == String.Empty)
			{
                ErrorValidacion.Message.GetInstance().MensajeAdvertencia("Tiene que ingresar el usuario");
                txtusuario.Text = String.Empty;
				txtusuario.Focus();
			}
			else if (clave == String.Empty)
			{
                ErrorValidacion.Message.GetInstance().MensajeAdvertencia("Tiene que ingresar el clave");
                txtclave.Text = String.Empty;
				txtclave.Focus();
			}
			else
			{
				var concectado = Myproxy().GetAll("?username=" + usuario + "&password=" + clave).FirstOrDefault();
				if (concectado == null)
				{
                    ErrorValidacion.Message.GetInstance().MensajeAdvertencia("Usuario y/o clave es incorrecto");
                    txtusuario.Text = String.Empty;
					txtusuario.Focus();
				}
				else
				{
					

					if (concectado.Usuarios.FirstOrDefault().cambia_clave == false)
					{
						frmcambiarclave fmcambiar = new frmcambiarclave(concectado);
						fmcambiar.ShowDialog();
						txtusuario.Text = String.Empty;
						txtclave.Text = String.Empty;
						txtusuario.Focus();
						this.Show();
					}
					else
					{
						frmprincipal fm = new frmprincipal(concectado);
						this.Hide();
						fm.ShowDialog();
						txtusuario.Text = String.Empty;
						txtclave.Text = String.Empty;
						txtusuario.Focus();
						this.Show();
					}
				}
			}
		}
		#endregion
	}
}
